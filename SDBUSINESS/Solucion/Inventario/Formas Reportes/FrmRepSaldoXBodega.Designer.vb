<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRepSaldoXBodega
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRepSaldoXBodega))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmbSucursal = New System.Windows.Forms.ComboBox()
        Me.CmbBodega = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CkSaldos = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnImprimir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(81, 157)
        Me.Panel1.TabIndex = 9
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Inventario.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(11, 79)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(59, 70)
        Me.BtnSalir.TabIndex = 13
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnImprimir
        '
        Me.BtnImprimir.BackColor = System.Drawing.Color.White
        Me.BtnImprimir.Image = Global.Inventario.My.Resources.Resources.Blue_F3
        Me.BtnImprimir.Location = New System.Drawing.Point(11, 6)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(59, 70)
        Me.BtnImprimir.TabIndex = 12
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CkSaldos)
        Me.GroupBox1.Controls.Add(Me.CmbSucursal)
        Me.GroupBox1.Controls.Add(Me.CmbBodega)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(87, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(422, 137)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'CmbSucursal
        '
        Me.CmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSucursal.FormattingEnabled = True
        Me.CmbSucursal.Location = New System.Drawing.Point(73, 43)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(333, 21)
        Me.CmbSucursal.TabIndex = 12
        '
        'CmbBodega
        '
        Me.CmbBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBodega.FormattingEnabled = True
        Me.CmbBodega.Location = New System.Drawing.Point(73, 70)
        Me.CmbBodega.Name = "CmbBodega"
        Me.CmbBodega.Size = New System.Drawing.Size(333, 21)
        Me.CmbBodega.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Bodega"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Sucursal"
        '
        'CkSaldos
        '
        Me.CkSaldos.AutoSize = True
        Me.CkSaldos.Location = New System.Drawing.Point(266, 114)
        Me.CkSaldos.Name = "CkSaldos"
        Me.CkSaldos.Size = New System.Drawing.Size(109, 17)
        Me.CkSaldos.TabIndex = 15
        Me.CkSaldos.Text = "Saldos Negativos"
        Me.CkSaldos.UseVisualStyleBackColor = True
        '
        'FrmRepSaldoXBodega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(517, 157)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRepSaldoXBodega"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Saldo por Bodega"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents CmbBodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CkSaldos As CheckBox
End Class
