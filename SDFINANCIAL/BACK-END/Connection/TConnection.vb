Public Class TConnection
#Region "Variables"
    Protected _CnStr As String
    Protected _MsgError As String
    Public _Conexion As System.Data.IDbConnection
    Protected _Command As System.Data.IDbCommand
    Protected _Adapter As System.Data.IDbDataAdapter
    Protected _Tran As System.Data.IDbTransaction
    Protected _RowsAffected As Long
#End Region
#Region "Propiedades"
    Public ReadOnly Property MsgError() As String
        Get
            Return DepuraTexto(_MsgError)
        End Get
    End Property
    Public ReadOnly Property RowsAffected() As Long
        Get
            Return _RowsAffected
        End Get
    End Property
#End Region
#Region "Constructores"
    Public Sub New(ByVal pCnStr As String)
        Try
            _MsgError = ""
            _CnStr = pCnStr
            _RowsAffected = 0

            _Conexion = New System.Data.SqlClient.SqlConnection(pCnStr)


        Catch ex As Exception
            _MsgError = ex.Message
        End Try
    End Sub
#End Region
#Region "Metodos Privados"
    Private Function DepuraTexto(ByVal pTexto As String) As String
        Try
            pTexto = pTexto.Replace("'", " ")
            Return pTexto
        Catch ex As Exception
            Return pTexto
        End Try
    End Function
    Protected Function Crear_Command(ByVal Query As String) As System.Data.IDbCommand
        Dim Command As System.Data.IDbCommand = Nothing

        Command = New System.Data.SqlClient.SqlCommand(Query, _Conexion)

        Return Command
    End Function
    Protected Function Crear_Adapter() As System.Data.IDbDataAdapter
        Dim Adapter As System.Data.IDbDataAdapter = Nothing
        Adapter = New System.Data.SqlClient.SqlDataAdapter(_Command)

        Return Adapter
    End Function
#End Region
#Region "Metodos Publicos"
    Public Function Open() As Boolean
        Try
            _MsgError = ""
            If (_Conexion.State = ConnectionState.Closed) Then
                _Conexion.Open()
            End If
            Return True
        Catch ex As Exception
            _MsgError = ex.Message
            Return False
        End Try
    End Function
    Public Function Close() As Boolean
        Try
            _MsgError = ""
            _Conexion.Close()

            Return True
        Catch ex As Exception
            _MsgError = ex.Message
            Return False
        End Try
    End Function
    Public Function BeginTransaction() As Boolean
        Try
            _MsgError = ""
            _Tran = _Conexion.BeginTransaction()
            Return True
        Catch Ex As Exception
            _MsgError = Ex.Message
            Return False
        End Try
    End Function
    Public Function CommitTransaction() As Boolean
        Try
            _MsgError = ""
            _Tran.Commit()
            _Tran = Nothing
            Return True
        Catch ex As Exception
            _MsgError = ex.Message
            Return False
        End Try
    End Function
    Public Function RollBackTransaction() As Boolean
        Try
            _MsgError = ""
            _Tran.Rollback()
            _Tran = Nothing
            Return True
        Catch ex As Exception
            _MsgError = ex.Message
            Return False
        End Try
    End Function
    Public Function Seleccionar(ByVal Query As String) As DataTable
        Dim Datos As DataSet
        Dim DT As DataTable = Nothing
        _MsgError = ""
        _RowsAffected = 0
        Try
            If IsNothing(_Command) Then
                _Command = Crear_Command(Query)
            Else
                _Command.CommandText = Query
            End If
            _Command.CommandTimeout = 0
            If Not (_Tran Is Nothing) Then
                _Command.Transaction = _Tran
            End If
            _Adapter = Me.Crear_Adapter()
            Datos = New DataSet
            _Adapter.Fill(Datos)
            DT = Datos.Tables(0).Copy

            If Not IsNothing(DT) Then
                _RowsAffected = DT.Rows.Count
            End If
        Catch Ex As Exception
            _MsgError = Ex.Message
        End Try
        Return DT
    End Function
    Public Function Ejecutar(ByVal pQuery As String) As Boolean
        _MsgError = ""
        _RowsAffected = 0
        Try
            If IsNothing(_Command) Then
                _Command = Crear_Command(pQuery)
            Else
                _Command.CommandText = pQuery
            End If
            _Command.CommandTimeout = 0
            If Not _Tran Is Nothing Then
                _Command.Transaction = _Tran
            End If
            _RowsAffected = _Command.ExecuteNonQuery()
            Return True
        Catch Ex As Exception
            _MsgError = Ex.Message
            Return False
        End Try
    End Function
#End Region
End Class
