<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPregunta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPregunta))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblPregunta = New System.Windows.Forms.Label()
        Me.BtnSI = New System.Windows.Forms.Button()
        Me.BtnNO = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.LblPregunta)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(634, 147)
        Me.Panel1.TabIndex = 1
        '
        'LblPregunta
        '
        Me.LblPregunta.BackColor = System.Drawing.Color.White
        Me.LblPregunta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblPregunta.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPregunta.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblPregunta.Location = New System.Drawing.Point(0, 0)
        Me.LblPregunta.Name = "LblPregunta"
        Me.LblPregunta.Size = New System.Drawing.Size(634, 147)
        Me.LblPregunta.TabIndex = 0
        Me.LblPregunta.Text = "Pregunta"
        Me.LblPregunta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnSI
        '
        Me.BtnSI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSI.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSI.ForeColor = System.Drawing.Color.White
        Me.BtnSI.Location = New System.Drawing.Point(367, 168)
        Me.BtnSI.Name = "BtnSI"
        Me.BtnSI.Size = New System.Drawing.Size(141, 110)
        Me.BtnSI.TabIndex = 2
        Me.BtnSI.Text = "SI"
        Me.BtnSI.UseVisualStyleBackColor = True
        '
        'BtnNO
        '
        Me.BtnNO.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnNO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNO.ForeColor = System.Drawing.Color.White
        Me.BtnNO.Location = New System.Drawing.Point(130, 168)
        Me.BtnNO.Name = "BtnNO"
        Me.BtnNO.Size = New System.Drawing.Size(141, 110)
        Me.BtnNO.TabIndex = 3
        Me.BtnNO.Text = "NO"
        Me.BtnNO.UseVisualStyleBackColor = True
        '
        'FrmPregunta
        '
        Me.AcceptButton = Me.BtnSI
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.CancelButton = Me.BtnNO
        Me.ClientSize = New System.Drawing.Size(634, 298)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnNO)
        Me.Controls.Add(Me.BtnSI)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPregunta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents LblPregunta As Windows.Forms.Label
    Friend WithEvents BtnSI As Windows.Forms.Button
    Friend WithEvents BtnNO As Windows.Forms.Button
End Class
