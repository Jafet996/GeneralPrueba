Public Class TPermisoBitacora
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Bitacora_Id As Long
    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Permiso_Id As Integer
    Private _Usuario_Id As String
    Private _Fecha As Datetime
    Private _Observacion As String
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
    Public Property Emp_Id() As Integer
        Get
            Return _Emp_Id
        End Get
        Set(ByVal Value As Integer)
            _Emp_Id = Value
        End Set
    End Property
    Public Property Suc_Id() As Integer
        Get
            Return _Suc_Id
        End Get
        Set(ByVal Value As Integer)
            _Suc_Id = Value
        End Set
    End Property
    Public Property Permiso_Id() As Integer
        Get
            Return _Permiso_Id
        End Get
        Set(ByVal Value As Integer)
            _Permiso_Id = Value
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
    Public Property Fecha() As Datetime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As Datetime)
            _Fecha = Value
        End Set
    End Property
    Public Property Observacion() As String
        Get
            Return _Observacion
        End Get
        Set(ByVal Value As String)
            _Observacion = Value
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
        _Emp_Id = 0
        _Suc_Id = 0
        _Permiso_Id = 0
        _Usuario_Id = ""
        _Fecha = CDate("1900/01/01")
        _Observacion = ""
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into PermisoBitacora(Emp_Id" & _
                   " , Suc_Id , Permiso_Id" & _
                   " , Usuario_Id , Fecha" & _
                   " , Observacion )" & _
                   " Values (" & _Emp_Id.ToString() & _
                   "," & _Suc_Id.ToString() & "," & _Permiso_Id.ToString() & _
                   ",'" & _Usuario_Id & "'" & ",getdate()" & _
                   ",'" & _Observacion & "'" & ")"

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

            query = "Delete PermisoBitacora" & _
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

            query = " Update dbo.PermisoBitacora " & _
                      " SET    Emp_Id=" & _Emp_Id.ToString() & "," & _
                      " Suc_Id=" & _Suc_Id & "," & _
                      " Permiso_Id=" & _Permiso_Id & "," & _
                      " Usuario_Id='" & _Usuario_Id & "'" & "," & _
                      " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                      " Observacion='" & _Observacion & "'" & _
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

            Query = "select * From PermisoBitacora" & _
           " Where     Bitacora_Id=" & _Bitacora_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Bitacora_Id = Tabla.Rows(0).Item("Bitacora_Id")
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Permiso_Id = Tabla.Rows(0).Item("Permiso_Id")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Observacion = Tabla.Rows(0).Item("Observacion")
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

            Query = "select * From PermisoBitacora"

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

            Query = "select PermisoBitacora_Id as Numero, Nombre From PermisoBitacora"

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
#End Region
End Class
