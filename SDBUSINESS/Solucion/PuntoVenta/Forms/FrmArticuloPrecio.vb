Imports Business
Public Class FrmArticuloPrecio
    Dim Numerico() As TNumericFormat

    Private _PermiteDecimales As Boolean
    Private _CantidadEnteros As Integer
    Private _CantidadDecimales As Integer
    Private _Descripcion As String
    Private _Monto As Double
    Private _Acepto As Boolean
    Private _CodArt As String
    Private _Exento As Integer
    Private _Impuesto As New TInfoArticulo(EmpresaInfo.Emp_Id)
    Public Property Exento() As Integer
        Get
            Return _Exento
        End Get
        Set(ByVal value As Integer)
            _Exento = value
        End Set
    End Property

    Public WriteOnly Property PermiteDecimales As Boolean
        Set(value As Boolean)
            _PermiteDecimales = value
        End Set
    End Property
    Public WriteOnly Property CantidadEnteros As Integer
        Set(value As Integer)
            _CantidadEnteros = value
        End Set
    End Property
    Public WriteOnly Property CantidadDecimales As Integer
        Set(value As Integer)
            _CantidadDecimales = value
        End Set
    End Property
    Public WriteOnly Property Descripcion As String
        Set(value As String)
            _Descripcion = value
        End Set
    End Property
    Public Property Monto As Double
        Get
            Return _Monto
        End Get
        Set(value As Double)
            _Monto = value
        End Set
    End Property
    Public ReadOnly Property Acepto As Boolean
        Get
            Return _Acepto
        End Get
    End Property
    Public WriteOnly Property CodArt As String
        Set(value As String)
            _CodArt = value
        End Set
    End Property

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(6)

            If _Descripcion.Trim <> "" Then
                LblDescripcion.Text = _Descripcion
            End If

            If _PermiteDecimales Then
                Numerico(0) = New TNumericFormat(TxtMonto, _CantidadEnteros, _CantidadDecimales, False, "", "##0.0000")
                Numerico(1) = New TNumericFormat(TxtPrecio1, _CantidadEnteros, _CantidadDecimales, False, "", "##0.0000")
                Numerico(2) = New TNumericFormat(TxtPrecio2, _CantidadEnteros, _CantidadDecimales, False, "", "##0.0000")
                Numerico(3) = New TNumericFormat(TxtPrecio3, _CantidadEnteros, _CantidadDecimales, False, "", "##0.0000")
                Numerico(4) = New TNumericFormat(TxtPrecio4, _CantidadEnteros, _CantidadDecimales, False, "", "##0.0000")
                Numerico(5) = New TNumericFormat(TxtPrecio5, _CantidadEnteros, _CantidadDecimales, False, "", "##0.0000")
                Numerico(6) = New TNumericFormat(TxtMontoConImpuesto, _CantidadEnteros, _CantidadDecimales, False, "", "##0.0000")
            Else
                Numerico(0) = New TNumericFormat(TxtMonto, _CantidadEnteros, 0, False, "", "##0")
                Numerico(1) = New TNumericFormat(TxtPrecio1, _CantidadEnteros, 0, False, "", "##0")
                Numerico(2) = New TNumericFormat(TxtPrecio2, _CantidadEnteros, 0, False, "", "##0")
                Numerico(3) = New TNumericFormat(TxtPrecio3, _CantidadEnteros, 0, False, "", "##0")
                Numerico(4) = New TNumericFormat(TxtPrecio4, _CantidadEnteros, 0, False, "", "##0")
                Numerico(5) = New TNumericFormat(TxtPrecio5, _CantidadEnteros, 0, False, "", "##0")
                Numerico(6) = New TNumericFormat(TxtMontoConImpuesto, _CantidadEnteros, 0, False, "", "##0")
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute()
        CargaImpuesto()
        _Acepto = False
        If _Descripcion.Trim <> "" Then
            LblDescripcion.Text = _Descripcion
            Me.Text = _Descripcion
        End If
        If _PermiteDecimales Then
            TxtMonto.Text = Format(_Monto, "0." & StrDup(_CantidadDecimales, "0"))
        Else
            TxtMonto.Text = _Monto.ToString
        End If

        If _Exento Then
            LblPoliticaImpuesto.Text = "EXENTO"
        Else
            LblPoliticaImpuesto.Text = "GRAVADO"
            LblPoliticaImpuesto.ForeColor = Color.DarkGreen
            CalculaMontoImpuesto(_Monto, _Impuesto.ArticuloImpuestos)
        End If


        CargaPrecio()
        FormateaCamposNumericos()

        TxtMonto.SelectAll()

        Me.ShowDialog()
    End Sub

    Private Function ValidaMonto() As Boolean
        Try
            If Not IsNumeric(TxtMonto.Text) Then
                VerificaMensaje("Debe de digitar un monto")
            End If
            If CDbl(TxtMonto.Text) < 0 Then
                VerificaMensaje("El monto debe de ser mayor a cero")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        Try
            If ValidaMonto() Then
                _Acepto = True

                'If _Exento Then
                '    _Monto = CDbl(TxtMonto.Text)
                'Else
                '    _Monto = (CDbl(TxtMonto.Text) / (1 + (EmpresaParametroInfo.PorcIV / 100)))
                'End If

                _Monto = CDbl(TxtMonto.Text)

                Me.Close()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        _Acepto = False
        Me.Close()
    End Sub

    Private Sub CargaPrecio()
        Dim precio As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Try

            With articulo
                .Art_Id = _CodArt
            End With

            VerificaMensaje(articulo.ListKey())
            _Exento = articulo.ExentoIV

            With precio
                .Suc_Id = SucursalInfo.Suc_Id
                .Bod_Id = CajaInfo.Bod_Id
                .Art_Id = _CodArt
            End With

            VerificaMensaje(precio.ListKey())

            TxtPrecio1.Text = precio.Precio
            TxtPrecio2.Text = precio.PrecioMayorista
            TxtPrecio3.Text = precio.Precio3
            TxtPrecio4.Text = precio.Precio4
            TxtPrecio5.Text = precio.Precio5

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            precio = Nothing
        End Try
    End Sub
    Private Sub CargaImpuesto()
        Try

            _Impuesto.Art_Id = _CodArt
            VerificaMensaje(_Impuesto.ConsultaArticuloImpuestos())

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub TxtPrecio1_DoubleClick(sender As Object, e As EventArgs) Handles TxtPrecio1.DoubleClick
        Try
            TxtMonto.Text = ""
            TxtMonto.Text = TxtPrecio1.Text
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtPrecio2_DoubleClick(sender As Object, e As EventArgs) Handles TxtPrecio2.DoubleClick
        Try
            TxtMonto.Text = ""
            TxtMonto.Text = TxtPrecio2.Text
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtPrecio3_DoubleClick(sender As Object, e As EventArgs) Handles TxtPrecio3.DoubleClick
        Try
            TxtMonto.Text = ""
            TxtMonto.Text = TxtPrecio3.Text
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtPrecio4_DoubleClick(sender As Object, e As EventArgs) Handles TxtPrecio4.DoubleClick
        Try
            TxtMonto.Text = ""
            TxtMonto.Text = TxtPrecio4.Text
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtPrecio5_DoubleClick(sender As Object, e As EventArgs) Handles TxtPrecio5.DoubleClick
        Try
            TxtMonto.Text = ""
            TxtMonto.Text = TxtPrecio5.Text
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtMonto_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMonto.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(TxtMonto.Text) Then
                BtnAceptar.PerformClick()
            End If
        End If
    End Sub

    Private Sub FrmArticuloPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnAceptar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub FrmArticuloPrecio_Load(sender As Object, e As EventArgs) Handles Me.Load
        TxtMonto.Focus()
    End Sub

    Private Sub TxtMonto_TextChanged(sender As Object, e As EventArgs) Handles TxtMonto.TextChanged
        Dim PrecioSinImpuesto As Double = 0
        Dim Impuesto As Double = 0
        Dim PrecioConImpuesto As Double = 0
        Try

            If TxtMonto.Tag <> "" Then
                Exit Sub
            End If

            TxtMonto.Tag = "PrecioSIV"

            If IsNumeric(TxtMonto.Text) Then
                PrecioSinImpuesto = CDbl(TxtMonto.Text)
            End If

            If PrecioSinImpuesto <> 0 AndAlso Not _Exento Then
                Impuesto = CalculaMontoImpuesto(PrecioSinImpuesto, _Impuesto.ArticuloImpuestos)
            End If

            If PrecioSinImpuesto <> 0 AndAlso Not _Exento Then
                PrecioConImpuesto = PrecioSinImpuesto + Impuesto
            Else
                PrecioConImpuesto = PrecioSinImpuesto
            End If


            If _PermiteDecimales Then
                'TxtMonto.Text = Format(PrecioSinImpuesto, "0." & StrDup(_CantidadDecimales, "0"))
                TxtImpuesto.Text = Format(Impuesto, "0." & StrDup(_CantidadDecimales, "0"))
                TxtMontoConImpuesto.Text = Format(PrecioConImpuesto, "0." & StrDup(_CantidadDecimales, "0"))
            Else
                'TxtMonto.Text = PrecioSinImpuesto.ToString
                TxtImpuesto.Text = Impuesto.ToString
                TxtMontoConImpuesto.Text = PrecioConImpuesto.ToString()
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            If TxtMonto.Tag = "PrecioSIV" Then
                TxtMonto.Tag = ""
            End If
        End Try
    End Sub

    Private Sub TxtMontoConImpuesto_TextChanged(sender As Object, e As EventArgs) Handles TxtMontoConImpuesto.TextChanged
        Dim PrecioSinImpuesto As Double = 0
        Dim Impuesto As Double = 0
        Dim PrecioConImpuesto As Double = 0
        Try

            If TxtMonto.Tag <> "" Then
                Exit Sub
            End If

            TxtMonto.Tag = "PrecioIVI"

            If IsNumeric(TxtMontoConImpuesto.Text) Then
                PrecioConImpuesto = CDbl(TxtMontoConImpuesto.Text)
            End If



            If PrecioConImpuesto <> 0 AndAlso Not _Exento Then
                PrecioSinImpuesto = PrecioConImpuesto - RestaMontoImpuesto(PrecioConImpuesto, _Impuesto.ArticuloImpuestos)
            Else
                PrecioConImpuesto = PrecioSinImpuesto
            End If



            Impuesto = PrecioConImpuesto - PrecioSinImpuesto




            If _PermiteDecimales Then
                TxtMonto.Text = Format(PrecioSinImpuesto, "0." & StrDup(_CantidadDecimales, "0"))
                TxtImpuesto.Text = Format(Impuesto, "0." & StrDup(_CantidadDecimales, "0"))
                'TxtMontoConImpuesto.Text = Format(PrecioConImpuesto, "0." & StrDup(_CantidadDecimales, "0"))
            Else
                TxtMonto.Text = PrecioSinImpuesto.ToString
                TxtImpuesto.Text = Impuesto.ToString
                'TxtMontoConImpuesto.Text = PrecioConImpuesto.ToString()
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            If TxtMonto.Tag = "PrecioIVI" Then
                TxtMonto.Tag = ""
            End If
        End Try
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
    'Private Function RestaMontoImpuesto(pMonto As Double, pArticuloImpuestos As List(Of TInfoArticuloImpuesto)) As Double
    '    Dim OtrosImpuestos As Double = 0
    '    Dim TotalImpuesto As Double = 0
    '    Dim TotalPorcentaje As Double = 0

    '    For Each impuesto As TInfoArticuloImpuesto In pArticuloImpuestos
    '        If impuesto.Codigo_Id = coImpuesto01 OrElse impuesto.Codigo_Id = coImpuesto12 Then
    '            TotalPorcentaje += impuesto.Porcentaje
    '        End If
    '    Next

    '    TotalImpuesto = pMonto - (pMonto / (1 + (TotalPorcentaje / 100)))

    '    For Each impuesto As TInfoArticuloImpuesto In pArticuloImpuestos
    '        If impuesto.Codigo_Id <> coImpuesto01 And impuesto.Codigo_Id <> coImpuesto12 Then
    '            OtrosImpuestos += impuesto.Porcentaje
    '        End If
    '    Next

    '    Return TotalImpuesto + (pMonto - TotalImpuesto) - ((pMonto - TotalImpuesto) / (1 + (OtrosImpuestos / 100)))

    'End Function
End Class