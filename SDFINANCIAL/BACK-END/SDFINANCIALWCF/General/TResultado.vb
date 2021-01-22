<DataContract>
Public Class TResultado
#Region "Definicion Variables Locales"
    Private _ErrorCode As String
    Private _ErrorDescription As String
    Private _Datos As DataTable
    Private _Valor As String
    Private _RowsAffected As Long
#End Region
#Region "Definicion de propiedades"
    Public Property ErrorCode As String
        Get
            Return _ErrorCode
        End Get
        Set(value As String)
            _ErrorCode = value
        End Set
    End Property
    Public Property ErrorDescription As String
        Get
            Return _ErrorDescription
        End Get
        Set(value As String)
            _ErrorDescription = value
        End Set
    End Property
    Public Property Datos As DataTable
        Get
            Return _Datos
        End Get
        Set(value As DataTable)
            _Datos = value
        End Set
    End Property
    Public Property Valor As String
        Get
            Return _Valor
        End Get
        Set(value As String)
            _Valor = value
        End Set
    End Property
    Public Property RowsAffected As Long
        Get
            Return _RowsAffected
        End Get
        Set(value As Long)
            _RowsAffected = value
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
        _ErrorCode = String.Empty
        _ErrorDescription = String.Empty
        _Datos = Nothing
        _Valor = String.Empty
        _RowsAffected = 0
    End Sub
#End Region
End Class