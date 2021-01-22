Public Class FrmReporte
    Public Sub Execute(ByRef pRep As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        Me.Show()
        CrystalReportViewer1.ReportSource = pRep
    End Sub
    Private Sub FrmReporte_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class