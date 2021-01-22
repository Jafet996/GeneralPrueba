<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantProveedorCuentaDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantProveedorCuentaDetalle))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbBanco = New System.Windows.Forms.ComboBox()
        Me.TxtCuenta = New System.Windows.Forms.TextBox()
        Me.CmbMoneda = New System.Windows.Forms.ComboBox()
        Me.ChkActivo = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnGuardar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(80, 168)
        Me.Panel1.TabIndex = 3
        '
        'BtnGuardar
        '
        Me.BtnGuardar.BackColor = System.Drawing.Color.White
        Me.BtnGuardar.Image = Global.SDBANCOS.My.Resources.Resources.Blue_F3
        Me.BtnGuardar.Location = New System.Drawing.Point(8, 9)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(64, 71)
        Me.BtnGuardar.TabIndex = 13
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnGuardar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.SDBANCOS.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(8, 86)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(64, 71)
        Me.BtnSalir.TabIndex = 9
        Me.BtnSalir.TabStop = False
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(122, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Código"
        '
        'TxtNumero
        '
        Me.TxtNumero.BackColor = System.Drawing.Color.White
        Me.TxtNumero.Location = New System.Drawing.Point(204, 37)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.ReadOnly = True
        Me.TxtNumero.Size = New System.Drawing.Size(100, 20)
        Me.TxtNumero.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(122, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Banco"
        '
        'CmbBanco
        '
        Me.CmbBanco.BackColor = System.Drawing.Color.White
        Me.CmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbBanco.FormattingEnabled = True
        Me.CmbBanco.Location = New System.Drawing.Point(204, 70)
        Me.CmbBanco.Name = "CmbBanco"
        Me.CmbBanco.Size = New System.Drawing.Size(264, 21)
        Me.CmbBanco.TabIndex = 7
        '
        'TxtCuenta
        '
        Me.TxtCuenta.Location = New System.Drawing.Point(204, 98)
        Me.TxtCuenta.Name = "TxtCuenta"
        Me.TxtCuenta.Size = New System.Drawing.Size(264, 20)
        Me.TxtCuenta.TabIndex = 8
        '
        'CmbMoneda
        '
        Me.CmbMoneda.BackColor = System.Drawing.Color.White
        Me.CmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMoneda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbMoneda.FormattingEnabled = True
        Me.CmbMoneda.Items.AddRange(New Object() {"COLONES", "DOLARES"})
        Me.CmbMoneda.Location = New System.Drawing.Point(204, 124)
        Me.CmbMoneda.Name = "CmbMoneda"
        Me.CmbMoneda.Size = New System.Drawing.Size(151, 21)
        Me.CmbMoneda.TabIndex = 9
        '
        'ChkActivo
        '
        Me.ChkActivo.AutoSize = True
        Me.ChkActivo.Checked = True
        Me.ChkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkActivo.Location = New System.Drawing.Point(412, 126)
        Me.ChkActivo.Name = "ChkActivo"
        Me.ChkActivo.Size = New System.Drawing.Size(56, 17)
        Me.ChkActivo.TabIndex = 10
        Me.ChkActivo.Text = "Activo"
        Me.ChkActivo.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(122, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Cuenta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(122, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Moneda"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SDBANCOS.My.Resources.Resources.edit
        Me.PictureBox1.Location = New System.Drawing.Point(474, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'FrmMantProveedorCuentaDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(518, 168)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ChkActivo)
        Me.Controls.Add(Me.CmbMoneda)
        Me.Controls.Add(Me.TxtCuenta)
        Me.Controls.Add(Me.CmbBanco)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtNumero)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantProveedorCuentaDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbBanco As System.Windows.Forms.ComboBox
    Friend WithEvents TxtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents CmbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents ChkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
