﻿Imports Business
Imports System.Threading
Public Class FrmPuntoVentaClasico
#Region "Declaración de variables"
    Dim Numerico() As TNumericFormat
    Dim InfoArticulo As New TInfoArticulo(EmpresaInfo.Emp_Id)
    Private _ListaConjuntos As New List(Of TInfoArticuloConjunto)
    'Dim _FacturaCxCLlave As TFacturaCxCLlave
    Dim _Proforma As TProformaEncabezado
    Dim _FacturaDev As TFacturaEncabezado
    Dim _ReferenciaNC As TReferenciaNC
    Dim _Comentario As String
    Dim _TipoFacturacion As Enum_TipoFacturacion
    Dim _Loaded As Boolean = False
    Dim _CerrarAlGuardar As Boolean = False
    Dim _CargandoProforma As Boolean = False
    Dim _CargandoFacturaDev As Boolean = False
    Dim cargaVendedor As Boolean = False
    Dim _CxCDevolucionFacturas As New List(Of SDFinancial.DTCxCMovimientoLinea)
    Dim _MontoNotaAdicional As Double = 0
    Dim _MontoDevolucionFacturas As Double = 0
    Dim _TipoDevolucion As Enum_TipoDevolucion
    'Dim _FacturaDetalleImpuestos As New List(Of TFacturaDetalleImpuesto)
    Dim _CargandoArchivo As Boolean = False

#End Region
#Region "Declaracion de Enums"
    Private Enum TipoCantidadEtiqueta
        Peso = 0
        Unidad = 1
    End Enum
    Private Enum AccionDetalle
        Nuevo = 0
        Sumariza = 1
        Modifica = 2
    End Enum
    Private Enum ColumnasDetalle
        Linea = 0
        Articulo = 1
        Cantidad = 2
        Nombre = 3
        Precio = 4
        PorcDescuento = 5
        MontoDescuento = 6
        Suelto = 7
        Padre = 8
        Conjunto = 9
        Exento = 10
        MontoIV = 11
        Saldo = 12
        Costo = 13
        TotalLinea = 14
        Observacion = 15
        Servicio = 16
        CalculaCantidadFactura = 17
    End Enum
