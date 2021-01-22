Public Class TBotones
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _BotonTipo As Integer
    Private _Ancho As Integer
    Private _Espacio As Integer
    Private _Alto As Integer
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
    Public Property BotonTipo() As Integer
        Get
            Return _BotonTipo
        End Get
        Set(ByVal Value As Integer)
            _BotonTipo = Value
        End Set
    End Property
    Public Property Ancho() As Integer
        Get
            Return _Ancho
        End Get
        Set(ByVal Value As Integer)
            _Ancho = Value
        End Set
    End Property
    Public Property Espacio() As Integer
        Get
            Return _Espacio
        End Get
        Set(ByVal Value As Integer)
            _Espacio = Value
        End Set
    End Property
    Public Property Alto() As Integer
        Get
            Return _Alto
        End Get
        Set(ByVal Value As Integer)
            _Alto = Value
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
        _BotonTipo = 0
        _Ancho = 0
        _Espacio = 0
        _Alto = 0
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


            Query = " Insert into Botones( Emp_Id , BotonTipo" & _
                   " , Ancho , Espacio" & _
                   " , Alto , Nombre" & _
                   " )" & _
                   " Values ( " & _Emp_Id.ToString() & "," & _BotonTipo.ToString() & _
                   "," & _Ancho.ToString() & "," & _Espacio.ToString() & _
                   "," & _Alto.ToString() & ",'" & _Nombre & "')"

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

            query = "Delete Botones" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And    BotonTipo=" & _BotonTipo.ToString()

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

            query = " Update dbo.Botones " & _
                      " SET    Ancho=" & _Ancho.ToString() & "," & _
                      " Espacio=" & _Espacio & "," & _
                      " Alto=" & _Alto & "," & _
                      " Nombre='" & _Nombre & "'" & _
                      " Where     Emp_Id=" & _Emp_Id.ToString() & _
                      " And    BotonTipo=" & _BotonTipo.ToString()

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

            Query = "select * From Botones" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    BotonTipo=" & _BotonTipo.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _BotonTipo = Tabla.Rows(0).Item("BotonTipo")
                _Ancho = Tabla.Rows(0).Item("Ancho")
                _Espacio = Tabla.Rows(0).Item("Espacio")
                _Alto = Tabla.Rows(0).Item("Alto")
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

            Query = "select * From Botones"

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

            Query = "select Botones_Id as Numero, Nombre From Botones"

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
