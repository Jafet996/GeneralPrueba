<DataContract()>
Public Class DTCxPSolicitudPago
#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Solicitud_Id As Long
    Private _Prov_Id As Integer
    Private _Tipo_Id As Integer
    Private _Mov_Id As Long
    Private _Fecha As Datetime
    Private _Monto As Double
    Private _Moneda As Char
    Private _TipoCambio As Double
    Private _Dolares As Double
    Private _Usuario_Id As String
    Private _UltimaModificacion As DateTime
    Private _PagoMonto As Double
    Private _PagoDolares As Double
    Private _Diferencial As Double
    Private _ListaMovimientos As New List(Of DTCxPMovimientoLinea)
#End Region
#Region "Definicion de propiedades"
    <DataMember()> _
    Public Property Emp_Id() As Integer
        Get
            Return _Emp_Id
        End Get
        Set(ByVal Value As Integer)
            _Emp_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Solicitud_Id() As Long
        Get
            Return _Solicitud_Id
        End Get
        Set(ByVal Value As Long)
            _Solicitud_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Prov_Id() As Integer
        Get
            Return _Prov_Id
        End Get
        Set(ByVal Value As Integer)
            _Prov_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Tipo_Id() As Integer
        Get
            Return _Tipo_Id
        End Get
        Set(ByVal Value As Integer)
            _Tipo_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Mov_Id() As Long
        Get
            Return _Mov_Id
        End Get
        Set(ByVal Value As Long)
            _Mov_Id = Value
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
    Public Property Monto() As Double
        Get
            Return _Monto
        End Get
        Set(ByVal Value As Double)
            _Monto = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Moneda() As Char
        Get
            Return _Moneda
        End Get
        Set(ByVal Value As Char)
            _Moneda = Value
        End Set
    End Property
    <DataMember()> _
    Public Property TipoCambio() As Double
        Get
            Return _TipoCambio
        End Get
        Set(ByVal Value As Double)
            _TipoCambio = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Dolares() As Double
        Get
            Return _Dolares
        End Get
        Set(ByVal Value As Double)
            _Dolares = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Usuario_Id() As String
        Get
            Return _Usuario_Id
        End Get
        Set(ByVal Value As String)
            _Usuario_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property UltimaModificacion() As Datetime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As Datetime)
            _UltimaModificacion = Value
        End Set
    End Property
    <DataMember()> _
    Public Property PagoMonto As Double
        Get
            Return _PagoMonto
        End Get
        Set(value As Double)
            _PagoMonto = value
        End Set
    End Property
    <DataMember()> _
    Public Property PagoDolares As Double
        Get
            Return _PagoDolares
        End Get
        Set(value As Double)
            _PagoDolares = value
        End Set
    End Property
    <DataMember()> _
    Public Property Diferencial As Double
        Get
            Return _Diferencial
        End Get
        Set(value As Double)
            _Diferencial = value
        End Set
    End Property
    <DataMember()> _
    Public Property ListaMovimientos As List(Of DTCxPMovimientoLinea)
        Get
            Return _ListaMovimientos
        End Get
        Set(value As List(Of DTCxPMovimientoLinea))
            _ListaMovimientos = value
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
        _Emp_Id = 0
        _Solicitud_Id = 0
        _Prov_Id = 0
        _Tipo_Id = 0
        _Mov_Id = 0
        _Fecha = CDate("1900/01/01")
        _Monto = 0.0
        _Moneda = ""
        _TipoCambio = 0.0
        _Dolares = 0.0
        _Usuario_Id = ""
        _UltimaModificacion = CDate("1900/01/01")
        _PagoMonto = 0
        _PagoDolares = 0
        _Diferencial = 0.0
        _ListaMovimientos.Clear()
    End Sub
#End Region
End Class