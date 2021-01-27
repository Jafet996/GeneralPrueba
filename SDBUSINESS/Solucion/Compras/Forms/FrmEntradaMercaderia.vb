Imports Business
Public Class FrmEntradaMercaderia
#Region "Declaración de variables"
    Dim InfoArticuloCompra As New TInfoAticuloCompra(EmpresaInfo.Emp_Id)
    Dim _EntradaFacturas As New List(Of TEntradaFactura)
    Dim Numerico() As TNumericFormat
    Dim _CargaAutomatica As Boolean = False
    Dim _Lotes As New List(Of TArticuloLote)

    'Dim _EntradaDetalleImpuestos As New List(Of TEntradaDetalleImpuesto)
    'Dim _OrdenCompraDetalleImpuesto As New List(Of TOrdenCompraDetalleImpuesto)
    '   Dim InfoArticulo As New TInfoArticulo(EmpresaInfo.Emp_Id)

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
        CantidadEscaneada = 4
        Nombre = 5
        Costo = 6
        PorcDescuento = 7
        MontoDescuento = 8
        MontoIV = 9
        TotalLinea = 10
        TotalLineaBonificacion = 11
        PorcUtilidad = 12
        Precio = 13
        PrecioIVI = 14
        Maximo = 15
        Minimo = 16
        FactorConversion = 17
        PromedioVenta = 18
        Exento = 19
        Suelto = 20
        CostoActual = 21
        LoteUU = 22
    End Enum
    Private Enum AccionDetalle
        Nuevo = 0
        Sumariza = 1
        Modifica = 2
    End Enum
#End Region
#Region "Metodos Publicos"
    Public Sub Execute(pNuevo As Boolean, pProv_Id As Integer, pListaArticulos As List(Of TArticuloConteo), pClave As String)
        Try


            AsignaLogo(PicLogo)
            CargaCombos()
            Inicializa()
            _CargaAutomatica = True

            If pClave.Trim <> String.Empty Then
                TSSClaveTitulo.Visible = True
                TSSClave.Visible = True
                TSSClave.Text = pClave
            End If

            Me.Show()

            If pNuevo Then
                Nuevo()
                TxtProveedor.Text = pProv_Id
                ValidaProveedor()
                TxtArticulo.Select()

                For Each art As TArticuloConteo In pListaArticulos
                    TxtArticulo.Text = art.Art_Id
                    ValidaArticulo(TxtArticulo.Text, False)
                    TxtCantidad.Text = art.Cantidad
                    TxtCosto.Text = art.Costo
                    TxtPorcDesc.Text = CDbl(((art.Descuento * 100) / art.Costo).ToString("##0.00"))
                    IngresaArticulo()
                Next

            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute()
        Try

            AsignaLogo(PicLogo)
            CargaCombos()
            Inicializa()

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    'Public Sub Execute(pOrden_Id As Integer)
    '    AsignaLogo(PicLogo)
    '    CargaCombos()
    '    Inicializa()
    '    Nuevo()
    '    TxtOrden.Text = pOrden_Id
    '    CargaOrdenCompra()
    '    MuestraTotales()
    '    Me.ShowDialog()
    'End Sub
