Imports Business
Public Class FrmRepVentasXHoraXCategoria
    Public Sub Execute()
        DtpPFechaIni.Value = DateValue(EmpresaInfo.Getdate())
        DtpPFechaFin.Value = DtpPFechaIni.Value
        CargaCombo()

        Me.ShowDialog()
    End Sub

    Private Sub CargaCombo()
        Try
            Dim Categoria As New TCategoria(EmpresaInfo.Emp_Id)
            Dim Mensaje As String = ""

            Mensaje = Categoria.LoadComboBox(CmbCategoria)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim FacturaEncabezado As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptVentasXHoraXCategoria
        Dim FormaReporte As New FrmReporte
        Dim FechaIni As Date
        Dim FechaFin As Date
        Dim HoraIni As Date
        Dim HoraFin As Date
        Try
            Cursor.Current = Cursors.WaitCursor

            FechaIni = DateValue(DtpPFechaIni.Value)
            FechaFin = DateValue(DtpPFechaFin.Value)
            HoraIni = DpHoraIni.Value
            HoraFin = DpHoraFin.Value
            Mensaje = FacturaEncabezado.RptVentasxHoraxCategoria(FechaIni, FechaFin, IIf(CbkCategoria.Checked, CmbCategoria.SelectedValue, -1), HoraIni, HoraFin)
            VerificaMensaje(Mensaje)

            If FacturaEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(FacturaEncabezado.Data.Tables(0))

            If Form_Abierto("FrmReporte") = False Then
                VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
                Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))

                Reporte.SetParameterValue("pEmpresa", EmpresaInfo.Nombre)
                Reporte.SetParameterValue("pFechaDesde", DtpPFechaIni.Value.ToString("dd/MM/yyyy") + " " + DpHoraIni.Value.ToString("HH:mm:ss"))
                Reporte.SetParameterValue("pFechaHasta", DtpPFechaFin.Value.ToString("dd/MM/yyyy") + " " + DpHoraFin.Value.ToString("HH:mm:ss"))

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

    Private Function ValidaTodo() As Boolean 'Metodo de validar
        Try
            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Imprimir() 'Metodo de impresion 
        Try
            If ValidaTodo() Then
                MuestraReporte()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub

    Private Sub FrmRepVentasxCategoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Imprimir()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Imprimir()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub CbkCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles CbkCategoria.CheckedChanged
        Try
            CmbCategoria.Enabled = CbkCategoria.Checked
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class