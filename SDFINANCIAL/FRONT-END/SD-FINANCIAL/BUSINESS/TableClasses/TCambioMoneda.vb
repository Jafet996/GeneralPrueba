Public Class TCambioMoneda
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Cambio_Id As Integer
    Private _Tipo_Id As Integer
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _Efectivo As Double
    Private _Dolares As Double
    Private _TipoCambio As Double
    Private _Fecha As Datetime
    Private _Usuario_Id As String
    Private _UsuarioNombre As String
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTCambioMoneda
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
    Public Property Cambio_Id() As Integer
        Get
            Return _Cambio_Id
        End Get
        Set(ByVal Value As Integer)
            _Cambio_Id = Value
        End Set
    End Property
    Public Property Tipo_Id() As Integer
        Get
            Return _Tipo_Id
        End Get
        Set(ByVal Value As Integer)
            _Tipo_Id = Value
        End Set
    End Property
    Public Property Caja_Id() As Integer
        Get
            Return _Caja_Id
        End Get
        Set(ByVal Value As Integer)
            _Caja_Id = Value
        End Set
    End Property
    Public Property Cierre_Id() As Integer
        Get
            Return _Cierre_Id
        End Get
        Set(ByVal Value As Integer)
            _Cierre_Id = Value
        End Set
    End Property
    Public Property Efectivo() As Double
        Get
            Return _Efectivo
        End Get
        Set(ByVal Value As Double)
            _Efectivo = Value
        End Set
    End Property
    Public Property Dolares() As Double
        Get
            Return _Dolares
        End Get
        Set(ByVal Value As Double)
            _Dolares = Value
        End Set
    End Property
    Public Property TipoCambio() As Double
        Get
            Return _TipoCambio
        End Get
        Set(ByVal Value As Double)
            _TipoCambio = Value
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
    Public Property Usuario_Id() As String
        Get
            Return _Usuario_Id
        End Get
        Set(ByVal Value As String)
            _Usuario_Id = Value
        End Set
    End Property
    Public ReadOnly Property UsuarioNombre As String
        Get
            Return _UsuarioNombre
        End Get
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
        _Cambio_Id = 0
        _Tipo_Id = 0
        _Caja_Id = 0
        _Cierre_Id = 0
        _Efectivo = 0.0
        _Dolares = 0.0
        _TipoCambio = 0.0
        _Fecha = CDate("1900/01/01")
        _Usuario_Id = ""
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Cambio_Id = _Cambio_Id
                .Tipo_Id = _Tipo_Id
                .Caja_Id = _Caja_Id
                .Cierre_Id = _Cierre_Id
                .Efectivo = _Efectivo
                .Dolares = _Dolares
                .TipoCambio = _TipoCambio
                .Fecha = _Fecha
                .Usuario_Id = _Usuario_Id
            End With

            _Resultado = _SDWCF.CambioMonedaMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            _Cambio_Id = CInt(_Resultado.Valor)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function Delete() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Cambio_Id = _Cambio_Id
            End With

            _Resultado = _SDWCF.CambioMonedaMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Cambio_Id = _Cambio_Id
                .Tipo_Id = _Tipo_Id
                .Caja_Id = _Caja_Id
                .Cierre_Id = _Cierre_Id
                .Efectivo = _Efectivo
                .Dolares = _Dolares
                .TipoCambio = _TipoCambio
                .Fecha = _Fecha
                .Usuario_Id = _Usuario_Id
            End With

            _Resultado = _SDWCF.CambioMonedaMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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
                .Cambio_Id = _Cambio_Id
            End With

            _Resultado = _SDWCF.CambioMonedaMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _Cambio_Id = _Resultado.Datos.Rows(0).Item("Cambio_Id")
                _Tipo_Id = _Resultado.Datos.Rows(0).Item("Tipo_Id")
                _Caja_Id = _Resultado.Datos.Rows(0).Item("Caja_Id")
                _Cierre_Id = _Resultado.Datos.Rows(0).Item("Cierre_Id")
                _Efectivo = _Resultado.Datos.Rows(0).Item("Efectivo")
                _Dolares = _Resultado.Datos.Rows(0).Item("Dolares")
                _TipoCambio = _Resultado.Datos.Rows(0).Item("TipoCambio")
                _Fecha = _Resultado.Datos.Rows(0).Item("Fecha")
                _Usuario_Id = _Resultado.Datos.Rows(0).Item("Usuario_Id")
                _UsuarioNombre = _Resultado.Datos.Rows(0).Item("UsuarioNombre")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.CambioMonedaMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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

            _Resultado = _SDWCF.CambioMonedaMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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

            _Resultado = _SDWCF.CambioMonedaMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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

            _Resultado = _SDWCF.CambioMonedaMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Cambio_Id = _Resultado.Datos.Rows(0).Item("CambioMoneda_Id")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
End Class