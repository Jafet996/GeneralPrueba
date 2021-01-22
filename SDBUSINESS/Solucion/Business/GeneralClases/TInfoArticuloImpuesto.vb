Public Class TInfoArticuloImpuesto
#Region "Definition of Properties"
    Public Property Codigo_Id As String
    Public Property Tarifa_Id As String
    Public Property Porcentaje As Double
    Public Property Monto As Double
#End Region
#Region "Definition of Constructors"
    Public Sub New()
        Inicializa()
    End Sub
#End Region
#Region "Definition of Private Methods"
    Private Sub Inicializa()
        Codigo_Id = ""
        Tarifa_Id = ""
        Porcentaje = 0.00
        Monto = 0.00
    End Sub
#End Region
End Class
