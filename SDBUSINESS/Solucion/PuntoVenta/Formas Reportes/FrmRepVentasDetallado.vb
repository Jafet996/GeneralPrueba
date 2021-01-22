Imports Business
Public Class FrmRepVentasDetallado
    Private Sub CargaSucursal()
        Dim Sucursal As New TSucursal(EmpresaInfo.Emp_Id)
        Try

            VerificaMensaje(Sucursal.LoadComboBox(CmbSucursal))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Sucursal = Nothing
        End Try
    End Sub

    Public Sub Execute()
        Try

            CargaSucursal()

            DtpPFechaIni.Value = DateValue(EmpresaInfo.Getdate())
            DtpPFechaFin.Value = DtpPFechaIni.Value

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim FacturaEncabezado As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte
        Dim FormaReporte As New FrmReporte
        Dim FechaIni As Date
        Dim FechaFin As Date

        Try
            Cursor.Current = Cursors.WaitCursor


            If PrintLocation.PCW = InfoMaquina.PrintLocation Then

                Reporte = New RptFacturasDetalladoPCW

            ElseIf PrintLocation.Tectel = InfoMaquina.PrintLocation Then

                Reporte = New RptFacturasDetalladoTECTEL

                'ElseIf PrintLocation.CarnesGarroyRetana = InfoMaquina.PrintLocation Then
            ElseIf InfoMaquina.IdentificadorId = "SDG-CGR" Then

                Reporte = New RptFacturasDetalladoCG
            Else
                Reporte = New RptFacturasDetallado

            End If




            FechaIni = DateValue(DtpPFechaIni.Value)
            FechaFin = DateAdd(DateInterval.Day, 1, DateValue(DtpPFechaFin.Value))

            With FacturaEncabezado
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = CmbSucursal.SelectedValue
            End With

            If InfoMaquina.IdentificadorId = "SDG-CGR" Then

                Mensaje = FacturaEncabezado.RptFacturasDetalladoCR(FechaIni, FechaFin)
            Else
                Mensaje = FacturaEncabezado.RptFacturasDetallado(FechaIni, FechaFin)
            End If

            VerificaMensaje(Mensaje)

            If FacturaEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(FacturaEncabezado.Data.Tables(0))
            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("NombreSucursal", CmbSucursal.Text)

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