Imports BUSINESS

Public Class FrmRptComisionesPorVendedor
    Dim Vendedor As New TVendedor()

    Public Sub Execute()
        Inicializa()
        CargaCombos()
        Me.ShowDialog()
    End Sub

    Private Sub Inicializa()
        CbVendedores.Enabled = Not ChbTodos.Checked
    End Sub

    Private Sub CargaCombos()
        Try
            Vendedor.Emp_Id = EmpresaInfo.Emp_Id
            Vendedor.LoadComboBox(CbVendedores)

        Catch ex As Exception
            VerificaMensaje(ex.Message)
        End Try

    End Sub

    Private Sub Imprimir()
        If ValidaTodo() Then
            MuestraReporte()
        End If
    End Sub

    Private Function ValidaTodo() As Boolean
        If DpDesde.Value <= DpHasta.Value Then
            Return True
        Else
            Mensaje("La fecha final debe ser mayor o igual a inicial")
        End If
        Return False
    End Function

    Private Sub MuestraReporte()
        Dim Vendedor As New TVendedor
        Dim Reporte As New RptComisionesPorVendedor
        Dim FormaReporte As New FrmReporte
        Dim Desde As DateTime
        Dim Hasta As DateTime

        Try
            Cursor = Cursors.WaitCursor
            Desde = DpDesde.Value
            Hasta = DpHasta.Value

            With Vendedor
                .Emp_Id = EmpresaInfo.Emp_Id
                If ChbTodos.Checked Then
                    .Vendedor_Id = -1
                Else
                    .Vendedor_Id = CbVendedores.SelectedValue
                End If
            End With

            VerificaMensaje(Vendedor.RptComisionPorVendedor(DpDesde.Value, DpHasta.Value))

            If Vendedor.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(Vendedor.Datos.Tables(0))
            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Datos.Tables(0))
            Reporte.SetParameterValue("pEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("pFechaDesde", DpDesde.Value.ToString("dd-MM-yyyy"))
            Reporte.SetParameterValue("pFechaHasta", DpHasta.Value.ToString("dd-MM-yyyy"))

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            Vendedor = Nothing
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ChbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChbTodos.CheckedChanged
        CbVendedores.Enabled = Not ChbTodos.Checked
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Imprimir()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmRptComisionesPorVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnImprimir.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub
End Class