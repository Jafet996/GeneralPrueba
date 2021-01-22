Imports BUSINESS
Public Class FrmBusquedaCliente
#Region "Variables"
    Private _Cliente_Id As Integer = 0
    Private _Selecciono As Boolean = False
#End Region
#Region "Propiedades"
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
#End Region

    Public Sub Execute()
        Me.ShowDialog()
    End Sub

    Private Sub Buscar()
        Dim Cliente As New TCliente
        Dim TipoBusqueda As Integer = 0

        Try
            If TxtCriterio.Text.Trim = "" Then
                DGDetalle.DataSource = Nothing
                DGDetalle.Rows.Clear()
                Exit Sub
            End If

            DGDetalle.DataSource = Nothing
            DGDetalle.Rows.Clear()

            If RdbNombre.Checked Then
                TipoBusqueda = 1
            Else
                TipoBusqueda = 2
            End If

            Cliente.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(Cliente.ListBusqueda(TxtCriterio.Text.Trim, TipoBusqueda))

            If Cliente.RowsAffected = 0 Then
                LblMensaje.Text = "No se encontraron datos relacionados"
            Else
                LblMensaje.Text = ""
            End If

            DGDetalle.DataSource = Cliente.Datos.Tables(0)
            DGDetalle.Columns(0).Width = 100
            DGDetalle.Columns(1).Width = 300
            DGDetalle.Columns(2).Width = 150
            DGDetalle.Columns(3).Width = 120

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
        End Try
    End Sub

    Private Sub Seleccionar()
        Try
            If DGDetalle.CurrentCell Is Nothing Then
                VerificaMensaje("Debe de seleccionar un cliente de la lista")
            End If

            _Cliente_Id = CInt(DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value)
            _Selecciono = True

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub DGDetalle_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGDetalle.CellContentDoubleClick
        Seleccionar()
    End Sub

    Private Sub TxtCriterio_TextChanged(sender As Object, e As EventArgs) Handles TxtCriterio.TextChanged
        Buscar()
    End Sub

    Private Sub DGDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles DGDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.F2, Keys.Enter
                Seleccionar()
        End Select
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

    Private Sub FrmBusquedaCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub FrmBusquedaCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtCriterio.Select()
    End Sub

End Class