Imports BUSINESS
Public Class FrmMovimientoFormaPago
#Region "Variables"
    Private _Acepto As Boolean = False
    Private _TipoTransaccion As Integer = 0
#End Region
#Region "Propiedades"
    Public ReadOnly Property Acepto As Boolean
        Get
            Return _Acepto
        End Get
    End Property
    Public ReadOnly Property TipoTransaccion As Integer
        Get
            Return _TipoTransaccion
        End Get
    End Property
#End Region

    Public Sub Execute()
        Me.ShowDialog()
    End Sub

    Private Sub SeleccionaTipo(pTipo As Enum_TipoTransaccion)
        Try
            _TipoTransaccion = pTipo
            _Acepto = True

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnFisica_Click(sender As Object, e As EventArgs) Handles BtnFisica.Click
        SeleccionaTipo(Enum_TipoTransaccion.Fisica)
    End Sub

    Private Sub BtnElectronica_Click(sender As Object, e As EventArgs) Handles BtnElectronica.Click
        SeleccionaTipo(Enum_TipoTransaccion.Electronica)
    End Sub

    Private Sub PicVolver_Click(sender As Object, e As EventArgs) Handles PicVolver.Click
        Me.Close()
    End Sub

    Private Sub FrmMovimientoFormaPago_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

End Class