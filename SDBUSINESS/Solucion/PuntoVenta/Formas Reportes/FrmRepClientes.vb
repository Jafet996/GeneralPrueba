Imports Business
Public Class FrmRepClientes
    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptClientes
        Dim FormaReporte As New FrmReporte
        Dim Precio_Id As Integer = -1
        Try

            Cursor.Current = Cursors.WaitCursor


            If Not ChkTodos.Checked Then
                Precio_Id = CmbPrecio.SelectedValue
            End If


            With Cliente
                .Emp_Id = SucursalInfo.Emp_Id
                .Precio_Id = Precio_Id
            End With

            Mensaje = Cliente.RptCliente()
            VerificaMensaje(Mensaje)

            If Cliente.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(Cliente.Data.Tables(0))

            'parametros encabezado y pie de pagina

            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("NombreSucursal", SucursalInfo.Nombre)
            'Reporte.SetParameterValue("TelefonoSucursal", SucursalInfo.Telefono)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            Cliente = Nothing
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

    Private Sub LlenaCombos()
        Dim ClientePrecio As New TClientePrecio(EmpresaInfo.Emp_Id)
        Try

            VerificaMensaje(ClientePrecio.LoadComboBox(CmbPrecio))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ClientePrecio = Nothing
        End Try
    End Sub


    Public Sub Execute()

        LlenaCombos()

        ChkTodos.Checked = True
        ChkTodos_CheckedChanged(Nothing, EventArgs.Empty)


        'DtpPFechaIni.Value = DateValue(EmpresaInfo.Getdate())
        'DtpPFechaFin.Value = DtpPFechaIni.Value

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

    Private Sub ChkTodos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkTodos.CheckedChanged
        CmbPrecio.Enabled = Not (ChkTodos.Checked)
    End Sub
End Class