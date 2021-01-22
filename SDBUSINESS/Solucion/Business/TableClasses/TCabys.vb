Public Class TCabys


#Region "Definicion Variables Locales"

    Private _descripcion As String
    Private _categorias As List(Of String)
    Private _Articuloslist As List(Of TArticulo)
    Private _id As String

#End Region

#Region "Definicion de propiedades"
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal Value As String)
            _descripcion = Value
        End Set
    End Property

    Public Property Categorias() As List(Of String)
        Get
            Return _categorias
        End Get
        Set(ByVal Value As List(Of String))
            _categorias = Value
        End Set
    End Property

    Public Property Articulos() As List(Of TArticulo)
        Get
            Return _Articuloslist
        End Get
        Set(ByVal Value As List(Of TArticulo))
            _Articuloslist = Value
        End Set
    End Property

    Public Property Id() As String
        Get
            Return _id
        End Get
        Set(ByVal Value As String)
            _id = Value
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
        _descripcion = ""
        _id = ""
    End Sub
#End Region





End Class
