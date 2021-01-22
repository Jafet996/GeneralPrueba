Imports Business
Public Class FrmMuestraValores
    Private _ObjetoTabla As Object
    Private _Seleccion_Id As Object
    Private _Titulo As String

    Public WriteOnly Property ObjetoTabla As Object
        Set(value As Object)
            _ObjetoTabla = value
        End Set
    End Property
    Public WriteOnly Property Titulo As String
        Set(value As String)
            _Titulo = value
        End Set
    End Property
    Public ReadOnly Property Seleccion_Id As Object
        Get
            Return _Seleccion_Id
        End Get
    End Property

    Public Sub Execute()
        Dim Mensaje As String = ""
        Try
            Me.Text = _Titulo

            _Seleccion_Id = Nothing

            DGDetalle.DataSource = Nothing
            DGDetalle.Rows.Clear()

            Mensaje = _ObjetoTabla.list()
            VerificaMensaje(Mensaje)
            If _ObjetoTabla.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos")
            End If

            DGDetalle.DataSource = _ObjetoTabla.Data.Tables(0)

            DGDetalle.Columns(0).Width = 50
            DGDetalle.Columns(1).Width = 190

            BtnAceptar.Enabled = True

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Seleccionar()
        Try
            If DGDetalle.CurrentCell Is Nothing Then
                VerificaMensaje("Debe de seleccionar un valor")
            End If

            _Seleccion_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        Seleccionar()
    End Sub

    Private Sub DGDetalle_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDetalle.CellContentDoubleClick
        Try
            If DGDetalle.CurrentCell Is Nothing Then
                VerificaMensaje("Debe de seleccionar un valor")
            End If

            _Seleccion_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub
    Private Sub DGDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DGDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.F2, Keys.Enter
                Seleccionar()
        End Select
    End Sub

    Private Sub DGDetalle_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDetalle.CellContentClick

    End Sub
End Class