Public Class FrmPregunta
    Public Property Pregunta As String
    Public Property Respuesta As Boolean = False
    Public Sub Execute()
        Try

            LblPregunta.Text = Pregunta
            BtnSI.Select()
            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnSI_Click(sender As Object, e As EventArgs) Handles BtnSI.Click
        Try

            Respuesta = True
            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnNO_Click(sender As Object, e As EventArgs) Handles BtnNO.Click
        Try

            Respuesta = False
            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


End Class