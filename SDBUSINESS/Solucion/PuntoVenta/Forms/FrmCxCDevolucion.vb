Imports Business
Public Class FrmCxCDevolucion
    Public Property Guardo As Boolean = False
    Public Property DocumentoMonto As Double = 0
    Public Property DocumentoSaldo As Double = 0
    Public Property TotalDevolucion As Double = 0
    Public Property CXCEmp_Id As Integer = 0
    Public Property CXCTipo_Id As Integer = 0
    Public Property CXCMov_Id As Long = 0
    Public Property Cliente_Id As Long = 0
    Public Property CxCDevolucionFacturas As New List(Of SDFinancial.DTCxCMovimientoLinea)
    Public Property MontoNotaAdicional As Double = 0
    Public Property MontoDevolucionFacturas As Double = 0

    Private _FacturaDev As TFacturaEncabezado

    Private Enum ColumnasDetalle
        TipoNombre = 0
        Mov_Id
        Tipo_Id
        Referencia
        Vence
        Monto
        Saldo
        Orden
    End Enum

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
                .Columns(ColumnasDetalle.Referencia).Width = 500

                .Columns(ColumnasDetalle.Vence).Text = "Vence"
                .Columns(ColumnasDetalle.Vence).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Vence).Width = 80

                .Columns(ColumnasDetalle.Monto).Text = "Monto"
                .Columns(ColumnasDetalle.Monto).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Monto).Width = 120

                .Columns(ColumnasDetalle.Saldo).Text = "Saldo"
                .Columns(ColumnasDetalle.Saldo).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Saldo).Width = 120

                .Columns(ColumnasDetalle.Orden).Text = "Orden"
                .Columns(ColumnasDetalle.Orden).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Orden).Width = 0

            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub CargaLista()
        Dim Cliente As New TCxC_Cliente
        Dim Items(7) As String
        Dim Item As ListViewItem = Nothing
        Dim Orden As Integer = 2
        Try
            LvwMovimientos.Items.Clear()

            With Cliente
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cliente_Id = Cliente_Id
            End With
            VerificaMensaje(Cliente.MovimientosClienteCxC())

            If Cliente.Datos.Tables(0).Rows.Count = 0 Then
                VerificaMensaje("No se encontraron facturas")
            End If

            For Each Fila As DataRow In Cliente.Datos.Tables(0).Rows
                If (Fila("Tipo_Id") = Enum_CxCMovimientoTipo.Factura OrElse Fila("Tipo_Id") = Enum_CxCMovimientoTipo.NotaDebito) AndAlso Fila("Saldo") > 0 Then
                    Items(ColumnasDetalle.Mov_Id) = Fila("Mov_Id")
                    Items(ColumnasDetalle.TipoNombre) = UCase(Fila("TipoNombre"))
                    Items(ColumnasDetalle.Tipo_Id) = Fila("Tipo_Id")
                    Items(ColumnasDetalle.Referencia) = Fila("Referencia")
                    Items(ColumnasDetalle.Vence) = Format(Fila("FechaVencimiento"), "dd/MM/yyyy")
                    Items(ColumnasDetalle.Monto) = Math.Round(CDbl(Format(Fila("Monto")))).ToString("#,##0.00")
                    Items(ColumnasDetalle.Saldo) = Math.Round(CDbl(Format(Fila("Saldo")))).ToString("#,##0.00")
                    If Fila("Tipo_Id") = CXCTipo_Id AndAlso Fila("Mov_Id") = CXCMov_Id Then
                        Items(ColumnasDetalle.Orden) = 1
                    Else
                        Items(ColumnasDetalle.Orden) = Orden
                        Orden += 1
                    End If


                    Item = New ListViewItem(Items)
                    LvwMovimientos.Items.Add(Item)

                    If Fila("Tipo_Id") = CXCTipo_Id AndAlso Fila("Mov_Id") = CXCMov_Id Then
                        Item.Checked = True
                        ListViewCambiaColorFilaTexto(Item, Color.Blue)
                    End If

                End If


            Next


            LvwMovimientos.Enabled = True
            BtnAceptar.Enabled = True

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
        End Try
    End Sub


    Private Sub CargaDatos()
        Try


            LblDocumentoMonto.Text = DocumentoMonto.ToString("#,##0.00")
            LblDocumentoSaldo.Text = DocumentoSaldo.ToString("#,##0.00")
            LblDocumentoMontoFavor.Text = (DocumentoMonto - DocumentoSaldo).ToString("#,##0.00")
            LblTotalDevolucion.Text = TotalDevolucion.ToString("#,##0.00")




            CargaLista()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Public Sub Execute(pFacturaDev As TFacturaEncabezado)
        Try
            _FacturaDev = pFacturaDev

            CargaDatos()

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmCxCDevolucion_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            ConfiguraLista()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Try

            Guardo = False
            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try

            If CDbl(LblMontoNotaCreditoGeneral.Text) > 0 And LvwMovimientos.CheckedItems.Count < LvwMovimientos.Items.Count Then
                VerificaMensaje("Debe de seleccionar los documentos a los que desea aplicarles el monto a favor")
            End If



            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Dim TotalDevolucion As Double = 0
        Dim Movimiento As SDFinancial.DTCxCMovimientoLinea
        Try

            If Not ValidaTodo() Then
                Exit Sub
            End If


            MontoDevolucionFacturas = 0
            CxCDevolucionFacturas.Clear()

            TotalDevolucion = CDbl(LblTotalDevolucion.Text)


            For Each item As ListViewItem In LvwMovimientos.CheckedItems
                If item.SubItems(ColumnasDetalle.Orden).Text = "1" Then
                    Movimiento = New SDFinancial.DTCxCMovimientoLinea
                    With Movimiento
                        .Emp_Id = EmpresaInfo.Emp_Id
                        .Tipo_Id = CInt(item.SubItems(ColumnasDetalle.Tipo_Id).Text)
                        .Mov_Id = CInt(item.SubItems(ColumnasDetalle.Mov_Id).Text)
                        If TotalDevolucion >= CDbl(item.SubItems(ColumnasDetalle.Saldo).Text) Then
                            .Monto = CDbl(item.SubItems(ColumnasDetalle.Saldo).Text)
                            TotalDevolucion = TotalDevolucion - CDbl(item.SubItems(ColumnasDetalle.Saldo).Text)
                        Else
                            .Monto = TotalDevolucion
                            TotalDevolucion = 0
                        End If
                        MontoDevolucionFacturas = MontoDevolucionFacturas + .Monto
                    End With
                    CxCDevolucionFacturas.Add(Movimiento)
                    Exit For
                End If
            Next




            For Each item As ListViewItem In LvwMovimientos.CheckedItems
                If item.SubItems(ColumnasDetalle.Orden).Text <> "1" Then
                    If TotalDevolucion > 0 Then
                        Movimiento = New SDFinancial.DTCxCMovimientoLinea
                        With Movimiento
                            .Emp_Id = EmpresaInfo.Emp_Id
                            .Tipo_Id = CInt(item.SubItems(ColumnasDetalle.Tipo_Id).Text)
                            .Mov_Id = CInt(item.SubItems(ColumnasDetalle.Mov_Id).Text)
                            If TotalDevolucion >= CDbl(item.SubItems(ColumnasDetalle.Saldo).Text) Then
                                .Monto = CDbl(item.SubItems(ColumnasDetalle.Saldo).Text)
                                TotalDevolucion = TotalDevolucion - CDbl(item.SubItems(ColumnasDetalle.Saldo).Text)
                            Else
                                .Monto = TotalDevolucion
                                TotalDevolucion = 0
                            End If
                            MontoDevolucionFacturas = MontoDevolucionFacturas + .Monto
                        End With
                        CxCDevolucionFacturas.Add(Movimiento)
                    Else
                        Exit For
                    End If

                End If
            Next


            MontoNotaAdicional = CDbl(LblMontoNotaCreditoGeneral.Text)


            Guardo = True
            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CalculaSeleccionados()
        Dim Total As Double = 0
        Try

            LblTotalMovimientosSeleccionados.Text = "0.00"

            For Each item As ListViewItem In LvwMovimientos.Items
                If item.Checked Then
                    Total += (item.SubItems(ColumnasDetalle.Saldo).Text)
                End If
            Next
            LblTotalDevolucion.Text = Math.Round(CDbl(LblTotalDevolucion.Text)).ToString("#,#00.00")


            LblTotalMovimientosSeleccionados.Text = Total.ToString("#,#00.00")
            LblTotalMovimientosSeleccionados.Text = Math.Round(CDbl(LblTotalMovimientosSeleccionados.Text)).ToString("#,#00.00")

            LblMontoNotaCreditoGeneral.Text = (CDbl(LblTotalDevolucion.Text) - Total).ToString("#,#00.00")
            LblMontoNotaCreditoGeneral.Text = Math.Round(CDbl(LblMontoNotaCreditoGeneral.Text)).ToString("#,#00.00")


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LvwMovimientos_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles LvwMovimientos.ItemChecked
        CalculaSeleccionados()
    End Sub

    Private Sub FrmCxCDevolucion_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnAceptar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub LblTotalMovimientosSeleccionados_Click(sender As Object, e As EventArgs) Handles LblTotalMovimientosSeleccionados.Click

    End Sub
End Class