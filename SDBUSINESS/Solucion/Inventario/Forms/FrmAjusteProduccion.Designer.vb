<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAjusteProduccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAjusteProduccion))
        Me.TxtUnidadMedida = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtCantidad = New System.Windows.Forms.TextBox()
        Me.TxtSuelto = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbl_CantidadLabel = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtArticulo = New System.Windows.Forms.TextBox()
        Me.TxtArticuloNombre = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtCosto = New System.Windows.Forms.TextBox()
        Me.StatusBar = New System.Windows.Forms.StatusStrip()
        Me.TSSNombreEmpresa = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSNombreSucursal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PnLineaDetalle = New System.Windows.Forms.Panel()
        Me.TxtSaldo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PnEncabezado = New System.Windows.Forms.Panel()
        Me.TxtComentario = New System.Windows.Forms.TextBox()
        Me.CmbTipoProduccion = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmbBodega = New System.Windows.Forms.ComboBox()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.LvwDetalle = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MenuDetalle = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuModificarLinea = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuEliminarLinea = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Lbl_Total_Tit = New System.Windows.Forms.Label()
        Me.LblTotalCosto = New System.Windows.Forms.Label()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BtnBuscar = New System.Windows.Forms.ToolStripButton()
        Me.BtnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.BtnModificar = New System.Windows.Forms.ToolStripButton()
        Me.BtnAplicar = New System.Windows.Forms.ToolStripButton()
        Me.BtnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.BtnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.BtnSaldos = New System.Windows.Forms.ToolStripButton()
        Me.BtnSalir = New System.Windows.Forms.ToolStripButton()
        Me.BtnCargaArticulos = New System.Windows.Forms.ToolStripButton()
        Me.PicLogo = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.PnLineaDetalle.SuspendLayout()
        Me.PnEncabezado.SuspendLayout()
        Me.MenuDetalle.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtUnidadMedida
        '
        Me.TxtUnidadMedida.BackColor = System.Drawing.SystemColors.Window
        Me.TxtUnidadMedida.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUnidadMedida.Location = New System.Drawing.Point(436, 37)
        Me.TxtUnidadMedida.Name = "TxtUnidadMedida"
        Me.TxtUnidadMedida.ReadOnly = True
        Me.TxtUnidadMedida.Size = New System.Drawing.Size(114, 23)
        Me.TxtUnidadMedida.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(436, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(114, 23)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Unidad Medida"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCantidad.Enabled = False
        Me.TxtCantidad.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidad.Location = New System.Drawing.Point(1021, 37)
        Me.TxtCantidad.MaxLength = 9
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(79, 23)
        Me.TxtCantidad.TabIndex = 7
        Me.TxtCantidad.Text = "0.00"
        Me.TxtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtSuelto
        '
        Me.TxtSuelto.BackColor = System.Drawing.SystemColors.Window
        Me.TxtSuelto.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSuelto.Location = New System.Drawing.Point(556, 37)
        Me.TxtSuelto.Name = "TxtSuelto"
        Me.TxtSuelto.ReadOnly = True
        Me.TxtSuelto.Size = New System.Drawing.Size(59, 23)
        Me.TxtSuelto.TabIndex = 14
        Me.TxtSuelto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(127, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(303, 23)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Nombre"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(6, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 23)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Articulo"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_CantidadLabel
        '
        Me.lbl_CantidadLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_CantidadLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.lbl_CantidadLabel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CantidadLabel.ForeColor = System.Drawing.Color.White
        Me.lbl_CantidadLabel.Location = New System.Drawing.Point(1021, 11)
        Me.lbl_CantidadLabel.Name = "lbl_CantidadLabel"
        Me.lbl_CantidadLabel.Size = New System.Drawing.Size(79, 23)
        Me.lbl_CantidadLabel.TabIndex = 6
        Me.lbl_CantidadLabel.Text = "Cantidad"
        Me.lbl_CantidadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(908, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 23)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Costo"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtArticulo
        '
        Me.TxtArticulo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtArticulo.Location = New System.Drawing.Point(6, 37)
        Me.TxtArticulo.MaxLength = 25
        Me.TxtArticulo.Name = "TxtArticulo"
        Me.TxtArticulo.Size = New System.Drawing.Size(115, 23)
        Me.TxtArticulo.TabIndex = 1
        '
        'TxtArticuloNombre
        '
        Me.TxtArticuloNombre.BackColor = System.Drawing.SystemColors.Window
        Me.TxtArticuloNombre.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtArticuloNombre.Location = New System.Drawing.Point(127, 37)
        Me.TxtArticuloNombre.Name = "TxtArticuloNombre"
        Me.TxtArticuloNombre.ReadOnly = True
        Me.TxtArticuloNombre.Size = New System.Drawing.Size(303, 23)
        Me.TxtArticuloNombre.TabIndex = 3
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.White
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(48, 48)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnBuscar, Me.BtnNuevo, Me.BtnModificar, Me.BtnAplicar, Me.BtnEliminar, Me.BtnCancelar, Me.BtnImprimir, Me.ToolStripSeparator3, Me.BtnSaldos, Me.ToolStripSeparator4, Me.BtnSalir, Me.BtnCargaArticulos})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1025, 72)
        Me.ToolStrip1.TabIndex = 11
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 72)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 72)
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(556, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 23)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Suelto"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCosto
        '
        Me.TxtCosto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCosto.Enabled = False
        Me.TxtCosto.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCosto.Location = New System.Drawing.Point(908, 37)
        Me.TxtCosto.Name = "TxtCosto"
        Me.TxtCosto.Size = New System.Drawing.Size(107, 23)
        Me.TxtCosto.TabIndex = 9
        Me.TxtCosto.Text = "0.00"
        Me.TxtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'StatusBar
        '
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.TSSNombreEmpresa, Me.ToolStripStatusLabel3, Me.TSSNombreSucursal})
        Me.StatusBar.Location = New System.Drawing.Point(0, 652)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(1125, 22)
        Me.StatusBar.TabIndex = 71
        Me.StatusBar.Text = "StatusStrip1"
        '
        'TSSNombreEmpresa
        '
        Me.TSSNombreEmpresa.AutoSize = False
        Me.TSSNombreEmpresa.Font = New System.Drawing.Font("Verdana", 9.75!)
        Me.TSSNombreEmpresa.Name = "TSSNombreEmpresa"
        Me.TSSNombreEmpresa.Size = New System.Drawing.Size(250, 17)
        Me.TSSNombreEmpresa.Text = "..."
        '
        'TSSNombreSucursal
        '
        Me.TSSNombreSucursal.AutoSize = False
        Me.TSSNombreSucursal.Font = New System.Drawing.Font("Verdana", 9.75!)
        Me.TSSNombreSucursal.Name = "TSSNombreSucursal"
        Me.TSSNombreSucursal.Size = New System.Drawing.Size(250, 17)
        Me.TSSNombreSucursal.Text = "..."
        '
        'PnLineaDetalle
        '
        Me.PnLineaDetalle.BackColor = System.Drawing.Color.White
        Me.PnLineaDetalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnLineaDetalle.Controls.Add(Me.Label8)
        Me.PnLineaDetalle.Controls.Add(Me.TxtSuelto)
        Me.PnLineaDetalle.Controls.Add(Me.Label7)
        Me.PnLineaDetalle.Controls.Add(Me.Label12)
        Me.PnLineaDetalle.Controls.Add(Me.lbl_CantidadLabel)
        Me.PnLineaDetalle.Controls.Add(Me.TxtUnidadMedida)
        Me.PnLineaDetalle.Controls.Add(Me.Label10)
        Me.PnLineaDetalle.Controls.Add(Me.Label9)
        Me.PnLineaDetalle.Controls.Add(Me.TxtArticulo)
        Me.PnLineaDetalle.Controls.Add(Me.TxtArticuloNombre)
        Me.PnLineaDetalle.Controls.Add(Me.TxtCantidad)
        Me.PnLineaDetalle.Controls.Add(Me.TxtCosto)
        Me.PnLineaDetalle.Controls.Add(Me.TxtSaldo)
        Me.PnLineaDetalle.Controls.Add(Me.Label11)
        Me.PnLineaDetalle.Location = New System.Drawing.Point(9, 196)
        Me.PnLineaDetalle.Name = "PnLineaDetalle"
        Me.PnLineaDetalle.Size = New System.Drawing.Size(1105, 81)
        Me.PnLineaDetalle.TabIndex = 72
        '
        'TxtSaldo
        '
        Me.TxtSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSaldo.BackColor = System.Drawing.SystemColors.Window
        Me.TxtSaldo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaldo.Location = New System.Drawing.Point(823, 37)
        Me.TxtSaldo.Name = "TxtSaldo"
        Me.TxtSaldo.ReadOnly = True
        Me.TxtSaldo.Size = New System.Drawing.Size(79, 23)
        Me.TxtSaldo.TabIndex = 5
        Me.TxtSaldo.Text = "0"
        Me.TxtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(823, 11)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 23)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Saldo"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnEncabezado
        '
        Me.PnEncabezado.BackColor = System.Drawing.Color.White
        Me.PnEncabezado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnEncabezado.Controls.Add(Me.TxtComentario)
        Me.PnEncabezado.Controls.Add(Me.CmbTipoProduccion)
        Me.PnEncabezado.Controls.Add(Me.Label5)
        Me.PnEncabezado.Controls.Add(Me.LblEstado)
        Me.PnEncabezado.Controls.Add(Me.DtpFecha)
        Me.PnEncabezado.Controls.Add(Me.Label4)
        Me.PnEncabezado.Controls.Add(Me.Label2)
        Me.PnEncabezado.Controls.Add(Me.Label3)
        Me.PnEncabezado.Controls.Add(Me.Label1)
        Me.PnEncabezado.Controls.Add(Me.Label6)
        Me.PnEncabezado.Controls.Add(Me.CmbBodega)
        Me.PnEncabezado.Controls.Add(Me.TxtNumero)
        Me.PnEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnEncabezado.Location = New System.Drawing.Point(9, 84)
        Me.PnEncabezado.Name = "PnEncabezado"
        Me.PnEncabezado.Size = New System.Drawing.Size(1105, 106)
        Me.PnEncabezado.TabIndex = 69
        '
        'TxtComentario
        '
        Me.TxtComentario.Location = New System.Drawing.Point(112, 71)
        Me.TxtComentario.MaxLength = 200
        Me.TxtComentario.Name = "TxtComentario"
        Me.TxtComentario.Size = New System.Drawing.Size(748, 22)
        Me.TxtComentario.TabIndex = 24
        '
        'CmbTipoProduccion
        '
        Me.CmbTipoProduccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoProduccion.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbTipoProduccion.Location = New System.Drawing.Point(334, 13)
        Me.CmbTipoProduccion.Name = "CmbTipoProduccion"
        Me.CmbTipoProduccion.Size = New System.Drawing.Size(281, 24)
        Me.CmbTipoProduccion.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(923, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 23)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Fecha "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblEstado
        '
        Me.LblEstado.BackColor = System.Drawing.Color.White
        Me.LblEstado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblEstado.Location = New System.Drawing.Point(112, 42)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(105, 23)
        Me.LblEstado.TabIndex = 23
        Me.LblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DtpFecha
        '
        Me.DtpFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.DtpFecha.Enabled = False
        Me.DtpFecha.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFecha.Location = New System.Drawing.Point(999, 14)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(96, 23)
        Me.DtpFecha.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(8, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 23)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Estado"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(230, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 24)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Bodega "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(230, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 24)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Tipo "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ajuste N°"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(8, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 23)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Comentario"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbBodega
        '
        Me.CmbBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBodega.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbBodega.Location = New System.Drawing.Point(334, 41)
        Me.CmbBodega.Name = "CmbBodega"
        Me.CmbBodega.Size = New System.Drawing.Size(281, 24)
        Me.CmbBodega.TabIndex = 14
        '
        'TxtNumero
        '
        Me.TxtNumero.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumero.Location = New System.Drawing.Point(112, 14)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(105, 23)
        Me.TxtNumero.TabIndex = 1
        Me.TxtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LvwDetalle
        '
        Me.LvwDetalle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.LvwDetalle.ContextMenuStrip = Me.MenuDetalle
        Me.LvwDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LvwDetalle.FullRowSelect = True
        Me.LvwDetalle.Location = New System.Drawing.Point(9, 283)
        Me.LvwDetalle.Name = "LvwDetalle"
        Me.LvwDetalle.Size = New System.Drawing.Size(1105, 306)
        Me.LvwDetalle.TabIndex = 70
        Me.LvwDetalle.UseCompatibleStateImageBehavior = False
        Me.LvwDetalle.View = System.Windows.Forms.View.Details
        '
        'MenuDetalle
        '
        Me.MenuDetalle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuModificarLinea, Me.MnuEliminarLinea})
        Me.MenuDetalle.Name = "MenuDetalle"
        Me.MenuDetalle.Size = New System.Drawing.Size(126, 48)
        '
        'MnuModificarLinea
        '
        Me.MnuModificarLinea.Name = "MnuModificarLinea"
        Me.MnuModificarLinea.Size = New System.Drawing.Size(125, 22)
        Me.MnuModificarLinea.Text = "Modificar"
        '
        'MnuEliminarLinea
        '
        Me.MnuEliminarLinea.Name = "MnuEliminarLinea"
        Me.MnuEliminarLinea.Size = New System.Drawing.Size(125, 22)
        Me.MnuEliminarLinea.Text = "Eliminar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Controls.Add(Me.PicLogo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1125, 72)
        Me.Panel1.TabIndex = 74
        '
        'Lbl_Total_Tit
        '
        Me.Lbl_Total_Tit.AutoSize = True
        Me.Lbl_Total_Tit.BackColor = System.Drawing.Color.White
        Me.Lbl_Total_Tit.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Total_Tit.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Lbl_Total_Tit.Location = New System.Drawing.Point(871, 612)
        Me.Lbl_Total_Tit.Name = "Lbl_Total_Tit"
        Me.Lbl_Total_Tit.Size = New System.Drawing.Size(44, 16)
        Me.Lbl_Total_Tit.TabIndex = 75
        Me.Lbl_Total_Tit.Text = "Total"
        Me.Lbl_Total_Tit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalCosto
        '
        Me.LblTotalCosto.BackColor = System.Drawing.Color.White
        Me.LblTotalCosto.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalCosto.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalCosto.Location = New System.Drawing.Point(983, 609)
        Me.LblTotalCosto.Name = "LblTotalCosto"
        Me.LblTotalCosto.Size = New System.Drawing.Size(126, 22)
        Me.LblTotalCosto.TabIndex = 76
        Me.LblTotalCosto.Text = "0.00"
        Me.LblTotalCosto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Verdana", 9.75!)
        Me.ToolStripStatusLabel1.Image = Global.Inventario.My.Resources.Resources.Company_Building
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(84, 16)
        Me.ToolStripStatusLabel1.Text = "Empresa "
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("Verdana", 9.75!)
        Me.ToolStripStatusLabel3.Image = Global.Inventario.My.Resources.Resources.House__2_
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(85, 16)
        Me.ToolStripStatusLabel3.Text = "Sucursal "
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Inventario.My.Resources.Resources.Total5
        Me.PictureBox2.Location = New System.Drawing.Point(859, 602)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(263, 39)
        Me.PictureBox2.TabIndex = 73
        Me.PictureBox2.TabStop = False
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Image = Global.Inventario.My.Resources.Resources.Blue_F1
        Me.BtnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(52, 69)
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Image = Global.Inventario.My.Resources.Resources.Blue_F2
        Me.BtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(52, 69)
        Me.BtnNuevo.Text = "Nuevo"
        Me.BtnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnModificar
        '
        Me.BtnModificar.Image = Global.Inventario.My.Resources.Resources.Blue_F3
        Me.BtnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(53, 69)
        Me.BtnModificar.Text = "Guardar"
        Me.BtnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnAplicar
        '
        Me.BtnAplicar.Image = Global.Inventario.My.Resources.Resources.Blue_F4
        Me.BtnAplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnAplicar.Name = "BtnAplicar"
        Me.BtnAplicar.Size = New System.Drawing.Size(52, 69)
        Me.BtnAplicar.Text = "Aplicar"
        Me.BtnAplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Image = Global.Inventario.My.Resources.Resources.Blue_F5
        Me.BtnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(54, 69)
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Inventario.My.Resources.Resources.Blue_F6
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(52, 69)
        Me.BtnCancelar.Text = "Limpiar"
        Me.BtnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Image = Global.Inventario.My.Resources.Resources.Blue_F7
        Me.BtnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(57, 69)
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnSaldos
        '
        Me.BtnSaldos.Image = Global.Inventario.My.Resources.Resources.Blue_F8
        Me.BtnSaldos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSaldos.Name = "BtnSaldos"
        Me.BtnSaldos.Size = New System.Drawing.Size(52, 69)
        Me.BtnSaldos.Text = "Saldos"
        Me.BtnSaldos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnSalir
        '
        Me.BtnSalir.Image = Global.Inventario.My.Resources.Resources.Blue_F9
        Me.BtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(52, 69)
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnCargaArticulos
        '
        Me.BtnCargaArticulos.Image = Global.Inventario.My.Resources.Resources.Blue_F11
        Me.BtnCargaArticulos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCargaArticulos.Name = "BtnCargaArticulos"
        Me.BtnCargaArticulos.Size = New System.Drawing.Size(61, 69)
        Me.BtnCargaArticulos.Text = "Carga Art"
        Me.BtnCargaArticulos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnCargaArticulos.Visible = False
        '
        'PicLogo
        '
        Me.PicLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.PicLogo.Location = New System.Drawing.Point(1025, 0)
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(100, 72)
        Me.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicLogo.TabIndex = 1
        Me.PicLogo.TabStop = False
        '
        'FrmAjusteProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1125, 674)
        Me.Controls.Add(Me.Lbl_Total_Tit)
        Me.Controls.Add(Me.LblTotalCosto)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.PnLineaDetalle)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PnEncabezado)
        Me.Controls.Add(Me.LvwDetalle)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmAjusteProduccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajuste de Producción"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.PnLineaDetalle.ResumeLayout(False)
        Me.PnLineaDetalle.PerformLayout()
        Me.PnEncabezado.ResumeLayout(False)
        Me.PnEncabezado.PerformLayout()
        Me.MenuDetalle.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtUnidadMedida As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtCantidad As TextBox
    Friend WithEvents BtnEliminar As ToolStripButton
    Friend WithEvents BtnAplicar As ToolStripButton
    Friend WithEvents BtnModificar As ToolStripButton
    Friend WithEvents BtnNuevo As ToolStripButton
    Friend WithEvents TxtSuelto As TextBox
    Friend WithEvents BtnBuscar As ToolStripButton
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lbl_CantidadLabel As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TxtArticulo As TextBox
    Friend WithEvents TxtArticuloNombre As TextBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnCancelar As ToolStripButton
    Friend WithEvents BtnImprimir As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents BtnSaldos As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents BtnSalir As ToolStripButton
    Friend WithEvents BtnCargaArticulos As ToolStripButton
    Friend WithEvents Label12 As Label
    Friend WithEvents TxtCosto As TextBox
    Friend WithEvents StatusBar As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents TSSNombreEmpresa As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents TSSNombreSucursal As ToolStripStatusLabel
    Friend WithEvents PnLineaDetalle As Panel
    Friend WithEvents TxtSaldo As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PicLogo As PictureBox
    Friend WithEvents PnEncabezado As Panel
    Friend WithEvents TxtComentario As TextBox
    Friend WithEvents CmbTipoProduccion As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents LblEstado As Label
    Friend WithEvents DtpFecha As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents CmbBodega As ComboBox
    Friend WithEvents TxtNumero As TextBox
    Friend WithEvents LvwDetalle As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents MenuDetalle As ContextMenuStrip
    Friend WithEvents MnuModificarLinea As ToolStripMenuItem
    Friend WithEvents MnuEliminarLinea As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Lbl_Total_Tit As Label
    Friend WithEvents LblTotalCosto As Label
End Class
