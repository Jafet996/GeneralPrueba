Imports Business
Public Class FrmMantGrupoLista
    Private coTitulo = "Grupo"

    Public Sub Execute()
        Me.Text = coTitulo
        LblTitulo.Text = coTitulo
        Refrescar()
        Me.Show()
    End Sub

    Private Sub BtnRefrescar_Click(sender As System.Object, e As System.EventArgs) Handles BtnRefrescar.Click
        Refrescar()
    End Sub

    Private Sub Refrescar()
        Dim Grupo As New TGrupo(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            DGDetalle.DataSource = Nothing

            Mensaje = Grupo.ListaMantenimiento(TxtCriterio.Text.Trim)
            VerificaMensaje(Mensaje)

            DGDetalle.DataSource = Grupo.Data.Tables(0)

            DGDetalle.Columns(0).HeaderText = "Código"
            DGDetalle.Columns(1).HeaderText = "Nombre"
            DGDetalle.Columns(0).Width = 100
            DGDetalle.Columns(1).Width = 345

            BtnModificar.Enabled = (DGDetalle.RowCount > 0)
            BtnEliminar.Enabled = (DGDetalle.RowCount > 0)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Grupo = Nothing
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMantGrupoLista_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        Dim Grupo As New TGrupo(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            If DGDetalle.SelectedCells Is Nothing OrElse DGDetalle.SelectedCells.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un registro")
            End If

            If MsgBox("Desea eliminar el registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                Exit Sub
            End If


            Grupo.Grupo_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value
            Mensaje = Grupo.Delete()
            VerificaMensaje(Mensaje)

            Refrescar()

        Catch ex As Exception
            MensajeError(ex.Message, "Mantenimiento")
        Finally
            Grupo = Nothing
        End Try
    End Sub


    Private Sub Modificar()
        Dim Forma As New FrmMantGrupoDetalle
        Dim Codigo As Integer = -1
        Try

            If DGDetalle.SelectedCells Is Nothing OrElse DGDetalle.SelectedCells.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un registro")
            End If


            Codigo = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value

            Forma.Titulo = coTitulo
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

    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click
        Dim Forma As New FrmMantGrupoDetalle
        Dim Mensaje As String = ""
        Try

            Forma.Titulo = coTitulo
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

    Private Sub TxtCriterio_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCriterio.TextChanged
        If TxtCriterio.Text.Trim <> "" Then
            PicBorrar.Image = Inventario.My.Resources.Resources.delete
        Else
            PicBorrar.Image = Nothing
        End If
        Refrescar()
    End Sub


    Private Sub PicBorrar_Click(sender As System.Object, e As System.EventArgs) Handles PicBorrar.Click
        TxtCriterio.Text = ""
    End Sub
End Class