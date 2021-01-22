<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptConsultaMovimientoCuenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptConsultaMovimientoCuenta))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmbAnnioFin = New System.Windows.Forms.ComboBox()
        Me.CmbMesFin = New System.Windows.Forms.ComboBox()
        Me.CmbAnnioIni = New System.Windows.Forms.ComboBox()
        Me.CmbMesIni = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtCuentaFin = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtCuentaIni = New System.Windows.Forms.MaskedTextBox()
        Me.RdbCuentaRango = New System.Windows.Forms.RadioButton()
        Me.RdbCuentaTodo = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ChkOrigen = New System.Windows.Forms.CheckBox()
        Me.CmbOrigen = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ChkTipo = New System.Windows.Forms.CheckBox()
        Me.CmbTipoAsiento = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnImprimir)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(77, 248)
        Me.Panel1.TabIndex = 11
        '
        'BtnImprimir
        '
        Me.BtnImprimir.BackColor = System.Drawing.Color.White
        Me.BtnImprimir.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_F3
        Me.BtnImprimir.Location = New System.Drawing.Point(10, 6)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(57, 72)
        Me.BtnImprimir.TabIndex = 1
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(10, 84)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(57, 72)
        Me.BtnSalir.TabIndex = 2
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmbAnnioFin)
        Me.GroupBox1.Controls.Add(Me.CmbMesFin)
        Me.GroupBox1.Controls.Add(Me.CmbAnnioIni)
        Me.GroupBox1.Controls.Add(Me.CmbMesIni)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TxtCuentaFin)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtCuentaIni)
        Me.GroupBox1.Controls.Add(Me.RdbCuentaRango)
        Me.GroupBox1.Controls.Add(Me.RdbCuentaTodo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ChkOrigen)
        Me.GroupBox1.Controls.Add(Me.CmbOrigen)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ChkTipo)
        Me.GroupBox1.Controls.Add(Me.CmbTipoAsiento)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(84, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 233)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'CmbAnnioFin
        '
        Me.CmbAnnioFin.BackColor = System.Drawing.Color.White
        Me.CmbAnnioFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAnnioFin.FormattingEnabled = True
        Me.CmbAnnioFin.Location = New System.Drawing.Point(229, 52)
        Me.CmbAnnioFin.Name = "CmbAnnioFin"
        Me.CmbAnnioFin.Size = New System.Drawing.Size(97, 21)
        Me.CmbAnnioFin.TabIndex = 29
        '
        'CmbMesFin
        '
        Me.CmbMesFin.BackColor = System.Drawing.Color.White
        Me.CmbMesFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMesFin.FormattingEnabled = True
        Me.CmbMesFin.Location = New System.Drawing.Point(88, 52)
        Me.CmbMesFin.Name = "CmbMesFin"
        Me.CmbMesFin.Size = New System.Drawing.Size(135, 21)
        Me.CmbMesFin.TabIndex = 28
        '
        'CmbAnnioIni
        '
        Me.CmbAnnioIni.BackColor = System.Drawing.Color.White
        Me.CmbAnnioIni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAnnioIni.FormattingEnabled = True
        Me.CmbAnnioIni.Location = New System.Drawing.Point(229, 25)
        Me.CmbAnnioIni.Name = "CmbAnnioIni"
        Me.CmbAnnioIni.Size = New System.Drawing.Size(97, 21)
        Me.CmbAnnioIni.TabIndex = 27
        '
        'CmbMesIni
        '
        Me.CmbMesIni.BackColor = System.Drawing.Color.White
        Me.CmbMesIni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMesIni.FormattingEnabled = True
        Me.CmbMesIni.Location = New System.Drawing.Point(88, 25)
        Me.CmbMesIni.Name = "CmbMesIni"
        Me.CmbMesIni.Size = New System.Drawing.Size(135, 21)
        Me.CmbMesIni.TabIndex = 26
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(19, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 21)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Periodo"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(172, 189)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Hasta"
        '
        'TxtCuentaFin
        '
        Me.TxtCuentaFin.BackColor = System.Drawing.Color.White
        Me.TxtCuentaFin.Enabled = False
        Me.TxtCuentaFin.Location = New System.Drawing.Point(216, 186)
        Me.TxtCuentaFin.Mask = "000-000-000-000-000"
        Me.TxtCuentaFin.Name = "TxtCuentaFin"
        Me.TxtCuentaFin.Size = New System.Drawing.Size(110, 20)
        Me.TxtCuentaFin.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(172, 163)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Desde"
        '
        'TxtCuentaIni
        '
        Me.TxtCuentaIni.BackColor = System.Drawing.Color.White
        Me.TxtCuentaIni.Enabled = False
        Me.TxtCuentaIni.Location = New System.Drawing.Point(216, 160)
        Me.TxtCuentaIni.Mask = "000-000-000-000-000"
        Me.TxtCuentaIni.Name = "TxtCuentaIni"
        Me.TxtCuentaIni.Size = New System.Drawing.Size(110, 20)
        Me.TxtCuentaIni.TabIndex = 21
        '
        'RdbCuentaRango
        '
        Me.RdbCuentaRango.AutoSize = True
        Me.RdbCuentaRango.Location = New System.Drawing.Point(88, 163)
        Me.RdbCuentaRango.Name = "RdbCuentaRango"
        Me.RdbCuentaRango.Size = New System.Drawing.Size(57, 17)
        Me.RdbCuentaRango.TabIndex = 20
        Me.RdbCuentaRango.Text = "Rango"
        Me.RdbCuentaRango.UseVisualStyleBackColor = True
        '
        'RdbCuentaTodo
        '
        Me.RdbCuentaTodo.AutoSize = True
        Me.RdbCuentaTodo.Checked = True
        Me.RdbCuentaTodo.Location = New System.Drawing.Point(88, 140)
        Me.RdbCuentaTodo.Name = "RdbCuentaTodo"
        Me.RdbCuentaTodo.Size = New System.Drawing.Size(55, 17)
        Me.RdbCuentaTodo.TabIndex = 19
        Me.RdbCuentaTodo.TabStop = True
        Me.RdbCuentaTodo.Text = "Todas"
        Me.RdbCuentaTodo.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(19, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 21)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Cuentas"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ChkOrigen
        '
        Me.ChkOrigen.AutoSize = True
        Me.ChkOrigen.Checked = True
        Me.ChkOrigen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkOrigen.Location = New System.Drawing.Point(88, 112)
        Me.ChkOrigen.Name = "ChkOrigen"
        Me.ChkOrigen.Size = New System.Drawing.Size(56, 17)
        Me.ChkOrigen.TabIndex = 17
        Me.ChkOrigen.Text = "Todos"
        Me.ChkOrigen.UseVisualStyleBackColor = True
        '
        'CmbOrigen
        '
        Me.CmbOrigen.BackColor = System.Drawing.Color.White
        Me.CmbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbOrigen.Enabled = False
        Me.CmbOrigen.FormattingEnabled = True
        Me.CmbOrigen.Location = New System.Drawing.Point(150, 110)
        Me.CmbOrigen.Name = "CmbOrigen"
        Me.CmbOrigen.Size = New System.Drawing.Size(176, 21)
        Me.CmbOrigen.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(19, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 21)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Origen"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ChkTipo
        '
        Me.ChkTipo.AutoSize = True
        Me.ChkTipo.Checked = True
        Me.ChkTipo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkTipo.Location = New System.Drawing.Point(88, 85)
        Me.ChkTipo.Name = "ChkTipo"
        Me.ChkTipo.Size = New System.Drawing.Size(56, 17)
        Me.ChkTipo.TabIndex = 14
        Me.ChkTipo.Text = "Todos"
        Me.ChkTipo.UseVisualStyleBackColor = True
        '
        'CmbTipoAsiento
        '
        Me.CmbTipoAsiento.BackColor = System.Drawing.Color.White
        Me.CmbTipoAsiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoAsiento.Enabled = False
        Me.CmbTipoAsiento.FormattingEnabled = True
        Me.CmbTipoAsiento.Location = New System.Drawing.Point(150, 83)
        Me.CmbTipoAsiento.Name = "CmbTipoAsiento"
        Me.CmbTipoAsiento.Size = New System.Drawing.Size(176, 21)
        Me.CmbTipoAsiento.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(19, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 21)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Tipo"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmRptConsultaMovimientoCuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(448, 248)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptConsultaMovimientoCuenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Movimientos por Cuenta"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkOrigen As System.Windows.Forms.CheckBox
    Friend WithEvents CmbOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ChkTipo As System.Windows.Forms.CheckBox
    Friend WithEvents CmbTipoAsiento As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RdbCuentaRango As System.Windows.Forms.RadioButton
    Friend WithEvents RdbCuentaTodo As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCuentaIni As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtCuentaFin As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CmbAnnioIni As System.Windows.Forms.ComboBox
    Friend WithEvents CmbMesIni As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmbAnnioFin As System.Windows.Forms.ComboBox
    Friend WithEvents CmbMesFin As System.Windows.Forms.ComboBox
End Class
