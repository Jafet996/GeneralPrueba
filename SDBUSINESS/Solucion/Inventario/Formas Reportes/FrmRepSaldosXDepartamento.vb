Imports Business
Public Class FrmRepSaldosXDepartamento
    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim Saldo As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptSaldosXDepartamento
        Dim FormaReporte As New FrmReporte
        Try

            Cursor.Current = Cursors.WaitCursor

            Mensaje = Saldo.RptSaldosXDepartamento(IIf(CbkDepartamento.Checked, CmbDepartamento.SelectedValue, -1))
            VerificaMensaje(Mensaje)

            If Saldo.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(Saldo.Data.Tables(0))

            'parametros encabezado y pie de pagina

            Reporte.SetParameterValue("pEmpresa", EmpresaInfo.Nombre)


            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            Saldo = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If CmbDepartamento.SelectedValue Is Nothing Then
                CmbDepartamento.Focus()
                VerificaMensaje("Debe de seleccionar un valor")
            End If

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

    Private Sub CargarCombos()
        Dim Departamento As New TDepartamento(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            Mensaje = Departamento.LoadComboBox(CmbDepartamento)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Departamento = Nothing
        End Try
    End Sub

    Public Sub Execute()

        CargarCombos()

        Me.ShowDialog()
    End Sub
    Private Sub FrmRepVentasxCategoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Imprimir()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimir.Click
        Imprimir()
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub CbkDepartamento_CheckedChanged(sender As Object, e As EventArgs) Handles CbkDepartamento.CheckedChanged
        Try
            CmbDepartamento.Enabled = CbkDepartamento.Checked
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class