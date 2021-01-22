Public Class TUsuarioCodigoPermiso
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Usuario_Id As String
    Private _Codigo_Id As Integer
    Private _Codigo As String
    Private _Activo As Integer
    Private _Fecha As Datetime
    Private _FechaVencimiento As Datetime
    Private _Data As DataSet

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
    Public Property Usuario_Id() As String
        Get
            Return _Usuario_Id
        End Get
        Set(ByVal Value As String)
            _Usuario_Id = Value
        End Set
    End Property
    Public Property Codigo_Id() As Integer
        Get
            Return _Codigo_Id
        End Get
        Set(ByVal Value As Integer)
            _Codigo_Id = Value
        End Set
    End Property
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal Value As String)
            _Codigo = Value
        End Set
    End Property
    Public Property Activo() As Integer
        Get
            Return _Activo
        End Get
        Set(ByVal Value As Integer)
            _Activo = Value
        End Set
    End Property
    Public Property Fecha() As Datetime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As Datetime)
            _Fecha = Value
        End Set
    End Property
    Public Property FechaVencimiento() As Datetime
        Get
            Return _FechaVencimiento
        End Get
        Set(ByVal Value As Datetime)
            _FechaVencimiento = Value
        End Set
    End Property
    Public ReadOnly Property Data() As DataSet
        Get
            Return _Data
        End Get
    End Property
    Public ReadOnly Property RowsAffected() As Long
        Get
            Return Cn.RowsAffected
        End Get
    End Property


#End Region
#Region "Constructores"
    Public Sub New(pEmp_Id As Integer)
        MyBase.New()
        Inicializa()
        _Emp_Id = pEmp_Id
    End Sub
    Public Sub New(pEmp_Id As Integer, ByVal pCnStr As String)
        MyBase.New(pCnStr)
        Inicializa()
        _Emp_Id = pEmp_Id
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _Emp_Id = 0
        _Usuario_Id = ""
        _Codigo_Id = 0
        _Codigo = ""
        _Activo = 0
        _Fecha = CDate("1900/01/01")
        _FechaVencimiento = CDate("1900/01/01")
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into UsuarioCodigoPermiso( Emp_Id , Usuario_Id" & _
                    " , Codigo_Id , Codigo" & _
                    " , Activo , Fecha" & _
                    " , FechaVencimiento )" & _
                    " Values ( " & _Emp_Id.ToString & ",'" & _Usuario_Id & "'" & _
                    "," & _Codigo_Id.ToString & ",'" & _Codigo & "'" & _
                    "," & _Activo.ToString & ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & _
                    ",'" & Format(_FechaVencimiento, "yyyyMMdd HH:mm:ss") & "'" & ")"

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function Delete() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "Delete UsuarioCodigoPermiso" & _
                    " Where     Emp_Id=" & _Emp_Id.ToString & _
                    " And     Usuario_Id='" & _Usuario_Id & "'" & _
                    " And    Codigo_Id=" & _Codigo_Id.ToString

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function Modify() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Update dbo.UsuarioCodigoPermiso " & _
                    " SET   Codigo='" & _Codigo & "' " & "," & _
                    " Activo=" & _Activo & "," & _
                    " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                    " FechaVencimiento='" & Format(_FechaVencimiento, "yyyyMMdd HH:mm:ss") & "'" & _
                    " Where     Emp_Id=" & _Emp_Id.ToString & _
                    " And     Usuario_Id='" & _Usuario_Id & "'" & _
                    " And    Codigo_Id=" & _Codigo_Id.ToString

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function ListKey() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select * From UsuarioCodigoPermiso" & _
                    " Where     Emp_Id=" & _Emp_Id.ToString & _
                    " And     Usuario_Id='" & _Usuario_Id & "'" & _
                    " And    Codigo_Id=" & _Codigo_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function List() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select * From UsuarioCodigoPermiso"

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function LoadComboBox() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select Codigo_Id as Numero, Nombre From UsuarioCodigoPermiso"

            Tabla = Cn.Seleccionar(Query).Copy

             If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function ListMant(pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select Codigo_Id as Codigo, Nombre From UsuarioCodigoPermiso" & _
                    " where Emp_Id = " & _Emp_Id.ToString

            If pNombre.Trim <> "" Then
                Query += " and Nombre Like '%" & pNombre & "%'"
            End If

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function NextOne() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select IsNull(MAX(Codigo_Id),0) + 1 as Codigo_Id From UsuarioCodigoPermiso" & _
                    " Where     Emp_Id=" & _Emp_Id.ToString & _
                    " And     Usuario_Id='" & _Usuario_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
#End Region
End Class
