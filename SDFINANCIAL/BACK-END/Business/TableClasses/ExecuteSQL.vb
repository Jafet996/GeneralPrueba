Public Class ExecuteSQL
#Region "Variables"
    Private _Cn As Connection.TConnectionManager
    Private _Datos As DataTable
#End Region
#Region "Propiedades"
    Public ReadOnly Property Datos
        Get
            Return _Datos
        End Get
    End Property
    Public ReadOnly Property RowsAffected() As Long
        Get
            Return _Cn.RowsAffected
        End Get
    End Property
#End Region
#Region "Constructores"
    Public Sub New()
        _Cn = New Connection.TConnectionManager(GetConnectionString())
        Inicializa()
    End Sub
    Public Sub New(ByVal pCnStr As String)
        _Cn = New Connection.TConnectionManager(pCnStr)
        Inicializa()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _Datos = New DataTable
        FormatearOpcionesRegionales()
    End Sub
#End Region
#Region "Metodos Publicos"
    Public Function ExecuteQuery(pQuery As String) As String
        Try
            _Cn.Open()

            _Cn.BeginTransaction()

            If pQuery.Trim.Equals(String.Empty) Then
                ExecuteQuery = String.Empty
            End If

            _Cn.Ejecutar(pQuery)

            _Cn.CommitTransaction()

            Return String.Empty
        Catch ex As Exception
            _Cn.RollBackTransaction()
            Return ex.Message
        Finally
            _Cn.Close()
        End Try
    End Function
    Public Function SelectQuery(pQuery As String) As String
        Try
            _Cn.Open()

            _Datos = _Cn.Seleccionar(pQuery).Copy

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            _Cn.Close()
        End Try
    End Function
#End Region
End Class