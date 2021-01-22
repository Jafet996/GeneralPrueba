Public Class TEmpresa
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Nombre As String
    Private _Cedula As String
    Private _Telefono As String
    Private _Fax As String
    Private _Email As String
    Private _Direccion As String
    Private _DireccionWeb As String
    Private _Activo As Integer
    Private _UltimaModificacion As Datetime
    Private _Logo As Byte()
    Private _Parametros As New TEmpresaParametro()
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTEmpresa
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
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
        End Set
    End Property
    Public Property Cedula() As String
        Get
            Return _Cedula
        End Get
        Set(ByVal Value As String)
            _Cedula = Value
        End Set
    End Property
    Public Property Telefono() As String
        Get
            Return _Telefono
        End Get
        Set(ByVal Value As String)
            _Telefono = Value
        End Set
    End Property
    Public Property Fax() As String
        Get
            Return _Fax
        End Get
        Set(ByVal Value As String)
            _Fax = Value
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
    Public Property DireccionWeb() As String
        Get
            Return _DireccionWeb
        End Get
        Set(ByVal Value As String)
            _DireccionWeb = Value
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
    Public Property Logo() As Byte()
        Get
            Return _Logo
        End Get
        Set(ByVal Value As Byte())
            _Logo = Value
        End Set
    End Property
    Public Property Parametros As TEmpresaParametro
        Get
            Return _Parametros
        End Get
        Set(value As TEmpresaParametro)
            _Parametros = value
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
        _Nombre = ""
        _Cedula = ""
        _Telefono = ""
        _Fax = ""
        _Email = ""
        _Direccion = ""
        _DireccionWeb = ""
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
        _Logo = Nothing
        With _Parametros
            .Emp_Id = 0
            .ProcesoAnnio = 0
            .ProcesoMes = 0
            .MesCierreFiscal = 0
        End With
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Nombre = _Nombre
                .Cedula = _Cedula
                .Telefono = _Telefono
                .Fax = _Fax
                .Email = _Email
                .Direccion = _Direccion
                .DireccionWeb = _DireccionWeb
                .Activo = _Activo
                .Logo = _Logo
                .UltimaModificacion = _UltimaModificacion
            End With

            _Resultado = _SDWCF.EmpresaMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

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
            End With

            _Resultado = _SDWCF.EmpresaMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Nombre = _Nombre
                .Cedula = _Cedula
                .Telefono = _Telefono
                .Fax = _Fax
                .Email = _Email
                .Direccion = _Direccion
                .DireccionWeb = _DireccionWeb
                .Activo = _Activo
                .UltimaModificacion = _UltimaModificacion
                .Logo = _Logo
            End With

            _Resultado = _SDWCF.EmpresaMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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
            End With

            _Resultado = _SDWCF.EmpresaMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos.Rows.Count > 0 Then
                For Each Fila As DataRow In _Resultado.Datos.Rows
                    _Emp_Id = Fila("Emp_Id")
                    _Nombre = Fila("Nombre")
                    _Cedula = Fila("Cedula")
                    _Telefono = Fila("Telefono")
                    _Fax = Fila("Fax")
                    _Email = Fila("Email")
                    _Direccion = Fila("Direccion")
                    _DireccionWeb = Fila("DireccionWeb")
                    _Activo = Fila("Activo")
                    _UltimaModificacion = Fila("UltimaModificacion")
                    _Logo = IIf(IsDBNull(Fila("Logo")), Nothing, Fila("Logo"))
                Next
            End If

            _Parametros.Emp_Id = _Emp_Id
            VerificaMensaje(_Parametros.ListKey)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.EmpresaMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            _Resultado = _SDWCF.EmpresaMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos.Rows.Count > 0 Then

                If Not _Resultado.Datos.Rows Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                    _Emp_Id = _Resultado.Datos.Rows(0).Item("Numero")
                End If

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

            _Resultado = _SDWCF.EmpresaMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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

            _Resultado = _SDWCF.EmpresaMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos.Rows.Count > 0 Then
                For Each Fila As DataRow In _Resultado.Datos.Rows
                    _Emp_Id = Fila("Empresa_Id")
                Next
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function Getdate() As DateTime
        Dim Query As String

        Try
            Query = "select getdate() as Fecha"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                Return _Resultado.Datos.Rows(0).Item("Fecha")
            Else
                VerificaMensaje("No se pudo encontrar la fecha de la BD")
            End If

            Return String.Empty
        Catch ex As Exception
            Return Now
        End Try
    End Function
    Public Function GetLogoEmpresa() As String
        Dim Query As String

        Try
            Query = " exec GetLogoEmpresa " & _Emp_Id.ToString

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
    Public Function ConvierteNumeroLetras(pNumero As Double) As String
        Try

            _Resultado = _SDWCF.ConvierteNumeroLetras(pNumero)

            VerificaMsgError()

            Return _Resultado.Valor

        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
End Class