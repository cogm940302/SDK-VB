Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Net.Http.Json
Imports vb.ExceptionHandler
Imports SdkVisualBasic.vb.ExceptionHandler

Namespace vb.Http
    Friend Class HttpHelper
        Private endpoint As String
        Private client As HttpClient

        Public Sub New(ByVal endpoint As String)
            Me.endpoint = endpoint
            client = New HttpClient()
        End Sub

        Public Async Function Post(ByVal message As String) As Task(Of String)
            Try
                Dim nvc = New List(Of KeyValuePair(Of String, String))()
                nvc.Add(New KeyValuePair(Of String, String)("xml", message))
                Dim client = New HttpClient()
                Dim req = New HttpRequestMessage(HttpMethod.Post, endpoint) With {
                    .Content = New FormUrlEncodedContent(nvc)
                }
                Dim res = Await client.SendAsync(req)
                Dim content = Await res.Content.ReadAsStringAsync()
                Return content
            Catch ex As Exception
                Throw New SdkException("Error en los datos de envio: " & ex.Message)
            End Try
        End Function
    End Class
End Namespace
