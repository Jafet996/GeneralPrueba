<DataContract()>
Public Class DTMaquinaConfiguracion
#Region "Definicion Variables Locales"

    Private _MAC_Address As String
    Private _Nombre As String
    Private _Caja_Id As Integer
    Private _ClienteDefault As Integer
    Private _ComPort As String
    Private _ConfirmaImpresionFactura As Integer
    Private _Emp_Id As Integer
    Private _FacturaContadoSolicitaCliente As Integer
    Private _ImprimeCodigoArticulo As Integer
    Private _ImprimePrefactura As Integer
    Private _Interfaz As Integer
    Private _ParallePort As String
    Private _PrefacturaTipoEntrega As Integer
    Private _PrinterName As String
    Private _PrintLocation As Integer
    Private _URLTipoCambio As String
    Private _FechaIngreso As Datetime

#End Region
#Region "Definicion de propiedades"

    <DataMember()> _
    Public Property MAC_Address() As String
        Get
            Return _MAC_Address
        End Get
        Set(ByVal Value As String)
            _MAC_Address = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
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
    Public Property ClienteDefault() As Integer
        Get
            Return _ClienteDefault
        End Get
        Set(ByVal Value As Integer)
            _ClienteDefault = Value
        End Set
    End Property
    <DataMember()> _
    Public Property ComPort() As String
        Get
            Return _ComPort
        End Get
        Set(ByVal Value As String)
            _ComPort = Value
        End Set
    End Property
    <DataMember()> _
    Public Property ConfirmaImpresionFactura() As Integer
        Get
            Return _ConfirmaImpresionFactura
        End Get
        Set(ByVal Value As Integer)
            _ConfirmaImpresionFactura = Value
        End Set
    End Property
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
    Public Property FacturaContadoSolicitaCliente() As Integer
        Get
            Return _FacturaContadoSolicitaCliente
        End Get
        Set(ByVal Value As Integer)
            _FacturaContadoSolicitaCliente = Value
        End Set
    End Property
    <DataMember()> _
    Public Property ImprimeCodigoArticulo() As Integer
        Get
            Return _ImprimeCodigoArticulo
        End Get
        Set(ByVal Value As Integer)
            _ImprimeCodigoArticulo = Value
        End Set
    End Property
    <DataMember()> _
    Public Property ImprimePrefactura() As Integer
        Get
            Return _ImprimePrefactura
        End Get
        Set(ByVal Value As Integer)
            _ImprimePrefactura = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Interfaz() As Integer
        Get
            Return _Interfaz
        End Get
        Set(ByVal Value As Integer)
            _Interfaz = Value
        End Set
    End Property
    <DataMember()> _
    Public Property ParallePort() As String
        Get
            Return _ParallePort
        End Get
        Set(ByVal Value As String)
            _ParallePort = Value
        End Set
    End Property
    <DataMember()> _
    Public Property PrefacturaTipoEntrega() As Integer
        Get
            Return _PrefacturaTipoEntrega
        End Get
        Set(ByVal Value As Integer)
            _PrefacturaTipoEntrega = Value
        End Set
    End Property
    <DataMember()> _
    Public Property PrinterName() As String
        Get
            Return _PrinterName
        End Get
        Set(ByVal Value As String)
            _PrinterName = Value
        End Set
    End Property
    <DataMember()> _
    Public Property PrintLocation() As Integer
        Get
            Return _PrintLocation
        End Get
        Set(ByVal Value As Integer)
            _PrintLocation = Value
        End Set
    End Property
    <DataMember()> _
    Public Property URLTipoCambio() As String
        Get
            Return _URLTipoCambio
        End Get
        Set(ByVal Value As String)
            _URLTipoCambio = Value
        End Set
    End Property
    <DataMember()> _
    Public Property FechaIngreso() As Datetime
        Get
            Return _FechaIngreso
        End Get
        Set(ByVal Value As Datetime)
            _FechaIngreso = Value
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
        _MAC_Address = ""
        _Nombre = ""
        _Caja_Id = 0
        _ClienteDefault = 0
        _ComPort = ""
        _ConfirmaImpresionFactura = 0
        _Emp_Id = 0
        _FacturaContadoSolicitaCliente = 0
        _ImprimeCodigoArticulo = 0
        _ImprimePrefactura = 0
        _Interfaz = 0
        _ParallePort = ""
        _PrefacturaTipoEntrega = 0
        _PrinterName = ""
        _PrintLocation = 0
        _URLTipoCambio = ""
        _FechaIngreso = CDate("1900/01/01")
    End Sub
#End Region
End Class