#End Region
#Region "Metodos Privados"
    Public Sub Nuevo()
        Try
            TxtNumero.Enabled = False

            TxtProveedor.Enabled = True
            TxtProveedorNombre.Enabled = True
            TxtDiasCredito.Enabled = True
            TxtComentario.Enabled = True
            TxtPorcDescuentoGlobal.Enabled = True
            TxtOrden.Enabled = True
            TxtComprobante.Enabled = True
            DtpFecha.Enabled = True

            HabilitaBotones(AccionEnum.Creando)

            'Encabezado
            PnEncabezado.Enabled = True
            TxtNumero.Text = ""
            LblEstado.Text = "Nuevo"
            DtpFecha.Value = EmpresaInfo.Getdate
            TxtProveedor.Text = ""
            TxtProveedorNombre.Text = ""
            TxtDiasCredito.Text = ""
            TxtComentario.Text = ""
            TxtPorcDescuentoGlobal.Text = ""
            TxtOrden.Text = ""
            TxtOrden.Focus()

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

            _EntradaFacturas.Clear()
            _Lotes.Clear()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(9)

            Numerico(0) = New TNumericFormat(TxtNumero, 8, 0, False, "", "###0")
            Numerico(1) = New TNumericFormat(TxtCosto, 6, 4, False, "", "###0.00")
            Numerico(2) = New TNumericFormat(TxtCantidad, 6, 2, False, "", "###0.00")
            Numerico(3) = New TNumericFormat(TxtProveedor, 4, 0, False, "", "###0")
            Numerico(4) = New TNumericFormat(TxtPorcDesc, 3, 2, False, "", "###0.00")
            Numerico(5) = New TNumericFormat(TxtBonificacion, 6, 2, False, "", "###0.00")
            Numerico(6) = New TNumericFormat(TxtOrden, 8, 0, False, "", "###0")
            Numerico(7) = New TNumericFormat(TxtPrecio, 6, 4, False, "", "###0.00")
            Numerico(8) = New TNumericFormat(TxtPorcUtilidad, 3, 2, False, "", "###0.00")
            Numerico(9) = New TNumericFormat(TxtPorcDescuentoGlobal, 3, 2, False, "", "###0.00")


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
                .Columns(ColumnasDetalle.Linea).Width = 40

                .Columns(ColumnasDetalle.Articulo).Text = "Código"
                .Columns(ColumnasDetalle.Articulo).Width = 100

                .Columns(ColumnasDetalle.Cantidad).Text = "Cantidad"
                .Columns(ColumnasDetalle.Cantidad).Width = 60
                .Columns(ColumnasDetalle.Cantidad).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.CantidadBonificada).Text = "Bonif"
                .Columns(ColumnasDetalle.CantidadBonificada).Width = 60
                .Columns(ColumnasDetalle.CantidadBonificada).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.Nombre).Text = "Descripción"
                .Columns(ColumnasDetalle.Nombre).Width = 205

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
                .Columns(ColumnasDetalle.TotalLineaBonificacion).Width = 90
                .Columns(ColumnasDetalle.TotalLineaBonificacion).TextAlign = HorizontalAlignment.Right


                .Columns(ColumnasDetalle.PorcUtilidad).Text = "% Util"
                .Columns(ColumnasDetalle.PorcUtilidad).Width = 50
                .Columns(ColumnasDetalle.PorcUtilidad).TextAlign = HorizontalAlignment.Right


                .Columns(ColumnasDetalle.Precio).Text = "Precio"
                .Columns(ColumnasDetalle.Precio).Width = 80
                .Columns(ColumnasDetalle.Precio).TextAlign = HorizontalAlignment.Right


                .Columns(ColumnasDetalle.PrecioIVI).Text = "Precio IVI"
                .Columns(ColumnasDetalle.PrecioIVI).Width = 80
                .Columns(ColumnasDetalle.PrecioIVI).TextAlign = HorizontalAlignment.Right

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


                .Columns(ColumnasDetalle.CantidadEscaneada).Text = "Escaneo"
                .Columns(ColumnasDetalle.CantidadEscaneada).Width = 80 'IIf(EmpresaParametroInfo.EscaneaEntradaMercaderia, 80, 0)
                .Columns(ColumnasDetalle.CantidadEscaneada).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.LoteUU).Text = "Lote"
                .Columns(ColumnasDetalle.LoteUU).Width = 35
                .Columns(ColumnasDetalle.LoteUU).TextAlign = HorizontalAlignment.Center


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
                BtnDesaplicarEntrada.Enabled = False
                BtnFacturas.Enabled = False
                BtnUtilidades.Enabled = False
                BtnLotes.Enabled = False
                BtnEscaneo.Enabled = False

            Case AccionEnum.Creando
                BtnBuscar.Enabled = True
                BtnNuevo.Enabled = False
                BtnModificar.Enabled = True
                BtnAplicar.Enabled = False
                BtnEliminar.Enabled = False
                BtnCancelar.Enabled = True
                BtnImprimir.Enabled = False
                BtnDesaplicarEntrada.Enabled = False
                BtnFacturas.Enabled = True
                BtnUtilidades.Enabled = True
                BtnLotes.Enabled = True
                BtnEscaneo.Enabled = EmpresaParametroInfo.EscaneaEntradaMercaderia
            Case AccionEnum.Salvando
                BtnBuscar.Enabled = False
                BtnNuevo.Enabled = False
                BtnModificar.Enabled = False
                BtnAplicar.Enabled = False
                BtnEliminar.Enabled = False
                BtnCancelar.Enabled = False
                BtnImprimir.Enabled = False
                BtnDesaplicarEntrada.Enabled = False
                BtnFacturas.Enabled = False
                BtnEscaneo.Enabled = False
                BtnUtilidades.Enabled = False
                BtnLotes.Enabled = False
            Case AccionEnum.Modificando
                BtnBuscar.Enabled = True
                BtnNuevo.Enabled = False
                BtnModificar.Enabled = True
                BtnAplicar.Enabled = True
                BtnEliminar.Enabled = True
                BtnCancelar.Enabled = True
                BtnImprimir.Enabled = False
                BtnEscaneo.Enabled = EmpresaParametroInfo.EscaneaEntradaMercaderia
                BtnDesaplicarEntrada.Enabled = False
                BtnFacturas.Enabled = True
                BtnUtilidades.Enabled = True
                BtnLotes.Enabled = True
            Case AccionEnum.Aplicado
                BtnBuscar.Enabled = False
                BtnNuevo.Enabled = False
                BtnModificar.Enabled = False
                BtnAplicar.Enabled = False
                BtnEliminar.Enabled = False
                BtnCancelar.Enabled = True
                BtnImprimir.Enabled = True
                BtnDesaplicarEntrada.Enabled = True
                BtnFacturas.Enabled = False
                BtnUtilidades.Enabled = False
                BtnEscaneo.Enabled = False
                BtnLotes.Enabled = False
        End Select

    End Sub
    Private Sub Inicializa()
        Try

            HabilitaBotones(AccionEnum.Inicial)

            'Limpia variables globales

            'Encabezado
            TxtNumero.Enabled = True
            TxtNumero.Text = ""

            TSSClaveTitulo.Visible = False
            TSSClave.Visible = False
            TSSClave.Text = String.Empty

            _CargaAutomatica = False
            LblEstado.Text = ""
            DtpFecha.Value = EmpresaInfo.Getdate
            TxtProveedor.Enabled = False
            TxtProveedorNombre.Enabled = False
            TxtDiasCredito.Enabled = False
            TxtComentario.Enabled = False
            TxtPorcDescuentoGlobal.Enabled = False
            TxtOrden.Enabled = False
            TxtComprobante.Enabled = False
            DtpFecha.Enabled = False

            TxtProveedor.Text = ""
            TxtProveedorNombre.Text = ""
            TxtDiasCredito.Text = ""
            TxtComentario.Text = ""
            TxtPorcDescuentoGlobal.Text = ""
            TxtOrden.Text = ""
            TxtComprobante.Text = ""


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

            _EntradaFacturas.Clear()
            _Lotes.Clear()

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

        TxtSaldo.Enabled = pActivar
        TxtCosto.Enabled = pActivar

        TxtPorcUtilidad.Enabled = pActivar
        TxtPrecio.Enabled = pActivar


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
                VerificaMensaje(ArticuloProveedor.Insert())
                VerificaMensaje(Mensaje)

                'If MsgBox("El artículo seleccionado no se encuentra asociado a este proveedor, Desea asociarlo ahora?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                '    Mensaje = ArticuloProveedor.Insert()
                '    VerificaMensaje(Mensaje)
                'Else
                '    VerificaMensaje("No se puede ingresar el artículo debido a que este no pertenece al proveedor seleccionado")
                'End If
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

            If InfoArticuloCompra.RowsAffected = 0 Then
                VerificaMensaje("Artículo inválido, no se encontraron datos")
            End If

            If InfoArticuloCompra.Suelto Then
                VerificaMensaje("Artículo inválido, no se pueden hacer pedidos de articulos sueltos")
            End If

            If InfoArticuloCompra.Servicio Then
                VerificaMensaje("Artículo inválido, no se le puede hacer una entrada a un codigo de servicio")
            End If

            Mensaje = ValidaArticuloProveedor(CInt(TxtProveedor.Text), InfoArticuloCompra.Art_Id)
            VerificaMensaje(Mensaje)


            TxtArticuloNombre.Text = InfoArticuloCompra.NombreArticulo
            TxtUnidadMedida.Text = InfoArticuloCompra.NombreUnidad


            TxtFactorConversion.Text = Format(InfoArticuloCompra.FactorConversion, "###0")
            TxtTransito.Text = Format(InfoArticuloCompra.Transito, "###0.00")
            TxtMaximo.Text = Format(InfoArticuloCompra.Maximo, "###0.00")


            TxtSaldo.Text = Format(InfoArticuloCompra.Saldo, "###0.00")

            TxtPorcUtilidad.Text = Format(InfoArticuloCompra.Margen, "###0.00")
            TxtCosto.Text = Format(InfoArticuloCompra.Costo, "###0.00")
            TxtCostoActual.Text = Format(InfoArticuloCompra.Costo, "###0.00")


            If InfoArticuloCompra.ExentoIV Then
                TxtPrecio.Text = Format(InfoArticuloCompra.Precio, "###0.00")
            Else
                'cambio iva
                TxtPrecio.Text = Format(InfoArticuloCompra.Precio + CalculaMontoImpuesto(InfoArticuloCompra.Precio, InfoArticuloCompra.ArticuloImpuestos), "###0.00")
            End If


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

            If CDbl(TxtCosto.Text) <= 0 Then
                TxtCosto.SelectAll()
                TxtCosto.Focus()
                VerificaMensaje("El costo debe de ser mayor o igual a cero")
            End If

            Return True

        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function


    Private Function ValidaPrecio() As Boolean
        Try
            If Not IsNumeric(TxtPrecio.Text) Then
                TxtPrecio.SelectAll()
                TxtPrecio.Focus()
                VerificaMensaje("Debe de ingresar una cantidad válida")
            End If

            If CDbl(TxtPrecio.Text) < 0 Then
                TxtPrecio.SelectAll()
                TxtPrecio.Focus()
                VerificaMensaje("La cantidad debe de ser mayor o igual a cero")
            End If

            If CDbl(TxtPrecio.Text) < CDbl(TxtCosto.Text) Then
                TxtPrecio.SelectAll()
                TxtPrecio.Focus()
                VerificaMensaje("El precio no puede ser menor al costo")
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
            If Not IsNumeric(TxtCantidad.Text) OrElse CDbl(TxtCantidad.Text) < 0 Then
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

        TxtSaldo.Text = ""
        TxtCosto.Text = ""

        TxtPorcUtilidad.Text = ""
        TxtPrecio.Text = ""

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

    Private Function DescuentoMayor() As Double
        If Not IsNumeric(TxtPorcDescuentoGlobal.Text) Then
            TxtPorcDescuentoGlobal.Text = "0.00"
        End If
        If Not IsNumeric(TxtPorcDesc.Text) Then
            TxtPorcDesc.Text = "0.00"
        End If

        If CDbl(TxtPorcDescuentoGlobal.Text) > CDbl(TxtPorcDesc.Text) Then
            Return CDbl(TxtPorcDescuentoGlobal.Text)
        Else
            Return CDbl(TxtPorcDesc.Text)
        End If
    End Function

    Private Sub IngresaArticulo()
        Dim Item As ListViewItem
        Dim Items(22) As String
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
                    .SubItems(ColumnasDetalle.Cantidad).Text = Format(CDbl(.SubItems(ColumnasDetalle.Cantidad).Text) + CDbl(TxtCantidad.Text), "##0.0000")
                    .SubItems(ColumnasDetalle.CantidadBonificada).Text = Format(CDbl(.SubItems(ColumnasDetalle.CantidadBonificada).Text) + CDbl(TxtBonificacion.Text), "##0.0000")
                Else
                    .SubItems(ColumnasDetalle.Cantidad).Text = Format(CDbl(TxtCantidad.Text), "##0.0000")
                    .SubItems(ColumnasDetalle.CantidadBonificada).Text = Format(CDbl(TxtBonificacion.Text), "##0.0000")
                    .SubItems(ColumnasDetalle.CantidadEscaneada).Text = "0.0000"
                End If
                .SubItems(ColumnasDetalle.Nombre).Text = InfoArticuloCompra.NombreArticulo
                .SubItems(ColumnasDetalle.Costo).Text = Format(CDbl(TxtCosto.Text), "##0.0000")

                If Accion = AccionDetalle.Nuevo Or Accion = AccionDetalle.Sumariza Then
                    .SubItems(ColumnasDetalle.PorcDescuento).Text = Format(DescuentoMayor(), "##0.0000")
                Else
                    .SubItems(ColumnasDetalle.PorcDescuento).Text = Format(CDbl(TxtPorcDesc.Text), "##0.0000")
                End If


                .SubItems(ColumnasDetalle.MontoDescuento).Text = Format(CDbl(.SubItems(ColumnasDetalle.Costo).Text) * (CDbl(.SubItems(ColumnasDetalle.PorcDescuento).Text) / 100), "##0.0000")
                If InfoArticuloCompra.ExentoIV Then
                    .SubItems(ColumnasDetalle.MontoIV).Text = "0.0000"
                Else
                    .SubItems(ColumnasDetalle.MontoIV).Text = Format(CalculaMontoImpuesto((CDbl(.SubItems(ColumnasDetalle.Costo).Text) - CDbl(.SubItems(ColumnasDetalle.MontoDescuento).Text)), InfoArticuloCompra.ArticuloImpuestos), "##0.0000")
                End If
                .SubItems(ColumnasDetalle.TotalLinea).Text = Format(((CDbl(.SubItems(ColumnasDetalle.Costo).Text) - CDbl(.SubItems(ColumnasDetalle.MontoDescuento).Text)) + CDbl(.SubItems(ColumnasDetalle.MontoIV).Text)) * CDbl(.SubItems(ColumnasDetalle.Cantidad).Text), "##0.0000")
                .SubItems(ColumnasDetalle.TotalLineaBonificacion).Text = Format(CDbl(.SubItems(ColumnasDetalle.Costo).Text) * CDbl(.SubItems(ColumnasDetalle.CantidadBonificada).Text), "##0.0000")

                .SubItems(ColumnasDetalle.PrecioIVI).Text = Format(RedondeaMontoCobro(CDbl(TxtPrecio.Text)), "##0.0000")

                If InfoArticuloCompra.ExentoIV Then
                    .SubItems(ColumnasDetalle.Precio).Text = Format(CDbl(.SubItems(ColumnasDetalle.PrecioIVI).Text), "##0.0000")
                Else
                    ' .SubItems(ColumnasDetalle.Precio).Text = Format(CDbl(.SubItems(ColumnasDetalle.PrecioIVI).Text) - RestaMontoImpuesto(CDbl(.SubItems(ColumnasDetalle.PrecioIVI).Text), InfoArticuloCompra.ArticuloImpuestos), "##0.000000")
                    .SubItems(ColumnasDetalle.Precio).Text = Format(CDbl(TxtPrecio.Text) - RestaMontoImpuesto(CDbl(TxtPrecio.Text), InfoArticuloCompra.ArticuloImpuestos), "###0.00")
                End If
                .SubItems(ColumnasDetalle.PorcUtilidad).Text = Format(CalculaUtilidad(CDbl(.SubItems(ColumnasDetalle.Costo).Text) - CDbl(.SubItems(ColumnasDetalle.MontoDescuento).Text), CDbl(.SubItems(ColumnasDetalle.Precio).Text)), "##0.0000")

                .SubItems(ColumnasDetalle.Maximo).Text = Format(CDbl(InfoArticuloCompra.Maximo), "##0.0000")
                .SubItems(ColumnasDetalle.Minimo).Text = Format(CDbl(InfoArticuloCompra.Minimo), "##0.0000")
                .SubItems(ColumnasDetalle.FactorConversion).Text = Format(CDbl(InfoArticuloCompra.FactorConversion), "##0.0000")
                .SubItems(ColumnasDetalle.PromedioVenta).Text = Format(CDbl(InfoArticuloCompra.PromedioVenta), "##0.0000")
                .SubItems(ColumnasDetalle.Exento).Text = InfoArticuloCompra.ExentoIV
                .SubItems(ColumnasDetalle.Suelto).Text = InfoArticuloCompra.Suelto
                .SubItems(ColumnasDetalle.CostoActual).Text = InfoArticuloCompra.Costo
                If Not EmpresaParametroInfo.Lote Then
                    InfoArticuloCompra.Lote = False
                End If
                .SubItems(ColumnasDetalle.LoteUU).Text = IIf(InfoArticuloCompra.Lote, "SI", "NO")
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

                If InfoArticuloCompra.Lote Then
                    _Lotes.Add(New TArticuloLote With
                    {
                        .Art_Id = InfoArticuloCompra.Art_Id,
                        .Nombre = InfoArticuloCompra.NombreArticulo,
                        .Cantidad = CDbl(TxtCantidad.Text),
                        .Escaneado = 0
                    })
                End If
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
            TxtDiasCredito.Enabled = False

            If _CargaAutomatica Then
                Me.Refresh()
                LvwDetalle.Refresh()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function CalculaUtilidad(pCosto As Double, pPrecio As Double) As Double
        Dim MontoUtilidad As Double = 0
        Dim PorceUtilidad As Double = 0
        Try


            If pCosto = 0 Then
                PorceUtilidad = 100
            Else
                MontoUtilidad = pPrecio - pCosto
                PorceUtilidad = (MontoUtilidad * 100) / pCosto
            End If


            Return PorceUtilidad

        Catch ex As Exception
            MensajeError(ex.Message)
            Return 0
        End Try
    End Function


    Private Function CalculaPrecio(pCosto As Double, pPorcentaje As Double, pExentoIV As Boolean, pImp As List(Of TInfoArticuloImpuesto)) As Double
        Dim MontoPrecio As Double = 0
        Try

            MontoPrecio = pCosto * (1 + (pPorcentaje / 100))

            If Not pExentoIV Then
                MontoPrecio = MontoPrecio + CalculaMontoImpuesto(MontoPrecio, pImp)
            End If

            Return MontoPrecio

        Catch ex As Exception
            MensajeError(ex.Message)
            Return 0
        End Try
    End Function

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


            If TxtOrden.Text.Trim = "" Then
                TxtProveedor.Enabled = (LvwDetalle.Items.Count = 0)
                TxtProveedorNombre.Enabled = (LvwDetalle.Items.Count = 0)
                TxtDiasCredito.Enabled = (LvwDetalle.Items.Count = 0)
            End If


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
            'TxtPorcUtilidad.Text = Format(CDbl(LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.PorcUtilidad).Text), "###0.00")
            TxtPrecio.Text = Format(CDbl(LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.PrecioIVI).Text), "###0.00")


            TxtCantidad.SelectAll()

            LvwDetalle.Tag = LvwDetalle.SelectedItems(0)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub CalculaTotales(ByRef pSubTotal As Double, ByRef pDescuento As Double, ByRef pImpuestoVenta As Double, ByRef pTotalCosto As Double, ByRef pTotalBonificacion As Double, ByRef pExento As Double, ByRef pGravado As Double)
        Try
            pSubTotal = 0
            pDescuento = 0
            pImpuestoVenta = 0
            pTotalCosto = 0
            pTotalBonificacion = 0
            pExento = 0
            pGravado = 0


            For Each Fila As ListViewItem In LvwDetalle.Items
                pSubTotal = pSubTotal + (CDbl(Fila.SubItems(ColumnasDetalle.Costo).Text) * CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text))
                pDescuento = pDescuento + (CDbl(Fila.SubItems(ColumnasDetalle.MontoDescuento).Text) * CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text))
                pImpuestoVenta = pImpuestoVenta + (CDbl(Fila.SubItems(ColumnasDetalle.MontoIV).Text) * CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text))
                pTotalCosto = pSubTotal + pImpuestoVenta - pDescuento
                pTotalBonificacion = pTotalBonificacion + CDbl(Fila.SubItems(ColumnasDetalle.TotalLineaBonificacion).Text)

                If Fila.SubItems(ColumnasDetalle.Exento).Text = 0 Then
                    pGravado = pGravado + (CDbl(Fila.SubItems(ColumnasDetalle.Costo).Text) * CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text))
                Else
                    pExento = pExento + (CDbl(Fila.SubItems(ColumnasDetalle.Costo).Text) * CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text))
                End If
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
        Dim Exento As Double = 0
        Dim Gravado As Double = 0
        Try

            LblSubTotal.Text = "0.00"
            LblDescuento.Text = "0.00"
            LblImpuestoVenta.Text = "0.00"
            LblTotalCosto.Text = "0.00"
            LblTotalBonificacion.Text = "0.00"

            CalculaTotales(SubTotal, Descuento, ImpuestoVenta, TotalCosto, TotalBonificacion, Exento, Gravado)

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
        Dim EntradaEncabezado As New TEntradaEncabezado(EmpresaParametroInfo.Emp_Id)
        Dim EntradaDetalle As TEntradaDetalle = Nothing
        Dim Mensaje As String = ""

        Dim SubTotal As Double = 0
        Dim Descuento As Double = 0
        Dim MontoIV As Double = 0
        Dim TotalCosto As Double = 0
        Dim TotalBonificacion As Double = 0

        Dim Detalle_Id As Integer = 0
        Dim Nuevo As Boolean = False

        Dim Exento As Double = 0
        Dim Gravado As Double = 0
        Try

            CalculaTotales(SubTotal, Descuento, MontoIV, TotalCosto, TotalBonificacion, Exento, Gravado)

            With EntradaEncabezado
                .Emp_Id = SucursalParametroInfo.Emp_Id
                .Suc_Id = SucursalParametroInfo.Suc_Id
                If TxtNumero.Text <> "" Then
                    .Entrada_Id = CLng(TxtNumero.Text)
                Else
                    Nuevo = True
                    .Entrada_Id = 0
                End If

                .Prov_Id = CInt(TxtProveedor.Text)
                .Bod_Id = SucursalParametroInfo.BodCompra_Id
                .EntradaEstado_Id = EntradaEstadoEnum.Pendiente
                .Fecha = DtpFecha.Value
                .AplicaFecha = DtpFecha.Value
                .Comentario = TxtComentario.Text.Trim
                .SubTotal = SubTotal
                .Descuento = Descuento
                .IV = MontoIV
                .Total = TotalCosto
                .TotalBonificacion = TotalBonificacion
                .Exento = Exento
                .Gravado = Gravado
                .Comprobante = TxtComprobante.Text
                .Usuario_Id = UsuarioInfo.Usuario_Id
                .Clave = TSSClave.Text
                If IsNumeric(TxtOrden.Text) Then
                    .Orden_Id = CLng(TxtOrden.Text)
                Else
                    .Orden_Id = 0
                End If
            End With

            For Each Item As ListViewItem In LvwDetalle.Items
                EntradaDetalle = New TEntradaDetalle(EmpresaInfo.Emp_Id)
                Detalle_Id = Detalle_Id + 1
                With EntradaDetalle
                    .Emp_Id = EntradaEncabezado.Emp_Id
                    .Suc_Id = EntradaEncabezado.Suc_Id
                    .Entrada_Id = EntradaEncabezado.Entrada_Id
                    .Detalle_Id = Detalle_Id
                    .Bod_Id = EntradaEncabezado.Bod_Id
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
                    .Fecha = EntradaEncabezado.Fecha
                    .Margen = CDbl(Item.SubItems(ColumnasDetalle.PorcUtilidad).Text)
                    .Precio = CDbl(Item.SubItems(ColumnasDetalle.Precio).Text)
                    .CantidadEscaneada = CDbl(Item.SubItems(ColumnasDetalle.CantidadEscaneada).Text)
                    If Not EmpresaParametroInfo.Lote Then

                        Item.SubItems(ColumnasDetalle.LoteUU).Text = "NO"

                    End If
                    .Lote = IIf(Item.SubItems(ColumnasDetalle.LoteUU).Text = "SI", 1, 0)

                    For Each impuesto As TInfoArticuloImpuesto In CType(Item.Tag, List(Of TInfoArticuloImpuesto))

                        .EntradaDetalleImpuesto.Add(New TEntradaDetalleImpuesto(EmpresaInfo.Emp_Id) With
                                                  {.Codigo_Id = impuesto.Codigo_Id,
                                                   .Tarifa_Id = impuesto.Tarifa_Id,
                                                   .Porcentaje = impuesto.Porcentaje,
                                                   .Cantidad = CDbl(Item.SubItems(ColumnasDetalle.Cantidad).Text),
                                                   .Monto = impuesto.Monto,
                                                   .Total = impuesto.Monto * CDbl(Item.SubItems(ColumnasDetalle.Cantidad).Text),
                                                   .Fecha = EntradaEncabezado.Fecha})

                    Next

                End With
                EntradaEncabezado.EntradaDetalles.Add(EntradaDetalle)
                EntradaEncabezado.Lotes = _Lotes
            Next


            EntradaEncabezado.EntradaFacturas = _EntradaFacturas

            Mensaje = EntradaEncabezado.GuardarDocumento()
            VerificaMensaje(Mensaje)


            If pAplicar Then
                EntradaEncabezado.AplicaUsuario_Id = pAplicaUsuario_Id

                Mensaje = EntradaEncabezado.AplicaEntrada()
                VerificaMensaje(Mensaje)


            End If



            If Nuevo Then
                MsgBox("Se generó la Entrada de Mercadería # " & EntradaEncabezado.Entrada_Id.ToString, MsgBoxStyle.Information, Me.Text)
            Else
                MsgBox("Los datos se almacenaron de manera correcta", MsgBoxStyle.Information, Me.Text)
            End If

            Inicializa()
            TxtNumero.Text = EntradaEncabezado.Entrada_Id.ToString
            TxtNumero.Focus()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            EntradaEncabezado = Nothing
        End Try
    End Sub

    Private Sub CargaOrdenCompra()
        Dim OrdenCompraEncabezado As New TOrdenCompraEncabezado(EmpresaInfo.Emp_Id)
        Dim OrdenCompraDetalle As New TOrdenCompraDetalle(EmpresaInfo.Emp_Id)
        Dim Item As ListViewItem = Nothing
        Dim Items(20) As String
        Dim OCImpuesto As List(Of TInfoArticuloImpuesto)
        Dim Mensaje As String = ""
        Dim Detalle_Id As Integer = 0

        Try

            With OrdenCompraEncabezado
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
                .Orden_Id = CLng(TxtOrden.Text)
            End With
            Mensaje = OrdenCompraEncabezado.ListKey()
            VerificaMensaje(Mensaje)

            If OrdenCompraEncabezado.RowsAffected = 0 Then
                TxtOrden.SelectAll()
                TxtOrden.Focus()
                MsgBox("El número de orden de compra no es válido", MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If


            Select Case OrdenCompraEncabezado.OrdenEstado_Id
                Case OrdenCompraEstadoEnum.Pendiente
                    TxtOrden.SelectAll()
                    TxtOrden.Focus()
                    MsgBox("No se puede cargar la orden debido a que esta aún no ha sido aplicada", MsgBoxStyle.Information, Me.Text)
                    Exit Sub
                Case OrdenCompraEstadoEnum.Cerrada
                    TxtOrden.SelectAll()
                    TxtOrden.Focus()
                    MsgBox("No se puede cargar la orden debido a que esta ya fue utilizada en otra entrada de mercadería", MsgBoxStyle.Information, Me.Text)
                    Exit Sub

            End Select

            With OrdenCompraDetalle
                .Emp_Id = OrdenCompraEncabezado.Emp_Id
                .Suc_Id = OrdenCompraEncabezado.Suc_Id
                .Orden_Id = CLng(TxtOrden.Text)
            End With
            Mensaje = OrdenCompraDetalle.List()
            VerificaMensaje(Mensaje)


            TxtOrden.Enabled = False

            'TxtNumero.Enabled = False

            'Encabezado
            'DtpFecha.Value = DateValue(OrdenCompraEncabezado.Fecha)
            'LblEstado.Text = OrdenCompraEncabezado.NombreEstado
            'TxtComentario.Text = OrdenCompraEncabezado.Comentario
            TxtProveedor.Text = OrdenCompraEncabezado.Prov_Id
            ValidaProveedor()
            TxtProveedor.Enabled = False

            'Detalle
            TxtArticulo.Text = ""
            InicializaArticulo()
            'LvwDetalle.Items.Clear()

            LblSubTotal.Text = "0.00"
            LblDescuento.Text = "0.00"
            LblImpuestoVenta.Text = "0.00"
            LblTotalCosto.Text = "0.00"
            LblTotalBonificacion.Text = "0.00"

            Detalle_Id = LvwDetalle.Items.Count

            For Each Fila As DataRow In OrdenCompraDetalle.Data.Tables("TablaDetalle").Rows


                Item = New ListViewItem(Items)


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
                    .SubItems(ColumnasDetalle.TotalLinea).Text = Format(CDbl(Fila("Costo")) * CDbl(Fila("Cantidad")), "##0.0000")
                    .SubItems(ColumnasDetalle.TotalLineaBonificacion).Text = Format(Fila("TotalLineaBonificada"), "##0.0000")


                    If Fila("ExentoIV") Then
                        .SubItems(ColumnasDetalle.PrecioIVI).Text = Format(CDbl(Fila("Precio")), "##0.00")
                    Else
                        .SubItems(ColumnasDetalle.PrecioIVI).Text = Format(CDbl(Fila("Precio")) + CalculaMontoImpuesto(CDbl(Fila("Precio")), OCImpuesto), "##0.00")
                    End If


                    .SubItems(ColumnasDetalle.Precio).Text = Format(CDbl(Fila("Precio")), "##0.00")


                    .SubItems(ColumnasDetalle.PorcUtilidad).Text = Format(CalculaUtilidad(CDbl(.SubItems(ColumnasDetalle.Costo).Text) - CDbl(.SubItems(ColumnasDetalle.MontoDescuento).Text), CDbl(.SubItems(ColumnasDetalle.Precio).Text)), "##0.00")

                    .SubItems(ColumnasDetalle.Maximo).Text = Format(Fila("Maximo"), "##0.00")
                    .SubItems(ColumnasDetalle.Minimo).Text = Format(Fila("Minimo"), "##0.00")
                    .SubItems(ColumnasDetalle.FactorConversion).Text = Format(Fila("FactorConversion"), "##0.00")
                    .SubItems(ColumnasDetalle.PromedioVenta).Text = Format(Fila("PromedioVenta"), "##0.00")
                    .SubItems(ColumnasDetalle.Exento).Text = IIf(Fila("ExentoIV"), -1, 0)
                    .SubItems(ColumnasDetalle.Suelto).Text = IIf(Fila("Suelto"), -1, 0)
                    .SubItems(ColumnasDetalle.CostoActual).Text = Fila("CostoActual")

                End With

                Item.Tag = OCImpuesto

                LvwDetalle.Items.Add(Item)

                Item.EnsureVisible()

            Next



            TxtArticulo.Focus()

            MuestraTotales()

        Catch ex As Exception
            MensajeError(ex.Message)
            Inicializa()
        Finally
            OrdenCompraEncabezado = Nothing
            OrdenCompraDetalle = Nothing
        End Try
    End Sub


    Private Sub CargaDocumento()
        Dim EntradaEncabezado As New TEntradaEncabezado(EmpresaInfo.Emp_Id)
        Dim EntradaDetalle As New TEntradaDetalle(EmpresaInfo.Emp_Id)
        Dim EntradaDetalleLote As New TEntradaDetalleLote(EmpresaInfo.Emp_Id)
        Dim EntradaFactura As New TEntradaFactura(EmpresaInfo.Emp_Id)
        Dim Factura As TEntradaFactura = Nothing
        Dim Item As ListViewItem = Nothing
        Dim Items(22) As String
        Dim Mensaje As String = ""
        Dim Detalle_Id As Integer = 0
        Dim EntradaImpuesto As List(Of TInfoArticuloImpuesto)
        Try

            _EntradaFacturas.Clear()

            With EntradaEncabezado
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
                .Entrada_Id = CLng(TxtNumero.Text)
            End With
            Mensaje = EntradaEncabezado.ListKey()
            VerificaMensaje(Mensaje)


            If EntradaEncabezado.RowsAffected = 0 Then
                TxtNumero.SelectAll()
                TxtNumero.Focus()
                VerificaMensaje("El número de entrada no es válido")
            End If


            With EntradaDetalle
                .Emp_Id = EntradaEncabezado.Emp_Id
                .Suc_Id = EntradaEncabezado.Suc_Id
                .Entrada_Id = CLng(TxtNumero.Text)
            End With
            Mensaje = EntradaDetalle.List()
            VerificaMensaje(Mensaje)

            With EntradaFactura
                .Emp_Id = EntradaEncabezado.Emp_Id
                .Suc_Id = EntradaEncabezado.Suc_Id
                .Entrada_Id = CLng(TxtNumero.Text)
            End With
            Mensaje = EntradaFactura.List()
            VerificaMensaje(Mensaje)

            With EntradaDetalleLote
                .Emp_Id = EntradaEncabezado.Emp_Id
                .Suc_Id = EntradaEncabezado.Suc_Id
                .Entrada_Id = CLng(TxtNumero.Text)
            End With
            VerificaMensaje(EntradaDetalleLote.LotesEntradaMercaderia)


            TxtNumero.Enabled = False


            'Encabezado
            If EntradaEncabezado.Orden_Id > 0 Then
                TxtOrden.Text = EntradaEncabezado.Orden_Id.ToString
            Else
                TxtOrden.Text = ""
            End If
            DtpFecha.Value = DateValue(EntradaEncabezado.Fecha)
            LblEstado.Text = EntradaEncabezado.NombreEstado
            TxtComentario.Text = EntradaEncabezado.Comentario
            TxtProveedor.Text = EntradaEncabezado.Prov_Id
            TxtComprobante.Text = EntradaEncabezado.Comprobante

            If EntradaEncabezado.Clave.Trim <> String.Empty Then
                TSSClaveTitulo.Visible = True
                TSSClave.Visible = True
                TSSClave.Text = EntradaEncabezado.Clave
            End If

            ValidaProveedor()

            'Detalle
            TxtArticulo.Text = ""
            InicializaArticulo()
            LvwDetalle.Items.Clear()

            LblSubTotal.Text = "0.0000"
            LblDescuento.Text = "0.0000"
            LblImpuestoVenta.Text = "0.0000"
            LblTotalCosto.Text = "0.00"
            LblTotalBonificacion.Text = "0.0000"

            For Each Fila As DataRow In EntradaDetalle.Data.Tables("TablaDetalle").Rows
                Item = New ListViewItem(Items)
                Detalle_Id = Detalle_Id + 1


                With Item
                    .SubItems(ColumnasDetalle.Linea).Text = Detalle_Id
                    .SubItems(ColumnasDetalle.Articulo).Text = Fila("Art_Id")
                    .SubItems(ColumnasDetalle.Cantidad).Text = Format(Fila("Cantidad"), "##0.0000")
                    .SubItems(ColumnasDetalle.CantidadBonificada).Text = Format(Fila("CantidadBonificada"), "##0.0000")
                    .SubItems(ColumnasDetalle.Nombre).Text = Fila("NombreArticulo")
                    .SubItems(ColumnasDetalle.Costo).Text = Format(Fila("Costo"), "##0.0000")
                    .SubItems(ColumnasDetalle.PorcDescuento).Text = Format(Fila("PorcDescuento"), "##0.0000")
                    .SubItems(ColumnasDetalle.MontoDescuento).Text = Format(Fila("MontoDescuento"), "##0.0000")
                    .SubItems(ColumnasDetalle.MontoIV).Text = Format(Fila("MontoIV"), "##0.0000")
                    .SubItems(ColumnasDetalle.TotalLinea).Text = Format(CDbl((Fila("Cantidad")) * CDbl(Fila("Costo")) + (CDbl(Fila("MontoIV")) * CDbl(Fila("Cantidad")))), "##0.0000")
                    .SubItems(ColumnasDetalle.TotalLineaBonificacion).Text = Format(Fila("TotalLineaBonificada"), "##0.0000")
                    .SubItems(ColumnasDetalle.PorcUtilidad).Text = Format(Fila("Margen"), "##0.0000")
                    .SubItems(ColumnasDetalle.Precio).Text = Format(Fila("Precio"), "##0.0000")

                    EntradaImpuesto = New List(Of TInfoArticuloImpuesto)
                    If Not Fila("ExentoIV") Then
                        For Each impuesto As DataRow In EntradaDetalle.Data.Tables("TablaImpuesto").Rows
                            If impuesto("Detalle_Id") = Fila("Detalle_Id") Then

                                EntradaImpuesto.Add(New TInfoArticuloImpuesto() With {
                            .Codigo_Id = impuesto("Codigo_Id"),
                            .Tarifa_Id = impuesto("Tarifa_Id"),
                            .Porcentaje = impuesto("Porcentaje"),
                            .Monto = impuesto("Monto")})
                            End If
                        Next
                    End If

                    If Fila("ExentoIV") Then
                        .SubItems(ColumnasDetalle.PrecioIVI).Text = Format(Fila("Precio"), "##0.0000")
                    Else
                        .SubItems(ColumnasDetalle.PrecioIVI).Text = Format(Fila("Precio") + CalculaMontoImpuesto(Fila("Precio"), EntradaImpuesto), "##0.0000")
                    End If

                    .SubItems(ColumnasDetalle.Maximo).Text = Format(Fila("Maximo"), "##0.0000")
                    .SubItems(ColumnasDetalle.Minimo).Text = Format(Fila("Minimo"), "##0.0000")
                    .SubItems(ColumnasDetalle.FactorConversion).Text = Format(Fila("FactorConversion"), "##0.0000")
                    .SubItems(ColumnasDetalle.PromedioVenta).Text = Format(Fila("PromedioVenta"), "##0.0000")
                    .SubItems(ColumnasDetalle.Exento).Text = IIf(Fila("ExentoIV"), -1, 0)
                    .SubItems(ColumnasDetalle.Suelto).Text = IIf(Fila("Suelto"), -1, 0)
                    .SubItems(ColumnasDetalle.CostoActual).Text = Fila("CostoActual")
                    .SubItems(ColumnasDetalle.CantidadEscaneada).Text = Format(Fila("CantidadEscaneada"), "##0.0000")
                    If Not EmpresaParametroInfo.Lote Then
                        Fila("Lote") = False
                    End If
                    .SubItems(ColumnasDetalle.LoteUU).Text = IIf(Fila("Lote"), "SI", "NO")

                End With

                Item.Tag = EntradaImpuesto
                LvwDetalle.Items.Add(Item)
                Item.EnsureVisible()
            Next


            'Carga las facturas asociadas a la entrada
            For Each Fila As DataRow In EntradaFactura.Data.Tables(0).Rows
                Factura = New TEntradaFactura(EntradaEncabezado.Emp_Id)
                With Factura
                    .Emp_Id = Fila("Emp_Id")
                    .Suc_Id = Fila("Suc_Id")
                    .Entrada_Id = Fila("Entrada_Id")
                    .Factura_Id = Fila("Factura_Id")
                    .Prov_Id = Fila("Prov_Id")
                    .Factura = Fila("Factura")
                    .Monto = Fila("Monto")
                    .FechaVencimiento = Fila("FechaVencimiento")
                    .Comentario = Fila("Comentario")
                    .Tipo_Id = Fila("Tipo_Id")
                    .TipoFacturaNombre = Fila("TipoFacturaNombre")
                    .UltimaModificacion = Fila("UltimaModificacion")
                End With
                _EntradaFacturas.Add(Factura)
            Next

            ' Lotes
            For Each Row As DataRow In EntradaDetalleLote.Data.Tables(0).Rows
                IngresaLote(Row("Art_Id"), Row("LoteCantidad"), Row("Lote"), Row("Vencimiento"))
            Next

            'Habilita o desabilita campos
            Select Case EntradaEncabezado.EntradaEstado_Id
                Case EntradaEstadoEnum.Aplicado
                    TxtOrden.Enabled = False
                    TxtProveedor.Enabled = False
                    TxtProveedorNombre.Enabled = False
                    TxtDiasCredito.Enabled = False
                    TxtComentario.Enabled = False
                    TxtPorcDescuentoGlobal.Enabled = False
                    PnLineaDetalle.Enabled = False
                    TxtComprobante.Enabled = False
                    HabilitaBotones(AccionEnum.Aplicado)
                Case EntradaEstadoEnum.Pendiente
                    TxtOrden.Enabled = Not (EntradaEncabezado.Orden_Id > 0)
                    TxtProveedor.Enabled = (LvwDetalle.Items.Count = 0)
                    TxtProveedorNombre.Enabled = (LvwDetalle.Items.Count = 0)
                    TxtDiasCredito.Enabled = (LvwDetalle.Items.Count = 0)
                    TxtComentario.Enabled = True
                    TxtPorcDescuentoGlobal.Enabled = True
                    PnLineaDetalle.Enabled = True
                    TxtComprobante.Enabled = True
                    HabilitaBotones(AccionEnum.Modificando)
                    TxtArticulo.Focus()
            End Select

            MuestraTotales()



        Catch ex As Exception
            MensajeError(ex.Message)
            Inicializa()
        Finally
            EntradaEncabezado = Nothing
            EntradaDetalle = Nothing
            EntradaFactura = Nothing
        End Try
    End Sub

    Private Sub IngresaLote(pArt_Id As String, pCantidad As Double, pLote As String, pVencimiento As Date)
        Dim EncontroArticulo As Boolean = False
        Dim EncontroLote As Boolean = False
        Dim TmpLote As TLote
        Dim TmpArticulo As TArticuloLote

        Try
            For Each ArticuloLote As TArticuloLote In _Lotes
                EncontroArticulo = False
                EncontroLote = False

                If ArticuloLote.Art_Id = pArt_Id Then
                    EncontroArticulo = True

                    For Each Lote As TLote In ArticuloLote.Lotes
                        If Lote.Lote = pLote AndAlso DateValue(Lote.Vencimiento) = DateValue(pVencimiento) Then
                            EncontroLote = True
                            Lote.Cantidad = Lote.Cantidad + pCantidad
                            Exit For
                        End If
                    Next

                    If Not EncontroLote Then
                        TmpLote = New TLote

                        With TmpLote
                            .Lote = pLote
                            .Vencimiento = pVencimiento
                            .Cantidad = pCantidad
                        End With

                        ArticuloLote.Lotes.Add(TmpLote)
                    End If

                    Exit For
                End If
            Next

            If Not EncontroArticulo And Not EncontroLote Then
                TmpLote = New TLote

                With TmpLote
                    .Lote = pLote
                    .Vencimiento = pVencimiento
                    .Cantidad = pCantidad
                End With

                TmpArticulo = New TArticuloLote

                With TmpArticulo
                    .Art_Id = pArt_Id
                    .Nombre = String.Empty
                    .Cantidad = 0
                    If pCantidad > 0 Then .Lotes.Add(TmpLote)
                End With

                _Lotes.Add(TmpArticulo)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub BuscarDocumento()
        Dim Forma As New FrmBusquedaEntrada
        Try

            If Not TxtNumero.Enabled Then
                Exit Sub
            End If

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
        Dim EntradaEncabezado As New TEntradaEncabezado(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            With EntradaEncabezado
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
                .Entrada_Id = CLng(TxtNumero.Text)
                If IsNumeric(TxtOrden.Text) Then
                    .Orden_Id = CLng(TxtOrden.Text)
                End If
            End With

            Mensaje = EntradaEncabezado.EliminarDocumento()
            VerificaMensaje(Mensaje)

            Inicializa()
            TxtNumero.Focus()


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            EntradaEncabezado = Nothing
        End Try
    End Sub

    Private Sub CargaArticulos()
        Dim Forma As New FrmCargaArticulos
        Try


            If TxtProveedor.Text.Trim = "" OrElse Not IsNumeric(TxtProveedor.Text) Then
                TxtProveedor.Focus()
                VerificaMensaje("Debe de ingresar el código de proveedor")
            End If

            If Not ValidaProveedor() Then
                TxtProveedor.Focus()
                VerificaMensaje("Debe de ingresar el código de proveedor")
            End If

            With Forma
                .Suc_Id = SucursalInfo.Suc_Id
                .ValidaSueltos = True
                .VerificaBodega = True
                .Bod_Id = SucursalParametroInfo.BodCompra_Id
                .Execute()
            End With

            If Not Forma.Guardo Then
                Exit Sub
            End If

            For Each conteo As TArticuloConteo In Forma.ListaConteo
                TxtArticulo.Text = conteo.Art_Id
                ValidaArticulo(TxtArticulo.Text, False)
                TxtCantidad.Text = conteo.Cantidad
                IngresaArticulo()
            Next

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
            Case Keys.F10
                BtnFacturas.PerformClick()
            Case Keys.F11
                BtnLotes.PerformClick()
            Case Keys.F12
                'BtnCargaArticulos.PerformClick()
                BtnUtilidades.ShowDropDown()
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
        'Dim Forma As New FrmBusquedaArticuloOnLine
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
                'Case Keys.F1
                '    BuscarArticulo()
                'Case Keys.F2
                '    If LvwDetalle.Items.Count > 0 Then
                '        If LvwDetalle.SelectedItems.Count = 0 Then
                '            LvwDetalle.Items(0).Selected = True
                '        End If
                '        LvwDetalle.Focus()
                '    End If
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
                    TxtPrecio.Focus()
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
                    TxtCostoActual.Text = ""
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

    Private Sub BtnModificar_Click(sender As System.Object, e As System.EventArgs) Handles BtnModificar.Click
        Guardar(False)
    End Sub
    Private Sub BtnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles BtnBuscar.Click
        Select Case Me.ActiveControl.Name
            Case "TxtNumero"
                BuscarDocumento()
            Case "TxtArticulo"
                BuscarArticulo()
            Case "TxtOrden"
                BuscarOrdenCompra()
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

            If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.ComAplicaEntradaMercaderia, False) Then
                VerificaMensaje("No tiene permiso para aplicar entradas de mercadería")
            End If

            If MsgBox("Desea aplicar el movimiento?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                Guardar(True)
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

    Private Function ValidaFacturaProveedor() As String
        Dim EntradaFactura As New TEntradaFactura(SucursalParametroInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            With EntradaFactura
                .Emp_Id = SucursalParametroInfo.Emp_Id
                .Suc_Id = SucursalParametroInfo.Suc_Id
                If IsNumeric(TxtNumero.Text) Then
                    .Entrada_Id = CLng(TxtNumero.Text)
                Else
                    .Entrada_Id = 0
                End If

            End With

            For Each Factura As TEntradaFactura In _EntradaFacturas
                EntradaFactura.Prov_Id = CInt(TxtProveedor.Text)
                EntradaFactura.Factura = Factura.Factura
                Mensaje = EntradaFactura.ValidaFacturaProveedor()
                VerificaMensaje(Mensaje)
            Next


            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            EntradaFactura = Nothing
        End Try
    End Function

    Private Function Validatodo(pAplicar As Boolean)
        Dim OrdenCompraEncabezado As New TOrdenCompraEncabezado(EmpresaInfo.Emp_Id)
        Try

            If LvwDetalle.Items.Count = 0 Then
                VerificaMensaje("Debe de ingresar al menos una linea")
            End If


            For Each Fila As ListViewItem In LvwDetalle.Items
                If CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text) < 0 Then
                    LvwDetalle.SelectedIndices.Clear()
                    Fila.EnsureVisible()
                    Fila.Selected = True
                    VerificaMensaje("La cantidad debe de ser mayor a cero")
                End If

                If CDbl(Fila.SubItems(ColumnasDetalle.Costo).Text) <= 0 Then
                    LvwDetalle.SelectedIndices.Clear()
                    Fila.EnsureVisible()
                    Fila.Selected = True
                    VerificaMensaje("El monto del costo debe de ser mayor a cero")
                End If
            Next


            If pAplicar Then
                If _EntradaFacturas.Count = 0 And EmpresaParametroInfo.InterfazCxP Then
                    Mensaje("Debe asociar una factura al menos a esta entrada de mercadería")
                    Facturas()
                    If _EntradaFacturas.Count = 0 Then
                        VerificaMensaje("No se indicó ninguna factura")
                    End If
                End If
            End If

            If IsNumeric(TxtOrden.Text) Then
                With OrdenCompraEncabezado
                    .Emp_Id = SucursalInfo.Emp_Id
                    .Suc_Id = SucursalInfo.Suc_Id
                    .Orden_Id = CLng(TxtOrden.Text)
                End With
                VerificaMensaje(OrdenCompraEncabezado.ListKey())
                If OrdenCompraEncabezado.RowsAffected = 0 Then
                    VerificaMensaje("El número de orden de compra no es válido")
                End If
            End If

            If TxtProveedor.Text.Trim = "" Then
                VerificaMensaje("Código de proveedor no válido")
            End If

            If Not ValidaProveedor() Then
                VerificaMensaje("Código de proveedor no válido")
            End If


            If TxtComprobante.Text <> "" Then
                Dim entrada As New TEntradaEncabezado(EmpresaInfo.Emp_Id)
                With entrada
                    .Comprobante = TxtComprobante.Text
                    .Prov_Id = TxtProveedor.Text
                End With
                Dim Mensaje As String = entrada.VerificaComprobanteRegistrado()

                If Mensaje <> "" Then
                    If MessageBox.Show("El comprobante ya fue registrado anteriormente. ¿Desea continuar con el guardado?", "Alerta", MessageBoxButtons.YesNo) = DialogResult.No Then
                        VerificaMensaje("Comprobante " & TxtComprobante.Text & ", Ya fue registrado anteriormente.")
                    End If
                End If
            End If

            'Verifica las facturas x proveedor
            VerificaMensaje(ValidaFacturaProveedor())


            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        Finally
            OrdenCompraEncabezado = Nothing
        End Try
    End Function

    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimir.Click
        Imprimir()
    End Sub
    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim EntradaEncabezado As New TEntradaEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte As New EntradaMercaderia
        Dim FormaReporte As New FrmReporte
        Try

            Cursor.Current = Cursors.WaitCursor
            BtnImprimir.Enabled = False

            With EntradaEncabezado
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
                .Entrada_Id = CLng(TxtNumero.Text)
            End With

            Mensaje = EntradaEncabezado.RptEntradaMercaderia()
            VerificaMensaje(Mensaje)

            If EntradaEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(EntradaEncabezado.Data.Tables(0))


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
            EntradaEncabezado = Nothing
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
    Private Sub Guardar(pAplicar As Boolean)
        Try
            Me.Cursor = Cursors.WaitCursor

            If Validatodo(pAplicar) Then
                GuardarDocumento(pAplicar, IIf(pAplicar, UsuarioInfo.Usuario_Id, ""))
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
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
            TxtDiasCredito.Text = Proveedor.DiasCredito
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
        TxtDiasCredito.Text = ""
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
    Private Sub TxtOrden_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtOrden.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If TxtOrden.Text.Trim = "" Then
                    TxtProveedor.Focus()
                ElseIf IsNumeric(TxtOrden.Text) Then
                    CargaOrdenCompra()
                End If
        End Select
    End Sub
    Private Sub BuscarOrdenCompra()
        Dim Forma As New FrmBusquedaOrdenCompra
        Try

            If Not TxtOrden.Enabled Then
                Exit Sub
            End If

            Forma.SoloAplicadas = True
            Forma.Execute()
            If Forma.Selecciono Then
                TxtOrden.Text = Forma.Numero_Id
                CargaOrdenCompra()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Sub Facturas()
        Dim Forma As New FrmEntradaFactura
        Try



            If Not IsNumeric(TxtDiasCredito.Text) Then
                VerificaMensaje("Debe de seleccionar el proveedor para poder ingresar facturas")
            End If

            With Forma
                .EntradaFacturas = _EntradaFacturas
                .TotalEntrada = IIf(IsNumeric(LblTotalCosto.Text), CDbl(LblTotalCosto.Text), 0)
                .DiasCredito = IIf(IsNumeric(TxtDiasCredito.Text), CDbl(TxtDiasCredito.Text), 0)
            End With


            Forma.Execute()
            _EntradaFacturas = Forma.EntradaFacturas

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Sub BtnFacturas_Click(sender As System.Object, e As System.EventArgs) Handles BtnFacturas.Click
        Facturas()
    End Sub
    Private Sub TxtPrecio_GotFocus(sender As Object, e As System.EventArgs) Handles TxtPrecio.GotFocus
        TxtPrecio.SelectAll()
    End Sub

    Private Sub TxtPrecio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtPrecio.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If ValidaCosto() AndAlso ValidaPrecio() Then
                    TxtPorcDesc.Focus()
                End If
            Case Keys.Escape
                If TxtPrecio.Enabled AndAlso Not TxtPrecio.ReadOnly Then
                    InicializaArticulo()
                    TxtArticulo.Text = ""
                    TxtArticulo.Focus()
                End If
        End Select
    End Sub

    Private Sub TxtCosto_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCosto.TextChanged
        Try

            If Not IsNumeric(TxtCosto.Text) OrElse CDbl(TxtCosto.Text) <= 0 Then
                Exit Sub
            End If

            If InfoMaquina.RecalculaPrecioEntradaMercaderia Then
                TxtPrecio.Text = Format(CalculaPrecio(CDbl(TxtCosto.Text), CDbl(TxtPorcUtilidad.Text), InfoArticuloCompra.ExentoIV, InfoArticuloCompra.ArticuloImpuestos), "###0.00")
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CrearArticuloSuelto()
        Dim Forma As New FrmCreaArticuloSuelto
        Try
            If Not TxtArticulo.Enabled OrElse LvwDetalle.Items.Count = 0 OrElse Not PnLineaDetalle.Enabled OrElse LvwDetalle.SelectedItems.Count = 0 Then
                Exit Sub
            End If

            With Forma
                .ArticuloPadre = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Articulo).Text
                .FactorConversion = CInt(LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.FactorConversion).Text)
                .Precio = CDbl(LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.PrecioIVI).Text)
            End With

            Forma.Execute()

            TxtArticulo.Focus()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
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

    Private Sub MnuCrearArticuloSuelto_Click(sender As System.Object, e As System.EventArgs) Handles MnuCrearArticuloSuelto.Click
        CrearArticuloSuelto()
    End Sub

    Private Sub BtnCargaArticulos_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub MnuConsultar_Click(sender As Object, e As EventArgs) Handles MnuConsultar.Click
        ConsultarArticulo()
    End Sub

    'Private Function RestaMontoImpuesto(pMonto As Double, pArticuloImpuestos As List(Of TInfoArticuloImpuesto)) As Double
    '    Dim OtrosImpuestos As Double = 0
    '    Dim TotalImpuesto As Double = 0
    '    Dim TotalPorcentaje As Double = 0


    '    For Each impuesto As TInfoArticuloImpuesto In pArticuloImpuestos
    '        If impuesto.Codigo_Id = coImpuesto01 OrElse impuesto.Codigo_Id = coImpuesto12 Then
    '            TotalPorcentaje += impuesto.Porcentaje
    '        End If
    '    Next

    '    TotalImpuesto = pMonto - (pMonto / (1 + (TotalPorcentaje / 100)))

    '    For Each impuesto As TInfoArticuloImpuesto In pArticuloImpuestos
    '        If impuesto.Codigo_Id <> coImpuesto01 And impuesto.Codigo_Id <> coImpuesto12 Then
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
    'Private Function CalculaMontoImpuestoOC(pLinea As Integer, pMonto As Double, ByRef pArticuloImpuestos As List(Of TOrdenCompraDetalleImpuesto)) As Double
    '    Dim OtrosImpuestos As Double = 0
    '    Dim TotalImpuesto As Double = 0

    '    For Each impuesto As TOrdenCompraDetalleImpuesto In pArticuloImpuestos
    '        If impuesto.Codigo_Id <> coImpuesto01 And impuesto.Codigo_Id <> coImpuesto12 Then
    '            With impuesto
    '                .Detalle_Id = pLinea
    '                .Monto = pMonto * (impuesto.Porcentaje / 100)
    '            End With
    '            OtrosImpuestos += impuesto.Monto
    '        End If
    '    Next

    '    For Each impuesto As TOrdenCompraDetalleImpuesto In pArticuloImpuestos
    '        If impuesto.Codigo_Id = coImpuesto01 OrElse impuesto.Codigo_Id = coImpuesto12 Then
    '            With impuesto
    '                .Detalle_Id = pLinea
    '                .Monto = (pMonto + OtrosImpuestos) * (impuesto.Porcentaje / 100)
    '            End With
    '            TotalImpuesto += impuesto.Monto
    '        End If
    '    Next

    '    Return TotalImpuesto + OtrosImpuestos

    'End Function


    'Private Function CalculaMontoImpuestoML(pMonto As Double, pArticuloImpuestos As List(Of TOrdenCompraDetalleImpuesto)) As Double
    '    Dim OtrosImpuestos As Double = 0
    '    Dim TotalImpuesto As Double = 0


    '    For Each impuesto As TOrdenCompraDetalleImpuesto In pArticuloImpuestos
    '        If impuesto.Codigo_Id <> coImpuesto01 And impuesto.Codigo_Id <> coImpuesto12 Then
    '            With impuesto
    '                .Detalle_Id = 1
    '                .Monto = pMonto * (impuesto.Porcentaje / 100)
    '            End With
    '            OtrosImpuestos += impuesto.Monto
    '        End If
    '    Next

    '    For Each impuesto As TOrdenCompraDetalleImpuesto In pArticuloImpuestos
    '        If impuesto.Codigo_Id = coImpuesto01 OrElse impuesto.Codigo_Id = coImpuesto12 Then
    '            With impuesto
    '                .Detalle_Id = 1
    '                .Monto = (pMonto + OtrosImpuestos) * (impuesto.Porcentaje / 100)
    '            End With
    '            TotalImpuesto += impuesto.Monto
    '        End If
    '    Next

    '    Return TotalImpuesto + OtrosImpuestos

    'End Function

    Private Sub BtnDesaplicarEntrada_Click(sender As Object, e As EventArgs) Handles BtnDesaplicarEntrada.Click
        AnularCompra()
    End Sub


    Private Sub AnularCompra()
        Dim MovimientoEncabezado As New TMovimientoEncabezado(EmpresaInfo.Emp_Id)
        Dim MovimientoDetalle As TMovimientoDetalle = Nothing
        Dim Mensaje As String = ""
        Dim Costo As Double = 0
        Dim Detalle_Id As Integer = 0
        Dim Factor As Integer = 1
        Dim Nuevo As Boolean = False
        Dim entrada As TEntradaEncabezado
        Dim confirmacion As New FrmPregunta()
        Try

            confirmacion.Pregunta = "¿Desea anular la entrada de mercadería?"
            confirmacion.Execute()

            If Not confirmacion.Respuesta Then
                VerificaMensaje("Anulación cancelada.")
            End If

            If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.ComAnulaEntradaMercaderia, False) Then
                VerificaMensaje("No tiene permiso para anular entradas de mercadería")
            End If


            Factor = -1


            With MovimientoEncabezado
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
                .TipoMov_Id = 3
                Nuevo = True
                .Mov_Id = 0
                .Bod_Id = SucursalParametroInfo.BodCompra_Id
                .Fecha = Now
                .Comentario = "Ajuste de resta producto de la anulación de la compra " & TxtNumero.Text
                .Costo = LblTotalCosto.Text * Factor
                .Aplicado = 0
                .Usuario_Id = UsuarioInfo.Usuario_Id
                .Suc_Id_Destino = 0
                .Bod_Id_Destino = 0
            End With

            For Each Item As ListViewItem In LvwDetalle.Items
                MovimientoDetalle = New TMovimientoDetalle(SucursalInfo.Emp_Id)
                Detalle_Id = Detalle_Id + 1
                With MovimientoDetalle
                    .Suc_Id = SucursalInfo.Suc_Id
                    .TipoMov_Id = 3
                    .Mov_Id = MovimientoEncabezado.Mov_Id
                    .Detalle_Id = Detalle_Id
                    .Art_Id = Item.SubItems(ColumnasDetalle.Articulo).Text
                    .Cantidad = CDbl(Item.SubItems(ColumnasDetalle.Cantidad).Text) * Factor
                    .Costo = CDbl(Item.SubItems(ColumnasDetalle.Costo).Text)
                    .TotalLinea = CDbl(Item.SubItems(ColumnasDetalle.TotalLinea).Text)
                    .Suelto = IIf(Item.SubItems(ColumnasDetalle.Suelto).Text.ToLower = "si", 1, 0)
                    .Fecha = DtpFecha.Value
                End With
                MovimientoEncabezado.ListaDetalles.Add(MovimientoDetalle)
            Next

            MovimientoEncabezado.AplicaUsuario_Id = UsuarioInfo.Usuario_Id

            entrada = New TEntradaEncabezado(EmpresaInfo.Emp_Id)
            entrada.Suc_Id = SucursalParametroInfo.BodCompra_Id
            entrada.Entrada_Id = TxtNumero.Text
            VerificaMensaje(entrada.AnulaCompra(MovimientoEncabezado))

            MensajeError("Se anulo la compra # " & TxtNumero.Text)

            Inicializa()
            TxtNumero.Focus()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            MovimientoEncabezado = Nothing
        End Try
    End Sub

    Private Sub RecalculaDescuento()
        Dim PorcDesc As Double = 0
        Try

            PorcDesc = CDbl(TxtPorcDescuentoGlobal.Text)

            For Each item As ListViewItem In LvwDetalle.Items
                item.SubItems(ColumnasDetalle.PorcDescuento).Text = Format(PorcDesc, "##0.0000")
                item.SubItems(ColumnasDetalle.MontoDescuento).Text = Format(CDbl(item.SubItems(ColumnasDetalle.Costo).Text) * (CDbl(item.SubItems(ColumnasDetalle.PorcDescuento).Text) / 100), "##0.0000")

                If CBool(item.SubItems(ColumnasDetalle.Exento).Text) Then
                    item.SubItems(ColumnasDetalle.MontoIV).Text = "0.0000"
                Else
                    item.SubItems(ColumnasDetalle.MontoIV).Text = Format(CalculaMontoImpuesto((CDbl(item.SubItems(ColumnasDetalle.Costo).Text) - CDbl(item.SubItems(ColumnasDetalle.MontoDescuento).Text)), CType(item.Tag, List(Of TInfoArticuloImpuesto))), "##0.0000")
                End If
                item.SubItems(ColumnasDetalle.TotalLinea).Text = Format(((CDbl(item.SubItems(ColumnasDetalle.Costo).Text) - CDbl(item.SubItems(ColumnasDetalle.MontoDescuento).Text)) + CDbl(item.SubItems(ColumnasDetalle.MontoIV).Text)) * CDbl(item.SubItems(ColumnasDetalle.Cantidad).Text), "##0.0000")
                item.SubItems(ColumnasDetalle.PorcUtilidad).Text = Format(CalculaUtilidad(CDbl(item.SubItems(ColumnasDetalle.Costo).Text) - CDbl(item.SubItems(ColumnasDetalle.MontoDescuento).Text), CDbl(item.SubItems(ColumnasDetalle.Precio).Text)), "##0.0000")

            Next


            MuestraTotales()

            If TxtArticulo.Enabled Then
                TxtArticulo.Select()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtPorcDescuentoGlobal_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtPorcDescuentoGlobal.KeyDown
        Try

            If e.KeyCode = Keys.Enter AndAlso IsNumeric(TxtPorcDescuentoGlobal.Text) AndAlso CDbl(TxtPorcDescuentoGlobal.Text) >= 0 AndAlso LvwDetalle.Items.Count > 0 Then
                If ConfirmaAccion("Desea aplicar el % de descuento indicado a todo el documento?") Then
                    RecalculaDescuento()
                End If
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnCargaXML_Click(sender As Object, e As EventArgs)
        Dim Forma As New FrmCargaFacturaElectronica
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Public Function VerificaArticulo(pArt_Id As String) As String
        Try
            For Each Item As ListViewItem In LvwDetalle.Items
                If Item.SubItems(ColumnasDetalle.Articulo).Text = String.Empty Then
                    Exit For
                End If

                If Item.SubItems(ColumnasDetalle.Articulo).Text = pArt_Id Then
                    Item.EnsureVisible()
                    LvwDetalle.SelectedItems.Clear()
                    Item.Selected = True
                    Return String.Empty
                End If
            Next

            Return "El articulo no se encuentra en la entrada de mercaderia"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Sub LoteDetalle(pArt_Id As String)
        Dim Forma As New FrmLoteIngreso

        Try
            If _Lotes.Count = 0 Then
                VerificaMensaje("No existe información de lotes")
            End If

            For Each item As ListViewItem In LvwDetalle.Items
                For Each ArticuloLote As TArticuloLote In _Lotes
                    If item.SubItems(ColumnasDetalle.Articulo).Text = ArticuloLote.Art_Id Then
                        With ArticuloLote
                            .Nombre = item.SubItems(ColumnasDetalle.Nombre).Text
                            .Cantidad = 0
                            If IsNumeric(item.SubItems(ColumnasDetalle.Cantidad).Text) Then
                                .Cantidad += item.SubItems(ColumnasDetalle.Cantidad).Text
                            End If
                            If IsNumeric(item.SubItems(ColumnasDetalle.CantidadBonificada).Text) Then
                                .Cantidad += item.SubItems(ColumnasDetalle.CantidadBonificada).Text
                            End If
                            '.Escaneado = item.SubItems(ColumnasDetalle.CantidadEscaneada).Text
                        End With
                        Exit For
                    End If
                Next
            Next

            Forma.ArtActual_Id = pArt_Id

            Forma.Execute(_Lotes)
            ActualizaDesdeLotes()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Public Sub ActualizaDesdeLotes()
        'Recorre los articulos despues de el mantenimiento de articulos con lote.
        For Each Articulo In _Lotes
            'Busca y compara con el listView de la ventana.
            For Each item As ListViewItem In LvwDetalle.Items

                If item.SubItems(ColumnasDetalle.Articulo).Text = Articulo.Art_Id Then

                    'Sumariza la cantidades en los lotes y la establece en el ListView.
                    Dim cantidad As Double = 0

                    For Each lote In Articulo.Lotes
                        cantidad = cantidad + lote.Cantidad
                    Next

                    'item.SubItems(ColumnasDetalle.CantidadEscaneada).Text = Format(cantidad, "##0.00")
                End If
            Next
        Next

        'MarcaLineasCantidadEscaneado()
        MuestraTotales()

    End Sub
    Private Sub MarcaLineasCantidadEscaneado()
        Dim CantidadLinea As Double = 0

        Try
            For Each item As ListViewItem In LvwDetalle.Items
                If EmpresaParametroInfo.EscaneaEntradaMercaderia OrElse item.SubItems(ColumnasDetalle.LoteUU).Text = "SI" Then
                    CantidadLinea = CDbl(item.SubItems(ColumnasDetalle.Cantidad).Text) + CDbl(item.SubItems(ColumnasDetalle.CantidadBonificada).Text)

                    If CantidadLinea = CDbl(item.SubItems(ColumnasDetalle.CantidadEscaneada).Text) Then
                        ListViewCambiaColorFilaTexto(item, coColorEscaneoIgual)
                    ElseIf CantidadLinea < CDbl(item.SubItems(ColumnasDetalle.CantidadEscaneada).Text) Then
                        ListViewCambiaColorFilaTexto(item, coColorEscaneoMayor)
                    Else
                        ListViewCambiaColorFilaTexto(item, coColorEscaneoMenor)
                    End If
                End If

            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub BtnCargarArchivoArticulos_Click(sender As Object, e As EventArgs) Handles BtnCargarArchivoArticulos.Click
        CargaArticulos()
    End Sub


    Private Sub BtnCreacionDeArticulos_Click(sender As Object, e As EventArgs) Handles BtnCreacionDeArticulos.Click
        Dim Forma As New FrmMantArticuloDetalle
        Try

            If VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.ComMantenimientodeArticulos, True) Then
                Forma.Execute()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Sub EscaneoMercaderia()
        Dim Forma As New FrmEntradaEscaneo
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Public Function IngresaEscaneoArticulo(pArt_Id As String, pCantidad As Double, pLote As String, pVencimiento As Date) As String
        Dim Encontro As Boolean = False
        Dim CantidadEscaneada As Double = 0
        Dim CantidadSolicitada As Double = 0

        Try
            For Each Item As ListViewItem In LvwDetalle.Items
                If Item.SubItems(ColumnasDetalle.Articulo).Text = pArt_Id Then
                    CantidadSolicitada = CDbl(Item.SubItems(ColumnasDetalle.Cantidad).Text)
                    CantidadEscaneada = CDbl(Item.SubItems(ColumnasDetalle.CantidadEscaneada).Text)

                    If CantidadSolicitada < CantidadEscaneada + pCantidad Then
                        VerificaMensaje("La cantidad indicada supera a la cantidad solicitada en la entrada de mercadería")
                    End If

                    Item.SubItems(ColumnasDetalle.CantidadEscaneada).Text = Format(CDbl(Item.SubItems(ColumnasDetalle.CantidadEscaneada).Text) + pCantidad, "##0.0000")
                    Item.EnsureVisible()
                    LvwDetalle.SelectedItems.Clear()
                    Item.Selected = True
                    Encontro = True
                    Exit For
                End If
            Next

            If Encontro And pLote <> String.Empty Then
                IngresaLote(pArt_Id, pCantidad, pLote, pVencimiento)
            End If

            MarcaLineasCantidadEscaneado()
            MuestraTotales()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Private Sub BtnLotes_Click(sender As Object, e As EventArgs) Handles BtnLotes.Click
        Try
            If LvwDetalle.Items.Count = 0 Then
                VerificaMensaje("No se han ingresado productos")
            End If

            If Not PnLineaDetalle.Enabled OrElse Not TxtArticulo.Enabled Then
                Exit Sub
            End If


            LoteDetalle("")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnEscaneo_Click(sender As Object, e As EventArgs) Handles BtnEscaneo.Click
        EscaneoMercaderia()
    End Sub

    Private Sub TxtCantidad_TextChanged(sender As Object, e As EventArgs) Handles TxtCantidad.TextChanged

    End Sub
End Class