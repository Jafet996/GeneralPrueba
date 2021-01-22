<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRepDiferencias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRepDiferencias))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.TxtMonto = New System.Windows.Forms.TextBox()
        Me.GbDiferencias = New System.Windows.Forms.GroupBox()
        Me.PnlBodegas = New System.Windows.Forms.Panel()
        Me.LblBodegaNombre = New System.Windows.Forms.Label()
        Me.LblBodega = New System.Windows.Forms.Label()
        Me.RdbMonto = New System.Windows.Forms.RadioButton()
        Me.RdbCantidad = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.GbDiferencias.SuspendLayout()
        Me.PnlBodegas.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(78, 237)
        Me.Panel1.TabIndex = 10
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Inventario.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(9, 85)
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
        Me.BtnImprimir.Location = New System.Drawing.Point(9, 12)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(59, 70)
        Me.BtnImprimir.TabIndex = 12
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'TxtMonto
        '
        Me.TxtMonto.Location = New System.Drawing.Point(219, 55)
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Size = New System.Drawing.Size(139, 20)
        Me.TxtMonto.TabIndex = 32
        '
        'GbDiferencias
        '
        Me.GbDiferencias.Controls.Add(Me.RdbCantidad)
        Me.GbDiferencias.Controls.Add(Me.RdbMonto)
        Me.GbDiferencias.Controls.Add(Me.TxtMonto)
        Me.GbDiferencias.Location = New System.Drawing.Point(100, 71)
        Me.GbDiferencias.Name = "GbDiferencias"
        Me.GbDiferencias.Size = New System.Drawing.Size(406, 134)
        Me.GbDiferencias.TabIndex = 33
        Me.GbDiferencias.TabStop = False
        Me.GbDiferencias.Text = "Diferencias Mayor o Igual"
        '
        'PnlBodegas
        '
        Me.PnlBodegas.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.PnlBodegas.Controls.Add(Me.LblBodegaNombre)
        Me.PnlBodegas.Controls.Add(Me.LblBodega)
        Me.PnlBodegas.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlBodegas.ForeColor = System.Drawing.Color.White
        Me.PnlBodegas.Location = New System.Drawing.Point(78, 0)
        Me.PnlBodegas.Name = "PnlBodegas"
        Me.PnlBodegas.Size = New System.Drawing.Size(448, 44)
        Me.PnlBodegas.TabIndex = 34
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
        'RdbMonto
        '
        Me.RdbMonto.AutoSize = True
        Me.RdbMonto.Checked = True
        Me.RdbMonto.Location = New System.Drawing.Point(21, 41)
        Me.RdbMonto.Name = "RdbMonto"
        Me.RdbMonto.Size = New System.Drawing.Size(55, 17)
        Me.RdbMonto.TabIndex = 35
        Me.RdbMonto.TabStop = True
        Me.RdbMonto.Text = "Monto"
        Me.RdbMonto.UseVisualStyleBackColor = True
        '
        'RdbCantidad
        '
        Me.RdbCantidad.AutoSize = True
        Me.RdbCantidad.Location = New System.Drawing.Point(21, 67)
        Me.RdbCantidad.Name = "RdbCantidad"
        Me.RdbCantidad.Size = New System.Drawing.Size(67, 17)
        Me.RdbCantidad.TabIndex = 36
        Me.RdbCantidad.Text = "Cantidad"
        Me.RdbCantidad.UseVisualStyleBackColor = True
        '
        'FrmRepDiferencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(526, 237)
        Me.Controls.Add(Me.PnlBodegas)
        Me.Controls.Add(Me.GbDiferencias)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRepDiferencias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Diferencias por Bodega"
        Me.Panel1.ResumeLayout(False)
        Me.GbDiferencias.ResumeLayout(False)
        Me.GbDiferencias.PerformLayout()
        Me.PnlBodegas.ResumeLayout(False)
        Me.PnlBodegas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents TxtMonto As System.Windows.Forms.TextBox
    Friend WithEvents GbDiferencias As System.Windows.Forms.GroupBox
    Friend WithEvents PnlBodegas As System.Windows.Forms.Panel
    Friend WithEvents LblBodegaNombre As System.Windows.Forms.Label
    Friend WithEvents LblBodega As System.Windows.Forms.Label
    Friend WithEvents RdbCantidad As System.Windows.Forms.RadioButton
    Friend WithEvents RdbMonto As System.Windows.Forms.RadioButton
End Class
