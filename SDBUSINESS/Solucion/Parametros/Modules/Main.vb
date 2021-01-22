Module Main
    Public Sub Main()
        Dim Forma As New FrmMantParametrosRegistro
        Try

            Forma.Execute()

        Catch ex As Exception
            MsgBox(ex.Message, vbExclamation, "Error de aplicacion")
        Finally
            Forma = Nothing
        End Try
    End Sub
End Module
