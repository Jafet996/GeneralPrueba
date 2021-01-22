Imports Business
Public Class FrmBuscaArticuloTomaFisica
    Private _Art_Id As String
    Private _Bod_Id As Integer
    Private _TomaFisica_Id As Integer

    Public ReadOnly Property Art_Id As String
        Get
            Return _Art_Id
        End Get
    End Property

    Public Sub Execute(pBodega As Integer, pTomaFisica As Integer)
        _Art_Id = ""
        LblMensaje.Text = ""
        _Bod_Id = pBodega
        _TomaFisica_Id = pTomaFisica

        Me.ShowDialog()
    End Sub

    Private Sub Buscar()
        Dim Detalles As New TTomaFisicaDetalle(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""

        Try

            Detalles.Suc_Id = SucursalInfo.Suc_Id
            Detalles.Bod_Id = _Bod_Id
            Detalles.TomaFisica_Id = _TomaFisica_Id

            If TxtCriterio.Text.Trim = "" Then

                DGDetalle.DataSource = Nothing
                DGDetalle.Rows.Clear()
                Exit Sub
            End If

            DGDetalle.DataSource = Nothing
            DGDetalle.Rows.Clear()

            Mensaje = Detalles.ListBusqueda(TxtCriterio.Text.Trim)
            VerificaMensaje(Mensaje)

            If Detalles.RowsAffected = 0 Then
                LblMensaje.Text = "No se encontraron datos relacionados"
            Else
                LblMensaje.Text = ""
            End If

            DGDetalle.DataSource = Detalles.Data.Tables(0)

            DGDetalle.Columns(0).Width = 100
            DGDetalle.Columns(1).Width = 530
            DGDetalle.Columns(2).Width = 40

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Detalles = Nothing
        End Try
    End Sub

    Private Sub Seleccionar()
        Try
            If DGDetalle.CurrentCell Is Nothing Then
                VerificaMensaje("Debe de seleccionar un valor")
            End If

            _Art_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value
            _Bod_Id = Nothing
            _TomaFisica_Id = Nothing

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
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

    Private Sub TxtCriterio_TextChanged(sender As Object, e As EventArgs) Handles TxtCriterio.TextChanged
        If TxtCriterio.Text.Trim.Length >= 3 Then
            Buscar()
        End If
    End Sub

    Private Sub DGDetalle_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGDetalle.CellContentDoubleClick
        Seleccionar()
    End Sub

    Private Sub DGDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles DGDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.F2, Keys.Enter
                Seleccionar()
        End Select
    End Sub

    Private Sub FrmBuscaArticuloTomaFisica_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                TxtCriterio.SelectAll()
                TxtCriterio.Focus()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub
End Class