Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Xml.Serialization

Namespace vb.Models
    Public Class DatosAdicionalesData
        Public Class DataItem
            Public Sub New()
            End Sub

            <XmlElement()>
            Public id As Integer
            <XmlElement()>
            Public display As Boolean
            <XmlElement()>
            Public label As String
            <XmlElement()>
            Public value As String
        End Class

        <XmlElement()>
        Public data As HashSet(Of DataItem)

        Public Sub Append(ByVal aditionalData As DataItem)
            If data Is Nothing Then
                data = New HashSet(Of DataItem)()
            End If

            data.Add(aditionalData)
        End Sub
    End Class
End Namespace
