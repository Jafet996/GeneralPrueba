<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCambiaMoneda
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCambiaMoneda))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnAplicar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtRecibe = New System.Windows.Forms.TextBox()
        Me.LblRecibe = New System.Windows.Forms.Label()
        Me.LblDevuelve = New System.Windows.Forms.Label()
        Me.TxtDevuelve = New System.Windows.Forms.TextBox()
        Me.LblMontoTipoCambio = New System.Windows.Forms.Label()
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
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(68, 169)
        Me.Panel1.TabIndex = 6
        '
        'BtnAplicar
        '
        Me.BtnAplicar.BackColor = System.Drawing.Color.White
        Me.BtnAplicar.Image = Global.SDCXC.My.Resources.Resources.Blue_F3
        Me.BtnAplicar.Location = New System.Drawing.Point(6, 7)
        Me.BtnAplicar.Name = "BtnAplicar"
        Me.BtnAplicar.Size = New System.Drawing.Size(56, 72)
        Me.BtnAplicar.TabIndex = 1
        Me.BtnAplicar.Text = "Cambiar"
        Me.BtnAplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAplicar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.SDCXC.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(6, 85)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(56, 72)
        Me.BtnSalir.TabIndex = 2
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(262, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "T. Cambio"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtRecibe
        '
        Me.TxtRecibe.Location = New System.Drawing.Point(218, 64)
        Me.TxtRecibe.Name = "TxtRecibe"
        Me.TxtRecibe.Size = New System.Drawing.Size(143, 20)
        Me.TxtRecibe.TabIndex = 8
        '
        'LblRecibe
        '
        Me.LblRecibe.BackColor = System.Drawing.Color.SteelBlue
        Me.LblRecibe.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRecibe.ForeColor = System.Drawing.Color.White
        Me.LblRecibe.Location = New System.Drawing.Point(112, 64)
        Me.LblRecibe.Name = "LblRecibe"
        Me.LblRecibe.Size = New System.Drawing.Size(100, 20)
        Me.LblRecibe.TabIndex = 9
        Me.LblRecibe.Text = "Dólares"
        Me.LblRecibe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblDevuelve
        '
        Me.LblDevuelve.BackColor = System.Drawing.Color.SteelBlue
        Me.LblDevuelve.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDevuelve.ForeColor = System.Drawing.Color.White
        Me.LblDevuelve.Location = New System.Drawing.Point(112, 90)
        Me.LblDevuelve.Name = "LblDevuelve"
        Me.LblDevuelve.Size = New System.Drawing.Size(100, 20)
        Me.LblDevuelve.TabIndex = 10
        Me.LblDevuelve.Text = "Colones"
        Me.LblDevuelve.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtDevuelve
        '
        Me.TxtDevuelve.BackColor = System.Drawing.Color.White
        Me.TxtDevuelve.Location = New System.Drawing.Point(218, 90)
        Me.TxtDevuelve.Name = "TxtDevuelve"
        Me.TxtDevuelve.ReadOnly = True
        Me.TxtDevuelve.Size = New System.Drawing.Size(143, 20)
        Me.TxtDevuelve.TabIndex = 11
        '
        'LblMontoTipoCambio
        '
        Me.LblMontoTipoCambio.AutoSize = True
        Me.LblMontoTipoCambio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMontoTipoCambio.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblMontoTipoCambio.Location = New System.Drawing.Point(368, 13)
        Me.LblMontoTipoCambio.Name = "LblMontoTipoCambio"
        Me.LblMontoTipoCambio.Size = New System.Drawing.Size(45, 13)
        Me.LblMontoTipoCambio.TabIndex = 12
        Me.LblMontoTipoCambio.Text = "555.55"
        '
        'FrmCambiaMoneda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(433, 169)
        Me.Controls.Add(Me.LblMontoTipoCambio)
        Me.Controls.Add(Me.TxtDevuelve)
        Me.Controls.Add(Me.LblDevuelve)
        Me.Controls.Add(Me.LblRecibe)
        Me.Controls.Add(Me.TxtRecibe)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCambiaMoneda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnAplicar As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtRecibe As System.Windows.Forms.TextBox
    Friend WithEvents LblRecibe As System.Windows.Forms.Label
    Friend WithEvents LblDevuelve As System.Windows.Forms.Label
    Friend WithEvents TxtDevuelve As System.Windows.Forms.TextBox
    Friend WithEvents LblMontoTipoCambio As System.Windows.Forms.Label
End Class
