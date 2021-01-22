Imports Business
Public Class FrmRepDiferencias
    Private _TomaFisica As TTomaFisicaEncabezado
    Dim Numerico() As TNumericFormat

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtMonto, 8, 2, False, "0", "#,##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub CargaBodega()
        Dim Bodega As New TBodega(EmpresaInfo.Emp_Id)

        Try
            With Bodega
                .Suc_Id = _TomaFisica.Suc_Id
                .Bod_Id = _TomaFisica.Bod_Id
            End With

            VerificaMensaje(Bodega.ListKey)

            LblBodegaNombre.Text = Bodega.Nombre

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Bodega = Nothing
        End Try
    End Sub

    Public Sub Execute(pTomaFisica As TTomaFisicaEncabezado)
        Try

            _TomaFisica = pTomaFisica

            CargaBodega()

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub MuestraReporte()
        Dim TFEncabezado As New TTomaFisicaEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptDiferenciasTomaFisica
        Dim FormaReporte As New FrmReporte
        Dim Bodega As New TBodega(EmpresaInfo.Emp_Id)
        Dim Monto As Double = -1
        Dim Cantidad As Double = -1
        Try
            Cursor.Current = Cursors.WaitCursor

            With TFEncabezado
                .Suc_Id = _TomaFisica.Suc_Id
                .Bod_Id = _TomaFisica.Bod_Id
                .TomaFisica_Id = _TomaFisica.TomaFisica_Id
            End With

            If RdbMonto.Checked Then
                Monto = CDbl(TxtMonto.Text)
                Cantidad = -1
            Else
                Monto = -1
                Cantidad = CDbl(TxtMonto.Text)
            End If

            VerificaMensaje(TFEncabezado.RptDiferenciasTomaFisica(Monto, Cantidad))


            If TFEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(TFEncabezado.Data.Tables(0))

            'parametros encabezado y pie de pagina

            Bodega.Suc_Id = TFEncabezado.Suc_Id
            Bodega.Bod_Id = TFEncabezado.Bod_Id
            VerificaMensaje(Bodega.ListKey)

            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("NombreSucursal", SucursalInfo.Nombre)
            Reporte.SetParameterValue("NombreBodega", Bodega.Nombre)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            TFEncabezado = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try

            If Not IsNumeric(TxtMonto.Text.Trim) Then
                VerificaMensaje("Debe de ingresar un valor númerico")
                TxtMonto.Focus()
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

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Imprimir()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmRepDiferencias_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Imprimir()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub FrmRepDiferencias_Load(sender As Object, e As EventArgs) Handles Me.Load
        FormateaCamposNumericos()
    End Sub
End Class