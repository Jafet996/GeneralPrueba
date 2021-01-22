Imports Business
Public Class FrmIngresaMonto
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private _PermiteDecimales As Boolean
    Private _CantidadEnteros As Integer
    Private _CantidadDecimales As Integer
    Private _Descripcion As String
    Private _Monto As Double
    Private _Maximo As Double = 0
    Private _Acepto As Boolean
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
#Region "Funciones Privadas"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            If _Descripcion.Trim <> "" Then
                LblDescripcion.Text = _Descripcion
            End If

            If _PermiteDecimales Then
                Numerico(0) = New TNumericFormat(TxtMonto, _CantidadEnteros, _CantidadDecimales, False, "", "##0.00")
            Else
                Numerico(0) = New TNumericFormat(TxtMonto, _CantidadEnteros, 0, False, "", "##0")
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Public Sub Execute()
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

        Me.ShowDialog()
    End Sub

    Private Function ValidaMonto() As Boolean
        Try
            If Not IsNumeric(TxtMonto.Text) Then
                VerificaMensaje("Debe de digitar un número")
            End If

            If CDbl(TxtMonto.Text) < 0 Then
                VerificaMensaje("El número debe de ser mayor a cero")
            End If

            If _Maximo > 0 Then
                If CDbl(TxtMonto.Text.Trim) > _Maximo Then
                    VerificaMensaje("El número digitado no puede no puede ser mayor a " & _Maximo)
                End If
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

    Private Sub FrmIngresaMonto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormateaCamposNumericos()
    End Sub
End Class