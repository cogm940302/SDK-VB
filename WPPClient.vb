
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Xml.Serialization
Imports FluentValidation
Imports SdkVisualBasic.vb.AES
Imports SdkVisualBasic.vb.ExceptionHandler
Imports SdkVisualBasic.vb.Http
Imports SdkVisualBasic.vb.Models
Imports SdkVisualBasic.vb.Validators

Namespace SdkVisualBasic
    Public Class WPPClient
        Private endpoint As String
        Private id As String
        Private aesHelper As AESHelper

        Public Sub New(ByVal endpoint As String, ByVal id As String, ByVal key As String)
            Me.endpoint = endpoint
            Me.id = id
            aesHelper = New AESHelper(key)
        End Sub

        Public Function GetUrlPayment(ByVal payment As PaymentData) As String
            ValidaRequest(payment)
            Dim body As String = BuildRequest(payment)
            body = "xml=" & body
            Dim httpHelper As HttpHelper = New HttpHelper(endpoint)
            Dim xmlResponse As String = httpHelper.Post(body).GetAwaiter().GetResult()

            If Not IsBase64String(xmlResponse) Then
                Throw New SdkException("Error al enviar el XML: " & xmlResponse)
            End If

            xmlResponse = aesHelper.Decrypt(xmlResponse)
            Dim serializer As XmlSerializer = New XmlSerializer(GetType(GenUrlResponse))
            Dim result As GenUrlResponse

            Try

                Using reader As TextReader = New StringReader(xmlResponse)
                    result = CType(serializer.Deserialize(reader), GenUrlResponse)
                End Using

            Catch ex As Exception
                Throw New SdkException("Error al interpretar el XML: " & xmlResponse)
            End Try

            If Not "success".Equals(result.cdResponse) Then
                Throw New SdkException(result.nbResponse)
            End If

            Return result.nbUrl
        End Function

        Private Sub ValidaRequest(ByVal payment As PaymentData)
            Dim businessDataValidator As BusinessDataValidator = New BusinessDataValidator()
            businessDataValidator.ValidateAndThrow(payment.business)

            If payment.data3ds IsNot Nothing Then
                Dim d3dsValidator As D3DSValidator = New D3DSValidator()
                d3dsValidator.ValidateAndThrow(payment.data3ds)
            End If

            Dim urlDataValidator As UrlValidator = New UrlValidator()
            urlDataValidator.ValidateAndThrow(payment.url)
        End Sub

        Private Function BuildRequest(ByVal payment As PaymentData) As String
            Dim xml As String = GenerateXML(payment)
            xml = aesHelper.Encrypt(xml)
            Dim parentPgs As ParentPgs = New ParentPgs()
            parentPgs.data = xml
            parentPgs.data0 = id
            xml = GenerateXML(parentPgs)
            Return xml
        End Function

        Private Function GenerateXML(ByVal payment As Object) As String
            Dim x As System.Xml.Serialization.XmlSerializer = New System.Xml.Serialization.XmlSerializer(payment.[GetType]())
            Dim stringWriter As TextWriter = New StringWriter()
            x.Serialize(stringWriter, payment)
            Dim xml As String = stringWriter.ToString()
            xml = xml.Replace("<?xml version=""1.0"" encoding=""utf-16""?>", "")
            xml = xml.Replace(" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""", "")
            Return xml
        End Function

        Public Shared Function IsBase64String(ByVal base64 As String) As Boolean
            base64 = base64.Trim()
            Return (base64.Length Mod 4 = 0) AndAlso Regex.IsMatch(base64, "^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None)
        End Function

        Public Function ProcessAfterPaymentResponse(ByVal bodyResponse As String) As PaymentResponse
            bodyResponse = DecryptResponse(bodyResponse)
            Dim response As PaymentResponse = Nothing
            Dim serializer As XmlSerializer = New XmlSerializer(GetType(PaymentResponse))

            Try

                Using reader As TextReader = New StringReader(bodyResponse)
                    response = CType(serializer.Deserialize(reader), PaymentResponse)
                End Using

            Catch ex As Exception
                Throw New SdkException("Error al interpretar el XML: " & bodyResponse)
            End Try

            Return response
        End Function

        Private Function DecryptResponse(ByVal bodyResponse As String) As String
            If bodyResponse.StartsWith("strResponse=") Then
                bodyResponse = bodyResponse.Replace("strResponse=", "")
            End If

            If bodyResponse.Contains("%") Then
                bodyResponse = HttpUtility.UrlDecode(bodyResponse, Encoding.UTF8)
            End If

            bodyResponse = aesHelper.Decrypt(bodyResponse)
            Return bodyResponse
        End Function
    End Class
End Namespace
