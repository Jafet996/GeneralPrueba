Imports Business
Public Class FrmOrdenCompra
#Region "Declaración de variables"
    Dim InfoArticuloCompra As New TInfoAticuloCompra(EmpresaInfo.Emp_Id)
    Dim Numerico() As TNumericFormat
    Private Enum AccionEnum
        Inicial = 0
        Creando = 1
        Salvando = 2
        Modificando = 3
        Aplicado = 4
    End Enum
    Private Enum ColumnasDetalle
        Linea = 0
        Articulo = 1
        Cantidad = 2
        CantidadBonificada = 3
        Nombre = 4
        Costo = 5
        PorcDescuento = 6
        MontoDescuento = 7
        MontoIV = 8
        TotalLinea = 9
        TotalLineaBonificacion = 10
        Maximo = 11
        Minimo = 12
        FactorConversion = 13
        PromedioVenta = 14
        Exento = 15
        Suelto = 16
        CostoActual = 17
    End Enum
    Private Enum AccionDetalle
        Nuevo = 0
        Sumariza = 1
        Modifica = 2
    End Enum
#End Region
#Region "Metodos Publicos"
    Public Sub Execute()
        AsignaLogo(PicLogo)
        CargaCombos()
        Inicializa()
        Me.ShowDialog()
    End Sub
