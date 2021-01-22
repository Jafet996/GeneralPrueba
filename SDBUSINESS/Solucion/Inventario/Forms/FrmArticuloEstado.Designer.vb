<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmArticuloEstado
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmArticuloEstado))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnActivar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.SCDetalle = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmbSucursal = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbBodega = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LvwArticulos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BtnRefrescar = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BtnMarcarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnDesmarcarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnInvertirSeleccion = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        CType(Me.SCDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCDetalle.Panel1.SuspendLayout()
        Me.SCDetalle.Panel2.SuspendLayout()
        Me.SCDetalle.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnRefrescar)
        Me.Panel1.Controls.Add(Me.BtnActivar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(71, 487)
        Me.Panel1.TabIndex = 12
        '
        'BtnActivar
        '
        Me.BtnActivar.BackColor = System.Drawing.Color.White
        Me.BtnActivar.Image = Global.Inventario.My.Resources.Resources.Blue_F3
        Me.BtnActivar.Location = New System.Drawing.Point(5, 6)
        Me.BtnActivar.Name = "BtnActivar"
        Me.BtnActivar.Size = New System.Drawing.Size(61, 71)
        Me.BtnActivar.TabIndex = 3
        Me.BtnActivar.Text = "Activar"
        Me.BtnActivar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnActivar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Inventario.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(5, 160)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(61, 71)
        Me.BtnSalir.TabIndex = 2
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'SCDetalle
        '
        Me.SCDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SCDetalle.Location = New System.Drawing.Point(71, 0)
        Me.SCDetalle.Name = "SCDetalle"
        Me.SCDetalle.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SCDetalle.Panel1
        '
        Me.SCDetalle.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SCDetalle.Panel2
        '
        Me.SCDetalle.Panel2.Controls.Add(Me.LvwArticulos)
        Me.SCDetalle.Size = New System.Drawing.Size(559, 487)
        Me.SCDetalle.SplitterDistance = 113
        Me.SCDetalle.TabIndex = 13
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmbSucursal)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.CmbBodega)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(541, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información"
        '
        'CmbSucursal
        '
        Me.CmbSucursal.BackColor = System.Drawing.Color.White
        Me.CmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbSucursal.FormattingEnabled = True
        Me.CmbSucursal.Location = New System.Drawing.Point(169, 31)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(288, 21)
        Me.CmbSucursal.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(115, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Sucursal"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(115, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Bodega"
        '
        'CmbBodega
        '
        Me.CmbBodega.BackColor = System.Drawing.Color.White
        Me.CmbBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBodega.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbBodega.FormattingEnabled = True
        Me.CmbBodega.Location = New System.Drawing.Point(169, 58)
        Me.CmbBodega.Name = "CmbBodega"
        Me.CmbBodega.Size = New System.Drawing.Size(288, 21)
        Me.CmbBodega.TabIndex = 26
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Inventario.My.Resources.Resources.box_closed
        Me.PictureBox1.Location = New System.Drawing.Point(67, 33)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'LvwArticulos
        '
        Me.LvwArticulos.CheckBoxes = True
        Me.LvwArticulos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.LvwArticulos.ContextMenuStrip = Me.ContextMenuStrip1
        Me.LvwArticulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvwArticulos.FullRowSelect = True
        Me.LvwArticulos.Location = New System.Drawing.Point(0, 0)
        Me.LvwArticulos.Name = "LvwArticulos"
        Me.LvwArticulos.Size = New System.Drawing.Size(559, 370)
        Me.LvwArticulos.TabIndex = 0
        Me.LvwArticulos.UseCompatibleStateImageBehavior = False
        Me.LvwArticulos.View = System.Windows.Forms.View.Details
        '
        'BtnRefrescar
        '
        Me.BtnRefrescar.BackColor = System.Drawing.Color.White
        Me.BtnRefrescar.Image = Global.Inventario.My.Resources.Resources.Blue_F5
        Me.BtnRefrescar.Location = New System.Drawing.Point(5, 83)
        Me.BtnRefrescar.Name = "BtnRefrescar"
        Me.BtnRefrescar.Size = New System.Drawing.Size(61, 71)
        Me.BtnRefrescar.TabIndex = 4
        Me.BtnRefrescar.Text = "Refrescar"
        Me.BtnRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnRefrescar.UseVisualStyleBackColor = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnMarcarTodo, Me.BtnDesmarcarTodo, Me.BtnInvertirSeleccion})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(165, 92)
        '
        'BtnMarcarTodo
        '
        Me.BtnMarcarTodo.Name = "BtnMarcarTodo"
        Me.BtnMarcarTodo.Size = New System.Drawing.Size(164, 22)
        Me.BtnMarcarTodo.Text = "Marcar Todo"
        '
        'BtnDesmarcarTodo
        '
        Me.BtnDesmarcarTodo.Name = "BtnDesmarcarTodo"
        Me.BtnDesmarcarTodo.Size = New System.Drawing.Size(164, 22)
        Me.BtnDesmarcarTodo.Text = "Desmarcar Todo"
        '
        'BtnInvertirSeleccion
        '
        Me.BtnInvertirSeleccion.Name = "BtnInvertirSeleccion"
        Me.BtnInvertirSeleccion.Size = New System.Drawing.Size(164, 22)
        Me.BtnInvertirSeleccion.Text = "Invertir Selección"
        '
        'FrmArticuloEstado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(630, 487)
        Me.Controls.Add(Me.SCDetalle)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmArticuloEstado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Articulos Inactivos con Saldo"
        Me.Panel1.ResumeLayout(False)
        Me.SCDetalle.Panel1.ResumeLayout(False)
        Me.SCDetalle.Panel2.ResumeLayout(False)
        CType(Me.SCDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCDetalle.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnActivar As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents SCDetalle As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbBodega As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LvwArticulos As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnRefrescar As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BtnMarcarTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnDesmarcarTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnInvertirSeleccion As System.Windows.Forms.ToolStripMenuItem
End Class
