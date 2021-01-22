<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMantClienteNew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantClienteNew))
        Me.PnlBotones = New System.Windows.Forms.Panel()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtDireccion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtTelefono1 = New System.Windows.Forms.TextBox()
        Me.LblTelefono = New System.Windows.Forms.Label()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CmbTipoIdentificacion = New System.Windows.Forms.ComboBox()
        Me.TxtCedula = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GroupDireccion = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.CmbBarrio = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.CmbDistrito = New System.Windows.Forms.ComboBox()
        Me.CmbProvincia = New System.Windows.Forms.ComboBox()
        Me.CmbCanton = New System.Windows.Forms.ComboBox()
        Me.LblCedulaInfo = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TxtNombreComercial = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.BtnOutlook = New System.Windows.Forms.Button()
        Me.BtnGmail = New System.Windows.Forms.Button()
        Me.BtnYahoo = New System.Windows.Forms.Button()
        Me.BtnHotmail = New System.Windows.Forms.Button()
        Me.BtnIcloud = New System.Windows.Forms.Button()
        Me.BtnArroba = New System.Windows.Forms.Button()
        Me.BtnVerificaCedula = New System.Windows.Forms.Button()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PnlBotones.SuspendLayout()
        Me.GroupDireccion.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnlBotones
        '
        Me.PnlBotones.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.PnlBotones.Controls.Add(Me.BtnLimpiar)
        Me.PnlBotones.Controls.Add(Me.BtnSalir)
        Me.PnlBotones.Controls.Add(Me.BtnGuardar)
        Me.PnlBotones.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlBotones.Location = New System.Drawing.Point(0, 0)
        Me.PnlBotones.Margin = New System.Windows.Forms.Padding(4)
        Me.PnlBotones.Name = "PnlBotones"
        Me.PnlBotones.Size = New System.Drawing.Size(112, 615)
        Me.PnlBotones.TabIndex = 1
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.BackColor = System.Drawing.Color.White
        Me.BtnLimpiar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F6
        Me.BtnLimpiar.Location = New System.Drawing.Point(12, 108)
        Me.BtnLimpiar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(87, 90)
        Me.BtnLimpiar.TabIndex = 14
        Me.BtnLimpiar.TabStop = False
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnLimpiar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(13, 206)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(87, 90)
        Me.BtnSalir.TabIndex = 13
        Me.BtnSalir.TabStop = False
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.BackColor = System.Drawing.Color.White
        Me.BtnGuardar.Enabled = False
        Me.BtnGuardar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F7
        Me.BtnGuardar.Location = New System.Drawing.Point(12, 10)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(87, 90)
        Me.BtnGuardar.TabIndex = 12
        Me.BtnGuardar.TabStop = False
        Me.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnGuardar.UseVisualStyleBackColor = False
        '
        'TxtNombre
        '
        Me.TxtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombre.Location = New System.Drawing.Point(333, 238)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNombre.MaxLength = 80
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(492, 30)
        Me.TxtNombre.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(136, 241)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 25)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nombre"
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDireccion.Location = New System.Drawing.Point(39, 258)
        Me.TxtDireccion.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtDireccion.MaxLength = 200
        Me.TxtDireccion.Multiline = True
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Size = New System.Drawing.Size(356, 202)
        Me.TxtDireccion.TabIndex = 11
        Me.TxtDireccion.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(39, 213)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 25)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Dirección"
        '
        'TxtTelefono1
        '
        Me.TxtTelefono1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTelefono1.Location = New System.Drawing.Point(333, 334)
        Me.TxtTelefono1.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTelefono1.MaxLength = 20
        Me.TxtTelefono1.Name = "TxtTelefono1"
        Me.TxtTelefono1.Size = New System.Drawing.Size(132, 30)
        Me.TxtTelefono1.TabIndex = 5
        '
        'LblTelefono
        '
        Me.LblTelefono.AutoSize = True
        Me.LblTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTelefono.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblTelefono.Location = New System.Drawing.Point(136, 337)
        Me.LblTelefono.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTelefono.Name = "LblTelefono"
        Me.LblTelefono.Size = New System.Drawing.Size(89, 25)
        Me.LblTelefono.TabIndex = 10
        Me.LblTelefono.Text = "Teléfono"
        '
        'TxtEmail
        '
        Me.TxtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEmail.Location = New System.Drawing.Point(333, 386)
        Me.TxtEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtEmail.MaxLength = 50
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(492, 30)
        Me.TxtEmail.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.Location = New System.Drawing.Point(136, 43)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(169, 25)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "Tipo Identificación"
        '
        'CmbTipoIdentificacion
        '
        Me.CmbTipoIdentificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoIdentificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbTipoIdentificacion.FormattingEnabled = True
        Me.CmbTipoIdentificacion.Location = New System.Drawing.Point(333, 38)
        Me.CmbTipoIdentificacion.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbTipoIdentificacion.Name = "CmbTipoIdentificacion"
        Me.CmbTipoIdentificacion.Size = New System.Drawing.Size(492, 33)
        Me.CmbTipoIdentificacion.TabIndex = 0
        '
        'TxtCedula
        '
        Me.TxtCedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCedula.Location = New System.Drawing.Point(333, 80)
        Me.TxtCedula.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCedula.MaxLength = 20
        Me.TxtCedula.Name = "TxtCedula"
        Me.TxtCedula.Size = New System.Drawing.Size(393, 30)
        Me.TxtCedula.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.Location = New System.Drawing.Point(136, 84)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(141, 25)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "# Identificación"
        '
        'GroupDireccion
        '
        Me.GroupDireccion.Controls.Add(Me.Label19)
        Me.GroupDireccion.Controls.Add(Me.CmbBarrio)
        Me.GroupDireccion.Controls.Add(Me.Label26)
        Me.GroupDireccion.Controls.Add(Me.Label28)
        Me.GroupDireccion.Controls.Add(Me.Label27)
        Me.GroupDireccion.Controls.Add(Me.CmbDistrito)
        Me.GroupDireccion.Controls.Add(Me.CmbProvincia)
        Me.GroupDireccion.Controls.Add(Me.CmbCanton)
        Me.GroupDireccion.Controls.Add(Me.TxtDireccion)
        Me.GroupDireccion.Controls.Add(Me.Label3)
        Me.GroupDireccion.Location = New System.Drawing.Point(864, 38)
        Me.GroupDireccion.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupDireccion.Name = "GroupDireccion"
        Me.GroupDireccion.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupDireccion.Size = New System.Drawing.Size(445, 539)
        Me.GroupDireccion.TabIndex = 15
        Me.GroupDireccion.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.Location = New System.Drawing.Point(39, 154)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(63, 25)
        Me.Label19.TabIndex = 59
        Me.Label19.Text = "Barrio"
        '
        'CmbBarrio
        '
        Me.CmbBarrio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBarrio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbBarrio.FormattingEnabled = True
        Me.CmbBarrio.Location = New System.Drawing.Point(143, 150)
        Me.CmbBarrio.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbBarrio.Name = "CmbBarrio"
        Me.CmbBarrio.Size = New System.Drawing.Size(257, 33)
        Me.CmbBarrio.TabIndex = 10
        Me.CmbBarrio.TabStop = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label26.Location = New System.Drawing.Point(39, 27)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(92, 25)
        Me.Label26.TabIndex = 52
        Me.Label26.Text = "Provincia"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label28.Location = New System.Drawing.Point(39, 70)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(76, 25)
        Me.Label28.TabIndex = 57
        Me.Label28.Text = "Cantón"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label27.Location = New System.Drawing.Point(39, 112)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(71, 25)
        Me.Label27.TabIndex = 56
        Me.Label27.Text = "Distrito"
        '
        'CmbDistrito
        '
        Me.CmbDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbDistrito.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbDistrito.FormattingEnabled = True
        Me.CmbDistrito.ItemHeight = 25
        Me.CmbDistrito.Location = New System.Drawing.Point(143, 108)
        Me.CmbDistrito.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbDistrito.Name = "CmbDistrito"
        Me.CmbDistrito.Size = New System.Drawing.Size(257, 33)
        Me.CmbDistrito.TabIndex = 9
        Me.CmbDistrito.TabStop = False
        '
        'CmbProvincia
        '
        Me.CmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbProvincia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbProvincia.FormattingEnabled = True
        Me.CmbProvincia.Location = New System.Drawing.Point(143, 23)
        Me.CmbProvincia.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbProvincia.Name = "CmbProvincia"
        Me.CmbProvincia.Size = New System.Drawing.Size(257, 33)
        Me.CmbProvincia.TabIndex = 7
        Me.CmbProvincia.TabStop = False
        '
        'CmbCanton
        '
        Me.CmbCanton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCanton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCanton.FormattingEnabled = True
        Me.CmbCanton.ItemHeight = 25
        Me.CmbCanton.Location = New System.Drawing.Point(143, 66)
        Me.CmbCanton.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbCanton.Name = "CmbCanton"
        Me.CmbCanton.Size = New System.Drawing.Size(257, 33)
        Me.CmbCanton.TabIndex = 8
        Me.CmbCanton.TabStop = False
        '
        'LblCedulaInfo
        '
        Me.LblCedulaInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblCedulaInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCedulaInfo.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblCedulaInfo.Location = New System.Drawing.Point(333, 121)
        Me.LblCedulaInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCedulaInfo.Name = "LblCedulaInfo"
        Me.LblCedulaInfo.Size = New System.Drawing.Size(493, 94)
        Me.LblCedulaInfo.TabIndex = 4
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label23.Location = New System.Drawing.Point(136, 281)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(174, 25)
        Me.Label23.TabIndex = 56
        Me.Label23.Text = "Nombre Comercial"
        '
        'TxtNombreComercial
        '
        Me.TxtNombreComercial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombreComercial.Location = New System.Drawing.Point(333, 277)
        Me.TxtNombreComercial.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNombreComercial.MaxLength = 80
        Me.TxtNombreComercial.Name = "TxtNombreComercial"
        Me.TxtNombreComercial.Size = New System.Drawing.Size(492, 30)
        Me.TxtNombreComercial.TabIndex = 4
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label25.Location = New System.Drawing.Point(136, 393)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(72, 25)
        Me.Label25.TabIndex = 59
        Me.Label25.Text = "Correo"
        '
        'BtnOutlook
        '
        Me.BtnOutlook.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOutlook.ForeColor = System.Drawing.Color.Blue
        Me.BtnOutlook.Location = New System.Drawing.Point(261, 549)
        Me.BtnOutlook.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnOutlook.Name = "BtnOutlook"
        Me.BtnOutlook.Size = New System.Drawing.Size(107, 28)
        Me.BtnOutlook.TabIndex = 60
        Me.BtnOutlook.TabStop = False
        Me.BtnOutlook.Text = "OUTLOOK"
        Me.BtnOutlook.UseVisualStyleBackColor = True
        '
        'BtnGmail
        '
        Me.BtnGmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGmail.ForeColor = System.Drawing.Color.Firebrick
        Me.BtnGmail.Location = New System.Drawing.Point(376, 549)
        Me.BtnGmail.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnGmail.Name = "BtnGmail"
        Me.BtnGmail.Size = New System.Drawing.Size(107, 28)
        Me.BtnGmail.TabIndex = 62
        Me.BtnGmail.TabStop = False
        Me.BtnGmail.Text = "GMAIL"
        Me.BtnGmail.UseVisualStyleBackColor = True
        '
        'BtnYahoo
        '
        Me.BtnYahoo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnYahoo.ForeColor = System.Drawing.Color.Purple
        Me.BtnYahoo.Location = New System.Drawing.Point(491, 549)
        Me.BtnYahoo.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnYahoo.Name = "BtnYahoo"
        Me.BtnYahoo.Size = New System.Drawing.Size(107, 28)
        Me.BtnYahoo.TabIndex = 64
        Me.BtnYahoo.TabStop = False
        Me.BtnYahoo.Text = "YAHOO"
        Me.BtnYahoo.UseVisualStyleBackColor = True
        '
        'BtnHotmail
        '
        Me.BtnHotmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHotmail.ForeColor = System.Drawing.Color.Chocolate
        Me.BtnHotmail.Location = New System.Drawing.Point(605, 549)
        Me.BtnHotmail.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnHotmail.Name = "BtnHotmail"
        Me.BtnHotmail.Size = New System.Drawing.Size(107, 28)
        Me.BtnHotmail.TabIndex = 66
        Me.BtnHotmail.TabStop = False
        Me.BtnHotmail.Text = "HOTMAIL"
        Me.BtnHotmail.UseVisualStyleBackColor = True
        '
        'BtnIcloud
        '
        Me.BtnIcloud.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnIcloud.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.BtnIcloud.Location = New System.Drawing.Point(720, 549)
        Me.BtnIcloud.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnIcloud.Name = "BtnIcloud"
        Me.BtnIcloud.Size = New System.Drawing.Size(107, 28)
        Me.BtnIcloud.TabIndex = 68
        Me.BtnIcloud.TabStop = False
        Me.BtnIcloud.Text = "ICLOUD"
        Me.BtnIcloud.UseVisualStyleBackColor = True
        '
        'BtnArroba
        '
        Me.BtnArroba.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnArroba.ForeColor = System.Drawing.Color.DarkBlue
        Me.BtnArroba.Location = New System.Drawing.Point(145, 463)
        Me.BtnArroba.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnArroba.Name = "BtnArroba"
        Me.BtnArroba.Size = New System.Drawing.Size(107, 114)
        Me.BtnArroba.TabIndex = 71
        Me.BtnArroba.TabStop = False
        Me.BtnArroba.Text = "@"
        Me.BtnArroba.UseVisualStyleBackColor = True
        '
        'BtnVerificaCedula
        '
        Me.BtnVerificaCedula.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnVerificaCedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVerificaCedula.ForeColor = System.Drawing.Color.DarkGreen
        Me.BtnVerificaCedula.Location = New System.Drawing.Point(736, 80)
        Me.BtnVerificaCedula.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnVerificaCedula.Name = "BtnVerificaCedula"
        Me.BtnVerificaCedula.Size = New System.Drawing.Size(91, 32)
        Me.BtnVerificaCedula.TabIndex = 2
        Me.BtnVerificaCedula.Text = "Verificar"
        Me.BtnVerificaCedula.UseVisualStyleBackColor = True
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = Global.PuntoVenta.My.Resources.Resources.Icloud
        Me.PictureBox6.Location = New System.Drawing.Point(720, 463)
        Me.PictureBox6.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(107, 75)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 69
        Me.PictureBox6.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.PuntoVenta.My.Resources.Resources.Hotmail
        Me.PictureBox5.Location = New System.Drawing.Point(605, 463)
        Me.PictureBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(107, 75)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 67
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.PuntoVenta.My.Resources.Resources.Yahoo
        Me.PictureBox4.Location = New System.Drawing.Point(491, 463)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(107, 75)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 65
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.PuntoVenta.My.Resources.Resources.Gmail
        Me.PictureBox3.Location = New System.Drawing.Point(376, 463)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(107, 75)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 63
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.PuntoVenta.My.Resources.Resources.Outlook
        Me.PictureBox2.Location = New System.Drawing.Point(261, 463)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(107, 75)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 61
        Me.PictureBox2.TabStop = False
        '
        'FrmMantClienteNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtnSalir
        Me.ClientSize = New System.Drawing.Size(1343, 615)
        Me.Controls.Add(Me.BtnVerificaCedula)
        Me.Controls.Add(Me.BtnArroba)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.BtnIcloud)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.BtnHotmail)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.BtnYahoo)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.BtnGmail)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.BtnOutlook)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.TxtNombreComercial)
        Me.Controls.Add(Me.LblCedulaInfo)
        Me.Controls.Add(Me.GroupDireccion)
        Me.Controls.Add(Me.TxtCedula)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.CmbTipoIdentificacion)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.PnlBotones)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.LblTelefono)
        Me.Controls.Add(Me.TxtTelefono1)
        Me.Controls.Add(Me.TxtEmail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantClienteNew"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes"
        Me.PnlBotones.ResumeLayout(False)
        Me.GroupDireccion.ResumeLayout(False)
        Me.GroupDireccion.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PnlBotones As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtTelefono1 As System.Windows.Forms.TextBox
    Friend WithEvents LblTelefono As System.Windows.Forms.Label
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents CmbTipoIdentificacion As ComboBox
    Friend WithEvents TxtCedula As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents GroupDireccion As GroupBox
    Friend WithEvents Label19 As Label
    Friend WithEvents CmbBarrio As ComboBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents CmbDistrito As ComboBox
    Friend WithEvents CmbProvincia As ComboBox
    Friend WithEvents CmbCanton As ComboBox
    Friend WithEvents LblCedulaInfo As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents TxtNombreComercial As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents BtnOutlook As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents BtnGmail As Button
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents BtnYahoo As Button
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents BtnHotmail As Button
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents BtnIcloud As Button
    Friend WithEvents BtnArroba As Button
    Friend WithEvents BtnVerificaCedula As Button
    Friend WithEvents BtnLimpiar As Button
End Class
