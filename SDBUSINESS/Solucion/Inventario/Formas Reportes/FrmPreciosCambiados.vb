Imports Business

Public Class FrmPreciosCambiados
    Public Sub execute()
        LlenaCombos()
        Me.ShowDialog()
    End Sub

    Private Sub LlenaCombos()
        Dim Sucursal As New TSucursal(EmpresaInfo.Emp_Id)
        Dim Proveedor As New TProveedor(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            Mensaje = Sucursal.LoadComboBox(CmbSucursal)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Proveedor = Nothing
            Sucursal = Nothing
        End Try
    End Sub
    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        MuestraReporte()
    End Sub

    Private Sub MuestraReporte()
        Dim articulos As New TArticulo(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptProductosActualizados()
        Dim FormaReporte As New FrmReporte
        Try
            VerificaMensaje(articulos.PreciosCambiados(DtpFechaIni.Value.Date, DtpFechaFin.Value.Date, CmbBodega.SelectedValue))


            If articulos.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(articulos.Data.Tables(0))
            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("Desde", DtpFechaIni.Value.Date)
            Reporte.SetParameterValue("Hasta", DtpFechaFin.Value.Date)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmPreciosCambiados_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            BtnImprimir.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            BtnSalir.PerformClick()
        End If
    End Sub

    Private Sub CmbSucursal_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles CmbSucursal.SelectedValueChanged
        Dim Bodega As New TBodega(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            If Not IsNumeric(CmbSucursal.SelectedValue) Then
                Exit Sub
            End If

            Bodega.Suc_Id = CInt(CmbSucursal.SelectedValue)
            Mensaje = Bodega.LoadComboBox(CmbBodega)
            VerificaMensaje(Mensaje)


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Bodega = Nothing
        End Try
    End Sub
End Class