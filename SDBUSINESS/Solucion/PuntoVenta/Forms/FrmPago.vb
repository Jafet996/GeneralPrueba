Imports Business
Public Class FrmPago

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
    Const ColDolares = 11
#End Region

#Region "Declaracion Variables"
    Private NumericFormat(6) As TNumericFormat
    Private _Activado As Boolean
    Private _FacturaPagos As New List(Of TFacturaPago)
    Private _PagoDocumento As Boolean
    Private _Vuelto As Double
    Private _TotalEfectivo As Double
    Private _SubTotal As Double
    Private _Descuento As Double
    Private _ImpuestoVenta As Double
    Private _TotalFactura As Double
    Private _Cliente_Id As Integer
    Private _TotalDevuelveIV As Double
    Private _TotalCobradoIV As Double
    Private TotalCalculaIV As Double
    Private _CalculaIVSobrante As Double

#End Region

#Region "Propiedades"
    Public ReadOnly Property FacturaPagos As List(Of TFacturaPago)
        Get
            Return _FacturaPagos
        End Get
    End Property
    Public ReadOnly Property PagoDocumento As Boolean
        Get
            Return _PagoDocumento
        End Get
    End Property
    Public WriteOnly Property SubTotal As Double
        Set(value As Double)
            _SubTotal = value
        End Set
    End Property
    Public WriteOnly Property Descuento As Double
        Set(value As Double)
            _Descuento = value
        End Set
    End Property
    Public WriteOnly Property ImpuestoVenta As Double
        Set(value As Double)
            _ImpuestoVenta = value
        End Set
    End Property
    Public WriteOnly Property TotalFactura As Double
        Set(value As Double)
            _TotalFactura = value
        End Set
    End Property
    Public ReadOnly Property Vuelto As Double
        Get
            Return _Vuelto
        End Get
    End Property
    Public ReadOnly Property TotalEfectivo As Double
        Get
            Return _TotalEfectivo
        End Get
    End Property
    Public WriteOnly Property Cliente_Id As Integer
        Set(value As Integer)
            _Cliente_Id = value
        End Set
    End Property
    Public Property TotalDevuelveIV As Double
        Get
            Return _TotalDevuelveIV
        End Get
        Set(ByVal value As Double)
            _TotalDevuelveIV = value
        End Set
    End Property
    Public Property TotalCobradoIV As Double
        Get
            Return _TotalCobradoIV
        End Get
        Set(ByVal value As Double)
            _TotalCobradoIV = value
        End Set
    End Property
    Public Property CalculaIVSobrante As Double
        Get
            Return _CalculaIVSobrante
        End Get
        Set(ByVal value As Double)
            _CalculaIVSobrante = value
        End Set
    End Property
