Imports BUSINESS
Public Class FrmRptCambiosPatrimonio
#Region "Variables"
    Private _Modificando As Boolean = False
#End Region

    Public Sub Execute()
        CargaCombo()

        Me.ShowDialog()
    End Sub

    Private Sub CargaCombo()
        Try
            CargaComboAnnio(CmbAnnioFin)
            CargaComboAnnio(CmbAnnioIni)
            CargaComboMes(CmbMesFin)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If CmbAnnioIni.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar un periodo")
            End If

            If CmbAnnioFin.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar un periodo")
            End If

            If CmbMesFin.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar hasta que mes del periodo desea consultar")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub MuestraReporte()
        Dim Cuenta As New TCuenta
        Dim Reporte As New RptEstadoCambioPatrimonio
        Dim FormaReporte As New FrmReporte

        Try
            Cursor = Cursors.WaitCursor

            With Cuenta
                .Emp_Id = EmpresaInfo.Emp_Id
            End With
            VerificaMensaje(Cuenta.RptCambiosPatrimonio(CmbAnnioFin.Text, 10, CmbAnnioIni.Text, MesNumero(CmbMesFin.Text.Trim)))

            If Cuenta.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(Cuenta.Datos.Tables(0))
            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Datos.Tables(0))
            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("PeriodoInicio", "")
            Reporte.SetParameterValue("PeriodoFinal", "")

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

    Private Sub FrmRptCambiosPatrimonio_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnImprimir.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub CmbAnnioIni_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbAnnioIni.SelectedIndexChanged
        Try
            If _Modificando OrElse CmbAnnioFin.Items.Count = 0 Then
                Exit Sub
            End If

            _Modificando = True

            If CmbAnnioIni.SelectedIndex + 1 = CmbAnnioFin.Items.Count Then
                CmbAnnioFin.SelectedIndex = CmbAnnioIni.SelectedIndex
                CmbAnnioIni.SelectedIndex = CmbAnnioIni.SelectedIndex - 1
            Else
                CmbAnnioFin.SelectedIndex = CmbAnnioIni.SelectedIndex + 1
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            _Modificando = False
        End Try
    End Sub

    Private Sub CmbAnnioFin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbAnnioFin.SelectedIndexChanged
        Try
            If _Modificando OrElse CmbAnnioIni.Items.Count = 0 Then
                Exit Sub
            End If

            _Modificando = True

            If CmbAnnioFin.SelectedIndex - 1 < 0 Then
                CmbAnnioIni.SelectedIndex = 0
                CmbAnnioFin.SelectedIndex = 1
            Else
                CmbAnnioIni.SelectedIndex = CmbAnnioFin.SelectedIndex - 1
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            _Modificando = False
        End Try
    End Sub

End Class