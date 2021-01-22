Imports BUSINESS
Public Class FrmCxPPagoPendiente
#Region "Enums"
    Private Enum ColumnasDetalle
        Solicitud_Id = 0
        Tipo_Id = 1
        TipoNombre = 2
        Mov_Id = 3
        Referencia = 4
        Fecha = 5
        MonedaSTR = 6
        Moneda = 7
        Monto = 8
        TipoCambio = 9
        Dolares = 10
        MontoaHoy = 11
        DolaresaHoy = 12
        DiferencialCambiario = 13
        PagoMonto = 14
        PagoDolares = 15
        PagoMontoNumeric = 16
        PagoDolaresNumeric = 17
        MontoDiferencial = 18
    End Enum
#End Region
#Region "Variables"
    Private Numerico() As TNumericFormat
#End Region
#Region "Funciones Privadas"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtProveedor, 7, 0, False, "", "###")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Public Sub Execute()
        Try
            TxtTipoCambio.Text = Format(TipoCambioBancos(), "#,##0.00")
            ConfiguraDetalle()
            CargaCombos()
            Inicializa()
            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ConfiguraDetalle()
        Try
            With LvwMovimientos
                .Columns(ColumnasDetalle.Solicitud_Id).Text = "#"
                .Columns(ColumnasDetalle.Solicitud_Id).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Solicitud_Id).Width = 23

                .Columns(ColumnasDetalle.Tipo_Id).Text = ""
                .Columns(ColumnasDetalle.Tipo_Id).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Tipo_Id).Width = 0

                .Columns(ColumnasDetalle.TipoNombre).Text = "Tipo"
                .Columns(ColumnasDetalle.TipoNombre).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.TipoNombre).Width = 130

                .Columns(ColumnasDetalle.Mov_Id).Text = "Doc #"
                .Columns(ColumnasDetalle.Mov_Id).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Mov_Id).Width = 50

                .Columns(ColumnasDetalle.Referencia).Text = "Referencia"
                .Columns(ColumnasDetalle.Referencia).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Referencia).Width = 200

                .Columns(ColumnasDetalle.Fecha).Text = "Fecha"
                .Columns(ColumnasDetalle.Fecha).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Fecha).Width = 75

                .Columns(ColumnasDetalle.Moneda).Text = ""
                .Columns(ColumnasDetalle.Moneda).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Moneda).Width = 0

                .Columns(ColumnasDetalle.MonedaSTR).Text = "Moneda"
                .Columns(ColumnasDetalle.MonedaSTR).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.MonedaSTR).Width = 65

                .Columns(ColumnasDetalle.Monto).Text = "Monto"
                .Columns(ColumnasDetalle.Monto).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Monto).Width = 90

                .Columns(ColumnasDetalle.TipoCambio).Text = "TC Doc"
                .Columns(ColumnasDetalle.TipoCambio).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.TipoCambio).Width = 60

                .Columns(ColumnasDetalle.Dolares).Text = "Dólares"
                .Columns(ColumnasDetalle.Dolares).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Dolares).Width = 90

                .Columns(ColumnasDetalle.MontoaHoy).Text = "Monto a Hoy"
                .Columns(ColumnasDetalle.MontoaHoy).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.MontoaHoy).Width = 90

                .Columns(ColumnasDetalle.DolaresaHoy).Text = "Dólares a Hoy"
                .Columns(ColumnasDetalle.DolaresaHoy).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.DolaresaHoy).Width = 90

                .Columns(ColumnasDetalle.DiferencialCambiario).Text = "D.C."
                .Columns(ColumnasDetalle.DiferencialCambiario).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.DiferencialCambiario).Width = 90

                .Columns(ColumnasDetalle.PagoMonto).Text = "Pagar Monto"
                .Columns(ColumnasDetalle.PagoMonto).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.PagoMonto).Width = 90

                .Columns(ColumnasDetalle.PagoDolares).Text = "Pagar Dólares"
                .Columns(ColumnasDetalle.PagoDolares).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.PagoDolares).Width = 90

                .Columns(ColumnasDetalle.PagoMontoNumeric).Text = ""
                .Columns(ColumnasDetalle.PagoMontoNumeric).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.PagoMontoNumeric).Width = 0

                .Columns(ColumnasDetalle.PagoDolaresNumeric).Text = ""
                .Columns(ColumnasDetalle.PagoDolaresNumeric).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.PagoDolaresNumeric).Width = 0

                .Columns(ColumnasDetalle.MontoDiferencial).Text = ""
                .Columns(ColumnasDetalle.MontoDiferencial).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.MontoDiferencial).Width = 0
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaCombos()
        Dim BcoTipoPago As New TBcoTipoPago

        Try
            BcoTipoPago.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(BcoTipoPago.LoadComboBox(CmbBcoTipoPago))
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            BcoTipoPago = Nothing
        End Try
    End Sub

    Private Sub Inicializa()
        Try
            TxtProveedor.ReadOnly = False
            TxtProveedor.Text = ""
            TxtProveedorNombre.Text = ""
            CmbBcoTipoPago.Enabled = False
            BtnAgregaMovimiento.Enabled = False
            TxtTipoCambio.Enabled = False
            LvwMovimientos.Items.Clear()

            'Botones
            BtnBuscar.Enabled = True
            BtnPagar.Enabled = False
            BtnAgregaMovimiento.Enabled = False
            BtnEstadoCuenta.Enabled = False
            BtnRefrescar.Enabled = False
            BtnGeneraDocumento.Enabled = False
            BtnLimpiar.Enabled = False

            'Totales
            LblTotalSaldo.Text = ""
            LblTotalDolares.Text = ""
            LblTotalPago.Text = ""
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CalculaTotales()
        Dim Proveedor As New TProveedor

        Try
            LblTotalSaldo.Text = "0.00"

            With Proveedor
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = CInt(TxtProveedor.Text)
            End With
            VerificaMensaje(Proveedor.ListKey)

            If Proveedor.RowsAffected = 0 Then
                VerificaMensaje("El código de cliente no es válido")
            End If

            LblTotalSaldo.Text = Format(Proveedor.Saldo, "#,##0.00")
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Proveedor = Nothing
        End Try
    End Sub

    Private Sub CargaDetalle()
        Dim CxPSolicitudPago As New TCxPSolicitudPago
        Dim Items(18) As String
        Dim Item As ListViewItem = Nothing
        Dim FechaHoy As Date = EmpresaInfo.Getdate()

        Try
            TxtTipoCambio.Text = Format(TipoCambioBancos(), "#,##0.00")
            LvwMovimientos.Items.Clear()

            If TxtProveedorNombre.Text.Trim = "" Then
                Exit Sub
            End If

            With CxPSolicitudPago
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = CInt(TxtProveedor.Text.Trim)
            End With
            VerificaMensaje(CxPSolicitudPago.CxPSolicitudesPagoPendientes)

            If CxPSolicitudPago.RowsAffected = 0 Then
                Exit Sub
            End If

            For Each Mov As DataRow In CxPSolicitudPago.Datos.Tables(0).Rows
                Items(ColumnasDetalle.Solicitud_Id) = UCase(Mov("Solicitud_Id"))
                Items(ColumnasDetalle.Tipo_Id) = Mov("Tipo_Id")
                Items(ColumnasDetalle.TipoNombre) = Mov("TipoNombre")
                Items(ColumnasDetalle.Mov_Id) = Mov("Mov_Id")
                Items(ColumnasDetalle.Referencia) = Mov("Referencia")
                Items(ColumnasDetalle.Fecha) = Format(Mov("Fecha"), "dd/MM/yyyy")
                Items(ColumnasDetalle.Moneda) = Mov("Moneda")
                Items(ColumnasDetalle.MonedaSTR) = IIf(Mov("Moneda") = coMonedaColones, "COLONES", "DOLARES")
                Items(ColumnasDetalle.Monto) = Format(Mov("Monto"), "#,##0.00")
                Items(ColumnasDetalle.TipoCambio) = Format(Mov("TipoCambio"), "#,##0.00")
                Items(ColumnasDetalle.Dolares) = Format(Mov("Dolares"), "#,##0.0000")
                If Mov("Moneda") = coMonedaDolares Then
                    Items(ColumnasDetalle.DolaresaHoy) = Format(Mov("Dolares"), "#,##0.0000")
                    Items(ColumnasDetalle.MontoaHoy) = Format(CDbl(Mov("Dolares")) * CDbl(TxtTipoCambio.Text.Trim), "#,##0.00")
                    Items(ColumnasDetalle.DiferencialCambiario) = Format((CDbl(Mov("Dolares")) * CDbl(TxtTipoCambio.Text.Trim)) - CDbl(Mov("Monto")), "#,##0.00")
                    Items(ColumnasDetalle.MontoDiferencial) = (CDbl(Mov("Dolares")) * CDbl(TxtTipoCambio.Text.Trim)) - CDbl(Mov("Monto"))
                    Items(ColumnasDetalle.PagoMontoNumeric) = CDbl(Mov("Dolares")) * CDbl(TxtTipoCambio.Text.Trim).ToString
                    Items(ColumnasDetalle.PagoDolaresNumeric) = Mov("Dolares").ToString
                Else
                    Items(ColumnasDetalle.DolaresaHoy) = Format(CDbl(Mov("Monto")) / CDbl(TxtTipoCambio.Text.Trim), "#,##0.0000")
                    Items(ColumnasDetalle.MontoaHoy) = Format(CDbl(Items(ColumnasDetalle.Monto)), "#,##0.00")
                    Items(ColumnasDetalle.DiferencialCambiario) = "0.00"
                    Items(ColumnasDetalle.MontoDiferencial) = "0.00"
                    Items(ColumnasDetalle.PagoMontoNumeric) = Mov("Monto").ToString
                    Items(ColumnasDetalle.PagoDolaresNumeric) = (CDbl(Mov("Monto")) / CDbl(TxtTipoCambio.Text.Trim)).ToString
                End If
                Items(ColumnasDetalle.PagoMonto) = Items(ColumnasDetalle.MontoaHoy)
                Items(ColumnasDetalle.PagoDolares) = Items(ColumnasDetalle.DolaresaHoy)

                Item = New ListViewItem(Items)
                If Mov("Moneda") = coMonedaDolares Then ListViewCambiaColorFondoFila(Item, Color.LightCyan)
                LvwMovimientos.Items.Add(Item)
            Next

            LvwMovimientos.Refresh()
            CalculaTotales()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CxPSolicitudPago = Nothing
        End Try
    End Sub

    Private Function ValidaProveedor() As String
        Dim Proveedor As New TProveedor

        Try
            LblTotalDolares.Text = ""
            LblTotalPago.Text = ""
            LblTotalSaldo.Text = ""
            TxtTipoCambio.Text = Format(TipoCambioBancos(), "#,##0.00")

            With Proveedor
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = CInt(TxtProveedor.Text.Trim)
            End With
            VerificaMensaje(Proveedor.ListKey)

            If Proveedor.RowsAffected = 0 Then
                VerificaMensaje("El código de cliente no es válido")
            End If

            If Not Proveedor.Activo Then
                EnfocarTexto(TxtProveedor)
                VerificaMensaje("El cliente se encuentra inactivo")
            End If

            TxtProveedorNombre.Text = Proveedor.Nombre
            LblTotalSaldo.Text = Format(Proveedor.Saldo, "#,##0.00")
            TxtProveedor.ReadOnly = True
            CmbBcoTipoPago.Enabled = True
            TxtTipoCambio.Enabled = True
            BtnBuscar.Enabled = False
            BtnEstadoCuenta.Enabled = True
            BtnRefrescar.Enabled = True
            BtnLimpiar.Enabled = True
            CargaDetalle()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Proveedor = Nothing
        End Try
    End Function

    Private Sub BuscaProveedor()
        Dim Forma As New FrmBusquedaProveedor

        Try
            Forma.Execute()

            If Forma.Selecciono Then
                TxtProveedor.Text = Forma.Prov_Id
                VerificaMensaje(ValidaProveedor)
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Function ValidaEstadoCuenta() As Boolean
        Try
            VerificaMensaje(ValidaProveedor)

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub MuestraEstadoCuenta()
        'Dim Cliente As New TCliente
        'Dim Movimiento As New TCxPMovimiento
        'Dim Reporte As New RptCxCEstadoCuenta
        'Dim FormaReporte As New FrmReporte

        'Try
        '    Cursor = Cursors.WaitCursor

        '    With Movimiento
        '        .Emp_Id = EmpresaInfo.Emp_Id
        '        .Cliente_Id = CInt(TxtCliente.Text.Trim)
        '    End With
        '    VerificaMensaje(Movimiento.RptCxPEstadoCuenta)

        '    If Movimiento.RowsAffected = 0 Then
        '        VerificaMensaje("No se encontraron datos para mostrar el reporte")
        '    End If

        '    With Cliente
        '        .Emp_Id = EmpresaInfo.Emp_Id
        '        .Cliente_Id = CInt(TxtCliente.Text.Trim)
        '    End With
        '    VerificaMensaje(Cliente.RptConsultaInformacionCliente)

        '    If Cliente.RowsAffected = 0 Then
        '        VerificaMensaje("Ocurrió un error obteniendo la información del cliente")
        '    End If

        '    VerificaMensaje(EmpresaInfo.GetLogoEmpresa)

        '    Reporte.SetDataSource(Movimiento.Datos.Tables(0))
        '    Reporte.Subreports(0).SetDataSource(Cliente.Datos.Tables(0))
        '    Reporte.Subreports(1).SetDataSource(EmpresaInfo.Datos.Tables(0))
        '    Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)

        '    If Form_Abierto("FrmReporte") = False Then
        '        FormaReporte.Execute(Reporte)
        '    End If

        'Catch ex As Exception
        '    MensajeError(ex.Message)
        'Finally
        '    FormaReporte = Nothing
        '    Movimiento = Nothing
        '    Cliente = Nothing
        '    Cursor = Cursors.Default
        'End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMovimientosCliente_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            FormateaCamposNumericos()
            TxtProveedor.Select()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnPagar_Click(sender As Object, e As EventArgs) Handles BtnPagar.Click
        Try
            If ValidaPagos() Then
                CreaPagoDocumento()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtProveedor.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    If IsNumeric(TxtProveedor.Text) Then
                        VerificaMensaje(ValidaProveedor)
                    End If
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCliente_TextChanged(sender As Object, e As EventArgs) Handles TxtProveedor.TextChanged
        TxtProveedorNombre.Text = ""
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        Try
            Inicializa()
            TxtProveedor.Focus()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnAgregaMovimiento_Click(sender As Object, e As EventArgs) Handles BtnAgregaMovimiento.Click
        Try
            If ValidaPagos() Then
                CreaPagoDocumento()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CreaPagoDocumento()
        Try
            CalculaTotalPago()

            Select Case CmbBcoTipoPago.SelectedValue
                Case Enum_BcoTipoPago.Cheque
                    CreaPagoCheque()
                Case Enum_BcoTipoPago.Transferencia
                    CreaPagoTransferencia()
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CreaPagoCheque()
        Dim Forma As New FrmPagoCheque

        Try
            With Forma
                .MontoColones = CDbl(LblTotalPago.Tag)
                .MontoDolares = CDbl(LblTotalDolares.Tag)
                .Prov_Id = CInt(TxtProveedor.Text.Trim)
                .Titulo = CmbBcoTipoPago.Text
                .ListaCxPSolicitud = CreaListaSolicitudes()
                .Execute()
            End With

            If Forma.Acepto Then
                VerificaMensaje(ValidaProveedor())
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub CreaPagoTransferencia()
        Dim Forma As New FrmPagoTransferencia

        Try
            With Forma
                .MontoColones = CDbl(LblTotalPago.Tag)
                .MontoDolares = CDbl(LblTotalDolares.Tag)
                .Prov_Id = CInt(TxtProveedor.Text)
                .Titulo = CmbBcoTipoPago.Text
                .ListaCxPSolicitud = CreaListaSolicitudes()
                .Execute()
            End With

            If Forma.Acepto Then
                VerificaMensaje(ValidaProveedor())
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Function CreaListaSolicitudes() As List(Of TCxPSolicitudPago)
        Dim SolicitudLista As New List(Of TCxPSolicitudPago)
        Dim Solicitud As TCxPSolicitudPago = Nothing

        For Each Item As ListViewItem In LvwMovimientos.Items
            If Item.Checked Then
                Solicitud = New TCxPSolicitudPago

                With Solicitud
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Solicitud_Id = CLng(Item.SubItems(ColumnasDetalle.Solicitud_Id).Text)
                    .Tipo_Id = CInt(Item.SubItems(ColumnasDetalle.Tipo_Id).Text)
                    .Mov_Id = CLng(Item.SubItems(ColumnasDetalle.Mov_Id).Text)
                    .Monto = CDbl(Item.SubItems(ColumnasDetalle.Monto).Text)
                    .PagoMonto = CDbl(Item.SubItems(ColumnasDetalle.PagoMontoNumeric).Text)
                    .PagoDolares = CDbl(Item.SubItems(ColumnasDetalle.PagoDolaresNumeric).Text)
                    .Diferencial = CDbl(Item.SubItems(ColumnasDetalle.MontoDiferencial).Text)
                End With

                SolicitudLista.Add(Solicitud)
            End If
        Next

        Return SolicitudLista
    End Function

    Private Function ValidaPagos() As Boolean
        Try
            If LvwMovimientos.CheckedItems Is Nothing OrElse LvwMovimientos.CheckedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar al menos un documento")
            End If

            If Not IsNumeric(LblTotalPago.Text) OrElse CDbl(LblTotalPago.Text) <= 0 Then
                VerificaMensaje("EL monto a cancelar debe de ser mayor a cero")
            End If

            If Not IsNumeric(LblTotalDolares.Text) OrElse CDbl(LblTotalDolares.Text) <= 0 Then
                VerificaMensaje("EL monto a cancelar debe de ser mayor a cero")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub FrmMovimientosCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                BtnBuscar.PerformClick()
            Case Keys.F2
                BtnPagar.PerformClick()
            Case Keys.F4
                BtnEstadoCuenta.PerformClick()
            Case Keys.F5
                BtnRefrescar.PerformClick()
            Case Keys.F6
                BtnGeneraDocumento.PerformClick()
            Case Keys.F12
                BtnLimpiar.PerformClick()
            Case Keys.Escape
                If Not TxtProveedor.ReadOnly Then
                    BtnSalir.PerformClick()
                End If
        End Select
    End Sub

    Private Sub CmbFiltro_SelectedIndexChanged(sender As Object, e As EventArgs)
        CargaDetalle()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        BuscaProveedor()
    End Sub

    Private Sub BtnEstadoCuenta_Click(sender As Object, e As EventArgs) Handles BtnEstadoCuenta.Click
        If ValidaEstadoCuenta() Then
            MuestraEstadoCuenta()
        End If
    End Sub

    Private Sub MnuDetalle_Click(sender As Object, e As EventArgs) Handles MnuDetalle.Click
        'Dim Forma As New FrmMovimientoListaAplicados

        'Try
        '    If LvwMovimientos Is Nothing OrElse LvwMovimientos.SelectedItems.Count = 0 Then
        '        VerificaMensaje("Debe de seleccionar el Movimiento que desea reimprimir")
        '    End If

        '    With Forma
        '        .Tipo_Id = CInt(LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.Tipo_Id).Text.Trim)
        '        .Movimiento_Id = CLng(LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.Mov_Id).Text.Trim)
        '        .Execute()
        '    End With

        'Catch ex As Exception
        '    MensajeError(ex.Message)
        'Finally
        '    Forma = Nothing
        'End Try
    End Sub

    Private Sub ModificaMonto()
        Dim Forma As New FrmIngresaMonto
        Dim Moneda As Char = ""
        Dim Monto As Double = 0.0
        Dim Dolares As Double = 0.0
        Dim TipoCambio As Double = 0.0
        Dim MontoPago As Double = 0.0
        Dim DolaresPago As Double = 0.0
        Dim TipoCambioDocumento As Double = 0.0

        Try
            If LvwMovimientos.SelectedItems Is Nothing OrElse LvwMovimientos.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un item para poder cambiar el monto a pagar")
            End If

            Moneda = CChar(LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.MonedaSTR).Text)
            Monto = CDbl(LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.Monto).Text)
            Dolares = CDbl(LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.PagoDolaresNumeric).Text)
            TipoCambio = CDbl(TxtTipoCambio.Text)
            TipoCambioDocumento = CDbl(LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.TipoCambio).Text)
            MontoPago = Math.Round(CDbl(LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.PagoMontoNumeric).Text), 2)
            DolaresPago = CDbl(LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.PagoDolaresNumeric).Text)

            With Forma
                .PermiteDecimales = True
                .CantidadEnteros = 12
                .CantidadDecimales = 2
                .Descripcion = "Ingrese el monto a pagar"
                .Moneda = Moneda
                .Monto = MontoPago
                .Dolares = DolaresPago
                .TipoCambio = TipoCambio
                .Maximo = IIf(Moneda = coMonedaColones, Monto, Dolares)
                .Execute()
            End With

            If Forma.Acepto Then
                If Forma.Monto <= 0 Or Forma.Dolares <= 0 Then
                    VerificaMensaje("El monto a pagar debe de ser mayor a cero")
                End If

                Select Case Moneda
                    Case coMonedaColones
                        If Forma.Monto > Monto Then
                            VerificaMensaje("El monto a pagar no puede ser mayor al saldo del movimiento = ¢" & Format(Monto, "#,##0.00"))
                        End If
                    Case coMonedaDolares
                        If Forma.Dolares > Dolares Then
                            VerificaMensaje("El monto a pagar no puede ser mayor al saldo del movimiento = $" & Format(Dolares, "#,##0.00"))
                        End If
                End Select

                LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.PagoMonto).Text = Format(Forma.Monto, "#,##0.00")
                LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.PagoDolares).Text = Format(Forma.Dolares, "#,##0.0000")
                LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.PagoMontoNumeric).Text = Forma.Monto.ToString
                LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.PagoDolaresNumeric).Text = Forma.Dolares
                If LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.Moneda).Text = coMonedaDolares Then
                    LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.DiferencialCambiario).Text = Format((CDbl(LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.PagoDolaresNumeric).Text) * TipoCambio) - (CDbl(LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.PagoDolaresNumeric).Text) * TipoCambioDocumento), "#,##0.00")
                    LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.DiferencialCambiario).Text = (CDbl(LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.PagoDolaresNumeric).Text) * TipoCambio) - (CDbl(LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.PagoDolaresNumeric).Text) * TipoCambioDocumento)
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
            CalculaTotales()
            CalculaTotalPago()
        End Try
    End Sub

    Private Sub LvwMovimientos_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles LvwMovimientos.ItemChecked
        CalculaTotalPago()
        BtnGeneraDocumento.Enabled = LvwMovimientos.CheckedItems.Count > 0
    End Sub

    Private Sub CalculaTotalPago()
        Dim TotalDolares As Double = 0
        Dim TotalPago As Double = 0

        Try
            LblTotalDolares.Text = "0.00"
            LblTotalPago.Text = "0.00"

            For Each Item As ListViewItem In LvwMovimientos.CheckedItems
                TotalDolares += CDbl(Item.SubItems(ColumnasDetalle.PagoDolaresNumeric).Text)

                Select Case Item.SubItems(ColumnasDetalle.Moneda).Text
                    Case coMonedaColones
                        TotalPago += CDbl(Item.SubItems(ColumnasDetalle.PagoMontoNumeric).Text)
                    Case coMonedaDolares
                        TotalPago += (CDbl(Item.SubItems(ColumnasDetalle.PagoDolaresNumeric).Text) * CDbl(TxtTipoCambio.Text))
                End Select
            Next

            LblTotalDolares.Text = Format(TotalDolares, "#,##0.00")
            LblTotalPago.Text = Format(TotalPago, "#,##0.00")
            LblTotalDolares.Tag = TotalDolares
            LblTotalPago.Tag = TotalPago
            BtnPagar.Enabled = (CDbl(LblTotalPago.Text) > 0)
            BtnAgregaMovimiento.Enabled = (CDbl(LblTotalPago.Text) > 0)
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LvwMovimientos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LvwMovimientos.MouseDoubleClick
        MnuDetalle.PerformClick()
    End Sub

    Private Sub BtnRefrescar_Click(sender As Object, e As EventArgs) Handles BtnRefrescar.Click
        Try
            VerificaMensaje(ValidaProveedor)
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CmsMovimientos_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CmsMovimientos.Opening
        If LvwMovimientos.Items.Count = 0 OrElse LvwMovimientos.SelectedItems Is Nothing OrElse LvwMovimientos.SelectedItems.Count = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub MnuCambiarMonto_Click(sender As Object, e As EventArgs) Handles MnuCambiarMonto.Click
        Try
            ModificaMonto()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnGeneraDocumento_Click(sender As Object, e As EventArgs) Handles BtnGeneraDocumento.Click
        Dim Forma As New FrmGeneraDocumentoTransferencia
        Dim Solicitud As TCxPSolicitudPago
        Dim ListaSolicitudes As New List(Of TCxPSolicitudPago)
        Dim MontoTotal As Double = 0.0

        Try
            With Forma
                For Each Item As ListViewItem In LvwMovimientos.CheckedItems
                    Solicitud = New TCxPSolicitudPago

                    With Solicitud
                        .Emp_Id = EmpresaInfo.Emp_Id
                        .Solicitud_Id = CLng(Item.SubItems(ColumnasDetalle.Solicitud_Id).Text.Trim)
                        .Tipo_Id = CInt(Item.SubItems(ColumnasDetalle.Tipo_Id).Text.Trim)
                        .Mov_Id = CLng(Item.SubItems(ColumnasDetalle.Mov_Id).Text.Trim)
                        .Monto = CDbl(Item.SubItems(ColumnasDetalle.PagoMontoNumeric).Text.Trim)
                    End With

                    ListaSolicitudes.Add(Solicitud)
                    MontoTotal += Solicitud.Monto
                Next
                .Prov_Id = CInt(TxtProveedor.Text.Trim)
                .Monto = MontoTotal
                .Solicitudes = ListaSolicitudes
                .Execute()
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

End Class