Imports Business
Public Class FrmBusquedaPreFactura
    Private _TipoDoc_Id As Integer
    Private _Tipo As Enum_TipoFacturacion
    Private _TipoOrigen As Enum_TipoFacturacion

    Public WriteOnly Property Tipo As Enum_TipoFacturacion
        Set(value As Enum_TipoFacturacion)
            _Tipo = value
        End Set
    End Property
    Public WriteOnly Property TipoOrigen As Enum_TipoFacturacion
        Set(value As Enum_TipoFacturacion)
            _TipoOrigen = value
        End Set
    End Property


    Public WriteOnly Property TipoDoc_Id As Integer
        Set(value As Integer)
            _TipoDoc_Id = value
        End Set
    End Property

    Private _FacturaSeleccionada As TFacturaLlave = Nothing

    Public Property FacturaSeleccionada As TFacturaLlave
        Get
            Return _FacturaSeleccionada
        End Get
        Set(value As TFacturaLlave)
            _FacturaSeleccionada = value
        End Set
    End Property

    Private Enum ColumnasLista
        Documento_Id = 0
        ClienteNombre = 1
        Fecha = 2
        Monto = 3
        Vencimiento = 4
        TipoDocumento = 5
        TipoEntrega = 6
        FechaEntrega = 7

        Comentario = 8
        Emp_Id = 9
        Suc_Id = 10
        TipoDoc_Id = 11
        ClienteTelefono1 = 12
        ClienteTelefono2 = 13
        ClienteTipo = 14
        ClienteDireccion = 15
        Vendedor = 16
        Usuario = 17
        TipoDocNombre = 18
        Tipo = 19
    End Enum

    Private Enum ColumnasDetalle
        Linea = 0
        Articulo = 1
        Cantidad = 2
        Descripcion = 3
        Total = 4
        Comentario = 5
    End Enum


    Private Sub ConfiguraDetalle()
        With LvwDocumentos
            .Items.Clear()
            .Columns(ColumnasLista.Documento_Id).Width = 100
            .Columns(ColumnasLista.ClienteNombre).Width = 330
            .Columns(ColumnasLista.Fecha).Width = 120
            .Columns(ColumnasLista.Monto).Width = 100
            .Columns(ColumnasLista.Monto).TextAlign = HorizontalAlignment.Right
            .Columns(ColumnasLista.Vencimiento).Width = 120
            .Columns(ColumnasLista.TipoDocumento).Width = 120
            .Columns(ColumnasLista.TipoEntrega).Width = IIf(InfoMaquina.PrefacturaTipoEntrega, 80, 0)
            .Columns(ColumnasLista.FechaEntrega).Width = IIf(InfoMaquina.PrefacturaTipoEntrega, 120, 0)

            .Columns(ColumnasLista.Comentario).Width = 0
            .Columns(ColumnasLista.Emp_Id).Width = 0
            .Columns(ColumnasLista.Suc_Id).Width = 0
            .Columns(ColumnasLista.TipoDoc_Id).Width = 0
            .Columns(ColumnasLista.ClienteTelefono1).Width = 0
            .Columns(ColumnasLista.ClienteTelefono2).Width = 0
            .Columns(ColumnasLista.ClienteTipo).Width = 0
            .Columns(ColumnasLista.ClienteDireccion).Width = 0

            .Columns(ColumnasLista.Vendedor).Width = 0
            .Columns(ColumnasLista.Usuario).Width = 0


            .Columns(ColumnasLista.TipoDocNombre).Text = "Tipo Documento"
            .Columns(ColumnasLista.TipoDocNombre).Width = 120
            .Columns(ColumnasLista.Tipo).Width = 0
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
            .Columns(ColumnasDetalle.Total).TextAlign = HorizontalAlignment.Right

            .Columns(ColumnasDetalle.Comentario).Text = "Comentario"
            .Columns(ColumnasDetalle.Comentario).Width = 0
        End With
    End Sub

    Public Sub Execute()
        RdbMostarTodo.Checked = True
        DtpFechaEntrega.Enabled = False

        ConfiguraDetalle()
        CargaLista(False)

        If _Tipo <> Enum_TipoFacturacion.PreFactura Then
            PnlFiltros.Visible = True
        End If

        'If _Tipo = Enum_TipoFacturacion.PreFactura Or _Tipo = Enum_TipoFacturacion.Factura Then
        '    RdbNombre.Checked = True
        '    TxtNombre.Select()
        'End If

        RdbNombre.Checked = True
        TxtNombre.Select()

        LvwDocumentos.Select()

        Me.ShowDialog()
    End Sub
    Private Sub FrmPreFacturaLista_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                CargaLista(True)
            Case Keys.F3, Keys.Enter
                SeleccionaFactura()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub CargaLista(pMuestraMensaje As Boolean)
        Dim ProformaEncabezado As New TProformaEncabezado(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Dim Items(19) As String
        Dim Item As ListViewItem = Nothing
        Dim TipoBusqueda As Integer
        Dim Tipos As String = String.Empty
        Try
            LvwDocumentos.Items.Clear()

            With ProformaEncabezado
                .Suc_Id = CajaInfo.Suc_Id
                .TipoDoc_Id = _TipoDoc_Id
            End With

            If RdbMostarTodo.Checked Then
                TipoBusqueda = 1
            ElseIf RdbFechaEntrega.Checked Then
                TipoBusqueda = 2
            ElseIf RdbNombre.Checked Then
                TipoBusqueda = 3
            Else
                TipoBusqueda = 4
            End If


            Select Case _TipoOrigen
                Case Enum_TipoFacturacion.Factura
                    Tipos = Enum_TipoFacturacion.PreFactura & "," & Enum_TipoFacturacion.ApartadoRetirado
                Case Else
                    Tipos = Enum_TipoFacturacion.PreFactura
            End Select


            Mensaje = ProformaEncabezado.ListaPreFacturasPendientes(Tipos, TipoBusqueda, DtpFechaEntrega.Value, TxtNombre.Text.Trim)
            VerificaMensaje(Mensaje)

            If ProformaEncabezado.RowsAffected = 0 Then
                If pMuestraMensaje Then
                    VerificaMensaje("No hay prefacturas pendientes")
                End If
            Else
                For Each Fila As DataRow In ProformaEncabezado.Data.Tables(0).Rows
                    Items(ColumnasLista.Documento_Id) = Fila("Documento_Id")
                    Items(ColumnasLista.ClienteNombre) = Fila("Nombre")
                    Items(ColumnasLista.Fecha) = Format(Fila("Fecha"), "dd/MM/yyyy HH:mm:ss")
                    Items(ColumnasLista.Monto) = Format(Fila("TotalCobrado"), "#,##0.00")
                    Items(ColumnasLista.Vencimiento) = Format(Fila("Vencimiento"), "dd/MM/yyyy HH:mm:ss")
                    Items(ColumnasLista.TipoDocumento) = Fila("TipoDocumento")
                    Items(ColumnasLista.TipoEntrega) = Fila("TipoEntregaNombre")
                    Items(ColumnasLista.FechaEntrega) = Format(Fila("FechaEntrega"), "dd/MM/yyyy")


                    Items(ColumnasLista.Emp_Id) = Fila("Emp_Id")
                    Items(ColumnasLista.Suc_Id) = Fila("Suc_Id")

                    Items(ColumnasLista.Comentario) = Fila("Comentario")
                    Items(ColumnasLista.TipoDoc_Id) = Fila("TipoDoc_Id")
                    Items(ColumnasLista.ClienteTelefono1) = Fila("Telefono1")
                    Items(ColumnasLista.ClienteTelefono2) = Fila("Telefono2")
                    Items(ColumnasLista.ClienteTipo) = Fila("ClienteTipo")
                    Items(ColumnasLista.ClienteDireccion) = Fila("Direccion")

                    Items(ColumnasLista.Vendedor) = Fila("VendedorNombre")
                    Items(ColumnasLista.Usuario) = Fila("Usuario_Id")
                    Items(ColumnasLista.TipoDocNombre) = Fila("TipoDocNombre")
                    Items(ColumnasLista.Tipo) = Fila("Tipo")

                    Item = New ListViewItem(Items)

                    If Fila("Tipo") = Enum_TipoFacturacion.ApartadoRetirado Then
                        ListViewCambiaColorFilaTexto(Item, Color.DarkGreen)
                    End If

                    LvwDocumentos.Items.Add(Item)
                Next

                LvwDocumentos.SelectedItems.Clear()
                LvwDocumentos.Items(0).Selected = True
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ProformaEncabezado = Nothing
        End Try
    End Sub

    Private Sub SeleccionaFactura()
        Try

            If LvwDocumentos.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un documento")
            End If

            _FacturaSeleccionada = New TFacturaLlave

            With _FacturaSeleccionada
                .Emp_Id = CajaInfo.Emp_Id
                .Suc_Id = CajaInfo.Suc_Id
                .Documento_Id = CLng(LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.Documento_Id).Text)
                .TipoDoc_Id = CLng(LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.TipoDoc_Id).Text)
                .Tipo = CLng(LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.Tipo).Text)
            End With

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TSLF3_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub LvwDocumentos_DoubleClick(sender As Object, e As System.EventArgs) Handles LvwDocumentos.DoubleClick
        If Not LvwDocumentos.SelectedItems Is Nothing OrElse LvwDocumentos.SelectedItems.Count > 0 Then
            SeleccionaFactura()
        End If
    End Sub

    Private Sub HabilitaFiltros()
        Try

            DtpFechaEntrega.Enabled = RdbFechaEntrega.Checked
            If RdbNombre.Checked Or RdbNumero.Checked Then
                TxtNombre.Enabled = True
                TxtNombre.Focus()
            Else
                TxtNombre.Enabled = False
            End If

            CargaLista(False)

            If RdbNombre.Checked Then
                TxtNombre.Focus()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub



    Private Sub RdbFechaEntrega_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdbFechaEntrega.CheckedChanged
        HabilitaFiltros()
        'DtpFechaEntrega.Enabled = RdbFechaEntrega.Enabled
        'If RdbFechaEntrega.Checked Then
        '    CargaLista(False)
        'End If
    End Sub

    Private Sub RdbMostarTodo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdbMostarTodo.CheckedChanged
        'DtpFechaEntrega.Enabled = Not RdbFechaEntrega.Enabled
        HabilitaFiltros()
    End Sub

    Private Sub DtpFechaEntrega_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DtpFechaEntrega.ValueChanged
        CargaLista(False)
    End Sub

    Private Sub MnuEliminarPrefactura_Click(sender As System.Object, e As System.EventArgs) Handles MnuEliminarPrefactura.Click
        Dim ProformaEncabezado As New TProformaEncabezado(EmpresaInfo.Emp_Id)
        Try

            If ConfirmaAccion("Desea eliminar la prefactura?") Then

                If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PVEliminaPrefactura, False) Then
                    VerificaMensaje("No tiene permiso para eliminar la prefactura")
                End If

                With ProformaEncabezado
                    .Suc_Id = CajaInfo.Suc_Id
                    .Documento_Id = CLng(LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.Documento_Id).Text)
                End With

                VerificaMensaje(ProformaEncabezado.Delete())

                CargaLista(False)

            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ProformaEncabezado = Nothing
        End Try
    End Sub

    Private Sub CMSDocumentos_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles CMSDocumentos.Opening
        If _Tipo <> Enum_TipoFacturacion.PreFactura Then
            e.Cancel = True
        End If
    End Sub

    Private Sub RdbNombre_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdbNombre.CheckedChanged
        HabilitaFiltros()
    End Sub

    Private Sub TxtNombre_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtNombre.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If TxtNombre.Text <> "" Then
                    CargaLista(True)
                End If
        End Select
    End Sub

    Private Sub LvwDocumentos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles LvwDocumentos.SelectedIndexChanged
        Dim Emp_Id As Integer
        Dim Suc_Id As Integer
        Dim TipoDoc_Id As Integer
        Dim Documento As Long
        Try

            LvwDetalle.Items.Clear()


            If LvwDocumentos.SelectedItems Is Nothing OrElse LvwDocumentos.SelectedItems.Count = 0 Then
                Exit Sub
            End If


            LblTelefono1.Text = LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.ClienteTelefono1).Text
            LblTelefono2.Text = LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.ClienteTelefono2).Text
            LblClienteTipo.Text = LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.ClienteTipo).Text
            LblDireccion.Text = LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.ClienteDireccion).Text
            LblObservacion.Text = LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.Comentario).Text
            LblVendedor.Text = LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.Vendedor).Text
            LblUsuario.Text = LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.Usuario).Text

            Emp_Id = CInt(LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.Emp_Id).Text)
            Suc_Id = CInt(LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.Suc_Id).Text)
            TipoDoc_Id = CInt(LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.TipoDoc_Id).Text)
            Documento = CInt(LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.Documento_Id).Text)

            CargaDetalleProforma(Emp_Id, Suc_Id, Documento)

        Catch ex As Exception
            MensajeError(ex.Message)
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
                Items(ColumnasDetalle.Total) = Format(Fila("TotalLinea"), "#,##0.00")
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

    Private Sub TxtNombre_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtNombre.TextChanged
        If TxtNombre.Text.Trim.Length >= 3 Then
            CargaLista(False)
        End If
    End Sub

    Private Sub RdbNumero_CheckedChanged(sender As Object, e As EventArgs) Handles RdbNumero.CheckedChanged
        HabilitaFiltros()
    End Sub

    Private Sub FrmProformaLista_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            RdbNombre.Checked = True
            TxtNombre.Select()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class