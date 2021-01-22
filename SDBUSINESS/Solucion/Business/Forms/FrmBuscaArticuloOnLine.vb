Imports System.Windows.Forms
Imports Business
Public Class FrmBuscaArticuloOnLine
    Private _Art_Id As String
    Private _Art_Nombre As String


    Public ReadOnly Property Art_Id As String
        Get
            Return _Art_Id
        End Get
    End Property
    Public ReadOnly Property Art_Nombre As String
        Get
            Return _Art_Nombre
        End Get
    End Property

    Public Sub Execute()
        _Art_Id = ""
        _Art_Nombre = String.Empty
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
            Case Keys.Enter
                If TxtCriterio.Text <> "" Then
                    Buscar()
                End If
        End Select
    End Sub
    Private Sub TxtCriterio_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCriterio.TextChanged
        If TxtCriterio.Text.Trim.Length >= 3 And EmpresaParametroInfo.BusquedaArticuloOnline Then
            Buscar()
        Else
            DGDetalle.DataSource = Nothing
            DGDetalle.Rows.Clear()
        End If

    End Sub


    Private Sub Buscar()
        Dim Articulo As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Dim TipoCriterio As Integer = 0
        Try

            Articulo.Suc_Id = SucursalInfo.Suc_Id
            Articulo.Bod_Id = SucursalParametroInfo.BodCompra_Id

            If TxtCriterio.Text.Trim = "" Then
                DGDetalle.DataSource = Nothing
                DGDetalle.Rows.Clear()
                Exit Sub
            End If


            If RdbDescripcion.Checked Then
                TipoCriterio = 1
            ElseIf RdbCodigo.Checked Then
                TipoCriterio = 2
            ElseIf RdbCodigoEquivalente.Checked Then
                TipoCriterio = 3
            ElseIf RdbCodigoPtoveedor.Checked Then
                TipoCriterio = 4
            ElseIf RdbCodigoInterno.Checked Then
                TipoCriterio = 5
            Else
                TipoCriterio = 1
            End If

            DGDetalle.DataSource = Nothing
            DGDetalle.Rows.Clear()

            Mensaje = Articulo.ListBusquedaInventarioOnLine(TxtCriterio.Text.Trim, TipoCriterio, IIf(RdbIniciaCon.Checked, 2, 1))
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
            'DGDetalle.Columns(5).Width = 80
            'DGDetalle.Columns(5).Width = 80
            'DGDetalle.Columns(5).Width = 80

            If TipoCriterio = 3 OrElse TipoCriterio = 4 OrElse TipoCriterio = 5 Then
                DGDetalle.Columns(6).Width = 80
            End If


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
            _Art_Nombre = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(1).Value

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

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FrmBuscaArticuloOnLine_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Me.Width = Screen.PrimaryScreen.WorkingArea.Size.Width
            Me.Height = Screen.PrimaryScreen.WorkingArea.Size.Height - 50
            Me.CenterToScreen()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class