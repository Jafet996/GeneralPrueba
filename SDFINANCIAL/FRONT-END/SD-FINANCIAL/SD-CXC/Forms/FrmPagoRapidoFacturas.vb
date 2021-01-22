Imports BUSINESS

Public Class FrmPagoRapidoFacturas

    Private cliente As TCliente
    Private Numerico() As TNumericFormat

    Private Enum ColumnasDetalle
        Mov_Id
        TipoNombre
        Tipo_Id
        Referencia
        Vence
        Saldo
        Monto
    End Enum

    Public Sub Execute()
        FormateCamposNumericos()
        ConfiguraLista()
        inicializa()
        Me.ShowDialog()
    End Sub

    Private Sub FormateCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtPago, 12, 2, False, "", "#,##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ConfiguraLista()
        Try

            With LvwFacturas
                .Columns(ColumnasDetalle.Mov_Id).Text = "Documento"
                .Columns(ColumnasDetalle.Mov_Id).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Mov_Id).Width = 70

                .Columns(ColumnasDetalle.Tipo_Id).Text = ""
                .Columns(ColumnasDetalle.Tipo_Id).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Tipo_Id).Width = 0

                .Columns(ColumnasDetalle.TipoNombre).Text = "Tipo"
                .Columns(ColumnasDetalle.TipoNombre).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.TipoNombre).Width = 0

                .Columns(ColumnasDetalle.Referencia).Text = "Referencia"
                .Columns(ColumnasDetalle.Referencia).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Referencia).Width = 200

                .Columns(ColumnasDetalle.Vence).Text = "Vence"
                .Columns(ColumnasDetalle.Vence).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Vence).Width = 80

                .Columns(ColumnasDetalle.Monto).Text = "Monto"
                .Columns(ColumnasDetalle.Monto).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Monto).Width = 120

                .Columns(ColumnasDetalle.Saldo).Text = "Saldo"
                .Columns(ColumnasDetalle.Saldo).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Saldo).Width = 120
            End With

        Catch ex As Exception

            MensajeError(ex.Message)

        End Try
    End Sub

    Private Sub CargaLista()
        Dim CxCMovimiento As New TCxCMovimiento
        Dim Items(6) As String
        Dim Item As ListViewItem = Nothing

        Try
            LvwFacturas.Items.Clear()

            LvwFacturas.CheckBoxes = True

            With CxCMovimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cliente_Id = cliente.Cliente_Id
            End With
            VerificaMensaje(CxCMovimiento.MovimientosClienteRecibo)

            If CxCMovimiento.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos")
            End If

            For Each Fila As DataRow In CxCMovimiento.Datos.Tables(0).Rows
                Items(ColumnasDetalle.Mov_Id) = Fila("Mov_Id")
                Items(ColumnasDetalle.TipoNombre) = UCase(Fila("TipoNombre"))
                Items(ColumnasDetalle.Tipo_Id) = Fila("Tipo_Id")
                Items(ColumnasDetalle.Referencia) = Fila("Referencia")
                Items(ColumnasDetalle.Vence) = Format(Fila("FechaVencimiento"), "dd/MM/yyyy")
                Items(ColumnasDetalle.Monto) = Format(Fila("Monto"), "#,##0.00")
                Items(ColumnasDetalle.Saldo) = Format(Fila("Saldo"), "#,##0.00")

                Item = New ListViewItem(Items)


                LvwFacturas.Items.Add(Item)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CxCMovimiento = Nothing
        End Try
    End Sub


    Private Sub BuscarCliente()

        Dim busqueda As New FrmBusquedaCliente()

        Try
            cliente = New TCliente()
            cliente.Emp_Id = EmpresaInfo.Emp_Id

            busqueda.Execute()

            If busqueda.Selecciono Then

                cliente.Cliente_Id = busqueda.Cliente_Id
                VerificaMensaje(cliente.ListKey())
                EstableceDatosCliente()

            Else

                Exit Sub

            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try


    End Sub


    Private Sub EstableceDatosCliente()

        If cliente.Nombre <> "" Then

            TxtCodigo.Text = cliente.Cliente_Id
            TxtNombre.Text = cliente.Nombre
            BtnPagar.Enabled = True
            CargaLista()
            TxtPago.ReadOnly = False

        End If

    End Sub

    Private Function ValidaTodo() As Boolean

        Try
            If CDbl(TxtPago.Text) < 0 Or TxtPago.Text.Equals("") Then

                VerificaMensaje("No puede hacer un pago con el monto digitado.")

            End If

            If LvwFacturas.CheckedItems.Count < 0 Then

                VerificaMensaje("Debe selecionar las facturas las cuales va a aplicar el pago.")

            End If

            If TxtReferencia.Text.Equals("") Then
                If vbNo = MsgBox("Desea dejar el espacio de referencia vacio", MsgBoxStyle.YesNo, "caption") Then
                    Return False
                End If
            End If


            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try




    End Function

    Private Sub EfectuaPagos()
        Try

            Dim Movimiento As New TCxCMovimiento()
            Dim _ListaMovimiento As New List(Of TCxCMovimientoLinea)()
            Dim FormaPagoFisico As New FrmMovimientoPagoFisico
            Dim FormaPagoElectronico As New FrmMovimientoPagoElectronico
            Dim FormaPago As New FrmMovimientoFormaPago
            Dim ExedentePago As Double = 0.0
            Dim Vuelto As Double = 0.0

            FormaPago.Execute()

            If Not FormaPago.Acepto Then
                Exit Sub
            End If

            Select Case FormaPago.TipoTransaccion
                Case Enum_TipoTransaccion.Fisica
                    With FormaPagoFisico
                        .TotalFactura = CDbl(TxtPago.Text)
                        .Execute()
                    End With

                    If Not FormaPagoFisico.PagoDocumento Then
                        Exit Sub
                    End If

                    Vuelto = FormaPagoFisico.Vuelto
                    Movimiento.ListaPagos = FormaPagoFisico.MovimientoPagos
                Case Enum_TipoTransaccion.Electronica
                    With FormaPagoElectronico
                        .TotalFactura = TxtPago.Text.Trim
                        .Execute()
                    End With

                    If Not FormaPagoElectronico.PagoDocumento Then
                        Exit Sub
                    End If

                    If FormaPagoElectronico.GeneraNotaCredito Then
                        With Movimiento
                            .GeneraNotaCredito = True
                            .MontoNotaCredito = FormaPagoElectronico.Vuelto
                        End With
                    End If

                    Movimiento.ListaPagos = FormaPagoElectronico.MovimientoPagos
                Case Else
                    VerificaMensaje("El tipo de transacción seleccionado no es válido")
            End Select

            With cliente
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cliente_Id = TxtCodigo.Text
            End With
            VerificaMensaje(cliente.ListKey)

            If cliente.RowsAffected = 0 Then
                VerificaMensaje("No se encontró un cliente con el código " & TxtCodigo.Text)
            End If

            If cliente.Saldo > 0 AndAlso cliente.Saldo < CDbl(TxtPago.Text.Trim) Then
                ExedentePago = CDbl(TxtPago.Text.Trim) - cliente.Saldo

                With Movimiento
                    .GeneraNotaCredito = True
                    .MontoNotaCredito += ExedentePago
                End With
            End If

            Dim monto = CDbl(TxtPago.Text)

            For Each item In LvwFacturas.CheckedItems

                Dim movimientoLinea As New TCxCMovimientoLinea()

                With movimientoLinea
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Monto = If(monto > CDbl(item.SubItems(ColumnasDetalle.Saldo).Text.ToString()), CDbl(item.SubItems(ColumnasDetalle.Saldo).Text.ToString()), monto)
                    monto = monto - .Monto
                    .Mov_Id = item.SubItems(ColumnasDetalle.Mov_Id).Text.ToString()
                    .Tipo_Id = item.SubItems(ColumnasDetalle.Tipo_Id).Text.ToString()
                End With

                _ListaMovimiento.Add(movimientoLinea)

            Next

            With Movimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Tipo_Id = Enum_CxCMovimientoTipo.Recibo
                .Cliente_Id = cliente.Cliente_Id
                .Referencia = TxtReferencia.Text
                .Moneda = "C"
                .Monto = CDbl(TxtPago.Text) - monto
                .TipoCambio = 1
                .Dolares = 1
                .Usuario_Id = UsuarioInfo.Usuario_Id
                .AplicaMora = False
                .ListaMovimientos = _ListaMovimiento
                .MAC_Address = InfoMaquina.MAC_Address
                .GeneraAsiento = False
                .FechaRecibido = DateValue(Now)
                .FechaDocumento = DateValue(Now)
                .FechaVencimiento = DateValue(Now)
                .Caja_Id = 0
                .Cierre_Id = 0
                VerificaMensaje(Movimiento.Insert)
            End With

            Mensaje("Pago efectuado con exito.")

            inicializa()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        inicializa()
    End Sub

    Private Sub inicializa()
        TxtCodigo.Clear()
        TxtNombre.Clear()
        BtnPagar.Enabled = False
        LvwFacturas.Items.Clear()
        TxtCodigo.Select()
        TxtPago.Clear()
        TxtReferencia.Clear()
        TxtPago.ReadOnly = True
    End Sub

    Private Sub BtnPagar_Click(sender As Object, e As EventArgs) Handles BtnPagar.Click
        If ValidaTodo() Then
            EfectuaPagos()
        End If
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        BuscarCliente()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmPagoRapidoFacturas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            BtnSalir.PerformClick()
        ElseIf e.KeyCode = Keys.F1 Then
            BtnBuscar.PerformClick()
        ElseIf e.KeyCode = Keys.F3 Then
            BtnPagar.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            BtnLimpiar.PerformClick()
        End If
    End Sub

    Private Sub TxtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then

            Try

                cliente = New TCliente()
                cliente.Emp_Id = EmpresaInfo.Emp_Id
                cliente.Cliente_Id = TxtCodigo.Text

                VerificaMensaje(cliente.ListKey())
                If cliente.RowsAffected = 0 Then
                    VerificaMensaje("No existe cliente con el codigo digitado")
                End If

                EstableceDatosCliente()


            Catch ex As Exception
                MensajeError(ex.Message)
            End Try
        End If
    End Sub

    Private Sub LvwFacturas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LvwFacturas.SelectedIndexChanged
        If LvwFacturas.CheckedItems.Count > 0 Then
            TxtPago.Text = 0

            For Each item As ListViewItem In LvwFacturas.CheckedItems
                TxtPago.Text = CDbl(TxtPago.Text) + CDbl(item.SubItems(ColumnasDetalle.Saldo).Text.ToString())
            Next
        Else
            TxtPago.Text = "0.0"
        End If
    End Sub

    Private Sub LvwFacturas_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles LvwFacturas.ItemChecked
        If LvwFacturas.CheckedItems.Count > 0 Then
            TxtPago.Text = 0

            For Each item As ListViewItem In LvwFacturas.CheckedItems
                TxtPago.Text = CDbl(TxtPago.Text) + CDbl(item.SubItems(ColumnasDetalle.Saldo).Text.ToString())
            Next
        Else
            TxtPago.Text = "0.0"
        End If
    End Sub

End Class