Imports Business
Public Class FrmConsultaCliente
#Region "Enum"
    Private Enum ColumnasDocumentos
        SucursalNombre = 0
        TipoNombre = 1
        Documento = 2
        Fecha = 3
        Total = 4
        Comentario = 5
        Emp_Id = 6
        Suc_Id = 7
        Caja_Id = 8
        TipoDoc_Id = 9
        Documento_Id = 10
        Tipo = 11
        Puntos = 12
    End Enum
    Private Enum ColumnasDetalle
        Linea = 0
        Articulo = 1
        Cantidad = 2
        Descripcion = 3
        Total = 4
        Comentario = 5
    End Enum
    Private Enum ColumnasAnotaciones
        Id = 0
        Anotacion = 1
        Fecha = 2
        Usuario = 3
    End Enum

    Private Enum ColumnasEncargos
        Id = 0
        Codigo = 1
        Descripcion = 2
        Notificado = 3
        Facturado = 4
    End Enum
    Private Enum ColumnasBitacora
        Fecha = 0
        Usuario = 1
        Maquina = 2
    End Enum
#End Region
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private _Cliente_Id As Integer = 0
    Private _ClienteNuevo As Integer = 0
    Private _GuardoCambios As Boolean = False
#End Region
#Region "Propiedades"
    Public Property Cliente_Id As Integer
        Get
            Return _Cliente_Id
        End Get
        Set(value As Integer)
            _Cliente_Id = value
        End Set
    End Property
    Public ReadOnly Property ClienteNuevo As Integer
        Get
            Return _ClienteNuevo
        End Get
    End Property
    Public ReadOnly Property GuardoCambios As Boolean
        Get
            Return _GuardoCambios
        End Get
    End Property
