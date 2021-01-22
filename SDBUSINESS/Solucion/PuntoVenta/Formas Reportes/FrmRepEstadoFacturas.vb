Imports Business

Public Class FrmRepEstadoFacturas
    Public Sub Execute()
        Try
            CargaCombos()
            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub CargaCombos()
        Dim TipoDocumento As New TTipoDocumento(EmpresaInfo.Emp_Id)
        Dim Caja As New TCaja(EmpresaInfo.Emp_Id)
        Try

            Caja.Suc_Id = SucursalInfo.Suc_Id

            TipoDocumento.Emp_Id = CajaInfo.Emp_Id
            VerificaMensaje(TipoDocumento.LoadComboBox(CmbTipoDocumento))
            VerificaMensaje(Caja.LoadComboBox(CmbCaja))



        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TipoDocumento = Nothing
        End Try
    End Sub

    Private Sub CargaCliente(Cliente_Id As Integer)
        Dim cliente As New TCliente(EmpresaInfo.Emp_Id)
        Try
            cliente.Cliente_Id = Cliente_Id
            VerificaMensaje(cliente.ListKey)
            TxtCliente.Text = cliente.Cliente_Id
            TxtClienteNombre.Text = cliente.Nombre
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCliente.KeyDown
        Dim forma As New FrmBusquedaCliente()

        Try
            If e.KeyCode = Keys.F1 Then
                forma.Execute()

                If forma.Selecciono Then
                    CargaCliente(forma.Cliente_Id)
                End If
            End If

            If e.KeyCode = Keys.Enter Then
                CargaCliente(TxtCliente.Text)
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CbTipo_CheckedChanged(sender As Object, e As EventArgs) Handles CbTipo.CheckedChanged
        CmbTipoDocumento.Enabled = CbTipo.Checked
    End Sub

    Private Sub CbCaja_CheckedChanged(sender As Object, e As EventArgs) Handles CbCaja.CheckedChanged
        CmbTipoDocumento.Enabled = CbTipo.Checked
    End Sub

    Private Sub CbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles CbCliente.CheckedChanged
        TxtCliente.Enabled = CbCliente.Checked
    End Sub

    Private Sub FrmRepEstadoFacturas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            BtnImprimir.PerformClick()
        End If

        If e.KeyCode = Keys.Escape Then
            BtnSalir.PerformClick()
        End If
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        If ValidaTodo() Then
            Imprimir()
        End If
    End Sub

    Private Sub Imprimir()

        Dim Mensaje As String = ""
        Dim FacturaEncabezado As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte
        Dim FormaReporte As New FrmReporte
        Dim FechaIni As Date
        Dim FechaFin As Date

        Try
            Cursor.Current = Cursors.WaitCursor

            FechaIni = DateValue(FechaInicial.Value)
            FechaFin = DateValue(FechaFinal.Value)

            FacturaEncabezado.Suc_Id = SucursalInfo.Suc_Id
            Mensaje = FacturaEncabezado.RptFacturaElectronicaEstado(FechaIni,
                                                                    FechaFin,
                                                                    IIf(CbCliente.Checked, TxtCliente.Text, -1),
                                                                    IIf(CbCaja.Checked, CmbCaja.SelectedValue, -1),
                                                                    IIf(CbTipo.Checked, CmbTipoDocumento.SelectedValue, -1))
            VerificaMensaje(Mensaje)

            If Not FacturaEncabezado.Data.Tables.Count > 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            If PrintLocation.Tectel = InfoMaquina.PrintLocation Then
                Reporte = New RptFacturaElectronicaEstadoTECTEL()
            Else
                Reporte = New RptFacturaElectronicaEstado()
            End If

            Reporte.SetDataSource(FacturaEncabezado.Data.Tables(0))
            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))
            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("NombreSucursal", SucursalInfo.Nombre)
            Reporte.SetParameterValue("Desde", FechaInicial.Value)
            Reporte.SetParameterValue("Hasta", FechaFinal.Value)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            FacturaEncabezado = Nothing
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If CbCliente.Checked Then
                If TxtCliente.Text = "" Then
                    MensajeError("Debe digitar el coódigo del cliente")
                End If
            End If

            Return True

        Catch ex As Exception
            MensajeError(ex.Message)

            Return False
        End Try
    End Function

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
End Class