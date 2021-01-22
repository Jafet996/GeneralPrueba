<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConteoFisicoBodegas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConteoFisicoBodegas))
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
        Me.GbAccion = New System.Windows.Forms.GroupBox()
        Me.RdbReemplazar = New System.Windows.Forms.RadioButton()
        Me.RdbRestar = New System.Windows.Forms.RadioButton()
        Me.RdbSumar = New System.Windows.Forms.RadioButton()
        Me.TxtFisico = New System.Windows.Forms.TextBox()
        Me.LblArticulo = New System.Windows.Forms.Label()
        Me.BtnCarga = New System.Windows.Forms.Button()
        Me.PrgProgreso = New System.Windows.Forms.ProgressBar()
        Me.Panel1.SuspendLayout()
        Me.PnlBodegas.SuspendLayout()
        Me.PnlDetalle.SuspendLayout()
        Me.GbAccion.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnCarga)
        Me.Panel1.Controls.Add(Me.BtnLimpiar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(85, 226)
        Me.Panel1.TabIndex = 4
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.BackColor = System.Drawing.Color.White
        Me.BtnLimpiar.Enabled = False
        Me.BtnLimpiar.Location = New System.Drawing.Point(5, 12)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(75, 38)
        Me.BtnLimpiar.TabIndex = 9
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Location = New System.Drawing.Point(5, 100)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(75, 38)
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
        Me.PnlBodegas.Location = New System.Drawing.Point(85, 0)
        Me.PnlBodegas.Name = "PnlBodegas"
        Me.PnlBodegas.Size = New System.Drawing.Size(510, 44)
        Me.PnlBodegas.TabIndex = 5
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
        'TxtArticulo
        '
        Me.TxtArticulo.Location = New System.Drawing.Point(149, 66)
        Me.TxtArticulo.MaxLength = 13
        Me.TxtArticulo.Name = "TxtArticulo"
        Me.TxtArticulo.Size = New System.Drawing.Size(108, 20)
        Me.TxtArticulo.TabIndex = 22
        '
        'TxtArticuloNombre
        '
        Me.TxtArticuloNombre.Location = New System.Drawing.Point(263, 66)
        Me.TxtArticuloNombre.MaxLength = 50
        Me.TxtArticuloNombre.Name = "TxtArticuloNombre"
        Me.TxtArticuloNombre.ReadOnly = True
        Me.TxtArticuloNombre.Size = New System.Drawing.Size(306, 20)
        Me.TxtArticuloNombre.TabIndex = 23
        '
        'PnlDetalle
        '
        Me.PnlDetalle.Controls.Add(Me.LblFisicoActual)
        Me.PnlDetalle.Controls.Add(Me.TxtFisicoActual)
        Me.PnlDetalle.Controls.Add(Me.LblFisico)
        Me.PnlDetalle.Controls.Add(Me.BtnAplicar)
        Me.PnlDetalle.Controls.Add(Me.GbAccion)
        Me.PnlDetalle.Controls.Add(Me.TxtFisico)
        Me.PnlDetalle.Enabled = False
        Me.PnlDetalle.Location = New System.Drawing.Point(102, 92)
        Me.PnlDetalle.Name = "PnlDetalle"
        Me.PnlDetalle.Size = New System.Drawing.Size(476, 111)
        Me.PnlDetalle.TabIndex = 24
        '
        'LblFisicoActual
        '
        Me.LblFisicoActual.AutoSize = True
        Me.LblFisicoActual.Location = New System.Drawing.Point(175, 26)
        Me.LblFisicoActual.Name = "LblFisicoActual"
        Me.LblFisicoActual.Size = New System.Drawing.Size(37, 13)
        Me.LblFisicoActual.TabIndex = 30
        Me.LblFisicoActual.Text = "Actual"
        '
        'TxtFisicoActual
        '
        Me.TxtFisicoActual.Enabled = False
        Me.TxtFisicoActual.Location = New System.Drawing.Point(217, 23)
        Me.TxtFisicoActual.Name = "TxtFisicoActual"
        Me.TxtFisicoActual.Size = New System.Drawing.Size(100, 20)
        Me.TxtFisicoActual.TabIndex = 29
        '
        'LblFisico
        '
        Me.LblFisico.AutoSize = True
        Me.LblFisico.Location = New System.Drawing.Point(325, 26)
        Me.LblFisico.Name = "LblFisico"
        Me.LblFisico.Size = New System.Drawing.Size(36, 13)
        Me.LblFisico.TabIndex = 28
        Me.LblFisico.Text = "Físico"
        '
        'BtnAplicar
        '
        Me.BtnAplicar.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnAplicar.ForeColor = System.Drawing.Color.White
        Me.BtnAplicar.Location = New System.Drawing.Point(367, 62)
        Me.BtnAplicar.Name = "BtnAplicar"
        Me.BtnAplicar.Size = New System.Drawing.Size(100, 38)
        Me.BtnAplicar.TabIndex = 27
        Me.BtnAplicar.Text = "Aplicar Movimiento"
        Me.BtnAplicar.UseVisualStyleBackColor = False
        '
        'GbAccion
        '
        Me.GbAccion.Controls.Add(Me.RdbReemplazar)
        Me.GbAccion.Controls.Add(Me.RdbRestar)
        Me.GbAccion.Controls.Add(Me.RdbSumar)
        Me.GbAccion.Location = New System.Drawing.Point(47, 6)
        Me.GbAccion.Name = "GbAccion"
        Me.GbAccion.Size = New System.Drawing.Size(108, 94)
        Me.GbAccion.TabIndex = 26
        Me.GbAccion.TabStop = False
        Me.GbAccion.Text = "Acción"
        '
        'RdbReemplazar
        '
        Me.RdbReemplazar.AutoSize = True
        Me.RdbReemplazar.Location = New System.Drawing.Point(7, 68)
        Me.RdbReemplazar.Name = "RdbReemplazar"
        Me.RdbReemplazar.Size = New System.Drawing.Size(81, 17)
        Me.RdbReemplazar.TabIndex = 2
        Me.RdbReemplazar.Text = "Reemplazar"
        Me.RdbReemplazar.UseVisualStyleBackColor = True
        '
        'RdbRestar
        '
        Me.RdbRestar.AutoSize = True
        Me.RdbRestar.Location = New System.Drawing.Point(7, 44)
        Me.RdbRestar.Name = "RdbRestar"
        Me.RdbRestar.Size = New System.Drawing.Size(56, 17)
        Me.RdbRestar.TabIndex = 1
        Me.RdbRestar.Text = "Restar"
        Me.RdbRestar.UseVisualStyleBackColor = True
        '
        'RdbSumar
        '
        Me.RdbSumar.AutoSize = True
        Me.RdbSumar.Checked = True
        Me.RdbSumar.Location = New System.Drawing.Point(7, 20)
        Me.RdbSumar.Name = "RdbSumar"
        Me.RdbSumar.Size = New System.Drawing.Size(55, 17)
        Me.RdbSumar.TabIndex = 0
        Me.RdbSumar.TabStop = True
        Me.RdbSumar.Text = "Sumar"
        Me.RdbSumar.UseVisualStyleBackColor = True
        '
        'TxtFisico
        '
        Me.TxtFisico.Location = New System.Drawing.Point(367, 23)
        Me.TxtFisico.Name = "TxtFisico"
        Me.TxtFisico.Size = New System.Drawing.Size(100, 20)
        Me.TxtFisico.TabIndex = 25
        '
        'LblArticulo
        '
        Me.LblArticulo.AutoSize = True
        Me.LblArticulo.Location = New System.Drawing.Point(99, 69)
        Me.LblArticulo.Name = "LblArticulo"
        Me.LblArticulo.Size = New System.Drawing.Size(44, 13)
        Me.LblArticulo.TabIndex = 24
        Me.LblArticulo.Text = "Artículo"
        '
        'BtnCarga
        '
        Me.BtnCarga.BackColor = System.Drawing.Color.White
        Me.BtnCarga.Location = New System.Drawing.Point(5, 56)
        Me.BtnCarga.Name = "BtnCarga"
        Me.BtnCarga.Size = New System.Drawing.Size(75, 38)
        Me.BtnCarga.TabIndex = 11
        Me.BtnCarga.Text = "Carga"
        Me.BtnCarga.UseVisualStyleBackColor = False
        '
        'PrgProgreso
        '
        Me.PrgProgreso.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PrgProgreso.Location = New System.Drawing.Point(85, 216)
        Me.PrgProgreso.Name = "PrgProgreso"
        Me.PrgProgreso.Size = New System.Drawing.Size(510, 10)
        Me.PrgProgreso.TabIndex = 25
        Me.PrgProgreso.Visible = False
        '
        'FrmConteoFisicoBodegas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(595, 226)
        Me.Controls.Add(Me.PrgProgreso)
        Me.Controls.Add(Me.PnlDetalle)
        Me.Controls.Add(Me.PnlBodegas)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TxtArticuloNombre)
        Me.Controls.Add(Me.TxtArticulo)
        Me.Controls.Add(Me.LblArticulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConteoFisicoBodegas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conteo Físico por Bodega"
        Me.Panel1.ResumeLayout(False)
        Me.PnlBodegas.ResumeLayout(False)
        Me.PnlBodegas.PerformLayout()
        Me.PnlDetalle.ResumeLayout(False)
        Me.PnlDetalle.PerformLayout()
        Me.GbAccion.ResumeLayout(False)
        Me.GbAccion.PerformLayout()
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
    Friend WithEvents GbAccion As System.Windows.Forms.GroupBox
    Friend WithEvents RdbReemplazar As System.Windows.Forms.RadioButton
    Friend WithEvents RdbRestar As System.Windows.Forms.RadioButton
    Friend WithEvents RdbSumar As System.Windows.Forms.RadioButton
    Friend WithEvents BtnAplicar As System.Windows.Forms.Button
    Friend WithEvents LblFisico As System.Windows.Forms.Label
    Friend WithEvents LblFisicoActual As System.Windows.Forms.Label
    Friend WithEvents TxtFisicoActual As System.Windows.Forms.TextBox
    Friend WithEvents LblBodegaNombre As System.Windows.Forms.Label
    Friend WithEvents BtnCarga As System.Windows.Forms.Button
    Friend WithEvents PrgProgreso As System.Windows.Forms.ProgressBar
End Class
