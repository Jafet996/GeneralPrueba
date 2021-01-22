Public Class TLote
#Region "Variables"
    Private _Lote As String
    Private _Vencimiento As Date
    Private _Cantidad As Double
#End Region
#Region "Propiedades"
    Public Property Lote() As String
        Get
            Return _Lote
        End Get
        Set(ByVal value As String)
            _Lote = value
        End Set
    End Property
    Public Property Vencimiento() As Date
        Get
            Return _Vencimiento
        End Get
        Set(ByVal value As Date)
            _Vencimiento = value
        End Set
    End Property
    Public Property Cantidad As Double
        Get
            Return _Cantidad
        End Get
        Set(value As Double)
            _Cantidad = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New()
        _Lote = String.Empty
        _Vencimiento = #01/01/1900#
        _Cantidad = 0
    End Sub
#End Region
End Class
