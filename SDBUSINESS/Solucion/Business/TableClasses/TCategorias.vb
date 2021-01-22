Public Class TCategorias
#Region "Definicion Variables Locales"
    Private _categoria_id As Long
    Private _descripcion As String
#End Region


#Region "Definicion de propiedades"

    Public Property categoria_id() As Long
        Get
            Return _categoria_id
        End Get
        Set(ByVal Value As Long)
            _categoria_id = Value
        End Set
    End Property


    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal Value As String)
            _descripcion = Value
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
        _categoria_id = 0
        _descripcion = ""

    End Sub
#End Region


End Class
