Imports Business
Public Class FrmPermiso
#Region "Variables"
    Private _Emp_Id As Integer
    Private _Selecciono As Boolean
    Private _Usuario_Id As String
    Private _Permiso_Id As Integer
#End Region
#Region "Propiedades"
    Public WriteOnly Property Emp_Id As Integer
        Set(value As Integer)
            _Emp_Id = value
        End Set
    End Property
    Public WriteOnly Property Permiso_Id As Integer
        Set(value As Integer)
            _Permiso_Id = value
        End Set
    End Property

    Public ReadOnly Property Selecciono As Boolean
        Get
            Return _Selecciono
        End Get
    End Property
    Public ReadOnly Property Usuario_Id As String
        Get
            Return _Usuario_Id
        End Get
    End Property
#End Region
#Region "Metodos Publicos"
    Public Sub Execute()
        _Selecciono = False
        BuscaNombrePermiso()
        TcPermiso.SelectedIndex = 1
        TxtCodigoAcceso.Select()

        Me.ShowDialog()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub BuscaNombrePermiso()
        Dim Permiso As New TPermiso(0)

        Try
            Permiso.Permiso_Id = _Permiso_Id
            VerificaMensaje(Permiso.ListKey)

            If Permiso.RowsAffected > 0 Then
                Me.Text = Permiso.Nombre
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub BtnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancelar.Click
        _Selecciono = False
        _Usuario_Id = ""

        Me.Close()
    End Sub

    Private Sub AceptarUsuario()
        Dim Usuario As New TUsuario

        Try
            _Selecciono = False

            If TxtUsuario.Text.Trim = "" Then
                TxtUsuario.SelectAll()
                TxtUsuario.Focus()
                VerificaMensaje("Debe de digitar un usuario")
            End If

            If TxtPassword.Text.Trim = "" Then
                TxtUsuario.SelectAll()
                TxtUsuario.Focus()
                VerificaMensaje("Debe de digitar un password")
            End If

            With Usuario
                .Emp_Id = _Emp_Id
                .Usuario_Id = TxtUsuario.Text.Trim
            End With
            VerificaMensaje(Usuario.ListKey())

            If Usuario.RowsAffected = 0 Then
                TxtUsuario.SelectAll()
                TxtUsuario.Focus()
                VerificaMensaje("El usuario no existe")
            End If

            If UnLockPassword(Usuario.Password) <> TxtPassword.Text.Trim Then
                TxtPassword.SelectAll()
                TxtPassword.Focus()
                VerificaMensaje("Password incorrecto")
            End If

            _Usuario_Id = TxtUsuario.Text.Trim
            _Selecciono = True

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Usuario = Nothing
        End Try
    End Sub

    Private Function ValidaCodigo() As Boolean
        Try
            If TxtCodigoAcceso.Text.Trim = "" Then
                TxtCodigoAcceso.Focus()
                VerificaMensaje("Debe de digitar un código de acceso.")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub AceptarCodigo()
        Dim UsuarioCodigo As New TUsuarioCodigoPermiso
        Dim BitacoraCodigo As New TCodigoPermisoBitacora

        Try
            With UsuarioCodigo
                .Emp_Id = EmpresaInfo.Emp_Id
                .Codigo = TxtCodigoAcceso.Text.Trim
            End With
            VerificaMensaje(UsuarioCodigo.ListKeyXCodigo)

            If UsuarioCodigo.RowsAffected = 0 Then
                TxtCodigoAcceso.Text = ""
                VerificaMensaje("Código de acceso inválido")
            End If

            With BitacoraCodigo
                .Emp_Id = EmpresaInfo.Emp_Id
                .Usuario_Id = UsuarioCodigo.Usuario_Id
                .Codigo = TxtCodigoAcceso.Text.Trim.ToUpper
                .UsuarioUtilizo_Id = UsuarioInfo.Usuario_Id
                .Fecha = EmpresaInfo.Getdate
                .Permiso_Id = _Permiso_Id
            End With

            VerificaMensaje(BitacoraCodigo.Insert)
            VerificaMensaje(UsuarioCodigo.Delete)

            _Usuario_Id = UsuarioCodigo.Usuario_Id
            _Selecciono = True

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            UsuarioCodigo = Nothing
            BitacoraCodigo = Nothing
        End Try
    End Sub

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        Try
            If TcPermiso.SelectedIndex = 0 Then
                AceptarUsuario()
            Else
                If ValidaCodigo() Then
                    AceptarCodigo()
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmPermiso_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Windows.Forms.Keys.Escape
                _Selecciono = False
                Me.Close()
        End Select
    End Sub

    Private Sub TxtUsuario_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtUsuario.KeyDown
        Select Case e.KeyCode
            Case Windows.Forms.Keys.Enter
                If TxtUsuario.Text.Trim <> "" Then
                    TxtPassword.Focus()
                End If
        End Select
    End Sub

    Private Sub TxtPassword_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtPassword.KeyDown
        Select Case e.KeyCode
            Case Windows.Forms.Keys.Enter
                If TxtPassword.Text.Trim <> "" Then
                    BtnAceptar_Click(Me.BtnAceptar, EventArgs.Empty)
                End If
        End Select
    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub TcPermiso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TcPermiso.SelectedIndexChanged
        If TcPermiso.SelectedIndex = 0 Then
            TxtUsuario.Focus()
        Else
            TxtCodigoAcceso.Focus()
        End If
    End Sub

End Class