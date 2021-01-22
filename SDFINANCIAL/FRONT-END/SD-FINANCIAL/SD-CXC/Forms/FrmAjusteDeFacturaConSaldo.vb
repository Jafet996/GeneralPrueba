Imports BUSINESS

Class FrmAjusteDeFacturaConSaldo

    Private Enum ColumnasDetalle
        TipoNombre = 0
        Mov_Id
        Tipo_Id
        Referencia
        Vence
        Monto
        Saldo
        Tipo_Ajuste
        cliente
    End Enum

    Private Numerico() As TNumericFormat

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        If ValidaTodo() Then
            EjecutarRutina()
            ReiniciarInterface()
        End If
    End Sub

    Private Sub ReiniciarInterface()
        TxtMonto.Text = 0.00
        TxtMonto.Select()
        LvwMovimientos.Items.Clear()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub EjecutarRutina()
        Dim movimiento As New TCxCMovimiento()
        Dim listaDeFacturas As New DataTable()
        Dim row As DataRow
        Try

            With listaDeFacturas
                .Columns.Add("Mov_Id")
                .Columns.Add("New_Tipo")
                .Columns.Add("Cliente")
                .Columns.Add("Monto")
                .Columns.Add("Tipo_Id")
            End With


            For Each item As ListViewItem In LvwMovimientos.CheckedItems
                row = listaDeFacturas.NewRow()
                row(0) = item.SubItems(ColumnasDetalle.Mov_Id).Text.ToString()
                row(1) = CDbl(item.SubItems(ColumnasDetalle.Tipo_Ajuste).Text.ToString())
                row(2) = item.SubItems(ColumnasDetalle.cliente).Text.ToString()
                row(3) = Math.Abs(CDbl(item.SubItems(ColumnasDetalle.Saldo).Text.ToString()))
                row(4) = item.SubItems(ColumnasDetalle.Tipo_Id).Text.ToString()
                listaDeFacturas.Rows.Add(row)
            Next

            With movimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Moneda = "C"
                .Usuario_Id = UsuarioInfo.Usuario_Id
                .AjusteFacturas(CDbl(TxtMonto.Text.ToString()), listaDeFacturas)
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub

    Private Function ValidaTodo() As Boolean
        If TxtMonto.Text.ToString.Equals("") Then

            MensajeError("Debe digitar un monto superior a 0.00")
            Return False

        ElseIf CInt(TxtMonto.Text.ToString()) = 0 Then

            MensajeError("Debe digitar un monto superior a 0.00")
            Return False

        Else
            Return True
        End If
    End Function

    Private Sub FormateaCamposNumericos()

        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtMonto, 12, 2, False, "0", "#,##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Inicializa()
        FormateaCamposNumericos()
    End Sub

    Public Sub Execute()
        Inicializa()
        ConfiguraLista()
        TxtMonto.Select()
        Me.ShowDialog()
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
                .Columns(ColumnasDetalle.TipoNombre).Width = 100

                .Columns(ColumnasDetalle.Referencia).Text = "Referencia"
                .Columns(ColumnasDetalle.Referencia).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Referencia).Width = 200

                .Columns(ColumnasDetalle.Vence).Text = "Vence"
                .Columns(ColumnasDetalle.Vence).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Vence).Width = 80

                .Columns(ColumnasDetalle.Monto).Text = "Monto"
                .Columns(ColumnasDetalle.Monto).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Monto).Width = 100

                .Columns(ColumnasDetalle.Saldo).Text = "Saldo"
                .Columns(ColumnasDetalle.Saldo).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Saldo).Width = 100

                .Columns(ColumnasDetalle.Tipo_Ajuste).Text = ""
                .Columns(ColumnasDetalle.Tipo_Ajuste).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Tipo_Ajuste).Width = 0

                .Columns(ColumnasDetalle.cliente).Text = ""
                .Columns(ColumnasDetalle.cliente).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.cliente).Width = 0
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaLista()
        Dim CxCMovimiento As New TCxCMovimiento
        Dim Items(8) As String
        Dim Item As ListViewItem = Nothing

        Try
            LvwMovimientos.Items.Clear()

            With CxCMovimiento
                .Emp_Id = EmpresaInfo.Emp_Id
            End With
            VerificaMensaje(CxCMovimiento.CargarFacturasConSaldo(CDbl(TxtMonto.Text.ToString())))

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
                Items(ColumnasDetalle.Tipo_Ajuste) = Fila("TipoAplica")
                Items(ColumnasDetalle.cliente) = Fila("Cliente")
                Item = New ListViewItem(Items)
                LvwMovimientos.Items.Add(Item)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CxCMovimiento = Nothing
        End Try
    End Sub

    Private Sub FrmAjusteDeFacturaConSaldo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                BtnCargar.PerformClick()
            Case Keys.F3
                BtnAceptar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub TxtMonto_Click(sender As Object, e As EventArgs) Handles TxtMonto.Click
        TxtMonto.Text = ""
    End Sub

    Private Sub BtnCargar_Click(sender As Object, e As EventArgs) Handles BtnCargar.Click
        If ValidaTodo() Then
            CargaLista()
        End If
    End Sub

    Private Sub TToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TToolStripMenuItem.Click
        For i = 0 To LvwMovimientos.Items.Count - 1
            LvwMovimientos.Items(i).Checked = False
        Next
    End Sub

    Private Sub MarcarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarcarToolStripMenuItem.Click
        For i = 0 To LvwMovimientos.Items.Count - 1
            LvwMovimientos.Items(i).Checked = True
        Next
    End Sub
End Class