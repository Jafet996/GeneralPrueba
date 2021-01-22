<DataContract()>
Public Class DTPermiso
#Region "Definicion Variables Locales"

    Private _Permiso_Id As Integer
    Private _Modulo_Id As Integer
    Private _Nombre As String
    Private _Activo As Integer

#End Region
#Region "Definicion de propiedades"

    <DataMember()> _
    Public Property Permiso_Id() As Integer
        Get
            Return _Permiso_Id
        End Get
        Set(ByVal Value As Integer)
            _Permiso_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Modulo_Id() As Integer
        Get
            Return _Modulo_Id
        End Get
        Set(ByVal Value As Integer)
            _Modulo_Id = Value
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

#End Region
#Region "Constructores"
    Public Sub New()
        Inicializa()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _Permiso_Id = 0
        _Modulo_Id = 0
        _Nombre = ""
        _Activo = 0
    End Sub
#End Region
End Class
