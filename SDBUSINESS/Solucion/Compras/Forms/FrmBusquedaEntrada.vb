Imports Business
Public Class FrmBusquedaEntrada
#Region "Declaraciones"
    Dim Numerico() As TNumericFormat
    Private Const coCantidad = 30
    Private _Selecciono As Boolean
    Private _Numero_Id As Long
    Private _Activo As Boolean = False
    Private _SoloAplicadas As Boolean
#End Region
#Region "Propiedades"
    Public WriteOnly Property SoloAplicadas As Boolean
        Set(value As Boolean)
            _SoloAplicadas = value
        End Set
    End Property
    Public ReadOnly Property Selecciono As Boolean
        Get
            Return _Selecciono
        End Get
    End Property
    Public ReadOnly Property Numero_Id As Long
        Get
            Return _Numero_Id
        End Get
    End Property
#End Region
#Region "Funciones privadas"
    Private Sub Seleccionar()
        Try

            If DGDetalle.CurrentCell Is Nothing Then
                VerificaMensaje("Debe de seleccionar un valor")
            End If

            _Numero_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value

            _Selecciono = True

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtCantidad, 3, 0, False, "", "###0")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region
    Public Sub Execute()
        _Selecciono = False
        TxtCantidad.Text = coCantidad
        BtnBuscar.Focus()

        Me.ShowDialog()
    End Sub

    Private Function ValidaCriteriosBusqueda() As Boolean
        Try

            If Not IsNumeric(TxtCantidad.Text) Then
                If RdbUltimos.Checked Then
                    TxtCantidad.SelectAll()
                    TxtCantidad.Focus()
                    VerificaMensaje("Debe de ingresar una cantidad")
                Else
                    TxtCantidad.Text = coCantidad
                End If
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try

    End Function

    Private Sub Buscar()
        Dim EntradaEncabezado As New TEntradaEncabezado(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Dim TipoBusqueda As Integer = 0
        Try
            _Selecciono = False

            If Not IsNumeric(TxtCantidad.Text) OrElse CInt(TxtCantidad.Text) <= 0 Then
                TxtCantidad.SelectAll()
                TxtCantidad.Focus()
                VerificaMensaje("La cantidad no puede ser menor o igual a cero")
            End If

            DGDetalle.DataSource = Nothing

            If RdbUltimos.Checked Then
                TipoBusqueda = 1
            ElseIf RdbFechas.Checked Then
                TipoBusqueda = 2
            ElseIf RdbFactura.Checked Then
                TipoBusqueda = 3
            ElseIf RdbComentario.Checked Then
                TipoBusqueda = 4
            ElseIf RdbProveedor.Checked Then
                TipoBusqueda = 5
            End If

            EntradaEncabezado.Suc_Id = SucursalInfo.Suc_Id
            Mensaje = EntradaEncabezado.ListBusqueda(TipoBusqueda, CInt(TxtCantidad.Text), DateValue(DtpDesde.Value), DateValue(DtpHasta.Value), _SoloAplicadas, TxtFactura.Text, TxtComentario.Text, TxtProveerdor.Text)
            VerificaMensaje(Mensaje)

            DGDetalle.DataSource = EntradaEncabezado.Data.Tables(0)
            DGDetalle.Columns(0).Width = 60
            DGDetalle.Columns(1).Width = 100
            DGDetalle.Columns(2).Width = 70
            DGDetalle.Columns(3).Width = 200
            DGDetalle.Columns(4).Width = 300
            DGDetalle.Columns(5).Width = 200

            If DGDetalle.RowCount > 0 Then
                DGDetalle.Focus()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            EntradaEncabezado = Nothing
        End Try
    End Sub

    Private Sub CmbTipoMovimiento_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        DGDetalle.DataSource = Nothing
    End Sub


    Private Sub DGDetalle_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDetalle.CellDoubleClick
        Seleccionar()
    End Sub


    Private Sub FrmBusquedaMovimiento_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If Not _Activo Then
            _Activo = False
            BtnBuscar.Focus()
        End If
    End Sub

    Private Sub Limpiar()
        DGDetalle.DataSource = Nothing
        BtnBuscar.Focus()
    End Sub

    Private Sub Salir()
        Me.Close()
    End Sub

    Private Sub FrmBusquedaEntrada_Invalidated(sender As Object, e As System.Windows.Forms.InvalidateEventArgs) Handles Me.Invalidated

    End Sub


    Private Sub FrmBusquedaMovimiento_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If Me.ActiveControl.Name = "DGDetalle" Then
                    Seleccionar()
                End If
            Case Keys.F1
                BtnBuscar.PerformClick()
            Case Keys.F12
                Limpiar()
            Case Keys.Escape
                Salir()
        End Select
    End Sub

    Private Sub RdbUltimos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdbUltimos.CheckedChanged
        HabilitaFiltros()
    End Sub

    Private Sub HabilitaFiltros()
        If RdbUltimos.Checked Then
            TxtCantidad.Enabled = True
            DtpDesde.Enabled = False
            DtpHasta.Enabled = False
            TxtFactura.Enabled = False
            TxtComentario.Enabled = False
            TxtProveerdor.Enabled = False
        End If
        If RdbFechas.Checked Then
            TxtCantidad.Enabled = False
            DtpDesde.Enabled = True
            DtpHasta.Enabled = True
            TxtFactura.Enabled = False
            TxtComentario.Enabled = False
            TxtProveerdor.Enabled = False
        End If
        If RdbFactura.Checked Then
            TxtCantidad.Enabled = False
            DtpDesde.Enabled = False
            DtpHasta.Enabled = False
            TxtFactura.Enabled = True
            TxtComentario.Enabled = False
            TxtProveerdor.Enabled = False
        End If
        If RdbComentario.Checked Then
            TxtCantidad.Enabled = False
            DtpDesde.Enabled = False
            DtpHasta.Enabled = False
            TxtFactura.Enabled = False
            TxtComentario.Enabled = True
            TxtProveerdor.Enabled = False
        End If
        If RdbProveedor.Checked Then
            TxtCantidad.Enabled = False
            DtpDesde.Enabled = False
            DtpHasta.Enabled = False
            TxtFactura.Enabled = False
            TxtComentario.Enabled = False
            TxtProveerdor.Enabled = True
        End If

        'TxtCantidad.Enabled = RdbUltimos.Checked
        'DtpDesde.Enabled = Not RdbUltimos.Checked
        'DtpHasta.Enabled = Not RdbUltimos.Checked
    End Sub

    Private Sub RdbFechas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdbFechas.CheckedChanged
        HabilitaFiltros()
    End Sub
    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Salir()
    End Sub
    Private Sub BtnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles BtnBuscar.Click
        If ValidaCriteriosBusqueda() Then
            Buscar()
        End If
    End Sub

    Private Sub BtnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub RdbComentario_CheckedChanged(sender As Object, e As EventArgs) Handles RdbComentario.CheckedChanged
        HabilitaFiltros()
    End Sub

    Private Sub RdbFactura_CheckedChanged(sender As Object, e As EventArgs) Handles RdbFactura.CheckedChanged
        HabilitaFiltros()
    End Sub
End Class