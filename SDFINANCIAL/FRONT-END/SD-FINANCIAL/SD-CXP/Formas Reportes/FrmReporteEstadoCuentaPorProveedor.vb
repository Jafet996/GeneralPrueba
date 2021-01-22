
Imports BUSINESS
Public Class FrmReporteEstadoCuentaPorProveedor

#Region "Variables"
    Private Numerico() As TNumericFormat
    Private _Nuevo As Boolean
    Private _ProveedorId As Integer
    Private _NombreProveedor As String
#End Region
#Region "Propiedades"
    Public WriteOnly Property Proveedor_Id As Integer
        Set(value As Integer)
            _ProveedorId = value
        End Set
    End Property
    Public WriteOnly Property Nombre As String
        Set(value As String)
            _NombreProveedor = value
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

            Numerico(0) = New TNumericFormat(TxtProveedor, 6, 0, False, "", "####")

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
            TxtProveedor.Text = _ProveedorId
            TxtProveedorNombre.Text = _NombreProveedor
        End If
        TxtProveedor.Select()
        Me.ShowDialog()

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
                VerificaMensaje("El cliente seleccionado se encuentra inactivo")
            End If

            TxtProveedorNombre.Text = Proveedor.Nombre

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Proveedor = Nothing
        End Try
    End Function

    Private Sub Inicializa()
        TxtProveedor.Text = ""

    End Sub

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

            If TxtProveedorNombre.Text = "" Then
                VerificaMensaje("Ingrese cliente")
                TxtProveedor.Select()
            End If

            VerificaMensaje(CargaProveedor)

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

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

    Private Sub MuestraReporte()
        Dim Movimiento As New TCxPMovimiento
        Dim Reporte As New RptCxPEstadoCuentaPorProveedor
        Dim FormaReporte As New FrmReporte
        Dim Fecha As DateTime

        Try
            Cursor = Cursors.WaitCursor
            Fecha = EmpresaInfo.Getdate

            With Movimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = TxtProveedor.Text
            End With
            VerificaMensaje(Movimiento.RptCxPEstadoCuentaPorProveedor(DpDesde.Value, DpHasta.Value))

            If Movimiento.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(Movimiento.Datos.Tables(0))
            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Datos.Tables(0))
            Reporte.SetParameterValue("pEmpresa", EmpresaInfo.Nombre)

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

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Imprimir()
    End Sub
End Class