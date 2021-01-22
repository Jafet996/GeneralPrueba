<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTomaFisicaAplica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTomaFisicaAplica))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnAplicar = New System.Windows.Forms.Button()
        Me.PnlBodegas = New System.Windows.Forms.Panel()
        Me.LblBodegaNombre = New System.Windows.Forms.Label()
        Me.LblBodega = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.PnlBodegas.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnAplicar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(81, 169)
        Me.Panel1.TabIndex = 11
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
        'BtnAplicar
        '
        Me.BtnAplicar.BackColor = System.Drawing.Color.White
        Me.BtnAplicar.Image = Global.Inventario.My.Resources.Resources.Blue_F3
        Me.BtnAplicar.Location = New System.Drawing.Point(11, 12)
        Me.BtnAplicar.Name = "BtnAplicar"
        Me.BtnAplicar.Size = New System.Drawing.Size(59, 70)
        Me.BtnAplicar.TabIndex = 12
        Me.BtnAplicar.Text = "Aplicar"
        Me.BtnAplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAplicar.UseVisualStyleBackColor = False
        '
        'PnlBodegas
        '
        Me.PnlBodegas.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.PnlBodegas.Controls.Add(Me.LblBodegaNombre)
        Me.PnlBodegas.Controls.Add(Me.LblBodega)
        Me.PnlBodegas.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlBodegas.ForeColor = System.Drawing.Color.White
        Me.PnlBodegas.Location = New System.Drawing.Point(81, 0)
        Me.PnlBodegas.Name = "PnlBodegas"
        Me.PnlBodegas.Size = New System.Drawing.Size(421, 44)
        Me.PnlBodegas.TabIndex = 12
        '
        'LblBodegaNombre
        '
        Me.LblBodegaNombre.AutoSize = True
        Me.LblBodegaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBodegaNombre.ForeColor = System.Drawing.Color.White
        Me.LblBodegaNombre.Location = New System.Drawing.Point(95, 13)
        Me.LblBodegaNombre.Name = "LblBodegaNombre"
        Me.LblBodegaNombre.Size = New System.Drawing.Size(133, 20)
        Me.LblBodegaNombre.TabIndex = 2
        Me.LblBodegaNombre.Text = "BodegaNombre"
        '
        'LblBodega
        '
        Me.LblBodega.AutoSize = True
        Me.LblBodega.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBodega.ForeColor = System.Drawing.Color.White
        Me.LblBodega.Location = New System.Drawing.Point(18, 13)
        Me.LblBodega.Name = "LblBodega"
        Me.LblBodega.Size = New System.Drawing.Size(71, 20)
        Me.LblBodega.TabIndex = 1
        Me.LblBodega.Text = "Bodega"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(111, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(366, 29)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Desea aplicar la Toma Física?"
        '
        'FrmAplicaTomaFisica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(502, 169)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PnlBodegas)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAplicaTomaFisica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aplicar Toma Física"
        Me.Panel1.ResumeLayout(False)
        Me.PnlBodegas.ResumeLayout(False)
        Me.PnlBodegas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnAplicar As System.Windows.Forms.Button
    Friend WithEvents PnlBodegas As System.Windows.Forms.Panel
    Friend WithEvents LblBodegaNombre As System.Windows.Forms.Label
    Friend WithEvents LblBodega As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
