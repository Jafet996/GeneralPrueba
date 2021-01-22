Public Class FrmIngresaMonto
#Region "Definition of Fields"
    Dim Numerico() As TNumericFormat
    Private _PermiteDecimales As Boolean
    Private _CantidadEnteros As Integer
    Private _CantidadDecimales As Integer
    Private _ValorMaximo As Double = 0
    Private _ValorMinimo As Double = 0
    Private _Titulo As String
    Private _Descripcion As String
    Private _Monto As Double
    Private _Acepto As Boolean
#End Region
#Region "Definition of Properties"
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
    Public WriteOnly Property ValorMaximo As Double
        Set(value As Double)
            _ValorMaximo = value
        End Set
    End Property
    Public WriteOnly Property ValorMinimo As Double
        Set(value As Double)
            _ValorMaximo = value
        End Set
    End Property
    Public WriteOnly Property Titulo As String
        Set(value As String)
            _Titulo = value
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
#End Region
#Region "Definition of Public Methods"
    Public Sub Execute()
        FormateaCamposNumericos()
        _Acepto = False
        TxtMonto.Text = Format(_Monto, IIf(_PermiteDecimales, "#,##0." & StrDup(_CantidadDecimales, "0"), "#,##0"))

        If _Descripcion.Trim <> "" Then LblDescripcion.Text = _Descripcion
        If _Titulo.Trim <> String.Empty Then Me.Text = _Titulo

        Me.ShowDialog()
    End Sub
#End Region
#Region "Definition of Private Methods"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            If _Descripcion.Trim <> "" Then
                LblDescripcion.Text = _Descripcion
            End If

            If _PermiteDecimales Then
                Numerico(0) = New TNumericFormat(TxtMonto, _CantidadEnteros, _CantidadDecimales, False, "", "#,###0.00")
            Else
                Numerico(0) = New TNumericFormat(TxtMonto, _CantidadEnteros, 0, False, "", "#,##0")
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Function ValidaMonto() As Boolean
        Try
            If Not IsNumeric(TxtMonto.Text) Then
                VerificaMensaje("Debe de digitar un valor")
            End If

            If CDbl(TxtMonto.Text) < _ValorMinimo Then
                TxtMonto.Select()
                TxtMonto.SelectAll()
                VerificaMensaje("El valor debe de ser mayor a " & _ValorMinimo)
            End If

            If _ValorMaximo <> 0 AndAlso CDbl(TxtMonto.Text) > _ValorMaximo Then
                TxtMonto.Select()
                TxtMonto.SelectAll()
                VerificaMensaje("El valor no puede ser mayor a " & _ValorMaximo)
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function
#End Region
#Region "Definition of Events"
    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try
            If ValidaMonto() Then
                _Acepto = True
                _Monto = CDbl(TxtMonto.Text)
                Me.Close()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        _Acepto = False
        Me.Close()
    End Sub
#End Region
End Class