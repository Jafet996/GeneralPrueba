<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBusquedaPreFactura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBusquedaPreFactura))
        Me.LvwDocumentos = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CMSDocumentos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuEliminarPrefactura = New System.Windows.Forms.ToolStripMenuItem()
        Me.PnlFiltros = New System.Windows.Forms.Panel()
        Me.RdbNumero = New System.Windows.Forms.RadioButton()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.RdbNombre = New System.Windows.Forms.RadioButton()
        Me.DtpFechaEntrega = New System.Windows.Forms.DateTimePicker()
        Me.RdbFechaEntrega = New System.Windows.Forms.RadioButton()
        Me.RdbMostarTodo = New System.Windows.Forms.RadioButton()
        Me.LvwDetalle = New System.Windows.Forms.ListView()
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblVendedor = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblClienteTipo = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LblTelefono2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblTelefono1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblObservacion = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblDireccion = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ColumnHeader25 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader26 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CMSDocumentos.SuspendLayout()
        Me.PnlFiltros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LvwDocumentos
        '
        Me.LvwDocumentos.BackColor = System.Drawing.Color.White
        Me.LvwDocumentos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader8, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader23, Me.ColumnHeader24, Me.ColumnHeader25, Me.ColumnHeader26})
        Me.LvwDocumentos.ContextMenuStrip = Me.CMSDocumentos
        Me.LvwDocumentos.FullRowSelect = True
        Me.LvwDocumentos.HideSelection = False
        Me.LvwDocumentos.Location = New System.Drawing.Point(3, 3)
        Me.LvwDocumentos.Name = "LvwDocumentos"
        Me.LvwDocumentos.Size = New System.Drawing.Size(1234, 342)
        Me.LvwDocumentos.TabIndex = 0
        Me.LvwDocumentos.UseCompatibleStateImageBehavior = False
        Me.LvwDocumentos.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Documento"
        Me.ColumnHeader3.Width = 100
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Cliente"
        Me.ColumnHeader4.Width = 204
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Fecha Hora"
        Me.ColumnHeader5.Width = 111
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Monto"
        Me.ColumnHeader6.Width = 111
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Vencimiento"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Tipo"
        Me.ColumnHeader1.Width = 153
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Tipo Entrega"
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Fecha Entrega"
        '
        'CMSDocumentos
        '
        Me.CMSDocumentos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuEliminarPrefactura})
        Me.CMSDocumentos.Name = "CMSDocumentos"
        Me.CMSDocumentos.Size = New System.Drawing.Size(175, 26)
        '
        'MnuEliminarPrefactura
        '
        Me.MnuEliminarPrefactura.Name = "MnuEliminarPrefactura"
        Me.MnuEliminarPrefactura.Size = New System.Drawing.Size(174, 22)
        Me.MnuEliminarPrefactura.Text = "Eliminar Prefactura"
        '
        'PnlFiltros
        '
        Me.PnlFiltros.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.PnlFiltros.Controls.Add(Me.RdbNumero)
        Me.PnlFiltros.Controls.Add(Me.TxtNombre)
        Me.PnlFiltros.Controls.Add(Me.RdbNombre)
        Me.PnlFiltros.Controls.Add(Me.DtpFechaEntrega)
        Me.PnlFiltros.Controls.Add(Me.RdbFechaEntrega)
        Me.PnlFiltros.Controls.Add(Me.RdbMostarTodo)
        Me.PnlFiltros.Location = New System.Drawing.Point(3, 612)
        Me.PnlFiltros.Name = "PnlFiltros"
        Me.PnlFiltros.Size = New System.Drawing.Size(641, 52)
        Me.PnlFiltros.TabIndex = 51
        '
        'RdbNumero
        '
        Me.RdbNumero.AutoSize = True
        Me.RdbNumero.ForeColor = System.Drawing.Color.White
        Me.RdbNumero.Location = New System.Drawing.Point(305, 26)
        Me.RdbNumero.Name = "RdbNumero"
        Me.RdbNumero.Size = New System.Drawing.Size(62, 17)
        Me.RdbNumero.TabIndex = 8
        Me.RdbNumero.TabStop = True
        Me.RdbNumero.Text = "Número"
        Me.RdbNumero.UseVisualStyleBackColor = True
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(373, 17)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(256, 20)
        Me.TxtNombre.TabIndex = 7
        '
        'RdbNombre
        '
        Me.RdbNombre.AutoSize = True
        Me.RdbNombre.ForeColor = System.Drawing.Color.White
        Me.RdbNombre.Location = New System.Drawing.Point(305, 3)
        Me.RdbNombre.Name = "RdbNombre"
        Me.RdbNombre.Size = New System.Drawing.Size(62, 17)
        Me.RdbNombre.TabIndex = 6
        Me.RdbNombre.TabStop = True
        Me.RdbNombre.Text = "Nombre"
        Me.RdbNombre.UseVisualStyleBackColor = True
        '
        'DtpFechaEntrega
        '
        Me.DtpFechaEntrega.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaEntrega.Location = New System.Drawing.Point(204, 18)
        Me.DtpFechaEntrega.Name = "DtpFechaEntrega"
        Me.DtpFechaEntrega.Size = New System.Drawing.Size(95, 20)
        Me.DtpFechaEntrega.TabIndex = 5
        '
        'RdbFechaEntrega
        '
        Me.RdbFechaEntrega.AutoSize = True
        Me.RdbFechaEntrega.ForeColor = System.Drawing.Color.White
        Me.RdbFechaEntrega.Location = New System.Drawing.Point(103, 18)
        Me.RdbFechaEntrega.Name = "RdbFechaEntrega"
        Me.RdbFechaEntrega.Size = New System.Drawing.Size(95, 17)
        Me.RdbFechaEntrega.TabIndex = 1
        Me.RdbFechaEntrega.TabStop = True
        Me.RdbFechaEntrega.Text = "Fecha Entrega"
        Me.RdbFechaEntrega.UseVisualStyleBackColor = True
        '
        'RdbMostarTodo
        '
        Me.RdbMostarTodo.AutoSize = True
        Me.RdbMostarTodo.ForeColor = System.Drawing.Color.White
        Me.RdbMostarTodo.Location = New System.Drawing.Point(9, 18)
        Me.RdbMostarTodo.Name = "RdbMostarTodo"
        Me.RdbMostarTodo.Size = New System.Drawing.Size(88, 17)
        Me.RdbMostarTodo.TabIndex = 0
        Me.RdbMostarTodo.TabStop = True
        Me.RdbMostarTodo.Text = "Mostrar Todo"
        Me.RdbMostarTodo.UseVisualStyleBackColor = True
        '
        'LvwDetalle
        '
        Me.LvwDetalle.BackColor = System.Drawing.Color.AliceBlue
        Me.LvwDetalle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14})
        Me.LvwDetalle.FullRowSelect = True
        Me.LvwDetalle.Location = New System.Drawing.Point(3, 343)
        Me.LvwDetalle.Name = "LvwDetalle"
        Me.LvwDetalle.Size = New System.Drawing.Size(641, 266)
        Me.LvwDetalle.TabIndex = 52
        Me.LvwDetalle.UseCompatibleStateImageBehavior = False
        Me.LvwDetalle.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Línea"
        Me.ColumnHeader9.Width = 44
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Artículo"
        Me.ColumnHeader10.Width = 90
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Cantidad"
        Me.ColumnHeader11.Width = 69
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Descripcion"
        Me.ColumnHeader12.Width = 269
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Total"
        Me.ColumnHeader13.Width = 112
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Comentario"
        Me.ColumnHeader14.Width = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.LblUsuario)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.LblVendedor)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.LblClienteTipo)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.LblTelefono2)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.LblTelefono1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.LblObservacion)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.LblDireccion)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(650, 343)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(587, 324)
        Me.GroupBox1.TabIndex = 53
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(238, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Label5"
        '
        'LblUsuario
        '
        Me.LblUsuario.BackColor = System.Drawing.Color.White
        Me.LblUsuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblUsuario.Location = New System.Drawing.Point(473, 205)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(96, 25)
        Me.LblUsuario.TabIndex = 72
        Me.LblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(408, 211)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "Usuario"
        '
        'LblVendedor
        '
        Me.LblVendedor.BackColor = System.Drawing.Color.White
        Me.LblVendedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblVendedor.Location = New System.Drawing.Point(89, 205)
        Me.LblVendedor.Name = "LblVendedor"
        Me.LblVendedor.Size = New System.Drawing.Size(296, 25)
        Me.LblVendedor.TabIndex = 70
        Me.LblVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(17, 211)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "Vendedor"
        '
        'LblClienteTipo
        '
        Me.LblClienteTipo.BackColor = System.Drawing.Color.White
        Me.LblClienteTipo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblClienteTipo.Location = New System.Drawing.Point(473, 31)
        Me.LblClienteTipo.Name = "LblClienteTipo"
        Me.LblClienteTipo.Size = New System.Drawing.Size(96, 25)
        Me.LblClienteTipo.TabIndex = 68
        Me.LblClienteTipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(408, 37)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(28, 13)
        Me.Label13.TabIndex = 67
        Me.Label13.Text = "Tipo"
        '
        'LblTelefono2
        '
        Me.LblTelefono2.BackColor = System.Drawing.Color.White
        Me.LblTelefono2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblTelefono2.Location = New System.Drawing.Point(289, 31)
        Me.LblTelefono2.Name = "LblTelefono2"
        Me.LblTelefono2.Size = New System.Drawing.Size(96, 25)
        Me.LblTelefono2.TabIndex = 66
        Me.LblTelefono2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(217, 37)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 13)
        Me.Label11.TabIndex = 65
        Me.Label11.Text = "Teléfono 2"
        '
        'LblTelefono1
        '
        Me.LblTelefono1.BackColor = System.Drawing.Color.White
        Me.LblTelefono1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblTelefono1.Location = New System.Drawing.Point(89, 31)
        Me.LblTelefono1.Name = "LblTelefono1"
        Me.LblTelefono1.Size = New System.Drawing.Size(96, 25)
        Me.LblTelefono1.TabIndex = 64
        Me.LblTelefono1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(17, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 63
        Me.Label9.Text = "Teléfono 1"
        '
        'LblObservacion
        '
        Me.LblObservacion.BackColor = System.Drawing.Color.White
        Me.LblObservacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblObservacion.Location = New System.Drawing.Point(89, 135)
        Me.LblObservacion.Name = "LblObservacion"
        Me.LblObservacion.Size = New System.Drawing.Size(481, 61)
        Me.LblObservacion.TabIndex = 62
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(17, 132)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "Observación"
        '
        'LblDireccion
        '
        Me.LblDireccion.BackColor = System.Drawing.Color.White
        Me.LblDireccion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblDireccion.Location = New System.Drawing.Point(89, 64)
        Me.LblDireccion.Name = "LblDireccion"
        Me.LblDireccion.Size = New System.Drawing.Size(480, 61)
        Me.LblDireccion.TabIndex = 60
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(542, 308)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Salir"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.PictureBox3.Location = New System.Drawing.Point(530, 257)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(51, 48)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 58
        Me.PictureBox3.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(475, 308)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Facturar"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.PictureBox2.Location = New System.Drawing.Point(473, 257)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(51, 48)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 56
        Me.PictureBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(421, 308)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Buscar"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F1
        Me.PictureBox1.Location = New System.Drawing.Point(416, 257)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(51, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 54
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(17, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Dirección"
        '
        'FrmBusquedaPreFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1243, 672)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LvwDetalle)
        Me.Controls.Add(Me.PnlFiltros)
        Me.Controls.Add(Me.LvwDocumentos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBusquedaPreFactura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturas Pendientes"
        Me.CMSDocumentos.ResumeLayout(False)
        Me.PnlFiltros.ResumeLayout(False)
        Me.PnlFiltros.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LvwDocumentos As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents RdbFechaEntrega As System.Windows.Forms.RadioButton
    Friend WithEvents RdbMostarTodo As System.Windows.Forms.RadioButton
    Friend WithEvents DtpFechaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents CMSDocumentos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuEliminarPrefactura As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents RdbNombre As System.Windows.Forms.RadioButton
    Friend WithEvents LvwDetalle As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LblDireccion As System.Windows.Forms.Label
    Friend WithEvents LblTelefono2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LblTelefono1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LblObservacion As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblClienteTipo As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblVendedor As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents RdbNumero As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents ColumnHeader25 As ColumnHeader
    Friend WithEvents ColumnHeader26 As ColumnHeader
End Class
