<DataContract()>
Public Class DTEmpresaCuenta
#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Cuenta_Id As Integer
    Private _Banco_Id As Integer
    Private _Cuenta As String
    Private _Moneda As Char
    Private _Activo As Integer
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
    Public Property Cuenta_Id() As Integer
        Get
            Return _Cuenta_Id
        End Get
        Set(ByVal Value As Integer)
            _Cuenta_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Banco_Id() As Integer
        Get
            Return _Banco_Id
        End Get
        Set(ByVal Value As Integer)
            _Banco_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Cuenta() As String
        Get
            Return _Cuenta
        End Get
        Set(ByVal Value As String)
            _Cuenta = Value
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
#End Region
#Region "Constructores"
    Public Sub New()
        Inicializa()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _Emp_Id = 0
        _Cuenta_Id = 0
        _Banco_Id = 0
        _Cuenta = ""
        _Moneda = ""
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
    End Sub
#End Region
End Class