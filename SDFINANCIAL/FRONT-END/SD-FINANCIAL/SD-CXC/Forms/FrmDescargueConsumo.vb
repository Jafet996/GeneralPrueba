Imports BUSINESS

Public Class FrmDescargueConsumo

#Region "Enums"
    Private Enum ColumnasDetalle
        Cliente
        Cliente_Id
        Referencia
        Monto
        Saldo
        Fecha
        Vence
        Mov_Id
        Tipo_Id
    End Enum
#End Region

    Private Function ValidaTodo() As Boolean
        Dim Resultado As Integer = MessageBox.Show("Desea aplciar el descargue de consumo interno", "caption", MessageBoxButtons.YesNo)

        Return LvwDetalles.Items.Count > 0 And DialogResult.Yes = Resultado

    End Function

    Public Sub Execute()
        ConfiguraLista()
        CargaLista()
        Me.ShowDialog()
    End Sub

    Private Sub CargaLista()

        Dim Movimiento As New TCxCMovimiento()
        Dim Items(8) As String
        Dim Item As ListViewItem = Nothing

        Try

            Movimiento.Emp_Id = EmpresaInfo.Emp_Id

            Movimiento.ConsultaConsumoInterno()

            If Movimiento.Datos.Tables(0).Rows.Count = 0 Then

                VerificaMensaje("No se encontraron facturas de consumo interno")

            End If

            For Each row As DataRow In Movimiento.Datos.Tables(0).Rows

                Items(ColumnasDetalle.Cliente) = row.Item("Nombre").ToString()
                Items(ColumnasDetalle.Cliente_Id) = row.Item("Cliente_Id").ToString()
                Items(ColumnasDetalle.Mov_Id) = row.Item("Mov_Id").ToString()
                Items(ColumnasDetalle.Fecha) = CDate(row.Item("Fecha").ToString()).ToString("dd/MM/yyyy")
                Items(ColumnasDetalle.Monto) = Format(CDbl(row.Item("Monto").ToString()), "#,##0.00")
                Items(ColumnasDetalle.Referencia) = row.Item("Referencia").ToString()
                Items(ColumnasDetalle.Saldo) = Format(CDbl(row.Item("Saldo").ToString()), "#,##0.00")
                Items(ColumnasDetalle.Tipo_Id) = row.Item("Tipo_Id").ToString()
                Items(ColumnasDetalle.Vence) = CDate(row.Item("FechaVencimiento").ToString()).ToString("dd/MM/yyyy")

                Item = New ListViewItem(Items)
                LvwDetalles.Items.Add(Item)

            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ConfiguraLista()
        Try
            With LvwDetalles
                .Columns(ColumnasDetalle.Mov_Id).Text = "Mov_Id"
                .Columns(ColumnasDetalle.Mov_Id).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Mov_Id).Width = 0

                .Columns(ColumnasDetalle.Cliente).Text = "Colaborador"
                .Columns(ColumnasDetalle.Cliente).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Cliente).Width = 180

                .Columns(ColumnasDetalle.Referencia).Text = "Factura"
                .Columns(ColumnasDetalle.Referencia).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Referencia).Width = 250

                .Columns(ColumnasDetalle.Vence).Text = "Vence"
                .Columns(ColumnasDetalle.Vence).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Vence).Width = 80

                .Columns(ColumnasDetalle.Fecha).Text = "Fecha"
                .Columns(ColumnasDetalle.Fecha).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Fecha).Width = 80

                .Columns(ColumnasDetalle.Monto).Text = "Monto"
                .Columns(ColumnasDetalle.Monto).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Monto).Width = 90

                .Columns(ColumnasDetalle.Saldo).Text = "Saldo"
                .Columns(ColumnasDetalle.Saldo).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Saldo).Width = 90

                .Columns(ColumnasDetalle.Tipo_Id).Text = "Tipo_Id"
                .Columns(ColumnasDetalle.Tipo_Id).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Tipo_Id).Width = 0

                .Columns(ColumnasDetalle.Cliente_Id).Text = "Cliente_Id"
                .Columns(ColumnasDetalle.Cliente_Id).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Cliente_Id).Width = 0

            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Descargar()

        Try

            Dim referencia As String = InputBox("Digite la referencia del descargue consumo interno.")


            For Each item As ListViewItem In LvwDetalles.Items
                Dim Movimiento As New TCxCMovimiento()
                Dim _ListaMovimiento As New List(Of TCxCMovimientoLinea)()


                Movimiento.Emp_Id = EmpresaInfo.Emp_Id


                Dim movimientoLinea As New TCxCMovimientoLinea()

                With movimientoLinea
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Monto = CDbl(item.SubItems(ColumnasDetalle.Saldo).Text.ToString())
                    .Mov_Id = item.SubItems(ColumnasDetalle.Mov_Id).Text.ToString()
                    .Tipo_Id = item.SubItems(ColumnasDetalle.Tipo_Id).Text.ToString()
                End With

                _ListaMovimiento.Add(movimientoLinea)

                Dim ReferenciaAuxilliar As String = "Descargue de consumo interno, Reaizado: " & Now.ToString("dd/MM/yyyy") & ", Aplicado por: " & UsuarioInfo.Usuario_Id

                If referencia.Equals("") Then
                    referencia = ReferenciaAuxilliar
                End If

                With Movimiento
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Tipo_Id = Enum_CxCMovimientoTipo.NotaCredito
                    .Cliente_Id = item.SubItems(ColumnasDetalle.Cliente_Id).Text.ToString()
                    .Referencia = referencia
                    .Moneda = "C"
                    .Monto = CDbl(item.SubItems(ColumnasDetalle.Saldo).Text.ToString())
                    .TipoCambio = 1
                    .Dolares = 1
                    .Usuario_Id =
                    .AplicaMora = False
                    .ListaMovimientos = _ListaMovimiento
                    .MAC_Address = InfoMaquina.MAC_Address
                    .GeneraAsiento = False
                    .FechaRecibido = DateValue(Now)
                    .FechaDocumento = DateValue(Now)
                    .FechaVencimiento = DateValue(Now)
                    .Caja_Id = 0
                    .Cierre_Id = 0
                    VerificaMensaje(Movimiento.Insert)
                End With

            Next

            LvwDetalles.Items.Clear()

            Mensaje("Descargue de consumo interno realizado exitosamente")


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnDescargar_Click(sender As Object, e As EventArgs) Handles BtnDescargar.Click
        If ValidaTodo() Then
            Descargar()
        End If
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmDescargueConsumo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F3 Then

            BtnDescargar.PerformClick()

        ElseIf e.KeyCode = Keys.Escape Then

            BtnSalir.PerformClick()

        End If

    End Sub
End Class