﻿Imports Business

Public Class FrmRepClientesMasFacturan
    Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)

    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Cliente = New TCliente(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptClientesMasFacturados
        Dim FormaReporte As New FrmReporte
        Dim FechaIni As Date
        Dim FechaFin As Date
        Try

            Cursor.Current = Cursors.WaitCursor

            FechaIni = DateValue(DtpPFechaIni.Value)
            FechaFin = DateAdd(DateInterval.Day, 1, DateValue(DtpPFechaFin.Value))



            With Cliente
                .Emp_Id = SucursalInfo.Emp_Id
                If CmbClientes.Enabled Then
                    .Cliente_Id = CmbClientes.SelectedValue
                Else
                    .Cliente_Id = -1
                End If

            End With

            Mensaje = Cliente.RptClienteMasFacturados(SucursalInfo.Suc_Id, FechaIni, FechaFin)
            VerificaMensaje(Mensaje)

            If Cliente.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(Cliente.Data.Tables(0))

            'parametros encabezado y pie de pagina

            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("NombreSucursal", SucursalInfo.Nombre)
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


    Private Sub cargaCombos()
        Cliente.LoadComboBox(CmbClientes)
    End Sub


    Public Sub Execute()
        cargaCombos()

        DtpPFechaIni.Value = DateValue(EmpresaInfo.Getdate())
        DtpPFechaFin.Value = DtpPFechaIni.Value

        Me.ShowDialog()
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

    Private Sub CbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles CbTodos.CheckedChanged
        CmbClientes.Enabled = Not CbTodos.Checked
    End Sub
End Class