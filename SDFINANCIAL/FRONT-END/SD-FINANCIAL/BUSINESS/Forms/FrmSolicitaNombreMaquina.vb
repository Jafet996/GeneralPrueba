Public Class FrmSolicitaNombreMaquina
#Region "Variables"
    Private _Selecciono As Boolean = False
    Private _NombreActual As String = ""
    Private _NombreNuevo As String = ""
#End Region
#Region "Propiedades"
    Public ReadOnly Property Selecciono
        Get
            Return _Selecciono
        End Get
    End Property
    Public WriteOnly Property NombreActual
        Set(value)
            _NombreActual = value
        End Set
    End Property
    Public ReadOnly Property NombreNuevo
        Get
            Return _NombreNuevo
        End Get
    End Property
#End Region

    Public Sub Execute()
        Try
            LblNombreActual.Text = _NombreActual

            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If TxtNuevoNombre.Text.Trim = "" Then
                If MsgBox("Si no se asigna un nuevo nombre se dejará por el nombre actual, desea continuar?", MsgBoxStyle.Information + MsgBoxStyle.OkCancel, Me.Text) <> MsgBoxResult.Ok Then
                    Return True
                End If
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub CambiaNombre()
        Try
            _Selecciono = True
            _NombreNuevo = TxtNuevoNombre.Text.Trim

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        If ValidaTodo() Then
            CambiaNombre()
        End If

        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        If MsgBox("Si no se asigna un nuevo nombre se dejará por el nombre actual, desea continuar?", MsgBoxStyle.Information + MsgBoxStyle.OkCancel, Me.Text) = MsgBoxResult.Ok Then
            Me.Close()
        End If
    End Sub

    Private Sub TxtNuevoNombre_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles TxtNuevoNombre.KeyDown
        Select Case e.KeyCode
            Case Windows.Forms.Keys.Enter
                BtnAceptar.PerformClick()
        End Select
    End Sub
End Class