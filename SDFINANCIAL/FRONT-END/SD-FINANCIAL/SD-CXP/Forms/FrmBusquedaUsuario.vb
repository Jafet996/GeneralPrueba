Imports Business
Public Class FrmBusquedaUsuario
#Region "Variables"
    Private _Usuario_Id As String
    Private _Selecciono As Boolean
#End Region
#Region "Propiedades"
    Public ReadOnly Property Usuario_Id As String
        Get
            Return _Usuario_Id
        End Get
    End Property
    Public ReadOnly Property Selecciono As Boolean
        Get
            Return _Selecciono
        End Get
    End Property
#End Region

    Public Sub Execute()
        _Selecciono = False
        _Usuario_Id = 0

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
        Dim Usuario As New TUsuario()

        Try
            _Selecciono = False

            If TxtCriterio.Text.Trim = "" Then
                VerificaMensaje("Debe de digitar una descripción")
            End If

            DGDetalle.DataSource = Nothing
            DGDetalle.Rows.Clear()

            Usuario.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(Usuario.ListMant(TxtCriterio.Text.Trim))
            If Usuario.RowsAffected = 0 Then
                TxtCriterio.SelectAll()
                TxtCriterio.Focus()
                VerificaMensaje("No se encontraron usuarios relacionados con esta descripción")
            End If

            DGDetalle.DataSource = Usuario.Datos.Tables(0)

            DGDetalle.Columns(0).Width = 100
            DGDetalle.Columns(1).Width = 380

            DGDetalle.Focus()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Usuario = Nothing
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

            _Usuario_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value
            _Selecciono = True

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmBusquedaArticulo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub
End Class