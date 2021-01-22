Imports System.Xml.Serialization

Public Class TPricesmartLugarDeEntrega
    <XmlElement("retail:GLNLugarDeEntrega")>
    Public Property GLNLugarDeEntrega As String

    <XmlElement("retail:DireccionLugarDeEntrega")>
    Public Property DireccionLugarDeEntrega As String
End Class
