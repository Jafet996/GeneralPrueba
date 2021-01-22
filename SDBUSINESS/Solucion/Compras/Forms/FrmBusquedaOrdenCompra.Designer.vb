<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBusquedaOrdenCompra
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBusquedaOrdenCompra))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.DtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.TxtCantidad = New System.Windows.Forms.TextBox()
        Me.RdbFechas = New System.Windows.Forms.RadioButton()
        Me.RdbUltimos = New System.Windows.Forms.RadioButton()
        Me.DGDetalle = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnLimpiar)
        Me.Panel1.Controls.Add(Me.BtnBuscar)
        Me.Panel1.Controls.Add(Me.BtnAceptar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(71, 594)
        Me.Panel1.TabIndex = 10
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Compras.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(6, 243)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(56, 71)
        Me.BtnSalir.TabIndex = 5
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.BackColor = System.Drawing.Color.White
        Me.BtnLimpiar.Image = Global.Compras.My.Resources.Resources.Blue_F6
        Me.BtnLimpiar.Location = New System.Drawing.Point(6, 166)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(56, 71)
        Me.BtnLimpiar.TabIndex = 4
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnLimpiar.UseVisualStyleBackColor = False
        '
        'BtnBuscar
        '
        Me.BtnBuscar.BackColor = System.Drawing.Color.White
        Me.BtnBuscar.Image = Global.Compras.My.Resources.Resources.Blue_F1
        Me.BtnBuscar.Location = New System.Drawing.Point(6, 12)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(56, 71)
        Me.BtnBuscar.TabIndex = 0
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnBuscar.UseVisualStyleBackColor = False
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.White
        Me.BtnAceptar.Image = Global.Compras.My.Resources.Resources.Blue_F2
        Me.BtnAceptar.Location = New System.Drawing.Point(6, 89)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(56, 71)
        Me.BtnAceptar.TabIndex = 3
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Location = New System.Drawing.Point(71, 572)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1082, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DtpHasta)
        Me.GroupBox1.Controls.Add(Me.DtpDesde)
        Me.GroupBox1.Controls.Add(Me.TxtCantidad)
        Me.GroupBox1.Controls.Add(Me.RdbFechas)
        Me.GroupBox1.Controls.Add(Me.RdbUltimos)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(71, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1082, 63)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(395, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Hasta :"
        '
        'DtpHasta
        '
        Me.DtpHasta.CustomFormat = "dd/MM/yyyy"
        Me.DtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHasta.Location = New System.Drawing.Point(442, 25)
        Me.DtpHasta.Name = "DtpHasta"
        Me.DtpHasta.Size = New System.Drawing.Size(80, 20)
        Me.DtpHasta.TabIndex = 6
        '
        'DtpDesde
        '
        Me.DtpDesde.CustomFormat = "dd/MM/yyyy"
        Me.DtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpDesde.Location = New System.Drawing.Point(309, 25)
        Me.DtpDesde.Name = "DtpDesde"
        Me.DtpDesde.Size = New System.Drawing.Size(80, 20)
        Me.DtpDesde.TabIndex = 5
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(138, 25)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(80, 20)
        Me.TxtCantidad.TabIndex = 3
        Me.TxtCantidad.Text = "30"
        Me.TxtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RdbFechas
        '
        Me.RdbFechas.AutoSize = True
        Me.RdbFechas.Location = New System.Drawing.Point(237, 27)
        Me.RdbFechas.Name = "RdbFechas"
        Me.RdbFechas.Size = New System.Drawing.Size(66, 17)
        Me.RdbFechas.TabIndex = 4
        Me.RdbFechas.Text = "Fechas :"
        Me.RdbFechas.UseVisualStyleBackColor = True
        '
        'RdbUltimos
        '
        Me.RdbUltimos.AutoSize = True
        Me.RdbUltimos.Checked = True
        Me.RdbUltimos.Location = New System.Drawing.Point(17, 27)
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
        Me.DGDetalle.Location = New System.Drawing.Point(71, 69)
        Me.DGDetalle.Name = "DGDetalle"
        Me.DGDetalle.ReadOnly = True
        Me.DGDetalle.Size = New System.Drawing.Size(1082, 503)
        Me.DGDetalle.TabIndex = 7
        '
        'FrmBusquedaOrdenCompra
        '
        Me.AcceptButton = Me.BtnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1153, 594)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DGDetalle)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBusquedaOrdenCompra"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Búsqueda de Ordenes de Compra"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RdbUltimos As System.Windows.Forms.RadioButton
    Friend WithEvents TxtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents RdbFechas As System.Windows.Forms.RadioButton
    Friend WithEvents DGDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
End Class
