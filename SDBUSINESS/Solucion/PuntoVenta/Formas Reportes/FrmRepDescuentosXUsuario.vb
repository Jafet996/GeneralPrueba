Imports Business

Public Class FrmRepDescuentosXUsuario

    Public Sub Execute()
        DtpPFechaIni.Value = DateValue(EmpresaInfo.Getdate())
        DtpPFechaFin.Value = DtpPFechaIni.Value

        Me.Text = "Descuentos por Usuario"
        Me.ShowDialog()
    End Sub
    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim FacturaEncabezado As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptDescuentoXUsuario
        Dim FormaReporte As New FrmReporte
        Dim FechaIni As Date
        Dim FechaFin As Date

        Try
            Cursor.Current = Cursors.WaitCursor

            FechaIni = DateValue(DtpPFechaIni.Value)
            FechaFin = DateValue(DtpPFechaFin.Value)


            Mensaje = FacturaEncabezado.RptDescuentosXUsuario(FechaIni, FechaFin)
                VerificaMensaje(Mensaje)

                If FacturaEncabezado.RowsAffected = 0 Then
                    VerificaMensaje("No se encontraron datos para mostrar el reporte")
                End If

            Reporte.SetDataSource(FacturaEncabezado.Data.Tables(0))
            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)

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

    Private Sub FrmRepDescuentosXUsuario_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Imprimir()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Me.Imprimir()
    End Sub
End Class