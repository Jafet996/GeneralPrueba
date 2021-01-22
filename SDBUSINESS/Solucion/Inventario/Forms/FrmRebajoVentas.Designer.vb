<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRebajoVentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRebajoVentas))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.PnlBodegas = New System.Windows.Forms.Panel()
        Me.LblBodegaNombre = New System.Windows.Forms.Label()
        Me.LblBodega = New System.Windows.Forms.Label()
        Me.TxtArticulo = New System.Windows.Forms.TextBox()
        Me.TxtArticuloNombre = New System.Windows.Forms.TextBox()
        Me.PnlDetalle = New System.Windows.Forms.Panel()
        Me.LblFisicoActual = New System.Windows.Forms.Label()
        Me.TxtFisicoActual = New System.Windows.Forms.TextBox()
        Me.LblFisico = New System.Windows.Forms.Label()
        Me.BtnAplicar = New System.Windows.Forms.Button()
        Me.TxtFisico = New System.Windows.Forms.TextBox()
        Me.LblArticulo = New System.Windows.Forms.Label()
        Me.BtnAutomatico = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.PnlBodegas.SuspendLayout()
        Me.PnlDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnAutomatico)
        Me.Panel1.Controls.Add(Me.BtnLimpiar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(113, 286)
        Me.Panel1.TabIndex = 4
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.BackColor = System.Drawing.Color.White
        Me.BtnLimpiar.Enabled = False
        Me.BtnLimpiar.Location = New System.Drawing.Point(7, 15)
        Me.BtnLimpiar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(100, 47)
        Me.BtnLimpiar.TabIndex = 9
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Location = New System.Drawing.Point(7, 145)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(100, 47)
        Me.BtnSalir.TabIndex = 10
        Me.BtnSalir.TabStop = False
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'PnlBodegas
        '
        Me.PnlBodegas.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.PnlBodegas.Controls.Add(Me.LblBodegaNombre)
        Me.PnlBodegas.Controls.Add(Me.LblBodega)
        Me.PnlBodegas.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlBodegas.ForeColor = System.Drawing.Color.White
        Me.PnlBodegas.Location = New System.Drawing.Point(113, 0)
        Me.PnlBodegas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PnlBodegas.Name = "PnlBodegas"
        Me.PnlBodegas.Size = New System.Drawing.Size(680, 54)
        Me.PnlBodegas.TabIndex = 5
        '
        'LblBodegaNombre
        '
        Me.LblBodegaNombre.AutoSize = True
        Me.LblBodegaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBodegaNombre.ForeColor = System.Drawing.Color.White
        Me.LblBodegaNombre.Location = New System.Drawing.Point(127, 16)
        Me.LblBodegaNombre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBodegaNombre.Name = "LblBodegaNombre"
        Me.LblBodegaNombre.Size = New System.Drawing.Size(161, 25)
        Me.LblBodegaNombre.TabIndex = 2
        Me.LblBodegaNombre.Text = "BodegaNombre"
        '
        'LblBodega
        '
        Me.LblBodega.AutoSize = True
        Me.LblBodega.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBodega.ForeColor = System.Drawing.Color.White
        Me.LblBodega.Location = New System.Drawing.Point(24, 16)
        Me.LblBodega.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBodega.Name = "LblBodega"
        Me.LblBodega.Size = New System.Drawing.Size(86, 25)
        Me.LblBodega.TabIndex = 1
        Me.LblBodega.Text = "Bodega"
        '
        'TxtArticulo
        '
        Me.TxtArticulo.Location = New System.Drawing.Point(199, 81)
        Me.TxtArticulo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtArticulo.MaxLength = 13
        Me.TxtArticulo.Name = "TxtArticulo"
        Me.TxtArticulo.Size = New System.Drawing.Size(143, 22)
        Me.TxtArticulo.TabIndex = 22
        '
        'TxtArticuloNombre
        '
        Me.TxtArticuloNombre.Location = New System.Drawing.Point(351, 81)
        Me.TxtArticuloNombre.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtArticuloNombre.MaxLength = 50
        Me.TxtArticuloNombre.Name = "TxtArticuloNombre"
        Me.TxtArticuloNombre.ReadOnly = True
        Me.TxtArticuloNombre.Size = New System.Drawing.Size(407, 22)
        Me.TxtArticuloNombre.TabIndex = 23
        '
        'PnlDetalle
        '
        Me.PnlDetalle.Controls.Add(Me.LblFisicoActual)
        Me.PnlDetalle.Controls.Add(Me.TxtFisicoActual)
        Me.PnlDetalle.Controls.Add(Me.LblFisico)
        Me.PnlDetalle.Controls.Add(Me.BtnAplicar)
        Me.PnlDetalle.Controls.Add(Me.TxtFisico)
        Me.PnlDetalle.Enabled = False
        Me.PnlDetalle.Location = New System.Drawing.Point(136, 113)
        Me.PnlDetalle.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PnlDetalle.Name = "PnlDetalle"
        Me.PnlDetalle.Size = New System.Drawing.Size(635, 151)
        Me.PnlDetalle.TabIndex = 24
        '
        'LblFisicoActual
        '
        Me.LblFisicoActual.AutoSize = True
        Me.LblFisicoActual.Location = New System.Drawing.Point(223, 32)
        Me.LblFisicoActual.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFisicoActual.Name = "LblFisicoActual"
        Me.LblFisicoActual.Size = New System.Drawing.Size(47, 17)
        Me.LblFisicoActual.TabIndex = 30
        Me.LblFisicoActual.Text = "Actual"
        '
        'TxtFisicoActual
        '
        Me.TxtFisicoActual.Enabled = False
        Me.TxtFisicoActual.Location = New System.Drawing.Point(279, 28)
        Me.TxtFisicoActual.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtFisicoActual.Name = "TxtFisicoActual"
        Me.TxtFisicoActual.Size = New System.Drawing.Size(132, 22)
        Me.TxtFisicoActual.TabIndex = 29
        '
        'LblFisico
        '
        Me.LblFisico.AutoSize = True
        Me.LblFisico.Location = New System.Drawing.Point(420, 32)
        Me.LblFisico.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFisico.Name = "LblFisico"
        Me.LblFisico.Size = New System.Drawing.Size(60, 17)
        Me.LblFisico.TabIndex = 28
        Me.LblFisico.Text = "Vendido"
        '
        'BtnAplicar
        '
        Me.BtnAplicar.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnAplicar.ForeColor = System.Drawing.Color.White
        Me.BtnAplicar.Location = New System.Drawing.Point(489, 76)
        Me.BtnAplicar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnAplicar.Name = "BtnAplicar"
        Me.BtnAplicar.Size = New System.Drawing.Size(133, 47)
        Me.BtnAplicar.TabIndex = 27
        Me.BtnAplicar.Text = "Aplicar Movimiento"
        Me.BtnAplicar.UseVisualStyleBackColor = False
        '
        'TxtFisico
        '
        Me.TxtFisico.Location = New System.Drawing.Point(489, 28)
        Me.TxtFisico.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtFisico.Name = "TxtFisico"
        Me.TxtFisico.Size = New System.Drawing.Size(132, 22)
        Me.TxtFisico.TabIndex = 25
        '
        'LblArticulo
        '
        Me.LblArticulo.AutoSize = True
        Me.LblArticulo.Location = New System.Drawing.Point(132, 85)
        Me.LblArticulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblArticulo.Name = "LblArticulo"
        Me.LblArticulo.Size = New System.Drawing.Size(55, 17)
        Me.LblArticulo.TabIndex = 24
        Me.LblArticulo.Text = "Artículo"
        '
        'BtnAutomatico
        '
        Me.BtnAutomatico.BackColor = System.Drawing.Color.White
        Me.BtnAutomatico.Location = New System.Drawing.Point(7, 81)
        Me.BtnAutomatico.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAutomatico.Name = "BtnAutomatico"
        Me.BtnAutomatico.Size = New System.Drawing.Size(100, 47)
        Me.BtnAutomatico.TabIndex = 11
        Me.BtnAutomatico.Text = "Automático"
        Me.BtnAutomatico.UseVisualStyleBackColor = False
        '
        'FrmRebajoVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(793, 286)
        Me.Controls.Add(Me.PnlDetalle)
        Me.Controls.Add(Me.PnlBodegas)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TxtArticuloNombre)
        Me.Controls.Add(Me.TxtArticulo)
        Me.Controls.Add(Me.LblArticulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRebajoVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rebajo de Ventas"
        Me.Panel1.ResumeLayout(False)
        Me.PnlBodegas.ResumeLayout(False)
        Me.PnlBodegas.PerformLayout()
        Me.PnlDetalle.ResumeLayout(False)
        Me.PnlDetalle.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents PnlBodegas As System.Windows.Forms.Panel
    Friend WithEvents LblBodega As System.Windows.Forms.Label
    Friend WithEvents TxtArticulo As System.Windows.Forms.TextBox
    Friend WithEvents TxtArticuloNombre As System.Windows.Forms.TextBox
    Friend WithEvents PnlDetalle As System.Windows.Forms.Panel
    Friend WithEvents LblArticulo As System.Windows.Forms.Label
    Friend WithEvents TxtFisico As System.Windows.Forms.TextBox
    Friend WithEvents BtnAplicar As System.Windows.Forms.Button
    Friend WithEvents LblFisico As System.Windows.Forms.Label
    Friend WithEvents LblFisicoActual As System.Windows.Forms.Label
    Friend WithEvents TxtFisicoActual As System.Windows.Forms.TextBox
    Friend WithEvents LblBodegaNombre As System.Windows.Forms.Label
    Friend WithEvents BtnAutomatico As Button
End Class
