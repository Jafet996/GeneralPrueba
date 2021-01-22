<DataContract()>
Public Class DTProveedor
#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Prov_Id As Integer
    Private _TipoIdentificacion_Id As Integer
    Private _Identificacion As String
    Private _Nombre As String
    Private _Telefono1 As String
    Private _Telefono2 As String
    Private _Email As String
    Private _Direccion As String
    Private _Debitos As Double
    Private _Creditos As Double
    Private _Saldo As Double
    Private _CxP_Colones As String
    Private _CxP_Dolares As String
    Private _Activo As Integer
    Private _UltimaModificacion As DateTime
    Private _DiasCredito As Integer
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
    Public Property Prov_Id() As Integer
        Get
            Return _Prov_Id
        End Get
        Set(ByVal Value As Integer)
            _Prov_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property TipoIdentificacion_Id() As Integer
        Get
            Return _TipoIdentificacion_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoIdentificacion_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Identificacion() As String
        Get
            Return _Identificacion
        End Get
        Set(ByVal Value As String)
            _Identificacion = Value
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
    Public Property Telefono1() As String
        Get
            Return _Telefono1
        End Get
        Set(ByVal Value As String)
            _Telefono1 = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Telefono2() As String
        Get
            Return _Telefono2
        End Get
        Set(ByVal Value As String)
            _Telefono2 = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal Value As String)
            _Email = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal Value As String)
            _Direccion = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Debitos() As Double
        Get
            Return _Debitos
        End Get
        Set(ByVal Value As Double)
            _Debitos = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Creditos() As Double
        Get
            Return _Creditos
        End Get
        Set(ByVal Value As Double)
            _Creditos = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Saldo() As Double
        Get
            Return _Saldo
        End Get
        Set(ByVal Value As Double)
            _Saldo = Value
        End Set
    End Property
    <DataMember()> _
    Public Property CxP_Colones() As String
        Get
            Return _CxP_Colones
        End Get
        Set(ByVal Value As String)
            _CxP_Colones = Value
        End Set
    End Property
    <DataMember()> _
    Public Property CxP_Dolares() As String
        Get
            Return _CxP_Dolares
        End Get
        Set(ByVal Value As String)
            _CxP_Dolares = Value
        End Set
    End Property
    <DataMember()> _
        Public Property Activo() As Integer
        Get
            Return _Activo
        End Get
        Set(ByVal Value As Integer)
            _Activo = Value
        End Set
    End Property
    <DataMember()>
    Public Property UltimaModificacion() As Datetime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As Datetime)
            _UltimaModificacion = Value
        End Set
    End Property
    <DataMember()>
    Public Property DiasCredito() As Integer
        Get
            Return _DiasCredito
        End Get
        Set(ByVal Value As Integer)
            _DiasCredito = Value
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
        _Prov_Id = 0
        _TipoIdentificacion_Id = 0
        _Identificacion = ""
        _Nombre = ""
        _Telefono1 = ""
        _Telefono2 = ""
        _Email = ""
        _Direccion = ""
        _Debitos = 0.0
        _Creditos = 0.0
        _Saldo = 0.0
        _CxP_Colones = ""
        _CxP_Dolares = ""
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
        _DiasCredito = 0
    End Sub
#End Region
End Class