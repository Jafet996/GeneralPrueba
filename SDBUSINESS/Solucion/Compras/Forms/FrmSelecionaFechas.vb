Imports Business

Public Class FrmSelecionaFechas

    Private _CerroVentana As Boolean
    Private _Desde As Date
    Private _Hasta As Date
    Public Property Hasta() As Date
        Get
            Return _Hasta
        End Get
        Set(ByVal value As Date)
            _Hasta = value
        End Set
    End Property
    Public Property Desde() As Date
        Get
            Return _Desde
        End Get
        Set(ByVal value As Date)
            _Desde = value
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

    Public Sub Execute()
        Try
            CerroVentana = False
            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try

            If DtpDesde.Value.Date > DtpHasta.Value.Date Then
                VerificaMensaje("La fecha inicial debe ser menor o igual ala fecha final")
            End If

            Desde = DtpDesde.Value.Date
            Hasta = DtpHasta.Value.Date
            CerroVentana = True
            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmSelecionaFechas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            BtnSalir.PerformClick()
        ElseIf e.KeyCode = Keys.F3 Then
            BtnAceptar.PerformClick()
        End If
    End Sub
End Class