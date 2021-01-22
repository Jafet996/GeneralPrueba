Imports System.Windows.Forms
Imports Business
Public Class FrmOtroValor
    Dim _OtroValores As New List(Of TOtroValor)

    Public Property OtrosValores As List(Of TOtroValor)
        Get
            Return _OtroValores
        End Get
        Set(value As List(Of TOtroValor))
            _OtroValores = value
        End Set
    End Property

    Private Enum Columnas
        Etiqueta = 0
        Valor = 1
    End Enum

    Private Sub ConfiguraDetalle()
        Try

            With LvwDetalle
                .Columns(Columnas.Etiqueta).Text = "Etiqueta"
                .Columns(Columnas.Etiqueta).Width = 185

                .Columns(Columnas.Valor).Text = "Valor"
                .Columns(Columnas.Valor).Width = 185
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaCombos()
        Dim OtroValorEtiqueta As New TOtroValorEtiqueta(EmpresaInfo.Emp_Id)
        Try

            VerificaMensaje(OtroValorEtiqueta.LoadComboBox(CmbEtiqueta))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            OtroValorEtiqueta = Nothing
        End Try
    End Sub

    Private Sub CargaLista()
        Dim Item As ListViewItem = Nothing
        Dim Items(1) As String
        Try

            For Each valor As TOtroValor In _OtroValores
                Items(Columnas.Etiqueta) = valor.Etiqueta
                Items(Columnas.Valor) = valor.Valor

                Item = New ListViewItem(Items)

                LvwDetalle.Items.Add(Item)
            Next


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute()
        Try

            ConfiguraDetalle()
            CargaCombos()
            CargaLista()

            If CmbEtiqueta.Items.Count > 0 Then
                TxtValor.Select()
            Else
                CmbEtiqueta.Select()
            End If

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        Try

            AgregaValor()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub AgregaValor()
        Dim Item As ListViewItem
        Dim items(1) As String
        Try

            If CmbEtiqueta.Text.Trim = String.Empty Then
                VerificaMensaje("Debe de indicar una etiqueta")
                CmbEtiqueta.Select()
            End If

            If TxtValor.Text.Trim = String.Empty Then
                VerificaMensaje("Debe de indicar un valor")
                TxtValor.Select()
            End If

            items(Columnas.Etiqueta) = CmbEtiqueta.Text.Trim()
            items(Columnas.Valor) = TxtValor.Text.Trim()

            Item = New ListViewItem(items)

            LvwDetalle.Items.Add(Item)

            Item.EnsureVisible()

            CmbEtiqueta.Text = String.Empty
            TxtValor.Text = String.Empty
            CmbEtiqueta.Select()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try

            _OtroValores.Clear()

            For Each item As ListViewItem In LvwDetalle.Items
                _OtroValores.Add(New TOtroValor With {.Etiqueta = item.SubItems(Columnas.Etiqueta).Text, .Valor = item.SubItems(Columnas.Valor).Text})
            Next

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtValor_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtValor.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If TxtValor.Text.Trim <> String.Empty Then
                    BtnAgregar.PerformClick()
                End If
        End Select
    End Sub

    Private Sub CmbEtiqueta_KeyDown(sender As Object, e As KeyEventArgs) Handles CmbEtiqueta.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If CmbEtiqueta.Text.Trim <> String.Empty Then
                    TxtValor.Select()
                End If
        End Select
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        Try

            If Not ConfirmaAccion("Desea salir sin guardar los cambios?") Then
                Exit Sub
            End If

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LvwDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles LvwDetalle.KeyDown
        Try

            If LvwDetalle.SelectedItems Is Nothing OrElse LvwDetalle.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un valor")
            End If

            LvwDetalle.Items.Remove(LvwDetalle.SelectedItems(0))

            CmbEtiqueta.Select()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmOtroValor_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnAceptar.PerformClick()
        End Select
    End Sub

    Private Sub FrmOtroValor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class