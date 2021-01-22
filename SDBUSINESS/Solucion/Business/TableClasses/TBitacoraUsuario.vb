Public Class TBitacoraUsuario
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Bitacora_Id As Long
    Private _Modulo_Id As Integer
    Private _Emp_Id As Integer
    Private _Usuario_Id As String
    Private _Fecha As DateTime
    Private _Descripcion As String
    Private _Data As DataSet

#End Region

#Region "Definicion de propiedades"

    Public Property Bitacora_Id() As Long
        Get
            Return _Bitacora_Id
        End Get
        Set(ByVal Value As Long)
            _Bitacora_Id = Value
        End Set
    End Property
    Public Property Modulo_Id() As Integer
        Get
            Return _Modulo_Id
        End Get
        Set(ByVal Value As Integer)
            _Modulo_Id = Value
        End Set
    End Property
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
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As DateTime)
            _Fecha = Value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal Value As String)
            _Descripcion = Value
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
        _Bitacora_Id = 0
        _Modulo_Id = 0
        _Emp_Id = 0
        _Usuario_Id = ""
        _Fecha = CDate("1900/01/01")
        _Descripcion = ""
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into BitacoraUsuario(Modulo_Id" & _
       " , Emp_Id , Usuario_Id" & _
       " , Fecha , Descripcion" & _
       " )" & _
       " Values ( " & _Modulo_Id.ToString() & _
       "," & _Emp_Id.ToString() & ",'" & _Usuario_Id & "'" & _
       ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & ",'" & _Descripcion & "')"

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

            Query = "Delete BitacoraUsuario" & _
               " Where     Bitacora_Id=" & _Bitacora_Id.ToString()

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

            Query = " Update dbo.BitacoraUsuario " & _
                      " SET    Modulo_Id=" & _Modulo_Id.ToString() & "," & _
                      " Emp_Id=" & _Emp_Id & "," & _
                      " Usuario_Id='" & _Usuario_Id & "'" & "," & _
                      " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                      " Descripcion='" & _Descripcion & "'" & _
                      " Where     Bitacora_Id=" & _Bitacora_Id.ToString()

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

            Query = "select * From BitacoraUsuario" & _
           " Where     Bitacora_Id=" & _Bitacora_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Bitacora_Id = Tabla.Rows(0).Item("Bitacora_Id")
                _Modulo_Id = Tabla.Rows(0).Item("Modulo_Id")
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Descripcion = Tabla.Rows(0).Item("Descripcion")
            End If

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

            Query = "select * From BitacoraUsuario"

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
    Public Overrides Function LoadComboBox(pCombo As System.Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select BitacoraUsuario_Id as Numero, Nombre From BitacoraUsuario"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing Then
                pCombo.DataSource = Nothing
                pCombo.DataSource = Tabla
                pCombo.DisplayMember = "Nombre"
                pCombo.ValueMember = "Numero"
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function GuardaBitacoraUsuario() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "exec GuardaBitacoraUsuario " & _Modulo_Id.ToString() & "," & _Emp_Id.ToString() & ",'" & _Usuario_Id & "','" & _Descripcion & "'"

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
#End Region
End Class
