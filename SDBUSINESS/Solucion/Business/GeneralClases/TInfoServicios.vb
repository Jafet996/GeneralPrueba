Public Class TInfoServicios
#Region "Variales"
    Private _APEntidad As String
    Private _APPassword As String
    Private _WSRecargaTelefonica As String
    Private _CodigoDetallista As String
#End Region
#Region "Propiedades"
    Public Property APEntidad As String
        Get
            Return _APEntidad
        End Get
        Set(value As String)
            _APEntidad = value
        End Set
    End Property
    Public Property APPassword As String
        Get
            Return _APPassword
        End Get
        Set(value As String)
            _APPassword = value
        End Set
    End Property
    Public Property WSRecargaTelefonica As String
        Get
            Return _WSRecargaTelefonica
        End Get
        Set(value As String)
            _WSRecargaTelefonica = value
        End Set
    End Property
    Public Property CodigoDetallista As String
        Get
            Return _CodigoDetallista
        End Get
        Set(value As String)
            _CodigoDetallista = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New()
        _APEntidad = ""
        _APPassword = ""
        _WSRecargaTelefonica = ""
        _CodigoDetallista = ""
    End Sub
#End Region
End Class
