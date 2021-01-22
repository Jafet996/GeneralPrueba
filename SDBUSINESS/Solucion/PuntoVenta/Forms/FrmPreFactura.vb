Imports Business
Imports System.Threading
Public Class FrmPreFactura
#Region "Declaración de variables"
    Dim Numerico() As TNumericFormat
    Dim InfoArticulo As New TInfoArticulo(EmpresaInfo.Emp_Id)
    Private _ListaConjuntos As New List(Of TInfoArticuloConjunto)
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
            ReDim Numerico(6)

            Numerico(0) = New TNumericFormat(TxtTipoDocumento, 2, 0, False, "", "###0")
            Numerico(1) = New TNumericFormat(TxtCliente, 6, 0, False, "", "###0")
            Numerico(2) = New TNumericFormat(TxtVendedor, 4, 0, False, "", "###0")
            Numerico(3) = New TNumericFormat(TxtPrecio, 8, 2, False, "0")
            Numerico(4) = New TNumericFormat(TxtPorcDescLinea, 3, 2, False, "0")
            Numerico(5) = New TNumericFormat(TxtCantidad, 5, 4, False, "0")
            Numerico(6) = New TNumericFormat(TxtPorcDescGlobal, 3, 2, False, "0")

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
                .Columns(ColumnasDetalle.Nombre).Width = 500

                .Columns(ColumnasDetalle.Precio).Text = "Precio"
                .Columns(ColumnasDetalle.Precio).Width = 0
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
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub Inicializa()
        Try

            TxtTipoDocumento.Enabled = True
            TxtTipoDocumento.Text = ""
            TxtTipoDocumentoNombre.Text = ""
            TxtCliente.Text = ""
            TxtClienteNombre.Text = ""
            TxtVendedor.Text = ""
            TxtVendedorNombre.Text = ""
            TxtPorcDescGlobal.Text = "0.00"
            TxtExento.Text = "NO"
            PanelDetalle.Enabled = False

            LvwDetalle.Items.Clear()
            LblSubTotal.Text = "0.00"
            LblDescuento.Text = "0.00"
            LblImpuestoVenta.Text = "0.00"
            LblTotal.Text = "0.00"

            ActivarEdicionArticulo(False)
            InicializaArticulo()
            TxtArticulo.Text = ""
            InfoArticulo.ListaConjuntos.Clear()

            LblPorcDescGlobal.Visible = False
            TxtPorcDescGlobal.Visible = False
            LblExento.Visible = False
            TxtExento.Visible = False

            PicUltimoArticulo.Visible = False
            LblUltimoNombre.Visible = False
            LblUltimoPrecio.Visible = False
            LblUltimoNombre.Text = ""
            LblUltimoPrecio.Text = ""


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Public Sub Execute()
        Inicializa()
        Me.ShowDialog()
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
                Case Enum_TipoDocumento.DevolucionContado, Enum_TipoDocumento.DevolucionCredito
                    LblPorcDescGlobal.Visible = False
                    TxtPorcDescGlobal.Visible = False
                    LblExento.Visible = False
                    TxtExento.Visible = False
            End Select


            TxtTipoDocumentoNombre.Text = TipoDocumento.Nombre
            TxtTipoDocumento.Enabled = False

            Select Case CInt(TxtTipoDocumento.Text)
                Case Enum_TipoDocumento.Contado
                    If TxtCliente.Text.Trim = "" And TipoDocumento.Cliente_Id > 0 Then
                        TxtCliente.Text = TipoDocumento.Cliente_Id
                    End If
                    ValidaCliente(True)
                    ValidaVendedor(True)
                Case Else
                    TxtCliente.Focus()
            End Select


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

    Private Sub TxtTipoDocumento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTipoDocumento.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If TxtTipoDocumento.Text.Trim = "" Then
                    TxtTipoDocumento.Text = Enum_TipoDocumento.Contado
                End If
                ValidaTipoDocumento()
        End Select
    End Sub

    Private Sub TxtTipoDocumento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTipoDocumento.TextChanged
        TxtTipoDocumentoNombre.Text = ""
    End Sub
    Private Function ValidaCliente(ByVal pRefrescarDatos As Boolean) As Boolean
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            If Not IsNumeric(TxtCliente.Text.Trim) Then
                VerificaMensaje("Debe de digitar un valor válido")
                EnfocarTexto(TxtCliente)
            End If

            Cliente.Cliente_Id = TxtCliente.Text.Trim
            Mensaje = Cliente.ListKey
            VerificaMensaje(Mensaje)

            If Cliente.RowsAffected = 0 Then
                VerificaMensaje("Código de cliente no válido")
                EnfocarTexto(TxtCliente)
            End If

            If Not Cliente.Activo Then
                VerificaMensaje("El cliente se encuentra inactivo")
                EnfocarTexto(TxtCliente)
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
        End Try
    End Function
    Private Sub TxtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCliente.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If TxtCliente.Text.Trim <> "" Then
                    ValidaCliente(True)
                End If
            Case Keys.F2
                Dim Forma As New FrmCambioNombre
                Forma.Nombre = TxtClienteNombre.Text.Trim
                Forma.Execute()
                If Forma.Acepto Then
                    TxtClienteNombre.Text = Forma.Nombre
                End If
                Forma = Nothing
                If PanelDetalle.Enabled And TxtArticulo.Enabled Then
                    TxtArticulo.Focus()
                Else
                    If TxtVendedor.Enabled Then
                        TxtVendedor.Focus()
                    End If
                End If

        End Select
    End Sub

    Private Sub TxtCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCliente.TextChanged
        TxtClienteNombre.Text = ""
        TxtPorcDescGlobal.Text = ""
    End Sub

    Private Sub TxtVendedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVendedor.GotFocus
        If TxtVendedor.Text.Trim = "" Then
            TxtVendedor.Text = UsuarioInfo.Vendedor_Id
        End If
    End Sub
    Private Function ValidaVendedor(ByVal pRefrescarDatos As Boolean) As Boolean
        Dim Vendedor As New TVendedor(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            If Not IsNumeric(TxtVendedor.Text.Trim) Then
                VerificaMensaje("Debe de digitar un valor válido")
                EnfocarTexto(TxtVendedor)
            End If

            Vendedor.Vendedor_Id = TxtVendedor.Text.Trim
            Mensaje = Vendedor.ListKey
            VerificaMensaje(Mensaje)

            If Vendedor.RowsAffected = 0 Then
                VerificaMensaje("Código de vendedor no válido")
                EnfocarTexto(TxtVendedor)
            End If

            If Not Vendedor.Activo Then
                VerificaMensaje("El vendedor se encuentra inactivo")
                EnfocarTexto(TxtVendedor)
            End If

            If pRefrescarDatos Then
                TxtVendedorNombre.Text = Vendedor.Nombre
                PanelDetalle.Enabled = True
                TxtArticulo.Focus()
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
        Dim Mensaje As String = ""
        Try

            Cliente.Cliente_Id = CInt(TxtCliente.Text)
            Mensaje = Cliente.ListKey()
            VerificaMensaje(Mensaje)

            If Cliente.RowsAffected = 0 Then
                VerificaMensaje("El código de cliente no es válido")
            End If

            If (Cliente.Saldo + pTotalFactura) > Cliente.LimiteCredito Then
                If MsgBox("El cliente supera el límite de crédito asignado : " & Format(Cliente.LimiteCredito, "#,##0.00") & " Desea facturar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                    If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PvFacturaSobreLimiteCredito, False) Then
                        VerificaMensaje("No tiene permiso para exceder el límite de crédito")
                    End If
                Else
                    VerificaMensaje("El cliente supera el límite de crédito")
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


    Private Function ValidaTodo() As String
        Try
            If Not ValidaCliente(False) Then
                TxtCliente.SelectAll()
                TxtCliente.Focus()
                VerificaMensaje("No se puede guardar el documento, primero debe de ingresar un codigo de cliente válido")
            Else
                If CInt(TxtTipoDocumento.Text) = Enum_TipoDocumento.Credito Then
                    If Not ValidaSaldoCliente(RedondeaMontoCobro(CDbl(LblTotal.Text))) Then
                        TxtArticulo.Focus()
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

            Return ""
        Catch ex As Exception
            Return ex.Message
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

    Private Sub TxtVendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtVendedor.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If TxtVendedor.Text.Trim <> "" Then
                    ValidaVendedor(True)
                End If
        End Select
    End Sub

    Private Sub TxtVendedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtVendedor.TextChanged
        TxtVendedorNombre.Text = ""
    End Sub

    Private Sub ActivarEdicionArticulo(ByVal pActivar)
        TxtArticulo.Enabled = (Not pActivar)
        TxtArticuloNombre.Enabled = pActivar
        TxtUnidadMedida.Enabled = pActivar
        TxtPrecio.Enabled = pActivar
        TxtPorcDescLinea.Enabled = pActivar
        TxtCantidad.Enabled = pActivar
    End Sub

    Private Function ValidaArticulo(ByVal pArt_Id As String, ByVal pModificando As Boolean) As Boolean
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Dim ArtTmp As String = ""
        Dim EnteroStr As String = ""
        Dim DecimalStr As String = ""
        Dim Cantidad As Double = 1
        Try

            pArt_Id = QuitaComillas(pArt_Id)

            InfoArticulo.LimpiaArticulo()

            If Not pModificando AndAlso pArt_Id.Length > 6 Then
                'Veririca si es un codigo que trae la cantidad en la etiqueta
                Articulo.Art_Id = Mid(pArt_Id, 1, 6)
                Mensaje = Articulo.ArticuloEtiquetado()
                VerificaMensaje(Mensaje)

                If Articulo.Existe Then
                    Select Case Articulo.CodigoCantidadTipo
                        Case TipoCantidadEtiqueta.Peso
                            ArtTmp = CopyAndCut(pArt_Id, 6)
                            EnteroStr = CopyAndCut(pArt_Id, 2)
                            DecimalStr = pArt_Id
                            'Asigna los nuevos valores
                            pArt_Id = ArtTmp
                            Cantidad = CDbl(EnteroStr & "." & DecimalStr)
                        Case TipoCantidadEtiqueta.Unidad
                            ArtTmp = CopyAndCut(pArt_Id, 6)
                            EnteroStr = Mid(pArt_Id, 4, 2)
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
            Mensaje = InfoArticulo.ConsultaArticulo
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


            If InfoArticulo.Conjunto And Not pModificando Then
                Mensaje = InfoArticulo.CargaListaConjuntos()
                VerificaMensaje(Mensaje)
            End If


            TxtArticuloNombre.Text = InfoArticulo.Nombre
            TxtUnidadMedida.Text = InfoArticulo.UnidadMedidaNombre
            TxtPrecio.Text = Format(InfoArticulo.Precio, "##0.00")
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
        End Try
    End Function

    Private Sub InicializaArticulo()
        ActivarEdicionArticulo(False)
        LvwDetalle.Tag = Nothing
        InfoArticulo.LimpiaArticulo()
        TxtArticuloNombre.Text = ""
        TxtUnidadMedida.Text = ""
        TxtPrecio.Text = ""
        TxtPrecio.ReadOnly = True
        TxtPorcDescLinea.Text = ""
        TxtCantidad.Text = ""
    End Sub

    Private Sub CargaArticulosConjuntos()
        Dim Mensaje As String = ""
        Try

            If InfoArticulo.ListaConjuntos.Count = 0 Then
                Exit Sub
            End If

            For Each InfoArticuloConjunto As TInfoArticuloConjunto In InfoArticulo.ListaConjuntos

                InfoArticulo.LimpiaArticulo()

                InfoArticulo.Art_Id = InfoArticuloConjunto.ArtConjunto_Id
                Mensaje = InfoArticulo.ConsultaArticulo()

                If InfoArticulo.RowsAffected = 0 Then
                    MensajeError("Artículo conjunto inválido, no se encontraron datos")
                End If

                If InfoArticulo.Data.Tables(0) Is Nothing Then
                    MensajeError("Artículo conjunto inválido, no se encontraron datos")
                End If

                Mensaje = InfoArticulo.CargaRegistroArticulo(InfoArticulo.Data.Tables(0).Rows(0))
                VerificaMensaje(Mensaje)

                If Not InfoArticulo.PermiteFacturar Then
                    MensajeError("Artículo conjunto : " & InfoArticulo.Art_Id & " - " & InfoArticulo.Nombre & " no está disponible para la venta")
                End If

                TxtArticuloNombre.Text = InfoArticulo.Nombre
                TxtUnidadMedida.Text = InfoArticulo.UnidadMedidaNombre
                TxtPrecio.Text = Format(InfoArticulo.Precio, "##0.00")
                TxtPorcDescLinea.Text = Format(InfoArticulo.PorcDescuento, "##0.00")
                TxtCantidad.Text = InfoArticuloConjunto.Cantidad


                IngresaArticulo(True)

            Next

            InfoArticulo.ListaConjuntos.Clear()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BusquedaArticulo()
        Dim Forma As New FrmBusquedaArticuloOnLine
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

    Private Sub BusquedaCliente()
        Dim Forma As New FrmBusquedaCliente
        Try

            Forma.Execute()

            If Forma.Selecciono Then
                TxtCliente.Text = Forma.Cliente_Id
                ValidaCliente(True)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub TxtArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtArticulo.KeyDown
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

    Private Sub TxtArticulo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtArticulo.TextChanged
        InicializaArticulo()
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

    Private Sub CreaArticulo()
        Dim Forma As New FrmCreaArticulo
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
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

    Private Sub FrmPuntoVenta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If LvwDetalle.Items.Count > 0 Then
            MsgBox("Imposible cerrar la pantalla, hay líneas pendientes de procesar", MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmPuntoVenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
                    If Not TxtTipoDocumento.Enabled Then
                        If PanelDetalle.Enabled Then
                            Mensaje = ValidaTodo()
                            If Mensaje.Trim = "" Then
                                If SolicitaNombreCliente() Then
                                    GuardarDocumento()
                                End If
                            Else
                                MsgBox(Mensaje, MsgBoxStyle.Information, Me.Text)
                            End If
                        Else
                            MsgBox("Para poder facturar, primero debe de ingresar al menos un producto", MsgBoxStyle.Information, Me.Text)
                        End If
                    Else
                        MsgBox("Debe de seleccionar un tipo de documento", MsgBoxStyle.Information, Me.Text)
                    End If

                    'If LvwDetalle.Items.Count > 0 Then
                    '    GuardarDocumento()
                    'Else
                    '    If PanelDetalle.Enabled Then
                    '        MsgBox("Debe de ingresar algún producto", MsgBoxStyle.Information, Me.Text)
                    '    End If
                    'End If
                Case Keys.F4
                    ConsultarArticulo()
                Case Keys.F5
                    CreaArticulo()
                Case Keys.F6 And Me.ActiveControl.Name = "TxtArticulo"
                    BusquedaRapida()
                Case Keys.F12
                    If LvwDetalle.Items.Count > 0 Then
                        If MsgBox("Desea cancelar el documento actual?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) <> MsgBoxResult.Yes Then
                            Exit Sub
                        End If
                    End If
                    Inicializa()
                    TxtTipoDocumento.Focus()
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmPuntoVenta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FormateaCamposNumericos()
        ConfiguraDetalle()
        With InfoArticulo
            .Emp_Id = CajaInfo.Emp_Id
            .Suc_Id = CajaInfo.Suc_Id
            .Bod_Id = CajaInfo.Bod_Id
        End With
    End Sub

    Private Function BuscaItemArticulo(ByVal pArt_Id As String) As ListViewItem
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
    Private Sub RecalculaDescuento(ByVal pPorcentaje As Double)
        Dim Item As ListViewItem = Nothing
        Try
            For Each Linea As ListViewItem In LvwDetalle.Items

                With Linea
                    .SubItems(ColumnasDetalle.PorcDescuento).Text = Format(pPorcentaje, "##0.0000")
                    .SubItems(ColumnasDetalle.MontoDescuento).Text = Format(CDbl(.SubItems(ColumnasDetalle.Precio).Text) * (CDbl(.SubItems(ColumnasDetalle.PorcDescuento).Text) / 100), "##0.0000")

                    If Not .SubItems(ColumnasDetalle.Exento).Text Then
                        .SubItems(ColumnasDetalle.MontoIV).Text = Format((CDbl(.SubItems(ColumnasDetalle.Precio).Text) - CDbl(.SubItems(ColumnasDetalle.MontoDescuento).Text)) * (EmpresaParametroInfo.PorcIV / 100), "##0.0000")
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
                            .SubItems(ColumnasDetalle.MontoIV).Text = Format((CDbl(.SubItems(ColumnasDetalle.Precio).Text) - CDbl(.SubItems(ColumnasDetalle.MontoDescuento).Text)) * (EmpresaParametroInfo.PorcIV / 100), "##0.0000")
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
    Private Sub IngresaArticulo(ByVal pArtConjunto As Boolean)
        Dim Item As ListViewItem
        Dim Items(14) As String
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
                    .SubItems(ColumnasDetalle.Cantidad).Text = Format(CDbl(.SubItems(ColumnasDetalle.Cantidad).Text) + CDbl(TxtCantidad.Text), "##0.0000")
                Else
                    .SubItems(ColumnasDetalle.Cantidad).Text = Format(CDbl(TxtCantidad.Text), "##0.0000")
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
                        .SubItems(ColumnasDetalle.MontoIV).Text = Format((InfoArticulo.Precio - CDbl(.SubItems(ColumnasDetalle.MontoDescuento).Text)) * (EmpresaParametroInfo.PorcIV / 100), "##0.0000")
                    End If
                Else
                    .SubItems(ColumnasDetalle.MontoIV).Text = "0.00"
                End If
                .SubItems(ColumnasDetalle.Saldo).Text = InfoArticulo.Saldo
                .SubItems(ColumnasDetalle.Costo).Text = InfoArticulo.Costo
                .SubItems(ColumnasDetalle.TotalLinea).Text = Format(((CDbl(.SubItems(ColumnasDetalle.Precio).Text) - CDbl(.SubItems(ColumnasDetalle.MontoDescuento).Text)) + CDbl(.SubItems(ColumnasDetalle.MontoIV).Text)) * CDbl(.SubItems(ColumnasDetalle.Cantidad).Text), "##0.0000")
            End With

            If Accion = AccionDetalle.Nuevo Then
                LvwDetalle.Items.Add(Item)
                Item.EnsureVisible()
            End If

            'Marca la ultima linea modificada o ingresada
            LvwDetalle.SelectedItems.Clear()
            Item.Selected = True

            MuestraInfoUltimoArticulo(Item.SubItems(ColumnasDetalle.Nombre).Text, CDbl(Item.SubItems(ColumnasDetalle.TotalLinea).Text))

            TxtArticulo.Text = ""
            InicializaArticulo()
            TxtArticulo.Focus()

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
                TxtPrecio.Text = "0.00"
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


            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub TxtCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCantidad.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If ValidaDescuento() And ValidaCantidad() And ValidaPrecio() Then
                    IngresaArticulo(False)
                End If
            Case Keys.Escape
                InicializaArticulo()
                TxtArticulo.Text = ""
                TxtArticulo.Focus()
        End Select
    End Sub

    Private Sub LvwDetalle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvwDetalle.DoubleClick
        If Not LvwDetalle.SelectedItems Is Nothing And LvwDetalle.SelectedItems.Count > 0 Then
            ModificaLinea()
        End If

    End Sub
    Private Sub LvwDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LvwDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                ModificaLinea()
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

            If MsgBox("Desea eliminar la línea del detalle", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar líneas") <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            If LvwDetalle.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar una línea")
            End If

            If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PvEliminaLineaFactura, False) Then
                VerificaMensaje("No tiene permiso para Eliminar líneas")
            End If

            InicializaArticulo()
            LvwDetalle.Tag = Nothing
            InfoArticulo.ListaConjuntos.Clear()

            LvwDetalle.Items.Remove(LvwDetalle.SelectedItems(0))


            MuestraTotales()

            TxtArticulo.Focus()


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ModificaLinea()
        Try
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

    Private Sub TxtPorcDescLinea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPorcDescLinea.KeyDown
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

    Private Sub MuestraInfoUltimoArticulo(ByVal pNombre As String, ByVal pPrecio As Double)
        Try

            If Not PicUltimoArticulo.Visible Then
                PicUltimoArticulo.Visible = True
                LblUltimoNombre.Visible = True
                LblUltimoPrecio.Visible = True
            End If

            LblUltimoNombre.Text = Mid(pNombre, 1, 40).ToUpper
            LblUltimoPrecio.Text = Format(pPrecio, "#,##0.00")

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

            CalculaTotales(Costo, SubTotal, Descuento, IV, Total, TotalExento, TotalGravado)

            LblSubTotal.Text = Format(SubTotal, "##0.00")
            LblDescuento.Text = Format(Descuento, "##0.00")
            LblImpuestoVenta.Text = Format(IV, "##0.00")
            LblTotal.Text = Format(Total, "##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub GuardarDocumento()
        Dim FacturaEncabezado As New TPreFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim FormaVuelto As New FrmVuelto
        Dim FacturaDetalles As New List(Of TPreFacturaDetalle)
        Dim FacturaDetalle As TPreFacturaDetalle = Nothing
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
        Dim TotalExento As Double = 0
        Dim TotalGravado As Double = 0
        Try

            'Refresca los valores de la caja
            VerificaMensaje(CajaInfo.ListKey)

            TipoDoc_Id = Val(TxtTipoDocumento.Text)

            'Busca la fecha de la BD
            Fecha = EmpresaInfo.Getdate()

            CalculaTotales(Costo, SubTotal, Descuento, IV, Total, TotalExento, TotalGravado)

            TotalCobrado = RedondeaMontoCobro(Total)
            Redondeo = TotalCobrado - Total


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
                .Costo = Costo
                .Subtotal = SubTotal
                .Descuento = Descuento
                .IV = IV
                .Total = Total
                .Redondeo = Redondeo
                .TotalCobrado = TotalCobrado
                .Cierre_Id = CajaInfo.Cierre_Id
                .CPU = InfoGeneral.CPU
                .IPAddress = InfoGeneral.IPAddress
                .HostName = InfoGeneral.HostName
                .TipoDocumentoNombre = TxtTipoDocumentoNombre.Text
                .FacturaDetalles = FacturaDetalles
                .UsuarioNombre = UsuarioInfo.Nombre
                .Exento = TotalExento
                .Gravado = TotalGravado
            End With



            'Carga datos del detalle de la factura
            Detalle_Id = 0
            For Each Fila As ListViewItem In LvwDetalle.Items
                FacturaDetalle = New TPreFacturaDetalle(EmpresaInfo.Emp_Id)
                Detalle_Id += 1
                With FacturaDetalle
                    .Suc_Id = CajaInfo.Suc_Id
                    .Caja_Id = CajaInfo.Caja_Id
                    .TipoDoc_Id = TipoDoc_Id
                    .Documento_Id = FacturaEncabezado.Documento_Id
                    .Detalle_Id = Detalle_Id
                    .Art_Id = Fila.SubItems(ColumnasDetalle.Articulo).Text
                    .Cantidad = CDbl(Fila.SubItems(ColumnasDetalle.Cantidad).Text) 
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
                End With
                FacturaDetalles.Add(FacturaDetalle)
            Next

            'Agrega listas al encabezado de la factura
            With FacturaEncabezado
                .FacturaDetalles = FacturaDetalles
            End With


            Mensaje = FacturaEncabezado.GuardarDocumento()
            VerificaMensaje(Mensaje)


            FormaVuelto.Execute("Monto :", Math.Abs(TotalCobrado))

            Inicializa()
            TxtTipoDocumento.Focus()

            TxtTipoDocumento_KeyDown(Me.TxtTipoDocumento, New KeyEventArgs(Keys.Enter))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FacturaEncabezado = Nothing
            FormaVuelto = Nothing
            FacturaDetalles = Nothing
            FacturaDetalle = Nothing
        End Try
    End Sub

    Private Function VerificaSaldoFactura(ByVal pTipoMov_Id As Integer, ByVal pMov_Id As Long, ByVal pMonto As Double) As String
        Dim CxCMovimiento As New TCxCMovimiento(CajaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            With CxCMovimiento
                .TipoMov_Id = pTipoMov_Id
                .Mov_Id = pMov_Id
            End With

            Mensaje = CxCMovimiento.ListKey
            VerificaMensaje(Mensaje)

            If CxCMovimiento.Saldo < pMonto Then
                VerificaMensaje("No se puede aplicar la nota de crédito, debido a que el monto es mayor a la factura")
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            CxCMovimiento = Nothing
        End Try
    End Function

    Private Sub TxtPorcDescGlobal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPorcDescGlobal.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    If PanelDetalle.Enabled And TxtArticulo.Enabled Then
                        TxtArticulo.Focus()
                    Else
                        If TxtVendedor.Enabled Then
                            TxtVendedor.Focus()
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
                        If PanelDetalle.Enabled And TxtArticulo.Enabled Then
                            TxtArticulo.Focus()
                        Else
                            If TxtVendedor.Enabled Then
                                TxtVendedor.Focus()
                            End If
                        End If
                    End If
                    Forma = Nothing
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub TxtExento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtExento.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If PanelDetalle.Enabled And TxtArticulo.Enabled Then
                    TxtArticulo.Focus()
                Else
                    If TxtVendedor.Enabled Then
                        TxtVendedor.Focus()
                    End If
                End If
            Case Keys.F2
                If TxtExento.Text = "NO" Then
                    TxtExento.Text = "SI"
                Else
                    TxtExento.Text = "NO"
                End If
                RecalculaImpuesto()
                If PanelDetalle.Enabled And TxtArticulo.Enabled Then
                    TxtArticulo.Focus()
                Else
                    If TxtVendedor.Enabled Then
                        TxtVendedor.Focus()
                    End If
                End If
        End Select
    End Sub

    Private Sub TSLF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSLF3.Click
        FrmPuntoVenta_KeyDown(Nothing, New KeyEventArgs(Keys.F3))
    End Sub
    Private Function SolicitaNombreCliente() As Boolean
        Dim Forma As New FrmCambioNombre
        Try

            Forma.Nombre = TxtClienteNombre.Text.Trim
            Forma.Execute()
            If Forma.Acepto Then
                TxtClienteNombre.Text = Forma.Nombre.ToUpper
            Else
                VerificaMensaje("Debe de ingresar el nombre del cliente")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        Finally
            Forma = Nothing
        End Try
    End Function

    Private Sub TxtPrecio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPrecio.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If ValidaPrecio() Then
                    TxtPorcDescLinea.Focus()
                End If
            Case Keys.Escape
                InicializaArticulo()
                TxtArticulo.Text = ""
                TxtArticulo.Focus()
        End Select
    End Sub
End Class