#End Region
#Region "Metodos Privados"

    Private Sub Sugerir(pDias As Integer)
        Dim OrdenCompraEncabezado As New TOrdenCompraEncabezado(EmpresaInfo.Emp_Id)
        Dim Item As ListViewItem = Nothing
        Dim Items(17) As String
        Dim Mensaje As String = ""
        Dim Detalle_Id As Integer = 0
        Dim OCImpuesto As List(Of TInfoArticuloImpuesto)
        Try

            If LvwDetalle.Items.Count > 0 Then
                If MsgBox("Al ejecutar el proceso de sugerido se perderán todos los cambios hechos en el detalle del documento, Desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Sugerido de compras") <> MsgBoxResult.Yes Then
                    Exit Sub
                End If
            End If


            With OrdenCompraEncabezado
                .Emp_Id = SucursalParametroInfo.Emp_Id
                .Suc_Id = SucursalParametroInfo.Suc_Id
                .Bod_Id = SucursalParametroInfo.BodCompra_Id
                .Prov_Id = CInt(TxtProveedor.Text)
            End With

            Mensaje = OrdenCompraEncabezado.SugerirCompra(pDias)
            VerificaMensaje(Mensaje)


            If OrdenCompraEncabezado.Data Is Nothing OrElse OrdenCompraEncabezado.Data.Tables Is Nothing OrElse OrdenCompraEncabezado.Data.Tables.Count = 0 OrElse OrdenCompraEncabezado.Data.Tables(0).Rows.Count = 0 Then
                VerificaMensaje("No se articulos asociados al proveedor")
            End If


            'Detalle
            TxtArticulo.Text = ""
            InicializaArticulo()
            LvwDetalle.Items.Clear()

            LblSubTotal.Text = "0.00"
            LblDescuento.Text = "0.00"
            LblImpuestoVenta.Text = "0.00"
            LblTotalCosto.Text = "0.00"
            LblTotalBonificacion.Text = "0.00"

            For Each Fila As DataRow In OrdenCompraEncabezado.Data.Tables(0).Rows

                OCImpuesto = New List(Of TInfoArticuloImpuesto)
                If Not Fila("ExentoIV") Then
                    For Each impuesto As DataRow In OrdenCompraEncabezado.Data.Tables(1).Rows
                        If Fila("Art_Id") = impuesto("Art_Id") Then
                            OCImpuesto.Add(New TInfoArticuloImpuesto() With
                                       {.Codigo_Id = impuesto("Codigo_Id"),
                                        .Tarifa_Id = impuesto("Tarifa_Id"),
                                        .Porcentaje = impuesto("Porcentaje")})
                        End If
                    Next
                End If

                Item = New ListViewItem(Items)
                Detalle_Id = Detalle_Id + 1
                With Item
                    .SubItems(ColumnasDetalle.Linea).Text = Detalle_Id
                    .SubItems(ColumnasDetalle.Articulo).Text = Fila("Art_Id")
                    .SubItems(ColumnasDetalle.Cantidad).Text = Format(Fila("Cantidad"), "##0.00")
                    .SubItems(ColumnasDetalle.CantidadBonificada).Text = Format(0, "##0.00")
                    .SubItems(ColumnasDetalle.Nombre).Text = Fila("Nombre")
                    .SubItems(ColumnasDetalle.Costo).Text = Format(Fila("Costo"), "##0.0000")
                    .SubItems(ColumnasDetalle.PorcDescuento).Text = Format(0, "##0.0000")
                    .SubItems(ColumnasDetalle.MontoDescuento).Text = Format(0, "##0.0000")
                    If Fila("ExentoIV") = 0 Then
                        .SubItems(ColumnasDetalle.MontoIV).Text = Format(CalculaMontoImpuesto((CDbl(.SubItems(ColumnasDetalle.Costo).Text) - CDbl(.SubItems(ColumnasDetalle.MontoDescuento).Text)), OCImpuesto), "##0.0000")
                        '.SubItems(ColumnasDetalle.MontoIV).Text = Format((CDbl(.SubItems(ColumnasDetalle.Costo).Text) - CDbl(.SubItems(ColumnasDetalle.MontoDescuento).Text)) * (EmpresaParametroInfo.PorcIV / 100), "##0.0000")
                    Else
                        .SubItems(ColumnasDetalle.MontoIV).Text = Format(0, "##0.0000")
                    End If
                    .SubItems(ColumnasDetalle.TotalLinea).Text = Format(((CDbl(.SubItems(ColumnasDetalle.Costo).Text) - CDbl(.SubItems(ColumnasDetalle.MontoDescuento).Text)) + CDbl(.SubItems(ColumnasDetalle.MontoIV).Text)) * CDbl(.SubItems(ColumnasDetalle.Cantidad).Text), "##0.0000")
                    .SubItems(ColumnasDetalle.TotalLineaBonificacion).Text = Format(0, "##0.0000")
                    .SubItems(ColumnasDetalle.Maximo).Text = Format(Fila("Maximo"), "##0.00")
                    .SubItems(ColumnasDetalle.Minimo).Text = Format(Fila("Minimo"), "##0.00")
                    .SubItems(ColumnasDetalle.FactorConversion).Text = Format(Fila("FactorConversion"), "##0.00")
                    .SubItems(ColumnasDetalle.PromedioVenta).Text = Format(Fila("PromedioVenta"), "##0.00")
                    .SubItems(ColumnasDetalle.Exento).Text = IIf(Fila("ExentoIV"), -1, 0)
                    .SubItems(ColumnasDetalle.Suelto).Text = IIf(Fila("Suelto"), -1, 0)
                End With

                Item.Tag = OCImpuesto
                LvwDetalle.Items.Add(Item)
                Item.EnsureVisible()
            Next

            ''Habilita o desabilita campos
            'Select Case OrdenCompraEncabezado.OrdenEstado_Id
            '    Case OrdenCompraEstadoEnum.Aplicada, OrdenCompraEstadoEnum.Cerrada
            '        TxtProveedor.Enabled = False
            '        TxtProveedorNombre.Enabled = False
            '        TxtComentario.Enabled = False
            '        PnLineaDetalle.Enabled = False
            '        HabilitaBotones(AccionEnum.Aplicado)
            '    Case OrdenCompraEstadoEnum.Pendiente
            '        TxtProveedor.Enabled = (LvwDetalle.Items.Count = 0)
            '        TxtProveedorNombre.Enabled = (LvwDetalle.Items.Count = 0)
            '        TxtComentario.Enabled = True
            '        PnLineaDetalle.Enabled = True
            '        HabilitaBotones(AccionEnum.Modificando)
            '        TxtArticulo.Focus()
            'End Select

            MuestraTotales()

            TxtProveedor.Enabled = False
            TxtProveedorNombre.Enabled = False

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            OrdenCompraEncabezado = Nothing
        End Try
    End Sub

    Private Sub Nuevo()
        Try


            TxtNumero.Enabled = False

            TxtProveedor.Enabled = True
            TxtProveedorNombre.Enabled = True
            TxtComentario.Enabled = True

            HabilitaBotones(AccionEnum.Creando)

            'Encabezado
            PnEncabezado.Enabled = True
            TxtNumero.Text = ""
            LblEstado.Text = "Nuevo"
            DtpFecha.Value = EmpresaInfo.Getdate
            TxtProveedor.Text = ""
            TxtProveedorNombre.Text = ""
            TxtComentario.Text = ""
            TxtProveedor.Focus()

            'Detalle
            PnLineaDetalle.Enabled = True
            TxtArticulo.Text = ""
            InicializaArticulo()
            LvwDetalle.Items.Clear()

            LblSubTotal.Text = "0.00"
            LblDescuento.Text = "0.00"
            LblImpuestoVenta.Text = "0.00"
            LblTotalCosto.Text = "0.00"
            LblTotalBonificacion.Text = "0.00"


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(5)

            Numerico(0) = New TNumericFormat(TxtNumero, 8, 0, False, "", "###0")
            Numerico(1) = New TNumericFormat(TxtCosto, 6, 2, False, "", "###0.00")
            Numerico(2) = New TNumericFormat(TxtCantidad, 6, 2, False, "", "###0.00")
            Numerico(3) = New TNumericFormat(TxtProveedor, 4, 0, False, "", "###0")
            Numerico(4) = New TNumericFormat(TxtPorcDesc, 3, 2, False, "", "###0.00")
            Numerico(5) = New TNumericFormat(TxtBonificacion, 6, 2, False, "", "###0.00")


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ConfiguraStatusBar()
        TSSNombreEmpresa.Text = EmpresaInfo.Nombre
        TSSNombreSucursal.Text = SucursalInfo.Nombre
    End Sub

    Private Sub ConfiguraDetalle()
        Try
            With LvwDetalle
                .Columns(ColumnasDetalle.Linea).Text = "Línea"
                .Columns(ColumnasDetalle.Linea).Width = 50

                .Columns(ColumnasDetalle.Articulo).Text = "Código"
                .Columns(ColumnasDetalle.Articulo).Width = 100

                .Columns(ColumnasDetalle.Cantidad).Text = "Cantidad"
                .Columns(ColumnasDetalle.Cantidad).Width = 80
                .Columns(ColumnasDetalle.Cantidad).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.CantidadBonificada).Text = "Bonificación"
                .Columns(ColumnasDetalle.CantidadBonificada).Width = 80
                .Columns(ColumnasDetalle.CantidadBonificada).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.Nombre).Text = "Descripción"
                .Columns(ColumnasDetalle.Nombre).Width = 355

                .Columns(ColumnasDetalle.Costo).Text = "Costo"
                .Columns(ColumnasDetalle.Costo).Width = 80
                .Columns(ColumnasDetalle.Costo).TextAlign = HorizontalAlignment.Right


                .Columns(ColumnasDetalle.PorcDescuento).Text = "% Desc"
                .Columns(ColumnasDetalle.PorcDescuento).Width = 70
                .Columns(ColumnasDetalle.PorcDescuento).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.MontoDescuento).Text = "Descuento"
                .Columns(ColumnasDetalle.MontoDescuento).Width = 90
                .Columns(ColumnasDetalle.MontoDescuento).TextAlign = HorizontalAlignment.Right


                .Columns(ColumnasDetalle.MontoIV).Text = "MontoIV"
                .Columns(ColumnasDetalle.MontoIV).Width = 90
                .Columns(ColumnasDetalle.MontoIV).TextAlign = HorizontalAlignment.Right


                .Columns(ColumnasDetalle.TotalLinea).Text = "Total Línea"
                .Columns(ColumnasDetalle.TotalLinea).Width = 100
                .Columns(ColumnasDetalle.TotalLinea).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.TotalLineaBonificacion).Text = "Total Bonif."
                .Columns(ColumnasDetalle.TotalLineaBonificacion).Width = 100
                .Columns(ColumnasDetalle.TotalLineaBonificacion).TextAlign = HorizontalAlignment.Right

                '----------------------------------------------------------------------------
                .Columns(ColumnasDetalle.Suelto).Text = "Suelto"
                .Columns(ColumnasDetalle.Suelto).Width = 0
                .Columns(ColumnasDetalle.Suelto).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.Minimo).Text = "Minimo"
                .Columns(ColumnasDetalle.Minimo).Width = 0
                .Columns(ColumnasDetalle.Minimo).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.Maximo).Text = "Maximo"
                .Columns(ColumnasDetalle.Maximo).Width = 0
                .Columns(ColumnasDetalle.Maximo).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.FactorConversion).Text = "Factor C"
                .Columns(ColumnasDetalle.FactorConversion).Width = 0
                .Columns(ColumnasDetalle.FactorConversion).TextAlign = HorizontalAlignment.Right


                .Columns(ColumnasDetalle.PromedioVenta).Text = "Prom Venta"
                .Columns(ColumnasDetalle.PromedioVenta).Width = 0
                .Columns(ColumnasDetalle.PromedioVenta).TextAlign = HorizontalAlignment.Right


                .Columns(ColumnasDetalle.Exento).Text = "Exento"
                .Columns(ColumnasDetalle.Exento).Width = 0
                .Columns(ColumnasDetalle.Exento).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.CostoActual).Text = "Costo Actual"
                .Columns(ColumnasDetalle.CostoActual).Width = 0

            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaCombos()
        Dim Mensaje As String = ""
        Try






        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            '
        End Try
    End Sub

    Private Sub HabilitaBotones(pAccion As AccionEnum)

        Select Case pAccion
            Case AccionEnum.Inicial
                BtnBuscar.Enabled = True
                BtnNuevo.Enabled = True
                BtnModificar.Enabled = False
                BtnAplicar.Enabled = False
                BtnEliminar.Enabled = False
                BtnCancelar.Enabled = False
                BtnImprimir.Enabled = False
                BtnSalir.Enabled = True
                BtnSugerir.Enabled = False
            Case AccionEnum.Creando
                BtnBuscar.Enabled = True
                BtnNuevo.Enabled = False
                BtnModificar.Enabled = True
                BtnAplicar.Enabled = False
                BtnEliminar.Enabled = False
                BtnCancelar.Enabled = True
                BtnImprimir.Enabled = False
                BtnSalir.Enabled = True
                BtnSugerir.Enabled = True
            Case AccionEnum.Salvando
                BtnBuscar.Enabled = False
                BtnNuevo.Enabled = False
                BtnModificar.Enabled = False
                BtnAplicar.Enabled = False
                BtnEliminar.Enabled = False
                BtnCancelar.Enabled = False
                BtnImprimir.Enabled = False
                BtnSalir.Enabled = False
                BtnSugerir.Enabled = False
            Case AccionEnum.Modificando
                BtnBuscar.Enabled = True
                BtnNuevo.Enabled = False
                BtnModificar.Enabled = True
                BtnAplicar.Enabled = True
                BtnEliminar.Enabled = True
                BtnCancelar.Enabled = True
                BtnImprimir.Enabled = False
                BtnSalir.Enabled = False
                BtnSugerir.Enabled = True
            Case AccionEnum.Aplicado
                BtnBuscar.Enabled = False
                BtnNuevo.Enabled = False
                BtnModificar.Enabled = False
                BtnAplicar.Enabled = False
                BtnEliminar.Enabled = False
                BtnCancelar.Enabled = True
                BtnImprimir.Enabled = True
                BtnSalir.Enabled = True
                BtnSugerir.Enabled = False
        End Select

    End Sub

    Private Sub Inicializa()
        Try

            HabilitaBotones(AccionEnum.Inicial)

            'Limpia variables globales

            'Encabezado
            TxtNumero.Enabled = True
            TxtNumero.Text = ""

            LblEstado.Text = ""
            DtpFecha.Value = EmpresaInfo.Getdate
            TxtProveedor.Enabled = False
            TxtProveedorNombre.Enabled = False
            TxtComentario.Enabled = False

            TxtProveedor.Text = ""
            TxtProveedorNombre.Text = ""
            TxtComentario.Text = ""


            'Detalle
            PnLineaDetalle.Enabled = False


            TxtArticulo.Text = ""
            InicializaArticulo()
            LvwDetalle.Items.Clear()
            LblSubTotal.Text = "0.00"
            LblDescuento.Text = "0.00"
            LblImpuestoVenta.Text = "0.00"
            LblTotalCosto.Text = "0.00"
            LblTotalBonificacion.Text = "0.00"


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ActivarEdicionArticulo(pActivar)
        TxtArticulo.Enabled = (Not pActivar)
        TxtArticuloNombre.Enabled = pActivar
        TxtUnidadMedida.Enabled = pActivar

        TxtFactorConversion.Enabled = pActivar
        TxtTransito.Enabled = pActivar
        TxtMaximo.Enabled = pActivar
        TxtCostoActual.Enabled = pActivar

        TxtSaldo.Enabled = pActivar
        TxtCosto.Enabled = pActivar
        TxtPorcDesc.Enabled = pActivar
        TxtCantidad.Enabled = pActivar
        TxtBonificacion.Enabled = pActivar
    End Sub

    Private Function ValidaArticuloProveedor(pProv_Id As Integer, pArt_Id As String) As String
        Dim ArticuloProveedor As New TArticuloProveedor(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            With ArticuloProveedor
                .Prov_Id = pProv_Id
                .Art_Id = pArt_Id
            End With
            Mensaje = ArticuloProveedor.ListKey()
            VerificaMensaje(Mensaje)

            If ArticuloProveedor.RowsAffected = 0 Then
                If MsgBox("El artículo seleccionado no se encuentra asociado a este proveedor, Desea asociarlo ahora?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                    Mensaje = ArticuloProveedor.Insert()
                    VerificaMensaje(Mensaje)
                Else
                    VerificaMensaje("No se puede ingresar el artículo debido a que este no pertenece al proveedor seleccionado")
                End If
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            ArticuloProveedor = Nothing
        End Try
    End Function

    Private Function ValidaArticulo(pArt_Id As String, pModificando As Boolean) As Boolean
        Dim Mensaje As String = ""
        Try

            If TxtProveedor.Text.Trim = "" OrElse Not IsNumeric(TxtProveedor.Text) Then
                TxtProveedor.Focus()
                VerificaMensaje("Debe de ingresar el código de proveedor")
                Return False
            End If

            If Not ValidaProveedor() Then
                TxtProveedor.Focus()
                VerificaMensaje("Debe de ingresar el código de proveedor")
                Return False
            End If

            With InfoArticuloCompra
                .LimpiaArticulo()
                .Emp_Id = SucursalParametroInfo.Emp_Id
                .Suc_Id = SucursalParametroInfo.Suc_Id
                .Bod_Id = SucursalParametroInfo.BodCompra_Id
                .Art_Id = TxtArticulo.Text.Trim
            End With

            Mensaje = InfoArticuloCompra.ConsultaArticulo
            VerificaMensaje(Mensaje)

            'If InfoArticuloCompra.ExentoIV = 0 Then
            '    InfoArticulo.Art_Id = TxtArticulo.Text.Trim
            '    Mensaje = InfoArticulo.ConsultaArticuloImpuestosOC
            '    VerificaMensaje(Mensaje)
            'End If

            If InfoArticuloCompra.RowsAffected = 0 Then
                VerificaMensaje("Artículo inválido, no se encontraron datos")
            End If

            If InfoArticuloCompra.Suelto Then
                VerificaMensaje("Artículo inválido, no se pueden hacer pedidos de articulos sueltos")
            End If

            If InfoArticuloCompra.Servicio Then
                VerificaMensaje("Artículo inválido, no se pueden hacer pedidos de codigos de servicio")
            End If

            Mensaje = ValidaArticuloProveedor(CInt(TxtProveedor.Text), InfoArticuloCompra.Art_Id)
            VerificaMensaje(Mensaje)


            TxtArticuloNombre.Text = InfoArticuloCompra.NombreArticulo
            TxtUnidadMedida.Text = InfoArticuloCompra.NombreUnidad


            TxtFactorConversion.Text = Format(InfoArticuloCompra.FactorConversion, "###0")
            TxtTransito.Text = Format(InfoArticuloCompra.Transito, "###0.00")
            TxtMaximo.Text = Format(InfoArticuloCompra.Maximo, "###0.00")


            TxtSaldo.Text = Format(InfoArticuloCompra.Saldo, "###0.00")
            TxtCosto.Text = Format(InfoArticuloCompra.Costo, "###0.00")
            TxtCostoActual.Text = Format(InfoArticuloCompra.Costo, "###0.00")

            TxtPorcDesc.Text = "0.00"
            TxtCantidad.Text = "1.00"
            TxtBonificacion.Text = "0.00"

            ActivarEdicionArticulo(True)

            TxtCosto.Focus()

            Return True
        Catch ex As Exception
            InfoArticuloCompra.LimpiaArticulo()
            MensajeError(ex.Message)
            TxtArticulo.SelectAll()
            TxtArticulo.Focus()
            Return False
        End Try
    End Function

    Private Function ValidaCosto() As Boolean
        Try
            If Not IsNumeric(TxtCosto.Text) Then
                TxtCosto.SelectAll()
                TxtCosto.Focus()
                VerificaMensaje("Debe de ingresar una cantidad válida")
            End If

            If CDbl(TxtCosto.Text) < 0 Then
                TxtCosto.SelectAll()
                TxtCosto.Focus()
                VerificaMensaje("La cantidad debe de ser mayor o igual a cero")
            End If

            Return True

        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Function ValidaDescuento() As Boolean
        Try
            If Not IsNumeric(TxtPorcDesc.Text) Then
                VerificaMensaje("Debe de ingresar una cantidad válida")
            End If

            If CDbl(TxtPorcDesc.Text) < 0 Then
                VerificaMensaje("La cantidad debe de ser mayor o igual a cero")
            End If


            If CDbl(TxtPorcDesc.Text) > 100 Then
                VerificaMensaje("El descuento no puede ser mayor al 100%")
            End If

            Return True

        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Function ValidaBonificacion() As Boolean
        Try
            If Not IsNumeric(TxtBonificacion.Text) OrElse CDbl(TxtBonificacion.Text) < 0 Then
                TxtBonificacion.SelectAll()
                TxtBonificacion.Focus()
                VerificaMensaje("La bonificación debe de ser mayor o igual a cero")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Function ValidaCantidad() As Boolean
        Try
            If Not IsNumeric(TxtCantidad.Text) OrElse CDbl(TxtCantidad.Text) <= 0 Then
                TxtCantidad.SelectAll()
                TxtCantidad.Focus()
                VerificaMensaje("La cantidad debe de ser mayor a cero")
            End If

            If CDbl(TxtCantidad.Text) >= 500 Then
                If MsgBox("Usted desea ingresar " & TxtCantidad.Text & " unidades de este producto?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) <> MsgBoxResult.Yes Then
                    TxtCantidad.SelectAll()
                    TxtCantidad.Focus()
                    VerificaMensaje("Ingrese correctamente la cantidad")
                End If
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub InicializaArticulo()
        ActivarEdicionArticulo(False)
        LvwDetalle.Tag = Nothing
        InfoArticuloCompra.LimpiaArticulo()
        TxtArticuloNombre.Text = ""
        TxtUnidadMedida.Text = ""

        TxtFactorConversion.Text = ""
        TxtTransito.Text = ""
        TxtMaximo.Text = ""
        TxtCostoActual.Text = ""

        TxtSaldo.Text = ""
        TxtCosto.Text = ""
        TxtPorcDesc.Text = ""
        TxtCantidad.Text = ""
        TxtBonificacion.Text = ""
    End Sub

    Private Function BuscaItemArticulo(pArt_Id As String) As ListViewItem
        Dim Item As ListViewItem = Nothing
        Try
            For Each Linea As ListViewItem In LvwDetalle.Items
                If Linea.SubItems(ColumnasDetalle.Articulo).Text = pArt_Id Then
                    Item = Linea
                End If
            Next

            Return Item
        Catch ex As Exception
            MensajeError(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub IngresaArticulo()
        Dim Item As ListViewItem
        Dim Items(17) As String
        Dim Linea_Id As Integer = 0
        Dim Accion As AccionDetalle = AccionDetalle.Nuevo
        Dim ArticuloImpuestos As New List(Of TInfoArticuloImpuesto)
        Try

            If Not LvwDetalle.Tag Is Nothing Then
                'Modificando
                Item = LvwDetalle.Tag
                Linea_Id = CInt(Item.SubItems(ColumnasDetalle.Linea).Text)
                Accion = AccionDetalle.Modifica
            Else
                'Verifica si ya esta en la linea de detale
                Item = BuscaItemArticulo(InfoArticuloCompra.Art_Id)
                If Item Is Nothing Then
                    'Crea una nueva linea del detalle
                    Item = New ListViewItem(Items)
                    Linea_Id = LvwDetalle.Items.Count + 1
                    Accion = AccionDetalle.Nuevo
                Else
                    Linea_Id = CInt(Item.SubItems(ColumnasDetalle.Linea).Text)
                    Accion = AccionDetalle.Sumariza
                End If
            End If

            With Item
                .SubItems(ColumnasDetalle.Linea).Text = Linea_Id
                .SubItems(ColumnasDetalle.Articulo).Text = InfoArticuloCompra.Art_Id
                If Accion = AccionDetalle.Sumariza Then
                    .SubItems(ColumnasDetalle.Cantidad).Text = Format(CDbl(.SubItems(ColumnasDetalle.Cantidad).Text) + CDbl(TxtCantidad.Text), "##0.00")
                    .SubItems(ColumnasDetalle.CantidadBonificada).Text = Format(CDbl(.SubItems(ColumnasDetalle.CantidadBonificada).Text) + CDbl(TxtBonificacion.Text), "##0.00")
                Else
                    .SubItems(ColumnasDetalle.Cantidad).Text = Format(CDbl(TxtCantidad.Text), "##0.00")
                    .SubItems(ColumnasDetalle.CantidadBonificada).Text = Format(CDbl(TxtBonificacion.Text), "##0.00")
                End If
                .SubItems(ColumnasDetalle.Nombre).Text = InfoArticuloCompra.NombreArticulo
                .SubItems(ColumnasDetalle.Costo).Text = Format(CDbl(TxtCosto.Text), "##0.0000")
                .SubItems(ColumnasDetalle.PorcDescuento).Text = Format(CDbl(TxtPorcDesc.Text), "##0.0000")
                .SubItems(ColumnasDetalle.MontoDescuento).Text = Format(CDbl(.SubItems(ColumnasDetalle.Costo).Text) * (CDbl(.SubItems(ColumnasDetalle.PorcDescuento).Text) / 100), "##0.0000")
                If InfoArticuloCompra.ExentoIV Then
                    .SubItems(ColumnasDetalle.MontoIV).Text = "0.00"
                Else
                    .SubItems(ColumnasDetalle.MontoIV).Text = Format(CalculaMontoImpuesto((CDbl(.SubItems(ColumnasDetalle.Costo).Text) - CDbl(.SubItems(ColumnasDetalle.MontoDescuento).Text)), InfoArticuloCompra.ArticuloImpuestos), "##0.0000")
                End If
                .SubItems(ColumnasDetalle.TotalLinea).Text = Format(((CDbl(.SubItems(ColumnasDetalle.Costo).Text) - CDbl(.SubItems(ColumnasDetalle.MontoDescuento).Text)) + CDbl(.SubItems(ColumnasDetalle.MontoIV).Text)) * CDbl(.SubItems(ColumnasDetalle.Cantidad).Text), "##0.0000")
                .SubItems(ColumnasDetalle.TotalLineaBonificacion).Text = Format(CDbl(.SubItems(ColumnasDetalle.Costo).Text) * CDbl(.SubItems(ColumnasDetalle.CantidadBonificada).Text), "##0.0000")

                .SubItems(ColumnasDetalle.Maximo).Text = Format(CDbl(InfoArticuloCompra.Maximo), "##0.00")
                .SubItems(ColumnasDetalle.Minimo).Text = Format(CDbl(InfoArticuloCompra.Minimo), "##0.00")
                .SubItems(ColumnasDetalle.FactorConversion).Text = Format(CDbl(InfoArticuloCompra.FactorConversion), "##0.00")
                .SubItems(ColumnasDetalle.PromedioVenta).Text = Format(CDbl(InfoArticuloCompra.PromedioVenta), "##0.00")

                .SubItems(ColumnasDetalle.Exento).Text = InfoArticuloCompra.ExentoIV
                .SubItems(ColumnasDetalle.Suelto).Text = InfoArticuloCompra.Suelto
                .SubItems(ColumnasDetalle.CostoActual).Text = InfoArticuloCompra.Costo
            End With

            For Each impuesto As TInfoArticuloImpuesto In InfoArticuloCompra.ArticuloImpuestos
                ArticuloImpuestos.Add(New TInfoArticuloImpuesto() With
                          {.Codigo_Id = impuesto.Codigo_Id,
                           .Tarifa_Id = impuesto.Tarifa_Id,
                           .Porcentaje = impuesto.Porcentaje,
                           .Monto = impuesto.Monto})
            Next

            Item.Tag = ArticuloImpuestos

            If Accion = AccionDetalle.Nuevo Then
                LvwDetalle.Items.Add(Item)
            End If
            Item.EnsureVisible()
            'Marca la ultima linea modificada o ingresada
            LvwDetalle.SelectedItems.Clear()
            Item.Selected = True

            TxtArticulo.Text = ""
            InicializaArticulo()
            If Accion = AccionDetalle.Modifica Then
                LvwDetalle.Focus()
            Else
                TxtArticulo.Focus()
            End If

            MuestraTotales()

            TxtProveedor.Enabled = False
            TxtProveedorNombre.Enabled = False

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub EliminaLinea()
        Try
            If Not TxtArticulo.Enabled OrElse LvwDetalle.Items.Count = 0 OrElse Not PnLineaDetalle.Enabled OrElse LvwDetalle.SelectedItems.Count = 0 Then
                Exit Sub
            End If

            If MsgBox("Desea eliminar la línea del detalle", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar líneas") <> MsgBoxResult.Yes Then
                Exit Sub
            End If


            InicializaArticulo()
            LvwDetalle.Tag = Nothing

            LvwDetalle.Items.Remove(LvwDetalle.SelectedItems(0))


            MuestraTotales()

            TxtProveedor.Enabled = (LvwDetalle.Items.Count = 0)
            TxtProveedorNombre.Enabled = (LvwDetalle.Items.Count = 0)


            TxtArticulo.Focus()


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ModificaLinea()
        Try

            If Not TxtArticulo.Enabled OrElse LvwDetalle.Items.Count = 0 OrElse Not PnLineaDetalle.Enabled OrElse LvwDetalle.SelectedItems.Count = 0 Then
                Exit Sub
            End If

            InicializaArticulo()

            TxtArticulo.Text = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Articulo).Text
            ValidaArticulo(TxtArticulo.Text, True)

            TxtCosto.Text = Format(CDbl(LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Costo).Text), "###0.00")
            TxtPorcDesc.Text = Format(CDbl(LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.PorcDescuento).Text), "###0.00")
            TxtCantidad.Text = Format(CDbl(LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Cantidad).Text), "###0.00")
            TxtBonificacion.Text = Format(CDbl(LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.CantidadBonificada).Text), "###0.00")

            TxtCantidad.SelectAll()

            LvwDetalle.Tag = LvwDetalle.SelectedItems(0)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CalculaTotales(ByRef pSubTotal As Double, ByRef pDescuento As Double, ByRef pImpuestoVenta As Double, ByRef pTotalCosto As Double, ByRef pTotalBonificacion As Double)
        Try
            pSubTotal = 0
            pDescuento = 0
            pImpuestoVenta = 0
            pTotalCosto = 0
            pTotalBonificacion = 0

            For Each Fila As ListViewItem In LvwDetalle.Items
                pSubTotal = pSubTotal + (CDbl(Fila.SubItems(ColumnasDetalle.Costo).Text) * CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text))
                pDescuento = pDescuento + (CDbl(Fila.SubItems(ColumnasDetalle.MontoDescuento).Text) * CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text))
                pImpuestoVenta = pImpuestoVenta + (CDbl(Fila.SubItems(ColumnasDetalle.MontoIV).Text) * CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text))
                pTotalCosto = pTotalCosto + CDbl(Fila.SubItems(ColumnasDetalle.TotalLinea).Text)
                pTotalBonificacion = pTotalBonificacion + CDbl(Fila.SubItems(ColumnasDetalle.TotalLineaBonificacion).Text)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub MuestraTotales()
        Dim SubTotal As Double = 0
        Dim Descuento As Double = 0
        Dim ImpuestoVenta As Double = 0
        Dim TotalCosto As Double = 0
        Dim TotalBonificacion As Double = 0
        Try

            LblSubTotal.Text = "0.00"
            LblDescuento.Text = "0.00"
            LblImpuestoVenta.Text = "0.00"
            LblTotalCosto.Text = "0.00"
            LblTotalBonificacion.Text = "0.00"

            CalculaTotales(SubTotal, Descuento, ImpuestoVenta, TotalCosto, TotalBonificacion)

            LblSubTotal.Text = Format(SubTotal, "#,##0.00")
            LblDescuento.Text = Format(Descuento, "#,##0.00")
            LblImpuestoVenta.Text = Format(ImpuestoVenta, "#,##0.00")
            LblTotalCosto.Text = Format(TotalCosto, "#,##0.00")
            LblTotalBonificacion.Text = Format(TotalBonificacion, "#,##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub GuardarDocumento(pAplicar As Boolean, pAplicaUsuario_Id As String)
        Dim OrdenCompraEncabezado As New TOrdenCompraEncabezado(EmpresaParametroInfo.Emp_Id)
        Dim OrdenCompraDetalle As TOrdenCompraDetalle = Nothing
        Dim Mensaje As String = ""

        Dim SubTotal As Double = 0
        Dim Descuento As Double = 0
        Dim MontoIV As Double = 0
        Dim TotalCosto As Double = 0
        Dim TotalBonificacion As Double = 0

        Dim Detalle_Id As Integer = 0
        Dim Nuevo As Boolean = False
        Try

            CalculaTotales(SubTotal, Descuento, MontoIV, TotalCosto, TotalBonificacion)

            With OrdenCompraEncabezado
                .Emp_Id = SucursalParametroInfo.Emp_Id
                .Suc_Id = SucursalParametroInfo.Suc_Id
                If TxtNumero.Text <> "" Then
                    .Orden_Id = CLng(TxtNumero.Text)
                Else
                    Nuevo = True
                    .Orden_Id = 0
                End If
                .Prov_Id = CInt(TxtProveedor.Text)
                .Bod_Id = SucursalParametroInfo.BodCompra_Id
                .OrdenEstado_Id = OrdenCompraEstadoEnum.Pendiente
                .Fecha = EmpresaInfo.Getdate()
                .Comentario = TxtComentario.Text.Trim
                .SubTotal = SubTotal
                .Descuento = Descuento
                .IV = MontoIV
                .Total = TotalCosto
                .TotalBonificacion = TotalBonificacion
                .Usuario_Id = UsuarioInfo.Usuario_Id
            End With


            For Each Item As ListViewItem In LvwDetalle.Items
                OrdenCompraDetalle = New TOrdenCompraDetalle(EmpresaInfo.Emp_Id)
                Detalle_Id = Detalle_Id + 1
                With OrdenCompraDetalle
                    .Emp_Id = OrdenCompraEncabezado.Emp_Id
                    .Suc_Id = OrdenCompraEncabezado.Suc_Id
                    .Orden_Id = OrdenCompraEncabezado.Orden_Id
                    .Detalle_Id = Detalle_Id
                    .Bod_Id = OrdenCompraEncabezado.Bod_Id
                    .Art_Id = Item.SubItems(ColumnasDetalle.Articulo).Text
                    .Cantidad = CDbl(Item.SubItems(ColumnasDetalle.Cantidad).Text)
                    .CantidadBonificada = CDbl(Item.SubItems(ColumnasDetalle.CantidadBonificada).Text)
                    .Costo = CDbl(Item.SubItems(ColumnasDetalle.Costo).Text)
                    .PorcDescuento = CDbl(Item.SubItems(ColumnasDetalle.PorcDescuento).Text)
                    .MontoDescuento = CDbl(Item.SubItems(ColumnasDetalle.MontoDescuento).Text)
                    .MontoIV = CDbl(Item.SubItems(ColumnasDetalle.MontoIV).Text)
                    .TotalLinea = CDbl(Item.SubItems(ColumnasDetalle.TotalLinea).Text)
                    .TotalLineaBonificada = CDbl(Item.SubItems(ColumnasDetalle.TotalLineaBonificacion).Text)
                    .ExentoIV = CDbl(Item.SubItems(ColumnasDetalle.Exento).Text)
                    .Fecha = OrdenCompraEncabezado.Fecha

                    For Each impuesto As TInfoArticuloImpuesto In CType(Item.Tag, List(Of TInfoArticuloImpuesto))

                        .OrdenImpuestoDetalle.Add(New TOrdenCompraDetalleImpuesto(EmpresaInfo.Emp_Id) With
                                                  {.Codigo_Id = impuesto.Codigo_Id,
                                                   .Tarifa_Id = impuesto.Tarifa_Id,
                                                   .Porcentaje = impuesto.Porcentaje,
                                                   .Cantidad = CDbl(Item.SubItems(ColumnasDetalle.Cantidad).Text),
                                                   .Monto = impuesto.Monto,
                                                   .Total = impuesto.Monto * CDbl(Item.SubItems(ColumnasDetalle.Cantidad).Text),
                                                   .Fecha = OrdenCompraEncabezado.Fecha})

                    Next

                End With
                OrdenCompraEncabezado.OrdenCompraDetalles.Add(OrdenCompraDetalle)
            Next

            Mensaje = OrdenCompraEncabezado.GuardarDocumento()
            VerificaMensaje(Mensaje)


            If pAplicar Then
                OrdenCompraEncabezado.AplicaUsuario_Id = pAplicaUsuario_Id
                Mensaje = OrdenCompraEncabezado.AplicaOrdenCompra()
                VerificaMensaje(Mensaje)
            End If

            If Nuevo Then
                MsgBox("Se generó la Orden de Compra # " & OrdenCompraEncabezado.Orden_Id.ToString, MsgBoxStyle.Information, Me.Text)


            Else
                MsgBox("Los datos se almacenaron de manera correcta", MsgBoxStyle.Information, Me.Text)
            End If

            Inicializa()

            TxtNumero.Text = OrdenCompraEncabezado.Orden_Id.ToString
            TxtNumero.Focus()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            OrdenCompraEncabezado = Nothing
        End Try
    End Sub

    Private Sub CargaDocumento()
        Dim OrdenCompraEncabezado As New TOrdenCompraEncabezado(EmpresaInfo.Emp_Id)
        Dim OrdenCompraDetalle As New TOrdenCompraDetalle(EmpresaInfo.Emp_Id)
        Dim OCImpuesto As List(Of TInfoArticuloImpuesto)
        Dim Item As ListViewItem = Nothing
        Dim Items(17) As String
        Dim Mensaje As String = ""
        Dim Detalle_Id As Integer = 0
        Try

            With OrdenCompraEncabezado
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
                .Orden_Id = CLng(TxtNumero.Text)
            End With
            Mensaje = OrdenCompraEncabezado.ListKey()
            VerificaMensaje(Mensaje)

            If OrdenCompraEncabezado.RowsAffected = 0 Then
                TxtNumero.SelectAll()
                TxtNumero.Focus()
                VerificaMensaje("El número de orden de compra no es válido")
            End If

            With OrdenCompraDetalle
                .Emp_Id = OrdenCompraEncabezado.Emp_Id
                .Suc_Id = OrdenCompraEncabezado.Suc_Id
                .Orden_Id = CLng(TxtNumero.Text)
            End With
            Mensaje = OrdenCompraDetalle.List()
            VerificaMensaje(Mensaje)


            TxtNumero.Enabled = False

            'Encabezado
            DtpFecha.Value = DateValue(OrdenCompraEncabezado.Fecha)
            LblEstado.Text = OrdenCompraEncabezado.NombreEstado
            TxtComentario.Text = OrdenCompraEncabezado.Comentario
            TxtProveedor.Text = OrdenCompraEncabezado.Prov_Id
            ValidaProveedor()

            'Detalle
            TxtArticulo.Text = ""
            InicializaArticulo()
            LvwDetalle.Items.Clear()

            LblSubTotal.Text = "0.00"
            LblDescuento.Text = "0.00"
            LblImpuestoVenta.Text = "0.00"
            LblTotalCosto.Text = "0.00"
            LblTotalBonificacion.Text = "0.00"

            For Each Fila As DataRow In OrdenCompraDetalle.Data.Tables("TablaDetalle").Rows
                Item = New ListViewItem(Items)
                Detalle_Id = Detalle_Id + 1

                With Item
                    .SubItems(ColumnasDetalle.Linea).Text = Detalle_Id
                    .SubItems(ColumnasDetalle.Articulo).Text = Fila("Art_Id")
                    .SubItems(ColumnasDetalle.Cantidad).Text = Format(Fila("Cantidad"), "##0.00")
                    .SubItems(ColumnasDetalle.CantidadBonificada).Text = Format(Fila("CantidadBonificada"), "##0.00")
                    .SubItems(ColumnasDetalle.Nombre).Text = Fila("NombreArticulo")
                    .SubItems(ColumnasDetalle.Costo).Text = Format(Fila("Costo"), "##0.0000")
                    .SubItems(ColumnasDetalle.PorcDescuento).Text = Format(Fila("PorcDescuento"), "##0.0000")
                    .SubItems(ColumnasDetalle.MontoDescuento).Text = Format(Fila("MontoDescuento"), "##0.0000")
                    .SubItems(ColumnasDetalle.MontoIV).Text = Format(Fila("MontoIV"), "##0.0000")
                    .SubItems(ColumnasDetalle.TotalLinea).Text = Format(Fila("TotalLinea"), "##0.0000")
                    .SubItems(ColumnasDetalle.TotalLineaBonificacion).Text = Format(Fila("TotalLineaBonificada"), "##0.0000")
                    .SubItems(ColumnasDetalle.Maximo).Text = Format(Fila("Maximo"), "##0.00")
                    .SubItems(ColumnasDetalle.Minimo).Text = Format(Fila("Minimo"), "##0.00")
                    .SubItems(ColumnasDetalle.FactorConversion).Text = Format(Fila("FactorConversion"), "##0.00")
                    .SubItems(ColumnasDetalle.PromedioVenta).Text = Format(Fila("PromedioVenta"), "##0.00")
                    .SubItems(ColumnasDetalle.Exento).Text = IIf(Fila("ExentoIV"), -1, 0)
                    .SubItems(ColumnasDetalle.Suelto).Text = IIf(Fila("Suelto"), -1, 0)
                    .SubItems(ColumnasDetalle.CostoActual).Text = Fila("Costo")


                    OCImpuesto = New List(Of TInfoArticuloImpuesto)
                    If Not Fila("ExentoIV") Then
                        For Each impuesto As DataRow In OrdenCompraDetalle.Data.Tables("TablaImpuesto").Rows
                            If impuesto("Detalle_Id") = Fila("Detalle_Id") Then

                                OCImpuesto.Add(New TInfoArticuloImpuesto() With
                                               {.Codigo_Id = impuesto("Codigo_Id"),
                                                .Tarifa_Id = impuesto("Tarifa_Id"),
                                                .Porcentaje = impuesto("Porcentaje"),
                                                .Monto = impuesto("Monto")})
                            End If
                        Next
                    End If
                    Item.Tag = OCImpuesto
                End With
                LvwDetalle.Items.Add(Item)

                Item.EnsureVisible()
            Next

            'Habilita o desabilita campos
            Select Case OrdenCompraEncabezado.OrdenEstado_Id
                Case OrdenCompraEstadoEnum.Aplicada, OrdenCompraEstadoEnum.Cerrada
                    TxtProveedor.Enabled = False
                    TxtProveedorNombre.Enabled = False
                    TxtComentario.Enabled = False
                    PnLineaDetalle.Enabled = False
                    HabilitaBotones(AccionEnum.Aplicado)
                Case OrdenCompraEstadoEnum.Pendiente
                    TxtProveedor.Enabled = (LvwDetalle.Items.Count = 0)
                    TxtProveedorNombre.Enabled = (LvwDetalle.Items.Count = 0)
                    TxtComentario.Enabled = True
                    PnLineaDetalle.Enabled = True
                    HabilitaBotones(AccionEnum.Modificando)
                    TxtArticulo.Focus()
            End Select

            MuestraTotales()



        Catch ex As Exception
            MensajeError(ex.Message)
            Inicializa()
        Finally
            OrdenCompraEncabezado = Nothing
            OrdenCompraDetalle = Nothing
        End Try
    End Sub

    Private Sub BuscarDocumento()
        Dim Forma As New FrmBusquedaOrdenCompra
        Try

            If Not TxtNumero.Enabled Then
                Exit Sub
            End If

            Forma.SoloAplicadas = False
            Forma.Execute()
            If Forma.Selecciono Then
                TxtNumero.Text = Forma.Numero_Id
                CargaDocumento()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub EliminarMovimiento()
        Dim OrdenCompraEncabezado As New TOrdenCompraEncabezado(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            With OrdenCompraEncabezado
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
                .Orden_Id = CLng(TxtNumero.Text)
            End With

            Mensaje = OrdenCompraEncabezado.EliminarDocumento()
            VerificaMensaje(Mensaje)

            Inicializa()
            TxtNumero.Focus()


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            OrdenCompraEncabezado = Nothing
        End Try
    End Sub

    Private Sub ConsultarArticulo()
        Dim Forma As New FrmConsultaArticulo
        Try

            If Not LvwDetalle.SelectedItems Is Nothing AndAlso LvwDetalle.SelectedItems.Count > 0 Then
                Forma.Execute(LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Articulo).Text.ToString())
            Else
                Forma.Execute()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

#End Region
#Region "Eventos Forma"

    Private Sub FrmAjusteInventario_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                BtnBuscar.PerformClick()
            Case Keys.F2
                BtnNuevo.PerformClick()
            Case Keys.F3
                BtnModificar.PerformClick()
            Case Keys.F4
                BtnAplicar.PerformClick()
            Case Keys.F5
                BtnEliminar.PerformClick()
            Case Keys.F6
                BtnCancelar.PerformClick()
            Case Keys.F7
                BtnImprimir.PerformClick()
            Case Keys.F8
                BtnSaldos.PerformClick()
            Case Keys.F9
                BtnSalir.PerformClick()
            Case Keys.F10 And BtnSugerir.Enabled
                BtnSugerir.ShowDropDown()
        End Select
    End Sub
    Private Sub FrmAjusteInventario_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            FormateaCamposNumericos()
            ConfiguraDetalle()
            ConfiguraStatusBar()

            Me.Location = Screen.PrimaryScreen.WorkingArea.Location
            Me.Width = Screen.PrimaryScreen.WorkingArea.Size.Width
            Me.Height = Screen.PrimaryScreen.WorkingArea.Size.Height - 50


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click
        Nuevo()
    End Sub

    Private Sub BtnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancelar.Click
        Limpiar()
    End Sub

    Private Sub BuscarArticulo()
        Dim Forma As New FrmBusquedaArticuloOnLine
        Try
            With Forma
                .Suc_Id = SucursalParametroInfo.Suc_Id
                .Bod_Id = SucursalParametroInfo.BodCompra_Id
            End With

            Forma.Execute()
            If Forma.Art_Id.Trim <> "" Then
                TxtArticulo.Text = Forma.Art_Id
                ValidaArticulo(TxtArticulo.Text.Trim, False)
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BuscarProveedor()
        Dim Forma As New FrmBusquedaProveedor
        Try

            Forma.Execute()
            If Forma.Selecciono Then
                TxtProveedor.Text = Forma.Prov_Id
                ValidaProveedor()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub


    Private Sub TxtArticulo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtArticulo.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If TxtArticulo.Text.Trim <> "" Then
                    If Not ValidaArticulo(TxtArticulo.Text, False) Then
                        TxtArticulo.SelectAll()
                        TxtArticulo.Focus()
                    End If
                End If
        End Select
    End Sub
    Private Sub TxtArticulo_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtArticulo.TextChanged
        InicializaArticulo()
    End Sub

    Private Sub TxtComentario_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtComentario.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If TxtArticulo.Enabled And PnLineaDetalle.Enabled Then
                    TxtArticulo.Focus()
                End If
        End Select
    End Sub

    Private Sub TxtCosto_GotFocus(sender As Object, e As System.EventArgs) Handles TxtCosto.GotFocus
        TxtCosto.SelectAll()
    End Sub
    Private Sub TxtCosto_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCosto.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If ValidaCosto() Then
                    TxtPorcDesc.Focus()
                Else
                    TxtCosto.SelectAll()
                    TxtCosto.Focus()
                End If
            Case Keys.Escape
                If TxtCosto.Enabled AndAlso Not TxtCosto.ReadOnly Then
                    InicializaArticulo()
                    TxtArticulo.Text = ""
                    TxtArticulo.Focus()
                End If
        End Select
    End Sub

    Private Sub TxtCantidad_GotFocus(sender As Object, e As System.EventArgs) Handles TxtCantidad.GotFocus
        TxtCantidad.SelectAll()
    End Sub
    Private Sub TxtCantidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCantidad.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If TxtCantidad.Enabled Then
                    InicializaArticulo()
                    TxtArticulo.Text = ""
                    TxtArticulo.Focus()
                End If
            Case Keys.Enter
                If ValidaCosto() AndAlso ValidaCantidad() And ValidaBonificacion() Then
                    IngresaArticulo()
                End If
        End Select
    End Sub
    Private Sub LvwDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles LvwDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                EliminaLinea()
            Case Keys.Enter
                ModificaLinea()
        End Select
    End Sub
    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Salir()
    End Sub
    Private Sub BtnModificar_Click(sender As System.Object, e As System.EventArgs) Handles BtnModificar.Click
        Guardar()
    End Sub
    Private Sub BtnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles BtnBuscar.Click
        Select Case Me.ActiveControl.Name
            Case "TxtNumero"
                BuscarDocumento()
            Case "TxtArticulo"
                BuscarArticulo()
            Case "TxtProveedor"
                BuscarProveedor()
        End Select
    End Sub
    Private Sub TxtNumero_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtNumero.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If IsNumeric(TxtNumero.Text) Then
                    CargaDocumento()
                End If
        End Select

    End Sub
    Private Sub BtnAplicar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAplicar.Click
        Aplicar()
    End Sub

    Private Sub BtnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEliminar.Click
        Eliminar()
    End Sub
#End Region

    Private Sub Aplicar()
        Try

            If BtnAplicar.Enabled Then
                If MsgBox("Desea aplicar el movimiento?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                    GuardarDocumento(True, UsuarioInfo.Usuario_Id)
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            If BtnEliminar.Enabled Then
                If MsgBox("Desea eliminar el documento?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                    EliminarMovimiento()
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function Validatodo()
        Try

            If TxtProveedor.Text.Trim = "" Then
                VerificaMensaje("Código de proveedor no válido")
            End If

            If Not ValidaProveedor() Then
                VerificaMensaje("Código de proveedor no válido")
            End If

            If LvwDetalle.Items.Count = 0 Then
                VerificaMensaje("Debe de ingresar al menos una linea")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimir.Click
        Imprimir()
    End Sub

    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim OrdenCompraEncabezado As New TOrdenCompraEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte As New OrdenCompra
        Dim FormaReporte As New FrmReporte
        Try

            Cursor.Current = Cursors.WaitCursor
            BtnImprimir.Enabled = False

            With OrdenCompraEncabezado
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
                .Orden_Id = CLng(TxtNumero.Text)
            End With

            Mensaje = OrdenCompraEncabezado.RptOrdenCompra()
            VerificaMensaje(Mensaje)

            If OrdenCompraEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(OrdenCompraEncabezado.Data.Tables(0))


            'parametros encabezado y pie de pagina

            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("NombreSucursal", SucursalInfo.Nombre)
            Reporte.SetParameterValue("TelefonoSucursal", SucursalInfo.Telefono)


            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            OrdenCompraEncabezado = Nothing
            BtnImprimir.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub Limpiar()
        Try
            Inicializa()
            TxtNumero.Focus()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Imprimir()
        Try
            If BtnImprimir.Enabled Then
                MuestraReporte()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Salir()
        If LvwDetalle.Items.Count > 0 Then
            If MsgBox("Desea salir del documento?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Guardar()
        Try
            If BtnModificar.Enabled Then
                If Validatodo() Then
                    GuardarDocumento(False, "")
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LvwDetalle_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LvwDetalle.MouseDoubleClick
        ModificaLinea()
    End Sub

    Private Sub MenuDetalle_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles MenuDetalle.Opening
        If LvwDetalle.Items.Count = 0 OrElse Not PnLineaDetalle.Enabled OrElse LvwDetalle.SelectedItems.Count = 0 OrElse Not TxtArticulo.Enabled Then
            e.Cancel = True
        End If
    End Sub

    Private Sub MnuEliminarLinea_Click(sender As System.Object, e As System.EventArgs) Handles MnuEliminarLinea.Click
        EliminaLinea()
    End Sub

    Private Sub MnuModificarLinea_Click(sender As System.Object, e As System.EventArgs) Handles MnuModificarLinea.Click
        ModificaLinea()
    End Sub

    Private Function ValidaProveedor() As Boolean
        Dim Proveedor As New TProveedor(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            If Not IsNumeric(TxtProveedor.Text.Trim) Then
                VerificaMensaje("Debe de digitar un valor válido")
                EnfocarTexto(TxtProveedor)
            End If

            Proveedor.Prov_Id = TxtProveedor.Text.Trim
            Mensaje = Proveedor.ListKey
            VerificaMensaje(Mensaje)

            If Proveedor.RowsAffected = 0 Then
                VerificaMensaje("Código de proveedor no válido")
                EnfocarTexto(TxtProveedor)
            End If

            If Not Proveedor.Activo Then
                VerificaMensaje("El proveedor se encuentra inactivo")
                EnfocarTexto(TxtProveedor)
            End If

            TxtProveedorNombre.Text = Proveedor.Nombre
            TxtComentario.Focus()

            Return True
        Catch ex As Exception
            EnfocarTexto(TxtProveedor)
            MensajeError(ex.Message)
            Return False
        Finally
            Proveedor = Nothing
        End Try
    End Function

    Private Sub TxtProveedor_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtProveedor.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If TxtProveedor.Text.Trim <> "" Then
                    ValidaProveedor()
                End If
        End Select
    End Sub

    Private Sub TxtProveedor_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtProveedor.TextChanged
        TxtProveedorNombre.Text = ""
    End Sub

    Private Sub TxtPorcDesc_GotFocus(sender As Object, e As System.EventArgs) Handles TxtPorcDesc.GotFocus
        TxtPorcDesc.SelectAll()
    End Sub

    Private Sub TxtPorcDesc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtPorcDesc.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If ValidaDescuento() Then
                    TxtCantidad.Focus()
                Else
                    TxtPorcDesc.SelectAll()
                    TxtPorcDesc.Focus()
                End If
            Case Keys.Escape
                If TxtPorcDesc.Enabled Then
                    InicializaArticulo()
                    TxtArticulo.Text = ""
                    TxtArticulo.Focus()
                End If
        End Select
    End Sub

    Private Sub TxtBonificacion_GotFocus(sender As Object, e As System.EventArgs) Handles TxtBonificacion.GotFocus
        TxtBonificacion.SelectAll()
    End Sub

    Private Sub TxtBonificacion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtBonificacion.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If TxtCantidad.Enabled Then
                    InicializaArticulo()
                    TxtArticulo.Text = ""
                    TxtArticulo.Focus()
                End If
            Case Keys.Enter
                If ValidaCosto() AndAlso ValidaCantidad() And ValidaBonificacion() Then
                    IngresaArticulo()
                End If
        End Select
    End Sub

    Private Sub BtnSaldos_Click(sender As System.Object, e As System.EventArgs) Handles BtnSaldos.Click
        ConsultarArticulo()
    End Sub

    Private Sub Mnu7Dias_Click(sender As System.Object, e As System.EventArgs) Handles Mnu7Dias.Click
        If ValidaProveedor() Then
            Sugerir(7)
        End If
    End Sub

    Private Sub Mnu15Dias_Click(sender As System.Object, e As System.EventArgs) Handles Mnu15Dias.Click
        If ValidaProveedor() Then
            Sugerir(15)
        End If
    End Sub

    Private Sub Mnu30Dias_Click(sender As System.Object, e As System.EventArgs) Handles Mnu30Dias.Click
        If ValidaProveedor() Then
            Sugerir(30)
        End If
    End Sub

    Private Sub Mnu60Dias_Click(sender As System.Object, e As System.EventArgs) Handles Mnu60Dias.Click
        If ValidaProveedor() Then
            Sugerir(60)
        End If
    End Sub

    Private Sub Mnu90Dias_Click(sender As System.Object, e As System.EventArgs) Handles Mnu90Dias.Click
        If ValidaProveedor() Then
            Sugerir(90)
        End If
    End Sub

    Private Function ValidaTxtArticulo() As Boolean

        Try
            If TxtArticulo.Text = "" Then
                Return False
            End If

            If TxtArticulo.Text = "." Then
                Return False
            End If

            If Not IsNumeric(TxtArticulo.Text(TxtArticulo.Text.Length - 1)) Then
                Return False
            End If

            If Not IsNumeric(TxtArticulo.Text(0)) Then
                Return False
            End If

            Return True

        Catch ex As Exception
            Return False
        End Try



    End Function




    'Private Function RestaMontoImpuesto(pMonto As Double, pArticuloImpuestos As List(Of TOrdenCompraDetalleImpuesto)) As Double
    '    Dim OtrosImpuestos As Double = 0
    '    Dim TotalImpuesto As Double = 0
    '    Dim TotalPorcentaje As Double = 0


    '    For Each impuesto As TOrdenCompraDetalleImpuesto In pArticuloImpuestos
    '        If impuesto.Codigo_Id = coImpuesto01 OrElse impuesto.Codigo_Id = coImpuesto12 Then
    '            With impuesto
    '                .Detalle_Id = 1
    '                .Monto = pMonto - (pMonto / (1 + (impuesto.Porcentaje / 100)))
    '            End With
    '            TotalPorcentaje += impuesto.Porcentaje
    '        End If
    '    Next

    '    TotalImpuesto = pMonto - (pMonto / (1 + (TotalPorcentaje / 100)))

    '    For Each impuesto As TOrdenCompraDetalleImpuesto In pArticuloImpuestos
    '        If impuesto.Codigo_Id <> coImpuesto01 And impuesto.Codigo_Id <> coImpuesto12 Then
    '            With impuesto
    '                .Detalle_Id = 1
    '                .Monto = (pMonto - TotalImpuesto) - ((pMonto - TotalImpuesto) / (1 + (impuesto.Porcentaje / 100)))
    '            End With
    '            OtrosImpuestos += impuesto.Porcentaje
    '        End If
    '    Next

    '    Return TotalImpuesto + (pMonto - TotalImpuesto) - ((pMonto - TotalImpuesto) / (1 + (OtrosImpuestos / 100)))

    'End Function

    'Private Sub CargaImpuestos(pArt_Id As String)
    '    Dim Mensaje As String = ""
    '    Dim Item As ListViewItem = Nothing
    '    Dim Items(4) As String
    '    Try

    '        InfoArticuloCompra.Art_Id = pArt_Id
    '        Mensaje = InfoArticuloCompra.ConsultaArticuloImpuestosOC
    '        VerificaMensaje(Mensaje)

    '        If InfoArticuloCompra.RowsAffected = 0 Then
    '            Exit Sub
    '        End If

    '    Catch ex As Exception
    '        MensajeError(ex.Message)
    '    End Try
    'End Sub
End Class