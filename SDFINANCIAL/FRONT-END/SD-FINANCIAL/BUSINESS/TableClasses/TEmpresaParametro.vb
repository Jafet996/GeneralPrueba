Public Class TEmpresaParametro
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _ProcesoAnnio As Integer
    Private _ProcesoMes As Integer
    Private _MesCierreFiscal As Integer
    Private _CuentaResultadoPeriodo As String
    Private _DiasCredito As Integer
    Private _PorcMora As Double
    Private _DiasGraciaMora As Integer
    Private _AplicaMora As Integer
    Private _CuentaIngresoXDiferencial As String
    Private _CuentaGastoXDiferencial As String
    Private _CuentaRedondeo As String
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTEmpresaParametro
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
    Public WriteOnly Property ProcesoAnnio() As Integer
        Set(ByVal Value As Integer)
            _ProcesoAnnio = Value
        End Set
    End Property
    Public WriteOnly Property ProcesoMes() As Integer
        Set(ByVal Value As Integer)
            _ProcesoMes = Value
        End Set
    End Property
    Public WriteOnly Property MesCierreFiscal() As Integer
        Set(ByVal Value As Integer)
            _MesCierreFiscal = Value
        End Set
    End Property
    Public Property CuentaResultadoPeriodo() As String
        Get
            Return _CuentaResultadoPeriodo
        End Get
        Set(ByVal Value As String)
            _CuentaResultadoPeriodo = Value
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
    Public Property PorcMora() As Double
        Get
            Return _PorcMora
        End Get
        Set(ByVal Value As Double)
            _PorcMora = Value
        End Set
    End Property
    Public Property DiasGraciaMora() As Integer
        Get
            Return _DiasGraciaMora
        End Get
        Set(ByVal Value As Integer)
            _DiasGraciaMora = Value
        End Set
    End Property
    Public Property AplicaMora() As Integer
        Get
            Return _AplicaMora
        End Get
        Set(ByVal Value As Integer)
            _AplicaMora = Value
        End Set
    End Property
    Public Property CuentaIngresoXDiferencial() As String
        Get
            Return _CuentaIngresoXDiferencial
        End Get
        Set(ByVal Value As String)
            _CuentaIngresoXDiferencial = Value
        End Set
    End Property
    Public Property CuentaGastoXDiferencial() As String
        Get
            Return _CuentaGastoXDiferencial
        End Get
        Set(ByVal Value As String)
            _CuentaGastoXDiferencial = Value
        End Set
    End Property
    Public Property CuentaRedondeo() As String
        Get
            Return _CuentaRedondeo
        End Get
        Set(ByVal Value As String)
            _CuentaRedondeo = Value
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
        _ProcesoAnnio = 0
        _ProcesoMes = 0
        _MesCierreFiscal = 0
        _CuentaResultadoPeriodo = ""
        _DiasCredito = 0
        _PorcMora = 0.0
        _DiasGraciaMora = 0
        _AplicaMora = 0
        _CuentaIngresoXDiferencial = ""
        _CuentaGastoXDiferencial = ""
        _CuentaRedondeo = ""
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .ProcesoAnnio = _ProcesoAnnio
                .ProcesoMes = _ProcesoMes
                .MesCierreFiscal = _MesCierreFiscal
                .CuentaResultadoPeriodo = _CuentaResultadoPeriodo
                .DiasCredito = _DiasCredito
                .PorcMora = _PorcMora
                .DiasGraciaMora = _DiasGraciaMora
                .AplicaMora = _AplicaMora
                .CuentaIngresoXDiferencial = _CuentaIngresoXDiferencial
                .CuentaGastoXDiferencial = _CuentaGastoXDiferencial
                .CuentaRedondeo = _CuentaRedondeo
            End With

            _Resultado = _SDWCF.EmpresaParametroMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

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

            _Resultado = _SDWCF.EmpresaParametroMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .ProcesoAnnio = _ProcesoAnnio
                .ProcesoMes = _ProcesoMes
                .MesCierreFiscal = _MesCierreFiscal
                .CuentaResultadoPeriodo = _CuentaResultadoPeriodo
                .DiasCredito = _DiasCredito
                .PorcMora = _PorcMora
                .DiasGraciaMora = _DiasGraciaMora
                .AplicaMora = _AplicaMora
                .CuentaIngresoXDiferencial = _CuentaIngresoXDiferencial
                .CuentaGastoXDiferencial = _CuentaGastoXDiferencial
                .CuentaRedondeo = _CuentaRedondeo
            End With

            _Resultado = _SDWCF.EmpresaParametroMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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

            _Resultado = _SDWCF.EmpresaParametroMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _ProcesoAnnio = _Resultado.Datos.Rows(0).Item("ProcesoAnnio")
                _ProcesoMes = _Resultado.Datos.Rows(0).Item("ProcesoMes")
                _MesCierreFiscal = _Resultado.Datos.Rows(0).Item("MesCierreFiscal")
                _CuentaResultadoPeriodo = _Resultado.Datos.Rows(0).Item("CuentaResultadoPeriodo")
                _DiasCredito = _Resultado.Datos.Rows(0).Item("DiasCredito")
                _PorcMora = _Resultado.Datos.Rows(0).Item("PorcMora")
                _DiasGraciaMora = _Resultado.Datos.Rows(0).Item("DiasGraciaMora")
                _AplicaMora = _Resultado.Datos.Rows(0).Item("AplicaMora")
                _CuentaIngresoXDiferencial = _Resultado.Datos.Rows(0).Item("CuentaIngresoXDiferencial")
                _CuentaGastoXDiferencial = _Resultado.Datos.Rows(0).Item("CuentaGastoXDiferencial")
                _CuentaRedondeo = _Resultado.Datos.Rows(0).Item("CuentaRedondeo")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.EmpresaParametroMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            _Resultado = _SDWCF.EmpresaParametroMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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

            _Resultado = _SDWCF.EmpresaParametroMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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

            _Resultado = _SDWCF.EmpresaParametroMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("EmpresaParametro_Id")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function GetProcesoAnnio() As Double
        Dim Res As Double = 0
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
            End With

            _Resultado = _SDWCF.EmpresaParametroMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                Res = _Resultado.Datos.Rows(0).Item("ProcesoAnnio")
            End If

        Catch ex As Exception
            Res = -1
        End Try

        Return Res
    End Function
    Public Function GetProcesoMes() As Double
        Dim Res As Double = 0
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
            End With

            _Resultado = _SDWCF.EmpresaParametroMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                Res = _Resultado.Datos.Rows(0).Item("ProcesoMes")
            End If

        Catch ex As Exception
            Res = -1
        End Try

        Return Res
    End Function
    Public Function GetMesCierreFiscal() As Double
        Dim Res As Double = 0
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
            End With

            _Resultado = _SDWCF.EmpresaParametroMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                Res = _Resultado.Datos.Rows(0).Item("MesCierreFiscal")
            End If

        Catch ex As Exception
            Res = -1
        End Try

        Return Res
    End Function
#End Region
End Class