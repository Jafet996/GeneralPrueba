<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAsientoLista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAsientoLista))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnReversa = New System.Windows.Forms.Button()
        Me.BtnBorrar = New System.Windows.Forms.Button()
        Me.BtnAplicar = New System.Windows.Forms.Button()
        Me.BtnDetalle = New System.Windows.Forms.Button()
        Me.BtnModificar = New System.Windows.Forms.Button()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.GbFiltros = New System.Windows.Forms.GroupBox()
        Me.GbPeriodo = New System.Windows.Forms.GroupBox()
        Me.ChkPeriodo = New System.Windows.Forms.CheckBox()
        Me.CmbAnnio = New System.Windows.Forms.ComboBox()
        Me.CmbMes = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GbComentario = New System.Windows.Forms.GroupBox()
        Me.CmbEstado = New System.Windows.Forms.ComboBox()
        Me.ChkEstado = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GbFechas = New System.Windows.Forms.GroupBox()
        Me.ChkFechas = New System.Windows.Forms.CheckBox()
        Me.DtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GbTipoAsiento = New System.Windows.Forms.GroupBox()
        Me.ChkAsientoTipo = New System.Windows.Forms.CheckBox()
        Me.CmbTipoAsiento = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LvwAsientos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CmsAyudaLvw = New System.Windows.Forms.ContextMenuStrip()
        Me.BtnMarcarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnDesmarcarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnInvertirSeleccion = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnMarcarSeleccionados = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnDesmarcarSeleccionados = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrgProgreso = New System.Windows.Forms.ProgressBar()
        Me.Panel1.SuspendLayout()
        Me.GbFiltros.SuspendLayout()
        Me.GbPeriodo.SuspendLayout()
        Me.GbComentario.SuspendLayout()
        Me.GbFechas.SuspendLayout()
        Me.GbTipoAsiento.SuspendLayout()
        Me.CmsAyudaLvw.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnReversa)
        Me.Panel1.Controls.Add(Me.BtnBorrar)
        Me.Panel1.Controls.Add(Me.BtnAplicar)
        Me.Panel1.Controls.Add(Me.BtnDetalle)
        Me.Panel1.Controls.Add(Me.BtnModificar)
        Me.Panel1.Controls.Add(Me.BtnNuevo)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(80, 740)
        Me.Panel1.TabIndex = 0
        '
        'BtnReversa
        '
        Me.BtnReversa.BackColor = System.Drawing.Color.White
        Me.BtnReversa.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_F7
        Me.BtnReversa.Location = New System.Drawing.Point(7, 401)
        Me.BtnReversa.Name = "BtnReversa"
        Me.BtnReversa.Size = New System.Drawing.Size(66, 73)
        Me.BtnReversa.TabIndex = 11
        Me.BtnReversa.Text = "Reversa"
        Me.BtnReversa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnReversa.UseVisualStyleBackColor = False
        '
        'BtnBorrar
        '
        Me.BtnBorrar.BackColor = System.Drawing.Color.White
        Me.BtnBorrar.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_F6
        Me.BtnBorrar.Location = New System.Drawing.Point(7, 322)
        Me.BtnBorrar.Name = "BtnBorrar"
        Me.BtnBorrar.Size = New System.Drawing.Size(66, 73)
        Me.BtnBorrar.TabIndex = 10
        Me.BtnBorrar.Text = "Borrar"
        Me.BtnBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnBorrar.UseVisualStyleBackColor = False
        '
        'BtnAplicar
        '
        Me.BtnAplicar.BackColor = System.Drawing.Color.White
        Me.BtnAplicar.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_F5
        Me.BtnAplicar.Location = New System.Drawing.Point(7, 243)
        Me.BtnAplicar.Name = "BtnAplicar"
        Me.BtnAplicar.Size = New System.Drawing.Size(66, 73)
        Me.BtnAplicar.TabIndex = 9
        Me.BtnAplicar.Text = "Aplicar"
        Me.BtnAplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAplicar.UseVisualStyleBackColor = False
        '
        'BtnDetalle
        '
        Me.BtnDetalle.BackColor = System.Drawing.Color.White
        Me.BtnDetalle.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_F4
        Me.BtnDetalle.Location = New System.Drawing.Point(7, 164)
        Me.BtnDetalle.Name = "BtnDetalle"
        Me.BtnDetalle.Size = New System.Drawing.Size(66, 73)
        Me.BtnDetalle.TabIndex = 7
        Me.BtnDetalle.Text = "Detalle"
        Me.BtnDetalle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnDetalle.UseVisualStyleBackColor = False
        '
        'BtnModificar
        '
        Me.BtnModificar.BackColor = System.Drawing.Color.White
        Me.BtnModificar.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_F3
        Me.BtnModificar.Location = New System.Drawing.Point(7, 85)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(66, 73)
        Me.BtnModificar.TabIndex = 6
        Me.BtnModificar.Text = "Modificar"
        Me.BtnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnModificar.UseVisualStyleBackColor = False
        '
        'BtnNuevo
        '
        Me.BtnNuevo.BackColor = System.Drawing.Color.White
        Me.BtnNuevo.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_F2
        Me.BtnNuevo.Location = New System.Drawing.Point(7, 6)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(66, 73)
        Me.BtnNuevo.TabIndex = 5
        Me.BtnNuevo.Text = "Nuevo"
        Me.BtnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnNuevo.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(8, 480)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(66, 73)
        Me.BtnSalir.TabIndex = 4
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'GbFiltros
        '
        Me.GbFiltros.Controls.Add(Me.GbPeriodo)
        Me.GbFiltros.Controls.Add(Me.GbComentario)
        Me.GbFiltros.Controls.Add(Me.GbFechas)
        Me.GbFiltros.Controls.Add(Me.GbTipoAsiento)
        Me.GbFiltros.Location = New System.Drawing.Point(87, 4)
        Me.GbFiltros.Name = "GbFiltros"
        Me.GbFiltros.Size = New System.Drawing.Size(1232, 97)
        Me.GbFiltros.TabIndex = 1
        Me.GbFiltros.TabStop = False
        Me.GbFiltros.Text = "Filtros"
        '
        'GbPeriodo
        '
        Me.GbPeriodo.Controls.Add(Me.ChkPeriodo)
        Me.GbPeriodo.Controls.Add(Me.CmbAnnio)
        Me.GbPeriodo.Controls.Add(Me.CmbMes)
        Me.GbPeriodo.Controls.Add(Me.Label4)
        Me.GbPeriodo.Controls.Add(Me.Label5)
        Me.GbPeriodo.Location = New System.Drawing.Point(903, 13)
        Me.GbPeriodo.Name = "GbPeriodo"
        Me.GbPeriodo.Size = New System.Drawing.Size(324, 67)
        Me.GbPeriodo.TabIndex = 3
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
        Me.CmbAnnio.Location = New System.Drawing.Point(240, 25)
        Me.CmbAnnio.Name = "CmbAnnio"
        Me.CmbAnnio.Size = New System.Drawing.Size(71, 21)
        Me.CmbAnnio.TabIndex = 4
        '
        'CmbMes
        '
        Me.CmbMes.BackColor = System.Drawing.Color.White
        Me.CmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMes.FormattingEnabled = True
        Me.CmbMes.Location = New System.Drawing.Point(66, 25)
        Me.CmbMes.Name = "CmbMes"
        Me.CmbMes.Size = New System.Drawing.Size(124, 21)
        Me.CmbMes.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(196, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 21)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Año"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(22, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 21)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Mes"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GbComentario
        '
        Me.GbComentario.Controls.Add(Me.CmbEstado)
        Me.GbComentario.Controls.Add(Me.ChkEstado)
        Me.GbComentario.Controls.Add(Me.Label6)
        Me.GbComentario.Location = New System.Drawing.Point(278, 13)
        Me.GbComentario.Name = "GbComentario"
        Me.GbComentario.Size = New System.Drawing.Size(277, 67)
        Me.GbComentario.TabIndex = 2
        Me.GbComentario.TabStop = False
        '
        'CmbEstado
        '
        Me.CmbEstado.BackColor = System.Drawing.Color.White
        Me.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEstado.Enabled = False
        Me.CmbEstado.FormattingEnabled = True
        Me.CmbEstado.Location = New System.Drawing.Point(84, 25)
        Me.CmbEstado.Name = "CmbEstado"
        Me.CmbEstado.Size = New System.Drawing.Size(176, 21)
        Me.CmbEstado.TabIndex = 5
        '
        'ChkEstado
        '
        Me.ChkEstado.AutoSize = True
        Me.ChkEstado.Location = New System.Drawing.Point(4, 10)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(15, 14)
        Me.ChkEstado.TabIndex = 4
        Me.ChkEstado.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(24, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 21)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Estado"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GbFechas
        '
        Me.GbFechas.Controls.Add(Me.ChkFechas)
        Me.GbFechas.Controls.Add(Me.DtpFechaFinal)
        Me.GbFechas.Controls.Add(Me.Label3)
        Me.GbFechas.Controls.Add(Me.DtpFechaInicio)
        Me.GbFechas.Controls.Add(Me.Label2)
        Me.GbFechas.Location = New System.Drawing.Point(560, 13)
        Me.GbFechas.Name = "GbFechas"
        Me.GbFechas.Size = New System.Drawing.Size(337, 67)
        Me.GbFechas.TabIndex = 1
        Me.GbFechas.TabStop = False
        '
        'ChkFechas
        '
        Me.ChkFechas.AutoSize = True
        Me.ChkFechas.Location = New System.Drawing.Point(4, 9)
        Me.ChkFechas.Name = "ChkFechas"
        Me.ChkFechas.Size = New System.Drawing.Size(15, 14)
        Me.ChkFechas.TabIndex = 4
        Me.ChkFechas.UseVisualStyleBackColor = True
        '
        'DtpFechaFinal
        '
        Me.DtpFechaFinal.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaFinal.Enabled = False
        Me.DtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaFinal.Location = New System.Drawing.Point(223, 25)
        Me.DtpFechaFinal.Name = "DtpFechaFinal"
        Me.DtpFechaFinal.Size = New System.Drawing.Size(97, 20)
        Me.DtpFechaFinal.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(175, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 21)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Hasta"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DtpFechaInicio
        '
        Me.DtpFechaInicio.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaInicio.Enabled = False
        Me.DtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaInicio.Location = New System.Drawing.Point(72, 25)
        Me.DtpFechaInicio.Name = "DtpFechaInicio"
        Me.DtpFechaInicio.Size = New System.Drawing.Size(97, 20)
        Me.DtpFechaInicio.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(22, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 21)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Desde"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GbTipoAsiento
        '
        Me.GbTipoAsiento.Controls.Add(Me.ChkAsientoTipo)
        Me.GbTipoAsiento.Controls.Add(Me.CmbTipoAsiento)
        Me.GbTipoAsiento.Controls.Add(Me.Label1)
        Me.GbTipoAsiento.Location = New System.Drawing.Point(6, 13)
        Me.GbTipoAsiento.Name = "GbTipoAsiento"
        Me.GbTipoAsiento.Size = New System.Drawing.Size(266, 67)
        Me.GbTipoAsiento.TabIndex = 0
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
        Me.CmbTipoAsiento.Location = New System.Drawing.Point(69, 25)
        Me.CmbTipoAsiento.Name = "CmbTipoAsiento"
        Me.CmbTipoAsiento.Size = New System.Drawing.Size(176, 21)
        Me.CmbTipoAsiento.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(24, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LvwAsientos
        '
        Me.LvwAsientos.CheckBoxes = True
        Me.LvwAsientos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.LvwAsientos.ContextMenuStrip = Me.CmsAyudaLvw
        Me.LvwAsientos.FullRowSelect = True
        Me.LvwAsientos.Location = New System.Drawing.Point(80, 107)
        Me.LvwAsientos.Name = "LvwAsientos"
        Me.LvwAsientos.Size = New System.Drawing.Size(1239, 621)
        Me.LvwAsientos.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.LvwAsientos.TabIndex = 2
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
        Me.PrgProgreso.Location = New System.Drawing.Point(80, 727)
        Me.PrgProgreso.Name = "PrgProgreso"
        Me.PrgProgreso.Size = New System.Drawing.Size(1239, 13)
        Me.PrgProgreso.TabIndex = 6
        '
        'FrmAsientoLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1319, 740)
        Me.Controls.Add(Me.PrgProgreso)
        Me.Controls.Add(Me.LvwAsientos)
        Me.Controls.Add(Me.GbFiltros)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAsientoLista"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.GbFiltros.ResumeLayout(False)
        Me.GbPeriodo.ResumeLayout(False)
        Me.GbPeriodo.PerformLayout()
        Me.GbComentario.ResumeLayout(False)
        Me.GbComentario.PerformLayout()
        Me.GbFechas.ResumeLayout(False)
        Me.GbFechas.PerformLayout()
        Me.GbTipoAsiento.ResumeLayout(False)
        Me.GbTipoAsiento.PerformLayout()
        Me.CmsAyudaLvw.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnModificar As System.Windows.Forms.Button
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents GbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents GbTipoAsiento As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbTipoAsiento As System.Windows.Forms.ComboBox
    Friend WithEvents GbFechas As System.Windows.Forms.GroupBox
    Friend WithEvents DtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LvwAsientos As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GbPeriodo As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GbComentario As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbAnnio As System.Windows.Forms.ComboBox
    Friend WithEvents CmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents ChkPeriodo As System.Windows.Forms.CheckBox
    Friend WithEvents ChkEstado As System.Windows.Forms.CheckBox
    Friend WithEvents ChkFechas As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAsientoTipo As System.Windows.Forms.CheckBox
    Friend WithEvents CmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnDetalle As System.Windows.Forms.Button
    Friend WithEvents BtnBorrar As System.Windows.Forms.Button
    Friend WithEvents BtnAplicar As System.Windows.Forms.Button
    Friend WithEvents PrgProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents CmsAyudaLvw As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BtnMarcarTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnDesmarcarTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnInvertirSeleccion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnReversa As System.Windows.Forms.Button
    Friend WithEvents BtnMarcarSeleccionados As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnDesmarcarSeleccionados As System.Windows.Forms.ToolStripMenuItem
End Class
