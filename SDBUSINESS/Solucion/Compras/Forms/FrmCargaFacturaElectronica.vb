Imports System.ComponentModel
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports Business
Public Class FrmCargaFacturaElectronica
    Private Enum Columnas
        Linea = 0
        Candidad
        Codigo
        Art_Id
        DescripcionXML
        DescripcionInterna
        Art_Id_Tipo
        Costo
        Descuento
        ExentoIV
        TipoProducto
        MontoTotal
        MontoImpuesto
        TotalLinea
    End Enum
    Private Sub ConfiguraDetalle()
        Try

            With LvwDetalle
                .Columns(Columnas.Linea).Text = "Línea"
                .Columns(Columnas.Linea).Width = 80
                .Columns(Columnas.Linea).TextAlign = HorizontalAlignment.Right

                .Columns(Columnas.Codigo).Text = "Código"
                .Columns(Columnas.Codigo).Width = 110

                .Columns(Columnas.Art_Id).Text = "Interno"
                .Columns(Columnas.Art_Id).Width = 100

                .Columns(Columnas.Art_Id_Tipo).Text = "Cod Tipo"
                .Columns(Columnas.Art_Id_Tipo).Width = 120

                .Columns(Columnas.Candidad).Text = "Cantidad"
                .Columns(Columnas.Candidad).Width = 80
                .Columns(Columnas.Candidad).TextAlign = HorizontalAlignment.Right

                .Columns(Columnas.DescripcionXML).Text = "Descripción XML"
                .Columns(Columnas.DescripcionXML).Width = 290


                .Columns(Columnas.DescripcionInterna).Text = "Descripción Interna"
                .Columns(Columnas.DescripcionInterna).Width = 290

                .Columns(Columnas.Costo).Text = "Costo"
                .Columns(Columnas.Costo).Width = 100
                .Columns(Columnas.Costo).TextAlign = HorizontalAlignment.Right

                .Columns(Columnas.Descuento).Text = "Descuento"
                .Columns(Columnas.Descuento).Width = 0
                .Columns(Columnas.Descuento).TextAlign = HorizontalAlignment.Right

                .Columns(Columnas.ExentoIV).Text = "Exento"
                .Columns(Columnas.ExentoIV).Width = 60
                .Columns(Columnas.ExentoIV).TextAlign = HorizontalAlignment.Center

                .Columns(Columnas.TipoProducto).Text = "Tipo Producto"
                .Columns(Columnas.TipoProducto).Width = 80
                .Columns(Columnas.TipoProducto).TextAlign = HorizontalAlignment.Center

                .Columns(Columnas.MontoTotal).Text = "MontoTotal"
                .Columns(Columnas.MontoTotal).Width = 0
                .Columns(Columnas.MontoTotal).TextAlign = HorizontalAlignment.Right

                .Columns(Columnas.MontoImpuesto).Text = "Impuesto"
                .Columns(Columnas.MontoImpuesto).Width = 0
                .Columns(Columnas.MontoImpuesto).TextAlign = HorizontalAlignment.Right

                .Columns(Columnas.TotalLinea).Text = "TotalLinea"
                .Columns(Columnas.TotalLinea).Width = 130
                .Columns(Columnas.TotalLinea).TextAlign = HorizontalAlignment.Right
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub FrmCargaFacturaElectroica_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Me.Width = Screen.PrimaryScreen.WorkingArea.Size.Width
            Me.Height = Screen.PrimaryScreen.WorkingArea.Size.Height - 50
            Me.CenterToScreen()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute()
        Try
            ConfiguraDetalle()

            LimpiaEncabezado()

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LoadFileXML()
        Dim Reader As XmlReader = Nothing
        Dim DocumentoXML As New XmlDocument
        Dim XMLStr As String = String.Empty
        Try

            OFD.Filter = "XML Files (*.xml)|*.xml"
            OFD.FilterIndex = 0
            OFD.DefaultExt = "xml"
            OFD.FileName = String.Empty
            OFD.InitialDirectory = "c:\"

            If OFD.ShowDialog = DialogResult.OK Then
                Reader = XmlReader.Create(OFD.FileName)
                Reader.MoveToContent()

                XMLStr = Reader.ReadOuterXml


                If XMLStr.IndexOf(coFEMensajeHacienda) >= 0 Then
                    VerificaMensaje("El tipo de documento seleccionado corresponde a un Acuse de Recibido, imposible cargar")
                End If

                If XMLStr.IndexOf(coFEFacturaElectronica) < 0 AndAlso XMLStr.IndexOf(coFETiqueteElectronico) < 0 Then
                    VerificaMensaje("El tipo de documento no es válido, únicamente se permite cargar Facturas o Tiquetes Electrónicos")
                End If


                DocumentoXML.LoadXml(XMLStr)

                CargaDetalle(DocumentoXML)
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Reader = Nothing
            DocumentoXML = Nothing
        End Try
    End Sub

    Private Sub LoadEmailXML()
        Dim Forma As New FrmInbox
        Dim DocumentoXML As New XmlDocument
        Try

            Forma.Execute()

            If Forma.StrXml <> String.Empty Then

                DocumentoXML.LoadXml(Forma.StrXml)

                CargaDetalle(DocumentoXML)
            End If


        Catch ex As Exception
            Forma = Nothing
            MensajeError(ex.Message)
        Finally
            DocumentoXML = Nothing
        End Try
    End Sub

    Private Sub LimpiaEncabezado()
        Try

            LblProveedor.Text = String.Empty
            LblProveedor.Tag = 0
            LblNombreComercial.Text = String.Empty
            LblProveedorInterno.Text = String.Empty

            BtnEntrada.Enabled = False
            PicProveedor.Visible = False
            BtnCreaProveedor.Visible = False

            RdbNombreRazonSocial.Visible = False
            RdbNombreComercial.Visible = False

            LblIdentificacionTipo.Text = String.Empty
            TxtIdentificacionNumero.Text = String.Empty
            TxtIdentificacionNumero.Tag = String.Empty
            LblTelefono.Text = String.Empty
            LblEmail.Text = String.Empty
            LblFechaDocumento.Text = String.Empty
            LblFechaDocumento.Tag = String.Empty
            LblTotalDocumento.Text = String.Empty
            LblConsecutivo.Text = String.Empty
            LblClave.Text = String.Empty

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaProveedor(pTipoIdentificacion_Id As Integer, pIdentificacionNumero As String) As String
        Dim Proveedor As New TProveedor(EmpresaInfo.Emp_Id)
        Try


            Proveedor.TipoIdentificacion_Id = pTipoIdentificacion_Id
            Proveedor.CedulaJuridica = pIdentificacionNumero
            VerificaMensaje(Proveedor.ProveedorxCedula)
            If Proveedor.RowsAffected = 0 Then
                BtnCreaProveedor.Visible = True
                LblProveedor.Tag = 0
                BtnEntrada.Enabled = False
                PicProveedor.Visible = False
                RdbNombreRazonSocial.Checked = True
                RdbNombreRazonSocial.Visible = True
                RdbNombreComercial.Visible = True
            Else
                BtnCreaProveedor.Visible = False
                BtnEntrada.Enabled = True
                LblProveedor.Tag = Proveedor.Data.Tables(0).Rows(0).Item("Prov_Id")
                PicProveedor.Visible = True

                LblProveedorInterno.Text = Proveedor.Data.Tables(0).Rows(0).Item("Prov_Id").ToString & "-" & Proveedor.Data.Tables(0).Rows(0).Item("Nombre").ToString
            End If


            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Proveedor = Nothing
        End Try
    End Function

    Private Sub CargaDetalle(pDocumentoXML As XmlDocument)
        Dim items(13) As String
        Dim LineaId As Integer = 0
        Dim Item As ListViewItem = Nothing
        Dim DS As New DetalleServicio
        Dim Valor As String = String.Empty
        Dim TipoIdentificacion As New TTipoIdentificacion(EmpresaInfo.Emp_Id)
        Dim CedulaReceptor As String = String.Empty
        'Dim Resultado As Boolean = True
        'Dim Validacion As String = String.Empty
        'Dim oTipo As Integer = 0
        'Dim oArt_Id As String = String.Empty
        'Dim oNombre As String = String.Empty
        Try

            Cursor = Cursors.WaitCursor

            LimpiaEncabezado()

            If Not pDocumentoXML.InnerXml.IndexOf("<DetalleServicio>") <= 0 Then

                CedulaReceptor = GetValorXSeccion(pDocumentoXML, "Receptor", "Numero")
                If CedulaReceptor.Trim <> String.Empty AndAlso CedulaReceptor.Trim <> EmpresaInfo.Cedula.Trim Then
                    If Not ConfirmaAccion("El número de identificación del documento seleccionado es diferente al registrado en la empresa, Desea Continuar?") Then
                        Exit Sub
                    End If
                End If

                LblProveedor.Text = GetValorXSeccion(pDocumentoXML, "Emisor", "Nombre")
                LblNombreComercial.Text = GetValorXSeccion(pDocumentoXML, "Emisor", "NombreComercial")

                Valor = GetValorXSeccion(pDocumentoXML, "Emisor", "Tipo")

                If IsNumeric(Valor) Then
                    TipoIdentificacion.TipoIdentificacion_Id = CInt(Valor)
                Else
                    TipoIdentificacion.TipoIdentificacion_Id = Enum_TipoIdentificacion.Fisica
                End If
                VerificaMensaje(TipoIdentificacion.ListKey)

                LblIdentificacionTipo.Text = TipoIdentificacion.Nombre.ToUpper()
                LblIdentificacionTipo.Tag = TipoIdentificacion.TipoIdentificacion_Id
                TxtIdentificacionNumero.Text = GetValorXSeccion(pDocumentoXML, "Emisor", "Numero").Trim()

                VerificaMensaje(ValidaProveedor(TipoIdentificacion.TipoIdentificacion_Id, TxtIdentificacionNumero.Text.Trim))

                LblTelefono.Text = GetValorXSeccion(pDocumentoXML, "Emisor", "NumTelefono")
                LblEmail.Text = GetValorXSeccion(pDocumentoXML, "Emisor", "CorreoElectronico").ToLower()
                LblFechaDocumento.Text = CDate(GetXmlMessageLabelValue(pDocumentoXML.InnerXml, "FechaEmision")).ToString("dd/MM/yyyy HH:mm")
                LblFechaDocumento.Tag = CDate(GetXmlMessageLabelValue(pDocumentoXML.InnerXml, "FechaEmision"))
                LblTotalDocumento.Text = CDbl(GetXmlMessageLabelValue(pDocumentoXML.InnerXml, "TotalComprobante")).ToString("#,##0.00")
                LblConsecutivo.Text = GetXmlMessageLabelValue(pDocumentoXML.InnerXml, "NumeroConsecutivo")
                LblClave.Text = GetXmlMessageLabelValue(pDocumentoXML.InnerXml, "Clave")



                Dim xmlDetalle As String = pDocumentoXML.InnerXml.Substring(pDocumentoXML.InnerXml.IndexOf("<DetalleServicio>"), pDocumentoXML.InnerXml.IndexOf("</DetalleServicio>") - (pDocumentoXML.InnerXml.IndexOf("<DetalleServicio>") - 18))
                Dim serializer As XmlSerializer = New XmlSerializer(GetType(DetalleServicio))
                Dim readerDetalle As StringReader = New StringReader(xmlDetalle)
                DS = serializer.Deserialize(readerDetalle)

                LvwDetalle.Items.Clear()

                For Each det As LineaDetalle In DS.LineaDetalle
                    LineaId += 1

                    TSSLMensaje.Text = "Cargando Línea # " & LineaId.ToString() & " de " & DS.LineaDetalle.Count.ToString() : StatusStrip1.Refresh() : Application.DoEvents()

                    items(Columnas.Linea) = LineaId
                    If det.CodigoComercial.Count > 0 Then
                        items(Columnas.Codigo) = det.CodigoComercial(0).Codigo
                    Else
                        items(Columnas.Codigo) = String.Empty
                    End If
                    items(Columnas.Candidad) = det.Cantidad.ToString("#,##0.000")
                    items(Columnas.DescripcionXML) = det.Detalle
                    items(Columnas.Costo) = det.PrecioUnitario.ToString("#,##0.00000")
                    items(Columnas.Descuento) = det.Descuento.MontoDescuento.ToString("#,##0.00000")

                    If det.Impuesto.Count > 0 AndAlso det.Impuesto(0).Tarifa > 0 Then
                        items(Columnas.ExentoIV) = "NO"
                    Else
                        items(Columnas.ExentoIV) = "SI"
                    End If

                    items(Columnas.TipoProducto) = Enum_TipoProducto.Servicio.ToString()


                    If det.Impuesto.Count > 0 Then
                        items(Columnas.MontoImpuesto) = det.Impuesto(0).Monto.ToString("#,##0.00000")
                    Else
                        items(Columnas.MontoImpuesto) = "0.00000"
                    End If

                    items(Columnas.MontoTotal) = det.MontoTotal.ToString("#,##0.00000")
                    items(Columnas.TotalLinea) = det.MontoTotalLinea.ToString("#,##0.00000")

                    'If items(Columnas.Codigo).Trim <> String.Empty Then
                    '    Validacion = ValidaCodigoArticulo(LblProveedor.Tag, items(Columnas.Codigo), oTipo, oArt_Id, oNombre)
                    'End If

                    'If Validacion.Trim = String.Empty Then
                    '    Select Case oTipo
                    '        Case Enum_Art_Id_Tipo.Interno
                    '            items(Columnas.Art_Id_Tipo) = Enum_Art_Id_Tipo.Interno.ToString()
                    '        Case Enum_Art_Id_Tipo.Equivalente
                    '            items(Columnas.Art_Id_Tipo) = Enum_Art_Id_Tipo.Equivalente.ToString()
                    '        Case Enum_Art_Id_Tipo.EquivalenteProveedor
                    '            items(Columnas.Art_Id_Tipo) = Enum_Art_Id_Tipo.EquivalenteProveedor.ToString()
                    '        Case Enum_Art_Id_Tipo.NoExiste
                    '            items(Columnas.Art_Id_Tipo) = Enum_Art_Id_Tipo.NoExiste.ToString()
                    '    End Select
                    '    items(Columnas.Art_Id) = oArt_Id
                    '    items(Columnas.DescripcionInterna) = oNombre
                    'Else
                    '    items(Columnas.Codigo) = String.Empty
                    '    items(Columnas.Art_Id_Tipo) = Enum_Art_Id_Tipo.NoExiste.ToString()
                    '    items(Columnas.DescripcionInterna) = Validacion
                    'End If



                    Item = New ListViewItem(items)

                    'If items(Columnas.Art_Id_Tipo) = Enum_Art_Id_Tipo.NoExiste.ToString() Then
                    '    'ListViewCambiaColorCelda(Item, Color.Red, Columnas.Codigo)
                    '    ListViewCambiaColorFilaTexto(Item, Color.Red)
                    'End If

                    LvwDetalle.Items.Add(Item)
                    Item.EnsureVisible()


                Next

                ValidaArticulos()

            Else
                VerificaMensaje("No se encontro el detalle del documento")
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            items = Nothing
            Item = Nothing
            DS = Nothing
            TipoIdentificacion = Nothing
            Cursor = Cursors.Default
            TSSLMensaje.Text = "" : StatusStrip1.Refresh() : Application.DoEvents()
        End Try
    End Sub
    Private Sub ValidaArticulos(Optional ByVal pArt_Id As String = "")
        Dim Validacion As String = String.Empty
        Dim oTipo As Integer = 0
        Dim oArt_Id As String = String.Empty
        Dim oNombre As String = String.Empty
        Dim oServicio As Boolean = False
        Dim ProvId As Integer = 0


        If IsNumeric(LblProveedor.Tag) Then
            ProvId = CInt(LblProveedor.Tag)
        End If



        For Each item As ListViewItem In LvwDetalle.Items
            If pArt_Id <> String.Empty Then
                If pArt_Id <> item.SubItems(Columnas.Codigo).Text Then
                    Continue For
                End If
            End If

            Validacion = ValidaCodigoArticulo(ProvId, item.SubItems(Columnas.Codigo).Text, oTipo, oArt_Id, oNombre, oServicio)

            If Validacion.Trim() <> String.Empty Then
                item.SubItems(Columnas.Art_Id_Tipo).Text = Enum_Art_Id_Tipo.Errores.ToString
                item.SubItems(Columnas.DescripcionInterna).Text = Validacion
                item.ImageIndex = 1
                ListViewCambiaColorFilaTexto(item, Color.Red)
            Else
                Select Case oTipo
                    Case Enum_Art_Id_Tipo.NoExiste
                        item.SubItems(Columnas.Art_Id_Tipo).Text = Enum_Art_Id_Tipo.NoExiste.ToString()
                        item.ImageIndex = 1
                    Case Enum_Art_Id_Tipo.Interno
                        item.SubItems(Columnas.Art_Id_Tipo).Text = Enum_Art_Id_Tipo.Interno.ToString()
                        ListViewCambiaColorFilaTexto(item, Color.DarkBlue)
                        item.ImageIndex = 0
                        item.Checked = True
                    Case Enum_Art_Id_Tipo.Equivalente
                        item.SubItems(Columnas.Art_Id_Tipo).Text = Enum_Art_Id_Tipo.Equivalente.ToString()
                        ListViewCambiaColorFilaTexto(item, Color.DarkGreen)
                        item.ImageIndex = 0
                        item.Checked = True
                    Case Enum_Art_Id_Tipo.EquivalenteProveedor
                        item.SubItems(Columnas.Art_Id_Tipo).Text = Enum_Art_Id_Tipo.EquivalenteProveedor.ToString()
                        ListViewCambiaColorFilaTexto(item, Color.Purple)
                        item.ImageIndex = 0
                        item.Checked = True
                End Select
                item.SubItems(Columnas.DescripcionInterna).Text = oNombre
                item.SubItems(Columnas.Art_Id).Text = oArt_Id
                item.SubItems(Columnas.TipoProducto).Text = IIf(oServicio, Enum_TipoProducto.Servicio.ToString(), Enum_TipoProducto.Producto.ToString())
            End If
            item.EnsureVisible()
            LvwDetalle.Refresh()
        Next
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnArchivo_Click(sender As Object, e As EventArgs) Handles BtnArchivo.Click
        Try

            LoadFileXML()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnEmail_Click(sender As Object, e As EventArgs) Handles BtnEmail.Click
        Dim RecepcionFacturaEmail As New TRecepcionFacturaEmail(EmpresaInfo.Emp_Id)
        Try

            VerificaMensaje(RecepcionFacturaEmail.List())
            If RecepcionFacturaEmail.RowsAffected = 0 Then
                VerificaMensaje("Aun no se ha indicado una cuenta de correo")
            End If


            LoadEmailXML()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            RecepcionFacturaEmail = Nothing
        End Try
    End Sub

    Private Sub BtnCreaProveedor_Click(sender As Object, e As EventArgs) Handles BtnCreaProveedor.Click
        Dim Forma As New FrmMantProveedorDetalle
        Try

            With Forma
                .Nuevo = True
                .Nombre = IIf(RdbNombreRazonSocial.Checked, LblProveedor.Text.ToUpper(), LblNombreComercial.Text.ToUpper())
                If IsNumeric(LblIdentificacionTipo.Tag) Then
                    .TipoIdentificacion = CInt(LblIdentificacionTipo.Tag)
                Else
                    .TipoIdentificacion = 0
                End If
                .CedulaJuridica = TxtIdentificacionNumero.Text
                .Telefono = LblTelefono.Text
                .Email = LblEmail.Text.Trim().ToLower()
            End With


            Forma.Execute(-1)

            If Forma.GuardoCambios Then
                BtnCreaProveedor.Visible = False
                LblProveedor.Tag = Forma.NuevoId
                BtnEntrada.Enabled = True
                PicProveedor.Visible = True
                RdbNombreRazonSocial.Visible = False
                RdbNombreComercial.Visible = False
                LblProveedorInterno.Text = Forma.NuevoId.ToString & "-" & Forma.NuevoNombre
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnArticuloCrea_Click(sender As Object, e As EventArgs) Handles BtnArticuloCrea.Click
        Dim Forma As New FrmMantArticuloCreaMasivo
        Try

            For Each item As ListViewItem In LvwDetalle.Items
                If item.SubItems(Columnas.Art_Id_Tipo).Text = Enum_Art_Id_Tipo.NoExiste.ToString() AndAlso item.SubItems(Columnas.Codigo).Text.Trim <> String.Empty Then
                    Forma.Articulos.Add(New TArticuloConteo With {.Art_Id = item.SubItems(Columnas.Codigo).Text,
                                     .Descripcion = item.SubItems(Columnas.DescripcionXML).Text,
                                     .Costo = item.SubItems(Columnas.Costo).Text,
                                     .Exento = IIf(item.SubItems(Columnas.ExentoIV).Text.ToUpper() = "SI", True, False)})
                End If
            Next

            Forma.Execute()

            ValidaArticulos()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuMarcarTodos_Click(sender As Object, e As EventArgs) Handles MnuMarcarTodos.Click
        ListViewMarcaDesmarca(LvwDetalle, True)
    End Sub

    Private Sub MnuDesmarcharTodos_Click(sender As Object, e As EventArgs) Handles MnuDesmarcharTodos.Click
        ListViewMarcaDesmarca(LvwDetalle, False)
    End Sub

    Private Sub MnuProductoServicio_Click(sender As Object, e As EventArgs) Handles MnuProductoServicio.Click
        Dim Forma As New FrmMantArticuloEquivalenteProveedor
        Dim Item As ListViewItem = Nothing
        Try

            If LvwDetalle.SelectedItems Is Nothing OrElse LvwDetalle.SelectedItems.Count = 0 Then
                MensajeError("Debe de seleccionar un producto")
                Exit Sub
            End If

            If Not IsNumeric(LblProveedor.Tag) OrElse CInt(LblProveedor.Tag) = 0 Then
                MensajeError("Para asociar un producto primero debe de crear el proveedor")
                Exit Sub
            End If

            Item = LvwDetalle.SelectedItems(0)

            If Item.SubItems(Columnas.Codigo).Text.Trim = String.Empty Then
                VerificaMensaje("El producto seleccionado no tiene definido un código de proveedor en el XML")
            End If


            With Forma
                .Prov_Id = CInt(LblProveedor.Tag)
                .Prov_Nombre = LblProveedor.Text
                .Prov_ArtId = Item.SubItems(Columnas.Codigo).Text.Trim
                .Prov_ArtNombre = Item.SubItems(Columnas.DescripcionXML).Text.Trim
            End With

            Forma.Execute()

            If Forma.ArtInterno_Id <> String.Empty Then
                Item.SubItems(Columnas.Art_Id_Tipo).Text = Enum_Art_Id_Tipo.EquivalenteProveedor.ToString()
                Item.SubItems(Columnas.Art_Id).Text = Forma.ArtInterno_Id
                Item.SubItems(Columnas.DescripcionInterna).Text = Forma.ArtInterno_Nombre
                ListViewCambiaColorFilaTexto(Item, Color.Purple)
                Item.ImageIndex = 0
            Else
                ValidaArticulos(Item.SubItems(Columnas.Codigo).Text)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub CMSDetalle_Opening(sender As Object, e As CancelEventArgs) Handles CMSDetalle.Opening
        Try

            If LvwDetalle.Items.Count = 0 Then
                e.Cancel = True
                Exit Sub
            End If

            If Not IsNumeric(LblProveedor.Tag) Then
                MnuProductoServicio.Enabled = False
            Else
                MnuProductoServicio.Enabled = True
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnEntrada_Click(sender As Object, e As EventArgs) Handles BtnEntrada.Click
        Dim Forma As New FrmEntradaMercaderia
        Dim ListaArticulos As New List(Of TArticuloConteo)
        Dim SeleccionoServicio As Boolean = False
        Dim EntradaEncabezado As New TEntradaEncabezado(EmpresaInfo.Emp_Id)
        Try

            If Not IsNumeric(LblProveedor.Tag) OrElse CInt(LblProveedor.Tag) <= 0 Then
                VerificaMensaje("Proveedor no válido")
            End If

            For Each item As ListViewItem In LvwDetalle.Items
                If item.Checked AndAlso item.SubItems(Columnas.TipoProducto).Text = Enum_TipoProducto.Servicio.ToString() Then
                    SeleccionoServicio = True
                    item.Checked = False
                End If
            Next



            For Each item As ListViewItem In LvwDetalle.Items
                If item.Checked AndAlso item.SubItems(Columnas.TipoProducto).Text = Enum_TipoProducto.Producto.ToString() AndAlso
                    (item.SubItems(Columnas.Art_Id_Tipo).Text = Enum_Art_Id_Tipo.Interno.ToString() OrElse
                    item.SubItems(Columnas.Art_Id_Tipo).Text = Enum_Art_Id_Tipo.Equivalente.ToString() OrElse
                    item.SubItems(Columnas.Art_Id_Tipo).Text = Enum_Art_Id_Tipo.EquivalenteProveedor.ToString()) Then

                    ListaArticulos.Add(New TArticuloConteo With {.Art_Id = item.SubItems(Columnas.Art_Id).Text,
                                                                 .Cantidad = item.SubItems(Columnas.Candidad).Text,
                                                                 .Costo = CDbl(item.SubItems(Columnas.Costo).Text),
                                                                 .Descripcion = item.SubItems(Columnas.DescripcionInterna).Text,
                                                                 .Exento = IIf(item.SubItems(Columnas.ExentoIV).Text = "SI", True, False),
                                                                 .Descuento = (CDbl(item.SubItems(Columnas.Descuento).Text) / CDbl(item.SubItems(Columnas.Candidad).Text))
                                                                })

                End If
            Next

            If ListaArticulos.Count = 0 Then
                VerificaMensaje("Debe de seleccionar al menos una línea")
            End If

            If SeleccionoServicio Then
                VerificaMensaje("No se permiten seleccionar servicios para hacer una entrada de mercadería")
            End If

            If LblClave.Text.Trim.Length <> 50 Then
                VerificaMensaje("No se encontró la clave electronica del documento")
            End If

            EntradaEncabezado.Clave = LblClave.Text.Trim()
            VerificaMensaje(EntradaEncabezado.EntradaxClave())
            If EntradaEncabezado.RowsAffected > 0 Then
                If Not ConfirmaAccion("La factura ya fue cargada anteriormente el " & EntradaEncabezado.Fecha.ToString("dd/MM/yyyy") & ", Desea volver a generar una entrada?") Then
                    Exit Sub
                End If
            End If

            Cursor = Cursors.WaitCursor

            Forma.Execute(True, CInt(LblProveedor.Tag), ListaArticulos, LblClave.Text)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
            Cursor = Cursors.Default
            EntradaEncabezado = Nothing
        End Try
    End Sub

    Private Sub BtnArticulo_Click(sender As Object, e As EventArgs) Handles BtnArticulo.Click
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

    Private Sub BtnProveedor_Click(sender As Object, e As EventArgs) Handles BtnProveedor.Click
        Dim Forma As New FrmMantProveedorLista
        Try
            'Forma.MdiParent = Me
            Forma.Execute(True)


            If IsNumeric(LblIdentificacionTipo.Tag) AndAlso TxtIdentificacionNumero.Text.Trim <> String.Empty Then
                VerificaMensaje(ValidaProveedor(CInt(LblIdentificacionTipo.Tag), TxtIdentificacionNumero.Text.Trim))
            End If



        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnFacturarCR_Click(sender As Object, e As EventArgs) Handles BtnFacturarCR.Click
        Dim Forma As New FrmComprasFacturarCR
        Dim DocumentoXML As New XmlDocument
        Try

            Forma.Execute()

            If Forma.Acepto Then
                DocumentoXML.LoadXml(Forma.Xml)
                CargaDetalle(DocumentoXML)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
            DocumentoXML = Nothing
        End Try
    End Sub
End Class