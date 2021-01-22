Imports Business

Public Class FrmRepEntradasPorProveedor

    Public Sub execute()
        Me.ShowDialog()
    End Sub


    Function validaTodo() As Boolean

        Return DtpFechaFin.Value.Date >= DtpPFechaIni.Value.Date
    End Function


    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim EntradaEncabezado As New TEntradaEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte As New EntradaXProveedor
        Dim FormaReporte As New FrmReporte
        Dim FechaIni As Date
        Dim FechaFin As Date
        Try

            Cursor.Current = Cursors.WaitCursor

            FechaIni = DateValue(DtpPFechaIni.Value)
            FechaFin = DateAdd(DateInterval.Day, 1, DateValue(DtpFechaFin.Value))


            With EntradaEncabezado
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
                .Bod_Id = SucursalParametroInfo.BodCompra_Id
            End With

            Mensaje = EntradaEncabezado.RptEntradaMercaderiaxProveedor(FechaIni, FechaFin, CbConsolidado.Checked)
            VerificaMensaje(Mensaje)

            If EntradaEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(EntradaEncabezado.Data.Tables(0))

            'parametros encabezado y pie de pagina

            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("NombreSucursal", SucursalInfo.Nombre)
            Reporte.SetParameterValue("pDesde", DtpPFechaIni.Value.Date)
            Reporte.SetParameterValue("pHasta", DtpFechaFin.Value.Date)
            Reporte.SetParameterValue("pConsolidado", CbConsolidado.Checked)
            'Reporte.SetParameterValue("TelefonoSucursal", SucursalInfo.Telefono)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            EntradaEncabezado = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Try

            If validaTodo() Then
                MuestraReporte()
            Else
                MensajeError("Las fecha final debe ser mayor o igual a la inicial")
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmRepEntradasPorProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnImprimir.PerformClick()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub
End Class