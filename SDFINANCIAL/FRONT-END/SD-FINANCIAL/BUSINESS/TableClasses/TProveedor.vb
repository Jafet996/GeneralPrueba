Public Class TProveedor
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Prov_Id As Integer
    Private _TipoIdentificacion_Id As Integer
    Private _Identificacion As String
    Private _Nombre As String
    Private _Telefono1 As String
    Private _Telefono2 As String
    Private _Email As String
    Private _Direccion As String
    Private _Debitos As Double
    Private _Creditos As Double
    Private _Saldo As Double
    Private _CxP_Colones As String
    Private _CxP_Dolares As String
    Private _Activo As Integer
    Private _UltimaModificacion As Datetime
    Private _SDWCF As New SDFinancial.SDFinancial
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
    Public Property TipoIdentificacion_Id() As Integer
        Get
            Return _TipoIdentificacion_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoIdentificacion_Id = Value
        End Set
    End Property
    Public Property Identificacion() As String
        Get
            Return _Identificacion
        End Get
        Set(ByVal Value As String)
            _Identificacion = Value
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
    Public Property CxP_Colones() As String
        Get
            Return _CxP_Colones
        End Get
        Set(ByVal Value As String)
            _CxP_Colones = Value
        End Set
    End Property
    Public Property CxP_Dolares() As String
        Get
            Return _CxP_Dolares
        End Get
        Set(ByVal Value As String)
            _CxP_Dolares = Value
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
    Public Property UltimaModificacion() As Datetime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As Datetime)
            _UltimaModificacion = Value
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
        _Prov_Id = 0
        _TipoIdentificacion_Id = 0
        _Identificacion = ""
        _Nombre = ""
        _Telefono1 = ""
        _Telefono2 = ""
        _Email = ""
        _Direccion = ""
        _Debitos = 0.0
        _Creditos = 0.0
        _Saldo = 0.0
        _CxP_Colones = ""
        _CxP_Dolares = ""
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Prov_Id = _Prov_Id
                .TipoIdentificacion_Id = _TipoIdentificacion_Id
                .Identificacion = _Identificacion
                .Nombre = _Nombre
                .Telefono1 = _Telefono1
                .Telefono2 = _Telefono2
                .Email = _Email
                .Direccion = _Direccion
                .Debitos = _Debitos
                .Creditos = _Creditos
                .Saldo = _Saldo
                .CxP_Colones = _CxP_Colones
                .CxP_Dolares = _CxP_Dolares
                .Activo = _Activo
            End With

            _Resultado = _SDWCF.ProveedorMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

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

            _Resultado = _SDWCF.ProveedorMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .TipoIdentificacion_Id = _TipoIdentificacion_Id
                .Identificacion = _Identificacion
                .Nombre = _Nombre
                .Telefono1 = _Telefono1
                .Telefono2 = _Telefono2
                .Email = _Email
                .Direccion = _Direccion
                .Debitos = _Debitos
                .Creditos = _Creditos
                .Saldo = _Saldo
                .CxP_Colones = _CxP_Colones
                .CxP_Dolares = _CxP_Dolares
                .Activo = _Activo
            End With

            _Resultado = _SDWCF.ProveedorMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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

            _Resultado = _SDWCF.ProveedorMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _Prov_Id = _Resultado.Datos.Rows(0).Item("Prov_Id")
                _TipoIdentificacion_Id = _Resultado.Datos.Rows(0).Item("TipoIdentificacion_Id")
                _Identificacion = _Resultado.Datos.Rows(0).Item("Identificacion")
                _Nombre = _Resultado.Datos.Rows(0).Item("Nombre")
                _Telefono1 = _Resultado.Datos.Rows(0).Item("Telefono1")
                _Telefono2 = _Resultado.Datos.Rows(0).Item("Telefono2")
                _Email = _Resultado.Datos.Rows(0).Item("Email")
                _Direccion = _Resultado.Datos.Rows(0).Item("Direccion")
                _Debitos = _Resultado.Datos.Rows(0).Item("Debitos")
                _Creditos = _Resultado.Datos.Rows(0).Item("Creditos")
                _Saldo = _Resultado.Datos.Rows(0).Item("Saldo")
                _CxP_Colones = _Resultado.Datos.Rows(0).Item("CxP_Colones")
                _CxP_Dolares = _Resultado.Datos.Rows(0).Item("CxP_Dolares")
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
            _Resultado = _SDWCF.ProveedorMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            With _DTabla
                .Emp_Id = _Emp_Id
            End With

            _Resultado = _SDWCF.ProveedorMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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

            _Resultado = _SDWCF.ProveedorMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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

            _Resultado = _SDWCF.ProveedorMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

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
    Public Function ListKeyByIdentificacion() As String
        Dim Query As String

        Try
            Query = " select *" & _
                    " from Proveedor" & _
                    " where Emp_Id = " & _Emp_Id.ToString & _
                    " and   Identificacion = '" & _Identificacion.ToString & "'"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _Prov_Id = _Resultado.Datos.Rows(0).Item("Prov_Id")
                _TipoIdentificacion_Id = _Resultado.Datos.Rows(0).Item("TipoIdentificacion_Id")
                _Identificacion = _Resultado.Datos.Rows(0).Item("Identificacion")
                _Nombre = _Resultado.Datos.Rows(0).Item("Nombre")
                _Telefono1 = _Resultado.Datos.Rows(0).Item("Telefono1")
                _Telefono2 = _Resultado.Datos.Rows(0).Item("Telefono2")
                _Email = _Resultado.Datos.Rows(0).Item("Email")
                _Direccion = _Resultado.Datos.Rows(0).Item("Direccion")
                _Debitos = _Resultado.Datos.Rows(0).Item("Debitos")
                _Creditos = _Resultado.Datos.Rows(0).Item("Creditos")
                _Saldo = _Resultado.Datos.Rows(0).Item("Saldo")
                _CxP_Colones = _Resultado.Datos.Rows(0).Item("CxP_Colones")
                _CxP_Dolares = _Resultado.Datos.Rows(0).Item("CxP_Dolares")
                _Activo = _Resultado.Datos.Rows(0).Item("Activo")
                _UltimaModificacion = _Resultado.Datos.Rows(0).Item("UltimaModificacion")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function ListBusqueda(pCriterio As String, pTipoBusqueda As Integer) As String
        Dim Query As String

        Try
            Query = " select a.Prov_Id as Codigo" & _
                    " ,a.Nombre" & _
                    " ,b.Nombre as TipoIdentificacion" & _
                    " ,a.Identificacion" & _
                    " from Proveedor a" & _
                    " ,TipoIdentificacion b" & _
                    " where a.Emp_Id = b.Emp_Id" & _
                    " and   a.TipoIdentificacion_Id = b.TipoIdentificacion_Id" & _
                    " and   a.Activo = 1" & _
                    " and   a.Emp_Id = " & _Emp_Id.ToString

            Select Case pTipoBusqueda
                Case 1
                    If pCriterio <> "" Then
                        Query += " and   a.Nombre like '%" & pCriterio & "%'"
                    End If
                Case 2
                    If pCriterio <> "" Then
                        Query += " and   a.Identificacion like '%" & pCriterio & "%'"
                    End If
                Case Else
                    VerificaMensaje("El tipo de búsqueda indicado no es válido")
            End Select

            Query += " order by a.Nombre"

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
    Public Function RptConsultaInformacionProveedor() As String
        Dim Query As String

        Try
            Query = "exec RptConsultaInformacionProveedor " & _Emp_Id.ToString & "," & _Prov_Id.ToString

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