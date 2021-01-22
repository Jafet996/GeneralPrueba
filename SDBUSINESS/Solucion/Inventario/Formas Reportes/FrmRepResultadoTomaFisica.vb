Imports Business
Public Class FrmRepResultadoTomaFisica

    Private Sub LlenaCombos()
        Dim Sucursal As New TBodega(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            Sucursal.Suc_Id = SucursalInfo.Suc_Id
            Mensaje = Sucursal.LoadComboBox(CmbBodega)
            'VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Sucursal = Nothing
        End Try
    End Sub
    Private Sub CmbBodega_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbBodega.SelectedValueChanged
        Dim Sucursal As New TTomaFisicaEncabezado(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            Sucursal.Suc_Id = SucursalInfo.Suc_Id
            Mensaje = Sucursal.LoadComboBox(CmbToma)
            'VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Sucursal = Nothing
        End Try
    End Sub
    Public Sub Execute()
        Try
            LlenaCombos()
            Me.Text = "Resultados Toma Física"
            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim TomaFisicaEncabezado As New TTomaFisicaEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptResultadosTomaFisica
        Dim FormaReporte As New FrmReporte

        Try
            Cursor.Current = Cursors.WaitCursor

            With TomaFisicaEncabezado
                .Suc_Id = SucursalInfo.Suc_Id
                .Bod_Id = CInt(CmbBodega.SelectedValue)
                .TomaFisica_Id = CInt(CmbToma.SelectedValue)

            End With

            Mensaje = TomaFisicaEncabezado.RptTomaFisicaResultado()
            VerificaMensaje(Mensaje)

            If TomaFisicaEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(TomaFisicaEncabezado.Data.Tables(0))

            'parametros encabezado y pie de pagina

            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("NombreSucursal", SucursalInfo.Nombre)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            TomaFisicaEncabezado = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Sub Imprimir()
        Try
            MuestraReporte()
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
    Private Sub FrmRepResultadoTomaFisica_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Imprimir()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub


End Class