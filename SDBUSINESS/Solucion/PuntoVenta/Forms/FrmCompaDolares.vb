Imports Business

Public Class FrmCompaDolares
    Dim Numerico() As TNumericFormat

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtDolares, 7, 2, False, "", "##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute()
        Try

            LblTipoCambio.Text = Format(TipoCambioCierreCaja(CajaInfo.Suc_Id, CajaInfo.Caja_Id, CajaInfo.Cierre_Id), "#,##0.00")
            TxtDolares.Text = "0.00"
            LblColones.Text = "0.00"


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
        Me.ShowDialog()
    End Sub


    Private Sub TxtDolares_TextChanged(sender As Object, e As EventArgs) Handles TxtDolares.TextChanged
        CalculaColones()
    End Sub

    Private Sub CalculaColones()
        Dim tipoCambio As Double = 0
        Dim dolares As Double = 0
        Try

            If IsNumeric(LblTipoCambio.Text) Then
                tipoCambio = CDbl(LblTipoCambio.Text)
            End If

            If IsNumeric(TxtDolares.Text) Then
                dolares = CDbl(TxtDolares.Text)
            End If

            LblColones.Text = Format(tipoCambio * dolares, "#,##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmCompaDolares_Load(sender As Object, e As EventArgs) Handles Me.Load
        TxtDolares.Focus()
        TxtDolares.SelectAll()
    End Sub

    Private Function ValidaTodo() As Boolean
        Try

            If Not IsNumeric(TxtDolares.Text) OrElse CDbl(TxtDolares.Text) <= 0 Then
                TxtDolares.Focus()
                VerificaMensaje("El monto de dólares debe de ser mayor a cero")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Aplicar()
        Dim CajaCambioDolar As New TCajaCambioDolar(EmpresaInfo.Emp_Id)
        Dim Vuelto As New FrmVuelto
        Try



            With CajaCambioDolar
                .Suc_Id = CajaInfo.Suc_Id
                .Caja_Id = CajaInfo.Caja_Id
                .Cierre_Id = CajaInfo.Cierre_Id
                .Dolares = CDbl(TxtDolares.Text)
                .TipoCambio = CDbl(LblTipoCambio.Text)
                .Efectivo = CDbl(LblColones.Text)
                .Usuario_Id = UsuarioInfo.Usuario_Id
            End With

            VerificaMensaje(CajaCambioDolar.Siguiente)

            VerificaMensaje(CajaCambioDolar.Insert)

            Vuelto.Execute("Efectivo ", CajaCambioDolar.Efectivo)

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CajaCambioDolar = Nothing
            Vuelto = Nothing
        End Try
    End Sub

    Private Sub BtnAplicar_Click(sender As Object, e As EventArgs) Handles BtnAplicar.Click
        Try

            If ValidaTodo() Then
                If ConfirmaAccion("Desea aplicar la compra de dólares?") Then
                    Aplicar()
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmCompaDolares_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnAplicar.PerformClick()
        End Select
    End Sub
End Class