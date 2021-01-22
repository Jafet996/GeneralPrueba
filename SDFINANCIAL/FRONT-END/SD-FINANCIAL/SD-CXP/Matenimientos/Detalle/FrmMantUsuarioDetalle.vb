Imports Business
Public Class FrmMantUsuarioDetalle
#Region "Declaracion Variables"
    Dim Numerico() As TNumericFormat
    Private coErrorUsuario = "--ERROR:Usuario--"
    Private _Activo As Boolean = False
    Private _Nuevo As Boolean = True
    Private Enum AccionEnum
        Inicial = 0
        Editando = 1
    End Enum
#End Region
#Region "Metodos Publicos"
    Public Sub Execute()
        CargaCombos()
        Inicializa()

        Me.Show()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub HabilitaBotones(pAccion As AccionEnum)
        Select Case pAccion
            Case AccionEnum.Inicial
                BtnGuardar.Enabled = False
                BtnLimpiar.Enabled = False
                BtnSalir.Enabled = True
            Case AccionEnum.Editando
                BtnGuardar.Enabled = True
                BtnLimpiar.Enabled = True
                BtnSalir.Enabled = True
        End Select
    End Sub

    Private Sub CargaCombos()
        Dim Grupo As New TGrupo()

        Try
            Grupo.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(Grupo.LoadComboBox(CmbGrupo))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Grupo = Nothing
        End Try
    End Sub

    Private Sub Inicializa()
        Try
            HabilitaBotones(AccionEnum.Inicial)
            PanelGeneral1.Enabled = False
            TxtCodigo.Enabled = True
            TxtCodigo.Focus()
            _Nuevo = True

            TxtCodigo.Text = ""
            TxtNombre.Text = ""
            TxtPassword.Text = ""
            TxtConfirmar.Text = ""

            If CmbGrupo.Items.Count > 0 Then
                CmbGrupo.SelectedIndex = -1
            End If

            ChkActivo.Checked = False
            LvwPermisos.Items.Clear()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaPermisos()
        Dim Permiso As New TPermiso(Modulo_Id)
        Dim Item As ListViewItem = Nothing

        Try
            LvwPermisos.Items.Clear()

            VerificaMensaje(Permiso.ListaxModulo())

            If Permiso.RowsAffected = 0 Then
                Exit Sub
            End If

            For Each Fila As DataRow In Permiso.Datos.Tables(0).Rows
                Item = New ListViewItem(Fila("Nombre").ToString)
                Item.Tag = Fila("Permiso_Id")

                LvwPermisos.Items.Add(Item)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Permiso = Nothing
        End Try
    End Sub

    Private Sub CargaPermisosUsuario()
        Dim UsuarioPermiso As New TUsuarioPermiso()

        Try
            With UsuarioPermiso
                .Emp_Id = EmpresaInfo.Emp_Id
                .Modulo_Id = Modulo_Id
                .Usuario_Id = TxtCodigo.Text.Trim
            End With
            
            VerificaMensaje(UsuarioPermiso.ListaxUsuario(LvwPermisos))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            UsuarioPermiso = Nothing
        End Try
    End Sub

    Private Sub CargaDatos()
        Dim Usuario As New TUsuario()

        Try
            _Nuevo = True

            Usuario.Emp_Id = EmpresaInfo.Emp_Id
            Usuario.Usuario_Id = TxtCodigo.Text.Trim
            VerificaMensaje(Usuario.ListKey())

            If Usuario.RowsAffected = 0 Then
                If MsgBox("El código no existe, Desea crearlo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                    TxtCodigo.SelectAll()
                    TxtCodigo.Focus()
                    Exit Sub
                End If
            End If

            HabilitaBotones(AccionEnum.Editando)
            PanelGeneral1.Enabled = True
            TxtCodigo.Enabled = False
            TxtNombre.Focus()

            CargaPermisos()

            If Usuario.RowsAffected > 0 Then
                _Nuevo = False
                With Usuario
                    TxtNombre.Text = .Nombre
                    TxtPassword.Text = UnLockPassword(.Password)
                    TxtConfirmar.Text = TxtPassword.Text
                    CmbGrupo.SelectedValue = .Grupo_Id
                    ChkActivo.Checked = .Activo
                End With
                CargaPermisosUsuario()
            Else
                ChkActivo.Checked = True
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Usuario = Nothing
        End Try
    End Sub

    Private Function ValidaDatos() As Boolean
        Try
            If TxtNombre.Text.Trim = "" Then
                TxtNombre.Focus()
                VerificaMensaje("Debe de ingresar un valor")
            End If

            If TxtPassword.Text.Trim = "" Then
                TxtPassword.Focus()
                VerificaMensaje("Debe de ingresar un valor")
            End If

            If TxtPassword.Text.Trim <> TxtConfirmar.Text.Trim Then
                TxtConfirmar.Focus()
                VerificaMensaje("Error al confirmar el password")
            End If

            If CmbGrupo.SelectedIndex < 0 OrElse CmbGrupo.SelectedValue Is Nothing Then
                TabPrincipal.SelectedTab = TabPrincipal.TabPages(0)
                CmbGrupo.Focus()
                VerificaMensaje("Debe de seleccionar un grupo")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Guardar()
        Dim Usuario As New TUsuario
        Dim UsuarioPermiso As TUsuarioPermiso = Nothing
        Dim Mensaje As String = ""

        Try
            With Usuario
                .Emp_Id = EmpresaInfo.Emp_Id
                .Usuario_Id = QuitaComillas(TxtCodigo.Text.Trim)
                .Nombre = UCase(QuitaComillas(TxtNombre.Text.Trim))
                .Password = LockPassword(TxtPassword.Text)
                .Grupo_Id = CmbGrupo.SelectedValue
                .Activo = ChkActivo.Checked
                .Modulo_Id = Modulo_Id
            End With

            For Each Item As ListViewItem In LvwPermisos.CheckedItems
                UsuarioPermiso = New TUsuarioPermiso()
                With UsuarioPermiso
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Usuario_Id = TxtCodigo.Text.Trim
                    .Permiso_Id = Item.Tag
                    .Modulo_Id = Modulo_Id
                End With
                Usuario.Permisos.Add(UsuarioPermiso)
            Next

            If _Nuevo Then
                Mensaje = Usuario.Insert()
            Else
                Mensaje = Usuario.Modify()
            End If
            VerificaMensaje(Mensaje)

            MsgBox("Los cambios se guardaron de manera exitosa", MsgBoxStyle.Information, Me.Text)

            Inicializa()
            TxtCodigo.Focus()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Usuario = Nothing
            UsuarioPermiso = Nothing
        End Try
    End Sub

    Private Sub BusquedaUsuario()
        Dim Forma As New FrmBusquedaUsuario

        Try
            Forma.Execute()

            If Forma.Selecciono Then
                TxtCodigo.Text = Forma.Usuario_Id
                CargaDatos()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
#End Region
#Region "Eventos Forma"

    Private Sub TxtCodigo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigo.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                BusquedaUsuario()
            Case Keys.Enter
                If TxtCodigo.Text.Trim <> "" Then
                    CargaDatos()
                End If
        End Select
    End Sub

    Private Sub FrmMantUsuario_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If Not _Activo Then
            _Activo = True
            TxtCodigo.Focus()
        End If
    End Sub

    Private Sub BtnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpiar.Click
        Inicializa()
        TabPrincipal.SelectedTab = TabPrincipal.TabPages(0)
    End Sub

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        Try
            If Not ValidaDatos() Then
                Exit Sub
            End If

            Guardar()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

#End Region
End Class