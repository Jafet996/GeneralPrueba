<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReimpresionSalida
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReimpresionSalida))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.ChkResumido = New System.Windows.Forms.CheckBox()
        Me.CmbCierres = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CmbSalida = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnImprimir)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(93, 134)
        Me.Panel1.TabIndex = 7
        '
        'BtnImprimir
        '
        Me.BtnImprimir.BackColor = System.Drawing.Color.White
        Me.BtnImprimir.Location = New System.Drawing.Point(9, 11)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(75, 53)
        Me.BtnImprimir.TabIndex = 3
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Location = New System.Drawing.Point(9, 70)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(75, 53)
        Me.BtnSalir.TabIndex = 2
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'ChkResumido
        '
        Me.ChkResumido.AutoSize = True
        Me.ChkResumido.Checked = True
        Me.ChkResumido.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkResumido.Location = New System.Drawing.Point(133, 106)
        Me.ChkResumido.Name = "ChkResumido"
        Me.ChkResumido.Size = New System.Drawing.Size(73, 17)
        Me.ChkResumido.TabIndex = 11
        Me.ChkResumido.Text = "Resumido"
        Me.ChkResumido.UseVisualStyleBackColor = True
        Me.ChkResumido.Visible = False
        '
        'CmbCierres
        '
        Me.CmbCierres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCierres.FormattingEnabled = True
        Me.CmbCierres.Location = New System.Drawing.Point(180, 28)
        Me.CmbCierres.Name = "CmbCierres"
        Me.CmbCierres.Size = New System.Drawing.Size(202, 21)
        Me.CmbCierres.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(130, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Cierre #"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PuntoVenta.My.Resources.Resources.printer2
        Me.PictureBox1.Location = New System.Drawing.Point(350, 90)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'CmbSalida
        '
        Me.CmbSalida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSalida.FormattingEnabled = True
        Me.CmbSalida.Location = New System.Drawing.Point(180, 55)
        Me.CmbSalida.Name = "CmbSalida"
        Me.CmbSalida.Size = New System.Drawing.Size(202, 21)
        Me.CmbSalida.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(130, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Salida #"
        '
        'FrmReimpresionSalida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(435, 134)
        Me.Controls.Add(Me.CmbSalida)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ChkResumido)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CmbCierres)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReimpresionSalida"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmReimpresionSalida"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents ChkResumido As CheckBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CmbCierres As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CmbSalida As ComboBox
    Friend WithEvents Label2 As Label
End Class
