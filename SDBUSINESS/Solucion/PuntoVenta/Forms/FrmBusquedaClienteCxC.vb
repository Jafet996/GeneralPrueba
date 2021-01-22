Imports Business
Public Class FrmBusquedaClienteCxC
    Private _Cliente_Id As Integer
    Private _Selecciono As Boolean
    Dim tipoBusqueda As Integer = 1

    Public ReadOnly Property Cliente_Id As Integer
        Get
            Return _Cliente_Id
        End Get
    End Property
    Public ReadOnly Property Selecciono As Boolean
        Get
            Return _Selecciono
        End Get
    End Property


    Public Sub Execute()
        _Selecciono = False
        _Cliente_Id = 0
        Me.ShowDialog()
    End Sub

    Private Sub TxtCriterio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCriterio.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                If DGDetalle.Rows.Count > 0 Then
                    DGDetalle.Rows(0).Selected = True
                    DGDetalle.Focus()
                End If
            Case Keys.Enter
                If TxtCriterio.Text <> "" Then
                    Buscar()
                End If
        End Select
    End Sub

    Private Sub TxtCriterio_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCriterio.TextChanged
        If TxtCriterio.Text.Trim.Length >= 3 And EmpresaParametroInfo.BusquedaClienteOnline Then
            Buscar()
        Else
            DGDetalle.DataSource = Nothing
            DGDetalle.Rows.Clear()
        End If
    End Sub

    Private Sub Buscar()
        Dim Cliente As New TCxC_Cliente()
        Dim Mensaje As String = ""
        Try

            If TxtCriterio.Text.Trim = "" Then

                DGDetalle.DataSource = Nothing
                DGDetalle.Rows.Clear()
                Exit Sub
            End If

            DGDetalle.DataSource = Nothing
            DGDetalle.Rows.Clear()

            Cliente.Emp_Id = EmpresaInfo.Emp_Id
            Mensaje = Cliente.ListBusqueda(TxtCriterio.Text.Trim, tipoBusqueda)
            VerificaMensaje(Mensaje)
            If Cliente.RowsAffected = 0 Then
                LblMensaje.Text = "No se encontraron datos relacionados"
            Else
                LblMensaje.Text = ""
            End If

            DGDetalle.DataSource = Cliente.Datos.Tables(0)

            DGDetalle.Columns(0).Width = 100
            DGDetalle.Columns(1).Width = 380
            DGDetalle.Columns(2).Width = 100
            DGDetalle.Columns(3).Width = 165

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
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

            _Cliente_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value
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

    Private Sub RdbNombre_CheckedChanged(sender As Object, e As EventArgs) Handles RdbNombre.CheckedChanged
        Try
            If RdbNombre.Checked Then
                RdbCedula.Checked = False
                tipoBusqueda = 1
                TxtCriterio.Focus()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub RdbCedula_CheckedChanged(sender As Object, e As EventArgs) Handles RdbCedula.CheckedChanged
        Try
            If RdbCedula.Checked Then
                RdbNombre.Checked = False
                tipoBusqueda = 2
                TxtCriterio.Focus()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class