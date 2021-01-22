Imports Business
Public Class FrmIngresaMonto
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private _PermiteDecimales As Boolean
    Private _CantidadEnteros As Integer
    Private _CantidadDecimales As Integer
    Private _Descripcion As String
    Private _Moneda As Char = ""
    Private _Monto As Double = 0.0
    Private _Dolares As Double = 0.0
    Private _TipoCambio As Double = 1
    Private _Maximo As Double = 0.0
    Private _Acepto As Boolean = False
    Private _Modificando As Boolean = False
#End Region
#Region "Propiedades"
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
    Public WriteOnly Property Maximo As Double
        Set(value As Double)
            _Maximo = value
        End Set
    End Property
    Public WriteOnly Property Moneda As Char
        Set(value As Char)
            _Moneda = value
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
    Public Property Dolares As Double
        Get
            Return _Dolares
        End Get
        Set(value As Double)
            _Dolares = value
        End Set
    End Property
    Public Property TipoCambio As Double
        Get
            Return _TipoCambio
        End Get
        Set(value As Double)
            _TipoCambio = value
        End Set
    End Property
    Public ReadOnly Property Acepto As Boolean
        Get
            Return _Acepto
        End Get
    End Property
#End Region
#Region "Funciones Privadas"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(1)

            If _PermiteDecimales Then
                Numerico(0) = New TNumericFormat(TxtMonto, _CantidadEnteros, _CantidadDecimales, False, "", "#,##0.00")
            Else
                Numerico(0) = New TNumericFormat(TxtMonto, _CantidadEnteros, 0, False, "", "#,##0")
            End If

            Numerico(1) = New TNumericFormat(TxtDolares, _CantidadEnteros - 2, 4, False, "", "#,##0.0000")
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Public Sub Execute()
        CargaDatos()

        Me.ShowDialog()
    End Sub

    Private Function CargaDatos() As String
        Try
            If _Descripcion.Trim <> "" Then
                Me.Text = _Descripcion
            End If

            LblTipoCambio.Text = Format(_TipoCambio, "#,##0.00")

            If _PermiteDecimales Then
                TxtMonto.Text = Format(_Monto, "#,##0." & StrDup(_CantidadDecimales, "0"))
            Else
                TxtMonto.Text = Format(_Monto, "#,##0")
            End If

            'Select Case _Moneda
            '    Case coMonedaColones
            '        If _PermiteDecimales Then
            '            TxtMonto.Text = Format(_Monto, "#,##0." & StrDup(_CantidadDecimales, "0"))
            '        Else
            '            TxtMonto.Text = Format(_Monto, "#,##0")
            '        End If
            '    Case coMonedaDolares
            '        TxtDolares.Tag = _Dolares
            '        TxtDolares.Text = Format(_Dolares, "#,##0.0000")
            '    Case Else
            '        VerificaMensaje("Tipo de Moneda no permitido")
            'End Select

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function ValidaMonto() As Boolean
        Try
            If Not IsNumeric(TxtMonto.Text) Then
                VerificaMensaje("Debe de digitar un número")
            End If

            If CDbl(TxtMonto.Text) < 0 Then
                VerificaMensaje("El número debe de ser mayor a cero")
            End If

            If _Maximo > 0 Then
                If _Moneda = coMonedaColones Then
                    If CDbl(TxtMonto.Text.Trim) > _Maximo Then
                        VerificaMensaje("El número digitado no puede no puede ser mayor a ¢" & _Maximo)
                    End If
                ElseIf CDbl(TxtDolares.Tag) > _Maximo Then
                    VerificaMensaje("El número digitado no puede no puede ser mayor a $" & _Maximo)
                End If
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Aceptar()
        Try
            If ValidaMonto() Then
                _Acepto = True
                _Monto = CDbl(TxtMonto.Text.Trim)
                _Dolares = CDbl(TxtDolares.Tag)
                Me.Close()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        Aceptar()
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmIngresaMonto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormateaCamposNumericos()
    End Sub

    Private Sub FrmIngresaMonto_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnAceptar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub TxtMonto_TextChanged(sender As Object, e As EventArgs) Handles TxtMonto.TextChanged
        Try
            If _Modificando Then
                Exit Sub
            End If

            If Not IsNumeric(TxtMonto.Text) Then
                TxtMonto.Text = "0.00"
            End If

            _Modificando = True
            TxtDolares.Text = Format(CDbl(TxtMonto.Text.Trim) / _TipoCambio, "#,##0.0000")
            TxtDolares.Tag = CDbl(TxtMonto.Text.Trim) / _TipoCambio
            _Modificando = False
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtDolares_TextChanged(sender As Object, e As EventArgs) Handles TxtDolares.TextChanged
        Try
            If _Modificando Then
                Exit Sub
            End If

            _Modificando = True

            If Not IsNumeric(TxtDolares.Text) Then
                TxtDolares.Text = "0.00"
            End If

            TxtDolares.Tag = TxtDolares.Text.Trim
            TxtMonto.Text = Format(CDbl(TxtDolares.Tag) * _TipoCambio, IIf(_PermiteDecimales, "#,##0." & StrDup(_CantidadDecimales, "0"), "#,##0"))
            _Modificando = False
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

End Class