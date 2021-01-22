<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSolictaCxCMovimientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSolictaCxCMovimientos))
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
        Me.CmsMenuSeleccion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuMarcarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDesmarcarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuInvertirSeleccion = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarcarSeleccionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesmarcarSeleccionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LblTotalSaldo = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.CmsMenuSeleccion.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnAceptar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(107, 673)
        Me.Panel1.TabIndex = 3
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.White
        Me.BtnAceptar.Image = Global.SDCXC.My.Resources.Resources.Blue_F3
        Me.BtnAceptar.Location = New System.Drawing.Point(9, 7)
        Me.BtnAceptar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(88, 90)
        Me.BtnAceptar.TabIndex = 6
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.SDCXC.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(9, 105)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(88, 90)
        Me.BtnSalir.TabIndex = 4
        Me.BtnSalir.Text = "Cancelar"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'LvwMovimientos
        '
        Me.LvwMovimientos.CheckBoxes = True
        Me.LvwMovimientos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.LvwMovimientos.ContextMenuStrip = Me.CmsMenuSeleccion
        Me.LvwMovimientos.Dock = System.Windows.Forms.DockStyle.Top
        Me.LvwMovimientos.FullRowSelect = True
        Me.LvwMovimientos.Location = New System.Drawing.Point(107, 0)
        Me.LvwMovimientos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LvwMovimientos.Name = "LvwMovimientos"
        Me.LvwMovimientos.Size = New System.Drawing.Size(1252, 605)
        Me.LvwMovimientos.TabIndex = 4
        Me.LvwMovimientos.UseCompatibleStateImageBehavior = False
        Me.LvwMovimientos.View = System.Windows.Forms.View.Details
        '
        'CmsMenuSeleccion
        '
        Me.CmsMenuSeleccion.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CmsMenuSeleccion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMarcarTodo, Me.MnuDesmarcarTodo, Me.MnuInvertirSeleccion, Me.MarcarSeleccionadosToolStripMenuItem, Me.DesmarcarSeleccionadosToolStripMenuItem})
        Me.CmsMenuSeleccion.Name = "CmsMenuSeleccion"
        Me.CmsMenuSeleccion.Size = New System.Drawing.Size(249, 124)
        '
        'MnuMarcarTodo
        '
        Me.MnuMarcarTodo.Name = "MnuMarcarTodo"
        Me.MnuMarcarTodo.Size = New System.Drawing.Size(248, 24)
        Me.MnuMarcarTodo.Text = "Marcar Todo"
        '
        'MnuDesmarcarTodo
        '
        Me.MnuDesmarcarTodo.Name = "MnuDesmarcarTodo"
        Me.MnuDesmarcarTodo.Size = New System.Drawing.Size(248, 24)
        Me.MnuDesmarcarTodo.Text = "Desmarcar Todo"
        '
        'MnuInvertirSeleccion
        '
        Me.MnuInvertirSeleccion.Name = "MnuInvertirSeleccion"
        Me.MnuInvertirSeleccion.Size = New System.Drawing.Size(248, 24)
        Me.MnuInvertirSeleccion.Text = "Invertir Selección"
        '
        'MarcarSeleccionadosToolStripMenuItem
        '
        Me.MarcarSeleccionadosToolStripMenuItem.Name = "MarcarSeleccionadosToolStripMenuItem"
        Me.MarcarSeleccionadosToolStripMenuItem.Size = New System.Drawing.Size(248, 24)
        Me.MarcarSeleccionadosToolStripMenuItem.Text = "Marcar Seleccionados"
        '
        'DesmarcarSeleccionadosToolStripMenuItem
        '
        Me.DesmarcarSeleccionadosToolStripMenuItem.Name = "DesmarcarSeleccionadosToolStripMenuItem"
        Me.DesmarcarSeleccionadosToolStripMenuItem.Size = New System.Drawing.Size(248, 24)
        Me.DesmarcarSeleccionadosToolStripMenuItem.Text = "Desmarcar Seleccionados"
        '
        'LblTotalSaldo
        '
        Me.LblTotalSaldo.BackColor = System.Drawing.Color.White
        Me.LblTotalSaldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblTotalSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalSaldo.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalSaldo.Location = New System.Drawing.Point(1135, 622)
        Me.LblTotalSaldo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTotalSaldo.Name = "LblTotalSaldo"
        Me.LblTotalSaldo.Size = New System.Drawing.Size(211, 36)
        Me.LblTotalSaldo.TabIndex = 66
        Me.LblTotalSaldo.Text = "0.00"
        Me.LblTotalSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label12.Location = New System.Drawing.Point(960, 624)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 31)
        Me.Label12.TabIndex = 65
        Me.Label12.Text = "Saldo"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.SDCXC.My.Resources.Resources.Total3
        Me.PictureBox2.Location = New System.Drawing.Point(947, 608)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(412, 64)
        Me.PictureBox2.TabIndex = 64
        Me.PictureBox2.TabStop = False
        '
        'FrmSolictaCxCMovimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1359, 673)
        Me.Controls.Add(Me.LblTotalSaldo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.LvwMovimientos)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSolictaCxCMovimientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccione los movimientos a aplicar"
        Me.Panel1.ResumeLayout(False)
        Me.CmsMenuSeleccion.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents LblTotalSaldo As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