#End Region
#Region "Formateo de Campos"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtNumero, 8, 0, False, "", "###0")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub ConfiguraDetalle()
        Try
            With LvwDocumentos
                .Columns(ColumnasDocumentos.SucursalNombre).Text = "Sucursal"
                .Columns(ColumnasDocumentos.SucursalNombre).Width = 130

                .Columns(ColumnasDocumentos.TipoNombre).Text = "Tipo"
                .Columns(ColumnasDocumentos.TipoNombre).Width = 100

                .Columns(ColumnasDocumentos.Documento).Text = "Documento"
                .Columns(ColumnasDocumentos.Documento).Width = 67

                .Columns(ColumnasDocumentos.Fecha).Text = "Fecha"
                .Columns(ColumnasDocumentos.Fecha).Width = 100

                .Columns(ColumnasDocumentos.Total).Text = "Total"
                .Columns(ColumnasDocumentos.Total).Width = 100
                .Columns(ColumnasDocumentos.Total).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDocumentos.Comentario).Text = "Comentario"
                .Columns(ColumnasDocumentos.Comentario).Width = 0

                .Columns(ColumnasDocumentos.Emp_Id).Text = "Emp_Id"
                .Columns(ColumnasDocumentos.Emp_Id).Width = 0

                .Columns(ColumnasDocumentos.Suc_Id).Text = "Suc_Id"
                .Columns(ColumnasDocumentos.Suc_Id).Width = 0

                .Columns(ColumnasDocumentos.Caja_Id).Text = "Caja_Id"
                .Columns(ColumnasDocumentos.Caja_Id).Width = 0

                .Columns(ColumnasDocumentos.TipoDoc_Id).Text = "TipoDoc_Id"
                .Columns(ColumnasDocumentos.TipoDoc_Id).Width = 0

                .Columns(ColumnasDocumentos.Documento_Id).Text = "Documento_Id"
                .Columns(ColumnasDocumentos.Documento_Id).Width = 0

                .Columns(ColumnasDocumentos.Tipo).Text = "Tipo"
                .Columns(ColumnasDocumentos.Tipo).Width = 0

                .Columns(ColumnasDocumentos.Puntos).Text = "Puntos"
                .Columns(ColumnasDocumentos.Puntos).Width = 80
                .Columns(ColumnasDocumentos.Puntos).TextAlign = HorizontalAlignment.Right
            End With

            With LvwDetalle
                .Columns(ColumnasDetalle.Linea).Text = "Línea"
                .Columns(ColumnasDetalle.Linea).Width = 44

                .Columns(ColumnasDetalle.Articulo).Text = "Artículo"
                .Columns(ColumnasDetalle.Articulo).Width = 90

                .Columns(ColumnasDetalle.Cantidad).Text = "Cantidad"
                .Columns(ColumnasDetalle.Cantidad).Width = 69

                .Columns(ColumnasDetalle.Descripcion).Text = "Descripcion"
                .Columns(ColumnasDetalle.Descripcion).Width = 269

                .Columns(ColumnasDetalle.Total).Text = "Total"
                .Columns(ColumnasDetalle.Total).Width = 112

                .Columns(ColumnasDetalle.Comentario).Text = "Comentario"
                .Columns(ColumnasDetalle.Comentario).Width = 0
            End With

            With LvwAnotaciones
                .Columns(ColumnasAnotaciones.Id).Text = "Id"
                .Columns(ColumnasAnotaciones.Id).Width = 38

                .Columns(ColumnasAnotaciones.Anotacion).Text = "Anotación"
                .Columns(ColumnasAnotaciones.Anotacion).Width = 340

                .Columns(ColumnasAnotaciones.Fecha).Text = "Fecha"
                .Columns(ColumnasAnotaciones.Fecha).Width = 76

                .Columns(ColumnasAnotaciones.Usuario).Text = "Hecho Por"
                .Columns(ColumnasAnotaciones.Usuario).Width = 75
            End With


            With LvwEncargos
                .Columns(ColumnasEncargos.Id).Text = "Id"
                .Columns(ColumnasEncargos.Id).Width = 0

                .Columns(ColumnasEncargos.Codigo).Text = "Código"
                .Columns(ColumnasEncargos.Codigo).Width = 92

                .Columns(ColumnasEncargos.Descripcion).Text = "Descripción"
                .Columns(ColumnasEncargos.Descripcion).Width = 232

                .Columns(ColumnasEncargos.Notificado).Text = "Notificado"
                .Columns(ColumnasEncargos.Notificado).Width = 61
                .Columns(ColumnasEncargos.Notificado).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasEncargos.Facturado).Text = "Facturado"
                .Columns(ColumnasEncargos.Facturado).Width = 61
                .Columns(ColumnasEncargos.Notificado).TextAlign = HorizontalAlignment.Center
            End With


            With LvwBitacora
                .Columns(ColumnasBitacora.Fecha).Text = "Fecha"
                .Columns(ColumnasBitacora.Fecha).Width = 122

                .Columns(ColumnasBitacora.Usuario).Text = "Usuario"
                .Columns(ColumnasBitacora.Usuario).Width = 167

                .Columns(ColumnasBitacora.Maquina).Text = "Máquina"
                .Columns(ColumnasBitacora.Maquina).Width = 102
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute()
        If _Cliente_Id > 0 AndAlso _Cliente_Id <> InfoMaquina.ClienteDefault Then
            TxtNumero.Text = _Cliente_Id
            CargaDatos()
            BtnHistorial.Enabled = False
        End If

        Me.ShowDialog()
    End Sub

    Private Sub CargaDatos()
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)

        Try
            Cliente.Cliente_Id = CInt(TxtNumero.Text.Trim)
            VerificaMensaje(Cliente.ListKey)

            BtnLimpiar.Enabled = True
            BtnImprime.Enabled = True
            BtnPreFactura.Enabled = True
            TxtNumero.Enabled = False
            BtnAnotacionAgregar.Enabled = True

            With Cliente
                TxtNombre.Text = .Nombre
                TxtTelefono1.Text = .Telefono1
                TxtTelefono2.Text = .Telefono2
                TxtApartado.Text = .Apartado
                TxtEmail.Text = .Email
                TxtDireccion.Text = .Direccion
                TxtFacturaCredito.Text = IIf(.FacturaCredito, "SI", "NO")
                TxtPorcDescContado.Text = Format(.PorcDescContado, "#,##0.00")
                TxtPorcDescCredito.Text = Format(.PorcDescCredito, "#,##0.00")
                TxtActivo.Text = IIf(.Activo, "SI", "NO")
                TxtPrecio.Text = .PrecioNombre
                TxtPuntosAcumulados.Text = Format(.PuntosAcumulados, "#,##0")
                TxtPuntosCanjeados.Text = Format(.PuntosCanjeados, "#,##0")
                TxtPuntosVencidos.Text = Format(.PuntosVencidos, "#,##0")
                TxtPuntosDisponibles.Text = Format(.PuntosAcumulados - .PuntosCanjeados, "#,##0")
                TxtUltimaCompra.Text = Format(.FechaUltimaCompra, "dd/MM/yyyy")

                CargaListaMovimientos(Cliente.Cliente_Id)
                CargaListaAnotaciones(Cliente.Cliente_Id)
                CargaListaEncargos(Cliente.Cliente_Id)
            End With
            BtnHistorial.Enabled = True
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
        End Try
    End Sub

    Private Sub CargaListaMovimientos(pCliente As Integer)
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim Items(12) As String
        Dim Item As ListViewItem = Nothing

        Try
            LvwDocumentos.Items.Clear()

            Cliente.Cliente_Id = pCliente
            VerificaMensaje(Cliente.ConsultaMovimientosCliente)

            For Each Fila As DataRow In Cliente.Data.Tables(0).Rows
                Items(ColumnasDocumentos.SucursalNombre) = Fila("SucNombre")
                Items(ColumnasDocumentos.TipoNombre) = Fila("TipoDocNombre")
                Items(ColumnasDocumentos.Documento) = Fila("Documento")
                Items(ColumnasDocumentos.Fecha) = Format(Fila("Fecha"), "dd/MM/yyyy HH:mm")
                Items(ColumnasDocumentos.Total) = Fila("TotalCobrado")
                Items(ColumnasDocumentos.Comentario) = Fila("Comentario")
                Items(ColumnasDocumentos.Emp_Id) = Fila("Emp_Id")
                Items(ColumnasDocumentos.Suc_Id) = Fila("Suc_Id")
                Items(ColumnasDocumentos.Caja_Id) = Fila("Caja_Id")
                Items(ColumnasDocumentos.TipoDoc_Id) = Fila("TipoDoc_Id")
                Items(ColumnasDocumentos.Documento_Id) = Fila("Documento_Id")
                Items(ColumnasDocumentos.Tipo) = Fila("Tipo")
                Items(ColumnasDocumentos.Puntos) = Fila("Puntos")

                Item = New ListViewItem(Items)
                LvwDocumentos.Items.Add(Item)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
        End Try
    End Sub

    Private Sub CargaListaEncargos(pCliente As Integer)
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim Items(4) As String
        Dim Item As ListViewItem = Nothing
        Try

            LvwEncargos.Items.Clear()

            Cliente.Cliente_Id = pCliente
            VerificaMensaje(Cliente.ConsultaEncargosCliente())

            For Each Fila As DataRow In Cliente.Data.Tables(0).Rows
                Items(ColumnasEncargos.Id) = Fila("Encargo_Id")
                Items(ColumnasEncargos.Codigo) = Fila("Art_Id")
                Items(ColumnasEncargos.Descripcion) = Fila("Nombre")
                Items(ColumnasEncargos.Notificado) = IIf(Fila("Notificacion"), "SI", "NO")
                Items(ColumnasEncargos.Facturado) = IIf(Fila("Facturado"), "SI", "NO")

                Item = New ListViewItem(Items)
                LvwEncargos.Items.Add(Item)
            Next

            If LvwEncargos.Items.Count > 0 Then
                LvwEncargos.Items(LvwEncargos.Items.Count - 1).EnsureVisible()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
        End Try
    End Sub



    Private Sub CargaListaAnotaciones(pCliente As Integer)
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim Items(3) As String
        Dim Item As ListViewItem = Nothing

        Try
            LvwAnotaciones.Items.Clear()
            BtnAnotacionEliminar.Enabled = False

            Cliente.Cliente_Id = pCliente
            VerificaMensaje(Cliente.ConsultaAnotacionesCliente)

            For Each Fila As DataRow In Cliente.Data.Tables(0).Rows
                Items(ColumnasAnotaciones.Id) = Fila("Anotacion_Id")
                Items(ColumnasAnotaciones.Anotacion) = Fila("Anotacion")
                Items(ColumnasAnotaciones.Fecha) = Format(Fila("Fecha"), "dd/MM/yyyy")
                Items(ColumnasAnotaciones.Usuario) = Fila("Usuario_Id")

                Item = New ListViewItem(Items)
                LvwAnotaciones.Items.Add(Item)
            Next

            BtnAnotacionEliminar.Enabled = LvwAnotaciones.Items.Count > 0

            If LvwAnotaciones.Items.Count > 0 Then
                LvwAnotaciones.Items(LvwAnotaciones.Items.Count - 1).EnsureVisible()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
        End Try
    End Sub

    Private Sub CargaBitacora(pEmp_Id As Integer, pSuc_Id As Integer, pCaja_Id As Integer, pTipoDoc_Id As Integer, pDocumento_Id As Long, pTipo As Enum_TipoFacturacion)
        Dim FacturaEncabezado As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim Items(2) As String
        Dim Item As ListViewItem = Nothing

        Try
            LvwBitacora.Items.Clear()

            With FacturaEncabezado
                .Emp_Id = pEmp_Id
                .Suc_Id = pSuc_Id
                .Caja_Id = pCaja_Id
                .TipoDoc_Id = pTipoDoc_Id
                .Documento_Id = pDocumento_Id
                .Cliente_Id = CLng(TxtNumero.Text)
            End With
            VerificaMensaje(FacturaEncabezado.HistorialFactura(pTipo))

            For Each Fila As DataRow In FacturaEncabezado.Data.Tables(0).Rows
                Items(ColumnasBitacora.Fecha) = Format(Fila("Fecha"), "dd/MM/yyyy hh:mm tt")
                Items(ColumnasBitacora.Usuario) = Fila("Nombre")
                Select Case Fila("Tipo")
                    Case Enum_TipoFacturacion.Factura
                        Items(ColumnasBitacora.Maquina) = "Factura"
                    Case Enum_TipoFacturacion.PreFactura
                        Items(ColumnasBitacora.Maquina) = "Pre-Factura"
                    Case Enum_TipoFacturacion.Proforma
                        Items(ColumnasBitacora.Maquina) = "Proforma"
                End Select

                Item = New ListViewItem(Items)
                LvwBitacora.Items.Add(Item)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FacturaEncabezado = Nothing
        End Try
    End Sub

    Private Sub CargaDetalleFactura(pEmp_Id As Integer, pSuc_Id As Integer, pCaja_Id As Integer, pTipoDoc_Id As Integer, pDocumento_Id As Long)
        Dim FacturaDetalle As New TFacturaDetalle(EmpresaInfo.Emp_Id)
        Dim Items(5) As String
        Dim Item As ListViewItem = Nothing

        Try
            LvwDetalle.Items.Clear()

            With FacturaDetalle
                .Emp_Id = pEmp_Id
                .Suc_Id = pSuc_Id
                .Caja_Id = pCaja_Id
                .TipoDoc_Id = pTipoDoc_Id
                .Documento_Id = pDocumento_Id
            End With
            VerificaMensaje(FacturaDetalle.ConsultaDetalleFactura())

            For Each Fila As DataRow In FacturaDetalle.Data.Tables(0).Rows
                Items(ColumnasDetalle.Linea) = Fila("Detalle_Id")
                Items(ColumnasDetalle.Articulo) = Fila("Art_Id")
                Items(ColumnasDetalle.Cantidad) = Fila("Cantidad")
                Items(ColumnasDetalle.Descripcion) = Fila("Nombre")
                Items(ColumnasDetalle.Total) = Fila("PrecioTotal")
                Items(ColumnasDetalle.Comentario) = Fila("Observacion")

                Item = New ListViewItem(Items)
                LvwDetalle.Items.Add(Item)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FacturaDetalle = Nothing
        End Try
    End Sub

    Private Sub CargaDetalleProforma(pEmp_Id As Integer, pSuc_Id As Integer, pDocumento_Id As Long)
        Dim ProformaDetalle As New TProformaDetalle(EmpresaInfo.Emp_Id)
        Dim Items(5) As String
        Dim Item As ListViewItem = Nothing

        Try
            LvwDetalle.Items.Clear()

            With ProformaDetalle
                .Emp_Id = pEmp_Id
                .Suc_Id = pSuc_Id
                .Documento_Id = pDocumento_Id
            End With
            VerificaMensaje(ProformaDetalle.ConsultaDetalleProforma())

            For Each Fila As DataRow In ProformaDetalle.Data.Tables(0).Rows
                Items(ColumnasDetalle.Linea) = Fila("Detalle_Id")
                Items(ColumnasDetalle.Articulo) = Fila("Art_Id")
                Items(ColumnasDetalle.Cantidad) = Fila("Cantidad")
                Items(ColumnasDetalle.Descripcion) = Fila("Nombre")
                Items(ColumnasDetalle.Total) = Fila("TotalLinea")
                Items(ColumnasDetalle.Comentario) = Fila("Observacion")

                Item = New ListViewItem(Items)
                LvwDetalle.Items.Add(Item)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ProformaDetalle = Nothing
        End Try
    End Sub

    Private Sub TxtNumero_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtNumero.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If IsNumeric(TxtNumero.Text) Then
                    CargaDatos()
                    BtnHistorial.Enabled = True
                    'BtnProductosConsumidos.Enabled = True
                End If
            Case Keys.F1
                BusquedaCliente()
        End Select
    End Sub

    Private Sub TxtNumero_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtNumero.TextChanged
        Inicializa()
    End Sub

    Private Sub BusquedaCliente()
        Dim Forma As New FrmBusquedaClienteOnLine

        Try
            Forma.Execute()

            If Forma.Selecciono Then
                TxtNumero.Text = Forma.Cliente_Id
                CargaDatos()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub Inicializa()
        TxtNombre.Text = String.Empty
        TxtTelefono1.Text = String.Empty
        TxtTelefono2.Text = String.Empty
        TxtApartado.Text = String.Empty
        TxtEmail.Text = String.Empty
        TxtDireccion.Text = String.Empty
        TxtFacturaCredito.Text = String.Empty
        TxtPorcDescContado.Text = String.Empty
        TxtPorcDescCredito.Text = String.Empty
        TxtActivo.Text = String.Empty
        TxtPrecio.Text = String.Empty
        TxtUltimaCompra.Text = String.Empty
        TxtObservacion.Text = String.Empty
        TxtPuntosAcumulados.Text = String.Empty
        TxtPuntosCanjeados.Text = String.Empty
        TxtPuntosVencidos.Text = String.Empty
        TxtPuntosDisponibles.Text = String.Empty
        LvwDocumentos.Items.Clear()
        LvwDetalle.Items.Clear()
        LvwBitacora.Items.Clear()
        BtnLimpiar.Enabled = False
        BtnImprime.Enabled = False
        BtnPreFactura.Enabled = False
        TxtNumero.Enabled = True
        LvwAnotaciones.Items.Clear()
        LvwEncargos.Items.Clear()
        BtnAnotacionAgregar.Enabled = False
        BtnAnotacionEliminar.Enabled = False
    End Sub

    Private Sub FrmConsultaCliente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnPreFactura.PerformClick()
            Case Keys.F7
                BtnCrearCliente.PerformClick()
            Case Keys.F11
                BtnImprime.PerformClick()
            Case Keys.F12
                BtnLimpiar.PerformClick()
            Case Keys.F10
                BtnHistorial.PerformClick()
            Case Keys.F9
                'BtnProductosConsumidos.PerformClick()
        End Select
    End Sub

    Private Sub FrmConsultaCliente_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FormateaCamposNumericos()
        ConfiguraDetalle()
        TxtNumero.Select()
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpiar.Click
        Inicializa()
        TxtNumero.Text = String.Empty
        TxtNumero.Focus()
        BtnHistorial.Enabled = False
        'BtnProductosConsumidos.Enabled = False
    End Sub

    Private Sub LvwDocumentos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles LvwDocumentos.SelectedIndexChanged
        Dim Emp_Id As Integer
        Dim Suc_Id As Integer
        Dim Caja_Id As Integer
        Dim TipoDoc_Id As Integer
        Dim Documento As Long

        Try
            LvwDetalle.Items.Clear()

            If LvwDocumentos.SelectedItems Is Nothing OrElse LvwDocumentos.SelectedItems.Count = 0 Then
                Exit Sub
            End If

            TxtObservacion.Text = LvwDocumentos.SelectedItems(0).SubItems(ColumnasDocumentos.Comentario).Text

            Emp_Id = CInt(LvwDocumentos.SelectedItems(0).SubItems(ColumnasDocumentos.Emp_Id).Text)
            Suc_Id = CInt(LvwDocumentos.SelectedItems(0).SubItems(ColumnasDocumentos.Suc_Id).Text)
            Caja_Id = CInt(LvwDocumentos.SelectedItems(0).SubItems(ColumnasDocumentos.Caja_Id).Text)
            TipoDoc_Id = CInt(LvwDocumentos.SelectedItems(0).SubItems(ColumnasDocumentos.TipoDoc_Id).Text)
            Documento = CInt(LvwDocumentos.SelectedItems(0).SubItems(ColumnasDocumentos.Documento_Id).Text)

            If CInt(LvwDocumentos.SelectedItems(0).SubItems(ColumnasDocumentos.Tipo).Text) = Enum_TipoFacturacion.Factura Then
                CargaDetalleFactura(Emp_Id, Suc_Id, Caja_Id, TipoDoc_Id, Documento)
            Else
                CargaDetalleProforma(Emp_Id, Suc_Id, Documento)
            End If

            CargaBitacora(Emp_Id, Suc_Id, Caja_Id, TipoDoc_Id, Documento, CInt(LvwDocumentos.SelectedItems(0).SubItems(ColumnasDocumentos.Tipo).Text))
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnPreFactura_Click(sender As System.Object, e As System.EventArgs) Handles BtnPreFactura.Click
        Dim Forma As New FrmPuntoVentaRetail

        Try
            Forma.Execute(Enum_TipoFacturacion.PreFactura, CInt(TxtNumero.Text))

            CargaListaMovimientos(CInt(TxtNumero.Text))
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub CMSDocumentos_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles CMSDocumentos.Opening
        If CInt(LvwDocumentos.SelectedItems(0).SubItems(ColumnasDocumentos.Tipo).Text) <> Enum_TipoFacturacion.PreFactura Then
            e.Cancel = True
        End If
    End Sub

    Private Sub MnuEliminarPrefactura_Click(sender As System.Object, e As System.EventArgs) Handles MnuEliminarPrefactura.Click
        Dim ProformaEncabezado As New TProformaEncabezado(EmpresaInfo.Emp_Id)

        Try
            If ConfirmaAccion("Desea eliminar la prefactura?") Then
                With ProformaEncabezado
                    .Suc_Id = CajaInfo.Suc_Id
                    .Documento_Id = CLng(LvwDocumentos.SelectedItems(0).SubItems(ColumnasDocumentos.Documento_Id).Text)
                End With
                VerificaMensaje(ProformaEncabezado.Delete())
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ProformaEncabezado = Nothing
        End Try
    End Sub

    Private Sub BtnCrearCliente_Click(sender As System.Object, e As System.EventArgs) Handles BtnCrearCliente.Click
        CreaCliente()
    End Sub

    Private Sub CreaCliente()
        Dim Forma As New FrmMantClienteDetalle
        Dim FormaMant As New FrmMantClienteLista
        Dim Codigo As Integer = -1

        Try
            If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PVModificaClienteFacturacion, False) Then
                VerificaMensaje("No tiene permiso para modificar la información de los clientes")
            End If

            If TxtNombre.Text <> "" And TxtNumero.Text <> "" Then

                Codigo = TxtNumero.Text

                Forma.Titulo = "Mantenimiento Cliente"
                Forma.Nuevo = False
                Forma.Execute(Codigo)

                _GuardoCambios = Forma.GuardoCambios
            Else
                With FormaMant
                    .SalirAlGuardar = True
                    .Execute()
                End With

                _ClienteNuevo = FormaMant.ClienteNuevo
                _GuardoCambios = FormaMant.GuardoCambios
            End If
            If Forma.GuardoCambios AndAlso TxtNumero.Enabled And Forma.ClienteNuevo <> 0 Then
                If ConfirmaAccion("Desea refrescar la la información del cliente") Then
                    TxtNumero.Text = Forma.ClienteNuevo
                    CargaDatos()
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
            FormaMant = Nothing
        End Try
    End Sub

    Private Sub BtnAnotacionAgregar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAnotacionAgregar.Click
        Dim Forma As New FrmClienteAnotacion

        Try
            With Forma
                .Cliente_Id = CInt(TxtNumero.Text)
                .execute()
            End With

            CargaListaAnotaciones(CInt(TxtNumero.Text))
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnAnotacionEliminar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAnotacionEliminar.Click
        Dim ClienteAnotacion As New TClienteAnotacion(EmpresaInfo.Emp_Id)

        Try
            If LvwAnotaciones.SelectedItems Is Nothing OrElse LvwAnotaciones.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar una anotación")
            End If

            With ClienteAnotacion
                .Cliente_Id = CInt(TxtNumero.Text)
                .Anotacion_Id = CInt(LvwAnotaciones.SelectedItems(0).SubItems(0).Text)
            End With
            VerificaMensaje(ClienteAnotacion.Delete)

            CargaListaAnotaciones(CInt(TxtNumero.Text))
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ClienteAnotacion = Nothing
        End Try
    End Sub

    Private Sub BtnImprime_Click(sender As Object, e As EventArgs) Handles BtnImprime.Click
        Try
            ImprimeClienteInformacion(CInt(TxtNumero.Text), String.Empty)
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub imprimeHistorial()
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim Reporte
        Dim FormaReporte As New FrmReporte
        Dim desde As Date
        Dim hasta As Date
        Dim todo As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor
            Cliente.Cliente_Id = CInt(TxtNumero.Text.Trim())
            If PrintLocation.Tectel = InfoMaquina.PrintLocation Then
                Dim fechas As New FrmRepHistorialCliente()
                fechas.Execute()
                If fechas._VentanaCerrada Then
                    desde = fechas._FechaIni
                    hasta = fechas._FechaFin
                    todo = fechas._Todos

                Else
                    VerificaMensaje("Debe Seleccionar todo el historial o un rango de fechas")
                End If
                VerificaMensaje(Cliente.ConsultaMovimientosContadoCliente(desde, hasta, todo))
                fechas = Nothing
                Reporte = New RptHistorialCliente()
            ElseIf PrintLocation.ServicentroDelCarmen Then
                Dim fechas As New FrmRepHistorialCliente()
                fechas.Execute()
                If fechas._VentanaCerrada Then
                    desde = fechas._FechaIni
                    hasta = fechas._FechaFin
                    todo = fechas._Todos

                Else
                    VerificaMensaje("Debe Seleccionar todo el historial o un rango de fechas")
                End If
                VerificaMensaje(Cliente.ConsultaMovimientosClienteSDC(desde, hasta, todo))
                Reporte = New RptHistorialClienteSDC()
            Else
                VerificaMensaje(Cliente.ConsultaMovimientosCliente)
                Reporte = New RptHistorialCliente()
            End If


            Reporte.SetDataSource(Cliente.Data.Tables(0))

            'parametros encabezado y pie de pagina
            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))

            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("pNombreCliente", TxtNombre.Text)
            FormaReporte.Execute(Reporte)


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BtnHistorial_Click(sender As Object, e As EventArgs) Handles BtnHistorial.Click
        imprimeHistorial()
    End Sub

    Private Sub ImprimeProductoComprado()
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptProductoCompradoCliente
        Dim FormaReporte As New FrmReporte
        Try
            LvwDocumentos.Items.Clear()

            Cliente.Cliente_Id = CInt(TxtNumero.Text.Trim())
            VerificaMensaje(Cliente.ConsultaProductoCompradoCliente())

            Reporte.SetDataSource(Cliente.Data.Tables(0))

            'parametros encabezado y pie de pagina
            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))

            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("pNombreCliente", TxtNombre.Text)
            FormaReporte.Execute(Reporte)


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
        End Try
    End Sub

    'Private Sub BtnProductosConsumidos_Click(sender As Object, e As EventArgs) Handles BtnProductosConsumidos.Click
    '    ImprimeProductoComprado()
    'End Sub
End Class