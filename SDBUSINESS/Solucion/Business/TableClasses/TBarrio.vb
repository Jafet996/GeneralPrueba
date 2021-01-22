Public Class TBarrio
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Provincia_Id As Integer
    Private _Canton_Id As Integer
    Private _Distrito_Id As Integer
    Private _Barrio_Id As Integer
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
    Public Property Distrito_Id() As Integer
        Get
            Return _Distrito_Id
        End Get
        Set(ByVal Value As Integer)
            _Distrito_Id = Value
        End Set
    End Property
    Public Property Barrio_Id() As Integer
        Get
            Return _Barrio_Id
        End Get
        Set(ByVal Value As Integer)
            _Barrio_Id = Value
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
        _Distrito_Id = 0
        _Barrio_Id = 0
        _Nombre = ""
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into Barrio( Emp_Id , Provincia_Id" &
                   " , Canton_Id , Distrito_Id" &
                   " , Barrio_Id , Nombre" &
                   " )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Provincia_Id.ToString() &
                   "," & _Canton_Id.ToString() & "," & _Distrito_Id.ToString() &
                   "," & _Barrio_Id.ToString() & ",'" & _Nombre & "'" & ")"

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

            Query = "Delete Barrio" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And    Provincia_Id=" & _Provincia_Id.ToString() &
               " And    Canton_Id=" & _Canton_Id.ToString() &
               " And    Distrito_Id=" & _Distrito_Id.ToString() &
               " And    Barrio_Id=" & _Barrio_Id.ToString()

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

            Query = " Update dbo.Barrio " &
                      " SET   Nombre='" & _Nombre & "' " &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Provincia_Id=" & _Provincia_Id.ToString() &
                      " And    Canton_Id=" & _Canton_Id.ToString() &
                      " And    Distrito_Id=" & _Distrito_Id.ToString() &
                      " And    Barrio_Id=" & _Barrio_Id.ToString()

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

            Query = "select * From Barrio" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Provincia_Id=" & _Provincia_Id.ToString() &
           " And    Canton_Id=" & _Canton_Id.ToString() &
           " And    Distrito_Id=" & _Distrito_Id.ToString() &
           " And    Barrio_Id=" & _Barrio_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Provincia_Id = Tabla.Rows(0).Item("Provincia_Id")
                _Canton_Id = Tabla.Rows(0).Item("Canton_Id")
                _Distrito_Id = Tabla.Rows(0).Item("Distrito_Id")
                _Barrio_Id = Tabla.Rows(0).Item("Barrio_Id")
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

            Query = "select * From Barrio"

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

            Query = "select Barrio_Id as Numero, Nombre From Barrio" &
                    " where Emp_Id = " & _Emp_Id.ToString &
                    " and   Provincia_Id = " & Provincia_Id.ToString &
                    " and   Canton_Id = " & _Canton_Id.ToString &
                    " and   Distrito_Id = " & _Distrito_Id.ToString()

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
