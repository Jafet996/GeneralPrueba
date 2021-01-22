Imports BUSINESS
Public Class FrmMovimientoPagoElectronico
#Region "Enum"
    Private Enum Enum_Columnas
        TipoPagoNombre = 0
        Monto
        MontoDolares
        DepositoNumero
        TransferenciaNumero
        DepositoFecha
        Moneda
        TipoCambio
        Banco_Id
        Cuenta
        TipoPago_Id
    End Enum
#End Region
#Region "Constantes"
    Const Co_LeyendaFalta = "Falta"
    Const Co_LeyendaVuelto = "Vuelto"
#End Region
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private _Activado As Boolean
    Private _MovimientoPagos As New List(Of TCxCMovimientoPago)
    Private _PagoDocumento As Boolean = False
    Private _GeneraNotaCredito As Boolean = False
    Private _Vuelto As Double
    Private _TotalFactura As Double
    Private Co_ColorFaltante As System.Drawing.Color = Color.Red
    Private Co_ColorVuelto As System.Drawing.Color = Color.Blue
    Private _TipoCambio As Double = 1
#End Region
#Region "Propiedades"
    Public ReadOnly Property MovimientoPagos As List(Of TCxCMovimientoPago)
        Get
            Return _MovimientoPagos
        End Get
    End Property
    Public ReadOnly Property PagoDocumento As Boolean
        Get
            Return _PagoDocumento
        End Get
    End Property
    Public ReadOnly Property GeneraNotaCredito As Boolean
        Get
            Return _GeneraNotaCredito
        End Get
    End Property
    Public ReadOnly Property Vuelto As Double
        Get
            Return _Vuelto
        End Get
    End Property
    Public WriteOnly Property TotalFactura As Double
        Set(value As Double)
            _TotalFactura = value
        End Set
    End Property
