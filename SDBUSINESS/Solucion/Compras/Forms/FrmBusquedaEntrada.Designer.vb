<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBusquedaEntrada
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBusquedaEntrada))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtComentario = New System.Windows.Forms.TextBox()
        Me.TxtFactura = New System.Windows.Forms.TextBox()
        Me.RdbComentario = New System.Windows.Forms.RadioButton()
        Me.RdbFactura = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.DtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.TxtCantidad = New System.Windows.Forms.TextBox()
        Me.RdbFechas = New System.Windows.Forms.RadioButton()
        Me.RdbUltimos = New System.Windows.Forms.RadioButton()
        Me.DGDetalle = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtProveerdor = New System.Windows.Forms.TextBox()
        Me.RdbProveedor = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 572)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(927, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtProveerdor)
        Me.GroupBox1.Controls.Add(Me.RdbProveedor)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtComentario)
        Me.GroupBox1.Controls.Add(Me.TxtFactura)
        Me.GroupBox1.Controls.Add(Me.RdbComentario)
        Me.GroupBox1.Controls.Add(Me.RdbFactura)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DtpHasta)
        Me.GroupBox1.Controls.Add(Me.DtpDesde)
        Me.GroupBox1.Controls.Add(Me.TxtCantidad)
        Me.GroupBox1.Controls.Add(Me.RdbFechas)
        Me.GroupBox1.Controls.Add(Me.RdbUltimos)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(68, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(859, 88)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'TxtComentario
        '
        Me.TxtComentario.BackColor = System.Drawing.Color.White
        Me.TxtComentario.Location = New System.Drawing.Point(562, 16)
        Me.TxtComentario.Name = "TxtComentario"
        Me.TxtComentario.Size = New System.Drawing.Size(287, 20)
        Me.TxtComentario.TabIndex = 32
        '
        'TxtFactura
        '
        Me.TxtFactura.BackColor = System.Drawing.Color.White
        Me.TxtFactura.Location = New System.Drawing.Point(127, 57)
        Me.TxtFactura.Name = "TxtFactura"
        Me.TxtFactura.Size = New System.Drawing.Size(79, 20)
        Me.TxtFactura.TabIndex = 31
        '
        'RdbComentario
        '
        Me.RdbComentario.AutoSize = True
        Me.RdbComentario.Location = New System.Drawing.Point(478, 18)
        Me.RdbComentario.Name = "RdbComentario"
        Me.RdbComentario.Size = New System.Drawing.Size(78, 17)
        Me.RdbComentario.TabIndex = 30
        Me.RdbComentario.Text = "Comentario"
        Me.RdbComentario.UseVisualStyleBackColor = True
        '
        'RdbFactura
        '
        Me.RdbFactura.AutoSize = True
        Me.RdbFactura.Location = New System.Drawing.Point(10, 60)
        Me.RdbFactura.Name = "RdbFactura"
        Me.RdbFactura.Size = New System.Drawing.Size(71, 17)
        Me.RdbFactura.TabIndex = 29
        Me.RdbFactura.Text = "# Factura"
        Me.RdbFactura.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(304, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Hasta :"
        '
        'DtpHasta
        '
        Me.DtpHasta.CalendarMonthBackground = System.Drawing.Color.White
        Me.DtpHasta.CustomFormat = "dd/MM/yyyy"
        Me.DtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHasta.Location = New System.Drawing.Point(348, 57)
        Me.DtpHasta.Name = "DtpHasta"
        Me.DtpHasta.Size = New System.Drawing.Size(80, 20)
        Me.DtpHasta.TabIndex = 6
        '
        'DtpDesde
        '
        Me.DtpDesde.CalendarMonthBackground = System.Drawing.Color.White
        Me.DtpDesde.CustomFormat = "dd/MM/yyyy"
        Me.DtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpDesde.Location = New System.Drawing.Point(348, 17)
        Me.DtpDesde.Name = "DtpDesde"
        Me.DtpDesde.Size = New System.Drawing.Size(80, 20)
        Me.DtpDesde.TabIndex = 5
        '
        'TxtCantidad
        '
        Me.TxtCantidad.BackColor = System.Drawing.Color.White
        Me.TxtCantidad.Location = New System.Drawing.Point(127, 17)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(80, 20)
        Me.TxtCantidad.TabIndex = 3
        Me.TxtCantidad.Text = "30"
        Me.TxtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RdbFechas
        '
        Me.RdbFechas.AutoSize = True
        Me.RdbFechas.Location = New System.Drawing.Point(232, 19)
        Me.RdbFechas.Name = "RdbFechas"
        Me.RdbFechas.Size = New System.Drawing.Size(63, 17)
        Me.RdbFechas.TabIndex = 4
        Me.RdbFechas.Text = "Fechas "
        Me.RdbFechas.UseVisualStyleBackColor = True
        '
        'RdbUltimos
        '
        Me.RdbUltimos.AutoSize = True
        Me.RdbUltimos.Checked = True
        Me.RdbUltimos.Location = New System.Drawing.Point(6, 19)
        Me.RdbUltimos.Name = "RdbUltimos"
        Me.RdbUltimos.Size = New System.Drawing.Size(115, 17)
        Me.RdbUltimos.TabIndex = 2
        Me.RdbUltimos.TabStop = True
        Me.RdbUltimos.Text = "Mostras los Ultimos"
        Me.RdbUltimos.UseVisualStyleBackColor = True
        '
        'DGDetalle
        '
        Me.DGDetalle.AllowUserToAddRows = False
        Me.DGDetalle.AllowUserToDeleteRows = False
        Me.DGDetalle.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.DGDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDetalle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DGDetalle.Location = New System.Drawing.Point(68, 94)
        Me.DGDetalle.Name = "DGDetalle"
        Me.DGDetalle.ReadOnly = True
        Me.DGDetalle.Size = New System.Drawing.Size(859, 478)
        Me.DGDetalle.TabIndex = 7
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel2.Controls.Add(Me.BtnBuscar)
        Me.Panel2.Controls.Add(Me.BtnLimpiar)
        Me.Panel2.Controls.Add(Me.BtnSalir)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(68, 572)
        Me.Panel2.TabIndex = 11
        '
        'BtnBuscar
        '
        Me.BtnBuscar.BackColor = System.Drawing.Color.White
        Me.BtnBuscar.Image = Global.Compras.My.Resources.Resources.Blue_F1
        Me.BtnBuscar.Location = New System.Drawing.Point(3, 9)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(62, 69)
        Me.BtnBuscar.TabIndex = 2
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnBuscar.UseVisualStyleBackColor = False
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.BackColor = System.Drawing.Color.White
        Me.BtnLimpiar.Image = Global.Compras.My.Resources.Resources.Blue_F12
        Me.BtnLimpiar.Location = New System.Drawing.Point(3, 84)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(62, 69)
        Me.BtnLimpiar.TabIndex = 1
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnLimpiar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Compras.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(3, 159)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(62, 69)
        Me.BtnSalir.TabIndex = 0
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(301, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Desde :"
        '
        'TxtProveerdor
        '
        Me.TxtProveerdor.BackColor = System.Drawing.Color.White
        Me.TxtProveerdor.Location = New System.Drawing.Point(562, 54)
        Me.TxtProveerdor.Name = "TxtProveerdor"
        Me.TxtProveerdor.Size = New System.Drawing.Size(287, 20)
        Me.TxtProveerdor.TabIndex = 35
        '
        'RdbProveedor
        '
        Me.RdbProveedor.AutoSize = True
        Me.RdbProveedor.Location = New System.Drawing.Point(478, 59)
        Me.RdbProveedor.Name = "RdbProveedor"
        Me.RdbProveedor.Size = New System.Drawing.Size(74, 17)
        Me.RdbProveedor.TabIndex = 34
        Me.RdbProveedor.Text = "Proveedor"
        Me.RdbProveedor.UseVisualStyleBackColor = True
        '
        'FrmBusquedaEntrada
        '
        Me.AcceptButton = Me.BtnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(927, 594)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DGDetalle)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBusquedaEntrada"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Búsqueda de Entradas de Mercadería"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RdbUltimos As System.Windows.Forms.RadioButton
    Friend WithEvents TxtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents RdbFechas As System.Windows.Forms.RadioButton
    Friend WithEvents DGDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents TxtComentario As TextBox
    Friend WithEvents TxtFactura As TextBox
    Friend WithEvents RdbComentario As RadioButton
    Friend WithEvents RdbFactura As RadioButton
    Friend WithEvents TxtProveerdor As TextBox
    Friend WithEvents RdbProveedor As RadioButton
    Friend WithEvents Label2 As Label
End Class
