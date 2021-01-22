Imports Business
Public Class FrmRepCierreCaja
    Public Sub Execute()
        Me.Text = "Reportes"
        LlenaCombos()

        Me.ShowDialog()
    End Sub
    Private Sub LlenaCombos()
        Dim Sucursal As New TSucursal(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            CmbReporte.SelectedIndex = 0
            Mensaje = Sucursal.LoadComboBox(CmbSucursal)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Sucursal = Nothing
        End Try
    End Sub
    Private Function ValidaTodo() As Boolean
        Try

            If CmbSucursal.SelectedValue Is Nothing OrElse Not IsNumeric(CmbSucursal.SelectedValue) Then
                VerificaMensaje("Debe de seleccionar una sucursal")
            End If

            If CmbCaja.SelectedValue Is Nothing OrElse Not IsNumeric(CmbCaja.SelectedValue) Then
                VerificaMensaje("Debe de seleccionar una caja")
            End If
            If CmbCierre.SelectedValue Is Nothing OrElse Not IsNumeric(CmbCaja.SelectedValue) Then
                VerificaMensaje("Debe de seleccionar un cierre")
            End If
            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function
    Private Sub CmbSucursal_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles CmbSucursal.SelectedValueChanged
        Dim Caja As New TCaja(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            If Not IsNumeric(CmbSucursal.SelectedValue) Then
                Exit Sub
            End If

            Caja.Suc_Id = CInt(CmbSucursal.SelectedValue)
            Mensaje = Caja.CargaComboBox(CmbCaja)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Caja = Nothing
        End Try
    End Sub

    Private Sub CmbCaja_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbCaja.SelectedValueChanged
        Dim CajaCierreEncabezado As New TCajaCierreEncabezado(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            If Not IsNumeric(CmbCaja.SelectedValue) Then
                Exit Sub
            End If

            With CajaCierreEncabezado
                .Suc_Id = CmbSucursal.SelectedValue
                .Caja_Id = CmbCaja.SelectedValue
            End With
            Mensaje = CajaCierreEncabezado.CargaCierre(CmbCierre)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CajaCierreEncabezado = Nothing
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
    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim Cierre As New TCajaCierreEncabezado(EmpresaInfo.Emp_Id)
        Dim ReporteCierre As New RptCierreCajaCSM
        Dim ReporteVentas As New RptVentasContadoCSM
        Dim FormaReporte As New FrmReporte

        Try
            Cursor.Current = Cursors.WaitCursor
            With Cierre
                .Suc_Id = CmbSucursal.SelectedValue
                .Caja_Id = CmbCaja.SelectedValue
                .Cierre_Id = CmbCierre.SelectedValue
            End With

            Mensaje = Cierre.RptCierreCajaCSM(CmbReporte.SelectedIndex + 1)
            VerificaMensaje(Mensaje)

            If Cierre.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            If (CmbReporte.SelectedIndex + 1 = 1) Then

                VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
                ReporteCierre.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))
                ReporteCierre.SetDataSource(Cierre.Data.Tables(0))
                ReporteCierre.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
                ReporteCierre.SetParameterValue("Sucursal", CmbSucursal.Text)
                ReporteCierre.SetParameterValue("Caja", CmbCaja.Text)

                If Form_Abierto("FrmReporte") = False Then
                    FormaReporte.Execute(ReporteCierre)
                End If
            End If
            If (CmbReporte.SelectedIndex + 1 = 2) Then
                VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
                ReporteVentas.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))
                ReporteVentas.SetDataSource(Cierre.Data.Tables(0))
                ReporteVentas.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
                ReporteVentas.SetParameterValue("Sucursal", CmbSucursal.Text)
                ReporteVentas.SetParameterValue("tipoVentas", "Contado")

                If Form_Abierto("FrmReporte") = False Then
                    FormaReporte.Execute(ReporteVentas)
                End If

            End If
            If (CmbReporte.SelectedIndex + 1 = 3) Then
                VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
                ReporteVentas.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))
                ReporteVentas.SetDataSource(Cierre.Data.Tables(0))
                ReporteVentas.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
                ReporteVentas.SetParameterValue("Sucursal", CmbSucursal.Text)
                ReporteVentas.SetParameterValue("tipoVentas", "Crédito")

                If Form_Abierto("FrmReporte") = False Then
                    FormaReporte.Execute(ReporteVentas)
                End If

            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            Cierre = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Imprimir()
    End Sub
End Class