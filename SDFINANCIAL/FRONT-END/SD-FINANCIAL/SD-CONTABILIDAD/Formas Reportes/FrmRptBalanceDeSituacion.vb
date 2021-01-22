Imports BUSINESS
Public Class FrmRptBalanceDeSituacion
    Public Sub Execute()
        CargaCombo()

        Me.ShowDialog()
    End Sub

    Private Sub CargaCombo()
        Try
            CargaComboAnnio(CmbAnnio)
            CargaComboMes(CmbMes)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If CmbAnnio.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar un periodo")
            End If

            If CmbMes.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar un periodo")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub MuestraReporte()
        Dim Cuenta As New TCuenta
        Dim Reporte As New RptBalanceDeSituacion
        Dim FormaReporte As New FrmReporte

        Try
            Cursor = Cursors.WaitCursor

            With Cuenta
                .Emp_Id = EmpresaInfo.Emp_Id
            End With
            VerificaMensaje(Cuenta.RptBalanceDeSituacion(CInt(CmbAnnio.Text.Trim), MesNumero(CmbMes.Text.Trim)))

            If Cuenta.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(Cuenta.Datos.Tables(0))
            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Datos.Tables(0))
            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("Titulo", "Al " & MaximoDiaMes(CInt(CmbAnnio.Text), MesNumero(CmbMes.Text)) & " de " & CmbMes.Text & " del " & CmbAnnio.Text)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            Cuenta = Nothing
            Cursor = Cursors.Default
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

    Private Sub FrmRptBalanceDeSituacion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnImprimir.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

End Class