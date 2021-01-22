Public Class TInfoArticuloConjunto
#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Art_Id As String
    Private _ArtConjunto_Id As String
    Private _Cantidad As Integer
    Private _UltimaModificacion As DateTime
#End Region

#Region "Definicion de propiedades"
    Public Property Emp_Id() As Integer
        Get
            Return _Emp_Id
        End Get
        Set(ByVal Value As Integer)
            _Emp_Id = Value
        End Set
    End Property
    Public Property Art_Id() As String
        Get
            Return _Art_Id
        End Get
        Set(ByVal Value As String)
            _Art_Id = Value
        End Set
    End Property
    Public Property ArtConjunto_Id() As String
        Get
            Return _ArtConjunto_Id
        End Get
        Set(ByVal Value As String)
            _ArtConjunto_Id = Value
        End Set
    End Property
    Public Property Cantidad() As Integer
        Get
            Return _Cantidad
        End Get
        Set(ByVal Value As Integer)
            _Cantidad = Value
        End Set
    End Property
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
        _Art_Id = ""
        _ArtConjunto_Id = ""
        _Cantidad = 0
        _UltimaModificacion = CDate("1900/01/01")
    End Sub
#End Region
End Class
