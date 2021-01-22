Imports Business
Public Class FrmMantFamiliaArt
    Public Sub Execute()
        Me.Text = "Familia Artículo"
        LblTitulo.Text = "Familia Artículo"
        Refrescar()
        Me.Show()
    End Sub

    Private Sub Refrescar()
        Dim Familia As New TArticuloFamilia(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            DGDetalle.DataSource = Nothing

            Mensaje = Familia.ListaMantenimiento(TxtCriterio.Text.Trim)
            VerificaMensaje(Mensaje)

            DGDetalle.DataSource = Familia.Data.Tables(0)

            DGDetalle.Columns(0).HeaderText = "Código"
            DGDetalle.Columns(1).HeaderText = "Nombre"
            DGDetalle.Columns(0).Width = 100
            DGDetalle.Columns(1).Width = 345

            BtnModificar.Enabled = (DGDetalle.RowCount > 0)
            BtnEliminar.Enabled = (DGDetalle.RowCount > 0)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Familia = Nothing
        End Try
    End Sub

    Private Sub BtnRefrescar_Click(sender As Object, e As EventArgs) Handles BtnRefrescar.Click
        Refrescar()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
    Private Sub Eliminar()
        Dim Familia As New TArticuloFamilia(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            If DGDetalle.SelectedCells Is Nothing OrElse DGDetalle.SelectedCells.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un registro")
            End If

            If MsgBox("Desea eliminar el registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            Familia.Familia_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value
            Mensaje = Familia.DeleteArticulos()
            VerificaMensaje(Mensaje)

            Familia.Familia_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value
            Mensaje = Familia.Delete()
            VerificaMensaje(Mensaje)

            Refrescar()

        Catch ex As Exception
            MensajeError(ex.Message, "Mantenimiento")
        Finally
            Familia = Nothing
        End Try
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Eliminar()
    End Sub

    Private Sub FrmMantFamiliaArt_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                Refrescar()
        End Select
    End Sub

    Private Sub Modificar()
        Dim Forma As New FrmMantDetalleFamiliaArt
        Dim Codigo As Integer = -1
        Try

            If DGDetalle.SelectedCells Is Nothing OrElse DGDetalle.SelectedCells.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un registro")
            End If


            Codigo = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value

            Forma.Titulo = "Familia Artículo"
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
        Dim Forma As New FrmMantDetalleFamiliaArt
        Dim Mensaje As String = ""
        Try

            Forma.Titulo = "Familia Artículo"
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
            PicBorrar.Image = Global.Inventario.My.Resources.delete
        Else
            PicBorrar.Image = Nothing
        End If
        Refrescar()
    End Sub


    Private Sub PicBorrar_Click(sender As System.Object, e As System.EventArgs) Handles PicBorrar.Click
        TxtCriterio.Text = ""
    End Sub
End Class