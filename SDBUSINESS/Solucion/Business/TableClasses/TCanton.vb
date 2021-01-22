Public Class TCanton
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Provincia_Id As Integer
    Private _Canton_Id As Integer
    Private _Nombre As String
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
    Public Property Provincia_Id() As Integer
        Get
            Return _Provincia_Id
        End Get
        Set(ByVal Value As Integer)
            _Provincia_Id = Value
        End Set
    End Property
    Public Property Canton_Id() As Integer
        Get
            Return _Canton_Id
        End Get
        Set(ByVal Value As Integer)
            _Canton_Id = Value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
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
        _Provincia_Id = 0
        _Canton_Id = 0
        _Nombre = ""
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into Canton( Emp_Id , Provincia_Id" & _
                    " , Canton_Id , Nombre" & _
                    " )" & _
                    " Values ( " & _Emp_Id.ToString() & "," & _Provincia_Id.ToString() & _
                    "," & _Canton_Id.ToString() & ",'" & _Nombre & "'" & ")"

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

            Query = "Delete Canton" & _
                    " Where     Emp_Id=" & _Emp_Id.ToString() & _
                    " And    Provincia_Id=" & _Provincia_Id.ToString() & _
                    " And    Canton_Id=" & _Canton_Id.ToString()

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

            Query = " Update dbo.Canton " & _
                    " SET   Nombre='" & _Nombre & "' " & _
                    " Where     Emp_Id=" & _Emp_Id.ToString() & _
                    " And    Provincia_Id=" & _Provincia_Id.ToString() & _
                    " And    Canton_Id=" & _Canton_Id.ToString()

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

            Query = "select * From Canton" & _
                    " Where     Emp_Id=" & _Emp_Id.ToString() & _
                    " And    Provincia_Id=" & _Provincia_Id.ToString() & _
                    " And    Canton_Id=" & _Canton_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Provincia_Id = Tabla.Rows(0).Item("Provincia_Id")
                _Canton_Id = Tabla.Rows(0).Item("Canton_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
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

            Query = "select * From Canton where Emp_Id = " & _Emp_Id.ToString()

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

            Query = "select Canton_Id as Numero, Nombre From Canton where Emp_Id = " & _Emp_Id.ToString & " and Provincia_Id = " & _Provincia_Id.ToString

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
