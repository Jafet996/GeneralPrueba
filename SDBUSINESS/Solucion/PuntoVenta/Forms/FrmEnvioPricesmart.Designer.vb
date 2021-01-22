<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEnvioPricesmart
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEnvioPricesmart))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtRuta = New System.Windows.Forms.TextBox()
        Me.BtnRuta = New System.Windows.Forms.Button()
        Me.BtnConsultaAcuse = New System.Windows.Forms.Button()
        Me.BtnAcuse = New System.Windows.Forms.Button()
        Me.TxtAcuse = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnAceptar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(80, 187)
        Me.Panel1.TabIndex = 6
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.White
        Me.BtnAceptar.Enabled = False
        Me.BtnAceptar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnAceptar.Location = New System.Drawing.Point(10, 21)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(60, 76)
        Me.BtnAceptar.TabIndex = 6
        Me.BtnAceptar.Text = "&Enviar"
        Me.BtnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(10, 107)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(60, 71)
        Me.BtnSalir.TabIndex = 7
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Archivo"
        '
        'TxtRuta
        '
        Me.TxtRuta.Location = New System.Drawing.Point(77, 17)
        Me.TxtRuta.Name = "TxtRuta"
        Me.TxtRuta.ReadOnly = True
        Me.TxtRuta.Size = New System.Drawing.Size(343, 20)
        Me.TxtRuta.TabIndex = 8
        '
        'BtnRuta
        '
        Me.BtnRuta.Location = New System.Drawing.Point(426, 15)
        Me.BtnRuta.Name = "BtnRuta"
        Me.BtnRuta.Size = New System.Drawing.Size(26, 23)
        Me.BtnRuta.TabIndex = 9
        Me.BtnRuta.Text = "..."
        Me.BtnRuta.UseVisualStyleBackColor = True
        '
        'BtnConsultaAcuse
        '
        Me.BtnConsultaAcuse.Location = New System.Drawing.Point(12, 53)
        Me.BtnConsultaAcuse.Name = "BtnConsultaAcuse"
        Me.BtnConsultaAcuse.Size = New System.Drawing.Size(440, 32)
        Me.BtnConsultaAcuse.TabIndex = 10
        Me.BtnConsultaAcuse.Text = "Consultar recepción del documento"
        Me.BtnConsultaAcuse.UseVisualStyleBackColor = True
        '
        'BtnAcuse
        '
        Me.BtnAcuse.Location = New System.Drawing.Point(426, 17)
        Me.BtnAcuse.Name = "BtnAcuse"
        Me.BtnAcuse.Size = New System.Drawing.Size(26, 23)
        Me.BtnAcuse.TabIndex = 13
        Me.BtnAcuse.Text = "..."
        Me.BtnAcuse.UseVisualStyleBackColor = True
        '
        'TxtAcuse
        '
        Me.TxtAcuse.Location = New System.Drawing.Point(77, 19)
        Me.TxtAcuse.Name = "TxtAcuse"
        Me.TxtAcuse.ReadOnly = True
        Me.TxtAcuse.Size = New System.Drawing.Size(343, 20)
        Me.TxtAcuse.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Archivo"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtRuta)
        Me.GroupBox1.Controls.Add(Me.BtnRuta)
        Me.GroupBox1.Controls.Add(Me.BtnConsultaAcuse)
        Me.GroupBox1.Location = New System.Drawing.Point(101, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(469, 100)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Documento"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtAcuse)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.BtnAcuse)
        Me.GroupBox2.Location = New System.Drawing.Point(101, 118)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(469, 57)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Acuse "
        '
        'FrmEnvioPricesmart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(582, 187)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEnvioPricesmart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envío Facturas Pricesmart"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnAceptar As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtRuta As TextBox
    Friend WithEvents BtnRuta As Button
    Friend WithEvents BtnConsultaAcuse As Button
    Friend WithEvents BtnAcuse As Button
    Friend WithEvents TxtAcuse As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
End Class
