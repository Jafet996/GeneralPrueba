Imports BUSINESS
Public Class FrmMantProveedorLista
#Region "Variables"
    Private coTitulo = "Proveedor"
#End Region

    Public Sub Execute()
        Me.Text = coTitulo
        LblTitulo.Text = coTitulo
        Refrescar()

        Me.ShowDialog()
    End Sub

    Private Sub Refrescar()
        Dim Proveedor As New TProveedor

        Try
            DGDetalle.DataSource = Nothing

            Proveedor.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(Proveedor.ListMant(TxtCriterio.Text.Trim))

            DGDetalle.DataSource = Proveedor.Datos.Tables(0)
            DGDetalle.Columns(0).HeaderText = "Código"
            DGDetalle.Columns(1).HeaderText = "Nombre"
            DGDetalle.Columns(0).Width = 100
            DGDetalle.Columns(1).Width = 345

            BtnModificar.Enabled = (DGDetalle.RowCount > 0)
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Proveedor = Nothing
        End Try
    End Sub

    Private Sub Nuevo()
        Dim Forma As New FrmMantProveedorDetalle

        Try
            With Forma
                .Titulo = coTitulo
                .Nuevo = True
                .Execute(-1)
            End With

            If Forma.GuardoCambios Then
                Refrescar()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub Modificar()
        Dim Forma As New FrmMantProveedorDetalle
        Dim Codigo As Integer = -1

        Try
            If DGDetalle.SelectedCells Is Nothing OrElse DGDetalle.SelectedCells.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un registro")
            End If

            Codigo = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value

            With Forma
                .Titulo = coTitulo
                .Nuevo = False
                .Execute(Codigo)
            End With

            If Forma.GuardoCambios Then
                Refrescar()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub Eliminar()
        Dim Proveedor As New TProveedor

        Try
            If DGDetalle.SelectedCells Is Nothing OrElse DGDetalle.SelectedCells.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un registro")
            End If

            If MsgBox("Desea eliminar el registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            Proveedor.Emp_Id = EmpresaInfo.Emp_Id
            Proveedor.Prov_Id = CInt(DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value)
            VerificaMensaje(Proveedor.Delete())

            Refrescar()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Proveedor = Nothing
        End Try
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Nuevo()
    End Sub

    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click
        Modificar()
    End Sub

    Private Sub BtnRefrescar_Click(sender As Object, e As EventArgs) Handles BtnRefrescar.Click
        Refrescar()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub DGDetalle_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGDetalle.CellContentDoubleClick
        Modificar()
    End Sub

    Private Sub DGDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles DGDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Modificar()
            Case Keys.F2
                Modificar()
            Case Keys.Delete
                Eliminar()
        End Select
    End Sub

    Private Sub TxtCriterio_TextChanged(sender As Object, e As EventArgs) Handles TxtCriterio.TextChanged
        If TxtCriterio.Text.Trim <> "" Then
            PicBorrar.Image = Global.SDCXP.My.Resources.delete
        Else
            PicBorrar.Image = Nothing
        End If

        Refrescar()
    End Sub

    Private Sub PicBorrar_Click(sender As Object, e As EventArgs) Handles PicBorrar.Click
        TxtCriterio.Text = ""
    End Sub

    Private Sub TxtCriterio_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCriterio.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                If DGDetalle.Rows.Count > 0 Then
                    DGDetalle.Rows(0).Selected = True
                    DGDetalle.Focus()
                End If
        End Select
    End Sub

    Private Sub FrmMantProveedorLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtCriterio.Select()
    End Sub

End Class