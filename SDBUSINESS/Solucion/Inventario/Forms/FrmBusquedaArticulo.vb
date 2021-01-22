Imports Business
Public Class FrmBusquedaArticulo
    Private _Art_Id As String

    Public ReadOnly Property Art_Id As String
        Get
            Return _Art_Id
        End Get
    End Property


    Public Sub Execute()
        _Art_Id = ""
        Me.ShowDialog()
    End Sub

    Private Sub TxtCriterio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCriterio.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                If DGDetalle.Rows.Count > 0 Then
                    DGDetalle.Rows(0).Selected = True
                    DGDetalle.Focus()
                End If
        End Select
    End Sub

    Private Sub TxtCriterio_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCriterio.TextChanged
        BtnBuscar.Enabled = (TxtCriterio.Text.Trim <> "")
    End Sub

    Private Sub BtnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles BtnBuscar.Click
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            If TxtCriterio.Text.Trim = "" Then
                VerificaMensaje("Debe de digitar una descripción")
            End If

            DGDetalle.DataSource = Nothing
            DGDetalle.Rows.Clear()

            Mensaje = Articulo.ListBusqueda(TxtCriterio.Text.Trim)
            VerificaMensaje(Mensaje)
            If Articulo.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron artículos relacionados con esta descripción")
            End If

            DGDetalle.DataSource = Articulo.Data.Tables(0)

            DGDetalle.Columns(0).Width = 100
            DGDetalle.Columns(1).Width = 350
            DGDetalle.Columns(2).Width = 50

            DGDetalle.Focus()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Articulo = Nothing
        End Try
    End Sub


    Private Sub DGDetalle_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDetalle.CellContentDoubleClick
        Seleccionar()
    End Sub
    Private Sub DGDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DGDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.F2, Keys.Enter
                Seleccionar()
        End Select
    End Sub
    Private Sub Seleccionar()
        Try
            If DGDetalle.CurrentCell Is Nothing Then
                VerificaMensaje("Debe de seleccionar un valor")
            End If

            _Art_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub FrmBusquedaArticulo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                Limpiar()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub Limpiar()
        DGDetalle.DataSource = Nothing
        TxtCriterio.Text = ""
        TxtCriterio.Focus()
    End Sub
End Class