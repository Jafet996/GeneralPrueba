Imports Business
Public Class FrmCxCFacturaPendiente
#Region "Enum"
    Private Enum Enum_Columnas
        Empresa = 0
        Sucursal
        Caja
        TipoDoc
        Documento
        Fecha
        TipoNombre
        Factura
        Cliente
        Monto
        Mensaje
    End Enum
#End Region
#Region "Variables"
    Private _Titulo As String = "Facturas Pendientes por pasar a CxC"
#End Region

    Public Sub Execute()
        Me.Text = _Titulo
        ConfiguraLista()
        CargaLista()

        Me.ShowDialog()
    End Sub

    Private Sub ConfiguraLista()
        Try
            With LvwFacturas
                .Columns(Enum_Columnas.Empresa).Text = "Emp_Id"
                .Columns(Enum_Columnas.Empresa).Width = 0

                .Columns(Enum_Columnas.Sucursal).Text = "Suc_Id"
                .Columns(Enum_Columnas.Sucursal).Width = 0

                .Columns(Enum_Columnas.Caja).Text = "Caja_Id"
                .Columns(Enum_Columnas.Caja).Width = 0

                .Columns(Enum_Columnas.TipoDoc).Text = "TipoDoc_Id"
                .Columns(Enum_Columnas.TipoDoc).Width = 0

                .Columns(Enum_Columnas.Documento).Text = "Documento_Id"
                .Columns(Enum_Columnas.Documento).Width = 0

                .Columns(Enum_Columnas.Fecha).Text = "Fecha"
                .Columns(Enum_Columnas.Fecha).Width = 0

                .Columns(Enum_Columnas.TipoNombre).Text = "Tipo Documento"
                .Columns(Enum_Columnas.TipoNombre).Width = 105
                .Columns(Enum_Columnas.TipoNombre).TextAlign = HorizontalAlignment.Center

                .Columns(Enum_Columnas.Factura).Text = "Factura #"
                .Columns(Enum_Columnas.Factura).Width = 70
                .Columns(Enum_Columnas.Factura).TextAlign = HorizontalAlignment.Right

                .Columns(Enum_Columnas.Cliente).Text = "Cliente"
                .Columns(Enum_Columnas.Cliente).Width = 210
                .Columns(Enum_Columnas.Cliente).TextAlign = HorizontalAlignment.Left

                .Columns(Enum_Columnas.Monto).Text = "Monto"
                .Columns(Enum_Columnas.Monto).Width = 100
                .Columns(Enum_Columnas.Monto).TextAlign = HorizontalAlignment.Right

                .Columns(Enum_Columnas.Mensaje).Text = "Error"
                .Columns(Enum_Columnas.Mensaje).Width = 400
                .Columns(Enum_Columnas.Mensaje).TextAlign = HorizontalAlignment.Left
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaLista()
        Dim Movimiento As New TCxCMovimientoTmp(EmpresaInfo.Emp_Id)
        Dim Item As ListViewItem = Nothing
        Dim Items(10) As String

        Try
            LvwFacturas.Items.Clear()


            With Movimiento
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
            End With
            VerificaMensaje(Movimiento.List)

            If Movimiento.RowsAffected = 0 Then
                Exit Sub
            End If

            For Each Fila As DataRow In Movimiento.Data.Tables(0).Rows
                Items(Enum_Columnas.Empresa) = Fila("Emp_Id")
                Items(Enum_Columnas.Sucursal) = Fila("Suc_Id")
                Items(Enum_Columnas.Caja) = Fila("Caja_Id")
                Items(Enum_Columnas.TipoDoc) = Fila("TipoDoc_Id")
                Items(Enum_Columnas.Documento) = Fila("Documento_Id")
                Items(Enum_Columnas.Fecha) = Fila("Fecha")
                Items(Enum_Columnas.TipoNombre) = Fila("TipoNombre")
                Items(Enum_Columnas.Factura) = Fila("Factura_Id")
                Items(Enum_Columnas.Cliente) = Fila("Cliente")
                Items(Enum_Columnas.Monto) = Format(Fila("Monto"), "#,##0.00")
                Items(Enum_Columnas.Mensaje) = Fila("MensajeError")

                Item = New ListViewItem(Items)
                LvwFacturas.Items.Add(Item)
            Next

            If Not LvwFacturas.SelectedItems Is Nothing Then
                LvwFacturas.SelectedItems.Clear()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Movimiento = Nothing
            BtnMuestraDetalle.Enabled = LvwFacturas.Items.Count > 0
            'BtnPasaCxC.Enabled = LvwFacturas.Items.Count > 0
        End Try
    End Sub

    Private Sub ConsultaDetalleFactura()
        Dim Forma As New FrmDetalleFactura

        Try
            If LvwFacturas.SelectedItems Is Nothing OrElse LvwFacturas.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar una factura de la lista para consultar el detalle")
            End If

            With Forma
                .Titulo = "Detalle de Factura"
                .Mensaje = LvwFacturas.SelectedItems(0).SubItems(Enum_Columnas.Factura).Text
                .Caja_Id = CInt(LvwFacturas.SelectedItems(0).SubItems(Enum_Columnas.Caja).Text)
                .TipoDoc_Id = CInt(LvwFacturas.SelectedItems(0).SubItems(Enum_Columnas.TipoDoc).Text)
                .Documento_Id = CInt(LvwFacturas.SelectedItems(0).SubItems(Enum_Columnas.Documento).Text)
                .Execute()
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub



    Public Sub PasaFacturaCxC()
        Dim Movimiento As New TCxCMovimientoTmp(EmpresaInfo.Emp_Id)
        Dim FacturaEncabezado As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim CxC_Cliente = New TCxC_Cliente
        Dim Mensaje As String = ""
        Dim Item As ListViewItem = Nothing
        Dim _SDL As New SDFinancial.SDFinancial
        Dim _DTMovimiento As New SDFinancial.DTCxCMovimiento
        Dim _Resultado As New SDFinancial.TResultado
        Dim FormaCxCDevolucion As New FrmCxCDevolucion
        Dim CXCFacturaEncabezado As New SDFinancial.TFacturaEncabezado
        Dim CxCDevolucionFacturas As New List(Of SDFinancial.DTCxCMovimientoLinea)
        Dim MontoNotaAdicional As Double = 0
        Dim MontoDevolucionFacturas As Double = 0
        Dim ListaMovimientos() As SDFinancial.DTCxCMovimientoLinea
        Dim Movimiento_Id As Integer = 0
        Try


            If LvwFacturas.SelectedItems Is Nothing OrElse LvwFacturas.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un documento")
            End If


            If Not InfoMaquina Is Nothing AndAlso InfoMaquina.URLContabilidad <> "" Then
                _SDL.Url = InfoMaquina.URLContabilidad
            End If

            Item = LvwFacturas.SelectedItems(0)

            With Movimiento
                .Suc_Id = CInt(Item.SubItems(Enum_Columnas.Sucursal).Text)
                .Caja_Id = CInt(Item.SubItems(Enum_Columnas.Caja).Text)
                .TipoDoc_Id = CInt(Item.SubItems(Enum_Columnas.TipoDoc).Text)
                .Documento_Id = CLng(Item.SubItems(Enum_Columnas.Documento).Text)
            End With
            VerificaMensaje(Movimiento.ListKey)

            If Movimiento.RowsAffected = 0 Then
                CargaLista()
                VerificaMensaje("No se encontrarón datos del documento")
            End If

            With FacturaEncabezado
                .Suc_Id = Movimiento.Suc_Id
                .Caja_Id = Movimiento.Caja_Id
                .TipoDoc_Id = Movimiento.TipoDoc_Id
                .Documento_Id = Movimiento.Documento_Id
            End With
            VerificaMensaje(FacturaEncabezado.ListKey)
            If FacturaEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraró la factura")
            End If


            With CXCFacturaEncabezado
                .Emp_Id = Movimiento.Emp_Id
                .Suc_Id = Movimiento.Suc_Id
                .Caja_Id = Movimiento.Caja_Id
                .TipoDoc_Id = Movimiento.TipoDoc_Id
                .Documento_Id = Movimiento.Documento_Id
            End With


            'Verifica que el codigo del cliente sea del formato esperado
            If Not IsNumeric(FacturaEncabezado.Cliente.ClienteExterno) Then
                VerificaMensaje("El código asociado al cliente en CxC debe de ser númerico")
            End If

            Mensaje = _SDL.VerificaCliente(EmpresaParametroInfo.EmpresaExterna, FacturaEncabezado.Cliente.ClienteExterno)

            ' Valida que el cliente exista en el módulo de CxC
            If Mensaje <> "" Then
                VerificaMensaje(Mensaje)
            End If

            With CxC_Cliente
                .Emp_Id = EmpresaParametroInfo.EmpresaExterna
                .Cliente_Id = FacturaEncabezado.Cliente.ClienteExterno
            End With
            VerificaMensaje(CxC_Cliente.ListKey)

            If FacturaEncabezado.TipoDoc_Id = Enum_TipoDocumento.Credito Then
                _DTMovimiento.Tipo_Id = Enum_CxCMovimientoTipo.Factura

                With _DTMovimiento
                    .Emp_Id = EmpresaParametroInfo.Emp_Id
                    .Cliente_Id = FacturaEncabezado.Cliente.ClienteExterno
                    .Referencia = GetReferenciaCxC(FacturaEncabezado.Suc_Id, FacturaEncabezado.Caja_Id, FacturaEncabezado.TipoDoc_Id, FacturaEncabezado.Documento_Id) & IIf(FacturaEncabezado.FacturaElectronica.Consecutivo.Trim <> "", "-", "") & FacturaEncabezado.FacturaElectronica.Consecutivo
                    .FechaRecibido = FacturaEncabezado.Fecha
                    .FechaDocumento = FacturaEncabezado.Fecha
                    .FechaVencimiento = DateAdd(DateInterval.Day, CxC_Cliente.DiasCredito, FacturaEncabezado.Fecha)
                    .Moneda = IIf(FacturaEncabezado.Dolares, coMonedaDolares, coMonedaColones)
                    .Monto = Math.Abs(FacturaEncabezado.TotalCobrado)
                    .Saldo = Math.Abs(FacturaEncabezado.TotalCobrado)
                    .TipoCambio = FacturaEncabezado.TipoCambio
                    .Usuario_Id = coUsuarioGeneral
                    .AplicaMora = CxC_Cliente.AplicaMora
                    .Caja_Id = CajaInfo.Caja_Id
                    .Cierre_Id = CajaInfo.Cierre_Id
                End With
            End If

            If FacturaEncabezado.TipoDoc_Id = Enum_TipoDocumento.DevolucionCredito Then
                _DTMovimiento.Tipo_Id = Enum_CxCMovimientoTipo.NotaCredito


                VerificaMensaje(CxC_Cliente.MovimientosClienteCxCPendientePago())

                If Not CxC_Cliente.Datos Is Nothing AndAlso CxC_Cliente.Datos.Tables(0).Rows.Count > 0 Then
                    'VerificaMensaje(FacturaEncabezado.SaldoDocumentoCxC(CXCEmp_Id, CXCTipo_Id, CXCMov_Id, Monto, Saldo))


                    With FormaCxCDevolucion
                        .DocumentoMonto = 0
                        .DocumentoSaldo = 0
                        .TotalDevolucion = Math.Abs(FacturaEncabezado.TotalCobrado)
                        .CXCEmp_Id = 0
                        .CXCTipo_Id = 0
                        .CXCMov_Id = 0
                        .Cliente_Id = FacturaEncabezado.Cliente_Id
                    End With

                    '_FacturaDev.TotalCobrado = LblTotal.Text
                    '_FacturaDev.Total = LblTotal.Text

                    FormaCxCDevolucion.Execute(FacturaEncabezado)

                    If Not FormaCxCDevolucion.Guardo Then
                        VerificaMensaje("Debe de seleccionar que hacer el con el saldo a favor del cliente")
                    Else
                        CxCDevolucionFacturas = FormaCxCDevolucion.CxCDevolucionFacturas
                        MontoNotaAdicional = FormaCxCDevolucion.MontoNotaAdicional
                        MontoDevolucionFacturas = FormaCxCDevolucion.MontoDevolucionFacturas


                        ReDim ListaMovimientos(CxCDevolucionFacturas.Count - 1)


                        For Each Mov As SDFinancial.DTCxCMovimientoLinea In CxCDevolucionFacturas
                            ListaMovimientos(Movimiento_Id) = Mov
                            Movimiento_Id += 1
                        Next

                    End If
                Else
                    MontoDevolucionFacturas = FacturaEncabezado.TotalCobrado
                End If


                With _DTMovimiento
                    .Emp_Id = EmpresaParametroInfo.Emp_Id
                    .Cliente_Id = FacturaEncabezado.Cliente.ClienteExterno
                    .Referencia = GetReferenciaCxC(FacturaEncabezado.Suc_Id, FacturaEncabezado.Caja_Id, FacturaEncabezado.TipoDoc_Id, FacturaEncabezado.Documento_Id) & IIf(FacturaEncabezado.FacturaElectronica.Consecutivo.Trim <> "", "-", "") & FacturaEncabezado.FacturaElectronica.Consecutivo
                    .FechaRecibido = FacturaEncabezado.Fecha
                    .FechaDocumento = FacturaEncabezado.Fecha
                    .FechaVencimiento = DateAdd(DateInterval.Day, CxC_Cliente.DiasCredito, FacturaEncabezado.Fecha)
                    .Moneda = IIf(FacturaEncabezado.Dolares, coMonedaDolares, coMonedaColones)
                    .Monto = Math.Abs(MontoDevolucionFacturas)
                    .Saldo = Math.Abs(MontoDevolucionFacturas)
                    .TipoCambio = FacturaEncabezado.TipoCambio
                    .Usuario_Id = coUsuarioGeneral
                    .AplicaMora = CxC_Cliente.AplicaMora
                    .Caja_Id = CajaInfo.Caja_Id
                    .Cierre_Id = CajaInfo.Cierre_Id
                    .ListaMovimientos = ListaMovimientos
                    If MontoNotaAdicional > 0 Then
                        .GeneraNotaCredito = True
                        .MontoNotaCredito = MontoNotaAdicional
                    Else
                        .GeneraNotaCredito = False
                        .MontoNotaCredito = 0
                    End If
                End With

            End If

            _Resultado = _SDL.CxCMovimientoMantSD(_DTMovimiento, SDFinancial.EnumOperacionMant.Insertar, String.Empty, CXCFacturaEncabezado)
            If _Resultado.ErrorDescription <> "" Then
                VerificaMensaje(_Resultado.ErrorDescription)
            End If


            VerificaMensaje(Movimiento.Delete)


            CargaLista()

            MensajeError("El documento se pasó correctamente")

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Movimiento = Nothing
            FacturaEncabezado = Nothing
            CxC_Cliente = Nothing
            Item = Nothing
            _SDL = Nothing
            _DTMovimiento = Nothing
            _Resultado = Nothing
            FormaCxCDevolucion = Nothing
            CXCFacturaEncabezado = Nothing
            CxCDevolucionFacturas = Nothing
            ListaMovimientos = Nothing
        End Try
    End Sub




    Private Sub PasaFacturasCxC()
        Dim FacturaEncabezado As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim Forma As New FrmListaResultados

        Try
            If Not ConfirmaAccion("¿Desea pasar las facturas pendientes al módulo de CxC?") Then
                Exit Sub
            End If

            FacturaEncabezado.Suc_Id = SucursalInfo.Suc_Id
            VerificaMensaje(FacturaEncabezado.PasaFacturasPendientesCxC(PrgProgreso))

            If FacturaEncabezado.ErroresPasaCxC.Count > 0 Then
                With Forma
                    .Execute(FacturaEncabezado.ErroresPasaCxC)
                End With
            Else
                Mensaje("El proceso se completó correctamente")
            End If

            CargaLista()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnRefrescar_Click(sender As Object, e As EventArgs) Handles BtnRefrescar.Click
        CargaLista()
    End Sub

    Private Sub BtnMuestraDetalle_Click(sender As Object, e As EventArgs) Handles BtnMuestraDetalle.Click
        ConsultaDetalleFactura()
    End Sub

    Private Sub BtnPasaCxC_Click(sender As Object, e As EventArgs) Handles BtnPasaCxC.Click
        Try

            If LvwFacturas.SelectedItems Is Nothing OrElse LvwFacturas.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un documento")
            End If

            If ConfirmaAccion("Desea pasar el documento a CxC?") Then
                PasaFacturaCxC()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmCxCFacturaPendiente_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                BtnRefrescar.PerformClick()
            Case Keys.F2
                BtnMuestraDetalle.PerformClick()
            Case Keys.F3
                BtnPasaCxC.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub LvwFacturas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LvwFacturas.MouseDoubleClick
        ConsultaDetalleFactura()
    End Sub


End Class