#End Region

    Private Function SeleccionaPorcDescuento() As Double
        Dim PorcDescuento As Double = 0
        Try

            If Not IsNumeric(TxtPorcDescGlobal.Text) Then
                TxtPorcDescGlobal.Text = "0.00"
            End If

            If Not IsNumeric(TxtPorcDescLinea.Text) Then
                TxtPorcDescLinea.Text = "0.00"
            End If

            If CDbl(TxtPorcDescGlobal.Text) > CDbl(TxtPorcDescLinea.Text) Then
                PorcDescuento = CDbl(TxtPorcDescGlobal.Text)
            Else
                PorcDescuento = CDbl(TxtPorcDescLinea.Text)
            End If
        Catch ex As Exception
            PorcDescuento = 0
        End Try

        Return PorcDescuento
    End Function


    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(7)

            Numerico(0) = New TNumericFormat(TxtTipoDocumento, 2, 0, False, "", "###0")
            Numerico(1) = New TNumericFormat(TxtCliente, 6, 0, False, "", "###0")
            Numerico(2) = New TNumericFormat(TxtVendedor, 4, 0, False, "", "###0")
            Numerico(3) = New TNumericFormat(TxtPrecio, 12, 4, False, "0")
            Numerico(4) = New TNumericFormat(TxtPorcDescLinea, 3, 2, False, "0")
            Numerico(5) = New TNumericFormat(TxtCantidad, 5, 4, False, "0")
            Numerico(6) = New TNumericFormat(TxtPorcDescGlobal, 3, 2, False, "0")
            Numerico(7) = New TNumericFormat(TxtCantidadAntes, 5, 2, False, "")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub ConfiguraDetalle()
        Try
            With LvwDetalle
                .Columns(ColumnasDetalle.Linea).Text = "Línea"
                .Columns(ColumnasDetalle.Linea).Width = 45

                .Columns(ColumnasDetalle.Articulo).Text = "Código"
                .Columns(ColumnasDetalle.Articulo).Width = 120

                .Columns(ColumnasDetalle.Cantidad).Text = "Cantidad"
                .Columns(ColumnasDetalle.Cantidad).Width = 100
                .Columns(ColumnasDetalle.Cantidad).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.Nombre).Text = "Descripción"
                .Columns(ColumnasDetalle.Nombre).Width = 300

                .Columns(ColumnasDetalle.Precio).Text = "Precio"
                .Columns(ColumnasDetalle.Precio).Width = 100
                .Columns(ColumnasDetalle.Precio).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.PorcDescuento).Text = "% Desc"
                .Columns(ColumnasDetalle.PorcDescuento).Width = 70
                .Columns(ColumnasDetalle.PorcDescuento).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.MontoDescuento).Text = "Descuento"
                .Columns(ColumnasDetalle.MontoDescuento).Width = 120
                .Columns(ColumnasDetalle.MontoDescuento).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.Suelto).Text = "Suelto"
                .Columns(ColumnasDetalle.Suelto).Width = 0

                .Columns(ColumnasDetalle.Padre).Text = "Padre"
                .Columns(ColumnasDetalle.Padre).Width = 0

                .Columns(ColumnasDetalle.Conjunto).Text = "Conjunto"
                .Columns(ColumnasDetalle.Conjunto).Width = 0

                .Columns(ColumnasDetalle.Exento).Text = "Exento"
                .Columns(ColumnasDetalle.Exento).Width = 0

                .Columns(ColumnasDetalle.MontoIV).Text = "MontoIV"
                .Columns(ColumnasDetalle.MontoIV).Width = 120
                .Columns(ColumnasDetalle.MontoIV).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.Saldo).Text = "Saldo"
                .Columns(ColumnasDetalle.Saldo).Width = 0

                .Columns(ColumnasDetalle.Costo).Text = "Costo"
                .Columns(ColumnasDetalle.Costo).Width = 0

                .Columns(ColumnasDetalle.TotalLinea).Text = "Total Línea"
                .Columns(ColumnasDetalle.TotalLinea).Width = 120
                .Columns(ColumnasDetalle.TotalLinea).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.Observacion).Text = "Comentario"
                .Columns(ColumnasDetalle.Observacion).Width = 120
                .Columns(ColumnasDetalle.Observacion).TextAlign = HorizontalAlignment.Left

                .Columns(ColumnasDetalle.Servicio).Text = "Servicio"
                .Columns(ColumnasDetalle.Servicio).Width = 0

                .Columns(ColumnasDetalle.CalculaCantidadFactura).Text = "CalculaCantidadFactura"
                .Columns(ColumnasDetalle.CalculaCantidadFactura).Width = 0
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub Inicializa()
        Try

            If EmpresaParametroInfo.FacturacionElectronica Then
                RefrescaLeyendaFEPendiente()
            End If
            If EmpresaParametroInfo.InterfazCxC Then
                RefrescaLeyendaCxCPendiente()
            End If

            '_FacturaDetalleImpuestos.Clear()

            TxtTipoCambio.Text = TipoCambioCierreCaja(CajaInfo.Suc_Id, CajaInfo.Caja_Id, CajaInfo.Cierre_Id).ToString("#,##0.00")
            TxtTipoCambio.ForeColor = Color.Black

            _TipoDevolucion = Enum_TipoDevolucion.Original
            LblNumeroDoc.Visible = False
            LblNumeroDoc.Text = ""

            TxtTipoDocumento.Enabled = True
            TxtTipoDocumento.Text = ""
            TxtTipoDocumentoNombre.Text = ""
            TxtCliente.Text = ""
            TxtClienteNombre.Text = ""
            TxtPrecioId.Text = ""
            TxtVendedor.Text = ""
            TxtVendedorNombre.Text = ""
            TxtComentario.Text = ""
            TxtPorcDescGlobal.Text = "0.00"
            TxtExento.Text = "NO"
            TxtDolares.Text = "NO"
            TSSLDocumentoElectronico.Text = ""
            PanelDetalle.Enabled = False

            LvwDetalle.Items.Clear()
            LblSubTotal.Text = "0.00"
            LblDescuento.Text = "0.00"
            LblImpuestoVenta.Text = "0.00"
            LblTotal.Text = "0.00"

            LblTotalGrande.Text = "0.00"
            LblTotalGrande.Visible = False

            LblTotalDolares.Text = "0.00"
            LblTotalDolares.Visible = False

            ActivarEdicionArticulo(False)
            InicializaArticulo()
            TxtArticulo.Text = ""
            If InfoMaquina.InterfazFactura = Enum_InterfazFacturacion.CantidadAntes Then
                TxtCantidadAntes.Text = ""
            End If
            InfoArticulo.ListaConjuntos.Clear()
            '_FacturaCxCLlave = Nothing
            _Proforma = Nothing
            _FacturaDev = Nothing
            _ReferenciaNC = Nothing
            _Comentario = ""

            _CxCDevolucionFacturas.Clear()
            _MontoNotaAdicional = 0
            _MontoDevolucionFacturas = 0

            LblPorcDescGlobal.Visible = False
            TxtPorcDescGlobal.Visible = False
            LblExento.Visible = False
            TxtExento.Visible = False

            LblDolares.Visible = False
            TxtDolares.Visible = False

            LblTipoCambio.Visible = False
            TxtTipoCambio.Visible = False

            cargaVendedor = False
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub



    'Private Sub AsignaLogoDetalle()
    '    If Not EmpresaInfo.Logo Is Nothing Then
    '        Using ms As New MemoryStream()
    '            ms.Write(EmpresaInfo.Logo, 0, EmpresaInfo.Logo.Length)
    '            LvwDetalle.BackgroundImage = Image.FromStream(ms, True, True)
    '        End Using
    '    Else
    '        LvwDetalle.BackgroundImage = Nothing
    '    End If
    '    LvwDetalle.BackgroundImageTiled = True
    'End Sub

    Public Sub Execute(pTipoFacturacion As Enum_TipoFacturacion, pCliente_Id As Integer)
        _Loaded = False
        _CerrarAlGuardar = False
        _TipoFacturacion = pTipoFacturacion

        TxtTipoCambio.Text = TipoCambioCierreCaja(CajaInfo.Suc_Id, CajaInfo.Caja_Id, CajaInfo.Cierre_Id).ToString("#,##0.00")

        AsignaLogo(PicLogo)
        'AsignaLogoDetalle()

        Select Case _TipoFacturacion
            Case Enum_TipoFacturacion.Factura
                Me.Text = "Facturación"
                Me.ToolM1F3.Text = "Facturar"
            Case Enum_TipoFacturacion.Proforma
                Me.Text = "Proforma"
                ToolM1F9.Visible = False
                ToolM1F4.Visible = False
                Me.ToolM1F3.Text = "Proforma"
            Case Enum_TipoFacturacion.PreFactura
                Me.Text = "Pre Factura"
                ToolM1F8.Visible = False
                ToolM1F4.Visible = False
                Me.ToolM1F3.Text = "PreFactura"
            Case Enum_TipoFacturacion.Apartado
                Me.Text = "Apartado"
                ToolM1F8.Visible = False
                ToolM1F9.Visible = False
                ToolM1F4.Visible = False
                Me.ToolM1F3.Text = "Apartado"
        End Select

        Inicializa()


        If pCliente_Id > 0 Then
            _CerrarAlGuardar = True
            TxtVendedor.Text = UsuarioInfo.Vendedor_Id
            TxtCliente.Text = pCliente_Id
            TxtTipoDocumento_KeyDown(Me.TxtTipoDocumento, New KeyEventArgs(Keys.Enter))
            ValidaCliente(True)


            'ValidaCliente(True)
            TxtVendedor_KeyDown(Me.TxtVendedor, New KeyEventArgs(Keys.Enter))
        End If



        Me.ShowDialog()

    End Sub

    Private Sub CapturaComentarioDocumento()
        Dim Forma As New FrmComentario
        Try

            Forma.Titulo = "Comentario Documento"
            Forma.Comentario = _Comentario
            Forma.Execute()
            If Forma.Acepto Then
                _Comentario = Forma.Comentario
                TxtComentario.Text = _Comentario
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub CapturaComentarioLinea()
        Dim Forma As New FrmComentario
        Try

            If LvwDetalle.Items.Count = 0 OrElse LvwDetalle.SelectedItems Is Nothing OrElse LvwDetalle.SelectedItems.Count = 0 Then
                Exit Sub
            End If

            Forma.Titulo = "Observación Producto : " & Mid(LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Nombre).Text, 1, 50)

            Forma.Comentario = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Observacion).Text
            Forma.Execute()
            If Forma.Acepto Then
                LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Observacion).Text = Forma.Comentario
            End If

            If InfoMaquina.InterfazFactura = Enum_InterfazFacturacion.CantidadAntes Then
                TxtCantidadAntes.Focus()
            Else
                TxtArticulo.Focus()
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Function ValidaTipoDocumento() As Boolean
        Dim TipoDocumento As New TTipoDocumento(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Dim VerificarPermiso As Boolean = False
        Dim TipoPermiso As Permisos = Nothing
        Try
            If Not IsNumeric(TxtTipoDocumento.Text) Then
                VerificaMensaje("Debe de digitar un valor válido")
                EnfocarTexto(TxtTipoDocumento)
            End If

            TipoDocumento.TipoDoc_Id = TxtTipoDocumento.Text
            Mensaje = TipoDocumento.ListKey
            VerificaMensaje(Mensaje)

            If TipoDocumento.RowsAffected = 0 Then
                VerificaMensaje("Tipo de documento no válido")
                EnfocarTexto(TxtTipoDocumento)
            End If

            If Not TipoDocumento.Activo Then
                VerificaMensaje("El tipo de documento se encuentra inactivo")
                EnfocarTexto(TxtTipoDocumento)
            End If

            If _TipoFacturacion <> Enum_TipoFacturacion.Factura And (Val(TxtTipoDocumento.Text) = Enum_TipoDocumento.DevolucionContado Or Val(TxtTipoDocumento.Text) = Enum_TipoDocumento.DevolucionCredito) Then
                VerificaMensaje("El tipo de documento seleccionado es válido unicamente en facturación")
                EnfocarTexto(TxtTipoDocumento)
            End If

            If _TipoFacturacion = Enum_TipoFacturacion.Apartado And Val(TxtTipoDocumento.Text) <> Enum_TipoDocumento.Contado Then
                VerificaMensaje("Para crear apartados únicamente se permite el tipo " & Enum_TipoDocumento.Contado.ToString() & " (" & Enum_TipoDocumento.Contado & ")")
                EnfocarTexto(TxtTipoDocumento)
            End If

            Select Case TipoDocumento.TipoDoc_Id
                Case Enum_TipoDocumento.Credito
                    TipoPermiso = Permisos.PvFacturaCredito
                    VerificarPermiso = True
                Case Enum_TipoDocumento.DevolucionContado
                    TipoPermiso = Permisos.PvDevolucionContado
                    VerificarPermiso = True
                Case Enum_TipoDocumento.DevolucionCredito
                    TipoPermiso = Permisos.PvDevolucionCredito
                    VerificarPermiso = True
                Case Else
                    VerificarPermiso = False
            End Select

            If VerificarPermiso Then
                If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, TipoPermiso, False) Then
                    VerificaMensaje("No tiene permisos para seleccionar el tipo de documento")
                    EnfocarTexto(TxtTipoDocumento)
                End If
            End If




            Select Case CInt(TxtTipoDocumento.Text)
                Case Enum_TipoDocumento.Contado, Enum_TipoDocumento.Credito
                    LblPorcDescGlobal.Visible = True
                    TxtPorcDescGlobal.Visible = True
                    LblExento.Visible = True
                    TxtExento.Visible = True

                    LblDolares.Visible = True
                    TxtDolares.Visible = True
                    LblTipoCambio.Visible = False
                    TxtTipoCambio.Visible = False
                Case Enum_TipoDocumento.DevolucionContado, Enum_TipoDocumento.DevolucionCredito
                    LblPorcDescGlobal.Visible = False
                    TxtPorcDescGlobal.Visible = False
                    LblExento.Visible = False
                    TxtExento.Visible = False

                    LblDolares.Visible = False
                    TxtDolares.Visible = False
                    LblTipoCambio.Visible = False
                    TxtTipoCambio.Visible = False
            End Select


            TxtTipoDocumentoNombre.Text = TipoDocumento.Nombre
            TxtTipoDocumento.Enabled = False

            'Select Case CInt(TxtTipoDocumento.Text)
            '    Case Enum_TipoDocumento.Contado
            '        If TxtCliente.Text.Trim = "" And TipoDocumento.Cliente_Id > 0 Then
            '            TxtCliente.Text = TipoDocumento.Cliente_Id
            '        End If
            '        ValidaCliente(True)
            '        ValidaVendedor(True)
            '    Case Else
            '        TxtCliente.Focus()
            'End Select

            If CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.Contado And Not InfoMaquina.FacturaContadoSolicitaCliente Then
                If TxtCliente.Text.Trim = "" And TipoDocumento.Cliente_Id > 0 Then
                    TxtCliente.Text = TipoDocumento.Cliente_Id
                End If
                ValidaCliente(True)
                ValidaVendedor(True)
            Else
                TxtCliente.Focus()
            End If


            Return True
        Catch ex As Exception
            EnfocarTexto(TxtTipoDocumento)
            MensajeError(ex.Message)
            Return False
        Finally
            TipoDocumento = Nothing
        End Try
    End Function

    Private Sub BusquedaTipoDocumento()
        Dim Forma As New FrmMuestraValores
        Try
            Forma.ObjetoTabla = New TTipoDocumento(EmpresaInfo.Emp_Id)
            Forma.Titulo = "Tipo de documento"
            Forma.Execute()
            If Not Forma.Seleccion_Id Is Nothing Then
                TxtTipoDocumento.Text = CInt(Forma.Seleccion_Id)
                ValidaTipoDocumento()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub TxtTipoDocumento_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtTipoDocumento.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If TxtTipoDocumento.Text.Trim = "" Then
                    TxtTipoDocumento.Text = EmpresaParametroInfo.TipoFacturaDefault
                End If
                ValidaTipoDocumento()
        End Select
    End Sub

    Private Sub TxtTipoDocumento_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtTipoDocumento.TextChanged
        TxtTipoDocumentoNombre.Text = ""
    End Sub

    Private Function ValidaCliente(pRefrescarDatos As Boolean, Optional ByRef pExterno As String = "") As Boolean
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim ClientePrecio As New TClientePrecio(EmpresaInfo.Emp_Id)
        Dim TipoDocumentoElectronico As New TTipoDocumentoElectronico(EmpresaInfo.Emp_Id)

        Try
            If Not IsNumeric(TxtCliente.Text.Trim) Then
                VerificaMensaje("Debe de digitar un valor válido")
                EnfocarTexto(TxtCliente)
            End If

            Cliente.Cliente_Id = TxtCliente.Text.Trim
            VerificaMensaje(Cliente.ListKey)

            If Cliente.RowsAffected = 0 Then
                VerificaMensaje("Código de cliente no válido")
                EnfocarTexto(TxtCliente)
            End If

            If Not Cliente.Activo Then
                VerificaMensaje("El código de cliente no es válido (Inactivo)")
                EnfocarTexto(TxtCliente)
            End If

            Select Case CInt(TxtTipoDocumento.Text)
                Case Enum_TipoDocumento.Credito, Enum_TipoDocumento.DevolucionCredito
                    If Not Cliente.FacturaCredito Then
                        VerificaMensaje("El tipo de documento no está permitido para el cliente seleccionado")
                        EnfocarTexto(TxtCliente)
                    End If
            End Select

            pExterno = Cliente.ClienteExterno


            ClientePrecio.Precio_Id = Cliente.Precio_Id
            VerificaMensaje(ClientePrecio.ListKey)

            TxtPrecioId.Text = ClientePrecio.Nombre.ToUpper()

            If cargaVendedor = False Or TxtClienteNombre.Text = "" Then
                If EmpresaParametroInfo.ClienteVendedorAsociado Then
                    TxtVendedor.Text = Cliente.Vendedor_id
                Else
                    TxtVendedor.Text = UsuarioInfo.Vendedor_Id
                End If
                TxtVendedor.SelectAll()
                cargaVendedor = True
            End If

            If (_TipoFacturacion = Enum_TipoFacturacion.PreFactura Or _TipoFacturacion = Enum_TipoFacturacion.Factura) _
                AndAlso _Proforma Is Nothing AndAlso _FacturaDev Is Nothing AndAlso Not _CargandoFacturaDev AndAlso Not _CargandoProforma AndAlso (CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.Contado Or CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.Credito) Then
                If InfoMaquina.VerificaPreFacturasCliente AndAlso BuscaPrefacturaCliente(CInt(TxtCliente.Text)) > 0 Then
                    MensajeError("El cliente tiene Prefacturas activas")
                End If
            End If

            If Cliente.Precio_Id = Enum_ClientPrecio.Mayoreo AndAlso _Proforma Is Nothing AndAlso _FacturaDev Is Nothing AndAlso Not _CargandoProforma AndAlso Not _CargandoFacturaDev AndAlso (CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.Contado Or CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.Credito) Then
                If Not VerificaVigenciaMayoreo(CInt(TxtCliente.Text)) Then
                    MensajeError("El cliente tiene precio de mayoreo y no ha comprado en mas de " & EmpresaParametroInfo.DiasMayoreo & " días.")
                End If
            End If


            If _TipoFacturacion = Enum_TipoFacturacion.Factura Then
                If CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.DevolucionContado OrElse CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.DevolucionCredito Then
                    TSSLDocumentoElectronico.ForeColor = Color.Red
                    TSSLDocumentoElectronico.Text = coNotaCreditoElectronicaTitulo
                Else
                    TipoDocumentoElectronico.TipoDoc = Cliente.TipoDoc
                    TipoDocumentoElectronico.ListKey()
                    If TipoDocumentoElectronico.RowsAffected = 0 Then
                        VerificaMensaje("Error buscando tipo de documento electronico")
                    End If
                    TSSLDocumentoElectronico.ForeColor = Color.Blue
                    TSSLDocumentoElectronico.Text = TipoDocumentoElectronico.Nombre
                End If
            End If


            If pRefrescarDatos Then
                TxtClienteNombre.Text = Cliente.Nombre

                Select Case CInt(TxtTipoDocumento.Text)
                    Case Enum_TipoDocumento.Contado
                        TxtPorcDescGlobal.Text = Cliente.PorcDescContado
                    Case Enum_TipoDocumento.Credito
                        TxtPorcDescGlobal.Text = Cliente.PorcDescCredito
                    Case Else
                        TxtPorcDescGlobal.Text = "0"
                End Select

                If LvwDetalle.Items.Count > 0 Then
                    RecalculaPrecio()
                    RecalculaDescuento(CDbl(TxtPorcDescGlobal.Text))
                End If

                TxtVendedor.Focus()
            End If

            Return True
        Catch ex As Exception
            EnfocarTexto(TxtCliente)
            If pRefrescarDatos Then
                MensajeError(ex.Message)
            End If
            Return False
        Finally
            Cliente = Nothing
            ClientePrecio = Nothing
        End Try
    End Function

    Public Sub TxtCliente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCliente.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If TxtCliente.Text.Trim = String.Empty Then TxtCliente.Text = "1"
                ValidaCliente(True)
            Case Keys.F2
                Dim Forma As New FrmCambioNombre

                With Forma
                    .Nombre = TxtClienteNombre.Text.Trim
                    .Execute()
                End With

                If Forma.Acepto Then
                    TxtClienteNombre.Text = Forma.Nombre
                End If

                Forma = Nothing

                If InfoMaquina.InterfazFactura = Enum_InterfazFacturacion.CantidadAntes Then
                    If PanelDetalle.Enabled And TxtCantidadAntes.Enabled Then
                        TxtCantidadAntes.Focus()
                    ElseIf TxtVendedor.Enabled Then
                        TxtVendedor.Focus()
                    End If
                Else
                    If PanelDetalle.Enabled And TxtArticulo.Enabled Then
                        TxtArticulo.Focus()
                    ElseIf TxtVendedor.Enabled Then
                        TxtVendedor.Focus()
                    End If
                End If
        End Select
    End Sub

    Private Sub TxtCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCliente.TextChanged
        TxtClienteNombre.Text = ""
        TxtPorcDescGlobal.Text = ""
        TxtPrecioId.Text = ""
    End Sub

    Private Sub TxtVendedor_GotFocus(sender As Object, e As System.EventArgs) Handles TxtVendedor.GotFocus
        If TxtVendedor.Text.Trim = "" Then
            TxtVendedor.Text = UsuarioInfo.Vendedor_Id
        End If
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
                TxtVendedor.Text = TxtVendedor.Text
                TxtVendedorNombre.Text = Vendedor.Nombre
                PanelDetalle.Enabled = True

                If InfoMaquina.InterfazFactura = Enum_InterfazFacturacion.CantidadAntes Then
                    TxtCantidadAntes.Focus()
                Else
                    TxtArticulo.Focus()
                End If
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

    Private Function ValidaSaldoCliente(ByVal pTotalFactura As Double) As Boolean
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim CXCliente As New TCxC_Cliente()
        Dim Mensaje As String = ""
        Try


            Cliente.Cliente_Id = CInt(TxtCliente.Text)
            Mensaje = Cliente.ListKey()
            VerificaMensaje(Mensaje)

            With CXCliente
                .Emp_Id = EmpresaParametroInfo.EmpresaExterna
                .Cliente_Id = Cliente.ClienteExterno
            End With

            VerificaMensaje(CXCliente.ListKey())
            If CXCliente.RowsAffected = 0 Then
                VerificaMensaje("El cliente no se encuentra definido en CXC")
            End If



            If Cliente.RowsAffected = 0 Then
                VerificaMensaje("El código de cliente no es válido")
            End If


            If _TipoFacturacion = Enum_TipoFacturacion.Factura Or _TipoFacturacion = Enum_TipoFacturacion.PreFactura Then
                If (CXCliente.Saldo + pTotalFactura) > Cliente.LimiteCredito Then
                    If ConfirmaAccion("El cliente supera el límite de crédito(" & Format(Cliente.LimiteCredito, "#,##0.00") & ") asignado" & vbCrLf & "El saldo actual es " & Format(CXCliente.Saldo, "#,##0.00") & vbCrLf & "Desea continuar con la factura?") Then
                        If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PvFacturaSobreLimiteCredito, False) Then
                            VerificaMensaje("No tiene permiso para exceder el límite de crédito")
                        End If
                    Else
                        VerificaMensaje("El cliente supera el límite de crédito")
                    End If
                End If
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        Finally
            Cliente = Nothing
        End Try
    End Function

    'Private Function SeleccionaFactura() As String
    '    Dim Forma As New FrmCXCFacturasCliente
    '    Try

    '        Forma.Cliente_Id = CInt(TxtCliente.Text)
    '        Forma.Execute()

    '        If Forma.Factura Is Nothing Then
    '            VerificaMensaje("Debe de seleccionar una factura para poder aplicar la nota de credito")
    '        End If

    '        _FacturaCxCLlave = Forma.Factura

    '        Return ""
    '    Catch ex As Exception
    '        Return ex.Message
    '    Finally
    '        Forma = Nothing
    '    End Try
    'End Function

    Private Function VerificaCxCFacturasDevolucion() As String
        Dim FacturaEncabezadoTmp As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim CXCEmp_Id As Integer = 0
        Dim CXCTipo_Id As Integer = 0
        Dim CXCMov_Id As Long = 0
        Dim Monto As Double = 0
        Dim Saldo As Double = 0
        Dim CxCMovimiento As SDFinancial.DTCxCMovimientoLinea = Nothing
        Dim Forma As New FrmCxCDevolucion
        Try

            _CxCDevolucionFacturas.Clear()
            _MontoNotaAdicional = 0
            _MontoDevolucionFacturas = 0

            With FacturaEncabezadoTmp
                .Suc_Id = _FacturaDev.Suc_Id
                .Caja_Id = _FacturaDev.Caja_Id
                .TipoDoc_Id = _FacturaDev.TipoDoc_Id
                .Documento_Id = _FacturaDev.Documento_Id
            End With

            VerificaMensaje(FacturaEncabezadoTmp.SaldoDocumentoCxC(CXCEmp_Id, CXCTipo_Id, CXCMov_Id, Monto, Saldo))

            With Forma
                .DocumentoMonto = Monto
                .DocumentoSaldo = Saldo
                .TotalDevolucion = CDbl(LblTotal.Text)
                .CXCEmp_Id = CXCEmp_Id
                .CXCTipo_Id = CXCTipo_Id
                .CXCMov_Id = CXCMov_Id
                .Cliente_Id = CInt(TxtCliente.Text)
            End With

            _FacturaDev.TotalCobrado = LblTotal.Text
            _FacturaDev.Total = LblTotal.Text

            Forma.Execute(_FacturaDev)

            If Not Forma.Guardo Then
                VerificaMensaje("Debe de seleccionar que hacer el con el saldo a favor del cliente")
            Else
                _CxCDevolucionFacturas = Forma.CxCDevolucionFacturas
                _MontoNotaAdicional = Forma.MontoNotaAdicional
                _MontoDevolucionFacturas = Forma.MontoDevolucionFacturas
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            FacturaEncabezadoTmp = Nothing
            Forma = Nothing
        End Try
    End Function

    Private Function ObtieneTipoDevolucion() As String
        Dim Forma As New FrmDevolucionTipoPago
        Try

            _TipoDevolucion = Enum_TipoDevolucion.Original

            Forma.FacturaDev = _FacturaDev

            Forma.Execute(LblTotal.Text)
            If Not Forma.Guardo Then
                VerificaMensaje("Debe de seleccionar el tipo de devolución")
            Else
                _TipoDevolucion = Forma.TipoDevolucion
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Forma = Nothing
        End Try
    End Function

    Private Function ValidaTodo() As String
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim SDFResultado As New SDFinancial.TResultado()
        Dim SDL As New SDFinancial.SDFinancial
        Dim ClienteExterno As String = ""
        Dim Mensaje As String = String.Empty
        Dim Query As String = String.Empty
        Try
            If Not ValidaCliente(False, ClienteExterno) Then
                TxtCliente.SelectAll()
                TxtCliente.Focus()
                VerificaMensaje("No se puede guardar el documento, primero debe de ingresar un codigo de cliente válido")
            Else
                If CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.Credito And EmpresaParametroInfo.InterfazCxC Then
                    If Not ValidaSaldoCliente(RedondeaMontoCobro(CDbl(LblTotal.Text))) Then
                        If InfoMaquina.InterfazFactura = Enum_InterfazFacturacion.CantidadAntes Then
                            TxtCantidadAntes.Focus()
                        Else
                            TxtArticulo.Focus()
                        End If
                        VerificaMensaje("No se puede guardar el documento")
                    End If
                End If
            End If

            If Not ValidaVendedor(False) Then
                TxtVendedor.SelectAll()
                TxtVendedor.Focus()
                VerificaMensaje("No se puede guardar el documento, primero debe de ingresar un codigo de vendedor válido")
            End If

            If LvwDetalle.Items.Count = 0 Then
                VerificaMensaje("Imposible guardar el documento, al menos tiene que ingresar un producto")
            End If

            If TxtDolares.Text = "SI" Then
                If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PVCrearFacturaDolares, False) Then
                    VerificaMensaje("No tiene permiso para facturar en dólares")
                End If
            End If

            If Val(TxtCliente.Text) = Val(InfoMaquina.ClienteDefault) Then
                TxtCliente.Focus()
                TxtCliente.SelectAll()
                VerificaMensaje("Debe de seleccionar un cliente válido")
            End If

            'If CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.DevolucionCredito Then
            '    If Not IsNumeric(ClienteExterno.Trim) Then VerificaMensaje("El formato del cliente externo debe de ser númerico")

            '    If SaldoClienteCxC(CInt(ClienteExterno.Trim)) < CDbl(LblTotal.Text) Then VerificaMensaje("El saldo del cliente es menor al monto que se quiere devolver")
            'End If

            If (Val(TxtTipoDocumento.Text) = Enum_TipoDocumento.DevolucionContado OrElse Val(TxtTipoDocumento.Text) = Enum_TipoDocumento.DevolucionCredito) AndAlso _FacturaDev Is Nothing Then
                If _TipoFacturacion = Enum_TipoFacturacion.Factura AndAlso EmpresaParametroInfo.FacturacionElectronica Then
                    If ConfirmaAccion("El proceso de facturación electrónica no permite hacer devoluciones sin estar asociadas a una factura, Desea ingresar una referencia a un documento Externo?") Then
                        VerificaMensaje(ReferenciaNotaCreditoManual())
                    Else
                        VerificaMensaje("No se puede crear una Nota de Crédito sin una referencia")
                    End If
                End If
            End If


            'Si es una devolucion de contado y esta referenciando a una factura pregunta a que tipo de pago se hace la devolucion
            If (_TipoFacturacion = Enum_TipoFacturacion.Factura AndAlso Val(TxtTipoDocumento.Text) = Enum_TipoDocumento.DevolucionContado) AndAlso Not _FacturaDev Is Nothing Then
                VerificaMensaje(ObtieneTipoDevolucion())
            End If


            If EmpresaParametroInfo.InterfazCxC AndAlso _TipoFacturacion = Enum_TipoFacturacion.Factura AndAlso Val(TxtTipoDocumento.Text) = Enum_TipoDocumento.DevolucionCredito AndAlso Not _FacturaDev Is Nothing Then
                VerificaMensaje(VerificaCxCFacturasDevolucion())
            Else
                _CxCDevolucionFacturas.Clear()
            End If



            If EmpresaParametroInfo.InterfazCxC AndAlso _TipoFacturacion = Enum_TipoFacturacion.Factura AndAlso Val(TxtTipoDocumento.Text) = Enum_TipoDocumento.DevolucionCredito AndAlso _FacturaDev Is Nothing Then
                If _MontoNotaAdicional <= 0 AndAlso _MontoDevolucionFacturas <= 0 Then
                    _MontoNotaAdicional = CDbl(LblTotal.Text)

                End If
            End If



            If EmpresaParametroInfo.VerificaExistenciaFactura Then
                If CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.Contado Or CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.Credito Then
                    If (_TipoFacturacion = Enum_TipoFacturacion.Factura OrElse _TipoFacturacion = Enum_TipoFacturacion.PreFactura OrElse _TipoFacturacion = Enum_TipoFacturacion.Apartado) Then
                        If Not ValidaExistenciaArticulos() Then
                            VerificaMensaje("No Existe existencia suficiente")
                        End If
                    End If
                End If
            End If

            If Not VerificaClientePricesmart() Then
                VerificaMensaje("No establecido los valores requeridos por el cliente: PRICESMART para la Factura Electronica ")
            End If

            If _TipoFacturacion = Enum_TipoFacturacion.Apartado Then
                If CInt(TxtCliente.Text) = coClienteGeneral Then
                    TxtCliente.SelectAll()
                    TxtCliente.Focus()
                    VerificaMensaje("No se le pueden crear apartados al Cliente General, Debe de seleccionar un cliente válido")
                End If


                For Each item As ListViewItem In LvwDetalle.Items

                    With ArticuloBodega
                        .Suc_Id = CajaInfo.Suc_Id
                        .Bod_Id = CajaInfo.Bod_Id
                        .Art_Id = item.SubItems(ColumnasDetalle.Articulo).Text.ToString()
                    End With

                    Mensaje = ArticuloBodega.VerificaArticuloApartado(CDbl(item.SubItems(ColumnasDetalle.Cantidad).Text.ToString()))

                    If Mensaje <> String.Empty Then
                        VerificaMensaje("Error en la linea # " & item.SubItems(ColumnasDetalle.Linea).Text & " Artículo = " & item.SubItems(ColumnasDetalle.Nombre).Text & " - ERROR : " & Mensaje)
                    End If
                Next
            End If


            If _TipoFacturacion = Enum_TipoFacturacion.Factura AndAlso CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.Credito AndAlso EmpresaParametroInfo.InterfazCxC AndAlso EmpresaParametroInfo.ValidaClienteMorosoCxC Then

                SDL.Url = InfoMaquina.URLContabilidad


                Query = " Select 1 From CxCMovimiento a with (nolock)" &
                        " inner Join Cliente b with (nolock) on a.Emp_Id = b.Emp_Id And a.Cliente_Id = b.Cliente_Id" &
                        " where a.Emp_Id = " & EmpresaInfo.Emp_Id &
                        " and   a.Cliente_Id = " & Val(TxtCliente.Text) & "And a.Saldo > 0" &
                        " and   dateadd(day, b.DiasGraciaMora ,a.FechaVencimiento) < getdate()"


                SDFResultado = SDL.SelectQuery(Query, "")

                If SDFResultado.Datos.Rows.Count > 0 Then
                    If ConfirmaAccion("¿El cliente tiene documentos vencidos pendientes de pago, aun así desea facturar?") Then
                        If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.FacturarMoroso, False) Then
                            VerificaMensaje("No tiene permiso facturar a un cliente moroso.")
                        End If
                    Else
                        VerificaMensaje("No se puede facturar, el cliente tiene facturas vencidas pendientes de pago")
                    End If
                End If
            End If


            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            ArticuloBodega = Nothing
            SDFResultado = Nothing
            SDL = Nothing
        End Try
    End Function

    Private Function VerificaClientePricesmart() As Boolean
        Dim cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim forma As New FrmSolicitaDatosFacturaPricesmart()
        Try
            cliente.Cliente_Id = TxtCliente.Text
            cliente.ListKey()
            If cliente.Adjunto_Id = Enum_FeAdjuntos.Pricesmart Then

                forma.Execute(cliente)

                If forma._DatosGuardados Then
                    Return True
                Else
                    Return False
                End If

            Else

                Return True

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function ReferenciaNotaCreditoManual() As String
        Dim forma As New FrmReferenciaNotaCredito
        Try

            _ReferenciaNC = Nothing

            forma.Execute()

            If Not forma.Guardo Then
                VerificaMensaje("No se puede crear una Nota de Crédito sin una referencia")
            Else
                _ReferenciaNC = forma.ReferenciaNC
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            forma = Nothing
        End Try
    End Function


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

    Private Sub TxtVendedor_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtVendedor.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If TxtVendedor.Text.Trim <> "" Then
                    ValidaVendedor(True)
                End If
        End Select
    End Sub

    Private Sub TxtVendedor_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtVendedor.TextChanged
        TxtVendedorNombre.Text = ""
    End Sub

    Private Sub ActivarEdicionArticulo(pActivar)
        If InfoMaquina.InterfazFactura = Enum_InterfazFacturacion.CantidadAntes Then
            TxtCantidadAntes.Enabled = (Not pActivar)
        End If
        TxtArticulo.Enabled = (Not pActivar)
        TxtArticuloNombre.Enabled = pActivar
        TxtPrecio.Enabled = pActivar
        TxtPorcDescLinea.Enabled = pActivar
        TxtCantidad.Enabled = pActivar
    End Sub

    Private Function ValidaArticulo(pArt_Id As String, pModificando As Boolean) As Boolean
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Dim ArtTmp As String = ""
        Dim EnteroStr As String = ""
        Dim DecimalStr As String = ""
        Dim Cantidad As Double = 1
        Dim FormaSolicitaMonto As New FrmSolicitaMonto
        Try

            'Si esta facturando un apartado no permite agregar articulos
            If Not _Proforma Is Nothing AndAlso _Proforma.Tipo = Enum_TipoFacturacion.ApartadoRetirado Then
                TxtArticulo.SelectAll()
                VerificaMensaje("No se pueden agregar artículos a un apartado")
            End If


            pArt_Id = QuitaComillas(pArt_Id)

            InfoArticulo.LimpiaArticulo()

            If Not pModificando AndAlso pArt_Id.Length > 6 Then
                'Veririca si es un codigo que trae la cantidad en la etiqueta
                Articulo.Art_Id = Mid(pArt_Id, 3, 5)
                Mensaje = Articulo.ArticuloEtiquetado()
                VerificaMensaje(Mensaje)

                If Articulo.Existe Then
                    Select Case Articulo.CodigoCantidadTipo
                        Case TipoCantidadEtiqueta.Peso
                            ArtTmp = Mid(pArt_Id, 3, 5)
                            EnteroStr = Mid(pArt_Id, 8, 2)
                            DecimalStr = Mid(pArt_Id, 10, 3)
                            'Asigna los nuevos valores
                            pArt_Id = ArtTmp
                            Cantidad = CDbl(EnteroStr & "." & DecimalStr)
                        Case TipoCantidadEtiqueta.Unidad
                            ArtTmp = Mid(pArt_Id, 3, 5)
                            EnteroStr = "1"
                            'Asigna los nuevos valores
                            pArt_Id = ArtTmp
                            Cantidad = CDbl(EnteroStr)
                        Case Else
                            TxtArticulo.SelectAll()
                            TxtArticulo.Focus()
                            VerificaMensaje("Tipo de cantidad en la etiqueta no definida")
                    End Select
                End If
            End If

            InfoArticulo.Art_Id = pArt_Id
            Mensaje = InfoArticulo.ConsultaArticulo(CInt(TxtCliente.Text))
            VerificaMensaje(Mensaje)

            If InfoArticulo.RowsAffected = 0 Then
                TxtArticulo.SelectAll()
                TxtArticulo.Focus()
                VerificaMensaje("Artículo inválido, no se encontraron datos")
            End If

            If InfoArticulo.Data.Tables(0) Is Nothing Then
                TxtArticulo.SelectAll()
                TxtArticulo.Focus()
                VerificaMensaje("Artículo inválido, no se encontraron datos")
            End If

            Mensaje = InfoArticulo.CargaRegistroArticulo(InfoArticulo.Data.Tables(0).Rows(0))
            VerificaMensaje(Mensaje)


            If Not InfoArticulo.PermiteFacturar Then
                TxtArticulo.SelectAll()
                TxtArticulo.Focus()
                VerificaMensaje("El artículo no está disponible para la venta")
            End If

            If InfoArticulo.Servicio And _TipoFacturacion = Enum_TipoFacturacion.Apartado Then
                TxtArticulo.SelectAll()
                TxtArticulo.Focus()
                VerificaMensaje("No se pueden ingresar códigos de servicios en un apartado")
            End If

            If InfoArticulo.Conjunto And Not pModificando Then
                Mensaje = InfoArticulo.CargaListaConjuntos()
                VerificaMensaje(Mensaje)
            End If


            If InfoMaquina.InterfazFactura = Enum_InterfazFacturacion.CantidadAntes Then
                If IsNumeric(TxtCantidadAntes.Text) Then
                    Cantidad = CDbl(TxtCantidadAntes.Text)
                End If
            Else
                If InfoArticulo.CalculaCantidadFactura And Not pModificando And Not _CargandoArchivo Then
                    FormaSolicitaMonto.Execute(InfoArticulo)
                    If FormaSolicitaMonto.CerroVentana Then
                        Cantidad = Format(FormaSolicitaMonto.Cantidad, "##0.0000")
                        InfoArticulo.CantidadSinRedondeo = FormaSolicitaMonto.Cantidad
                    Else
                        TxtArticulo.SelectAll()
                        TxtArticulo.Focus()
                        VerificaMensaje("Debe de ingresar el monto")
                    End If
                End If
            End If

            TxtArticuloNombre.Text = InfoArticulo.Nombre
            TxtPrecio.Text = Format(InfoArticulo.Precio, "##0.0000")
            TxtPorcDescLinea.Text = Format(InfoArticulo.PorcDescuento, "##0.00")
            TxtCantidad.Text = Cantidad

            ActivarEdicionArticulo(True)

            If InfoArticulo.SolicitarCantidad OrElse InfoArticulo.Servicio OrElse pModificando Then
                If InfoArticulo.Servicio Then

                    TxtPrecio.ReadOnly = False
                    TxtPrecio.SelectAll()
                    TxtPrecio.Focus()
                Else
                    TxtCantidad.SelectAll()
                    TxtCantidad.Focus()
                End If
            Else
                IngresaArticulo(False)
            End If


            Return True
        Catch ex As Exception
            InfoArticulo.LimpiaArticulo()
            MensajeError(ex.Message)
            Return False
        Finally
            Articulo = Nothing
            FormaSolicitaMonto = Nothing
        End Try
    End Function

    Private Sub InicializaArticulo()
        ActivarEdicionArticulo(False)
        LvwDetalle.Tag = Nothing
        InfoArticulo.LimpiaArticulo()
        TxtArticuloNombre.Text = ""
        TxtPrecio.Text = ""
        TxtPrecio.ReadOnly = True
        TxtPorcDescLinea.Text = ""
        TxtCantidad.Text = ""
    End Sub

    Private Sub CargaArticulosConjuntos()
        Dim Mensaje As String = ""
        Dim AgregaArticulo As Boolean = True
        Try

            If InfoArticulo.ListaConjuntos.Count = 0 Then
                Exit Sub
            End If

            For Each InfoArticuloConjunto As TInfoArticuloConjunto In InfoArticulo.ListaConjuntos

                InfoArticulo.LimpiaArticulo()

                InfoArticulo.Art_Id = InfoArticuloConjunto.ArtConjunto_Id
                Mensaje = InfoArticulo.ConsultaArticulo(CInt(TxtCliente.Text))

                If InfoArticulo.RowsAffected = 0 Then
                    MensajeError("Artículo conjunto inválido, no se encontraron datos")
                End If

                If InfoArticulo.Data.Tables(0) Is Nothing Then
                    MensajeError("Artículo conjunto inválido, no se encontraron datos")
                End If

                Mensaje = InfoArticulo.CargaRegistroArticulo(InfoArticulo.Data.Tables(0).Rows(0))
                VerificaMensaje(Mensaje)


                AgregaArticulo = Not (_TipoFacturacion = Enum_TipoFacturacion.Apartado And InfoArticulo.Servicio)


                If Not InfoArticulo.PermiteFacturar Then
                    MensajeError("Artículo conjunto : " & InfoArticulo.Art_Id & " - " & InfoArticulo.Nombre & " no está disponible para la venta")
                End If

                If AgregaArticulo Then
                    TxtArticuloNombre.Text = InfoArticulo.Nombre
                    TxtPrecio.Text = Format(InfoArticulo.Precio, "##0.0000")
                    TxtPorcDescLinea.Text = Format(InfoArticulo.PorcDescuento, "##0.00")
                    TxtCantidad.Text = InfoArticuloConjunto.Cantidad

                    IngresaArticulo(True)
                End If
            Next

            InfoArticulo.ListaConjuntos.Clear()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BusquedaArticulo()
        Dim Forma As New FrmBusquedaArticuloOnLine
        Dim ArticuloTmp As New TArticulo(EmpresaInfo.Emp_Id)
        Try

            Forma.Execute()

            If Forma.Articulos.Count > 0 Then
                For Each Articulo In Forma.Articulos
                    TxtArticulo.Text = Articulo

                    ArticuloTmp.Art_Id = Articulo
                    VerificaMensaje(ArticuloTmp.ListKey())

                    If ArticuloTmp.SolicitarCantidad Then
                        ValidaArticulo(TxtArticulo.Text, False)
                        TxtCantidad.Text = 1
                        If ValidaDescuento() And ValidaCantidad() Then
                            IngresaArticulo(False)
                        End If
                    Else
                        ValidaArticulo(TxtArticulo.Text, False)
                    End If



                    'TxtArticulo.Text = Art_Id
                    'ValidaArticulo(TxtArticulo.Text.Trim, False)

                    'Dim articulo As New TArticulo(EmpresaInfo.Emp_Id)
                    'articulo.Art_Id = Art_Id

                    'VerificaMensaje(articulo.ListKey())

                    'If articulo.SolicitarCantidad Then
                    '    If ValidaPrecio() Then
                    '        TxtCantidad.Focus()
                    '    End If

                    '    TxtCantidad.Text = 1

                    '    If ValidaDescuento() And ValidaCantidad() And ValidaPrecio() Then
                    '        IngresaArticulo(False)
                    '    End If
                    'End If
                    Application.DoEvents()
                Next
            Else
                If Forma.Art_Id.Trim() <> String.Empty Then
                    TxtArticulo.Text = Forma.Art_Id
                    ValidaArticulo(TxtArticulo.Text.Trim, False)
                End If
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BusquedaCliente()
        Dim Forma As New FrmBusquedaClienteOnLine
        Try

            Forma.Execute()

            If Forma.Selecciono Then
                TxtCliente.Text = Forma.Cliente_Id

                TxtVendedor.Text = Forma.Vendedor_Id
                TxtVendedor.SelectAll()

                ValidaCliente(True)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub TxtArticulo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtArticulo.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    If TxtArticulo.Text.Trim <> "" Then
                        ValidaArticulo(TxtArticulo.Text.Trim, False)
                    End If
                Case Keys.F2
                    If LvwDetalle.Items.Count > 0 Then
                        If LvwDetalle.SelectedItems.Count = 0 Then
                            LvwDetalle.Items(0).Selected = True
                        End If
                        LvwDetalle.Focus()
                    End If
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtArticulo_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtArticulo.TextChanged
        InicializaArticulo()
    End Sub

    Private Sub BusquedaRapida()
        Dim Forma As New FrmBusquedaRapida
        Try

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

    Private Sub FrmPuntoVenta_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If LvwDetalle.Items.Count > 0 Then
            Mensaje("Imposible cerrar la pantalla, hay líneas pendientes de procesar")
            e.Cancel = True
        End If
    End Sub

    Private Sub GestionCliente()
        Dim ClienteCodigo As Integer = 0
        Try

            'If Not IsNumeric(TxtCliente.Text) OrElse (Val(TxtCliente.Text) < 0) OrElse Not ClienteValido(Val(TxtCliente.Text)) OrElse (TxtCliente.Text = InfoMaquina.ClienteDefault) Then
            '    ClienteCodigo = 0
            'Else
            '    ClienteCodigo = Val(TxtCliente.Text)
            'End If

            'If ClienteCodigo > 0 Then
            '    ConsultaCliente()
            'Else
            '    CreaCliente()
            'End If

            'Unicamente crea cliente
            CreaCliente()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ConsultaCliente()
        Dim Forma As New FrmConsultaCliente()
        Try

            Forma.Cliente_Id = Val(TxtCliente.Text)
            Forma.Execute()

            If Forma.GuardoCambios Then
                If ConfirmaAccion("Desea refrescar la la información del cliente") Then
                    If Forma.ClienteNuevo <> 0 Then
                        TxtCliente.Text = Forma.ClienteNuevo
                    End If
                    ValidaCliente(True)
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub CreaCliente()
        Dim Forma As New FrmMantClienteLista
        Try

            If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PVModificaClienteFacturacion, False) Then
                VerificaMensaje("No tiene permiso para modificar la información de los clientes")
            End If

            Forma.SalirAlGuardar = True
            Forma.Execute()

            If Forma.GuardoCambios Then
                If TxtCliente.Text.Trim <> "" Then
                    If ConfirmaAccion("Desea refrescar la la información del cliente") Then
                        If Forma.ClienteNuevo <> 0 Then
                            TxtCliente.Text = Forma.ClienteNuevo
                        End If
                        ValidaCliente(True)
                    End If
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub



    Private Sub FrmPuntoVenta_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim Mensaje As String = ""
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Select Case Me.ActiveControl.Name
                        Case "TxtArticulo"
                            BusquedaArticulo()
                        Case "TxtTipoDocumento"
                            BusquedaTipoDocumento()
                        Case "TxtVendedor"
                            BusquedaVendedor()
                        Case "TxtCliente"
                            BusquedaCliente()
                    End Select
                Case Keys.F3
                    'VerificaMensaje(VerificaModulo(Modulo_Id))
                    If TxtArticulo.Enabled Then
                        If Not TxtTipoDocumento.Enabled Then
                            If PanelDetalle.Enabled Then
                                Mensaje = ValidaTodo()
                                If Mensaje.Trim = "" Then
                                    Select Case _TipoFacturacion
                                        Case Enum_TipoFacturacion.Factura
                                            GuardarFactura()
                                        Case Enum_TipoFacturacion.Proforma, Enum_TipoFacturacion.PreFactura, Enum_TipoFacturacion.Apartado
                                            GuardarProforma(_TipoFacturacion, False)
                                    End Select
                                Else
                                    MensajeError(Mensaje)
                                End If
                            Else
                                MensajeError("Para poder facturar, primero debe de ingresar al menos un producto")
                            End If
                        Else
                            MensajeError("Debe de seleccionar un tipo de documento")
                        End If
                    End If
                Case Keys.F4
                    GuardaFacturaEnEspera()
                Case Keys.F5
                    'Esta opcion si funciona pero esta pendiente de pasarla a otro menu
                    'CreaArticulo()
                    If Not TxtTipoDocumento.Enabled Then
                        If LvwDetalle.Items.Count > 0 Then
                            If LvwDetalle.SelectedItems Is Nothing OrElse LvwDetalle.SelectedItems.Count = 0 Then
                                MsgBox("Debe de seleccionar un detalle para poder agregarle un comentario", MsgBoxStyle.Information, Me.Text)
                            Else
                                CapturaComentarioLinea()
                            End If
                        Else
                            MsgBox("El documnento aún no tiene detalles", MsgBoxStyle.Information, Me.Text)
                        End If
                    Else
                        MsgBox("Debe de seleccionar un tipo de documento", MsgBoxStyle.Information, Me.Text)
                    End If
                Case Keys.F6 And Me.ActiveControl.Name = "TxtArticulo"
                    BusquedaRapida()
                Case Keys.F7
                    GestionCliente()
                Case Keys.F8 'Proforma
                    If _TipoFacturacion = Enum_TipoFacturacion.PreFactura Or _TipoFacturacion = Enum_TipoFacturacion.Apartado Then
                        Exit Sub
                    End If
                    BuscaProformas(Enum_TipoFacturacion.Proforma)
                    'If Not TxtTipoDocumento.Enabled Then
                    '    If CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.Contado OrElse CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.Credito Then
                    '        BuscaProformas(Enum_TipoFacturacion.Proforma)
                    '    Else
                    '        MsgBox("No es posible cargar una proforma para el tipo de documento seleccionado", MsgBoxStyle.Information, Me.Text)
                    '    End If
                    'Else
                    '    MsgBox("Debe de seleccionar un tipo de documento", MsgBoxStyle.Information, Me.Text)
                    'End If
                Case Keys.F9 'PreFactura
                    If _TipoFacturacion = Enum_TipoFacturacion.Proforma Or _TipoFacturacion = Enum_TipoFacturacion.Apartado Then
                        Exit Sub
                    End If
                    BuscaPrefacturas(Enum_TipoFacturacion.PreFactura)
                    'If Not TxtTipoDocumento.Enabled Then
                    '    If CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.Contado OrElse CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.Credito Then
                    '        'BuscaProformas(Enum_TipoFacturacion.PreFactura)
                    '        BuscaPrefacturas(Enum_TipoFacturacion.PreFactura)
                    '    Else
                    '        MsgBox("No es posible cargar una proforma para el tipo de documento seleccionado", MsgBoxStyle.Information, Me.Text)
                    '    End If
                    'Else
                    '    MsgBox("Debe de seleccionar un tipo de documento", MsgBoxStyle.Information, Me.Text)
                    'End If
                Case Keys.F10
                    If Not TxtTipoDocumento.Enabled Then
                        CapturaComentarioDocumento()
                    Else
                        MsgBox("Debe de seleccionar un tipo de documento", MsgBoxStyle.Information, Me.Text)
                    End If
                Case Keys.F11
                    MuestraTeclasMenu()
                Case Keys.F12
                    If LvwDetalle.Items.Count > 0 Then
                        If Not ConfirmaAccion("Desea cancelar el documento actual?") Then
                            Exit Sub
                        End If
                    End If

                    If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PVCancelaFactura, False) Then
                        VerificaMensaje("No tiene permiso para cancelar el documento actual")
                    End If

                    Inicializa()
                    TxtTipoDocumento.Focus()

            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub GuardaFacturaEnEspera()
        Dim Mensaje As String
        Try
            If _TipoFacturacion = Enum_TipoFacturacion.Proforma Or _TipoFacturacion = Enum_TipoFacturacion.PreFactura Or _TipoFacturacion = Enum_TipoFacturacion.Apartado Then
                Exit Sub
            End If

            If Not _Proforma Is Nothing OrElse Not _FacturaDev Is Nothing Then
                VerificaMensaje("No se puede poner en espera un documento que ha sido cargado")
            End If



            If TxtArticulo.Enabled Then
                If Not TxtTipoDocumento.Enabled Then
                    If PanelDetalle.Enabled Then
                        Mensaje = ValidaTodo()
                        If Mensaje.Trim = "" Then
                            GuardarProforma(Enum_TipoFacturacion.PreFactura, True)
                        Else
                            MsgBox(Mensaje, MsgBoxStyle.Information, Me.Text)
                        End If
                    Else
                        MsgBox("Para poder facturar, primero debe de ingresar al menos un producto", MsgBoxStyle.Information, Me.Text)
                    End If
                Else
                    MsgBox("Debe de seleccionar un tipo de documento", MsgBoxStyle.Information, Me.Text)
                End If
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub MuestraTeclasMenu()
        Dim Forma As New FrmPuntoVentaFuncionalidades
        'Dim Forma As New FrmPuntoVentaMenu
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Sub CargaFactura(ByVal pFactura As TFacturaLlave, pTipoFacturacion As Enum_TipoFacturacion)
        Dim Proforma As New TProformaEncabezado(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Try


            'Encabezado
            'TxtTipoDocumento.Text = pFactura.TipoDoc_Id
            ValidaTipoDocumento()


            With Proforma
                .Emp_Id = pFactura.Emp_Id
                .Suc_Id = pFactura.Suc_Id
                .Documento_Id = pFactura.Documento_Id
                .Tipo = pFactura.Tipo
            End With

            Mensaje = Proforma.ListKey()
            VerificaMensaje(Mensaje)

            TxtCliente.Text = Proforma.Cliente_Id
            ValidaCliente(False)
            TxtClienteNombre.Text = Proforma.Nombre

            Cliente.Cliente_Id = Proforma.Cliente_Id
            VerificaMensaje(Cliente.ListKey())


            Select Case Val(TxtTipoDocumento.Text)
                Case Enum_TipoDocumento.Contado
                    TxtPorcDescGlobal.Text = Format(Cliente.PorcDescContado, "##0.00")
                Case Enum_TipoDocumento.Credito
                    TxtPorcDescGlobal.Text = Format(Cliente.PorcDescCredito, "##0.00")
                Case Else
                    TxtPorcDescGlobal.Text = "0.00"
            End Select

            TxtVendedor.Text = Proforma.Vendedor_Id
            ValidaVendedor(True)

            TxtDolares.Text = IIf(Proforma.Dolares, "SI", "NO")
            LblTipoCambio.Visible = Proforma.Dolares
            TxtTipoCambio.Visible = Proforma.Dolares

            _Comentario = Proforma.Comentario

            'If _Comentario.Trim = String.Empty Then
            '    _Comentario = IIf(Proforma.Tipo = Enum_TipoFacturacion.PreFactura, "PreFactura # " & Proforma.Documento_Id, "Proforma # " & Proforma.Documento_Id)
            'End If


            TxtComentario.Text = _Comentario



            'Detalle
            For Each Linea As TProformaDetalle In Proforma.ProformaDetalles
                IngresaArticuloCargado(Linea)
            Next

            _Proforma = Proforma


            LblNumeroDoc.Visible = True

            Select Case pTipoFacturacion
                Case Enum_TipoFacturacion.PreFactura
                    If _Proforma.Tipo = Enum_TipoFacturacion.ApartadoRetirado Then
                        LblNumeroDoc.Text = "Apartado # " & pFactura.Documento_Id.ToString()
                    Else
                        LblNumeroDoc.Text = "PreFactura # " & pFactura.Documento_Id.ToString()
                    End If

                Case Enum_TipoFacturacion.Proforma
                    LblNumeroDoc.Text = "Proforma # " & pFactura.Documento_Id.ToString()
            End Select



        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Proforma = Nothing
            Cliente = Nothing
        End Try
    End Sub

    Public Sub CargaFacturaDev(ByVal pFactura As TFacturaLlave)
        Dim Factura As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        'Dim FacturaDev As New TFacturaEncabezado(EmpresaInfo.Email)
        Try


            _CargandoFacturaDev = True

            'Encabezado
            'TxtTipoDocumento.Text = pFactura.TipoDoc_Id
            ValidaTipoDocumento()


            With Factura
                .Emp_Id = pFactura.Emp_Id
                .Suc_Id = pFactura.Suc_Id
                .Caja_Id = pFactura.Caja_Id
                .TipoDoc_Id = pFactura.TipoDoc_Id
                .Documento_Id = pFactura.Documento_Id
            End With

            Mensaje = Factura.ListKey()
            VerificaMensaje(Mensaje)

            TxtCliente.Text = Factura.Cliente_Id
            ValidaCliente(False)
            TxtClienteNombre.Text = Factura.Nombre

            Cliente.Cliente_Id = Factura.Cliente_Id
            VerificaMensaje(Cliente.ListKey())


            Select Case Val(TxtTipoDocumento.Text)
                Case Enum_TipoDocumento.Contado
                    TxtPorcDescGlobal.Text = Format(Cliente.PorcDescContado, "##0.00")
                Case Enum_TipoDocumento.Credito
                    TxtPorcDescGlobal.Text = Format(Cliente.PorcDescCredito, "##0.00")
                Case Else
                    TxtPorcDescGlobal.Text = "0.00"
            End Select

            TxtVendedor.Text = Factura.Vendedor_Id
            ValidaVendedor(True)

            TxtDolares.Text = IIf(Factura.Dolares, "SI", "NO")
            LblTipoCambio.Visible = Factura.Dolares
            TxtTipoCambio.Visible = Factura.Dolares
            TxtTipoCambio.Text = Format(Factura.TipoCambio, "#,##0.00")
            TxtTipoCambio.ForeColor = Color.Red


            _Comentario = Factura.Comentario

            'If _Comentario.Trim = String.Empty Then
            '    _Comentario = IIf(Proforma.Tipo = Enum_TipoFacturacion.PreFactura, "PreFactura # " & Proforma.Documento_Id, "Proforma # " & Proforma.Documento_Id)
            'End If


            TxtComentario.Text = _Comentario

            LvwDetalle.Items.Clear()

            'Detalle
            For Each Linea As TFacturaDetalle In Factura.FacturaDetalles
                IngresaArticuloCargadoDev(Linea)
            Next

            _FacturaDev = Factura


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            _CargandoFacturaDev = False
            'FacturaDev = Nothing
            Factura = Nothing
            Cliente = Nothing
        End Try
    End Sub

    Public Sub CargaArchivoArticulos(pLista As List(Of TArticuloConteo))
        Try

            _CargandoArchivo = True

            For Each conteo As TArticuloConteo In pLista
                TxtArticulo.Text = conteo.Art_Id
                ValidaArticulo(TxtArticulo.Text, False)
                If TxtArticulo.Text <> String.Empty Then
                    TxtCantidad.Text = conteo.Cantidad
                    IngresaArticulo(False)
                End If
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            _CargandoArchivo = False
        End Try
    End Sub




    Public Sub CargaDetalleFactura(pFactura As TFacturaLlave)
        Dim FacturaEncabezado As New TFacturaEncabezado(CajaInfo.Emp_Id)
        Dim Detalles As List(Of TProformaDetalle)
        Try
            With FacturaEncabezado
                .Suc_Id = pFactura.Suc_Id
                .Caja_Id = pFactura.Caja_Id
                .TipoDoc_Id = pFactura.TipoDoc_Id
                .Documento_Id = pFactura.Documento_Id
            End With

            VerificaMensaje(FacturaEncabezado.ListKey())

            Detalles = ConvierteLineaDetalle(FacturaEncabezado.FacturaDetalles)


            For Each Linea As TProformaDetalle In Detalles
                IngresaArticuloCargado(Linea)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FacturaEncabezado = Nothing
        End Try
    End Sub

    Private Function ConvierteLineaDetalle(Lineas As List(Of TFacturaDetalle)) As List(Of TProformaDetalle)
        Dim LineasProforma As New List(Of TProformaDetalle)
        Dim LineaProforma As TProformaDetalle = Nothing

        For Each LineaFactura As TFacturaDetalle In Lineas

            LineaProforma = New TProformaDetalle(EmpresaInfo.Emp_Id)

            With LineaProforma
                .Emp_Id = LineaFactura.Emp_Id
                .Suc_Id = LineaFactura.Suc_Id
                .Documento_Id = LineaFactura.Documento_Id
                .Detalle_Id = LineaFactura.Detalle_Id
                .Art_Id = LineaFactura.Art_Id
                .Cantidad = LineaFactura.Cantidad
                .Fecha = LineaFactura.Fecha
                .Costo = LineaFactura.Costo
                .Precio = LineaFactura.Precio
                .PorcDescuento = LineaFactura.PorcDescuento
                .MontoDescuento = LineaFactura.MontoDescuento
                .MontoIV = LineaFactura.MontoIV
                .TotalLinea = LineaFactura.TotalLinea
                .ExentoIV = LineaFactura.ExentoIV
                .Suelto = LineaFactura.Suelto
                .Descripcion = LineaFactura.Descripcion
                .Observacion = LineaFactura.Observacion
                .Servicio = LineaFactura.Servicio
                .ArticuloImpuestos = LineaFactura.ArticuloImpuestos
            End With

            LineasProforma.Add(LineaProforma)

        Next

        Return LineasProforma

    End Function

    Private Sub BuscaPrefacturas(pTipoFacturacion As Enum_TipoFacturacion)
        Dim Forma As New FrmBusquedaPreFactura
        'Dim Forma As New FrmBusquedaProforma
        Dim TipoSeleccionado As Integer = 0
        Try

            If LvwDetalle.Items.Count > 0 Then
                VerificaMensaje("Antes de cargar un documento debe de finalizar el actual")
            End If

            _CargandoProforma = True

            Forma.Tipo = pTipoFacturacion
            If Not TxtTipoDocumento.Enabled Then
                Forma.TipoDoc_Id = CInt(TxtTipoDocumento.Text)
            Else
                Forma.TipoDoc_Id = -1
            End If
            Forma.TipoOrigen = _TipoFacturacion
            Forma.Execute()

            If Forma.FacturaSeleccionada Is Nothing Then
                Exit Sub
            End If

            If Not TxtTipoDocumento.Enabled Then
                TipoSeleccionado = CInt(TxtTipoDocumento.Text)
            End If


            Inicializa()
            TxtTipoDocumento.Focus()


            If TipoSeleccionado > 0 Then
                TxtTipoDocumento.Text = TipoSeleccionado
            Else
                TxtTipoDocumento.Text = Forma.FacturaSeleccionada.TipoDoc_Id
            End If

            CargaFactura(Forma.FacturaSeleccionada, pTipoFacturacion)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
            _CargandoProforma = False
        End Try
    End Sub


    Private Sub BuscaProformas(pTipoFacturacion As Enum_TipoFacturacion)
        'Dim Forma As New FrmProformaLista
        Dim Forma As New FrmBusquedaProforma
        Dim TipoSeleccionado As Integer = 0
        Try

            If LvwDetalle.Items.Count > 0 Then
                VerificaMensaje("Antes de cargar un documento debe de finalizar el actual")
            End If

            _CargandoProforma = True

            Forma.Tipo = pTipoFacturacion
            Forma.TipoDoc_Id = -1
            Forma.Execute()

            If Forma.FacturaSeleccionada Is Nothing Then
                Exit Sub
            End If

            If Not TxtTipoDocumento.Enabled Then
                TipoSeleccionado = CInt(TxtTipoDocumento.Text)
            End If


            Inicializa()
            TxtTipoDocumento.Focus()


            If TipoSeleccionado > 0 Then
                TxtTipoDocumento.Text = TipoSeleccionado
            Else
                TxtTipoDocumento.Text = Forma.FacturaSeleccionada.TipoDoc_Id
            End If

            CargaFactura(Forma.FacturaSeleccionada, pTipoFacturacion)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
            _CargandoProforma = False
        End Try
    End Sub

    Private Sub AsignaInterfaz()
        Select Case InfoMaquina.InterfazFactura
            Case Enum_InterfazFacturacion.Reducida
                PicSubTotal.Visible = False
                LblSubTotal.Visible = False
                LblSubTotalTitulo.Visible = False
                Me.Width = Me.Width - 50

                LvwDetalle.Columns(ColumnasDetalle.PorcDescuento).Width = 0
                LvwDetalle.Columns(ColumnasDetalle.MontoDescuento).Width = 0
                LvwDetalle.Columns(ColumnasDetalle.Observacion).Width = 0
                LvwDetalle.Columns(ColumnasDetalle.Nombre).Width = 400
            Case Enum_InterfazFacturacion.CantidadAntes
                LblCantidadAntes.Left = LblArticulo.Left
                TxtCantidadAntes.Left = TxtArticulo.Left
                LblCantidadAntes.Visible = True
                TxtCantidadAntes.Visible = True
                LblArticulo.Left = LblArticulo.Left + 71
                TxtArticulo.Left = TxtArticulo.Left + 71
                LblArticuloNombre.Left = LblArticuloNombre.Left + 71
                TxtArticuloNombre.Left = TxtArticuloNombre.Left + 71
                LblPrecio.Left = LblPrecio.Left + 71
                TxtPrecio.Left = TxtPrecio.Left + 71
                LblPorcDescLinea.Left = LblPorcDescLinea.Left + 71
                TxtPorcDescLinea.Left = TxtPorcDescLinea.Left + 71
                LblCantidad.Left = LblCantidad.Left + 71
                TxtCantidad.Left = TxtCantidad.Left + 71
        End Select
    End Sub

    Private Sub FrmPuntoVenta_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FormateaCamposNumericos()
        ConfiguraDetalle()
        AsignaInterfaz()
        With InfoArticulo
            .Emp_Id = CajaInfo.Emp_Id
            .Suc_Id = CajaInfo.Suc_Id
            .Bod_Id = CajaInfo.Bod_Id
        End With
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
    Private Sub RecalculaDescuento(pPorcentaje As Double)
        Dim Item As ListViewItem = Nothing
        Try

            For Each Linea As ListViewItem In LvwDetalle.Items
                With Linea
                    .SubItems(ColumnasDetalle.PorcDescuento).Text = Format(pPorcentaje, "##0.0000")
                    .SubItems(ColumnasDetalle.MontoDescuento).Text = Format(CDbl(.SubItems(ColumnasDetalle.Precio).Text) * (CDbl(.SubItems(ColumnasDetalle.PorcDescuento).Text) / 100), "##0.0000")
                    If Not .SubItems(ColumnasDetalle.Exento).Text And TxtExento.Text <> "SI" Then
                        .SubItems(ColumnasDetalle.MontoIV).Text = Format(CalculaMontoImpuesto(CLng(.SubItems(ColumnasDetalle.Linea).Text), (CDbl(.SubItems(ColumnasDetalle.Precio).Text) - CDbl(.SubItems(ColumnasDetalle.MontoDescuento).Text)), CType(Linea.Tag, List(Of TFacturaDetalleImpuesto))), "##0.0000")
                    End If
                    .SubItems(ColumnasDetalle.TotalLinea).Text = Format(((CDbl(.SubItems(ColumnasDetalle.Precio).Text) - CDbl(.SubItems(ColumnasDetalle.MontoDescuento).Text)) + CDbl(.SubItems(ColumnasDetalle.MontoIV).Text)) * CDbl(.SubItems(ColumnasDetalle.Cantidad).Text), "##0.0000")
                End With
            Next

            MuestraTotales()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub RecalculaImpuesto()
        Dim Item As ListViewItem = Nothing
        Try
            For Each Linea As ListViewItem In LvwDetalle.Items

                With Linea
                    If TxtExento.Text = "NO" Then
                        If .SubItems(ColumnasDetalle.Exento).Text Then
                            .SubItems(ColumnasDetalle.MontoIV).Text = "0.00"
                        Else
                            .SubItems(ColumnasDetalle.MontoIV).Text = Format(CalculaMontoImpuesto(CLng(.SubItems(ColumnasDetalle.Linea).Text), (CDbl(.SubItems(ColumnasDetalle.Precio).Text) - CDbl(.SubItems(ColumnasDetalle.MontoDescuento).Text)), CType(Linea.Tag, List(Of TFacturaDetalleImpuesto))), "##0.0000")
                        End If
                    Else
                        .SubItems(ColumnasDetalle.MontoIV).Text = "0.00"
                    End If
                    .SubItems(ColumnasDetalle.TotalLinea).Text = Format(((CDbl(.SubItems(ColumnasDetalle.Precio).Text) - CDbl(.SubItems(ColumnasDetalle.MontoDescuento).Text)) + CDbl(.SubItems(ColumnasDetalle.MontoIV).Text)) * CDbl(.SubItems(ColumnasDetalle.Cantidad).Text), "##0.0000")
                End With
            Next

            MuestraTotales()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub RecalculaPrecio()
        Dim Item As ListViewItem = Nothing
        Dim Mensaje As String = ""
        Try

            For Each Linea As ListViewItem In LvwDetalle.Items
                With Linea

                    InfoArticulo.LimpiaArticulo()

                    InfoArticulo.Art_Id = .SubItems(ColumnasDetalle.Articulo).Text.Trim
                    Mensaje = InfoArticulo.ConsultaArticulo(CInt(TxtCliente.Text))

                    Mensaje = InfoArticulo.CargaRegistroArticulo(InfoArticulo.Data.Tables(0).Rows(0))
                    VerificaMensaje(Mensaje)

                    .SubItems(ColumnasDetalle.Precio).Text = Format(InfoArticulo.Precio, "##0.0000")
                    .SubItems(ColumnasDetalle.MontoDescuento).Text = Format(CDbl(.SubItems(ColumnasDetalle.Precio).Text) * (CDbl(.SubItems(ColumnasDetalle.PorcDescuento).Text) / 100), "##0.0000")

                    If Not .SubItems(ColumnasDetalle.Exento).Text Then
                        .SubItems(ColumnasDetalle.MontoIV).Text = Format(CalculaMontoImpuesto(CLng(.SubItems(ColumnasDetalle.Linea).Text), (CDbl(.SubItems(ColumnasDetalle.Precio).Text) - CDbl(.SubItems(ColumnasDetalle.MontoDescuento).Text)), CType(Linea.Tag, List(Of TFacturaDetalleImpuesto))), "##0.0000")
                    End If
                    .SubItems(ColumnasDetalle.TotalLinea).Text = Format(((CDbl(.SubItems(ColumnasDetalle.Precio).Text) - CDbl(.SubItems(ColumnasDetalle.MontoDescuento).Text)) + CDbl(.SubItems(ColumnasDetalle.MontoIV).Text)) * CDbl(.SubItems(ColumnasDetalle.Cantidad).Text), "##0.0000")
                End With
            Next

            MuestraTotales()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function GetLineaId() As Long
        Dim LineaId As Long = 0

        If LvwDetalle.Items.Count > 0 Then
            LineaId = CLng(LvwDetalle.Items(LvwDetalle.Items.Count - 1).SubItems(ColumnasDetalle.Linea).Text)
        End If

        Return LineaId + 1

    End Function

    Private Sub IngresaArticuloCargado(pArticuloDetalle As TProformaDetalle)
        Dim Item As ListViewItem
        Dim Items(17) As String
        Dim Linea_Id As Integer = 0
        Dim ArticuloImpuestos As New List(Of TFacturaDetalleImpuesto)
        Dim ArticuloImpuesto As TFacturaDetalleImpuesto
        Try


            'Crea una nueva linea del detalle
            Item = New ListViewItem(Items)
            'Linea_Id = LvwDetalle.Items.Count + 1
            Linea_Id = GetLineaId()

            With Item
                .SubItems(ColumnasDetalle.Linea).Text = Linea_Id
                .SubItems(ColumnasDetalle.Articulo).Text = pArticuloDetalle.Art_Id
                .SubItems(ColumnasDetalle.Cantidad).Text = CDbl(pArticuloDetalle.Cantidad)
                .SubItems(ColumnasDetalle.Nombre).Text = pArticuloDetalle.Descripcion
                .SubItems(ColumnasDetalle.Precio).Text = Format(pArticuloDetalle.Precio, "##0.0000")
                .SubItems(ColumnasDetalle.PorcDescuento).Text = Format(pArticuloDetalle.PorcDescuento, "##0.0000")
                .SubItems(ColumnasDetalle.MontoDescuento).Text = Format(pArticuloDetalle.MontoDescuento, "##0.0000")
                .SubItems(ColumnasDetalle.Suelto).Text = pArticuloDetalle.Suelto
                .SubItems(ColumnasDetalle.Padre).Text = ""
                .SubItems(ColumnasDetalle.Conjunto).Text = False
                .SubItems(ColumnasDetalle.Exento).Text = pArticuloDetalle.ExentoIV
                .SubItems(ColumnasDetalle.MontoIV).Text = Format(pArticuloDetalle.MontoIV, "##0.0000")
                .SubItems(ColumnasDetalle.Saldo).Text = 0
                .SubItems(ColumnasDetalle.Costo).Text = pArticuloDetalle.Costo
                .SubItems(ColumnasDetalle.TotalLinea).Text = Format(pArticuloDetalle.Cantidad * pArticuloDetalle.TotalLinea, "##0.0000")
                .SubItems(ColumnasDetalle.Observacion).Text = pArticuloDetalle.Observacion
                .SubItems(ColumnasDetalle.Servicio).Text = pArticuloDetalle.Servicio
                .SubItems(ColumnasDetalle.CalculaCantidadFactura).Text = pArticuloDetalle.CalculaCantidadFactura
            End With

            If Not pArticuloDetalle.ExentoIV Then
                For Each impuesto As TFacturaDetalleImpuesto In pArticuloDetalle.ArticuloImpuestos
                    ArticuloImpuesto = New TFacturaDetalleImpuesto(EmpresaInfo.Emp_Id)
                    With ArticuloImpuesto
                        .Suc_Id = impuesto.Suc_Id
                        .Caja_Id = impuesto.Caja_Id
                        .TipoDoc_Id = impuesto.TipoDoc_Id
                        .Documento_Id = impuesto.Documento_Id
                        .Detalle_Id = impuesto.Detalle_Id
                        .Codigo_Id = impuesto.Codigo_Id
                        .Tarifa_Id = impuesto.Tarifa_Id
                        .Porcentaje = impuesto.Porcentaje
                        .Monto = impuesto.Monto
                    End With
                    ArticuloImpuestos.Add(ArticuloImpuesto)
                Next
            End If


            Item.Tag = ArticuloImpuestos
            LvwDetalle.Items.Add(Item)
            Item.EnsureVisible()

            'Marca la ultima linea modificada o ingresada
            LvwDetalle.SelectedItems.Clear()
            Item.Selected = True

            TxtArticulo.Text = ""
            InicializaArticulo()

            If InfoMaquina.InterfazFactura = Enum_InterfazFacturacion.CantidadAntes Then
                TxtCantidadAntes.Text = ""
                TxtCantidadAntes.Focus()
            Else
                TxtArticulo.Focus()
            End If

            MuestraTotales()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub IngresaArticuloCargadoDev(pArticuloDetalle As TFacturaDetalle)
        Dim Item As ListViewItem
        Dim Items(17) As String
        Dim Linea_Id As Integer = 0
        Dim ArticuloImpuestos As New List(Of TFacturaDetalleImpuesto)
        Dim ArticuloImpuesto As TFacturaDetalleImpuesto
        Try


            'Crea una nueva linea del detalle
            Item = New ListViewItem(Items)
            'Linea_Id = LvwDetalle.Items.Count + 1
            Linea_Id = GetLineaId()

            With Item
                .SubItems(ColumnasDetalle.Linea).Text = Linea_Id
                .SubItems(ColumnasDetalle.Articulo).Text = pArticuloDetalle.Art_Id
                .SubItems(ColumnasDetalle.Cantidad).Text = Format(CDbl(pArticuloDetalle.Cantidad), "##0.0000")
                .SubItems(ColumnasDetalle.Nombre).Text = pArticuloDetalle.Descripcion
                .SubItems(ColumnasDetalle.Precio).Text = Format(pArticuloDetalle.Precio, "##0.0000")
                .SubItems(ColumnasDetalle.PorcDescuento).Text = Format(pArticuloDetalle.PorcDescuento, "##0.0000")
                .SubItems(ColumnasDetalle.MontoDescuento).Text = Format(pArticuloDetalle.MontoDescuento, "##0.0000")
                .SubItems(ColumnasDetalle.Suelto).Text = pArticuloDetalle.Suelto
                .SubItems(ColumnasDetalle.Padre).Text = ""
                .SubItems(ColumnasDetalle.Conjunto).Text = False
                .SubItems(ColumnasDetalle.Exento).Text = pArticuloDetalle.ExentoIV
                .SubItems(ColumnasDetalle.MontoIV).Text = Format(pArticuloDetalle.MontoIV, "##0.0000")
                .SubItems(ColumnasDetalle.Saldo).Text = 0
                .SubItems(ColumnasDetalle.Costo).Text = pArticuloDetalle.Costo
                .SubItems(ColumnasDetalle.TotalLinea).Text = Format(pArticuloDetalle.Cantidad * pArticuloDetalle.TotalLinea, "##0.0000")
                .SubItems(ColumnasDetalle.Observacion).Text = pArticuloDetalle.Observacion
                .SubItems(ColumnasDetalle.Servicio).Text = pArticuloDetalle.Servicio
                .SubItems(ColumnasDetalle.CalculaCantidadFactura).Text = pArticuloDetalle.CalculaCantidadFactura
            End With

            If Not pArticuloDetalle.ExentoIV Then
                For Each impuesto As TFacturaDetalleImpuesto In pArticuloDetalle.ArticuloImpuestos
                    ArticuloImpuesto = New TFacturaDetalleImpuesto(EmpresaInfo.Emp_Id)
                    With ArticuloImpuesto
                        .Suc_Id = impuesto.Suc_Id
                        .Caja_Id = impuesto.Caja_Id
                        .TipoDoc_Id = impuesto.TipoDoc_Id
                        .Documento_Id = impuesto.Documento_Id
                        .Detalle_Id = impuesto.Detalle_Id
                        .Codigo_Id = impuesto.Codigo_Id
                        .Tarifa_Id = impuesto.Tarifa_Id
                        .Porcentaje = impuesto.Porcentaje
                        .Monto = impuesto.Monto
                    End With
                    ArticuloImpuestos.Add(ArticuloImpuesto)
                Next
            End If


            Item.Tag = ArticuloImpuestos
            LvwDetalle.Items.Add(Item)
            Item.EnsureVisible()

            'Marca la ultima linea modificada o ingresada
            LvwDetalle.SelectedItems.Clear()
            Item.Selected = True

            TxtArticulo.Text = ""
            InicializaArticulo()

            If InfoMaquina.InterfazFactura = Enum_InterfazFacturacion.CantidadAntes Then
                TxtCantidadAntes.Text = ""
                TxtCantidadAntes.Focus()
            Else
                TxtArticulo.Focus()
            End If

            MuestraTotales()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function CalculaMontoImpuesto(pDetalle_Id As Integer, pMonto As Double, ByRef pArticuloImpuestos As List(Of TFacturaDetalleImpuesto)) As Double
        Dim OtrosImpuestos As Double = 0
        Dim TotalImpuesto As Double = 0



        For Each impuesto As TFacturaDetalleImpuesto In pArticuloImpuestos
            If impuesto.Codigo_Id <> coImpuesto01 And impuesto.Codigo_Id <> coImpuesto12 Then
                With impuesto
                    .Detalle_Id = pDetalle_Id
                    .Monto = pMonto * (impuesto.Porcentaje / 100)
                End With
                OtrosImpuestos += impuesto.Monto
            End If
        Next

        For Each impuesto As TFacturaDetalleImpuesto In pArticuloImpuestos
            If impuesto.Codigo_Id = coImpuesto01 OrElse impuesto.Codigo_Id = coImpuesto12 Then
                With impuesto
                    .Detalle_Id = pDetalle_Id
                    .Monto = (pMonto + OtrosImpuestos) * (impuesto.Porcentaje / 100)
                End With
                TotalImpuesto += impuesto.Monto
            End If
        Next

        Return TotalImpuesto + OtrosImpuestos

    End Function

    'Private Function AgregaImpuestosLinea(pDetalle_Id As Integer, pMonto As Double, pArticuloImpuestos As List(Of TFacturaDetalleImpuesto)) As String
    '    Dim FacturaDetalleImpuesto As TFacturaDetalleImpuesto
    '    Try

    '        _FacturaDetalleImpuestos.RemoveAll(Function(x) x.Detalle_Id = pDetalle_Id)


    '        For Each ArticuloImpuesto As TFacturaDetalleImpuesto In pArticuloImpuestos
    '            FacturaDetalleImpuesto = New TFacturaDetalleImpuesto(EmpresaInfo.Emp_Id)
    '            With FacturaDetalleImpuesto
    '                .Detalle_Id = pDetalle_Id
    '                .Codigo_Id = ArticuloImpuesto.Codigo_Id
    '                .Tarifa_Id = ArticuloImpuesto.Tarifa_Id
    '                .Porcentaje = ArticuloImpuesto.Porcentaje
    '                .Monto = pMonto * (ArticuloImpuesto.Porcentaje / 100)
    '            End With
    '            _FacturaDetalleImpuestos.Add(FacturaDetalleImpuesto)
    '        Next

    '        Return String.Empty
    '    Catch ex As Exception
    '        Return ex.Message
    '    End Try
    'End Function

    Private Sub IngresaArticulo(pArtConjunto As Boolean)
        Dim Item As ListViewItem
        Dim Items(17) As String
        Dim Linea_Id As Integer = 0
        Dim Accion As AccionDetalle = AccionDetalle.Nuevo
        Dim ArticuloImpuestos As New List(Of TFacturaDetalleImpuesto)
        Dim ArticuloImpuesto As TFacturaDetalleImpuesto
        Try

            For Each impuesto As TFacturaDetalleImpuesto In InfoArticulo.ArticuloImpuestos
                ArticuloImpuesto = New TFacturaDetalleImpuesto(EmpresaInfo.Emp_Id)
                With ArticuloImpuesto
                    .Suc_Id = impuesto.Suc_Id
                    .Caja_Id = impuesto.Caja_Id
                    .TipoDoc_Id = impuesto.TipoDoc_Id
                    .Documento_Id = impuesto.Documento_Id
                    .Detalle_Id = impuesto.Detalle_Id
                    .Codigo_Id = impuesto.Codigo_Id
                    .Tarifa_Id = impuesto.Tarifa_Id
                    .Porcentaje = impuesto.Porcentaje
                    .Monto = impuesto.Monto
                End With
                ArticuloImpuestos.Add(ArticuloImpuesto)
            Next


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
                    'Linea_Id = LvwDetalle.Items.Count + 1
                    Linea_Id = GetLineaId()
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
                    If InfoArticulo.CantidadSinRedondeo = 0 Then
                        '.SubItems(ColumnasDetalle.Cantidad).Text = Format(CDbl(.SubItems(ColumnasDetalle.Cantidad).Text) + CDbl(TxtCantidad.Text), "##0.0000")
                        .SubItems(ColumnasDetalle.Cantidad).Text = CDbl(.SubItems(ColumnasDetalle.Cantidad).Text) + CDbl(TxtCantidad.Text)
                    Else
                        .SubItems(ColumnasDetalle.Cantidad).Text = CDbl(.SubItems(ColumnasDetalle.Cantidad).Text) + InfoArticulo.CantidadSinRedondeo
                    End If
                Else
                    If InfoArticulo.CantidadSinRedondeo = 0 Then
                        '.SubItems(ColumnasDetalle.Cantidad).Text = Format(CDbl(TxtCantidad.Text), "##0.0000")
                        .SubItems(ColumnasDetalle.Cantidad).Text = CDbl(TxtCantidad.Text)
                    Else
                        .SubItems(ColumnasDetalle.Cantidad).Text = InfoArticulo.CantidadSinRedondeo
                    End If
                End If
                .SubItems(ColumnasDetalle.Nombre).Text = InfoArticulo.Nombre
                .SubItems(ColumnasDetalle.Precio).Text = Format(InfoArticulo.Precio, "##0.0000")
                .SubItems(ColumnasDetalle.PorcDescuento).Text = Format(SeleccionaPorcDescuento(), "##0.0000")
                .SubItems(ColumnasDetalle.MontoDescuento).Text = Format(InfoArticulo.Precio * (CDbl(.SubItems(ColumnasDetalle.PorcDescuento).Text) / 100), "##0.0000")
                .SubItems(ColumnasDetalle.Suelto).Text = InfoArticulo.Suelto
                .SubItems(ColumnasDetalle.Padre).Text = InfoArticulo.ArtPadre
                .SubItems(ColumnasDetalle.Conjunto).Text = pArtConjunto
                .SubItems(ColumnasDetalle.Exento).Text = InfoArticulo.ExentoIV
                If TxtExento.Text = "NO" Then
                    If InfoArticulo.ExentoIV Then
                        .SubItems(ColumnasDetalle.MontoIV).Text = "0.00"
                    Else
                        .SubItems(ColumnasDetalle.MontoIV).Text = Format(CalculaMontoImpuesto(Linea_Id, (InfoArticulo.Precio - CDbl(.SubItems(ColumnasDetalle.MontoDescuento).Text)), ArticuloImpuestos), "##0.0000")
                    End If
                Else
                    .SubItems(ColumnasDetalle.MontoIV).Text = "0.00"
                End If
                .SubItems(ColumnasDetalle.Saldo).Text = InfoArticulo.Saldo
                .SubItems(ColumnasDetalle.Costo).Text = InfoArticulo.Costo
                .SubItems(ColumnasDetalle.Servicio).Text = InfoArticulo.Servicio
                .SubItems(ColumnasDetalle.CalculaCantidadFactura).Text = InfoArticulo.CalculaCantidadFactura
                .SubItems(ColumnasDetalle.TotalLinea).Text = Format(((CDbl(.SubItems(ColumnasDetalle.Precio).Text) - CDbl(.SubItems(ColumnasDetalle.MontoDescuento).Text)) + CDbl(.SubItems(ColumnasDetalle.MontoIV).Text)) * CDbl(.SubItems(ColumnasDetalle.Cantidad).Text), "##0.0000")
                '.SubItems(ColumnasDetalle.Comentario).Text = ""
            End With


            Item.Tag = ArticuloImpuestos


            If Accion = AccionDetalle.Nuevo Then
                LvwDetalle.Items.Add(Item)
                Item.EnsureVisible()
            End If

            'Marca la ultima linea modificada o ingresada
            LvwDetalle.SelectedItems.Clear()
            Item.Selected = True

            TxtArticulo.Text = ""
            InicializaArticulo()

            If InfoMaquina.InterfazFactura = Enum_InterfazFacturacion.CantidadAntes Then
                TxtCantidadAntes.Text = ""
                TxtCantidadAntes.Focus()
            Else
                TxtArticulo.Focus()
            End If

            If Accion <> AccionDetalle.Modifica And Not pArtConjunto Then
                If InfoArticulo.ListaConjuntos.Count > 0 Then
                    CargaArticulosConjuntos()
                End If
            End If

            MuestraTotales()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaDescuento() As Boolean
        Try

            If Not IsNumeric(TxtPorcDescLinea.Text) Then
                TxtPorcDescLinea.Text = "0.00"
            End If


            If Not IsNumeric(TxtPorcDescLinea.Text) OrElse CDbl(TxtPorcDescLinea.Text) < 0 Then
                TxtPorcDescLinea.SelectAll()
                TxtPorcDescLinea.Focus()
                VerificaMensaje("El porcentaje de descuento debe de ser mayor o igual a cero")
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
                TxtPrecio.Text = "0.0000"
            End If


            If Not IsNumeric(TxtPrecio.Text) OrElse CDbl(TxtPrecio.Text) <= 0 Then
                TxtPrecio.SelectAll()
                TxtPrecio.Focus()
                VerificaMensaje("El precio debe de ser mayor a cero")
            End If

            InfoArticulo.Precio = CDbl(TxtPrecio.Text)


            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function


    Private Function ValidaCantidad() As Boolean
        Try
            'If Not IsNumeric(TxtPorcDescLinea.Text) OrElse CDbl(TxtPorcDescLinea.Text) < 0 Then
            '    TxtPorcDescLinea.SelectAll()
            '    TxtPorcDescLinea.Focus()
            '    VerificaMensaje("El porcentaje de descuento debe de ser mayor o igual a cero")
            'End If

            If Not IsNumeric(TxtCantidad.Text) OrElse CDbl(TxtCantidad.Text) <= 0 Then
                TxtCantidad.SelectAll()
                TxtCantidad.Focus()
                VerificaMensaje("La cantidad debe de ser mayor a cero")
            End If

            'Modificando linea verifica si la cantidad que esta ingresando es menor a la anterior
            If Not LvwDetalle.Tag Is Nothing Then
                If CDbl(CType(LvwDetalle.Tag, ListViewItem).SubItems(ColumnasDetalle.Cantidad).Text) > CDbl(TxtCantidad.Text) Then
                    If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PVDisminuyeCantidadLineaFactura, False) Then
                        VerificaMensaje("La cantidad no puede ser menor")
                    End If
                End If
            End If


            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub TxtCantidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCantidad.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If ValidaDescuento() And ValidaCantidad() And ValidaPrecio() Then
                    IngresaArticulo(False)
                End If
            Case Keys.Escape
                InicializaArticulo()
                TxtArticulo.Text = ""
                If InfoMaquina.InterfazFactura = Enum_InterfazFacturacion.CantidadAntes Then
                    TxtCantidadAntes.Text = ""
                    TxtCantidadAntes.Focus()
                Else
                    TxtArticulo.Focus()
                End If
        End Select
    End Sub

    Private Sub LvwDetalle_DoubleClick(sender As Object, e As System.EventArgs) Handles LvwDetalle.DoubleClick
        If Not LvwDetalle.SelectedItems Is Nothing And LvwDetalle.SelectedItems.Count > 0 Then
            ModificaLinea()
        End If

    End Sub
    Private Sub LvwDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles LvwDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                ModificaLinea()
            Case Keys.Enter
                MuestraLineaDetalle()
            Case Keys.Delete
                If LvwDetalle.Items.Count > 0 Then
                    EliminaLinea()
                End If
        End Select
    End Sub
    Private Sub EliminaLinea()
        Try
            If Not TxtArticulo.Enabled Then
                Exit Sub
            End If


            'Si esta facturando un apartado no permite agregar articulos
            If Not _Proforma Is Nothing AndAlso _Proforma.Tipo = Enum_TipoFacturacion.ApartadoRetirado Then
                TxtArticulo.SelectAll()
                VerificaMensaje("No se pueden eliminar líneas de un apartado")
            End If

            If LvwDetalle.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar una línea")
            End If

            If LvwDetalle.SelectedItems.Count > 1 Then
                VerificaMensaje("Debe de seleccionar únicamente la línea que desea eliminar")
            End If


            If Not ConfirmaAccion("Desea eliminar la línea del detalle") Then
                Exit Sub
            End If


            If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PvEliminaLineaFactura, False) Then
                VerificaMensaje("No tiene permiso para Eliminar líneas")
            End If

            If _TipoFacturacion = Enum_TipoFacturacion.Factura Then
                VerificaMensaje(VerificaModificacionFactura(_TipoFacturacion, _Proforma))
            End If



            InicializaArticulo()
            LvwDetalle.Tag = Nothing
            InfoArticulo.ListaConjuntos.Clear()

            '_FacturaDetalleImpuestos.RemoveAll(Function(x) x.Detalle_Id = CLng(LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Linea).Text))

            LvwDetalle.Items.Remove(LvwDetalle.SelectedItems(0))

            MuestraTotales()

            If InfoMaquina.InterfazFactura = Enum_InterfazFacturacion.CantidadAntes Then
                TxtCantidadAntes.Focus()
            Else
                TxtArticulo.Focus()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ModificaLinea()
        Try

            'Si esta facturando un apartado no permite agregar articulos
            If Not _Proforma Is Nothing AndAlso _Proforma.Tipo = Enum_TipoFacturacion.ApartadoRetirado Then
                TxtArticulo.SelectAll()
                VerificaMensaje("No se pueden modificar líneas de un apartado")
            End If

            If Not LvwDetalle.Tag Is Nothing Then
                TxtCantidad.Focus()
                Exit Sub
            End If

            If LvwDetalle.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar una línea")
            End If

            If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PvModificaLineaFactura, False) Then
                VerificaMensaje("No tiene permiso para modificar líneas")
            End If

            If _TipoFacturacion = Enum_TipoFacturacion.Factura Then
                VerificaMensaje(VerificaModificacionFactura(_TipoFacturacion, _Proforma))
            End If

            InicializaArticulo()

            TxtArticulo.Text = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Articulo).Text
            ValidaArticulo(TxtArticulo.Text, True)

            TxtPrecio.Text = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Precio).Text
            TxtPrecio.SelectAll()
            TxtPorcDescLinea.Text = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.PorcDescuento).Text
            TxtCantidad.Text = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Cantidad).Text
            TxtCantidad.SelectAll()

            LvwDetalle.Tag = LvwDetalle.SelectedItems(0)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub MuestraLineaDetalle()
        Dim forma As New FrmPuntoVentaLineaInfo
        Try
            If Not LvwDetalle.Tag Is Nothing Then
                TxtCantidad.Focus()
                Exit Sub
            End If

            If LvwDetalle.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar una línea")
            End If

            'If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PvModificaLineaFactura, False) Then
            '    VerificaMensaje("No tiene permiso para modificar líneas")
            'End If

            'If _TipoFacturacion = Enum_TipoFacturacion.Factura Then
            '    VerificaMensaje(VerificaModificacionFactura(_TipoFacturacion, _Proforma))
            'End If

            'InicializaArticulo()

            forma.ArticuloNombre = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Articulo).Text & " - " & LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Nombre).Text
            forma.Comentario = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Observacion).Text

            forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            forma = Nothing
        End Try
    End Sub

    Private Sub TxtPorcDescLinea_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtPorcDescLinea.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    If ValidaDescuento() Then
                        TxtCantidad.Focus()
                    End If
                Case Keys.F2
                    If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PvDescuentoFacturaLinea, False) Then
                        VerificaMensaje("No tiene permiso cambiar el descuento x línea de la factura")
                    End If

                    Dim Forma As New FrmIngresaMonto
                    With Forma
                        .PermiteDecimales = True
                        .CantidadEnteros = 3
                        .CantidadDecimales = 2
                        .Monto = CDbl(TxtPorcDescLinea.Text)
                        .Descripcion = "Descuento Línea"
                    End With

                    Forma.Execute()
                    If Forma.Acepto Then
                        If Forma.Monto > 100 Then
                            VerificaMensaje("El monto de descuento no puede ser mayor a 100")
                        End If
                        TxtPorcDescLinea.Text = Format(Forma.Monto, "##0.00")
                        TxtCantidad.Focus()
                    End If
                    Forma = Nothing
                Case Keys.Escape
                    InicializaArticulo()
                    TxtArticulo.Text = ""
                    If InfoMaquina.InterfazFactura = Enum_InterfazFacturacion.CantidadAntes Then
                        TxtCantidadAntes.Text = ""
                        TxtCantidadAntes.Focus()
                    End If
                    TxtArticulo.Focus()
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CalculaTotales(ByRef pCosto As Double, ByRef pSubTotal As Double, ByRef pDescuento As Double, ByRef pIV As Double, ByRef pTotal As Double, ByRef pTotalExento As Double, ByRef pTotalGravado As Double)
        Try
            pCosto = 0
            pSubTotal = 0
            pDescuento = 0
            pIV = 0
            pTotal = 0
            pTotalExento = 0
            pTotalGravado = 0


            For Each Fila As ListViewItem In LvwDetalle.Items
                pCosto = pCosto + (CDbl(Fila.SubItems(ColumnasDetalle.Costo).Text) * CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text))
                pSubTotal = pSubTotal + (CDbl(Fila.SubItems(ColumnasDetalle.Precio).Text) * CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text))
                pDescuento = pDescuento + (CDbl(Fila.SubItems(ColumnasDetalle.MontoDescuento).Text) * CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text))
                pIV = pIV + (CDbl(Fila.SubItems(ColumnasDetalle.MontoIV).Text) * CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text))
                pTotal = pTotal + CDbl(Fila.SubItems(ColumnasDetalle.TotalLinea).Text)
                If Fila.SubItems(ColumnasDetalle.Exento).Text = "0" Then
                    pTotalGravado = pTotalGravado + (CDbl(Fila.SubItems(ColumnasDetalle.Precio).Text) * CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text))
                Else
                    pTotalExento = pTotalExento + (CDbl(Fila.SubItems(ColumnasDetalle.Precio).Text) * CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text))
                End If
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub MuestraTotales()
        Dim Costo As Double = 0
        Dim SubTotal As Double = 0
        Dim Descuento As Double = 0
        Dim IV As Double = 0
        Dim Total As Double = 0
        Dim TotalExento As Double = 0
        Dim TotalGravado As Double = 0
        Try

            LblSubTotal.Text = "0.00"
            LblDescuento.Text = "0.00"
            LblImpuestoVenta.Text = "0.00"
            LblTotal.Text = "0.00"
            LblTotalGrande.Text = "0.00"
            LblTotalDolares.Text = "0.00"

            CalculaTotales(Costo, SubTotal, Descuento, IV, Total, TotalExento, TotalGravado)

            LblSubTotal.Text = Format(SubTotal, "##0.00")
            LblDescuento.Text = Format(Descuento, "##0.00")
            LblImpuestoVenta.Text = Format(IV, "##0.00")
            LblTotal.Text = Format(Total, "##0.00")
            LblTotalGrande.Text = Format(RedondeaMontoCobro(Total), "#,##0.00")

            If Not LblTotalGrande.Visible Then
                LblTotalGrande.Visible = True
            End If

            If TxtDolares.Text = "SI" Then
                If Not LblTotalDolares.Visible Then
                    LblTotalDolares.Visible = True
                End If

                CalculaTotalDolares()
            Else
                LblTotalDolares.Text = "0.00"
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CalculaTotalDolares()
        Try

            If Not IsNumeric(LblTotalGrande.Text) Then
                LblTotalGrande.Text = "0.00"
            End If

            If Not IsNumeric(TxtTipoCambio.Text) OrElse CDbl(TxtTipoCambio.Text) <= 0 Then
                VerificaMensaje("Se presentaron problemas con el tipo cambio favor verificar")
            End If

            LblTotalDolares.Text = "$ " & Format(CDbl(LblTotalGrande.Text) / CDbl(TxtTipoCambio.Text), "#,##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    'Private Function VerificaProforma() As String
    '    Dim Mensaje As String = ""
    '    Try

    '        Mensaje = _Proforma.ListKey
    '        VerificaMensaje(Mensaje)


    '        If _Proforma.RowsAffected = 0 Then
    '            VerificaMensaje("Imposible facturar, debido a que la Proforma ya no se encuentra disponible")
    '        End If

    '        Return ""

    '    Catch ex As Exception
    '        Return ex.Message
    '    End Try
    'End Function

    Private Sub GuardarProforma(pTipoFacturacion As Enum_TipoFacturacion, pFacturaEnEspera As Boolean)
        Dim ProformaEncabezado As New TProformaEncabezado(EmpresaInfo.Emp_Id)
        Dim FormaVuelto As New FrmVuelto
        Dim ProformaDetalles As New List(Of TProformaDetalle)
        Dim ProformaDetalle As TProformaDetalle = Nothing
        Dim FacturaPagos As New List(Of TFacturaPago)
        Dim FacturaPago As TFacturaPago = Nothing
        Dim TipoDoc_Id As Enum_TipoDocumento
        Dim Mensaje As String = ""
        Dim Fecha As DateTime
        Dim Costo As Double = 0
        Dim SubTotal As Double = 0
        Dim Descuento As Double = 0
        Dim IV As Double = 0
        Dim Total As Double = 0
        Dim Detalle_Id As Integer = 0
        Dim Redondeo As Double = 0
        Dim TotalCobrado As Double = 0
        Dim Vuelto As Double = 0
        Dim TotalEfectivo As Double = 0
        Dim Factor As Integer = 0
        'Dim ThdImpresion As Thread
        Dim TotalExento As Double = 0
        Dim TotalGravado As Double = 0
        Dim FormaTipoEntrega As New FrmEntregaMercaderia
        Dim TipoEntrega_Id As Integer = Enum_TipoEntrega.Tienda
        Dim FechaEntrega As Date = DateValue(EmpresaInfo.Getdate())
        Dim TipoEntrega As New TProformaTipoEntrega(EmpresaInfo.Emp_Id)
        Dim TipoEntregaNombre As String = ""
        Dim TipoEntregaDireccion As String = ""
        Dim TmpCliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim MontoPrima As Double = 0
        Dim MontoPrimaDigitado As Double = 0
        Dim FormaCondicionApartado As New FrmApartadoCondiciones
        Dim FormaPago As New FrmPago
        Dim tipoPago As String = String.Empty
        Dim Vencimiento As Date = #1/1/1900#
        Dim Apartado As New TApartadoEncabezado(EmpresaInfo.Emp_Id)
        Try


            TmpCliente.Cliente_Id = CInt(TxtCliente.Text)
            VerificaMensaje(TmpCliente.ListKey())

            If _TipoFacturacion = Enum_TipoFacturacion.PreFactura AndAlso InfoMaquina.PrefacturaTipoEntrega = 1 Then
                If Not _Proforma Is Nothing Then
                    FormaTipoEntrega.TipoEntrega = _Proforma.TipoEntrega_Id
                    FormaTipoEntrega.FechaEntrega = _Proforma.FechaEntrega
                    If _Proforma.TipoEntrega_Id = Enum_TipoEntrega.Tienda Then
                        FormaTipoEntrega.DireccionEntrega = TmpCliente.Direccion
                    Else
                        FormaTipoEntrega.DireccionEntrega = _Proforma.DireccionEntrega
                    End If
                Else
                    FormaTipoEntrega.DireccionEntrega = TmpCliente.Direccion
                End If

                FormaTipoEntrega.Execute()
                If Not FormaTipoEntrega.Guardo Then
                    Exit Sub
                Else
                    With FormaTipoEntrega
                        TipoEntrega_Id = .TipoEntrega
                        FechaEntrega = .FechaEntrega
                        TipoEntregaNombre = .TipoEntregaNombre
                        TipoEntregaDireccion = .DireccionEntrega
                    End With

                End If
            End If


            'Refresca los valores de la caja
            VerificaMensaje(CajaInfo.ListKey)

            TipoDoc_Id = Val(TxtTipoDocumento.Text)

            'Busca la fecha de la BD
            Fecha = EmpresaInfo.Getdate()

            CalculaTotales(Costo, SubTotal, Descuento, IV, Total, TotalExento, TotalGravado)

            TotalCobrado = RedondeaMontoCobro(Total)
            Redondeo = TotalCobrado - Total



            'Si es un apartado verifica si pide prima
            If _TipoFacturacion = Enum_TipoFacturacion.Apartado Then
                MontoPrima = RedondeaMontoCobro(Total) * (EmpresaParametroInfo.ApartadoPrimaPorcentaje / 100)

                With FormaCondicionApartado
                    .Descripcion = "Monto de Prima"
                    .CantidadEnteros = 8
                    .CantidadDecimales = 0
                    .Monto = MontoPrima
                End With

                FormaCondicionApartado.Execute()

                If Not FormaCondicionApartado.Acepto Then
                    VerificaMensaje("Debe de ingresar el monto de prima")
                End If



                MontoPrimaDigitado = FormaCondicionApartado.Monto
                Vencimiento = FormaCondicionApartado.Vencimiento

                If MontoPrimaDigitado >= Total Then
                    VerificaMensaje("El monto de la prima debe ser menor al total del apartado")
                End If

                If MontoPrima > MontoPrimaDigitado Then
                    If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PVApartaBajoPrima, False) Then
                        VerificaMensaje("No tiene permiso para realizar apartados con una prima menor al " & EmpresaParametroInfo.ApartadoPrimaPorcentaje & "% del total del Apartado")
                    End If
                End If



                '-- Pago Ini ---------------------------------------------------------------------------------------------------
                With FormaPago
                    .SubTotal = SubTotal
                    .Descuento = Descuento
                    .ImpuestoVenta = IV
                    .TotalFactura = MontoPrimaDigitado
                    .Cliente_Id = CInt(TxtCliente.Text)
                    .Execute()
                End With

                Application.DoEvents()

                If Not FormaPago.PagoDocumento Then
                    Exit Sub
                End If
                Vuelto = FormaPago.Vuelto
                TotalEfectivo = FormaPago.TotalEfectivo

                'FacturaEncabezado.Vuelto = FormaPago.Vuelto
                'FacturaEncabezado.TotalEfectivo = FormaPago.TotalEfectivo


                Detalle_Id = 0


                For Each Pago As TFacturaPago In FormaPago.FacturaPagos
                    If Pago.Monto <> 0 Then
                        FacturaPago = New TFacturaPago(EmpresaInfo.Emp_Id)
                        Detalle_Id += 1

                        With FacturaPago
                            .Suc_Id = CajaInfo.Suc_Id
                            .Caja_Id = CajaInfo.Caja_Id
                            .TipoDoc_Id = TipoDoc_Id
                            .Documento_Id = 0 'FacturaEncabezado.Documento_Id
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
                            .TipoDoc_Id = TipoDoc_Id
                            .Documento_Id = 0 'FacturaEncabezado.Documento_Id
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

                        FacturaPagos.Add(FacturaPago)

                        tipoPago = tipoPago & IIf(tipoPago.Trim = String.Empty, "", ",") & FacturaPago.TipoPago_Id.ToString()

                    End If
                Next

                '-- Pago Fin ---------------------------------------------------------------------------------------------------
            End If



            'If Not _Proforma Is Nothing AndAlso _TipoFacturacion = Enum_TipoFacturacion.PreFactura Then
            '    VerificaMensaje(_Proforma.Delete())
            'End If

            If Not _Proforma Is Nothing Then 'Si esta modificando alguna pre
                With ProformaEncabezado.ProformaAnterior
                    .Emp_Id = _Proforma.Emp_Id
                    .Suc_Id = _Proforma.Suc_Id
                    .Documento_Id = _Proforma.Documento_Id
                End With
            Else
                With ProformaEncabezado.ProformaAnterior
                    .Emp_Id = -1
                    .Suc_Id = -1
                    .Documento_Id = -1
                End With
            End If

            Select Case TipoDoc_Id
                Case Enum_TipoDocumento.Contado, Enum_TipoDocumento.Credito
                    Factor = 1
                Case Enum_TipoDocumento.DevolucionContado, Enum_TipoDocumento.DevolucionCredito
                    Factor = -1
            End Select

            'Carga datos del encabezado de la factura
            With ProformaEncabezado
                .Emp_Id = CajaInfo.Emp_Id
                .Suc_Id = CajaInfo.Suc_Id

                'If Not _Proforma Is Nothing AndAlso _TipoFacturacion = Enum_TipoFacturacion.PreFactura Then
                '    .Documento_Id = _Proforma.Documento_Id
                'Else
                '    VerificaMensaje(.SiguienteProforma)
                'End If

                If Not _Proforma Is Nothing And Not _TipoFacturacion = Enum_TipoFacturacion.Apartado Then
                    .Documento_Id = _Proforma.Documento_Id
                Else
                    VerificaMensaje(.SiguienteProforma)
                End If

                .TipoDoc_Id = Val(TxtTipoDocumento.Text)
                .Bod_Id = CajaInfo.Bod_Id
                .Fecha = Fecha
                .Cliente_Id = CInt(TxtCliente.Text)
                .Nombre = TxtClienteNombre.Text.Trim
                .Vendedor_Id = CInt(TxtVendedor.Text)
                .Usuario_Id = UsuarioInfo.Usuario_Id
                .Comentario = _Comentario
                .Costo = Costo * Factor
                .Subtotal = SubTotal * Factor
                .Descuento = Descuento * Factor
                .IV = IV * Factor
                .Total = Total * Factor
                .Redondeo = Redondeo * Factor
                .TotalCobrado = TotalCobrado * Factor
                .Cierre_Id = CajaInfo.Cierre_Id
                .CPU = InfoMaquina.CPU
                .IPAddress = InfoMaquina.IP_Address
                .HostName = InfoMaquina.HostName
                .TipoDocumentoNombre = TxtTipoDocumentoNombre.Text
                .ProformaDetalles = ProformaDetalles
                .UsuarioNombre = UsuarioInfo.Nombre
                .Exento = TotalExento * Factor
                .Gravado = TotalGravado * Factor
                .Dolares = IIf(TxtDolares.Text = "SI", 1, 0)
                .TipoCambio = IIf(TxtDolares.Text = "SI", IIf(IsNumeric(TxtTipoCambio.Text), CDbl(TxtTipoCambio.Text), 1), 1)
                .ProformaDiasVencimiento = EmpresaParametroInfo.ProformaDiasVencimiento
                .Vencimiento = DateAdd(DateInterval.Day, EmpresaParametroInfo.ProformaDiasVencimiento, EmpresaInfo.Getdate())
                .Tipo = pTipoFacturacion
                .TipoEntrega_Id = TipoEntrega_Id
                .FechaEntrega = FechaEntrega
                .TipoEntregaNombre = TipoEntregaNombre
                .VendedorNombre = TxtVendedorNombre.Text
                If _TipoFacturacion = Enum_TipoFacturacion.PreFactura And (TipoEntrega_Id = Enum_TipoEntrega.Encomienda Or TipoEntrega_Id = Enum_TipoEntrega.Mensajero) Then
                    .DireccionEntrega = TipoEntregaDireccion
                Else
                    .DireccionEntrega = String.Empty
                End If

            End With


            'Carga datos del detalle de la factura
            Detalle_Id = 0
            For Each Fila As ListViewItem In LvwDetalle.Items
                ProformaDetalle = New TProformaDetalle(EmpresaInfo.Emp_Id)
                Detalle_Id += 1
                With ProformaDetalle
                    .Suc_Id = CajaInfo.Suc_Id
                    .Documento_Id = ProformaEncabezado.Documento_Id
                    .Detalle_Id = Detalle_Id
                    .Art_Id = Fila.SubItems(ColumnasDetalle.Articulo).Text
                    .Cantidad = CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text) * Factor
                    .Fecha = Fecha
                    .Costo = CDbl(Fila.SubItems(ColumnasDetalle.Costo).Text)
                    .Precio = CDbl(Fila.SubItems(ColumnasDetalle.Precio).Text)
                    .PorcDescuento = CDbl(Fila.SubItems(ColumnasDetalle.PorcDescuento).Text)
                    .MontoDescuento = CDbl(Fila.SubItems(ColumnasDetalle.MontoDescuento).Text)
                    .MontoIV = CDbl(Fila.SubItems(ColumnasDetalle.MontoIV).Text)
                    .TotalLinea = ((CDbl(Fila.SubItems(ColumnasDetalle.Precio).Text) - CDbl(Fila.SubItems(ColumnasDetalle.MontoDescuento).Text)) + CDbl(Fila.SubItems(ColumnasDetalle.MontoIV).Text))
                    .ExentoIV = Fila.SubItems(ColumnasDetalle.Exento).Text
                    .Suelto = Fila.SubItems(ColumnasDetalle.Suelto).Text
                    .Descripcion = Fila.SubItems(ColumnasDetalle.Nombre).Text
                    .Usuario = UsuarioInfo.Usuario_Id
                    .Observacion = Fila.SubItems(ColumnasDetalle.Observacion).Text.Trim()
                    .Servicio = Fila.SubItems(ColumnasDetalle.Servicio).Text
                    .CalculaCantidadFactura = Fila.SubItems(ColumnasDetalle.CalculaCantidadFactura).Text
                    .ArticuloImpuestos = CType(Fila.Tag, List(Of TFacturaDetalleImpuesto))
                End With
                ProformaDetalles.Add(ProformaDetalle)
            Next

            'Agrega listas al encabezado de la factura
            With ProformaEncabezado
                .ProformaDetalles = ProformaDetalles
            End With


            If _TipoFacturacion = Enum_TipoFacturacion.Apartado Then
                Mensaje = Apartado.IngresarDeFacturaApartado(ProformaEncabezado, FacturaPagos, MontoPrimaDigitado)
            Else
                Mensaje = ProformaEncabezado.GuardarDocumento()
            End If
            VerificaMensaje(Mensaje)

            'If pTipoFacturacion = Enum_TipoFacturacion.Proforma Then
            '    ThdImpresion = New Thread(AddressOf ImprimeProforma)

            '    ThdImpresion.Start(ProformaEncabezado)
            'End If

            If pTipoFacturacion = Enum_TipoFacturacion.Apartado Then
                VerificaMensaje(ImprimeApartado(Apartado))
            End If

            If pTipoFacturacion = Enum_TipoFacturacion.Proforma Then
                ImprimeProforma(ProformaEncabezado)
            End If


            If Not pFacturaEnEspera Then
                If InfoMaquina.ImprimePrefactura And pTipoFacturacion = Enum_TipoFacturacion.PreFactura Then
                    If ConfirmaAccion("Desea imprimir la prefactura?") Then

                        ImprimePrefactura(ProformaEncabezado)
                    End If
                End If
            End If


            'If Not _Proforma Is Nothing AndAlso _TipoFacturacion = Enum_TipoFacturacion.PreFactura Then
            '    VerificaMensaje(_Proforma.Delete())
            'End If

            Inicializa()
            TxtTipoDocumento.Focus()

            TxtTipoDocumento_KeyDown(Me.TxtTipoDocumento, New KeyEventArgs(Keys.Enter))

            If _TipoFacturacion = Enum_TipoFacturacion.PreFactura AndAlso _CerrarAlGuardar Then
                Me.Close()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Apartado = Nothing
            ProformaEncabezado = Nothing
            FormaVuelto = Nothing
            ProformaDetalles = Nothing
            ProformaDetalle = Nothing
            TmpCliente = Nothing
            FormaCondicionApartado = Nothing
            FormaPago = Nothing
            FacturaPago = Nothing
            FacturaPagos = Nothing
        End Try
    End Sub


    Private Function VerificaDescuentoxTipoPago(pTipoPago As String) As String
        Dim Mensaje As String = ""
        Dim TipoPago As New TTipoPago(EmpresaInfo.Emp_Id)
        Dim valor As Double = 0.00
        Dim i As Integer = 0
        Try

            Mensaje = TipoPago.GetRangoDescuento(pTipoPago.ToString())
            VerificaMensaje(Mensaje)

            For Each item In LvwDetalle.Items

                valor = Convert.ToDouble(LvwDetalle.Items(i).SubItems(ColumnasDetalle.PorcDescuento).Text.ToString())

                If valor > 0 AndAlso (valor < TipoPago.PorcDescuentoDesde Or valor > TipoPago.PorcDescuentoHasta) Then
                    Throw New Exception("El porcentaje de descuento por tipo de pago no es permitido en la línea # " + (i + 1).ToString())
                End If
                i = i + 1
            Next

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Sub GuardarFactura()
        Dim FacturaEncabezado As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim FormaPago As New FrmPago
        Dim FormaVuelto As New FrmVuelto
        Dim FacturaDetalles As New List(Of TFacturaDetalle)
        Dim FacturaPagos As New List(Of TFacturaPago)
        Dim FacturaDetalle As TFacturaDetalle = Nothing
        Dim FacturaPago As TFacturaPago = Nothing
        Dim TipoDoc_Id As Enum_TipoDocumento
        Dim Mensaje As String = ""
        Dim Fecha As DateTime
        Dim Costo As Double = 0
        Dim SubTotal As Double = 0
        Dim Descuento As Double = 0
        Dim IV As Double = 0
        Dim Total As Double = 0
        Dim Detalle_Id As Integer = 0
        Dim Redondeo As Double = 0
        Dim TotalCobrado As Double = 0
        Dim Vuelto As Double = 0
        Dim TotalEfectivo As Double = 0
        Dim Factor As Integer = 0
        Dim ThdImpresion As Thread
        Dim TotalExento As Double = 0
        Dim TotalGravado As Double = 0
        Dim RecargoCredito As Double = 0
        Dim _Cliente As New TCliente(EmpresaInfo.Emp_Id)
        'Dim FormaIngresaMonto As New FrmIngresaMonto
        Dim tipoPago As String = String.Empty
        Dim Articulos As String = ""
        Dim FacturandoApartado As Boolean = False
        Dim FormaCxCFacturaPendiente As New FrmCxCFacturaPendiente
        Try
            'Refresca los valores de la caja
            VerificaMensaje(CajaInfo.ListKey)
            TipoDoc_Id = Val(TxtTipoDocumento.Text)

            'Busca la fecha de la BD
            Fecha = EmpresaInfo.Getdate()

            CalculaTotales(Costo, SubTotal, Descuento, IV, Total, TotalExento, TotalGravado)
            TotalCobrado = RedondeaMontoCobro(Total)
            Redondeo = TotalCobrado - Total

            Select Case TipoDoc_Id
                Case Enum_TipoDocumento.Contado, Enum_TipoDocumento.Credito
                    Factor = 1
                Case Enum_TipoDocumento.DevolucionContado, Enum_TipoDocumento.DevolucionCredito
                    Factor = -1
            End Select

            _Cliente.Cliente_Id = Val(TxtCliente.Text)
            VerificaMensaje(_Cliente.ListKey())


            FacturandoApartado = (Not _Proforma Is Nothing AndAlso _Proforma.Tipo = Enum_TipoFacturacion.ApartadoRetirado)

            'If CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.Credito AndAlso EmpresaParametroInfo.SolicitaCreditoPrima Then
            '    'Solicita el monto de la prima
            '    With FormaIngresaMonto
            '        .PermiteDecimales = True
            '        .CantidadEnteros = 6
            '        .CantidadDecimales = 2
            '        .Monto = 0
            '        .Descripcion = "Monto de Prima"
            '    End With

            '    FormaIngresaMonto.Execute()
            '    If FormaIngresaMonto.Acepto Then
            '        If FormaIngresaMonto.Monto >= TotalCobrado Then
            '            MensajeError("El monto de la prima debe de ser menor al total de la factura", Me.Text)
            '            Exit Sub
            '        End If
            '        MontoPrima = FormaIngresaMonto.Monto
            '    Else
            '        MensajeError("Debe de indicar el monto de la prima", Me.Text)
            '        Exit Sub
            '    End If
            'End If

            'Carga datos del encabezado de la factura
            With FacturaEncabezado
                .Emp_Id = CajaInfo.Emp_Id
                .Suc_Id = CajaInfo.Suc_Id
                .Caja_Id = CajaInfo.Caja_Id
                .TipoDoc_Id = TipoDoc_Id
                VerificaMensaje(.SiguienteFactura)
                .Bod_Id = CajaInfo.Bod_Id
                .Fecha = Fecha
                .Cliente_Id = CInt(TxtCliente.Text)
                .Nombre = TxtClienteNombre.Text.Trim
                .Vendedor_Id = CInt(TxtVendedor.Text)
                .Usuario_Id = UsuarioInfo.Usuario_Id
                .Comentario = _Comentario
                .Costo = Costo * Factor
                .Subtotal = SubTotal * Factor
                .Descuento = Descuento * Factor
                .IV = IV * Factor
                .Total = Total * Factor
                .Redondeo = Redondeo * Factor
                .TotalCobrado = TotalCobrado * Factor
                .Cierre_Id = CajaInfo.Cierre_Id
                .CPU = InfoMaquina.CPU
                .IPAddress = InfoMaquina.IP_Address
                .HostName = InfoMaquina.HostName
                .TipoDocumentoNombre = TxtTipoDocumentoNombre.Text
                .FacturaPagos = FacturaPagos
                .FacturaDetalles = FacturaDetalles
                .UsuarioNombre = UsuarioInfo.Nombre
                .Exento = TotalExento * Factor
                .Gravado = TotalGravado * Factor
                .Dolares = IIf(TxtDolares.Text = "SI", 1, 0)
                .TipoCambio = IIf(TxtDolares.Text = "SI", CDbl(TxtTipoCambio.Text), 1)
                .FacturaCxCLlave = Nothing
                .Proforma = _Proforma

                .FacturaDev = _FacturaDev
                .CxCDevolucionFacturas = _CxCDevolucionFacturas
                .MontoDevolucionFacturas = _MontoDevolucionFacturas
                .MontoNotaAdicional = _MontoNotaAdicional

                .TipoDevolucion = _TipoDevolucion
                .FacturandoApartado = FacturandoApartado
                .ReferenciaNC = _ReferenciaNC
                .Cliente = _Cliente
                .Vendedor.Emp_Id = EmpresaInfo.Emp_Id
                .Vendedor.Vendedor_Id = CInt(TxtVendedor.Text)

                If Not _Proforma Is Nothing AndAlso _Proforma.Tipo = Enum_TipoFacturacion.PreFactura AndAlso (_Proforma.TipoEntrega_Id = Enum_TipoEntrega.Encomienda Or _Proforma.TipoEntrega_Id = Enum_TipoEntrega.Mensajero) Then
                    .DireccionEntrega = _Proforma.DireccionEntrega
                Else
                    .DireccionEntrega = ""
                End If

            End With

            If CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.Contado And Not FacturandoApartado Then
                With FormaPago
                    .SubTotal = SubTotal
                    .Descuento = Descuento
                    .ImpuestoVenta = IV
                    .TotalFactura = TotalCobrado
                    'If CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.Contado Then
                    '    .TotalFactura = TotalCobrado
                    'Else
                    '    .TotalFactura = MontoPrima
                    'End If
                    .Cliente_Id = CInt(TxtCliente.Text)
                    .Execute()
                End With

                Application.DoEvents()

                If Not FormaPago.PagoDocumento Then
                    Exit Sub
                End If
                Vuelto = FormaPago.Vuelto
                TotalEfectivo = FormaPago.TotalEfectivo

                FacturaEncabezado.Vuelto = FormaPago.Vuelto
                FacturaEncabezado.TotalEfectivo = FormaPago.TotalEfectivo


                Detalle_Id = 0


                For Each Pago As TFacturaPago In FormaPago.FacturaPagos
                    If Pago.Monto <> 0 Then
                        FacturaPago = New TFacturaPago(EmpresaInfo.Emp_Id)
                        Detalle_Id += 1

                        With FacturaPago
                            .Suc_Id = CajaInfo.Suc_Id
                            .Caja_Id = CajaInfo.Caja_Id
                            .TipoDoc_Id = TipoDoc_Id
                            .Documento_Id = FacturaEncabezado.Documento_Id
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
                            .TipoDoc_Id = TipoDoc_Id
                            .Documento_Id = FacturaEncabezado.Documento_Id
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

                        FacturaPagos.Add(FacturaPago)

                        tipoPago = tipoPago & IIf(tipoPago.Trim = String.Empty, "", ",") & FacturaPago.TipoPago_Id.ToString()

                    End If
                Next
            End If


            'Si esta facturando un partado busca los pagos hechos al apartado para almacenarlos como pago de la factura
            If FacturandoApartado Then

                Detalle_Id = 0

                VerificaMensaje(_Proforma.ObtieneFormaPagoApartado())

                For Each fila As DataRow In _Proforma.Data.Tables("PagosApartado").Rows

                    FacturaPago = New TFacturaPago(EmpresaInfo.Emp_Id)
                    Detalle_Id += 1

                    With FacturaPago
                        .Suc_Id = CajaInfo.Suc_Id
                        .Caja_Id = CajaInfo.Caja_Id
                        .TipoDoc_Id = TipoDoc_Id
                        .Documento_Id = FacturaEncabezado.Documento_Id
                        .Pago_Id = Detalle_Id
                        .TipoPago_Id = fila("TipoPago_Id")
                        .Monto = fila("Monto")
                        .Dolares = 0
                        .Banco_Id = 0
                        .ChequeNumero = String.Empty
                        .ChequeFecha = #01/01/1900#
                        .Tarjeta_Id = 0
                        .TarjetaNumero = String.Empty
                        .TarjetaAutorizacion = String.Empty
                        .Fecha = Fecha
                    End With

                    FacturaPagos.Add(FacturaPago)

                    tipoPago = tipoPago & IIf(tipoPago.Trim = String.Empty, "", ",") & FacturaPago.TipoPago_Id.ToString()


                Next


            End If

            If CDbl(LblDescuento.Text) > 0 AndAlso FacturaPagos.Count > 0 Then
                Mensaje = VerificaDescuentoxTipoPago(tipoPago.ToString())
                If Mensaje.Trim <> String.Empty Then
                    If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PVDescuentoPorTipoPago, False) Then
                        VerificaMensaje(Mensaje)
                        Exit Sub
                    End If
                End If
            End If

            'Jimmy pendiente de hacer lo del comprometido
            'If CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.Contado Or CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.Credito Then
            '    If _TipoFacturacion = Enum_TipoFacturacion.Factura AndAlso EmpresaParametroInfo.PrefacturaCompromete Then
            '        If Not ValidaComprometido() Then
            '            Exit Sub
            '        End If
            '    End If
            'End If

            'Carga datos del detalle de la factura
            Detalle_Id = 0

            For Each Fila As ListViewItem In LvwDetalle.Items

                Articulos = Articulos & IIf(Articulos <> "", "|", "") + Fila.SubItems(ColumnasDetalle.Articulo).Text

                FacturaDetalle = New TFacturaDetalle(EmpresaInfo.Emp_Id)
                Detalle_Id += 1

                With FacturaDetalle
                    .Suc_Id = CajaInfo.Suc_Id
                    .Caja_Id = CajaInfo.Caja_Id
                    .TipoDoc_Id = TipoDoc_Id
                    .Documento_Id = FacturaEncabezado.Documento_Id
                    .Detalle_Id = Detalle_Id
                    .Art_Id = Fila.SubItems(ColumnasDetalle.Articulo).Text
                    .Cantidad = CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text) * Factor
                    .Fecha = Fecha
                    .Costo = CDbl(Fila.SubItems(ColumnasDetalle.Costo).Text)
                    .Precio = CDbl(Fila.SubItems(ColumnasDetalle.Precio).Text)
                    .PorcDescuento = CDbl(Fila.SubItems(ColumnasDetalle.PorcDescuento).Text)
                    .MontoDescuento = CDbl(Fila.SubItems(ColumnasDetalle.MontoDescuento).Text)
                    .MontoIV = CDbl(Fila.SubItems(ColumnasDetalle.MontoIV).Text)
                    .TotalLinea = ((CDbl(Fila.SubItems(ColumnasDetalle.Precio).Text) - CDbl(Fila.SubItems(ColumnasDetalle.MontoDescuento).Text)) + CDbl(Fila.SubItems(ColumnasDetalle.MontoIV).Text))
                    .ExentoIV = Fila.SubItems(ColumnasDetalle.Exento).Text
                    .Suelto = Fila.SubItems(ColumnasDetalle.Suelto).Text
                    .Descripcion = Fila.SubItems(ColumnasDetalle.Nombre).Text
                    .Usuario = UsuarioInfo.Usuario_Id
                    .Observacion = Fila.SubItems(ColumnasDetalle.Observacion).Text.Trim()
                    .Servicio = Fila.SubItems(ColumnasDetalle.Servicio).Text
                    .CalculaCantidadFactura = Fila.SubItems(ColumnasDetalle.CalculaCantidadFactura).Text
                    .ArticuloImpuestos = CType(Fila.Tag, List(Of TFacturaDetalleImpuesto))
                End With

                FacturaDetalles.Add(FacturaDetalle)
            Next

            'Agrega listas al encabezado de la factura
            With FacturaEncabezado
                .FacturaDetalles = FacturaDetalles
                .FacturaPagos = FacturaPagos
                .Articulos = Articulos
            End With

            'If TipoDoc_Id = Enum_TipoDocumento.DevolucionCredito Then
            '    If SaldoClienteCxC(CInt(TxtCliente.Text)) < CDbl(LblTotal.Text) Then
            '        VerificaMensaje("El saldo del cliente es menor al monto que se quiere devolver")
            '    End If
            'End If

            'Verifica que la prefactura todavia exista, si no existe reinica el documento
            If Not _Proforma Is Nothing Then
                Mensaje = ValidaProformaDisponible(_Proforma.Suc_Id, _Proforma.Documento_Id)
                If Mensaje <> "" Then
                    Inicializa()
                    TxtTipoDocumento.Focus()
                    TxtTipoDocumento_KeyDown(Me.TxtTipoDocumento, New KeyEventArgs(Keys.Enter))
                    VerificaMensaje(Mensaje)
                End If
            End If

            If FacturaDetalles.Count = 0 Then
                VerificaMensaje("Se presentaron errores almacenando el documento antes de ejecutar FacturaEncabezado.GuardarDocumento() por falta de comunicacion con el server" & vbCrLf & "No Cierre esta pantalla y comuniquese con el proveedor del software")
            End If

            'If Enum_TipoDocumento.DevolucionCredito = CInt(TxtTipoDocumento.Text) Then
            '    FacturaEncabezado.FacturaDev = _FacturaDev
            'End If

            'If Enum_TipoDocumento.DevolucionCredito = CInt(TxtTipoDocumento.Text) Then
            '    FacturaEncabezado.FacturaDev = _FacturaDev
            '    CXCAplicaNota.Execute(FacturaEncabezado)

            '    If CXCAplicaNota._VentanaCerrada Then
            '        FacturaEncabezado.MovimientoFacturaOriginal = CXCAplicaNota._MovimientoFacturaOriginal
            '        FacturaEncabezado.MovimientosFacturasDiferencia = CXCAplicaNota._MovimientosFacturasDiferencia
            '        FacturaEncabezado.TotalRestante = CXCAplicaNota._TotalRestante
            '    Else
            '        VerificaMensaje("No selecciono ninguna factura para dividir la diferencia")
            '    End If
            'End If

            VerificaMensaje(FacturaEncabezado.GuardarDocumento())

            If Detalle_Id <> FacturaEncabezado.DetallesGuardados Then
                VerificaMensaje("Error al guardar la factura por favor verifique la cantidad de detalles del documento: " & Articulos)
            End If

            VerificaMensaje(FacturaEncabezado.Cliente.ListKey())
            VerificaMensaje(FacturaEncabezado.Vendedor.ListKey())
            GuardaBitacoraUsuario(Modulos.PuntoVenta, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "Creación " & TxtTipoDocumentoNombre.Text & " # " & FacturaEncabezado.Documento_Id.ToString())

            If Not InfoMaquina.ConfirmaImpresionFactura Then
                ThdImpresion = New Thread(AddressOf ImprimeFactura)
                ThdImpresion.Start(FacturaEncabezado)
            Else
                If ConfirmaAccion("Desea imprimir la factura?") Then
                    ThdImpresion = New Thread(AddressOf ImprimeFactura)
                    ThdImpresion.Start(FacturaEncabezado)
                End If
            End If

            Select Case TipoDoc_Id
                Case Enum_TipoDocumento.Contado
                    FormaVuelto.Execute("Su vuelto es :", Vuelto)
                Case Enum_TipoDocumento.DevolucionContado, Enum_TipoDocumento.DevolucionCredito
                    FormaVuelto.Execute("Monto :", Math.Abs(TotalCobrado + FacturaEncabezado.RecargoCredito))
                Case Enum_TipoDocumento.Credito
                    If FacturaPagos.Count > 0 Then
                        FormaVuelto.Execute("Su vuelto es :", Vuelto)
                    Else
                        FormaVuelto.Execute("Monto :", Math.Abs(TotalCobrado + FacturaEncabezado.RecargoCredito))
                    End If
            End Select

            Inicializa()
            TxtTipoDocumento.Focus()
            TxtTipoDocumento_KeyDown(Me.TxtTipoDocumento, New KeyEventArgs(Keys.Enter))

            If CantidadFacturasPendientesDeEnvioCxC() > 0 Then
                FormaCxCFacturaPendiente.Execute()
                RefrescaLeyendaCxCPendiente()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FacturaEncabezado = Nothing
            FormaPago = Nothing
            FormaVuelto = Nothing
            FacturaDetalles = Nothing
            FacturaPagos = Nothing
            FacturaDetalle = Nothing
            FacturaPago = Nothing
            FormaCxCFacturaPendiente = Nothing
            _Comentario = ""
        End Try
    End Sub

    Private Sub TxtPorcDescGlobal_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtPorcDescGlobal.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    If InfoMaquina.InterfazFactura = Enum_InterfazFacturacion.CantidadAntes Then
                        If PanelDetalle.Enabled And TxtCantidadAntes.Enabled Then
                            TxtCantidadAntes.Focus()
                        Else
                            If TxtVendedor.Enabled Then
                                TxtVendedor.Focus()
                            End If
                        End If
                    Else
                        If PanelDetalle.Enabled And TxtArticulo.Enabled Then
                            TxtArticulo.Focus()
                        Else
                            If TxtVendedor.Enabled Then
                                TxtVendedor.Focus()
                            End If
                        End If
                    End If
                Case Keys.F2
                    If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PvDescuentoFacturaGlobal, False) Then
                        VerificaMensaje("No tiene permiso cambiar el descuento global de la factura")
                    End If

                    Dim Forma As New FrmIngresaMonto

                    With Forma
                        .PermiteDecimales = True
                        .CantidadEnteros = 3
                        .CantidadDecimales = 2
                        .Monto = CDbl(TxtPorcDescGlobal.Text)
                        .Descripcion = "Descuento Global"
                    End With

                    Forma.Execute()
                    If Forma.Acepto Then
                        If Forma.Monto > 100 Then
                            VerificaMensaje("El monto de descuento no puede ser mayor a 100")
                        End If
                        TxtPorcDescGlobal.Text = Format(Forma.Monto, "##0.00")
                        RecalculaDescuento(Forma.Monto)

                        If InfoMaquina.InterfazFactura = Enum_InterfazFacturacion.CantidadAntes Then
                            If PanelDetalle.Enabled And TxtCantidadAntes.Enabled Then
                                TxtCantidadAntes.Focus()
                            Else
                                If TxtVendedor.Enabled Then
                                    TxtVendedor.Focus()
                                End If
                            End If
                        Else
                            If PanelDetalle.Enabled And TxtArticulo.Enabled Then
                                TxtArticulo.Focus()
                            Else
                                If TxtVendedor.Enabled Then
                                    TxtVendedor.Focus()
                                End If
                            End If
                        End If
                    End If
                    Forma = Nothing
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub TxtExento_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtExento.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If InfoMaquina.InterfazFactura = Enum_InterfazFacturacion.CantidadAntes Then
                    If PanelDetalle.Enabled And TxtCantidadAntes.Enabled Then
                        TxtCantidadAntes.Focus()
                    Else
                        If TxtVendedor.Enabled Then
                            TxtVendedor.Focus()
                        End If
                    End If
                Else
                    If PanelDetalle.Enabled And TxtArticulo.Enabled Then
                        TxtArticulo.Focus()
                    Else
                        If TxtVendedor.Enabled Then
                            TxtVendedor.Focus()
                        End If
                    End If
                End If
            Case Keys.F2
                If TxtExento.Text = "NO" Then
                    TxtExento.Text = "SI"
                Else
                    TxtExento.Text = "NO"
                End If

                RecalculaImpuesto()

                If InfoMaquina.InterfazFactura = Enum_InterfazFacturacion.CantidadAntes Then
                    If PanelDetalle.Enabled And TxtCantidadAntes.Enabled Then
                        TxtCantidadAntes.Focus()
                    Else
                        If TxtVendedor.Enabled Then
                            TxtVendedor.Focus()
                        End If
                    End If
                Else
                    If PanelDetalle.Enabled And TxtArticulo.Enabled Then
                        TxtArticulo.Focus()
                    Else
                        If TxtVendedor.Enabled Then
                            TxtVendedor.Focus()
                        End If
                    End If
                End If
        End Select
    End Sub
    Private Sub TSLF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolM1F3.Click
        FrmPuntoVenta_KeyDown(Nothing, New KeyEventArgs(Keys.F3))
    End Sub
    Private Sub TxtPrecio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPrecio.KeyDown
        Try

            Select Case e.KeyCode
                Case Keys.Enter
                    If ValidaPrecio() Then
                        TxtPorcDescLinea.Focus()
                    End If
                Case Keys.Escape
                    InicializaArticulo()
                    TxtArticulo.Text = ""
                    If InfoMaquina.InterfazFactura = Enum_InterfazFacturacion.CantidadAntes Then
                        TxtCantidadAntes.Text = ""
                        TxtCantidadAntes.Focus()
                    Else
                        TxtArticulo.Focus()
                    End If
                Case Keys.F2
                    If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PVModificaPrecioFactura, False) Then
                        VerificaMensaje("No tiene permiso cambiar el precio")
                    End If

                    Dim Forma As New FrmArticuloPrecio
                    With Forma
                        .PermiteDecimales = True
                        .CantidadEnteros = 12
                        .CantidadDecimales = 4
                        .Monto = CDbl(TxtPrecio.Text)
                        .CodArt = TxtArticulo.Text
                        .Descripcion = "Precio de artículo"
                        .Exento = InfoArticulo.ExentoIV
                    End With

                    Forma.Execute()
                    If Forma.Acepto Then
                        If Forma.Monto < InfoArticulo.Costo Then
                            VerificaMensaje("El precio no  puede ser menor al costo")
                        End If
                        TxtPrecio.Text = Format(Forma.Monto, "##0.0000")
                        TxtCantidad.Focus()
                    End If
                    Forma = Nothing
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtDolares_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtDolares.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If InfoMaquina.InterfazFactura = Enum_InterfazFacturacion.CantidadAntes Then
                    If PanelDetalle.Enabled And TxtCantidadAntes.Enabled Then
                        TxtCantidadAntes.Focus()
                    Else
                        If TxtVendedor.Enabled Then
                            TxtVendedor.Focus()
                        End If
                    End If
                Else
                    If PanelDetalle.Enabled And TxtArticulo.Enabled Then
                        TxtArticulo.Focus()
                    Else
                        If TxtVendedor.Enabled Then
                            TxtVendedor.Focus()
                        End If
                    End If
                End If
            Case Keys.F2
                If TxtDolares.Text = "NO" Then
                    TxtDolares.Text = "SI"
                    LblTipoCambio.Visible = True
                    TxtTipoCambio.Visible = True
                    CalculaTotalDolares()
                    LblTotalDolares.Visible = LblTotalGrande.Visible
                Else
                    TxtDolares.Text = "NO"
                    LblTipoCambio.Visible = False
                    TxtTipoCambio.Visible = False
                    LblTotalDolares.Visible = False
                    LblTotalDolares.Text = "0.00"
                End If
        End Select
    End Sub

    Private Sub TxtDolares_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtDolares.TextChanged

    End Sub

    Private Sub TxtExento_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtExento.TextChanged

    End Sub

    Private Sub TxtTipoCambio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtTipoCambio.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If InfoMaquina.InterfazFactura = Enum_InterfazFacturacion.CantidadAntes Then
                    If PanelDetalle.Enabled And TxtCantidadAntes.Enabled Then
                        TxtCantidadAntes.Focus()
                    Else
                        If TxtVendedor.Enabled Then
                            TxtVendedor.Focus()
                        End If
                    End If
                Else
                    If PanelDetalle.Enabled And TxtArticulo.Enabled Then
                        TxtArticulo.Focus()
                    Else
                        If TxtVendedor.Enabled Then
                            TxtVendedor.Focus()
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Function ValidaComprometido() As Boolean
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim forma As New FrmExistenciaArticulosInfo
        Dim Articulo As TArticuloExistencia
        Dim Resultado As Boolean = False
        Dim ExistenciaTotal As Double = 0
        Try
            forma.ArticuloLista.Clear()

            With ArticuloBodega
                .Emp_Id = CajaInfo.Emp_Id
                .Suc_Id = CajaInfo.Suc_Id
                .Bod_Id = CajaInfo.Bod_Id
            End With

            For Each Fila As ListViewItem In LvwDetalle.Items

                If Not ArticuloServicio(Fila.SubItems(ColumnasDetalle.Articulo).Text.Trim) Then


                    ArticuloBodega.Art_Id = Fila.SubItems(ColumnasDetalle.Articulo).Text.Trim
                    VerificaMensaje(ArticuloBodega.ListKey())

                    If Not _Proforma Is Nothing Then
                        ExistenciaTotal = (ArticuloBodega.Saldo - ArticuloBodega.Comprometido) + CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text)
                    Else
                        ExistenciaTotal = ArticuloBodega.Saldo - ArticuloBodega.Comprometido
                    End If

                    If ExistenciaTotal < CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text) Then
                        Articulo = New TArticuloExistencia

                        With Articulo
                            .Art_Id = Fila.SubItems(ColumnasDetalle.Articulo).Text
                            .Nombre = Fila.SubItems(ColumnasDetalle.Nombre).Text
                            .Saldo = ArticuloBodega.Saldo
                            .Comprometido = ArticuloBodega.Comprometido
                            .Facturado = Fila.SubItems(ColumnasDetalle.Cantidad).Text
                            .Disponible = ArticuloBodega.Saldo - ArticuloBodega.Comprometido
                        End With

                        forma.ArticuloLista.Add(Articulo)
                    End If

                End If
            Next

            If forma.ArticuloLista.Count > 0 Then
                forma.Execute()

                Resultado = forma.Facturar
            Else
                Resultado = True
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
            Resultado = False
        Finally
            ArticuloBodega = Nothing
            Articulo = Nothing
            forma = Nothing
        End Try

        Return Resultado
    End Function


    Private Function ValidaExistenciaArticulos() As Boolean
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Forma As New FrmExistenciaArticulosInfo
        Dim Articulo As TArticuloExistencia
        Dim Resultado As Boolean = False
        Dim Disponible As Double = 0
        Dim PreFacturado As Double = 0
        Dim ExistenciaTotal As Double = 0
        Dim Sucursal As Integer = 0
        Dim Bodega As Integer = 0

        Try
            Forma.ArticuloLista.Clear()

            For Each Fila As ListViewItem In LvwDetalle.Items
                Disponible = 0
                PreFacturado = 0
                ExistenciaTotal = 0

                If Not ArticuloServicio(Fila.SubItems(ColumnasDetalle.Articulo).Text.Trim) Then
                    If Not _Proforma Is Nothing AndAlso _Proforma.Tipo = Enum_TipoFacturacion.ApartadoRetirado Then
                        'Si es un apartado busca la existencia del articulo en la bodega de apartados
                        Sucursal = SucursalParametroInfo.Suc_Id
                        Bodega = SucursalParametroInfo.BodegaApartado_Id
                    Else
                        'Busca la existencia del articulo en la bodega asignada a la caja
                        Sucursal = CajaInfo.Suc_Id
                        Bodega = CajaInfo.Bod_Id
                    End If

                    If Not _Proforma Is Nothing AndAlso _Proforma.Tipo <> Enum_TipoFacturacion.ApartadoRetirado Then
                        PreFacturado = GetPreFacturadoArticulo(_Proforma.Suc_Id, _Proforma.Documento_Id, Fila.SubItems(ColumnasDetalle.Articulo).Text.Trim)
                    End If

                    Disponible = GetDisponibleArticulo(Sucursal, Bodega, Fila.SubItems(ColumnasDetalle.Articulo).Text.Trim)
                    ExistenciaTotal = Disponible + PreFacturado

                    If ExistenciaTotal < CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text) Then
                        With ArticuloBodega
                            .Suc_Id = Sucursal
                            .Bod_Id = Bodega
                            .Art_Id = Fila.SubItems(ColumnasDetalle.Articulo).Text.Trim
                        End With
                        VerificaMensaje(ArticuloBodega.ListKey)

                        Articulo = New TArticuloExistencia

                        With Articulo
                            .Art_Id = Fila.SubItems(ColumnasDetalle.Articulo).Text
                            .Nombre = Fila.SubItems(ColumnasDetalle.Nombre).Text
                            .Saldo = ArticuloBodega.Saldo
                            .Comprometido = ArticuloBodega.Comprometido
                            .Facturado = CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text)
                            .Disponible = Disponible
                        End With

                        Forma.ArticuloLista.Add(Articulo)
                    End If
                End If
            Next

            If Forma.ArticuloLista.Count > 0 Then
                Forma.Execute()
                Resultado = Forma.Facturar
            Else
                Resultado = True
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
            Resultado = False
        Finally
            ArticuloBodega = Nothing
            Articulo = Nothing
            Forma = Nothing
        End Try

        Return Resultado
    End Function

    Private Sub RefrescaLeyendaFEPendiente()
        Try

            If CantidadFacturasPendientesDeEnvio() > 0 Then
                TSSLDocumentosPendientes.Text = "Existen documentos electrónicos pendientes de envío"
            Else
                TSSLDocumentosPendientes.Text = ""
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub RefrescaLeyendaCxCPendiente()
        Try

            If CantidadFacturasPendientesDeEnvioCxC() > 0 Then
                TSSLDocumentosPendientesCxC.Text = "Existen documentos de crédito pendientes de envío a CxC"
            Else
                TSSLDocumentosPendientesCxC.Text = ""
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TSSLDocumentosPendientes_Click(sender As Object, e As EventArgs) Handles TSSLDocumentosPendientes.Click
        Dim Forma As New FrmFacturaElectronicaPendiente
        Try

            Forma.Execute()

            If EmpresaParametroInfo.FacturacionElectronica Then
                RefrescaLeyendaFEPendiente()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub FrmPuntoVenta_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

    End Sub

    Private Sub TxtCantidadAntes_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCantidadAntes.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    If LvwDetalle.Items.Count > 0 Then
                        If LvwDetalle.SelectedItems.Count = 0 Then
                            LvwDetalle.Items(0).Selected = True
                        End If
                        LvwDetalle.Focus()
                    End If
                Case Keys.Enter
                    If TxtCantidadAntes.Text = "" Then
                        If LvwDetalle.Items.Count > 0 Then
                            FrmPuntoVenta_KeyDown(Me, New KeyEventArgs(Keys.F3))
                        End If
                    Else
                        If Not IsNumeric(TxtCantidadAntes.Text) OrElse CDbl(TxtCantidadAntes.Text) <= 0 Then
                            TxtCantidadAntes.SelectAll()
                            TxtCantidadAntes.Focus()
                            VerificaMensaje("La cantidad debe de ser mayor a cero")
                        Else
                            TxtArticulo.Focus()
                        End If
                    End If
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TSSLDocumentosPendientesCxC_Click(sender As Object, e As EventArgs) Handles TSSLDocumentosPendientesCxC.Click
        Dim Forma As New FrmCxCFacturaPendiente
        Try

            Forma.Execute()

            If EmpresaParametroInfo.InterfazCxC Then
                RefrescaLeyendaCxCPendiente()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub


End Class
