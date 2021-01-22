Imports System.Xml.Serialization

Public Class DetalleServicio
    <XmlElement("LineaDetalle")>
    Public Property LineaDetalle As List(Of LineaDetalle)

    Public Sub New()
        Me.LineaDetalle = New List(Of LineaDetalle)()
    End Sub
End Class
