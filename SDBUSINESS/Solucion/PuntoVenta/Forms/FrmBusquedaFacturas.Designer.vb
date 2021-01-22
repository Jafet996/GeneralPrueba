<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBusquedaFacturas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBusquedaFacturas))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.RdbNombre = New System.Windows.Forms.RadioButton()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.TxtClienteNombre = New System.Windows.Forms.TextBox()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.RdbFecha = New System.Windows.Forms.RadioButton()
        Me.RdbCliente = New System.Windows.Forms.RadioButton()
        Me.LvwFacturas = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.BtnAceptar)
        Me.GroupBox1.Controls.Add(Me.BtnSalir)
        Me.GroupBox1.Controls.Add(Me.TxtNombre)
        Me.GroupBox1.Controls.Add(Me.RdbNombre)
        Me.GroupBox1.Controls.Add(Me.DtpFecha)
        Me.GroupBox1.Controls.Add(Me.BtnBuscar)
        Me.GroupBox1.Controls.Add(Me.TxtClienteNombre)
        Me.GroupBox1.Controls.Add(Me.TxtCliente)
        Me.GroupBox1.Controls.Add(Me.RdbFecha)
        Me.GroupBox1.Controls.Add(Me.RdbCliente)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(737, 131)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.White
        Me.BtnAceptar.Location = New System.Drawing.Point(622, 53)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(92, 28)
        Me.BtnAceptar.TabIndex = 5
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Location = New System.Drawing.Point(622, 87)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(92, 28)
        Me.BtnSalir.TabIndex = 3
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(110, 81)
        Me.TxtNombre.MaxLength = 50
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(401, 20)
        Me.TxtNombre.TabIndex = 9
        '
        'RdbNombre
        '
        Me.RdbNombre.AutoSize = True
        Me.RdbNombre.ForeColor = System.Drawing.Color.White
        Me.RdbNombre.Location = New System.Drawing.Point(43, 81)
        Me.RdbNombre.Name = "RdbNombre"
        Me.RdbNombre.Size = New System.Drawing.Size(62, 17)
        Me.RdbNombre.TabIndex = 8
        Me.RdbNombre.TabStop = True
        Me.RdbNombre.Text = "Nombre"
        Me.RdbNombre.UseVisualStyleBackColor = True
        '
        'DtpFecha
        '
        Me.DtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFecha.Location = New System.Drawing.Point(110, 26)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(95, 20)
        Me.DtpFecha.TabIndex = 1
        '
        'BtnBuscar
        '
        Me.BtnBuscar.BackColor = System.Drawing.Color.White
        Me.BtnBuscar.Location = New System.Drawing.Point(622, 19)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(92, 28)
        Me.BtnBuscar.TabIndex = 2
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.UseVisualStyleBackColor = False
        '
        'TxtClienteNombre
        '
        Me.TxtClienteNombre.Location = New System.Drawing.Point(211, 53)
        Me.TxtClienteNombre.Name = "TxtClienteNombre"
        Me.TxtClienteNombre.ReadOnly = True
        Me.TxtClienteNombre.Size = New System.Drawing.Size(300, 20)
        Me.TxtClienteNombre.TabIndex = 7
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(110, 53)
        Me.TxtCliente.MaxLength = 6
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(95, 20)
        Me.TxtCliente.TabIndex = 0
        '
        'RdbFecha
        '
        Me.RdbFecha.AutoSize = True
        Me.RdbFecha.ForeColor = System.Drawing.Color.White
        Me.RdbFecha.Location = New System.Drawing.Point(43, 28)
        Me.RdbFecha.Name = "RdbFecha"
        Me.RdbFecha.Size = New System.Drawing.Size(55, 17)
        Me.RdbFecha.TabIndex = 1
        Me.RdbFecha.TabStop = True
        Me.RdbFecha.Text = "Fecha"
        Me.RdbFecha.UseVisualStyleBackColor = True
        '
        'RdbCliente
        '
        Me.RdbCliente.AutoSize = True
        Me.RdbCliente.ForeColor = System.Drawing.Color.White
        Me.RdbCliente.Location = New System.Drawing.Point(43, 55)
        Me.RdbCliente.Name = "RdbCliente"
        Me.RdbCliente.Size = New System.Drawing.Size(57, 17)
        Me.RdbCliente.TabIndex = 0
        Me.RdbCliente.TabStop = True
        Me.RdbCliente.Text = "Cliente"
        Me.RdbCliente.UseVisualStyleBackColor = True
        '
        'LvwFacturas
        '
        Me.LvwFacturas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.LvwFacturas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LvwFacturas.FullRowSelect = True
        Me.LvwFacturas.Location = New System.Drawing.Point(0, 133)
        Me.LvwFacturas.Name = "LvwFacturas"
        Me.LvwFacturas.Size = New System.Drawing.Size(737, 374)
        Me.LvwFacturas.TabIndex = 4
        Me.LvwFacturas.UseCompatibleStateImageBehavior = False
        Me.LvwFacturas.View = System.Windows.Forms.View.Details
        '
        'FrmBusquedaFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtnSalir
        Me.ClientSize = New System.Drawing.Size(737, 507)
        Me.Controls.Add(Me.LvwFacturas)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBusquedaFacturas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda Facturas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RdbFecha As System.Windows.Forms.RadioButton
    Friend WithEvents RdbCliente As System.Windows.Forms.RadioButton
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtClienteNombre As System.Windows.Forms.TextBox
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents LvwFacturas As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents RdbNombre As System.Windows.Forms.RadioButton
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
End Class
