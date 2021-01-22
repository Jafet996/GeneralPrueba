Imports BUSINESS
Public Class FrmSolictaCxCMovimientos
#Region "Enums"
    Private Enum ColumnasDetalle
        TipoNombre = 0
        Mov_Id
        Tipo_Id
        Referencia
        Vence
        Monto
        Saldo
    End Enum
#End Region
#Region "Variables"
    Private _Cliente_Id As Integer = 0
    Private _Selecciono As Boolean = False
    Private _ListaMovimientos As New List(Of TCxCMovimientoLinea)
    Private _MontoTotal As Double = 0.0
    Private _CerrarPantalla As Boolean = False
#End Region
#Region "Propiedades"
    Public WriteOnly Property Cliente_Id As Integer
        Set(value As Integer)
            _Cliente_Id = value
        End Set
    End Property
    Public ReadOnly Property Selecciono As Boolean
        Get
            Return _Selecciono
        End Get
    End Property
    Public ReadOnly Property ListaMovimientos As List(Of TCxCMovimientoLinea)
        Get
            Return _ListaMovimientos
        End Get
    End Property
    Public ReadOnly Property MontoTotal As Double
        Get
            Return _MontoTotal
        End Get
    End Property
#End Region

    Public Sub Execute()
        ConfiguraLista()
        CargaLista()

        If Not _CerrarPantalla Then Me.ShowDialog()
    End Sub

    Private Sub ConfiguraLista()
        Try
            With LvwMovimientos
                .Columns(ColumnasDetalle.Mov_Id).Text = "Documento"
                .Columns(ColumnasDetalle.Mov_Id).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Mov_Id).Width = 80

                .Columns(ColumnasDetalle.Tipo_Id).Text = ""
                .Columns(ColumnasDetalle.Tipo_Id).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Tipo_Id).Width = 0

                .Columns(ColumnasDetalle.TipoNombre).Text = "Tipo"
                .Columns(ColumnasDetalle.TipoNombre).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.TipoNombre).Width = 150

                .Columns(ColumnasDetalle.Referencia).Text = "Referencia"
                .Columns(ColumnasDetalle.Referencia).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Referencia).Width = 320

                .Columns(ColumnasDetalle.Vence).Text = "Vence"
                .Columns(ColumnasDetalle.Vence).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Vence).Width = 80

                .Columns(ColumnasDetalle.Monto).Text = "Monto"
                .Columns(ColumnasDetalle.Monto).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Monto).Width = 120

                .Columns(ColumnasDetalle.Saldo).Text = "Saldo"
                .Columns(ColumnasDetalle.Saldo).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Saldo).Width = 120
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaLista()
        Dim CxCMovimiento As New TCxCMovimiento
        Dim Items(6) As String
        Dim Item As ListViewItem = Nothing

        Try
            LvwMovimientos.Items.Clear()

            With CxCMovimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cliente_Id = _Cliente_Id
            End With
            VerificaMensaje(CxCMovimiento.MovimientosClienteRecibo)

            If CxCMovimiento.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos")
            End If

            For Each Fila As DataRow In CxCMovimiento.Datos.Tables(0).Rows
                Items(ColumnasDetalle.Mov_Id) = Fila("Mov_Id")
                Items(ColumnasDetalle.TipoNombre) = UCase(Fila("TipoNombre"))
                Items(ColumnasDetalle.Tipo_Id) = Fila("Tipo_Id")
                Items(ColumnasDetalle.Referencia) = Fila("Referencia")
                Items(ColumnasDetalle.Vence) = Format(Fila("FechaVencimiento"), "dd/MM/yyyy")
                Items(ColumnasDetalle.Monto) = Format(Fila("Monto"), "#,##0.00")
                Items(ColumnasDetalle.Saldo) = Format(Fila("Saldo"), "#,##0.00")

                Item = New ListViewItem(Items)
                LvwMovimientos.Items.Add(Item)
            Next

        Catch ex As Exception
            _CerrarPantalla = True
            MensajeError(ex.Message)
            Me.Close()
        Finally
            CxCMovimiento = Nothing
        End Try
    End Sub

    Private Function Seleccionar() As String
        Dim Movimiento As TCxCMovimientoLinea

        Try
            _ListaMovimientos.Clear()

            If LvwMovimientos.CheckedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar al menos un movimiento para poder continuar")
            End If

            For Each Item As ListViewItem In LvwMovimientos.CheckedItems
                Movimiento = New TCxCMovimientoLinea

                With Movimiento
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Tipo_Id = CInt(Item.SubItems(ColumnasDetalle.Tipo_Id).Text.Trim)
                    .Mov_Id = CInt(Item.SubItems(ColumnasDetalle.Mov_Id).Text.Trim)
                    .Monto = CDbl(Item.SubItems(ColumnasDetalle.Saldo).Text.Trim)
                End With

                _ListaMovimientos.Add(Movimiento)
                _MontoTotal += Movimiento.Monto
            Next

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Sub MarcarTodos()
        Try
            For Each Item As ListViewItem In LvwMovimientos.Items
                Item.Checked = True
            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub DesmarcarTodo()
        Try
            For Each Item As ListViewItem In LvwMovimientos.CheckedItems
                Item.Checked = False
            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub InvertirSeleccion()
        Try
            For Each Item As ListViewItem In LvwMovimientos.Items
                Item.Checked = Not Item.Checked
            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub MarcarSeleccionados()
        Try
            For Each Item As ListViewItem In LvwMovimientos.SelectedItems
                Item.Checked = True
            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub DesmarcarSeleccionados()
        Try
            For Each Item As ListViewItem In LvwMovimientos.SelectedItems
                Item.Checked = False
            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try
            VerificaMensaje(Seleccionar)
            _Selecciono = True

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CalculaTotales()
        Dim Total As Double = 0.0

        Try
            LblTotalSaldo.Text = "0.00"

            If LvwMovimientos.CheckedItems.Count = 0 Then
                Exit Sub
            End If

            For Each Item As ListViewItem In LvwMovimientos.CheckedItems
                Total += CDbl(Item.SubItems(ColumnasDetalle.Saldo).Text.Trim)
            Next

            LblTotalSaldo.Text = Format(Total, "#,##0.00")
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub MnuMarcarTodo_Click(sender As Object, e As EventArgs) Handles MnuMarcarTodo.Click
        MarcarTodos()
    End Sub

    Private Sub MnuDesmarcarTodo_Click(sender As Object, e As EventArgs) Handles MnuDesmarcarTodo.Click
        DesmarcarTodo()
    End Sub

    Private Sub MnuInvertirSeleccion_Click(sender As Object, e As EventArgs) Handles MnuInvertirSeleccion.Click
        InvertirSeleccion()
    End Sub

    Private Sub MarcarSeleccionadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarcarSeleccionadosToolStripMenuItem.Click
        MarcarSeleccionados()
    End Sub

    Private Sub DesmarcarSeleccionadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesmarcarSeleccionadosToolStripMenuItem.Click
        DesmarcarSeleccionados()
    End Sub

    Private Sub FrmSolictaCxCMovimientos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnAceptar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub LvwMovimientos_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles LvwMovimientos.ItemChecked
        CalculaTotales()
    End Sub

    Private Sub CmsMenuSeleccion_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CmsMenuSeleccion.Opening
        If LvwMovimientos.SelectedItems Is Nothing OrElse LvwMovimientos.SelectedItems.Count = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub LblTotalSaldo_Click(sender As Object, e As EventArgs) Handles LblTotalSaldo.Click

    End Sub
End Class