#End Region
    Private Sub ConfiguraTextosNumericos()
        NumericFormat(0) = New TNumericFormat(TxtEfectivoMonto, 9, 2, False, "0")
        NumericFormat(1) = New TNumericFormat(TxtTarjetaMonto, 9, 2, False, "0")
        NumericFormat(2) = New TNumericFormat(TxtTarjetaNumero, 4, 0, False, "", "###")
        NumericFormat(3) = New TNumericFormat(TxtTarjetaAutorizacion, 9, 0, False, "", "###")
        NumericFormat(4) = New TNumericFormat(TxtChequeMonto, 9, 2, False, "0")
        NumericFormat(5) = New TNumericFormat(TxtChequeNumero, 9, 0, False, "", "###")
        NumericFormat(0) = New TNumericFormat(TxtDolaresMonto, 9, 2, False, "0")
    End Sub

    Private Sub BuscaInformacionPuntos()
        Dim Puntos As Integer = 0
        Dim PuntosCanjeados As Integer = 0
        Try

            If Not EmpresaParametroInfo.PuntosActivo Then
                LblPuntosTitulo.Visible = False
                LblPuntos.Visible = False
            Else
                Puntos = PuntosAcumulados(_Cliente_Id, True)
                PuntosCanjeados = PuntosCanjeadosPago()

                'If Puntos > 0 Then
                LblPuntosTitulo.Visible = True
                LblPuntos.Visible = True
                'End If

                LblPuntos.Text = Format(Puntos - PuntosCanjeados, "#,##0")
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaCombos()
        Dim Tarjeta As New TTarjeta(EmpresaInfo.Emp_Id)
        Dim Banco As New TBanco(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            Mensaje = Tarjeta.LoadCombobox(CmbTarjeta)
            VerificaMensaje(Mensaje)

            Mensaje = Banco.LoadCombobox(CmbBanco)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Tarjeta = Nothing
            Banco = Nothing
        End Try

    End Sub

    Public Sub HabilitaCamposPago()
        Dim TotalPagado = CalculaTotalPagado()
        Try
            'LblPuntos.Text = Format(PuntosAcumulados(_Cliente_Id), "#,###")
            BuscaInformacionPuntos()

            'Efectivo
            TxtEfectivoMonto.Enabled = IIf(RdbEfectivo.Checked, True, False)
            TxtDolaresMonto.Enabled = IIf(RdbEfectivo.Checked, True, False)
            ChkDolares.Enabled = IIf(RdbEfectivo.Checked, True, False)
            'Tarjeta
            CmbTarjeta.Enabled = IIf(RdbTarjeta.Checked, True, False)
            TxtTarjetaMonto.Enabled = IIf(RdbTarjeta.Checked, True, False)
            TxtTarjetaNumero.Enabled = IIf(RdbTarjeta.Checked, True, False)
            TxtTarjetaAutorizacion.Enabled = IIf(RdbTarjeta.Checked, True, False)
            'Cheque
            CmbBanco.Enabled = IIf(RdbCheque.Checked, True, False)
            TxtChequeMonto.Enabled = IIf(RdbCheque.Checked, True, False)
            TxtChequeNumero.Enabled = IIf(RdbCheque.Checked, True, False)
            DtpChequeFecha.Enabled = IIf(RdbCheque.Checked, True, False)

            'Efectivo
            TxtPuntosMonto.Enabled = IIf(RdbPuntos.Checked, True, False)

            If RdbEfectivo.Checked Then
                If LblFaltaEtiqueta.Text = Co_LeyendaFalta Then
                    TxtTarjetaMonto.Text = ""
                    TxtTarjetaNumero.Text = ""
                    TxtTarjetaAutorizacion.Text = ""
                    TxtChequeMonto.Text = ""
                    TxtChequeNumero.Text = ""
                    TxtPuntosMonto.Text = ""
                    LbDevuelveIVTitle.Visible = False
                    LbDevuelveIVMonto.Visible = False
                    'Mike 15/12/2020
                    If Math.Round(CDbl(LblTotalFaltante.Text)) < Math.Round(_SubTotal) AndAlso LvwListaPagos.Items.Count > 0 Then
                        If Format(Math.Round(CDbl(LblTotalFaltante.Text + TotalPagado)), "##,##0.00") = Math.Round(TotalCalculaIV) Then
                            For i = 0 To LvwListaPagos.Items.Count - 1
                                If LvwListaPagos.Items(i).SubItems(ColTipoPagoNombre).Text.Equals("Tarjeta") Then
                                    TxtEfectivoMonto.Text = Format(CDbl(LblTotalFaltante.Text), "##,##0.00")
                                    LblTotalFaltante.Text = TxtEfectivoMonto.Text
                                    LbDevuelveIVTitle.Visible = True
                                    LbDevuelveIVMonto.Visible = True
                                Else
                                    If LvwListaPagos.Items.Count > 1 Then
                                        If Format(Math.Round(CDbl(LblTotalFaltante.Text + TotalPagado)), "##,##0.00") = Math.Round(TotalCalculaIV) Then
                                            TxtChequeMonto.Text = Format(CDbl(LblTotalFaltante.Text), "##,##0.00")
                                            LblTotalFaltante.Text = TxtChequeMonto.Text
                                        Else
                                            TxtChequeMonto.Text = Format(CDbl(LblTotalFaltante.Text) + Math.Round(TotalDevuelveIV), "##,##0.00")
                                            LblTotalFaltante.Text = TxtChequeMonto.Text
                                        End If
                                    Else
                                        TxtChequeMonto.Text = Format(CDbl(LblTotalFaltante.Text) + Math.Round(_TotalDevuelveIV), "##,##0.00")
                                        LblTotalFaltante.Text = TxtChequeMonto.Text
                                    End If
                                    'TxtEfectivoMonto.Text = IIf(LvwListaPagos.Items.Count > 1, Format(CDbl(LblTotalFaltante.Text), "##,##0.00"), Format(CDbl(LblTotalFaltante.Text + Math.Round(_TotalDevuelveIV)), "##,##0.00"))
                                    'LblTotalFaltante.Text = TxtEfectivoMonto.Text
                                End If
                            Next
                        End If
                        TxtEfectivoMonto.Text = IIf(Format(Math.Round(CDbl(LblTotalFaltante.Text + TotalPagado)), "##,##0.00") = Math.Round(_TotalFactura), Format(CDbl(LblTotalFaltante.Text), "##,##0.00"), IIf(Format(Math.Round(CDbl(TotalCalculaIV - TotalPagado)), "##,##0.00") = Math.Round(CDbl(LblTotalFaltante.Text)), IIf(Format(Math.Round(CDbl(LblTotalFaltante.Text + TotalPagado)), "##,##0.00") < Math.Round(TotalCalculaIV), Format(Math.Round(CDbl(LblTotalFaltante.Text)) + Math.Round(_TotalDevuelveIV), "##,##0.00"), Format(CDbl(LblTotalFaltante.Text), "##,##0.00")), Format(CDbl(LblTotalFaltante.Text) + Math.Round(TotalDevuelveIV), "##,##0.00")))
                        LblTotalFaltante.Text = Format(CDbl(TxtEfectivoMonto.Text), "##,##0.00")
                    Else
                        TxtEfectivoMonto.Text = IIf(Math.Round(CDbl(LblTotalFaltante.Text)) = Math.Round(_TotalFactura), Format(CDbl(LblTotalFaltante.Text), "##,##0.00"), IIf(Format(Math.Round(CDbl(LblTotalFaltante.Text + TotalPagado)), "##,##0.00") < Math.Round(_TotalFactura), Format(Math.Round(CDbl(LblTotalFaltante.Text + _TotalDevuelveIV)), "##,##0.00"), Format(CDbl(LblTotalFaltante.Text), "##,##0.00")))
                        LblTotalFaltante.Text = TxtEfectivoMonto.Text
                    End If
                End If
            End If
            If RdbTarjeta.Checked Then
                If LblFaltaEtiqueta.Text = Co_LeyendaFalta Then
                    TxtEfectivoMonto.Text = ""
                    If EmpresaInfo.DevuelveIV AndAlso _TotalDevuelveIV > 0 Then
                        TxtDolaresMonto.Text = "0.00"
                        TxtChequeMonto.Text = ""
                        TxtChequeNumero.Text = ""
                        TxtPuntosMonto.Text = ""

                        LbDevuelveIVTitle.Visible = True
                        LbDevuelveIVMonto.Visible = True
                        If TxtTarjetaMonto.Text = "" Or TxtTarjetaMonto.Text = LblTotalFaltante.Text Then
                            TxtTarjetaMonto.Text = IIf(Math.Round(CDbl(LblTotalFaltante.Text)) = Math.Round(_TotalFactura), Format(CDbl(TotalCalculaIV), "##,##0.00"), IIf(Format(Math.Round(CDbl(TotalCalculaIV - TotalPagado)), "##,##0.00") = Math.Round(CDbl(LblTotalFaltante.Text)), Format(CDbl(LblTotalFaltante.Text), "##,##0.00"), Format(CDbl(LblTotalFaltante.Text - Math.Round(_TotalDevuelveIV)), "##,##0.00")))
                            LblTotalFaltante.Text = Format(CDbl(TxtTarjetaMonto.Text), "##,##0.00")
                        Else
                            TxtTarjetaMonto.Text = IIf(Math.Round(CDbl(LblTotalFaltante.Text)) = Math.Round(_TotalFactura), Format(CDbl(TotalCalculaIV), "##,##0.00"), IIf(Math.Round(CDbl(TxtTarjetaMonto.Text)) < Math.Round(CDbl(LblTotalFaltante.Text)), LblTotalFaltante.Text, Format(CDbl(LblTotalFaltante.Text - Math.Round(_TotalDevuelveIV)), "##,##0.00")))
                            LblTotalFaltante.Text = IIf(Math.Round(CDbl(TxtTarjetaMonto.Text)) = Math.Round(TotalCalculaIV), Format(CDbl(TotalCalculaIV), "##,##0.00"), Format(CDbl(LblTotalFaltante.Text - Math.Round(_TotalDevuelveIV)), "##,##0.00"))
                        End If

                        LbDevuelveIVMonto.Text = Format(CDbl(-Math.Round(_TotalDevuelveIV)), "##,##0.00")

                        'LbDevuelveIVMonto.ForeColor = IIf(LblTotalFaltante.Text = TxtTarjetaMonto.Text, Color.DarkRed, Color.Blue)
                    Else
                        TxtTarjetaMonto.Text = LblTotalFaltante.Text
                    End If
                Else
                    TxtTarjetaMonto.Text = "0.00"
                End If
            End If

            If RdbCheque.Checked Then
                If LblFaltaEtiqueta.Text = Co_LeyendaFalta Then
                    TxtDolaresMonto.Text = "0.00"
                    TxtEfectivoMonto.Text = ""
                    TxtTarjetaMonto.Text = ""
                    TxtTarjetaNumero.Text = ""
                    TxtTarjetaAutorizacion.Text = ""
                    TxtPuntosMonto.Text = ""
                    LbDevuelveIVTitle.Visible = False
                    LbDevuelveIVMonto.Visible = False
                    'Mike 15/12/2020
                    If Math.Round(CDbl(LblTotalFaltante.Text)) < Math.Round(_SubTotal) And LvwListaPagos.Items.Count > 0 Then
                        If Format(Math.Round(CDbl(LblTotalFaltante.Text + TotalPagado)), "##,##0.00") = Math.Round(TotalCalculaIV) Then
                            For i = 0 To LvwListaPagos.Items.Count - 1
                                If LvwListaPagos.Items(i).SubItems(ColTipoPagoNombre).Text.Equals("Tarjeta") Then
                                    TxtChequeMonto.Text = Format(CDbl(LblTotalFaltante.Text), "##,##0.00")
                                    LblTotalFaltante.Text = TxtChequeMonto.Text
                                    LbDevuelveIVTitle.Visible = True
                                    LbDevuelveIVMonto.Visible = True
                                Else
                                    If LvwListaPagos.Items.Count > 1 Then
                                        If Format(Math.Round(CDbl(LblTotalFaltante.Text + TotalPagado)), "##,##0.00") = Math.Round(TotalCalculaIV) Then
                                            TxtChequeMonto.Text = Format(CDbl(LblTotalFaltante.Text), "##,##0.00")
                                            LblTotalFaltante.Text = TxtChequeMonto.Text
                                        Else
                                            TxtChequeMonto.Text = Format(CDbl(LblTotalFaltante.Text) + Math.Round(TotalDevuelveIV), "##,##0.00")
                                            LblTotalFaltante.Text = TxtChequeMonto.Text
                                        End If
                                    Else
                                        TxtChequeMonto.Text = Format(CDbl(LblTotalFaltante.Text) + Math.Round(_TotalDevuelveIV), "##,##0.00")
                                        LblTotalFaltante.Text = TxtChequeMonto.Text
                                    End If
                                    'TxtChequeMonto.Text = IIf(LvwListaPagos.Items.Count > 1, Format(CDbl(LblTotalFaltante.Text), "##,##0.00"), Format(CDbl(LblTotalFaltante.Text) + Math.Round(_TotalDevuelveIV), "##,##0.00"))
                                    'LblTotalFaltante.Text = TxtChequeMonto.Text
                                End If
                            Next
                        End If
                        TxtChequeMonto.Text = IIf(Format(Math.Round(CDbl(LblTotalFaltante.Text + TotalPagado)), "##,##0.00") = Math.Round(_TotalFactura), Format(CDbl(LblTotalFaltante.Text), "##,##0.00"), IIf(Format(Math.Round(CDbl(TotalCalculaIV - TotalPagado)), "##,##0.00") = Math.Round(CDbl(LblTotalFaltante.Text)), IIf(Format(Math.Round(CDbl(LblTotalFaltante.Text + TotalPagado)), "##,##0.00") < Math.Round(TotalCalculaIV), Format(CDbl(LblTotalFaltante.Text + Math.Round(_TotalDevuelveIV)), "##,##0.00"), Format(CDbl(LblTotalFaltante.Text), "##,##0.00")), Format(CDbl(LblTotalFaltante.Text) + Math.Round(TotalDevuelveIV), "##,##0.00")))
                        LblTotalFaltante.Text = Format(CDbl(TxtChequeMonto.Text), "##,##0.00")
                    Else
                        TxtChequeMonto.Text = IIf(Math.Round(CDbl(LblTotalFaltante.Text)) = Math.Round(_TotalFactura), Format(CDbl(LblTotalFaltante.Text), "##,##0.00"), IIf(Format(Math.Round(CDbl(LblTotalFaltante.Text + TotalPagado)), "##,##0.00") < Math.Round(_TotalFactura), Format(CDbl(LblTotalFaltante.Text + Math.Round(_TotalDevuelveIV)), "##,##0.00"), Format(CDbl(LblTotalFaltante.Text), "##,##0.00")))
                        LblTotalFaltante.Text = TxtChequeMonto.Text
                    End If
                Else
                    TxtChequeMonto.Text = "0.00"
                End If
                DtpChequeFecha.Value = DateValue(EmpresaInfo.Getdate())
            End If

            If RdbPuntos.Checked Then
                If LblFaltaEtiqueta.Text = Co_LeyendaFalta Then
                    TxtDolaresMonto.Text = "0.00"
                    TxtEfectivoMonto.Text = ""
                    TxtTarjetaMonto.Text = ""
                    TxtTarjetaNumero.Text = ""
                    TxtTarjetaAutorizacion.Text = ""
                    TxtChequeMonto.Text = ""
                    TxtChequeNumero.Text = ""
                    LbDevuelveIVTitle.Visible = False
                    LbDevuelveIVMonto.Visible = False
                    If Format(CDbl(LblPuntos.Text), "##,##0.00") <= CDbl(LblTotalFaltante.Text) Then
                        TxtPuntosMonto.Text = LblPuntos.Text
                        'Else
                        '    If LblTotalFaltante.Text < _SubTotal AndAlso LvwListaPagos.Items.Count > 0 Then
                        '        TxtPuntosMonto.Text = LblTotalFaltante.Text
                        '        LblTotalFaltante.Text = TxtPuntosMonto.Text
                        '    Else
                        '        TxtPuntosMonto.Text = IIf(LblTotalFaltante.Text <> _TotalFactura, _TotalFactura, Format(CDbl(LblTotalFaltante.Text), "##,##0.00"))
                        '        LblTotalFaltante.Text = TxtPuntosMonto.Text
                        '    End If
                    Else
                        TxtPuntosMonto.Text = "0.00"
                    End If
                End If
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
        With LvwListaPagos.Columns(ColDolares)
            .Text = "Dolares"
            .Width = 0
            .TextAlign = HorizontalAlignment.Right
        End With
    End Sub

    Public Sub Execute()

        AsignaLogo(PicLogo)
        _PagoDocumento = False
        _FacturaPagos.Clear()
        _Vuelto = 0

        TxtDolaresMonto.Text = "0.00"
        TxtEfectivoMonto.Text = Format(_TotalFactura, "#,##0.00")
        TotalCalculaIV = Format(_TotalFactura - Math.Round(_TotalDevuelveIV), "#,##0.00")
        TxtEfectivoMonto.SelectAll()
        VerificaMensaje(EmpresaInfo.ListKey()) 'Mike 10/12/2020
        'LblSubTotal.Text = Format(_SubTotal, "##0.00")
        'LblDescuento.Text = Format(_Descuento, "##0.00")
        'LblImpuestoVenta.Text = Format(_ImpuestoVenta, "##0.00")
        'LblTotal.Text = Format(_TotalFactura, "##0.00")

        RdbPuntos.Enabled = EmpresaParametroInfo.PuntosActivo
        LblTipoCambio.Text = Format(TipoCambioCierreCaja(CajaInfo.Suc_Id, CajaInfo.Caja_Id, CajaInfo.Cierre_Id), "#,##0.00")
        Me.ShowDialog()
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
                    If RdbEfectivo.Enabled Then
                        RdbEfectivo.Select()
                        If Not TxtEfectivoMonto.ReadOnly Then
                            TxtEfectivoMonto.Focus()
                        Else
                            TxtDolaresMonto.Focus()
                        End If
                    End If
                Case Keys.P And e.Alt
                    If RdbPuntos.Enabled Then
                        RdbPuntos.Select()
                        TxtPuntosMonto.Focus()
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

    Private Sub AsignaInterfaz()
        Select Case InfoMaquina.InterfazFactura
            Case Enum_InterfazFacturacion.Reducida
                Me.Width = Me.Width - 80
                PicFacturar.Left = 584
                LblFacturar.Left = 581
                PicLogo.Visible = False
                LvwListaPagos.Columns(ColTipoPagoNombre).Width = 350

                Me.Width = 1000
                Me.Height = 680
                Me.CenterToScreen()

                PictureBox6.Visible = False
                PictureBox4.Visible = False
                Label13.Visible = False
                Label10.Visible = False
            Case Else
                LvwListaPagos.Columns(ColTipoPagoNombre).Width = 400
        End Select
    End Sub


    Private Sub FrmPagoFactura_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Mensaje As String = ""
        Try
            _Activado = False
            LblTotalFaltante.Text = Format(_TotalFactura, "#,##0.00")
            LblPuntos.Text = "0"

            ConfiguraTextosNumericos()
            ConfiguraListView()
            CargaCombos()

            If EmpresaParametroInfo.PuntosActivo Then
                BuscaInformacionPuntos()
            End If

            AsignaInterfaz()


            If InfoMaquina.InterfazFactura <> Enum_InterfazFacturacion.Reducida Then
                Me.Width = Screen.PrimaryScreen.WorkingArea.Size.Width
                Me.Height = Screen.PrimaryScreen.WorkingArea.Size.Height - 50
            End If
            Me.Location = Screen.PrimaryScreen.WorkingArea.Location

            TxtEfectivoMonto.Focus()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub RdbEfectivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbEfectivo.CheckedChanged
        HabilitaCamposPago()
    End Sub

    Private Sub RdbTarjeta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbTarjeta.CheckedChanged
        HabilitaCamposPago()
    End Sub

    Private Sub RdbCheque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbCheque.CheckedChanged
        HabilitaCamposPago()
    End Sub
    Private Function ValidaDatosPago() As Boolean
        Dim Banco As New TBanco(EmpresaInfo.Emp_Id)
        Try
            ValidaDatosPago = False

            If RdbEfectivo.Checked Then
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

                If Comparer.Equals(CmbBanco.SelectedValue, Nothing) Or CmbBanco.Items.Count = 0 Or CmbBanco.SelectedValue = 0 Then
                    MsgBox("Debe de seleccionar el banco", MsgBoxStyle.Information, "Validación de datos")
                    CmbBanco.Focus()
                    Exit Function
                End If


                Banco.Banco_Id = CmbBanco.SelectedValue
                VerificaMensaje(Banco.ListKey())


                If TxtChequeNumero.Text.Trim() = "" Then
                    MsgBox("Debe de digitar el número de " & IIf(Banco.Transferencia, "Transferencia", "Cheque"), MsgBoxStyle.Information, "Validación de datos")
                    EnfocarTexto(TxtChequeNumero)
                    Exit Function
                End If
            End If

            If EmpresaParametroInfo.PuntosActivo AndAlso RdbPuntos.Checked Then
                If Not IsNumeric(TxtPuntosMonto.Text) Then
                    MsgBox("Debe de digitar un monto", MsgBoxStyle.Information, "Validación de datos")
                    EnfocarTexto(TxtPuntosMonto)
                    Exit Function
                End If
                If CDbl(TxtPuntosMonto.Text) <= 0 Then
                    MsgBox("El monto debe de ser mayor a cero", MsgBoxStyle.Information, "Validación de datos")
                    EnfocarTexto(TxtPuntosMonto)
                    Exit Function
                End If
                BuscaInformacionPuntos()
                If CDbl(LblPuntos.Text) < CDbl(TxtPuntosMonto.Text) Then
                    MsgBox("No tiene la cantidad de puntos disponibles para cubrir el monto ingresado", MsgBoxStyle.Information, "Validación de datos")
                    EnfocarTexto(TxtPuntosMonto)
                    Exit Function
                End If
            End If

            Return True

        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        Finally
            Banco = Nothing
        End Try
    End Function


    Private Sub AgregarPago()
        Dim TipoPagoId As Enum_TipoPago
        Dim TipoPagoNombre As String = ""
        Dim Item As ListViewItem = Nothing
        Dim NewItem As ListViewItem = Nothing
        Dim SubItems(LvwListaPagos.Columns.Count - 1) As String
        Dim Monto As String = ""
        Dim MontoDolares As String = ""
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
        Dim Banco As New TBanco(EmpresaInfo.Emp_Id)
        Try
            'Efectivo
            If RdbEfectivo.Checked Then
                TipoPagoId = Enum_TipoPago.Efectivo
                TipoPagoNombre = "Efectivo"

                Monto = IIf(RdbEfectivo.Checked, TxtEfectivoMonto.Text, "")

                If ChkDolares.Checked Then
                    MontoDolares = TxtDolaresMonto.Text
                Else
                    MontoDolares = "0.00"
                End If

                EnfocarTexto(TxtEfectivoMonto)

                'Busca si la hay un pago en efectivo en la lista
                Item = BuscaTipoPago(Enum_TipoPago.Efectivo)
            End If

            'Puntos
            If RdbPuntos.Checked Then
                TipoPagoId = Enum_TipoPago.Puntos
                TipoPagoNombre = "Puntos"

                Monto = IIf(RdbPuntos.Checked, TxtPuntosMonto.Text, "")

                EnfocarTexto(TxtPuntosMonto)

                'Busca si la hay un pago en efectivo en la lista
                Item = BuscaTipoPago(Enum_TipoPago.Puntos)
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
                Banco.Banco_Id = CmbBanco.SelectedValue
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
                    .SubItems(ColDolares).Text = MontoDolares
                End With

                NewItem = LvwListaPagos.Items.Add(Item)

                LvwListaPagos.SelectedItems.Clear()

                LvwListaPagos.Items(NewItem.Index).Selected = True

                LvwListaPagos.TopItem = NewItem

            Else
                'sumariza el efectivo
                Item.SubItems(ColMonto).Text = Format(CDbl(Item.SubItems(ColMonto).Text) + CDbl(Monto), "#,##0.00")
                If ChkDolares.Checked Then
                    Item.SubItems(ColDolares).Text = Format(CDbl(Item.SubItems(ColDolares).Text) + CDbl(MontoDolares), "#,##0.00")
                End If
                LvwListaPagos.TopItem = Item
            End If

            'BtnEliminar.Enabled = True

            CalculaMontoFaltante()
            'Revisar
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

    Private Function PuntosCanjeadosPago() As Double
        Dim i As Integer = 0
        Dim Puntos As Double = 0
        Try


            For i = 0 To LvwListaPagos.Items.Count - 1
                If CInt(LvwListaPagos.Items(i).SubItems(ColTipoPagoId).Text) = Enum_TipoPago.Puntos Then
                    Puntos = Puntos + CDbl(LvwListaPagos.Items(i).SubItems(ColMonto).Text)
                End If
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

        Return Puntos
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
        LblDolaresTitulo.Visible = False
        LblDolaresMonto.Visible = False
        LblDolaresMonto.Text = "0.00"

        For i = 0 To LvwListaPagos.Items.Count - 1

            If CInt(LvwListaPagos.Items(i).SubItems(ColTipoPagoId).Text) = Enum_TipoPago.Efectivo Then
                If IsNumeric(LvwListaPagos.Items(i).SubItems(ColDolares).Text) AndAlso CDbl(LvwListaPagos.Items(i).SubItems(ColDolares).Text) > 0 Then
                    LblDolaresTitulo.Visible = True
                    LblDolaresMonto.Visible = True
                    LblDolaresMonto.Text = CDbl(LvwListaPagos.Items(i).SubItems(ColDolares).Text).ToString("#,##0.00")
                    TotalPagado = TotalPagado + CDbl(LvwListaPagos.Items(i).SubItems(ColMonto).Text)
                Else
                    TotalPagado = TotalPagado + CDbl(LvwListaPagos.Items(i).SubItems(ColMonto).Text)
                End If
            Else
                If CInt(LvwListaPagos.Items(i).SubItems(ColTipoPagoId).Text) = Enum_TipoPago.Tarjeta Then
                    TotalPagado = TotalPagado + CDbl(LvwListaPagos.Items(i).SubItems(ColMonto).Text)
                Else
                    If CInt(LvwListaPagos.Items(i).SubItems(ColTipoPagoId).Text) = Enum_TipoPago.Cheque Then
                        TotalPagado = TotalPagado + CDbl(LvwListaPagos.Items(i).SubItems(ColMonto).Text)
                    Else
                        If CInt(LvwListaPagos.Items(i).SubItems(ColTipoPagoId).Text) = Enum_TipoPago.Puntos Then
                            TotalPagado = TotalPagado + CDbl(LvwListaPagos.Items(i).SubItems(ColMonto).Text)
                        End If
                    End If
                End If
            End If
        Next

        CalculaTotalPagado = TotalPagado
        TotalCobradoIV = TotalPagado

    End Function


    Private Sub CalculaMontoFaltante()
        Dim TotalPagado As Double = 0
        Dim CalculaIV As Double = 0
        Dim TarjetaPago As Boolean = False
        TotalPagado = CalculaTotalPagado()

        'Mike 10/12/2020
        If LvwListaPagos.Items.Count > 1 Then
            For i = 0 To LvwListaPagos.Items.Count - 1
                If CInt(LvwListaPagos.Items(i).SubItems(ColTipoPagoId).Text) = Enum_TipoPago.Efectivo Then
                    CalculaIV = CalculaIV + CDbl(LvwListaPagos.Items(i).SubItems(ColMonto).Text)
                Else
                    If CInt(LvwListaPagos.Items(i).SubItems(ColTipoPagoId).Text) = Enum_TipoPago.Tarjeta Then
                        CalculaIV = CalculaIV + CDbl(LvwListaPagos.Items(i).SubItems(ColMonto).Text)
                        TarjetaPago = True
                    Else
                        If CInt(LvwListaPagos.Items(i).SubItems(ColTipoPagoId).Text) = Enum_TipoPago.Cheque Then
                            CalculaIV = CalculaIV + CDbl(LvwListaPagos.Items(i).SubItems(ColMonto).Text)
                        Else
                            If CInt(LvwListaPagos.Items(i).SubItems(ColTipoPagoId).Text) = Enum_TipoPago.Puntos Then
                                CalculaIV = CalculaIV + CDbl(LvwListaPagos.Items(i).SubItems(ColMonto).Text)
                            End If
                        End If
                    End If
                End If
            Next
            LblTotalFaltante.Text = IIf(TarjetaPago, Format(TotalCalculaIV - CalculaIV, "#,##0.00"), Format(_TotalFactura - TotalPagado, "#,##0.00"))
        ElseIf _TotalDevuelveIV <> 0 AndAlso LbDevuelveIVTitle.Visible Then
            LblTotalFaltante.Text = Format(LblTotalFaltante.Text - TotalPagado, "#,##0.00")
        Else
            LblTotalFaltante.Text = Format(_TotalFactura - TotalPagado, "#,##0.00")
        End If
        CalculaIVSobrante = LblTotalFaltante.Text

        If CDbl(LblTotalFaltante.Text) > 0 Then
            LblFaltaEtiqueta.Text = Co_LeyendaFalta
        Else
            LblTotalFaltante.Text = Format(Math.Abs(CDbl(LblTotalFaltante.Text)), "#,##0.00")
            LblFaltaEtiqueta.Text = Co_LeyendaVuelto
        End If

        LblFaltaEtiqueta.ForeColor = IIf(LblFaltaEtiqueta.Text = Co_LeyendaFalta, Color.Red, Color.Blue)
        LblTotalFaltante.ForeColor = IIf(LblFaltaEtiqueta.Text = Co_LeyendaFalta, Color.Red, Color.Blue)

        BuscaInformacionPuntos()
    End Sub

    Private Sub EliminarPago()
        Try
            If LvwListaPagos.SelectedItems.Count = 0 Then
                MsgBox("Debe de seleccionar un tipo de pago", MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If

            LvwListaPagos.Items(LvwListaPagos.SelectedItems(0).Index).Remove()

            If LvwListaPagos.Items.Count > 0 Then
                LvwListaPagos.SelectedItems.Clear()
                LvwListaPagos.Items(0).Selected = True
                LvwListaPagos.TopItem = LvwListaPagos.Items(0)
            Else
                'BtnEliminar.Enabled = False
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
        TxtDolaresMonto.Text = ""
        ChkDolares.Checked = False
        TxtPuntosMonto.Text = ""

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
        If e.KeyCode = Keys.Enter Then
            EnfocarTexto(TxtTarjetaAutorizacion)
        End If
    End Sub

    Private Sub TxtTarjetaAutorizacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTarjetaAutorizacion.KeyDown
        If e.KeyCode = Keys.Enter Then
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
        Dim TotalPagadoPuntos As Double = 0
        'Dim FacturaEncabezado As TFacturaEncabezado = Nothing
        'Dim OrdenEncabezado As TOrdenEncabezado = Nothing
        Try
            ValidaTodo = False

            'Total mixto
            TotalPagado = CalculaTotalPagado()
            'Total tarjeta
            TotalPagadoTarjeta = TotalxTipoPago(Enum_TipoPago.Tarjeta)
            'Total cheque
            TotalPagadoCheque = TotalxTipoPago(Enum_TipoPago.Cheque)
            'Total Puntos
            TotalPagadoPuntos = TotalxTipoPago(Enum_TipoPago.Puntos)
            'Mike 10/12/2020
            If TotalPagadoTarjeta <> 0 AndAlso Enum_TipoPago.Tarjeta Then
                If TotalPagado < Math.Round(_TotalFactura - Math.Round(_TotalDevuelveIV), 2, MidpointRounding.AwayFromZero) Then
                    MsgBox("Monto insuficiente", MsgBoxStyle.Information, Me.Text)
                    Exit Function
                End If
            Else
                If TotalPagado < Math.Round(_TotalFactura, 2, MidpointRounding.AwayFromZero) Then
                    MsgBox("Monto insuficiente", MsgBoxStyle.Information, Me.Text)
                    Exit Function
                End If
            End If
            If EmpresaParametroInfo.PuntosActivo Then
                If (TotalPagadoCheque + TotalPagadoTarjeta + TotalPagadoPuntos) > _TotalFactura Then
                    MsgBox("El monto de tarjetas,cheques y puntos debe de ser menor o igual al total de la factura", MsgBoxStyle.Information, Me.Text)
                    Exit Function
                End If
            Else
                If (TotalPagadoCheque + TotalPagadoTarjeta) > _TotalFactura Then
                    MsgBox("El monto de tarjetas y cheques debe de ser menor o igual al total de la factura", MsgBoxStyle.Information, Me.Text)
                    Exit Function
                End If
            End If

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function



    Private Function GuardaPago() As String
        Dim FacturaPago As TFacturaPago = Nothing
        Dim i As Integer = 0
        Dim TotalEfectivo As Double = 0.00

        Try

            _FacturaPagos.Clear()

            For i = 0 To LvwListaPagos.Items.Count - 1
                FacturaPago = New TFacturaPago(EmpresaInfo.Emp_Id)
                With FacturaPago
                    .Suc_Id = CajaInfo.Suc_Id
                    .Caja_Id = CajaInfo.Caja_Id
                    .TipoDoc_Id = 0
                    .Documento_Id = 0
                    .TipoPago_Id = CInt(LvwListaPagos.Items(i).SubItems(ColTipoPagoId).Text)

                    Select Case .TipoPago_Id
                        Case Enum_TipoPago.Efectivo
                            .Monto = (CDbl(LvwListaPagos.Items(i).SubItems(ColMonto).Text) - (CDbl(LvwListaPagos.Items(i).SubItems(ColDolares).Text) * CDbl(LblTipoCambio.Text))) - CDbl(LblTotalFaltante.Text)
                            If CDbl(LvwListaPagos.Items(i).SubItems(ColDolares).Text) > 0 Then
                                .Dolares = CDbl(LvwListaPagos.Items(i).SubItems(ColDolares).Text)
                            End If
                            .Tarjeta_Id = 0
                            .TarjetaNumero = ""
                            .TarjetaAutorizacion = ""
                            .Banco_Id = 0
                            .ChequeNumero = ""
                            .ChequeFecha = #1/1/1900#
                            TotalEfectivo = TotalEfectivo + FacturaPago.Monto
                        Case Enum_TipoPago.Puntos
                            .Monto = CDbl(LvwListaPagos.Items(i).SubItems(ColMonto).Text)
                            .Tarjeta_Id = 0
                            .TarjetaNumero = ""
                            .TarjetaAutorizacion = ""
                            .Banco_Id = 0
                            .ChequeNumero = ""
                            .ChequeFecha = #1/1/1900#
                        Case Enum_TipoPago.Tarjeta
                            .Monto = CDbl(LvwListaPagos.Items(i).SubItems(ColMonto).Text)
                            .Tarjeta_Id = CInt(LvwListaPagos.Items(i).SubItems(ColTarjetaTipo_Id).Text)
                            .TarjetaNumero = LvwListaPagos.Items(i).SubItems(ColTarjetaNumero).Text.Trim
                            .TarjetaAutorizacion = LvwListaPagos.Items(i).SubItems(ColTarjetaAutorizacion).Text.Trim
                            .Banco_Id = 0
                            .ChequeNumero = ""
                            .ChequeFecha = #1/1/1900#
                        Case Enum_TipoPago.Cheque
                            .Monto = CDbl(LvwListaPagos.Items(i).SubItems(ColMonto).Text)
                            .Tarjeta_Id = 0
                            .TarjetaNumero = ""
                            .TarjetaAutorizacion = ""
                            .Banco_Id = CInt(LvwListaPagos.Items(i).SubItems(ColBancoTipo_Id).Text)
                            .ChequeNumero = CInt(LvwListaPagos.Items(i).SubItems(ColChequeNumero).Text)
                            .ChequeFecha = CDate(LvwListaPagos.Items(i).SubItems(ColChequeFecha).Text)
                    End Select
                End With
                _FacturaPagos.Add(FacturaPago)
            Next

            _TotalEfectivo = TotalEfectivo
            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            FacturaPago = Nothing
        End Try
    End Function

    Private Sub Facturar()
        Dim Mensaje As String = ""
        Try
            If ValidaTodo() Then
                'BtnAceptar.Enabled = False
                BtnAgregar.Enabled = False
                'BtnSalir.Enabled = False


                Mensaje = GuardaPago()
                VerificaMensaje(Mensaje)

                _PagoDocumento = True
                _Vuelto = CDbl(LblTotalFaltante.Text)

                Close()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
            'BtnSalir.Enabled = True
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


    Private Sub RdbPuntos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdbPuntos.CheckedChanged
        HabilitaCamposPago()
    End Sub

    Private Sub TxtPuntosMonto_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtPuntosMonto.KeyDown
        If e.KeyCode = Keys.Enter And TxtPuntosMonto.Text.Trim <> "" Then
            BtnAgregar_Click(BtnAgregar, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub ChkDolares_CheckedChanged(sender As Object, e As EventArgs) Handles ChkDolares.CheckedChanged
        Try

            TxtDolaresMonto.Text = "0.00"
            If ChkDolares.Checked Then
                HabilitaCamposPago()
                TxtDolaresMonto.ReadOnly = False
                TxtEfectivoMonto.ReadOnly = True
                TxtDolaresMonto.SelectAll()
                TxtDolaresMonto.Focus()
            Else
                TxtDolaresMonto.ReadOnly = True
                TxtEfectivoMonto.ReadOnly = False
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtDolaresMonto_TextChanged(sender As Object, e As EventArgs) Handles TxtDolaresMonto.TextChanged
        Dim Dolares As Double = 0
        Dim Colones As Double = 0
        Try

            If IsNumeric(TxtDolaresMonto.Text) Then
                Dolares = CDbl(TxtDolaresMonto.Text)
            End If

            If RdbEfectivo.Checked Then
                If Not LblFaltaEtiqueta.Text = Co_LeyendaVuelto Then
                    TxtEfectivoMonto.Text = IIf(Dolares = 0, LblTotalFaltante.Text, Format(Dolares * CDbl(LblTipoCambio.Text), "#,##0.00"))
                Else
                    TxtEfectivoMonto.Text = "0.00"
                End If
            Else
                    TxtEfectivoMonto.Text = Format(Dolares * CDbl(LblTipoCambio.Text), "#,##0.00")
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtDolaresMonto_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDolaresMonto.KeyDown
        If e.KeyCode = Keys.Enter And TxtEfectivoMonto.Text.Trim <> "" And TxtDolaresMonto.Text.Trim <> "" Then
            If IsNumeric(TxtDolaresMonto.Text) Then
                BtnAgregar_Click(BtnAgregar, System.EventArgs.Empty)
            End If
        End If
    End Sub
End Class