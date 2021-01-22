Imports System.Windows.Forms
Public Class TGrupoMenu
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Grupo_Id As Integer
    Private _Modulo_Id As Integer
    Private _Menu_Id As String
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTGrupoMenu
    Private _Resultado As New SDFinancial.TResultado
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
    Public ReadOnly Property RowsAffected As Long
        Get
            Return _Resultado.RowsAffected
        End Get
    End Property
#End Region
#Region "Constructores"
    Public Sub New()
        MyBase.New()
        Inicializa()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        If Not InfoMaquina Is Nothing AndAlso InfoMaquina.Url <> "" Then
            _SDWCF.Url = InfoMaquina.Url
        Else
            _SDWCF.Url = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegUrl, String.Empty)
        End If
        _Emp_Id = 0
        _Grupo_Id = 0
        _Modulo_Id = 0
        _Menu_Id = ""
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Grupo_Id = _Grupo_Id
                .Modulo_Id = _Modulo_Id
                .Menu_Id = _Menu_Id
            End With

            _Resultado = _SDWCF.GrupoMenuMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function Delete() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Grupo_Id = _Grupo_Id
                .Modulo_Id = _Modulo_Id
                .Menu_Id = _Menu_Id
            End With

            _Resultado = _SDWCF.GrupoMenuMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function Modify() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Grupo_Id = _Grupo_Id
                .Modulo_Id = _Modulo_Id
                .Menu_Id = _Menu_Id
            End With

            _Resultado = _SDWCF.GrupoMenuMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function ListKey() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Grupo_Id = _Grupo_Id
                .Modulo_Id = _Modulo_Id
                .Menu_Id = _Menu_Id
            End With

            _Resultado = _SDWCF.GrupoMenuMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos.Rows.Count > 0 Then
                For Each Fila As DataRow In _Resultado.Datos.Rows
                    _Emp_Id = Fila("Emp_Id")
                    _Grupo_Id = Fila("Grupo_Id")
                    _Modulo_Id = Fila("Modulo_Id")
                    _Menu_Id = Fila("Menu_Id")
                Next
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.GrupoMenuMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function LoadComboBox(pCombo As Windows.Forms.ComboBox) As String
        Try
            _Resultado = _SDWCF.GrupoMenuMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos.Rows.Count > 0 Then
                pCombo.DataSource = Nothing
                pCombo.DataSource = _Resultado.Datos
                pCombo.DisplayMember = "Nombre"
                pCombo.ValueMember = "Numero"
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function ListMant(pCriterio As String) As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
            End With

            _Resultado = _SDWCF.GrupoMenuMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function NextOne() As String
        Return String.Empty
    End Function
    Public Function HabilitaMenuGrupo(pMenu As MenuStrip, pGrupo_Id As Integer, pModulo_Id As Integer) As String
        Dim Query As String

        Try
            Query = "select Menu_Id From GrupoMenu" & _
                    " where Emp_Id = " & _Emp_Id.ToString & _
                    " and Grupo_Id = " & pGrupo_Id.ToString() & _
                    " and Modulo_Id = " & pModulo_Id.ToString()

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                RecorrerNivelesAltos(pMenu, _Resultado.Datos)
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Private Function VerificaMenuItem(pTabla As DataTable, pMenu_Id As String) As Boolean
        Dim query = (From Fila In pTabla _
                    Where Fila("Menu_Id") = pMenu_Id _
                    Select Fila).FirstOrDefault

        Return Not (query Is Nothing)
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
#End Region
End Class
