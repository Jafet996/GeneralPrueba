Imports BUSINESS
Public Class FrmRptAsientosDeDiario
    Public Sub Execute()
        CargaCombo()

        Me.ShowDialog()
    End Sub

    Private Sub CargaCombo()
        Dim AsientoTipo As New TAsientoTipo
        Dim AsientoEstado As New TAsientoEstado
        Dim AsientoOrigen As New TAsientoOrigen

        Try
            VerificaMensaje(AsientoTipo.LoadComboBox(CmbTipoAsiento))
            VerificaMensaje(AsientoEstado.LoadComboBox(CmbEstado))
            VerificaMensaje(AsientoOrigen.LoadComboBox(CmbOrigen))

            CargaComboAnnio(CmbAnnio)
            CargaComboMes(CmbMes)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            AsientoTipo = Nothing
            AsientoEstado = Nothing
            AsientoOrigen = Nothing
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If Not ChkTipo.Checked And CmbTipoAsiento.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar un tipo de asiento")
            End If

            If Not ChkEstado.Checked And CmbEstado.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar un estado")
            End If

            If Not ChkOrigen.Checked And CmbOrigen.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar un origen")
            End If

            If ChkFechas.Checked Then
                If DateValue(DtpFechaInicio.Value) > DateValue(DtpFechaFinal.Value) Then
                    VerificaMensaje("La fecha de inicio debe ser menor o igual a la de finalización")
                End If
            End If

            If ChkPeriodo.Checked AndAlso CmbMes.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar un año del periodo")
            End If

            If ChkPeriodo.Checked AndAlso CmbAnnio.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar un mes del periodo")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub MuestraReporte()
        Dim AsientoEncabezado As New TAsientoEncabezado
        Dim Reporte As New RptAsientosDeDiario
        Dim FormaReporte As New FrmReporte
        Dim FechaIni As DateTime
        Dim FechaFin As DateTime

        Try
            Cursor = Cursors.WaitCursor

            FechaIni = DateValue(DtpFechaInicio.Value)
            FechaFin = DateAdd(DateInterval.Day, 1, DateValue(DtpFechaFinal.Value))

            With AsientoEncabezado
                .Emp_Id = EmpresaInfo.Emp_Id
                .Tipo_Id = IIf(ChkTipo.Checked, 0, CmbTipoAsiento.SelectedValue)
                .Annio = IIf(ChkPeriodo.Checked, CmbAnnio.Text, 0)
                .Mes = IIf(ChkPeriodo.Checked, MesNumero(CmbMes.Text), 0)
                .Estado_Id = IIf(ChkEstado.Checked, 0, CmbEstado.SelectedValue)
                .Origen_Id = IIf(ChkOrigen.Checked, 0, CmbOrigen.SelectedValue)
            End With
            VerificaMensaje(AsientoEncabezado.RptAsientosDeDiario(ChkFechas.Checked, FechaIni, FechaFin))

            If AsientoEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(AsientoEncabezado.Datos.Tables(0))
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

    Private Sub ChkTipo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTipo.CheckedChanged
        CmbTipoAsiento.Enabled = Not ChkTipo.Checked
    End Sub

    Private Sub ChkEstado_CheckedChanged(sender As Object, e As EventArgs) Handles ChkEstado.CheckedChanged
        CmbEstado.Enabled = Not ChkEstado.Checked
    End Sub

    Private Sub ChkOrigen_CheckedChanged(sender As Object, e As EventArgs) Handles ChkOrigen.CheckedChanged
        CmbOrigen.Enabled = Not ChkOrigen.Checked
    End Sub

    Private Sub ChkFechas_CheckedChanged(sender As Object, e As EventArgs) Handles ChkFechas.CheckedChanged
        DtpFechaInicio.Enabled = ChkFechas.Checked
        DtpFechaFinal.Enabled = ChkFechas.Checked
    End Sub

    Private Sub ChkPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPeriodo.CheckedChanged
        CmbAnnio.Enabled = ChkPeriodo.Checked
        CmbMes.Enabled = ChkPeriodo.Checked
    End Sub

End Class