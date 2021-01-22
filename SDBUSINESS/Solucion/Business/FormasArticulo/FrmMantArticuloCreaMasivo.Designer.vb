<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMantArticuloCreaMasivo
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantArticuloCreaMasivo))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnCrear = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmbCategoria = New System.Windows.Forms.ComboBox()
        Me.CmbUnidadMedida = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbSubCategoria = New System.Windows.Forms.ComboBox()
        Me.LvwArticulos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CMSDetalle = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuMarcarTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDesmarcharTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuProductoServicio = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImgLstArticulos = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtUtilidad = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.CMSDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnCrear)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(113, 831)
        Me.Panel1.TabIndex = 1
        '
        'BtnCrear
        '
        Me.BtnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCrear.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCrear.ForeColor = System.Drawing.Color.White
        Me.BtnCrear.Location = New System.Drawing.Point(12, 12)
        Me.BtnCrear.Name = "BtnCrear"
        Me.BtnCrear.Size = New System.Drawing.Size(83, 73)
        Me.BtnCrear.TabIndex = 8
        Me.BtnCrear.Text = "Crear"
        Me.BtnCrear.UseVisualStyleBackColor = True
        '
        'BtnSalir
        '
        Me.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.ForeColor = System.Drawing.Color.White
        Me.BtnSalir.Location = New System.Drawing.Point(12, 91)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(83, 73)
        Me.BtnSalir.TabIndex = 7
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TxtUtilidad)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.CmbDepartamento)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.CmbCategoria)
        Me.Panel2.Controls.Add(Me.CmbUnidadMedida)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.CmbSubCategoria)
        Me.Panel2.Location = New System.Drawing.Point(129, 11)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1500, 74)
        Me.Panel2.TabIndex = 2
        '
        'CmbDepartamento
        '
        Me.CmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbDepartamento.FormattingEnabled = True
        Me.CmbDepartamento.Location = New System.Drawing.Point(747, 23)
        Me.CmbDepartamento.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbDepartamento.Name = "CmbDepartamento"
        Me.CmbDepartamento.Size = New System.Drawing.Size(195, 24)
        Me.CmbDepartamento.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.Location = New System.Drawing.Point(629, 27)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 17)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Departamento"
        '
        'CmbCategoria
        '
        Me.CmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCategoria.FormattingEnabled = True
        Me.CmbCategoria.ItemHeight = 16
        Me.CmbCategoria.Location = New System.Drawing.Point(104, 23)
        Me.CmbCategoria.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbCategoria.Name = "CmbCategoria"
        Me.CmbCategoria.Size = New System.Drawing.Size(195, 24)
        Me.CmbCategoria.TabIndex = 15
        '
        'CmbUnidadMedida
        '
        Me.CmbUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbUnidadMedida.FormattingEnabled = True
        Me.CmbUnidadMedida.Location = New System.Drawing.Point(1074, 23)
        Me.CmbUnidadMedida.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbUnidadMedida.Name = "CmbUnidadMedida"
        Me.CmbUnidadMedida.Size = New System.Drawing.Size(195, 24)
        Me.CmbUnidadMedida.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.Location = New System.Drawing.Point(950, 27)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 17)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Unidad Medida"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(18, 27)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 17)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Categoría"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.Location = New System.Drawing.Point(307, 27)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Sub Categoría"
        '
        'CmbSubCategoria
        '
        Me.CmbSubCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSubCategoria.FormattingEnabled = True
        Me.CmbSubCategoria.Location = New System.Drawing.Point(426, 23)
        Me.CmbSubCategoria.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbSubCategoria.Name = "CmbSubCategoria"
        Me.CmbSubCategoria.Size = New System.Drawing.Size(195, 24)
        Me.CmbSubCategoria.TabIndex = 18
        '
        'LvwArticulos
        '
        Me.LvwArticulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LvwArticulos.CheckBoxes = True
        Me.LvwArticulos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.LvwArticulos.ContextMenuStrip = Me.CMSDetalle
        Me.LvwArticulos.FullRowSelect = True
        Me.LvwArticulos.HideSelection = False
        Me.LvwArticulos.Location = New System.Drawing.Point(129, 91)
        Me.LvwArticulos.Name = "LvwArticulos"
        Me.LvwArticulos.Size = New System.Drawing.Size(1500, 726)
        Me.LvwArticulos.SmallImageList = Me.ImgLstArticulos
        Me.LvwArticulos.TabIndex = 3
        Me.LvwArticulos.UseCompatibleStateImageBehavior = False
        Me.LvwArticulos.View = System.Windows.Forms.View.Details
        '
        'CMSDetalle
        '
        Me.CMSDetalle.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CMSDetalle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMarcarTodos, Me.MnuDesmarcharTodos, Me.MnuProductoServicio})
        Me.CMSDetalle.Name = "CMSDetalle"
        Me.CMSDetalle.Size = New System.Drawing.Size(194, 76)
        '
        'MnuMarcarTodos
        '
        Me.MnuMarcarTodos.Name = "MnuMarcarTodos"
        Me.MnuMarcarTodos.Size = New System.Drawing.Size(193, 24)
        Me.MnuMarcarTodos.Text = "Marcar Todos"
        '
        'MnuDesmarcharTodos
        '
        Me.MnuDesmarcharTodos.Name = "MnuDesmarcharTodos"
        Me.MnuDesmarcharTodos.Size = New System.Drawing.Size(193, 24)
        Me.MnuDesmarcharTodos.Text = "Desmarcar Todos"
        '
        'MnuProductoServicio
        '
        Me.MnuProductoServicio.Name = "MnuProductoServicio"
        Me.MnuProductoServicio.Size = New System.Drawing.Size(193, 24)
        Me.MnuProductoServicio.Text = "Producto"
        '
        'ImgLstArticulos
        '
        Me.ImgLstArticulos.ImageStream = CType(resources.GetObject("ImgLstArticulos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgLstArticulos.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgLstArticulos.Images.SetKeyName(0, "check.ico")
        Me.ImgLstArticulos.Images.SetKeyName(1, "delete.ico")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(1277, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 17)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "% Utilidad"
        '
        'TxtUtilidad
        '
        Me.TxtUtilidad.Location = New System.Drawing.Point(1365, 25)
        Me.TxtUtilidad.Name = "TxtUtilidad"
        Me.TxtUtilidad.Size = New System.Drawing.Size(100, 22)
        Me.TxtUtilidad.TabIndex = 22
        '
        'FrmMantArticuloCreaMasivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1644, 831)
        Me.Controls.Add(Me.LvwArticulos)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantArticuloCreaMasivo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Creación Artículos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.CMSDetalle.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents CmbDepartamento As Windows.Forms.ComboBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents CmbCategoria As Windows.Forms.ComboBox
    Friend WithEvents CmbUnidadMedida As Windows.Forms.ComboBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents CmbSubCategoria As Windows.Forms.ComboBox
    Friend WithEvents LvwArticulos As Windows.Forms.ListView
    Friend WithEvents BtnCrear As Windows.Forms.Button
    Friend WithEvents BtnSalir As Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As Windows.Forms.ColumnHeader
    Friend WithEvents ImgLstArticulos As Windows.Forms.ImageList
    Friend WithEvents ColumnHeader6 As Windows.Forms.ColumnHeader
    Friend WithEvents CMSDetalle As Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuMarcarTodos As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuDesmarcharTodos As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuProductoServicio As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader7 As Windows.Forms.ColumnHeader
    Friend WithEvents TxtUtilidad As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
End Class
