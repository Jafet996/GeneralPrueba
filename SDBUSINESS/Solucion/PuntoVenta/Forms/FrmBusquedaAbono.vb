Imports Business
Public Class FrmBusquedaAbono
    Dim cliente As TCliente
    Dim Numerico() As TNumericFormat
    Dim Apartado As New TApartadoEncabezado(EmpresaInfo.Emp_Id)

    Private Enum ColumnasDetalle

        Apartado_Id = 0
        Estado = 1
        Fecha = 2
        Monto = 3
        Saldo = 4
        Vencimiento = 5
        Suc_Id = 6
        Bod_Id = 7

    End Enum

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtCodigo, 8, 0, False, "", "###0")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Inicializa()
        TxtCodigo.Select()
        TxtCodigo.Clear()
        TxtNombre.Clear()
        TxtCodigo.ReadOnly = False
        LvwDetalle.Items.Clear()
    End Sub

    Private Function ValidaTodo() As Boolean

        Try
            If Not TxtCodigo.Text.Equals("") And Not cliente.Nombre.Equals("") Then
                Return True
            Else
                VerificaMensaje("Debe indicar el cliente para buscar los apartados.")
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return False
    End Function

    Public Sub Execute()
        Apartado.BuscaYColocaVencidos()
        ConfiguraLista()
        Inicializa()
        FormateaCamposNumericos()
        Me.ShowDialog()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Try

            BuscarCliente()
            EstableceValoresCliente()
            CargaLista()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub

    Private Sub BuscarCliente()
        Dim busquedaCliente As New FrmBusquedaClienteApartado()

        Try
            cliente = New TCliente(EmpresaInfo.Emp_Id)

            busquedaCliente.Execute()

            If busquedaCliente.Selecciono Then
                With cliente
                    .Cliente_Id = busquedaCliente.Cliente_Id
                    VerificaMensaje(.ListKey())
                End With

                If cliente.RowsAffected = 0 Then
                    VerificaMensaje("El código del cliente no existe")
                End If

            Else
                VerificaMensaje("Debe seleccionar un cliente para buscar")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EstableceValoresCliente()
        Try

            TxtCodigo.Text = cliente.Cliente_Id
            TxtNombre.Text = cliente.Nombre
            TxtCodigo.ReadOnly = True
        Catch ex As Exception

            Throw ex

        End Try
    End Sub


    Private Sub TxtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigo.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then

                If Not TxtCodigo.Text.Equals("") Then

                    cliente = New TCliente(EmpresaInfo.Emp_Id)
                    cliente.Cliente_Id = TxtCodigo.Text.ToString()
                    cliente.ListKey()
                    EstableceValoresCliente()
                    CargaLista()

                End If

            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub

    Private Sub FrmBusquedaApartado_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try

            If e.KeyCode = Keys.F1 Then

                BtnBuscar.PerformClick()

            ElseIf e.KeyCode = Keys.F3 Then

                BtnImprimir.PerformClick()

            ElseIf e.KeyCode = Keys.Escape Then

                Me.Close()

            ElseIf e.KeyCode = Keys.F12 Then

                BtnLimpiar.PerformClick()

            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Imprime()
        Dim ApartadoEncabezado As New TApartadoEncabezado(EmpresaInfo.Emp_Id)
        Dim FormaAbonos As New FrmVisualizarDetalleApartado()
        Try

            Cursor = Cursors.WaitCursor

            With ApartadoEncabezado
                .Suc_Id = SucursalInfo.Suc_Id
                .Apartado_Id = CInt(LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Apartado_Id).Text.ToString())
            End With

            VerificaMensaje(ApartadoEncabezado.ListKey())

            If ApartadoEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos correspondientes al apartado seleccionado")
            End If

            Cursor = Cursors.Default

            If FormaAbonos.EsAbonoRealizado Then
                If LvwDetalle.Items.Count > 1 Or Not FormaAbonos.EsAbandonado Then
                    CargaLista()
                Else
                    Inicializa()
                End If
            End If

            VerificaMensaje(ImprimeAbonoAbonoApartado(ApartadoEncabezado, True))

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ConfiguraLista()
        Try
            With LvwDetalle
                .Columns(ColumnasDetalle.Apartado_Id).Text = "#"
                .Columns(ColumnasDetalle.Apartado_Id).Width = 50
                .Columns(ColumnasDetalle.Apartado_Id).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasDetalle.Estado).Text = "Estado"
                .Columns(ColumnasDetalle.Estado).Width = 65
                .Columns(ColumnasDetalle.Estado).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasDetalle.Fecha).Text = "Fecha"
                .Columns(ColumnasDetalle.Fecha).Width = 75
                .Columns(ColumnasDetalle.Fecha).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasDetalle.Monto).Text = "Monto"
                .Columns(ColumnasDetalle.Monto).Width = 100
                .Columns(ColumnasDetalle.Monto).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasDetalle.Saldo).Text = "Saldo"
                .Columns(ColumnasDetalle.Saldo).Width = 100
                .Columns(ColumnasDetalle.Saldo).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasDetalle.Vencimiento).Text = "Vencimiento"
                .Columns(ColumnasDetalle.Vencimiento).Width = 75
                .Columns(ColumnasDetalle.Vencimiento).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasDetalle.Suc_Id).Text = "Suc_Id"
                .Columns(ColumnasDetalle.Suc_Id).Width = 0

                .Columns(ColumnasDetalle.Bod_Id).Text = "Bod_Id"
                .Columns(ColumnasDetalle.Bod_Id).Width = 0
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub CargaLista()
        Try

            LvwDetalle.Items.Clear()

            With Apartado
                .Suc_Id = SucursalInfo.Suc_Id
                .Cliente_Id = cliente.Cliente_Id
            End With

            VerificaMensaje(Apartado.ApartadosDelCliente())

            If Apartado.Data.Tables(0).Rows.Count = 0 Then
                VerificaMensaje("El cliente no posee apartados")
            End If

            For Each row As DataRow In Apartado.Data.Tables(0).Rows
                Dim items(7) As String
                Dim listItem As New ListViewItem(items)

                listItem.SubItems(ColumnasDetalle.Apartado_Id).Text = row.Item("Apartado_Id").ToString()
                listItem.SubItems(ColumnasDetalle.Bod_Id).Text = row.Item("Bod_Id").ToString()
                Select Case row.Item("Estado_Id").ToString()
                    Case "1"
                        listItem.SubItems(ColumnasDetalle.Estado).Text = "Pendiente"
                        listItem.ForeColor = Color.Green
                    Case "2"
                        listItem.SubItems(ColumnasDetalle.Estado).Text = "Retirado"
                        listItem.ForeColor = Color.Blue
                    Case "3"
                        listItem.SubItems(ColumnasDetalle.Estado).Text = "Vencido"
                        listItem.ForeColor = Color.Red
                    Case "4"
                        listItem.SubItems(ColumnasDetalle.Estado).Text = "Abandonado"
                        listItem.ForeColor = Color.Gray
                End Select
                listItem.SubItems(ColumnasDetalle.Fecha).Text = CDate(row.Item("Fecha").ToString()).ToString("dd/MM/yyyy")
                listItem.SubItems(ColumnasDetalle.Monto).Text = Format(CDbl(row.Item("Monto").ToString()), "#,##0.00")
                listItem.SubItems(ColumnasDetalle.Saldo).Text = Format(CDbl(row.Item("Saldo").ToString()), "#,##0.00")
                listItem.SubItems(ColumnasDetalle.Suc_Id).Text = row.Item("Suc_Id").ToString()
                listItem.SubItems(ColumnasDetalle.Vencimiento).Text = CDate(row.Item("Vencimiento").ToString()).ToString("dd/MM/yyyy")

                LvwDetalle.Items.Add(listItem.Clone)
            Next


        Catch ex As Exception
            MensajeError(ex.Message)
            Inicializa()
        End Try


    End Sub

    Private Function ValidaApartado() As Boolean
        Try

            If (LvwDetalle.SelectedItems.Count > 0) And Not TxtCodigo.Text.Equals("") Then

                Return True

            End If

            Mensaje("Debe selecionar tanto cliente como el apartado.")
            Return False

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Function

    Private Sub LvwDetalle_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LvwDetalle.MouseDoubleClick
        BtnImprimir.PerformClick()
    End Sub

    Private Sub LvwDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles LvwDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnImprimir.PerformClick()
        End If
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        Inicializa()
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click

        If ValidaApartado() Then

            Imprime()

        End If

    End Sub
End Class