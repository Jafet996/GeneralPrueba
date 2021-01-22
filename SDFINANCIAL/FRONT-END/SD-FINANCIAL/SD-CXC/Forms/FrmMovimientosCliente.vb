Imports BUSINESS
Public Class FrmMovimientosCliente
#Region "Enums"
    Private Enum ColumnasDetalle
        TipoNombre = 0
        Mov_Id = 1
        Tipo_Id = 2
        Referencia = 3
        Fecha = 4
        Entrega = 5
        Vence = 6
        Moneda = 7
        Monto = 8
        TipoCambio = 9
        Dolares = 10
        Saldo = 11
        FechaMora = 12
    End Enum
#End Region
#Region "Variables"
    Private Numerico() As TNumericFormat
    Public _Cmb_Suc As Integer
#End Region
#Region "Funciones Privadas"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtCliente, 7, 0, False, "", "###")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

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
                .Columns(ColumnasDetalle.Referencia).Width = 285

                .Columns(ColumnasDetalle.Fecha).Text = "Fecha"
                .Columns(ColumnasDetalle.Fecha).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Fecha).Width = 80

                .Columns(ColumnasDetalle.Entrega).Text = "Entrega"
                .Columns(ColumnasDetalle.Entrega).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Entrega).Width = 80

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
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

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
        Dim CxCMovimientoTipo As New TCxCMovimientoTipo
        Dim Empresa As New TEmpresa
        Try

            CxCMovimientoTipo.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(CxCMovimientoTipo.LoadComboTipoRecibeMovimientos(CmbMovimientoTipo))



        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CxCMovimientoTipo = Nothing
        End Try
    End Sub

    Private Sub Inicializa()
        Try
            TxtCliente.ReadOnly = False
            TxtCliente.Text = ""
            TxtClienteNombre.Text = ""
            CmbMovimientoTipo.Enabled = False
            CmbFiltro.Enabled = False
            CmbFiltro.SelectedIndex = 1
            BtnAgregaMovimiento.Enabled = False

            LvwMovimientos.Items.Clear()

            'Botones
            BtnBuscar.Enabled = True
            BtnPagar.Enabled = False
            BtnMora.Enabled = False
            BtnEstadoCuenta.Enabled = False
            BtnRefrescar.Enabled = False
            BtnLimpiar.Enabled = False

            'Totales
            LblTotalMora.Text = ""
            LblTotalDebitos.Text = ""
            LblTotalCreditos.Text = ""
            LblTotalSaldo.Text = ""
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CalculaTotales()
        Dim Cliente As New TCliente
        Dim Mora As Double = 0.0

        Try
            LblTotalMora.Text = "0.00"
            LblTotalDebitos.Text = "0.00"
            LblTotalCreditos.Text = "0.00"
            LblTotalSaldo.Text = "0.00"

            With Cliente
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cliente_Id = CInt(TxtCliente.Text)
            End With
            VerificaMensaje(Cliente.ListKey)

            If Cliente.RowsAffected = 0 Then
                VerificaMensaje("El código de cliente no es válido")
            End If

            VerificaMensaje(Cliente.CalculaMontoMora(EmpresaInfo.Getdate, UsuarioInfo.Usuario_Id, 0, Mora))

            LblTotalMora.Text = Format(Mora, "#,##0.00")
            LblTotalDebitos.Text = Format(Cliente.Debitos, "#,##0.00")
            LblTotalCreditos.Text = Format(Cliente.Creditos, "#,##0.00")
            LblTotalSaldo.Text = Format(Cliente.Saldo, "#,##0.00")
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
        End Try
    End Sub

    Private Sub MarcaMovimientosVencidos()
        Dim Cliente As New TCliente
        Dim FechaVence As DateTime
        Dim FechaMora As DateTime
        Dim TipoMov As Integer
        Dim Saldo As Double = 0.0

        Try
            For Each Item As ListViewItem In LvwMovimientos.Items
                TipoMov = CInt(Item.SubItems(ColumnasDetalle.Tipo_Id).Text.Trim)
                Saldo = CDbl(Item.SubItems(ColumnasDetalle.Saldo).Text.Trim)

                If TipoMov <> Enum_CxCMovimientoTipo.Factura And TipoMov <> Enum_CxCMovimientoTipo.NotaDebito Then
                    Continue For
                End If

                If Saldo = 0 Then
                    Item.ImageIndex = 1
                    Continue For
                End If

                With Cliente
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Cliente_Id = CInt(TxtCliente.Text.Trim)
                End With
                VerificaMensaje(Cliente.ListKey)

                FechaVence = CDate(Item.SubItems(ColumnasDetalle.FechaMora).Text.Trim)
                FechaMora = DateAdd(DateInterval.Day, Cliente.DiasGraciaMora, FechaVence)

                If DateValue(FechaMora) < DateValue(EmpresaInfo.Getdate) Then
                    Item.ImageIndex = 0
                    Item.ForeColor = Color.Red
                End If
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
        End Try
    End Sub

    Private Sub CargaDetalle()
        Dim CxCMovimiento As New TCxCMovimiento
        Dim Items(12) As String
        Dim Item As ListViewItem = Nothing
        Dim Texto As String = ""

        Try
            LvwMovimientos.Items.Clear()

            If TxtClienteNombre.Text.Trim = "" Then
                Exit Sub
            End If

            With CxCMovimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cliente_Id = CInt(TxtCliente.Text)
            End With
            VerificaMensaje(CxCMovimiento.MovimientosCliente(CmbFiltro.SelectedIndex))

            If CxCMovimiento.RowsAffected = 0 Then
                Exit Sub
            End If

            For Each Mov As DataRow In CxCMovimiento.Datos.Tables(0).Rows
                If Mov("Tipo_Id") <> Enum_CxPMovimientoTipo.Factura And Mov("Tipo_Id") <> Enum_CxPMovimientoTipo.NotaDebito Then
                    Texto = "NO APLICA"
                Else
                    Texto = Format(Mov("FechaVencimiento"), "dd/MM/yyyy")
                End If
                Items(ColumnasDetalle.Mov_Id) = Mov("Mov_Id")
                Items(ColumnasDetalle.TipoNombre) = UCase(Mov("TipoNombre"))
                Items(ColumnasDetalle.Tipo_Id) = Mov("Tipo_Id")
                Items(ColumnasDetalle.Referencia) = Mov("Referencia")
                Items(ColumnasDetalle.Fecha) = Format(Mov("FechaDocumento"), "dd/MM/yyyy")
                Items(ColumnasDetalle.Entrega) = Format(Mov("FechaRecibido"), "dd/MM/yyyy")
                Items(ColumnasDetalle.Vence) = Texto
                Items(ColumnasDetalle.Moneda) = IIf(Mov("Moneda") = coMonedaColones, "COLONES", "DOLARES")
                Items(ColumnasDetalle.Monto) = Format(Mov("Monto"), "#,##0.00")
                Items(ColumnasDetalle.TipoCambio) = Format(Mov("TipoCambio"), "#,##0.00")
                Items(ColumnasDetalle.Dolares) = Format(Mov("Dolares"), "#,##0.0000")
                Items(ColumnasDetalle.Saldo) = Format(Mov("Saldo"), "#,##0.00")
                Items(ColumnasDetalle.FechaMora) = Format(Mov("FechaVencimiento"), "yyyy-MM-dd")

                Item = New ListViewItem(Items)
                LvwMovimientos.Items.Add(Item)

                If Mov("IncrementaSaldo") = 0 Then
                    ListViewCambiaColorFila(Item, Color.LightSeaGreen)
                End If
            Next

            CalculaTotales()
            MarcaMovimientosVencidos()

            BtnPagar.Enabled = (CDbl(LblTotalSaldo.Text) > 0)
            BtnMora.Enabled = (CDbl(LblTotalMora.Text) > 0)
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CxCMovimiento = Nothing
        End Try
    End Sub

    Private Function ValidaCliente()
        Dim Cliente As New TCliente

        Try
            With Cliente
                .Emp_Id = EmpresaInfo.Emp_Id

                .Cliente_Id = CInt(TxtCliente.Text)
            End With
            VerificaMensaje(Cliente.ListKey)

            If Cliente.RowsAffected = 0 Then
                VerificaMensaje("El código de cliente no es válido")
            End If

            If Not Cliente.Activo Then
                EnfocarTexto(TxtCliente)
                VerificaMensaje("El cliente se encuentra inactivo")
            End If

            TxtClienteNombre.Text = Cliente.Nombre
            LblTotalMora.Text = "0.00"
            LblTotalDebitos.Text = Format(Cliente.Debitos, "#,##0.00")
            LblTotalCreditos.Text = Format(Cliente.Creditos, "#,##0.00")
            LblTotalSaldo.Text = Format(Cliente.Saldo, "#,##0.00")

            TxtCliente.ReadOnly = True
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
            Cliente = Nothing
        End Try
    End Function

    Private Sub BuscaCliente()
        Dim Forma As New FrmBusquedaCliente

        Try
            Forma.Execute()

            If Forma.Selecciono Then
                TxtCliente.Text = Forma.Cliente_Id
                VerificaMensaje(ValidaCliente)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Function ValidaEstadoCuenta() As Boolean
        Try
            VerificaMensaje(ValidaCliente)

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub MuestraEstadoCuenta()
        Dim Cliente As New TCliente
        Dim Movimiento As New TCxCMovimiento
        Dim Reporte As New RptCxCEstadoCuenta
        Dim FormaReporte As New FrmReporte

        Try
            Cursor = Cursors.WaitCursor

            With Movimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cliente_Id = CInt(TxtCliente.Text.Trim)
            End With
            VerificaMensaje(Movimiento.RptCxCEstadoCuenta)

            If Movimiento.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            With Cliente
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cliente_Id = CInt(TxtCliente.Text.Trim)
            End With
            VerificaMensaje(Cliente.RptConsultaInformacionCliente)

            If Cliente.RowsAffected = 0 Then
                VerificaMensaje("Ocurrió un error obteniendo la información del cliente")
            End If

            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)

            Reporte.SetDataSource(Movimiento.Datos.Tables(0))
            Reporte.Subreports(0).SetDataSource(Cliente.Datos.Tables(0))
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
            Cliente = Nothing
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMovimientosCliente_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            Me.Width = Screen.PrimaryScreen.WorkingArea.Size.Width
            Me.Height = Screen.PrimaryScreen.WorkingArea.Size.Height - 50

            Me.CenterToScreen()

            FormateaCamposNumericos()
            TxtCliente.Select()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnPagar_Click(sender As Object, e As EventArgs) Handles BtnPagar.Click
        Dim Forma As New FrmMovimientoCrea
        Dim FormaSeleccion As New FrmSolictaCxCMovimientos

        Try
            With FormaSeleccion
                .Cliente_Id = CInt(TxtCliente.Text.Trim)
                .Execute()
            End With

            If Not FormaSeleccion.Selecciono Then
                Exit Sub
            End If

            VerificaMensaje(VerificaAperturaCaja(True))

            With Forma
                .Cliente_Id = CInt(TxtCliente.Text)
                .Tipo_Id = Enum_CxCMovimientoTipo.Recibo
                .ListaMovimiento = FormaSeleccion.ListaMovimientos
                .Monto = FormaSeleccion.MontoTotal
                .Execute()
            End With

            If Forma.AplicoMovimiento Then
                BtnPagar.Enabled = (CDbl(LblTotalSaldo.Text) > 0)
                BtnMora.Enabled = (CDbl(LblTotalMora.Text) > 0)
                BtnLimpiar.Enabled = True
            End If

            VerificaMensaje(ValidaCliente)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
            FormaSeleccion = Nothing
        End Try
    End Sub

    Private Sub TxtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCliente.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    If IsNumeric(TxtCliente.Text) Then
                        VerificaMensaje(ValidaCliente)
                    End If
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCliente_TextChanged(sender As Object, e As EventArgs) Handles TxtCliente.TextChanged
        TxtClienteNombre.Text = ""
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        Try
            Inicializa()
            TxtCliente.Focus()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnAgregaMovimiento_Click(sender As Object, e As EventArgs) Handles BtnAgregaMovimiento.Click
        Dim Forma As New FrmMovimientoCrea

        Try
            If CmbMovimientoTipo.SelectedValue = Enum_CxCMovimientoTipo.Recibo Then
                VerificaMensaje(VerificaAperturaCaja(True))
            End If

            With Forma
                .Cliente_Id = CInt(TxtCliente.Text.Trim)
                .Tipo_Id = CmbMovimientoTipo.SelectedValue
                .Execute()
            End With

            If Forma.AplicoMovimiento Then
                BtnPagar.Enabled = (CDbl(LblTotalSaldo.Text) > 0)
                BtnMora.Enabled = (CDbl(LblTotalMora.Text) > 0)
                BtnLimpiar.Enabled = True
            End If

            VerificaMensaje(ValidaCliente)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub FrmMovimientosCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                BtnBuscar.PerformClick()
            Case Keys.F2
                BtnPagar.PerformClick()
            Case Keys.F3
                BtnMora.PerformClick()
            Case Keys.F4
                BtnEstadoCuenta.PerformClick()
            Case Keys.F5
                BtnRefrescar.PerformClick()
            Case Keys.F6
                BtnAgregaMovimiento.PerformClick()
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
        BuscaCliente()
    End Sub

    Private Sub BtnMora_Click(sender As Object, e As EventArgs) Handles BtnMora.Click
        Dim Cliente As New TCliente
        Dim Mora As Double = 0.0

        Try
            If MsgBox("¿Desea generar los intereses por mora del cliente?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, Me.Text) <> MsgBoxResult.Ok Then
                Exit Sub
            End If

            With Cliente
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cliente_Id = CInt(TxtCliente.Text.Trim)
            End With
            VerificaMensaje(Cliente.CalculaMontoMora(EmpresaInfo.Getdate, UsuarioInfo.Usuario_Id, 1, Mora))
            VerificaMensaje(ValidaCliente)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
        End Try
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

            VerificaMensaje(ImprimeMovimiento(EmpresaInfo, Tipo_Id, Mov_Id, True))

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnEstadoCuenta_Click(sender As Object, e As EventArgs) Handles BtnEstadoCuenta.Click
        If ValidaEstadoCuenta() Then
            Dim Forma As New FrmRptEstadoCuenta

            Try
                Forma.Nuevo = False
                Forma.Cliente_Id = CInt(TxtCliente.Text)
                Forma.Nombre = TxtClienteNombre.Text
                Forma.Execute()
            Catch ex As Exception
                MensajeError(ex.Message)
            Finally
                Forma = Nothing
            End Try
            'MuestraEstadoCuenta()
        End If
    End Sub

    Private Sub MnuDetalle_Click(sender As Object, e As EventArgs) Handles MnuDetalle.Click
        Dim Forma As New FrmMovimientoListaAplicados

        Try
            If LvwMovimientos Is Nothing OrElse LvwMovimientos.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar el Movimiento que desea reimprimir")
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
            VerificaMensaje(ValidaCliente)
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CmsMovimientos_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CmsMovimientos.Opening
        If LvwMovimientos.SelectedItems Is Nothing OrElse LvwMovimientos.SelectedItems.Count = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub BtnMovimiento_Click(sender As Object, e As EventArgs) Handles BtnMovimiento.Click
        If ValidaEstadoCuenta() Then
            MuestraEstadoCuenta()
        End If
    End Sub


End Class