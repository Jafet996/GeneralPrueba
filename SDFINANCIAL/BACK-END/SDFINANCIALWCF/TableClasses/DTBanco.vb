<DataContract()>
Public Class DTBanco
#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Banco_Id As Integer
    Private _Nombre As String
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
    Public Property Banco_Id() As Integer
        Get
            Return _Banco_Id
        End Get
        Set(ByVal Value As Integer)
            _Banco_Id = Value
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
        _Banco_Id = 0
        _Nombre = ""
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
    End Sub
#End Region
End Class