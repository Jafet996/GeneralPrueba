<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRepTrasladosXArticulo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRepTrasladosXArticulo))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.DtpFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtArticulo = New System.Windows.Forms.TextBox()
        Me.TxtArticuloNombre = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GrpSucursal = New System.Windows.Forms.GroupBox()
        Me.ChkSucusal = New System.Windows.Forms.CheckBox()
        Me.CmbSucursales = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GrpSucursal.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(358, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Hasta"
        '
        'DtpFechaFin
        '
        Me.DtpFechaFin.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaFin.Location = New System.Drawing.Point(399, 22)
        Me.DtpFechaFin.Name = "DtpFechaFin"
        Me.DtpFechaFin.Size = New System.Drawing.Size(95, 20)
        Me.DtpFechaFin.TabIndex = 40
        '
        'DtpFechaIni
        '
        Me.DtpFechaIni.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaIni.Location = New System.Drawing.Point(206, 22)
        Me.DtpFechaIni.Name = "DtpFechaIni"
        Me.DtpFechaIni.Size = New System.Drawing.Size(95, 20)
        Me.DtpFechaIni.TabIndex = 39
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(152, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Desde"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnImprimir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(81, 241)
        Me.Panel1.TabIndex = 30
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Inventario.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(12, 85)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(59, 70)
        Me.BtnSalir.TabIndex = 13
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnImprimir
        '
        Me.BtnImprimir.BackColor = System.Drawing.Color.White
        Me.BtnImprimir.Image = Global.Inventario.My.Resources.Resources.Blue_F3
        Me.BtnImprimir.Location = New System.Drawing.Point(12, 12)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(59, 70)
        Me.BtnImprimir.TabIndex = 12
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.Inventario.My.Resources.Resources.calendar
        Me.PictureBox4.Location = New System.Drawing.Point(104, 22)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 37
        Me.PictureBox4.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtArticulo)
        Me.GroupBox1.Controls.Add(Me.TxtArticuloNombre)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(104, 154)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(390, 75)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(212, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "(Si el artículo selecciona todos los artículos"
        '
        'TxtArticulo
        '
        Me.TxtArticulo.Location = New System.Drawing.Point(9, 19)
        Me.TxtArticulo.MaxLength = 13
        Me.TxtArticulo.Name = "TxtArticulo"
        Me.TxtArticulo.Size = New System.Drawing.Size(121, 20)
        Me.TxtArticulo.TabIndex = 20
        '
        'TxtArticuloNombre
        '
        Me.TxtArticuloNombre.Location = New System.Drawing.Point(136, 19)
        Me.TxtArticuloNombre.MaxLength = 50
        Me.TxtArticuloNombre.Name = "TxtArticuloNombre"
        Me.TxtArticuloNombre.ReadOnly = True
        Me.TxtArticuloNombre.Size = New System.Drawing.Size(238, 20)
        Me.TxtArticuloNombre.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Artículo"
        '
        'GrpSucursal
        '
        Me.GrpSucursal.Controls.Add(Me.CmbSucursales)
        Me.GrpSucursal.Controls.Add(Me.ChkSucusal)
        Me.GrpSucursal.Location = New System.Drawing.Point(104, 76)
        Me.GrpSucursal.Name = "GrpSucursal"
        Me.GrpSucursal.Size = New System.Drawing.Size(390, 75)
        Me.GrpSucursal.TabIndex = 43
        Me.GrpSucursal.TabStop = False
        Me.GrpSucursal.Text = "Sucursal"
        '
        'ChkSucusal
        '
        Me.ChkSucusal.AutoSize = True
        Me.ChkSucusal.Location = New System.Drawing.Point(9, 31)
        Me.ChkSucusal.Name = "ChkSucusal"
        Me.ChkSucusal.Size = New System.Drawing.Size(114, 17)
        Me.ChkSucusal.TabIndex = 0
        Me.ChkSucusal.Text = "Sucursal de origen"
        Me.ChkSucusal.UseVisualStyleBackColor = True
        '
        'CmbSucursales
        '
        Me.CmbSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSucursales.Enabled = False
        Me.CmbSucursales.FormattingEnabled = True
        Me.CmbSucursales.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CmbSucursales.Location = New System.Drawing.Point(136, 31)
        Me.CmbSucursales.Name = "CmbSucursales"
        Me.CmbSucursales.Size = New System.Drawing.Size(238, 21)
        Me.CmbSucursales.TabIndex = 1
        '
        'FrmRepTrasladosXArticulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(517, 241)
        Me.Controls.Add(Me.GrpSucursal)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DtpFechaFin)
        Me.Controls.Add(Me.DtpFechaIni)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRepTrasladosXArticulo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Traslados por Artículo"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GrpSucursal.ResumeLayout(False)
        Me.GrpSucursal.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label7 As Label
    Friend WithEvents DtpFechaFin As DateTimePicker
    Friend WithEvents DtpFechaIni As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtArticulo As TextBox
    Friend WithEvents TxtArticuloNombre As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GrpSucursal As GroupBox
    Friend WithEvents CmbSucursales As ComboBox
    Friend WithEvents ChkSucusal As CheckBox
End Class
