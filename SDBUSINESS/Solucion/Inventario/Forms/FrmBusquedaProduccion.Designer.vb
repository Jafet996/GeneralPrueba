<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBusquedaProduccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBusquedaProduccion))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.DtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.TxtCantidad = New System.Windows.Forms.TextBox()
        Me.CmbTipoMovimiento = New System.Windows.Forms.ComboBox()
        Me.RdbFechas = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
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
        Me.Panel1.Controls.Add(Me.BtnAceptar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(71, 467)
        Me.Panel1.TabIndex = 14
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Inventario.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(7, 166)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(56, 71)
        Me.BtnSalir.TabIndex = 2
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.BackColor = System.Drawing.Color.White
        Me.BtnLimpiar.Image = Global.Inventario.My.Resources.Resources.Blue_F6
        Me.BtnLimpiar.Location = New System.Drawing.Point(7, 89)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(56, 71)
        Me.BtnLimpiar.TabIndex = 1
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnLimpiar.UseVisualStyleBackColor = False
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.White
        Me.BtnAceptar.Image = Global.Inventario.My.Resources.Resources.Blue_F2
        Me.BtnAceptar.Location = New System.Drawing.Point(7, 12)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(56, 71)
        Me.BtnAceptar.TabIndex = 0
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Location = New System.Drawing.Point(253, 45)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.BtnBuscar.TabIndex = 0
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 474)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(730, 22)
        Me.StatusStrip1.TabIndex = 13
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DtpHasta)
        Me.GroupBox1.Controls.Add(Me.BtnBuscar)
        Me.GroupBox1.Controls.Add(Me.DtpDesde)
        Me.GroupBox1.Controls.Add(Me.TxtCantidad)
        Me.GroupBox1.Controls.Add(Me.CmbTipoMovimiento)
        Me.GroupBox1.Controls.Add(Me.RdbFechas)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.RdbUltimos)
        Me.GroupBox1.Location = New System.Drawing.Point(77, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(644, 83)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(506, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Hasta :"
        '
        'DtpHasta
        '
        Me.DtpHasta.CustomFormat = "dd/MM/yyyy"
        Me.DtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHasta.Location = New System.Drawing.Point(553, 41)
        Me.DtpHasta.Name = "DtpHasta"
        Me.DtpHasta.Size = New System.Drawing.Size(80, 20)
        Me.DtpHasta.TabIndex = 6
        '
        'DtpDesde
        '
        Me.DtpDesde.CustomFormat = "dd/MM/yyyy"
        Me.DtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpDesde.Location = New System.Drawing.Point(420, 41)
        Me.DtpDesde.Name = "DtpDesde"
        Me.DtpDesde.Size = New System.Drawing.Size(80, 20)
        Me.DtpDesde.TabIndex = 5
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(553, 15)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(80, 20)
        Me.TxtCantidad.TabIndex = 3
        Me.TxtCantidad.Text = "30"
        Me.TxtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CmbTipoMovimiento
        '
        Me.CmbTipoMovimiento.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CmbTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoMovimiento.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbTipoMovimiento.Location = New System.Drawing.Point(48, 14)
        Me.CmbTipoMovimiento.Name = "CmbTipoMovimiento"
        Me.CmbTipoMovimiento.Size = New System.Drawing.Size(280, 24)
        Me.CmbTipoMovimiento.TabIndex = 1
        '
        'RdbFechas
        '
        Me.RdbFechas.AutoSize = True
        Me.RdbFechas.Location = New System.Drawing.Point(348, 43)
        Me.RdbFechas.Name = "RdbFechas"
        Me.RdbFechas.Size = New System.Drawing.Size(66, 17)
        Me.RdbFechas.TabIndex = 4
        Me.RdbFechas.Text = "Fechas :"
        Me.RdbFechas.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 16)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Tipo"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RdbUltimos
        '
        Me.RdbUltimos.AutoSize = True
        Me.RdbUltimos.Checked = True
        Me.RdbUltimos.Location = New System.Drawing.Point(348, 17)
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
        Me.DGDetalle.Location = New System.Drawing.Point(77, 89)
        Me.DGDetalle.Name = "DGDetalle"
        Me.DGDetalle.ReadOnly = True
        Me.DGDetalle.Size = New System.Drawing.Size(644, 378)
        Me.DGDetalle.TabIndex = 12
        '
        'FrmBusquedaProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(730, 496)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DGDetalle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmBusquedaProduccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Búsqueda de Producción"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnLimpiar As Button
    Friend WithEvents BtnAceptar As Button
    Friend WithEvents BtnBuscar As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DtpHasta As DateTimePicker
    Friend WithEvents DtpDesde As DateTimePicker
    Friend WithEvents TxtCantidad As TextBox
    Friend WithEvents CmbTipoMovimiento As ComboBox
    Friend WithEvents RdbFechas As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents RdbUltimos As RadioButton
    Friend WithEvents DGDetalle As DataGridView
End Class
