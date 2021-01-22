﻿Imports Business
Public Class FrmRepVentasxCategoria

    Private Sub CargaSucursal()
        Dim Sucursal As New TSucursal(EmpresaInfo.Emp_Id)
        Try

            VerificaMensaje(Sucursal.LoadComboBox(CmbSucursal))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Sucursal = Nothing
        End Try
    End Sub


    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim FacturaEncabezado As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptVentasxCategoria
        Dim FormaReporte As New FrmReporte
        Dim FechaIni As Date
        Dim FechaFin As Date
        Try

            Cursor.Current = Cursors.WaitCursor

            FechaIni = DateValue(DtpPFechaIni.Value)
            FechaFin = DateAdd(DateInterval.Day, 1, DateValue(DtpPFechaFin.Value))
            With FacturaEncabezado
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = CmbSucursal.SelectedValue
            End With
            Mensaje = FacturaEncabezado.RptVentasCategoria(FechaIni, FechaFin)
            VerificaMensaje(Mensaje)
            If FacturaEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(FacturaEncabezado.Data.Tables(0))
            'parametros encabezado y pie de pagina
            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("NombreSucursal", CmbSucursal.Text)
            'Reporte.SetParameterValue("TelefonoSucursal", SucursalInfo.Telefono)
            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            FacturaEncabezado = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            'If CmbCategoriaIni.SelectedValue Is Nothing Then
            '    CmbCategoriaIni.Focus()
            '    VerificaMensaje("Debe de seleccionar un valor")
            'End If

            'If CmbCategoriaFin.SelectedValue Is Nothing Then
            '    CmbCategoriaFin.Focus()
            '    VerificaMensaje("Debe de seleccionar un valor")
            'End If

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

    'Private Sub CargarCombos()
    '    Dim Categoria As New TCategoria(EmpresaInfo.Emp_Id)
    '    Dim Mensaje As String = ""
    '    Try

    '        Mensaje = Categoria.LoadComboBox(CmbCategoriaIni)
    '        VerificaMensaje(Mensaje)

    '        Mensaje = Categoria.LoadComboBox(CmbCategoriaFin)
    '        VerificaMensaje(Mensaje)

    '        If CmbCategoriaFin.Items.Count > 0 Then
    '            CmbCategoriaFin.SelectedIndex = CmbCategoriaFin.Items.Count - 1
    '        End If


    '    Catch ex As Exception
    '        MensajeError(ex.Message)
    '    Finally
    '        Categoria = Nothing
    '    End Try
    'End Sub

    Public Sub Execute()
        Try

            CargaSucursal()

            DtpPFechaIni.Value = DateValue(EmpresaInfo.Getdate())
            DtpPFechaFin.Value = DtpPFechaIni.Value

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

    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimir.Click
        Imprimir()
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
End Class