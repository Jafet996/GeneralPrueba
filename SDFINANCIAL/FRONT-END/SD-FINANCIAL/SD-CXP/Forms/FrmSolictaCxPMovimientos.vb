Imports BUSINESS
Public Class FrmSolictaCxPMovimientos
#Region "Enums"
    Private Enum ColumnasDetalle
        TipoNombre = 0
        Mov_Id
        Tipo_Id
        Referencia
        Vence
        Moneda
        MonedaNombre
        Monto
        MontoDolares
        Pago
        PagoDolares
        TipoCambio
        FechaMora
        PagoNumeric
        PagoDolaresNumeric
    End Enum
#End Region
#Region "Variables"
    Private _Tipo_Id As Integer = 0
    Private _Prov_Id As Integer = 0
    Private _Selecciono As Boolean = False
    Private _ListaMovimientos As New List(Of TCxPMovimientoLinea)
    Private _ListaMovimientosCxP As New List(Of TCxPMovimiento)
    Private _MontoTotal As Double = 0.0
    Private _CerrarPantalla As Boolean = False
#End Region
#Region "Propiedades"
    Public WriteOnly Property Tipo_Id As Integer
        Set(value As Integer)
            _Tipo_Id = value
        End Set
    End Property
    Public WriteOnly Property Prov_Id As Integer
        Set(value As Integer)
            _Prov_Id = value
        End Set
    End Property
    Public ReadOnly Property Selecciono As Boolean
        Get
            Return _Selecciono
        End Get
    End Property
    Public ReadOnly Property ListaMovimientosCxP As List(Of TCxPMovimiento)
        Get
            Return _ListaMovimientosCxP
        End Get
    End Property

    Public ReadOnly Property ListaMovimientos As List(Of TCxPMovimientoLinea)
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
        Select Case _Tipo_Id
            Case 1
                LblTituloTotalColones.Text = "Paga ¢"
                LblTituloTotalDolares.Text = "Paga $"
                CargaListaPendientes()
            Case 2
                LblTituloTotalColones.Text = "Monto ¢"
                LblTituloTotalDolares.Text = "Monto $"
                CargaListaProcesoPago()
            Case Else
                _CerrarPantalla = True
                MensajeError("Ocurrió un error al seleccionar la lista a mostrar")
        End Select

        If Not _CerrarPantalla Then
            Me.ShowDialog()
        Else
            Me.Close()
        End If
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
                .Columns(ColumnasDetalle.Referencia).Width = 290

                .Columns(ColumnasDetalle.Vence).Text = "Vence"
                .Columns(ColumnasDetalle.Vence).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Vence).Width = 80

                .Columns(ColumnasDetalle.Moneda).Text = ""
                .Columns(ColumnasDetalle.Moneda).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Moneda).Width = 0

                .Columns(ColumnasDetalle.MonedaNombre).Text = "Moneda"
                .Columns(ColumnasDetalle.MonedaNombre).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.MonedaNombre).Width = 65

                .Columns(ColumnasDetalle.Monto).Text = "Monto Pendiente ¢"
                .Columns(ColumnasDetalle.Monto).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Monto).Width = 120

                .Columns(ColumnasDetalle.MontoDolares).Text = "Monto Pendiente $"
                .Columns(ColumnasDetalle.MontoDolares).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.MontoDolares).Width = 120

                .Columns(ColumnasDetalle.Pago).Text = "Monto a Pagar ¢"
                .Columns(ColumnasDetalle.Pago).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Pago).Width = 120

                .Columns(ColumnasDetalle.PagoDolares).Text = "Monto a Pagar $"
                .Columns(ColumnasDetalle.PagoDolares).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.PagoDolares).Width = 120

                .Columns(ColumnasDetalle.TipoCambio).Text = ""
                .Columns(ColumnasDetalle.TipoCambio).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.TipoCambio).Width = 0

                .Columns(ColumnasDetalle.FechaMora).Text = ""
                .Columns(ColumnasDetalle.FechaMora).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.FechaMora).Width = 0

                .Columns(ColumnasDetalle.PagoNumeric).Text = ""
                .Columns(ColumnasDetalle.PagoNumeric).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.PagoNumeric).Width = 0

                .Columns(ColumnasDetalle.PagoDolaresNumeric).Text = ""
                .Columns(ColumnasDetalle.PagoDolaresNumeric).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.PagoDolaresNumeric).Width = 0
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaListaPendientes()
        Dim CxPMovimiento As New TCxPMovimiento
        Dim Items(14) As String
        Dim Item As ListViewItem = Nothing
        Dim TipoCambio As Double = 0.0

        Try
            LvwMovimientos.Items.Clear()

            With CxPMovimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = _Prov_Id
                .Estado_Id = Enum_CxPMovimientoEstado.Pendiente
            End With
            VerificaMensaje(CxPMovimiento.MovimientosProveedorPago)

            If CxPMovimiento.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos")
            End If

            For Each Fila As DataRow In CxPMovimiento.Datos.Tables(0).Rows
                If CChar(Fila("Moneda")) = coMonedaColones Then
                    TipoCambio = 1
                Else
                    TipoCambio = CDbl(Fila("TipoCambio"))
                End If

                Items(ColumnasDetalle.TipoNombre) = UCase(Fila("TipoNombre"))
                Items(ColumnasDetalle.Mov_Id) = Fila("Mov_Id")
                Items(ColumnasDetalle.Tipo_Id) = Fila("Tipo_Id")
                Items(ColumnasDetalle.Referencia) = Fila("Referencia")
                Items(ColumnasDetalle.Vence) = Format(Fila("FechaVencimiento"), "dd/MM/yyyy")
                Items(ColumnasDetalle.Moneda) = Fila("Moneda")
                Items(ColumnasDetalle.MonedaNombre) = IIf(CChar(Fila("Moneda")) = coMonedaColones, "COLONES", "DOLARES")
                Items(ColumnasDetalle.Monto) = Format(Fila("Saldo"), "#,##0.00")
                Items(ColumnasDetalle.MontoDolares) = Format(IIf(CChar(Fila("Moneda")) = coMonedaColones, 0, CDbl(Fila("Saldo"))) / TipoCambio, "#,##0.0000")
                Items(ColumnasDetalle.Pago) = Format(Fila("Saldo"), "#,##0.00")
                Items(ColumnasDetalle.PagoDolares) = Format(IIf(CChar(Fila("Moneda")) = coMonedaColones, 0, CDbl(Fila("Saldo"))) / TipoCambio, "#,##0.0000")
                Items(ColumnasDetalle.TipoCambio) = Fila("TipoCambio")
                Items(ColumnasDetalle.FechaMora) = Format(Fila("FechaVencimiento"), "yyyy-MM-dd")
                Items(ColumnasDetalle.PagoNumeric) = Fila("Saldo")
                Items(ColumnasDetalle.PagoDolaresNumeric) = IIf(CChar(Fila("Moneda")) = coMonedaColones, 0, CDbl(Fila("Saldo"))) / TipoCambio

                Item = New ListViewItem(Items)
                If CChar(Fila("Moneda")) = coMonedaColones Then
                    Item.Tag = CDbl(Items(ColumnasDetalle.PagoNumeric))
                Else
                    Item.Tag = CDbl(Items(ColumnasDetalle.PagoDolaresNumeric))
                End If
                LvwMovimientos.Items.Add(Item)
            Next

            MarcaMovimientosVencimientos()
        Catch ex As Exception
            _CerrarPantalla = True
            MensajeError(ex.Message)
        Finally
            CxPMovimiento = Nothing
        End Try
    End Sub

    Private Sub MarcaMovimientosVencimientos()
        Dim FechaVence As DateTime
        Dim Fecha As DateTime

        Try
            Fecha = EmpresaInfo.Getdate

            For Each Item As ListViewItem In LvwMovimientos.Items
                FechaVence = CDate(Item.SubItems(ColumnasDetalle.FechaMora).Text.Trim)

                If DateValue(FechaVence) < DateValue(Fecha) Then
                    Item.ImageIndex = 0
                    Item.ForeColor = Color.Red
                End If
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ModificaMonto()
        Dim Forma As New FrmIngresaMonto
        Dim Moneda As Char = ""
        Dim Monto As Double = 0.0
        Dim Dolares As Double = 0.0
        Dim TipoCambio As Double = 0.0
        Dim MontoOriginal As Double = 0.0

        Try
            If LvwMovimientos.SelectedItems Is Nothing OrElse LvwMovimientos.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un item para poder cambiar el monto a pagar")
            End If

            Moneda = CChar(LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.Moneda).Text)
            Monto = CDbl(LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.PagoNumeric).Text)
            Dolares = CDbl(LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.PagoDolaresNumeric).Text)
            TipoCambio = IIf(Moneda = coMonedaColones, TipoCambioCxP, CDbl(LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.TipoCambio).Text))
            MontoOriginal = CDbl(LvwMovimientos.SelectedItems(0).Tag)

            With Forma
                .PermiteDecimales = True
                .CantidadEnteros = 12
                .CantidadDecimales = 2
                .Descripcion = "Ingrese el monto a pagar"
                .Moneda = Moneda
                .Monto = Monto
                .Dolares = Dolares
                .TipoCambio = TipoCambio
                .Maximo = MontoOriginal
                .Execute()
            End With

            If Forma.Acepto Then
                If Forma.Monto <= 0 Then
                    VerificaMensaje("El monto a pagar debe de ser mayor a cero")
                End If

                If Moneda = coMonedaColones Then
                    If Forma.Monto > MontoOriginal Then
                        VerificaMensaje("El monto a pagar no puede ser mayor al saldo del movimiento = ¢" & Format(MontoOriginal, "#,##0.00"))
                    ElseIf Forma.Dolares > MontoOriginal Then
                        VerificaMensaje("El monto a pagar no puede ser mayor al saldo del movimiento = $" & Format(MontoOriginal, "#,##0.00"))
                    End If
                End If

                LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.Pago).Text = Format(Forma.Monto, "#,##0.00")
                LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.PagoDolares).Text = Format(Forma.Dolares, "#,##0.0000")
                LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.PagoNumeric).Text = Forma.Monto
                LvwMovimientos.SelectedItems(0).SubItems(ColumnasDetalle.PagoDolaresNumeric).Text = Forma.Dolares
            End If

            CalculaTotales()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub CargaListaProcesoPago()
        Dim CxPMovimiento As New TCxPMovimiento
        Dim Items(14) As String
        Dim Item As ListViewItem = Nothing
        Dim TipoCambio As Double = 0.0

        Try
            LvwMovimientos.Items.Clear()

            With CxPMovimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = _Prov_Id
                .Estado_Id = Enum_CxPMovimientoEstado.Pendiente
            End With
            VerificaMensaje(CxPMovimiento.MovimientosProveedorProcesoPago)

            If CxPMovimiento.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos")
            End If

            For Each Fila As DataRow In CxPMovimiento.Datos.Tables(0).Rows
                If CChar(Fila("Moneda")) = coMonedaColones Then
                    TipoCambio = 1
                Else
                    TipoCambio = CDbl(Fila("TipoCambio"))
                End If

                Items(ColumnasDetalle.Mov_Id) = Fila("Mov_Id")
                Items(ColumnasDetalle.TipoNombre) = UCase(Fila("TipoNombre"))
                Items(ColumnasDetalle.Tipo_Id) = Fila("Tipo_Id")
                Items(ColumnasDetalle.Referencia) = Fila("Referencia")
                Items(ColumnasDetalle.Vence) = Format(Fila("FechaVencimiento"), "dd/MM/yyyy")
                Items(ColumnasDetalle.Moneda) = Fila("MonedaSolicitud")
                Items(ColumnasDetalle.MonedaNombre) = IIf(CChar(Fila("MonedaSolicitud")) = coMonedaColones, "COLONES", "DOLARES")
                Items(ColumnasDetalle.Monto) = Format(Fila("Saldo"), "#,##0.00")
                Items(ColumnasDetalle.MontoDolares) = Format(IIf(CChar(Fila("MonedaSolicitud")) = coMonedaColones, 0, CDbl(Fila("Saldo"))) / TipoCambio, "#,##0.0000")
                Items(ColumnasDetalle.Pago) = Format(Fila("MontoPagar"), "#,##0.00")
                Items(ColumnasDetalle.PagoDolares) = Format(Fila("DolaresSolicitud"), "#,##0.0000")
                Items(ColumnasDetalle.TipoCambio) = Fila("TCambio")
                Items(ColumnasDetalle.FechaMora) = Format(Fila("FechaVencimiento"), "yyyy-MM-dd")
                Items(ColumnasDetalle.PagoNumeric) = Fila("Saldo")
                Items(ColumnasDetalle.PagoDolaresNumeric) = IIf(CChar(Fila("Moneda")) = coMonedaColones, 0, CDbl(Fila("Saldo"))) / TipoCambio

                Item = New ListViewItem(Items)
                Item.ImageIndex = 1
                Item.ForeColor = Color.SteelBlue
                LvwMovimientos.Items.Add(Item)
            Next

            MnuCambiarMonto.Visible = False

        Catch ex As Exception
            _CerrarPantalla = True
            MensajeError(ex.Message)
        Finally
            CxPMovimiento = Nothing
        End Try
    End Sub

    Private Function Seleccionar() As String
        Dim Movimiento As TCxPMovimientoLinea
        Dim MovimientoCxP As TCxPMovimiento
        Try
            _ListaMovimientos.Clear()

            If LvwMovimientos.CheckedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar al menos un movimiento para poder continuar")
            End If

            For Each Item As ListViewItem In LvwMovimientos.CheckedItems
                Movimiento = New TCxPMovimientoLinea
                MovimientoCxP = New TCxPMovimiento

                With Movimiento
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Tipo_Id = CInt(Item.SubItems(ColumnasDetalle.Tipo_Id).Text.Trim)
                    .Mov_Id = CInt(Item.SubItems(ColumnasDetalle.Mov_Id).Text.Trim)
                    .Moneda = CChar(Item.SubItems(ColumnasDetalle.Moneda).Text.Trim)
                    .Monto = CDbl(Item.SubItems(ColumnasDetalle.PagoNumeric).Text.Trim)
                    .Dolares = IIf(.Moneda = coMonedaColones, 0, CDbl(Item.SubItems(ColumnasDetalle.PagoDolaresNumeric).Text.Trim))
                    .TipoCambio = IIf(.Moneda = coMonedaColones, 1, CDbl(Item.SubItems(ColumnasDetalle.TipoCambio).Text.Trim))
                End With

                With MovimientoCxP
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Tipo_Id = CInt(Item.SubItems(ColumnasDetalle.Tipo_Id).Text.Trim)
                    .Mov_Id = CInt(Item.SubItems(ColumnasDetalle.Mov_Id).Text.Trim)
                    .Moneda = CChar(Item.SubItems(ColumnasDetalle.Moneda).Text.Trim)
                    .Monto = CDbl(Item.SubItems(ColumnasDetalle.PagoNumeric).Text.Trim)
                    .Dolares = IIf(.Moneda = coMonedaColones, 0, CDbl(Item.SubItems(ColumnasDetalle.PagoDolaresNumeric).Text.Trim))
                    .TipoCambio = IIf(.Moneda = coMonedaColones, 1, CDbl(Item.SubItems(ColumnasDetalle.TipoCambio).Text.Trim))
                End With

                _ListaMovimientos.Add(Movimiento)
                _ListaMovimientosCxP.Add(MovimientoCxP)
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
        Dim TotalColones As Double = 0.0
        Dim TotalDolares As Double = 0.0
        Dim Total As Double = 0.0

        Try
            LblTotalColones.Text = "0.00"
            LblTotalDolares.Text = "0.00"
            LblMontoTotal.Text = "0.00"

            If LvwMovimientos.CheckedItems.Count = 0 Then
                Exit Sub
            End If

            For Each Item As ListViewItem In LvwMovimientos.CheckedItems
                If Item.SubItems(ColumnasDetalle.Moneda).Text = coMonedaColones Then
                    TotalColones += CDbl(Item.SubItems(ColumnasDetalle.Pago).Text.Trim)
                Else
                    TotalDolares += CDbl(Item.SubItems(ColumnasDetalle.PagoDolares).Text.Trim)
                End If
                Total += CDbl(Item.SubItems(ColumnasDetalle.Pago).Text.Trim)
            Next

            LblTotalColones.Text = Format(TotalColones, "#,##0.00")
            LblTotalDolares.Text = Format(TotalDolares, "#,##0.00")
            LblMontoTotal.Text = Format(Total, "#,##0.00")
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

    Private Sub FrmSolictaCxPMovimientos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub MnuCambiarMonto_Click(sender As Object, e As EventArgs) Handles MnuCambiarMonto.Click
        ModificaMonto()
    End Sub

    Private Sub CmsMenuSeleccion_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CmsMenuSeleccion.Opening
        If LvwMovimientos.SelectedItems Is Nothing OrElse LvwMovimientos.SelectedItems.Count = 0 Then
            e.Cancel = True
        End If
    End Sub

End Class