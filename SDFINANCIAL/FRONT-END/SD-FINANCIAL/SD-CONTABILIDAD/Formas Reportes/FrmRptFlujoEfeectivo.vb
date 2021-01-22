Imports BUSINESS
Public Class FrmRptFlujoEfeectivo
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

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub MuestraReporte()
        Dim AsientoEncabezado As New TAsientoEncabezado
        Dim Reporte As New RptFlujoEfeectivo
        Dim FormaReporte As New FrmReporte
        Dim AnnioIni As String = ""
        Dim MesIni As String = ""
        Dim AnnioFin As String = ""
        Dim MesFin As String = ""

        Try
            Cursor = Cursors.WaitCursor

            AnnioIni = CmbAnnioIni.Text.Trim
            MesIni = MesNumero(CmbMesIni.Text.Trim)
            AnnioFin = CmbAnnioFin.Text.Trim
            MesFin = MesNumero(CmbMesFin.Text).ToString

            With AsientoEncabezado
                .Emp_Id = EmpresaInfo.Emp_Id
            End With
            VerificaMensaje(AsientoEncabezado.RptFlujoEfeectivo(AnnioIni, MesIni, AnnioFin, MesFin))

            If AsientoEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(AsientoEncabezado.Datos.Tables(0))
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

    Private Sub FrmRptFlujoEfeectivo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnImprimir.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

End Class