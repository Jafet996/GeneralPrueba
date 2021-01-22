Public Class FrmListaResultados

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub

    Private Sub CargaLista(pLista As List(Of String))
        Try

            For Each Linea As String In pLista
                LstLista.Items.Add(Linea)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute(pLista As List(Of String))
        Try

            CargaLista(pLista)

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class