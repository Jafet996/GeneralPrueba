Imports Business
Public Class FrmMovimientoPagoFisico
#Region "Constantes"
    Const Co_LeyendaFalta = "Falta"
    Const Co_LeyendaVuelto = "Vuelto"
    Const ColTipoPagoNombre = 0
    Const ColMonto = 1
    Const ColTarjetaTipo_Nombre = 2
    Const ColTarjetaNumero = 3
    Const ColTarjetaAutorizacion = 4
    Const ColBancoTipo_Nombre = 5
    Const ColChequeNumero = 6
    Const ColChequeFecha = 7
    Const ColTarjetaTipo_Id = 8
    Const ColBancoTipo_Id = 9
    Const ColTipoPagoId = 10
    Const ColMontoDolares = 11
#End Region
#Region "Declaracion Variables"
    Private Numerico() As TNumericFormat
    Private _Activado As Boolean
    Private _MovimientoPagos As New List(Of TCxCMovimientoPago)
    Private _PagoDocumento As Boolean = False
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
            ReDim Numerico(5)

            Numerico(0) = New TNumericFormat(TxtEfectivoMonto, 12, 2, False, "0", "#,##0.00")
            Numerico(1) = New TNumericFormat(TxtTarjetaMonto, 12, 2, False, "0", "#,##0.00")
            Numerico(2) = New TNumericFormat(TxtTarjetaNumero, 4, 0, False, "", "###")
            Numerico(3) = New TNumericFormat(TxtTarjetaAutorizacion, 9, 0, False, "", "###")
            Numerico(4) = New TNumericFormat(TxtChequeMonto, 12, 2, False, "0", "#,##0.00")
            Numerico(5) = New TNumericFormat(TxtChequeNumero, 9, 0, False, "", "###")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub CargaCombos()
        Dim Tarjeta As New TTarjeta
        Dim Banco As New TBanco

        Try
            Tarjeta.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(Tarjeta.LoadComboBox(CmbTarjeta))

            Banco.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(Banco.LoadComboBox(CmbBanco))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Tarjeta = Nothing
            Banco = Nothing
        End Try
    End Sub

    Private Sub HabilitaCamposPago()
        Dim MontoPagoDolares As Double = 0

        Try
            'Efectivo
            TxtEfectivoMonto.Enabled = IIf(RdbEfectivoColones.Checked, True, False)
            If Not RdbEfectivoColones.Checked Then TxtEfectivoMonto.Text = ""
            'Tarjeta
            CmbTarjeta.Enabled = IIf(RdbTarjeta.Checked, True, False)
            TxtTarjetaMonto.Enabled = IIf(RdbTarjeta.Checked, True, False)
            TxtTarjetaNumero.Enabled = IIf(RdbTarjeta.Checked, True, False)
            TxtTarjetaAutorizacion.Enabled = IIf(RdbTarjeta.Checked, True, False)
            If Not RdbTarjeta.Checked Then TxtTarjetaMonto.Text = ""
            'Cheque
            CmbBanco.Enabled = IIf(RdbCheque.Checked, True, False)
            TxtChequeMonto.Enabled = IIf(RdbCheque.Checked, True, False)
            TxtChequeNumero.Enabled = IIf(RdbCheque.Checked, True, False)
            DtpChequeFecha.Enabled = IIf(RdbCheque.Checked, True, False)
            If Not RdbCheque.Checked Then TxtChequeMonto.Text = ""

            If RdbEfectivoColones.Checked Then
                If LblFaltaEtiqueta.Text = Co_LeyendaFalta Then
                    TxtEfectivoMonto.Text = LblTotalFaltante.Text
                Else
                    TxtEfectivoMonto.Text = "0.00"
                End If
                EnfocarTexto(TxtEfectivoMonto)
            End If

            If RdbTarjeta.Checked Then
                If LblFaltaEtiqueta.Text = Co_LeyendaFalta Then
                    TxtTarjetaMonto.Text = LblTotalFaltante.Text
                Else
                    TxtTarjetaMonto.Text = "0.00"
                End If
                EnfocarTexto(TxtTarjetaMonto)
            End If

            If RdbCheque.Checked Then
                If LblFaltaEtiqueta.Text = Co_LeyendaFalta Then
                    TxtChequeMonto.Text = LblTotalFaltante.Text
                Else
                    TxtChequeMonto.Text = "0.00"
                End If
                DtpChequeFecha.Value = DateValue(EmpresaInfo.Getdate())
                EnfocarTexto(TxtChequeMonto)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ConfiguraListView()
        With LvwListaPagos.Columns(ColTipoPagoNombre)
            .Text = "Tipo Pago"
            .Width = 500
        End With
        With LvwListaPagos.Columns(ColMonto)
            .Text = "Monto"
            .Width = 280
            .TextAlign = HorizontalAlignment.Right
        End With
        With LvwListaPagos.Columns(ColTarjetaTipo_Nombre)
            .Text = "Tarjeta"
            .Width = 0
        End With
        With LvwListaPagos.Columns(ColTarjetaNumero)
            .Text = "Tarjeta #"
            .Width = 0
            .TextAlign = HorizontalAlignment.Right
        End With
        With LvwListaPagos.Columns(ColTarjetaAutorizacion)
            .Text = "Auto #"
            .Width = 0
            .TextAlign = HorizontalAlignment.Right
        End With
        With LvwListaPagos.Columns(ColBancoTipo_Nombre)
            .Text = "Banco"
            .Width = 0
        End With
        With LvwListaPagos.Columns(ColChequeNumero)
            .Text = "Cheque/Trans #"
            .Width = 0
            .TextAlign = HorizontalAlignment.Right
        End With
        With LvwListaPagos.Columns(ColChequeFecha)
            .Text = "Fecha"
            .Width = 0
            .TextAlign = HorizontalAlignment.Center
        End With
        'Ocultas
        With LvwListaPagos.Columns(ColTarjetaTipo_Id)
            .Text = "tarjeta id"
            .Width = 0
        End With
        With LvwListaPagos.Columns(ColBancoTipo_Id)
            .Text = "banco id"
            .Width = 0
            .TextAlign = HorizontalAlignment.Right
        End With
        With LvwListaPagos.Columns(ColTipoPagoId)
            .Text = "pago id"
            .Width = 0
            .TextAlign = HorizontalAlignment.Right
        End With
        With LvwListaPagos.Columns(ColMontoDolares)
            .Text = "dolares"
            .Width = 0
            .TextAlign = HorizontalAlignment.Right
        End With
    End Sub

    Public Sub Execute()
        Try
            _TipoCambio = GetTipoCambioCierre(CajaInfo.Cierre_Id)
            LblTipoCambio.Text = Format(_TipoCambio, "#,##0.00")
            AsignaLogo(PicLogo)
            _MovimientoPagos.Clear()
            _Vuelto = 0
            TxtEfectivoMonto.Text = Format(_TotalFactura, "#,##0.00")
            TxtEfectivoMonto.SelectAll()

            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub

    Private Sub FrmPago_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If Not _Activado Then
            _Activado = True
            TxtEfectivoMonto.Focus()
        End If
    End Sub

    Private Sub FrmPago_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    MuestraCalculadora()
                Case Keys.F3
                    Facturar()
                Case Keys.Escape
                    Close()
                Case Keys.E And e.Alt
                    If RdbEfectivoColones.Enabled Then
                        RdbEfectivoColones.Select()
                        TxtEfectivoMonto.Focus()
                    End If
                Case Keys.T And e.Alt
                    If RdbTarjeta.Enabled Then
                        RdbTarjeta.Select()
                        TxtTarjetaMonto.Focus()
                    End If
                Case Keys.C And e.Alt
                    If RdbCheque.Enabled Then
                        RdbCheque.Select()
                        TxtChequeMonto.Focus()
                    End If
                Case Keys.P And e.Alt
                    If LvwListaPagos.Enabled And LvwListaPagos.Items.Count > 0 Then
                        LvwListaPagos.Focus()
                        LvwListaPagos.Items(0).Selected = True
                    End If
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmPagoFactura_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            _Activado = False
            LblTotalFaltante.Text = Format(_TotalFactura, "#,##0.00")
            LblTotalFaltante.ForeColor = Co_ColorFaltante
            LblFaltaEtiqueta.ForeColor = Co_ColorFaltante
            FormateaCamposNumericos()
            ConfiguraListView()
            CargaCombos()

            TxtEfectivoMonto.Focus()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub RdbEfectivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbEfectivoColones.CheckedChanged
        HabilitaCamposPago()
    End Sub

    Private Sub RdbTarjeta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbTarjeta.CheckedChanged
        HabilitaCamposPago()
    End Sub

    Private Sub RdbCheque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbCheque.CheckedChanged
        HabilitaCamposPago()
    End Sub

    Private Function ValidaDatosPago() As Boolean
        Try
            ValidaDatosPago = False

            If RdbEfectivoColones.Checked Then
                If Not IsNumeric(TxtEfectivoMonto.Text) Then
                    MsgBox("Debe de digitar un monto", MsgBoxStyle.Information, "Validación de datos")
                    EnfocarTexto(TxtEfectivoMonto)
                    Exit Function
                End If
                If CDbl(TxtEfectivoMonto.Text) <= 0 Then
                    MsgBox("El monto debe de ser mayor a cero", MsgBoxStyle.Information, "Validación de datos")
                    EnfocarTexto(TxtEfectivoMonto)
                    Exit Function
                End If
            End If

            If RdbTarjeta.Checked Then
                If Not IsNumeric(TxtTarjetaMonto.Text) Then
                    MsgBox("Debe de digitar un monto", MsgBoxStyle.Information, "Validación de datos")
                    EnfocarTexto(TxtTarjetaMonto)
                    Exit Function
                End If
                If CDbl(TxtTarjetaMonto.Text) <= 0 Then
                    MsgBox("El monto debe de ser mayor a cero", MsgBoxStyle.Information, "Validación de datos")
                    EnfocarTexto(TxtTarjetaMonto)
                    Exit Function
                End If

                If comparer.Equals(CmbTarjeta.SelectedValue, Nothing) Or CmbTarjeta.Items.Count = 0 Then
                    MsgBox("Debe de seleccionar el tipo de tarjeta", MsgBoxStyle.Information, "Validación de datos")
                    CmbTarjeta.Focus()
                    Exit Function
                End If

                If TxtTarjetaNumero.Text.Trim() = "" Then
                    MsgBox("Debe de digitar el número de tarjeta", MsgBoxStyle.Information, "Validación de datos")
                    EnfocarTexto(TxtTarjetaNumero)
                    Exit Function
                End If

                If TxtTarjetaAutorizacion.Text.Trim() = "" Then
                    MsgBox("Debe de digitar el número de autorización", MsgBoxStyle.Information, "Validación de datos")
                    EnfocarTexto(TxtTarjetaAutorizacion)
                    Exit Function
                End If
            End If

            If RdbCheque.Checked Then
                If Not IsNumeric(TxtChequeMonto.Text) Then
                    MsgBox("Debe de digitar un monto", MsgBoxStyle.Information, "Validación de datos")
                    EnfocarTexto(TxtChequeMonto)
                    Exit Function
                End If
                If CDbl(TxtChequeMonto.Text) <= 0 Then
                    MsgBox("El monto debe de ser mayor a cero", MsgBoxStyle.Information, "Validación de datos")
                    EnfocarTexto(TxtChequeMonto)
                    Exit Function
                End If

                If comparer.Equals(CmbBanco.SelectedValue, Nothing) Or CmbBanco.Items.Count = 0 Then
                    MsgBox("Debe de seleccionar el banco", MsgBoxStyle.Information, "Validación de datos")
                    CmbBanco.Focus()
                    Exit Function
                End If

            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub AgregarPago()
        Dim TipoPagoId As Enum_TipoPago
        Dim TipoPagoNombre As String = ""
        Dim Item As ListViewItem = Nothing
        Dim NewItem As ListViewItem = Nothing
        Dim SubItems(LvwListaPagos.Columns.Count - 1) As String
        Dim Monto As String = ""
        Dim MontoDolares As String = "0"
        'Tarjeta
        Dim TarjetaId As String = ""
        Dim TarjetaNombre As String = ""
        Dim TarjetaNumero As String = ""
        Dim TarjetaAutorizacion As String = ""
        'Cheque
        Dim ChequeBancoId As String = ""
        Dim ChequeBancoNombre As String = ""
        Dim ChequeNumero As String = ""
        Dim ChequeFecha As Date = #1/1/1900#
        Dim Banco As New TBanco

        Try
            'Efectivo
            If RdbEfectivoColones.Checked Then
                TipoPagoId = Enum_TipoPago.Efectivo
                TipoPagoNombre = "Efectivo"

                Monto = IIf(RdbEfectivoColones.Checked, TxtEfectivoMonto.Text, "")
                EnfocarTexto(TxtEfectivoMonto)

                'Busca si ya hay un pago en efectivo en la lista
                Item = BuscaTipoPago(Enum_TipoPago.Efectivo)
            End If

            'Tarjeta
            If RdbTarjeta.Checked Then
                TipoPagoId = Enum_TipoPago.Tarjeta
                TipoPagoNombre = "Tarjeta"

                Monto = TxtTarjetaMonto.Text
                TarjetaId = CmbTarjeta.SelectedValue
                TarjetaNombre = CmbTarjeta.Text
                TarjetaNumero = TxtTarjetaNumero.Text
                TarjetaAutorizacion = TxtTarjetaAutorizacion.Text

                EnfocarTexto(TxtTarjetaMonto)
            End If

            'Cheque
            If RdbCheque.Checked Then
                With Banco
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Banco_Id = CmbBanco.SelectedValue
                End With
                VerificaMensaje(Banco.ListKey())

                TipoPagoId = Enum_TipoPago.Cheque
                TipoPagoNombre = Banco.Nombre

                Monto = TxtChequeMonto.Text
                ChequeBancoId = CmbBanco.SelectedValue
                ChequeBancoNombre = CmbBanco.Text
                ChequeNumero = TxtChequeNumero.Text
                ChequeFecha = DtpChequeFecha.Value

                EnfocarTexto(TxtChequeMonto)
            End If

            If Item Is Nothing Then
                Item = New ListViewItem(SubItems)

                With Item
                    .SubItems(ColTipoPagoNombre).Text = TipoPagoNombre
                    .SubItems(ColMonto).Text = Format(CDbl(Monto), "#,##0.00")
                    'Valores tarjeta
                    .SubItems(ColTarjetaTipo_Nombre).Text = TarjetaNombre
                    .SubItems(ColTarjetaNumero).Text = TarjetaNumero
                    .SubItems(ColTarjetaAutorizacion).Text = TarjetaAutorizacion
                    'Valores cheque
                    .SubItems(ColBancoTipo_Nombre).Text = ChequeBancoNombre
                    .SubItems(ColChequeNumero).Text = ChequeNumero
                    .SubItems(ColChequeFecha).Text = ChequeFecha
                    'Ocultos
                    .SubItems(ColTarjetaTipo_Id).Text = TarjetaId
                    .SubItems(ColBancoTipo_Id).Text = ChequeBancoId
                    .SubItems(ColTipoPagoId).Text = TipoPagoId
                    .SubItems(ColMontoDolares).Text = Format(CDbl(MontoDolares), "#,##0.00")
                End With

                NewItem = LvwListaPagos.Items.Add(Item)

                LvwListaPagos.SelectedItems.Clear()
                LvwListaPagos.Items(NewItem.Index).Selected = True
                LvwListaPagos.TopItem = NewItem
            Else
                Item.SubItems(ColMonto).Text = Format(CDbl(Item.SubItems(ColMonto).Text) + CDbl(Monto), "#,##0.00")
                Item.SubItems(ColMontoDolares).Text = Format(CDbl(Item.SubItems(ColMontoDolares).Text) + CDbl(MontoDolares), "#,##0.00")
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

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ValidaDatosPago() Then
            AgregarPago()
        End If
    End Sub

    Private Function BuscaTipoPago(ByVal pTipoPago As Enum_TipoPago) As ListViewItem
        Dim i As Integer = 0

        Try
            BuscaTipoPago = Nothing

            For i = 0 To LvwListaPagos.Items.Count - 1
                If CInt(LvwListaPagos.Items(i).SubItems(ColTipoPagoId).Text) = pTipoPago Then
                    Return LvwListaPagos.Items(i)
                    Exit Function
                End If
            Next

        Catch ex As Exception
            BuscaTipoPago = Nothing
            MensajeError(ex.Message)
        End Try
    End Function

    Private Function TotalxTipoPago(ByVal pTipoPago As Enum_TipoPago) As Double
        Dim i As Integer
        Dim Total As Double = 0

        Try
            For i = 0 To LvwListaPagos.Items.Count - 1
                If CInt(LvwListaPagos.Items(i).SubItems(ColTipoPagoId).Text) = pTipoPago Then
                    Total = Total + CDbl(LvwListaPagos.Items(i).SubItems(ColMonto).Text)
                End If
            Next

            TotalxTipoPago = Total

        Catch ex As Exception
            Return -1
        End Try
    End Function

    Private Function CalculaTotalPagado() As Double
        Dim i As Integer
        Dim TotalPagado As Double = 0

        For i = 0 To LvwListaPagos.Items.Count - 1
            TotalPagado = TotalPagado + CDbl(LvwListaPagos.Items(i).SubItems(ColMonto).Text)
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

    Private Sub TxtEfectivoMonto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtEfectivoMonto.KeyDown
        If e.KeyCode = Keys.Enter And TxtEfectivoMonto.Text.Trim <> "" Then
            BtnAgregar_Click(BtnAgregar, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub LimpiaDatosPago()
        TxtEfectivoMonto.Text = ""
        TxtTarjetaMonto.Text = ""
        TxtTarjetaNumero.Text = ""
        TxtTarjetaAutorizacion.Text = ""
        TxtChequeMonto.Text = ""
        TxtChequeNumero.Text = ""
        DtpChequeFecha.Value = #1/1/1900#
    End Sub

    Private Sub TxtTarjetaMonto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTarjetaMonto.KeyDown
        If e.KeyCode = Keys.Enter And TxtTarjetaMonto.Text.Trim <> "" Then
            EnfocarTexto(TxtTarjetaNumero)
        End If
    End Sub

    Private Sub TxtTarjetaNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTarjetaNumero.KeyDown
        If e.KeyCode = Keys.Enter And TxtTarjetaNumero.Text.Trim <> "" Then
            EnfocarTexto(TxtTarjetaAutorizacion)
        End If
    End Sub

    Private Sub TxtTarjetaAutorizacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTarjetaAutorizacion.KeyDown
        If e.KeyCode = Keys.Enter And TxtTarjetaAutorizacion.Text.Trim <> "" Then
            BtnAgregar_Click(BtnAgregar, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub TxtChequeMonto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtChequeMonto.KeyDown
        If e.KeyCode = Keys.Enter And TxtChequeMonto.Text.Trim <> "" Then
            EnfocarTexto(TxtChequeNumero)
        End If
    End Sub

    Private Sub TxtChequeNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtChequeNumero.KeyDown
        If e.KeyCode = Keys.Enter And TxtChequeNumero.Text.Trim <> "" Then
            BtnAgregar_Click(BtnAgregar, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub MuestraCalculadora()
        Try
            System.Diagnostics.Process.Start("calc.exe")
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Dim TotalPagado As Double = 0
        Dim TotalPagadoTarjeta As Double = 0
        Dim TotalPagadoCheque As Double = 0

        Try
            'Total mixto
            TotalPagado = CalculaTotalPagado()
            'Total tarjeta
            TotalPagadoTarjeta = TotalxTipoPago(Enum_TipoPago.Tarjeta)
            'Total cheque
            TotalPagadoCheque = TotalxTipoPago(Enum_TipoPago.Cheque)

            If TotalPagado < _TotalFactura Then
                VerificaMensaje("Monto insuficiente")
            End If

            If (TotalPagadoCheque + TotalPagadoTarjeta) > _TotalFactura Then
                VerificaMensaje("El monto de tarjetas y cheques debe de ser menor o igual al total de la factura")
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
                    .TipoPago_Id = CInt(LvwListaPagos.Items(i).SubItems(ColTipoPagoId).Text)

                    Select Case .TipoPago_Id
                        Case Enum_TipoPago.Efectivo
                            .Monto = CDbl(LvwListaPagos.Items(i).SubItems(ColMonto).Text)
                            .Tarjeta_Id = 0
                            .TarjetaNumero = ""
                            .TarjetaAutorizacion = ""
                            .Banco_Id = 0
                            .ChequeNumero = ""
                            .ChequeFecha = #1/1/1900#
                            .DepositoNumero = ""
                            .TransferenciaNumero = ""
                            .Moneda = coMonedaColones
                            .TipoCambio = 1
                            .Dolares = 0
                            'Case Enum_TipoPago.Dolares
                            '    .Monto = CDbl(LvwListaPagos.Items(i).SubItems(ColMonto).Text)
                            '    .Tarjeta_Id = 0
                            '    .TarjetaNumero = ""
                            '    .TarjetaAutorizacion = ""
                            '    .Banco_Id = 0
                            '    .ChequeNumero = ""
                            '    .ChequeFecha = #1/1/1900#
                            '    .DepositoNumero = ""
                            '    .TransferenciaNumero = ""
                            '    .Moneda = coMonedaDolares
                            '    .TipoCambio = _TipoCambio
                            '    .Dolares = CDbl(LvwListaPagos.Items(i).SubItems(ColMontoDolares).Text)
                        Case Enum_TipoPago.Tarjeta
                            .Monto = CDbl(LvwListaPagos.Items(i).SubItems(ColMonto).Text)
                            .Tarjeta_Id = CInt(LvwListaPagos.Items(i).SubItems(ColTarjetaTipo_Id).Text)
                            .TarjetaNumero = CInt(LvwListaPagos.Items(i).SubItems(ColTarjetaNumero).Text)
                            .TarjetaAutorizacion = CInt(LvwListaPagos.Items(i).SubItems(ColTarjetaAutorizacion).Text)
                            .Banco_Id = 0
                            .ChequeNumero = ""
                            .ChequeFecha = #1/1/1900#
                            .DepositoNumero = ""
                            .TransferenciaNumero = ""
                            .Moneda = coMonedaColones
                            .TipoCambio = 1
                            .Dolares = 0
                        Case Enum_TipoPago.Cheque
                            .Monto = CDbl(LvwListaPagos.Items(i).SubItems(ColMonto).Text)
                            .Tarjeta_Id = 0
                            .TarjetaNumero = ""
                            .TarjetaAutorizacion = ""
                            .Banco_Id = CInt(LvwListaPagos.Items(i).SubItems(ColBancoTipo_Id).Text)
                            .ChequeNumero = CInt(LvwListaPagos.Items(i).SubItems(ColChequeNumero).Text)
                            .ChequeFecha = CDate(LvwListaPagos.Items(i).SubItems(ColChequeFecha).Text)
                            .DepositoNumero = ""
                            .TransferenciaNumero = ""
                            .Moneda = coMonedaColones
                            .TipoCambio = 1
                            .Dolares = 0
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

    Private Sub LvwListaPagos_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles LvwListaPagos.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Delete
                    EliminarPago()
            End Select
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

End Class