Public Class TGarantiaInfo
    Public Property Art_Id As String
    Public Property Fecha As Date
    Public Property OrdenNumero As String
    Public Property Vencimiento As Date
    Public Sub New()
        Art_Id = String.Empty
        Fecha = #01/01/1900#
        OrdenNumero = String.Empty
        Vencimiento = #01/01/1900#
    End Sub

End Class
