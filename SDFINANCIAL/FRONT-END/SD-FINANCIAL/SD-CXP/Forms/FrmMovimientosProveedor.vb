Imports BUSINESS
Public Class FrmMovimientosProveedor
#Region "Enums"
    Private Enum ColumnasDetalle
        TipoNombre = 0
        Mov_Id = 1
        Tipo_Id = 2
        Referencia = 3
        Fecha = 4
        Vence = 5
        Moneda = 6
        Monto = 7
        TipoCambio = 8
        Dolares = 9
        Saldo = 10
        FechaMora = 11
        SaldoAnterior = 12
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
            ConfiguraDetalle()
            CargaCombos()
            Inicializa()

            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaCombos()
        Dim CxPMovimientoTipo As New TCxPMovimientoTipo

        Try
            CxPMovimientoTipo.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(CxPMovimientoTipo.LoadComboTipoRecibeMovimientos(CmbMovimientoTipo))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CxPMovimientoTipo = Nothing
        End Try
    End Sub

    Private Sub ConfiguraDetalle()
        Try
            With LvwMovimientos
                .Columns(ColumnasDetalle.Mov_Id).Text = "Documento"
                .Columns(ColumnasDetalle.Mov_Id).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Mov_Id).Width = 70

                .Columns(ColumnasDetalle.Tipo_Id).Text = ""
                .Columns(ColumnasDetalle.Tipo_Id).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Tipo_Id).Width = 0

                .Columns(ColumnasDetalle.TipoNombre).Text = "Tipo"
                .Columns(ColumnasDetalle.TipoNombre).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.TipoNombre).Width = 172

                .Columns(ColumnasDetalle.Referencia).Text = "Referencia"
                .Columns(ColumnasDetalle.Referencia).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Referencia).Width = 300

                .Columns(ColumnasDetalle.Fecha).Text = "Fecha"
                .Columns(ColumnasDetalle.Fecha).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Fecha).Width = 80

                .Columns(ColumnasDetalle.Vence).Text = "Vence"
                .Columns(ColumnasDetalle.Vence).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Vence).Width = 80

                .Columns(ColumnasDetalle.Moneda).Text = "Moneda"
                .Columns(ColumnasDetalle.Moneda).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Moneda).Width = 65

                .Columns(ColumnasDetalle.Monto).Text = "Monto"
                .Columns(ColumnasDetalle.Monto).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Monto).Width = 120

                .Columns(ColumnasDetalle.TipoCambio).Text = "T.Cambio"
                .Columns(ColumnasDetalle.TipoCambio).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.TipoCambio).Width = 60

                .Columns(ColumnasDetalle.Dolares).Text = "Dólares"
                .Columns(ColumnasDetalle.Dolares).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Dolares).Width = 120

                .Columns(ColumnasDetalle.Saldo).Text = "Saldo"
                .Columns(ColumnasDetalle.Saldo).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Saldo).Width = 120

                .Columns(ColumnasDetalle.FechaMora).Text = ""
                .Columns(ColumnasDetalle.FechaMora).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.FechaMora).Width = 0

                .Columns(ColumnasDetalle.SaldoAnterior).Text = "Saldo Ant"
                .Columns(ColumnasDetalle.SaldoAnterior).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.SaldoAnterior).Width = 120
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaDetalle()
        Dim CxPMovimiento As New TCxPMovimiento
        Dim Items(13) As String
        Dim Item As ListViewItem = Nothing
        Dim FechaHoy As Date = EmpresaInfo.Getdate()
        Dim Texto As String = ""

        Try
            LvwMovimientos.Items.Clear()

            If TxtProveedorNombre.Text.Trim = "" Then
                Exit Sub
            End If

            With CxPMovimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = CInt(TxtProveedor.Text.Trim)
            End With
            VerificaMensaje(CxPMovimiento.MovimientosProveedor(CmbFiltro.SelectedIndex))

            If CxPMovimiento.RowsAffected = 0 Then
                Exit Sub
            End If

            For Each Mov As DataRow In CxPMovimiento.Datos.Tables(0).Rows
                If Mov("Tipo_Id") <> Enum_CxPMovimientoTipo.Factura And Mov("Tipo_Id") <> Enum_CxPMovimientoTipo.NotaDebito Then
                    Texto = "NO APLICA"
                Else
                    Texto = Format(Mov("FechaVencimiento"), "dd/MM/yyyy")
                End If
                Items(ColumnasDetalle.TipoNombre) = UCase(Mov("TipoNombre"))
                Items(ColumnasDetalle.Mov_Id) = Mov("Mov_Id")
                Items(ColumnasDetalle.Tipo_Id) = Mov("Tipo_Id")
                Items(ColumnasDetalle.Referencia) = Mov("Referencia")
                Items(ColumnasDetalle.Fecha) = Format(Mov("FechaDocumento"), "dd/MM/yyyy")
                Items(ColumnasDetalle.Vence) = Texto
                Items(ColumnasDetalle.Moneda) = IIf(Mov("Moneda") = coMonedaColones, "COLONES", "DOLARES")
                Items(ColumnasDetalle.Monto) = Format(Mov("Monto"), "#,##0.00")
                Items(ColumnasDetalle.TipoCambio) = Format(Mov("TipoCambio"), "#,##0.00")
                Items(ColumnasDetalle.Dolares) = Format(Mov("Dolares"), "#,##0.0000")
                Items(ColumnasDetalle.Saldo) = Format(Mov("Saldo"), "#,##0.00")
                Items(ColumnasDetalle.FechaMora) = Format(Mov("FechaVencimiento"), "yyyy-MM-dd")

                If Not IsDBNull(Mov("SaldoAnterior")) AndAlso Mov("SaldoAnterior") <> 0 Then
                    Items(ColumnasDetalle.SaldoAnterior) = Format(Mov("SaldoAnterior"), "#,##0.00")
                Else
                    Items(ColumnasDetalle.SaldoAnterior) = String.Empty
                End If

                Item = New ListViewItem(Items)
                LvwMovimientos.Items.Add(Item)

                If Mov("IncrementaSaldo") = 0 Then
                    ListViewCambiaColorFila(Item, Color.LightSeaGreen)
                Else
                    'Si ya el documento fue cancelado
                    If Mov("Saldo") <= 0 Then
                        Item.ImageIndex = 1
                    ElseIf Mov("Estado_Id") = Enum_CxPMovimientoEstado.EnProceso Then
                        Item.ImageIndex = 2
                        Item.ForeColor = Color.SteelBlue
                    ElseIf DateValue(Mov("FechaVencimiento")) < DateValue(FechaHoy) Then
                        Item.ImageIndex = 0
                        Item.ForeColor = Color.Red
                    End If
                End If
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CxPMovimiento = Nothing
            CalculaTotales()
            BtnPagar.Enabled = (CDbl(LblTotalSaldo.Text) > 0)
            BtnPagando.Enabled = (CDbl(LblTotalProcesoPago.Text) > 0)
        End Try
    End Sub

    Private Sub Inicializa()
        Try
            TxtProveedor.ReadOnly = False
            TxtProveedor.Text = ""
            TxtProveedorNombre.Text = ""
            CmbMovimientoTipo.Enabled = False
            CmbFiltro.Enabled = False
            CmbFiltro.SelectedIndex = 1
            BtnAgregaMovimiento.Enabled = False

            LvwMovimientos.Items.Clear()

            'Botones
            BtnBuscar.Enabled = True
            BtnPagar.Enabled = False
            BtnEstadoCuenta.Enabled = False
            BtnRefrescar.Enabled = False
            BtnLimpiar.Enabled = False

            'Totales
            LblTotalMora.Text = ""
            LblTotalProcesoPago.Text = ""
            LblTotalSaldo.Text = ""
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CalculaTotales()
        Dim Movimiento As New TCxPMovimiento
        Dim Proveedor As New TProveedor
        Dim Mora As Double = 0.0
        Dim Pagando As Double = 0.0

        Try
            LblTotalMora.Text = "0.00"
            LblTotalProcesoPago.Text = "0.00"
            LblTotalSaldo.Text = "0.00"

            If TxtProveedor.Text.Trim = "" Then
                Exit Sub
            End If

            With Proveedor
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = CInt(TxtProveedor.Text.Trim)
            End With
            VerificaMensaje(Proveedor.ListKey)

            If Proveedor.RowsAffected = 0 Then
                VerificaMensaje("El código de proveedor no es válido")
            End If

            If Not Proveedor.Activo Then
                VerificaMensaje("El proveedor se encuentra inactivo")
            End If

            With Movimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Tipo_Id = Enum_CxPMovimientoTipo.NotaDebitoXIntereses
                .Prov_Id = CInt(TxtProveedor.Text.Trim)
            End With
            VerificaMensaje(Movimiento.ObtieneMontoMora(Mora))
            VerificaMensaje(Movimiento.ObtieneMontoPagando(Pagando))

            LblTotalMora.Text = Format(Mora, "#,##0.00")
            LblTotalProcesoPago.Text = Format(Pagando, "#,##0.00")
            LblTotalSaldo.Text = Format(Proveedor.Saldo, "#,##0.00")
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Movimiento = Nothing
            Proveedor = Nothing
        End Try
    End Sub

    Private Function ValidaProveedor()
        Dim Proveedor As New TProveedor

        Try
            With Proveedor
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = CInt(TxtProveedor.Text.Trim)
            End With
            VerificaMensaje(Proveedor.ListKey)

            If Proveedor.RowsAffected = 0 Then
                VerificaMensaje("El código de proveedor no es válido")
            End If

            If Not Proveedor.Activo Then
                EnfocarTexto(TxtProveedor)
                VerificaMensaje("El proveedor se encuentra inactivo")
            End If

            TxtProveedorNombre.Text = Proveedor.Nombre
            LblTotalMora.Text = "0.00"
            LblTotalProcesoPago.Text = Format(Proveedor.Debitos, "#,##0.00")
            LblTotalSaldo.Text = Format(Proveedor.Saldo, "#,##0.00")

            TxtProveedor.ReadOnly = True
            CmbMovimientoTipo.Enabled = True
            CmbFiltro.Enabled = True
            BtnBuscar.Enabled = False
            BtnAgregaMovimiento.Enabled = True
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

    Private Sub FacturasPendientes()
        Dim Forma As New FrmSolictaCxPMovimientos
        Dim SolicitudPago As New TCxPSolicitudPago

        Try
            With Forma
                .Tipo_Id = 1
                .Prov_Id = CInt(TxtProveedor.Text.Trim)
                .Execute()
            End With

            If Forma.Selecciono Then
                With SolicitudPago
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Prov_Id = CInt(TxtProveedor.Text.Trim)
                    .Usuario_Id = UsuarioInfo.Usuario_Id
                    .ListaMovimientos = Forma.ListaMovimientos
                End With
                VerificaMensaje(SolicitudPago.Insert)
                CargaDetalle()
                Mensaje("El proceso se completó exitosamente")
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
            SolicitudPago = Nothing
        End Try
    End Sub

    Private Sub FacturasProcesoPago()
        Dim Forma As New FrmSolictaCxPMovimientos
        Dim SolicitudPago As New TCxPSolicitudPago

        Try
            With Forma
                .Tipo_Id = 2
                .Prov_Id = CInt(TxtProveedor.Text.Trim)
                .Execute()
            End With

            If Forma.Selecciono Then
                With SolicitudPago
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Prov_Id = CInt(TxtProveedor.Text.Trim)
                    .Usuario_Id = UsuarioInfo.Usuario_Id
                    .ListaMovimientos = Forma.ListaMovimientos
                End With
                VerificaMensaje(SolicitudPago.Delete)
                CargaDetalle()
                Mensaje("El proceso se completó exitosamente!")
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
            SolicitudPago = Nothing
        End Try
    End Sub

    Private Sub CreaMovimiento()
        Dim Forma As New FrmMovimientoCrea

        Try
            With Forma
                .Prov_Id = CInt(TxtProveedor.Text.Trim)
                .Tipo_Id = CmbMovimientoTipo.SelectedValue
                .Execute()
            End With

            If Forma.AplicoMovimiento Then
                VerificaMensaje(ValidaProveedor)
                BtnPagar.Enabled = (CDbl(LblTotalSaldo.Text) > 0)
                BtnLimpiar.Enabled = True
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
        Dim Proveedor As New TProveedor
        Dim Movimiento As New TCxPMovimiento
        Dim Reporte As New RptCxPEstadoCuenta
        Dim FormaReporte As New FrmReporte

        Try
            Cursor = Cursors.WaitCursor

            With Movimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = CInt(TxtProveedor.Text.Trim)
            End With
            VerificaMensaje(Movimiento.RptCxPEstadoCuenta)

            If Movimiento.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            With Proveedor
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = CInt(TxtProveedor.Text.Trim)
            End With
            VerificaMensaje(Proveedor.RptConsultaInformacionProveedor)

            If Proveedor.RowsAffected = 0 Then
                VerificaMensaje("Ocurrió un error obteniendo la información del proveedor")
            End If

            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)

            Reporte.SetDataSource(Movimiento.Datos.Tables(0))
            Reporte.Subreports(0).SetDataSource(Proveedor.Datos.Tables(0))
            Reporte.Subreports(1).SetDataSource(EmpresaInfo.Datos.Tables(0))
            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            Movimiento = Nothing
            Proveedor = Nothing
            Cursor = Cursors.Default
        End Try
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
        FacturasPendientes()
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
            Select Case CmbMovimientoTipo.SelectedValue
                Case Enum_CxPMovimientoTipo.Pago
                    FacturasPendientes()
                Case Else
                    CreaMovimiento()
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmMovimientosCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                BtnBuscar.PerformClick()
            Case Keys.F2
                BtnPagar.PerformClick()
            Case Keys.F3
                BtnPagando.PerformClick()
            Case Keys.F4
                BtnEstadoCuenta.PerformClick()
            Case Keys.F5
                BtnRefrescar.PerformClick()
            Case Keys.F12
                BtnLimpiar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub CmbFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFiltro.SelectedIndexChanged
        CargaDetalle()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        BuscaProveedor()
    End Sub

    Private Sub MnuReimprimir_Click(sender As Object, e As EventArgs) Handles MnuReimprimir.Click
        Dim Tipo_Id As Integer = 0
        Dim Mov_Id As Long = 0

        Try
            If LvwMovimientos Is Nothing OrElse LvwMovimientos.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar el Movimiento que desea reimprimir")
            End If

            Tipo_Id = CInt(LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.Tipo_Id).Text.Trim)
            Mov_Id = CLng(LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.Mov_Id).Text.Trim)

            VerificaMensaje(ImprimeCxPMovimiento(EmpresaInfo, Tipo_Id, Mov_Id, True))

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnEstadoCuenta_Click(sender As Object, e As EventArgs) Handles BtnEstadoCuenta.Click
        If ValidaEstadoCuenta() Then
            MuestraEstadoCuenta()
        End If
    End Sub

    Private Sub MnuDetalle_Click(sender As Object, e As EventArgs) Handles MnuDetalle.Click
        Dim Forma As New FrmMovimientoListaAplicados

        Try
            If LvwMovimientos Is Nothing OrElse LvwMovimientos.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar el Movimiento que desea consultar")
            End If

            With Forma
                .Tipo_Id = CInt(LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.Tipo_Id).Text.Trim)
                .Movimiento_Id = CLng(LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.Mov_Id).Text.Trim)
                .Execute()
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
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

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnPagando.Click
        FacturasProcesoPago()
    End Sub

    Private Sub CmsMovimientos_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CmsMovimientos.Opening
        If LvwMovimientos.SelectedItems Is Nothing OrElse LvwMovimientos.SelectedItems.Count = 0 Then
            e.Cancel = True
        End If
    End Sub

End Class