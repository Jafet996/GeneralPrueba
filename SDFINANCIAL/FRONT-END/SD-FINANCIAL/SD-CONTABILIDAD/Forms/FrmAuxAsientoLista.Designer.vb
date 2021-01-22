<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAuxAsientoLista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAuxAsientoLista))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnBorrar = New System.Windows.Forms.Button()
        Me.BtnAplicar = New System.Windows.Forms.Button()
        Me.BtnConsultar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CmbTotal = New System.Windows.Forms.ComboBox()
        Me.ChkTotal = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GbTipoAsiento = New System.Windows.Forms.GroupBox()
        Me.ChkAsientoTipo = New System.Windows.Forms.CheckBox()
        Me.CmbTipoAsiento = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GbPeriodo = New System.Windows.Forms.GroupBox()
        Me.ChkPeriodo = New System.Windows.Forms.CheckBox()
        Me.CmbAnnio = New System.Windows.Forms.ComboBox()
        Me.CmbMes = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GbComentario = New System.Windows.Forms.GroupBox()
        Me.CmbOrigen = New System.Windows.Forms.ComboBox()
        Me.ChkOrigen = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LvwAsientos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CmsAyudaLvw = New System.Windows.Forms.ContextMenuStrip()
        Me.BtnMarcarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnDesmarcarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnInvertirSeleccion = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnMarcarSeleccionados = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnDesmarcarSeleccionados = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrgProgreso = New System.Windows.Forms.ProgressBar()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GbTipoAsiento.SuspendLayout()
        Me.GbPeriodo.SuspendLayout()
        Me.GbComentario.SuspendLayout()
        Me.CmsAyudaLvw.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnBorrar)
        Me.Panel1.Controls.Add(Me.BtnAplicar)
        Me.Panel1.Controls.Add(Me.BtnConsultar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(80, 701)
        Me.Panel1.TabIndex = 1
        '
        'BtnBorrar
        '
        Me.BtnBorrar.BackColor = System.Drawing.Color.White
        Me.BtnBorrar.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_F4
        Me.BtnBorrar.Location = New System.Drawing.Point(5, 174)
        Me.BtnBorrar.Name = "BtnBorrar"
        Me.BtnBorrar.Size = New System.Drawing.Size(69, 73)
        Me.BtnBorrar.TabIndex = 8
        Me.BtnBorrar.Text = "Borrar"
        Me.BtnBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnBorrar.UseVisualStyleBackColor = False
        '
        'BtnAplicar
        '
        Me.BtnAplicar.BackColor = System.Drawing.Color.White
        Me.BtnAplicar.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_F3
        Me.BtnAplicar.Location = New System.Drawing.Point(5, 84)
        Me.BtnAplicar.Name = "BtnAplicar"
        Me.BtnAplicar.Size = New System.Drawing.Size(69, 84)
        Me.BtnAplicar.TabIndex = 6
        Me.BtnAplicar.Text = "Pasa Conta"
        Me.BtnAplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAplicar.UseVisualStyleBackColor = False
        '
        'BtnConsultar
        '
        Me.BtnConsultar.BackColor = System.Drawing.Color.White
        Me.BtnConsultar.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_F2
        Me.BtnConsultar.Location = New System.Drawing.Point(5, 5)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(69, 73)
        Me.BtnConsultar.TabIndex = 5
        Me.BtnConsultar.Text = "Detalle"
        Me.BtnConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnConsultar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(5, 253)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(69, 73)
        Me.BtnSalir.TabIndex = 4
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.GbTipoAsiento)
        Me.GroupBox1.Controls.Add(Me.GbPeriodo)
        Me.GroupBox1.Controls.Add(Me.GbComentario)
        Me.GroupBox1.Location = New System.Drawing.Point(86, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1167, 100)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CmbTotal)
        Me.GroupBox2.Controls.Add(Me.ChkTotal)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(876, 17)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(277, 67)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'CmbTotal
        '
        Me.CmbTotal.BackColor = System.Drawing.Color.White
        Me.CmbTotal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTotal.Enabled = False
        Me.CmbTotal.FormattingEnabled = True
        Me.CmbTotal.Items.AddRange(New Object() {"DESBALANCEADOS", "BALANCEADOS"})
        Me.CmbTotal.Location = New System.Drawing.Point(84, 23)
        Me.CmbTotal.Name = "CmbTotal"
        Me.CmbTotal.Size = New System.Drawing.Size(176, 21)
        Me.CmbTotal.TabIndex = 5
        '
        'ChkTotal
        '
        Me.ChkTotal.AutoSize = True
        Me.ChkTotal.Location = New System.Drawing.Point(4, 10)
        Me.ChkTotal.Name = "ChkTotal"
        Me.ChkTotal.Size = New System.Drawing.Size(15, 14)
        Me.ChkTotal.TabIndex = 4
        Me.ChkTotal.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(24, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 21)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Totales"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GbTipoAsiento
        '
        Me.GbTipoAsiento.Controls.Add(Me.ChkAsientoTipo)
        Me.GbTipoAsiento.Controls.Add(Me.CmbTipoAsiento)
        Me.GbTipoAsiento.Controls.Add(Me.Label1)
        Me.GbTipoAsiento.Location = New System.Drawing.Point(295, 17)
        Me.GbTipoAsiento.Name = "GbTipoAsiento"
        Me.GbTipoAsiento.Size = New System.Drawing.Size(266, 67)
        Me.GbTipoAsiento.TabIndex = 5
        Me.GbTipoAsiento.TabStop = False
        '
        'ChkAsientoTipo
        '
        Me.ChkAsientoTipo.AutoSize = True
        Me.ChkAsientoTipo.Location = New System.Drawing.Point(4, 9)
        Me.ChkAsientoTipo.Name = "ChkAsientoTipo"
        Me.ChkAsientoTipo.Size = New System.Drawing.Size(15, 14)
        Me.ChkAsientoTipo.TabIndex = 3
        Me.ChkAsientoTipo.UseVisualStyleBackColor = True
        '
        'CmbTipoAsiento
        '
        Me.CmbTipoAsiento.BackColor = System.Drawing.Color.White
        Me.CmbTipoAsiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoAsiento.Enabled = False
        Me.CmbTipoAsiento.FormattingEnabled = True
        Me.CmbTipoAsiento.Location = New System.Drawing.Point(69, 23)
        Me.CmbTipoAsiento.Name = "CmbTipoAsiento"
        Me.CmbTipoAsiento.Size = New System.Drawing.Size(176, 21)
        Me.CmbTipoAsiento.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(24, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GbPeriodo
        '
        Me.GbPeriodo.Controls.Add(Me.ChkPeriodo)
        Me.GbPeriodo.Controls.Add(Me.CmbAnnio)
        Me.GbPeriodo.Controls.Add(Me.CmbMes)
        Me.GbPeriodo.Controls.Add(Me.Label5)
        Me.GbPeriodo.Location = New System.Drawing.Point(567, 17)
        Me.GbPeriodo.Name = "GbPeriodo"
        Me.GbPeriodo.Size = New System.Drawing.Size(303, 67)
        Me.GbPeriodo.TabIndex = 4
        Me.GbPeriodo.TabStop = False
        '
        'ChkPeriodo
        '
        Me.ChkPeriodo.AutoSize = True
        Me.ChkPeriodo.Location = New System.Drawing.Point(4, 10)
        Me.ChkPeriodo.Name = "ChkPeriodo"
        Me.ChkPeriodo.Size = New System.Drawing.Size(15, 14)
        Me.ChkPeriodo.TabIndex = 4
        Me.ChkPeriodo.UseVisualStyleBackColor = True
        '
        'CmbAnnio
        '
        Me.CmbAnnio.BackColor = System.Drawing.Color.White
        Me.CmbAnnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAnnio.FormattingEnabled = True
        Me.CmbAnnio.Location = New System.Drawing.Point(212, 23)
        Me.CmbAnnio.Name = "CmbAnnio"
        Me.CmbAnnio.Size = New System.Drawing.Size(71, 21)
        Me.CmbAnnio.TabIndex = 4
        '
        'CmbMes
        '
        Me.CmbMes.BackColor = System.Drawing.Color.White
        Me.CmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMes.FormattingEnabled = True
        Me.CmbMes.Location = New System.Drawing.Point(82, 23)
        Me.CmbMes.Name = "CmbMes"
        Me.CmbMes.Size = New System.Drawing.Size(124, 21)
        Me.CmbMes.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(22, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 21)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Periodo"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GbComentario
        '
        Me.GbComentario.Controls.Add(Me.CmbOrigen)
        Me.GbComentario.Controls.Add(Me.ChkOrigen)
        Me.GbComentario.Controls.Add(Me.Label6)
        Me.GbComentario.Location = New System.Drawing.Point(12, 17)
        Me.GbComentario.Name = "GbComentario"
        Me.GbComentario.Size = New System.Drawing.Size(277, 67)
        Me.GbComentario.TabIndex = 3
        Me.GbComentario.TabStop = False
        '
        'CmbOrigen
        '
        Me.CmbOrigen.BackColor = System.Drawing.Color.White
        Me.CmbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbOrigen.Enabled = False
        Me.CmbOrigen.FormattingEnabled = True
        Me.CmbOrigen.Location = New System.Drawing.Point(84, 23)
        Me.CmbOrigen.Name = "CmbOrigen"
        Me.CmbOrigen.Size = New System.Drawing.Size(176, 21)
        Me.CmbOrigen.TabIndex = 5
        '
        'ChkOrigen
        '
        Me.ChkOrigen.AutoSize = True
        Me.ChkOrigen.Location = New System.Drawing.Point(4, 10)
        Me.ChkOrigen.Name = "ChkOrigen"
        Me.ChkOrigen.Size = New System.Drawing.Size(15, 14)
        Me.ChkOrigen.TabIndex = 4
        Me.ChkOrigen.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(24, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 21)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Origen"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LvwAsientos
        '
        Me.LvwAsientos.CheckBoxes = True
        Me.LvwAsientos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.LvwAsientos.ContextMenuStrip = Me.CmsAyudaLvw
        Me.LvwAsientos.FullRowSelect = True
        Me.LvwAsientos.Location = New System.Drawing.Point(80, 106)
        Me.LvwAsientos.Name = "LvwAsientos"
        Me.LvwAsientos.Size = New System.Drawing.Size(1178, 583)
        Me.LvwAsientos.TabIndex = 3
        Me.LvwAsientos.UseCompatibleStateImageBehavior = False
        Me.LvwAsientos.View = System.Windows.Forms.View.Details
        '
        'CmsAyudaLvw
        '
        Me.CmsAyudaLvw.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnMarcarTodo, Me.BtnDesmarcarTodo, Me.BtnInvertirSeleccion, Me.BtnMarcarSeleccionados, Me.BtnDesmarcarSeleccionados})
        Me.CmsAyudaLvw.Name = "CmsAyudaLvw"
        Me.CmsAyudaLvw.Size = New System.Drawing.Size(209, 136)
        '
        'BtnMarcarTodo
        '
        Me.BtnMarcarTodo.Name = "BtnMarcarTodo"
        Me.BtnMarcarTodo.Size = New System.Drawing.Size(208, 22)
        Me.BtnMarcarTodo.Text = "Marcar Todo"
        '
        'BtnDesmarcarTodo
        '
        Me.BtnDesmarcarTodo.Name = "BtnDesmarcarTodo"
        Me.BtnDesmarcarTodo.Size = New System.Drawing.Size(208, 22)
        Me.BtnDesmarcarTodo.Text = "Desmarcar Todo"
        '
        'BtnInvertirSeleccion
        '
        Me.BtnInvertirSeleccion.Name = "BtnInvertirSeleccion"
        Me.BtnInvertirSeleccion.Size = New System.Drawing.Size(208, 22)
        Me.BtnInvertirSeleccion.Text = "Invertir Selección"
        '
        'BtnMarcarSeleccionados
        '
        Me.BtnMarcarSeleccionados.Name = "BtnMarcarSeleccionados"
        Me.BtnMarcarSeleccionados.Size = New System.Drawing.Size(208, 22)
        Me.BtnMarcarSeleccionados.Text = "Marcar Seleccionados"
        '
        'BtnDesmarcarSeleccionados
        '
        Me.BtnDesmarcarSeleccionados.Name = "BtnDesmarcarSeleccionados"
        Me.BtnDesmarcarSeleccionados.Size = New System.Drawing.Size(208, 22)
        Me.BtnDesmarcarSeleccionados.Text = "Desmarcar Seleccionados"
        '
        'PrgProgreso
        '
        Me.PrgProgreso.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PrgProgreso.Location = New System.Drawing.Point(80, 688)
        Me.PrgProgreso.Name = "PrgProgreso"
        Me.PrgProgreso.Size = New System.Drawing.Size(1178, 13)
        Me.PrgProgreso.TabIndex = 5
        '
        'FrmAuxAsientoLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1258, 701)
        Me.Controls.Add(Me.PrgProgreso)
        Me.Controls.Add(Me.LvwAsientos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAuxAsientoLista"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GbTipoAsiento.ResumeLayout(False)
        Me.GbTipoAsiento.PerformLayout()
        Me.GbPeriodo.ResumeLayout(False)
        Me.GbPeriodo.PerformLayout()
        Me.GbComentario.ResumeLayout(False)
        Me.GbComentario.PerformLayout()
        Me.CmsAyudaLvw.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnAplicar As System.Windows.Forms.Button
    Friend WithEvents BtnConsultar As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GbComentario As System.Windows.Forms.GroupBox
    Friend WithEvents CmbOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents ChkOrigen As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GbPeriodo As System.Windows.Forms.GroupBox
    Friend WithEvents ChkPeriodo As System.Windows.Forms.CheckBox
    Friend WithEvents CmbAnnio As System.Windows.Forms.ComboBox
    Friend WithEvents CmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LvwAsientos As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GbTipoAsiento As System.Windows.Forms.GroupBox
    Friend WithEvents ChkAsientoTipo As System.Windows.Forms.CheckBox
    Friend WithEvents CmbTipoAsiento As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbTotal As System.Windows.Forms.ComboBox
    Friend WithEvents ChkTotal As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnBorrar As System.Windows.Forms.Button
    Friend WithEvents CmsAyudaLvw As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BtnMarcarTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnDesmarcarTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnInvertirSeleccion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrgProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents BtnMarcarSeleccionados As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnDesmarcarSeleccionados As System.Windows.Forms.ToolStripMenuItem
End Class
