Imports Business

Public Class FrmAjusteProduccion
#Region "Declaración de variables"
    Dim InfoArticulo As New TInfoArticulo(EmpresaInfo.Emp_Id)
    Dim _EntradaMercaderia As Boolean
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
        Nombre = 3
        Costo = 4
        Suelto = 5
        TotalLinea = 6
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
    Private Sub Nuevo()
        Try

            CmbTipoProduccion.Enabled = False
            TxtNumero.Enabled = False
            CmbTipoProduccion_SelectedIndexChanged(Nothing, EventArgs.Empty)

            CmbBodega.Enabled = True
            TxtComentario.Enabled = True

            HabilitaBotones(AccionEnum.Creando)

            'Encabezado
            PnEncabezado.Enabled = True
            CmbBodega.Enabled = True
            If CmbBodega.Items.Count > 0 Then
                CmbBodega.SelectedIndex = 0
            End If
            LblEstado.Text = "Nuevo"
            DtpFecha.Value = EmpresaInfo.Getdate
            TxtComentario.Text = ""
            TxtComentario.Focus()

            'Detalle
            PnLineaDetalle.Enabled = True
            TxtArticulo.Text = ""
            InicializaArticulo()
            LvwDetalle.Items.Clear()
            LblTotalCosto.Text = "0.00"

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Function VerificaTipoEntradaMercaderia() As Boolean
        Dim TipoProduccion As New TTipoProduccion(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Dim EntradaMercaderia As Boolean = False

        TipoProduccion.TipoProd_Id = CmbTipoProduccion.SelectedValue()
        Mensaje = TipoProduccion.ListKey()
        VerificaMensaje(Mensaje)

        If TipoProduccion.RowsAffected = 0 Then
            VerificaMensaje("No se encontró el tipo de producción")
        End If


        Return "" 'TipoProduccion.EntradaMercaderia

    End Function
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(2)

            Numerico(0) = New TNumericFormat(TxtNumero, 8, 0, False, "", "###0")
            Numerico(1) = New TNumericFormat(TxtCosto, 6, 2, False, "", "###0.00")
            Numerico(2) = New TNumericFormat(TxtCantidad, 6, 2, False, "", "###0.00")

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

                .Columns(ColumnasDetalle.Nombre).Text = "Descripción"
                .Columns(ColumnasDetalle.Nombre).Width = 359

                .Columns(ColumnasDetalle.Costo).Text = "Costo"
                .Columns(ColumnasDetalle.Costo).Width = 80
                .Columns(ColumnasDetalle.Costo).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.Suelto).Text = "Suelto"
                .Columns(ColumnasDetalle.Suelto).Width = 60
                .Columns(ColumnasDetalle.Suelto).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.TotalLinea).Text = "Total Línea"
                .Columns(ColumnasDetalle.TotalLinea).Width = 100
                .Columns(ColumnasDetalle.TotalLinea).TextAlign = HorizontalAlignment.Right
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub CargaCombos()
        Dim TipoProduccion As New TTipoProduccion(EmpresaInfo.Emp_Id)
        Dim Bodega As New TBodega(SucursalInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            Mensaje = TipoProduccion.LoadComboBoxTipo(CmbTipoProduccion)
            VerificaMensaje(Mensaje)

            CmbTipoProduccion.SelectedIndex = -1


            Bodega.Suc_Id = SucursalInfo.Suc_Id
            Mensaje = Bodega.LoadComboBox(CmbBodega)
            VerificaMensaje(Mensaje)



        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TipoProduccion = Nothing
            Bodega = Nothing
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
                BtnCargaArticulos.Enabled = False
            Case AccionEnum.Creando
                BtnBuscar.Enabled = True
                BtnNuevo.Enabled = False
                BtnModificar.Enabled = True
                BtnAplicar.Enabled = False
                BtnEliminar.Enabled = False
                BtnCancelar.Enabled = True
                BtnImprimir.Enabled = False
                BtnSalir.Enabled = True
                BtnCargaArticulos.Enabled = True
            Case AccionEnum.Salvando
                BtnBuscar.Enabled = False
                BtnNuevo.Enabled = False
                BtnModificar.Enabled = False
                BtnAplicar.Enabled = False
                BtnEliminar.Enabled = False
                BtnCancelar.Enabled = False
                BtnImprimir.Enabled = False
                BtnSalir.Enabled = False
                BtnCargaArticulos.Enabled = False
            Case AccionEnum.Modificando
                BtnBuscar.Enabled = True
                BtnNuevo.Enabled = False
                BtnModificar.Enabled = True
                BtnAplicar.Enabled = True
                BtnEliminar.Enabled = True
                BtnCancelar.Enabled = True
                BtnImprimir.Enabled = True
                BtnSalir.Enabled = False
                BtnCargaArticulos.Enabled = True
            Case AccionEnum.Aplicado
                BtnBuscar.Enabled = False
                BtnNuevo.Enabled = False
                BtnModificar.Enabled = False
                BtnAplicar.Enabled = False
                BtnEliminar.Enabled = False
                BtnCancelar.Enabled = True
                BtnImprimir.Enabled = True
                BtnSalir.Enabled = False
                BtnCargaArticulos.Enabled = False
        End Select

    End Sub
    Private Sub Inicializa()
        Try

            HabilitaBotones(AccionEnum.Inicial)

            'Limpia variables globales
            _EntradaMercaderia = False

            'Encabezado
            CmbTipoProduccion.Enabled = True
            CmbTipoProduccion.SelectedIndex = 0
            TxtNumero.Enabled = True
            TxtNumero.Text = ""

            CmbBodega.Enabled = False
            CmbBodega.SelectedIndex = -1
            LblEstado.Text = ""
            DtpFecha.Value = EmpresaInfo.Getdate
            TxtComentario.Enabled = False
            TxtComentario.Text = ""


            'Detalle
            PnLineaDetalle.Enabled = False


            TxtArticulo.Text = ""
            InicializaArticulo()
            LvwDetalle.Items.Clear()
            LblTotalCosto.Text = "0.00"


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub ActivarEdicionArticulo(pActivar)
        TxtArticulo.Enabled = (Not pActivar)
        TxtArticuloNombre.Enabled = pActivar
        TxtUnidadMedida.Enabled = pActivar
        TxtSuelto.Enabled = pActivar
        TxtSaldo.Enabled = pActivar
        TxtCosto.Enabled = pActivar
        TxtCantidad.Enabled = pActivar
        If pActivar Then
            TxtCosto.ReadOnly = (Not _EntradaMercaderia)
        End If
    End Sub
    Private Function ValidaArticulo(pArt_Id As String, pModificando As Boolean) As Boolean
        Dim Mensaje As String = ""
        Try
            If CmbTipoProduccion.SelectedValue Is Nothing OrElse CmbTipoProduccion.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar un tipo de documento")
            End If


            If CmbBodega.SelectedValue Is Nothing OrElse CmbBodega.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar una bodega")
                Return False
            End If

            With InfoArticulo
                .LimpiaArticulo()
                .Suc_Id = SucursalInfo.Suc_Id
                .Bod_Id = CmbBodega.SelectedValue
                .Art_Id = TxtArticulo.Text.Trim
            End With

            Mensaje = InfoArticulo.ConsultaArticulo(-1)
            VerificaMensaje(Mensaje)

            If InfoArticulo.RowsAffected = 0 Then
                VerificaMensaje("Artículo inválido, no se encontraron datos")
            End If

            If InfoArticulo.Data.Tables(0) Is Nothing Then
                TxtArticulo.SelectAll()
                TxtArticulo.Focus()
                VerificaMensaje("Artículo inválido, no se encontraron datos")
            End If

            Mensaje = InfoArticulo.CargaRegistroArticulo(InfoArticulo.Data.Tables(0).Rows(0))
            VerificaMensaje(Mensaje)


            If InfoArticulo.Servicio Then
                VerificaMensaje("Artículo inválido, no se pueden hacer ajustes a un codigo de servicio")
            End If

            If Not InfoArticulo.Compuesto Then
                VerificaMensaje("Artículo inválido, únicamente se le pueden hacer ajustes de producción a artículos compuestos")
            End If

            If Not InfoArticulo.SaldoPropio Then
                VerificaMensaje("Artículo inválido, el artículo no tiene saldo propio")
            End If


            'If InfoArticulo.Compuesto Then
            '    VerificaMensaje("Artículo inválido, no se pueden hacer ajustes a un codigo de servicio")
            'End If

            CmbBodega.Enabled = False

            TxtArticuloNombre.Text = InfoArticulo.Nombre
            TxtUnidadMedida.Text = InfoArticulo.UnidadMedidaNombre
            TxtSuelto.Text = IIf(InfoArticulo.Suelto, "Si", "No")
            TxtSaldo.Text = Format(InfoArticulo.Saldo, "###0.00")
            TxtCosto.Text = Format(InfoArticulo.Costo, "###0.00")
            TxtCantidad.Text = "1.00"

            ActivarEdicionArticulo(True)

            If _EntradaMercaderia Then
                TxtCosto.Focus()
            Else
                TxtCantidad.Focus()
            End If


            Return True
        Catch ex As Exception
            InfoArticulo.LimpiaArticulo()
            MensajeError(ex.Message)
            Return False
        End Try
    End Function
    Private Function ValidaCosto() As Boolean
        Try
            If Not IsNumeric(TxtCosto.Text) Then
                VerificaMensaje("Debe de ingresar una cantidad válida")
            End If

            If _EntradaMercaderia Then
                If CDbl(TxtCosto.Text) <= 0 Then
                    VerificaMensaje("El costo debe de ser mayor a cero")
                End If
            Else
                If CDbl(TxtCosto.Text) < 0 Then
                    VerificaMensaje("El costo debe de ser mayor o igual a cero")
                End If
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

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function
    Private Sub InicializaArticulo()
        ActivarEdicionArticulo(False)
        LvwDetalle.Tag = Nothing
        InfoArticulo.LimpiaArticulo()
        TxtArticuloNombre.Text = ""
        TxtUnidadMedida.Text = ""
        TxtSuelto.Text = ""
        TxtSaldo.Text = ""
        TxtCosto.Text = ""
        TxtCantidad.Text = ""
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
        Dim Items(7) As String
        Dim Linea_Id As Integer = 0
        Dim Accion As AccionDetalle = AccionDetalle.Nuevo
        Try

            If Not LvwDetalle.Tag Is Nothing Then
                'Modificando
                Item = LvwDetalle.Tag
                Linea_Id = CInt(Item.SubItems(ColumnasDetalle.Linea).Text)
                Accion = AccionDetalle.Modifica
            Else
                'Verifica si ya esta en la linea de detale
                Item = BuscaItemArticulo(InfoArticulo.Art_Id)
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
                .SubItems(ColumnasDetalle.Articulo).Text = InfoArticulo.Art_Id
                If Accion = AccionDetalle.Sumariza Then
                    .SubItems(ColumnasDetalle.Cantidad).Text = Format(CDbl(.SubItems(ColumnasDetalle.Cantidad).Text) + CDbl(TxtCantidad.Text), "##0.00")
                Else
                    .SubItems(ColumnasDetalle.Cantidad).Text = Format(CDbl(TxtCantidad.Text), "##0.00")
                End If
                .SubItems(ColumnasDetalle.Nombre).Text = InfoArticulo.Nombre
                .SubItems(ColumnasDetalle.Suelto).Text = IIf(InfoArticulo.Suelto, "Si", "No")
                .SubItems(ColumnasDetalle.Costo).Text = Format(CDbl(TxtCosto.Text), "##0.0000")
                .SubItems(ColumnasDetalle.TotalLinea).Text = Format(CDbl(.SubItems(ColumnasDetalle.Cantidad).Text) * CDbl(.SubItems(ColumnasDetalle.Costo).Text), "##0.0000")
            End With

            If Accion = AccionDetalle.Nuevo Then
                LvwDetalle.Items.Add(Item)
                Item.EnsureVisible()
            End If

            TxtArticulo.Text = ""
            InicializaArticulo()
            TxtArticulo.Focus()

            MuestraTotales()

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
            InfoArticulo.ListaConjuntos.Clear()

            LvwDetalle.Items.Remove(LvwDetalle.SelectedItems(0))

            CmbBodega.Enabled = (LvwDetalle.Items.Count = 0)

            MuestraTotales()

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

            TxtCosto.Text = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Costo).Text
            TxtCantidad.Text = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Cantidad).Text
            TxtCantidad.SelectAll()

            LvwDetalle.Tag = LvwDetalle.SelectedItems(0)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub CalculaTotales(ByRef pCosto As Double)
        Try
            pCosto = 0

            For Each Fila As ListViewItem In LvwDetalle.Items
                pCosto = pCosto + (CDbl(Fila.SubItems(ColumnasDetalle.Costo).Text) * CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text))
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Public Sub MuestraTotales()
        Dim Costo As Double = 0
        Try

            LblTotalCosto.Text = "0.00"

            CalculaTotales(Costo)

            LblTotalCosto.Text = Format(Costo, "#,##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub GuardarDocumento(pAplicar As Boolean, pAplicaUsuario_Id As String)
        Dim ProduccionEncabezado As New TProduccionEncabezado(EmpresaInfo.Emp_Id)
        Dim ProduccionDetalle As TProduccionDetalle = Nothing
        Dim Mensaje As String = ""
        Dim Costo As Double = 0
        Dim Detalle_Id As Integer = 0
        Dim Factor As Integer = 1
        Dim Nuevo As Boolean = False
        Try


            Factor = FactorxDocumento()
            If Math.Abs(Factor) <> 1 Then
                VerificaMensaje("No se pudo optener el factor x el tipo de documento")
            End If

            CalculaTotales(Costo)

            With ProduccionEncabezado
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
                .TipoProd_Id = CmbTipoProduccion.SelectedValue
                If TxtNumero.Text <> "" Then
                    .Prod_Id = CLng(TxtNumero.Text)
                Else
                    Nuevo = True
                    .Prod_Id = 0
                End If
                .Bod_Id = CmbBodega.SelectedValue
                .Fecha = EmpresaInfo.Getdate()
                .Comentario = TxtComentario.Text
                .Costo = Costo * Factor
                .Aplicado = 0
                .Usuario_Id = UsuarioInfo.Usuario_Id
            End With

            For Each Item As ListViewItem In LvwDetalle.Items
                ProduccionDetalle = New TProduccionDetalle(SucursalInfo.Emp_Id)
                Detalle_Id = Detalle_Id + 1
                With ProduccionDetalle
                    .Suc_Id = SucursalInfo.Suc_Id
                    .TipoProd_Id = CmbTipoProduccion.SelectedValue
                    .Prod_Id = ProduccionEncabezado.Prod_Id
                    .Detalle_Id = Detalle_Id
                    .Art_Id = Item.SubItems(ColumnasDetalle.Articulo).Text
                    .Cantidad = CDbl(Item.SubItems(ColumnasDetalle.Cantidad).Text) * Factor
                    .Costo = CDbl(Item.SubItems(ColumnasDetalle.Costo).Text)
                    .TotalLinea = CDbl(Item.SubItems(ColumnasDetalle.TotalLinea).Text)
                    .Suelto = IIf(Item.SubItems(ColumnasDetalle.Suelto).Text.ToLower = "si", 1, 0)
                    .Fecha = ProduccionEncabezado.Fecha
                End With
                ProduccionEncabezado.ListaDetalles.Add(ProduccionDetalle)
            Next

            Mensaje = ProduccionEncabezado.GuardarDocumento()
            VerificaMensaje(Mensaje)


            If pAplicar Then
                ProduccionEncabezado.AplicaUsuario_Id = pAplicaUsuario_Id
                Mensaje = ProduccionEncabezado.AplicaProduccionAjuste()
                VerificaMensaje(Mensaje)
            End If

            If Nuevo Then
                MsgBox("Se generó el ajuste # " & ProduccionEncabezado.Prod_Id.ToString, MsgBoxStyle.Information, Me.Text)
            Else
                MsgBox("Los datos se almacenaron de manera correcta", MsgBoxStyle.Information, Me.Text)
            End If

            Inicializa()
            CmbTipoProduccion.SelectedItem = -1
            CmbBodega.SelectedIndex = -1
            TxtNumero.Focus()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ProduccionEncabezado = Nothing
        End Try
    End Sub
    Private Function FactorxDocumento() As Integer
        Dim TipoProduccion As New TTipoProduccion(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Dim Factor As Integer = 0
        Try

            TipoProduccion.TipoProd_Id = CmbTipoProduccion.SelectedValue
            Mensaje = TipoProduccion.ListKey()
            VerificaMensaje(Mensaje)

            If TipoProduccion.Suma Then
                Factor = 1
            Else
                If Not TipoProduccion.Suma Then
                    Factor = -1
                End If
            End If

            Return Factor

        Catch ex As Exception
            MensajeError(ex.Message)
            Return 0
        Finally
            TipoProduccion = Nothing
        End Try
    End Function
    Private Sub CargaDocumento()
        Dim ProduccionEncabezado As New TProduccionEncabezado(EmpresaInfo.Emp_Id)
        Dim ProduccionDetalle As New TProduccionDetalle(EmpresaInfo.Emp_Id)
        Dim Item As ListViewItem = Nothing
        Dim Items(7) As String
        Dim Mensaje As String = ""
        Dim Detalle_Id As Integer = 0
        Try

            With ProduccionEncabezado
                .Suc_Id = SucursalInfo.Suc_Id
                .TipoProd_Id = CmbTipoProduccion.SelectedValue
                .Prod_Id = CLng(TxtNumero.Text)
            End With
            Mensaje = ProduccionEncabezado.ListKey()
            VerificaMensaje(Mensaje)

            If ProduccionEncabezado.RowsAffected = 0 Then
                TxtNumero.SelectAll()
                TxtNumero.Focus()
                VerificaMensaje("El número de producción no es válido")
            End If

            With ProduccionDetalle
                .Suc_Id = SucursalInfo.Suc_Id
                .TipoProd_Id = CmbTipoProduccion.SelectedValue
                .Prod_Id = CLng(TxtNumero.Text)
            End With
            Mensaje = ProduccionDetalle.List()
            VerificaMensaje(Mensaje)



            CmbTipoProduccion.Enabled = False
            CmbTipoProduccion_SelectedIndexChanged(Nothing, EventArgs.Empty)
            TxtNumero.Enabled = False

            'Encabezado
            CmbBodega.SelectedValue = ProduccionEncabezado.Bod_Id
            DtpFecha.Value = DateValue(ProduccionEncabezado.Fecha)
            LblEstado.Text = IIf(ProduccionEncabezado.Aplicado, "Aplicado", "Pendiente")
            TxtComentario.Text = ProduccionEncabezado.Comentario

            'Detalle
            TxtArticulo.Text = ""
            InicializaArticulo()
            LvwDetalle.Items.Clear()
            LblTotalCosto.Text = "0.00"

            For Each Fila As DataRow In ProduccionDetalle.Data.Tables(0).Rows
                Item = New ListViewItem(Items)
                Detalle_Id = Detalle_Id + 1
                With Item
                    .SubItems(ColumnasDetalle.Linea).Text = Detalle_Id
                    .SubItems(ColumnasDetalle.Articulo).Text = Fila("Art_Id")
                    .SubItems(ColumnasDetalle.Cantidad).Text = Format(Math.Abs(Fila("Cantidad")), "##0.00")
                    .SubItems(ColumnasDetalle.Nombre).Text = Fila("Nombre")
                    .SubItems(ColumnasDetalle.Suelto).Text = IIf(Fila("Suelto"), "Si", "No")
                    .SubItems(ColumnasDetalle.Costo).Text = Format(Fila("Costo"), "##0.0000")
                    .SubItems(ColumnasDetalle.TotalLinea).Text = Format(Fila("TotalLinea"), "##0.0000")
                End With
                LvwDetalle.Items.Add(Item)
                Item.EnsureVisible()
            Next

            'Habilita o desabilita campos
            If ProduccionEncabezado.Aplicado Then
                CmbBodega.Enabled = False
                TxtComentario.Enabled = False
                PnLineaDetalle.Enabled = False
            Else
                CmbBodega.Enabled = (LvwDetalle.Items.Count = 0)
                TxtComentario.Enabled = True
                PnLineaDetalle.Enabled = True
            End If

            MuestraTotales()

            If Not ProduccionEncabezado.Aplicado Then
                HabilitaBotones(AccionEnum.Modificando)
                TxtArticulo.Focus()
            Else
                HabilitaBotones(AccionEnum.Aplicado)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
            Inicializa()
        Finally
            ProduccionEncabezado = Nothing
            ProduccionDetalle = Nothing
        End Try
    End Sub
    Private Sub BuscarProduccion()
        Dim Forma As New FrmBusquedaProduccion
        Try

            If Not TxtNumero.Enabled Then
                Exit Sub
            End If

            Forma.Execute()
            If Forma.Selecciono Then
                CmbTipoProduccion.SelectedValue = Forma.TipoProd_Id
                TxtNumero.Text = Forma.Prod_Id
                CargaDocumento()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Sub EliminarProduccion()
        Dim ProduccionEncabezado As New TProduccionEncabezado(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            With ProduccionEncabezado
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
                .TipoProd_Id = CmbTipoProduccion.SelectedValue
                .Prod_Id = CLng(TxtNumero.Text)
            End With

            Mensaje = ProduccionEncabezado.EliminarDocumento()
            VerificaMensaje(Mensaje)

            Inicializa()
            TxtNumero.Focus()
            CmbTipoProduccion.SelectedItem = -1

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ProduccionEncabezado = Nothing
        End Try
    End Sub
    Private Sub ConsultarArticulo()
        Dim Forma As New FrmConsultaArticulo
        Try

            Forma.Execute()

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
                Select Case Me.ActiveControl.Name
                    Case "TxtNumero"
                        BuscarProduccion()
                    Case "TxtArticulo"
                        BuscarArticulo()
                End Select
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
            Case Keys.F11
                BtnCargaArticulos.PerformClick()
        End Select
    End Sub
    Private Sub FrmAjusteInventario_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            FormateaCamposNumericos()
            ConfiguraDetalle()
            ConfiguraStatusBar()

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
        Dim Forma As New FrmBuscaArticuloCompuesto
        Try
            Forma.SaldoPropio = 1
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
    Private Sub CmbTipoProduccion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbTipoProduccion.SelectedIndexChanged
        Dim TipoProduccion As New TTipoProduccion(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            If CmbTipoProduccion.SelectedValue Is Nothing OrElse CmbTipoProduccion.SelectedValue.ToString = "System.Data.DataRowView" Then
                Exit Sub
            End If

            _EntradaMercaderia = False


            TipoProduccion.TipoProd_Id = CmbTipoProduccion.SelectedValue
            Mensaje = TipoProduccion.ListKey()
            VerificaMensaje(Mensaje)

            If TipoProduccion.RowsAffected = 0 Then
                MensajeError("El tipo de documento no es válido")
            End If

            'If Not TipoProduccion.Activo Then
            '    MensajeError("El tipo de documento se encuentra inactivo")
            'End If

            '_EntradaMercaderia = TipoProduccion.EntradaMercaderia

        Catch ex As Exception
            _EntradaMercaderia = False
            MensajeError(ex.Message)
        Finally
            TipoProduccion = Nothing
        End Try
    End Sub
    Private Sub TxtComentario_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtComentario.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If TxtArticulo.Enabled And PnLineaDetalle.Enabled Then
                    TxtArticulo.Focus()
                End If
        End Select
    End Sub
    Private Sub TxtCosto_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCosto.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If ValidaCosto() Then
                    TxtCantidad.Focus()
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
    Private Sub TxtCantidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCantidad.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If TxtCantidad.Enabled Then
                    InicializaArticulo()
                    TxtArticulo.Text = ""
                    TxtArticulo.Focus()
                End If
            Case Keys.Enter
                If ValidaCosto() AndAlso ValidaCantidad() Then
                    IngresaArticulo()
                End If
        End Select
    End Sub
    Private Sub LvwDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles LvwDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                EliminaLinea()
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
                BuscarProduccion()
            Case "TxtArticulo"
                BuscarArticulo()
        End Select
    End Sub
    Private Sub TxtNumero_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtNumero.KeyDown
        Select Case e.KeyCode
            'Case Keys.F1
            '    BuscarProduccion()
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
            If MsgBox("Desea aplicar el ajuste de producción?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                If VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.InvAplicaAjusteProduccion, True) Then
                    GuardarDocumento(True, UsuarioInfo.Usuario_Id)
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub Eliminar()
        Try
            If MsgBox("Desea eliminar el ajuste de producción?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                EliminarProduccion()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Function Validatodo()
        Try
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
        Dim ProduccionEncabezado As New TProduccionEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte As New AjusteProduccion
        Dim FormaReporte As New FrmReporte
        Try

            Cursor.Current = Cursors.WaitCursor
            BtnImprimir.Enabled = False

            With ProduccionEncabezado
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
                .TipoProd_Id = CmbTipoProduccion.SelectedValue
                .Prod_Id = CLng(TxtNumero.Text)
            End With

            Mensaje = ProduccionEncabezado.RptAjusteProduccion()
            VerificaMensaje(Mensaje)

            If ProduccionEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))

            Reporte.SetDataSource(ProduccionEncabezado.Data.Tables(0))
            'parametros encabezado y pie de pagina

            Reporte.SetParameterValue("pEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("pSucursal", SucursalInfo.Nombre)


            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            ProduccionEncabezado = Nothing
            BtnImprimir.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Sub Limpiar()
        Try
            Inicializa()
            TxtNumero.Focus()
            CmbTipoProduccion.SelectedItem = -1
            CmbBodega.SelectedIndex = -1

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub Imprimir()
        Try
            MuestraReporte()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub Salir()
        Me.Close()
    End Sub
    Private Sub Guardar()
        Try
            If Validatodo() Then
                GuardarDocumento(False, "")
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
    Private Sub BtnSaldos_Click(sender As System.Object, e As System.EventArgs) Handles BtnSaldos.Click
        ConsultarArticulo()
    End Sub

    Private Sub BtnCargaArticulos_Click(sender As System.Object, e As System.EventArgs) Handles BtnCargaArticulos.Click
        CargaArticulos()
    End Sub

    Private Sub CargaArticulos()
        'Dim Forma As New FrmCargaArticulos
        'Try

        '    Forma.ValidaSueltos = False
        '    Forma.VerificaBodega = True
        '    Forma.Suc_Id = SucursalInfo.Suc_Id
        '    Forma.Bod_Id = CmbBodega.SelectedValue
        '    Forma.Execute()

        '    If Not Forma.Guardo Then
        '        Exit Sub
        '    End If

        '    For Each conteo As TArticuloConteo In Forma.ListaConteo
        '        TxtArticulo.Text = conteo.Art_Id
        '        ValidaArticulo(TxtArticulo.Text, False)
        '        TxtCantidad.Text = conteo.Cantidad
        '        IngresaArticulo()
        '    Next

        'Catch ex As Exception
        '    MensajeError(ex.Message)
        'Finally
        '    Forma = Nothing
        'End Try
    End Sub
End Class