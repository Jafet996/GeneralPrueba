Imports Business
Public Class FrmRptVentasXArticulo
    Public Sub Execute()
        DtpPFechaIni.Value = DateValue(EmpresaInfo.Getdate())
        DtpPFechaFin.Value = DtpPFechaIni.Value

        Me.ShowDialog()
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If DateValue(DtpPFechaIni.Value) > DateValue(DtpPFechaFin.Value) Then
                VerificaMensaje("La fecha de inicio no puede superior a la final")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub MuestraReporte()
        Dim FacturaEncabezado As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptVentasXArticulo
        Dim FormaReporte As New FrmReporte
        Dim FechaIni As Date
        Dim FechaFin As Date

        Try
            Cursor.Current = Cursors.WaitCursor

            FechaIni = DateValue(DtpPFechaIni.Value)
            FechaFin = DateAdd(DateInterval.Day, 1, DateValue(DtpPFechaFin.Value))

            With FacturaEncabezado
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
            End With
            VerificaMensaje(FacturaEncabezado.RptVentasXArticulo(FechaIni, FechaFin))

            If FacturaEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(FacturaEncabezado.Data.Tables(0))
            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))
            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("FechaIni", FechaIni)
            Reporte.SetParameterValue("FechaFin", DateValue(DtpPFechaFin.Value))

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

    Private Sub Imprimir()
        Try
            If ValidaTodo() Then
                MuestraReporte()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Imprimir()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmRptVentasXArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnImprimir.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

End Class