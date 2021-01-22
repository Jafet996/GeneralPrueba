Imports Business
Public Class FrmBusquedaProduccion
#Region "Declaraciones"
    Dim Numerico() As TNumericFormat
    Private Const coCantidad = 30
    Private _TipoTraslado As Boolean
    Private _Selecciono As Boolean
    Private _TipoProd_Id As Integer
    Private _Prod_Id As Long
    Private _Activo As Boolean = False
#End Region
#Region "Propiedades"
    Public WriteOnly Property TipoTraslado As Boolean
        Set(value As Boolean)
            _TipoTraslado = value
        End Set
    End Property
    Public ReadOnly Property Selecciono As Boolean
        Get
            Return _Selecciono
        End Get
    End Property
    Public ReadOnly Property TipoProd_Id As Integer
        Get
            Return _TipoProd_Id
        End Get
    End Property
    Public ReadOnly Property Prod_Id As Long
        Get
            Return _Prod_Id
        End Get
    End Property
#End Region
#Region "Funciones privadas"
    Private Sub Seleccionar()
        Try
            If CmbTipoMovimiento.SelectedValue Is Nothing Then
                CmbTipoMovimiento.Focus()
                VerificaMensaje("Debe de seleccionar un tipo de movimiento")
            End If

            If DGDetalle.CurrentCell Is Nothing Then
                VerificaMensaje("Debe de seleccionar un valor")
            End If

            _TipoProd_Id = CmbTipoMovimiento.SelectedValue
            _Prod_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value

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

    Private Sub CargaCombos()
        Dim TipoProduccion As New TTipoProduccion(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try


            Mensaje = TipoProduccion.LoadComboBoxTipo(CmbTipoMovimiento)
            VerificaMensaje(Mensaje)


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TipoProduccion = Nothing
        End Try
    End Sub
    Public Sub Execute()
        _Selecciono = False
        TxtCantidad.Text = coCantidad
        CargaCombos()
        BtnBuscar.Focus()

        Me.ShowDialog()
    End Sub

    Private Function ValidaCriteriosBusqueda() As Boolean
        Try

            If CmbTipoMovimiento.SelectedValue Is Nothing OrElse CmbTipoMovimiento.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccinar un tipo de movimiento")
            End If

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

    Private Sub BtnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles BtnBuscar.Click
        If ValidaCriteriosBusqueda() Then
            Buscar()
        End If
    End Sub
    Private Sub Buscar()
        Dim ProduccionEncabezado As New TProduccionEncabezado(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Dim TipoBusqueda As Integer = 0
        Try
            _Selecciono = False

            DGDetalle.DataSource = Nothing

            If RdbUltimos.Checked Then
                TipoBusqueda = 1
            ElseIf RdbFechas.Checked Then
                TipoBusqueda = 2
            End If


            ProduccionEncabezado.Suc_Id = SucursalInfo.Suc_Id
            ProduccionEncabezado.TipoProd_Id = CmbTipoMovimiento.SelectedValue
            Mensaje = ProduccionEncabezado.ListBusqueda(TipoBusqueda, CInt(TxtCantidad.Text), DateValue(DtpDesde.Value), DateValue(DtpHasta.Value))
            VerificaMensaje(Mensaje)

            DGDetalle.DataSource = ProduccionEncabezado.Data.Tables(0)
            DGDetalle.Columns(0).Width = 80
            DGDetalle.Columns(1).Width = 245
            DGDetalle.Columns(2).Width = 120
            DGDetalle.Columns(3).Width = 100

            If DGDetalle.RowCount > 0 Then
                DGDetalle.Focus()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ProduccionEncabezado = Nothing
        End Try
    End Sub

    Private Sub CmbTipoMovimiento_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbTipoMovimiento.SelectedIndexChanged
        DGDetalle.DataSource = Nothing
    End Sub


    Private Sub DGDetalle_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDetalle.CellDoubleClick
        Seleccionar()
    End Sub

    Private Sub DGDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DGDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.F2, (Keys.Enter And DGDetalle.RowCount > 0)
                Seleccionar()
        End Select
    End Sub

    Private Sub FrmBusquedaMovimiento_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If Not _Activo Then
            _Activo = False
            BtnBuscar.Focus()
        End If
    End Sub

    Private Sub Limpiar()
        DGDetalle.DataSource = Nothing
    End Sub

    Private Sub FrmBusquedaMovimiento_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                If Me.ActiveControl.Name = "DGDetalle" Then
                    BtnAceptar.PerformClick()
                End If
            Case Keys.F6
                BtnLimpiar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select

    End Sub


    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        Seleccionar()
    End Sub

    Private Sub BtnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
End Class