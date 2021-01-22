Imports BUSINESS
Public Class FrmRptConsultaMovimientoCuenta
    Public Sub Execute()
        CargaCombo()

        Me.ShowDialog()
    End Sub

    Private Sub CargaCombo()
        Dim AsientoTipo As New TAsientoTipo
        Dim AsientoOrigen As New TAsientoOrigen

        Try
            VerificaMensaje(AsientoTipo.LoadComboBox(CmbTipoAsiento))
            VerificaMensaje(AsientoOrigen.LoadComboBox(CmbOrigen))

            CargaComboAnnio(CmbAnnioIni)
            CargaComboAnnio(CmbAnnioFin)
            CargaComboMes(CmbMesIni)
            CargaComboMes(CmbMesFin)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            AsientoTipo = Nothing
            AsientoOrigen = Nothing
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
            If Not ChkTipo.Checked And CmbTipoAsiento.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar un tipo de asiento")
            End If

            If Not ChkOrigen.Checked And CmbOrigen.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar un origen")
            End If

            If CInt(CmbAnnioIni.Text) > CInt(CmbAnnioFin.Text) Then
                VerificaMensaje("El periodo inicial no puede ser superior al final")
            End If

            If CInt(CmbAnnioIni.Text) = CInt(CmbAnnioFin.Text) Then
                If MesNumero(CmbMesIni.Text) > MesNumero(CmbMesFin.Text) Then
                    VerificaMensaje("El periodo inicial no puede ser superior al final")
                End If
            End If

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
        Dim AsientoEncabezado As New TAsientoEncabezado
        Dim Reporte As New RptConsultaMovimientoCuenta
        Dim FormaReporte As New FrmReporte
        Dim AnnioFin As String = ""
        Dim MesFin As String = ""
        Dim CuentaIni As String = ""
        Dim CuentaFin As String = ""

        Try
            Cursor = Cursors.WaitCursor

            AnnioFin = CmbAnnioFin.Text.Trim
            MesFin = MesNumero(CmbMesFin.Text).ToString

            If RdbCuentaRango.Checked Then
                CuentaIni = DepuraNumeroCuenta(TxtCuentaIni.Text.Trim)
                CuentaFin = DepuraNumeroCuenta(TxtCuentaFin.Text.Trim)
            End If

            With AsientoEncabezado
                .Emp_Id = EmpresaInfo.Emp_Id
                .Tipo_Id = IIf(ChkTipo.Checked, 0, CmbTipoAsiento.SelectedValue)
                .Annio = CInt(CmbAnnioIni.Text.Trim)
                .Mes = MesNumero(CmbMesIni.Text.Trim)
                .Origen_Id = IIf(ChkOrigen.Checked, 0, CmbOrigen.SelectedValue)
            End With
            VerificaMensaje(AsientoEncabezado.RptConsultaMovimientoCuenta(AnnioFin, MesFin, CuentaIni, CuentaFin))

            If AsientoEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(AsientoEncabezado.Datos.Tables(0))
            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("TituloReporte", "Movimientos de " & CmbMesIni.Text & ", " & CmbAnnioIni.Text & " hasta " & CmbMesFin.Text & ", " & CmbAnnioFin.Text)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            AsientoEncabezado = Nothing
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

    Private Sub ChkTipo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTipo.CheckedChanged
        CmbTipoAsiento.Enabled = Not ChkTipo.Checked
    End Sub

    Private Sub ChkOrigen_CheckedChanged(sender As Object, e As EventArgs) Handles ChkOrigen.CheckedChanged
        CmbOrigen.Enabled = Not ChkOrigen.Checked
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