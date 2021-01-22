Imports BUSINESS
Public Class FrmRptBalanceDeComprobacion
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
        Finally
        End Try
    End Sub

    Private Sub BusquedaCuenta(pTextBox As MaskedTextBox)
        Dim Forma As New FrmBusquedaCuentaContable

        Try
            Forma.Execute()

            If Forma.Selecciono Then
                pTextBox.Text = Forma.Cuenta_Id
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try

            If RdbCuentaRango.Checked Then
                If TxtCuentaIni.Text.Trim = "" Then
                    VerificaMensaje("Debe de ingresar una cuenta de inicio")
                End If

                If TxtCuentaFin.Text.Trim = "" Then
                    VerificaMensaje("Debe de ingresar una cuenta final")
                End If
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub MuestraReporte()
        Dim Cuenta As New TCuenta
        Dim Reporte As New RptBalanceDeComprobacion
        Dim FormaReporte As New FrmReporte
        Dim CuentaIni As String = ""
        Dim CuentaFin As String = ""

        Try
            Cursor = Cursors.WaitCursor

            If RdbCuentaRango.Checked Then
                CuentaIni = DepuraNumeroCuenta(TxtCuentaIni.Text.Trim)
                CuentaFin = DepuraNumeroCuenta(TxtCuentaFin.Text.Trim)
            End If

            With Cuenta
                .Emp_Id = EmpresaInfo.Emp_Id
            End With
            VerificaMensaje(Cuenta.RptBalanceDeComprobacion(CInt(CmbAnnio.Text.Trim), MesNumero(CmbMes.Text.Trim), CuentaIni, CuentaFin))

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

    Private Sub RdbCuentaRango_CheckedChanged(sender As Object, e As EventArgs) Handles RdbCuentaRango.CheckedChanged
        TxtCuentaIni.Enabled = RdbCuentaRango.Checked
        TxtCuentaFin.Enabled = RdbCuentaRango.Checked
    End Sub

    Private Sub TxtCuentaIni_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCuentaIni.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                BusquedaCuenta(TxtCuentaIni)
        End Select
    End Sub

    Private Sub TxtCuentaFin_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCuentaFin.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                BusquedaCuenta(TxtCuentaFin)
        End Select
    End Sub

    Private Sub FrmRptConsultaMovimientoCuenta_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnImprimir.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

End Class