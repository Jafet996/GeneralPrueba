Public Class TConnectionManager
#Region "Variables"
    Protected _Conexion As TConnection
#End Region
#Region "Propiedades"
    Public ReadOnly Property RowsAffected() As Long
        Get
            Return _Conexion.RowsAffected
        End Get
    End Property
#End Region
#Region "Constructores"
    Public Sub New()
    End Sub
    Public Sub New(ByVal pCnStr As String)
        _Conexion = New TConnection(pCnStr)
    End Sub
    Public ReadOnly Property ConexionObject() As System.Data.IDbConnection
        Get
            Return _Conexion._Conexion
        End Get
    End Property
#End Region
#Region "Metodos Privados"

#End Region
#Region "Metodos Publicos"
    Public Sub Open()
        If Not _Conexion.Open() Then
            Throw New Exception(_Conexion.MsgError)
        End If
    End Sub
    Public Sub Close()
        If Not _Conexion.Close() Then
            Throw New Exception(_Conexion.MsgError)
        End If
    End Sub
    Public Sub BeginTransaction()
        If Not _Conexion.BeginTransaction() Then
            Throw New Exception(_Conexion.MsgError)
        End If
    End Sub
    Public Sub CommitTransaction()
        If Not _Conexion.CommitTransaction Then
            Throw New Exception(_Conexion.MsgError)
        End If
    End Sub
    Public Sub RollBackTransaction()
        If Not _Conexion.RollBackTransaction Then
            Throw New Exception(_Conexion.MsgError)
        End If
    End Sub
    Public Sub Ejecutar(ByVal pQuery As String)
        If Not _Conexion.Ejecutar(pQuery) Then
            Throw New Exception(_Conexion.MsgError)
        End If
    End Sub
    Public Function Seleccionar(ByVal pQuery As String) As DataTable
        Dim Tabla As DataTable = Nothing

        Tabla = _Conexion.Seleccionar(pQuery)
        If _Conexion.MsgError <> "" Then
            Throw New Exception(_Conexion.MsgError)
        End If

        Return Tabla
    End Function
#End Region
End Class
