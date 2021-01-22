Imports BUSINESS
Public Class FrmCajaApertura
    Public Sub Execute()
        Try

            LblCaja.Text = CajaInfo.Nombre
            LblUsuario.Text = UsuarioInfo.Nombre
            TxtFondo.Text = "0.00"

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmCajaApertura_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnAceptar.PerformClick()
        End Select
    End Sub

    Private Sub FrmCajaApertura_Load(sender As Object, e As EventArgs) Handles Me.Load
        TxtFondo.Select()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try

            If ValidaTodo() Then
                If CDbl(TxtFondo.Text) = 0 Then
                    If MsgBox("Desea abrir la caja sin ingresar el fondo", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                        Abrir()
                    End If
                Else
                    Abrir()
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Abrir()
        Dim CajaCierreEncabezado As New TCajaCierreEncabezado
        Try

            With CajaCierreEncabezado
                .Emp_Id = CajaInfo.Emp_Id
                .Caja_Id = CajaInfo.Caja_Id
                .Usuario_Id = UsuarioInfo.Usuario_Id
                .Fondo = CDbl(TxtFondo.Text)
            End With


            VerificaMensaje(CajaCierreEncabezado.CierreCajaApertura)

            VerificaMensaje(CajaInfo.ListKey)

            Mensaje("La caja se abrio de manera exitosa")

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CajaCierreEncabezado = Nothing
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try

            If Not IsNumeric(TxtFondo.Text) Then
                VerificaMensaje("El fondo debe de ser mayor o igual a cero")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function
End Class