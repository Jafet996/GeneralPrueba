Imports Business

Public Class FrmCxCAplicaNota
    Private _Factura As TFacturaEncabezado
    Dim DTMovimientoTemp As New SDFinancial.DTCxCMovimiento()
    Private _SDL As New SDFinancial.SDFinancial
    Private _Resultado As New SDFinancial.TResultado
    Private _FacturaCxCMovimiento As FacturaCxCMovimiento
    Public _VentanaCerrada As Boolean = False
    Public _MovimientosFacturasDiferencia As New List(Of SDFinancial.DTCxCMovimientoLinea)
    Public _MovimientoFacturaOriginal As New List(Of SDFinancial.DTCxCMovimientoLinea)
    Public _TotalRestante As Double

    Private Enum ColumnasDetalle
        TipoNombre = 0
        Mov_Id
        Tipo_Id
        Referencia
        Vence
        Monto
        Saldo
    End Enum

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

    Private Sub CargaLista()
        Dim CxCMovimiento As New TCxC_Cliente
        Dim Items(6) As String
        Dim Item As ListViewItem = Nothing

        Try
            LvwMovimientos.Items.Clear()

            With CxCMovimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cliente_Id = _Factura.Cliente_Id.ToString()
            End With
            VerificaMensaje(_Factura.BusquedaFacturasCxC(_Factura.Tabla.Rows(0).Item("Mov_Id")))

            If _Factura.Data.Tables(0).Rows.Count = 0 Then
                VerificaMensaje("No se encontraron facturas")
            End If

            For Each Fila As DataRow In _Factura.Data.Tables(0).Rows
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
            BtnAceptar.Enabled = True

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CxCMovimiento = Nothing
        End Try
    End Sub

    Private Function verificaSaldoFactura()

        Return _Factura.VefiricaSaldoFacturaCxC()

    End Function

    Public Sub Execute(pFactura As TFacturaEncabezado)
        _Factura = pFactura
        _SDL.Url = InfoMaquina.URLContabilidad
        If verificaSaldoFactura() Then

            AplicarNotaCredito()
            _VentanaCerrada = True
            Me.Close()

        Else

            LblSaldoCxC.Text = _Factura.Tabla.Rows(0).Item("Saldo").ToString()
            LblMontoOriginal.Text = Math.Abs(CDbl(_Factura.TotalCobrado))
            LblDiferencia.Text = (Math.Abs(CDbl(_Factura.TotalCobrado)) - Math.Abs(CDbl(_Factura.Tabla.Rows(0).Item("Saldo").ToString())))

            ConfiguraLista()
            CargaLista()
            Me.ShowDialog()

        End If

    End Sub

    Private Function validaTodo() As Boolean

        Try
            If LvwMovimientos.CheckedItems.Count > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Function

    Private Sub AplicarMovimientosDiferencia(pSeleccionDeFacturas As Boolean)


        Dim ListaMovimiento As New SDFinancial.DTCxCMovimientoLinea
        Dim TotalAplicar As Double
        Dim TotalAplicado As Double
        Try

            TotalAplicar = CDbl(LblDiferencia.Text)
            TotalAplicado = 0


            'Divide la diferencia entre las facturas seleccionas y las agrega
            'a una lista de la facturas que se va a aplicar para ser enviada a cxc
            If pSeleccionDeFacturas Then

                For Each item As ListViewItem In LvwMovimientos.CheckedItems

                    ListaMovimiento = New SDFinancial.DTCxCMovimientoLinea()

                    With ListaMovimiento

                        .Emp_Id = EmpresaInfo.Emp_Id
                        .Tipo_Id = item.SubItems.Item(ColumnasDetalle.Tipo_Id).Text.ToString
                        .Mov_Id = item.SubItems.Item(ColumnasDetalle.Mov_Id).Text.ToString()
                        If TotalAplicar >= item.SubItems.Item(ColumnasDetalle.Monto).Text.ToString() Then
                            .Monto = item.SubItems.Item(ColumnasDetalle.Saldo).Text.ToString()
                            TotalAplicar = TotalAplicar - .Monto
                        Else
                            .Monto = TotalAplicar
                            TotalAplicar = TotalAplicar - .Monto
                        End If
                        TotalAplicado = TotalAplicado + .Monto
                    End With

                    _MovimientosFacturasDiferencia.Add(ListaMovimiento)

                Next

            End If

            'Monto que sobra del saldo devuelto, entonces para 
            'aplicar a la facturas mas antiguas
            _TotalRestante = TotalAplicar


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub AplicarNotaCredito()

        Dim TotalAplicar As Double = Math.Abs(_Factura.TotalCobrado) - CDbl(LblDiferencia.Text)
        Dim ListaMovimiento As New SDFinancial.DTCxCMovimientoLinea


        Try
            'Toma el monto que tiene la factura en CxC y lo mata con la factura original 
            'en caso de ser menor o igual
            ListaMovimiento = New SDFinancial.DTCxCMovimientoLinea()

            _FacturaCxCMovimiento = New FacturaCxCMovimiento(EmpresaInfo.Emp_Id)

            With _FacturaCxCMovimiento
                .Emp_Id = _Factura.FacturaDev.Emp_Id
                .Suc_Id = _Factura.FacturaDev.Suc_Id
                .Caja_Id = _Factura.FacturaDev.Caja_Id
                .Documento_Id = _Factura.FacturaDev.Documento_Id
                .TipoDoc_Id = _Factura.FacturaDev.TipoDoc_Id
                .ListKey()
            End With

            With ListaMovimiento
                .Emp_Id = SucursalInfo.Suc_Id
                .Tipo_Id = 1
                .Mov_Id = _FacturaCxCMovimiento.CXC_Mov_Id
                .Monto = TotalAplicar
            End With

            _MovimientoFacturaOriginal.Add(ListaMovimiento)


        Catch ex As Exception

            MensajeError(ex.Message)

        End Try

    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        AplicarNotaCredito()
        AplicarMovimientosDiferencia(validaTodo())
        _VentanaCerrada = True
        Me.Close()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub LvwMovimientos_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles LvwMovimientos.ItemChecked

        If e.Item.Checked Then
            LblTotalFacturasSeleccionadas.Text = CDbl(LblTotalFacturasSeleccionadas.Text) + CDbl(e.Item.SubItems(ColumnasDetalle.Saldo).Text.ToString())
        Else
            If CDbl(LblTotalFacturasSeleccionadas.Text) <> 0 Then
                LblTotalFacturasSeleccionadas.Text = CDbl(LblTotalFacturasSeleccionadas.Text) - CDbl(e.Item.SubItems(ColumnasDetalle.Saldo).Text.ToString())
            End If
        End If

    End Sub


End Class