#End Region
#Region "Formateo de Campos"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(1)

            Numerico(0) = New TNumericFormat(TxtMontoDeposito, 12, 2, False, "0", "#,##0.00")
            Numerico(1) = New TNumericFormat(TxtMontoTransferencia, 12, 2, False, "0", "#,##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Public Sub Execute()
        Try
            _TipoCambio = GetTipoCambioCierre(CajaInfo.Cierre_Id)
            AsignaLogo(PicLogo)
            CargaCombosBanco()
            HabilitaCamposPago()
            ConfiguraLista()
            _MovimientoPagos.Clear()
            _Vuelto = 0
            _Activado = False
            LblTotalFaltante.Text = Format(_TotalFactura, "#,##0.00")
            LblTotalFaltante.ForeColor = Co_ColorFaltante
            LblFaltaEtiqueta.ForeColor = Co_ColorFaltante
            TxtMontoDeposito.Text = Format(_TotalFactura, "#,##0.00")
            EnfocarTexto(TxtMontoDeposito)
            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaCombosBanco()
        Dim Banco As New TBanco

        Try
            Banco.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(Banco.LoadComboBoxEmpresaCuenta(CmbBancoDeposito))
            VerificaMensaje(Banco.LoadComboBoxEmpresaCuenta(CmbBancoTransferencia))

            CmbMonedaDeposito.SelectedIndex = 0
            CmbMonedaTransferencia.SelectedIndex = 0
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Banco = Nothing
        End Try
    End Sub

    Private Sub CargaComboCuentaDeposito()
        Dim EmpresaCuenta As New TEmpresaCuenta

        Try
            If CmbBancoDeposito.SelectedValue Is Nothing OrElse CmbBancoDeposito.SelectedValue.ToString.Equals("System.Data.DataRowView") Then
                Exit Sub
            End If

            CmbCuentaDeposito.DataSource = Nothing

            With EmpresaCuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Banco_Id = CmbBancoDeposito.SelectedValue
            End With
            VerificaMensaje(EmpresaCuenta.LoadComboBox(CmbCuentaDeposito))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            EmpresaCuenta = Nothing
        End Try
    End Sub

    Private Sub CargaComboCuentaTransferencia()
        Dim EmpresaCuenta As New TEmpresaCuenta

        Try
            If CmbBancoTransferencia.SelectedValue Is Nothing OrElse CmbBancoTransferencia.SelectedValue.ToString.Equals("System.Data.DataRowView") Then
                Exit Sub
            End If

            CmbCuentaTransferencia.DataSource = Nothing

            With EmpresaCuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Banco_Id = CmbBancoTransferencia.SelectedValue
            End With
            VerificaMensaje(EmpresaCuenta.LoadComboBox(CmbCuentaTransferencia))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            EmpresaCuenta = Nothing
        End Try
    End Sub

    Private Sub AsignaMonedaDeposito()
        Dim EmpresaCuenta As New TEmpresaCuenta

        Try
            If CmbCuentaDeposito.SelectedValue Is Nothing OrElse CmbCuentaDeposito.SelectedValue.ToString.Equals("System.Data.DataRowView") Then
                Exit Sub
            End If

            With EmpresaCuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cuenta_Id = CInt(CmbCuentaDeposito.SelectedValue)
            End With
            VerificaMensaje(EmpresaCuenta.ListKey)

            If EmpresaCuenta.RowsAffected = 0 Then
                VerificaMensaje("No se encontró la cuenta seleccionada")
            End If

            CmbMonedaDeposito.SelectedIndex = IIf(EmpresaCuenta.Moneda = coMonedaColones, 0, 1)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            EmpresaCuenta = Nothing
        End Try
    End Sub

    Private Sub AsignaMonedaTransferencia()
        Dim EmpresaCuenta As New TEmpresaCuenta

        Try
            If CmbCuentaTransferencia.SelectedValue Is Nothing OrElse CmbCuentaTransferencia.SelectedValue.ToString.Equals("System.Data.DataRowView") Then
                Exit Sub
            End If

            With EmpresaCuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cuenta_Id = CInt(CmbCuentaTransferencia.SelectedValue)
            End With
            VerificaMensaje(EmpresaCuenta.ListKey)

            If EmpresaCuenta.RowsAffected = 0 Then
                VerificaMensaje("No se encontró la cuenta seleccionada")
            End If

            CmbMonedaTransferencia.SelectedIndex = IIf(EmpresaCuenta.Moneda = coMonedaColones, 0, 1)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            EmpresaCuenta = Nothing
        End Try
    End Sub

    Private Function AsignaFaltanteCampo(pMoneda As Integer) As Double
        Dim Monto As Double = 0

        Try
            If LblFaltaEtiqueta.Text = Co_LeyendaFalta Then
                If pMoneda = 0 Then
                    Monto = CDbl(LblTotalFaltante.Text.Trim)
                Else
                    Monto = CDbl(LblTotalFaltante.Text) / _TipoCambio
                End If
            End If

        Catch ex As Exception
            Monto = -1
        End Try

        Return Monto
    End Function

    Private Sub HabilitaCamposPago()
        Try
            'Deposito
            CmbBancoDeposito.Enabled = RdbDeposito.Checked
            CmbCuentaDeposito.Enabled = RdbDeposito.Checked
            TxtMontoDeposito.Enabled = RdbDeposito.Checked
            TxtNumeroDeposito.Enabled = RdbDeposito.Checked
            DtpFechaDeposito.Enabled = RdbDeposito.Checked
            CmbMonedaDeposito.Enabled = RdbDeposito.Checked
            If Not RdbDeposito.Checked Then
                TxtMontoDeposito.Text = ""
                TxtNumeroDeposito.Text = ""
            Else
                TxtMontoDeposito.Text = Format(AsignaFaltanteCampo(CmbMonedaDeposito.SelectedIndex), "#,##0.00")
                EnfocarTexto(TxtMontoDeposito)
            End If

            'Transferencia
            CmbBancoTransferencia.Enabled = RdbTransferencia.Checked
            CmbCuentaTransferencia.Enabled = RdbTransferencia.Checked
            TxtMontoTransferencia.Enabled = RdbTransferencia.Checked
            TxtNumeroTransferencia.Enabled = RdbTransferencia.Checked
            DtpFechaTransferencia.Enabled = RdbTransferencia.Checked
            CmbMonedaTransferencia.Enabled = RdbTransferencia.Checked
            If Not RdbTransferencia.Checked Then
                TxtMontoTransferencia.Text = ""
                TxtNumeroTransferencia.Text = ""
            Else
                TxtMontoTransferencia.Text = Format(AsignaFaltanteCampo(CmbMonedaTransferencia.SelectedIndex), "#,##0.00")
                EnfocarTexto(TxtMontoTransferencia)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ConfiguraLista()
        Try
            With LvwListaPagos
                .Columns(Enum_Columnas.TipoPagoNombre).Text = "Tipo Pago"
                .Columns(Enum_Columnas.TipoPagoNombre).Width = 400

                .Columns(Enum_Columnas.Monto).Text = "Monto"
                .Columns(Enum_Columnas.Monto).Width = 260

                .Columns(Enum_Columnas.MontoDolares).Text = "Monto Dolares"
                .Columns(Enum_Columnas.MontoDolares).Width = 0

                .Columns(Enum_Columnas.DepositoNumero).Text = "Deposito Numero"
                .Columns(Enum_Columnas.DepositoNumero).Width = 0

                .Columns(Enum_Columnas.TransferenciaNumero).Text = "Transferencia Numero"
                .Columns(Enum_Columnas.TransferenciaNumero).Width = 0

                .Columns(Enum_Columnas.DepositoFecha).Text = "Fecha"
                .Columns(Enum_Columnas.DepositoFecha).Width = 0

                .Columns(Enum_Columnas.Moneda).Text = "Moneda"
                .Columns(Enum_Columnas.Moneda).Width = 0

                .Columns(Enum_Columnas.TipoCambio).Text = "Tipo Cambio"
                .Columns(Enum_Columnas.TipoCambio).Width = 0

                .Columns(Enum_Columnas.Banco_Id).Text = "Banco Id"
                .Columns(Enum_Columnas.Banco_Id).Width = 0

                .Columns(Enum_Columnas.Cuenta).Text = "Cuenta"
                .Columns(Enum_Columnas.Cuenta).Width = 0

                .Columns(Enum_Columnas.TipoPago_Id).Text = "Tipo Pago Id"
                .Columns(Enum_Columnas.TipoPago_Id).Width = 0
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub MuestraCalculadora()
        Try
            System.Diagnostics.Process.Start("calc.exe")
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function BuscaTipoPago(pTipoPago As Enum_TipoPago) As ListViewItem
        Dim i As Integer = 0

        Try
            For i = 0 To LvwListaPagos.Items.Count - 1
                If CInt(LvwListaPagos.Items(i).SubItems(Enum_Columnas.TipoPago_Id).Text) = pTipoPago Then
                    Return LvwListaPagos.Items(i)
                End If
            Next

            Return Nothing
        Catch ex As Exception
            MensajeError(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Function CalculaTotalPagado() As Double
        Dim i As Integer
        Dim TotalPagado As Double = 0

        For i = 0 To LvwListaPagos.Items.Count - 1
            TotalPagado = TotalPagado + CDbl(LvwListaPagos.Items(i).SubItems(Enum_Columnas.Monto).Text)
        Next

        CalculaTotalPagado = TotalPagado
    End Function

    Private Sub CalculaMontoFaltante()
        Dim TotalPagado As Double = 0

        TotalPagado = CalculaTotalPagado()
        LblTotalFaltante.Text = Format((_TotalFactura - TotalPagado), "#,##0.00")

        If CDbl(LblTotalFaltante.Text) > 0 Then
            LblFaltaEtiqueta.Text = Co_LeyendaFalta
        Else
            LblTotalFaltante.Text = Format(Math.Abs(CDbl(LblTotalFaltante.Text)), "#,##0.00")
            LblFaltaEtiqueta.Text = Co_LeyendaVuelto
        End If

        LblFaltaEtiqueta.ForeColor = IIf(LblFaltaEtiqueta.Text = Co_LeyendaFalta, Co_ColorFaltante, Co_ColorVuelto)
        LblTotalFaltante.ForeColor = IIf(LblFaltaEtiqueta.Text = Co_LeyendaFalta, Co_ColorFaltante, Co_ColorVuelto)
    End Sub

    Private Sub LimpiaDatosPago()
        Dim Fecha As Date = EmpresaInfo.Getdate
        'Deposito
        CmbBancoDeposito.SelectedIndex = 0
        CmbCuentaDeposito.SelectedIndex = 0
        TxtMontoDeposito.Text = ""
        TxtNumeroDeposito.Text = ""
        DtpFechaDeposito.Value = Fecha
        CmbMonedaDeposito.SelectedIndex = 0
        'Transferencia
        CmbBancoTransferencia.SelectedIndex = 0
        CmbCuentaTransferencia.SelectedIndex = 0
        TxtMontoTransferencia.Text = ""
        TxtNumeroTransferencia.Text = ""
        DtpFechaTransferencia.Value = Fecha
        CmbMonedaTransferencia.SelectedIndex = 0
    End Sub

    Private Function ValidaPago() As Boolean
        Try
            If RdbDeposito.Checked Then
                If CmbBancoDeposito.SelectedIndex = -1 Then
                    VerificaMensaje("Debe de seleccionar un banco válido")
                End If

                If CmbCuentaDeposito.SelectedIndex = -1 Then
                    VerificaMensaje("Debe de seleccionar una cuenta válida")
                End If

                If Not IsNumeric(TxtMontoDeposito.Text.Trim) Then
                    EnfocarTexto(TxtMontoDeposito)
                    VerificaMensaje("El monto del deposito debe ser númerico")
                End If

                If CDbl(TxtMontoDeposito.Text.Trim) <= 0 Then
                    EnfocarTexto(TxtMontoDeposito)
                    VerificaMensaje("El monto del deposito debe ser mayor a 0")
                End If

                If TxtNumeroDeposito.Text.Trim = "" Then
                    EnfocarTexto(TxtNumeroDeposito)
                    VerificaMensaje("Debe de digitar el número de deposito")
                End If

                If DateValue(DtpFechaDeposito.Value) > DateValue(EmpresaInfo.Getdate) Then
                    VerificaMensaje("La fecha del deposito no puede ser superior a la actual")
                End If

                If CmbMonedaDeposito.SelectedIndex = -1 Then
                    VerificaMensaje("Debe de seleccionar una moneda válida")
                End If
            End If

            If RdbTransferencia.Checked Then
                If CmbBancoTransferencia.SelectedIndex = -1 Then
                    VerificaMensaje("Debe de seleccionar un banco válido")
                End If

                If CmbCuentaTransferencia.SelectedIndex = -1 Then
                    VerificaMensaje("Debe de seleccionar una cuenta válida")
                End If

                If Not IsNumeric(TxtMontoTransferencia.Text.Trim) Then
                    EnfocarTexto(TxtMontoTransferencia)
                    VerificaMensaje("El monto de la transferencia debe ser númerico")
                End If

                If CDbl(TxtMontoTransferencia.Text.Trim) <= 0 Then
                    EnfocarTexto(TxtMontoTransferencia)
                    VerificaMensaje("El monto de la transferencia debe ser mayor a 0")
                End If

                If TxtNumeroTransferencia.Text.Trim = "" Then
                    EnfocarTexto(TxtNumeroTransferencia)
                    VerificaMensaje("Debe de digitar el número de transferencia")
                End If

                If DateValue(DtpFechaTransferencia.Value) > DateValue(EmpresaInfo.Getdate) Then
                    VerificaMensaje("La fecha de la transferencia no puede ser superior a la actual")
                End If

                If CmbMonedaTransferencia.SelectedIndex = -1 Then
                    VerificaMensaje("Debe de seleccionar una moneda válida")
                End If
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub AgregarPago()
        Dim Item As ListViewItem = Nothing
        Dim NewItem As ListViewItem = Nothing
        Dim SubItems(LvwListaPagos.Columns.Count - 1) As String
        Dim Banco As New TBanco
        'Deposito y Transferencia
        Dim TipoPagoId As Enum_TipoPago
        Dim TipoPagoNombre As String = ""
        Dim BancoId As String = ""
        Dim Cuenta As String = ""
        Dim NumeroDeposito As String = ""
        Dim NumeroTransferencia As String = ""
        Dim Fecha As Date = #1/1/1900#
        Dim Moneda As Char = "C"
        Dim Monto As String = ""
        Dim MontoDolares As String = "0"
        Dim TipoCambio As Double = 0

        Try
            TipoCambio = _TipoCambio

            'Deposito
            If RdbDeposito.Checked Then
                With Banco
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Banco_Id = CmbBancoDeposito.SelectedValue
                End With
                VerificaMensaje(Banco.ListKey)

                TipoPagoId = Enum_TipoPago.Deposito
                TipoPagoNombre = Banco.Nombre

                Monto = TxtMontoDeposito.Text.Trim * IIf(CmbMonedaDeposito.SelectedIndex = 0, 1, TipoCambio)
                If CmbMonedaDeposito.SelectedIndex = 2 Then MontoDolares = TxtMontoDeposito.Text.Trim
                BancoId = CmbBancoDeposito.SelectedValue
                Cuenta = CmbCuentaDeposito.Text
                NumeroDeposito = TxtNumeroDeposito.Text.Trim
                Fecha = DateValue(DtpFechaDeposito.Value)
                Moneda = IIf(CmbMonedaDeposito.SelectedIndex = 0, coMonedaColones, coMonedaDolares)
                EnfocarTexto(TxtMontoDeposito)
            End If

            'Transferencia
            If RdbTransferencia.Checked Then
                With Banco
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Banco_Id = CmbBancoTransferencia.SelectedValue
                End With
                VerificaMensaje(Banco.ListKey)

                TipoPagoId = Enum_TipoPago.Transferencia
                TipoPagoNombre = Banco.Nombre
                Monto = TxtMontoTransferencia.Text.Trim * IIf(CmbMonedaTransferencia.SelectedIndex = 0, 1, TipoCambio)
                If CmbMonedaTransferencia.SelectedIndex = 1 Then MontoDolares = TxtMontoTransferencia.Text.Trim
                BancoId = CmbBancoTransferencia.SelectedValue
                Cuenta = CmbCuentaTransferencia.Text
                NumeroTransferencia = TxtNumeroTransferencia.Text.Trim
                Fecha = DateValue(DtpFechaTransferencia.Value)
                Moneda = IIf(CmbMonedaTransferencia.SelectedIndex = 0, coMonedaColones, coMonedaDolares)

                EnfocarTexto(TxtMontoTransferencia)
            End If

            If Item Is Nothing Then
                Item = New ListViewItem(SubItems)

                With Item
                    .SubItems(Enum_Columnas.TipoPagoNombre).Text = TipoPagoNombre
                    .SubItems(Enum_Columnas.Monto).Text = Format(CDbl(Monto), "#,##0.00")
                    'Valores deposito y Transferencia
                    .SubItems(Enum_Columnas.DepositoNumero).Text = NumeroDeposito
                    .SubItems(Enum_Columnas.TransferenciaNumero).Text = NumeroTransferencia
                    .SubItems(Enum_Columnas.DepositoFecha).Text = Fecha
                    .SubItems(Enum_Columnas.Moneda).Text = Moneda
                    .SubItems(Enum_Columnas.TipoCambio).Text = IIf(Moneda = coMonedaColones, 1, TipoCambio)
                    .SubItems(Enum_Columnas.Banco_Id).Text = BancoId
                    .SubItems(Enum_Columnas.Cuenta).Text = Cuenta
                    .SubItems(Enum_Columnas.TipoPago_Id).Text = TipoPagoId
                    .SubItems(Enum_Columnas.MontoDolares).Text = Format(CDbl(MontoDolares), "#,##0.00")
                End With

                NewItem = LvwListaPagos.Items.Add(Item)

                LvwListaPagos.SelectedItems.Clear()
                LvwListaPagos.Items(NewItem.Index).Selected = True
                LvwListaPagos.TopItem = NewItem
            Else
                Item.SubItems(Enum_Columnas.Monto).Text = Format(CDbl(Item.SubItems(Enum_Columnas.Monto).Text) + CDbl(Monto), "#,##0.00")
                Item.SubItems(Enum_Columnas.MontoDolares).Text = Format(CDbl(Item.SubItems(Enum_Columnas.MontoDolares).Text) + CDbl(MontoDolares), "#,##0.00")
                LvwListaPagos.TopItem = Item
            End If

            CalculaMontoFaltante()
            LimpiaDatosPago()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Banco = Nothing
        End Try
    End Sub

    Private Sub EliminarPago()
        Try
            If LvwListaPagos.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un tipo de pago")
            End If

            LvwListaPagos.Items(LvwListaPagos.SelectedItems(0).Index).Remove()

            If LvwListaPagos.Items.Count > 0 Then
                LvwListaPagos.SelectedItems.Clear()
                LvwListaPagos.Items(0).Selected = True
                LvwListaPagos.TopItem = LvwListaPagos.Items(0)
            End If

            CalculaMontoFaltante()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function TotalxTipoPago(ByVal pTipoPago As Enum_TipoPago) As Double
        Dim i As Integer
        Dim Total As Double = 0

        Try
            For i = 0 To LvwListaPagos.Items.Count - 1
                If CInt(LvwListaPagos.Items(i).SubItems(Enum_Columnas.TipoPago_Id).Text) = pTipoPago Then
                    Total = Total + CDbl(LvwListaPagos.Items(i).SubItems(Enum_Columnas.Monto).Text)
                End If
            Next

            Return Total
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Private Function ValidaTodo() As Boolean
        Dim TotalPagado As Double = 0
        Dim TotalPagadoDeposito As Double = 0
        Dim TotalPagadoTransferencia As Double = 0

        Try
            'Total mixto
            TotalPagado = CalculaTotalPagado()
            'Total Deposito
            TotalPagadoDeposito = TotalxTipoPago(Enum_TipoPago.Deposito)
            'Total Transferencia
            TotalPagadoTransferencia = TotalxTipoPago(Enum_TipoPago.Transferencia)

            If TotalPagado < _TotalFactura Then
                VerificaMensaje("El monto ingresado es insuficiente")
            End If

            If (TotalPagadoTransferencia + TotalPagadoDeposito) > _TotalFactura Then
                If MsgBox("El monto de transacciones realizadas es mayor al total a cancelar ¿Desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, Me.Text) <> MsgBoxResult.Ok Then
                    Return False
                End If
                _GeneraNotaCredito = True
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Function GuardaPago() As String
        Dim MovimientoPago As TCxCMovimientoPago = Nothing
        Dim i As Integer = 0

        Try
            _MovimientoPagos.Clear()

            For i = 0 To LvwListaPagos.Items.Count - 1
                MovimientoPago = New TCxCMovimientoPago
                With MovimientoPago
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Caja_Id = CajaInfo.Caja_Id
                    .Cierre_Id = CajaInfo.Cierre_Id
                    .TipoPago_Id = CInt(LvwListaPagos.Items(i).SubItems(Enum_Columnas.TipoPago_Id).Text)

                    Select Case .TipoPago_Id
                        Case Enum_TipoPago.Deposito
                            .Monto = CDbl(LvwListaPagos.Items(i).SubItems(Enum_Columnas.Monto).Text)
                            .Banco_Id = CInt(LvwListaPagos.Items(i).SubItems(Enum_Columnas.Banco_Id).Text)
                            .Cuenta = LvwListaPagos.Items(i).SubItems(Enum_Columnas.Cuenta).Text
                            .DepositoNumero = CInt(LvwListaPagos.Items(i).SubItems(Enum_Columnas.DepositoNumero).Text)
                            .DepositoFecha = CDate(LvwListaPagos.Items(i).SubItems(Enum_Columnas.DepositoFecha).Text)
                            .TransferenciaNumero = ""
                            .Moneda = LvwListaPagos.Items(i).SubItems(Enum_Columnas.Moneda).Text
                            .TipoCambio = CDbl(LvwListaPagos.Items(i).SubItems(Enum_Columnas.TipoCambio).Text)
                            .Dolares = CDbl(LvwListaPagos.Items(i).SubItems(Enum_Columnas.MontoDolares).Text)
                        Case Enum_TipoPago.Transferencia
                            .Monto = CDbl(LvwListaPagos.Items(i).SubItems(Enum_Columnas.Monto).Text)
                            .Banco_Id = CInt(LvwListaPagos.Items(i).SubItems(Enum_Columnas.Banco_Id).Text)
                            .Cuenta = LvwListaPagos.Items(i).SubItems(Enum_Columnas.Cuenta).Text
                            .DepositoNumero = ""
                            .DepositoFecha = CDate(LvwListaPagos.Items(i).SubItems(Enum_Columnas.DepositoFecha).Text)
                            .TransferenciaNumero = CInt(LvwListaPagos.Items(i).SubItems(Enum_Columnas.TransferenciaNumero).Text)
                            .Moneda = LvwListaPagos.Items(i).SubItems(Enum_Columnas.Moneda).Text
                            .TipoCambio = CDbl(LvwListaPagos.Items(i).SubItems(Enum_Columnas.TipoCambio).Text)
                            .Dolares = CDbl(LvwListaPagos.Items(i).SubItems(Enum_Columnas.MontoDolares).Text)
                    End Select
                End With

                _MovimientoPagos.Add(MovimientoPago)
            Next

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            MovimientoPago = Nothing
        End Try
    End Function

    Private Sub Facturar()
        Try
            If ValidaTodo() Then
                BtnAgregar.Enabled = False

                VerificaMensaje(GuardaPago())

                _PagoDocumento = True
                _Vuelto = CDbl(LblTotalFaltante.Text)

                Me.Close()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnMuestraCalculadora_Click(sender As Object, e As EventArgs) Handles BtnMuestraCalculadora.Click
        MuestraCalculadora()
    End Sub

    Private Sub BtnFacturar_Click(sender As Object, e As EventArgs) Handles BtnFacturar.Click
        Facturar()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        If ValidaPago() Then
            AgregarPago()
        End If
    End Sub

    Private Sub RdbDeposito_CheckedChanged(sender As Object, e As EventArgs) Handles RdbDeposito.CheckedChanged
        HabilitaCamposPago()
    End Sub

    Private Sub RdbTransferencia_CheckedChanged(sender As Object, e As EventArgs) Handles RdbTransferencia.CheckedChanged
        HabilitaCamposPago()
    End Sub

    Private Sub TxtMontoDeposito_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMontoDeposito.KeyDown
        If e.KeyCode = Keys.Enter And TxtMontoDeposito.Text.Trim <> "" Then
            EnfocarTexto(TxtNumeroDeposito)
        End If
    End Sub

    Private Sub TxtNumeroDeposito_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNumeroDeposito.KeyDown
        If e.KeyCode = Keys.Enter And TxtNumeroDeposito.Text.Trim <> "" Then
            BtnAgregar.PerformClick()
        End If
    End Sub

    Private Sub TxtMontoTransferencia_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMontoTransferencia.KeyDown
        If e.KeyCode = Keys.Enter And TxtMontoTransferencia.Text.Trim <> "" Then
            EnfocarTexto(TxtNumeroTransferencia)
        End If
    End Sub

    Private Sub TxtNumeroTransferencia_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNumeroTransferencia.KeyDown
        If e.KeyCode = Keys.Enter And TxtNumeroTransferencia.Text.Trim <> "" Then
            BtnAgregar.PerformClick()
        End If
    End Sub

    Private Sub FrmMovimientoPagoElectronico_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    BtnMuestraCalculadora.PerformClick()
                Case Keys.F3
                    BtnFacturar.PerformClick()
                Case Keys.Escape
                    BtnCancelar.PerformClick()
                Case Keys.D And e.Alt
                    If RdbDeposito.Enabled Then
                        RdbDeposito.Select()
                    End If
                Case Keys.T And e.Alt
                    If RdbTransferencia.Enabled Then
                        RdbTransferencia.Select()
                    End If
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LvwListaPagos_KeyDown(sender As Object, e As KeyEventArgs) Handles LvwListaPagos.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                EliminarPago()
        End Select
    End Sub

    Private Sub CmbMonedaDeposito_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbMonedaDeposito.SelectedIndexChanged
        TxtMontoDeposito.Text = Format(AsignaFaltanteCampo(CmbMonedaDeposito.SelectedIndex), "#,##0.00")
    End Sub

    Private Sub CmbMonedaTransferencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbMonedaTransferencia.SelectedIndexChanged
        TxtMontoTransferencia.Text = Format(AsignaFaltanteCampo(CmbMonedaTransferencia.SelectedIndex), "#,##0.00")
    End Sub

    Private Sub CmbBancoDeposito_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbBancoDeposito.SelectedValueChanged
        CargaComboCuentaDeposito()
    End Sub

    Private Sub CmbBancoTransferencia_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbBancoTransferencia.SelectedValueChanged
        CargaComboCuentaTransferencia()
    End Sub

    Private Sub CmbCuentaDeposito_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbCuentaDeposito.SelectedValueChanged
        AsignaMonedaDeposito()
    End Sub

    Private Sub CmbCuentaTransferencia_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbCuentaTransferencia.SelectedValueChanged
        AsignaMonedaTransferencia()
    End Sub

    Private Sub FrmMovimientoPagoElectronico_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class