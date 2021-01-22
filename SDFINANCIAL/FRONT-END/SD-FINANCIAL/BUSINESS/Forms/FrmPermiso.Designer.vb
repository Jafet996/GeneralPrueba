<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPermiso
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPermiso))
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtUsuario = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TcPermiso = New System.Windows.Forms.TabControl()
        Me.TpUsuario = New System.Windows.Forms.TabPage()
        Me.TpCodigo = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TxtCodigoAcceso = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TcPermiso.SuspendLayout()
        Me.TpUsuario.SuspendLayout()
        Me.TpCodigo.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtPassword
        '
        Me.TxtPassword.Location = New System.Drawing.Point(74, 45)
        Me.TxtPassword.MaxLength = 20
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword.Size = New System.Drawing.Size(155, 20)
        Me.TxtPassword.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Password"
        '
        'TxtUsuario
        '
        Me.TxtUsuario.Location = New System.Drawing.Point(74, 19)
        Me.TxtUsuario.MaxLength = 20
        Me.TxtUsuario.Name = "TxtUsuario"
        Me.TxtUsuario.Size = New System.Drawing.Size(155, 20)
        Me.TxtUsuario.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Usuario"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.BUSINESS.My.Resources.Resources.key1
        Me.PictureBox1.Location = New System.Drawing.Point(235, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 46)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.White
        Me.BtnAceptar.Location = New System.Drawing.Point(7, 12)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(75, 58)
        Me.BtnAceptar.TabIndex = 2
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.BackColor = System.Drawing.Color.White
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Location = New System.Drawing.Point(7, 76)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(75, 58)
        Me.BtnCancelar.TabIndex = 3
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnAceptar)
        Me.Panel1.Controls.Add(Me.BtnCancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(88, 149)
        Me.Panel1.TabIndex = 14
        '
        'TcPermiso
        '
        Me.TcPermiso.Controls.Add(Me.TpUsuario)
        Me.TcPermiso.Controls.Add(Me.TpCodigo)
        Me.TcPermiso.Location = New System.Drawing.Point(94, 12)
        Me.TcPermiso.Name = "TcPermiso"
        Me.TcPermiso.SelectedIndex = 0
        Me.TcPermiso.Size = New System.Drawing.Size(303, 125)
        Me.TcPermiso.TabIndex = 15
        '
        'TpUsuario
        '
        Me.TpUsuario.Controls.Add(Me.TxtPassword)
        Me.TpUsuario.Controls.Add(Me.Label3)
        Me.TpUsuario.Controls.Add(Me.PictureBox1)
        Me.TpUsuario.Controls.Add(Me.TxtUsuario)
        Me.TpUsuario.Controls.Add(Me.Label4)
        Me.TpUsuario.Location = New System.Drawing.Point(4, 22)
        Me.TpUsuario.Name = "TpUsuario"
        Me.TpUsuario.Padding = New System.Windows.Forms.Padding(3)
        Me.TpUsuario.Size = New System.Drawing.Size(295, 99)
        Me.TpUsuario.TabIndex = 0
        Me.TpUsuario.Text = "Usuario"
        Me.TpUsuario.UseVisualStyleBackColor = True
        '
        'TpCodigo
        '
        Me.TpCodigo.Controls.Add(Me.Label1)
        Me.TpCodigo.Controls.Add(Me.PictureBox2)
        Me.TpCodigo.Controls.Add(Me.TxtCodigoAcceso)
        Me.TpCodigo.Location = New System.Drawing.Point(4, 22)
        Me.TpCodigo.Name = "TpCodigo"
        Me.TpCodigo.Padding = New System.Windows.Forms.Padding(3)
        Me.TpCodigo.Size = New System.Drawing.Size(295, 99)
        Me.TpCodigo.TabIndex = 1
        Me.TpCodigo.Text = "Código de Acceso"
        Me.TpCodigo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Código"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.BUSINESS.My.Resources.Resources.key1
        Me.PictureBox2.Location = New System.Drawing.Point(235, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(48, 46)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 18
        Me.PictureBox2.TabStop = False
        '
        'TxtCodigoAcceso
        '
        Me.TxtCodigoAcceso.Location = New System.Drawing.Point(74, 33)
        Me.TxtCodigoAcceso.MaxLength = 20
        Me.TxtCodigoAcceso.Name = "TxtCodigoAcceso"
        Me.TxtCodigoAcceso.Size = New System.Drawing.Size(155, 20)
        Me.TxtCodigoAcceso.TabIndex = 14
        '
        'FrmPermiso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtnCancelar
        Me.ClientSize = New System.Drawing.Size(409, 149)
        Me.Controls.Add(Me.TcPermiso)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPermiso"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Permiso"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TcPermiso.ResumeLayout(False)
        Me.TpUsuario.ResumeLayout(False)
        Me.TpUsuario.PerformLayout()
        Me.TpCodigo.ResumeLayout(False)
        Me.TpCodigo.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TcPermiso As System.Windows.Forms.TabControl
    Friend WithEvents TpUsuario As System.Windows.Forms.TabPage
    Friend WithEvents TpCodigo As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtCodigoAcceso As System.Windows.Forms.TextBox
End Class
