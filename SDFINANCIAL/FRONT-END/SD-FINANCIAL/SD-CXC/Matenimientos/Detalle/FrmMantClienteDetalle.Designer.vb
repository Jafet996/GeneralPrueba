<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantClienteDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantClienteDetalle))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.ChkActivo = New System.Windows.Forms.CheckBox()
        Me.TxtDireccion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtTelefono1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtTelefono2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmbTipoIdentificacion = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtCxCColones = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtIdentificacion = New System.Windows.Forms.MaskedTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.TcClientes = New System.Windows.Forms.TabControl()
        Me.TpInfoBasica = New System.Windows.Forms.TabPage()
        Me.TxtCxCDolares = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ChkAplicaMora = New System.Windows.Forms.CheckBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TxtPorcentajeMora = New System.Windows.Forms.TextBox()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.TxtDiasGraciaMora = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TxtDiasCredito = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.TxtLimiteCredito = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ChbInterno = New System.Windows.Forms.CheckBox()
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
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(93, 590)
        Me.Panel1.TabIndex = 1
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.SDCXC.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(8, 103)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(76, 90)
        Me.BtnSalir.TabIndex = 22
        Me.BtnSalir.TabStop = False
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.BackColor = System.Drawing.Color.White
        Me.BtnGuardar.Image = Global.SDCXC.My.Resources.Resources.Blue_F2
        Me.BtnGuardar.Location = New System.Drawing.Point(8, 6)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(76, 90)
        Me.BtnGuardar.TabIndex = 21
        Me.BtnGuardar.TabStop = False
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnGuardar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(76, 112)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Código"
        '
        'TxtNumero
        '
        Me.TxtNumero.Enabled = False
        Me.TxtNumero.Location = New System.Drawing.Point(215, 108)
        Me.TxtNumero.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(175, 22)
        Me.TxtNumero.TabIndex = 0
        Me.TxtNumero.TabStop = False
        '
        'ChkActivo
        '
        Me.ChkActivo.AutoSize = True
        Me.ChkActivo.Checked = True
        Me.ChkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkActivo.Location = New System.Drawing.Point(215, 460)
        Me.ChkActivo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ChkActivo.Name = "ChkActivo"
        Me.ChkActivo.Size = New System.Drawing.Size(68, 21)
        Me.ChkActivo.TabIndex = 23
        Me.ChkActivo.Text = "Activo"
        Me.ChkActivo.UseVisualStyleBackColor = True
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(215, 268)
        Me.TxtDireccion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtDireccion.MaxLength = 200
        Me.TxtDireccion.Multiline = True
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Size = New System.Drawing.Size(505, 56)
        Me.TxtDireccion.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(76, 270)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Dirección"
        '
        'TxtTelefono1
        '
        Me.TxtTelefono1.Location = New System.Drawing.Point(215, 204)
        Me.TxtTelefono1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtTelefono1.MaxLength = 20
        Me.TxtTelefono1.Name = "TxtTelefono1"
        Me.TxtTelefono1.Size = New System.Drawing.Size(175, 22)
        Me.TxtTelefono1.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(76, 209)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Teléfono 1"
        '
        'TxtTelefono2
        '
        Me.TxtTelefono2.Location = New System.Drawing.Point(545, 204)
        Me.TxtTelefono2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtTelefono2.MaxLength = 20
        Me.TxtTelefono2.Name = "TxtTelefono2"
        Me.TxtTelefono2.Size = New System.Drawing.Size(175, 22)
        Me.TxtTelefono2.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(415, 208)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 17)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Teléfono 2"
        '
        'TxtEmail
        '
        Me.TxtEmail.Location = New System.Drawing.Point(215, 236)
        Me.TxtEmail.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtEmail.MaxLength = 50
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(175, 22)
        Me.TxtEmail.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(76, 240)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 17)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Email"
        '
        'CmbTipoIdentificacion
        '
        Me.CmbTipoIdentificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoIdentificacion.FormattingEnabled = True
        Me.CmbTipoIdentificacion.Location = New System.Drawing.Point(215, 172)
        Me.CmbTipoIdentificacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmbTipoIdentificacion.Name = "CmbTipoIdentificacion"
        Me.CmbTipoIdentificacion.Size = New System.Drawing.Size(175, 24)
        Me.CmbTipoIdentificacion.TabIndex = 6
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(76, 176)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(122, 17)
        Me.Label19.TabIndex = 31
        Me.Label19.Text = "Tipo Identificación"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(416, 176)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(90, 17)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Identificación"
        '
        'TxtCxCColones
        '
        Me.TxtCxCColones.BackColor = System.Drawing.Color.White
        Me.TxtCxCColones.Location = New System.Drawing.Point(215, 332)
        Me.TxtCxCColones.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCxCColones.MaxLength = 20
        Me.TxtCxCColones.Name = "TxtCxCColones"
        Me.TxtCxCColones.Size = New System.Drawing.Size(175, 22)
        Me.TxtCxCColones.TabIndex = 20
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(76, 336)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 17)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "CxC Colones"
        '
        'TxtIdentificacion
        '
        Me.TxtIdentificacion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtIdentificacion.Location = New System.Drawing.Point(545, 172)
        Me.TxtIdentificacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtIdentificacion.Name = "TxtIdentificacion"
        Me.TxtIdentificacion.Size = New System.Drawing.Size(175, 22)
        Me.TxtIdentificacion.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(76, 144)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 17)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Nombre"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(215, 140)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtNombre.MaxLength = 50
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(505, 22)
        Me.TxtNombre.TabIndex = 2
        '
        'TcClientes
        '
        Me.TcClientes.Controls.Add(Me.TpInfoBasica)
        Me.TcClientes.Location = New System.Drawing.Point(100, 5)
        Me.TcClientes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TcClientes.Name = "TcClientes"
        Me.TcClientes.SelectedIndex = 0
        Me.TcClientes.Size = New System.Drawing.Size(808, 583)
        Me.TcClientes.TabIndex = 41
        '
        'TpInfoBasica
        '
        Me.TpInfoBasica.Controls.Add(Me.ChbInterno)
        Me.TpInfoBasica.Controls.Add(Me.TxtCxCDolares)
        Me.TpInfoBasica.Controls.Add(Me.Label6)
        Me.TpInfoBasica.Controls.Add(Me.ChkActivo)
        Me.TpInfoBasica.Controls.Add(Me.ChkAplicaMora)
        Me.TpInfoBasica.Controls.Add(Me.PictureBox2)
        Me.TpInfoBasica.Controls.Add(Me.TxtPorcentajeMora)
        Me.TpInfoBasica.Controls.Add(Me.LblTitulo)
        Me.TpInfoBasica.Controls.Add(Me.Label35)
        Me.TpInfoBasica.Controls.Add(Me.TxtDireccion)
        Me.TpInfoBasica.Controls.Add(Me.TxtDiasGraciaMora)
        Me.TpInfoBasica.Controls.Add(Me.Label34)
        Me.TpInfoBasica.Controls.Add(Me.Label3)
        Me.TpInfoBasica.Controls.Add(Me.TxtDiasCredito)
        Me.TpInfoBasica.Controls.Add(Me.Label1)
        Me.TpInfoBasica.Controls.Add(Me.Label33)
        Me.TpInfoBasica.Controls.Add(Me.TxtIdentificacion)
        Me.TpInfoBasica.Controls.Add(Me.TxtLimiteCredito)
        Me.TpInfoBasica.Controls.Add(Me.TxtTelefono1)
        Me.TpInfoBasica.Controls.Add(Me.Label2)
        Me.TpInfoBasica.Controls.Add(Me.Label4)
        Me.TpInfoBasica.Controls.Add(Me.TxtCxCColones)
        Me.TpInfoBasica.Controls.Add(Me.Label12)
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
        Me.TpInfoBasica.Location = New System.Drawing.Point(4, 25)
        Me.TpInfoBasica.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TpInfoBasica.Name = "TpInfoBasica"
        Me.TpInfoBasica.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TpInfoBasica.Size = New System.Drawing.Size(800, 554)
        Me.TpInfoBasica.TabIndex = 0
        Me.TpInfoBasica.Text = "Información Básica"
        Me.TpInfoBasica.UseVisualStyleBackColor = True
        '
        'TxtCxCDolares
        '
        Me.TxtCxCDolares.BackColor = System.Drawing.Color.White
        Me.TxtCxCDolares.Location = New System.Drawing.Point(215, 364)
        Me.TxtCxCDolares.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCxCDolares.MaxLength = 20
        Me.TxtCxCDolares.Name = "TxtCxCDolares"
        Me.TxtCxCDolares.Size = New System.Drawing.Size(175, 22)
        Me.TxtCxCDolares.TabIndex = 65
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(76, 368)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 17)
        Me.Label6.TabIndex = 66
        Me.Label6.Text = "CxC Dólares"
        '
        'ChkAplicaMora
        '
        Me.ChkAplicaMora.AutoSize = True
        Me.ChkAplicaMora.Checked = True
        Me.ChkAplicaMora.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkAplicaMora.Location = New System.Drawing.Point(215, 432)
        Me.ChkAplicaMora.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ChkAplicaMora.Name = "ChkAplicaMora"
        Me.ChkAplicaMora.Size = New System.Drawing.Size(104, 21)
        Me.ChkAplicaMora.TabIndex = 46
        Me.ChkAplicaMora.Text = "Aplica Mora"
        Me.ChkAplicaMora.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.SDCXC.My.Resources.Resources.user1
        Me.PictureBox2.Location = New System.Drawing.Point(80, 37)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(56, 42)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 64
        Me.PictureBox2.TabStop = False
        '
        'TxtPorcentajeMora
        '
        Me.TxtPorcentajeMora.BackColor = System.Drawing.Color.White
        Me.TxtPorcentajeMora.Location = New System.Drawing.Point(545, 396)
        Me.TxtPorcentajeMora.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtPorcentajeMora.MaxLength = 20
        Me.TxtPorcentajeMora.Name = "TxtPorcentajeMora"
        Me.TxtPorcentajeMora.Size = New System.Drawing.Size(175, 22)
        Me.TxtPorcentajeMora.TabIndex = 44
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblTitulo.Location = New System.Drawing.Point(144, 42)
        Me.LblTitulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(109, 33)
        Me.LblTitulo.TabIndex = 63
        Me.LblTitulo.Text = "Cliente"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(416, 400)
        Me.Label35.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(108, 17)
        Me.Label35.TabIndex = 45
        Me.Label35.Text = "Aplica Mora (%)"
        '
        'TxtDiasGraciaMora
        '
        Me.TxtDiasGraciaMora.BackColor = System.Drawing.Color.White
        Me.TxtDiasGraciaMora.Location = New System.Drawing.Point(545, 364)
        Me.TxtDiasGraciaMora.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtDiasGraciaMora.MaxLength = 20
        Me.TxtDiasGraciaMora.Name = "TxtDiasGraciaMora"
        Me.TxtDiasGraciaMora.Size = New System.Drawing.Size(175, 22)
        Me.TxtDiasGraciaMora.TabIndex = 42
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(415, 368)
        Me.Label34.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(102, 17)
        Me.Label34.TabIndex = 43
        Me.Label34.Text = "Días de Gracia"
        '
        'TxtDiasCredito
        '
        Me.TxtDiasCredito.BackColor = System.Drawing.Color.White
        Me.TxtDiasCredito.Location = New System.Drawing.Point(545, 332)
        Me.TxtDiasCredito.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtDiasCredito.MaxLength = 20
        Me.TxtDiasCredito.Name = "TxtDiasCredito"
        Me.TxtDiasCredito.Size = New System.Drawing.Size(175, 22)
        Me.TxtDiasCredito.TabIndex = 40
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(415, 336)
        Me.Label33.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(105, 17)
        Me.Label33.TabIndex = 41
        Me.Label33.Text = "Días de Crédito"
        '
        'TxtLimiteCredito
        '
        Me.TxtLimiteCredito.BackColor = System.Drawing.Color.White
        Me.TxtLimiteCredito.Location = New System.Drawing.Point(215, 396)
        Me.TxtLimiteCredito.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtLimiteCredito.MaxLength = 20
        Me.TxtLimiteCredito.Name = "TxtLimiteCredito"
        Me.TxtLimiteCredito.Size = New System.Drawing.Size(175, 22)
        Me.TxtLimiteCredito.TabIndex = 38
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(76, 400)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 17)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Limite de Crédito"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ChbInterno
        '
        Me.ChbInterno.AutoSize = True
        Me.ChbInterno.Location = New System.Drawing.Point(215, 489)
        Me.ChbInterno.Margin = New System.Windows.Forms.Padding(4)
        Me.ChbInterno.Name = "ChbInterno"
        Me.ChbInterno.Size = New System.Drawing.Size(121, 21)
        Me.ChbInterno.TabIndex = 67
        Me.ChbInterno.Text = "Cliente Interno"
        Me.ChbInterno.UseVisualStyleBackColor = True
        '
        'FrmMantClienteDetalle
        '
        Me.AcceptButton = Me.BtnGuardar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtnSalir
        Me.ClientSize = New System.Drawing.Size(912, 590)
        Me.Controls.Add(Me.TcClientes)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantClienteDetalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMantCategoriaDetalle"
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents ChkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtTelefono1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtTelefono2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtCxCColones As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CmbTipoIdentificacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents TxtIdentificacion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TcClientes As System.Windows.Forms.TabControl
    Friend WithEvents TpInfoBasica As System.Windows.Forms.TabPage
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtLimiteCredito As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDiasCredito As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents TxtDiasGraciaMora As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents TxtPorcentajeMora As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents ChkAplicaMora As System.Windows.Forms.CheckBox
    Friend WithEvents TxtCxCDolares As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ChbInterno As CheckBox
End Class
