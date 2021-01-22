Public Class TCodigoPermisoBitacora
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Bitacora_Id As Long
    Private _Emp_Id As Integer
    Private _Usuario_Id As String
    Private _UsuarioUtilizo_Id As String
    Private _Permiso_Id As Integer
    Private _Codigo As String
    Private _Fecha As Datetime
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTCodigoPermisoBitacora
    Private _Resultado As New SDFinancial.TResultado
#End Region
#Region "Definicion de propiedades"
    Public Property Bitacora_Id() As Long
        Get
            Return _Bitacora_Id
        End Get
        Set(ByVal Value As Long)
            _Bitacora_Id = Value
        End Set
    End Property
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
    Public Property UsuarioUtilizo_Id() As String
        Get
            Return _UsuarioUtilizo_Id
        End Get
        Set(ByVal Value As String)
            _UsuarioUtilizo_Id = Value
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
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal Value As String)
            _Codigo = Value
        End Set
    End Property
    Public Property Fecha() As Datetime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As Datetime)
            _Fecha = Value
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
        _Bitacora_Id = 0
        _Emp_Id = 0
        _Usuario_Id = ""
        _UsuarioUtilizo_Id = ""
        _Permiso_Id = 0
        _Codigo = ""
        _Fecha = CDate("1900/01/01")
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Bitacora_Id = _Bitacora_Id
                .Emp_Id = _Emp_Id
                .Usuario_Id = _Usuario_Id
                .UsuarioUtilizo_Id = _UsuarioUtilizo_Id
                .Permiso_Id = _Permiso_Id
                .Codigo = _Codigo
                .Fecha = _Fecha
            End With

            _Resultado = _SDWCF.CodigoPermisoBitacoraMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

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
                .Bitacora_Id = _Bitacora_Id
            End With

            _Resultado = _SDWCF.CodigoPermisoBitacoraMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Bitacora_Id = _Bitacora_Id
                .Emp_Id = _Emp_Id
                .Usuario_Id = _Usuario_Id
                .UsuarioUtilizo_Id = _UsuarioUtilizo_Id
                .Permiso_Id = _Permiso_Id
                .Codigo = _Codigo
                .Fecha = _Fecha
            End With

            _Resultado = _SDWCF.CodigoPermisoBitacoraMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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
                .Bitacora_Id = _Bitacora_Id
            End With

            _Resultado = _SDWCF.CodigoPermisoBitacoraMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Bitacora_Id = _Resultado.Datos.Rows(0).Item("Bitacora_Id")
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _Usuario_Id = _Resultado.Datos.Rows(0).Item("Usuario_Id")
                _UsuarioUtilizo_Id = _Resultado.Datos.Rows(0).Item("UsuarioUtilizo_Id")
                _Permiso_Id = _Resultado.Datos.Rows(0).Item("Permiso_Id")
                _Codigo = _Resultado.Datos.Rows(0).Item("Codigo")
                _Fecha = _Resultado.Datos.Rows(0).Item("Fecha")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.CodigoPermisoBitacoraMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            _Resultado = _SDWCF.CodigoPermisoBitacoraMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
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

            _Resultado = _SDWCF.CodigoPermisoBitacoraMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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
#End Region
End Class
