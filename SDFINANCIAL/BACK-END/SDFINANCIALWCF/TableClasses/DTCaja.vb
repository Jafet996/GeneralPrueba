<DataContract()>
Public Class DTCaja
#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Caja_Id As Integer
    Private _Nombre As String
    Private _Abierta As Integer
    Private _Cierre_Id As Integer
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
    Public Property Caja_Id() As Integer
        Get
            Return _Caja_Id
        End Get
        Set(ByVal Value As Integer)
            _Caja_Id = Value
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
    Public Property Abierta() As Integer
        Get
            Return _Abierta
        End Get
        Set(ByVal Value As Integer)
            _Abierta = Value
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
        _Caja_Id = 0
        _Nombre = ""
        _Abierta = 0
        _Cierre_Id = 0
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
    End Sub
#End Region
End Class