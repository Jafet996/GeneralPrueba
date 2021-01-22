Imports Business
Public Class FrmRepCorteVentasCajero
    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim Cierre As New TUsuarioCierre(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptCierreUsuario
        Dim FormaReporte As New FrmReporte

        Try
            If LvwDetalle.SelectedItems Is Nothing OrElse LvwDetalle.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe seleccionar un cierre")
            End If
            Cursor.Current = Cursors.WaitCursor

            With Cierre
                .Usuario_Id = CmbUsuario.SelectedValue
                .Cierre_Id = CInt(LvwDetalle.SelectedItems.Item(0).SubItems(0).Text)
            End With

            Mensaje = Cierre.RptCierreCajaUsuario()
            VerificaMensaje(Mensaje)

            If Cierre.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(Cierre.Data.Tables(0))

            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))

            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("NombreSucursal", SucursalInfo.Nombre)

            Reporte.PrintToPrinter(1, False, 0, 0)


            'If Form_Abierto("FrmReporte") = False Then
            '    FormaReporte.Execute(Reporte)
            'End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            Cierre = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
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
    Public Sub CargaUsuario()
        Dim Usuario As New TUsuario(EmpresaInfo.Emp_Id)
        Try
            VerificaMensaje(Usuario.LoadComboBox(CmbUsuario))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Usuario = Nothing
        End Try
    End Sub

    Public Sub Execute()
        Try
            DtpPFechaIni.Value = DateValue(EmpresaInfo.Getdate())
            DtpPFechaFin.Value = DtpPFechaIni.Value

            CargaUsuario()
            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub FrmRepVentasxCategoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Imprimir()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        Imprimir()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Try
            CargaCierres()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub
    Private Sub CargaCierres()
        Dim Cierre As New TUsuarioCierre(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Dim Item As ListViewItem = Nothing
        Dim Items(2) As String
        Try

            LvwDetalle.Items.Clear()

            With Cierre
                .Emp_Id = CajaInfo.Emp_Id
                .Usuario_Id = CmbUsuario.SelectedValue
            End With

            Mensaje = Cierre.ListaCierresXUsuario(DtpPFechaIni.Value, DtpPFechaIni.Value)
            VerificaMensaje(Mensaje)

            If Cierre.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron cortes de venta para el usuario en ese rango de fechas")
            End If

            For Each Fila As DataRow In Cierre.Data.Tables(0).Rows
                Items(0) = Fila("Cierre_Id")
                Items(1) = Fila("Fecha")

                Item = New ListViewItem(Items)
                Item.Tag = Fila("Cierre_Id")

                LvwDetalle.Items.Add(Item)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cierre = Nothing
        End Try
    End Sub

    Private Sub LvwDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LvwDetalle.SelectedIndexChanged

    End Sub

    Private Sub LvwDetalle_DoubleClick(sender As Object, e As EventArgs) Handles LvwDetalle.DoubleClick
        Try

            If LvwDetalle.SelectedItems() Is Nothing OrElse LvwDetalle.SelectedItems.Count = 0 Then
                Exit Sub
            End If

            BtnImprimir.PerformClick()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class