Imports Business
Public Class FrmFacturaElectronicaPendiente
#Region "Enum"
    Private Enum ColumnasFacturaPendiente
        Cliente_Id = 0
        ClienteNombre = 1
        Sucursal = 2
        Caja = 3
        Tipo = 4
        Documento = 5
        Consecutivo = 6
        Fecha = 7
        Monto = 8
        MsjError = 9
    End Enum
#End Region
    Public Sub Execute()
        Try
            ConfiguraLista()
            CargaPantalla()
            AsignaInterfaz()
            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub AsignaInterfaz()
        Select Case InfoMaquina.InterfazFactura
            Case Enum_InterfazFacturacion.Reducida
                Me.Width = Me.Width - 120
        End Select
    End Sub

#Region ""
    Private Sub ConfiguraLista()
        Try
            With LsvFacturaPendiente

                .Columns(ColumnasFacturaPendiente.ClienteNombre).Text = "Cliente"
                .Columns(ColumnasFacturaPendiente.ClienteNombre).Width = 200

                .Columns(ColumnasFacturaPendiente.Cliente_Id).Text = "Cliente ID"
                .Columns(ColumnasFacturaPendiente.Cliente_Id).Width = 0


                .Columns(ColumnasFacturaPendiente.Sucursal).Text = "Sucursal"
                .Columns(ColumnasFacturaPendiente.Sucursal).Width = 0

                .Columns(ColumnasFacturaPendiente.Caja).Text = "Caja"
                .Columns(ColumnasFacturaPendiente.Caja).Width = 0

                .Columns(ColumnasFacturaPendiente.Tipo).Text = "Tipo Documento"
                .Columns(ColumnasFacturaPendiente.Tipo).Width = 0

                .Columns(ColumnasFacturaPendiente.Documento).Text = "Documento"
                .Columns(ColumnasFacturaPendiente.Documento).Width = 0

                .Columns(ColumnasFacturaPendiente.Consecutivo).Text = "Consecutivo"
                .Columns(ColumnasFacturaPendiente.Consecutivo).Width = 175

                .Columns(ColumnasFacturaPendiente.Fecha).Text = "Fecha"
                .Columns(ColumnasFacturaPendiente.Fecha).Width = 175

                .Columns(ColumnasFacturaPendiente.Monto).Text = "Monto"
                .Columns(ColumnasFacturaPendiente.Monto).Width = 120

                .Columns(ColumnasFacturaPendiente.MsjError).Text = "Error"
                .Columns(ColumnasFacturaPendiente.MsjError).Width = 650

            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub CargaPantalla()
        Dim Mensaje As String = ""
        Dim FacturaPendiente As New TFacturaElectronicaPendiente(EmpresaInfo.Emp_Id)
        Dim Item As ListViewItem = Nothing
        Dim Items(9) As String
        Try

            Mensaje = FacturaPendiente.CargaFacturaPendiente()
            VerificaMensaje(Mensaje)

            LsvFacturaPendiente.Items.Clear()


            For Each Fila As DataRow In FacturaPendiente.Data.Tables(0).Rows


                Items(ColumnasFacturaPendiente.ClienteNombre) = Fila("ClienteNombre")
                Items(ColumnasFacturaPendiente.Cliente_Id) = Fila("Cliente_Id")
                Items(ColumnasFacturaPendiente.Sucursal) = Fila("Suc_Id")
                Items(ColumnasFacturaPendiente.Caja) = Fila("Caja_Id")
                Items(ColumnasFacturaPendiente.Tipo) = Fila("TipoDoc_Id")
                Items(ColumnasFacturaPendiente.Documento) = Fila("Documento_Id")
                Items(ColumnasFacturaPendiente.Consecutivo) = Fila("Consecutivo")
                Items(ColumnasFacturaPendiente.Fecha) = Format(Fila("Fecha"), "dd/MM/yyyy HH:mm tt")
                Items(ColumnasFacturaPendiente.Monto) = Format(Fila("TotalCobrado"), "#,##0.00")
                Items(ColumnasFacturaPendiente.MsjError) = Format(Fila("Mensaje"))

                Item = New ListViewItem(Items)
                LsvFacturaPendiente.Items.Add(Item)
            Next

            BtnEnviar.Enabled = LsvFacturaPendiente.Items.Count > 0
            BtnCliente.Enabled = LsvFacturaPendiente.Items.Count > 0


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnRefrescar_Click(sender As Object, e As EventArgs) Handles BntRefrescar.Click
        CargaPantalla()
    End Sub

    Private Sub FrmFacturaElectronicaPendiente_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                BtnEnviar.PerformClick()
            Case Keys.F3
                BntRefrescar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnEnviar.Click
        If ConfirmaAccion("Desea enviar las facturas electrónicas pendientes?") Then
            EnvioFactura()
        End If
    End Sub

    Private Sub EnvioFactura()
        Dim FacturaElectronicaPendiente As New TFacturaElectronicaPendiente(EmpresaInfo.Emp_Id)
        Try
            Cursor.Current = Cursors.WaitCursor
            BtnEnviar.Enabled = False
            BtnCliente.Enabled = False


            VerificaMensaje(FacturaElectronicaPendiente.EnviaFacturasPendientes())

            CargaPantalla()

            Mensaje("El proceso se ejecuto de manera correcta")

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cursor.Current = Cursors.Default
            FacturaElectronicaPendiente = Nothing
            PrgProgreso.Visible = False

            CargaPantalla()
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnCliente_Click(sender As Object, e As EventArgs) Handles BtnCliente.Click
        Try

            If Not LsvFacturaPendiente.SelectedItems Is Nothing AndAlso LsvFacturaPendiente.SelectedItems.Count > 0 Then
                ModificaClienteFactura()
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ModificaClienteFactura()
        'Dim FacturaEncabezado As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim MantClienteDetalle As New FrmMantClienteDetalle
        Try

            'With FacturaEncabezado
            '    .Suc_Id = CInt(LsvFacturaPendiente.SelectedItems(0).SubItems(ColumnasFacturaPendiente.Sucursal).Text)
            '    .Caja_Id = CInt(LsvFacturaPendiente.SelectedItems(0).SubItems(ColumnasFacturaPendiente.Caja).Text)
            '    .TipoDoc_Id = CInt(LsvFacturaPendiente.SelectedItems(0).SubItems(ColumnasFacturaPendiente.Tipo).Text)
            '    .Documento_Id = CLng(LsvFacturaPendiente.SelectedItems(0).SubItems(ColumnasFacturaPendiente.Documento).Text)
            'End With

            'FacturaEncabezado.ListKey()
            'If FacturaEncabezado.RowsAffected = 0 Then
            '    VerificaMensaje("No se encontro la factura")
            'End If


            With MantClienteDetalle
                .Nuevo = False
                .Titulo = Me.Text
            End With

            MantClienteDetalle.Execute(CInt(LsvFacturaPendiente.SelectedItems(0).SubItems(ColumnasFacturaPendiente.Cliente_Id).Text))

            If MantClienteDetalle.GuardoCambios Then
                CargaPantalla()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            'FacturaEncabezado = Nothing
            MantClienteDetalle = Nothing
        End Try
    End Sub



#End Region

End Class
