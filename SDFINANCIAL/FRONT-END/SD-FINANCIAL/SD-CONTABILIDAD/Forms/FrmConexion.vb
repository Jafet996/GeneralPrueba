Imports Business
Public Class FrmConexion
#Region "Variables"
    Private _Conecto As Boolean = False
#End Region
#Region "Propiedades"
    Public ReadOnly Property Conecto As Boolean
        Get
            Return _Conecto
        End Get
    End Property
#End Region

    Private Sub CargaCombos()
        Dim Empresa As New TEmpresa

        Try
            VerificaMensaje(Empresa.LoadComboBox(CmbEmpresa))

            If Empresa.RowsAffected = 0 Then
                Exit Sub
            End If

        Catch ex As Exception
            MensajeError(ex.Message, "Conexión")
        Finally
            Empresa = Nothing
        End Try
    End Sub

    Public Sub Execute()
        Try
            CargaCombos()

            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message, "Conexión")
        End Try
    End Sub

    Private Function Errores() As Boolean
        Try
            If TxtUsuario.Text.Trim = "" Then
                TxtUsuario.Focus()
                VerificaMensaje("Debe de seleccionar un Usuario")
            End If

            If TxtPassword.Text.Trim = "" Then
                TxtPassword.Focus()
                VerificaMensaje("Debe de seleccionar un Password")
            End If

            If CmbEmpresa.SelectedValue Is Nothing OrElse CmbEmpresa.SelectedIndex = -1 Then
                CmbEmpresa.Focus()
                VerificaMensaje("Debe de seleccionar una Empresa")
            End If

            Return False
        Catch ex As Exception
            MensajeError(ex.Message, "Conexión")
            Return True
        End Try
    End Function

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        Dim Usuario As New TUsuario
        Dim Grupo As New TGrupo

        Try
            _Conecto = False

            If Errores() Then
                Exit Sub
            End If

            With Usuario
                .Emp_Id = CmbEmpresa.SelectedValue
                .Usuario_Id = TxtUsuario.Text.Trim
            End With
            VerificaMensaje(Usuario.ListKey)

            If Usuario.RowsAffected = 0 Then
                TxtUsuario.Focus()
                VerificaMensaje("Usuario no válido")
            End If

            If TxtPassword.Text.Trim <> UnLockPassword(Usuario.Password) Then
                TxtPassword.SelectAll()
                VerificaMensaje("El password es incorrecto")
            End If

            If Not Usuario.Activo Then
                TxtUsuario.SelectAll()
                VerificaMensaje("El usuario se encuentra inactivo, Imposible ingresar")
            End If

            With Grupo
                .Emp_Id = CmbEmpresa.SelectedValue
                .Grupo_Id = Usuario.Grupo_Id
            End With
            VerificaMensaje(Grupo.ListKey)

            If Grupo.RowsAffected = 0 Then
                TxtUsuario.Focus()
                VerificaMensaje("El usuario tiene asignado un rol inválido")
            End If

            If Not Grupo.Activo Then
                TxtUsuario.Focus()
                VerificaMensaje("El usuario tiene asignado un rol inválido")
            End If

            'Carga la empresa
            EmpresaInfo.Emp_Id = CmbEmpresa.SelectedValue
            VerificaMensaje(EmpresaInfo.ListKey)

            If EmpresaInfo.RowsAffected = 0 Then
                CmbEmpresa.Focus()
                VerificaMensaje("Empresa no válida")
            End If

            'Carga parametros para la empresa
            EmpresaParametroInfo.Emp_Id = CmbEmpresa.SelectedValue
            VerificaMensaje(EmpresaParametroInfo.ListKey)

            If EmpresaParametroInfo.RowsAffected = 0 Then
                CmbEmpresa.Focus()
                VerificaMensaje("No se encontraron parámetros definidos para la empresa")
            End If

            'Carga el usuario
            UsuarioInfo.Emp_Id = Usuario.Emp_Id
            UsuarioInfo.Usuario_Id = Usuario.Usuario_Id
            VerificaMensaje(UsuarioInfo.ListKey)
            If UsuarioInfo.RowsAffected = 0 Then
                TxtUsuario.Focus()
                VerificaMensaje("Usuario no válido")
            End If

            _Conecto = True

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Usuario = Nothing
            Grupo = Nothing
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Try
            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

End Class