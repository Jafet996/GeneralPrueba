Imports Business
Public Class FrmMantRecetaLista
    Public Sub Execute()
        Me.Text = "Receta"
        LblTitulo.Text = "Receta"
        Refrescar()
        Me.Show()
    End Sub

    Private Sub Refrescar()
        Dim Receta As New TArticuloReceta(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            DGDetalle.DataSource = Nothing

            Mensaje = Receta.ListaMantenimiento(TxtCriterio.Text.Trim)
            VerificaMensaje(Mensaje)

            DGDetalle.DataSource = Receta.Data.Tables(0)

            DGDetalle.Columns(0).HeaderText = "Código"
            DGDetalle.Columns(1).HeaderText = "Nombre"
            DGDetalle.Columns(0).Width = 100
            DGDetalle.Columns(1).Width = 345

            BtnModificar.Enabled = (DGDetalle.RowCount > 0)
            BtnEliminar.Enabled = (DGDetalle.RowCount > 0)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Receta = Nothing
        End Try
    End Sub

    Private Sub BtnRefrescar_Click(sender As Object, e As EventArgs) Handles BtnRefrescar.Click
        Refrescar()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
    Private Sub Eliminar()
        Dim Receta As New TArticuloReceta(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            If DGDetalle.SelectedCells Is Nothing OrElse DGDetalle.SelectedCells.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un registro")
            End If

            If MsgBox("Desea eliminar el registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            'Receta.Ingrediente_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value
            'Mensaje = Receta.DeleteArticulos()
            'VerificaMensaje(Mensaje)

            Receta.Ingrediente_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value
            Mensaje = Receta.Delete()
            VerificaMensaje(Mensaje)

            Refrescar()

        Catch ex As Exception
            MensajeError(ex.Message, "Mantenimiento")
        Finally
            Receta = Nothing
        End Try
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Eliminar()
    End Sub

    Private Sub FrmMantRecetaLista_KeyDown(sender As Object, e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                Refrescar()
        End Select
    End Sub

    Private Sub Modificar()
        Dim Forma As New FrmMantRecetaDetalle
        Dim Codigo As String = "-1"
        Try

            If DGDetalle.SelectedCells Is Nothing OrElse DGDetalle.SelectedCells.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un registro")
            End If


            Codigo = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value.ToString()

            Forma.Titulo = "Receta"
            Forma.Nuevo = False
            Forma.Execute(Codigo)

            If Forma.GuardoCambios Then
                Refrescar()
            End If

        Catch ex As Exception
            MensajeError(ex.Message, "Mantenimiento")
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click
        Modificar()
    End Sub
    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click
        Dim Forma As New FrmMantRecetaDetalle
        Dim Mensaje As String = ""
        Try

            Forma.Titulo = "Receta"
            Forma.Nuevo = True
            Forma.Execute(-1)

            If Forma.GuardoCambios Then
                Refrescar()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub DGDetalle_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDetalle.CellContentDoubleClick
        Modificar()
    End Sub

    Private Sub TxtCriterio_TextChanged(sender As Object, e As EventArgs) Handles TxtCriterio.TextChanged
        Try
            Refrescar()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class