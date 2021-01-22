<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptCambiosPatrimonio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptCambiosPatrimonio))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.CmbAnnioFin = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbMesFin = New System.Windows.Forms.ComboBox()
        Me.CmbAnnioIni = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(77, 168)
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
        'CmbAnnioFin
        '
        Me.CmbAnnioFin.BackColor = System.Drawing.Color.White
        Me.CmbAnnioFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAnnioFin.FormattingEnabled = True
        Me.CmbAnnioFin.Location = New System.Drawing.Point(188, 48)
        Me.CmbAnnioFin.Name = "CmbAnnioFin"
        Me.CmbAnnioFin.Size = New System.Drawing.Size(97, 21)
        Me.CmbAnnioFin.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(110, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 21)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Periodo"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(110, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 21)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Al mes de"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbMesFin
        '
        Me.CmbMesFin.BackColor = System.Drawing.Color.White
        Me.CmbMesFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMesFin.FormattingEnabled = True
        Me.CmbMesFin.Location = New System.Drawing.Point(188, 75)
        Me.CmbMesFin.Name = "CmbMesFin"
        Me.CmbMesFin.Size = New System.Drawing.Size(216, 21)
        Me.CmbMesFin.TabIndex = 17
        '
        'CmbAnnioIni
        '
        Me.CmbAnnioIni.BackColor = System.Drawing.Color.White
        Me.CmbAnnioIni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAnnioIni.FormattingEnabled = True
        Me.CmbAnnioIni.Location = New System.Drawing.Point(307, 48)
        Me.CmbAnnioIni.Name = "CmbAnnioIni"
        Me.CmbAnnioIni.Size = New System.Drawing.Size(97, 21)
        Me.CmbAnnioIni.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(291, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "-"
        '
        'FrmRptCambiosPatrimonio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(446, 168)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmbAnnioIni)
        Me.Controls.Add(Me.CmbMesFin)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CmbAnnioFin)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptCambiosPatrimonio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estado de Cambios en el Patrimonio"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents CmbAnnioFin As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbMesFin As System.Windows.Forms.ComboBox
    Friend WithEvents CmbAnnioIni As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
