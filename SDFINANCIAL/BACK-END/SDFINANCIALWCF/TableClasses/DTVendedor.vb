<DataContract()>
Public Class DTVendedor
#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Vendedor_Id As Integer
    Private _Nombre As String
    Private _Activo As Integer
    Private _Comision As Double
    Private _UltimaModificacion As DateTime
#End Region
#Region "Definicion de propiedades"
    <DataMember()>
    Public Property Emp_Id() As Integer
        Get
            Return _Emp_Id
        End Get
        Set(ByVal Value As Integer)
            _Emp_Id = Value
        End Set
    End Property
    <DataMember()>
    Public Property Vendedor_Id() As Integer
        Get
            Return _Vendedor_Id
        End Get
        Set(ByVal Value As Integer)
            _Vendedor_Id = Value
        End Set
    End Property
    <DataMember()>
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
        End Set
    End Property
    <DataMember()>
    Public Property Activo() As Integer
        Get
            Return _Activo
        End Get
        Set(ByVal Value As Integer)
            _Activo = Value
        End Set
    End Property
    <DataMember()>
    Public Property Comision() As Double
        Get
            Return _Comision
        End Get
        Set(ByVal Value As Double)
            _Comision = Value
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
#End Region
#Region "Constructores"
    Public Sub New()
        Inicializa()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _Emp_Id = 0
        _Vendedor_Id = 0
        _Nombre = ""
        _Activo = 0
        _Comision = 0.00
        _UltimaModificacion = CDate("1900/01/01")
    End Sub
#End Region
End Class
