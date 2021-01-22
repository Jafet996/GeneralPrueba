Imports Business
Public Class FrmListaArticulos
    Public Enum EnumFuncionalidad
        AjusteCosto = 0
        CambioPrecio = 1
    End Enum

    Private _Funcionalidad As EnumFuncionalidad


    Private _Art_Id As String

    Public ReadOnly Property Art_Id As String
        Get
            Return _Art_Id
        End Get
    End Property


    Public Sub Execute(pFuncionalidad As EnumFuncionalidad)
        _Funcionalidad = pFuncionalidad
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
        Buscar()
    End Sub


    Private Sub Buscar()
        Dim Articulo As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            Articulo.Suc_Id = 1
            Articulo.Bod_Id = 1

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
            DGDetalle.Columns(1).Width = 300
            DGDetalle.Columns(2).Width = 50
            DGDetalle.Columns(3).Width = 80
            DGDetalle.Columns(4).Width = 80
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

    Private Sub AjusteCosto(pArt_Id As String)
        Dim Forma As New FrmAjusteCosto
        Try

            Forma.Art_Id = pArt_Id
            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub CambioPrecio(pArt_Id As String)
        Dim Forma As New FrmArticuloBodega
        Try

            Forma.Art_Id = pArt_Id
            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub Seleccionar()
        Try
            If DGDetalle.CurrentCell Is Nothing Then
                VerificaMensaje("Debe de seleccionar un valor")
            End If

            _Art_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value

            Select Case _Funcionalidad
                Case EnumFuncionalidad.AjusteCosto
                    AjusteCosto(_Art_Id)
                Case EnumFuncionalidad.CambioPrecio
                    CambioPrecio(_Art_Id)
            End Select

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


    Private Sub DGDetalle_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDetalle.CellContentClick

    End Sub
End Class