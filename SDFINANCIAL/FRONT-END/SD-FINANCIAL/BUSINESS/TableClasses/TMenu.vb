Imports System.Windows.Forms

Public Class TMenu
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Modulo_Id As Integer
    Private _Menu_Id As String
    Private _MenuPadre_Id As String
    Private _Nombre As String
    Private _Orden As Integer
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTMenu
    Private _Resultado As New SDFinancial.TResultado
#End Region
#Region "Definicion de propiedades"
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
    Public Property MenuPadre_Id() As String
        Get
            Return _MenuPadre_Id
        End Get
        Set(ByVal Value As String)
            _MenuPadre_Id = Value
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
    Public Property Orden() As Integer
        Get
            Return _Orden
        End Get
        Set(ByVal Value As Integer)
            _Orden = Value
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
        _Modulo_Id = 0
        _Menu_Id = ""
        _MenuPadre_Id = ""
        _Nombre = ""
        _Orden = 0
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Modulo_Id = _Modulo_Id
                .Menu_Id = _Menu_Id
                .MenuPadre_Id = _MenuPadre_Id
                .Nombre = _Nombre
                .Orden = _Orden
            End With

            _Resultado = _SDWCF.MenuMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

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
                .Modulo_Id = _Modulo_Id
            End With

            _Resultado = _SDWCF.MenuMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Modulo_Id = _Modulo_Id
                .Menu_Id = _Menu_Id
                .MenuPadre_Id = _MenuPadre_Id
                .Nombre = _Nombre
                .Orden = _Orden
            End With

            _Resultado = _SDWCF.MenuMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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
                .Modulo_Id = _Modulo_Id
                .Menu_Id = _Menu_Id
            End With

            _Resultado = _SDWCF.MenuMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos.Rows.Count > 0 Then
                For Each Fila As DataRow In _Resultado.Datos.Rows
                    _Modulo_Id = Fila("Modulo_Id")
                    _Menu_Id = Fila("Menu_Id")
                    _MenuPadre_Id = Fila("MenuPadre_Id")
                    _Nombre = Fila("Nombre")
                    _Orden = Fila("Orden")
                Next
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.MenuMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            _Resultado = _SDWCF.MenuMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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
            _Resultado = _SDWCF.MenuMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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
        Try
            With _DTabla
                .Modulo_Id = _Modulo_Id
            End With

            _Resultado = _SDWCF.MenuMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos.Rows.Count > 0 Then
                For Each Fila As DataRow In _Resultado.Datos.Rows
                    _Menu_Id = Fila("Menu_Id")
                Next
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function CreaArbolMenu(pArbol As TreeView) As String
        Dim Query As String
        Dim Nodo As TreeNode = Nothing
        Dim NodoPapa As TreeNode() = Nothing

        Try
            Query = "Select * From Menu Where Modulo_Id=" & _Modulo_Id.ToString() & "Order By Orden Asc"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                For Each Fila As DataRow In _Resultado.Datos.Rows
                    Nodo = New TreeNode
                    Nodo.Name = Fila("Menu_Id")
                    Nodo.Text = Fila("Nombre")
                    Nodo.SelectedImageIndex = 2

                    If Fila("MenuPadre_Id") = "" Then
                        pArbol.Nodes.Add(Nodo)
                        Nodo.ImageIndex = 0
                    Else
                        NodoPapa = pArbol.Nodes.Find(Fila("MenuPadre_Id"), True)
                        If Not NodoPapa Is Nothing Then
                            NodoPapa(0).Nodes.Add(Nodo)
                            Nodo.ImageIndex = 1
                        End If
                    End If
                Next
                pArbol.ExpandAll()
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
End Class
