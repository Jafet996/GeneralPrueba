<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptEstadoResultados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptEstadoResultados))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.GbPeriodo = New System.Windows.Forms.GroupBox()
        Me.CmbAnnio = New System.Windows.Forms.ComboBox()
        Me.CmbMes = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ChkDetallado = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.GbPeriodo.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(77, 167)
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
        'GbPeriodo
        '
        Me.GbPeriodo.Controls.Add(Me.ChkDetallado)
        Me.GbPeriodo.Controls.Add(Me.CmbAnnio)
        Me.GbPeriodo.Controls.Add(Me.CmbMes)
        Me.GbPeriodo.Controls.Add(Me.Label7)
        Me.GbPeriodo.Location = New System.Drawing.Point(83, 6)
        Me.GbPeriodo.Name = "GbPeriodo"
        Me.GbPeriodo.Size = New System.Drawing.Size(337, 150)
        Me.GbPeriodo.TabIndex = 15
        Me.GbPeriodo.TabStop = False
        '
        'CmbAnnio
        '
        Me.CmbAnnio.BackColor = System.Drawing.Color.White
        Me.CmbAnnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAnnio.FormattingEnabled = True
        Me.CmbAnnio.Location = New System.Drawing.Point(223, 60)
        Me.CmbAnnio.Name = "CmbAnnio"
        Me.CmbAnnio.Size = New System.Drawing.Size(97, 21)
        Me.CmbAnnio.TabIndex = 4
        '
        'CmbMes
        '
        Me.CmbMes.BackColor = System.Drawing.Color.White
        Me.CmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMes.FormattingEnabled = True
        Me.CmbMes.Location = New System.Drawing.Point(85, 60)
        Me.CmbMes.Name = "CmbMes"
        Me.CmbMes.Size = New System.Drawing.Size(132, 21)
        Me.CmbMes.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(16, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 21)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Periodo"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ChkDetallado
        '
        Me.ChkDetallado.AutoSize = True
        Me.ChkDetallado.Location = New System.Drawing.Point(85, 88)
        Me.ChkDetallado.Name = "ChkDetallado"
        Me.ChkDetallado.Size = New System.Drawing.Size(71, 17)
        Me.ChkDetallado.TabIndex = 5
        Me.ChkDetallado.Text = "Detallado"
        Me.ChkDetallado.UseVisualStyleBackColor = True
        '
        'FrmRptEstadoResultados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(429, 167)
        Me.Controls.Add(Me.GbPeriodo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptEstadoResultados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Estado de Resultados"
        Me.Panel1.ResumeLayout(False)
        Me.GbPeriodo.ResumeLayout(False)
        Me.GbPeriodo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents GbPeriodo As System.Windows.Forms.GroupBox
    Friend WithEvents CmbAnnio As System.Windows.Forms.ComboBox
    Friend WithEvents CmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ChkDetallado As System.Windows.Forms.CheckBox
End Class
