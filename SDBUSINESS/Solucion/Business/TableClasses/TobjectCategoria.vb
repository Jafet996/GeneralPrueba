Public Class TobjectCategoria
#Region "Definicion Variables Locales"
    Private _ok As Boolean
    Private _message As String
    Private _result As List(Of TCategorias)

#End Region
#Region "Definicion de propiedades"
    Public Property ok() As Boolean
        Get
            Return _ok
        End Get
        Set(ByVal Value As Boolean)
            _ok = Value
        End Set
    End Property

    Public Property result() As List(Of TCategorias)
        Get
            Return _result
        End Get
        Set(ByVal Value As List(Of TCategorias))
            _result = Value
        End Set
    End Property
    Public Property message() As String
        Get
            Return _message
        End Get
        Set(ByVal Value As String)
            _message = Value
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
        _ok = False
        _message = ""
    End Sub
#End Region

End Class
