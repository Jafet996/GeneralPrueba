Imports Business

Public Class FrmRepClienteEncargos
    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptClienteEncargo
        Dim FormaReporte As New FrmReporte
        Dim FechaIni As Date
        Dim FechaFin As Date
        Try

            Cursor.Current = Cursors.WaitCursor

            FechaIni = DateValue(DtpPFechaIni.Value)
            FechaFin = DateAdd(DateInterval.Day, 1, DateValue(DtpPFechaFin.Value))


            With Cliente
                .Emp_Id = SucursalInfo.Emp_Id
            End With

            Mensaje = Cliente.RptEncargosDeMercaderia(FechaIni, FechaFin)
            VerificaMensaje(Mensaje)

            If Cliente.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(Cliente.Data.Tables(0))

            'parametros encabezado y pie de pagina

            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("FechaInicio", FechaIni)
            Reporte.SetParameterValue("FechaFinal", DateValue(DtpPFechaFin.Value))

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
            If DateValue(DtpPFechaIni.Value) > DateValue(DtpPFechaFin.Value) Then
                VerificaMensaje("La fecha de inicio no puede ser superior a la final")
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



    Public Sub Execute()
        Try

            DtpPFechaFin.Value = DateValue(EmpresaInfo.Getdate())
            DtpPFechaIni.Value = DateAdd(DateInterval.Year, -1, DtpPFechaFin.Value)

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmRepClientesMasFacturan_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
End Class