Imports Business
Public Class FrmMantEmailRecepcionDetalle
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private RecepcionFacturaEmail As New TRecepcionFacturaEmail(EmpresaInfo.Emp_Id)
    Private _Titulo As String
    Private _GuardoCambios As Boolean
    Private _Nuevo As Boolean
    Private _Cargando As Boolean
#End Region
#Region "Propiedades"
    Public WriteOnly Property Titulo As String
        Set(value As String)
            _Titulo = value
        End Set
    End Property
    Public WriteOnly Property Nuevo As Boolean
        Set(value As Boolean)
            _Nuevo = value
        End Set
    End Property
    Public ReadOnly Property GuardoCambios As Boolean
        Get
            Return _GuardoCambios
        End Get
    End Property
#End Region
#Region "Funciones Privadas"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(1)

            Numerico(0) = New TNumericFormat(TxtNumero, 4, 0, False, "", "###")
            Numerico(1) = New TNumericFormat(TxtPuerto, 5, 0, False, "", "###")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region
    Private Sub CargaCombos()
        Dim ServerCorreo As New TServerCorreo()
        Try

            VerificaMensaje(ServerCorreo.LoadComboBox(CmbServerCorreo))

            CmbServerCorreo.SelectedIndex = -1

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ServerCorreo = Nothing
        End Try
    End Sub

    Private Sub CargaDatos()
        Dim Mensaje As String = ""
        Try
            RecepcionFacturaEmail.Email_Id = CInt(TxtNumero.Text)
            Mensaje = RecepcionFacturaEmail.ListKey()
            VerificaMensaje(Mensaje)

            With RecepcionFacturaEmail
                TxtNombre.Text = .Nombre
                TxtEmail.Text = .Email
                CmbServerCorreo.SelectedValue = .Server_Id
                TxtServer.Text = .Server
                TxtPuerto.Text = .Port
                TxtPassword.Text = UnLockPassword(.Password)
                ChkActivo.Checked = .Activo
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub



    Public Sub Execute(pCodigo As Integer)
        Dim Menu As New TMenu(Modulo_Id)
        Try
            Me.Text = _Titulo
            _GuardoCambios = False
            _Cargando = True
            CargaCombos()

            If Not _Nuevo Then
                TxtNumero.Text = pCodigo
                CargaDatos()
            End If

            TxtNumero.Focus()

            _Cargando = False
            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Menu = Nothing
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMantCategoriaDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Function ValidaTodo() As Boolean
        Try

            If TxtNombre.Text.Trim = "" Then
                TxtNombre.Focus()
                VerificaMensaje("Debe de ingresar un valor")
            End If

            If TxtEmail.Text.Trim = "" Then
                TxtEmail.Focus()
                VerificaMensaje("Debe de ingresar un valor")
            End If

            If ValidaEmail(TxtEmail.Text) <> String.Empty Then
                TxtEmail.Focus()
                VerificaMensaje("Debe de ingresar una dirección de correo válida")
            End If

            If CmbServerCorreo.Items.Count = 0 OrElse CmbServerCorreo.SelectedIndex < 0 Then
                CmbServerCorreo.Focus()
                VerificaMensaje("Debe de seleccionar un tipo de servidor")
            End If

            If TxtPassword.Text.Trim = "" Then
                TxtPassword.Focus()
                VerificaMensaje("Debe de ingresar un valor")
            End If

            If CmbServerCorreo.SelectedValue = coServerCorreoIMAP Then
                If TxtServer.Text.Trim = "" Then
                    TxtServer.Focus()
                    VerificaMensaje("Debe de ingresar un valor")
                End If
                If TxtPuerto.Text.Trim = "" Then
                    TxtPuerto.Focus()
                    VerificaMensaje("Debe de ingresar un valor")
                End If
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        If ValidaTodo() Then
            Guardar()
        End If
    End Sub

    Private Sub Guardar()
        Dim Mensaje As String = ""
        Dim ServerCorreo As New TServerCorreo
        Try

            If _Nuevo Then
                Mensaje = RecepcionFacturaEmail.Siguiente()
                VerificaMensaje(Mensaje)
            Else
                RecepcionFacturaEmail.Email_Id = CInt(TxtNumero.Text)
            End If


            ServerCorreo.Server_Id = (CmbServerCorreo.SelectedValue)
            VerificaMensaje(ServerCorreo.ListKey)
            If ServerCorreo.RowsAffected = 0 Then
                VerificaMensaje("No se encontró")
            End If

            With RecepcionFacturaEmail
                .Email = TxtEmail.Text.Trim
                .Nombre = TxtNombre.Text
                .Server_Id = CInt(CmbServerCorreo.SelectedValue)
                If CmbServerCorreo.SelectedValue = coServerCorreoIMAP Then
                    .Server = TxtServer.Text.Trim
                    .Port = CInt(TxtPuerto.Text)
                Else
                    .Server = ServerCorreo.Server
                    .Port = ServerCorreo.Port
                End If
                .Password = LockPassword(TxtPassword.Text)
                .SSL = True
                .ServerAuthType = 0
                .ServerProtocol = 1
                .Activo = ChkActivo.Checked
            End With



            If _Nuevo Then
                Mensaje = RecepcionFacturaEmail.Insert()
            Else
                Mensaje = RecepcionFacturaEmail.Modify()
            End If
            VerificaMensaje(Mensaje)

            _GuardoCambios = True

            MsgBox("Los cambios se almacenaron correctamente", MsgBoxStyle.Information, Me.Text)

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ServerCorreo = Nothing
        End Try
    End Sub
    Private Sub FrmMantProveedorDetalle_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FormateaCamposNumericos()
        TxtNombre.Select()
    End Sub
    Private Sub TrwMenu_AfterCheck(sender As Object, e As System.Windows.Forms.TreeViewEventArgs)
        If Not _Cargando Then
            CheckChildNones(e.Node)
        End If
    End Sub

    Private Sub CmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbServerCorreo.SelectedIndexChanged
        Try
            If CmbServerCorreo.SelectedValue Is Nothing OrElse CmbServerCorreo.SelectedValue.ToString() = "System.Data.DataRowView" Then
                Exit Sub
            End If

            LblServer.Visible = CmbServerCorreo.SelectedValue = coServerCorreoIMAP
            TxtServer.Visible = CmbServerCorreo.SelectedValue = coServerCorreoIMAP
            LblPuerto.Visible = CmbServerCorreo.SelectedValue = coServerCorreoIMAP
            TxtPuerto.Visible = CmbServerCorreo.SelectedValue = coServerCorreoIMAP

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class