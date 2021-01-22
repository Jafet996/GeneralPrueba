<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLoteSeleccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLoteSeleccion))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.LvwArticulos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LvwLotesInventario = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.LvwLotesFactura = New System.Windows.Forms.ListView()
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PnlArticulos = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PnlDetalle = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.PnlArticulos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.PnlDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnAceptar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(112, 827)
        Me.Panel1.TabIndex = 2
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Business.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnSalir.Location = New System.Drawing.Point(12, 105)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(85, 87)
        Me.BtnSalir.TabIndex = 12
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.White
        Me.BtnAceptar.Image = Global.Business.My.Resources.Resources.Blue_F3
        Me.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnAceptar.Location = New System.Drawing.Point(12, 11)
        Me.BtnAceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(85, 86)
        Me.BtnAceptar.TabIndex = 9
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'LvwArticulos
        '
        Me.LvwArticulos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader9, Me.ColumnHeader14, Me.ColumnHeader16})
        Me.LvwArticulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvwArticulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LvwArticulos.FullRowSelect = True
        Me.LvwArticulos.HideSelection = False
        Me.LvwArticulos.Location = New System.Drawing.Point(3, 18)
        Me.LvwArticulos.Margin = New System.Windows.Forms.Padding(4)
        Me.LvwArticulos.MultiSelect = False
        Me.LvwArticulos.Name = "LvwArticulos"
        Me.LvwArticulos.Size = New System.Drawing.Size(906, 806)
        Me.LvwArticulos.TabIndex = 2
        Me.LvwArticulos.UseCompatibleStateImageBehavior = False
        Me.LvwArticulos.View = System.Windows.Forms.View.Details
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LvwLotesInventario)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(633, 404)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lotes Inventario"
        '
        'LvwLotesInventario
        '
        Me.LvwLotesInventario.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LvwLotesInventario.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader15})
        Me.LvwLotesInventario.FullRowSelect = True
        Me.LvwLotesInventario.HideSelection = False
        Me.LvwLotesInventario.Location = New System.Drawing.Point(17, 23)
        Me.LvwLotesInventario.Margin = New System.Windows.Forms.Padding(4)
        Me.LvwLotesInventario.Name = "LvwLotesInventario"
        Me.LvwLotesInventario.Size = New System.Drawing.Size(600, 361)
        Me.LvwLotesInventario.TabIndex = 0
        Me.LvwLotesInventario.UseCompatibleStateImageBehavior = False
        Me.LvwLotesInventario.View = System.Windows.Forms.View.Details
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.LvwLotesFactura)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 404)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(633, 423)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Lotes Seleccionados"
        '
        'LvwLotesFactura
        '
        Me.LvwLotesFactura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LvwLotesFactura.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13})
        Me.LvwLotesFactura.FullRowSelect = True
        Me.LvwLotesFactura.HideSelection = False
        Me.LvwLotesFactura.Location = New System.Drawing.Point(17, 23)
        Me.LvwLotesFactura.Margin = New System.Windows.Forms.Padding(4)
        Me.LvwLotesFactura.Name = "LvwLotesFactura"
        Me.LvwLotesFactura.Size = New System.Drawing.Size(600, 380)
        Me.LvwLotesFactura.TabIndex = 1
        Me.LvwLotesFactura.UseCompatibleStateImageBehavior = False
        Me.LvwLotesFactura.View = System.Windows.Forms.View.Details
        '
        'PnlArticulos
        '
        Me.PnlArticulos.Controls.Add(Me.GroupBox1)
        Me.PnlArticulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlArticulos.Location = New System.Drawing.Point(112, 0)
        Me.PnlArticulos.Name = "PnlArticulos"
        Me.PnlArticulos.Size = New System.Drawing.Size(912, 827)
        Me.PnlArticulos.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LvwArticulos)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(912, 827)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Artículos Facturados"
        '
        'PnlDetalle
        '
        Me.PnlDetalle.Controls.Add(Me.GroupBox3)
        Me.PnlDetalle.Controls.Add(Me.GroupBox2)
        Me.PnlDetalle.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlDetalle.Location = New System.Drawing.Point(1024, 0)
        Me.PnlDetalle.Name = "PnlDetalle"
        Me.PnlDetalle.Size = New System.Drawing.Size(633, 827)
        Me.PnlDetalle.TabIndex = 9
        '
        'FrmLoteSeleccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1657, 827)
        Me.Controls.Add(Me.PnlArticulos)
        Me.Controls.Add(Me.PnlDetalle)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLoteSeleccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selección de Lotes"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.PnlArticulos.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.PnlDetalle.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents BtnSalir As Windows.Forms.Button
    Friend WithEvents BtnAceptar As Windows.Forms.Button
    Friend WithEvents LvwArticulos As Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents LvwLotesInventario As Windows.Forms.ListView
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents ColumnHeader4 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As Windows.Forms.ColumnHeader
    Friend WithEvents LvwLotesFactura As Windows.Forms.ListView
    Friend WithEvents ColumnHeader10 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As Windows.Forms.ColumnHeader
    Friend WithEvents PnlArticulos As Windows.Forms.Panel
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents PnlDetalle As Windows.Forms.Panel
    Friend WithEvents ColumnHeader14 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As Windows.Forms.ColumnHeader
End Class
