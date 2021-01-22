<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAjusteDeFacturaConSaldo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAjusteDeFacturaConSaldo))
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtMonto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnCargar = New System.Windows.Forms.Button()
        Me.LvwMovimientos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MarcarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.White
        Me.BtnAceptar.Image = Global.SDCXC.My.Resources.Resources.Blue_F3
        Me.BtnAceptar.Location = New System.Drawing.Point(9, 105)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(56, 72)
        Me.BtnAceptar.TabIndex = 1
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.SDCXC.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(9, 193)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(56, 72)
        Me.BtnSalir.TabIndex = 2
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnCargar)
        Me.Panel1.Controls.Add(Me.BtnAceptar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(75, 410)
        Me.Panel1.TabIndex = 6
        '
        'TxtMonto
        '
        Me.TxtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMonto.Location = New System.Drawing.Point(433, 12)
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Size = New System.Drawing.Size(100, 22)
        Me.TxtMonto.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(211, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Ajustar facturas con saldo mayor a:"
        '
        'BtnCargar
        '
        Me.BtnCargar.BackColor = System.Drawing.Color.White
        Me.BtnCargar.Image = Global.SDCXC.My.Resources.Resources.Blue_F2
        Me.BtnCargar.Location = New System.Drawing.Point(9, 15)
        Me.BtnCargar.Name = "BtnCargar"
        Me.BtnCargar.Size = New System.Drawing.Size(56, 72)
        Me.BtnCargar.TabIndex = 3
        Me.BtnCargar.Text = "Cargar"
        Me.BtnCargar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnCargar.UseVisualStyleBackColor = False
        '
        'LvwMovimientos
        '
        Me.LvwMovimientos.CheckBoxes = True
        Me.LvwMovimientos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.LvwMovimientos.ContextMenuStrip = Me.ContextMenuStrip1
        Me.LvwMovimientos.FullRowSelect = True
        Me.LvwMovimientos.Location = New System.Drawing.Point(81, 40)
        Me.LvwMovimientos.Name = "LvwMovimientos"
        Me.LvwMovimientos.Size = New System.Drawing.Size(703, 370)
        Me.LvwMovimientos.TabIndex = 9
        Me.LvwMovimientos.UseCompatibleStateImageBehavior = False
        Me.LvwMovimientos.View = System.Windows.Forms.View.Details
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MarcarToolStripMenuItem, Me.TToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(166, 48)
        '
        'MarcarToolStripMenuItem
        '
        Me.MarcarToolStripMenuItem.Name = "MarcarToolStripMenuItem"
        Me.MarcarToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.MarcarToolStripMenuItem.Text = "Marcar todos"
        '
        'TToolStripMenuItem
        '
        Me.TToolStripMenuItem.Name = "TToolStripMenuItem"
        Me.TToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.TToolStripMenuItem.Text = "Desmarcar Todos"
        '
        'FrmAjusteDeFacturaConSaldo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 410)
        Me.Controls.Add(Me.LvwMovimientos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtMonto)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmAjusteDeFacturaConSaldo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajuste de facturas"
        Me.Panel1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnAceptar As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtMonto As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnCargar As Button
    Friend WithEvents LvwMovimientos As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents MarcarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnHeader9 As ColumnHeader
End Class
