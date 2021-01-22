Imports Business
Public Class FrmRepKardexDetallado
    Public Sub Execute()
        Try

            LlenaCombos()
            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub LlenaCombos()
        Dim Sucursal As New TSucursal(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""

        Try
            Mensaje = Sucursal.LoadComboBox(CmbSucursal)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Sucursal = Nothing
        End Try
    End Sub


    Private Sub CmbSucursal_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbSucursal.SelectedValueChanged
        Dim Bodega As New TBodega(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            If Not IsNumeric(CmbSucursal.SelectedValue) Then
                Exit Sub
            End If

            Bodega.Suc_Id = CInt(CmbSucursal.SelectedValue)
            Mensaje = Bodega.LoadComboBox(CmbBodega)
            VerificaMensaje(Mensaje)


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Bodega = Nothing
        End Try
    End Sub

    Private Sub CmbSucursal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSucursal.SelectedIndexChanged

    End Sub

    Private Sub CmbBodega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBodega.SelectedIndexChanged

    End Sub

    Private Sub CmbBodega_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbBodega.SelectedValueChanged
        Dim ArticuloBodegaHistoricoEncabezado As New TArticuloBodegaHistoricoEncabezado(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            CmbFechaCorte.DataSource = Nothing
            CmbFechaCorte.Items.Clear()

            If Not IsNumeric(CmbSucursal.SelectedValue) Or Not IsNumeric(CmbBodega.SelectedValue) Then
                Exit Sub
            End If
            With ArticuloBodegaHistoricoEncabezado
                .Suc_Id = CInt(CmbSucursal.SelectedValue)
                .Bod_Id = CInt(CmbBodega.SelectedValue)
            End With

            Mensaje = ArticuloBodegaHistoricoEncabezado.LoadComboBox(CmbFechaCorte)
            VerificaMensaje(Mensaje)


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloBodegaHistoricoEncabezado = Nothing
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Dim ArticuloBodegaHistoricoEncabezado As New TArticuloBodegaHistoricoEncabezado(EmpresaInfo.Emp_Id)
        Try

            If CmbSucursal.SelectedValue Is Nothing OrElse Not IsNumeric(CmbSucursal.SelectedValue) Then
                VerificaMensaje("Debe de seleccionar una sucursal")
            End If

            If CmbBodega.SelectedValue Is Nothing OrElse Not IsNumeric(CmbBodega.SelectedValue) Then
                VerificaMensaje("Debe de seleccionar una bodega")
            End If

            If CmbFechaCorte.SelectedValue Is Nothing OrElse Not IsNumeric(CmbFechaCorte.SelectedValue) Then
                VerificaMensaje("Debe de seleccionar una fecha de corte")
            End If

            'With ArticuloBodegaHistoricoEncabezado
            '    .Suc_Id = CmbSucursal.SelectedValue
            '    .Bod_Id = CmbBodega.SelectedValue
            '    .Historico_Id = CmbFechaCorte.SelectedValue
            'End With

            'VerificaMensaje(ArticuloBodegaHistoricoEncabezado.ListKey())

            'If Format(ArticuloBodegaHistoricoEncabezado.Fecha, "yyyyMMdd") >= Format(DtpFechaFinal.Value, "yyyyMMdd") Then
            '    VerificaMensaje("La fecha final debe de ser mayor a la fecha inicial")
            'End If


            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        Finally
            ArticuloBodegaHistoricoEncabezado = Nothing
        End Try
    End Function


    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim ArticuloBodegaHistoricoEncabezado As New TArticuloBodegaHistoricoEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptKardexDetallado
        Dim ReporteReversa As New RptReversaKardex
        Dim FormaReporte As New FrmReporte
        Dim Cantidad As Double = 0
        Dim FechaFinal As Date
        Try
            Cursor.Current = Cursors.WaitCursor

            With ArticuloBodegaHistoricoEncabezado
                .Suc_Id = CInt(CmbSucursal.SelectedValue)
                .Bod_Id = CInt(CmbBodega.SelectedValue)
                .Historico_Id = CLng(CmbFechaCorte.SelectedValue)
            End With


            VerificaMensaje(ArticuloBodegaHistoricoEncabezado.ListKey())
            If Format(ArticuloBodegaHistoricoEncabezado.Fecha, "yyyyMMdd") <= Format(DtpFechaFinal.Value, "yyyyMMdd") Then

                FechaFinal = DateAdd(DateInterval.Day, 1, DtpFechaFinal.Value)



                Mensaje = ArticuloBodegaHistoricoEncabezado.RptKardexInventario(IIf(ChkSoloConMovimiento.Checked, 1, 0), FechaFinal)
                VerificaMensaje(Mensaje)

                If ArticuloBodegaHistoricoEncabezado.RowsAffected = 0 Then
                    VerificaMensaje("No se encontraron datos para mostrar el reporte")
                End If

                Reporte.SetDataSource(ArticuloBodegaHistoricoEncabezado.Data.Tables(0))

                'parametros encabezado y pie de pagina

                Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
                Reporte.SetParameterValue("NombreSucursal", CmbSucursal.Text)
                Reporte.SetParameterValue("NombreBodega", CmbBodega.Text)

                If Form_Abierto("FrmReporte") = False Then
                    FormaReporte.Execute(Reporte)
                End If

            Else

                FechaFinal = DtpFechaFinal.Value



                Mensaje = ArticuloBodegaHistoricoEncabezado.RptReversarKardex(IIf(ChkSoloConMovimiento.Checked, 1, 0), FechaFinal)
                VerificaMensaje(Mensaje)

                If ArticuloBodegaHistoricoEncabezado.RowsAffected = 0 Then
                    VerificaMensaje("No se encontraron datos para mostrar el reporte")
                End If

                ReporteReversa.SetDataSource(ArticuloBodegaHistoricoEncabezado.Data.Tables(0))

                'parametros encabezado y pie de pagina

                ReporteReversa.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
                ReporteReversa.SetParameterValue("NombreSucursal", CmbSucursal.Text)
                ReporteReversa.SetParameterValue("NombreBodega", CmbBodega.Text)

                If Form_Abierto("FrmReporte") = False Then
                    FormaReporte.Execute(ReporteReversa)
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            ArticuloBodegaHistoricoEncabezado = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Try
            If ValidaTodo() Then
                MuestraReporte()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmRepKardexDetallado_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnImprimir.PerformClick()
        End Select
    End Sub
End Class