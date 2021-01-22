Imports Business
Imports System.IO
Public Class FrmConexion
    Private _Conecto As Boolean = False

    Public ReadOnly Property Conecto As Boolean
        Get
            Return _Conecto
        End Get
    End Property
    Public Sub Execute()
        Try
            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message, "Conexión")
        End Try
    End Sub
    Private Function Errores() As Boolean
        Try
            If TxtUsuario.Text.Trim = "" Then
                EnfocarTexto(TxtUsuario)
                VerificaMensaje("Debe de seleccionar un Usuario")
            End If

            If TxtPassword.Text.Trim = "" Then
                EnfocarTexto(TxtPassword)
                VerificaMensaje("Debe de seleccionar un Password")
            End If

            Return False
        Catch ex As Exception
            MensajeError(ex.Message, "Conexión")
            Return True
        End Try
    End Function

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        Dim Usuario As New TUsuario(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            _Conecto = False

            If Errores() Then
                Exit Sub
            End If

            Usuario.Usuario_Id = TxtUsuario.Text.Trim
            Mensaje = Usuario.ListKey
            VerificaMensaje(Mensaje)

            If Usuario.RowsAffected = 0 Then
                EnfocarTexto(TxtUsuario)
                VerificaMensaje("Usuario no válido")
            End If

            If TxtPassword.Text.Trim <> UnLockPassword(Usuario.Password) Then
                EnfocarTexto(TxtPassword)
                VerificaMensaje("El password es incorrecto")
            End If

            If Not Usuario.Activo Then
                EnfocarTexto(TxtUsuario)
                VerificaMensaje("El usuario se encuentra inactivo, Imposible ingresar")
            End If


            'Carga el usuario
            UsuarioInfo.Emp_Id = Usuario.Emp_Id
            UsuarioInfo.Usuario_Id = Usuario.Usuario_Id
            Mensaje = UsuarioInfo.ListKey
            VerificaMensaje(Mensaje)
            If UsuarioInfo.RowsAffected = 0 Then
                EnfocarTexto(TxtUsuario)
                VerificaMensaje("Usuario no válido")
            End If


            _Conecto = True
            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message, "Conexión")
        Finally
            Usuario = Nothing
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Try
            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message, "Conexión")
        End Try
    End Sub

    Private Sub FrmConexion_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtUsuario.Select()
    End Sub
End Class