Imports BUSINESS

Public Class FrmRptMovimientosGenerales

    Public Sub execute()
        CargaCombos()
        Me.ShowDialog()
    End Sub

    Private Sub CbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles CbTodos.CheckedChanged
        CmbtipoDocumento.Enabled = Not CbTodos.Checked
    End Sub


    Private Sub CargaCombos()
        Dim tipoDocumento As New TCxCMovimientoTipo

        Try
            tipoDocumento.Emp_Id = EmpresaInfo.Emp_Id
            tipoDocumento.LoadComboBox(CmbtipoDocumento)
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub

    Function ValidaTodo() As Boolean

        Return DpDesde.Value.Date <= DpHasta.Value.Date

    End Function

    Private Sub MuestraReporte()
        Dim CXCMovimiento As New TCxCMovimiento
        Dim Reporte As New RptMovimientosGenerales
        Dim FormaReporte As New FrmReporte
        Dim Desde As DateTime
        Dim Hasta As DateTime
        Dim tipo As Integer

        Try
            Cursor = Cursors.WaitCursor
            Desde = DpDesde.Value
            Hasta = DpDesde.Value

            With CXCMovimiento
                .Emp_Id = EmpresaInfo.Emp_Id
            End With

            If CbTodos.Checked Then
                tipo = -1
            Else
                tipo = CmbtipoDocumento.SelectedValue
            End If

            VerificaMensaje(CXCMovimiento.RptMovimientosGenerales(DpDesde.Value, DpHasta.Value, tipo))

            If CXCMovimiento.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(CXCMovimiento.Datos.Tables(0))
            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Datos.Tables(0))
            Reporte.SetParameterValue("pEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("pFechaDesde", DpDesde.Value.ToString("dd-MM-yyyy"))
            Reporte.SetParameterValue("pFechaHasta", DpHasta.Value.ToString("dd-MM-yyyy"))

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            CXCMovimiento = Nothing
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Imprimir()
        Try
            If ValidaTodo() Then
                MuestraReporte()
            Else
                MensajeError("La fecha inicial debe ser menor o igual a la final")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Imprimir()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmRptMovimientosGenerales_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnImprimir.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub
End Class