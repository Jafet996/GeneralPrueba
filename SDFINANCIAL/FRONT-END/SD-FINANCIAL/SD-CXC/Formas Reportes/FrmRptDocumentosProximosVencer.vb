Imports BUSINESS
Public Class FrmRptDocumentosProximosVencer
#Region "Variables"
    Private Numerico() As TNumericFormat
#End Region
#Region "Formateo de Campos"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(1)

            Numerico(0) = New TNumericFormat(TxtCliente, 6, 0, False, "0")
            'Numerico(1) = New TNumericFormat(txtVendedor, 6, 0, False, "0")
            Numerico(1) = New TNumericFormat(TxtCantidadDias, 3, 0, False, "0")

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
        TxtCantidadDias.Text = "0"
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
            EnfocarTexto(TxtCantidadDias)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Cliente = Nothing
        End Try
    End Function
    'Private Function CargaVendedor() As String
    '    'Dim Cliente As New TCliente
    '    Dim Vendedor As New TVendedor

    '    Try
    '        If txtVendedor.Text.Trim = "" OrElse CInt(txtVendedor.Text.Trim) <= 0 Then
    '            Return String.Empty
    '        End If

    '        With Vendedor
    '            .Emp_Id = EmpresaInfo.Emp_Id
    '            .Vendedor_Id = CInt(txtVendedor.Text.Trim)
    '        End With
    '        VerificaMensaje(Vendedor.ListKey)

    '        If Vendedor.RowsAffected = 0 Then
    '            EnfocarTexto(txtVendedor)
    '            VerificaMensaje("No se encontró un vendedor con el código: " & txtVendedor.Text.Trim)
    '        End If

    '        If Not Vendedor.Activo Then
    '            EnfocarTexto(txtVendedor)
    '            VerificaMensaje("El vendedor seleccionado se encuentra inactivo")
    '        End If

    '        TextVendedoNombre.Text = Vendedor.Nombre
    '        EnfocarTexto(TxtCantidadDias)

    '        Return String.Empty
    '    Catch ex As Exception
    '        Return ex.Message
    '    Finally
    '        Vendedor = Nothing
    '    End Try
    'End Function







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
            If Not IsNumeric(TxtCantidadDias.Text.Trim) Then
                EnfocarTexto(TxtCantidadDias)
                VerificaMensaje("La cantidad de días debe ser un caracter númerico")
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
        Dim Reporte As New RptDocumentosProximosVencer
        Dim FormaReporte As New FrmReporte
        Dim Fecha As DateTime

        Try
            Cursor = Cursors.WaitCursor
            Fecha = EmpresaInfo.Getdate

            With Movimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cliente_Id = IIf(TxtCliente.Text.Trim = "" OrElse CInt(TxtCliente.Text.Trim) = 0, 0, CInt(TxtCliente.Text.Trim))
                '.Vendedor_Id = IIf(txtVendedor.Text.Trim = "" OrElse CInt(txtVendedor.Text.Trim) = 0, 0, CInt(txtVendedor.Text.Trim))
                .FechaVencimiento = DateAdd(DateInterval.Day, CInt(TxtCantidadDias.Text.Trim), Fecha)
            End With
            VerificaMensaje(Movimiento.RptDocumentosProximosVencer)

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

    Private Sub Imprimir()
        Try
            If ValidaTodo() Then
                MuestraReporte()
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

    'Private Sub TextVendedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVendedor.KeyPress
    '    e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)

    'End Sub

    'Private Sub TextVendedor_TextChanged(sender As Object, e As EventArgs) Handles txtVendedor.TextChanged
    '    TextVendedoNombre.Text = ""

    'End Sub
    'Private Sub TextVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVendedor.KeyDown
    '    Try
    '        Select Case e.KeyCode
    '            Case Keys.F1
    '                BuscaCliente()
    '            Case Keys.Enter
    '                VerificaMensaje(CargaVendedor)
    '        End Select
    '    Catch ex As Exception
    '        MensajeError(ex.Message)
    '    End Try
    'End Sub


End Class