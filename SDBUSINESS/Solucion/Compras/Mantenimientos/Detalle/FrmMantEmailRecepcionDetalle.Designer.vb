<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMantEmailRecepcionDetalle
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantEmailRecepcionDetalle))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ChkActivo = New System.Windows.Forms.CheckBox()
        Me.ImgLstMenu = New System.Windows.Forms.ImageList(Me.components)
        Me.CmbServerCorreo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtServer = New System.Windows.Forms.TextBox()
        Me.LblServer = New System.Windows.Forms.Label()
        Me.TxtPuerto = New System.Windows.Forms.TextBox()
        Me.LblPuerto = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnGuardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(113, 349)
        Me.Panel1.TabIndex = 1
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.ForeColor = System.Drawing.Color.White
        Me.BtnSalir.Location = New System.Drawing.Point(5, 100)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(100, 77)
        Me.BtnSalir.TabIndex = 9
        Me.BtnSalir.TabStop = False
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardar.ForeColor = System.Drawing.Color.White
        Me.BtnGuardar.Location = New System.Drawing.Point(5, 15)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(100, 77)
        Me.BtnGuardar.TabIndex = 8
        Me.BtnGuardar.TabStop = False
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(156, 59)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Código"
        '
        'TxtNumero
        '
        Me.TxtNumero.Enabled = False
        Me.TxtNumero.Location = New System.Drawing.Point(233, 55)
        Me.TxtNumero.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(132, 22)
        Me.TxtNumero.TabIndex = 0
        Me.TxtNumero.TabStop = False
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(233, 96)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNombre.MaxLength = 100
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(468, 22)
        Me.TxtNombre.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(156, 101)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nombre"
        '
        'ChkActivo
        '
        Me.ChkActivo.AutoSize = True
        Me.ChkActivo.Checked = True
        Me.ChkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkActivo.Location = New System.Drawing.Point(159, 282)
        Me.ChkActivo.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkActivo.Name = "ChkActivo"
        Me.ChkActivo.Size = New System.Drawing.Size(68, 21)
        Me.ChkActivo.TabIndex = 7
        Me.ChkActivo.Text = "Activo"
        Me.ChkActivo.UseVisualStyleBackColor = True
        '
        'ImgLstMenu
        '
        Me.ImgLstMenu.ImageStream = CType(resources.GetObject("ImgLstMenu.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgLstMenu.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgLstMenu.Images.SetKeyName(0, "branch_element.ico")
        Me.ImgLstMenu.Images.SetKeyName(1, "element.ico")
        Me.ImgLstMenu.Images.SetKeyName(2, "element_into.ico")
        '
        'CmbServerCorreo
        '
        Me.CmbServerCorreo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbServerCorreo.FormattingEnabled = True
        Me.CmbServerCorreo.Location = New System.Drawing.Point(233, 184)
        Me.CmbServerCorreo.Name = "CmbServerCorreo"
        Me.CmbServerCorreo.Size = New System.Drawing.Size(182, 24)
        Me.CmbServerCorreo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(156, 187)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Tipo"
        '
        'TxtEmail
        '
        Me.TxtEmail.Location = New System.Drawing.Point(233, 140)
        Me.TxtEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtEmail.MaxLength = 100
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(468, 22)
        Me.TxtEmail.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(156, 143)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Email"
        '
        'TxtPassword
        '
        Me.TxtPassword.Location = New System.Drawing.Point(233, 231)
        Me.TxtPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPassword.MaxLength = 100
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword.Size = New System.Drawing.Size(182, 22)
        Me.TxtPassword.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(156, 234)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Password"
        '
        'TxtServer
        '
        Me.TxtServer.Location = New System.Drawing.Point(511, 187)
        Me.TxtServer.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtServer.MaxLength = 100
        Me.TxtServer.Name = "TxtServer"
        Me.TxtServer.Size = New System.Drawing.Size(190, 22)
        Me.TxtServer.TabIndex = 4
        Me.TxtServer.Visible = False
        '
        'LblServer
        '
        Me.LblServer.AutoSize = True
        Me.LblServer.Location = New System.Drawing.Point(434, 190)
        Me.LblServer.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblServer.Name = "LblServer"
        Me.LblServer.Size = New System.Drawing.Size(61, 17)
        Me.LblServer.TabIndex = 12
        Me.LblServer.Text = "Servidor"
        Me.LblServer.Visible = False
        '
        'TxtPuerto
        '
        Me.TxtPuerto.Location = New System.Drawing.Point(511, 230)
        Me.TxtPuerto.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPuerto.MaxLength = 50
        Me.TxtPuerto.Name = "TxtPuerto"
        Me.TxtPuerto.Size = New System.Drawing.Size(190, 22)
        Me.TxtPuerto.TabIndex = 6
        Me.TxtPuerto.Visible = False
        '
        'LblPuerto
        '
        Me.LblPuerto.AutoSize = True
        Me.LblPuerto.Location = New System.Drawing.Point(434, 233)
        Me.LblPuerto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPuerto.Name = "LblPuerto"
        Me.LblPuerto.Size = New System.Drawing.Size(50, 17)
        Me.LblPuerto.TabIndex = 14
        Me.LblPuerto.Text = "Puerto"
        Me.LblPuerto.Visible = False
        '
        'FrmMantEmailRecepcionDetalle
        '
        Me.AcceptButton = Me.BtnGuardar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtnSalir
        Me.ClientSize = New System.Drawing.Size(752, 349)
        Me.Controls.Add(Me.TxtPuerto)
        Me.Controls.Add(Me.LblPuerto)
        Me.Controls.Add(Me.TxtServer)
        Me.Controls.Add(Me.LblServer)
        Me.Controls.Add(Me.TxtPassword)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtEmail)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CmbServerCorreo)
        Me.Controls.Add(Me.ChkActivo)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtNumero)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantEmailRecepcionDetalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Email Recepción"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ChkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents ImgLstMenu As System.Windows.Forms.ImageList
    Friend WithEvents CmbServerCorreo As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtEmail As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtServer As TextBox
    Friend WithEvents LblServer As Label
    Friend WithEvents TxtPuerto As TextBox
    Friend WithEvents LblPuerto As Label
End Class
