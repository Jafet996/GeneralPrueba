<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCierreProcesoMes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCierreProcesoMes))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnAplicar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblMes = New System.Windows.Forms.Label()
        Me.LblAnnio = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnAplicar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(107, 214)
        Me.Panel1.TabIndex = 1
        '
        'BtnAplicar
        '
        Me.BtnAplicar.BackColor = System.Drawing.Color.White
        Me.BtnAplicar.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_F3
        Me.BtnAplicar.Location = New System.Drawing.Point(9, 13)
        Me.BtnAplicar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAplicar.Name = "BtnAplicar"
        Me.BtnAplicar.Size = New System.Drawing.Size(88, 90)
        Me.BtnAplicar.TabIndex = 6
        Me.BtnAplicar.Text = "Aplicar"
        Me.BtnAplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAplicar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(9, 111)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(88, 90)
        Me.BtnSalir.TabIndex = 4
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(187, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 29)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Periodo"
        '
        'LblMes
        '
        Me.LblMes.BackColor = System.Drawing.Color.White
        Me.LblMes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMes.Location = New System.Drawing.Point(299, 95)
        Me.LblMes.Name = "LblMes"
        Me.LblMes.Size = New System.Drawing.Size(195, 29)
        Me.LblMes.TabIndex = 3
        Me.LblMes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblAnnio
        '
        Me.LblAnnio.BackColor = System.Drawing.Color.White
        Me.LblAnnio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblAnnio.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAnnio.Location = New System.Drawing.Point(500, 95)
        Me.LblAnnio.Name = "LblAnnio"
        Me.LblAnnio.Size = New System.Drawing.Size(87, 29)
        Me.LblAnnio.TabIndex = 4
        Me.LblAnnio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmCierreProcesoMes
        '
        Me.AcceptButton = Me.BtnAplicar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnSalir
        Me.ClientSize = New System.Drawing.Size(716, 214)
        Me.Controls.Add(Me.LblAnnio)
        Me.Controls.Add(Me.LblMes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCierreProcesoMes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cierre de Mes"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnAplicar As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblMes As System.Windows.Forms.Label
    Friend WithEvents LblAnnio As System.Windows.Forms.Label
End Class
