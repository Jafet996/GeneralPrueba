Imports System.Windows.Forms
Public Class TUsuarioPermiso
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Usuario_Id As String
    Private _Permiso_Id As Integer
    Private _Modulo_Id As Integer
    Private _UltimaModificacion As DateTime
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
    Public Property UltimaModificacion() As DateTime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As DateTime)
            _UltimaModificacion = Value
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
        _Permiso_Id = 0
        _Modulo_Id = 0
        _UltimaModificacion = CDate("1900/01/01")
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()


            Query = " Insert into UsuarioPermiso( Emp_Id , Usuario_Id" & _
                   " , Permiso_Id , Modulo_Id , UltimaModificacion )" & _
                   " Values ( " & _Emp_Id.ToString() & ",'" & _Usuario_Id & "'" & _
                   "," & _Permiso_Id.ToString() & "," & _Modulo_Id.ToString() & _
                   ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "')"
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

            Query = "Delete UsuarioPermiso" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And     Usuario_Id='" & _Usuario_Id & "'" & _
               " And    Permiso_Id=" & _Permiso_Id.ToString()

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

            Query = " Update dbo.UsuarioPermiso " & _
                      " SET    Modulo_Id=" & _Modulo_Id.ToString() & "," & _
                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & _
                      " Where     Emp_Id=" & _Emp_Id.ToString() & _
                      " And     Usuario_Id='" & _Usuario_Id & "'" & _
                      " And    Permiso_Id=" & _Permiso_Id.ToString()

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

            Query = "select * From UsuarioPermiso" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And     Usuario_Id='" & _Usuario_Id & "'" & _
           " And    Permiso_Id=" & _Permiso_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _Permiso_Id = Tabla.Rows(0).Item("Permiso_Id")
                _Modulo_Id = Tabla.Rows(0).Item("Modulo_Id")
                _UltimaModificacion = Tabla.Rows(0).Item("UltimaModificacion")
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

            Query = "select * From UsuarioPermiso"

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

            Query = "select UsuarioPermiso_Id as Numero, Nombre From UsuarioPermiso"

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

    Public Function ListaxUsuario(pListaPermisos As ListView) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select * From UsuarioPermiso where Emp_Id = " & _Emp_Id.ToString & " and Usuario_Id = '" & _Usuario_Id & "' and Modulo_Id = " & _Modulo_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                For Each Fila As DataRow In Tabla.Rows
                    For Each Item As ListViewItem In pListaPermisos.Items
                        If Item.Tag = Fila("Permiso_Id") Then
                            Item.Checked = True
                        End If
                    Next
                Next
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
