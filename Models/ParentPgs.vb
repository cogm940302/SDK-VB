Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Xml.Serialization

Namespace vb.Models
    <XmlRoot("pgs")>
    Public Class ParentPgs
        <XmlElement()>
        Public data0 As String
        <XmlElement()>
        Public data As String
    End Class
End Namespace
