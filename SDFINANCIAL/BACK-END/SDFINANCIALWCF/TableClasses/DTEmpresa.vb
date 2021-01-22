<DataContract()>
Public Class DTEmpresa
#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Nombre As String
    Private _Cedula As String
    Private _Telefono As String
    Private _Fax As String
    Private _Email As String
    Private _Direccion As String
    Private _DireccionWeb As String
    Private _Activo As Integer
    Private _UltimaModificacion As Datetime
    Private _Logo As Byte()

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
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Cedula() As String
        Get
            Return _Cedula
        End Get
        Set(ByVal Value As String)
            _Cedula = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Telefono() As String
        Get
            Return _Telefono
        End Get
        Set(ByVal Value As String)
            _Telefono = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Fax() As String
        Get
            Return _Fax
        End Get
        Set(ByVal Value As String)
            _Fax = Value
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
    Public Property DireccionWeb() As String
        Get
            Return _DireccionWeb
        End Get
        Set(ByVal Value As String)
            _DireccionWeb = Value
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
    Public Property Logo() As Byte()
        Get
            Return _Logo
        End Get
        Set(ByVal Value As Byte())
            _Logo = Value
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
        _Nombre = ""
        _Cedula = ""
        _Telefono = ""
        _Fax = ""
        _Email = ""
        _Direccion = ""
        _DireccionWeb = ""
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
        _Logo = Nothing
    End Sub
#End Region
End Class
