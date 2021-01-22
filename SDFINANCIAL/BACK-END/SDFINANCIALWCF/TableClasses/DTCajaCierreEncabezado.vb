<DataContract()>
Public Class DTCajaCierreEncabezado
#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _Usuario_Id As String
    Private _Cerrado As Integer
    Private _FechaCierre As Datetime
    Private _FechaApertura As Datetime
    Private _Efectivo As Double
    Private _Tarjeta As Double
    Private _Cheque As Double
    Private _Dolares As Double
    Private _Fondo As Double
    Private _Transferencia As Double
    Private _Deposito As Double
    Private _CajeroEfectivo As Double
    Private _CajeroTarjeta As Double
    Private _CajeroCheque As Double
    Private _CajeroDocumentos As Double
    Private _CajeroDolares As Double
    Private _TipoCambio As Double
    Private _UltimaModificacion As Datetime

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
    Public Property Caja_Id() As Integer
        Get
            Return _Caja_Id
        End Get
        Set(ByVal Value As Integer)
            _Caja_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Cierre_Id() As Integer
        Get
            Return _Cierre_Id
        End Get
        Set(ByVal Value As Integer)
            _Cierre_Id = Value
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
    Public Property Cerrado() As Integer
        Get
            Return _Cerrado
        End Get
        Set(ByVal Value As Integer)
            _Cerrado = Value
        End Set
    End Property
    <DataMember()> _
    Public Property FechaCierre() As Datetime
        Get
            Return _FechaCierre
        End Get
        Set(ByVal Value As Datetime)
            _FechaCierre = Value
        End Set
    End Property
    <DataMember()> _
    Public Property FechaApertura() As Datetime
        Get
            Return _FechaApertura
        End Get
        Set(ByVal Value As Datetime)
            _FechaApertura = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Efectivo() As Double
        Get
            Return _Efectivo
        End Get
        Set(ByVal Value As Double)
            _Efectivo = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Tarjeta() As Double
        Get
            Return _Tarjeta
        End Get
        Set(ByVal Value As Double)
            _Tarjeta = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Cheque() As Double
        Get
            Return _Cheque
        End Get
        Set(ByVal Value As Double)
            _Cheque = Value
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
    Public Property Fondo() As Double
        Get
            Return _Fondo
        End Get
        Set(ByVal Value As Double)
            _Fondo = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Transferencia() As Double
        Get
            Return _Transferencia
        End Get
        Set(ByVal Value As Double)
            _Transferencia = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Deposito() As Double
        Get
            Return _Deposito
        End Get
        Set(ByVal Value As Double)
            _Deposito = Value
        End Set
    End Property
    <DataMember()> _
    Public Property CajeroEfectivo() As Double
        Get
            Return _CajeroEfectivo
        End Get
        Set(ByVal Value As Double)
            _CajeroEfectivo = Value
        End Set
    End Property
    <DataMember()> _
    Public Property CajeroTarjeta() As Double
        Get
            Return _CajeroTarjeta
        End Get
        Set(ByVal Value As Double)
            _CajeroTarjeta = Value
        End Set
    End Property
    <DataMember()> _
    Public Property CajeroCheque() As Double
        Get
            Return _CajeroCheque
        End Get
        Set(ByVal Value As Double)
            _CajeroCheque = Value
        End Set
    End Property
    <DataMember()> _
    Public Property CajeroDocumentos() As Double
        Get
            Return _CajeroDocumentos
        End Get
        Set(ByVal Value As Double)
            _CajeroDocumentos = Value
        End Set
    End Property
    <DataMember()> _
    Public Property CajeroDolares() As Double
        Get
            Return _CajeroDolares
        End Get
        Set(ByVal Value As Double)
            _CajeroDolares = Value
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
    Public Property UltimaModificacion() As Datetime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As Datetime)
            _UltimaModificacion = Value
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
        _Caja_Id = 0
        _Cierre_Id = 0
        _Usuario_Id = ""
        _Cerrado = 0
        _FechaCierre = CDate("1900/01/01")
        _FechaApertura = CDate("1900/01/01")
        _Efectivo = 0.0
        _Tarjeta = 0.0
        _Cheque = 0.0
        _Dolares = 0.0
        _Fondo = 0.0
        _Transferencia = 0.0
        _Deposito = 0.0
        _CajeroEfectivo = 0.0
        _CajeroTarjeta = 0.0
        _CajeroCheque = 0.0
        _CajeroDocumentos = 0.0
        _CajeroDolares = 0.0
        _TipoCambio = 0.0
        _UltimaModificacion = CDate("1900/01/01")
    End Sub
#End Region
End Class
