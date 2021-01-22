<DataContract()>
Public Class DTTipoCambio
#Region "Definicion Variables Locales"

    Private _TipoCambio_Id As Integer
    Private _Fecha As Datetime
    Private _Compra As Double
    Private _Venta As Double

#End Region
#Region "Definicion de propiedades"

    <DataMember()> _
    Public Property TipoCambio_Id() As Integer
        Get
            Return _TipoCambio_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoCambio_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Fecha() As Datetime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As Datetime)
            _Fecha = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Compra() As Double
        Get
            Return _Compra
        End Get
        Set(ByVal Value As Double)
            _Compra = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Venta() As Double
        Get
            Return _Venta
        End Get
        Set(ByVal Value As Double)
            _Venta = Value
        End Set
    End Property

#End Region
#Region "Constructores"
    Public Sub New()
        Inicializa()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _TipoCambio_Id = 0
        _Fecha = CDate("1900/01/01")
        _Compra = 0.0
        _Venta = 0.0
    End Sub
#End Region
End Class