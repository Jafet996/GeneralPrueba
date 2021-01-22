Imports Business
Public Class FrmMantListaSucursal
    Private coTitulo = "Sucursal"
    Private _GuardoCambios As Boolean
    Private _SucursalNuevo As Integer
    Public Sub Execute()
        Me.Text = coTitulo
        _GuardoCambios = False
        _SucursalNuevo = 0
        LblTitulo.Text = coTitulo
        Refrescar()
        Me.ShowDialog()
    End Sub
    Private Sub Refrescar()
        Dim Sucursal As New TSucursal(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            DGDetalle.DataSource = Nothing
            Mensaje = Sucursal.ListaMantenimientos(TxtCriterio.Text.Trim)
            VerificaMensaje(Mensaje)
            DGDetalle.DataSource = Sucursal.Data.Tables(0)
            DGDetalle.Columns(0).HeaderText = "Código"
            DGDetalle.Columns(0).Width = 100
            DGDetalle.Columns(1).HeaderText = "Nombre"
            DGDetalle.Columns(1).Width = 345
            DGDetalle.Columns(2).HeaderText = "Teléfono"
            DGDetalle.Columns(2).Width = 130
            DGDetalle.Columns(3).HeaderText = "Fax"
            DGDetalle.Columns(3).Width = 130
            DGDetalle.Columns(4).HeaderText = "Email"
            DGDetalle.Columns(4).Width = 345
            DGDetalle.Columns(5).HeaderText = "Direccion"
            DGDetalle.Columns(5).Width = 345
            DGDetalle.Columns(6).HeaderText = "Activo"
            DGDetalle.Columns(6).Width = 100
            BtnModificar.Enabled = (DGDetalle.RowCount > 0)
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Sucursal = Nothing
        End Try
    End Sub
    Private Sub NuevaSucursal()
        Dim Forma As New FrmMantSucursalDetalle
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
    Private Sub Modificar()
        Dim Forma As New FrmMantSucursalDetalle
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
    Private Sub Criterio()
        If TxtCriterio.Text.Trim <> "" Then
            PicBorrar.Image = Global.PuntoVenta.My.Resources.delete
        Else
            PicBorrar.Image = Nothing
        End If
        Refrescar()
    End Sub
    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click
        Modificar()
    End Sub
    Private Sub TxtCriterio_TextChanged(sender As Object, e As EventArgs) Handles TxtCriterio.TextChanged
        Criterio()
    End Sub
    Private Sub BtnRefrescar_Click(sender As Object, e As EventArgs) Handles BtnRefrescar.Click
        Refrescar()
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
End Class