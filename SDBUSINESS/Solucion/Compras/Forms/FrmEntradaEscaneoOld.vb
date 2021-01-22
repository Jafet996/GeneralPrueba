Imports Business

Public Class FrmEntradaEscaneoOld

    Dim Numerico() As TNumericFormat

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtCantidad, 8, 2, False, "1", "#.##0,00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtArticulo_TextChanged(sender As Object, e As EventArgs) Handles TxtArticulo.TextChanged

    End Sub

    Private Sub TxtArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtArticulo.KeyDown

        Try

            Select Case e.KeyCode
                Case Keys.Enter
                    RegistraCantidad()
                    Inicializa()
            End Select


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Inicializa()
        Try

            TxtCantidad.Text = 1
            TxtArticulo.Text = ""
            TxtCantidad.Focus()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub RegistraCantidad()
        Dim Forma As FrmEntradaMercaderia
        Dim Mensaje As String = String.Empty
        Try

            If Not IsNumeric(TxtCantidad.Text) Then
                TxtCantidad.SelectAll()
                VerificaMensaje("Debe de ingresar un valor numérico")
            End If

            If TxtArticulo.Text.Trim.Length = 0 Then
                TxtArticulo.SelectAll()
                VerificaMensaje("Debe de ingresar un artículo")
            End If


            Forma = My.Application.OpenForms("FrmEntradaMercaderia")


            'Mensaje = Forma.RegistraCantidadRecibida(TxtArticulo.Text.Trim, CDbl(TxtCantidad.Text))

            If Mensaje <> String.Empty Then
                TxtArticulo.SelectAll()
                VerificaMensaje(Mensaje)
            End If

        Catch ex As Exception

            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Public Sub Execute()
        FormateaCamposNumericos()
        Me.ShowDialog()
    End Sub

    Private Sub TxtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtArticulo.Focus()
        End If
    End Sub
End Class