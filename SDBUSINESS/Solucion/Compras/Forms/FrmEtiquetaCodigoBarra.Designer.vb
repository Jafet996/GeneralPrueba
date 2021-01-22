<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEtiquetaCodigoBarra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEtiquetaCodigoBarra))
        Me.TxtArticulo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtArticuloNombre = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtCantidad = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtPrecio = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.BtnEntrada = New System.Windows.Forms.Button()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.PnlArticulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtExento = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbBodega = New System.Windows.Forms.ComboBox()
        Me.LvwDetalle = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PicImpresora = New System.Windows.Forms.PictureBox()
        Me.LblImpresora = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbEtiqueta = New System.Windows.Forms.ComboBox()
        Me.BtnImpresora = New System.Windows.Forms.Button()
        Me.BtnPrecios = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.PnlArticulo.SuspendLayout()
        CType(Me.PicImpresora, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtArticulo
        '
        Me.TxtArticulo.Location = New System.Drawing.Point(176, 34)
        Me.TxtArticulo.MaxLength = 13
        Me.TxtArticulo.Name = "TxtArticulo"
        Me.TxtArticulo.Size = New System.Drawing.Size(100, 20)
        Me.TxtArticulo.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(173, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Código Artículo"
        '
        'TxtArticuloNombre
        '
        Me.TxtArticuloNombre.BackColor = System.Drawing.SystemColors.Window
        Me.TxtArticuloNombre.Enabled = False
        Me.TxtArticuloNombre.Location = New System.Drawing.Point(282, 34)
        Me.TxtArticuloNombre.Name = "TxtArticuloNombre"
        Me.TxtArticuloNombre.ReadOnly = True
        Me.TxtArticuloNombre.Size = New System.Drawing.Size(325, 20)
        Me.TxtArticuloNombre.TabIndex = 11
        Me.TxtArticuloNombre.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(279, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Descripción"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.BackColor = System.Drawing.SystemColors.Window
        Me.TxtCantidad.Enabled = False
        Me.TxtCantidad.Location = New System.Drawing.Point(775, 33)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(66, 20)
        Me.TxtCantidad.TabIndex = 1
        Me.TxtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(792, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Cantidad"
        '
        'TxtPrecio
        '
        Me.TxtPrecio.BackColor = System.Drawing.SystemColors.Window
        Me.TxtPrecio.Enabled = False
        Me.TxtPrecio.Location = New System.Drawing.Point(659, 33)
        Me.TxtPrecio.Name = "TxtPrecio"
        Me.TxtPrecio.ReadOnly = True
        Me.TxtPrecio.Size = New System.Drawing.Size(110, 20)
        Me.TxtPrecio.TabIndex = 15
        Me.TxtPrecio.TabStop = False
        Me.TxtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(732, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Precio"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnPrecios)
        Me.Panel1.Controls.Add(Me.BtnLimpiar)
        Me.Panel1.Controls.Add(Me.BtnEntrada)
        Me.Panel1.Controls.Add(Me.BtnBuscar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnImprimir)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(81, 579)
        Me.Panel1.TabIndex = 19
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.BackColor = System.Drawing.Color.White
        Me.BtnLimpiar.Image = Global.Compras.My.Resources.Resources.Blue_F4
        Me.BtnLimpiar.Location = New System.Drawing.Point(11, 240)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(59, 70)
        Me.BtnLimpiar.TabIndex = 16
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnLimpiar.UseVisualStyleBackColor = False
        '
        'BtnEntrada
        '
        Me.BtnEntrada.BackColor = System.Drawing.Color.White
        Me.BtnEntrada.Image = Global.Compras.My.Resources.Resources.Blue_F2
        Me.BtnEntrada.Location = New System.Drawing.Point(11, 88)
        Me.BtnEntrada.Name = "BtnEntrada"
        Me.BtnEntrada.Size = New System.Drawing.Size(59, 70)
        Me.BtnEntrada.TabIndex = 15
        Me.BtnEntrada.Text = "Entrada"
        Me.BtnEntrada.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnEntrada.UseVisualStyleBackColor = False
        '
        'BtnBuscar
        '
        Me.BtnBuscar.BackColor = System.Drawing.Color.White
        Me.BtnBuscar.Image = Global.Compras.My.Resources.Resources.Blue_F1
        Me.BtnBuscar.Location = New System.Drawing.Point(11, 12)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(59, 70)
        Me.BtnBuscar.TabIndex = 14
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnBuscar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Compras.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(11, 392)
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
        Me.BtnImprimir.Image = Global.Compras.My.Resources.Resources.Blue_F3
        Me.BtnImprimir.Location = New System.Drawing.Point(11, 164)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(59, 70)
        Me.BtnImprimir.TabIndex = 12
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'PnlArticulo
        '
        Me.PnlArticulo.Controls.Add(Me.Label1)
        Me.PnlArticulo.Controls.Add(Me.TxtExento)
        Me.PnlArticulo.Controls.Add(Me.Label2)
        Me.PnlArticulo.Controls.Add(Me.CmbBodega)
        Me.PnlArticulo.Controls.Add(Me.TxtArticulo)
        Me.PnlArticulo.Controls.Add(Me.Label7)
        Me.PnlArticulo.Controls.Add(Me.TxtPrecio)
        Me.PnlArticulo.Controls.Add(Me.Label4)
        Me.PnlArticulo.Controls.Add(Me.Label6)
        Me.PnlArticulo.Controls.Add(Me.TxtArticuloNombre)
        Me.PnlArticulo.Controls.Add(Me.TxtCantidad)
        Me.PnlArticulo.Controls.Add(Me.Label5)
        Me.PnlArticulo.Location = New System.Drawing.Point(81, 3)
        Me.PnlArticulo.Name = "PnlArticulo"
        Me.PnlArticulo.Size = New System.Drawing.Size(862, 70)
        Me.PnlArticulo.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(613, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Exento"
        '
        'TxtExento
        '
        Me.TxtExento.BackColor = System.Drawing.SystemColors.Window
        Me.TxtExento.Enabled = False
        Me.TxtExento.Location = New System.Drawing.Point(613, 33)
        Me.TxtExento.Name = "TxtExento"
        Me.TxtExento.ReadOnly = True
        Me.TxtExento.Size = New System.Drawing.Size(40, 20)
        Me.TxtExento.TabIndex = 26
        Me.TxtExento.TabStop = False
        Me.TxtExento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Bodega"
        '
        'CmbBodega
        '
        Me.CmbBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBodega.FormattingEnabled = True
        Me.CmbBodega.Location = New System.Drawing.Point(16, 33)
        Me.CmbBodega.Name = "CmbBodega"
        Me.CmbBodega.Size = New System.Drawing.Size(154, 21)
        Me.CmbBodega.TabIndex = 25
        '
        'LvwDetalle
        '
        Me.LvwDetalle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.LvwDetalle.FullRowSelect = True
        Me.LvwDetalle.Location = New System.Drawing.Point(81, 79)
        Me.LvwDetalle.Name = "LvwDetalle"
        Me.LvwDetalle.Size = New System.Drawing.Size(862, 462)
        Me.LvwDetalle.TabIndex = 21
        Me.LvwDetalle.UseCompatibleStateImageBehavior = False
        Me.LvwDetalle.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 120
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 300
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Width = 100
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Width = 100
        '
        'PicImpresora
        '
        Me.PicImpresora.Image = Global.Compras.My.Resources.Resources.printer
        Me.PicImpresora.Location = New System.Drawing.Point(87, 547)
        Me.PicImpresora.Name = "PicImpresora"
        Me.PicImpresora.Size = New System.Drawing.Size(24, 24)
        Me.PicImpresora.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicImpresora.TabIndex = 22
        Me.PicImpresora.TabStop = False
        '
        'LblImpresora
        '
        Me.LblImpresora.Location = New System.Drawing.Point(154, 548)
        Me.LblImpresora.Name = "LblImpresora"
        Me.LblImpresora.Size = New System.Drawing.Size(421, 23)
        Me.LblImpresora.TabIndex = 23
        Me.LblImpresora.Text = "..."
        Me.LblImpresora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(581, 553)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Etiqueta"
        '
        'CmbEtiqueta
        '
        Me.CmbEtiqueta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEtiqueta.FormattingEnabled = True
        Me.CmbEtiqueta.Location = New System.Drawing.Point(633, 549)
        Me.CmbEtiqueta.Name = "CmbEtiqueta"
        Me.CmbEtiqueta.Size = New System.Drawing.Size(304, 21)
        Me.CmbEtiqueta.TabIndex = 25
        '
        'BtnImpresora
        '
        Me.BtnImpresora.BackColor = System.Drawing.Color.White
        Me.BtnImpresora.Location = New System.Drawing.Point(117, 548)
        Me.BtnImpresora.Name = "BtnImpresora"
        Me.BtnImpresora.Size = New System.Drawing.Size(31, 23)
        Me.BtnImpresora.TabIndex = 26
        Me.BtnImpresora.Text = "..."
        Me.BtnImpresora.UseVisualStyleBackColor = False
        '
        'BtnPrecios
        '
        Me.BtnPrecios.BackColor = System.Drawing.Color.White
        Me.BtnPrecios.Image = Global.Compras.My.Resources.Resources.Blue_F5
        Me.BtnPrecios.Location = New System.Drawing.Point(11, 316)
        Me.BtnPrecios.Name = "BtnPrecios"
        Me.BtnPrecios.Size = New System.Drawing.Size(59, 70)
        Me.BtnPrecios.TabIndex = 17
        Me.BtnPrecios.Text = "Precios"
        Me.BtnPrecios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnPrecios.UseVisualStyleBackColor = False
        '
        'FrmEtiquetaCodigoBarra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(943, 575)
        Me.Controls.Add(Me.BtnImpresora)
        Me.Controls.Add(Me.CmbEtiqueta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblImpresora)
        Me.Controls.Add(Me.PicImpresora)
        Me.Controls.Add(Me.LvwDetalle)
        Me.Controls.Add(Me.PnlArticulo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEtiquetaCodigoBarra"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresión de etiquetas"
        Me.Panel1.ResumeLayout(False)
        Me.PnlArticulo.ResumeLayout(False)
        Me.PnlArticulo.PerformLayout()
        CType(Me.PicImpresora, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtArticuloNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents PnlArticulo As System.Windows.Forms.Panel
    Friend WithEvents LvwDetalle As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents CmbBodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtExento As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents BtnEntrada As System.Windows.Forms.Button
    Friend WithEvents PicImpresora As System.Windows.Forms.PictureBox
    Friend WithEvents LblImpresora As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbEtiqueta As System.Windows.Forms.ComboBox
    Friend WithEvents BtnImpresora As System.Windows.Forms.Button
    Friend WithEvents BtnPrecios As Button
End Class
