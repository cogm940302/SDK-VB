Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Xml.Linq
Imports System.Xml.Serialization

Namespace vb.Models
    <XmlRoot("P_RESPONSE")>
    Public Class GenUrlResponse
        <XmlElement("cd_response")>
        Public Property cdResponse As String
        <XmlElement("nb_response")>
        Public Property nbResponse As String
        <XmlElement("nb_url")>
        Public Property nbUrl As String
    End Class
End Namespace
