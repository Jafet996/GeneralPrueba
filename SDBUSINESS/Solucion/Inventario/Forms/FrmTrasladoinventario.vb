Imports Business
Public Class FrmTrasladoinventario
#Region "Declaración de variables"
    Dim InfoArticulo As New TInfoArticulo(EmpresaInfo.Emp_Id)
    Dim Numerico() As TNumericFormat
    Dim _UltimaModificacion As DateTime
    Dim _Lotes As New List(Of TArticuloLote)

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
        CantidadLote = 3
        Nombre = 4
        Lote = 5
        Costo = 6
        Suelto = 7
        TotalLinea = 8
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

            TxtNumero.Enabled = False

            GroupOrigen.Enabled = True
            GroupDestino.Enabled = True
            TxtComentario.Enabled = True

            CmbSucursalOrigen.Enabled = True
            CmbSucursalDestino.Enabled = True
            CmbBodegaOrigen.Enabled = True
            CmbBodegaDestino.Enabled = True

            HabilitaBotones(AccionEnum.Creando)

            'Encabezado
            PnEncabezado.Enabled = True

            If CmbSucursalOrigen.Items.Count > 0 Then
                CmbSucursalOrigen.SelectedIndex = 0
            End If
            If CmbSucursalDestino.Items.Count > 0 Then
                CmbSucursalDestino.SelectedIndex = 0
            End If
            If CmbBodegaOrigen.Items.Count > 0 Then
                CmbBodegaOrigen.SelectedIndex = 0
            End If
            If CmbBodegaDestino.Items.Count > 0 Then
                CmbBodegaDestino.SelectedIndex = 0
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

            CmbSucursalOrigen_SelectedIndexChanged(CmbSucursalOrigen, EventArgs.Empty)
            CmbSucursalDestino_SelectedIndexChanged(CmbSucursalDestino, EventArgs.Empty)


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
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

                .Columns(ColumnasDetalle.CantidadLote).Text = "Cantidad Lotes"
                .Columns(ColumnasDetalle.CantidadLote).Width = 90
                .Columns(ColumnasDetalle.CantidadLote).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.Nombre).Text = "Descripción"
                .Columns(ColumnasDetalle.Nombre).Width = 359

                .Columns(ColumnasDetalle.Lote).Text = "Lote"
                .Columns(ColumnasDetalle.Lote).Width = 40
                .Columns(ColumnasDetalle.Lote).TextAlign = HorizontalAlignment.Center

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
        Dim SucursalOrigen As New TSucursal(EmpresaInfo.Emp_Id)
        Dim SucursalDestino As New TSucursal(EmpresaInfo.Emp_Id)
        Try

            VerificaMensaje(SucursalOrigen.LoadComboBox(CmbSucursalOrigen))
            VerificaMensaje(SucursalDestino.LoadComboBox(CmbSucursalDestino))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            SucursalOrigen = Nothing
            SucursalDestino = Nothing
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
                BtnLotes.Enabled = False
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
                BtnLotes.Enabled = True
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
                BtnLotes.Enabled = False
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
                BtnLotes.Enabled = True
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
                BtnLotes.Enabled = False
                BtnCargaArticulos.Enabled = False
        End Select

    End Sub
    Private Sub Inicializa()
        Try

            HabilitaBotones(AccionEnum.Inicial)

            _UltimaModificacion = #01/01/1900#

            'Encabezado
            TxtNumero.Enabled = True
            TxtNumero.Text = ""

            LblEstado.Text = ""
            DtpFecha.Value = EmpresaInfo.Getdate
            TxtComentario.Enabled = False
            TxtComentario.Text = ""

            GroupOrigen.Enabled = False
            GroupDestino.Enabled = False


            'Detalle
            PnLineaDetalle.Enabled = False


            TxtArticulo.Text = ""
            InicializaArticulo()
            LvwDetalle.Items.Clear()
            LblTotalCosto.Text = "0.00"

            _Lotes.Clear()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub ActivarEdicionArticulo(pActivar)
        TxtArticulo.Enabled = (Not pActivar)
        TxtArticuloNombre.Enabled = pActivar
        TxtSuelto.Enabled = pActivar
        TxtSaldo.Enabled = pActivar
        TxtCosto.Enabled = pActivar
        TxtCantidad.Enabled = pActivar
    End Sub

    Private Function ValidaSucursalBodega()
        Try

            If CmbSucursalOrigen.SelectedValue Is Nothing OrElse CmbSucursalOrigen.SelectedIndex = -1 Then
                CmbSucursalOrigen.Focus()
                VerificaMensaje("Debe de seleccionar la sucursal de origen")
            End If

            If CmbBodegaOrigen.SelectedValue Is Nothing OrElse CmbBodegaOrigen.SelectedIndex = -1 Then
                CmbBodegaOrigen.Focus()
                VerificaMensaje("Debe de seleccionar la bodega de origen")
            End If

            If CmbSucursalDestino.SelectedValue Is Nothing OrElse CmbSucursalDestino.SelectedIndex = -1 Then
                CmbSucursalDestino.Focus()
                VerificaMensaje("Debe de seleccionar la sucursal de destino")
            End If

            If CmbBodegaDestino.SelectedValue Is Nothing OrElse CmbBodegaDestino.SelectedIndex = -1 Then
                CmbBodegaDestino.Focus()
                VerificaMensaje("Debe de seleccionar la bodega de dstino")
            End If

            If CmbSucursalOrigen.SelectedValue = CmbSucursalDestino.SelectedValue AndAlso CmbBodegaOrigen.SelectedValue = CmbBodegaDestino.SelectedValue Then
                CmbBodegaDestino.Focus()
                VerificaMensaje("La bodega origen y destino no pueden ser iguales")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Function ValidaArticulo(pArt_Id As String, pModificando As Boolean) As Boolean
        Dim Mensaje As String = ""
        Dim Resultado As Boolean = False
        Try

            If Not ValidaSucursalBodega() Then
                Exit Try
            End If


            With InfoArticulo
                .LimpiaArticulo()
                .Suc_Id = CInt(CmbSucursalOrigen.SelectedValue)
                .Bod_Id = CInt(CmbBodegaOrigen.SelectedValue)
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

            GroupOrigen.Enabled = False
            GroupDestino.Enabled = False

            TxtArticuloNombre.Text = InfoArticulo.Nombre
            TxtSuelto.Text = IIf(InfoArticulo.Suelto, "Si", "No")
            TxtSaldo.Text = Format(InfoArticulo.Saldo, "###0.00")
            TxtCosto.Text = Format(InfoArticulo.Costo, "###0.00")
            TxtCantidad.Text = "1.00"

            ActivarEdicionArticulo(True)

            TxtCantidad.Focus()


            Resultado = True
        Catch ex As Exception
            InfoArticulo.LimpiaArticulo()
            MensajeError(ex.Message)
            Resultado = False
        End Try
        Return Resultado
    End Function
    Private Function ValidaCosto() As Boolean
        Try
            If Not IsNumeric(TxtCosto.Text) Then
                VerificaMensaje("Debe de ingresar una cantidad válida")
            End If

            If CDbl(TxtCosto.Text) < 0 Then
                VerificaMensaje("El costo debe de ser mayor o igual a cero")
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

            If CDbl(TxtCantidad.Text) > CDbl(TxtSaldo.Text) Then
                TxtCantidad.SelectAll()
                TxtCantidad.Focus()
                VerificaMensaje("La cantidad a trasladar no puede ser mayor al saldo")
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
        Dim Items(9) As String
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
                ElseIf Accion = AccionDetalle.Modifica Then
                    .SubItems(ColumnasDetalle.Cantidad).Text = Format(CDbl(TxtCantidad.Text), "##0.00")
                Else
                    .SubItems(ColumnasDetalle.Cantidad).Text = Format(CDbl(TxtCantidad.Text), "##0.00")
                    .SubItems(ColumnasDetalle.CantidadLote).Text = "0.00"
                End If
                .SubItems(ColumnasDetalle.Nombre).Text = InfoArticulo.Nombre
                .SubItems(ColumnasDetalle.Suelto).Text = IIf(InfoArticulo.Suelto, "Si", "No")
                .SubItems(ColumnasDetalle.Lote).Text = IIf(InfoArticulo.Lote, "Si", "No")
                .SubItems(ColumnasDetalle.Costo).Text = Format(CDbl(TxtCosto.Text), "##0.0000")
                .SubItems(ColumnasDetalle.TotalLinea).Text = Format(CDbl(.SubItems(ColumnasDetalle.Cantidad).Text) * CDbl(.SubItems(ColumnasDetalle.Costo).Text), "##0.0000")
            End With

            If Accion = AccionDetalle.Nuevo Then
                LvwDetalle.Items.Add(Item)
                Item.EnsureVisible()

                If InfoArticulo.Lote Then
                    _Lotes.Add(New TArticuloLote With
                    {
                        .Art_Id = InfoArticulo.Art_Id,
                        .Nombre = InfoArticulo.Nombre,
                        .Cantidad = CDbl(TxtCantidad.Text),
                        .Escaneado = 0
                    })
                End If

                Item.UseItemStyleForSubItems = False
                ListViewCambiaCeldaBackForeColor(Item, Color.Teal, Color.White, ColumnasDetalle.Lote)
                Item.SubItems(ColumnasDetalle.Lote).Font = New Font(LvwDetalle.Font, FontStyle.Bold)
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

            GroupOrigen.Enabled = (LvwDetalle.Items.Count = 0)
            GroupDestino.Enabled = (LvwDetalle.Items.Count = 0)

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
        Dim TrasladoEncabezado As New TTrasladoEncabezado(EmpresaInfo.Emp_Id)
        Dim TrasladoDetalle As TTrasladoDetalle = Nothing
        Dim Mensaje As String = ""
        Dim Costo As Double = 0
        Dim Detalle_Id As Integer = 0
        Dim Nuevo As Boolean = False
        Try


            CalculaTotales(Costo)

            With TrasladoEncabezado

                .Emp_Id = EmpresaInfo.Emp_Id
                If TxtNumero.Text <> "" Then
                    .Traslado_Id = CLng(TxtNumero.Text)
                Else
                    Nuevo = True
                    .Traslado_Id = 0
                End If
                .SucOrigen_Id = CInt(CmbSucursalOrigen.SelectedValue)
                .BodOrigen_Id = CInt(CmbBodegaOrigen.SelectedValue)
                .SucDestino_Id = CInt(CmbSucursalDestino.SelectedValue)
                .BodDestino_Id = CInt(CmbBodegaDestino.SelectedValue)
                .Fecha = EmpresaInfo.Getdate()
                .Comentario = TxtComentario.Text
                .Costo = Costo
                .Aplicado = 0
                .Usuario_Id = UsuarioInfo.Usuario_Id
                .UltimaModificacion = _UltimaModificacion
                .Lotes = _Lotes
            End With

            For Each Item As ListViewItem In LvwDetalle.Items
                TrasladoDetalle = New TTrasladoDetalle(EmpresaInfo.Emp_Id)
                Detalle_Id = Detalle_Id + 1
                With TrasladoDetalle
                    .Traslado_Id = TrasladoEncabezado.Traslado_Id
                    .Detalle_Id = Detalle_Id
                    .Art_Id = Item.SubItems(ColumnasDetalle.Articulo).Text
                    .Cantidad = CDbl(Item.SubItems(ColumnasDetalle.Cantidad).Text)
                    .CantidadLote = CDbl(Item.SubItems(ColumnasDetalle.CantidadLote).Text)
                    .Costo = CDbl(Item.SubItems(ColumnasDetalle.Costo).Text)
                    .TotalLinea = CDbl(Item.SubItems(ColumnasDetalle.TotalLinea).Text)
                    .Suelto = IIf(Item.SubItems(ColumnasDetalle.Suelto).Text.ToLower = "si", 1, 0)
                    .Lote = IIf(Item.SubItems(ColumnasDetalle.Lote).Text.ToLower = "si", 1, 0)
                    .Fecha = TrasladoEncabezado.Fecha
                End With
                TrasladoEncabezado.ListaDetalles.Add(TrasladoDetalle)
            Next

            Mensaje = TrasladoEncabezado.GuardarDocumento()
            VerificaMensaje(Mensaje)


            If pAplicar Then
                TrasladoEncabezado.UsuarioAplica_Id = pAplicaUsuario_Id
                Mensaje = TrasladoEncabezado.AplicarTrasladoAjuste()
                VerificaMensaje(Mensaje)
            End If

            If Nuevo Then
                MsgBox("Se generó el traslado # " & TrasladoEncabezado.Traslado_Id.ToString, MsgBoxStyle.Information, Me.Text)
            Else
                MsgBox("Los datos se almacenaron de manera correcta", MsgBoxStyle.Information, Me.Text)
            End If

            Inicializa()
            TxtNumero.Focus()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TrasladoEncabezado = Nothing
        End Try
    End Sub
    Private Sub CargaDocumento()
        Dim TrasladoEncabezado As New TTrasladoEncabezado(EmpresaInfo.Emp_Id)
        Dim TrasladoDetalle As New TTrasladoDetalle(EmpresaInfo.Emp_Id)
        Dim TrasladoDetalleLote As New TTrasladoDetalleLote(EmpresaInfo.Emp_Id)
        Dim Item As ListViewItem = Nothing
        Dim Items(9) As String
        Dim Mensaje As String = ""
        Dim Detalle_Id As Integer = 0
        Try

            With TrasladoEncabezado
                .Traslado_Id = CLng(TxtNumero.Text)
            End With
            Mensaje = TrasladoEncabezado.ListKey()
            VerificaMensaje(Mensaje)

            If TrasladoEncabezado.RowsAffected = 0 Then
                TxtNumero.SelectAll()
                TxtNumero.Focus()
                VerificaMensaje("El número de movimiento no es válido")
            End If

            With TrasladoDetalle
                .Traslado_Id = CLng(TxtNumero.Text)
            End With
            Mensaje = TrasladoDetalle.List()
            VerificaMensaje(Mensaje)

            With TrasladoDetalleLote
                .Traslado_Id = CLng(TxtNumero.Text)
            End With
            VerificaMensaje(TrasladoDetalleLote.LotesEntradaMercaderia)

            TxtNumero.Enabled = False

            CmbSucursalOrigen_SelectedIndexChanged(CmbSucursalOrigen, EventArgs.Empty)
            CmbSucursalDestino_SelectedIndexChanged(CmbSucursalDestino, EventArgs.Empty)

            'Encabezado
            CmbSucursalOrigen.SelectedValue = TrasladoEncabezado.SucOrigen_Id
            CmbSucursalDestino.SelectedValue = TrasladoEncabezado.SucDestino_Id
            CmbBodegaOrigen.SelectedValue = TrasladoEncabezado.BodOrigen_Id
            CmbBodegaDestino.SelectedValue = TrasladoEncabezado.BodDestino_Id

            DtpFecha.Value = DateValue(TrasladoEncabezado.Fecha)
            LblEstado.Text = IIf(TrasladoEncabezado.Aplicado, "Aplicado", "Pendiente")
            TxtComentario.Text = TrasladoEncabezado.Comentario
            _UltimaModificacion = TrasladoEncabezado.UltimaModificacion

            'Detalle
            TxtArticulo.Text = ""
            InicializaArticulo()
            LvwDetalle.Items.Clear()
            LblTotalCosto.Text = "0.00"

            For Each Fila As DataRow In TrasladoDetalle.Data.Tables(0).Rows
                Item = New ListViewItem(Items)
                Detalle_Id = Detalle_Id + 1
                With Item
                    .SubItems(ColumnasDetalle.Linea).Text = Detalle_Id
                    .SubItems(ColumnasDetalle.Articulo).Text = Fila("Art_Id")
                    .SubItems(ColumnasDetalle.Cantidad).Text = Format(Math.Abs(Fila("Cantidad")), "##0.00")
                    .SubItems(ColumnasDetalle.CantidadLote).Text = Format(Math.Abs(Fila("CantidadLote")), "##0.00")
                    .SubItems(ColumnasDetalle.Nombre).Text = Fila("Nombre")
                    .SubItems(ColumnasDetalle.Suelto).Text = IIf(Fila("Suelto"), "Si", "No")
                    .SubItems(ColumnasDetalle.Costo).Text = Format(Fila("Costo"), "##0.0000")
                    .SubItems(ColumnasDetalle.TotalLinea).Text = Format(Fila("TotalLinea"), "##0.0000")
                    .SubItems(ColumnasDetalle.Lote).Text = IIf(Fila("Lote"), "Si", "No")
                End With
                If Fila("Lote") Then
                    Item.UseItemStyleForSubItems = False
                    ListViewCambiaCeldaBackForeColor(Item, Color.Teal, Color.White, ColumnasDetalle.Lote)
                    Item.SubItems(ColumnasDetalle.Lote).Font = New Font(LvwDetalle.Font, FontStyle.Bold)
                End If
                LvwDetalle.Items.Add(Item)
                Item.EnsureVisible()
            Next

            ' Lotes
            For Each Row As DataRow In TrasladoDetalleLote.Data.Tables(0).Rows
                IngresaLote(Row("Art_Id"), Row("LoteCantidad"), Row("Lote"), Row("Vencimiento"))
            Next

            'Habilita o desabilita campos
            If TrasladoEncabezado.Aplicado Then
                CmbSucursalOrigen.Enabled = False
                CmbSucursalDestino.Enabled = False
                CmbBodegaOrigen.Enabled = False
                CmbBodegaDestino.Enabled = False

                TxtComentario.Enabled = False
                PnLineaDetalle.Enabled = False
            Else
                CmbSucursalOrigen.Enabled = (LvwDetalle.Items.Count = 0)
                CmbSucursalDestino.Enabled = (LvwDetalle.Items.Count = 0)
                CmbBodegaOrigen.Enabled = (LvwDetalle.Items.Count = 0)
                CmbBodegaDestino.Enabled = (LvwDetalle.Items.Count = 0)

                TxtComentario.Enabled = True
                PnLineaDetalle.Enabled = True
            End If

            MuestraTotales()

            If Not TrasladoEncabezado.Aplicado Then
                HabilitaBotones(AccionEnum.Modificando)
                TxtArticulo.Focus()
            Else
                HabilitaBotones(AccionEnum.Aplicado)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
            Inicializa()
        Finally
            TrasladoEncabezado = Nothing
            TrasladoDetalle = Nothing
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
    Private Sub BuscarMovimiento()
        Dim Forma As New FrmBusquedaTraslado
        Try

            If Not TxtNumero.Enabled Then
                Exit Sub
            End If

            Forma.Execute()
            If Forma.Selecciono Then
                TxtNumero.Text = Forma.Traslado_Id
                CargaDocumento()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Sub EliminarMovimiento()
        Dim TrasladoEncabezado As New TTrasladoEncabezado(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            With TrasladoEncabezado
                .Emp_Id = SucursalInfo.Emp_Id
                .Traslado_Id = CLng(TxtNumero.Text)
            End With

            Mensaje = TrasladoEncabezado.EliminarDocumento()
            VerificaMensaje(Mensaje)

            Inicializa()
            TxtNumero.Focus()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TrasladoEncabezado = Nothing
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
                        BuscarMovimiento()
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
        Dim Forma As New FrmBuscaArticuloSucBodOnLine
        Try

            If Not ValidaSucursalBodega() Then
                Exit Try
            End If


            With Forma
                .Suc_Id = CInt(CmbSucursalOrigen.SelectedValue)
                .Bod_Id = CInt(CmbBodegaOrigen.SelectedValue)
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
                BuscarMovimiento()
            Case "TxtArticulo"
                BuscarArticulo()
        End Select
    End Sub
    Private Sub TxtNumero_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtNumero.KeyDown
        Select Case e.KeyCode
            'Case Keys.F1
            '    BuscarMovimiento()
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
            If MsgBox("Desea aplicar el movimiento?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                If VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.InvAplicaTrasladoInventario, True) Then
                    GuardarDocumento(True, UsuarioInfo.Usuario_Id)
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub Eliminar()
        Try
            If MsgBox("Desea eliminar el movimiento?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                EliminarMovimiento()
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
        Dim TrasladoEncabezado As New TTrasladoEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte As New TrasladoInventario
        Dim FormaReporte As New FrmReporte
        Try

            Cursor.Current = Cursors.WaitCursor
            BtnImprimir.Enabled = False

            With TrasladoEncabezado
                .Emp_Id = SucursalInfo.Emp_Id
                .Traslado_Id = CLng(TxtNumero.Text)
            End With

            Mensaje = TrasladoEncabezado.RptTrasladoInventario()
            VerificaMensaje(Mensaje)

            If PrintLocation.NaturalMedica = InfoMaquina.PrintLocation Then

                Dim detalles As New List(Of TTrasladoDetalle)()

                For Each row As DataRow In TrasladoEncabezado.Data.Tables(0).Rows
                    Dim detalle As New TTrasladoDetalle(EmpresaInfo.Emp_Id)

                    With detalle
                        .Fecha = row("Fecha").ToString()
                        .Costo = row("Costo").ToString()
                        .TotalLinea = row("TotalLinea").ToString()
                        .Cantidad = row("Cantidad").ToString()
                        .Art_Id = row("Art_Id").ToString()
                    End With

                    detalles.Add(detalle)

                    With TrasladoEncabezado
                        .Costo = row("TotalCosto").ToString()
                        .Fecha = row("Fecha").ToString()
                        .SucDestino_Id = row("SucDestino_Id").ToString()
                        .SucOrigen_Id = row("SucOrigen_Id").ToString()
                        .Comentario = row("Comentario").ToString()
                    End With
                Next

                TrasladoEncabezado.ListaDetalles = detalles

                Dim impresionPOS As New TImprimeNaturalTraslado(EmpresaInfo, EmpresaParametroInfo, TrasladoEncabezado)
                impresionPOS.Print(PrintLocation.NaturalMedica, False)
                MensajeError("Traslado impreso con existo.")
            Else

                If TrasladoEncabezado.RowsAffected = 0 Then
                    VerificaMensaje("No se encontraron datos para mostrar el reporte")
                End If

                Reporte.SetDataSource(TrasladoEncabezado.Data.Tables(0))


                'parametros encabezado y pie de pagina

                Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)


                If Form_Abierto("FrmReporte") = False Then
                    FormaReporte.Execute(Reporte)
                End If

            End If



        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            TrasladoEncabezado = Nothing
            BtnImprimir.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Sub Limpiar()
        Try
            Inicializa()
            TxtNumero.Focus()

            CmbSucursalOrigen.SelectedIndex = -1
            CmbSucursalDestino.SelectedIndex = -1

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
        Dim Forma As New FrmCargaArticulos
        Try


            If Not ValidaSucursalBodega() Then
                Exit Try
            End If


            With Forma
                .ValidaSueltos = False
                .VerificaBodega = True
                .Suc_Id = CInt(CmbSucursalOrigen.SelectedValue)
                .Bod_Id = CInt(CmbBodegaOrigen.SelectedValue)
            End With
            Forma.Execute()

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

    Private Sub CmbSucursalOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSucursalOrigen.SelectedIndexChanged
        Dim Bodega As New TBodega(EmpresaInfo.Emp_Id)
        Try
            If CmbSucursalOrigen.SelectedValue Is Nothing OrElse CmbSucursalOrigen.SelectedValue.ToString = "System.Data.DataRowView" Then
                Exit Sub
            End If

            Bodega.Suc_Id = CmbSucursalOrigen.SelectedValue
            VerificaMensaje(Bodega.LoadComboBox(CmbBodegaOrigen))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Bodega = Nothing
        End Try
    End Sub

    Private Sub CmbSucursalDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSucursalDestino.SelectedIndexChanged
        Dim Bodega As New TBodega(EmpresaInfo.Emp_Id)
        Try
            If CmbSucursalDestino.SelectedValue Is Nothing OrElse CmbSucursalDestino.SelectedValue.ToString = "System.Data.DataRowView" Then
                Exit Sub
            End If

            Bodega.Suc_Id = CmbSucursalDestino.SelectedValue
            VerificaMensaje(Bodega.LoadComboBox(CmbBodegaDestino))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Bodega = Nothing
        End Try
    End Sub
    Private Sub LoteDetalle()
        Dim Forma As New FrmLoteSeleccion
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
                            .Escaneado = item.SubItems(ColumnasDetalle.CantidadLote).Text
                        End With
                        Exit For
                    End If
                Next
            Next

            If Not IsNumeric(CmbSucursalOrigen.SelectedValue) Then
                VerificaMensaje("Debe de seleccionar la sucursal origen")
            End If

            If Not IsNumeric(CmbBodegaOrigen.SelectedValue) Then
                VerificaMensaje("Debe de seleccionar la bodega origen")
            End If

            Forma.Emp_Id = EmpresaInfo.Emp_Id
            Forma.Suc_Id = CInt(CmbSucursalOrigen.SelectedValue)
            Forma.Bod_Id = CInt(CmbBodegaOrigen.SelectedValue)
            Forma.Lotes = _Lotes
            Forma.Execute()
            _Lotes = Forma.Lotes
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
                    Dim Cantidad As Double = 0

                    For Each Lote In Articulo.Lotes
                        Cantidad += Lote.Cantidad
                    Next

                    item.SubItems(ColumnasDetalle.CantidadLote).Text = Format(Cantidad, "##0.00")
                End If
            Next
        Next
    End Sub

    Private Sub BtnLotes_Click(sender As Object, e As EventArgs) Handles BtnLotes.Click
        LoteDetalle()
    End Sub
End Class