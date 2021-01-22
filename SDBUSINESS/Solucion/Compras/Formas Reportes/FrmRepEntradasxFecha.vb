Imports Business
Public Class FrmRepEntradasxFecha
    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim EntradaEncabezado As New TEntradaEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptEntradasxFecha
        Dim FormaReporte As New FrmReporte
        Dim FechaIni As Date
        Dim FechaFin As Date
        Try

            Cursor.Current = Cursors.WaitCursor

            FechaIni = DateValue(DtpPFechaIni.Value)
            FechaFin = DateAdd(DateInterval.Day, 1, DateValue(DtpPFechaFin.Value))


            With EntradaEncabezado
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
            End With

            Mensaje = EntradaEncabezado.RptEntradaMercaderiaxFecha(FechaIni, FechaFin)
            VerificaMensaje(Mensaje)

            If EntradaEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(EntradaEncabezado.Data.Tables(0))

            'parametros encabezado y pie de pagina

            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("NombreSucursal", SucursalInfo.Nombre)
            'Reporte.SetParameterValue("TelefonoSucursal", SucursalInfo.Telefono)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            EntradaEncabezado = Nothing
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



    Public Sub Execute()

        DtpPFechaIni.Value = DateValue(EmpresaInfo.Getdate())
        DtpPFechaFin.Value = DtpPFechaIni.Value

        Me.ShowDialog()
    End Sub
    Private Sub FrmRepVentasxCategoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
End Class