Imports Business
Public Class FrmRepReposicionInventario


    Dim Numerico() As TNumericFormat


    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            'Numerico(0) = New TNumericFormat(TxtCantidad, 6, 2, False, "", "#,##0.00")


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

    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptReposicionInventario
        Dim FormaReporte As New FrmReporte
        Dim Cantidad As Double = 0

        Try

            Cursor.Current = Cursors.WaitCursor



            With ArticuloBodega
                .Suc_Id = CInt(CmbSucursal.SelectedValue)
                .Bod_Id = CInt(CmbBodega.SelectedValue)
            End With

            Mensaje = ArticuloBodega.RptInventarioReposicion(DateValue(DtpDesde.Value), DateValue(DateAdd(DateInterval.Day, 1, DtpHasta.Value)))
            VerificaMensaje(Mensaje)

            If ArticuloBodega.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(ArticuloBodega.Data.Tables(0))

            'parametros encabezado y pie de pagina

            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("NombreSucursal", SucursalInfo.Nombre)
            Reporte.SetParameterValue("NombreBodega", CmbBodega.Text)
            'Reporte.SetParameterValue("FehaIni", Format(DtpDesde.Value, "yyyyMMdd"))
            'Reporte.SetParameterValue("FehaFin", Format(DtpHasta.Value, "yyyyMMdd"))

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

            DtpDesde.Value = DateValue(EmpresaInfo.Getdate)
            DtpHasta.Value = DtpDesde.Value

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try



        LlenaCombos()

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

    Private Function ValidaTodo() As Boolean
        Try

            If CmbSucursal.SelectedValue Is Nothing OrElse Not IsNumeric(CmbSucursal.SelectedValue) Then
                VerificaMensaje("Debe de seleccionar una sucursal")
            End If

            If CmbBodega.SelectedValue Is Nothing OrElse Not IsNumeric(CmbBodega.SelectedValue) Then
                VerificaMensaje("Debe de seleccionar una bodega")
            End If

            If DateValue(DtpDesde.Value) > DateValue(DtpHasta.Value) Then
                VerificaMensaje("La fecha final debe de ser mayor o igual a la fecha inicial")
            End If

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

    Private Sub CmbSucursal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSucursal.SelectedIndexChanged

    End Sub
End Class