Public Class TClienteImpresion
#Region "Definicion Variables Locales"
    Private _Cliente_Id As String
    Private _Nombre As String
    Private _Direccion As String
    Private _Telefono As String
    Private _Email As String
    Private _Fecha As DateTime
#End Region

#Region "Definicion de propiedades"
    Public Property Cliente_Id As String
        Get
            Return _Cliente_Id
        End Get
        Set(ByVal value As String)
            _Cliente_Id = value
        End Set
    End Property
    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property
    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal Value As String)
            _Direccion = Value
        End Set
    End Property
    Public Property Telefono() As String
        Get
            Return _Telefono
        End Get
        Set(ByVal Value As String)
            _Telefono = Value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal Value As String)
            _Email = Value
        End Set
    End Property
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As DateTime)
            _Fecha = Value
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
        _Cliente_Id = ""
        _Nombre = ""
        _Direccion = ""
        _Telefono = ""
        _Email = ""
        _Fecha = #1/1/1900#
    End Sub
#End Region
End Class
