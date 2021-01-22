<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSeleccionaTomaFisica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSeleccionaTomaFisica))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnIniciar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbBodega = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblFechaInicio = New System.Windows.Forms.Label()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.LblInfoUsuario = New System.Windows.Forms.Label()
        Me.LblInfoInicio = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnIniciar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(81, 173)
        Me.Panel1.TabIndex = 10
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Inventario.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(11, 85)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(59, 70)
        Me.BtnSalir.TabIndex = 13
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnIniciar
        '
        Me.BtnIniciar.BackColor = System.Drawing.Color.White
        Me.BtnIniciar.Image = Global.Inventario.My.Resources.Resources.Blue_F3
        Me.BtnIniciar.Location = New System.Drawing.Point(11, 12)
        Me.BtnIniciar.Name = "BtnIniciar"
        Me.BtnIniciar.Size = New System.Drawing.Size(59, 70)
        Me.BtnIniciar.TabIndex = 12
        Me.BtnIniciar.Text = "Iniciar"
        Me.BtnIniciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnIniciar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(102, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Bodega"
        '
        'CmbBodega
        '
        Me.CmbBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBodega.FormattingEnabled = True
        Me.CmbBodega.Location = New System.Drawing.Point(156, 38)
        Me.CmbBodega.Name = "CmbBodega"
        Me.CmbBodega.Size = New System.Drawing.Size(288, 21)
        Me.CmbBodega.TabIndex = 29
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Inventario.My.Resources.Resources.box_closed
        Me.PictureBox1.Location = New System.Drawing.Point(463, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'LblFechaInicio
        '
        Me.LblFechaInicio.AutoSize = True
        Me.LblFechaInicio.ForeColor = System.Drawing.Color.Red
        Me.LblFechaInicio.Location = New System.Drawing.Point(153, 85)
        Me.LblFechaInicio.Name = "LblFechaInicio"
        Me.LblFechaInicio.Size = New System.Drawing.Size(39, 13)
        Me.LblFechaInicio.TabIndex = 31
        Me.LblFechaInicio.Text = "Label1"
        '
        'LblUsuario
        '
        Me.LblUsuario.AutoSize = True
        Me.LblUsuario.ForeColor = System.Drawing.Color.Red
        Me.LblUsuario.Location = New System.Drawing.Point(153, 114)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(39, 13)
        Me.LblUsuario.TabIndex = 32
        Me.LblUsuario.Text = "Label1"
        '
        'LblInfoUsuario
        '
        Me.LblInfoUsuario.AutoSize = True
        Me.LblInfoUsuario.ForeColor = System.Drawing.Color.Red
        Me.LblInfoUsuario.Location = New System.Drawing.Point(102, 114)
        Me.LblInfoUsuario.Name = "LblInfoUsuario"
        Me.LblInfoUsuario.Size = New System.Drawing.Size(43, 13)
        Me.LblInfoUsuario.TabIndex = 34
        Me.LblInfoUsuario.Text = "Usuario"
        '
        'LblInfoInicio
        '
        Me.LblInfoInicio.AutoSize = True
        Me.LblInfoInicio.ForeColor = System.Drawing.Color.Red
        Me.LblInfoInicio.Location = New System.Drawing.Point(102, 85)
        Me.LblInfoInicio.Name = "LblInfoInicio"
        Me.LblInfoInicio.Size = New System.Drawing.Size(32, 13)
        Me.LblInfoInicio.TabIndex = 33
        Me.LblInfoInicio.Text = "Inicio"
        '
        'FrmSeleccionaTomaFisica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(505, 173)
        Me.Controls.Add(Me.LblInfoUsuario)
        Me.Controls.Add(Me.LblInfoInicio)
        Me.Controls.Add(Me.LblUsuario)
        Me.Controls.Add(Me.LblFechaInicio)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CmbBodega)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSeleccionaTomaFisica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Toma Fisica"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnIniciar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbBodega As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    Friend WithEvents LblInfoUsuario As System.Windows.Forms.Label
    Friend WithEvents LblInfoInicio As System.Windows.Forms.Label
End Class
