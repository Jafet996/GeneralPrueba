<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptFlujoEfeectivo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptFlujoEfeectivo))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmbAnnioFin = New System.Windows.Forms.ComboBox()
        Me.CmbMesFin = New System.Windows.Forms.ComboBox()
        Me.CmbAnnioIni = New System.Windows.Forms.ComboBox()
        Me.CmbMesIni = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
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
        Me.Panel1.Size = New System.Drawing.Size(77, 163)
        Me.Panel1.TabIndex = 12
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
        Me.GroupBox1.Location = New System.Drawing.Point(86, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 150)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'CmbAnnioFin
        '
        Me.CmbAnnioFin.BackColor = System.Drawing.Color.White
        Me.CmbAnnioFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAnnioFin.FormattingEnabled = True
        Me.CmbAnnioFin.Location = New System.Drawing.Point(229, 61)
        Me.CmbAnnioFin.Name = "CmbAnnioFin"
        Me.CmbAnnioFin.Size = New System.Drawing.Size(97, 21)
        Me.CmbAnnioFin.TabIndex = 29
        '
        'CmbMesFin
        '
        Me.CmbMesFin.BackColor = System.Drawing.Color.White
        Me.CmbMesFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMesFin.FormattingEnabled = True
        Me.CmbMesFin.Location = New System.Drawing.Point(88, 61)
        Me.CmbMesFin.Name = "CmbMesFin"
        Me.CmbMesFin.Size = New System.Drawing.Size(135, 21)
        Me.CmbMesFin.TabIndex = 28
        '
        'CmbAnnioIni
        '
        Me.CmbAnnioIni.BackColor = System.Drawing.Color.White
        Me.CmbAnnioIni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAnnioIni.FormattingEnabled = True
        Me.CmbAnnioIni.Location = New System.Drawing.Point(229, 34)
        Me.CmbAnnioIni.Name = "CmbAnnioIni"
        Me.CmbAnnioIni.Size = New System.Drawing.Size(97, 21)
        Me.CmbAnnioIni.TabIndex = 27
        '
        'CmbMesIni
        '
        Me.CmbMesIni.BackColor = System.Drawing.Color.White
        Me.CmbMesIni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMesIni.FormattingEnabled = True
        Me.CmbMesIni.Location = New System.Drawing.Point(88, 34)
        Me.CmbMesIni.Name = "CmbMesIni"
        Me.CmbMesIni.Size = New System.Drawing.Size(135, 21)
        Me.CmbMesIni.TabIndex = 26
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(19, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 21)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Periodo"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmRptFlujoEfeectivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(448, 163)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptFlujoEfeectivo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estado de Flujo de Efectivo"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbAnnioFin As System.Windows.Forms.ComboBox
    Friend WithEvents CmbMesFin As System.Windows.Forms.ComboBox
    Friend WithEvents CmbAnnioIni As System.Windows.Forms.ComboBox
    Friend WithEvents CmbMesIni As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
