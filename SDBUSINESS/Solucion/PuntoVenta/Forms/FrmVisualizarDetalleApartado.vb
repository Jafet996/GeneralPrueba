Imports Business

Public Class FrmVisualizarDetalleApartado
    Public Apartado As TApartadoEncabezado
    Public EsAbonoRealizado As Boolean
    Public EsAbandonado As Boolean
    Dim Numerico() As TNumericFormat
    Private Enum ColumnasDetalle

        Abono_Id = 0
        Monto = 1
        Fecha = 2

    End Enum

    Public Sub Execute()
        ConfiguraLista()
        CargaLista()
        Inicializa()
        FormateaCamposNumericos()
        EsAbonoRealizado = False
        Me.ShowDialog()
    End Sub

    Private Sub ConfiguraLista()
        Try
            With LvwAbonos
                .Columns(ColumnasDetalle.Abono_Id).Text = "#"
                .Columns(ColumnasDetalle.Abono_Id).Width = 85
                .Columns(ColumnasDetalle.Abono_Id).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasDetalle.Monto).Text = "Monto"
                .Columns(ColumnasDetalle.Monto).Width = 100
                .Columns(ColumnasDetalle.Monto).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasDetalle.Fecha).Text = "Fecha"
                .Columns(ColumnasDetalle.Fecha).Width = 100
                .Columns(ColumnasDetalle.Fecha).TextAlign = HorizontalAlignment.Center

            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaLista()
        Try

            For Each abono In Apartado.Abonos
                Dim items(2) As String
                Dim listItem As New ListViewItem(items)

                listItem.SubItems(ColumnasDetalle.Abono_Id).Text = abono.Abono_Id
                listItem.SubItems(ColumnasDetalle.Fecha).Text = abono.Fecha.ToString("dd/MM/yyyy")
                listItem.SubItems(ColumnasDetalle.Monto).Text = Format(abono.Monto, "##0.00")

                LvwAbonos.Items.Add(listItem.Clone)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try


    End Sub

    Private Sub Inicializa()
        Dim cliente As New TCliente(EmpresaInfo.Emp_Id)

        Try

            With Apartado
                TxtApartado.Text = .Apartado_Id
                Select Case .Estado_Id
                    Case Enum_ApartadoEstado.Pendiente
                        TxtEstado.Text = "Pendiente"
                    Case Enum_ApartadoEstado.Retirado
                        TxtEstado.Text = "Retirado"
                    Case Enum_ApartadoEstado.Abandonado
                        TxtEstado.Text = "Abandonado"
                    Case Enum_ApartadoEstado.Vencido
                        TxtEstado.Text = "Vencido"
                End Select
                TxtFecha.Text = .Fecha.ToString("dd/MM/yyyy")
                TxtMonto.Text = Format(.Monto, "#,##0.00")
                TxtSaldo.Text = Format(.Saldo, "#,##0.00")
                TxtVencimiento.Text = .Vencimiento.ToString("dd/MM/yyyy")
            End With

            cliente.Cliente_Id = Apartado.Cliente_Id
            VerificaMensaje(cliente.ListKey())
            TxtCliente.Text = cliente.Nombre
            TxtAbono.Text = Format(Apartado.Saldo, "#,##0.00")
            TxtAbono.Select()
            EsAbandonado = False

            If Apartado.Saldo = 0 Then
                BtnAbonar.Enabled = False
                BtnAbandonar.Enabled = False
                TxtAbono.ReadOnly = True
            ElseIf Apartado.Estado_Id = Enum_ApartadoEstado.Abandonado Then
                BtnAbonar.Enabled = False
                BtnAbandonar.Enabled = False
                TxtAbono.ReadOnly = True
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtAbono, 8, 4, False, "", "###0.0000")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnAbonar_Click(sender As Object, e As EventArgs) Handles BtnAbonar.Click
        Try

            If ValidaTodo() Then
                Abonar()
            End If

        Catch ex As Exception

            MensajeError(ex.Message)

        End Try

    End Sub

    Private Sub Abonar()
        Dim FacturaPagos As New List(Of TFacturaPago)
        Dim FacturaPago As TFacturaPago = Nothing
        Dim Detalle_Id As Integer = 0
        Dim tipoPago As String = String.Empty
        Try

            Dim FormaPago As New FrmPago()
            Dim FormaVuelto As New FrmVuelto()

            With FormaPago
                .SubTotal = CDbl(TxtAbono.Text)
                .Descuento = 0
                .ImpuestoVenta = 0
                .TotalFactura = TxtAbono.Text
                .Cliente_Id = Apartado.Cliente_Id
                .Execute()
            End With

            If Not FormaPago.PagoDocumento Then
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor



            Detalle_Id = 0
            tipoPago = String.Empty

            For Each Pago As TFacturaPago In FormaPago.FacturaPagos
                If Pago.Monto <> 0 Then
                    FacturaPago = New TFacturaPago(EmpresaInfo.Emp_Id)
                    Detalle_Id += 1

                    With FacturaPago
                        .Suc_Id = CajaInfo.Suc_Id
                        .Caja_Id = CajaInfo.Caja_Id
                        .TipoDoc_Id = 0 'TipoDoc_Id
                        .Documento_Id = Apartado.Apartado_Id  'FacturaEncabezado.Documento_Id
                        .Pago_Id = Detalle_Id
                        .TipoPago_Id = Pago.TipoPago_Id
                        .Monto = Pago.Monto
                        .Dolares = Pago.Dolares
                        .Banco_Id = Pago.Banco_Id
                        .ChequeNumero = Pago.ChequeNumero
                        .ChequeFecha = Pago.ChequeFecha
                        .Tarjeta_Id = Pago.Tarjeta_Id
                        .TarjetaNumero = Pago.TarjetaNumero
                        .TarjetaAutorizacion = Pago.TarjetaAutorizacion
                        .Fecha = Apartado.Fecha
                    End With

                    FacturaPagos.Add(FacturaPago)


                    If tipoPago <> "" Then
                        tipoPago = tipoPago + "," + Convert.ToString(FacturaPago.TipoPago_Id)
                    Else
                        tipoPago = Convert.ToString(FacturaPago.TipoPago_Id)
                    End If
                End If

                If Pago.TipoPago_Id = Enum_TipoPago.Efectivo AndAlso Pago.Dolares > 0 Then
                    FacturaPago = New TFacturaPago(EmpresaInfo.Emp_Id)
                    Detalle_Id += 1

                    With FacturaPago
                        .Suc_Id = CajaInfo.Suc_Id
                        .Caja_Id = CajaInfo.Caja_Id
                        .TipoDoc_Id = 0 'TipoDoc_Id
                        .Documento_Id = Apartado.Apartado_Id 'FacturaEncabezado.Documento_Id
                        .Pago_Id = Detalle_Id
                        .TipoPago_Id = Enum_TipoPago.Dolares
                        .Monto = Pago.Dolares
                        .Dolares = Pago.Dolares
                        .Banco_Id = Pago.Banco_Id
                        .ChequeNumero = Pago.ChequeNumero
                        .ChequeFecha = Pago.ChequeFecha
                        .Tarjeta_Id = Pago.Tarjeta_Id
                        .TarjetaNumero = Pago.TarjetaNumero
                        .TarjetaAutorizacion = Pago.TarjetaAutorizacion
                        .Fecha = Apartado.Fecha  'Fecha
                    End With

                    FacturaPagos.Add(FacturaPago)

                    tipoPago = tipoPago & IIf(tipoPago.Trim = String.Empty, "", ",") & FacturaPago.TipoPago_Id.ToString()

                End If
            Next




            VerificaMensaje(Apartado.CrearAbono(FacturaPagos, CDbl(TxtAbono.Text)))


            Apartado.ListKey()


            VerificaMensaje(ImprimeAbonoAbonoApartado(Apartado))

            FormaVuelto.Execute("Su vuelto es: ", FormaPago.Vuelto)

            LvwAbonos.Items.Clear()


            CargaLista()

            Inicializa()

            Cursor = Cursors.Default

            EsAbonoRealizado = True

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try


    End Sub

    Private Function ValidaTodo() As Boolean



        Try

            If TxtAbono.Text = "" Or TxtAbono.Text = "." Then
                VerificaMensaje("El monto digitado es incorrecto")
            ElseIf Not CDbl(TxtAbono.Text) > 0 Then
                VerificaMensaje("El abono debe ser mayor a cero")
            ElseIf Not CDbl(TxtAbono.Text) <= CDbl(TxtSaldo.Text) Then
                VerificaMensaje("El abono debe ser un monto menor o igual al saldo")
            ElseIf Not IsNumeric(TxtAbono.Text(0)) Then
                VerificaMensaje("El monto digitado es incorrecto")
            End If

            Return True

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmVisualizarDetalleApartado_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.F3
                BtnAbonar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
            Case Keys.F4
                BtnAbandonar.PerformClick()
        End Select


    End Sub


    Private Sub BtnAbandonar_Click(sender As Object, e As EventArgs) Handles BtnAbandonar.Click
        Try

            If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PVAbandonaApartado, False) Then
                VerificaMensaje("No tiene marcar el apartado como abandonado")
            End If

            If ConfirmaAccion("Desea marcar el apartado como abandonado?") Then
                AbandonoApartado()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub AbandonoApartado()
        Try

            Apartado.Estado_Id = Enum_ApartadoEstado.Abandonado

            VerificaMensaje(Apartado.Abandonar())

            Apartado.ListKey()

            Inicializa()

            EsAbonoRealizado = True
            EsAbandonado = True

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtAbono_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtAbono.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnAbonar.PerformClick()
        End If
    End Sub

    Private Sub TxtAbono_TextChanged(sender As Object, e As EventArgs) Handles TxtAbono.TextChanged

    End Sub
End Class