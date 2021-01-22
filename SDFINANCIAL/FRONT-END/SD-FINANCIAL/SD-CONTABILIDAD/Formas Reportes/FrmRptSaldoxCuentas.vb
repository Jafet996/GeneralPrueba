Imports BUSINESS
Public Class FrmRptSaldoxCuentas
    Public Sub Execute()
        CargaCombo()

        Me.ShowDialog()
    End Sub

    Private Sub CargaCombo()
        Try
            CargaComboAnnio(CmbAnnioIni)
            CargaComboAnnio(CmbAnnioFin)
            CargaComboMes(CmbMesIni)
            CargaComboMes(CmbMesFin)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If CInt(CmbAnnioIni.Text) > CInt(CmbAnnioFin.Text) Then
                VerificaMensaje("El periodo inicial no puede ser superior al final")
            End If

            If CInt(CmbAnnioIni.Text) = CInt(CmbAnnioFin.Text) Then
                If MesNumero(CmbMesIni.Text) > MesNumero(CmbMesFin.Text) Then
                    VerificaMensaje("El periodo inicial no puede ser superior al final")
                End If
            End If

            If TxtNivel.Value.ToString = "" Then
                TxtNivel.Focus()
                VerificaMensaje("Debe de seleccionar un nivel de cuenta")
            End If

            If TxtNivel.Value > 10 Or TxtNivel.Value < 0 Then
                TxtNivel.Focus()
                VerificaMensaje("Debe de ingresar un valor del 0 al 10 para el nivel de la cuenta")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub MuestraReporte()
        Dim Cuenta As New TCuenta
        Dim Reporte As New RptSaldoxCuentas
        Dim FormaReporte As New FrmReporte
        Dim AnnioIni As String = ""
        Dim MesIni As String = ""
        Dim AnnioFin As String = ""
        Dim MesFin As String = ""

        Try
            Cursor = Cursors.WaitCursor

            AnnioIni = CInt(CmbAnnioIni.Text.Trim)
            MesIni = MesNumero(CmbMesIni.Text.Trim)
            AnnioFin = CInt(CmbAnnioFin.Text.Trim)
            MesFin = MesNumero(CmbMesFin.Text).ToString

            With Cuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Nivel = TxtNivel.Value
            End With
            VerificaMensaje(Cuenta.RptSaldoxCuentas(AnnioIni, MesIni, AnnioFin, MesFin))

            If Cuenta.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(Cuenta.Datos.Tables(0))

            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Datos.Tables(0))
            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)

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

    Private Sub FrmRptSaldoxCuentas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnImprimir.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

End Class