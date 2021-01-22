Imports Business

Public Class FrmRepCostoVentaxFactura

    Public Sub Execute()
        Try
            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
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
        Dim Reporte As New RptCostoVentaxFactura
        Dim FormaReporte As New FrmReporte
        Dim FacturaEncabezado As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim FechaIni As Date
        Dim FechaFin As Date

        Try

            Cursor.Current = Cursors.WaitCursor

            FechaIni = DateValue(DtpPFechaIni.Value)
            FechaFin = DateAdd(DateInterval.Day, 1, DateValue(DtpPFechaFin.Value))



            VerificaMensaje(FacturaEncabezado.RptCostoVentaxFactura(FechaIni, FechaFin))

            If FacturaEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(FacturaEncabezado.Data.Tables(0))

            'parametros encabezado y pie de pagina

            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("Desde", DtpPFechaIni.Value)
            Reporte.SetParameterValue("Hasta", DtpPFechaFin.Value)
            'Reporte.SetParameterValue("TelefonoSucursal", SucursalInfo.Telefono)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Function ValidaTodo() As Boolean
        Try

            Return True

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Try
            Imprimir()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub
End Class