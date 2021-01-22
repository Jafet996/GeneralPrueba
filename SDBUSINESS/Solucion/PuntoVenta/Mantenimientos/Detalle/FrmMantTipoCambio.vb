Imports Business
Public Class FrmMantTipoCambio
    Private Numerico() As TNumericFormat

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(1)



            Numerico(0) = New TNumericFormat(TxtCompra, 6, 2, False, "", "#,##0.00")
            Numerico(1) = New TNumericFormat(TxtVenta, 6, 2, False, "", "#,##0.00")


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute()
        Try

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmMantTipoCambio_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FormateaCamposNumericos()
        CargaLista()
    End Sub

    Private Sub CargaLista()
        Dim TipoCambio As New TTipoCambio()
        Dim Items(3) As String
        Dim Item As ListViewItem = Nothing
        Dim Mensaje As String = ""
        Try
            LvwDetalle.Items.Clear()

            Mensaje = TipoCambio.List()
            VerificaMensaje(Mensaje)

            For Each Row As DataRow In TipoCambio.Data.Tables(0).Rows
                Items(0) = Row("TipoCambio_Id")
                Items(1) = Row("Fecha")
                Items(2) = Row("Compra")
                Items(3) = Row("Venta")

                Item = New ListViewItem(Items)

                LvwDetalle.Items.Add(Item)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TipoCambio = Nothing
        End Try
    End Sub

    Private Function ValidaTodo() As String
        Try

            If Not IsNumeric(TxtCompra.Text) OrElse CDbl(TxtCompra.Text) <= 0 Then
                TxtCompra.Focus()
                VerificaMensaje("El tipo de compra debe de ser mayor a cero")
            End If

            If Not IsNumeric(TxtVenta.Text) OrElse CDbl(TxtVenta.Text) <= 0 Then
                TxtCompra.Focus()
                VerificaMensaje("El tipo de venta debe de ser mayor a cero")
            End If


            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Sub BtnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAgregar.Click
        Dim TipoCambio As New TTipoCambio()
        Dim Mensaje As String = ""
        Try

            VerificaMensaje(ValidaTodo())

            TipoCambio.Compra = CDbl(TxtCompra.Text)
            TipoCambio.Venta = CDbl(TxtVenta.Text)

            Mensaje = TipoCambio.Insert()
            VerificaMensaje(Mensaje)

            TxtCompra.Text = ""
            TxtVenta.Text = ""

            CargaLista()

            MsgBox("El tipo de cambio se agregó correctamente", MsgBoxStyle.Information, Me.Text)

            TxtCompra.Focus()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TipoCambio = Nothing
        End Try
    End Sub

    Private Sub TxtCompra_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCompra.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TxtVenta.Focus()
        End Select
    End Sub

    Private Sub TxtVenta_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtVenta.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                BtnAgregar.Focus()
        End Select
    End Sub

    Private Sub LvwDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles LvwDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                If ConfirmaAccion("Desea eliminar el tipo de cambio?") Then
                    EliminaTipoCambio()
                End If
        End Select
    End Sub
    Private Sub EliminaTipoCambio()
        Dim TipoCambio As New TTipoCambio()
        Dim Mensaje As String = ""
        Try

            If LvwDetalle.SelectedItems Is Nothing OrElse LvwDetalle.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un detalle de la lista")
            End If


            TipoCambio.TipoCambio_Id = LvwDetalle.SelectedItems(0).Text
            Mensaje = TipoCambio.Delete()
            VerificaMensaje(Mensaje)

            CargaLista()

            MsgBox("El tipo de cambio se eliminó correctamente", MsgBoxStyle.Information, Me.Text)

            TxtCompra.Focus()


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TipoCambio = Nothing
        End Try
    End Sub

    Private Sub LvwDetalle_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles LvwDetalle.SelectedIndexChanged

    End Sub
End Class