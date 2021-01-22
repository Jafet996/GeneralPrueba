Imports Business
Public Class FrmRepComisionxVendedor
    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim Comision As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte
        Dim FormaReporte As New FrmReporte
        Dim FechaIni As Date
        Dim FechaFin As Date
        Try

            Cursor.Current = Cursors.WaitCursor

            FechaIni = DateValue(DtpPFechaIni.Value)
            FechaFin = DateAdd(DateInterval.Day, 1, DateValue(DtpPFechaFin.Value))
            Select Case CmbTipo.SelectedIndex
                Case 0
                    Mensaje = Comision.RptComisionxVendedor(FechaIni, FechaFin, IIf(ChkTodos.Checked, -1, CmbVendedor.SelectedValue))
                    Reporte = New RptComisionxVendedor()
                Case 1
                    Mensaje = Comision.RptComisionxProveedor(FechaIni, FechaFin, IIf(ChkTodos.Checked, -1, CmbVendedor.SelectedValue))
                    Reporte = New RptComisionXProveedor()
                Case 2
                    Mensaje = Comision.RptComisionxServicios(FechaIni, FechaFin, IIf(ChkTodos.Checked, -1, CmbVendedor.SelectedValue))
                    Reporte = New RptComisionXServicio()
            End Select

            VerificaMensaje(Mensaje)

            If Comision.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(Comision.Data.Tables(0))

            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))

            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)


            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            Comision = Nothing
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
    Public Sub CargaVendedores()
        Dim Vendedor As New TVendedor(EmpresaInfo.Emp_Id)
        Try
            VerificaMensaje(Vendedor.LoadComboBox(CmbVendedor))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Vendedor = Nothing
        End Try
    End Sub

    Public Sub Execute()
        Try
            DtpPFechaIni.Value = DateValue(EmpresaInfo.Getdate())
            DtpPFechaFin.Value = DtpPFechaIni.Value

            CargaVendedores()
            Me.CmbTipo.SelectedIndex = 0
            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub FrmRepVentasxCategoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Imprimir()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        Imprimir()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub ChkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTodos.CheckedChanged
        Try
            If ChkTodos.Checked Then
                CmbVendedor.Enabled = False
                CmbVendedor.SelectedValue = -1
            Else
                CmbVendedor.Enabled = True
                CmbVendedor.SelectedValue = 1
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub
End Class