<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGeneraListadoArticulos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGeneraListadoArticulos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblRuta = New System.Windows.Forms.Label()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnRuta = New System.Windows.Forms.Button()
        Me.BtnGenerar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(128, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ruta"
        '
        'LblRuta
        '
        Me.LblRuta.BackColor = System.Drawing.Color.White
        Me.LblRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblRuta.Location = New System.Drawing.Point(164, 58)
        Me.LblRuta.Name = "LblRuta"
        Me.LblRuta.Size = New System.Drawing.Size(415, 23)
        Me.LblRuta.TabIndex = 1
        Me.LblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnSalir
        '
        Me.BtnSalir.Location = New System.Drawing.Point(10, 76)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(75, 58)
        Me.BtnSalir.TabIndex = 2
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'BtnRuta
        '
        Me.BtnRuta.Location = New System.Drawing.Point(585, 58)
        Me.BtnRuta.Name = "BtnRuta"
        Me.BtnRuta.Size = New System.Drawing.Size(25, 23)
        Me.BtnRuta.TabIndex = 3
        Me.BtnRuta.Text = "..."
        Me.BtnRuta.UseVisualStyleBackColor = True
        '
        'BtnGenerar
        '
        Me.BtnGenerar.Location = New System.Drawing.Point(10, 12)
        Me.BtnGenerar.Name = "BtnGenerar"
        Me.BtnGenerar.Size = New System.Drawing.Size(75, 58)
        Me.BtnGenerar.TabIndex = 4
        Me.BtnGenerar.Text = "Generar"
        Me.BtnGenerar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnGenerar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(94, 150)
        Me.Panel1.TabIndex = 5
        '
        'FrmGeneraListadoArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 150)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtnRuta)
        Me.Controls.Add(Me.LblRuta)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGeneraListadoArticulos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Genera Listado Artículos"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblRuta As System.Windows.Forms.Label
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnRuta As System.Windows.Forms.Button
    Friend WithEvents BtnGenerar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
