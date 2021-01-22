<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMovimientoCrea
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMovimientoCrea))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnAplicar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblVendedor = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TxtFecha = New System.Windows.Forms.TextBox()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtTipoCambio = New System.Windows.Forms.TextBox()
        Me.TxtMontoDolares = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ChkAplicaMora = New System.Windows.Forms.CheckBox()
        Me.PnlFechas = New System.Windows.Forms.Panel()
        Me.BtnFacturas = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DtpFechaEntrega = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DtpFechaVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.DtpFechaEmision = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbMoneda = New System.Windows.Forms.ComboBox()
        Me.TxtMonto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtTipo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.PnlFechas.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnAplicar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(80, 391)
        Me.Panel1.TabIndex = 2
        '
        'BtnAplicar
        '
        Me.BtnAplicar.BackColor = System.Drawing.Color.White
        Me.BtnAplicar.Image = Global.SDCXC.My.Resources.Resources.Blue_F3
        Me.BtnAplicar.Location = New System.Drawing.Point(7, 6)
        Me.BtnAplicar.Name = "BtnAplicar"
        Me.BtnAplicar.Size = New System.Drawing.Size(66, 73)
        Me.BtnAplicar.TabIndex = 6
        Me.BtnAplicar.Text = "Aplicar"
        Me.BtnAplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAplicar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.SDCXC.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(7, 85)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(66, 73)
        Me.BtnSalir.TabIndex = 4
        Me.BtnSalir.Text = "Cancelar"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblVendedor)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.TxtFecha)
        Me.GroupBox1.Controls.Add(Me.LblCliente)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(90, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(687, 142)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'LblVendedor
        '
        Me.LblVendedor.AutoSize = True
        Me.LblVendedor.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVendedor.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblVendedor.Location = New System.Drawing.Point(59, 97)
        Me.LblVendedor.Name = "LblVendedor"
        Me.LblVendedor.Size = New System.Drawing.Size(79, 18)
        Me.LblVendedor.TabIndex = 4
        Me.LblVendedor.Text = "Vendedor"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.SDCXC.My.Resources.Resources.shirt
        Me.PictureBox2.Location = New System.Drawing.Point(15, 86)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(37, 39)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'TxtFecha
        '
        Me.TxtFecha.BackColor = System.Drawing.Color.White
        Me.TxtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFecha.Location = New System.Drawing.Point(535, 32)
        Me.TxtFecha.Name = "TxtFecha"
        Me.TxtFecha.ReadOnly = True
        Me.TxtFecha.Size = New System.Drawing.Size(119, 21)
        Me.TxtFecha.TabIndex = 2
        Me.TxtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblCliente
        '
        Me.LblCliente.AutoSize = True
        Me.LblCliente.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCliente.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblCliente.Location = New System.Drawing.Point(59, 33)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(61, 18)
        Me.LblCliente.TabIndex = 1
        Me.LblCliente.Text = "Cliente"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SDCXC.My.Resources.Resources.user1
        Me.PictureBox1.Location = New System.Drawing.Point(15, 22)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 39)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtTipoCambio)
        Me.GroupBox2.Controls.Add(Me.TxtMontoDolares)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.ChkAplicaMora)
        Me.GroupBox2.Controls.Add(Me.PnlFechas)
        Me.GroupBox2.Controls.Add(Me.CmbMoneda)
        Me.GroupBox2.Controls.Add(Me.TxtMonto)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TxtReferencia)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TxtTipo)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(90, 147)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(687, 244)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'TxtTipoCambio
        '
        Me.TxtTipoCambio.BackColor = System.Drawing.Color.White
        Me.TxtTipoCambio.Location = New System.Drawing.Point(102, 158)
        Me.TxtTipoCambio.Name = "TxtTipoCambio"
        Me.TxtTipoCambio.ReadOnly = True
        Me.TxtTipoCambio.Size = New System.Drawing.Size(162, 20)
        Me.TxtTipoCambio.TabIndex = 16
        Me.TxtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtMontoDolares
        '
        Me.TxtMontoDolares.BackColor = System.Drawing.Color.White
        Me.TxtMontoDolares.Location = New System.Drawing.Point(102, 184)
        Me.TxtMontoDolares.Name = "TxtMontoDolares"
        Me.TxtMontoDolares.Size = New System.Drawing.Size(162, 20)
        Me.TxtMontoDolares.TabIndex = 15
        Me.TxtMontoDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(12, 184)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 20)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Dólares"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(12, 158)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 20)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "$ Cambio"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ChkAplicaMora
        '
        Me.ChkAplicaMora.AutoSize = True
        Me.ChkAplicaMora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAplicaMora.Location = New System.Drawing.Point(561, 29)
        Me.ChkAplicaMora.Name = "ChkAplicaMora"
        Me.ChkAplicaMora.Size = New System.Drawing.Size(93, 17)
        Me.ChkAplicaMora.TabIndex = 12
        Me.ChkAplicaMora.Text = "Aplica Mora"
        Me.ChkAplicaMora.UseVisualStyleBackColor = True
        '
        'PnlFechas
        '
        Me.PnlFechas.Controls.Add(Me.BtnFacturas)
        Me.PnlFechas.Controls.Add(Me.Label10)
        Me.PnlFechas.Controls.Add(Me.DtpFechaEntrega)
        Me.PnlFechas.Controls.Add(Me.Label9)
        Me.PnlFechas.Controls.Add(Me.DtpFechaVencimiento)
        Me.PnlFechas.Controls.Add(Me.DtpFechaEmision)
        Me.PnlFechas.Controls.Add(Me.Label5)
        Me.PnlFechas.Controls.Add(Me.Label4)
        Me.PnlFechas.Location = New System.Drawing.Point(373, 105)
        Me.PnlFechas.Name = "PnlFechas"
        Me.PnlFechas.Size = New System.Drawing.Size(281, 122)
        Me.PnlFechas.TabIndex = 11
        '
        'BtnFacturas
        '
        Me.BtnFacturas.Location = New System.Drawing.Point(109, 78)
        Me.BtnFacturas.Name = "BtnFacturas"
        Me.BtnFacturas.Size = New System.Drawing.Size(162, 22)
        Me.BtnFacturas.TabIndex = 15
        Me.BtnFacturas.Text = "Seleccionar"
        Me.BtnFacturas.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SteelBlue
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(19, 79)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 20)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Facturas"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DtpFechaEntrega
        '
        Me.DtpFechaEntrega.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaEntrega.Location = New System.Drawing.Point(109, 30)
        Me.DtpFechaEntrega.Name = "DtpFechaEntrega"
        Me.DtpFechaEntrega.Size = New System.Drawing.Size(162, 20)
        Me.DtpFechaEntrega.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SteelBlue
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(19, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 20)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Entrega"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DtpFechaVencimiento
        '
        Me.DtpFechaVencimiento.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaVencimiento.Location = New System.Drawing.Point(109, 56)
        Me.DtpFechaVencimiento.Name = "DtpFechaVencimiento"
        Me.DtpFechaVencimiento.Size = New System.Drawing.Size(162, 20)
        Me.DtpFechaVencimiento.TabIndex = 10
        '
        'DtpFechaEmision
        '
        Me.DtpFechaEmision.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaEmision.Location = New System.Drawing.Point(109, 4)
        Me.DtpFechaEmision.Name = "DtpFechaEmision"
        Me.DtpFechaEmision.Size = New System.Drawing.Size(162, 20)
        Me.DtpFechaEmision.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(19, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 20)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Vencimiento"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(19, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Emisión"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmbMoneda
        '
        Me.CmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMoneda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbMoneda.FormattingEnabled = True
        Me.CmbMoneda.Items.AddRange(New Object() {"COLONES", "DÓLARES"})
        Me.CmbMoneda.Location = New System.Drawing.Point(102, 105)
        Me.CmbMoneda.Name = "CmbMoneda"
        Me.CmbMoneda.Size = New System.Drawing.Size(162, 21)
        Me.CmbMoneda.TabIndex = 10
        '
        'TxtMonto
        '
        Me.TxtMonto.BackColor = System.Drawing.Color.White
        Me.TxtMonto.Location = New System.Drawing.Point(102, 132)
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Size = New System.Drawing.Size(162, 20)
        Me.TxtMonto.TabIndex = 9
        Me.TxtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Monto"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Moneda"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(102, 51)
        Me.TxtReferencia.MaxLength = 400
        Me.TxtReferencia.Multiline = True
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(552, 48)
        Me.TxtReferencia.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Referencia"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtTipo
        '
        Me.TxtTipo.BackColor = System.Drawing.Color.White
        Me.TxtTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtTipo.Location = New System.Drawing.Point(102, 25)
        Me.TxtTipo.Name = "TxtTipo"
        Me.TxtTipo.ReadOnly = True
        Me.TxtTipo.Size = New System.Drawing.Size(162, 22)
        Me.TxtTipo.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(12, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 20)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Tipo"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmMovimientoCrea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 391)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMovimientoCrea"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.PnlFechas.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnAplicar As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtTipo As System.Windows.Forms.TextBox
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents PnlFechas As System.Windows.Forms.Panel
    Friend WithEvents DtpFechaVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpFechaEmision As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ChkAplicaMora As System.Windows.Forms.CheckBox
    Friend WithEvents TxtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents TxtMontoDolares As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DtpFechaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As Label
    Friend WithEvents BtnFacturas As Button
    Friend WithEvents LblVendedor As Label
    Friend WithEvents PictureBox2 As PictureBox
End Class
