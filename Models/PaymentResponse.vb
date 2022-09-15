Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Xml.Linq
Imports System.Xml
Imports System.Xml.Serialization

Namespace vb.Models
    <XmlRoot("CENTEROFPAYMENTS")>
    Public Class PaymentResponse
        <XmlElement()>
        Public reference As String
        <XmlElement()>
        Public response As String
        <XmlElement("foliocpagos")>
        Public folio As String
        <XmlElement("auth")>
        Public authorization As String
        <XmlElement("cd_response")>
        Public responseCode As String
        <XmlElement("cd_error")>
        Public errorCode As String
        <XmlElement("nb_error")>
        Public errorDescription As String
        <XmlElement()>
        Public time As TimeOnly
        <XmlElement("date")>
        Public fecha As DateOnly
        <XmlElement("nb_company")>
        Public companyName As String
        <XmlElement("nb_merchant")>
        Public merchantName As String
        <XmlElement("cc_type")>
        Public ccType As String
        <XmlElement("tp_operation")>
        Public operacion As String
        <XmlElement("cc_name ")>
        Public name As String
        <XmlElement("cc_number")>
        Public ccNumber As String
        <XmlElement("amount")>
        Public amount As Double
        <XmlElement("id_url")>
        Public idUrl As String
        <XmlElement("email")>
        Public eamil As String
        <XmlElement("cc_mask")>
        Public ccMask As String
        <XmlElement("datos_adicionales")>
        Public datosAdicionales As List(Of Data)
    End Class
End Namespace
