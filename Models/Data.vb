Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Xml.Serialization

Namespace vb.Models
    Public Class Data
        <XmlElement()>
        Public Property label As String
        <XmlElement()>
        Public Property value As String
    End Class
End Namespace
