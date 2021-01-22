Public Class TCxCEntregaDocumentoEncabezado
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Entrega_Id As Integer
    Private _Vendedor_Id As Integer
    Private _Fecha As DateTime
    Private _Usuario_Id As String
    Private _Activo As Integer
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
    Public Property Entrega_Id() As Integer
        Get
            Return _Entrega_Id
        End Get
        Set(ByVal Value As Integer)
            _Entrega_Id = Value
        End Set
    End Property
    Public Property Vendedor_Id() As Integer
        Get
            Return _Vendedor_Id
        End Get
        Set(ByVal Value As Integer)
            _Vendedor_Id = Value
        End Set
    End Property
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As DateTime)
            _Fecha = Value
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
    Public Property Activo() As Integer
        Get
            Return _Activo
        End Get
        Set(ByVal Value As Integer)
            _Activo = Value
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
        _Entrega_Id = 0
        _Vendedor_Id = 0
        _Fecha = CDate("1900/01/01")
        _Usuario_Id = ""
        _Activo = 0
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into CxCEntregaDocumentoEncabezado( Emp_Id , Entrega_Id" &
       " , Vendedor_Id , Fecha" &
       " , Usuario_Id , Activo" &
       " )" &
       " Values ( " & _Emp_Id.ToString & "," & _Entrega_Id.ToString &
       "," & _Vendedor_Id.ToString & ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" &
       ",'" & _Usuario_Id & "'" & "," & _Activo.ToString &
       ")"

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return String.Empty
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

            Query = "Delete CxCEntregaDocumentoEncabezado" &
               " Where Emp_Id = " & _Emp_Id.ToString &
               " And   Entrega_Id = " & _Entrega_Id.ToString

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return String.Empty
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

            Query = " Update CxCEntregaDocumentoEncabezado " &
           " SET    Vendedor_Id = " & _Vendedor_Id.ToString & "," &
           " Fecha = '" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," &
           " Usuario_Id = '" & _Usuario_Id & "'" & "," &
           " Activo = " & _Activo &
           " Where Emp_Id = " & _Emp_Id.ToString &
           " And   Entrega_Id = " & _Entrega_Id.ToString

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return String.Empty
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

            Query = "select * From CxCEntregaDocumentoEncabezado" &
           " Where Emp_Id = " & _Emp_Id.ToString &
           " And   Entrega_Id = " & _Entrega_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return String.Empty
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

            Query = "select * From CxCEntregaDocumentoEncabezado"

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return String.Empty
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

            Query = "select CxCEntregaDocumentoEncabezado_Id as Numero, Nombre From CxCEntregaDocumentoEncabezado" &
                    " where Emp_Id = " & _Emp_Id.ToString &
                    " and   Activo = 1"

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return String.Empty
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

            Query = "select CxCEntregaDocumentoEncabezado_Id as Codigo, Nombre From CxCEntregaDocumentoEncabezado" &
                    " where Emp_Id = " & _Emp_Id.ToString

            If pNombre.Trim <> "" Then
                Query += " and Nombre Like '%" & pNombre & "%'"
            End If

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return String.Empty
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

            Query = "select ISNULL(MAX(Entrega_Id),0) + 1 as CxCEntregaDocumentoEncabezado_Id From CxCEntregaDocumentoEncabezado" &
           " Where Emp_Id = " & _Emp_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
#End Region

End Class
