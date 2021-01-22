<DataContract()>
Public Class DTCliente
#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Cliente_Id As Integer
    Private _TipoIdentificacion_Id As Integer
    Private _Identificacion As String
    Private _Nombre As String
    Private _NombreComercial As String
    Private _Telefono1 As String
    Private _Telefono2 As String
    Private _Email As String
    Private _Direccion As String
    Private _Debitos As Double
    Private _Creditos As Double
    Private _Saldo As Double
    Private _DiasCredito As Integer
    Private _PorcMora As Double
    Private _DiasGraciaMora As Integer
    Private _AplicaMora As Integer
    Private _LimiteCredito As Double
    Private _CxC_Colones As String
    Private _CxC_Dolares As String
    Private _Activo As Integer
    Private _UltimaModificacion As DateTime
    Private _EsInterno As Boolean
    Private _Vendedor_Id As Integer
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
    Public Property Cliente_Id() As Integer
        Get
            Return _Cliente_Id
        End Get
        Set(ByVal Value As Integer)
            _Cliente_Id = Value
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
    Public Property DiasCredito() As Integer
        Get
            Return _DiasCredito
        End Get
        Set(ByVal Value As Integer)
            _DiasCredito = Value
        End Set
    End Property
    <DataMember()> _
    Public Property PorcMora() As Double
        Get
            Return _PorcMora
        End Get
        Set(ByVal Value As Double)
            _PorcMora = Value
        End Set
    End Property
    <DataMember()> _
    Public Property DiasGraciaMora() As Integer
        Get
            Return _DiasGraciaMora
        End Get
        Set(ByVal Value As Integer)
            _DiasGraciaMora = Value
        End Set
    End Property
    <DataMember()> _
    Public Property AplicaMora() As Integer
        Get
            Return _AplicaMora
        End Get
        Set(ByVal Value As Integer)
            _AplicaMora = Value
        End Set
    End Property
    <DataMember()> _
    Public Property LimiteCredito() As Double
        Get
            Return _LimiteCredito
        End Get
        Set(ByVal Value As Double)
            _LimiteCredito = Value
        End Set
    End Property
    <DataMember()> _
    Public Property CxC_Colones() As String
        Get
            Return _CxC_Colones
        End Get
        Set(ByVal Value As String)
            _CxC_Colones = Value
        End Set
    End Property
    <DataMember()> _
    Public Property CxC_Dolares() As String
        Get
            Return _CxC_Dolares
        End Get
        Set(ByVal Value As String)
            _CxC_Dolares = Value
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
    Public Property UltimaModificacion() As DateTime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As DateTime)
            _UltimaModificacion = Value
        End Set
    End Property

    <DataMember()>
    Public Property NombreComercial() As String
        Get
            Return _NombreComercial
        End Get
        Set(ByVal value As String)
            _NombreComercial = value
        End Set
    End Property

    <DataMember()>
    Public Property Vendedor_Id() As Integer
        Get
            Return _Vendedor_Id
        End Get

        Set(ByVal value As Integer)
            _Vendedor_Id = value
        End Set
    End Property

    <DataMember()>
    Public Property EsInterno() As Boolean
        Get
            Return _EsInterno
        End Get

        Set(ByVal value As Boolean)
            _EsInterno = value
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
        _Cliente_Id = 0
        _TipoIdentificacion_Id = 0
        _Identificacion = ""
        _Nombre = ""
        _NombreComercial = ""
        _Telefono1 = ""
        _Telefono2 = ""
        _Email = ""
        _Direccion = ""
        _Debitos = 0.0
        _Creditos = 0.0
        _Saldo = 0.0
        _DiasCredito = 0
        _PorcMora = 0.0
        _DiasGraciaMora = 0
        _AplicaMora = 0
        _LimiteCredito = 0.0
        _CxC_Colones = ""
        _CxC_Dolares = ""
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
        _Vendedor_Id = 1
        _EsInterno = False
    End Sub
#End Region
End Class