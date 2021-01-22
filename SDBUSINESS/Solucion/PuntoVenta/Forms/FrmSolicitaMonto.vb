Imports Business

Public Class FrmSolicitaMonto
    Private _CerroVentana As Boolean = False
    Private _Cantidad As Double = 1
    Private _Articulo As TInfoArticulo
    Private _Precio As Double

    Public Property Articulo() As TInfoArticulo
        Get
            Return _Articulo
        End Get
        Set(ByVal value As TInfoArticulo)
            _Articulo = value
        End Set
    End Property


    Public Property Cantidad() As Double
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Double)
            _Cantidad = value
        End Set
    End Property

    Public Property CerroVentana() As Boolean
        Get
            Return _CerroVentana
        End Get
        Set(ByVal value As Boolean)
            _CerroVentana = value
        End Set
    End Property

    Dim Numerico() As TNumericFormat

    Public Sub Execute(pArticulo As TInfoArticulo)
        _Articulo = pArticulo
        FormateaCamposNumericos()
        CargaDatosArticulo()
        TxtMonto.Select()
        Me.ShowDialog()
    End Sub

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(1)

            Numerico(0) = New TNumericFormat(TxtMonto, 7, 4, False, "0.00", "#,##0.0000")
            Numerico(1) = New TNumericFormat(TxtCantidad, 7, 4, False, "0.00", "#,##0.0000")



        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaDatosArticulo()
        Try
            _Cantidad = 1
            LblArticulo.Text = _Articulo.Nombre
            LblUnidadMedida.Text = _Articulo.UnidadMedidaNombre

            If Not _Articulo.ExentoIV Then
                _Precio = (_Articulo.Precio + CalculaMontoImpuesto(_Articulo.Precio, _Articulo.ArticuloImpuestos))
            Else
                _Precio = _Articulo.Precio
            End If

            LblPrecio.Text = Format(_Precio, "#,##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try


    End Sub


    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        _CerroVentana = True
        Me.Close()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmSolicitaMonto_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F3 Then
            BtnAceptar.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            BtnSalir.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            BtnAceptar.PerformClick()
        ElseIf e.KeyCode = Keys.F4 Then
            BtnCinco.PerformClick()
        ElseIf e.KeyCode = Keys.F5 Then
            BtnDiez.PerformClick()
        ElseIf e.KeyCode = Keys.F6 Then
            BtnQuince.PerformClick()
        ElseIf e.KeyCode = Keys.F7 Then
            BtnViente.PerformClick()
        End If

    End Sub

    Private Sub TxtMonto_TextChanged(sender As Object, e As EventArgs) Handles TxtMonto.TextChanged
        Try
            Cantidad = (CDbl(TxtMonto.Text) / _Precio)

            TxtCantidad.Text = Format(Cantidad, "##0.0000")
        Catch ex As Exception
            TxtCantidad.Text = 0
        End Try

    End Sub

    Private Sub TxtMonto_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMonto.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnAceptar.PerformClick()
        End If
    End Sub


    Private Sub BtnCinco_Click(sender As Object, e As EventArgs) Handles BtnCinco.Click
        TxtMonto.Text = 5000
        BtnAceptar.PerformClick()
    End Sub

    Private Sub BtnDiez_Click(sender As Object, e As EventArgs) Handles BtnDiez.Click
        TxtMonto.Text = 10000
        BtnAceptar.PerformClick()
    End Sub

    Private Sub BtnQuince_Click(sender As Object, e As EventArgs) Handles BtnQuince.Click
        TxtMonto.Text = 15000
        BtnAceptar.PerformClick()
    End Sub

    Private Sub BtnViente_Click(sender As Object, e As EventArgs) Handles BtnViente.Click
        TxtMonto.Text = 20000
        BtnAceptar.PerformClick()
    End Sub

    'Private Function CalculaMontoImpuesto(pMonto As Double, pArticuloImpuestos As List(Of TFacturaDetalleImpuesto)) As Double
    '    Dim OtrosImpuestos As Double = 0
    '    Dim TotalImpuesto As Double = 0


    '    For Each impuesto As TFacturaDetalleImpuesto In pArticuloImpuestos
    '        If impuesto.Codigo_Id <> coImpuesto01 And impuesto.Codigo_Id <> coImpuesto12 Then
    '            With impuesto
    '                .Detalle_Id = 1
    '                .Monto = pMonto * (impuesto.Porcentaje / 100)
    '            End With
    '            OtrosImpuestos += impuesto.Monto

    '        End If
    '    Next

    '    For Each impuesto As TFacturaDetalleImpuesto In pArticuloImpuestos
    '        If impuesto.Codigo_Id = coImpuesto01 OrElse impuesto.Codigo_Id = coImpuesto12 Then
    '            With impuesto
    '                .Detalle_Id = 1
    '                .Monto = (pMonto + OtrosImpuestos) * (impuesto.Porcentaje / 100)
    '            End With
    '            TotalImpuesto += impuesto.Monto
    '        End If
    '    Next

    '    Return TotalImpuesto + OtrosImpuestos

    'End Function
End Class