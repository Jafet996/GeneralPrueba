Public Class TPermiso
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Permiso_Id As Integer
    Private _Modulo_Id As Integer
    Private _Nombre As String
    Private _Activo As Integer
    Private _Data As DataSet

#End Region

#Region "Definicion de propiedades"

    Public Property Permiso_Id() As Integer
        Get
            Return _Permiso_Id
        End Get
        Set(ByVal Value As Integer)
            _Permiso_Id = Value
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
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
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
    Public Sub New(pModulo_Id As Integer)
        MyBase.New()
        Inicializa()
        _Modulo_Id = pModulo_Id
    End Sub
    Public Sub New(pEmp_Id As Integer, ByVal pCnStr As String)
        MyBase.New(pCnStr)
        Inicializa()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _Permiso_Id = 0
        _Modulo_Id = 0
        _Nombre = ""
        _Activo = 0
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into Permiso( Permiso_Id , Modulo_Id" & _
                   " , Nombre , Activo)" & _
                   " Values ( " & _Permiso_Id.ToString() & "," & _Modulo_Id.ToString() & _
                   ",'" & _Nombre & "'" & "," & _Activo.ToString() & ")"

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

            query = "Delete Permiso" & _
               " Where     Permiso_Id=" & _Permiso_Id.ToString()

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

            query = " Update dbo.Permiso " & _
                      " SET    Modulo_Id=" & _Modulo_Id.ToString() & "," & _
                      " Nombre='" & _Nombre & "'" & "," & _
                      " Activo=" & _Activo & _
                      " Where     Permiso_Id=" & _Permiso_Id.ToString()

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

            Query = "select * From Permiso" & _
           " Where     Permiso_Id=" & _Permiso_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Permiso_Id = Tabla.Rows(0).Item("Permiso_Id")
                _Modulo_Id = Tabla.Rows(0).Item("Modulo_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
                _Activo = Tabla.Rows(0).Item("Activo")
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

            Query = "select * From Permiso"

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

            Query = "select Permiso_Id as Numero, Nombre From Permiso"

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
    Public Function ListaxModulo() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try

            Cn.Open()

            Query = "select * From Permiso where Modulo_Id = " & _Modulo_Id.ToString & " Order by Nombre asc"

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
