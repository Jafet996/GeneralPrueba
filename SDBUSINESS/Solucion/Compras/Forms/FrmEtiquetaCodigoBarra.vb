Imports Business
Public Class FrmEtiquetaCodigoBarra
    Dim Numerico() As TNumericFormat

    Private Enum ColumnasDetalle
        Articulo = 0
        Descripcion = 1
        Exento = 2
        Precio = 3
        Cantidad = 4
    End Enum

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtCantidad, 4, 0, False, "", "###0")


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ConfiguraDetalle()
        Try
            With LvwDetalle
                .Columns(ColumnasDetalle.Articulo).Text = "Artículo"
                .Columns(ColumnasDetalle.Articulo).Width = 120
                .Columns(ColumnasDetalle.Articulo).TextAlign = HorizontalAlignment.Left

                .Columns(ColumnasDetalle.Descripcion).Text = "Descripción"
                .Columns(ColumnasDetalle.Descripcion).Width = 300
                .Columns(ColumnasDetalle.Descripcion).TextAlign = HorizontalAlignment.Left

                .Columns(ColumnasDetalle.Exento).Text = "Exento"
                .Columns(ColumnasDetalle.Exento).Width = 60
                .Columns(ColumnasDetalle.Exento).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasDetalle.Precio).Text = "Precio"
                .Columns(ColumnasDetalle.Precio).Width = 100
                .Columns(ColumnasDetalle.Precio).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.Cantidad).Text = "Cantidad"
                .Columns(ColumnasDetalle.Cantidad).Width = 100
                .Columns(ColumnasDetalle.Cantidad).TextAlign = HorizontalAlignment.Right
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargaCombos()
        Dim Bodega As New TBodega(EmpresaInfo.Emp_Id)
        Dim EtiquetaTipo As New TEtiquetaTipo
        Dim Mensaje As String = ""
        Try

            With Bodega
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
            End With

            Mensaje = Bodega.LoadComboBox(CmbBodega)
            VerificaMensaje(Mensaje)

            Mensaje = EtiquetaTipo.LoadComboBox(CmbEtiqueta)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Bodega = Nothing
            EtiquetaTipo = Nothing
        End Try
    End Sub

    Public Sub Execute()
        Try

            CargaCombos()
            ConfiguraDetalle()
            BuscaNombreImpresora()
            CmbEtiqueta.SelectedIndex = 0

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub BuscarArticulo()
        Dim Forma As New FrmBusquedaArticuloOnLine
        Try

            With Forma
                .Suc_Id = SucursalInfo.Suc_Id
                .Bod_Id = CInt(CmbBodega.SelectedValue)
            End With

            Forma.Execute()
            If Forma.Art_Id.Trim <> "" Then
                TxtArticulo.Text = Forma.Art_Id
                CargaDatos()
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Sub FrmEtiquetaCodigoBarra_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1 And BtnBuscar.Enabled
                Select Case Me.ActiveControl.Name
                    Case "TxtArticulo"
                        BuscarArticulo()
                End Select
                'Case Keys.F2 And BtnNuevo.Enabled
                '    Nuevo()
                'Case Keys.F3 And BtnModificar.Enabled
                '    Guardar()
                'Case Keys.F4 And BtnAplicar.Enabled
                '    Aplicar()
            Case Keys.F5
                BtnPrecios.PerformClick()
                'Case Keys.F6 And BtnCancelar.Enabled
                '    Limpiar()
                'Case Keys.F7 And BtnImprimir.Enabled
                '    Imprimir()
                'Case Keys.F8 And BtnSaldos.Enabled
                '    ConsultarArticulo()
                'Case Keys.F9 And BtnSalir.Enabled
                '    Salir()
                'Case Keys.F10 And BtnSugerir.Enabled
        End Select
    End Sub

    Private Sub BuscaNombreImpresora()
        LblImpresora.Text = ImpresoraPredeterminada()
    End Sub

    Private Sub FrmEtiquetaCodigoBarra_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FormateaCamposNumericos()
        TxtArticulo.Select()
    End Sub

    Private Sub TxtArticulo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtArticulo.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If TxtArticulo.Text.Trim <> "" Then
                    CargaDatos()
                End If
        End Select
    End Sub
    Private Sub CargaDatos()
        Dim InfoArticulo As New TInfoAticuloCompra(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            TxtArticulo.Text = QuitaComillas(TxtArticulo.Text)


            With InfoArticulo
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
                .Bod_Id = CmbBodega.SelectedValue
                .Art_Id = TxtArticulo.Text.Trim
            End With

            Mensaje = InfoArticulo.ConsultaArticulo()
            VerificaMensaje(Mensaje)

            If InfoArticulo.RowsAffected = 0 Then
                VerificaMensaje("El código de artículo no existe")
                TxtArticulo.SelectAll()
                TxtArticulo.Focus()
                Exit Sub
            End If

            With InfoArticulo
                TxtArticuloNombre.Text = .NombreArticulo
                If .ExentoIV = 0 Then
                    TxtExento.Text = "NO"
                    TxtPrecio.Text = Format(.Precio + CalculaMontoImpuesto(.Precio, .ArticuloImpuestos), "#,##0.00")
                Else
                    TxtExento.Text = "SI"
                    TxtPrecio.Text = Format(.Precio, "#,##0.00")
                End If

                TxtCantidad.Text = 1
            End With

            CmbBodega.Enabled = False
            TxtArticulo.Enabled = False
            TxtArticuloNombre.Enabled = True
            TxtExento.Enabled = True
            TxtPrecio.Enabled = True
            TxtCantidad.Enabled = True

            TxtCantidad.SelectAll()
            TxtCantidad.Focus()

            If Not InfoArticulo.SolicitaCantidad Then

                TxtCantidad.Text = 1
                AgregaArticulo()

            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            InfoArticulo = Nothing
        End Try
    End Sub

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

    Private Sub Inicializa()
        Try

            LvwDetalle.Items.Clear()
            InicializaLineaArticulo()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub InicializaLineaArticulo()
        Try
            TxtArticulo.Text = ""
            TxtArticuloNombre.Text = ""
            TxtExento.Text = ""
            TxtPrecio.Text = ""
            TxtCantidad.Text = ""

            CmbBodega.Enabled = True
            TxtArticulo.Enabled = True
            TxtArticuloNombre.Enabled = False
            TxtExento.Enabled = False
            TxtPrecio.Enabled = False
            TxtCantidad.Enabled = False

            TxtArticulo.Focus()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub AgregaArticulo()
        Dim Items(4) As String
        Dim Item As ListViewItem = Nothing
        Try

            Items(ColumnasDetalle.Articulo) = TxtArticulo.Text
            Items(ColumnasDetalle.Descripcion) = TxtArticuloNombre.Text.Trim
            Items(ColumnasDetalle.Exento) = TxtExento.Text.Trim
            Items(ColumnasDetalle.Precio) = TxtPrecio.Text
            Items(ColumnasDetalle.Cantidad) = TxtCantidad.Text

            Item = New ListViewItem(Items)

            LvwDetalle.Items.Add(Item)

            Item.EnsureVisible()

            InicializaLineaArticulo()


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaArticulo() As Double
        Try

            If CmbBodega.SelectedValue Is Nothing OrElse CmbBodega.Items.Count = 0 Then
                CmbBodega.Focus()
                VerificaMensaje("Debe de seleccionar una bodega")
            End If

            If Not IsNumeric(TxtCantidad.Text) OrElse CInt(TxtCantidad.Text) <= 0 Then
                TxtCantidad.SelectAll()
                TxtCantidad.Focus()
                VerificaMensaje("La cantidad debe de ser mayor a cero")
            End If


            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub TxtCantidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCantidad.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If Not TxtArticulo.Enabled Then
                    InicializaLineaArticulo()
                End If
            Case Keys.Enter
                If ValidaArticulo() Then
                    AgregaArticulo()
                End If
        End Select
    End Sub

    Private Sub BtnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpiar.Click
        If LvwDetalle.Items.Count > 0 Then
            If MsgBox("Desea limpiar la pantalla?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) <> MsgBoxResult.Yes Then
                Exit Sub
            End If
        End If
        Inicializa()
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles BtnBuscar.Click
        BuscarArticulo()
    End Sub
    Private Sub BuscarDocumento()
        Dim Forma As New FrmBusquedaEntrada
        Try

            'If Not TxtNumero.Enabled Then
            '    Exit Sub
            'End If

            Forma.Execute()
            If Forma.Selecciono Then
                CargaArticulosEntrada(Forma.Numero_Id)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub CargaArticulosEntrada(pEntrada_Id)
        Dim EntradaDetalle As New TEntradaDetalle(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Dim Items(4) As String
        Dim Item As ListViewItem = Nothing
        Dim EntradaImpuesto As List(Of TInfoArticuloImpuesto)
        Try


            With EntradaDetalle
                .Suc_Id = SucursalInfo.Suc_Id
                .Entrada_Id = pEntrada_Id
            End With
            Mensaje = EntradaDetalle.List()
            VerificaMensaje(Mensaje)

            If EntradaDetalle.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron artículos para la entrada seleccionada")
            End If

            For Each Fila As DataRow In EntradaDetalle.Data.Tables("TablaDetalle").Rows
                Items(ColumnasDetalle.Articulo) = Fila("Art_Id")
                Items(ColumnasDetalle.Descripcion) = Fila("NombreArticulo")

                EntradaImpuesto = New List(Of TInfoArticuloImpuesto)

                For Each impuesto As DataRow In EntradaDetalle.Data.Tables("TablaImpuesto").Rows
                    If impuesto("Detalle_Id") = Fila("Detalle_Id") Then

                        EntradaImpuesto.Add(New TInfoArticuloImpuesto() With
                                            {.Codigo_Id = impuesto("Codigo_Id"),
                                             .Tarifa_Id = impuesto("Tarifa_Id"),
                                             .Porcentaje = impuesto("Porcentaje")})

                        Item.Tag = EntradaImpuesto
                    End If
                Next
                If Not Fila("ExentoIV") Then
                    Items(ColumnasDetalle.Exento) = "NO"
                    Items(ColumnasDetalle.Precio) = Format(Fila("Precio") + CalculaMontoImpuesto(Fila("Precio"), EntradaImpuesto), "#,##0.00")
                Else
                    Items(ColumnasDetalle.Exento) = "SI"
                    Items(ColumnasDetalle.Precio) = Format(Fila("Precio"), "#,##0.00")
                End If


                Items(ColumnasDetalle.Cantidad) = Fila("Cantidad")

                Item = New ListViewItem(Items)
                LvwDetalle.Items.Add(Item)
                Item.EnsureVisible()
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            EntradaDetalle = Nothing
        End Try
    End Sub


    Private Sub BtnEntrada_Click(sender As System.Object, e As System.EventArgs) Handles BtnEntrada.Click
        BuscarDocumento()
    End Sub

    Private Sub EliminaLinea()
        Try
            If LvwDetalle.SelectedItems Is Nothing OrElse LvwDetalle.SelectedItems.Count = 0 Then
                Exit Sub
            End If

            LvwDetalle.Items.Remove(LvwDetalle.SelectedItems(0))

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LvwDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles LvwDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                EliminaLinea()
        End Select

    End Sub

    Private Sub BtnImpresora_Click(sender As System.Object, e As System.EventArgs) Handles BtnImpresora.Click
        Try
            LblImpresora.Text = SeleccionaImpresora()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try

            If LvwDetalle.Items.Count = 0 Then
                VerificaMensaje("Debe de ingresar artículos")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimir.Click
        If ValidaTodo() Then
            If MsgBox("Desea imprimir las etiquetas de los productos ingresados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) <> MsgBoxResult.Yes Then
                Exit Sub
            End If
            Imprimir()
        End If
    End Sub
    Private Sub Imprimir()
        Dim Etiqueta As TEtiquetaInfo = Nothing
        Dim CodigoBarra As New TCodigoBarra
        Dim Copias As Long = 1
        Try

            With CodigoBarra
                .Impresora = LblImpresora.Text
                .TipoEtiqueta = CmbEtiqueta.SelectedValue
            End With

            For Each Item As ListViewItem In LvwDetalle.Items
                Etiqueta = New TEtiquetaInfo
                With Etiqueta
                    .Codigo = Item.SubItems(ColumnasDetalle.Articulo).Text.Trim
                    .Descripcion = Item.SubItems(ColumnasDetalle.Descripcion).Text.Trim
                    .Precio = Item.SubItems(ColumnasDetalle.Precio).Text.Trim
                    If Item.SubItems(ColumnasDetalle.Exento).Text.Trim = "NO" Then
                        .LeyendaImpuesto = "IVI"
                    Else
                        .LeyendaImpuesto = "Exento"
                    End If

                End With

                Select Case CmbEtiqueta.SelectedValue
                    Case EtiquetasEnum.DosColumna_CincoxDosPuntoDos
                        Copias = (CantidadEtiquetasPar(CLng(Item.SubItems(ColumnasDetalle.Cantidad).Text))) / 2
                    Case EtiquetasEnum.UnaColumna_NuevexDosPuntoCinco
                        Copias = CLng(Item.SubItems(ColumnasDetalle.Cantidad).Text)
                    Case EtiquetasEnum.CincoColumna_CincoxDosPuntoDos
                        Copias = 1
                End Select

                CodigoBarra.Etiqueta = Etiqueta
                CodigoBarra.ImprimirEstandar(Copias, Item.SubItems(ColumnasDetalle.Cantidad).Text)


            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Etiqueta = Nothing
            CodigoBarra = Nothing
        End Try
    End Sub

    Private Sub BtnPrecios_Click(sender As Object, e As EventArgs) Handles BtnPrecios.Click
        Dim forma As New FrmSelecionaFechas()
        Try
            forma.Execute()
            If forma.CerroVentana Then

                CargaCambioDePrecio(forma.Desde, forma.Hasta)

            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub CargaCambioDePrecio(pDesde As Date, pHasta As Date)
        Dim articulos As New TArticulo(EmpresaInfo.Emp_Id)
        Try
            VerificaMensaje(articulos.PreciosCambiados(pDesde, pHasta, CmbBodega.SelectedValue))

            LvwDetalle.Items.Clear()

            For Each row As DataRow In articulos.Data.Tables(0).Rows
                TxtArticulo.Text = row.Item("Art_Id").ToString()

                CargaDatos()

                TxtCantidad.Text = 1

                If ValidaArticulo() Then
                    AgregaArticulo()
                End If
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class