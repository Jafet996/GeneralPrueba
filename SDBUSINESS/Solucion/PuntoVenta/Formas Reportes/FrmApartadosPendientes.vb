Imports Business
Public Class FrmApartadosPendientes
    Public Sub Execute()
        Me.ShowDialog()
    End Sub
    Private Sub PrintReport()
        Dim Mensaje As String = ""
        Dim StateApart As New TApartadoEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptApartadosPendientes
        Dim FormaReporte As New FrmReporte
        Dim StartDate As Date
        Dim EndDate As Date
        Dim CheckAll As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            If CkbAlls.Checked Then
                CheckAll = False
            Else
                CheckAll = True
                StartDate = DateValue(DtpStartDate.Value)
                EndDate = DateAdd(DateInterval.Day, 1, DateValue(DtpEndDate.Value))
            End If
            With StateApart
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
            End With
            Mensaje = StateApart.RptApartPending(StartDate, EndDate, CheckAll)
            VerificaMensaje(Mensaje)
            If StateApart.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If
            Reporte.SetDataSource(StateApart.Data.Tables(0))
            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))
            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("NombreSucursal", SucursalInfo.Nombre)
            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            StateApart = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        PrintReport()
    End Sub
    Private Sub CkbAlls_CheckedChanged(sender As Object, e As EventArgs) Handles CkbAlls.CheckedChanged
        DtpStartDate.Enabled = Not (CkbAlls.Checked)
        DtpEndDate.Enabled = Not (CkbAlls.Checked)
    End Sub
End Class