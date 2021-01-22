Imports Business
Public Class FrmRepMovUsuarioCaja
    Public Sub Execute()
        LlenaCombos()

        Me.ShowDialog()
    End Sub
    Private Sub LlenaCombos()
        Dim Sucursal As New TSucursal(EmpresaInfo.Emp_Id)
        Dim Usuario As New TUsuario(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            Mensaje = Sucursal.LoadComboBox(CmbSucursal)
            VerificaMensaje(Mensaje)

            Mensaje = Usuario.LoadComboBox(CmbUsuario)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Sucursal = Nothing
        End Try
    End Sub
    Private Function ValidaTodo() As Boolean
        Try

            If CmbSucursal.SelectedValue Is Nothing OrElse Not IsNumeric(CmbSucursal.SelectedValue) Then
                VerificaMensaje("Debe de seleccionar una sucursal")
            End If

            If ckbCaja.Checked Then
                If CmbCaja.SelectedValue Is Nothing OrElse Not IsNumeric(CmbCaja.SelectedValue) Then
                    VerificaMensaje("Debe de seleccionar una caja")
                End If
            End If

            If ckbUsuario.Checked Then
                If CmbUsuario.SelectedValue Is Nothing Then
                    VerificaMensaje("Debe de seleccionar un usuario")
                End If
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function
    Private Sub CmbSucursal_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles CmbSucursal.SelectedValueChanged
        Dim Caja As New TCaja(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            If Not IsNumeric(CmbSucursal.SelectedValue) Then
                Exit Sub
            End If

            Caja.Suc_Id = CInt(CmbSucursal.SelectedValue)
            Mensaje = Caja.CargaComboBox(CmbCaja)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Caja = Nothing
        End Try
    End Sub
    Private Sub Imprimir()
        Try
            If ValidaTodo() Then
                MuestraReporte()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim Movimientos As New TCajaCierreEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptMovimientosPorCajaUsuario
        Dim FormaReporte As New FrmReporte

        Try
            Cursor.Current = Cursors.WaitCursor
            With Movimientos
                .Suc_Id = CmbSucursal.SelectedValue
                .Caja_Id = IIf(CmbCaja.SelectedValue Is Nothing, -1, CmbCaja.SelectedValue)
                .Usuario_Id = IIf(CmbUsuario.SelectedValue Is Nothing, "-1", CmbUsuario.SelectedValue)
            End With

            Mensaje = Movimientos.RptMovimientosPorCajaUsuario(dpDesde.Value, dpHasta.Value)
            VerificaMensaje(Mensaje)

            If Movimientos.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(Movimientos.Data.Tables(0))
            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("Sucursal", CmbSucursal.Text)
            Reporte.SetParameterValue("Caja", IIf(CmbCaja.SelectedValue Is Nothing, "TODAS", CmbCaja.Text))

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            Movimientos = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Imprimir()
    End Sub

    Private Sub ckbCaja_CheckedChanged(sender As Object, e As EventArgs) Handles ckbCaja.CheckedChanged
        If ckbCaja.Checked Then
            CmbCaja.Visible = True
            CmbCaja.Enabled = True
        Else
            CmbCaja.Visible = False
            CmbCaja.Enabled = False
            CmbCaja.SelectedValue = -1
        End If
    End Sub

    Private Sub ckbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles ckbUsuario.CheckedChanged
        If ckbUsuario.Checked Then
            CmbUsuario.Visible = True
            CmbUsuario.Enabled = True
        Else
            CmbUsuario.Visible = False
            CmbUsuario.Enabled = False
            CmbUsuario.SelectedValue = -1
        End If
    End Sub
End Class