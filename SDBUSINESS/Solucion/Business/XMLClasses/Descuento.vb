Imports System.Xml.Serialization

Public Class Descuento
    Public Property MontoDescuento As Double
    Public Property NaturalezaDescuento As String
    Public Sub New()
        Me.MontoDescuento = 0
        Me.NaturalezaDescuento = String.Empty
    End Sub
End Class
