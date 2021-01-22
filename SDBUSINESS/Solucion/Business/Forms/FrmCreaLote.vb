Imports System.Windows.Forms
Imports Business
Public Class FrmCreaLote
    Private _CerroVentana As Boolean
    Private _Lote As TLote
    Private _ValidaVencimiento As Boolean = True
    Dim Numerico() As TNumericFormat

    Public Property Lote() As TLote
        Get
            Return _Lote
        End Get
        Set(ByVal value As TLote)
            _Lote = value
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
    Public WriteOnly Property ValidaVencimiento As Boolean
        Set(value As Boolean)
            _ValidaVencimiento = value
        End Set
    End Property

    Public Sub Execute(pNompre As String)
        LblArticulo.Text = pNompre
        _CerroVentana = False
        TxtCantidad.Select()
        FormateaCamposNumericos()
        Me.ShowDialog()
    End Sub

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtCantidad, 9, 4, False, "1.0000", "##0.0000")
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtLote_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLote.KeyDown
        If e.KeyCode = Keys.Enter Then
            DtpVencimiento.Select()
        End If
    End Sub

    Private Sub TxtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLote.Select()
        End If
    End Sub

    Private Sub DtpVencimiento_KeyDown(sender As Object, e As KeyEventArgs) Handles DtpVencimiento.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnAceptar.Select()
        End If
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If Not IsNumeric(TxtCantidad.Text) OrElse CDbl(TxtCantidad.Text) <= 0 Then
                TxtCantidad.Select()
                VerificaMensaje("La cantidad tiene que ser mayor a 0 y no puede estar vacia")
            End If

            If TxtLote.Text = "" Then
                TxtLote.Select()
                VerificaMensaje("El lote no puede ser vacio")
            End If

            If _ValidaVencimiento AndAlso DtpVencimiento.Value.Date < Now.Date Then
                DtpVencimiento.Select()
                VerificaMensaje("La fecha de vencimiento no puede ser menor a la fecha actual")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try
            If ValidaTodo() Then

                Lote = New TLote()

                With Lote

                    .Cantidad = TxtCantidad.Text
                    .Lote = TxtLote.Text
                    .Vencimiento = DateValue(DtpVencimiento.Value)

                End With

                _CerroVentana = True
                Me.Close()

            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmCreaLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class