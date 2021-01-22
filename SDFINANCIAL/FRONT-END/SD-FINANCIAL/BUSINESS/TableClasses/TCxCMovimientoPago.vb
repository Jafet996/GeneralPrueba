Public Class TCxCMovimientoPago
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Tipo_Id As Integer
    Private _Mov_Id As Long
    Private _Pago_Id As Integer
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _TipoPago_Id As Integer
    Private _Monto As Double
    Private _Banco_Id As Integer
    Private _Cuenta As String
    Private _ChequeNumero As String
    Private _ChequeFecha As DateTime
    Private _DepositoNumero As String
    Private _DepositoFecha As DateTime
    Private _TransferenciaNumero As String
    Private _Tarjeta_Id As Integer
    Private _TarjetaNumero As String
    Private _TarjetaAutorizacion As String
    Private _Moneda As Char
    Private _TipoCambio As Double
    Private _Dolares As Double
    Private _Fecha As DateTime
    Private _Batch_Id As Long
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTCxCMovimientoPago
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
    Public Property Tipo_Id() As Integer
        Get
            Return _Tipo_Id
        End Get
        Set(ByVal Value As Integer)
            _Tipo_Id = Value
        End Set
    End Property
    Public Property Mov_Id() As Long
        Get
            Return _Mov_Id
        End Get
        Set(ByVal Value As Long)
            _Mov_Id = Value
        End Set
    End Property
    Public Property Pago_Id() As Integer
        Get
            Return _Pago_Id
        End Get
        Set(ByVal Value As Integer)
            _Pago_Id = Value
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

    Public Property TipoPago_Id() As Integer
        Get
            Return _TipoPago_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoPago_Id = Value
        End Set
    End Property
    Public Property Monto() As Double
        Get
            Return _Monto
        End Get
        Set(ByVal Value As Double)
            _Monto = Value
        End Set
    End Property
    Public Property Banco_Id() As Integer
        Get
            Return _Banco_Id
        End Get
        Set(ByVal Value As Integer)
            _Banco_Id = Value
        End Set
    End Property
    Public Property Cuenta() As String
        Get
            Return _Cuenta
        End Get
        Set(ByVal Value As String)
            _Cuenta = Value
        End Set
    End Property
    Public Property ChequeNumero() As String
        Get
            Return _ChequeNumero
        End Get
        Set(ByVal Value As String)
            _ChequeNumero = Value
        End Set
    End Property
    Public Property ChequeFecha() As DateTime
        Get
            Return _ChequeFecha
        End Get
        Set(ByVal Value As DateTime)
            _ChequeFecha = Value
        End Set
    End Property
    Public Property DepositoNumero() As String
        Get
            Return _DepositoNumero
        End Get
        Set(ByVal Value As String)
            _DepositoNumero = Value
        End Set
    End Property
    Public Property DepositoFecha() As DateTime
        Get
            Return _DepositoFecha
        End Get
        Set(ByVal Value As DateTime)
            _DepositoFecha = Value
        End Set
    End Property
    Public Property TransferenciaNumero() As String
        Get
            Return _TransferenciaNumero
        End Get
        Set(ByVal Value As String)
            _TransferenciaNumero = Value
        End Set
    End Property
    Public Property Tarjeta_Id() As Integer
        Get
            Return _Tarjeta_Id
        End Get
        Set(ByVal Value As Integer)
            _Tarjeta_Id = Value
        End Set
    End Property
    Public Property TarjetaNumero() As String
        Get
            Return _TarjetaNumero
        End Get
        Set(ByVal Value As String)
            _TarjetaNumero = Value
        End Set
    End Property
    Public Property TarjetaAutorizacion() As String
        Get
            Return _TarjetaAutorizacion
        End Get
        Set(ByVal Value As String)
            _TarjetaAutorizacion = Value
        End Set
    End Property
    Public Property Moneda() As Char
        Get
            Return _Moneda
        End Get
        Set(ByVal Value As Char)
            _Moneda = Value
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
    Public Property Dolares() As Double
        Get
            Return _Dolares
        End Get
        Set(ByVal Value As Double)
            _Dolares = Value
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
    Public Property Batch_Id() As Long
        Get
            Return _Batch_Id
        End Get
        Set(ByVal Value As Long)
            _Batch_Id = Value
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
        _Tipo_Id = 0
        _Mov_Id = 0
        _Pago_Id = 0
        _Caja_Id = 0
        _Cierre_Id = 0
        _TipoPago_Id = 0
        _Monto = 0.0
        _Banco_Id = 0
        _Cuenta = ""
        _ChequeNumero = ""
        _ChequeFecha = CDate("1900/01/01")
        _DepositoNumero = ""
        _DepositoFecha = CDate("1900/01/01")
        _TransferenciaNumero = ""
        _Tarjeta_Id = 0
        _TarjetaNumero = ""
        _TarjetaAutorizacion = ""
        _Moneda = ""
        _TipoCambio = 0.0
        _Dolares = 0.0
        _Fecha = CDate("1900/01/01")
        _Batch_Id = 0
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Tipo_Id = _Tipo_Id
                .Mov_Id = _Mov_Id
                .Pago_Id = _Pago_Id
                .Caja_Id = _Caja_Id
                .Cierre_Id = _Cierre_Id
                .TipoPago_Id = _TipoPago_Id
                .Monto = _Monto
                .Banco_Id = _Banco_Id
                .Cuenta = _Cuenta
                .ChequeNumero = _ChequeNumero
                .ChequeFecha = _ChequeFecha
                .DepositoNumero = _DepositoNumero
                .DepositoFecha = _DepositoFecha
                .TransferenciaNumero = _TransferenciaNumero
                .Tarjeta_Id = _Tarjeta_Id
                .TarjetaNumero = _TarjetaNumero
                .TarjetaAutorizacion = _TarjetaAutorizacion
                .Moneda = _Moneda
                .TipoCambio = _TipoCambio
                .Dolares = _Dolares
                .Fecha = _Fecha
                .Batch_Id = _Batch_Id
            End With

            _Resultado = _SDWCF.CxCMovimientoPagoMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

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
                .Tipo_Id = _Tipo_Id
                .Mov_Id = _Mov_Id
                .Pago_Id = _Pago_Id
            End With

            _Resultado = _SDWCF.CxCMovimientoPagoMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Tipo_Id = _Tipo_Id
                .Mov_Id = _Mov_Id
                .Pago_Id = _Pago_Id
                .Caja_Id = _Caja_Id
                .Cierre_Id = _Cierre_Id
                .TipoPago_Id = _TipoPago_Id
                .Monto = _Monto
                .Banco_Id = _Banco_Id
                .Cuenta = _Cuenta
                .ChequeNumero = _ChequeNumero
                .ChequeFecha = _ChequeFecha
                .DepositoNumero = _DepositoNumero
                .DepositoFecha = _DepositoFecha
                .TransferenciaNumero = _TransferenciaNumero
                .Tarjeta_Id = _Tarjeta_Id
                .TarjetaNumero = _TarjetaNumero
                .TarjetaAutorizacion = _TarjetaAutorizacion
                .Moneda = _Moneda
                .TipoCambio = _TipoCambio
                .Dolares = _Dolares
                .Fecha = _Fecha
                .Batch_Id = _Batch_Id
            End With

            _Resultado = _SDWCF.CxCMovimientoPagoMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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
                .Tipo_Id = _Tipo_Id
                .Mov_Id = _Mov_Id
                .Pago_Id = _Pago_Id
            End With

            _Resultado = _SDWCF.CxCMovimientoPagoMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _Tipo_Id = _Resultado.Datos.Rows(0).Item("Tipo_Id")
                _Mov_Id = _Resultado.Datos.Rows(0).Item("Mov_Id")
                _Pago_Id = _Resultado.Datos.Rows(0).Item("Pago_Id")
                _Caja_Id = _Resultado.Datos.Rows(0).Item("Caja_Id")
                _Cierre_Id = _Resultado.Datos.Rows(0).Item("Cierre_Id")
                _TipoPago_Id = _Resultado.Datos.Rows(0).Item("TipoPago_Id")
                _Monto = _Resultado.Datos.Rows(0).Item("Monto")
                _Banco_Id = _Resultado.Datos.Rows(0).Item("Banco_Id")
                _Cuenta = _Resultado.Datos.Rows(0).Item("Cuenta")
                _ChequeNumero = _Resultado.Datos.Rows(0).Item("ChequeNumero")
                _ChequeFecha = _Resultado.Datos.Rows(0).Item("ChequeFecha")
                _DepositoNumero = _Resultado.Datos.Rows(0).Item("DepositoNumero")
                _DepositoFecha = _Resultado.Datos.Rows(0).Item("DepositoFecha")
                _TransferenciaNumero = _Resultado.Datos.Rows(0).Item("TransferenciaNumero")
                _Tarjeta_Id = _Resultado.Datos.Rows(0).Item("Tarjeta_Id")
                _TarjetaNumero = _Resultado.Datos.Rows(0).Item("TarjetaNumero")
                _TarjetaAutorizacion = _Resultado.Datos.Rows(0).Item("TarjetaAutorizacion")
                _Moneda = _Resultado.Datos.Rows(0).Item("Moneda")
                _TipoCambio = _Resultado.Datos.Rows(0).Item("TipoCambio")
                _Dolares = _Resultado.Datos.Rows(0).Item("Dolares")
                _Fecha = _Resultado.Datos.Rows(0).Item("Fecha")
                _Batch_Id = _Resultado.Datos.Rows(0).Item("Batch_Id")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.CxCMovimientoPagoMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            _Resultado = _SDWCF.CxCMovimientoPagoMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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

            _Resultado = _SDWCF.CxCMovimientoPagoMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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
                .Tipo_Id = _Tipo_Id
                .Mov_Id = _Mov_Id
            End With

            _Resultado = _SDWCF.CxCMovimientoPagoMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Pago_Id = _Resultado.Datos.Rows(0).Item("Pago_Id")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
End Class