Imports BUSINESS
Public Class FrmRptEstadoCuenta
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private _Nuevo As Boolean
    Private _Cliente_Id As Integer
    Private _NombreCliente As String
#End Region
#Region "Propiedades"
    Public WriteOnly Property Cliente_Id As Integer
        Set(value As Integer)
            _Cliente_Id = value
        End Set
    End Property
    Public WriteOnly Property Nombre As String
        Set(value As String)
            _NombreCliente = value
        End Set
    End Property
    Public WriteOnly Property Nuevo As Boolean
        Set(value As Boolean)
            _Nuevo = value
        End Set
    End Property
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

        DpDesde.Value = EmpresaInfo.Getdate
        DpHasta.Value = EmpresaInfo.Getdate
        FormateaCamposNumericos()
        Inicializa()
        If _Nuevo = False Then
            TxtCliente.Text = _Cliente_Id
            TxtClienteNombre.Text = _NombreCliente
        End If
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

            If TxtClienteNombre.Text = "" Then
                VerificaMensaje("Ingrese cliente")
                TxtCliente.Select()
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
        Dim Reporte As New RptCxCEstadoCuentaPorCliente
        Dim FormaReporte As New FrmReporte
        Dim Fecha As DateTime

        Try
            Cursor = Cursors.WaitCursor
            Fecha = EmpresaInfo.Getdate

            With Movimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cliente_Id = TxtCliente.Text
            End With
            VerificaMensaje(Movimiento.RptEstadoCuentaPorCliente(DpDesde.Value, DpHasta.Value))

            If Movimiento.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(Movimiento.Datos.Tables(0))
            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Datos.Tables(0))
            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)

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
        Dim Reporte As New RptFacturaPendienteTectel
        Dim FormaReporte As New FrmReporte
        Dim Fecha As DateTime

        Try
            Cursor = Cursors.WaitCursor
            Fecha = EmpresaInfo.Getdate

            With Movimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cliente_Id = TxtCliente.Text
            End With
            VerificaMensaje(Movimiento.RptFacturaPendiente(False))

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


                If InfoMaquina.Identificacion_Id = "SDF-TPV" Then
                    MuestraReporte()
                ElseIf PrintLocation.Tectel = InfoMaquina.PrintLocation Then
                    MuestraReporteTectel()
                Else
                    MuestraReporte()
                End If




                'If InfoMaquina.Identificacion_Id = "SDF-TPV" Then
                '    MuestraReporte()

                'ElseIf InfoMaquina.PrintLocation = PrintLocation.Tectel Then



                'End If



                'Select Case InfoMaquina.PrintLocation
                '    Case PrintLocation.Tectel
                '        MuestraReporteTectel()
                '    Case Else
                '        MuestraReporte()
                'End Select
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

End Class