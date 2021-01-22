Imports Business
Public Class FrmRepVentasEmpresa
    Public Sub Execute()
        DtpPFechaIni.Value = DateValue(EmpresaInfo.Getdate())
        DtpPFechaFin.Value = DtpPFechaIni.Value

        Me.ShowDialog()
    End Sub
    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim FacturaEncabezado As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptVentasEmpresa
        'Dim ReporteCR As New RptVentasEmpresaCR 'CGR
        Dim ReporteResumido As New RptVentasEmpresaResumido
        Dim FormaReporte As New FrmReporte
        Dim ReporteVentasCR As New RptVentasEmpresaCR
        Dim FechaIni As Date
        Dim FechaFin As Date

        Try
            Cursor.Current = Cursors.WaitCursor

            FechaIni = DateValue(DtpPFechaIni.Value)
            FechaFin = DateValue(DtpPFechaFin.Value)

            'MIKE 13/11/2020
            If ckbResumido.Checked = 0 Then
                If InfoMaquina.IdentificadorId = "SDG-CGR" Then
                    Mensaje = FacturaEncabezado.RptVentasDetalladoXEmpresa_CR(FechaIni, FechaFin)

                Else
                    Mensaje = FacturaEncabezado.RptVentasDetalladoXEmpresa(FechaIni, FechaFin)
                End If

                VerificaMensaje(Mensaje)

                If FacturaEncabezado.RowsAffected = 0 Then
                    VerificaMensaje("No se encontraron datos para mostrar el reporte")
                End If

                Reporte.SetDataSource(FacturaEncabezado.Data.Tables(0))
                ReporteVentasCR.SetDataSource(FacturaEncabezado.Data.Tables(0))


                If Form_Abierto("FrmReporte") = False Then
                    If InfoMaquina.IdentificadorId = "SDG-CGR" Then


                        FormaReporte.Execute(ReporteVentasCR)
                    Else
                        FormaReporte.Execute(Reporte)
                    End If


                End If
            Else
                Mensaje = FacturaEncabezado.RptVentasResumidoXEmpresa(FechaIni, FechaFin)
                    VerificaMensaje(Mensaje)

                    If FacturaEncabezado.RowsAffected = 0 Then
                        VerificaMensaje("No se encontraron datos para mostrar el reporte")
                    End If

                    ReporteResumido.SetDataSource(FacturaEncabezado.Data.Tables(0))


                    If Form_Abierto("FrmReporte") = False Then
                        FormaReporte.Execute(ReporteResumido)
                    End If
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
End Class