Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Xml.Serialization

Namespace vb.Models
    <XmlRoot("P")>
    Public Class PaymentData
        Public Enum FormaPagoType
            GPY
            APY
            C2P
            COD
            TCD
            BNPL
        End Enum

        <XmlElement()>
        Public business As BusinessData
        <XmlElement("nb_fpago")>
        Public paymentMethod As FormaPagoType
        <XmlElement()>
        Public version As String = "IntegraWPP"
        <XmlElement()>
        Public url As UrlData
        <XmlElement()>
        Public data3ds As D3DSData
        <XmlElement("datos_adicionales")>
        Public additionalData As DatosAdicionalesData
    End Class
End Namespace
