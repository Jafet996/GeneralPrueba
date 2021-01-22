Imports Business
Public Class FrmCerrarCaja
    Dim Numerico() As TNumericFormat

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(4)

            Numerico(0) = New TNumericFormat(TxtEfectivo, 7, 2, False, "", "##0.00")
            Numerico(1) = New TNumericFormat(TxtTarjetas, 7, 2, False, "", "##0.00")
            Numerico(2) = New TNumericFormat(TxtCheques, 7, 2, False, "", "##0.00")
            'Numerico(3) = New TNumericFormat(TxtDocumentos, 7, 2, False, "", "##0.00")
            Numerico(4) = New TNumericFormat(TxtDolares, 7, 2, False, "", "##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute()
        LblCaja.Text = CajaInfo.Nombre
        LblUsuario.Text = UsuarioInfo.Nombre
        TxtEfectivo.Text = "0.00"
        TxtDolares.Text = "0.00"

        Me.ShowDialog()
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If Not IsNumeric(TxtEfectivo.Text) Then
                TxtEfectivo.Focus()
                VerificaMensaje("El monto ingresado debe de ser numérico")
            End If

            If CDbl(TxtEfectivo.Text) < 0 Then
                TxtEfectivo.Focus()
                VerificaMensaje("El monto ingresado debe de ser mayor o igual a cero")
            End If

            If Not IsNumeric(TxtTarjetas.Text) Then
                TxtTarjetas.Focus()
                VerificaMensaje("El monto ingresado debe de ser numérico")
            End If

            If CDbl(TxtTarjetas.Text) < 0 Then
                TxtTarjetas.Focus()
                VerificaMensaje("El monto ingresado debe de ser mayor o igual a cero")
            End If

            If Not IsNumeric(TxtCheques.Text) Then
                TxtCheques.Focus()
                VerificaMensaje("El monto ingresado debe de ser numérico")
            End If

            If CDbl(TxtCheques.Text) < 0 Then
                TxtCheques.Focus()
                VerificaMensaje("El monto ingresado debe de ser mayor o igual a cero")
            End If

            'If Not IsNumeric(TxtDocumentos.Text) Then
            '    TxtDocumentos.Focus()
            '    VerificaMensaje("El monto ingresado debe de ser numérico")
            'End If

            'If CDbl(TxtDocumentos.Text) < 0 Then
            '    TxtDocumentos.Focus()
            '    VerificaMensaje("El monto ingresado debe de ser mayor o igual a cero")
            'End If

            If Not IsNumeric(TxtDolares.Text) OrElse CDbl(TxtDolares.Text) < 0 Then
                TxtDolares.Focus()
                VerificaMensaje("El monto ingresado debe de ser mayor o igual a cero")
            End If

            If Not RevisaCajaEstado(True) Then
                VerificaMensaje("Imposible cerrar la caja, ya que esta no se encuentra abierta")
            End If


            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub FrmAbrirCaja_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FormateaCamposNumericos()
        TxtEfectivo.Select()
    End Sub
    Private Sub Aceptar()
        Dim Caja As New TCaja(EmpresaInfo.Emp_Id)
        Try

            With Caja
                .Emp_Id = CajaInfo.Emp_Id
                .Suc_Id = CajaInfo.Suc_Id
                .Caja_Id = CajaInfo.Caja_Id
            End With

            VerificaMensaje(Caja.CerrarCaja(CDbl(TxtEfectivo.Text), CDbl(TxtTarjetas.Text), CDbl(TxtCheques.Text), 0, CDbl(TxtDolares.Text)))

            VerificaMensaje(CajaInfo.ListKey())

            Mensaje("La caja se cerró correctamente")


            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Caja = Nothing
        End Try

    End Sub
    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        If ValidaTodo() Then
            If ConfirmaAccion("Desea cerrar la caja?") Then
                Aceptar()
            End If
        End If
    End Sub

    Private Sub TxtEfectivo_GotFocus(sender As Object, e As System.EventArgs) Handles TxtEfectivo.GotFocus
        TxtEfectivo.SelectAll()
    End Sub

    Private Sub TxtEfectivo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtEfectivo.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtTarjetas.Focus()
        End If
    End Sub

    Private Sub TxtTarjetas_GotFocus(sender As Object, e As System.EventArgs) Handles TxtTarjetas.GotFocus
        TxtTarjetas.SelectAll()
    End Sub
    Private Sub TxtTarjetas_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtTarjetas.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtCheques.Focus()
        End If
    End Sub

    Private Sub TxtCheques_GotFocus(sender As Object, e As System.EventArgs) Handles TxtCheques.GotFocus
        TxtCheques.SelectAll()
    End Sub
    Private Sub TxtCheques_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCheques.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtDolares.Focus()
        End If
    End Sub


    Private Sub TxtDocumentos_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            BtnAceptar.Focus()
        End If
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub TxtDolares_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDolares.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnAceptar.PerformClick()
        End If
    End Sub
End Class