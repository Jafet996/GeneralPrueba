Public Class TClienteAnotacion
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Cliente_Id As Integer
    Private _Anotacion_Id As Integer
    Private _Anotacion As String
    Private _Fecha As DateTime
    Private _Usuario_Id As String
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
    Public Property Cliente_Id() As Integer
        Get
            Return _Cliente_Id
        End Get
        Set(ByVal Value As Integer)
            _Cliente_Id = Value
        End Set
    End Property
    Public Property Anotacion_Id() As Integer
        Get
            Return _Anotacion_Id
        End Get
        Set(ByVal Value As Integer)
            _Anotacion_Id = Value
        End Set
    End Property
    Public Property Anotacion() As String
        Get
            Return _Anotacion
        End Get
        Set(ByVal Value As String)
            _Anotacion = Value
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
        _Cliente_Id = 0
        _Anotacion_Id = 0
        _Anotacion = ""
        _Fecha = CDate("1900/01/01")
        _Usuario_Id = ""
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Function Siguiente() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select isnull(max(Anotacion_Id),0) + 1 From ClienteAnotacion" & _
                " Where Emp_Id=" & _Emp_Id.ToString() & _
                " And Cliente_Id = " & _Cliente_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Anotacion_Id = Tabla.Rows(0).Item(0)
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into ClienteAnotacion( Emp_Id , Cliente_Id" & _
                   " , Anotacion_Id , Anotacion" & _
                   " , Fecha , Usuario_Id" & _
                   " )" & _
                   " Values ( " & _Emp_Id.ToString() & "," & _Cliente_Id.ToString() & _
                   "," & _Anotacion_Id.ToString() & ",'" & _Anotacion & "'" & _
                   ",getdate(),'" & _Usuario_Id & "'" & ")"

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

            Query = "Delete ClienteAnotacion" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And    Cliente_Id=" & _Cliente_Id.ToString() & _
               " And    Anotacion_Id=" & _Anotacion_Id.ToString()

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

            Query = " Update dbo.ClienteAnotacion " & _
                      " SET   Anotacion='" & _Anotacion & "' " & "," & _
                      " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                      " Usuario_Id='" & _Usuario_Id & "'" & _
                      " Where     Emp_Id=" & _Emp_Id.ToString() & _
                      " And    Cliente_Id=" & _Cliente_Id.ToString() & _
                      " And    Anotacion_Id=" & _Anotacion_Id.ToString()

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

            Query = "select * From ClienteAnotacion" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    Cliente_Id=" & _Cliente_Id.ToString() & _
           " And    Anotacion_Id=" & _Anotacion_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Cliente_Id = Tabla.Rows(0).Item("Cliente_Id")
                _Anotacion_Id = Tabla.Rows(0).Item("Anotacion_Id")
                _Anotacion = Tabla.Rows(0).Item("Anotacion")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
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

            Query = "select * From ClienteAnotacion"

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

            Query = "select ClienteAnotacion_Id as Numero, Nombre From ClienteAnotacion"

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
