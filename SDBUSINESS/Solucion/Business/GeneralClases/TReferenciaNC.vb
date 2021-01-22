Public Class TReferenciaNC
    Public Property Fecha As Date
    Public Property Tipo As String = String.Empty
    Public Property Documento As String = String.Empty
    Public Property Razon As String = String.Empty
    Public Property Codigo As String = String.Empty

    Public Sub New()
        Fecha = #01/01/1900#
        Tipo = String.Empty
        Documento = String.Empty
        Razon = String.Empty
        Codigo = String.Empty
    End Sub
End Class
