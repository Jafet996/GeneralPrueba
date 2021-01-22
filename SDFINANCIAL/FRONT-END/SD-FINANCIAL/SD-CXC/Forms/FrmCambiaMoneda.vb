Imports BUSINESS
Public Class FrmCambiaMoneda
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private _Titulo As String = ""
    Private _TipoMovimiento As Integer = 0
    Private _TipoCambio As Double = 0.0
    Private _Dolares As Double = 0.0
    Private _Colones As Double = 0.0
    Private _CerrarPantalla As Boolean = False
    Private _Modificando As Boolean = False
#End Region
#Region "Propiedades"
    Public Property Dolares As Double
        Get
            Return _Dolares
        End Get
        Set(value As Double)
            _Dolares = value
        End Set
    End Property
    Public Property Colones As Double
        Get
            Return _Colones
        End Get
        Set(value As Double)
            _Colones = value
        End Set
    End Property
    Public WriteOnly Property Titulo As String
        Set(value As String)
            _Titulo = value
        End Set
    End Property
    Public WriteOnly Property TipoMovimiento As Integer
        Set(value As Integer)
            _TipoMovimiento = value
        End Set
    End Property
#End Region
#Region "Formateo de Campos"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(1)

            Numerico(0) = New TNumericFormat(TxtRecibe, 12, 4, False, "0.0000", "#,##0.0000")
            Numerico(1) = New TNumericFormat(TxtDevuelve, 12, 4, False, "0.0000", "#,##0.0000")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Public Sub Execute()
        CargaDatos()

        If Not _CerrarPantalla Then Me.ShowDialog()
    End Sub

    Private Sub CargaDatos()
        Try
            Me.Text = _Titulo
            VerificaMensaje(VerificaAperturaCaja(True))
            _TipoCambio = GetTipoCambioCierre(CajaInfo.Cierre_Id)
            LblMontoTipoCambio.Text = _TipoCambio
            Select Case _TipoMovimiento
                Case Enum_CambioMonedaTipo.Compra
                    LblRecibe.Text = "Dólares"
                    LblDevuelve.Text = "Colones"
                    TxtRecibe.Text = Format(_Dolares, "#,##0.0000")
                    TxtDevuelve.ReadOnly = True
                Case Enum_CambioMonedaTipo.Venta
                    LblRecibe.Text = "Colones"
                    LblDevuelve.Text = "Dólares"
                    TxtRecibe.Text = Format(_Colones, "#,##0.0000")
                    TxtDevuelve.ReadOnly = False
                Case Else
                    VerificaMensaje("Tipo de Transacción no especificada(" & _TipoMovimiento & ")")
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
            _CerrarPantalla = True
            Me.Close()
        End Try
    End Sub

    Private Sub ConvierteDolares()
        Try
            If TxtRecibe.Text.Trim = "" OrElse Not IsNumeric(TxtRecibe.Text.Trim) OrElse CDbl(TxtRecibe.Text.Trim) < 0 Then
                Exit Sub
            End If

            TxtDevuelve.Text = Format(CDbl(TxtRecibe.Text.Trim) * _TipoCambio, "#,##0.0000")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ConvierteDolaresInverso()
        Try
            If TxtDevuelve.Text.Trim = "" OrElse Not IsNumeric(TxtDevuelve.Text.Trim) OrElse CDbl(TxtDevuelve.Text.Trim) < 0 Then
                Exit Sub
            End If

            TxtRecibe.Text = Format(CDbl(TxtDevuelve.Text.Trim) * _TipoCambio, "#,##0.0000")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ConvierteColones()
        Try
            If TxtRecibe.Text.Trim = "" OrElse Not IsNumeric(TxtRecibe.Text.Trim) OrElse CDbl(TxtRecibe.Text.Trim) < 0 Then
                Exit Sub
            End If

            TxtDevuelve.Text = Format(CDbl(TxtRecibe.Text.Trim) / _TipoCambio, "#,##0.0000")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaCompra() As Boolean
        Try
            If TxtRecibe.Text.Trim = "" Then
                EnfocarTexto(TxtRecibe)
                VerificaMensaje("Debe de ingresar el monto de dólares que desea comprar")
            End If

            If Not IsNumeric(TxtRecibe.Text.Trim) Then
                EnfocarTexto(TxtRecibe)
                VerificaMensaje("El monto de dólares debe der númerico")
            End If

            If CDbl(TxtRecibe.Text.Trim) <= 0.0 Then
                EnfocarTexto(TxtRecibe)
                VerificaMensaje("El monto de dólares debe ser mayor a 0")
            End If

            If TxtDevuelve.Text.Trim = "" Then
                EnfocarTexto(TxtDevuelve)
                VerificaMensaje("Ocurrió un error al convertir a colones")
            End If

            If Not IsNumeric(TxtDevuelve.Text.Trim) Then
                EnfocarTexto(TxtDevuelve)
                VerificaMensaje("El monto de colones no es númerico")
            End If

            If CDbl(TxtDevuelve.Text.Trim) <= 0.0 Then
                EnfocarTexto(TxtDevuelve)
                VerificaMensaje("El monto de colones debe ser mayor a 0")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Function ValidaVenta() As Boolean
        Try
            If TxtRecibe.Text.Trim = "" Then
                EnfocarTexto(TxtRecibe)
                VerificaMensaje("Debe de ingresar el monto de colones que desea regresar")
            End If

            If Not IsNumeric(TxtRecibe.Text.Trim) Then
                EnfocarTexto(TxtRecibe)
                VerificaMensaje("El monto de colones debe der númerico")
            End If

            If CDbl(TxtRecibe.Text.Trim) <= 0.0 Then
                EnfocarTexto(TxtRecibe)
                VerificaMensaje("El monto de colones debe ser mayor a 0")
            End If

            If TxtDevuelve.Text.Trim = "" Then
                EnfocarTexto(TxtDevuelve)
                VerificaMensaje("Ocurrió un error al convertir a dólares")
            End If

            If Not IsNumeric(TxtDevuelve.Text.Trim) Then
                EnfocarTexto(TxtDevuelve)
                VerificaMensaje("El monto de dólares no es númerico")
            End If

            If CDbl(TxtDevuelve.Text.Trim) <= 0.0 Then
                EnfocarTexto(TxtDevuelve)
                VerificaMensaje("El monto de dólares debe ser mayor a 0")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub CompraDolares()
        Dim CambioMoneda As New TCambioMoneda
        Dim Forma As New FrmVuelto

        Try
            If MsgBox("¿Desea efectuar la compra?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, Me.Text) <> MsgBoxResult.Ok Then
                Exit Sub
            End If

            With CambioMoneda
                .Emp_Id = EmpresaInfo.Emp_Id
                .Caja_Id = CajaInfo.Caja_Id
                .Cierre_Id = CajaInfo.Cierre_Id
                .Efectivo = CDbl(TxtDevuelve.Text.Trim)
                .Dolares = CDbl(TxtRecibe.Text.Trim)
                .TipoCambio = _TipoCambio
                .Tipo_Id = Enum_CambioMonedaTipo.Compra
                .Usuario_Id = UsuarioInfo.Usuario_Id
            End With
            VerificaMensaje(CambioMoneda.Insert)
            VerificaMensaje(ImprimeCambioMoneda(EmpresaInfo, CambioMoneda.Cambio_Id, False))

            Forma.Execute(CambioMoneda.Efectivo, "Colones")

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CambioMoneda = Nothing
            Forma = Nothing
        End Try
    End Sub

    Private Sub DevolucionDolares()
        Dim CambioMoneda As New TCambioMoneda
        Dim Forma As New FrmVuelto

        Try
            If MsgBox("¿Desea efectuar la devolución?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, Me.Text) <> MsgBoxResult.Ok Then
                Exit Sub
            End If

            With CambioMoneda
                .Emp_Id = EmpresaInfo.Emp_Id
                .Caja_Id = CajaInfo.Caja_Id
                .Cierre_Id = CajaInfo.Cierre_Id
                .Efectivo = CDbl(TxtRecibe.Text.Trim)
                .Dolares = CDbl(TxtDevuelve.Text.Trim)
                .TipoCambio = _TipoCambio
                .Tipo_Id = Enum_CambioMonedaTipo.Venta
                .Usuario_Id = UsuarioInfo.Usuario_Id
            End With
            VerificaMensaje(CambioMoneda.Insert)
            VerificaMensaje(ImprimeCambioMoneda(EmpresaInfo, CambioMoneda.Cambio_Id, False))

            Forma.Execute(CambioMoneda.Dolares, "Dólares")

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CambioMoneda = Nothing
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnAplicar_Click(sender As Object, e As EventArgs) Handles BtnAplicar.Click
        Select Case _TipoMovimiento
            Case Enum_CambioMonedaTipo.Compra
                If ValidaCompra() Then
                    CompraDolares()
                End If
            Case Enum_CambioMonedaTipo.Venta
                If ValidaVenta() Then
                    DevolucionDolares()
                End If
        End Select
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub TxtRecibe_TextChanged(sender As Object, e As EventArgs) Handles TxtRecibe.TextChanged
        If _Modificando Then
            Exit Sub
        End If

        _Modificando = True

        Select Case _TipoMovimiento
            Case Enum_CambioMonedaTipo.Compra
                ConvierteDolares()
            Case Enum_CambioMonedaTipo.Venta
                ConvierteColones()
        End Select

        _Modificando = False
    End Sub

    Private Sub FrmCambiaMoneda_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnAplicar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub FrmCambiaMoneda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormateaCamposNumericos()
        TxtRecibe.Select()
    End Sub

    Private Sub TxtDevuelve_TextChanged(sender As Object, e As EventArgs) Handles TxtDevuelve.TextChanged
        If _Modificando Or _TipoMovimiento = Enum_CambioMonedaTipo.Compra Then
            Exit Sub
        End If

        _Modificando = True
        ConvierteDolaresInverso()
        _Modificando = False
    End Sub

End Class