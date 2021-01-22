Imports System.Xml.Serialization

Public Class LineaDetalle
    Public Property NumeroLinea As Integer
    <XmlElement("CodigoComercial")>
    Public Property CodigoComercial As List(Of CodigoComercial)
    Public Property PartidaArancelaria As String
    Public Property Codigo As String
    Public Property Cantidad As Double
    Public Property UnidadMedida As String
    Public Property UnidadMedidaComercial As String
    Public Property Detalle As String
    Public Property PrecioUnitario As Double
    Public Property MontoTotal As Double
    Public Property Descuento As Descuento
    Public Property BaseImponible As Double
    Public Property SubTotal As Double
    <XmlElement("Impuesto")>
    Public Property Impuesto As List(Of Impuesto)
    Public Property ImpuestoNeto As Double
    Public Property MontoTotalLinea As Double

    Public Sub New()
        Me.NumeroLinea = 0
        Me.PartidaArancelaria = String.Empty
        Me.Codigo = String.Empty
        Me.Cantidad = 0
        Me.UnidadMedida = String.Empty
        Me.UnidadMedidaComercial = String.Empty
        Me.Detalle = String.Empty
        Me.PrecioUnitario = 0
        Me.MontoTotal = 0
        Me.Descuento = New Descuento
        Me.SubTotal = 0
        Me.BaseImponible = 0
        Me.Impuesto = New List(Of Impuesto)()
        Me.ImpuestoNeto = 0
        Me.MontoTotalLinea = 0
    End Sub

End Class
