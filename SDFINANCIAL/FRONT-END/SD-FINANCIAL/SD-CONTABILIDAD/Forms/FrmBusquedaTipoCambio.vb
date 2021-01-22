Imports BUSINESS
Public Class FrmBusquedaTipoCambio
#Region "Variables"
    Private _TipoCambioSeleccionado As Char = ""
    Private _TipoCambioCompra As Double = 0.0
    Private _TipoCambioVenta As Double = 0.0
    Private _Selecciono As Boolean = False
#End Region
#Region "Propiedades"
    Public ReadOnly Property TipoCambioSeleccionado As Char
        Get
            Return _TipoCambioSeleccionado
        End Get
    End Property
    Public ReadOnly Property TipoCambioCompra As Double
        Get
            Return _TipoCambioCompra
        End Get
    End Property
    Public ReadOnly Property TipoCambioVenta As Double
        Get
            Return _TipoCambioVenta
        End Get
    End Property
    Public ReadOnly Property Selecciono As Boolean
        Get
            Return _Selecciono
        End Get
    End Property
#End Region

    Public Sub Execute()
        Buscar()

        Me.ShowDialog()
    End Sub

    Private Sub Buscar()
        Dim TipoCambio As New TTipoCambio
        Dim TipoBusqueda As Char = "T"

        Try
            If RdbTodos.Checked Then
                TipoBusqueda = "T"
            Else
                TipoBusqueda = "F"
            End If

            If TipoBusqueda = "F" Then
                If DateValue(DtpFechaIni.Value) > DateValue(DtpFechaFin.Value) Then
                    DGDetalle.DataSource = Nothing
                    DGDetalle.Rows.Clear()
                    VerificaMensaje("La fecha de inicio no puede ser mayor a la de finalización")
                End If
            End If

            DGDetalle.DataSource = Nothing
            DGDetalle.Rows.Clear()

            VerificaMensaje(TipoCambio.ListBusqueda(TipoBusqueda, DtpFechaIni.Value, DateAdd(DateInterval.Day, 1, DtpFechaFin.Value)))

            If TipoCambio.RowsAffected = 0 Then
                LblMensaje.Text = "No se encontraron datos relacionados"
            Else
                LblMensaje.Text = ""
            End If

            DGDetalle.DataSource = TipoCambio.Datos.Tables(0)

            If DGDetalle.Columns.Count = 0 Then
                Exit Sub
            End If

            DGDetalle.Columns(0).Width = 200
            DGDetalle.Columns(0).DefaultCellStyle.Format = "dd/MM/yyyy"
            DGDetalle.Columns(1).Width = 200
            DGDetalle.Columns(1).DefaultCellStyle.Format = "#,##0.00"
            DGDetalle.Columns(2).Width = 200
            DGDetalle.Columns(2).DefaultCellStyle.Format = "#,##0.00"

            If DGDetalle.Rows.Count > 0 Then
                DGDetalle.Rows(0).Selected = True
                DGDetalle.Focus()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TipoCambio = Nothing
        End Try
    End Sub

    Private Sub Seleccionar()
        Try
            If DGDetalle.CurrentCell Is Nothing Then
                VerificaMensaje("Debe de seleccionar un valor")
            End If

            If DGDetalle.CurrentCell.ColumnIndex = 0 Then
                VerificaMensaje("Debe de seleccionar entre el tipo de cambio de compra y el de venta")
            End If

            _TipoCambioSeleccionado = IIf(DGDetalle.CurrentCell.ColumnIndex = 1, coTipoCambioCompra, coTipoCambioVenta)
            _TipoCambioCompra = CDbl(DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(1).Value)
            _TipoCambioVenta = CDbl(DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(2).Value)
            _Selecciono = True

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub RdbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles RdbTodos.CheckedChanged
        Buscar()
        DtpFechaIni.Enabled = Not RdbTodos.Checked
        DtpFechaFin.Enabled = Not RdbTodos.Checked
    End Sub

    Private Sub RdbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles RdbFecha.CheckedChanged
        Buscar()
        DtpFechaIni.Enabled = RdbFecha.Checked
        DtpFechaFin.Enabled = RdbFecha.Checked
    End Sub

    Private Sub DtpFechaIni_ValueChanged(sender As Object, e As EventArgs) Handles DtpFechaIni.ValueChanged
        Buscar()
    End Sub

    Private Sub DtpFechaFin_ValueChanged(sender As Object, e As EventArgs) Handles DtpFechaFin.ValueChanged
        Buscar()
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

    Private Sub FrmBusquedaTipoCambio_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

End Class