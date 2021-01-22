Imports Business
Public Class FrmArticuloEstado
#Region "Enum"
    Private Enum ColumnaDetalle
        Art_Id = 0
        Nombre
        Precio
        PrecioMayorista
        Saldo
    End Enum
#End Region

    Public Sub Execute()
        CargaComboSucursal()
        ConfiguraLista()
        Me.ShowDialog()
    End Sub

    Private Sub CargaComboSucursal()
        Dim Sucursal As New TSucursal(EmpresaInfo.Emp_Id)

        Try
            VerificaMensaje(Sucursal.LoadComboBox(CmbSucursal))
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Sucursal = Nothing
        End Try
    End Sub

    Private Sub CargaComboBodega()
        Dim Bodega As New TBodega(EmpresaInfo.Emp_Id)

        Try
            If CmbSucursal.SelectedValue Is Nothing OrElse CmbSucursal.SelectedValue.ToString = "System.Data.DataRowView" Then
                Exit Sub
            End If

            Bodega.Suc_Id = CInt(CmbSucursal.SelectedValue)
            VerificaMensaje(Bodega.LoadComboBox(CmbBodega))
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Bodega = Nothing
        End Try
    End Sub

    Private Sub ConfiguraLista()
        Try
            With LvwArticulos
                .Columns(ColumnaDetalle.Art_Id).Text = "Código"
                .Columns(ColumnaDetalle.Art_Id).Width = 100

                .Columns(ColumnaDetalle.Nombre).Text = "Nombre"
                .Columns(ColumnaDetalle.Nombre).Width = 250

                .Columns(ColumnaDetalle.Precio).Text = "Precio"
                .Columns(ColumnaDetalle.Precio).Width = 80
                .Columns(ColumnaDetalle.Precio).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnaDetalle.PrecioMayorista).Text = "Mayorista"
                .Columns(ColumnaDetalle.PrecioMayorista).Width = 80
                .Columns(ColumnaDetalle.PrecioMayorista).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnaDetalle.Saldo).Text = "Saldo"
                .Columns(ColumnaDetalle.Saldo).Width = 40
                .Columns(ColumnaDetalle.Saldo).TextAlign = HorizontalAlignment.Right
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaLista()
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Item As ListViewItem = Nothing
        Dim Items(4) As String

        Try
            LvwArticulos.Items.Clear()

            If CmbBodega.SelectedValue Is Nothing OrElse CmbBodega.SelectedValue.ToString = "System.Data.DataRowView" Then
                Exit Sub
            End If

            With ArticuloBodega
                .Suc_Id = CmbSucursal.SelectedValue
                .Bod_Id = CmbBodega.SelectedValue
            End With
            VerificaMensaje(ArticuloBodega.ArticulosInactivos)

            For Each Fila As DataRow In ArticuloBodega.Data.Tables(0).Rows
                Items(ColumnaDetalle.Art_Id) = Fila("Art_Id")
                Items(ColumnaDetalle.Nombre) = Fila("Nombre")
                Items(ColumnaDetalle.Precio) = Format(Fila("Precio"), "#,##0.00")
                Items(ColumnaDetalle.PrecioMayorista) = Format(Fila("PrecioMayorista"), "#,##0.00")
                Items(ColumnaDetalle.Saldo) = Format(Fila("Saldo"), "#,##0")
                Item = New ListViewItem(Items)
                Item.Checked = True
                LvwArticulos.Items.Add(Item)
            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloBodega = Nothing
        End Try
    End Sub

    Private Sub Activar()
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)

        Try
            If LvwArticulos.CheckedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar los artículos que desea habilitar")
            End If

            With ArticuloBodega
                .Suc_Id = CmbSucursal.SelectedValue
                .Bod_Id = CmbBodega.SelectedValue
            End With
            VerificaMensaje(ArticuloBodega.HabilitaArticulo(LvwArticulos))

            CargaLista()
            Mensaje("El proceso se completó exitosamente")
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloBodega = Nothing
        End Try
    End Sub

    Private Sub BtnActivar_Click(sender As Object, e As EventArgs) Handles BtnActivar.Click
        Activar()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub CmbSucursal_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbSucursal.SelectedValueChanged
        CargaComboBodega()
    End Sub

    Private Sub CmbBodega_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbBodega.SelectedValueChanged
        CargaLista()
    End Sub

    Private Sub BtnRefrescar_Click(sender As Object, e As EventArgs) Handles BtnRefrescar.Click
        CargaLista()
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If LvwArticulos.Items.Count = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub BtnMarcarTodo_Click(sender As Object, e As EventArgs) Handles BtnMarcarTodo.Click
        Try
            For Each Item As ListViewItem In LvwArticulos.Items
                Item.Checked = True
            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnDesmarcarTodo_Click(sender As Object, e As EventArgs) Handles BtnDesmarcarTodo.Click
        Try
            For Each Item As ListViewItem In LvwArticulos.CheckedItems
                Item.Checked = False
            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnInvertirSeleccion_Click(sender As Object, e As EventArgs) Handles BtnInvertirSeleccion.Click
        Try
            For Each Item As ListViewItem In LvwArticulos.Items
                Item.Checked = Not Item.Checked
            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

End Class