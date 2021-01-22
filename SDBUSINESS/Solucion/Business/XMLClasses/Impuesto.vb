Public Class Impuesto
    Public Property Codigo As String
    Public Property CodigoTarifa As String
    Public Property Tarifa As Double
    Public Property FactorIVA As Double
    Public Property Monto As Double
    Public Property MontoExportacion As Double
    Public Property Exoneracion As Exoneracion

    Public Sub New()
        Me.Codigo = String.Empty
        Me.CodigoTarifa = String.Empty
        Me.Tarifa = 0
        Me.FactorIVA = 0
        Me.Monto = 0
        Me.MontoExportacion = 0
        Me.Exoneracion = New Exoneracion()
    End Sub

End Class
