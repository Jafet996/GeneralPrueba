Public Class Exoneracion
    Public Property TipoDocumento As String
    Public Property NumeroDocumento As String
    Public Property NombreInstitucion As String
    Public Property FechaEmision As DateTime
    Public Property PorcentajeExoneracion As Integer
    Public Property MontoExoneracion As Double
    Public Sub New()
        Me.TipoDocumento = String.Empty
        Me.NumeroDocumento = String.Empty
        Me.NombreInstitucion = String.Empty
        Me.FechaEmision = DateTime.Parse("1900/01/01")
        Me.PorcentajeExoneracion = 0
        Me.MontoExoneracion = 0
    End Sub
End Class
