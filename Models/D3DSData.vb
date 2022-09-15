Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Xml.Serialization

Namespace vb.Models
    Public Class D3DSData
        <XmlElement("ml")>
        Public email As String
        <XmlElement("cl")>
        Public phone As String
        <XmlElement("dir")>
        Public address As String
        <XmlElement("cd")>
        Public city As String
        <XmlElement("est")>
        Public state As String
        <XmlElement("cp")>
        Public zipCode As String
        <XmlElement("idc")>
        Public countryCode As String
    End Class
End Namespace
