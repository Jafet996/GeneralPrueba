Public Class TBcoPago
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _BcoPago_Id As Long
    Private _TipoPago_Id As Integer
    Private _Prov_Id As Integer
    Private _Banco_Id As Integer
    Private _Cuenta As String
    Private _Moneda As Char
    Private _Fecha As DateTime
    Private _Monto As Double
    Private _TipoCambio As Double
    Private _Dolares As Double
    Private _Usuario_Id As String
    Private _Concepto As String
    Private _Cheque As TBcoPagoCheque
    Private _Transferencia As TBcoPagoTransferencia
    Private _ListaSolicitudes As New List(Of TCxPSolicitudPago)
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTBcoPago
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
    Public Property BcoPago_Id() As Long
        Get
            Return _BcoPago_Id
        End Get
        Set(ByVal Value As Long)
            _BcoPago_Id = Value
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
    Public Property Prov_Id As Long
        Get
            Return _Prov_Id
        End Get
        Set(value As Long)
            _Prov_Id = value
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
    Public Property Moneda() As Char
        Get
            Return _Moneda
        End Get
        Set(ByVal Value As Char)
            _Moneda = Value
        End Set
    End Property
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As DateTime)
            _Fecha = Value
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
    Public Property Usuario_Id() As String
        Get
            Return _Usuario_Id
        End Get
        Set(ByVal Value As String)
            _Usuario_Id = Value
        End Set
    End Property
    Public Property Concepto() As String
        Get
            Return _Concepto
        End Get
        Set(ByVal Value As String)
            _Concepto = Value
        End Set
    End Property
    Public Property Cheque() As TBcoPagoCheque
        Get
            Return _Cheque
        End Get
        Set(value As TBcoPagoCheque)
            _Cheque = value
        End Set
    End Property
    Public Property Transferencia() As TBcoPagoTransferencia
        Get
            Return _Transferencia
        End Get
        Set(value As TBcoPagoTransferencia)
            _Transferencia = value
        End Set
    End Property
    Public Property ListaSolicitudes() As List(Of TCxPSolicitudPago)
        Get
            Return _ListaSolicitudes
        End Get
        Set(value As List(Of TCxPSolicitudPago))
            _ListaSolicitudes = value
        End Set
    End Property
    Public ReadOnly Property RowsAffected() As Long
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
        _BcoPago_Id = 0
        _TipoPago_Id = 0
        _Prov_Id = 0
        _Banco_Id = 0
        _Cuenta = ""
        _Moneda = ""
        _Fecha = CDate("1900/01/01")
        _Monto = 0.0
        _TipoCambio = 0.0
        _Dolares = 0.0
        _Usuario_Id = ""
        _Concepto = ""
        _Cheque = New TBcoPagoCheque
        _Transferencia = New TBcoPagoTransferencia
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Detalle As SDFinancial.DTCxPSolicitudPago
        Dim Lista As New List(Of SDFinancial.DTCxPSolicitudPago)
        Dim CxPMovimiento As TCxPMovimiento = Nothing

        Try
            For Each Item As TCxPSolicitudPago In _ListaSolicitudes
                Detalle = New SDFinancial.DTCxPSolicitudPago

                With Detalle
                    .Emp_Id = Item.Emp_Id
                    .Solicitud_Id = Item.Solicitud_Id
                    .Tipo_Id = Item.Tipo_Id
                    .Mov_Id = Item.Mov_Id
                    .Monto = Item.Monto
                    .PagoMonto = Item.PagoMonto
                    .PagoDolares = Item.PagoDolares
                    .Diferencial = Item.Diferencial
                End With

                Lista.Add(Detalle)
            Next

            With _DTabla
                .Emp_Id = _Emp_Id
                .BcoPago_Id = _BcoPago_Id
                .TipoPago_Id = _TipoPago_Id
                .Prov_Id = _Prov_Id
                .Banco_Id = _Banco_Id
                .Cuenta = _Cuenta
                .Moneda = _Moneda
                .Fecha = _Fecha
                .Monto = _Monto
                .TipoCambio = _TipoCambio
                .Dolares = _Dolares
                .Usuario_Id = _Usuario_Id
                .Concepto = _Concepto
                .ListaSolicitudes = Lista.ToArray
            End With

            _DTabla.Cheque = New SDFinancial.DTBcoPagoCheque

            With _DTabla.Cheque
                .Nombre = _Cheque.Nombre
                .Fecha = _Cheque.Fecha
            End With

            _DTabla.Transferencia = New SDFinancial.DTBcoPagoTransferencia

            With _DTabla.Transferencia
                .Banco_Id = _Transferencia.Banco_Id
                .Cuenta = _Transferencia.Cuenta
                .Moneda = _Transferencia.Moneda
                .Fecha = _Transferencia.Fecha
                .TipoCambio = _Transferencia.TipoCambio
                .Numero = _Transferencia.Numero
            End With

            _Resultado = _SDWCF.BcoPagoMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If IsNumeric(_Resultado.Valor.Trim) Then
                _BcoPago_Id = CLng(_Resultado.Valor.Trim)
            End If

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                For Each Fila As DataRow In _Resultado.Datos.Rows
                    CxPMovimiento = New TCxPMovimiento

                    With CxPMovimiento
                        .Emp_Id = EmpresaInfo.Emp_Id
                        .Tipo_Id = CInt(Fila("Tipo_Id"))
                        .Mov_Id = CLng(Fila("Mov_Id"))
                    End With
                    VerificaMensaje(CxPMovimiento.ListKey)

                    If Not CxPMovimiento.Encontro Then
                        VerificaMensaje("No se encontró el movimiento seleccionado")
                    End If

                    Select Case CxPMovimiento.Tipo_Id
                        Case Enum_CxPMovimientoTipo.Pago
                            GeneraAsientoPago(CxPMovimiento)
                        Case Enum_CxPMovimientoTipo.NotaCredito, Enum_CxPMovimientoTipo.NotaDebito
                            GeneraAsientoDiferencialCambiario(CxPMovimiento)
                    End Select
                Next
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function Delete() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .BcoPago_Id = _BcoPago_Id
            End With

            _Resultado = _SDWCF.BcoPagoMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .BcoPago_Id = _BcoPago_Id
                .TipoPago_Id = _TipoPago_Id
                .Prov_Id = _Prov_Id
                .Banco_Id = _Banco_Id
                .Cuenta = _Cuenta
                .Moneda = _Moneda
                .Fecha = _Fecha
                .Monto = _Monto
                .TipoCambio = _TipoCambio
                .Dolares = _Dolares
                .Usuario_Id = _Usuario_Id
                .Concepto = _Concepto
            End With

            _Resultado = _SDWCF.BcoPagoMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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
                .BcoPago_Id = _BcoPago_Id
            End With

            _Resultado = _SDWCF.BcoPagoMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _BcoPago_Id = _Resultado.Datos.Rows(0).Item("BcoPago_Id")
                _TipoPago_Id = _Resultado.Datos.Rows(0).Item("TipoPago_Id")
                _Prov_Id = _Resultado.Datos.Rows(0).Item("Prov_Id")
                _Banco_Id = _Resultado.Datos.Rows(0).Item("Banco_Id")
                _Cuenta = _Resultado.Datos.Rows(0).Item("Cuenta")
                _Moneda = _Resultado.Datos.Rows(0).Item("Moneda")
                _Fecha = _Resultado.Datos.Rows(0).Item("Fecha")
                _Monto = _Resultado.Datos.Rows(0).Item("Monto")
                _TipoCambio = _Resultado.Datos.Rows(0).Item("TipoCambio")
                _Dolares = _Resultado.Datos.Rows(0).Item("Dolares")
                _Usuario_Id = _Resultado.Datos.Rows(0).Item("Usuario_Id")
                _Concepto = _Resultado.Datos.Rows(0).Item("Concepto")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.BcoPagoMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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

            _Resultado = _SDWCF.BcoPagoMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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

            _Resultado = _SDWCF.BcoPagoMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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

            _Resultado = _SDWCF.BcoPagoMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _BcoPago_Id = _Resultado.Datos.Rows(0).Item("BcoPago_Id")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function RptComprobanteTransferencia() As String
        Dim Query As String

        Try
            Query = "exec RptComprobanteTransferencia " & _Emp_Id.ToString & "," & _BcoPago_Id.ToString

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
    Public Function RptComprobanteCheque() As String
        Dim Query As String

        Try
            Query = "exec RptComprobanteCheque " & _Emp_Id.ToString & "," & _BcoPago_Id.ToString

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
    Public Function GeneraAsientoPago(pCxPMovimiento As TCxPMovimiento) As String
        Dim AsientoEncabezado As New TAuxAsientoEncabezado
        Dim AsientoDetalle As TAuxAsientoDetalle = Nothing
        Dim Proveedor As New TProveedor
        Dim CuentaBanco As String = String.Empty
        Dim MontoColones As Double = 0.0
        Dim MontoDolares As Double = 0.0
        Dim MontoDebe As Double = 0.0
        Dim MontoHaber As Double = 0.0
        Dim Redondeo As Double = 0.0
        Dim Linea As Integer = 1

        Try
            With Proveedor
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = pCxPMovimiento.Prov_Id
            End With
            VerificaMensaje(Proveedor.ListKey)

            If Proveedor.CxP_Colones.Trim = "" Then
                VerificaMensaje("El proveedor no tiene una cuenta contable asignada")
            End If

            If Proveedor.CxP_Dolares.Trim = "" Then
                VerificaMensaje("El proveedor no tiene una cuenta contable asignada")
            End If

            VerificaMensaje(pCxPMovimiento.MovimientosAplicados)

            If pCxPMovimiento.RowsAffected = 0 Then
                VerificaMensaje("No se encontró el detalle del movimiento")
            End If

            For Each Fila As DataRow In pCxPMovimiento.Datos.Tables(0).Rows
                Select Case Fila("Moneda")
                    Case coMonedaColones
                        MontoColones += CDbl(Fila("Monto"))
                    Case coMonedaDolares
                        MontoDolares += CDbl(Fila("Monto"))
                End Select
                MontoDebe += CDbl(Fila("Monto"))
            Next

            If MontoColones > 0 Then
                AsientoDetalle = New TAuxAsientoDetalle

                With AsientoDetalle
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Linea_Id = Linea
                    .Fecha = pCxPMovimiento.Fecha
                    .Moneda = coMonedaColones
                    .CC_Id = 0
                    .Cuenta_Id = Proveedor.CxP_Colones
                    .Tipo = coDebe
                    .Monto = MontoColones
                    .MontoDolares = 0
                    .TipoCambio = 1
                    .Referencia = ""
                    .Descripcion = "PAGO DE SOLICITUDES"
                End With

                AsientoEncabezado.ListaDetalle.Add(AsientoDetalle)

                Linea += 1
                AsientoDetalle = Nothing
            End If

            If MontoDolares > 0 Then
                AsientoDetalle = New TAuxAsientoDetalle

                With AsientoDetalle
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Linea_Id = Linea
                    .Fecha = pCxPMovimiento.Fecha
                    .Moneda = coMonedaDolares
                    .CC_Id = 0
                    .Cuenta_Id = Proveedor.CxP_Dolares
                    .Tipo = coDebe
                    .Monto = MontoDolares
                    .MontoDolares = MontoDolares / TipoCambioBancos()
                    .TipoCambio = TipoCambioBancos()
                    .Referencia = ""
                    .Descripcion = "PAGO DE SOLICITUDES"
                End With

                AsientoEncabezado.ListaDetalle.Add(AsientoDetalle)

                Linea += 1
                AsientoDetalle = Nothing
            End If

            Redondeo = (MontoColones + MontoDolares) - Math.Abs(pCxPMovimiento.Monto)

            If Redondeo < 0 Then
                AsientoDetalle = New TAuxAsientoDetalle

                With AsientoDetalle
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Linea_Id = Linea
                    .Fecha = pCxPMovimiento.Fecha
                    .Moneda = coMonedaColones
                    .CC_Id = 0
                    .Cuenta_Id = EmpresaParametroInfo.CuentaRedondeo
                    .Tipo = coDebe
                    .Monto = Math.Abs(Redondeo)
                    .MontoDolares = 0
                    .TipoCambio = 1
                    .Referencia = ""
                    .Descripcion = "REDONDEO"
                End With

                AsientoEncabezado.ListaDetalle.Add(AsientoDetalle)

                Linea += 1
                AsientoDetalle = Nothing
                MontoDebe += Redondeo
            End If

            VerificaMensaje(pCxPMovimiento.ObtieneCuentaContable)

            If pCxPMovimiento.RowsAffected = 0 Then
                VerificaMensaje("No se encontró la cuenta contable del banco")
            End If

            CuentaBanco = pCxPMovimiento.Datos.Tables("Cuenta").Rows(0).Item(0).ToString

            If Not ValidaCuentaContable(CuentaBanco) Then
                VerificaMensaje("La cuenta contable no es válida")
            End If

            AsientoDetalle = New TAuxAsientoDetalle

            With AsientoDetalle
                .Emp_Id = EmpresaInfo.Emp_Id
                .Linea_Id = Linea
                .Fecha = pCxPMovimiento.Fecha
                .Moneda = pCxPMovimiento.Moneda
                .CC_Id = 0
                .Cuenta_Id = CuentaBanco
                .Tipo = coHaber
                .Monto = Math.Abs(pCxPMovimiento.Monto)
                .MontoDolares = pCxPMovimiento.Dolares
                .TipoCambio = pCxPMovimiento.TipoCambio
                .Referencia = ""
                .Descripcion = "PAGO DE SOLICITUDES"
            End With

            AsientoEncabezado.ListaDetalle.Add(AsientoDetalle)

            Linea += 1
            AsientoDetalle = Nothing
            MontoHaber += Math.Abs(pCxPMovimiento.Monto)

            If Redondeo < 0 Then
                AsientoDetalle = New TAuxAsientoDetalle

                With AsientoDetalle
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Linea_Id = Linea
                    .Fecha = pCxPMovimiento.Fecha
                    .Moneda = coMonedaColones
                    .CC_Id = 0
                    .Cuenta_Id = EmpresaParametroInfo.CuentaRedondeo
                    .Tipo = coHaber
                    .Monto = Math.Abs(Redondeo)
                    .MontoDolares = 0
                    .TipoCambio = 1
                    .Referencia = ""
                    .Descripcion = "REDONDEO"
                End With

                AsientoEncabezado.ListaDetalle.Add(AsientoDetalle)

                Linea += 1
                AsientoDetalle = Nothing
                MontoHaber += Math.Abs(Redondeo)
            End If

            With AsientoEncabezado
                .Emp_Id = EmpresaInfo.Emp_Id
                .Annio = CDate(pCxPMovimiento.Fecha).Year
                .Mes = CDate(pCxPMovimiento.Fecha).Month
                .Fecha = pCxPMovimiento.Fecha
                .Tipo_Id = Enum_AsientoTipo.PagoFactura
                .Comentario = "PAGO DE FACTURAS"
                .Debitos = (MontoColones + MontoDolares)
                .Creditos = Math.Abs(pCxPMovimiento.Monto)
                .Usuario_Id = pCxPMovimiento.Usuario_Id
                .Origen_Id = Enum_AsientoOrigen.CXP
                .MAC_Address = InfoMaquina.MAC_Address
            End With
            VerificaMensaje(AsientoEncabezado.Insert)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            AsientoEncabezado = Nothing
            Proveedor = Nothing
        End Try
    End Function
    Public Function GeneraAsientoDiferencialCambiario(pCxPMovimiento As TCxPMovimiento) As String
        Dim AsientoEncabezado As New TAuxAsientoEncabezado
        Dim AsientoDetalle As TAuxAsientoDetalle = Nothing
        Dim Proveedor As New TProveedor
        Dim CuentaDebe As String = ""
        Dim CuentaHaber As String = ""
        Dim Linea As Integer = 1

        Try
            With Proveedor
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = pCxPMovimiento.Prov_Id
            End With
            VerificaMensaje(Proveedor.ListKey)

            If Proveedor.CxP_Dolares.Trim = "" Then
                VerificaMensaje("El proveedor no tiene una cuenta contable asignada")
            End If

            Select Case pCxPMovimiento.Tipo_Id
                Case Enum_CxPMovimientoTipo.NotaDebito
                    CuentaDebe = EmpresaParametroInfo.CuentaGastoXDiferencial
                    CuentaHaber = Proveedor.CxP_Dolares
                Case Enum_CxPMovimientoTipo.NotaCredito
                    CuentaDebe = Proveedor.CxP_Dolares
                    CuentaHaber = EmpresaParametroInfo.CuentaIngresoXDiferencial
            End Select

            'Debe
            AsientoDetalle = New TAuxAsientoDetalle

            With AsientoDetalle
                .Emp_Id = EmpresaInfo.Emp_Id
                .Linea_Id = Linea
                .Fecha = pCxPMovimiento.Fecha
                .Moneda = coMonedaDolares
                .CC_Id = 0
                .Cuenta_Id = CuentaDebe
                .Tipo = coDebe
                .Monto = Math.Abs(pCxPMovimiento.Monto)
                .MontoDolares = pCxPMovimiento.Dolares
                .TipoCambio = pCxPMovimiento.TipoCambio
                .Referencia = ""
                .Descripcion = "DIFERENCIAL CAMBIARIO"
            End With

            AsientoEncabezado.ListaDetalle.Add(AsientoDetalle)

            Linea += 1
            AsientoDetalle = Nothing

            'Haber
            AsientoDetalle = New TAuxAsientoDetalle

            With AsientoDetalle
                .Emp_Id = EmpresaInfo.Emp_Id
                .Linea_Id = Linea
                .Fecha = pCxPMovimiento.Fecha
                .Moneda = coMonedaDolares
                .CC_Id = 0
                .Cuenta_Id = CuentaHaber
                .Tipo = coHaber
                .Monto = Math.Abs(pCxPMovimiento.Monto)
                .MontoDolares = pCxPMovimiento.Dolares
                .TipoCambio = pCxPMovimiento.TipoCambio
                .Referencia = ""
                .Descripcion = "DIFERENCIAL CAMBIARIO"
            End With

            AsientoEncabezado.ListaDetalle.Add(AsientoDetalle)

            Linea += 1
            AsientoDetalle = Nothing

            'Encabezado
            With AsientoEncabezado
                .Emp_Id = EmpresaInfo.Emp_Id
                .Annio = CDate(pCxPMovimiento.Fecha).Year
                .Mes = CDate(pCxPMovimiento.Fecha).Month
                .Fecha = pCxPMovimiento.Fecha
                .Tipo_Id = Enum_AsientoTipo.PagoFactura
                .Comentario = "AJUSTE POR DIFERENCIAL CAMBIARIO"
                .Debitos = Math.Abs(pCxPMovimiento.Monto)
                .Creditos = Math.Abs(pCxPMovimiento.Monto)
                .Usuario_Id = pCxPMovimiento.Usuario_Id
                .Origen_Id = Enum_AsientoOrigen.CXP
                .MAC_Address = InfoMaquina.MAC_Address
            End With
            VerificaMensaje(AsientoEncabezado.Insert)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            AsientoEncabezado = Nothing
            Proveedor = Nothing
        End Try
    End Function
#End Region
End Class