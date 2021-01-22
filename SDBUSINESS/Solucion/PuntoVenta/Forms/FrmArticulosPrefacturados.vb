Imports Business

Public Class FrmArticulosPrefacturados
    Dim Numerico() As TNumericFormat


    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)


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
        Dim ProformaEncabezado As New TProformaEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptArticulosPrefacturados
        Dim ReporteResumido As New RptArticulosPrefacturadosResumido
        Dim FormaReporte As New FrmReporte
        Dim FechaIni As Date
        Dim FechaFin As Date
        Try

            Cursor.Current = Cursors.WaitCursor


            FechaIni = DateValue(DtpFechaIni.Value)
            FechaFin = DateAdd(DateInterval.Day, 1, DateValue(DtpFechaFin.Value))


            With ProformaEncabezado
                .Suc_Id = CInt(CmbSucursal.SelectedValue)
                .Bod_Id = CInt(CmbBodega.SelectedValue)
            End With


            If CmbTipo.SelectedIndex = 1 Then
                Mensaje = ProformaEncabezado.RptArticulosPrefacturados(FechaIni, FechaFin, -1)
            Else
                Mensaje = ProformaEncabezado.RptArticulosPrefacturadosResumido(FechaIni, FechaFin, -1)
            End If
            VerificaMensaje(Mensaje)

            If ProformaEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            If CmbTipo.SelectedIndex = 1 Then
                Reporte.SetDataSource(ProformaEncabezado.Data.Tables(0))
                Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
                Reporte.SetParameterValue("NombreSucursal", SucursalInfo.Nombre)
            Else
                ReporteResumido.SetDataSource(ProformaEncabezado.Data.Tables(0))
                ReporteResumido.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
                ReporteResumido.SetParameterValue("NombreSucursal", SucursalInfo.Nombre)
            End If

            'parametros encabezado y pie de pagina

            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("NombreSucursal", SucursalInfo.Nombre)

            If Form_Abierto("FrmReporte") = False Then
                If CmbTipo.SelectedIndex = 1 Then
                    FormaReporte.Execute(Reporte)
                Else
                    FormaReporte.Execute(ReporteResumido)
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            ProformaEncabezado = Nothing
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

            DtpFechaIni.Value = DateValue(EmpresaInfo.Getdate())
            DtpFechaFin.Value = DateAdd(DateInterval.Day, 1, DtpFechaIni.Value)

            CmbTipo.SelectedIndex = 0

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

    Private Function TxtCantidad() As TextBox
        Throw New NotImplementedException
    End Function

End Class