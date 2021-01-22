Imports Business

Public Class FrmEntradaEfectivo

    Dim Numerico() As TNumericFormat

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If TxtMonto.Text <= 0 Then
                VerificaMensaje("El monto por entrada de efectivo debe ser mayor a cero.")
            End If

            If Not IsNumeric(TxtPagaCon.Text) Then
                TxtPagaCon.Focus()
                VerificaMensaje("El monto digitado de pago en incorrecto.")
            End If

            If Not IsNumeric(TxtMonto.Text) Then
                TxtMonto.Focus()
                VerificaMensaje("El monto digitado no es numérico.")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub CargaCombos()
        Dim concepto As New TCajaEntradaEfectivoConcepto(EmpresaInfo.Emp_Id)
        Try
            concepto.LoadComboBox(CmbMotivo)
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute()
        Try

            If CajaInfo.Abierta = 0 Then
                VerificaMensaje("Imposible continuar, debe abrir caja primero.")
            End If

            FormateaCamporNumericos()
            CargaCombos()
            CmbMotivo.Select()
            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FormateaCamporNumericos()
        Try
            ReDim Numerico(1)

            Numerico(0) = New TNumericFormat(TxtMonto, 6, 2, False, "", "##0.0000")
            Numerico(1) = New TNumericFormat(TxtPagaCon, 6, 2, False, "", "##0.0000")

        Catch ex As Exception
            VerificaMensaje(ex.Message)
        End Try
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        If ValidaTodo() Then
            GuardarEntrada()
        End If
    End Sub

    Private Sub GuardarEntrada()
        Dim confirmacion As New FrmPregunta()
        Dim vuelto As New FrmVuelto()
        Dim entrada As New TCajaEntradaEfectivo(EmpresaInfo.Emp_Id)
        Dim concepto As New TCajaEntradaEfectivoConcepto(EmpresaInfo.Emp_Id)

        Try
            confirmacion.Pregunta = "¿Desea aplicar la entrada de efectivo?"
            confirmacion.Execute()
            If confirmacion.Respuesta Then

                With entrada
                    .Suc_Id = InfoMaquina.Suc_Id
                    .Monto = TxtMonto.Text
                    .Motivo = TxtDescripcion.Text
                    .Usuario_Id = UsuarioInfo.Usuario_Id
                    .Concepto_Id = CmbMotivo.SelectedValue
                    .Caja_Id = InfoMaquina.Caja_Id
                    .Cierre_Id = CajaInfo.Cierre_Id
                End With

                concepto.Concepto_Id = CmbMotivo.SelectedValue
                VerificaMensaje(concepto.ListKey())

                VerificaMensaje(entrada.Insert())

                Dim impresion As New TImprimeEntradaEfectivo(EmpresaInfo, SucursalInfo, CajaInfo, entrada, concepto, True)
                impresion.Print(InfoMaquina.PrintLocation, True)

                vuelto.Execute("Su vuelto es:", (TxtPagaCon.Text - TxtMonto.Text))





                Inicializa()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Inicializa()
        Try
            TxtMonto.Text = 0
            TxtDescripcion.Text = ""
            CmbMotivo.SelectedIndex = 0
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmEntradaEfectivo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            BtnAgregar.PerformClick()
        End If

        If e.KeyCode = Keys.Escape Then
            BtnSalir.PerformClick()
        End If
    End Sub

    Private Sub TxtMonto_TextChanged(sender As Object, e As EventArgs) Handles TxtMonto.TextChanged
        Try
            TxtPagaCon.Text = TxtMonto.Text
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


End Class