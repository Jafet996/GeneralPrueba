Imports Business

Public Class FrmEntradaEscaneo

    Dim Numerico() As TNumericFormat

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtCantidad, 9, 4, False, "1.0000", "##0.0000")
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
                    VerificaArticulo()
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub VerificaArticulo()
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim Forma As FrmEntradaMercaderia

        Try
            'Busca en la lista de detalles si existe
            Forma = My.Application.OpenForms("FrmEntradaMercaderia")

            'Busca el articulo para verificar si menaje lotes
            With Articulo
                .Emp_Id = EmpresaInfo.Emp_Id
                .Art_Id = TxtArticulo.Text.Trim.ToString()
            End With

            VerificaMensaje(Articulo.ListKey())
            If Articulo.RowsAffected = 0 Then
                TxtArticulo.SelectAll()
                VerificaMensaje("El código de artículo no es válido")
            End If

            If Forma.VerificaArticulo(TxtArticulo.Text.Trim) <> String.Empty Then
                TxtArticulo.SelectAll()
                VerificaMensaje("El artículo no se encontró en la entrada de mercadería")
            End If

            TxtDescripcion.Text = Articulo.Nombre
            TxtArticulo.ReadOnly = True
            GrpBoxDatos.Visible = True

            If Not Articulo.Lote Then
                LblVencimiento.Visible = False
                LblLote.Visible = False
                TxtLote.Visible = False
                DtpVencimiento.Visible = False
                GrpBoxDatos.Height = 68
            Else
                LblVencimiento.Visible = True
                LblLote.Visible = True
                TxtLote.Visible = True
                DtpVencimiento.Visible = True
                GrpBoxDatos.Height = 178
            End If

            BtnAceptar.Enabled = True
            TxtCantidad.Focus()
            TxtCantidad.SelectAll()
            BtnSalir.Text = "Cancelar"
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub Inicializa()
        Try
            BtnAceptar.Enabled = False
            BtnSalir.Text = "Salir"
            TxtCantidad.Text = 1
            TxtArticulo.Text = ""
            TxtDescripcion.Text = ""
            TxtArticulo.ReadOnly = False
            TxtArticulo.Focus()
            DtpVencimiento.Value = Now()
            TxtLote.Text = ""
            GrpBoxDatos.Visible = False
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub RegistraCantidad()
        Dim Forma As FrmEntradaMercaderia

        Try
            If Not IsNumeric(TxtCantidad.Text) Then
                TxtCantidad.Select()
                VerificaMensaje("Debe de ingresar un valor numérico")
            End If

            If TxtArticulo.Text.Trim.Length = 0 Then
                TxtArticulo.Select()
                VerificaMensaje("Debe de ingresar un artículo")
            End If

            Forma = My.Application.OpenForms("FrmEntradaMercaderia")
            VerificaMensaje(Forma.IngresaEscaneoArticulo(TxtArticulo.Text, TxtCantidad.Text, TxtLote.Text, DateValue(DtpVencimiento.Value)))
        Catch ex As Exception
            TxtCantidad.Select()
            Throw ex
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        If TxtArticulo.ReadOnly Then
            Inicializa()
        Else
            Me.Close()
        End If
    End Sub

    Public Sub Execute()
        Try
            FormateaCamposNumericos()
            GrpBoxDatos.Visible = False
            BtnAceptar.Enabled = False
            TxtArticulo.Select()
            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtLote.Visible Then

                TxtLote.Focus()

            Else

                BtnAceptar.PerformClick()

            End If
        End If
    End Sub

    Private Sub TxtLote_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLote.KeyDown
        If e.KeyCode = Keys.Enter Then
            DtpVencimiento.Focus()
        End If
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try
            VerificaMensaje(ValidaTodo)
            RegistraCantidad()
            Inicializa()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaTodo() As String
        Dim Forma As New FrmEntradaMercaderia
        Dim Mensaje As String = String.Empty
        Try

            Forma = My.Application.OpenForms("FrmEntradaMercaderia")

            If Not IsNumeric(TxtCantidad.Text) OrElse CDbl(TxtCantidad.Text) = 0 Then
                TxtCantidad.Select()
                VerificaMensaje("La cantidad no puede ser 0 ó estar vacio.")
            End If

            If TxtLote.Visible And TxtLote.Text = "" Then
                TxtLote.Focus()
                TxtLote.SelectAll()
                VerificaMensaje("El lote no puede estar vacio.")
            End If

            If DtpVencimiento.Value.Date < Now.Date Then
                DtpVencimiento.Select()
                VerificaMensaje("La fecha de vencimiento no puede ser menor a la actual.")
            End If

            'Mensaje = Forma.VerificaLoteVencimiento(TxtArticulo.Text.Trim, TxtLote.Text.Trim, DateValue(DtpVencimiento.Value))
            'If Mensaje <> String.Empty Then
            '    TxtLote.Focus()
            '    TxtLote.SelectAll()
            '    VerificaMensaje(Mensaje)
            'End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Forma = Nothing
        End Try
    End Function

    Private Sub FrmEntradaEscaneo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                BtnSalir.PerformClick()
            ElseIf e.KeyCode = Keys.F3 Then
                BtnAceptar.PerformClick()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub DtpVencimiento_KeyDown(sender As Object, e As KeyEventArgs) Handles DtpVencimiento.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnAceptar.PerformClick()
        End If
    End Sub

End Class