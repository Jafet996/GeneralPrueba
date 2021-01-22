Imports Business
Public Class FrmBusquedaCliente
    Private _Cliente_Id As Integer
    Private _Selecciono As Boolean

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
            Case Keys.F2
                If DGDetalle.Rows.Count > 0 Then
                    DGDetalle.Rows(0).Selected = True
                    DGDetalle.Focus()
                End If
            Case Keys.Enter
                BtnBuscar.PerformClick()
        End Select
    End Sub

    Private Sub TxtCriterio_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCriterio.TextChanged
        'BtnBuscar.Enabled = (TxtCriterio.Text.Trim <> "")
    End Sub

    Private Sub BtnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles BtnBuscar.Click
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            _Selecciono = False

            If TxtCriterio.Text.Trim = "" Then
                TxtCriterio.Text = "%%%"
            End If

            DGDetalle.DataSource = Nothing
            DGDetalle.Rows.Clear()

            With Cliente
                .Emp_Id = CajaInfo.Emp_Id
            End With

            Mensaje = Cliente.ListBusqueda(TxtCriterio.Text.Trim)
            VerificaMensaje(Mensaje)
            If Cliente.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron clientes relacionados con esta descripción")
            End If

            DGDetalle.DataSource = Cliente.Data.Tables(0)

            DGDetalle.Columns(0).Width = 100
            DGDetalle.Columns(1).Width = 380


            DGDetalle.Focus()


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
End Class