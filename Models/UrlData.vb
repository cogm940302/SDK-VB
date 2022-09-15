Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Xml.Serialization

Namespace vb.Models
    Public Class UrlData
        Public Enum MonedaType
            MXN
            USD
        End Enum

        <XmlElement()>
        Public Property reference As String
        <XmlElement()>
        Public Property amount As Double
        <XmlElement()>
        Public Property moneda As MonedaType
        <XmlElement()>
        Public Property canal As String
        <XmlElement("omitir_notif_default")>
        Public Property omitNotification As Integer
        <XmlElement("promociones")>
        Public Property promotions As String
        <XmlElement("id_promotion")>
        Public Property idPromotion As String
        <XmlElement("st_correo")>
        Public Property stEmail As Integer
        <XmlElement("fh_vigencia")>
        Public expirationDate As DateTime? = Nothing
        <XmlElement("mail_cliente")>
        Public Property clientEmail As String
        <XmlElement("prepago")>
        Public Property prepaid As Integer

        Public Sub SetPromotions(ByVal promotion As String())
            Dim promos As String = ""

            For Each promo As String In promotion
                promos += promo & ","
            Next

            Me.promotions = promos.Substring(0, promos.Length - 1)
        End Sub
    End Class
End Namespace
