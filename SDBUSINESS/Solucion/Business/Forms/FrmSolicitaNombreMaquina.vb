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
                Else
                    VerificaMensaje("Debe de registrar la máquina con un nombre para identificarla")
                End If
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub CambiaNombre()
        Try
            If TxtNuevoNombre.Text.Trim <> "" Then
                _NombreNuevo = TxtNuevoNombre.Text.Trim
            Else
                _NombreNuevo = _NombreActual
            End If

            _Selecciono = True
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
        If MsgBox("Si no se asigna un nuevo nombre se conservará el nombre actual del dispositivo, desea continuar?", MsgBoxStyle.Information + MsgBoxStyle.OkCancel, Me.Text) = MsgBoxResult.Ok Then
            Me.Close()
        End If
    End Sub

End Class