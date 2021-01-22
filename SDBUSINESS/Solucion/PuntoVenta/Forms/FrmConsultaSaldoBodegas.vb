Imports Business
Public Class FrmConsultaSaldoBodegas
    Private _Art_Id As String = ""

    Public WriteOnly Property Art_Id
        Set(value)
            _Art_Id = value
        End Set
    End Property

    Public Sub Execute()
        Refrescar()
        LblTotalSaldo.Text = CalculaSaldoTotal()

        Me.ShowDialog()
    End Sub

    Private Sub Refrescar()
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)

        Try
            DGDetalle.DataSource = Nothing

            With ArticuloBodega
                .Suc_Id = SucursalInfo.Suc_Id
                .Art_Id = _Art_Id
            End With

            VerificaMensaje(ArticuloBodega.ListaSaldosXBodega)

            DGDetalle.DataSource = ArticuloBodega.Data.Tables(0)

            DGDetalle.Columns(0).HeaderText = "# Bodega"
            DGDetalle.Columns(1).HeaderText = "Bodega"
            DGDetalle.Columns(2).HeaderText = "Código"
            DGDetalle.Columns(3).HeaderText = "Descripción"
            DGDetalle.Columns(4).HeaderText = "Saldo"
            DGDetalle.Columns(5).HeaderText = "Precio"
            DGDetalle.Columns(0).Width = 50
            DGDetalle.Columns(1).Width = 100
            DGDetalle.Columns(3).Width = 270
            DGDetalle.Columns(4).Width = 50


            DGDetalle.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGDetalle.Columns(4).DefaultCellStyle.Format = "#,##0.00"

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloBodega = Nothing
        End Try
    End Sub

    Private Function CalculaSaldoTotal() As Integer
        Dim Saldo As Integer = 0

        Try
            If DGDetalle.Rows.Count = 0 Then
                Return 0
            End If

            For Each Fila As DataGridViewRow In DGDetalle.Rows
                Saldo += Fila.Cells(4).Value
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

        Return Saldo
    End Function

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmConsultaSaldoBodegas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub
End Class