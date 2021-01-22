Imports Business
Public Class FrmBusquedaProforma
    Private _TipoDoc_Id As Integer
    Private _Tipo As Enum_TipoFacturacion

    Public WriteOnly Property Tipo As Enum_TipoFacturacion
        Set(value As Enum_TipoFacturacion)
            _Tipo = value
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
    End Enum

    Private Enum ColumnasDetalle
        Linea = 0
        Articulo = 1
        Cantidad = 2
        Descripcion = 3
        Total = 4
        Comentario = 5
    End Enum
#Region "Variables"
    Private Numerico() As TNumericFormat
#End Region
#Region "Funciones Privadas"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(2)

            Numerico(0) = New TNumericFormat(TxtNumero, 8, 0, False, "", "###")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region
    Private Sub ConfiguraDetalle()
        With LvwDocumentos
            .Items.Clear()
            .Columns(ColumnasLista.Documento_Id).Width = 100
            .Columns(ColumnasLista.ClienteNombre).Width = 250
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
        Try

            RdbFechaEntrega.Checked = True

            ConfiguraDetalle()
            CargaLista(False)

            'If _Tipo <> Enum_TipoFacturacion.PreFactura Then
            '    PnlFiltros.Visible = True
            'End If

            'If _Tipo = Enum_TipoFacturacion.PreFactura Or _Tipo = Enum_TipoFacturacion.Factura Then
            '    RdbNombre.Checked = True
            '    TxtNombre.Select()
            'End If

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
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
        Dim Items(17) As String
        Dim Item As ListViewItem = Nothing
        Dim TipoBusqueda As Integer
        Try
            LvwDocumentos.Items.Clear()

            With ProformaEncabezado
                .Suc_Id = CajaInfo.Suc_Id
                .TipoDoc_Id = _TipoDoc_Id
            End With


            If RdbFechaEntrega.Checked Then
                TipoBusqueda = 2
            ElseIf RdbNombre.Checked Then
                TipoBusqueda = 3
                If TxtNombre.Text.Trim.Length = 0 Then
                    Exit Sub
                End If
            ElseIf RdbNumero.Checked Then
                TipoBusqueda = 4
                If TxtNumero.Text.Trim.Length = 0 Then
                    Exit Sub
                End If
            Else
                TipoBusqueda = 1
            End If


            Mensaje = ProformaEncabezado.ListaProformasPendientes(_Tipo, TipoBusqueda, DtpFechaEntrega.Value, IIf(RdbNumero.Checked, TxtNumero.Text, TxtNombre.Text.Trim))
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

                    Item = New ListViewItem(Items)

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

            DtpFechaEntrega.Enabled = False
            TxtNombre.Enabled = False
            TxtNumero.Enabled = False

            If RdbFechaEntrega.Checked Then
                DtpFechaEntrega.Enabled = True
                DtpFechaEntrega.Focus()
            ElseIf RdbNombre.Checked Then
                TxtNombre.Enabled = True
                TxtNombre.Focus()
            ElseIf RdbNumero.Checked Then
                TxtNumero.Enabled = True
                TxtNumero.Focus()
            End If

            CargaLista(False)

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

            If ConfirmaAccion("Desea eliminar la Proforma?") Then
                With ProformaEncabezado
                    .Suc_Id = CajaInfo.Suc_Id
                    .Documento_Id = CLng(LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.Documento_Id).Text)
                    .Emp_Id = EmpresaInfo.Emp_Id
                End With

                VerificaMensaje(ProformaEncabezado.Delete())

                CargaLista(False)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ProformaEncabezado = Nothing
            Mensaje("Proforma eliminada con exito.")
            LvwDocumentos.Items.Clear()
        End Try
    End Sub

    Private Sub CMSDocumentos_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles CMSDocumentos.Opening
        If _Tipo <> Enum_TipoFacturacion.Proforma Then
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


            'LblTelefono1.Text = LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.ClienteTelefono1).Text
            'LblTelefono2.Text = LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.ClienteTelefono2).Text
            'LblClienteTipo.Text = LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.ClienteTipo).Text
            'LblDireccion.Text = LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.ClienteDireccion).Text
            'LblObservacion.Text = LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.Comentario).Text
            'LblVendedor.Text = LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.Vendedor).Text
            'LblUsuario.Text = LvwDocumentos.SelectedItems(0).SubItems(ColumnasLista.Usuario).Text

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

    Private Sub TxtNumero_TextChanged(sender As Object, e As EventArgs) Handles TxtNumero.TextChanged
        If TxtNumero.Text.Trim.Length >= 3 Then
            CargaLista(False)
        End If
    End Sub

    Private Sub TxtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNumero.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If TxtNumero.Text <> "" Then
                    CargaLista(True)
                End If
        End Select
    End Sub

    Private Sub FrmBusquedaProforma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.FormateaCamposNumericos()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class