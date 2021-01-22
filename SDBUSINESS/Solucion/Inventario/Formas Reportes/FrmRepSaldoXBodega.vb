Imports Business
Public Class FrmRepSaldoXBodega

    Public Sub Execute()
        CargaComboSucursal()

        Me.ShowDialog()
    End Sub

    Private Sub CargaComboSucursal()
        Dim Sucursal As New TSucursal(EmpresaInfo.Emp_Id)

        Try
            VerificaMensaje(Sucursal.LoadComboBox(CmbSucursal))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Sucursal = Nothing
        End Try
    End Sub

    Private Sub CargaComboBodega()
        Dim Bodega As New TBodega(EmpresaInfo.Emp_Id)

        Try
            If CmbSucursal.SelectedValue Is Nothing OrElse CmbSucursal.SelectedValue.ToString = "System.Data.DataRowView" Then
                Exit Sub
            End If

            Bodega.Suc_Id = CmbSucursal.SelectedValue
            VerificaMensaje(Bodega.LoadComboBox(CmbBodega))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Bodega = Nothing
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If CmbSucursal.SelectedValue Is Nothing OrElse Not IsNumeric(CmbSucursal.SelectedValue) Then
                VerificaMensaje("Debe de seleccionar una sucursal")
            End If

            If CmbBodega.SelectedValue Is Nothing OrElse Not IsNumeric(CmbBodega.SelectedValue) Then
                VerificaMensaje("Debe de seleccionar una bodega")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub MuestraReporte()
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptSaldosXBodega
        Dim FormaReporte As New FrmReporte
        Dim pNegativos As Integer

        If CkSaldos.Checked = True Then
            pNegativos = 1
        Else
            pNegativos = 0
        End If

        Try
            Cursor.Current = Cursors.WaitCursor

            With ArticuloBodega
                .Suc_Id = CInt(CmbSucursal.SelectedValue)
                .Bod_Id = CInt(CmbBodega.SelectedValue)

            End With

            VerificaMensaje(ArticuloBodega.RptSaldosXBodega(pNegativos))

            If ArticuloBodega.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(ArticuloBodega.Data.Tables(0))

            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))

            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("NombreSucursal", CmbSucursal.Text)
            Reporte.SetParameterValue("NombreBodega", CmbBodega.Text)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            ArticuloBodega = Nothing
            Cursor.Current = Cursors.Default
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

    Private Sub CmbSucursal_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbSucursal.SelectedValueChanged
        CargaComboBodega()
    End Sub

    Private Sub FrmRepSaldoXBodega_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnImprimir.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

End Class