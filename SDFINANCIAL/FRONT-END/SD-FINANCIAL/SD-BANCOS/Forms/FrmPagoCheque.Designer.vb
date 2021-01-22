<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPagoCheque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPagoCheque))
        Me.PnlEncabezado = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.PnlPie = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblMonto = New System.Windows.Forms.Label()
        Me.LblTotalEnc = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtBeneficiario = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtConcepto = New System.Windows.Forms.TextBox()
        Me.CmbBanco = New System.Windows.Forms.ComboBox()
        Me.CmbCuenta = New System.Windows.Forms.ComboBox()
        Me.CmbMoneda = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.PnlEncabezado.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlPie.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PnlEncabezado.Size = New System.Drawing.Size(542, 61)
        Me.PnlEncabezado.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.SDBANCOS.My.Resources.Resources.money2
        Me.PictureBox2.Location = New System.Drawing.Point(494, 7)
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
        Me.LblTitulo.Size = New System.Drawing.Size(260, 25)
        Me.LblTitulo.TabIndex = 2
        Me.LblTitulo.Text = "Forma de Pago: Cheque"
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
        Me.PnlPie.Location = New System.Drawing.Point(0, 294)
        Me.PnlPie.Name = "PnlPie"
        Me.PnlPie.Size = New System.Drawing.Size(542, 57)
        Me.PnlPie.TabIndex = 3
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
        Me.PictureBox1.Location = New System.Drawing.Point(55, 3)
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
        Me.LblMonto.Location = New System.Drawing.Point(374, 13)
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
        Me.LblTotalEnc.Location = New System.Drawing.Point(243, 15)
        Me.LblTotalEnc.Name = "LblTotalEnc"
        Me.LblTotalEnc.Size = New System.Drawing.Size(84, 25)
        Me.LblTotalEnc.TabIndex = 65
        Me.LblTotalEnc.Text = "Monto "
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.SDBANCOS.My.Resources.Resources.Total3
        Me.PictureBox3.Location = New System.Drawing.Point(233, 2)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(309, 52)
        Me.PictureBox3.TabIndex = 64
        Me.PictureBox3.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(21, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Beneficiario"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtBeneficiario
        '
        Me.TxtBeneficiario.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBeneficiario.Location = New System.Drawing.Point(127, 113)
        Me.TxtBeneficiario.Name = "TxtBeneficiario"
        Me.TxtBeneficiario.Size = New System.Drawing.Size(397, 21)
        Me.TxtBeneficiario.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(21, 194)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Concepto"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConcepto.Location = New System.Drawing.Point(127, 194)
        Me.TxtConcepto.Multiline = True
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Size = New System.Drawing.Size(397, 63)
        Me.TxtConcepto.TabIndex = 4
        '
        'CmbBanco
        '
        Me.CmbBanco.BackColor = System.Drawing.Color.White
        Me.CmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbBanco.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbBanco.FormattingEnabled = True
        Me.CmbBanco.Location = New System.Drawing.Point(127, 140)
        Me.CmbBanco.Name = "CmbBanco"
        Me.CmbBanco.Size = New System.Drawing.Size(397, 21)
        Me.CmbBanco.TabIndex = 2
        '
        'CmbCuenta
        '
        Me.CmbCuenta.BackColor = System.Drawing.Color.White
        Me.CmbCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbCuenta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCuenta.FormattingEnabled = True
        Me.CmbCuenta.Location = New System.Drawing.Point(127, 167)
        Me.CmbCuenta.Name = "CmbCuenta"
        Me.CmbCuenta.Size = New System.Drawing.Size(179, 21)
        Me.CmbCuenta.TabIndex = 3
        '
        'CmbMoneda
        '
        Me.CmbMoneda.BackColor = System.Drawing.Color.White
        Me.CmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMoneda.Enabled = False
        Me.CmbMoneda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbMoneda.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbMoneda.FormattingEnabled = True
        Me.CmbMoneda.Items.AddRange(New Object() {"COLONES", "DOLARES"})
        Me.CmbMoneda.Location = New System.Drawing.Point(401, 167)
        Me.CmbMoneda.Name = "CmbMoneda"
        Me.CmbMoneda.Size = New System.Drawing.Size(123, 21)
        Me.CmbMoneda.TabIndex = 11
        Me.CmbMoneda.TabStop = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(21, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Banco"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(21, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Cuenta"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(312, 167)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Moneda"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DtpFecha
        '
        Me.DtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.DtpFecha.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFecha.Location = New System.Drawing.Point(401, 82)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(123, 21)
        Me.DtpFecha.TabIndex = 15
        '
        'FrmPagoCheque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(542, 351)
        Me.Controls.Add(Me.DtpFecha)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CmbMoneda)
        Me.Controls.Add(Me.CmbCuenta)
        Me.Controls.Add(Me.CmbBanco)
        Me.Controls.Add(Me.TxtConcepto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtBeneficiario)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PnlPie)
        Me.Controls.Add(Me.PnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPagoCheque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PnlEncabezado.ResumeLayout(False)
        Me.PnlEncabezado.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlPie.ResumeLayout(False)
        Me.PnlPie.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents PnlPie As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtBeneficiario As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents LblMonto As System.Windows.Forms.Label
    Friend WithEvents LblTotalEnc As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbBanco As System.Windows.Forms.ComboBox
    Friend WithEvents CmbCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents CmbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
End Class
