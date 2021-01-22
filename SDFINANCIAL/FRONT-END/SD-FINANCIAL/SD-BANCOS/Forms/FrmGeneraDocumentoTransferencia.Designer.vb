<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGeneraDocumentoTransferencia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGeneraDocumentoTransferencia))
        Me.PnlEncabezado = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.PnlPie = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblMonto = New System.Windows.Forms.Label()
        Me.LblTotalEnc = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.GbBeneficiario = New System.Windows.Forms.GroupBox()
        Me.BtnAgregarCuenta = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtBeneficiario = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CmbMonedaBeneficiario = New System.Windows.Forms.ComboBox()
        Me.CmbBancoProveedor = New System.Windows.Forms.ComboBox()
        Me.CmbCuentaBeneficiario = New System.Windows.Forms.ComboBox()
        Me.PnlEncabezado.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlPie.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbBeneficiario.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlEncabezado
        '
        Me.PnlEncabezado.BackColor = System.Drawing.Color.SteelBlue
        Me.PnlEncabezado.Controls.Add(Me.PictureBox2)
        Me.PnlEncabezado.Controls.Add(Me.LblTitulo)
        Me.PnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.PnlEncabezado.Name = "PnlEncabezado"
        Me.PnlEncabezado.Size = New System.Drawing.Size(565, 61)
        Me.PnlEncabezado.TabIndex = 1
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.SDBANCOS.My.Resources.Resources.money2
        Me.PictureBox2.Location = New System.Drawing.Point(514, 7)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(42, 46)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.White
        Me.LblTitulo.Location = New System.Drawing.Point(19, 18)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(382, 25)
        Me.LblTitulo.TabIndex = 2
        Me.LblTitulo.Text = "Solicitud de Pago por Transferencia"
        '
        'PnlPie
        '
        Me.PnlPie.BackColor = System.Drawing.Color.White
        Me.PnlPie.Controls.Add(Me.PictureBox4)
        Me.PnlPie.Controls.Add(Me.PictureBox1)
        Me.PnlPie.Controls.Add(Me.LblMonto)
        Me.PnlPie.Controls.Add(Me.LblTotalEnc)
        Me.PnlPie.Controls.Add(Me.PictureBox3)
        Me.PnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlPie.Location = New System.Drawing.Point(0, 203)
        Me.PnlPie.Name = "PnlPie"
        Me.PnlPie.Size = New System.Drawing.Size(565, 57)
        Me.PnlPie.TabIndex = 4
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.SDBANCOS.My.Resources.Resources.Blue_F3
        Me.PictureBox4.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(49, 50)
        Me.PictureBox4.TabIndex = 68
        Me.PictureBox4.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SDBANCOS.My.Resources.Resources.Blue_Esc
        Me.PictureBox1.Location = New System.Drawing.Point(54, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 50)
        Me.PictureBox1.TabIndex = 67
        Me.PictureBox1.TabStop = False
        '
        'LblMonto
        '
        Me.LblMonto.BackColor = System.Drawing.Color.White
        Me.LblMonto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMonto.ForeColor = System.Drawing.Color.Blue
        Me.LblMonto.Location = New System.Drawing.Point(396, 13)
        Me.LblMonto.Name = "LblMonto"
        Me.LblMonto.Size = New System.Drawing.Size(158, 29)
        Me.LblMonto.TabIndex = 66
        Me.LblMonto.Text = "0.00"
        Me.LblMonto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTotalEnc
        '
        Me.LblTotalEnc.AutoSize = True
        Me.LblTotalEnc.BackColor = System.Drawing.Color.White
        Me.LblTotalEnc.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalEnc.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblTotalEnc.Location = New System.Drawing.Point(265, 15)
        Me.LblTotalEnc.Name = "LblTotalEnc"
        Me.LblTotalEnc.Size = New System.Drawing.Size(84, 25)
        Me.LblTotalEnc.TabIndex = 65
        Me.LblTotalEnc.Text = "Monto "
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.SDBANCOS.My.Resources.Resources.Total3
        Me.PictureBox3.Location = New System.Drawing.Point(255, 2)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(309, 52)
        Me.PictureBox3.TabIndex = 64
        Me.PictureBox3.TabStop = False
        '
        'GbBeneficiario
        '
        Me.GbBeneficiario.Controls.Add(Me.BtnAgregarCuenta)
        Me.GbBeneficiario.Controls.Add(Me.Label1)
        Me.GbBeneficiario.Controls.Add(Me.Label7)
        Me.GbBeneficiario.Controls.Add(Me.TxtBeneficiario)
        Me.GbBeneficiario.Controls.Add(Me.Label8)
        Me.GbBeneficiario.Controls.Add(Me.Label9)
        Me.GbBeneficiario.Controls.Add(Me.CmbMonedaBeneficiario)
        Me.GbBeneficiario.Controls.Add(Me.CmbBancoProveedor)
        Me.GbBeneficiario.Controls.Add(Me.CmbCuentaBeneficiario)
        Me.GbBeneficiario.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbBeneficiario.Location = New System.Drawing.Point(11, 67)
        Me.GbBeneficiario.Name = "GbBeneficiario"
        Me.GbBeneficiario.Size = New System.Drawing.Size(544, 128)
        Me.GbBeneficiario.TabIndex = 24
        Me.GbBeneficiario.TabStop = False
        Me.GbBeneficiario.Text = "Información del Beneficiario"
        '
        'BtnAgregarCuenta
        '
        Me.BtnAgregarCuenta.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnAgregarCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAgregarCuenta.ForeColor = System.Drawing.Color.White
        Me.BtnAgregarCuenta.Location = New System.Drawing.Point(87, 79)
        Me.BtnAgregarCuenta.Name = "BtnAgregarCuenta"
        Me.BtnAgregarCuenta.Size = New System.Drawing.Size(32, 22)
        Me.BtnAgregarCuenta.TabIndex = 15
        Me.BtnAgregarCuenta.Text = "..."
        Me.BtnAgregarCuenta.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnAgregarCuenta.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(20, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Beneficiario"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(311, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 20)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Moneda"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtBeneficiario
        '
        Me.TxtBeneficiario.BackColor = System.Drawing.Color.White
        Me.TxtBeneficiario.Location = New System.Drawing.Point(126, 26)
        Me.TxtBeneficiario.Name = "TxtBeneficiario"
        Me.TxtBeneficiario.Size = New System.Drawing.Size(397, 22)
        Me.TxtBeneficiario.TabIndex = 1
        Me.TxtBeneficiario.TabStop = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(20, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 20)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Cuenta"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SteelBlue
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(20, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Banco"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbMonedaBeneficiario
        '
        Me.CmbMonedaBeneficiario.BackColor = System.Drawing.Color.White
        Me.CmbMonedaBeneficiario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMonedaBeneficiario.Enabled = False
        Me.CmbMonedaBeneficiario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbMonedaBeneficiario.FormattingEnabled = True
        Me.CmbMonedaBeneficiario.Items.AddRange(New Object() {"COLONES", "DOLARES"})
        Me.CmbMonedaBeneficiario.Location = New System.Drawing.Point(400, 79)
        Me.CmbMonedaBeneficiario.Name = "CmbMonedaBeneficiario"
        Me.CmbMonedaBeneficiario.Size = New System.Drawing.Size(123, 22)
        Me.CmbMonedaBeneficiario.TabIndex = 19
        Me.CmbMonedaBeneficiario.TabStop = False
        '
        'CmbBancoProveedor
        '
        Me.CmbBancoProveedor.BackColor = System.Drawing.Color.White
        Me.CmbBancoProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBancoProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbBancoProveedor.FormattingEnabled = True
        Me.CmbBancoProveedor.Location = New System.Drawing.Point(126, 52)
        Me.CmbBancoProveedor.Name = "CmbBancoProveedor"
        Me.CmbBancoProveedor.Size = New System.Drawing.Size(397, 22)
        Me.CmbBancoProveedor.TabIndex = 17
        '
        'CmbCuentaBeneficiario
        '
        Me.CmbCuentaBeneficiario.BackColor = System.Drawing.Color.White
        Me.CmbCuentaBeneficiario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCuentaBeneficiario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbCuentaBeneficiario.FormattingEnabled = True
        Me.CmbCuentaBeneficiario.Location = New System.Drawing.Point(126, 79)
        Me.CmbCuentaBeneficiario.Name = "CmbCuentaBeneficiario"
        Me.CmbCuentaBeneficiario.Size = New System.Drawing.Size(179, 22)
        Me.CmbCuentaBeneficiario.TabIndex = 18
        '
        'FrmGeneraDocumentoTransferencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(565, 260)
        Me.Controls.Add(Me.GbBeneficiario)
        Me.Controls.Add(Me.PnlPie)
        Me.Controls.Add(Me.PnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGeneraDocumentoTransferencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PnlEncabezado.ResumeLayout(False)
        Me.PnlEncabezado.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlPie.ResumeLayout(False)
        Me.PnlPie.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbBeneficiario.ResumeLayout(False)
        Me.GbBeneficiario.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents PnlPie As System.Windows.Forms.Panel
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LblMonto As System.Windows.Forms.Label
    Friend WithEvents LblTotalEnc As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents GbBeneficiario As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregarCuenta As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtBeneficiario As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CmbMonedaBeneficiario As System.Windows.Forms.ComboBox
    Friend WithEvents CmbBancoProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents CmbCuentaBeneficiario As System.Windows.Forms.ComboBox
End Class
