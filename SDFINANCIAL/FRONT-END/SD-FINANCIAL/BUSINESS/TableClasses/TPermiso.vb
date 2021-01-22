Public Class TPermiso
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Permiso_Id As Integer
    Private _Modulo_Id As Integer
    Private _Nombre As String
    Private _Activo As Integer
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTPermiso
    Private _Resultado As New SDFinancial.TResultado
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
    Public ReadOnly Property RowsAffected As Long
        Get
            Return _Resultado.RowsAffected
        End Get
    End Property
#End Region
#Region "Constructores"
    Public Sub New(pModulo_Id As Integer)
        MyBase.New()
        Inicializa()
        _Modulo_Id = pModulo_Id
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        If Not InfoMaquina Is Nothing AndAlso InfoMaquina.Url <> "" Then
            _SDWCF.Url = InfoMaquina.Url
        Else
            _SDWCF.Url = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegUrl, String.Empty)
        End If
        _Permiso_Id = 0
        _Modulo_Id = 0
        _Nombre = ""
        _Activo = 0
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Permiso_Id = _Permiso_Id
                .Modulo_Id = _Modulo_Id
                .Nombre = _Nombre
                .Activo = _Activo
            End With

            _Resultado = _SDWCF.PermisoMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

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
                .Permiso_Id = _Permiso_Id
            End With

            _Resultado = _SDWCF.PermisoMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Permiso_Id = _Permiso_Id
                .Modulo_Id = _Modulo_Id
                .Nombre = _Nombre
                .Activo = _Activo
            End With

            _Resultado = _SDWCF.PermisoMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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
                .Permiso_Id = _Permiso_Id
            End With

            _Resultado = _SDWCF.PermisoMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos.Rows.Count > 0 Then
                For Each Fila As DataRow In _Resultado.Datos.Rows
                    _Permiso_Id = Fila("Permiso_Id")
                    _Modulo_Id = Fila("Modulo_Id")
                    _Nombre = Fila("Nombre")
                    _Activo = Fila("Activo")
                Next
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.PermisoMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            _Resultado = _SDWCF.PermisoMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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
            _Resultado = _SDWCF.PermisoMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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
            End With

            _Resultado = _SDWCF.PermisoMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos.Rows.Count > 0 Then
                For Each Fila As DataRow In _Resultado.Datos.Rows
                    _Permiso_Id = Fila("Permiso_Id")
                Next
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function ListaxModulo() As String
        Dim Query As String

        Try
            Query = "select * From Permiso " & _
                    " where Modulo_Id = " & _Modulo_Id.ToString & _
                    " and   Activo = 1" & _
                    " Order by Nombre asc"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

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
#End Region
End Class
