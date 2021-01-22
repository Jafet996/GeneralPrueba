<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantArticuloPromocionDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantArticuloPromocionDetalle))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.PnlDetalle = New System.Windows.Forms.Panel()
        Me.TxtPrecioActual = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtPorcentajeDescuento = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnConfirmar = New System.Windows.Forms.Button()
        Me.DtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.DtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.TxtPrecioConvenio = New System.Windows.Forms.TextBox()
        Me.TxtArticuloNombre = New System.Windows.Forms.TextBox()
        Me.TxtArticulo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LvwArticulos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtCriterio = New System.Windows.Forms.TextBox()
        Me.PicBorrar = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.PnlDetalle.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicBorrar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnBuscar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(71, 539)
        Me.Panel1.TabIndex = 11
        '
        'BtnBuscar
        '
        Me.BtnBuscar.BackColor = System.Drawing.Color.White
        Me.BtnBuscar.Image = Global.Inventario.My.Resources.Resources.Blue_F1
        Me.BtnBuscar.Location = New System.Drawing.Point(7, 9)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(56, 71)
        Me.BtnBuscar.TabIndex = 3
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnBuscar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Inventario.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(7, 86)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(56, 71)
        Me.BtnSalir.TabIndex = 2
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'PnlDetalle
        '
        Me.PnlDetalle.Controls.Add(Me.TxtPrecioActual)
        Me.PnlDetalle.Controls.Add(Me.Label7)
        Me.PnlDetalle.Controls.Add(Me.TxtPorcentajeDescuento)
        Me.PnlDetalle.Controls.Add(Me.Label5)
        Me.PnlDetalle.Controls.Add(Me.BtnConfirmar)
        Me.PnlDetalle.Controls.Add(Me.DtpFechaFin)
        Me.PnlDetalle.Controls.Add(Me.DtpFechaInicio)
        Me.PnlDetalle.Controls.Add(Me.TxtPrecioConvenio)
        Me.PnlDetalle.Controls.Add(Me.TxtArticuloNombre)
        Me.PnlDetalle.Controls.Add(Me.TxtArticulo)
        Me.PnlDetalle.Controls.Add(Me.Label6)
        Me.PnlDetalle.Controls.Add(Me.Label4)
        Me.PnlDetalle.Controls.Add(Me.Label3)
        Me.PnlDetalle.Controls.Add(Me.Label2)
        Me.PnlDetalle.Location = New System.Drawing.Point(77, 12)
        Me.PnlDetalle.Name = "PnlDetalle"
        Me.PnlDetalle.Size = New System.Drawing.Size(588, 116)
        Me.PnlDetalle.TabIndex = 12
        '
        'TxtPrecioActual
        '
        Me.TxtPrecioActual.Enabled = False
        Me.TxtPrecioActual.Location = New System.Drawing.Point(97, 35)
        Me.TxtPrecioActual.Name = "TxtPrecioActual"
        Me.TxtPrecioActual.Size = New System.Drawing.Size(100, 20)
        Me.TxtPrecioActual.TabIndex = 15
        Me.TxtPrecioActual.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Precio Actual"
        '
        'TxtPorcentajeDescuento
        '
        Me.TxtPorcentajeDescuento.Location = New System.Drawing.Point(464, 35)
        Me.TxtPorcentajeDescuento.Name = "TxtPorcentajeDescuento"
        Me.TxtPorcentajeDescuento.Size = New System.Drawing.Size(100, 20)
        Me.TxtPorcentajeDescuento.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(400, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Porcentaje"
        '
        'BtnConfirmar
        '
        Me.BtnConfirmar.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnConfirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConfirmar.ForeColor = System.Drawing.Color.White
        Me.BtnConfirmar.Location = New System.Drawing.Point(464, 64)
        Me.BtnConfirmar.Name = "BtnConfirmar"
        Me.BtnConfirmar.Size = New System.Drawing.Size(100, 40)
        Me.BtnConfirmar.TabIndex = 7
        Me.BtnConfirmar.Text = "Aceptar"
        Me.BtnConfirmar.UseVisualStyleBackColor = False
        '
        'DtpFechaFin
        '
        Me.DtpFechaFin.CustomFormat = "dd/MM/yyyy hh:mm tt"
        Me.DtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaFin.Location = New System.Drawing.Point(96, 87)
        Me.DtpFechaFin.Name = "DtpFechaFin"
        Me.DtpFechaFin.Size = New System.Drawing.Size(297, 20)
        Me.DtpFechaFin.TabIndex = 6
        '
        'DtpFechaInicio
        '
        Me.DtpFechaInicio.CustomFormat = "dd/MM/yyyy hh:mm tt"
        Me.DtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaInicio.Location = New System.Drawing.Point(96, 61)
        Me.DtpFechaInicio.Name = "DtpFechaInicio"
        Me.DtpFechaInicio.Size = New System.Drawing.Size(297, 20)
        Me.DtpFechaInicio.TabIndex = 5
        '
        'TxtPrecioConvenio
        '
        Me.TxtPrecioConvenio.Location = New System.Drawing.Point(294, 35)
        Me.TxtPrecioConvenio.Name = "TxtPrecioConvenio"
        Me.TxtPrecioConvenio.Size = New System.Drawing.Size(100, 20)
        Me.TxtPrecioConvenio.TabIndex = 3
        '
        'TxtArticuloNombre
        '
        Me.TxtArticuloNombre.Enabled = False
        Me.TxtArticuloNombre.Location = New System.Drawing.Point(202, 9)
        Me.TxtArticuloNombre.Name = "TxtArticuloNombre"
        Me.TxtArticuloNombre.Size = New System.Drawing.Size(362, 20)
        Me.TxtArticuloNombre.TabIndex = 6
        Me.TxtArticuloNombre.TabStop = False
        '
        'TxtArticulo
        '
        Me.TxtArticulo.Location = New System.Drawing.Point(96, 9)
        Me.TxtArticulo.Name = "TxtArticulo"
        Me.TxtArticulo.Size = New System.Drawing.Size(100, 20)
        Me.TxtArticulo.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(203, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Precio Promoción"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Finaliza"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Inicia"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Artículo"
        '
        'LvwArticulos
        '
        Me.LvwArticulos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.LvwArticulos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LvwArticulos.FullRowSelect = True
        Me.LvwArticulos.Location = New System.Drawing.Point(71, 196)
        Me.LvwArticulos.Name = "LvwArticulos"
        Me.LvwArticulos.Size = New System.Drawing.Size(597, 343)
        Me.LvwArticulos.TabIndex = 13
        Me.LvwArticulos.UseCompatibleStateImageBehavior = False
        Me.LvwArticulos.View = System.Windows.Forms.View.Details
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PicBorrar)
        Me.GroupBox1.Controls.Add(Me.TxtCriterio)
        Me.GroupBox1.Location = New System.Drawing.Point(77, 134)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(588, 56)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buscar en las promociones"
        '
        'TxtCriterio
        '
        Me.TxtCriterio.Location = New System.Drawing.Point(96, 22)
        Me.TxtCriterio.Name = "TxtCriterio"
        Me.TxtCriterio.Size = New System.Drawing.Size(362, 20)
        Me.TxtCriterio.TabIndex = 0
        '
        'PicBorrar
        '
        Me.PicBorrar.Image = Global.Inventario.My.Resources.Resources.delete
        Me.PicBorrar.Location = New System.Drawing.Point(464, 22)
        Me.PicBorrar.Name = "PicBorrar"
        Me.PicBorrar.Size = New System.Drawing.Size(20, 20)
        Me.PicBorrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicBorrar.TabIndex = 4
        Me.PicBorrar.TabStop = False
        Me.PicBorrar.Visible = False
        '
        'FrmMantArticuloPromocionDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(668, 539)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LvwArticulos)
        Me.Controls.Add(Me.PnlDetalle)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantArticuloPromocionDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Promociones"
        Me.Panel1.ResumeLayout(False)
        Me.PnlDetalle.ResumeLayout(False)
        Me.PnlDetalle.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PicBorrar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents PnlDetalle As System.Windows.Forms.Panel
    Friend WithEvents TxtPrecioActual As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtPorcentajeDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnConfirmar As System.Windows.Forms.Button
    Friend WithEvents DtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtPrecioConvenio As System.Windows.Forms.TextBox
    Friend WithEvents TxtArticuloNombre As System.Windows.Forms.TextBox
    Friend WithEvents TxtArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LvwArticulos As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCriterio As System.Windows.Forms.TextBox
    Friend WithEvents PicBorrar As System.Windows.Forms.PictureBox
End Class
