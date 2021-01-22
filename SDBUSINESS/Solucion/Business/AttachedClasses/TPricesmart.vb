Imports System.Xml.Serialization

'<Serializable, XmlRoot(ElementName:="FreightInvoiceMessage" Namespace = "http://esb.dsv.com/CDM/FreightInvoiceMessage_V2")>
<XmlRoot("retail:Complemento")>
Public Class TPricesmart

    <XmlElement("retail:NumeroVendedor")>
    Public Property NumeroVendedor As String

    '-----------------------------------------------
    <XmlElement("retail:OrdenDeCompra")>
    Public Property OrdenDeCompra As TPricesmartOrdenDeCompra

    '------------------------------------------------

    '-----------------------------------------------
    <XmlElement("retail:LugarDeEntrega")>
    Public Property LugarDeEntrega As TPricesmartLugarDeEntrega
    '-----------------------------------------------


End Class
