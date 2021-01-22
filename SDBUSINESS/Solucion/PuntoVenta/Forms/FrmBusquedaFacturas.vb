Imports Business
Public Class FrmBusquedaFacturas
    Private _Respuesta As TFacturaLlave

    Public Property Respuesta As TFacturaLlave
        Get
            Return _Respuesta
        End Get
        Set(value As TFacturaLlave)
            _Respuesta = value
        End Set
    End Property

    Private Enum ColumnasDetalle
        DocumentoId = 0
        CajaId
        CajaNombre
        TipoDocumentoId
        TipoDocumentoNombre
        ClienteNombre
        Fecha
        Monto
    End Enum

    Private Sub ConfiguraDetalle()
        With LvwFacturas
            .Columns(ColumnasDetalle.DocumentoId).Text = "Número"
            .Columns(ColumnasDetalle.DocumentoId).Width = 80

            .Columns(ColumnasDetalle.CajaId).Text = ""
            .Columns(ColumnasDetalle.CajaId).Width = 0

            .Columns(ColumnasDetalle.CajaNombre).Text = "Caja"
            .Columns(ColumnasDetalle.CajaNombre).Width = 100

            .Columns(ColumnasDetalle.TipoDocumentoId).Text = ""
            .Columns(ColumnasDetalle.TipoDocumentoId).Width = 0

            .Columns(ColumnasDetalle.TipoDocumentoNombre).Text = "Tipo"
            .Columns(ColumnasDetalle.TipoDocumentoNombre).Width = 100

            .Columns(ColumnasDetalle.ClienteNombre).Text = "Cliente"
            .Columns(ColumnasDetalle.ClienteNombre).Width = 220

            .Columns(ColumnasDetalle.Fecha).Text = "Fecha"
            .Columns(ColumnasDetalle.Fecha).Width = 95

            .Columns(ColumnasDetalle.Monto).Text = "Monto"
            .Columns(ColumnasDetalle.Monto).Width = 120
            .Columns(ColumnasDetalle.Monto).TextAlign = HorizontalAlignment.Right
        End With
    End Sub

    Public Sub Execute()
        _Respuesta = Nothing
        ConfiguraDetalle()
        RdbFecha.Checked = True
        TxtCliente.Focus()
        Me.ShowDialog()
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Function ValidaCliente() As Boolean
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

            TxtClienteNombre.Text = Cliente.Nombre

            Return True
        Catch ex As Exception
            EnfocarTexto(TxtCliente)
            MensajeError(ex.Message)
            Return False
        Finally
            Cliente = Nothing
        End Try
    End Function
    Private Sub BusquedaCliente()
        Dim Forma As New FrmBusquedaClienteOnLine
        Try

            Forma.Execute()

            If Forma.Selecciono Then
                TxtCliente.Text = Forma.Cliente_Id
                ValidaCliente()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Sub TxtCliente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCliente.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If TxtCliente.Text.Trim <> "" Then
                    ValidaCliente()
                End If
            Case Keys.F1
                BusquedaCliente()
        End Select
    End Sub

    Private Sub TxtCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCliente.TextChanged
        TxtClienteNombre.Text = ""
    End Sub

    Private Sub HabilitaControles()
        TxtCliente.Enabled = RdbCliente.Checked
        TxtClienteNombre.Enabled = RdbCliente.Checked
        DtpFecha.Enabled = RdbFecha.Checked
        TxtNombre.Enabled = RdbNombre.Checked
    End Sub

    Private Sub RdbCliente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdbCliente.CheckedChanged
        HabilitaControles()
    End Sub

    Private Sub RdbFecha_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdbFecha.CheckedChanged
        HabilitaControles()
    End Sub

    Private Sub Buscar()
        Dim FacturaEncabezado As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim Tipo As Integer = -1
        Dim Items(8) As String
        Dim Item As ListViewItem = Nothing
        Try

            LvwFacturas.Items.Clear()

            With FacturaEncabezado
                .Emp_Id = CajaInfo.Emp_Id
                .Suc_Id = CajaInfo.Suc_Id
                If RdbCliente.Checked Then
                    Tipo = 0
                    .Cliente_Id = CInt(TxtCliente.Text)
                End If

                If RdbFecha.Checked Then
                    Tipo = 1
                    .Fecha = DateValue(DtpFecha.Value)
                End If

                If RdbNombre.Checked Then
                    Tipo = 2
                    .Nombre = TxtNombre.Text.Trim
                End If
            End With

            VerificaMensaje(FacturaEncabezado.BusquedaFacturas(Tipo))

            For Each Reg As DataRow In FacturaEncabezado.Data.Tables(0).Rows
                Items(ColumnasDetalle.DocumentoId) = Reg("Documento_Id")
                Items(ColumnasDetalle.CajaId) = Reg("Caja_Id")
                Items(ColumnasDetalle.CajaNombre) = Reg("NombreCaja")
                Items(ColumnasDetalle.TipoDocumentoId) = Reg("TipoDoc_Id")
                Items(ColumnasDetalle.TipoDocumentoNombre) = Reg("NombreTipoDoc")
                Items(ColumnasDetalle.ClienteNombre) = Reg("NombreCliente")
                Items(ColumnasDetalle.Fecha) = Format(Reg("Fecha"), "dd/MM/yyyy")
                Items(ColumnasDetalle.Monto) = Format(Reg("TotalCobrado"), "#,##0.00")

                Item = New ListViewItem(Items)
                LvwFacturas.Items.Add(Item)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FacturaEncabezado = Nothing
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try

            If RdbCliente.Checked Then
                If Not ValidaCliente() Then
                    VerificaMensaje("Debe de ingresar un cliente válido")
                End If
            End If

            If RdbNombre.Checked Then
                If TxtNombre.Text.Trim = "" Then
                    VerificaMensaje("Debe de ingresar un nombre")
                End If
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub BtnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles BtnBuscar.Click
        Try
            If ValidaTodo() Then
                Buscar()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LvwFacturas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles LvwFacturas.SelectedIndexChanged

    End Sub

    Private Sub Seleccionar()
        Try
            _Respuesta = Nothing

            If LvwFacturas.SelectedItems Is Nothing OrElse LvwFacturas.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un documento")
            End If

            _Respuesta = New TFacturaLlave

            With _Respuesta
                .Emp_Id = CajaInfo.Emp_Id
                .Suc_Id = CajaInfo.Suc_Id
                .Caja_Id = CInt(LvwFacturas.SelectedItems(0).SubItems(ColumnasDetalle.CajaId).Text)
                .TipoDoc_Id = CInt(LvwFacturas.SelectedItems(0).SubItems(ColumnasDetalle.TipoDocumentoId).Text)
                .Documento_Id = CLng(LvwFacturas.SelectedItems(0).SubItems(ColumnasDetalle.DocumentoId).Text)
            End With

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        Seleccionar()
    End Sub

    Private Sub LvwFacturas_DoubleClick(sender As System.Object, e As System.EventArgs) Handles LvwFacturas.DoubleClick
        If LvwFacturas.SelectedItems Is Nothing OrElse LvwFacturas.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        Seleccionar()
    End Sub

    Private Sub LvwFacturas_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles LvwFacturas.KeyDown
        If LvwFacturas.SelectedItems Is Nothing OrElse LvwFacturas.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        Seleccionar()
    End Sub
End Class