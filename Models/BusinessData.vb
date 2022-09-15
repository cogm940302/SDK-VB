Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Xml.Serialization

Namespace vb.Models
    Public Class BusinessData
        <XmlElement("id_company")>
        Public Property idCompany As String
        <XmlElement("id_branch")>
        Public Property idBranch As String
        <XmlElement()>
        Public Property user As String
        <XmlElement()>
        Public Property pwd As String
    End Class
End Namespace
