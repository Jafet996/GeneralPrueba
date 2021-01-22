Imports BUSINESS
Public Class FrmRptClientesConSaldo
#Region "Variables"
    Private Numerico() As TNumericFormat
#End Region
#Region "Formateo de Campos"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtSaldo, 8, 0, False, "0")


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
        TxtSaldo.Text = "1.00"
    End Sub



    Private Function ValidaTodo() As Boolean
        Try
            If Not IsNumeric(TxtSaldo.Text.Trim) Then
                TxtSaldo.Text = "1.00"
            End If


            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub MuestraReporte()
        Dim Movimiento As New TCliente
        Dim Reporte As New RptClientesConSaldo
        Dim FormaReporte As New FrmReporte
        Dim Fecha As DateTime

        Try
            Cursor = Cursors.WaitCursor
            Fecha = EmpresaInfo.Getdate

            With Movimiento
                .Emp_Id = EmpresaInfo.Emp_Id
            End With
            VerificaMensaje(Movimiento.RptCxCClientesConSaldo(CDbl(TxtSaldo.Text)))

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
        TxtSaldo.Select()
    End Sub



End Class