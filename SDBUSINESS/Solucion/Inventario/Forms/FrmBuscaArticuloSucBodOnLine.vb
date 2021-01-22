Imports Business
Public Class FrmBuscaArticuloSucBodOnLine
    Private _Suc_Id As Integer
    Private _Bod_Id As Integer
    Private _Art_Id As String


    Public WriteOnly Property Suc_Id As Integer
        Set(value As Integer)
            _Suc_Id = value
        End Set
    End Property
    Public WriteOnly Property Bod_Id As Integer
        Set(value As Integer)
            _Bod_Id = value
        End Set
    End Property

    Public ReadOnly Property Art_Id As String
        Get
            Return _Art_Id
        End Get
    End Property


    Public Sub Execute()
        _Art_Id = ""
        LblMensaje.Text = ""
        Me.ShowDialog()
    End Sub

    Private Sub TxtCriterio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCriterio.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                If DGDetalle.Rows.Count > 0 Then
                    DGDetalle.Rows(0).Selected = True
                    DGDetalle.Focus()
                End If
        End Select
    End Sub

    Private Sub TxtCriterio_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCriterio.TextChanged
        If TxtCriterio.Text.Trim.Length >= 3 Then
            Buscar()
        Else
            DGDetalle.DataSource = Nothing
            DGDetalle.Rows.Clear()
        End If

    End Sub


    Private Sub Buscar()
        Dim Articulo As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            Articulo.Suc_Id = _Suc_Id
            Articulo.Bod_Id = _Bod_Id

            If TxtCriterio.Text.Trim = "" Then
                DGDetalle.DataSource = Nothing
                DGDetalle.Rows.Clear()
                Exit Sub
            End If

            DGDetalle.DataSource = Nothing
            DGDetalle.Rows.Clear()

            Mensaje = Articulo.ListBusquedaInventario(TxtCriterio.Text.Trim)
            VerificaMensaje(Mensaje)
            If Articulo.RowsAffected = 0 Then
                LblMensaje.Text = "No se encontraron datos relacionados"
            Else
                LblMensaje.Text = ""
            End If

            DGDetalle.DataSource = Articulo.Data.Tables(0)

            DGDetalle.Columns(0).Width = 100
            DGDetalle.Columns(1).Width = 370
            DGDetalle.Columns(2).Width = 50
            DGDetalle.Columns(3).Width = 80
            DGDetalle.Columns(4).Width = 80
            DGDetalle.Columns(5).Width = 80
            DGDetalle.Columns(5).Width = 80
            DGDetalle.Columns(5).Width = 80
            DGDetalle.Columns(5).Width = 80


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
            Case Keys.F1
                TxtCriterio.SelectAll()
                TxtCriterio.Focus()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub
End Class