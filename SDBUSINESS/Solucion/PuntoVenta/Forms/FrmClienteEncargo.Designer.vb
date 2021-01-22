<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClienteEncargo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClienteEncargo))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtDireccion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtApartado = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtTelefono1 = New System.Windows.Forms.TextBox()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtTelefono2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnImprime = New System.Windows.Forms.Button()
        Me.BtnCrearCliente = New System.Windows.Forms.Button()
        Me.BtnPreFactura = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.LvwAnotaciones = New System.Windows.Forms.ListView()
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BtnAnotacionAgregar = New System.Windows.Forms.Button()
        Me.BtnAnotacionEliminar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnArticuloEliminar = New System.Windows.Forms.Button()
        Me.BtnArticuloAgregar = New System.Windows.Forms.Button()
        Me.LvwEncargos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtDireccion)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtApartado)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TxtTelefono1)
        Me.GroupBox1.Controls.Add(Me.TxtEmail)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TxtTelefono2)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(91, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(487, 251)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'TxtDireccion
        '
        Me.TxtDireccion.BackColor = System.Drawing.Color.White
        Me.TxtDireccion.Location = New System.Drawing.Point(102, 105)
        Me.TxtDireccion.MaxLength = 200
        Me.TxtDireccion.Multiline = True
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.ReadOnly = True
        Me.TxtDireccion.Size = New System.Drawing.Size(361, 44)
        Me.TxtDireccion.TabIndex = 38
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Dirección"
        '
        'TxtApartado
        '
        Me.TxtApartado.BackColor = System.Drawing.Color.White
        Me.TxtApartado.Location = New System.Drawing.Point(102, 52)
        Me.TxtApartado.MaxLength = 20
        Me.TxtApartado.Name = "TxtApartado"
        Me.TxtApartado.ReadOnly = True
        Me.TxtApartado.Size = New System.Drawing.Size(100, 20)
        Me.TxtApartado.TabIndex = 32
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Teléfono 1"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "Apartado"
        '
        'TxtTelefono1
        '
        Me.TxtTelefono1.BackColor = System.Drawing.Color.White
        Me.TxtTelefono1.Location = New System.Drawing.Point(102, 26)
        Me.TxtTelefono1.MaxLength = 20
        Me.TxtTelefono1.Name = "TxtTelefono1"
        Me.TxtTelefono1.ReadOnly = True
        Me.TxtTelefono1.Size = New System.Drawing.Size(100, 20)
        Me.TxtTelefono1.TabIndex = 29
        '
        'TxtEmail
        '
        Me.TxtEmail.BackColor = System.Drawing.Color.White
        Me.TxtEmail.Location = New System.Drawing.Point(102, 79)
        Me.TxtEmail.MaxLength = 50
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.ReadOnly = True
        Me.TxtEmail.Size = New System.Drawing.Size(361, 20)
        Me.TxtEmail.TabIndex = 33
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(286, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Teléfono 2"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Email"
        '
        'TxtTelefono2
        '
        Me.TxtTelefono2.BackColor = System.Drawing.Color.White
        Me.TxtTelefono2.Location = New System.Drawing.Point(363, 26)
        Me.TxtTelefono2.MaxLength = 20
        Me.TxtTelefono2.Name = "TxtTelefono2"
        Me.TxtTelefono2.ReadOnly = True
        Me.TxtTelefono2.Size = New System.Drawing.Size(100, 20)
        Me.TxtTelefono2.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(104, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Código"
        '
        'TxtNumero
        '
        Me.TxtNumero.Location = New System.Drawing.Point(193, 12)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(100, 20)
        Me.TxtNumero.TabIndex = 26
        Me.TxtNumero.TabStop = False
        '
        'TxtNombre
        '
        Me.TxtNombre.BackColor = System.Drawing.Color.White
        Me.TxtNombre.Location = New System.Drawing.Point(299, 12)
        Me.TxtNombre.MaxLength = 50
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.ReadOnly = True
        Me.TxtNombre.Size = New System.Drawing.Size(255, 20)
        Me.TxtNombre.TabIndex = 27
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnImprime)
        Me.Panel1.Controls.Add(Me.BtnCrearCliente)
        Me.Panel1.Controls.Add(Me.BtnPreFactura)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnLimpiar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(85, 685)
        Me.Panel1.TabIndex = 51
        '
        'BtnImprime
        '
        Me.BtnImprime.BackColor = System.Drawing.Color.White
        Me.BtnImprime.Enabled = False
        Me.BtnImprime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImprime.ForeColor = System.Drawing.Color.Black
        Me.BtnImprime.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F11
        Me.BtnImprime.Location = New System.Drawing.Point(13, 93)
        Me.BtnImprime.Name = "BtnImprime"
        Me.BtnImprime.Size = New System.Drawing.Size(58, 72)
        Me.BtnImprime.TabIndex = 15
        Me.BtnImprime.TabStop = False
        Me.BtnImprime.Text = "Imprime"
        Me.BtnImprime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnImprime.UseVisualStyleBackColor = False
        '
        'BtnCrearCliente
        '
        Me.BtnCrearCliente.BackColor = System.Drawing.Color.White
        Me.BtnCrearCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCrearCliente.ForeColor = System.Drawing.Color.Black
        Me.BtnCrearCliente.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F7
        Me.BtnCrearCliente.Location = New System.Drawing.Point(13, 249)
        Me.BtnCrearCliente.Name = "BtnCrearCliente"
        Me.BtnCrearCliente.Size = New System.Drawing.Size(58, 72)
        Me.BtnCrearCliente.TabIndex = 14
        Me.BtnCrearCliente.TabStop = False
        Me.BtnCrearCliente.Text = "Cliente"
        Me.BtnCrearCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnCrearCliente.UseVisualStyleBackColor = False
        '
        'BtnPreFactura
        '
        Me.BtnPreFactura.BackColor = System.Drawing.Color.White
        Me.BtnPreFactura.Enabled = False
        Me.BtnPreFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreFactura.ForeColor = System.Drawing.Color.Black
        Me.BtnPreFactura.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnPreFactura.Location = New System.Drawing.Point(13, 171)
        Me.BtnPreFactura.Name = "BtnPreFactura"
        Me.BtnPreFactura.Size = New System.Drawing.Size(58, 72)
        Me.BtnPreFactura.TabIndex = 13
        Me.BtnPreFactura.TabStop = False
        Me.BtnPreFactura.Text = "PreFac"
        Me.BtnPreFactura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnPreFactura.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(12, 327)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(58, 72)
        Me.BtnSalir.TabIndex = 12
        Me.BtnSalir.TabStop = False
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.BackColor = System.Drawing.Color.White
        Me.BtnLimpiar.Enabled = False
        Me.BtnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLimpiar.ForeColor = System.Drawing.Color.Black
        Me.BtnLimpiar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F12
        Me.BtnLimpiar.Location = New System.Drawing.Point(13, 15)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(58, 72)
        Me.BtnLimpiar.TabIndex = 11
        Me.BtnLimpiar.TabStop = False
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnLimpiar.UseVisualStyleBackColor = False
        '
        'LvwAnotaciones
        '
        Me.LvwAnotaciones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader23})
        Me.LvwAnotaciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LvwAnotaciones.FullRowSelect = True
        Me.LvwAnotaciones.Location = New System.Drawing.Point(3, 48)
        Me.LvwAnotaciones.Name = "LvwAnotaciones"
        Me.LvwAnotaciones.Size = New System.Drawing.Size(481, 200)
        Me.LvwAnotaciones.TabIndex = 0
        Me.LvwAnotaciones.UseCompatibleStateImageBehavior = False
        Me.LvwAnotaciones.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Id"
        Me.ColumnHeader20.Width = 0
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Anotación"
        Me.ColumnHeader21.Width = 302
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "Fecha"
        Me.ColumnHeader22.Width = 76
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "Hecho Por"
        Me.ColumnHeader23.Width = 75
        '
        'BtnAnotacionAgregar
        '
        Me.BtnAnotacionAgregar.Enabled = False
        Me.BtnAnotacionAgregar.Location = New System.Drawing.Point(6, 19)
        Me.BtnAnotacionAgregar.Name = "BtnAnotacionAgregar"
        Me.BtnAnotacionAgregar.Size = New System.Drawing.Size(20, 23)
        Me.BtnAnotacionAgregar.TabIndex = 1
        Me.BtnAnotacionAgregar.Text = "+"
        Me.BtnAnotacionAgregar.UseVisualStyleBackColor = True
        '
        'BtnAnotacionEliminar
        '
        Me.BtnAnotacionEliminar.Enabled = False
        Me.BtnAnotacionEliminar.Location = New System.Drawing.Point(32, 19)
        Me.BtnAnotacionEliminar.Name = "BtnAnotacionEliminar"
        Me.BtnAnotacionEliminar.Size = New System.Drawing.Size(20, 23)
        Me.BtnAnotacionEliminar.TabIndex = 2
        Me.BtnAnotacionEliminar.Text = "-"
        Me.BtnAnotacionEliminar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BtnAnotacionEliminar)
        Me.GroupBox3.Controls.Add(Me.BtnAnotacionAgregar)
        Me.GroupBox3.Controls.Add(Me.LvwAnotaciones)
        Me.GroupBox3.Location = New System.Drawing.Point(584, 38)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(487, 251)
        Me.GroupBox3.TabIndex = 53
        Me.GroupBox3.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BtnArticuloEliminar)
        Me.GroupBox2.Controls.Add(Me.BtnArticuloAgregar)
        Me.GroupBox2.Controls.Add(Me.LvwEncargos)
        Me.GroupBox2.Location = New System.Drawing.Point(91, 295)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(980, 378)
        Me.GroupBox2.TabIndex = 54
        Me.GroupBox2.TabStop = False
        '
        'BtnArticuloEliminar
        '
        Me.BtnArticuloEliminar.Enabled = False
        Me.BtnArticuloEliminar.Location = New System.Drawing.Point(32, 19)
        Me.BtnArticuloEliminar.Name = "BtnArticuloEliminar"
        Me.BtnArticuloEliminar.Size = New System.Drawing.Size(20, 23)
        Me.BtnArticuloEliminar.TabIndex = 4
        Me.BtnArticuloEliminar.Text = "-"
        Me.BtnArticuloEliminar.UseVisualStyleBackColor = True
        '
        'BtnArticuloAgregar
        '
        Me.BtnArticuloAgregar.Enabled = False
        Me.BtnArticuloAgregar.Location = New System.Drawing.Point(6, 19)
        Me.BtnArticuloAgregar.Name = "BtnArticuloAgregar"
        Me.BtnArticuloAgregar.Size = New System.Drawing.Size(20, 23)
        Me.BtnArticuloAgregar.TabIndex = 3
        Me.BtnArticuloAgregar.Text = "+"
        Me.BtnArticuloAgregar.UseVisualStyleBackColor = True
        '
        'LvwEncargos
        '
        Me.LvwEncargos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader5, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.LvwEncargos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LvwEncargos.FullRowSelect = True
        Me.LvwEncargos.Location = New System.Drawing.Point(3, 51)
        Me.LvwEncargos.Name = "LvwEncargos"
        Me.LvwEncargos.Size = New System.Drawing.Size(974, 324)
        Me.LvwEncargos.TabIndex = 1
        Me.LvwEncargos.UseCompatibleStateImageBehavior = False
        Me.LvwEncargos.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Id"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Artículo"
        Me.ColumnHeader2.Width = 134
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Descripcion"
        Me.ColumnHeader5.Width = 469
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Fecha"
        Me.ColumnHeader3.Width = 102
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Hecho Por"
        Me.ColumnHeader4.Width = 75
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Notificado"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Fecha Notificación"
        Me.ColumnHeader7.Width = 102
        '
        'FrmClienteEncargo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtnSalir
        Me.ClientSize = New System.Drawing.Size(1077, 685)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TxtNumero)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtNombre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmClienteEncargo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Encargo de Mercadería"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtApartado As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtTelefono1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtTelefono2 As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents BtnPreFactura As System.Windows.Forms.Button
    Friend WithEvents BtnCrearCliente As System.Windows.Forms.Button
    Friend WithEvents LvwAnotaciones As System.Windows.Forms.ListView
    Friend WithEvents BtnAnotacionEliminar As System.Windows.Forms.Button
    Friend WithEvents BtnAnotacionAgregar As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnImprime As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LvwEncargos As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnArticuloEliminar As System.Windows.Forms.Button
    Friend WithEvents BtnArticuloAgregar As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
End Class
