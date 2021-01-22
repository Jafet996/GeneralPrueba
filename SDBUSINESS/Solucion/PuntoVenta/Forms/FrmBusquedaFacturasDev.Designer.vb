<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBusquedaFacturasDev
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBusquedaFacturasDev))
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.RdbNombre = New System.Windows.Forms.RadioButton()
        Me.DtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.TxtClienteNombre = New System.Windows.Forms.TextBox()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.RdbFecha = New System.Windows.Forms.RadioButton()
        Me.RdbCliente = New System.Windows.Forms.RadioButton()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LvwFacturas = New System.Windows.Forms.ListView()
        Me.DtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAceptar.ForeColor = System.Drawing.Color.White
        Me.BtnAceptar.Location = New System.Drawing.Point(622, 60)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(92, 35)
        Me.BtnAceptar.TabIndex = 5
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSalir.ForeColor = System.Drawing.Color.White
        Me.BtnSalir.Location = New System.Drawing.Point(622, 101)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(92, 35)
        Me.BtnSalir.TabIndex = 3
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(88, 72)
        Me.TxtNombre.MaxLength = 50
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(317, 20)
        Me.TxtNombre.TabIndex = 9
        '
        'RdbNombre
        '
        Me.RdbNombre.AutoSize = True
        Me.RdbNombre.ForeColor = System.Drawing.Color.White
        Me.RdbNombre.Location = New System.Drawing.Point(21, 72)
        Me.RdbNombre.Name = "RdbNombre"
        Me.RdbNombre.Size = New System.Drawing.Size(62, 17)
        Me.RdbNombre.TabIndex = 8
        Me.RdbNombre.TabStop = True
        Me.RdbNombre.Text = "Nombre"
        Me.RdbNombre.UseVisualStyleBackColor = True
        '
        'DtpFechaDesde
        '
        Me.DtpFechaDesde.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaDesde.Location = New System.Drawing.Point(88, 17)
        Me.DtpFechaDesde.Name = "DtpFechaDesde"
        Me.DtpFechaDesde.Size = New System.Drawing.Size(95, 20)
        Me.DtpFechaDesde.TabIndex = 1
        '
        'BtnBuscar
        '
        Me.BtnBuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBuscar.ForeColor = System.Drawing.Color.White
        Me.BtnBuscar.Location = New System.Drawing.Point(622, 19)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(92, 35)
        Me.BtnBuscar.TabIndex = 2
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.UseVisualStyleBackColor = False
        '
        'TxtClienteNombre
        '
        Me.TxtClienteNombre.Location = New System.Drawing.Point(189, 42)
        Me.TxtClienteNombre.Name = "TxtClienteNombre"
        Me.TxtClienteNombre.ReadOnly = True
        Me.TxtClienteNombre.Size = New System.Drawing.Size(216, 20)
        Me.TxtClienteNombre.TabIndex = 7
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(88, 42)
        Me.TxtCliente.MaxLength = 6
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(95, 20)
        Me.TxtCliente.TabIndex = 0
        '
        'RdbFecha
        '
        Me.RdbFecha.AutoSize = True
        Me.RdbFecha.ForeColor = System.Drawing.Color.White
        Me.RdbFecha.Location = New System.Drawing.Point(21, 19)
        Me.RdbFecha.Name = "RdbFecha"
        Me.RdbFecha.Size = New System.Drawing.Size(56, 17)
        Me.RdbFecha.TabIndex = 1
        Me.RdbFecha.TabStop = True
        Me.RdbFecha.Text = "Desde"
        Me.RdbFecha.UseVisualStyleBackColor = True
        '
        'RdbCliente
        '
        Me.RdbCliente.AutoSize = True
        Me.RdbCliente.ForeColor = System.Drawing.Color.White
        Me.RdbCliente.Location = New System.Drawing.Point(21, 44)
        Me.RdbCliente.Name = "RdbCliente"
        Me.RdbCliente.Size = New System.Drawing.Size(57, 17)
        Me.RdbCliente.TabIndex = 0
        Me.RdbCliente.TabStop = True
        Me.RdbCliente.Text = "Cliente"
        Me.RdbCliente.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.BtnAceptar)
        Me.GroupBox1.Controls.Add(Me.BtnSalir)
        Me.GroupBox1.Controls.Add(Me.BtnBuscar)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(741, 153)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'LvwFacturas
        '
        Me.LvwFacturas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.LvwFacturas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvwFacturas.FullRowSelect = True
        Me.LvwFacturas.Location = New System.Drawing.Point(0, 153)
        Me.LvwFacturas.Name = "LvwFacturas"
        Me.LvwFacturas.Size = New System.Drawing.Size(741, 354)
        Me.LvwFacturas.TabIndex = 6
        Me.LvwFacturas.UseCompatibleStateImageBehavior = False
        Me.LvwFacturas.View = System.Windows.Forms.View.Details
        '
        'DtpFechaHasta
        '
        Me.DtpFechaHasta.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaHasta.Location = New System.Drawing.Point(230, 17)
        Me.DtpFechaHasta.Name = "DtpFechaHasta"
        Me.DtpFechaHasta.Size = New System.Drawing.Size(95, 20)
        Me.DtpFechaHasta.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(189, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Hasta"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TxtNombre)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.RdbCliente)
        Me.Panel1.Controls.Add(Me.DtpFechaHasta)
        Me.Panel1.Controls.Add(Me.RdbFecha)
        Me.Panel1.Controls.Add(Me.TxtCliente)
        Me.Panel1.Controls.Add(Me.TxtClienteNombre)
        Me.Panel1.Controls.Add(Me.DtpFechaDesde)
        Me.Panel1.Controls.Add(Me.RdbNombre)
        Me.Panel1.Location = New System.Drawing.Point(12, 19)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(593, 117)
        Me.Panel1.TabIndex = 12
        '
        'FrmBusquedaFacturasDev
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(741, 507)
        Me.Controls.Add(Me.LvwFacturas)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBusquedaFacturasDev"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Devolución de Facturas"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents BtnAceptar As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents TxtNombre As TextBox
    Friend WithEvents RdbNombre As RadioButton
    Friend WithEvents DtpFechaDesde As DateTimePicker
    Friend WithEvents BtnBuscar As Button
    Friend WithEvents TxtClienteNombre As TextBox
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents TxtCliente As TextBox
    Friend WithEvents RdbFecha As RadioButton
    Friend WithEvents RdbCliente As RadioButton
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents LvwFacturas As ListView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents DtpFechaHasta As DateTimePicker
End Class
