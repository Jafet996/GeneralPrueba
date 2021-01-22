Imports Business

Public Class FrmAjusteMargenMasivo
    Dim Numerico() As TNumericFormat
    Public Sub Execute()
        CargaCombos()
        FormateaCamposNumericos()
        Me.ShowDialog()
    End Sub

    Private Sub CargaCombos()
        Dim Precios As New TClientePrecio(EmpresaInfo.Emp_Id)
        Try
            Precios.LoadComboBox(CmbTipoPrecio)
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtMargen, 3, 4, False, "0", "#,##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If TxtMargen.Text = "" Then
                VerificaMensaje("Debe digitar el margen al cual quiere que se ajusten los precios.")
            End If

            If Not IsNumeric(TxtMargen.Text) Then
                VerificaMensaje("El texto digitado no corresponde a un número.")
            End If

            Return True

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click

        Dim precios As New TClientePrecio(EmpresaInfo.Emp_Id)
        Dim confirma As New FrmPregunta()

        Try

            If ValidaTodo() Then
                confirma.Pregunta = "¿Desea realmente ajustar los margenes del precio seleccionado?"
                confirma.Execute()

                If confirma.Respuesta Then
                    precios.Emp_Id = EmpresaInfo.Emp_Id
                    precios.Precio_Id = CmbTipoPrecio.SelectedValue
                    VerificaMensaje(precios.AjusteMargenes(IIf(ChkSucusales.Checked, -1, SucursalInfo.Suc_Id), TxtMargen.Text))
                    Mensaje("Margenes de precios ajustados exitosamente")
                End If
            End If



        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles ChkSucusales.CheckedChanged

    End Sub

    Private Sub FrmAjusteMargenMasivo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            BtnAceptar.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            BtnSalir.PerformClick()
        End If
    End Sub
End Class