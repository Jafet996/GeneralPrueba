Imports Business
Public Class FrmApartadoCondiciones
    Dim Numerico() As TNumericFormat

    Private _PermiteDecimales As Boolean
    Private _CantidadEnteros As Integer
    Private _CantidadDecimales As Integer
    Private _Descripcion As String
    Private _Monto As Double
    Private _Acepto As Boolean
    Private _Vencimiento As Date = #1/1/1900#

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
    Public ReadOnly Property Vencimiento As Date
        Get
            Return _Vencimiento
        End Get
    End Property

    Public ReadOnly Property Acepto As Boolean
        Get
            Return _Acepto
        End Get
    End Property

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

    Public Sub Execute()
        Try

            _Acepto = False
            If _Descripcion.Trim <> "" Then
                LblDescripcion.Text = _Descripcion
                Me.Text = _Descripcion
            End If
            If _PermiteDecimales Then
                TxtMonto.Text = Format(_Monto, "0." & StrDup(_CantidadDecimales, "0"))
            Else
                TxtMonto.Text = Format(_Monto, "#,##0")
            End If

            DtpVencimiento.Value = DateValue(DateAdd(DateInterval.Day, EmpresaParametroInfo.ApartadoDiasVencimiento, EmpresaInfo.Getdate()))

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub

    Private Function ValidaTodo() As Boolean
        Dim Fecha As Date
        Try

            Fecha = EmpresaInfo.Getdate()


            If Not IsNumeric(TxtMonto.Text) Then
                VerificaMensaje("Debe de digitar un monto")
            End If
            If CDbl(TxtMonto.Text) < 0 Then
                VerificaMensaje("El monto debe de ser mayor a cero")
            End If

            If DateValue(DtpVencimiento.Value) < DateValue(Fecha) Then
                VerificaMensaje("La fecha de vencimiento no puede ser menoy a la fecha actual")
            End If


            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function


    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        Try


            If Not ConfirmaAccion("Desea guardar las condiciones para el apartado?") Then
                Exit Sub
            End If


            If ValidaTodo() Then
                _Acepto = True
                _Monto = CDbl(TxtMonto.Text)
                _Vencimiento = DateValue(DtpVencimiento.Value)
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

    Private Sub FrmIngresaMonto_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            FormateaCamposNumericos()

            TxtMonto.Focus()
            TxtMonto.SelectAll()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmApartadoCondiciones_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnAceptar.PerformClick()
        End Select
    End Sub

    Private Sub TxtMonto_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMonto.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                BtnAceptar.PerformClick()
        End Select
    End Sub
End Class