Imports Business
Public Class FrmConexion
    Private _Conecto As Boolean = False

    Public ReadOnly Property Conecto As Boolean
        Get
            Return _Conecto
        End Get
    End Property

    Private Sub CargaCombos()
        Dim Empresa As New TEmpresa(0)
        Dim Sucursal As New TSucursal(0)
        Dim Mensaje As String = ""
        Try

            Mensaje = Empresa.LoadComboBox(CmbEmpresa)
            VerificaMensaje(Mensaje)

            If Empresa.RowsAffected = 0 Then
                Exit Sub
            End If

            Sucursal.Emp_Id = Empresa.Emp_Id
            Mensaje = Sucursal.LoadComboBox(CmbSucursal)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message, "Conexión")
        Finally
            Empresa = Nothing
            Sucursal = Nothing
        End Try
    End Sub
    Private Sub CargaSucursales()
        Dim Sucursal As New TSucursal(0)
        Dim Mensaje As String = ""
        Try

            CmbSucursal.DataSource = Nothing

            If CmbEmpresa.SelectedValue Is Nothing Or Not IsNumeric(CmbEmpresa.SelectedValue) Then
                Exit Sub
            End If

            Sucursal.Emp_Id = CmbEmpresa.SelectedValue
            Mensaje = Sucursal.LoadComboBox(CmbSucursal)
            VerificaMensaje(Mensaje)


        Catch ex As Exception
            MensajeError(ex.Message, "Conexión")
        Finally
            Sucursal = Nothing
        End Try

    End Sub
    Public Sub Execute()
        Try
            CargaCombos()
            CmbEmpresa.SelectedValue = InfoMaquina.Emp_Id
            CmbSucursal.SelectedValue = InfoMaquina.Suc_Id
            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message, "Conexión")
        End Try
    End Sub

    Private Sub CmbEmpresa_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbEmpresa.SelectedIndexChanged
        CargaSucursales()
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

            If CmbEmpresa.SelectedValue Is Nothing OrElse CmbEmpresa.SelectedIndex = -1 Then
                CmbEmpresa.Focus()
                VerificaMensaje("Debe de seleccionar una Empresa")
            End If

            If CmbSucursal.SelectedValue Is Nothing OrElse CmbSucursal.SelectedIndex = -1 Then
                CmbSucursal.Focus()
                VerificaMensaje("Debe de seleccionar una Sucursal")
            End If


            Return False
        Catch ex As Exception
            MensajeError(ex.Message, "Conexión")
            Return True
        End Try
    End Function


    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        Dim Usuario As New TUsuario(0)
        Dim Mensaje As String = ""
        Try
            _Conecto = False

            If Errores() Then
                Exit Sub
            End If

            Usuario.Emp_Id = CmbEmpresa.SelectedValue
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

            'Carga la empresa
            EmpresaInfo.Emp_Id = CmbEmpresa.SelectedValue
            Mensaje = EmpresaInfo.ListKey
            VerificaMensaje(Mensaje)
            If EmpresaInfo.RowsAffected = 0 Then
                CmbEmpresa.Focus()
                VerificaMensaje("Empresa no válida")
            End If

            'Carga parametros para la empresa
            EmpresaParametroInfo.Emp_Id = CmbEmpresa.SelectedValue
            Mensaje = EmpresaParametroInfo.ListKey
            VerificaMensaje(Mensaje)
            If EmpresaParametroInfo.RowsAffected = 0 Then
                CmbEmpresa.Focus()
                VerificaMensaje("No se encontraron parámetros definidos para la empresa")
            End If

            'Carga la sucursal
            SucursalInfo.Emp_Id = CmbEmpresa.SelectedValue
            SucursalInfo.Suc_Id = CmbSucursal.SelectedValue
            Mensaje = SucursalInfo.ListKey
            VerificaMensaje(Mensaje)
            If SucursalInfo.RowsAffected = 0 Then
                CmbSucursal.Focus()
                VerificaMensaje("Sucursal no válida")
            End If

            'Carga los parametros de la sucursal
            SucursalParametroInfo.Emp_Id = CmbEmpresa.SelectedValue
            SucursalParametroInfo.Suc_Id = CmbSucursal.SelectedValue
            Mensaje = SucursalParametroInfo.ListKey
            VerificaMensaje(Mensaje)
            If SucursalParametroInfo.RowsAffected = 0 Then
                CmbEmpresa.Focus()
                VerificaMensaje("No se encontraron parámetros definidos para la sucursal")
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
            MensajeError(ex.Message)
        Finally
            Usuario = Nothing
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