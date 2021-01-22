Imports Business
Imports System.IO
Public Class FrmMantEmpresaDetalle
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private Empresa As New TEmpresa
    Private _Titulo As String
    Private _GuardoCambios As Boolean
    Private _Nuevo As Boolean
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
            ReDim Numerico(14)

            Numerico(0) = New TNumericFormat(TxtNumero, 4, 0, False, "", "###")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub CargaDatos()
        Dim Mensaje As String = ""

        Try
            Empresa.Emp_Id = CInt(TxtNumero.Text)
            Mensaje = Empresa.ListKey()
            VerificaMensaje(Mensaje)

            With Empresa
                TxtNombre.Text = .Nombre
                TxtCedula.Text = .Cedula
                TxtTelefono.Text = .Telefono
                TxtFax.Text = .Fax
                TxtEmail.Text = .Email
                TxtDireccion.Text = .Direccion
                TxtDireccionWeb.Text = .DireccionWeb
                ChkActivo.Checked = .Activo
            End With

            If Not Empresa.Logo Is Nothing Then
                Using ms As New MemoryStream()
                    ms.Write(Empresa.Logo, 0, Empresa.Logo.Length)
                    PicLogo.Image = Image.FromStream(ms, True, True)
                End Using
            Else
                PicLogo.Image = Nothing
            End If

            With Empresa.Parametros
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub CargaCombos()
        Try

            CargaComboAnnio(CmbAnnio)
            CargaComboMes(CmbMes)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute(pCodigo As Integer)
        Me.Text = _Titulo
        _GuardoCambios = False

        CargaCombos()

        If Not _Nuevo Then
            TxtNumero.Text = pCodigo
            CargaDatos()
        End If

        TxtNumero.Focus()

        Me.ShowDialog()
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
                TabControl1.SelectedIndex = 0
                TxtNombre.Focus()
                VerificaMensaje("Debe de ingresar un valor")
            End If

            If TxtTelefono.Text.Trim = "" And TxtTelefono.Text.Trim = "" Then
                TabControl1.SelectedIndex = 0
                TxtTelefono.Focus()
                VerificaMensaje("Debe de ingresar al menos un teléfono")
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
        Dim data As Byte() = Nothing

        Try
            If Not PicLogo.Image Is Nothing Then
                data = ImageToByte(PicLogo)
            End If

            If _Nuevo Then
                VerificaMensaje(Empresa.NextOne())
            Else
                Empresa.Emp_Id = CInt(TxtNumero.Text)
            End If

            With Empresa
                .Nombre = TxtNombre.Text
                .Cedula = TxtCedula.Text
                .Telefono = TxtTelefono.Text
                .Fax = TxtFax.Text
                .Email = TxtEmail.Text
                .Direccion = TxtDireccion.Text
                .DireccionWeb = TxtDireccionWeb.Text
                .Activo = ChkActivo.Checked
                .Logo = data
            End With

            With Empresa.Parametros
                .Emp_Id = Empresa.Emp_Id
            End With

            If _Nuevo Then
                Mensaje = Empresa.Insert() & Empresa.Parametros.Insert
            Else
                Mensaje = Empresa.Modify() & Empresa.Parametros.Modify
            End If

            VerificaMensaje(Mensaje)

            _GuardoCambios = True

            MsgBox("Los cambios se almacenaron correctamente", MsgBoxStyle.Information, Me.Text)

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub FrmMantEmpresaDetalle_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FormateaCamposNumericos()
        TxtNombre.Select()
    End Sub


    Private Sub AgregarRuta(pTextBox As TextBox)
        Try
            If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
                pTextBox.Text = FolderBrowserDialog1.SelectedPath
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnLogo_Click(sender As System.Object, e As System.EventArgs) Handles BtnLogo.Click
        OpenFileDialog1.InitialDirectory = Application.StartupPath
        OpenFileDialog1.Filter = "PNG|*.png|Bitmap|*.bmp|JPEG|*.jpg" 'If you like file type filters you can add them here
        OpenFileDialog1.FileName = String.Empty
        'any other modifications to the dialog
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Try
            Dim bmp As New Bitmap(OpenFileDialog1.FileName)
            If Not IsNothing(PicLogo.Image) Then PicLogo.Image.Dispose() 'Optional if you want to destroy the previously loaded image
            PicLogo.Image = bmp
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnLogoEliminar_Click(sender As System.Object, e As System.EventArgs) Handles BtnLogoEliminar.Click
        PicLogo.Image = Nothing
    End Sub


End Class