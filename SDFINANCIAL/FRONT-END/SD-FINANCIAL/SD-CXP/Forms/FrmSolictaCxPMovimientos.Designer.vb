<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSolictaCxPMovimientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSolictaCxPMovimientos))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.LvwMovimientos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CmsMenuSeleccion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuMarcarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDesmarcarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuInvertirSeleccion = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarcarSeleccionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesmarcarSeleccionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCambiarMonto = New System.Windows.Forms.ToolStripMenuItem()
        Me.LstImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.LblTotalColones = New System.Windows.Forms.Label()
        Me.LblTituloTotalColones = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.LblTotalDolares = New System.Windows.Forms.Label()
        Me.LblTituloTotalDolares = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblMontoTotal = New System.Windows.Forms.Label()
        Me.LblTituloTotal = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.CmsMenuSeleccion.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnAceptar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(80, 655)
        Me.Panel1.TabIndex = 3
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.White
        Me.BtnAceptar.Image = Global.SDCXP.My.Resources.Resources.Blue_F3
        Me.BtnAceptar.Location = New System.Drawing.Point(7, 6)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(66, 73)
        Me.BtnAceptar.TabIndex = 6
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.SDCXP.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(7, 85)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(66, 73)
        Me.BtnSalir.TabIndex = 4
        Me.BtnSalir.Text = "Cancelar"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'LvwMovimientos
        '
        Me.LvwMovimientos.CheckBoxes = True
        Me.LvwMovimientos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15})
        Me.LvwMovimientos.ContextMenuStrip = Me.CmsMenuSeleccion
        Me.LvwMovimientos.Dock = System.Windows.Forms.DockStyle.Top
        Me.LvwMovimientos.FullRowSelect = True
        Me.LvwMovimientos.Location = New System.Drawing.Point(80, 0)
        Me.LvwMovimientos.Name = "LvwMovimientos"
        Me.LvwMovimientos.Size = New System.Drawing.Size(1154, 596)
        Me.LvwMovimientos.SmallImageList = Me.LstImagenes
        Me.LvwMovimientos.TabIndex = 4
        Me.LvwMovimientos.UseCompatibleStateImageBehavior = False
        Me.LvwMovimientos.View = System.Windows.Forms.View.Details
        '
        'CmsMenuSeleccion
        '
        Me.CmsMenuSeleccion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMarcarTodo, Me.MnuDesmarcarTodo, Me.MnuInvertirSeleccion, Me.MarcarSeleccionadosToolStripMenuItem, Me.DesmarcarSeleccionadosToolStripMenuItem, Me.MnuCambiarMonto})
        Me.CmsMenuSeleccion.Name = "CmsMenuSeleccion"
        Me.CmsMenuSeleccion.Size = New System.Drawing.Size(209, 136)
        '
        'MnuMarcarTodo
        '
        Me.MnuMarcarTodo.Name = "MnuMarcarTodo"
        Me.MnuMarcarTodo.Size = New System.Drawing.Size(208, 22)
        Me.MnuMarcarTodo.Text = "Marcar Todo"
        '
        'MnuDesmarcarTodo
        '
        Me.MnuDesmarcarTodo.Name = "MnuDesmarcarTodo"
        Me.MnuDesmarcarTodo.Size = New System.Drawing.Size(208, 22)
        Me.MnuDesmarcarTodo.Text = "Desmarcar Todo"
        '
        'MnuInvertirSeleccion
        '
        Me.MnuInvertirSeleccion.Name = "MnuInvertirSeleccion"
        Me.MnuInvertirSeleccion.Size = New System.Drawing.Size(208, 22)
        Me.MnuInvertirSeleccion.Text = "Invertir Selección"
        '
        'MarcarSeleccionadosToolStripMenuItem
        '
        Me.MarcarSeleccionadosToolStripMenuItem.Name = "MarcarSeleccionadosToolStripMenuItem"
        Me.MarcarSeleccionadosToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.MarcarSeleccionadosToolStripMenuItem.Text = "Marcar Seleccionados"
        '
        'DesmarcarSeleccionadosToolStripMenuItem
        '
        Me.DesmarcarSeleccionadosToolStripMenuItem.Name = "DesmarcarSeleccionadosToolStripMenuItem"
        Me.DesmarcarSeleccionadosToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.DesmarcarSeleccionadosToolStripMenuItem.Text = "Desmarcar Seleccionados"
        '
        'MnuCambiarMonto
        '
        Me.MnuCambiarMonto.Name = "MnuCambiarMonto"
        Me.MnuCambiarMonto.Size = New System.Drawing.Size(208, 22)
        Me.MnuCambiarMonto.Text = "Cambiar Monto"
        '
        'LstImagenes
        '
        Me.LstImagenes.ImageStream = CType(resources.GetObject("LstImagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.LstImagenes.TransparentColor = System.Drawing.Color.Transparent
        Me.LstImagenes.Images.SetKeyName(0, "delete.ico")
        Me.LstImagenes.Images.SetKeyName(1, "currency_dollar.ico")
        '
        'LblTotalColones
        '
        Me.LblTotalColones.BackColor = System.Drawing.Color.White
        Me.LblTotalColones.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblTotalColones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalColones.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalColones.Location = New System.Drawing.Point(538, 610)
        Me.LblTotalColones.Name = "LblTotalColones"
        Me.LblTotalColones.Size = New System.Drawing.Size(158, 29)
        Me.LblTotalColones.TabIndex = 66
        Me.LblTotalColones.Text = "0.00"
        Me.LblTotalColones.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTituloTotalColones
        '
        Me.LblTituloTotalColones.AutoSize = True
        Me.LblTituloTotalColones.BackColor = System.Drawing.Color.White
        Me.LblTituloTotalColones.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTituloTotalColones.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblTituloTotalColones.Location = New System.Drawing.Point(407, 613)
        Me.LblTituloTotalColones.Name = "LblTituloTotalColones"
        Me.LblTituloTotalColones.Size = New System.Drawing.Size(92, 25)
        Me.LblTituloTotalColones.TabIndex = 65
        Me.LblTituloTotalColones.Text = "Saldo ¢"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.SDCXP.My.Resources.Resources.Total3
        Me.PictureBox2.Location = New System.Drawing.Point(397, 599)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(309, 52)
        Me.PictureBox2.TabIndex = 64
        Me.PictureBox2.TabStop = False
        '
        'LblTotalDolares
        '
        Me.LblTotalDolares.BackColor = System.Drawing.Color.White
        Me.LblTotalDolares.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblTotalDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalDolares.ForeColor = System.Drawing.Color.DarkGreen
        Me.LblTotalDolares.Location = New System.Drawing.Point(223, 610)
        Me.LblTotalDolares.Name = "LblTotalDolares"
        Me.LblTotalDolares.Size = New System.Drawing.Size(158, 29)
        Me.LblTotalDolares.TabIndex = 69
        Me.LblTotalDolares.Text = "0.00"
        Me.LblTotalDolares.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTituloTotalDolares
        '
        Me.LblTituloTotalDolares.AutoSize = True
        Me.LblTituloTotalDolares.BackColor = System.Drawing.Color.White
        Me.LblTituloTotalDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTituloTotalDolares.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblTituloTotalDolares.Location = New System.Drawing.Point(92, 612)
        Me.LblTituloTotalDolares.Name = "LblTituloTotalDolares"
        Me.LblTituloTotalDolares.Size = New System.Drawing.Size(92, 25)
        Me.LblTituloTotalDolares.TabIndex = 68
        Me.LblTituloTotalDolares.Text = "Saldo $"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SDCXP.My.Resources.Resources.Total3
        Me.PictureBox1.Location = New System.Drawing.Point(82, 599)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(309, 52)
        Me.PictureBox1.TabIndex = 67
        Me.PictureBox1.TabStop = False
        '
        'LblMontoTotal
        '
        Me.LblMontoTotal.BackColor = System.Drawing.Color.White
        Me.LblMontoTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblMontoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMontoTotal.ForeColor = System.Drawing.Color.Red
        Me.LblMontoTotal.Location = New System.Drawing.Point(1066, 610)
        Me.LblMontoTotal.Name = "LblMontoTotal"
        Me.LblMontoTotal.Size = New System.Drawing.Size(158, 29)
        Me.LblMontoTotal.TabIndex = 72
        Me.LblMontoTotal.Text = "0.00"
        Me.LblMontoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTituloTotal
        '
        Me.LblTituloTotal.AutoSize = True
        Me.LblTituloTotal.BackColor = System.Drawing.Color.White
        Me.LblTituloTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTituloTotal.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblTituloTotal.Location = New System.Drawing.Point(935, 612)
        Me.LblTituloTotal.Name = "LblTituloTotal"
        Me.LblTituloTotal.Size = New System.Drawing.Size(85, 25)
        Me.LblTituloTotal.TabIndex = 71
        Me.LblTituloTotal.Text = "Total ¢"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.SDCXP.My.Resources.Resources.Total3
        Me.PictureBox3.Location = New System.Drawing.Point(925, 599)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(309, 52)
        Me.PictureBox3.TabIndex = 70
        Me.PictureBox3.TabStop = False
        '
        'FrmSolictaCxPMovimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1234, 655)
        Me.Controls.Add(Me.LblMontoTotal)
        Me.Controls.Add(Me.LblTituloTotal)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.LblTotalDolares)
        Me.Controls.Add(Me.LblTituloTotalDolares)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LblTotalColones)
        Me.Controls.Add(Me.LblTituloTotalColones)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.LvwMovimientos)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSolictaCxPMovimientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccione los movimientos a aplicar"
        Me.Panel1.ResumeLayout(False)
        Me.CmsMenuSeleccion.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents LvwMovimientos As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents CmsMenuSeleccion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuMarcarTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuDesmarcarTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuInvertirSeleccion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarcarSeleccionadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DesmarcarSeleccionadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblTotalColones As System.Windows.Forms.Label
    Friend WithEvents LblTituloTotalColones As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents LstImagenes As System.Windows.Forms.ImageList
    Friend WithEvents MnuCambiarMonto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LblTotalDolares As System.Windows.Forms.Label
    Friend WithEvents LblTituloTotalDolares As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LblMontoTotal As System.Windows.Forms.Label
    Friend WithEvents LblTituloTotal As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
End Class
