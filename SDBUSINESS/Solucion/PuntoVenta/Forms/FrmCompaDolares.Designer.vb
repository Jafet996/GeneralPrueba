<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCompaDolares
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCompaDolares))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnAplicar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.LblTipoCambio = New System.Windows.Forms.Label()
        Me.LblDevuelve = New System.Windows.Forms.Label()
        Me.LblRecibe = New System.Windows.Forms.Label()
        Me.TxtDolares = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblColones = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnAplicar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(93, 219)
        Me.Panel1.TabIndex = 13
        '
        'BtnAplicar
        '
        Me.BtnAplicar.BackColor = System.Drawing.Color.White
        Me.BtnAplicar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnAplicar.Location = New System.Drawing.Point(12, 12)
        Me.BtnAplicar.Name = "BtnAplicar"
        Me.BtnAplicar.Size = New System.Drawing.Size(68, 72)
        Me.BtnAplicar.TabIndex = 3
        Me.BtnAplicar.Text = "Cambiar"
        Me.BtnAplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAplicar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(12, 90)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(68, 72)
        Me.BtnSalir.TabIndex = 4
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'LblTipoCambio
        '
        Me.LblTipoCambio.BackColor = System.Drawing.Color.White
        Me.LblTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblTipoCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipoCambio.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblTipoCambio.Location = New System.Drawing.Point(289, 40)
        Me.LblTipoCambio.Name = "LblTipoCambio"
        Me.LblTipoCambio.Size = New System.Drawing.Size(171, 35)
        Me.LblTipoCambio.TabIndex = 19
        Me.LblTipoCambio.Text = "555.55"
        Me.LblTipoCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblDevuelve
        '
        Me.LblDevuelve.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.LblDevuelve.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDevuelve.ForeColor = System.Drawing.Color.White
        Me.LblDevuelve.Location = New System.Drawing.Point(154, 131)
        Me.LblDevuelve.Name = "LblDevuelve"
        Me.LblDevuelve.Size = New System.Drawing.Size(129, 35)
        Me.LblDevuelve.TabIndex = 17
        Me.LblDevuelve.Text = "Colones"
        Me.LblDevuelve.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblRecibe
        '
        Me.LblRecibe.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.LblRecibe.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRecibe.ForeColor = System.Drawing.Color.White
        Me.LblRecibe.Location = New System.Drawing.Point(154, 85)
        Me.LblRecibe.Name = "LblRecibe"
        Me.LblRecibe.Size = New System.Drawing.Size(129, 35)
        Me.LblRecibe.TabIndex = 16
        Me.LblRecibe.Text = "Dólares"
        Me.LblRecibe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtDolares
        '
        Me.TxtDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDolares.ForeColor = System.Drawing.Color.Green
        Me.TxtDolares.Location = New System.Drawing.Point(289, 85)
        Me.TxtDolares.Name = "TxtDolares"
        Me.TxtDolares.Size = New System.Drawing.Size(171, 35)
        Me.TxtDolares.TabIndex = 0
        Me.TxtDolares.Text = "0.00"
        Me.TxtDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(154, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 36)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "T. Cambio"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblColones
        '
        Me.LblColones.BackColor = System.Drawing.Color.White
        Me.LblColones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblColones.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblColones.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblColones.Location = New System.Drawing.Point(289, 131)
        Me.LblColones.Name = "LblColones"
        Me.LblColones.Size = New System.Drawing.Size(171, 35)
        Me.LblColones.TabIndex = 20
        Me.LblColones.Text = "0.00"
        Me.LblColones.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmCompaDolares
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnSalir
        Me.ClientSize = New System.Drawing.Size(526, 219)
        Me.Controls.Add(Me.LblColones)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LblTipoCambio)
        Me.Controls.Add(Me.LblDevuelve)
        Me.Controls.Add(Me.LblRecibe)
        Me.Controls.Add(Me.TxtDolares)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCompaDolares"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compa Dólares"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnAplicar As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents LblTipoCambio As Label
    Friend WithEvents LblDevuelve As Label
    Friend WithEvents LblRecibe As Label
    Friend WithEvents TxtDolares As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LblColones As Label
End Class
