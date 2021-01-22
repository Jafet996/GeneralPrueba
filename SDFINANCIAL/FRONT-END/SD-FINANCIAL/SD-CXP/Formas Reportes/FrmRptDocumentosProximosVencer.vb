Imports BUSINESS
Public Class FrmRptDocumentosProximosVencer
#Region "Variables"
    Private Numerico() As TNumericFormat
#End Region
#Region "Formateo de Campos"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(1)

            Numerico(0) = New TNumericFormat(TxtProveedor, 6, 0, False, "0")
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
        TxtProveedor.Text = ""
        TxtCantidadDias.Text = "0"
    End Sub

    Private Function CargaProveedor() As String
        Dim Proveedor As New TProveedor

        Try
            If TxtProveedor.Text.Trim = "" OrElse CInt(TxtProveedor.Text.Trim) <= 0 Then
                Return String.Empty
            End If

            With Proveedor
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = CInt(TxtProveedor.Text.Trim)
            End With
            VerificaMensaje(Proveedor.ListKey)

            If Proveedor.RowsAffected = 0 Then
                EnfocarTexto(TxtProveedor)
                VerificaMensaje("No se encontró un proveedor con el código: " & TxtProveedor.Text.Trim)
            End If

            If Not Proveedor.Activo Then
                EnfocarTexto(TxtProveedor)
                VerificaMensaje("El proveedor seleccionado se encuentra inactivo")
            End If

            TxtProveedorNombre.Text = Proveedor.Nombre
            EnfocarTexto(TxtCantidadDias)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Proveedor = Nothing
        End Try
    End Function

    Private Sub BuscaProveedor()
        Dim Forma As New FrmBusquedaProveedor

        Try
            Forma.Execute()

            If Forma.Selecciono Then
                TxtProveedor.Text = Forma.Prov_Id
                VerificaMensaje(CargaProveedor)
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

            VerificaMensaje(CargaProveedor)

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub MuestraReporte()
        Dim Movimiento As New TCxPMovimiento
        Dim Reporte As New RptDocumentosProximosVencer
        Dim FormaReporte As New FrmReporte
        Dim Fecha As DateTime

        Try
            Cursor = Cursors.WaitCursor
            Fecha = EmpresaInfo.Getdate

            With Movimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = IIf(TxtProveedor.Text.Trim = "" OrElse CInt(TxtProveedor.Text.Trim) = 0, 0, CInt(TxtProveedor.Text.Trim))
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
            Reporte.SetParameterValue("Titulo", "Al " & Format(Movimiento.FechaVencimiento, "dd/MM/yyyy"))

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
        TxtProveedor.Select()
    End Sub

    Private Sub TxtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtProveedor.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    BuscaProveedor()
                Case Keys.Enter
                    VerificaMensaje(CargaProveedor)
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCliente_TextChanged(sender As Object, e As EventArgs) Handles TxtProveedor.TextChanged
        TxtProveedorNombre.Text = ""
    End Sub

End Class