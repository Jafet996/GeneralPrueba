<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRepSaldoXCategoria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRepSaldoXCategoria))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CmbCategoriaIni = New System.Windows.Forms.ComboBox()
        Me.CbkCategoria = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnImprimir)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(81, 168)
        Me.Panel1.TabIndex = 17
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
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
        Me.BtnImprimir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnImprimir.Location = New System.Drawing.Point(12, 12)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(59, 70)
        Me.BtnImprimir.TabIndex = 12
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(28, 309)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Salir"
        '
        'CmbCategoriaIni
        '
        Me.CmbCategoriaIni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCategoriaIni.FormattingEnabled = True
        Me.CmbCategoriaIni.Location = New System.Drawing.Point(221, 61)
        Me.CmbCategoriaIni.Name = "CmbCategoriaIni"
        Me.CmbCategoriaIni.Size = New System.Drawing.Size(254, 21)
        Me.CmbCategoriaIni.TabIndex = 9
        '
        'CbkCategoria
        '
        Me.CbkCategoria.AutoSize = True
        Me.CbkCategoria.Checked = True
        Me.CbkCategoria.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CbkCategoria.Location = New System.Drawing.Point(125, 61)
        Me.CbkCategoria.Name = "CbkCategoria"
        Me.CbkCategoria.Size = New System.Drawing.Size(76, 17)
        Me.CbkCategoria.TabIndex = 18
        Me.CbkCategoria.Text = "Categoría "
        Me.CbkCategoria.UseVisualStyleBackColor = True
        '
        'FrmRepSaldoXCategoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(521, 168)
        Me.Controls.Add(Me.CbkCategoria)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CmbCategoriaIni)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmRepSaldoXCategoria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saldos por Categoría"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents CmbCategoriaIni As ComboBox
    Friend WithEvents CbkCategoria As CheckBox
End Class
