Imports BUSINESS

Public Class FrmRptCobrosPorFechas

    Public Sub Execute()
        Me.ShowDialog()
    End Sub

    Private Function ValidaTodo() As Boolean
        If DpDesde.Value <= DpHasta.Value And ((Not CbCliente.Checked And Not TxtNombre.Equals("") And Not TxtCodigoCliente.Equals("")) Or CbCliente.Checked) Then
            Return True
        End If
        Return False
    End Function

    Private Sub MuestraReporte()
        Dim Movimiento As New TCxCMovimiento
        Dim Reporte
        Dim FormaReporte As New FrmReporte
        Dim Desde As DateTime
        Dim Hasta As DateTime

        Try

            Reporte = New RptCxCCobrosPorFechas()

            Cursor = Cursors.WaitCursor
            Desde = DpDesde.Value
            Hasta = DpDesde.Value

            With Movimiento
                .Emp_Id = EmpresaInfo.Emp_Id

            End With

            If CbCliente.Checked Then
                Movimiento.Cliente_Id = -1
            Else
                Movimiento.Cliente_Id = TxtCodigoCliente.Text
            End If

            VerificaMensaje(Movimiento.RptCxCCobrosPorFechas(DpDesde.Value, DpHasta.Value))

            If Movimiento.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(Movimiento.Datos.Tables(0))
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
            Movimiento = Nothing
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Imprimir()
        If ValidaTodo() Then
            MuestraReporte()
        End If
    End Sub


    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Imprimir()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmRptCobrosPorFechas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnImprimir.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub CbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles CbCliente.CheckedChanged
        TxtCodigoCliente.Enabled = Not CbCliente.Checked
    End Sub

    Private Sub TxtCodigoCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigoCliente.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    BuscaCliente()
                Case Keys.Enter
                    VerificaMensaje(CargaCliente)
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function CargaCliente() As String
        Dim Cliente As New TCliente

        Try
            If TxtCodigoCliente.Text.Trim = "" OrElse CInt(TxtCodigoCliente.Text.Trim) <= 0 Then
                Return String.Empty
            End If

            With Cliente
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cliente_Id = CInt(TxtCodigoCliente.Text.Trim)
            End With
            VerificaMensaje(Cliente.ListKey)

            If Cliente.RowsAffected = 0 Then
                EnfocarTexto(TxtCodigoCliente)
                VerificaMensaje("No se encontró un cliente con el código: " & TxtCodigoCliente.Text.Trim)
            End If

            If Not Cliente.Activo Then
                EnfocarTexto(TxtCodigoCliente)
                VerificaMensaje("El cliente seleccionado se encuentra inactivo")
            End If

            TxtNombre.Text = Cliente.Nombre

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Cliente = Nothing
        End Try
    End Function

    Private Sub BuscaCliente()
        Dim Forma As New FrmBusquedaCliente

        Try
            Forma.Execute()

            If Forma.Selecciono Then
                TxtCodigoCliente.Text = Forma.Cliente_Id
                VerificaMensaje(CargaCliente)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub


End Class