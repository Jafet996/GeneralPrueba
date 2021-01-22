<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmClienteTipoPrecio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClienteTipoPrecio))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnAplicar = New System.Windows.Forms.Button()
        Me.BtnConsultar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnInicializa = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.DtpFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtMontoFin = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtMontoIni = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbPrecio = New System.Windows.Forms.ComboBox()
        Me.LvwClientes = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MnuClienteOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuMarcarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDesMarcarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.MnuClienteOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnAplicar)
        Me.Panel1.Controls.Add(Me.BtnConsultar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnInicializa)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(84, 713)
        Me.Panel1.TabIndex = 2
        '
        'BtnAplicar
        '
        Me.BtnAplicar.BackColor = System.Drawing.Color.White
        Me.BtnAplicar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnAplicar.Location = New System.Drawing.Point(12, 100)
        Me.BtnAplicar.Name = "BtnAplicar"
        Me.BtnAplicar.Size = New System.Drawing.Size(57, 77)
        Me.BtnAplicar.TabIndex = 14
        Me.BtnAplicar.TabStop = False
        Me.BtnAplicar.Text = "Aplicar"
        Me.BtnAplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAplicar.UseVisualStyleBackColor = False
        '
        'BtnConsultar
        '
        Me.BtnConsultar.BackColor = System.Drawing.Color.White
        Me.BtnConsultar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnConsultar.Location = New System.Drawing.Point(12, 17)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(57, 77)
        Me.BtnConsultar.TabIndex = 13
        Me.BtnConsultar.TabStop = False
        Me.BtnConsultar.Text = "Consulta"
        Me.BtnConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnConsultar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(12, 183)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(57, 72)
        Me.BtnSalir.TabIndex = 12
        Me.BtnSalir.TabStop = False
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnInicializa
        '
        Me.BtnInicializa.BackColor = System.Drawing.Color.White
        Me.BtnInicializa.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F2
        Me.BtnInicializa.Location = New System.Drawing.Point(12, 611)
        Me.BtnInicializa.Name = "BtnInicializa"
        Me.BtnInicializa.Size = New System.Drawing.Size(57, 77)
        Me.BtnInicializa.TabIndex = 11
        Me.BtnInicializa.TabStop = False
        Me.BtnInicializa.Text = "Inicializa"
        Me.BtnInicializa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnInicializa.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DtpFechaFin)
        Me.GroupBox1.Controls.Add(Me.DtpFechaIni)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.SteelBlue
        Me.GroupBox1.Location = New System.Drawing.Point(90, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(292, 100)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(120, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Hasta"
        '
        'DtpFechaFin
        '
        Me.DtpFechaFin.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaFin.Location = New System.Drawing.Point(175, 42)
        Me.DtpFechaFin.Name = "DtpFechaFin"
        Me.DtpFechaFin.Size = New System.Drawing.Size(101, 22)
        Me.DtpFechaFin.TabIndex = 1
        '
        'DtpFechaIni
        '
        Me.DtpFechaIni.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaIni.Location = New System.Drawing.Point(13, 42)
        Me.DtpFechaIni.Name = "DtpFechaIni"
        Me.DtpFechaIni.Size = New System.Drawing.Size(101, 22)
        Me.DtpFechaIni.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtMontoFin)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TxtMontoIni)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.SteelBlue
        Me.GroupBox2.Location = New System.Drawing.Point(388, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(292, 100)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ventas"
        '
        'TxtMontoFin
        '
        Me.TxtMontoFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMontoFin.Location = New System.Drawing.Point(178, 42)
        Me.TxtMontoFin.Name = "TxtMontoFin"
        Me.TxtMontoFin.Size = New System.Drawing.Size(101, 22)
        Me.TxtMontoFin.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(123, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta"
        '
        'TxtMontoIni
        '
        Me.TxtMontoIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMontoIni.Location = New System.Drawing.Point(16, 42)
        Me.TxtMontoIni.Name = "TxtMontoIni"
        Me.TxtMontoIni.Size = New System.Drawing.Size(101, 22)
        Me.TxtMontoIni.TabIndex = 6
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.CmbPrecio)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.SteelBlue
        Me.GroupBox3.Location = New System.Drawing.Point(686, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(292, 100)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Precio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Tipo"
        '
        'CmbPrecio
        '
        Me.CmbPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbPrecio.FormattingEnabled = True
        Me.CmbPrecio.Location = New System.Drawing.Point(76, 41)
        Me.CmbPrecio.Name = "CmbPrecio"
        Me.CmbPrecio.Size = New System.Drawing.Size(194, 24)
        Me.CmbPrecio.TabIndex = 0
        '
        'LvwClientes
        '
        Me.LvwClientes.CheckBoxes = True
        Me.LvwClientes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.LvwClientes.ContextMenuStrip = Me.MnuClienteOpciones
        Me.LvwClientes.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LvwClientes.FullRowSelect = True
        Me.LvwClientes.Location = New System.Drawing.Point(84, 109)
        Me.LvwClientes.Name = "LvwClientes"
        Me.LvwClientes.Size = New System.Drawing.Size(903, 604)
        Me.LvwClientes.TabIndex = 6
        Me.LvwClientes.UseCompatibleStateImageBehavior = False
        Me.LvwClientes.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Codigo"
        Me.ColumnHeader1.Width = 83
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Nombre"
        Me.ColumnHeader2.Width = 520
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Total"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 168
        '
        'MnuClienteOpciones
        '
        Me.MnuClienteOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMarcarTodo, Me.MnuDesMarcarTodo})
        Me.MnuClienteOpciones.Name = "MnuClienteOpciones"
        Me.MnuClienteOpciones.Size = New System.Drawing.Size(161, 48)
        '
        'MnuMarcarTodo
        '
        Me.MnuMarcarTodo.Name = "MnuMarcarTodo"
        Me.MnuMarcarTodo.Size = New System.Drawing.Size(160, 22)
        Me.MnuMarcarTodo.Text = "Marcar Todo"
        '
        'MnuDesMarcarTodo
        '
        Me.MnuDesMarcarTodo.Name = "MnuDesMarcarTodo"
        Me.MnuDesMarcarTodo.Size = New System.Drawing.Size(160, 22)
        Me.MnuDesMarcarTodo.Text = "Desmarcar Todo"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Tipo Precio"
        Me.ColumnHeader4.Width = 105
        '
        'FrmClienteTipoPrecio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(987, 713)
        Me.Controls.Add(Me.LvwClientes)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmClienteTipoPrecio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualiza Tipo Precio"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.MnuClienteOpciones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnInicializa As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents DtpFechaFin As DateTimePicker
    Friend WithEvents DtpFechaIni As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtMontoFin As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtMontoIni As TextBox
    Friend WithEvents CmbPrecio As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents LvwClientes As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents BtnConsultar As Button
    Friend WithEvents BtnAplicar As Button
    Friend WithEvents MnuClienteOpciones As ContextMenuStrip
    Friend WithEvents MnuMarcarTodo As ToolStripMenuItem
    Friend WithEvents MnuDesMarcarTodo As ToolStripMenuItem
    Friend WithEvents ColumnHeader4 As ColumnHeader
End Class
