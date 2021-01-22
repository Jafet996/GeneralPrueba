﻿Imports Business ''
Public Class FrmBusquedaOrdenCompra
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

    Private Sub BtnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles BtnBuscar.Click
        If ValidaCriteriosBusqueda() Then
            Buscar()
        End If
    End Sub
    Private Sub Buscar()
        Dim OrdenCompraEncabezado As New TOrdenCompraEncabezado(EmpresaInfo.Emp_Id)
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
            End If


            OrdenCompraEncabezado.Suc_Id = SucursalInfo.Suc_Id
            Mensaje = OrdenCompraEncabezado.ListBusqueda(TipoBusqueda, CInt(TxtCantidad.Text), DateValue(DtpDesde.Value), DateValue(DtpHasta.Value), _SoloAplicadas) '
            VerificaMensaje(Mensaje)

            DGDetalle.DataSource = OrdenCompraEncabezado.Data.Tables(0)
            DGDetalle.Columns(0).Width = 60
            DGDetalle.Columns(1).Width = 100
            DGDetalle.Columns(2).Width = 70
            DGDetalle.Columns(3).Width = 300
            DGDetalle.Columns(4).Width = 490

            If DGDetalle.RowCount > 0 Then
                DGDetalle.Focus()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            OrdenCompraEncabezado = Nothing
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


    Private Sub FrmBusquedaMovimiento_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                BtnBuscar.PerformClick()
            Case Keys.F2, Keys.Enter
                If Me.ActiveControl.Name = "DGDetalle" Then
                    BtnAceptar.PerformClick()
                End If
            Case Keys.F6
                BtnLimpiar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub RdbUltimos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdbUltimos.CheckedChanged
        HabilitaFiltros()
    End Sub

    Private Sub HabilitaFiltros()
        TxtCantidad.Enabled = RdbUltimos.Checked
        DtpDesde.Enabled = Not RdbUltimos.Checked
        DtpHasta.Enabled = Not RdbUltimos.Checked
    End Sub

    Private Sub RdbFechas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdbFechas.CheckedChanged
        HabilitaFiltros()
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