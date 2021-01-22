Imports System.Windows.Forms
Imports Business
Public Class FrmMantSubCategoriaLista
    Private coTitulo = "Sub Categorías"

    Public Sub Execute()
        Try

            Me.Text = coTitulo
            LblTitulo.Text = coTitulo
            Refrescar()
            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnRefrescar_Click(sender As System.Object, e As System.EventArgs) Handles BtnRefrescar.Click
        Refrescar()
    End Sub

    Private Sub Refrescar()
        Dim SubCategoria As New TSubCategoria(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            DGDetalle.DataSource = Nothing

            Mensaje = SubCategoria.List()
            VerificaMensaje(Mensaje)

            DGDetalle.DataSource = SubCategoria.Data.Tables(0)


            DGDetalle.Columns(0).HeaderText = "Categoría"
            DGDetalle.Columns(1).HeaderText = "Nombre"
            DGDetalle.Columns(2).HeaderText = "SubCategoría"
            DGDetalle.Columns(3).HeaderText = "Nombre"
            DGDetalle.Columns(0).Width = 80
            DGDetalle.Columns(1).Width = 163
            DGDetalle.Columns(2).Width = 80
            DGDetalle.Columns(3).Width = 163

            BtnModificar.Enabled = (DGDetalle.RowCount > 0)
            BtnEliminar.Enabled = (DGDetalle.RowCount > 0)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            SubCategoria = Nothing
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMantSubCategoriaLista_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                Refrescar()
        End Select
    End Sub

    Private Sub BtnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEliminar.Click
        Eliminar()
    End Sub
    Private Sub Eliminar()
        Dim SubCategoria As New TSubCategoria(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            If DGDetalle.SelectedCells Is Nothing OrElse DGDetalle.SelectedCells.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un registro")
            End If

            If MsgBox("Desea eliminar el registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                Exit Sub
            End If


            SubCategoria.Cat_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value
            SubCategoria.SubCat_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(2).Value
            Mensaje = SubCategoria.Delete()
            VerificaMensaje(Mensaje)

            Refrescar()

        Catch ex As Exception
            MensajeError(ex.Message, "Mantenimiento")
        Finally
            SubCategoria = Nothing
        End Try
    End Sub


    Private Sub Modificar()
        Dim Forma As New FrmMantSubCategoriaDetalle
        Dim Categoria As Integer
        Dim Codigo As Integer = -1
        Try

            If DGDetalle.SelectedCells Is Nothing OrElse DGDetalle.SelectedCells.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un registro")
            End If

            Categoria = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value
            Codigo = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(2).Value

            Forma.Titulo = coTitulo
            Forma.Nuevo = False
            Forma.Execute(Categoria, Codigo)

            If Forma.GuardoCambios Then
                Refrescar()
            End If

        Catch ex As Exception
            MensajeError(ex.Message, "Mantenimiento")
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click
        Dim Forma As New FrmMantSubCategoriaDetalle
        Dim Mensaje As String = ""
        Try



            Forma.Titulo = coTitulo
            Forma.Nuevo = True
            Forma.Execute(-1, -1)

            If Forma.GuardoCambios Then
                Refrescar()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnModificar_Click(sender As System.Object, e As System.EventArgs) Handles BtnModificar.Click
        Modificar()
    End Sub

    Private Sub DGDetalle_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDetalle.CellContentDoubleClick
        Modificar()
    End Sub

    Private Sub DGDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DGDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                Modificar()
            Case Keys.Delete
                Eliminar()
        End Select
    End Sub

End Class