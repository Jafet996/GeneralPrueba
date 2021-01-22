<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantBoletaServicioDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantBoletaServicioDetalle))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnCliente = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtBoleta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtTelefono2 = New System.Windows.Forms.TextBox()
        Me.TxtTelefono1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtUsuarioCrea = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtSucursal = New System.Windows.Forms.TextBox()
        Me.GpCliente = New System.Windows.Forms.GroupBox()
        Me.lsvContactosBoleta = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LsvContactos = New System.Windows.Forms.ListView()
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtDireccion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GpAsignar = New System.Windows.Forms.GroupBox()
        Me.dpFechaAsigna = New System.Windows.Forms.DateTimePicker()
        Me.TxtObservacion = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtUsuarioAsigna = New System.Windows.Forms.TextBox()
        Me.CmbTecnico = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GpCierre = New System.Windows.Forms.GroupBox()
        Me.TxtFactura = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.dpFechaCierre = New System.Windows.Forms.DateTimePicker()
        Me.TxtSolucion = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TxtUsuarioCierre = New System.Windows.Forms.TextBox()
        Me.GpMotivo = New System.Windows.Forms.GroupBox()
        Me.CmbPrioridad = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtAsunto = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtMotivo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CmbEstado = New System.Windows.Forms.ComboBox()
        Me.DpFechaCrea = New System.Windows.Forms.DateTimePicker()
        Me.GpPostServicio = New System.Windows.Forms.GroupBox()
        Me.lsvPost = New System.Windows.Forms.ListView()
        Me.Comentario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Usuario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BtnAgregar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GpCliente.SuspendLayout()
        Me.GpAsignar.SuspendLayout()
        Me.GpCierre.SuspendLayout()
        Me.GpMotivo.SuspendLayout()
        Me.GpPostServicio.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnCliente)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnGuardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(67, 637)
        Me.Panel1.TabIndex = 2
        '
        'BtnCliente
        '
        Me.BtnCliente.BackColor = System.Drawing.Color.White
        Me.BtnCliente.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F8
        Me.BtnCliente.Location = New System.Drawing.Point(5, 83)
        Me.BtnCliente.Name = "BtnCliente"
        Me.BtnCliente.Size = New System.Drawing.Size(57, 73)
        Me.BtnCliente.TabIndex = 23
        Me.BtnCliente.TabStop = False
        Me.BtnCliente.Text = "Cliente"
        Me.BtnCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnCliente.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(5, 162)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(57, 73)
        Me.BtnSalir.TabIndex = 22
        Me.BtnSalir.TabStop = False
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.BackColor = System.Drawing.Color.White
        Me.BtnGuardar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F7
        Me.BtnGuardar.Location = New System.Drawing.Point(5, 4)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(57, 73)
        Me.BtnGuardar.TabIndex = 21
        Me.BtnGuardar.TabStop = False
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnGuardar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(86, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Boleta"
        '
        'TxtBoleta
        '
        Me.TxtBoleta.BackColor = System.Drawing.Color.White
        Me.TxtBoleta.ForeColor = System.Drawing.Color.Black
        Me.TxtBoleta.Location = New System.Drawing.Point(171, 38)
        Me.TxtBoleta.Name = "TxtBoleta"
        Me.TxtBoleta.ReadOnly = True
        Me.TxtBoleta.Size = New System.Drawing.Size(100, 20)
        Me.TxtBoleta.TabIndex = 48
        Me.TxtBoleta.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Cliente"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Location = New System.Drawing.Point(98, 22)
        Me.TxtCodigo.MaxLength = 50
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(100, 20)
        Me.TxtCodigo.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Teléfono 1"
        '
        'TxtTelefono2
        '
        Me.TxtTelefono2.Location = New System.Drawing.Point(303, 48)
        Me.TxtTelefono2.MaxLength = 8
        Me.TxtTelefono2.Name = "TxtTelefono2"
        Me.TxtTelefono2.Size = New System.Drawing.Size(100, 20)
        Me.TxtTelefono2.TabIndex = 4
        '
        'TxtTelefono1
        '
        Me.TxtTelefono1.Location = New System.Drawing.Point(98, 48)
        Me.TxtTelefono1.MaxLength = 8
        Me.TxtTelefono1.Name = "TxtTelefono1"
        Me.TxtTelefono1.Size = New System.Drawing.Size(100, 20)
        Me.TxtTelefono1.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(230, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Teléfono 2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(582, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "Usuario Crea"
        '
        'TxtUsuarioCrea
        '
        Me.TxtUsuarioCrea.BackColor = System.Drawing.Color.White
        Me.TxtUsuarioCrea.Location = New System.Drawing.Point(777, 39)
        Me.TxtUsuarioCrea.Name = "TxtUsuarioCrea"
        Me.TxtUsuarioCrea.ReadOnly = True
        Me.TxtUsuarioCrea.Size = New System.Drawing.Size(254, 20)
        Me.TxtUsuarioCrea.TabIndex = 63
        Me.TxtUsuarioCrea.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(582, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 66
        Me.Label6.Text = "Sucursal"
        '
        'TxtSucursal
        '
        Me.TxtSucursal.BackColor = System.Drawing.Color.White
        Me.TxtSucursal.Location = New System.Drawing.Point(777, 68)
        Me.TxtSucursal.Name = "TxtSucursal"
        Me.TxtSucursal.ReadOnly = True
        Me.TxtSucursal.Size = New System.Drawing.Size(254, 20)
        Me.TxtSucursal.TabIndex = 65
        Me.TxtSucursal.TabStop = False
        '
        'GpCliente
        '
        Me.GpCliente.Controls.Add(Me.lsvContactosBoleta)
        Me.GpCliente.Controls.Add(Me.LsvContactos)
        Me.GpCliente.Controls.Add(Me.Label10)
        Me.GpCliente.Controls.Add(Me.TxtDireccion)
        Me.GpCliente.Controls.Add(Me.Label8)
        Me.GpCliente.Controls.Add(Me.TxtEmail)
        Me.GpCliente.Controls.Add(Me.Label7)
        Me.GpCliente.Controls.Add(Me.TxtNombre)
        Me.GpCliente.Controls.Add(Me.Label2)
        Me.GpCliente.Controls.Add(Me.TxtCodigo)
        Me.GpCliente.Controls.Add(Me.Label4)
        Me.GpCliente.Controls.Add(Me.TxtTelefono2)
        Me.GpCliente.Controls.Add(Me.TxtTelefono1)
        Me.GpCliente.Controls.Add(Me.Label5)
        Me.GpCliente.Location = New System.Drawing.Point(73, 107)
        Me.GpCliente.Name = "GpCliente"
        Me.GpCliente.Size = New System.Drawing.Size(478, 210)
        Me.GpCliente.TabIndex = 67
        Me.GpCliente.TabStop = False
        Me.GpCliente.Text = "Datos Cliente"
        '
        'lsvContactosBoleta
        '
        Me.lsvContactosBoleta.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lsvContactosBoleta.FullRowSelect = True
        Me.lsvContactosBoleta.Location = New System.Drawing.Point(285, 126)
        Me.lsvContactosBoleta.Name = "lsvContactosBoleta"
        Me.lsvContactosBoleta.Size = New System.Drawing.Size(181, 70)
        Me.lsvContactosBoleta.TabIndex = 70
        Me.lsvContactosBoleta.UseCompatibleStateImageBehavior = False
        Me.lsvContactosBoleta.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nombre"
        Me.ColumnHeader1.Width = 160
        '
        'LsvContactos
        '
        Me.LsvContactos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader21})
        Me.LsvContactos.FullRowSelect = True
        Me.LsvContactos.Location = New System.Drawing.Point(98, 126)
        Me.LsvContactos.Name = "LsvContactos"
        Me.LsvContactos.Size = New System.Drawing.Size(181, 70)
        Me.LsvContactos.TabIndex = 69
        Me.LsvContactos.UseCompatibleStateImageBehavior = False
        Me.LsvContactos.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Nombre"
        Me.ColumnHeader21.Width = 160
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 127)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "Contacto"
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(98, 100)
        Me.TxtDireccion.MaxLength = 50
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Size = New System.Drawing.Size(367, 20)
        Me.TxtDireccion.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "Dirección"
        '
        'TxtEmail
        '
        Me.TxtEmail.Location = New System.Drawing.Point(98, 74)
        Me.TxtEmail.MaxLength = 50
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(367, 20)
        Me.TxtEmail.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Email"
        '
        'TxtNombre
        '
        Me.TxtNombre.BackColor = System.Drawing.Color.White
        Me.TxtNombre.Location = New System.Drawing.Point(209, 22)
        Me.TxtNombre.MaxLength = 50
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.ReadOnly = True
        Me.TxtNombre.Size = New System.Drawing.Size(256, 20)
        Me.TxtNombre.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(363, 71)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 13)
        Me.Label11.TabIndex = 69
        Me.Label11.Text = "Fecha Creación"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(363, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 13)
        Me.Label13.TabIndex = 73
        Me.Label13.Text = "Estado"
        '
        'GpAsignar
        '
        Me.GpAsignar.Controls.Add(Me.dpFechaAsigna)
        Me.GpAsignar.Controls.Add(Me.TxtObservacion)
        Me.GpAsignar.Controls.Add(Me.Label22)
        Me.GpAsignar.Controls.Add(Me.Label18)
        Me.GpAsignar.Controls.Add(Me.Label17)
        Me.GpAsignar.Controls.Add(Me.txtUsuarioAsigna)
        Me.GpAsignar.Controls.Add(Me.CmbTecnico)
        Me.GpAsignar.Controls.Add(Me.Label16)
        Me.GpAsignar.Location = New System.Drawing.Point(73, 323)
        Me.GpAsignar.Name = "GpAsignar"
        Me.GpAsignar.Size = New System.Drawing.Size(478, 183)
        Me.GpAsignar.TabIndex = 77
        Me.GpAsignar.TabStop = False
        Me.GpAsignar.Text = "Asignar"
        '
        'dpFechaAsigna
        '
        Me.dpFechaAsigna.CustomFormat = "dd/MM/yyyy"
        Me.dpFechaAsigna.Enabled = False
        Me.dpFechaAsigna.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFechaAsigna.Location = New System.Drawing.Point(108, 77)
        Me.dpFechaAsigna.Name = "dpFechaAsigna"
        Me.dpFechaAsigna.Size = New System.Drawing.Size(100, 20)
        Me.dpFechaAsigna.TabIndex = 15
        '
        'TxtObservacion
        '
        Me.TxtObservacion.Location = New System.Drawing.Point(108, 103)
        Me.TxtObservacion.MaxLength = 1000
        Me.TxtObservacion.Multiline = True
        Me.TxtObservacion.Name = "TxtObservacion"
        Me.TxtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtObservacion.Size = New System.Drawing.Size(351, 66)
        Me.TxtObservacion.TabIndex = 16
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(21, 106)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 13)
        Me.Label22.TabIndex = 89
        Me.Label22.Text = "Observación"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(21, 80)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 13)
        Me.Label18.TabIndex = 84
        Me.Label18.Text = "Fecha Asignado"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(18, 54)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 13)
        Me.Label17.TabIndex = 83
        Me.Label17.Text = "Asignado por"
        '
        'txtUsuarioAsigna
        '
        Me.txtUsuarioAsigna.BackColor = System.Drawing.Color.White
        Me.txtUsuarioAsigna.Location = New System.Drawing.Point(108, 51)
        Me.txtUsuarioAsigna.Name = "txtUsuarioAsigna"
        Me.txtUsuarioAsigna.ReadOnly = True
        Me.txtUsuarioAsigna.Size = New System.Drawing.Size(202, 20)
        Me.txtUsuarioAsigna.TabIndex = 14
        Me.txtUsuarioAsigna.TabStop = False
        '
        'CmbTecnico
        '
        Me.CmbTecnico.BackColor = System.Drawing.Color.White
        Me.CmbTecnico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTecnico.FormattingEnabled = True
        Me.CmbTecnico.Location = New System.Drawing.Point(108, 22)
        Me.CmbTecnico.Name = "CmbTecnico"
        Me.CmbTecnico.Size = New System.Drawing.Size(202, 21)
        Me.CmbTecnico.TabIndex = 13
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(18, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 13)
        Me.Label16.TabIndex = 54
        Me.Label16.Text = "Técnico"
        '
        'GpCierre
        '
        Me.GpCierre.Controls.Add(Me.TxtFactura)
        Me.GpCierre.Controls.Add(Me.Label23)
        Me.GpCierre.Controls.Add(Me.dpFechaCierre)
        Me.GpCierre.Controls.Add(Me.TxtSolucion)
        Me.GpCierre.Controls.Add(Me.Label21)
        Me.GpCierre.Controls.Add(Me.Label19)
        Me.GpCierre.Controls.Add(Me.Label20)
        Me.GpCierre.Controls.Add(Me.TxtUsuarioCierre)
        Me.GpCierre.Location = New System.Drawing.Point(571, 323)
        Me.GpCierre.Name = "GpCierre"
        Me.GpCierre.Size = New System.Drawing.Size(478, 183)
        Me.GpCierre.TabIndex = 78
        Me.GpCierre.TabStop = False
        Me.GpCierre.Text = "Cierre"
        '
        'TxtFactura
        '
        Me.TxtFactura.Location = New System.Drawing.Point(303, 51)
        Me.TxtFactura.MaxLength = 200
        Me.TxtFactura.Name = "TxtFactura"
        Me.TxtFactura.Size = New System.Drawing.Size(156, 20)
        Me.TxtFactura.TabIndex = 19
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(230, 54)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(53, 13)
        Me.Label23.TabIndex = 93
        Me.Label23.Text = "# Factura"
        '
        'dpFechaCierre
        '
        Me.dpFechaCierre.CustomFormat = "dd/MM/yyyy"
        Me.dpFechaCierre.Enabled = False
        Me.dpFechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFechaCierre.Location = New System.Drawing.Point(108, 51)
        Me.dpFechaCierre.Name = "dpFechaCierre"
        Me.dpFechaCierre.Size = New System.Drawing.Size(100, 20)
        Me.dpFechaCierre.TabIndex = 18
        '
        'TxtSolucion
        '
        Me.TxtSolucion.Location = New System.Drawing.Point(108, 77)
        Me.TxtSolucion.MaxLength = 1000
        Me.TxtSolucion.Multiline = True
        Me.TxtSolucion.Name = "TxtSolucion"
        Me.TxtSolucion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtSolucion.Size = New System.Drawing.Size(351, 79)
        Me.TxtSolucion.TabIndex = 20
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(18, 74)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 13)
        Me.Label21.TabIndex = 86
        Me.Label21.Text = "Solución"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(18, 54)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 13)
        Me.Label19.TabIndex = 84
        Me.Label19.Text = "Fecha Cierre"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(18, 27)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(62, 13)
        Me.Label20.TabIndex = 83
        Me.Label20.Text = "Cerrado por"
        '
        'TxtUsuarioCierre
        '
        Me.TxtUsuarioCierre.BackColor = System.Drawing.Color.White
        Me.TxtUsuarioCierre.Location = New System.Drawing.Point(108, 24)
        Me.TxtUsuarioCierre.Name = "TxtUsuarioCierre"
        Me.TxtUsuarioCierre.ReadOnly = True
        Me.TxtUsuarioCierre.Size = New System.Drawing.Size(351, 20)
        Me.TxtUsuarioCierre.TabIndex = 17
        Me.TxtUsuarioCierre.TabStop = False
        '
        'GpMotivo
        '
        Me.GpMotivo.Controls.Add(Me.CmbPrioridad)
        Me.GpMotivo.Controls.Add(Me.Label15)
        Me.GpMotivo.Controls.Add(Me.TxtAsunto)
        Me.GpMotivo.Controls.Add(Me.Label14)
        Me.GpMotivo.Controls.Add(Me.dpFechaFinal)
        Me.GpMotivo.Controls.Add(Me.Label12)
        Me.GpMotivo.Controls.Add(Me.TxtMotivo)
        Me.GpMotivo.Controls.Add(Me.Label9)
        Me.GpMotivo.Location = New System.Drawing.Point(571, 107)
        Me.GpMotivo.Name = "GpMotivo"
        Me.GpMotivo.Size = New System.Drawing.Size(478, 210)
        Me.GpMotivo.TabIndex = 79
        Me.GpMotivo.TabStop = False
        Me.GpMotivo.Text = "Detalle Visita"
        '
        'CmbPrioridad
        '
        Me.CmbPrioridad.BackColor = System.Drawing.Color.White
        Me.CmbPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbPrioridad.FormattingEnabled = True
        Me.CmbPrioridad.Location = New System.Drawing.Point(303, 19)
        Me.CmbPrioridad.Name = "CmbPrioridad"
        Me.CmbPrioridad.Size = New System.Drawing.Size(100, 21)
        Me.CmbPrioridad.TabIndex = 10
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(230, 25)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 13)
        Me.Label15.TabIndex = 79
        Me.Label15.Text = "Prioridad"
        '
        'TxtAsunto
        '
        Me.TxtAsunto.Location = New System.Drawing.Point(93, 45)
        Me.TxtAsunto.MaxLength = 200
        Me.TxtAsunto.Name = "TxtAsunto"
        Me.TxtAsunto.Size = New System.Drawing.Size(367, 20)
        Me.TxtAsunto.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(11, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 13)
        Me.Label14.TabIndex = 77
        Me.Label14.Text = "Asunto"
        '
        'dpFechaFinal
        '
        Me.dpFechaFinal.CustomFormat = "dd/MM/yyyy"
        Me.dpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFechaFinal.Location = New System.Drawing.Point(93, 19)
        Me.dpFechaFinal.Name = "dpFechaFinal"
        Me.dpFechaFinal.Size = New System.Drawing.Size(100, 20)
        Me.dpFechaFinal.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 75
        Me.Label12.Text = "Fecha Visita"
        '
        'TxtMotivo
        '
        Me.TxtMotivo.Location = New System.Drawing.Point(93, 71)
        Me.TxtMotivo.MaxLength = 1000
        Me.TxtMotivo.Multiline = True
        Me.TxtMotivo.Name = "TxtMotivo"
        Me.TxtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtMotivo.Size = New System.Drawing.Size(367, 125)
        Me.TxtMotivo.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 73
        Me.Label9.Text = "Motivo"
        '
        'CmbEstado
        '
        Me.CmbEstado.BackColor = System.Drawing.Color.White
        Me.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEstado.Enabled = False
        Me.CmbEstado.FormattingEnabled = True
        Me.CmbEstado.Location = New System.Drawing.Point(451, 38)
        Me.CmbEstado.Name = "CmbEstado"
        Me.CmbEstado.Size = New System.Drawing.Size(100, 21)
        Me.CmbEstado.TabIndex = 82
        '
        'DpFechaCrea
        '
        Me.DpFechaCrea.CustomFormat = "dd/MM/yyyy"
        Me.DpFechaCrea.Enabled = False
        Me.DpFechaCrea.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DpFechaCrea.Location = New System.Drawing.Point(451, 68)
        Me.DpFechaCrea.Name = "DpFechaCrea"
        Me.DpFechaCrea.Size = New System.Drawing.Size(100, 20)
        Me.DpFechaCrea.TabIndex = 83
        '
        'GpPostServicio
        '
        Me.GpPostServicio.Controls.Add(Me.lsvPost)
        Me.GpPostServicio.Controls.Add(Me.BtnAgregar)
        Me.GpPostServicio.Location = New System.Drawing.Point(73, 512)
        Me.GpPostServicio.Name = "GpPostServicio"
        Me.GpPostServicio.Size = New System.Drawing.Size(976, 125)
        Me.GpPostServicio.TabIndex = 84
        Me.GpPostServicio.TabStop = False
        Me.GpPostServicio.Text = "Post Servicio"
        '
        'lsvPost
        '
        Me.lsvPost.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Comentario, Me.Fecha, Me.Usuario})
        Me.lsvPost.FullRowSelect = True
        Me.lsvPost.Location = New System.Drawing.Point(108, 17)
        Me.lsvPost.Name = "lsvPost"
        Me.lsvPost.Size = New System.Drawing.Size(849, 102)
        Me.lsvPost.TabIndex = 70
        Me.lsvPost.UseCompatibleStateImageBehavior = False
        Me.lsvPost.View = System.Windows.Forms.View.Details
        '
        'Comentario
        '
        Me.Comentario.Text = "Comentario"
        Me.Comentario.Width = 600
        '
        'Fecha
        '
        Me.Fecha.Text = "Fecha"
        Me.Fecha.Width = 100
        '
        'Usuario
        '
        Me.Usuario.Text = "Usuario"
        Me.Usuario.Width = 100
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Image = Global.PuntoVenta.My.Resources.Resources.edit
        Me.BtnAgregar.Location = New System.Drawing.Point(29, 34)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(40, 38)
        Me.BtnAgregar.TabIndex = 1
        Me.BtnAgregar.UseVisualStyleBackColor = True
        '
        'FrmMantBoletaServicioDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1065, 637)
        Me.Controls.Add(Me.GpPostServicio)
        Me.Controls.Add(Me.DpFechaCrea)
        Me.Controls.Add(Me.CmbEstado)
        Me.Controls.Add(Me.GpMotivo)
        Me.Controls.Add(Me.GpCliente)
        Me.Controls.Add(Me.GpCierre)
        Me.Controls.Add(Me.GpAsignar)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtSucursal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtUsuarioCrea)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtBoleta)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantBoletaServicioDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Boleta de Servicio Detalle"
        Me.Panel1.ResumeLayout(False)
        Me.GpCliente.ResumeLayout(False)
        Me.GpCliente.PerformLayout()
        Me.GpAsignar.ResumeLayout(False)
        Me.GpAsignar.PerformLayout()
        Me.GpCierre.ResumeLayout(False)
        Me.GpCierre.PerformLayout()
        Me.GpMotivo.ResumeLayout(False)
        Me.GpMotivo.PerformLayout()
        Me.GpPostServicio.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnGuardar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtBoleta As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtCodigo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtTelefono2 As TextBox
    Friend WithEvents TxtTelefono1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtUsuarioCrea As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtSucursal As TextBox
    Friend WithEvents TxtNombre As TextBox
    Friend WithEvents TxtDireccion As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtEmail As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents GpAsignar As GroupBox
    Friend WithEvents CmbTecnico As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtUsuarioAsigna As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents GpCierre As GroupBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents TxtUsuarioCierre As TextBox
    Friend WithEvents TxtSolucion As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents GpMotivo As GroupBox
    Friend WithEvents CmbPrioridad As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TxtAsunto As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents dpFechaFinal As DateTimePicker
    Friend WithEvents Label12 As Label
    Friend WithEvents TxtMotivo As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtObservacion As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents CmbEstado As ComboBox
    Friend WithEvents GpCliente As GroupBox
    Friend WithEvents DpFechaCrea As DateTimePicker
    Friend WithEvents dpFechaAsigna As DateTimePicker
    Friend WithEvents dpFechaCierre As DateTimePicker
    Friend WithEvents GpPostServicio As GroupBox
    Friend WithEvents TxtFactura As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents lsvContactosBoleta As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents LsvContactos As ListView
    Friend WithEvents ColumnHeader21 As ColumnHeader
    Friend WithEvents BtnAgregar As Button
    Friend WithEvents lsvPost As ListView
    Friend WithEvents Comentario As ColumnHeader
    Friend WithEvents Fecha As ColumnHeader
    Friend WithEvents Usuario As ColumnHeader
    Friend WithEvents BtnCliente As Button
End Class
