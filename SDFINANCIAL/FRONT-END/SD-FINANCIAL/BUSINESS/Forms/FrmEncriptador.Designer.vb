<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEncriptador
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEncriptador))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtResultado = New System.Windows.Forms.TextBox()
        Me.TxtValor = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RdbEncriptar = New System.Windows.Forms.RadioButton()
        Me.RdbDesencriptar = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Valor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Resultado"
        '
        'TxtResultado
        '
        Me.TxtResultado.Location = New System.Drawing.Point(92, 77)
        Me.TxtResultado.Name = "TxtResultado"
        Me.TxtResultado.Size = New System.Drawing.Size(321, 20)
        Me.TxtResultado.TabIndex = 2
        '
        'TxtValor
        '
        Me.TxtValor.Location = New System.Drawing.Point(92, 38)
        Me.TxtValor.Name = "TxtValor"
        Me.TxtValor.Size = New System.Drawing.Size(321, 20)
        Me.TxtValor.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RdbDesencriptar)
        Me.GroupBox1.Controls.Add(Me.RdbEncriptar)
        Me.GroupBox1.Location = New System.Drawing.Point(34, 119)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(379, 49)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'RdbEncriptar
        '
        Me.RdbEncriptar.AutoSize = True
        Me.RdbEncriptar.Location = New System.Drawing.Point(58, 19)
        Me.RdbEncriptar.Name = "RdbEncriptar"
        Me.RdbEncriptar.Size = New System.Drawing.Size(67, 17)
        Me.RdbEncriptar.TabIndex = 0
        Me.RdbEncriptar.TabStop = True
        Me.RdbEncriptar.Text = "Encriptar"
        Me.RdbEncriptar.UseVisualStyleBackColor = True
        '
        'RdbDesencriptar
        '
        Me.RdbDesencriptar.AutoSize = True
        Me.RdbDesencriptar.Location = New System.Drawing.Point(204, 19)
        Me.RdbDesencriptar.Name = "RdbDesencriptar"
        Me.RdbDesencriptar.Size = New System.Drawing.Size(85, 17)
        Me.RdbDesencriptar.TabIndex = 1
        Me.RdbDesencriptar.TabStop = True
        Me.RdbDesencriptar.Text = "Desencriptar"
        Me.RdbDesencriptar.UseVisualStyleBackColor = True
        '
        'FrmEncriptador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 194)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TxtValor)
        Me.Controls.Add(Me.TxtResultado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEncriptador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmEncriptador"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtResultado As System.Windows.Forms.TextBox
    Friend WithEvents TxtValor As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RdbDesencriptar As System.Windows.Forms.RadioButton
    Friend WithEvents RdbEncriptar As System.Windows.Forms.RadioButton
End Class
