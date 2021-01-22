Imports System.IO
Imports System.Threading
Imports Business

Public Class FrmCxCPago
    Dim Numerico() As TNumericFormat
#Region "Enums"
    Private Enum ColumnasDetalle
        TipoNombre = 0
        Mov_Id
        Tipo_Id
        Referencia
        Vence
        Monto
        Saldo
    End Enum
#End Region
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(3)

            Numerico(0) = New TNumericFormat(TxtSaldo, 7, 2, False, "0.00", "#,##0.00")
            Numerico(1) = New TNumericFormat(TxtMonto, 7, 2, False, "0.00", "#,##0.00")
            Numerico(2) = New TNumericFormat(TxtCodigo, 6, 0, False, "0", "###")
            Numerico(3) = New TNumericFormat(TxtVendedor, 6, 0, False, "0", "###")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Public Sub Execute()
        Try
            FormateaCamposNumericos()
            ConfiguraLista()


            Limpiar()

            TxtCodigo.Select()
            AsignaLogo(PcbLogo)
            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub
    Private Sub ConfiguraLista()
        Try
            With LvwMovimientos
                .Columns(ColumnasDetalle.Mov_Id).Text = "Documento"
                .Columns(ColumnasDetalle.Mov_Id).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Mov_Id).Width = 80

                .Columns(ColumnasDetalle.Tipo_Id).Text = ""
                .Columns(ColumnasDetalle.Tipo_Id).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Tipo_Id).Width = 0

                .Columns(ColumnasDetalle.TipoNombre).Text = "Tipo"
                .Columns(ColumnasDetalle.TipoNombre).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.TipoNombre).Width = 150

                .Columns(ColumnasDetalle.Referencia).Text = "Referencia"
                .Columns(ColumnasDetalle.Referencia).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Referencia).Width = 320

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
    Private Sub TxtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigo.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If IsNumeric(TxtCodigo.Text) Then
                    CargaCliente()
                End If
        End Select
    End Sub
    Private Sub BusquedaCliente()
        Dim Forma As New FrmBusquedaClienteCxC

        Try
            Forma.Execute()

            If Forma.Selecciono Then
                TxtCodigo.Text = Forma.Cliente_Id
                CargaCliente()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Sub CargaCliente()
        Dim Cliente As New TCxC_Cliente()

        Try
            Cliente.Emp_Id = EmpresaInfo.Emp_Id
            Cliente.Cliente_Id = CInt(TxtCodigo.Text.Trim)
            VerificaMensaje(Cliente.ListKey)
            If Cliente.RowsAffected = 0 Then
                VerificaMensaje("Código de cliente no válido")
            End If


            With Cliente
                TxtNombre.Text = .Nombre
                TxtSaldo.Text = .Saldo.ToString("#,##0.00")
            End With

            TxtVendedor.Text = UsuarioInfo.Vendedor_Id
            ValidaVendedor(True)

            CargaLista()

            TxtMonto.Focus()
            TxtMonto.SelectAll()


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
        End Try
    End Sub
    Private Sub CargaLista()
        Dim CxCMovimiento As New TCxC_Cliente
        Dim Items(6) As String
        Dim Item As ListViewItem = Nothing

        Try
            LvwMovimientos.Items.Clear()

            With CxCMovimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cliente_Id = TxtCodigo.Text
            End With
            VerificaMensaje(CxCMovimiento.MovimientosClienteRecibo)

            If CxCMovimiento.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron facturas")
            Else
                GpbDetalle.Enabled = True
                TxtVendedor.SelectAll()
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
                LvwMovimientos.Items.Add(Item)
            Next


            LvwMovimientos.Enabled = True
            TxtCodigo.Enabled = False
            GpbDetalle.Enabled = True
            TxtSaldo.Enabled = True
            TxtMonto.Enabled = True
            BtnPago.Enabled = True
            BtnRefrescar.Enabled = True
            BtnLimpiar.Enabled = True
            TxtMonto.SelectAll()

        Catch ex As Exception
            MensajeError(ex.Message)
            TxtCodigo.Focus()
        Finally
            CxCMovimiento = Nothing
        End Try
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Try
            Me.Dispose()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub FrmCxCPago_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Select Case Me.ActiveControl.Name
                    Case "TxtVendedor"
                        BusquedaVendedor()
                    Case "TxtCodigo"
                        BusquedaCliente()
                End Select
            Case Keys.F3
                BtnPago.PerformClick()
            Case Keys.F4
                BtnRefrescar.PerformClick()
            Case Keys.F12
                BtnLimpiar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub
    Private Sub LvwMovimientos_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles LvwMovimientos.ItemChecked
        CalculaTotales()
    End Sub
    Private Sub CalculaTotales()
        Dim Total As Double = 0.0

        Try
            TxtMonto.Text = "0.00"

            If LvwMovimientos.CheckedItems.Count = 0 Then
                Exit Sub
            End If

            For Each Item As ListViewItem In LvwMovimientos.CheckedItems
                Total += CDbl(Item.SubItems(ColumnasDetalle.Saldo).Text.Trim)
            Next

            TxtMonto.Text = Format(Total, "#,##0.00")
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub BtnRefrescar_Click(sender As Object, e As EventArgs) Handles BtnRefrescar.Click
        Try
            If TxtCodigo.Text <> "" Then
                CargaCliente()
            Else
                TxtNombre.Text = ""
                TxtSaldo.Text = ""
                LvwMovimientos.Items.Clear()
                TxtMonto.Text = ""
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function Valida() As Boolean
        Dim TotalSeleccionado As Double = 0
        Try

            If CDbl(TxtMonto.Text) <= 0 Then
                VerificaMensaje("El monto a pagar debe de ser mayor a cero")
            End If


            If LvwMovimientos.CheckedItems.Count > 0 Then

                For Each item As ListViewItem In LvwMovimientos.Items
                    If item.Checked Then
                        TotalSeleccionado += CDbl(item.SubItems(ColumnasDetalle.Saldo).Text)
                    End If

                Next

                If CDbl(TxtMonto.Text) < TotalSeleccionado Then
                    VerificaMensaje("El monto a pagar no puede ser menor que el total seleccionado")
                End If

            End If


            If Not ValidaVendedor(True) Then
                TxtVendedor.SelectAll()
                VerificaMensaje("Código de vendedor inválido")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub BtnPago_Click(sender As Object, e As EventArgs) Handles BtnPago.Click
        Try
            If Valida() Then
                Pagar()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Pagar()
        Dim AbonoEncabezado As New TCxCAbonoEncabezado(EmpresaInfo.Emp_Id)
        Dim FormaPago As New FrmPago
        Dim AbonoDetalles As New List(Of TCxCAbonoDetalle)
        Dim AbonoDetalle As TCxCAbonoDetalle = Nothing
        Dim AbonoPagos As New List(Of TCxCAbonoPago)
        Dim AbonoPago As TCxCAbonoPago = Nothing
        Dim Detalle_Id As Integer = 0
        Dim Vuelto As Double = 0
        Dim Fecha As DateTime = EmpresaInfo.Getdate()
        Dim tipoPago As String = String.Empty
        Dim Ref As String = ""
        'Dim ThdImpresion As Thread
        Try

            With AbonoEncabezado
                .Emp_Id = CajaInfo.Emp_Id
                .Suc_Id = CajaInfo.Suc_Id
                .Caja_Id = CajaInfo.Caja_Id
                .Tipo_Id = Enum_CxCAbonoTipo.Abono
                .Cierre_Id = CajaInfo.Cierre_Id
                VerificaMensaje(.SiguienteAbono(True))
                .Fecha = Fecha
                .Monto = TxtMonto.Text
                .Usuario_Id = UsuarioInfo.Usuario_Id
                .Cliente_Id = TxtCodigo.Text
                .Vendedor_Id = TxtVendedor.Text
                .VendedorNombre = TxtNombreVendedor.Text.Trim
                .Referencia = TxTReferencia.Text.Trim
            End With

            If (CDbl(TxtMonto.Text) > 0) Then

                With FormaPago
                    .TotalFactura = TxtMonto.Text
                    .Cliente_Id = CInt(TxtCodigo.Text)
                    .Execute()
                End With

                If Not FormaPago.PagoDocumento Then
                    Exit Sub
                End If
                Vuelto = FormaPago.Vuelto

                Detalle_Id = 0


                For Each Pago As TFacturaPago In FormaPago.FacturaPagos
                    If Pago.Monto <> 0 Then
                        AbonoPago = New TCxCAbonoPago(EmpresaInfo.Emp_Id)
                        Detalle_Id += 1

                        With AbonoPago
                            '.Suc_Id = CajaInfo.Suc_Id
                            '.Caja_Id = CajaInfo.Caja_Id
                            '.Cierre_Id = CajaInfo.Cierre_Id
                            '.Abono_Id = AbonoEncabezado.Abono_Id
                            '.Pago_Id = Detalle_Id
                            '.TipoPago_Id = Pago.TipoPago_Id
                            '.Monto = Pago.Monto
                            '.Dolares = Pago.Dolares
                            '.Banco_Id = Pago.Banco_Id
                            '.ChequeNumero = Pago.ChequeNumero
                            '.ChequeFecha = Pago.ChequeFecha
                            '.Tarjeta_Id = Pago.Tarjeta_Id
                            '.TarjetaNumero = Pago.TarjetaNumero
                            '.TarjetaAutorizacion = Pago.TarjetaAutorizacion
                            '.Fecha = Fecha
                            .Suc_Id = CajaInfo.Suc_Id
                            .Caja_Id = CajaInfo.Caja_Id
                            .Abono_Id = AbonoEncabezado.Abono_Id
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
                            .Fecha = Fecha
                        End With


                        If tipoPago <> "" Then
                            tipoPago = tipoPago + "," + Convert.ToString(AbonoPago.TipoPago_Id)
                        Else
                            tipoPago = Convert.ToString(AbonoPago.TipoPago_Id)
                        End If

                        AbonoPagos.Add(AbonoPago)

                    End If

                    If Pago.TipoPago_Id = Enum_TipoPago.Efectivo AndAlso Pago.Dolares > 0 Then
                        AbonoPago = New TCxCAbonoPago(EmpresaInfo.Emp_Id)
                        Detalle_Id += 1

                        With AbonoPago
                            '.Suc_Id = CajaInfo.Suc_Id
                            '.Caja_Id = CajaInfo.Caja_Id
                            '.Cierre_Id = CajaInfo.Cierre_Id
                            '.Abono_Id = AbonoEncabezado.Abono_Id
                            '.Pago_Id = Detalle_Id
                            '.TipoPago_Id = Pago.TipoPago_Id
                            '.Monto = Pago.Monto
                            '.Dolares = Pago.Dolares
                            '.Banco_Id = Pago.Banco_Id
                            '.ChequeNumero = Pago.ChequeNumero
                            '.ChequeFecha = Pago.ChequeFecha
                            '.Tarjeta_Id = Pago.Tarjeta_Id
                            '.TarjetaNumero = Pago.TarjetaNumero
                            '.TarjetaAutorizacion = Pago.TarjetaAutorizacion
                            '.Fecha = Fecha
                            .Suc_Id = CajaInfo.Suc_Id
                            .Caja_Id = CajaInfo.Caja_Id
                            '.TipoDoc_Id = TipoDoc_Id
                            .Abono_Id = AbonoEncabezado.Abono_Id
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
                            .Fecha = Fecha
                        End With

                        AbonoPagos.Add(AbonoPago)

                        tipoPago = tipoPago & IIf(tipoPago.Trim = String.Empty, "", ",") & AbonoPago.TipoPago_Id.ToString()

                    End If
                Next
                'Carga datos del detalle del abono
                Detalle_Id = 0

                For Each Fila As ListViewItem In LvwMovimientos.CheckedItems
                    AbonoDetalle = New TCxCAbonoDetalle(EmpresaInfo.Emp_Id)
                    Detalle_Id += 1

                    With AbonoDetalle
                        .Suc_Id = CajaInfo.Suc_Id
                        .Caja_Id = CajaInfo.Caja_Id
                        .Cierre_Id = CajaInfo.Cierre_Id
                        .Abono_Id = AbonoEncabezado.Abono_Id
                        .Detalle_Id = Detalle_Id
                        .Fecha = Fecha
                        .Tipo_Id = Fila.SubItems(ColumnasDetalle.Tipo_Id).Text
                        .Mov_Id = Fila.SubItems(ColumnasDetalle.Mov_Id).Text
                        .Referencia = Fila.SubItems(ColumnasDetalle.Referencia).Text + " : " + TxTReferencia.Text
                        .Monto = CDbl(Fila.SubItems(ColumnasDetalle.Saldo).Text)
                    End With
                    Ref = Ref + " " + Fila.SubItems(ColumnasDetalle.Referencia).Text

                    AbonoDetalles.Add(AbonoDetalle)
                Next

                'Agrega listas al encabezado de la factura
                With AbonoEncabezado
                    .Detalles = AbonoDetalles
                    .Pagos = AbonoPagos
                    .Referencia = Ref
                End With

                VerificaMensaje(AbonoEncabezado.GuardaAbono())
                VerificaMensaje(AbonoEncabezado.ListKey())

                ''Impresion del documento
                'ThdImpresion = New Thread(AddressOf ImprimeAbono)
                'ThdImpresion.Start(AbonoEncabezado)

                VerificaMensaje(ImprimeAbonoCxC(AbonoEncabezado))

                Mensaje("Pago realizado correctamente")
                BtnLimpiar.PerformClick()
                TxtMonto.Select()

            Else
                MensajeError("El monto debe de ser mayor a cero")
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            AbonoEncabezado = Nothing
            FormaPago = Nothing
            AbonoPago = Nothing
            AbonoPagos = Nothing
        End Try
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        Try
            Limpiar()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub Limpiar()
        Try
            LvwMovimientos.Items.Clear()
            TxtCodigo.Text = ""
            TxtNombre.Text = ""
            TxtMonto.Text = ""
            TxtSaldo.Text = ""
            TxtCodigo.Enabled = True
            TxtMonto.Enabled = False
            TxtCodigo.Select()

            TxtVendedor.Text = ""
            TxtNombreVendedor.Text = ""
            TxTReferencia.Text = ""

            LvwMovimientos.Enabled = False
            TxtCodigo.Enabled = True
            GpbDetalle.Enabled = False
            TxtSaldo.Enabled = False
            TxtMonto.Enabled = False
            BtnPago.Enabled = False
            BtnRefrescar.Enabled = False
            BtnLimpiar.Enabled = False

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BusquedaVendedor()
        Dim Forma As New FrmMuestraValores
        Try
            Forma.ObjetoTabla = New TVendedor(EmpresaInfo.Emp_Id)
            Forma.Titulo = "Vendedor"
            Forma.Execute()
            If Not Forma.Seleccion_Id Is Nothing Then
                TxtVendedor.Text = CInt(Forma.Seleccion_Id)
                ValidaVendedor(True)
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Sub TxtVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtVendedor.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If TxtVendedor.Text.Trim <> "" Then
                    ValidaVendedor(True)
                End If
        End Select
    End Sub
    Private Function ValidaVendedor(pRefrescarDatos As Boolean) As Boolean
        Dim Vendedor As New TVendedor(EmpresaInfo.Emp_Id)

        Try
            If Not IsNumeric(TxtVendedor.Text.Trim) Then
                VerificaMensaje("Debe de digitar un valor válido")
                EnfocarTexto(TxtVendedor)
            End If

            Vendedor.Vendedor_Id = TxtVendedor.Text.Trim
            VerificaMensaje(Vendedor.ListKey)

            If Vendedor.RowsAffected = 0 Then
                VerificaMensaje("Código de vendedor no válido")
                EnfocarTexto(TxtVendedor)
            End If

            If Not Vendedor.Activo Then
                VerificaMensaje("El vendedor se encuentra inactivo")
                EnfocarTexto(TxtVendedor)
            End If

            If pRefrescarDatos Then
                TxtNombreVendedor.Text = Vendedor.Nombre
            End If

            Return True
        Catch ex As Exception
            EnfocarTexto(TxtVendedor)
            If pRefrescarDatos Then
                MensajeError(ex.Message)
            End If
            Return False
        Finally
            Vendedor = Nothing
        End Try
    End Function

    Private Sub TxtVendedor_TextChanged(sender As Object, e As EventArgs) Handles TxtVendedor.TextChanged
        TxtNombreVendedor.Text = ""
    End Sub

    Private Sub TxtMonto_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMonto.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(TxtMonto.Text) AndAlso CDbl(TxtMonto.Text) > 0 Then
                BtnPago.PerformClick()
            End If
        End If
    End Sub
End Class