Imports System.Windows.Forms
Public Class TGrupoMenu
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Grupo_Id As Integer
    Private _Modulo_Id As Integer
    Private _Menu_Id As String
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
    Public Property Grupo_Id() As Integer
        Get
            Return _Grupo_Id
        End Get
        Set(ByVal Value As Integer)
            _Grupo_Id = Value
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
    Public Property Menu_Id() As String
        Get
            Return _Menu_Id
        End Get
        Set(ByVal Value As String)
            _Menu_Id = Value
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
        _Grupo_Id = 0
        _Modulo_Id = 0
        _Menu_Id = ""
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into GrupoMenu( Emp_Id , Grupo_Id, Modulo_Id , Menu_Id)" & _
                    " Values ( " & _Emp_Id.ToString() & "," & _Grupo_Id.ToString() & _
                    "," & _Modulo_Id.ToString() & ",'" & _Menu_Id & "')"

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

            Query = "Delete GrupoMenu" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And    Grupo_Id=" & _Grupo_Id.ToString() & _
               " And    Modulo_Id=" & _Modulo_Id.ToString() & _
               " And     Menu_Id='" & _Menu_Id & "'"

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

            Query = ""

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

            Query = "select * From GrupoMenu" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    Grupo_Id=" & _Grupo_Id.ToString() & _
           " And    Modulo_Id=" & _Modulo_Id.ToString() & _
           " And     Menu_Id='" & _Menu_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Grupo_Id = Tabla.Rows(0).Item("Grupo_Id")
                _Modulo_Id = Tabla.Rows(0).Item("Modulo_Id")
                _Menu_Id = Tabla.Rows(0).Item("Menu_Id")
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

            Query = "select * From GrupoMenu where Emp_Id = " & _Emp_Id.ToString & " and Grupo_Id = " & _Grupo_Id.ToString & " and Modulo_Id = " & _Modulo_Id.ToString

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

            Query = "select GrupoMenu_Id as Numero, Nombre From GrupoMenu"

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
    Public Function HabilitaMenuGrupo(pMenu As MenuStrip, pGrupo_Id As Integer, pModulo_Id As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select Menu_Id From GrupoMenu where Emp_Id = " & _Emp_Id.ToString & _
                " and Grupo_Id = " & pGrupo_Id.ToString() & _
                " and Modulo_Id = " & pModulo_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                RecorrerNivelesAltos(pMenu, Tabla)
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Sub RecorrerNivelesAltos(pMenu As MenuStrip, pTabla As DataTable)
        For Each M As ToolStripMenuItem In pMenu.Items
            M.Visible = VerificaMenuItem(pTabla, M.Name)
            RecorrerSubMenuNivelesAltos(M, pTabla)
        Next
    End Sub

    Public Sub RecorrerSubMenuNivelesAltos(ByVal M As ToolStripMenuItem, pTabla As DataTable)
        For Each SubMenu As ToolStripMenuItem In M.DropDownItems
            SubMenu.Visible = VerificaMenuItem(pTabla, SubMenu.Name)
            RecorrerSubMenuNivelesAltos(SubMenu, pTabla)
        Next
    End Sub
    Private Function VerificaMenuItem(pTabla As DataTable, pMenu_Id As String) As Boolean

        Dim query = (From Fila In pTabla _
                    Where Fila("Menu_Id") = pMenu_Id _
                    Select Fila).FirstOrDefault

        Return Not (query Is Nothing)

    End Function

#End Region
End Class
