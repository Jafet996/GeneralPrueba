Imports BUSINESS

Public Class FrmRptDescargueConsumoInterno

    Public Sub Execute()
        Me.ShowDialog()
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        If ValidaTodo() Then
            MuestraReporte()
        End If
    End Sub


    Private Sub MuestraReporte()
        Dim Reporte As New RptDescargueConsumoInterno
        Dim FormaReporte As New FrmReporte
        Dim Desde As DateTime
        Dim Hasta As DateTime
        Dim movimiento As New TCxCMovimiento()

        Try

            Cursor = Cursors.WaitCursor

            movimiento.Emp_Id = EmpresaInfo.Emp_Id

            VerificaMensaje(movimiento.ReporteConsumoInterno(DtpDesde.Value, DtpHasta.Value))

            If movimiento.RowsAffected = 0 Then
                VerificaMensaje("No existen datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(movimiento.Datos.Tables(0))
            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Datos.Tables(0))
            Reporte.SetParameterValue("pEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("pFechaDesde", DtpDesde.Value.ToString("dd-MM-yyyy"))
            Reporte.SetParameterValue("pFechaHasta", DtpHasta.Value.ToString("dd-MM-yyyy"))

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If



        Catch ex As Exception

            MensajeError(ex.Message)

        Finally

            FormaReporte = Nothing
            movimiento = Nothing
            Cursor = Cursors.Default

        End Try
    End Sub

    Private Function ValidaTodo() As Boolean

        Return DtpDesde.Value.ToString("yyyyMMdd") <= DtpHasta.Value.ToString("yyyyMMdd")

    End Function

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmRptDescargueConsumoInterno_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            BtnSalir.PerformClick()
        ElseIf e.KeyCode = Keys.F3 Then
            BtnImprimir.PerformClick()
        End If
    End Sub
End Class