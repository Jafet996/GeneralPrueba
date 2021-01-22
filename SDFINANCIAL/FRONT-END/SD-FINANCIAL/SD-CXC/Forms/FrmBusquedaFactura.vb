Imports BUSINESS

Public Class FrmBusquedaFactura
    Dim Vendedor_Id As Integer
    Public _CerrarPantalla As Boolean = False
    Public _Entrega_Id As Integer = 0
    Public _Nuevo As Boolean = False
    Public _Vendedor_id As Int16
    Dim lista As DataRowCollection
    Public DetallesEntregaDocumento As New List(Of TCxCEntregaDocumentoDetalle)
    Public FacturasSeleccionadas As New List(Of String)()
    Public Encabezado As New TCxCEntregaDocumentoEncabezado()
    Dim Detalle As New TCxCEntregaDocumentoDetalle()

    Private Enum ColumnasDetalle
        TipoNombre
        Mov_Id
        Tipo_Id
        Cliente_Id
        Referencia
        Cliente
        Vence
        Monto
        Saldo

    End Enum

    Public Sub Execute()
        ConfiguraLista()
        CargarDocumentos()
        TxtBuscar.Select()
        Me.ShowDialog()
    End Sub

    Private Sub ConfiguraLista()
        Try
            With LvwMovimientos
                .Columns(ColumnasDetalle.Mov_Id).Text = "Documento"
                .Columns(ColumnasDetalle.Mov_Id).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Mov_Id).Width = 75

                .Columns(ColumnasDetalle.Tipo_Id).Text = ""
                .Columns(ColumnasDetalle.Tipo_Id).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Tipo_Id).Width = 0

                .Columns(ColumnasDetalle.Cliente_Id).Text = ""
                .Columns(ColumnasDetalle.Cliente_Id).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Cliente_Id).Width = 0

                .Columns(ColumnasDetalle.TipoNombre).Text = "Tipo"
                .Columns(ColumnasDetalle.TipoNombre).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.TipoNombre).Width = 120

                .Columns(ColumnasDetalle.Referencia).Text = "Referencia"
                .Columns(ColumnasDetalle.Referencia).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Referencia).Width = 300

                .Columns(ColumnasDetalle.Cliente).Text = "Cliente"
                .Columns(ColumnasDetalle.Cliente).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Cliente).Width = 150

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

    Private Sub CargarDocumentos()
        Dim CxCMovimiento As New TCxCMovimiento
        Dim Items(8) As String
        Dim Item As ListViewItem = Nothing

        Try
            LvwMovimientos.Items.Clear()

            With CxCMovimiento
                .Emp_Id = EmpresaInfo.Emp_Id
            End With
            VerificaMensaje(CxCMovimiento.AsignarFacturasPendientes)

            If CxCMovimiento.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos")
            End If

            lista = CxCMovimiento.Datos.Tables(0).Rows

            For Each Fila As DataRow In CxCMovimiento.Datos.Tables(0).Rows
                Items(ColumnasDetalle.TipoNombre) = Fila("TipoNombre")
                Items(ColumnasDetalle.Mov_Id) = Fila("Mov_Id")
                Items(ColumnasDetalle.Tipo_Id) = Fila("Tipo_Id")
                Items(ColumnasDetalle.Cliente_Id) = Fila("Cliente_Id")
                Items(ColumnasDetalle.Referencia) = Fila("Referencia")
                Items(ColumnasDetalle.Cliente) = Fila("Cliente")
                Items(ColumnasDetalle.Vence) = Format(Fila("FechaVencimiento"), "dd/MM/yyyy")
                Items(ColumnasDetalle.Monto) = Format(Fila("Monto"), "#,##0.00")
                Items(ColumnasDetalle.Saldo) = Format(Fila("Saldo"), "#,##0.00")
                Item = New ListViewItem(Items)
                LvwMovimientos.Items.Add(Item)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
            Me.Close()
            _CerrarPantalla = True
        Finally
        End Try
    End Sub

    Private Sub GuardarDocumentos()

        Try
            If _Nuevo Then
                With Encabezado
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Usuario_Id = UsuarioInfo.Usuario_Id
                    .Vendedor_Id = _Vendedor_id
                    .Fecha = Today.Date()
                    .Activo = True
                    .NextOne()
                End With
                Encabezado.Insert()
                _Entrega_Id = Encabezado.Entrega_Id
            Else
                _Entrega_Id = DetallesEntregaDocumento(0).Entrega_Id
            End If

            For Each item As ListViewItem In LvwMovimientos.CheckedItems
                Detalle = New TCxCEntregaDocumentoDetalle()
                With Detalle
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Entrega_Id = _Entrega_Id
                    .Tipo_Id = item.SubItems(ColumnasDetalle.Tipo_Id).Text.ToString()
                    .Mov_Id = item.SubItems(ColumnasDetalle.Mov_Id).Text.ToString()
                    .NextOne()
                    .Insert()
                End With

                DetallesEntregaDocumento.Add(Detalle)

            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try


    End Sub

    Private Function ValidaTodo() As Boolean
        If lista.Count = LvwMovimientos.Items.Count Then
            If LvwMovimientos.CheckedItems.Count > 0 Then
                Return True
            Else

                Return False
            End If
        Else
            Return False
        End If
    End Function



    Private Sub BuscarEnTabla()
        Dim Items(8) As String
        Dim Item As ListViewItem = Nothing

        Try
            LvwMovimientos.Items.Clear()

            For Each fila As DataRow In lista

                If fila("Referencia").ToString.Contains(TxtBuscar.Text.ToString) Then
                    Items(ColumnasDetalle.TipoNombre) = fila("TipoNombre")
                    Items(ColumnasDetalle.Mov_Id) = fila("Mov_Id")
                    Items(ColumnasDetalle.Tipo_Id) = fila("Tipo_Id")
                    Items(ColumnasDetalle.Cliente_Id) = fila("Cliente_Id")
                    Items(ColumnasDetalle.Referencia) = fila("Referencia")
                    Items(ColumnasDetalle.Cliente) = fila("Cliente")
                    Items(ColumnasDetalle.Vence) = Format(fila("FechaVencimiento"), "dd/MM/yyyy")
                    Items(ColumnasDetalle.Monto) = Format(fila("Monto"), "#,##0.00")
                    Items(ColumnasDetalle.Saldo) = Format(fila("Saldo"), "#,##0.00")
                    Item = New ListViewItem(Items)
                    If ExisteEnFacturasSeleccionadas(fila("Referencia")) Then
                        Item.Checked = True
                        LvwMovimientos.Items.Insert(0, Item)
                    Else
                        LvwMovimientos.Items.Add(Item)
                    End If


                End If

            Next

            LvwMovimientos.Sort()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        If ValidaTodo() Then
            GuardarDocumentos()
            _CerrarPantalla = True
            Me.Close()
        End If


    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmBusquedaFactura_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            BtnGuardar.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            BtnSalir.PerformClick()
        End If
    End Sub

    Private Sub TxtBuscar_TextChanged(sender As Object, e As EventArgs) Handles TxtBuscar.TextChanged
        BuscarEnTabla()
    End Sub

    Private Function ExisteEnDetalleLista(Mov_Id As String, Tipo_Id As String) As Boolean
        Try
            For Each item In DetallesEntregaDocumento
                If Mov_Id.Equals(item.Mov_Id.ToString()) And Tipo_Id.Equals(item.Tipo_Id.ToString()) Then
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Private Function ExisteEnFacturasSeleccionadas(pReferencia As String) As Boolean

        For Each factura In FacturasSeleccionadas
            If pReferencia.ToString().Equals(factura.ToString()) Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Function AgregarFactura(pItem As ListViewItem) As Boolean
        Dim existeFactura As Boolean = False

        Try

            For Each factura As String In FacturasSeleccionadas
                If factura.ToString().Equals(pItem.SubItems(ColumnasDetalle.Referencia).Text.ToString()) Then
                    existeFactura = True
                    Exit For
                End If
            Next

            If Not existeFactura Then
                FacturasSeleccionadas.Add(pItem.SubItems(ColumnasDetalle.Referencia).Text.ToString())
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Function

    Private Sub EliminarFactura(pItem As ListViewItem)

        If ExisteEnFacturasSeleccionadas(pItem.SubItems(ColumnasDetalle.Referencia).Text.ToString()) Then
            For i = 0 To FacturasSeleccionadas.Count - 1
                If pItem.SubItems(ColumnasDetalle.Referencia).Text.ToString().Equals(FacturasSeleccionadas(i).ToString()) Then
                    FacturasSeleccionadas.RemoveAt(i)
                    Exit For
                End If
            Next
        End If


    End Sub

    Private Sub LvwMovimientos_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles LvwMovimientos.ItemChecked
        Try

            If e.Item.Checked Then

                AgregarFactura(e.Item)

            Else



            End If



        Catch ex As Exception
            MensajeError(ex.Message)
        End Try


    End Sub


End Class