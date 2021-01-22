<DataContract()>
Public Class DTCuenta
#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Cuenta_Id As String
    Private _Nombre As String
    Private _Tipo_Id As Integer
    Private _Clase_Id As Integer
    Private _Nivel As Integer
    Private _Padre_Id As String
    Private _Moneda As Char
    Private _AceptaMovimiento As Integer
    Private _Activo As Integer
    Private _UltimaModificacion As DateTime
    Private _SolicitaCentroCosto As Integer

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
    Public Property Cuenta_Id() As String
        Get
            Return _Cuenta_Id
        End Get
        Set(ByVal Value As String)
            _Cuenta_Id = Value
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
    Public Property Tipo_Id() As Integer
        Get
            Return _Tipo_Id
        End Get
        Set(ByVal Value As Integer)
            _Tipo_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Clase_Id() As Integer
        Get
            Return _Clase_Id
        End Get
        Set(ByVal Value As Integer)
            _Clase_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Nivel() As Integer
        Get
            Return _Nivel
        End Get
        Set(ByVal Value As Integer)
            _Nivel = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Padre_Id() As String
        Get
            Return _Padre_Id
        End Get
        Set(ByVal Value As String)
            _Padre_Id = Value
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
    Public Property AceptaMovimiento() As Integer
        Get
            Return _AceptaMovimiento
        End Get
        Set(ByVal Value As Integer)
            _AceptaMovimiento = Value
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
    Public Property UltimaModificacion() As DateTime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As DateTime)
            _UltimaModificacion = Value
        End Set
    End Property
    <DataMember()> _
    Public Property SolicitaCentroCosto() As Integer
        Get
            Return _SolicitaCentroCosto
        End Get
        Set(ByVal Value As Integer)
            _SolicitaCentroCosto = Value
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
        _Cuenta_Id = ""
        _Nombre = ""
        _Tipo_Id = 0
        _Clase_Id = 0
        _Nivel = 0
        _Padre_Id = ""
        _Moneda = ""
        _AceptaMovimiento = 0
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
        _SolicitaCentroCosto = 0
    End Sub
#End Region
End Class