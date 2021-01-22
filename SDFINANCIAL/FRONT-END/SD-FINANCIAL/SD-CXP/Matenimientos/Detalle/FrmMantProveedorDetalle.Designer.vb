<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantProveedorDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantProveedorDetalle))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.TcClientes = New System.Windows.Forms.TabControl()
        Me.TpInfoBasica = New System.Windows.Forms.TabPage()
        Me.ChkActivo = New System.Windows.Forms.CheckBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.TxtDireccion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtIdentificacion = New System.Windows.Forms.MaskedTextBox()
        Me.TxtTelefono1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmbTipoIdentificacion = New System.Windows.Forms.ComboBox()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.TxtTelefono2 = New System.Windows.Forms.TextBox()
        Me.TxtCxPColones = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtCxPDolares = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.TcClientes.SuspendLayout()
        Me.TpInfoBasica.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnGuardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(70, 381)
        Me.Panel1.TabIndex = 2
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.SDCXP.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(6, 84)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(57, 73)
        Me.BtnSalir.TabIndex = 22
        Me.BtnSalir.TabStop = False
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.BackColor = System.Drawing.Color.White
        Me.BtnGuardar.Image = Global.SDCXP.My.Resources.Resources.Blue_F2
        Me.BtnGuardar.Location = New System.Drawing.Point(6, 5)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(57, 73)
        Me.BtnGuardar.TabIndex = 21
        Me.BtnGuardar.TabStop = False
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnGuardar.UseVisualStyleBackColor = False
        '
        'TcClientes
        '
        Me.TcClientes.Controls.Add(Me.TpInfoBasica)
        Me.TcClientes.Location = New System.Drawing.Point(75, 4)
        Me.TcClientes.Name = "TcClientes"
        Me.TcClientes.SelectedIndex = 0
        Me.TcClientes.Size = New System.Drawing.Size(606, 371)
        Me.TcClientes.TabIndex = 42
        '
        'TpInfoBasica
        '
        Me.TpInfoBasica.Controls.Add(Me.TxtCxPDolares)
        Me.TpInfoBasica.Controls.Add(Me.Label6)
        Me.TpInfoBasica.Controls.Add(Me.TxtCxPColones)
        Me.TpInfoBasica.Controls.Add(Me.Label12)
        Me.TpInfoBasica.Controls.Add(Me.ChkActivo)
        Me.TpInfoBasica.Controls.Add(Me.PictureBox2)
        Me.TpInfoBasica.Controls.Add(Me.LblTitulo)
        Me.TpInfoBasica.Controls.Add(Me.TxtDireccion)
        Me.TpInfoBasica.Controls.Add(Me.Label3)
        Me.TpInfoBasica.Controls.Add(Me.Label1)
        Me.TpInfoBasica.Controls.Add(Me.TxtIdentificacion)
        Me.TpInfoBasica.Controls.Add(Me.TxtTelefono1)
        Me.TpInfoBasica.Controls.Add(Me.Label4)
        Me.TpInfoBasica.Controls.Add(Me.TxtEmail)
        Me.TpInfoBasica.Controls.Add(Me.Label15)
        Me.TpInfoBasica.Controls.Add(Me.Label5)
        Me.TpInfoBasica.Controls.Add(Me.TxtNombre)
        Me.TpInfoBasica.Controls.Add(Me.Label14)
        Me.TpInfoBasica.Controls.Add(Me.Label19)
        Me.TpInfoBasica.Controls.Add(Me.Label7)
        Me.TpInfoBasica.Controls.Add(Me.CmbTipoIdentificacion)
        Me.TpInfoBasica.Controls.Add(Me.TxtNumero)
        Me.TpInfoBasica.Controls.Add(Me.TxtTelefono2)
        Me.TpInfoBasica.Location = New System.Drawing.Point(4, 22)
        Me.TpInfoBasica.Name = "TpInfoBasica"
        Me.TpInfoBasica.Padding = New System.Windows.Forms.Padding(3)
        Me.TpInfoBasica.Size = New System.Drawing.Size(598, 345)
        Me.TpInfoBasica.TabIndex = 0
        Me.TpInfoBasica.Text = "Información Básica"
        Me.TpInfoBasica.UseVisualStyleBackColor = True
        '
        'ChkActivo
        '
        Me.ChkActivo.AutoSize = True
        Me.ChkActivo.Checked = True
        Me.ChkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkActivo.Location = New System.Drawing.Point(161, 296)
        Me.ChkActivo.Name = "ChkActivo"
        Me.ChkActivo.Size = New System.Drawing.Size(56, 17)
        Me.ChkActivo.TabIndex = 23
        Me.ChkActivo.Text = "Activo"
        Me.ChkActivo.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.SDCXP.My.Resources.Resources.user1
        Me.PictureBox2.Location = New System.Drawing.Point(60, 30)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(42, 34)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 64
        Me.PictureBox2.TabStop = False
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblTitulo.Location = New System.Drawing.Point(108, 34)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(119, 25)
        Me.LblTitulo.TabIndex = 63
        Me.LblTitulo.Text = "Proveedor"
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(161, 218)
        Me.TxtDireccion.MaxLength = 200
        Me.TxtDireccion.Multiline = True
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Size = New System.Drawing.Size(380, 46)
        Me.TxtDireccion.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(57, 219)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Dirección"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(57, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Código"
        '
        'TxtIdentificacion
        '
        Me.TxtIdentificacion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtIdentificacion.Location = New System.Drawing.Point(409, 140)
        Me.TxtIdentificacion.Name = "TxtIdentificacion"
        Me.TxtIdentificacion.Size = New System.Drawing.Size(132, 20)
        Me.TxtIdentificacion.TabIndex = 7
        '
        'TxtTelefono1
        '
        Me.TxtTelefono1.Location = New System.Drawing.Point(161, 166)
        Me.TxtTelefono1.MaxLength = 20
        Me.TxtTelefono1.Name = "TxtTelefono1"
        Me.TxtTelefono1.Size = New System.Drawing.Size(132, 20)
        Me.TxtTelefono1.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(57, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Teléfono 1"
        '
        'TxtEmail
        '
        Me.TxtEmail.Location = New System.Drawing.Point(161, 192)
        Me.TxtEmail.MaxLength = 50
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(132, 20)
        Me.TxtEmail.TabIndex = 12
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(57, 117)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 13)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Nombre"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(311, 169)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Teléfono 2"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(161, 114)
        Me.TxtNombre.MaxLength = 50
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(380, 20)
        Me.TxtNombre.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(312, 143)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 13)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Identificación"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(57, 143)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(94, 13)
        Me.Label19.TabIndex = 31
        Me.Label19.Text = "Tipo Identificación"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(57, 195)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Email"
        '
        'CmbTipoIdentificacion
        '
        Me.CmbTipoIdentificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoIdentificacion.FormattingEnabled = True
        Me.CmbTipoIdentificacion.Location = New System.Drawing.Point(161, 140)
        Me.CmbTipoIdentificacion.Name = "CmbTipoIdentificacion"
        Me.CmbTipoIdentificacion.Size = New System.Drawing.Size(132, 21)
        Me.CmbTipoIdentificacion.TabIndex = 6
        '
        'TxtNumero
        '
        Me.TxtNumero.Enabled = False
        Me.TxtNumero.Location = New System.Drawing.Point(161, 88)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(132, 20)
        Me.TxtNumero.TabIndex = 0
        Me.TxtNumero.TabStop = False
        '
        'TxtTelefono2
        '
        Me.TxtTelefono2.Location = New System.Drawing.Point(409, 166)
        Me.TxtTelefono2.MaxLength = 20
        Me.TxtTelefono2.Name = "TxtTelefono2"
        Me.TxtTelefono2.Size = New System.Drawing.Size(132, 20)
        Me.TxtTelefono2.TabIndex = 11
        '
        'TxtCxPColones
        '
        Me.TxtCxPColones.BackColor = System.Drawing.Color.White
        Me.TxtCxPColones.Location = New System.Drawing.Point(161, 270)
        Me.TxtCxPColones.MaxLength = 20
        Me.TxtCxPColones.Name = "TxtCxPColones"
        Me.TxtCxPColones.Size = New System.Drawing.Size(132, 20)
        Me.TxtCxPColones.TabIndex = 65
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(57, 273)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 13)
        Me.Label12.TabIndex = 66
        Me.Label12.Text = "CxP Colones"
        '
        'TxtCxPDolares
        '
        Me.TxtCxPDolares.BackColor = System.Drawing.Color.White
        Me.TxtCxPDolares.Location = New System.Drawing.Point(409, 270)
        Me.TxtCxPDolares.MaxLength = 20
        Me.TxtCxPDolares.Name = "TxtCxPDolares"
        Me.TxtCxPDolares.Size = New System.Drawing.Size(132, 20)
        Me.TxtCxPDolares.TabIndex = 67
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(312, 273)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 68
        Me.Label6.Text = "CxP Dólares"
        '
        'FrmMantProveedorDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(684, 381)
        Me.Controls.Add(Me.TcClientes)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantProveedorDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.TcClientes.ResumeLayout(False)
        Me.TpInfoBasica.ResumeLayout(False)
        Me.TpInfoBasica.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents TcClientes As System.Windows.Forms.TabControl
    Friend WithEvents TpInfoBasica As System.Windows.Forms.TabPage
    Friend WithEvents ChkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtIdentificacion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TxtTelefono1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmbTipoIdentificacion As System.Windows.Forms.ComboBox
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents TxtTelefono2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtCxPColones As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtCxPDolares As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
