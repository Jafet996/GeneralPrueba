<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmOrdenCompra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOrdenCompra))
        Me.LblTotalCosto = New System.Windows.Forms.Label()
        Me.Lbl_Total_Tit = New System.Windows.Forms.Label()
        Me.PnEncabezado = New System.Windows.Forms.Panel()
        Me.TxtProveedorNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtProveedor = New System.Windows.Forms.TextBox()
        Me.TxtComentario = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.TxtUnidadMedida = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LvwDetalle = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MenuDetalle = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuModificarLinea = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuEliminarLinea = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuConsulta = New System.Windows.Forms.ToolStripMenuItem()
        Me.TxtSaldo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtCosto = New System.Windows.Forms.TextBox()
        Me.TxtCantidad = New System.Windows.Forms.TextBox()
        Me.TxtArticuloNombre = New System.Windows.Forms.TextBox()
        Me.TxtArticulo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbl_CantidadLabel = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnBuscar = New System.Windows.Forms.ToolStripButton()
        Me.BtnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.BtnModificar = New System.Windows.Forms.ToolStripButton()
        Me.BtnAplicar = New System.Windows.Forms.ToolStripButton()
        Me.BtnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.BtnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnSaldos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnSalir = New System.Windows.Forms.ToolStripButton()
        Me.BtnSugerir = New System.Windows.Forms.ToolStripDropDownButton()
        Me.Mnu7Dias = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnu15Dias = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnu30Dias = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnu60Dias = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnu90Dias = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusBar = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSNombreEmpresa = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSNombreSucursal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PnLineaDetalle = New System.Windows.Forms.Panel()
        Me.TxtCostoActual = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtFactorConversion = New System.Windows.Forms.TextBox()
        Me.TxtMaximo = New System.Windows.Forms.TextBox()
        Me.TxtTransito = New System.Windows.Forms.TextBox()
        Me.TxtBonificacion = New System.Windows.Forms.TextBox()
        Me.TxtPorcDesc = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LblSubTotal = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.LblDescuento = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.LblImpuestoVenta = New System.Windows.Forms.Label()
        Me.LblTotalBonificacion = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PicLogo = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PnEncabezado.SuspendLayout()
        Me.MenuDetalle.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.PnLineaDetalle.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblTotalCosto
        '
        Me.LblTotalCosto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblTotalCosto.BackColor = System.Drawing.Color.White
        Me.LblTotalCosto.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalCosto.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalCosto.Location = New System.Drawing.Point(1097, 16)
        Me.LblTotalCosto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTotalCosto.Name = "LblTotalCosto"
        Me.LblTotalCosto.Size = New System.Drawing.Size(181, 28)
        Me.LblTotalCosto.TabIndex = 3
        Me.LblTotalCosto.Text = "0.00"
        Me.LblTotalCosto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_Total_Tit
        '
        Me.Lbl_Total_Tit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Total_Tit.AutoSize = True
        Me.Lbl_Total_Tit.BackColor = System.Drawing.Color.White
        Me.Lbl_Total_Tit.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Total_Tit.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Lbl_Total_Tit.Location = New System.Drawing.Point(948, 21)
        Me.Lbl_Total_Tit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Total_Tit.Name = "Lbl_Total_Tit"
        Me.Lbl_Total_Tit.Size = New System.Drawing.Size(49, 18)
        Me.Lbl_Total_Tit.TabIndex = 2
        Me.Lbl_Total_Tit.Text = "Total"
        Me.Lbl_Total_Tit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnEncabezado
        '
        Me.PnEncabezado.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.PnEncabezado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnEncabezado.Controls.Add(Me.TxtProveedorNombre)
        Me.PnEncabezado.Controls.Add(Me.Label2)
        Me.PnEncabezado.Controls.Add(Me.TxtProveedor)
        Me.PnEncabezado.Controls.Add(Me.TxtComentario)
        Me.PnEncabezado.Controls.Add(Me.Label5)
        Me.PnEncabezado.Controls.Add(Me.LblEstado)
        Me.PnEncabezado.Controls.Add(Me.DtpFecha)
        Me.PnEncabezado.Controls.Add(Me.Label4)
        Me.PnEncabezado.Controls.Add(Me.Label1)
        Me.PnEncabezado.Controls.Add(Me.Label6)
        Me.PnEncabezado.Controls.Add(Me.TxtNumero)
        Me.PnEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnEncabezado.Location = New System.Drawing.Point(0, 96)
        Me.PnEncabezado.Margin = New System.Windows.Forms.Padding(4)
        Me.PnEncabezado.Name = "PnEncabezado"
        Me.PnEncabezado.Size = New System.Drawing.Size(1644, 130)
        Me.PnEncabezado.TabIndex = 8
        '
        'TxtProveedorNombre
        '
        Me.TxtProveedorNombre.BackColor = System.Drawing.SystemColors.Window
        Me.TxtProveedorNombre.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedorNombre.Location = New System.Drawing.Point(275, 53)
        Me.TxtProveedorNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtProveedorNombre.Name = "TxtProveedorNombre"
        Me.TxtProveedorNombre.ReadOnly = True
        Me.TxtProveedorNombre.Size = New System.Drawing.Size(464, 27)
        Me.TxtProveedorNombre.TabIndex = 2
        Me.TxtProveedorNombre.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(11, 53)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 28)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Proveedor "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtProveedor
        '
        Me.TxtProveedor.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor.Location = New System.Drawing.Point(149, 53)
        Me.TxtProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtProveedor.Name = "TxtProveedor"
        Me.TxtProveedor.Size = New System.Drawing.Size(116, 27)
        Me.TxtProveedor.TabIndex = 1
        Me.TxtProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtComentario
        '
        Me.TxtComentario.Location = New System.Drawing.Point(149, 89)
        Me.TxtComentario.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtComentario.MaxLength = 200
        Me.TxtComentario.Name = "TxtComentario"
        Me.TxtComentario.Size = New System.Drawing.Size(1480, 26)
        Me.TxtComentario.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(1400, 17)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 28)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Fecha "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblEstado
        '
        Me.LblEstado.BackColor = System.Drawing.Color.White
        Me.LblEstado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblEstado.Location = New System.Drawing.Point(1501, 54)
        Me.LblEstado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(128, 27)
        Me.LblEstado.TabIndex = 23
        Me.LblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DtpFecha
        '
        Me.DtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.DtpFecha.Enabled = False
        Me.DtpFecha.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFecha.Location = New System.Drawing.Point(1501, 17)
        Me.DtpFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(127, 27)
        Me.DtpFecha.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(1400, 53)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 28)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Estado "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 28)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Orden N° "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(11, 89)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(131, 28)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Comentario "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtNumero
        '
        Me.TxtNumero.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumero.Location = New System.Drawing.Point(149, 17)
        Me.TxtNumero.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(116, 27)
        Me.TxtNumero.TabIndex = 0
        Me.TxtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtUnidadMedida
        '
        Me.TxtUnidadMedida.BackColor = System.Drawing.SystemColors.Window
        Me.TxtUnidadMedida.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUnidadMedida.Location = New System.Drawing.Point(549, 36)
        Me.TxtUnidadMedida.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtUnidadMedida.Name = "TxtUnidadMedida"
        Me.TxtUnidadMedida.ReadOnly = True
        Me.TxtUnidadMedida.Size = New System.Drawing.Size(107, 27)
        Me.TxtUnidadMedida.TabIndex = 6
        Me.TxtUnidadMedida.TabStop = False
        Me.TxtUnidadMedida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(549, 10)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(108, 27)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "UM"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LvwDetalle
        '
        Me.LvwDetalle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18})
        Me.LvwDetalle.ContextMenuStrip = Me.MenuDetalle
        Me.LvwDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvwDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LvwDetalle.FullRowSelect = True
        Me.LvwDetalle.HideSelection = False
        Me.LvwDetalle.Location = New System.Drawing.Point(0, 305)
        Me.LvwDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.LvwDetalle.Name = "LvwDetalle"
        Me.LvwDetalle.Size = New System.Drawing.Size(1644, 444)
        Me.LvwDetalle.TabIndex = 14
        Me.LvwDetalle.UseCompatibleStateImageBehavior = False
        Me.LvwDetalle.View = System.Windows.Forms.View.Details
        '
        'MenuDetalle
        '
        Me.MenuDetalle.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuDetalle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuModificarLinea, Me.MnuEliminarLinea, Me.MnuConsulta})
        Me.MenuDetalle.Name = "MenuDetalle"
        Me.MenuDetalle.Size = New System.Drawing.Size(143, 76)
        '
        'MnuModificarLinea
        '
        Me.MnuModificarLinea.Name = "MnuModificarLinea"
        Me.MnuModificarLinea.Size = New System.Drawing.Size(142, 24)
        Me.MnuModificarLinea.Text = "Modificar"
        '
        'MnuEliminarLinea
        '
        Me.MnuEliminarLinea.Name = "MnuEliminarLinea"
        Me.MnuEliminarLinea.Size = New System.Drawing.Size(142, 24)
        Me.MnuEliminarLinea.Text = "Eliminar"
        '
        'MnuConsulta
        '
        Me.MnuConsulta.Name = "MnuConsulta"
        Me.MnuConsulta.Size = New System.Drawing.Size(142, 24)
        Me.MnuConsulta.Text = "Consulta"
        '
        'TxtSaldo
        '
        Me.TxtSaldo.BackColor = System.Drawing.SystemColors.Window
        Me.TxtSaldo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaldo.Location = New System.Drawing.Point(728, 36)
        Me.TxtSaldo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtSaldo.Name = "TxtSaldo"
        Me.TxtSaldo.ReadOnly = True
        Me.TxtSaldo.Size = New System.Drawing.Size(99, 27)
        Me.TxtSaldo.TabIndex = 7
        Me.TxtSaldo.TabStop = False
        Me.TxtSaldo.Text = "0.00"
        Me.TxtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(728, 10)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 27)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Saldo"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCosto
        '
        Me.TxtCosto.Enabled = False
        Me.TxtCosto.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCosto.Location = New System.Drawing.Point(1191, 36)
        Me.TxtCosto.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCosto.Name = "TxtCosto"
        Me.TxtCosto.Size = New System.Drawing.Size(117, 27)
        Me.TxtCosto.TabIndex = 10
        Me.TxtCosto.Text = "0.00"
        Me.TxtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Enabled = False
        Me.TxtCantidad.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidad.Location = New System.Drawing.Point(1395, 36)
        Me.TxtCantidad.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCantidad.MaxLength = 9
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(103, 27)
        Me.TxtCantidad.TabIndex = 12
        Me.TxtCantidad.Text = "0.00"
        Me.TxtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtArticuloNombre
        '
        Me.TxtArticuloNombre.BackColor = System.Drawing.SystemColors.Window
        Me.TxtArticuloNombre.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtArticuloNombre.Location = New System.Drawing.Point(167, 36)
        Me.TxtArticuloNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtArticuloNombre.Name = "TxtArticuloNombre"
        Me.TxtArticuloNombre.ReadOnly = True
        Me.TxtArticuloNombre.Size = New System.Drawing.Size(373, 27)
        Me.TxtArticuloNombre.TabIndex = 5
        Me.TxtArticuloNombre.TabStop = False
        '
        'TxtArticulo
        '
        Me.TxtArticulo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtArticulo.Location = New System.Drawing.Point(9, 36)
        Me.TxtArticulo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtArticulo.MaxLength = 25
        Me.TxtArticulo.Name = "TxtArticulo"
        Me.TxtArticulo.Size = New System.Drawing.Size(152, 27)
        Me.TxtArticulo.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(1191, 10)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(117, 27)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Costo"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_CantidadLabel
        '
        Me.lbl_CantidadLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.lbl_CantidadLabel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CantidadLabel.ForeColor = System.Drawing.Color.White
        Me.lbl_CantidadLabel.Location = New System.Drawing.Point(1395, 10)
        Me.lbl_CantidadLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_CantidadLabel.Name = "lbl_CantidadLabel"
        Me.lbl_CantidadLabel.Size = New System.Drawing.Size(104, 27)
        Me.lbl_CantidadLabel.TabIndex = 6
        Me.lbl_CantidadLabel.Text = "Cantidad"
        Me.lbl_CantidadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(167, 10)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(375, 27)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Nombre"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label7.Location = New System.Drawing.Point(9, 10)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(153, 27)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Articulo"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(48, 48)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnBuscar, Me.BtnNuevo, Me.BtnModificar, Me.BtnAplicar, Me.BtnEliminar, Me.BtnCancelar, Me.BtnImprimir, Me.ToolStripSeparator3, Me.BtnSaldos, Me.ToolStripSeparator4, Me.BtnSalir, Me.BtnSugerir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1511, 96)
        Me.ToolStrip1.TabIndex = 11
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Image = Global.Compras.My.Resources.Resources.Blue_F1
        Me.BtnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(56, 93)
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Image = Global.Compras.My.Resources.Resources.Blue_F2
        Me.BtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(56, 93)
        Me.BtnNuevo.Text = "Nuevo"
        Me.BtnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnModificar
        '
        Me.BtnModificar.Image = Global.Compras.My.Resources.Resources.Blue_F3
        Me.BtnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(66, 93)
        Me.BtnModificar.Text = "Guardar"
        Me.BtnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnAplicar
        '
        Me.BtnAplicar.Image = Global.Compras.My.Resources.Resources.Blue_F4
        Me.BtnAplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnAplicar.Name = "BtnAplicar"
        Me.BtnAplicar.Size = New System.Drawing.Size(60, 93)
        Me.BtnAplicar.Text = "Aplicar"
        Me.BtnAplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Image = Global.Compras.My.Resources.Resources.Blue_F5
        Me.BtnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(67, 93)
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Compras.My.Resources.Resources.Blue_F6
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(63, 93)
        Me.BtnCancelar.Text = "Limpiar"
        Me.BtnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Image = Global.Compras.My.Resources.Resources.Blue_F7
        Me.BtnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(70, 93)
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 96)
        '
        'BtnSaldos
        '
        Me.BtnSaldos.Image = Global.Compras.My.Resources.Resources.Blue_F8
        Me.BtnSaldos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSaldos.Name = "BtnSaldos"
        Me.BtnSaldos.Size = New System.Drawing.Size(57, 93)
        Me.BtnSaldos.Text = "Saldos"
        Me.BtnSaldos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 96)
        '
        'BtnSalir
        '
        Me.BtnSalir.Image = Global.Compras.My.Resources.Resources.Blue_F9
        Me.BtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(52, 93)
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnSugerir
        '
        Me.BtnSugerir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Mnu7Dias, Me.Mnu15Dias, Me.Mnu30Dias, Me.Mnu60Dias, Me.Mnu90Dias})
        Me.BtnSugerir.Image = Global.Compras.My.Resources.Resources.Blue_F10
        Me.BtnSugerir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSugerir.Name = "BtnSugerir"
        Me.BtnSugerir.Size = New System.Drawing.Size(70, 93)
        Me.BtnSugerir.Text = "Sugerir"
        Me.BtnSugerir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Mnu7Dias
        '
        Me.Mnu7Dias.Name = "Mnu7Dias"
        Me.Mnu7Dias.Size = New System.Drawing.Size(133, 26)
        Me.Mnu7Dias.Text = "7 Días"
        '
        'Mnu15Dias
        '
        Me.Mnu15Dias.Name = "Mnu15Dias"
        Me.Mnu15Dias.Size = New System.Drawing.Size(133, 26)
        Me.Mnu15Dias.Text = "15 Días"
        '
        'Mnu30Dias
        '
        Me.Mnu30Dias.Name = "Mnu30Dias"
        Me.Mnu30Dias.Size = New System.Drawing.Size(133, 26)
        Me.Mnu30Dias.Text = "30 Días"
        '
        'Mnu60Dias
        '
        Me.Mnu60Dias.Name = "Mnu60Dias"
        Me.Mnu60Dias.Size = New System.Drawing.Size(133, 26)
        Me.Mnu60Dias.Text = "60 Días"
        '
        'Mnu90Dias
        '
        Me.Mnu90Dias.Name = "Mnu90Dias"
        Me.Mnu90Dias.Size = New System.Drawing.Size(133, 26)
        Me.Mnu90Dias.Text = "90 Días"
        '
        'StatusBar
        '
        Me.StatusBar.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.TSSNombreEmpresa, Me.ToolStripStatusLabel3, Me.TSSNombreSucursal})
        Me.StatusBar.Location = New System.Drawing.Point(0, 807)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusBar.Size = New System.Drawing.Size(1644, 25)
        Me.StatusBar.TabIndex = 12
        Me.StatusBar.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Verdana", 9.75!)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(90, 20)
        Me.ToolStripStatusLabel1.Text = "Empresa "
        '
        'TSSNombreEmpresa
        '
        Me.TSSNombreEmpresa.AutoSize = False
        Me.TSSNombreEmpresa.Font = New System.Drawing.Font("Verdana", 9.75!)
        Me.TSSNombreEmpresa.Name = "TSSNombreEmpresa"
        Me.TSSNombreEmpresa.Size = New System.Drawing.Size(250, 20)
        Me.TSSNombreEmpresa.Text = "..."
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("Verdana", 9.75!)
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(89, 20)
        Me.ToolStripStatusLabel3.Text = "Sucursal "
        '
        'TSSNombreSucursal
        '
        Me.TSSNombreSucursal.AutoSize = False
        Me.TSSNombreSucursal.Font = New System.Drawing.Font("Verdana", 9.75!)
        Me.TSSNombreSucursal.Name = "TSSNombreSucursal"
        Me.TSSNombreSucursal.Size = New System.Drawing.Size(250, 20)
        Me.TSSNombreSucursal.Text = "..."
        '
        'PnLineaDetalle
        '
        Me.PnLineaDetalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnLineaDetalle.Controls.Add(Me.TxtCostoActual)
        Me.PnLineaDetalle.Controls.Add(Me.Label16)
        Me.PnLineaDetalle.Controls.Add(Me.TxtArticulo)
        Me.PnLineaDetalle.Controls.Add(Me.TxtFactorConversion)
        Me.PnLineaDetalle.Controls.Add(Me.TxtMaximo)
        Me.PnLineaDetalle.Controls.Add(Me.TxtTransito)
        Me.PnLineaDetalle.Controls.Add(Me.TxtBonificacion)
        Me.PnLineaDetalle.Controls.Add(Me.TxtPorcDesc)
        Me.PnLineaDetalle.Controls.Add(Me.TxtUnidadMedida)
        Me.PnLineaDetalle.Controls.Add(Me.TxtArticuloNombre)
        Me.PnLineaDetalle.Controls.Add(Me.TxtCantidad)
        Me.PnLineaDetalle.Controls.Add(Me.TxtCosto)
        Me.PnLineaDetalle.Controls.Add(Me.TxtSaldo)
        Me.PnLineaDetalle.Controls.Add(Me.Label15)
        Me.PnLineaDetalle.Controls.Add(Me.Label14)
        Me.PnLineaDetalle.Controls.Add(Me.Label13)
        Me.PnLineaDetalle.Controls.Add(Me.Label3)
        Me.PnLineaDetalle.Controls.Add(Me.Label8)
        Me.PnLineaDetalle.Controls.Add(Me.Label7)
        Me.PnLineaDetalle.Controls.Add(Me.lbl_CantidadLabel)
        Me.PnLineaDetalle.Controls.Add(Me.Label10)
        Me.PnLineaDetalle.Controls.Add(Me.Label11)
        Me.PnLineaDetalle.Controls.Add(Me.Label9)
        Me.PnLineaDetalle.Controls.Add(Me.Label12)
        Me.PnLineaDetalle.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnLineaDetalle.Location = New System.Drawing.Point(0, 226)
        Me.PnLineaDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.PnLineaDetalle.Name = "PnLineaDetalle"
        Me.PnLineaDetalle.Size = New System.Drawing.Size(1644, 79)
        Me.PnLineaDetalle.TabIndex = 15
        '
        'TxtCostoActual
        '
        Me.TxtCostoActual.BackColor = System.Drawing.Color.White
        Me.TxtCostoActual.Enabled = False
        Me.TxtCostoActual.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCostoActual.Location = New System.Drawing.Point(1048, 36)
        Me.TxtCostoActual.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCostoActual.Name = "TxtCostoActual"
        Me.TxtCostoActual.ReadOnly = True
        Me.TxtCostoActual.Size = New System.Drawing.Size(133, 27)
        Me.TxtCostoActual.TabIndex = 26
        Me.TxtCostoActual.TabStop = False
        Me.TxtCostoActual.Text = "0.00"
        Me.TxtCostoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(1048, 10)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(135, 27)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Costo Actual"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtFactorConversion
        '
        Me.TxtFactorConversion.BackColor = System.Drawing.SystemColors.Window
        Me.TxtFactorConversion.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFactorConversion.Location = New System.Drawing.Point(663, 36)
        Me.TxtFactorConversion.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFactorConversion.Name = "TxtFactorConversion"
        Me.TxtFactorConversion.ReadOnly = True
        Me.TxtFactorConversion.Size = New System.Drawing.Size(55, 27)
        Me.TxtFactorConversion.TabIndex = 24
        Me.TxtFactorConversion.TabStop = False
        Me.TxtFactorConversion.Text = "0"
        Me.TxtFactorConversion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtMaximo
        '
        Me.TxtMaximo.BackColor = System.Drawing.SystemColors.Window
        Me.TxtMaximo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMaximo.Location = New System.Drawing.Point(939, 36)
        Me.TxtMaximo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtMaximo.Name = "TxtMaximo"
        Me.TxtMaximo.ReadOnly = True
        Me.TxtMaximo.Size = New System.Drawing.Size(99, 27)
        Me.TxtMaximo.TabIndex = 9
        Me.TxtMaximo.TabStop = False
        Me.TxtMaximo.Text = "0.00"
        Me.TxtMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTransito
        '
        Me.TxtTransito.BackColor = System.Drawing.SystemColors.Window
        Me.TxtTransito.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTransito.Location = New System.Drawing.Point(835, 36)
        Me.TxtTransito.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTransito.Name = "TxtTransito"
        Me.TxtTransito.ReadOnly = True
        Me.TxtTransito.Size = New System.Drawing.Size(99, 27)
        Me.TxtTransito.TabIndex = 8
        Me.TxtTransito.TabStop = False
        Me.TxtTransito.Text = "0.00"
        Me.TxtTransito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtBonificacion
        '
        Me.TxtBonificacion.Enabled = False
        Me.TxtBonificacion.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBonificacion.Location = New System.Drawing.Point(1504, 36)
        Me.TxtBonificacion.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtBonificacion.MaxLength = 9
        Me.TxtBonificacion.Name = "TxtBonificacion"
        Me.TxtBonificacion.Size = New System.Drawing.Size(101, 27)
        Me.TxtBonificacion.TabIndex = 13
        Me.TxtBonificacion.Text = "0.00"
        Me.TxtBonificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPorcDesc
        '
        Me.TxtPorcDesc.Enabled = False
        Me.TxtPorcDesc.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPorcDesc.Location = New System.Drawing.Point(1313, 36)
        Me.TxtPorcDesc.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPorcDesc.Name = "TxtPorcDesc"
        Me.TxtPorcDesc.Size = New System.Drawing.Size(75, 27)
        Me.TxtPorcDesc.TabIndex = 11
        Me.TxtPorcDesc.Text = "0.00"
        Me.TxtPorcDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(939, 10)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 27)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Máximo"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(835, 10)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 27)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "Tránsito"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(1504, 10)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 27)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Bonif."
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(1313, 10)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 27)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Desc."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(663, 10)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 27)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "FC"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblSubTotal
        '
        Me.LblSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblSubTotal.BackColor = System.Drawing.Color.White
        Me.LblSubTotal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubTotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblSubTotal.Location = New System.Drawing.Point(140, 16)
        Me.LblSubTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSubTotal.Name = "LblSubTotal"
        Me.LblSubTotal.Size = New System.Drawing.Size(161, 28)
        Me.LblSubTotal.TabIndex = 66
        Me.LblSubTotal.Text = "0.00"
        Me.LblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.White
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label17.Location = New System.Drawing.Point(8, 21)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(85, 18)
        Me.Label17.TabIndex = 65
        Me.Label17.Text = "Sub Total"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.White
        Me.Label18.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label18.Location = New System.Drawing.Point(320, 21)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(94, 18)
        Me.Label18.TabIndex = 68
        Me.Label18.Text = "Descuento"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblDescuento
        '
        Me.LblDescuento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblDescuento.BackColor = System.Drawing.Color.White
        Me.LblDescuento.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescuento.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblDescuento.Location = New System.Drawing.Point(452, 16)
        Me.LblDescuento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDescuento.Name = "LblDescuento"
        Me.LblDescuento.Size = New System.Drawing.Size(161, 28)
        Me.LblDescuento.TabIndex = 69
        Me.LblDescuento.Text = "0.00"
        Me.LblDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.White
        Me.Label20.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label20.Location = New System.Drawing.Point(633, 21)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(37, 18)
        Me.Label20.TabIndex = 71
        Me.Label20.Text = "I.V."
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblImpuestoVenta
        '
        Me.LblImpuestoVenta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblImpuestoVenta.BackColor = System.Drawing.Color.White
        Me.LblImpuestoVenta.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblImpuestoVenta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblImpuestoVenta.Location = New System.Drawing.Point(765, 16)
        Me.LblImpuestoVenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblImpuestoVenta.Name = "LblImpuestoVenta"
        Me.LblImpuestoVenta.Size = New System.Drawing.Size(161, 28)
        Me.LblImpuestoVenta.TabIndex = 72
        Me.LblImpuestoVenta.Text = "0.00"
        Me.LblImpuestoVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTotalBonificacion
        '
        Me.LblTotalBonificacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblTotalBonificacion.BackColor = System.Drawing.Color.White
        Me.LblTotalBonificacion.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalBonificacion.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalBonificacion.Location = New System.Drawing.Point(1449, 16)
        Me.LblTotalBonificacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTotalBonificacion.Name = "LblTotalBonificacion"
        Me.LblTotalBonificacion.Size = New System.Drawing.Size(181, 28)
        Me.LblTotalBonificacion.TabIndex = 75
        Me.LblTotalBonificacion.Text = "0.00"
        Me.LblTotalBonificacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.White
        Me.Label23.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label23.Location = New System.Drawing.Point(1299, 21)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(103, 18)
        Me.Label23.TabIndex = 74
        Me.Label23.Text = "Bonificación"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Controls.Add(Me.PicLogo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1644, 96)
        Me.Panel1.TabIndex = 77
        '
        'PicLogo
        '
        Me.PicLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.PicLogo.Location = New System.Drawing.Point(1511, 0)
        Me.PicLogo.Margin = New System.Windows.Forms.Padding(4)
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(133, 96)
        Me.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicLogo.TabIndex = 3
        Me.PicLogo.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Image = Global.Compras.My.Resources.Resources.Total5
        Me.PictureBox5.Location = New System.Drawing.Point(1292, 6)
        Me.PictureBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(351, 48)
        Me.PictureBox5.TabIndex = 76
        Me.PictureBox5.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = Global.Compras.My.Resources.Resources.Total6
        Me.PictureBox3.Location = New System.Drawing.Point(313, 6)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(312, 48)
        Me.PictureBox3.TabIndex = 70
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.Compras.My.Resources.Resources.Total6
        Me.PictureBox4.Location = New System.Drawing.Point(627, 6)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(312, 48)
        Me.PictureBox4.TabIndex = 73
        Me.PictureBox4.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = Global.Compras.My.Resources.Resources.Total5
        Me.PictureBox2.Location = New System.Drawing.Point(940, 6)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(351, 48)
        Me.PictureBox2.TabIndex = 64
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.Compras.My.Resources.Resources.Total6
        Me.PictureBox1.Location = New System.Drawing.Point(0, 6)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(312, 48)
        Me.PictureBox1.TabIndex = 67
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.Lbl_Total_Tit)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.LblSubTotal)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.LblTotalCosto)
        Me.Panel2.Controls.Add(Me.LblImpuestoVenta)
        Me.Panel2.Controls.Add(Me.PictureBox4)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.LblDescuento)
        Me.Panel2.Controls.Add(Me.LblTotalBonificacion)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Controls.Add(Me.PictureBox5)
        Me.Panel2.Controls.Add(Me.PictureBox3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 749)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1644, 58)
        Me.Panel2.TabIndex = 78
        '
        'FrmOrdenCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1644, 832)
        Me.Controls.Add(Me.LvwDetalle)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PnLineaDetalle)
        Me.Controls.Add(Me.PnEncabezado)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmOrdenCompra"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orden de Compra"
        Me.PnEncabezado.ResumeLayout(False)
        Me.PnEncabezado.PerformLayout()
        Me.MenuDetalle.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.PnLineaDetalle.ResumeLayout(False)
        Me.PnLineaDetalle.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblTotalCosto As System.Windows.Forms.Label
    Friend WithEvents Lbl_Total_Tit As System.Windows.Forms.Label
    Friend WithEvents PnEncabezado As System.Windows.Forms.Panel
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtSaldo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtArticuloNombre As System.Windows.Forms.TextBox
    Friend WithEvents TxtArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbl_CantidadLabel As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LvwDetalle As System.Windows.Forms.ListView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnAplicar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSNombreEmpresa As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSNombreSucursal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TxtCosto As System.Windows.Forms.TextBox
    Friend WithEvents TxtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents TxtUnidadMedida As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtComentario As System.Windows.Forms.TextBox
    Friend WithEvents PnLineaDetalle As System.Windows.Forms.Panel
    Friend WithEvents BtnSaldos As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuDetalle As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuModificarLinea As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEliminarLinea As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TxtProveedorNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtPorcDesc As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtBonificacion As System.Windows.Forms.TextBox
    Friend WithEvents TxtTransito As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtMaximo As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtFactorConversion As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents LblSubTotal As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents LblDescuento As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents LblImpuestoVenta As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents LblTotalBonificacion As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnSugerir As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents Mnu30Dias As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnu60Dias As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnu90Dias As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnu7Dias As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnu15Dias As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PicLogo As System.Windows.Forms.PictureBox
    Friend WithEvents TxtCostoActual As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents MnuConsulta As ToolStripMenuItem
    Friend WithEvents Panel2 As Panel
End Class
