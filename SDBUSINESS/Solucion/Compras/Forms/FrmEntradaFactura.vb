Imports Business
Public Class FrmEntradaFactura
    Private _EntradaFacturas As New List(Of TEntradaFactura)
    Private _TotalEntrada As Double = 0
    Private _DiasCredito As Integer = 0
    Private _Activo As Boolean = False
    Dim Numerico() As TNumericFormat

    Private Sub CargaCombos()
        Dim EntradaFacturaTipo As New TEntradaFacturaTipo(EmpresaInfo.Emp_Id)
        Try

            VerificaMensaje(EntradaFacturaTipo.LoadComboBox(CmbTipoFactura))


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            EntradaFacturaTipo = Nothing
        End Try
    End Sub

    Public Property EntradaFacturas As List(Of TEntradaFactura)
        Get
            Return _EntradaFacturas
        End Get
        Set(value As List(Of TEntradaFactura))
            _EntradaFacturas = value
        End Set
    End Property
    Public Property TotalEntrada As Double
        Get
            Return _TotalEntrada
        End Get
        Set(value As Double)
            _TotalEntrada = value
        End Set
    End Property
    Public Property DiasCredito() As Integer
        Get
            Return _DiasCredito
        End Get
        Set(ByVal value As Integer)
            _DiasCredito = value
        End Set
    End Property

    Private Enum ColumnasDetalle
        TipoFacturaNombre = 0
        Factura = 1
        Monto = 2
        FechaVencimiento = 3
        Comentario = 4
        Tipo_Id = 5
    End Enum

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtMonto, 8, 2, False, "", "##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ConfiguraDetalle()
        Try
            With LvwFacturas
                .Columns(ColumnasDetalle.TipoFacturaNombre).Text = "Tipo"
                .Columns(ColumnasDetalle.TipoFacturaNombre).Width = 120

                .Columns(ColumnasDetalle.Factura).Text = "Factura"
                .Columns(ColumnasDetalle.Factura).Width = 100

                .Columns(ColumnasDetalle.Monto).Text = "Monto"
                .Columns(ColumnasDetalle.Monto).Width = 80

                .Columns(ColumnasDetalle.FechaVencimiento).Text = "Vencimiento"
                .Columns(ColumnasDetalle.FechaVencimiento).Width = 80

                .Columns(ColumnasDetalle.Comentario).Text = "Comentario"
                .Columns(ColumnasDetalle.Comentario).Width = 372

                .Columns(ColumnasDetalle.Tipo_Id).Text = "TipoId"
                .Columns(ColumnasDetalle.Tipo_Id).Width = 0
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Inicializa()
        Try

            LblTotal.Text = "0.00"
            LblFaltante.Text = Format(_TotalEntrada, "#,##0.00")
            CargaFacturas()

            TxtMonto.Text = IIf(IsNumeric(LblFaltante.Text), CDbl(LblFaltante.Text), 0)
            DtpFechaVencimiento.Value = DateAdd(DateInterval.Day, _DiasCredito, EmpresaInfo.Getdate())
            LblDiasCredito.Text = _DiasCredito

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CalculaTotal()
        Dim Monto As Double = 0

        LblTotal.Text = "0.00"
        For Each Item As ListViewItem In LvwFacturas.Items
            Monto = Monto + CDbl(Item.SubItems(ColumnasDetalle.Monto).Text)
        Next
        LblTotal.Text = Format(Monto, "#,##0.00")
        LblFaltante.Text = Format(TotalEntrada - Monto, "#,##0.00")

        If CDbl(LblFaltante.Text) > 0 Then
            LblFaltante.ForeColor = Color.Red
        Else
            LblFaltante.ForeColor = Color.Blue
        End If
    End Sub

    Private Sub CargaFacturas()
        LvwFacturas.Items.Clear()
        For Each Factura As TEntradaFactura In _EntradaFacturas
            Agregar(Factura.TipoFacturaNombre, Factura.Tipo_Id, Factura.Factura, Factura.Monto, Factura.FechaVencimiento, Factura.Comentario)
        Next
    End Sub

    Public Sub Execute()
        Try
            FormateaCamposNumericos()

            ConfiguraDetalle()
            CargaCombos()
            Inicializa()

            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmEntradaFactura_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If Not _Activo Then
            _Activo = True
            TxtFactura.Focus()
        End If
    End Sub

    Private Sub FrmEntradaFactura_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnGuardar.PerformClick()
            Case Keys.F6
                BtnLimpiar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Function ValidaTodo() As Boolean
        Try

            If TxtFactura.Text.Trim = "" Then
                TxtFactura.Focus()
                VerificaMensaje("Debe de ingresar el número de factura")
            End If

            If Not IsNumeric(TxtMonto.Text) OrElse CDbl(TxtMonto.Text) <= 0 Then
                TxtMonto.SelectAll()
                TxtMonto.Focus()
                VerificaMensaje("Debe de ingresar el monto de la factura")
            End If

            VerificaMensaje(BuscaItemFactura(TxtFactura.Text))

            Return True

        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Agregar(pTipoFacturaNombre As String, pTipo_Id As Integer, pFactura As String, pMonto As Double, pVencimiento As Date, pComentario As String)
        Dim Item As ListViewItem = Nothing
        Dim Items(5) As String
        Try


            Items(ColumnasDetalle.TipoFacturaNombre) = pTipoFacturaNombre
            Items(ColumnasDetalle.Factura) = pFactura
            Items(ColumnasDetalle.Monto) = Format(pMonto, "##0.00")
            Items(ColumnasDetalle.FechaVencimiento) = pVencimiento
            Items(ColumnasDetalle.Comentario) = pComentario
            Items(ColumnasDetalle.Tipo_Id) = pTipo_Id

            Item = New ListViewItem(Items)

            LvwFacturas.Items.Add(Item)

            CalculaTotal()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LimpiaDatosFactura()
        CmbTipoFactura.SelectedIndex = 0
        TxtFactura.Text = ""
        TxtMonto.Text = CDbl(LblFaltante.Text)
        DtpFechaVencimiento.Value = DateAdd(DateInterval.Day, _DiasCredito, EmpresaInfo.Getdate())
        TxtComentario.Text = ""
        TxtFactura.Focus()
    End Sub

    Private Function BuscaItemFactura(pFactura As String) As String
        Try
            For Each Linea As ListViewItem In LvwFacturas.Items
                If Linea.SubItems(ColumnasDetalle.Factura).Text = pFactura Then
                    VerificaMensaje("Imposible agregar, ya existe una factura con ese número")
                End If
            Next

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Private Sub BtnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAgregar.Click
        If ValidaTodo() Then
            Agregar(CmbTipoFactura.Text, CInt(CmbTipoFactura.SelectedValue), TxtFactura.Text, CDbl(TxtMonto.Text), DateValue(DtpFechaVencimiento.Value), TxtComentario.Text)
            LimpiaDatosFactura()
        End If
    End Sub

    Private Sub Limpiar()
        LimpiaDatosFactura()
    End Sub


    Private Sub Guardar()
        Dim Factura As TEntradaFactura = Nothing
        Dim Detalle_Id As Integer = 0
        Try
            _EntradaFacturas.Clear()

            For Each Item As ListViewItem In LvwFacturas.Items
                Factura = New TEntradaFactura(0)
                Detalle_Id = Detalle_Id + 1
                With Factura
                    .Emp_Id = SucursalInfo.Emp_Id
                    .Suc_Id = SucursalInfo.Suc_Id
                    .Entrada_Id = 0
                    .Factura_Id = Detalle_Id
                    .Prov_Id = 0
                    .Factura = Item.SubItems(ColumnasDetalle.Factura).Text
                    .Monto = CDbl(Item.SubItems(ColumnasDetalle.Monto).Text)
                    .FechaVencimiento = DateValue(Item.SubItems(ColumnasDetalle.FechaVencimiento).Text)
                    .Comentario = Item.SubItems(ColumnasDetalle.Comentario).Text
                    .Tipo_Id = Item.SubItems(ColumnasDetalle.Tipo_Id).Text
                    .TipoFacturaNombre = Item.SubItems(ColumnasDetalle.TipoFacturaNombre).Text
                End With
                _EntradaFacturas.Add(Factura)
            Next

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub



    Private Sub LvwFacturas_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles LvwFacturas.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                EliminaLinea()
        End Select
    End Sub
    Private Sub EliminaLinea()
        Try
            If LvwFacturas.Items.Count = 0 OrElse LvwFacturas.SelectedItems.Count = 0 Then
                Exit Sub
            End If

            If MsgBox("Desea eliminar la línea del detalle", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar líneas") <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            LimpiaDatosFactura()

            LvwFacturas.Items.Remove(LvwFacturas.SelectedItems(0))

            CalculaTotal()

            TxtFactura.Focus()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub MnuDetalle_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles MnuDetalle.Opening
        If LvwFacturas.Items.Count = 0 OrElse LvwFacturas.SelectedItems.Count = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub MnuEliminar_Click(sender As System.Object, e As System.EventArgs) Handles MnuEliminar.Click
        EliminaLinea()
    End Sub

    Private Sub TxtFactura_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtFactura.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TxtMonto.Focus()
        End Select
    End Sub

    Private Sub TxtMonto_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtMonto.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                DtpFechaVencimiento.Focus()
        End Select
    End Sub

    Private Sub DtpFechaVencimiento_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DtpFechaVencimiento.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TxtComentario.Focus()
        End Select
    End Sub

    Private Sub TxtComentario_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtComentario.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                BtnAgregar.Focus()
        End Select
    End Sub




    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        Guardar()
    End Sub

    Private Sub BtnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

End Class