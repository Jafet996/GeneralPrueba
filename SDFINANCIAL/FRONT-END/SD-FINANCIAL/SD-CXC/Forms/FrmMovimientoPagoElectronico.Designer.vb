<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMovimientoPagoElectronico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMovimientoPagoElectronico))
        Me.PanelTiposDePago = New System.Windows.Forms.Panel()
        Me.CmbCuentaTransferencia = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CmbCuentaDeposito = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CmbMonedaTransferencia = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CmbMonedaDeposito = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtpFechaTransferencia = New System.Windows.Forms.DateTimePicker()
        Me.TxtNumeroTransferencia = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbBancoTransferencia = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtMontoTransferencia = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RdbTransferencia = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DtpFechaDeposito = New System.Windows.Forms.DateTimePicker()
        Me.BtnAgregar = New System.Windows.Forms.Button()
        Me.TxtNumeroDeposito = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbBancoDeposito = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtMontoDeposito = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RdbDeposito = New System.Windows.Forms.RadioButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.BtnFacturar = New System.Windows.Forms.ToolStripButton()
        Me.BtnMuestraCalculadora = New System.Windows.Forms.ToolStripButton()
        Me.PicLogo = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LvwListaPagos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PanelFaltan = New System.Windows.Forms.Panel()
        Me.LblTotalFaltante = New System.Windows.Forms.Label()
        Me.LblFaltaEtiqueta = New System.Windows.Forms.Label()
        Me.PanelTiposDePago.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.PanelFaltan.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelTiposDePago
        '
        Me.PanelTiposDePago.BackColor = System.Drawing.Color.SteelBlue
        Me.PanelTiposDePago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelTiposDePago.Controls.Add(Me.CmbCuentaTransferencia)
        Me.PanelTiposDePago.Controls.Add(Me.Label12)
        Me.PanelTiposDePago.Controls.Add(Me.CmbCuentaDeposito)
        Me.PanelTiposDePago.Controls.Add(Me.Label10)
        Me.PanelTiposDePago.Controls.Add(Me.CmbMonedaTransferencia)
        Me.PanelTiposDePago.Controls.Add(Me.Label9)
        Me.PanelTiposDePago.Controls.Add(Me.CmbMonedaDeposito)
        Me.PanelTiposDePago.Controls.Add(Me.Label8)
        Me.PanelTiposDePago.Controls.Add(Me.Label1)
        Me.PanelTiposDePago.Controls.Add(Me.DtpFechaTransferencia)
        Me.PanelTiposDePago.Controls.Add(Me.TxtNumeroTransferencia)
        Me.PanelTiposDePago.Controls.Add(Me.Label2)
        Me.PanelTiposDePago.Controls.Add(Me.CmbBancoTransferencia)
        Me.PanelTiposDePago.Controls.Add(Me.Label3)
        Me.PanelTiposDePago.Controls.Add(Me.TxtMontoTransferencia)
        Me.PanelTiposDePago.Controls.Add(Me.Label4)
        Me.PanelTiposDePago.Controls.Add(Me.RdbTransferencia)
        Me.PanelTiposDePago.Controls.Add(Me.PictureBox1)
        Me.PanelTiposDePago.Controls.Add(Me.Label11)
        Me.PanelTiposDePago.Controls.Add(Me.DtpFechaDeposito)
        Me.PanelTiposDePago.Controls.Add(Me.BtnAgregar)
        Me.PanelTiposDePago.Controls.Add(Me.TxtNumeroDeposito)
        Me.PanelTiposDePago.Controls.Add(Me.Label5)
        Me.PanelTiposDePago.Controls.Add(Me.CmbBancoDeposito)
        Me.PanelTiposDePago.Controls.Add(Me.Label6)
        Me.PanelTiposDePago.Controls.Add(Me.TxtMontoDeposito)
        Me.PanelTiposDePago.Controls.Add(Me.Label7)
        Me.PanelTiposDePago.Controls.Add(Me.RdbDeposito)
        Me.PanelTiposDePago.Controls.Add(Me.PictureBox2)
        Me.PanelTiposDePago.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelTiposDePago.Location = New System.Drawing.Point(0, 0)
        Me.PanelTiposDePago.Name = "PanelTiposDePago"
        Me.PanelTiposDePago.Size = New System.Drawing.Size(273, 554)
        Me.PanelTiposDePago.TabIndex = 26
        '
        'CmbCuentaTransferencia
        '
        Me.CmbCuentaTransferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCuentaTransferencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbCuentaTransferencia.FormattingEnabled = True
        Me.CmbCuentaTransferencia.Location = New System.Drawing.Point(71, 320)
        Me.CmbCuentaTransferencia.Name = "CmbCuentaTransferencia"
        Me.CmbCuentaTransferencia.Size = New System.Drawing.Size(184, 21)
        Me.CmbCuentaTransferencia.TabIndex = 74
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(10, 325)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 13)
        Me.Label12.TabIndex = 73
        Me.Label12.Text = "Cuenta"
        '
        'CmbCuentaDeposito
        '
        Me.CmbCuentaDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCuentaDeposito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbCuentaDeposito.FormattingEnabled = True
        Me.CmbCuentaDeposito.Location = New System.Drawing.Point(71, 83)
        Me.CmbCuentaDeposito.Name = "CmbCuentaDeposito"
        Me.CmbCuentaDeposito.Size = New System.Drawing.Size(184, 21)
        Me.CmbCuentaDeposito.TabIndex = 72
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(10, 88)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 71
        Me.Label10.Text = "Cuenta"
        '
        'CmbMonedaTransferencia
        '
        Me.CmbMonedaTransferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMonedaTransferencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbMonedaTransferencia.FormattingEnabled = True
        Me.CmbMonedaTransferencia.Items.AddRange(New Object() {"COLONES", "DÓLARES"})
        Me.CmbMonedaTransferencia.Location = New System.Drawing.Point(71, 434)
        Me.CmbMonedaTransferencia.Name = "CmbMonedaTransferencia"
        Me.CmbMonedaTransferencia.Size = New System.Drawing.Size(184, 21)
        Me.CmbMonedaTransferencia.TabIndex = 70
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(10, 439)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 69
        Me.Label9.Text = "Moneda"
        '
        'CmbMonedaDeposito
        '
        Me.CmbMonedaDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMonedaDeposito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbMonedaDeposito.FormattingEnabled = True
        Me.CmbMonedaDeposito.Items.AddRange(New Object() {"COLONES", "DÓLARES"})
        Me.CmbMonedaDeposito.Location = New System.Drawing.Point(71, 197)
        Me.CmbMonedaDeposito.Name = "CmbMonedaDeposito"
        Me.CmbMonedaDeposito.Size = New System.Drawing.Size(184, 21)
        Me.CmbMonedaDeposito.TabIndex = 68
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(10, 202)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 67
        Me.Label8.Text = "Moneda"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 414)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Fecha"
        '
        'DtpFechaTransferencia
        '
        Me.DtpFechaTransferencia.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaTransferencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaTransferencia.Location = New System.Drawing.Point(71, 408)
        Me.DtpFechaTransferencia.Name = "DtpFechaTransferencia"
        Me.DtpFechaTransferencia.Size = New System.Drawing.Size(184, 20)
        Me.DtpFechaTransferencia.TabIndex = 65
        '
        'TxtNumeroTransferencia
        '
        Me.TxtNumeroTransferencia.Location = New System.Drawing.Point(71, 382)
        Me.TxtNumeroTransferencia.MaxLength = 20
        Me.TxtNumeroTransferencia.Name = "TxtNumeroTransferencia"
        Me.TxtNumeroTransferencia.Size = New System.Drawing.Size(184, 20)
        Me.TxtNumeroTransferencia.TabIndex = 63
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(10, 385)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "Número"
        '
        'CmbBancoTransferencia
        '
        Me.CmbBancoTransferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBancoTransferencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbBancoTransferencia.FormattingEnabled = True
        Me.CmbBancoTransferencia.Location = New System.Drawing.Point(71, 293)
        Me.CmbBancoTransferencia.Name = "CmbBancoTransferencia"
        Me.CmbBancoTransferencia.Size = New System.Drawing.Size(184, 21)
        Me.CmbBancoTransferencia.TabIndex = 59
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(10, 298)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Banco"
        '
        'TxtMontoTransferencia
        '
        Me.TxtMontoTransferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMontoTransferencia.Location = New System.Drawing.Point(71, 347)
        Me.TxtMontoTransferencia.Name = "TxtMontoTransferencia"
        Me.TxtMontoTransferencia.Size = New System.Drawing.Size(184, 29)
        Me.TxtMontoTransferencia.TabIndex = 61
        Me.TxtMontoTransferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(10, 357)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Monto"
        '
        'RdbTransferencia
        '
        Me.RdbTransferencia.AutoSize = True
        Me.RdbTransferencia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdbTransferencia.ForeColor = System.Drawing.Color.White
        Me.RdbTransferencia.Location = New System.Drawing.Point(10, 257)
        Me.RdbTransferencia.Name = "RdbTransferencia"
        Me.RdbTransferencia.Size = New System.Drawing.Size(144, 17)
        Me.RdbTransferencia.TabIndex = 57
        Me.RdbTransferencia.Text = "Transferencia (Alt-T)"
        Me.RdbTransferencia.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SDCXC.My.Resources.Resources.text_ok
        Me.PictureBox1.Location = New System.Drawing.Point(223, 257)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 64
        Me.PictureBox1.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(10, 177)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "Fecha"
        '
        'DtpFechaDeposito
        '
        Me.DtpFechaDeposito.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaDeposito.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaDeposito.Location = New System.Drawing.Point(71, 171)
        Me.DtpFechaDeposito.Name = "DtpFechaDeposito"
        Me.DtpFechaDeposito.Size = New System.Drawing.Size(184, 20)
        Me.DtpFechaDeposito.TabIndex = 55
        '
        'BtnAgregar
        '
        Me.BtnAgregar.BackColor = System.Drawing.Color.White
        Me.BtnAgregar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgregar.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BtnAgregar.Image = Global.SDCXC.My.Resources.Resources.add
        Me.BtnAgregar.Location = New System.Drawing.Point(10, 489)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(245, 41)
        Me.BtnAgregar.TabIndex = 31
        Me.BtnAgregar.Text = "Agregar"
        Me.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAgregar.UseVisualStyleBackColor = False
        '
        'TxtNumeroDeposito
        '
        Me.TxtNumeroDeposito.Location = New System.Drawing.Point(71, 145)
        Me.TxtNumeroDeposito.MaxLength = 20
        Me.TxtNumeroDeposito.Name = "TxtNumeroDeposito"
        Me.TxtNumeroDeposito.Size = New System.Drawing.Size(184, 20)
        Me.TxtNumeroDeposito.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(10, 148)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Número"
        '
        'CmbBancoDeposito
        '
        Me.CmbBancoDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBancoDeposito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbBancoDeposito.FormattingEnabled = True
        Me.CmbBancoDeposito.Location = New System.Drawing.Point(71, 56)
        Me.CmbBancoDeposito.Name = "CmbBancoDeposito"
        Me.CmbBancoDeposito.Size = New System.Drawing.Size(184, 21)
        Me.CmbBancoDeposito.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(10, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Banco"
        '
        'TxtMontoDeposito
        '
        Me.TxtMontoDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMontoDeposito.Location = New System.Drawing.Point(71, 110)
        Me.TxtMontoDeposito.Name = "TxtMontoDeposito"
        Me.TxtMontoDeposito.Size = New System.Drawing.Size(184, 29)
        Me.TxtMontoDeposito.TabIndex = 16
        Me.TxtMontoDeposito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(10, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Monto"
        '
        'RdbDeposito
        '
        Me.RdbDeposito.AutoSize = True
        Me.RdbDeposito.Checked = True
        Me.RdbDeposito.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdbDeposito.ForeColor = System.Drawing.Color.White
        Me.RdbDeposito.Location = New System.Drawing.Point(10, 20)
        Me.RdbDeposito.Name = "RdbDeposito"
        Me.RdbDeposito.Size = New System.Drawing.Size(117, 17)
        Me.RdbDeposito.TabIndex = 12
        Me.RdbDeposito.TabStop = True
        Me.RdbDeposito.Text = "Deposito (Alt-D)"
        Me.RdbDeposito.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.SDCXC.My.Resources.Resources.money_envelope
        Me.PictureBox2.Location = New System.Drawing.Point(223, 20)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 30)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 20
        Me.PictureBox2.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Location = New System.Drawing.Point(275, 476)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(674, 79)
        Me.Panel1.TabIndex = 40
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.White
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnCancelar, Me.BtnFacturar, Me.BtnMuestraCalculadora})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(674, 79)
        Me.ToolStrip1.TabIndex = 61
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.SDCXC.My.Resources.Resources.Blue_Esc
        Me.BtnCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(57, 76)
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnFacturar
        '
        Me.BtnFacturar.Image = Global.SDCXC.My.Resources.Resources.Blue_F3
        Me.BtnFacturar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnFacturar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFacturar.Name = "BtnFacturar"
        Me.BtnFacturar.Size = New System.Drawing.Size(54, 76)
        Me.BtnFacturar.Text = "Facturar"
        Me.BtnFacturar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnMuestraCalculadora
        '
        Me.BtnMuestraCalculadora.Image = Global.SDCXC.My.Resources.Resources.Blue_F1
        Me.BtnMuestraCalculadora.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnMuestraCalculadora.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnMuestraCalculadora.Name = "BtnMuestraCalculadora"
        Me.BtnMuestraCalculadora.Size = New System.Drawing.Size(74, 76)
        Me.BtnMuestraCalculadora.Text = "Calculadora"
        Me.BtnMuestraCalculadora.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PicLogo
        '
        Me.PicLogo.Location = New System.Drawing.Point(820, 0)
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(129, 124)
        Me.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicLogo.TabIndex = 39
        Me.PicLogo.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.LvwListaPagos)
        Me.GroupBox1.Location = New System.Drawing.Point(275, 120)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(674, 353)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        '
        'LvwListaPagos
        '
        Me.LvwListaPagos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.LvwListaPagos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvwListaPagos.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LvwListaPagos.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.LvwListaPagos.FullRowSelect = True
        Me.LvwListaPagos.HideSelection = False
        Me.LvwListaPagos.Location = New System.Drawing.Point(3, 16)
        Me.LvwListaPagos.Name = "LvwListaPagos"
        Me.LvwListaPagos.Size = New System.Drawing.Size(668, 334)
        Me.LvwListaPagos.TabIndex = 0
        Me.LvwListaPagos.UseCompatibleStateImageBehavior = False
        Me.LvwListaPagos.View = System.Windows.Forms.View.Details
        '
        'PanelFaltan
        '
        Me.PanelFaltan.Controls.Add(Me.LblTotalFaltante)
        Me.PanelFaltan.Location = New System.Drawing.Point(445, 22)
        Me.PanelFaltan.Name = "PanelFaltan"
        Me.PanelFaltan.Size = New System.Drawing.Size(356, 77)
        Me.PanelFaltan.TabIndex = 36
        '
        'LblTotalFaltante
        '
        Me.LblTotalFaltante.BackColor = System.Drawing.Color.White
        Me.LblTotalFaltante.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblTotalFaltante.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalFaltante.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LblTotalFaltante.Location = New System.Drawing.Point(0, 0)
        Me.LblTotalFaltante.Name = "LblTotalFaltante"
        Me.LblTotalFaltante.Size = New System.Drawing.Size(356, 77)
        Me.LblTotalFaltante.TabIndex = 0
        Me.LblTotalFaltante.Text = "0.00"
        Me.LblTotalFaltante.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblFaltaEtiqueta
        '
        Me.LblFaltaEtiqueta.AutoSize = True
        Me.LblFaltaEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFaltaEtiqueta.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LblFaltaEtiqueta.Location = New System.Drawing.Point(298, 44)
        Me.LblFaltaEtiqueta.Name = "LblFaltaEtiqueta"
        Me.LblFaltaEtiqueta.Size = New System.Drawing.Size(106, 42)
        Me.LblFaltaEtiqueta.TabIndex = 37
        Me.LblFaltaEtiqueta.Text = "Falta"
        Me.LblFaltaEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmMovimientoPagoElectronico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(950, 554)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PicLogo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PanelFaltan)
        Me.Controls.Add(Me.LblFaltaEtiqueta)
        Me.Controls.Add(Me.PanelTiposDePago)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMovimientoPagoElectronico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelTiposDePago.ResumeLayout(False)
        Me.PanelTiposDePago.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.PanelFaltan.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelTiposDePago As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DtpFechaDeposito As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnAgregar As System.Windows.Forms.Button
    Friend WithEvents TxtNumeroDeposito As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbBancoDeposito As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtMontoDeposito As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RdbDeposito As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpFechaTransferencia As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtNumeroTransferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbBancoTransferencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtMontoTransferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RdbTransferencia As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnFacturar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnMuestraCalculadora As System.Windows.Forms.ToolStripButton
    Friend WithEvents PicLogo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LvwListaPagos As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PanelFaltan As System.Windows.Forms.Panel
    Friend WithEvents LblTotalFaltante As System.Windows.Forms.Label
    Friend WithEvents LblFaltaEtiqueta As System.Windows.Forms.Label
    Friend WithEvents CmbMonedaTransferencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CmbMonedaDeposito As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents CmbCuentaTransferencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CmbCuentaDeposito As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
End Class
