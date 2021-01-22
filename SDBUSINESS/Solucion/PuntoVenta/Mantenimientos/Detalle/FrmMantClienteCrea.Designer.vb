<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMantClienteCrea
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantClienteCrea))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtTelefono1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CmbTipoIdentificacion = New System.Windows.Forms.ComboBox()
        Me.TxtCedula = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.LblCedulaInfo = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TxtNombreComercial = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(89, 337)
        Me.Panel1.TabIndex = 1
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(7, 102)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(76, 90)
        Me.BtnSalir.TabIndex = 31
        Me.BtnSalir.TabStop = False
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.BackColor = System.Drawing.Color.White
        Me.BtnGuardar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F7
        Me.BtnGuardar.Location = New System.Drawing.Point(7, 5)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(76, 90)
        Me.BtnGuardar.TabIndex = 30
        Me.BtnGuardar.TabStop = False
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnGuardar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(133, 27)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Código"
        '
        'TxtNumero
        '
        Me.TxtNumero.Enabled = False
        Me.TxtNumero.Location = New System.Drawing.Point(277, 23)
        Me.TxtNumero.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(132, 22)
        Me.TxtNumero.TabIndex = 0
        Me.TxtNumero.TabStop = False
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(277, 54)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNombre.MaxLength = 80
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(424, 22)
        Me.TxtNombre.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(133, 58)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nombre"
        '
        'TxtTelefono1
        '
        Me.TxtTelefono1.Location = New System.Drawing.Point(277, 121)
        Me.TxtTelefono1.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTelefono1.MaxLength = 20
        Me.TxtTelefono1.Name = "TxtTelefono1"
        Me.TxtTelefono1.Size = New System.Drawing.Size(132, 22)
        Me.TxtTelefono1.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(133, 124)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Teléfono 1"
        '
        'TxtEmail
        '
        Me.TxtEmail.Location = New System.Drawing.Point(277, 250)
        Me.TxtEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtEmail.MaxLength = 50
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(132, 22)
        Me.TxtEmail.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(133, 188)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(122, 17)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "Tipo Identificación"
        '
        'CmbTipoIdentificacion
        '
        Me.CmbTipoIdentificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoIdentificacion.FormattingEnabled = True
        Me.CmbTipoIdentificacion.Location = New System.Drawing.Point(277, 185)
        Me.CmbTipoIdentificacion.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbTipoIdentificacion.Name = "CmbTipoIdentificacion"
        Me.CmbTipoIdentificacion.Size = New System.Drawing.Size(132, 24)
        Me.CmbTipoIdentificacion.TabIndex = 7
        '
        'TxtCedula
        '
        Me.TxtCedula.Location = New System.Drawing.Point(277, 218)
        Me.TxtCedula.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCedula.MaxLength = 20
        Me.TxtCedula.Name = "TxtCedula"
        Me.TxtCedula.Size = New System.Drawing.Size(132, 22)
        Me.TxtCedula.TabIndex = 8
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(133, 222)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 17)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "Cédula"
        '
        'LblCedulaInfo
        '
        Me.LblCedulaInfo.Location = New System.Drawing.Point(419, 185)
        Me.LblCedulaInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCedulaInfo.Name = "LblCedulaInfo"
        Me.LblCedulaInfo.Size = New System.Drawing.Size(284, 58)
        Me.LblCedulaInfo.TabIndex = 47
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PuntoVenta.My.Resources.Resources.user1
        Me.PictureBox1.Location = New System.Drawing.Point(779, 46)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(71, 62)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 41
        Me.PictureBox1.TabStop = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(133, 90)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(124, 17)
        Me.Label23.TabIndex = 56
        Me.Label23.Text = "Nombre Comercial"
        '
        'TxtNombreComercial
        '
        Me.TxtNombreComercial.Location = New System.Drawing.Point(277, 86)
        Me.TxtNombreComercial.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNombreComercial.MaxLength = 80
        Me.TxtNombreComercial.Name = "TxtNombreComercial"
        Me.TxtNombreComercial.Size = New System.Drawing.Size(424, 22)
        Me.TxtNombreComercial.TabIndex = 2
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(133, 253)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(51, 17)
        Me.Label25.TabIndex = 59
        Me.Label25.Text = "Correo"
        '
        'FrmMantClienteCrea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtnSalir
        Me.ClientSize = New System.Drawing.Size(972, 337)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.TxtNombreComercial)
        Me.Controls.Add(Me.LblCedulaInfo)
        Me.Controls.Add(Me.TxtCedula)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.CmbTipoIdentificacion)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtNumero)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtTelefono1)
        Me.Controls.Add(Me.TxtEmail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantClienteCrea"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMantCategoriaDetalle"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents TxtTelefono1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As Label
    Friend WithEvents CmbTipoIdentificacion As ComboBox
    Friend WithEvents TxtCedula As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents LblCedulaInfo As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents TxtNombreComercial As TextBox
    Friend WithEvents Label25 As Label
End Class
