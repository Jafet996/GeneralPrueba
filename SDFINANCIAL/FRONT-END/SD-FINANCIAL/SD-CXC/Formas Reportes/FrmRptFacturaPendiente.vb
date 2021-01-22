Imports BUSINESS
Public Class FrmRptFacturaPendiente

#Region "Variables"
    Private Numerico() As TNumericFormat
#End Region
#Region "Formateo de Campos"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(1)

            Numerico(0) = New TNumericFormat(TxtCliente, 6, 0, False, "0", "####")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Public Sub Execute()
        FormateaCamposNumericos()
        Inicializa()

        Me.ShowDialog()
    End Sub

    Private Sub Inicializa()
        TxtCliente.Text = ""

    End Sub

    Private Function CargaCliente() As String
        Dim Cliente As New TCliente

        Try
            If TxtCliente.Text.Trim = "" OrElse CInt(TxtCliente.Text.Trim) <= 0 Then
                Return String.Empty
            End If

            With Cliente
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cliente_Id = CInt(TxtCliente.Text.Trim)
            End With
            VerificaMensaje(Cliente.ListKey)

            If Cliente.RowsAffected = 0 Then
                EnfocarTexto(TxtCliente)
                VerificaMensaje("No se encontró un cliente con el código: " & TxtCliente.Text.Trim)
            End If

            If Not Cliente.Activo Then
                EnfocarTexto(TxtCliente)
                VerificaMensaje("El cliente seleccionado se encuentra inactivo")
            End If

            TxtClienteNombre.Text = Cliente.Nombre

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Cliente = Nothing
        End Try
    End Function

    Private Sub BuscaCliente()
        Dim Forma As New FrmBusquedaCliente

        Try
            Forma.Execute()

            If Forma.Selecciono Then
                TxtCliente.Text = Forma.Cliente_Id
                VerificaMensaje(CargaCliente)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If (CkbCliente.Checked) Then
                If TxtClienteNombre.Text = "" Then
                    VerificaMensaje("Ingrese cliente")
                    TxtCliente.Select()
                End If
            End If

            VerificaMensaje(CargaCliente)

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub MuestraReporte()
        Dim Movimiento As New TCxCMovimiento
        Dim Reporte
        Dim FormaReporte As New FrmReporte
        Dim Fecha As DateTime
        Dim pInfoAdicional As Boolean


        Try
            Cursor = Cursors.WaitCursor
            Fecha = EmpresaInfo.Getdate
            If CkbClienteInfoAdicional.Checked Then
                Reporte = New RptFacturaPendienteInfoAdicional
                pInfoAdicional = True
            Else
                pInfoAdicional = False
                Reporte = New RptFacturaPendiente
            End If
            With Movimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cliente_Id = IIf(CkbCliente.Checked, TxtCliente.Text, -1)
            End With
            VerificaMensaje(Movimiento.RptFacturaPendiente(pInfoAdicional))

            If Movimiento.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(Movimiento.Datos.Tables(0))
            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Datos.Tables(0))
            Reporte.SetParameterValue("pNombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("pCedula", EmpresaInfo.Cedula)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            Movimiento = Nothing
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub MuestraReporteTectel()
        Dim Movimiento As New TCxCMovimiento
        Dim Reporte
        Dim FormaReporte As New FrmReporte
        Dim Fecha As DateTime
        Dim pInfoAdicional As Boolean

        Try
            Cursor = Cursors.WaitCursor
            Fecha = EmpresaInfo.Getdate
            If CkbClienteInfoAdicional.Checked Then
                Reporte = New RptFacturaPendienteInfoAdicional
                pInfoAdicional = True
            Else
                pInfoAdicional = False
                Reporte = New RptFacturaPendienteTectel
            End If
            With Movimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cliente_Id = IIf(CkbCliente.Checked, TxtCliente.Text, -1)
            End With
            VerificaMensaje(Movimiento.RptFacturaPendiente(pInfoAdicional))

            If Movimiento.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(Movimiento.Datos.Tables(0))
            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Datos.Tables(0))
            Reporte.SetParameterValue("pNombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("pCedula", EmpresaInfo.Cedula)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            Movimiento = Nothing
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MuestraReportePety()
        Dim Movimiento As New TCxCMovimiento
        Dim Reporte
        Dim FormaReporte As New FrmReporte
        Dim Fecha As DateTime
        Dim pInfoAdicional As Boolean

        Try
            Cursor = Cursors.WaitCursor
            Fecha = EmpresaInfo.Getdate
            If CkbClienteInfoAdicional.Checked Then
                Reporte = New RptFacturaPendienteInfoAdicional
                pInfoAdicional = True
            Else
                pInfoAdicional = False
                Reporte = New RptFacturaPendiente
            End If
            With Movimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cliente_Id = IIf(CkbCliente.Checked, TxtCliente.Text, -1)
            End With
            VerificaMensaje(Movimiento.RptFacturaPendiente(pInfoAdicional))

            If Movimiento.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(Movimiento.Datos.Tables(0))
            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Datos.Tables(0))
            Reporte.SetParameterValue("pNombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("pCedula", EmpresaInfo.Cedula)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            Movimiento = Nothing
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub Imprimir()
        Try
            If ValidaTodo() Then
                Select Case InfoMaquina.PrintLocation
                    Case PrintLocation.Tectel
                        MuestraReporteTectel()
                    Case PrintLocation.CartaPety
                        MuestraReportePety()
                    Case Else
                        MuestraReporte()
                End Select
            End If

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

    Private Sub FrmRptDocumentosProximosVencer_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnImprimir.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub FrmRptDocumentosProximosVencer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtCliente.Select()
    End Sub

    Private Sub TxtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCliente.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    BuscaCliente()
                Case Keys.Enter
                    VerificaMensaje(CargaCliente)
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCliente_TextChanged(sender As Object, e As EventArgs) Handles TxtCliente.TextChanged
        TxtClienteNombre.Text = ""
    End Sub

    Private Sub CkbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles CkbCliente.CheckedChanged
        Try
            PnlCliente.Enabled = CkbCliente.Checked
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class