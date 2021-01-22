Imports Business
Public Class FrmConsultaDocumentoElectronico
    Public Sub Execute()
        TxtClave.Select()
        Me.ShowDialog()
    End Sub
    Private Sub TxtClave_TextChanged(sender As Object, e As EventArgs) Handles TxtClave.TextChanged
        LblEstado.Text = ""
    End Sub

    Private Sub TxtClave_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtClave.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnConsulta.PerformClick()
        End If
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnConsulta_Click(sender As Object, e As EventArgs) Handles BtnConsulta.Click
        Try

            If Validar() Then
                Consulta()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function Validar()
        Try

            If TxtClave.Text.Trim = "" Then
                TxtClave.SelectAll()
                VerificaMensaje("Debe de ingresar la clave que desea consultar")
            End If

            If TxtClave.Text.Length <> 50 Then
                TxtClave.SelectAll()
                VerificaMensaje("La clave debe de tener un largo de 50 caracteres")
            End If


            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Consulta()
        Dim FE As New TFacturacionElectronica()
        Try

            With FE
                .CoreURL = InfoMaquina.URLCoreAPI
                .CoreURL = "http://localhost:56132/"
            End With

            VerificaMensaje(FE.Consultar(EmpresaParametroInfo.Emisor_Id, EmpresaParametroInfo.FeToken, TxtClave.Text.Trim))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FE = Nothing
        End Try
    End Sub

    Private Sub FrmConsultaDocumentoElectronico_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnConsulta.PerformClick()
        End Select

    End Sub
End Class