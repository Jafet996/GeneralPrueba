Imports Business
Public Class FrmRepSaldosInventarioAgrupado
    Dim Numerico() As TNumericFormat

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(1)

            'Numerico(0) = New TNumericFormat(TxtCantidadM, 6, 2, False, "", "#,##0.00")
            'Numerico(1) = New TNumericFormat(TxtCantidadI, 6, 2, False, "", "#,##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LlenaCombos()
        Dim Sucursal As New TSucursal(EmpresaInfo.Emp_Id)
        Dim Proveedor As New TProveedor(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""

        Try
            Mensaje = Sucursal.LoadComboBox(CmbSucursal)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Proveedor = Nothing
            Sucursal = Nothing
        End Try
    End Sub

    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptSaldosInventarioCatSubCatDep
        Dim FormaReporte As New FrmReporte
        Dim Cantidad As Double = 0

        Try
            Cursor.Current = Cursors.WaitCursor



            With ArticuloBodega
                .Suc_Id = CInt(CmbSucursal.SelectedValue)
                .Bod_Id = CInt(CmbBodega.SelectedValue)
            End With

            Mensaje = ArticuloBodega.RptSaldosInventarioCatSubCatDep()
            VerificaMensaje(Mensaje)

            If ArticuloBodega.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(ArticuloBodega.Data.Tables(0))

            'parametros encabezado y pie de pagina

            Reporte.SetParameterValue("EmpresaNombre", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("SucursalNombre", CmbSucursal.Text)
            Reporte.SetParameterValue("BodegaNombre", CmbBodega.Text)

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
    Public Sub Execute()
        Try



            LlenaCombos()

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub FrmRepVentasxCategoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Imprimir()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Function ValidaTodo() As Boolean
        Try

            If CmbSucursal.SelectedValue Is Nothing OrElse Not IsNumeric(CmbSucursal.SelectedValue) Then
                VerificaMensaje("Debe de seleccionar una sucursal")
            End If

            If CmbBodega.SelectedValue Is Nothing OrElse Not IsNumeric(CmbBodega.SelectedValue) Then
                VerificaMensaje("Debe de seleccionar una bodega")
            End If

            'If Not IsNumeric(TxtCantidad.Text) OrElse CDbl(TxtCantidad.Text) <= 0 Then
            '    VerificaMensaje("La cantidad debe de ser mayor a cero")
            'End If


            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimir.Click
        Imprimir()
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmRepArticulosPromedioVenta_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FormateaCamposNumericos()
    End Sub

    Private Sub CmbSucursal_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles CmbSucursal.SelectedValueChanged
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

End Class