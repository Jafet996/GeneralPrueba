Public Class TCxP_Proveedor
    Inherits WCF_TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Prov_Id As Integer
    Private _Nombre As String
    Private _Telefono1 As String
    Private _Telefono2 As String
    Private _Email As String
    Private _Direccion As String
    Private _Debitos As Double
    Private _Creditos As Double
    Private _Saldo As Double
    Private _DiasCredito As Integer
    Private _Activo As Integer
    Private _UltimaModificacion As DateTime
    Private _SDL As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTProveedor
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
    Public Property Prov_Id() As Integer
        Get
            Return _Prov_Id
        End Get
        Set(ByVal Value As Integer)
            _Prov_Id = Value
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
    Public Property Telefono1() As String
        Get
            Return _Telefono1
        End Get
        Set(ByVal Value As String)
            _Telefono1 = Value
        End Set
    End Property
    Public Property Telefono2() As String
        Get
            Return _Telefono2
        End Get
        Set(ByVal Value As String)
            _Telefono2 = Value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal Value As String)
            _Email = Value
        End Set
    End Property
    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal Value As String)
            _Direccion = Value
        End Set
    End Property
    Public Property Debitos() As Double
        Get
            Return _Debitos
        End Get
        Set(ByVal Value As Double)
            _Debitos = Value
        End Set
    End Property
    Public Property Creditos() As Double
        Get
            Return _Creditos
        End Get
        Set(ByVal Value As Double)
            _Creditos = Value
        End Set
    End Property
    Public Property Saldo() As Double
        Get
            Return _Saldo
        End Get
        Set(ByVal Value As Double)
            _Saldo = Value
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
    Public Property UltimaModificacion() As DateTime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As DateTime)
            _UltimaModificacion = Value
        End Set
    End Property
    Public Property DiasCredito() As Integer
        Get
            Return _DiasCredito
        End Get
        Set(ByVal Value As Integer)
            _DiasCredito = Value
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
        If Not InfoMaquina Is Nothing AndAlso InfoMaquina.URLContabilidad <> "" Then
            _SDL.Url = InfoMaquina.URLContabilidad
        Else
            _SDL.Url = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegURLContabilidad, String.Empty)
        End If
        _Emp_Id = 0
        _Prov_Id = 0
        _Nombre = ""
        _Telefono1 = ""
        _Telefono2 = ""
        _Email = ""
        _Direccion = ""
        _Debitos = 0.0
        _Creditos = 0.0
        _Saldo = 0.0
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
        _DiasCredito = 0
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Prov_Id = _Prov_Id
                .Nombre = _Nombre
                .Telefono1 = _Telefono1
                .Telefono2 = _Telefono2
                .Email = _Email
                .Direccion = _Direccion
                .Debitos = _Debitos
                .Creditos = _Creditos
                .Saldo = _Saldo
                .Activo = _Activo
                .DiasCredito = _DiasCredito
            End With

            _Resultado = _SDL.ProveedorMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

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
                .Prov_Id = _Prov_Id
            End With

            _Resultado = _SDL.ProveedorMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Prov_Id = _Prov_Id
                .Nombre = _Nombre
                .Telefono1 = _Telefono1
                .Telefono2 = _Telefono2
                .Email = _Email
                .Direccion = _Direccion
                .Debitos = _Debitos
                .Creditos = _Creditos
                .Saldo = _Saldo
                .Activo = _Activo
                .DiasCredito = _DiasCredito
            End With

            _Resultado = _SDL.ProveedorMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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
                .Prov_Id = _Prov_Id
            End With

            _Resultado = _SDL.ProveedorMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _Prov_Id = _Resultado.Datos.Rows(0).Item("Prov_Id")
                _Nombre = _Resultado.Datos.Rows(0).Item("Nombre")
                _Telefono1 = _Resultado.Datos.Rows(0).Item("Telefono1")
                _Telefono2 = _Resultado.Datos.Rows(0).Item("Telefono2")
                _Email = _Resultado.Datos.Rows(0).Item("Email")
                _Direccion = _Resultado.Datos.Rows(0).Item("Direccion")
                _Debitos = _Resultado.Datos.Rows(0).Item("Debitos")
                _Creditos = _Resultado.Datos.Rows(0).Item("Creditos")
                _Saldo = _Resultado.Datos.Rows(0).Item("Saldo")
                _Activo = _Resultado.Datos.Rows(0).Item("Activo")
                _UltimaModificacion = _Resultado.Datos.Rows(0).Item("UltimaModificacion")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDL.ProveedorMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            _Resultado = _SDL.ProveedorMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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

            _Resultado = _SDL.ProveedorMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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
                .Emp_Id = _Emp_Id
            End With

            _Resultado = _SDL.ProveedorMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Prov_Id = _Resultado.Datos.Rows(0).Item("Prov_Id")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
End Class
