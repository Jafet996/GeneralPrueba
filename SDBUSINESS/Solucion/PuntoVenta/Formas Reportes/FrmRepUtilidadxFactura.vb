Imports Business
Public Class FrmRepUtilidadxFactura
    Public Sub Execute()
        DtpPFechaIni.Value = DateValue(EmpresaInfo.Getdate())
        DtpPFechaFin.Value = DtpPFechaIni.Value
        Me.ShowDialog()
    End Sub
    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim FacturaEncabezado As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        ''  Dim Reporte As New RptUtilidadxFactura
        Dim Reporte
        Dim FormaReporte As New FrmReporte
        Dim StartDate As Date
        Dim EndDate As Date
        Try
            Cursor.Current = Cursors.WaitCursor

            StartDate = DateValue(DtpPFechaIni.Value)
            EndDate = DateAdd(DateInterval.Day, 1, DateValue(DtpPFechaFin.Value))
            If ChkDetallado.Checked Then
                If PrintLocation.PCW = InfoMaquina.PrintLocation Then
                    Reporte = New RptUtilidadxFacturaPCW
                Else
                    Reporte = New RptUtilidadxFactura
                End If

            Else
                Reporte = New RptUtilidadxFacturaGeneral
            End If
            With FacturaEncabezado
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
            End With
            Mensaje = FacturaEncabezado.RptUtilidadxFactura(StartDate, EndDate)
            VerificaMensaje(Mensaje)

            If FacturaEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(FacturaEncabezado.Data.Tables(0))
            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))
            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("NombreSucursal", SucursalInfo.Nombre)
            Reporte.SetParameterValue("StartDate", StartDate)
            Reporte.SetParameterValue("EndDate", EndDate)

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
            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function
    Private Sub Imprimir()
        Try
            If ValidaTodo() Then
                MuestraReporte()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub FrmRepUtilidadxFactura_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Imprimir()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub
    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimir.Click
        Imprimir()
    End Sub
    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
    Private Sub ChkGeneral_CheckedChanged(sender As Object, e As EventArgs) Handles ChkGeneral.CheckedChanged
        ChkDetallado.Enabled = Not (ChkGeneral.Checked)
    End Sub
    Private Sub ChkDetallado_CheckedChanged(sender As Object, e As EventArgs) Handles ChkDetallado.CheckedChanged
        ChkGeneral.Enabled = Not (ChkDetallado.Checked)
    End Sub
End Class