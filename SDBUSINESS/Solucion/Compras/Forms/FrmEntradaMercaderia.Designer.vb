<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEntradaMercaderia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEntradaMercaderia))
        Me.LblTotalCosto = New System.Windows.Forms.Label()
        Me.Lbl_Total_Tit = New System.Windows.Forms.Label()
        Me.PnEncabezado = New System.Windows.Forms.Panel()
        Me.TxtPorcDescuentoGlobal = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TxtComprobante = New System.Windows.Forms.TextBox()
        Me.TxtDiasCredito = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtOrden = New System.Windows.Forms.TextBox()
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
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MenuDetalle = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuModificarLinea = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuEliminarLinea = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCrearArticuloSuelto = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuConsultar = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.BtnSaldos = New System.Windows.Forms.ToolStripButton()
        Me.BtnDesaplicarEntrada = New System.Windows.Forms.ToolStripButton()
        Me.BtnFacturas = New System.Windows.Forms.ToolStripButton()
        Me.BtnLotes = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnUtilidades = New System.Windows.Forms.ToolStripDropDownButton()
        Me.BtnCargarArchivoArticulos = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnCreacionDeArticulos = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnEscaneo = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusBar = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSNombreEmpresa = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSNombreSucursal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSClaveTitulo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSClave = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PnLineaDetalle = New System.Windows.Forms.Panel()
        Me.TxtCostoActual = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TxtPorcUtilidad = New System.Windows.Forms.TextBox()
        Me.TxtPrecio = New System.Windows.Forms.TextBox()
        Me.Lbl18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
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
        Me.PnlBotones = New System.Windows.Forms.Panel()
        Me.PicLogo = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PnEncabezado.SuspendLayout()
        Me.MenuDetalle.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.PnLineaDetalle.SuspendLayout()
        Me.PnlBotones.SuspendLayout()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTotalCosto
        '
        Me.LblTotalCosto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblTotalCosto.BackColor = System.Drawing.Color.White
        Me.LblTotalCosto.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalCosto.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalCosto.Location = New System.Drawing.Point(1095, 15)
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
        Me.Lbl_Total_Tit.Location = New System.Drawing.Point(946, 20)
        Me.Lbl_Total_Tit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Total_Tit.Name = "Lbl_Total_Tit"
        Me.Lbl_Total_Tit.Size = New System.Drawing.Size(49, 18)
        Me.Lbl_Total_Tit.TabIndex = 2
        Me.Lbl_Total_Tit.Text = "Total"
        Me.Lbl_Total_Tit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnEncabezado
        '
        Me.PnEncabezado.BackColor = System.Drawing.Color.White
        Me.PnEncabezado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnEncabezado.Controls.Add(Me.TxtPorcDescuentoGlobal)
        Me.PnEncabezado.Controls.Add(Me.Label25)
        Me.PnEncabezado.Controls.Add(Me.Label24)
        Me.PnEncabezado.Controls.Add(Me.TxtComprobante)
        Me.PnEncabezado.Controls.Add(Me.TxtDiasCredito)
        Me.PnEncabezado.Controls.Add(Me.Label22)
        Me.PnEncabezado.Controls.Add(Me.Label16)
        Me.PnEncabezado.Controls.Add(Me.TxtOrden)
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
        Me.PnEncabezado.Location = New System.Drawing.Point(0, 89)
        Me.PnEncabezado.Margin = New System.Windows.Forms.Padding(4)
        Me.PnEncabezado.Name = "PnEncabezado"
        Me.PnEncabezado.Size = New System.Drawing.Size(1644, 130)
        Me.PnEncabezado.TabIndex = 8
        '
        'TxtPorcDescuentoGlobal
        '
        Me.TxtPorcDescuentoGlobal.Location = New System.Drawing.Point(1231, 53)
        Me.TxtPorcDescuentoGlobal.Name = "TxtPorcDescuentoGlobal"
        Me.TxtPorcDescuentoGlobal.Size = New System.Drawing.Size(113, 26)
        Me.TxtPorcDescuentoGlobal.TabIndex = 37
        Me.TxtPorcDescuentoGlobal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label25.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(1092, 53)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(131, 28)
        Me.Label25.TabIndex = 36
        Me.Label25.Text = "% Desc"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label24.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(747, 16)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(131, 28)
        Me.Label24.TabIndex = 35
        Me.Label24.Text = "Comprobante"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtComprobante
        '
        Me.TxtComprobante.Enabled = False
        Me.TxtComprobante.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtComprobante.Location = New System.Drawing.Point(887, 17)
        Me.TxtComprobante.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtComprobante.Name = "TxtComprobante"
        Me.TxtComprobante.Size = New System.Drawing.Size(457, 27)
        Me.TxtComprobante.TabIndex = 34
        Me.TxtComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtDiasCredito
        '
        Me.TxtDiasCredito.BackColor = System.Drawing.SystemColors.Window
        Me.TxtDiasCredito.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDiasCredito.Location = New System.Drawing.Point(887, 54)
        Me.TxtDiasCredito.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtDiasCredito.Name = "TxtDiasCredito"
        Me.TxtDiasCredito.ReadOnly = True
        Me.TxtDiasCredito.Size = New System.Drawing.Size(113, 27)
        Me.TxtDiasCredito.TabIndex = 33
        Me.TxtDiasCredito.TabStop = False
        Me.TxtDiasCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label22.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(747, 53)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(131, 28)
        Me.Label22.TabIndex = 32
        Me.Label22.Text = "Días Crédito"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(469, 16)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(131, 28)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "Orden N° "
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtOrden
        '
        Me.TxtOrden.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOrden.Location = New System.Drawing.Point(612, 16)
        Me.TxtOrden.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtOrden.Name = "TxtOrden"
        Me.TxtOrden.Size = New System.Drawing.Size(127, 27)
        Me.TxtOrden.TabIndex = 30
        Me.TxtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtProveedorNombre
        '
        Me.TxtProveedorNombre.BackColor = System.Drawing.SystemColors.Window
        Me.TxtProveedorNombre.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedorNombre.Location = New System.Drawing.Point(275, 54)
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
        Me.TxtProveedor.Location = New System.Drawing.Point(149, 54)
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
        Me.TxtComentario.Size = New System.Drawing.Size(1478, 26)
        Me.TxtComentario.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(1400, 53)
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
        Me.LblEstado.Location = New System.Drawing.Point(1500, 17)
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
        Me.DtpFecha.Location = New System.Drawing.Point(1500, 54)
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
        Me.Label4.Location = New System.Drawing.Point(1400, 17)
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
        Me.Label1.Text = "Entrada N° "
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
        Me.TxtUnidadMedida.ForeColor = System.Drawing.Color.Maroon
        Me.TxtUnidadMedida.Location = New System.Drawing.Point(469, 36)
        Me.TxtUnidadMedida.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtUnidadMedida.Name = "TxtUnidadMedida"
        Me.TxtUnidadMedida.ReadOnly = True
        Me.TxtUnidadMedida.Size = New System.Drawing.Size(73, 27)
        Me.TxtUnidadMedida.TabIndex = 6
        Me.TxtUnidadMedida.TabStop = False
        Me.TxtUnidadMedida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(469, 10)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 27)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "UM"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LvwDetalle
        '
        Me.LvwDetalle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader23})
        Me.LvwDetalle.ContextMenuStrip = Me.MenuDetalle
        Me.LvwDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvwDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LvwDetalle.FullRowSelect = True
        Me.LvwDetalle.HideSelection = False
        Me.LvwDetalle.Location = New System.Drawing.Point(0, 298)
        Me.LvwDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.LvwDetalle.Name = "LvwDetalle"
        Me.LvwDetalle.Size = New System.Drawing.Size(1644, 449)
        Me.LvwDetalle.TabIndex = 17
        Me.LvwDetalle.UseCompatibleStateImageBehavior = False
        Me.LvwDetalle.View = System.Windows.Forms.View.Details
        '
        'MenuDetalle
        '
        Me.MenuDetalle.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuDetalle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuModificarLinea, Me.MnuEliminarLinea, Me.MnuCrearArticuloSuelto, Me.MnuConsultar})
        Me.MenuDetalle.Name = "MenuDetalle"
        Me.MenuDetalle.Size = New System.Drawing.Size(216, 100)
        '
        'MnuModificarLinea
        '
        Me.MnuModificarLinea.Name = "MnuModificarLinea"
        Me.MnuModificarLinea.Size = New System.Drawing.Size(215, 24)
        Me.MnuModificarLinea.Text = "Modificar"
        '
        'MnuEliminarLinea
        '
        Me.MnuEliminarLinea.Name = "MnuEliminarLinea"
        Me.MnuEliminarLinea.Size = New System.Drawing.Size(215, 24)
        Me.MnuEliminarLinea.Text = "Eliminar"
        '
        'MnuCrearArticuloSuelto
        '
        Me.MnuCrearArticuloSuelto.Name = "MnuCrearArticuloSuelto"
        Me.MnuCrearArticuloSuelto.Size = New System.Drawing.Size(215, 24)
        Me.MnuCrearArticuloSuelto.Text = "Crear Artículo Suelto"
        '
        'MnuConsultar
        '
        Me.MnuConsultar.Name = "MnuConsultar"
        Me.MnuConsultar.Size = New System.Drawing.Size(215, 24)
        Me.MnuConsultar.Text = "Consultar"
        '
        'TxtSaldo
        '
        Me.TxtSaldo.BackColor = System.Drawing.SystemColors.Window
        Me.TxtSaldo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaldo.ForeColor = System.Drawing.Color.DarkGreen
        Me.TxtSaldo.Location = New System.Drawing.Point(607, 36)
        Me.TxtSaldo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtSaldo.Name = "TxtSaldo"
        Me.TxtSaldo.ReadOnly = True
        Me.TxtSaldo.Size = New System.Drawing.Size(85, 27)
        Me.TxtSaldo.TabIndex = 8
        Me.TxtSaldo.TabStop = False
        Me.TxtSaldo.Text = "0.00"
        Me.TxtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(607, 10)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 28)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Saldo"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCosto
        '
        Me.TxtCosto.Enabled = False
        Me.TxtCosto.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCosto.ForeColor = System.Drawing.Color.Navy
        Me.TxtCosto.Location = New System.Drawing.Point(1103, 36)
        Me.TxtCosto.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCosto.Name = "TxtCosto"
        Me.TxtCosto.Size = New System.Drawing.Size(117, 27)
        Me.TxtCosto.TabIndex = 12
        Me.TxtCosto.Text = "0.00"
        Me.TxtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Enabled = False
        Me.TxtCantidad.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidad.ForeColor = System.Drawing.Color.Navy
        Me.TxtCantidad.Location = New System.Drawing.Point(1429, 36)
        Me.TxtCantidad.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCantidad.MaxLength = 9
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(89, 27)
        Me.TxtCantidad.TabIndex = 15
        Me.TxtCantidad.Text = "0.00"
        Me.TxtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtArticuloNombre
        '
        Me.TxtArticuloNombre.BackColor = System.Drawing.SystemColors.Window
        Me.TxtArticuloNombre.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtArticuloNombre.Location = New System.Drawing.Point(149, 36)
        Me.TxtArticuloNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtArticuloNombre.Name = "TxtArticuloNombre"
        Me.TxtArticuloNombre.ReadOnly = True
        Me.TxtArticuloNombre.Size = New System.Drawing.Size(316, 27)
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
        Me.TxtArticulo.Size = New System.Drawing.Size(132, 27)
        Me.TxtArticulo.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(1103, 10)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(119, 27)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Costo"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_CantidadLabel
        '
        Me.lbl_CantidadLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.lbl_CantidadLabel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CantidadLabel.ForeColor = System.Drawing.Color.White
        Me.lbl_CantidadLabel.Location = New System.Drawing.Point(1429, 10)
        Me.lbl_CantidadLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_CantidadLabel.Name = "lbl_CantidadLabel"
        Me.lbl_CantidadLabel.Size = New System.Drawing.Size(91, 27)
        Me.lbl_CantidadLabel.TabIndex = 6
        Me.lbl_CantidadLabel.Text = "Cantidad"
        Me.lbl_CantidadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(149, 10)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(317, 27)
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
        Me.Label7.Size = New System.Drawing.Size(133, 27)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Articulo"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.White
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(48, 48)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnBuscar, Me.BtnNuevo, Me.BtnModificar, Me.BtnAplicar, Me.BtnEliminar, Me.BtnCancelar, Me.BtnImprimir, Me.BtnSaldos, Me.BtnDesaplicarEntrada, Me.BtnFacturas, Me.BtnLotes, Me.ToolStripSeparator1, Me.BtnUtilidades})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1511, 89)
        Me.ToolStrip1.TabIndex = 11
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Image = Global.Compras.My.Resources.Resources.Blue_F1
        Me.BtnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(56, 86)
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Image = Global.Compras.My.Resources.Resources.Blue_F2
        Me.BtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(56, 86)
        Me.BtnNuevo.Text = "Nuevo"
        Me.BtnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnModificar
        '
        Me.BtnModificar.Image = Global.Compras.My.Resources.Resources.Blue_F3
        Me.BtnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(66, 86)
        Me.BtnModificar.Text = "Guardar"
        Me.BtnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnAplicar
        '
        Me.BtnAplicar.Image = Global.Compras.My.Resources.Resources.Blue_F4
        Me.BtnAplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnAplicar.Name = "BtnAplicar"
        Me.BtnAplicar.Size = New System.Drawing.Size(60, 86)
        Me.BtnAplicar.Text = "Aplicar"
        Me.BtnAplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Image = Global.Compras.My.Resources.Resources.Blue_F5
        Me.BtnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(67, 86)
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Compras.My.Resources.Resources.Blue_F6
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(63, 86)
        Me.BtnCancelar.Text = "Limpiar"
        Me.BtnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Image = Global.Compras.My.Resources.Resources.Blue_F7
        Me.BtnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(70, 86)
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnSaldos
        '
        Me.BtnSaldos.Image = Global.Compras.My.Resources.Resources.Blue_F8
        Me.BtnSaldos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSaldos.Name = "BtnSaldos"
        Me.BtnSaldos.Size = New System.Drawing.Size(57, 86)
        Me.BtnSaldos.Text = "Saldos"
        Me.BtnSaldos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnDesaplicarEntrada
        '
        Me.BtnDesaplicarEntrada.Image = Global.Compras.My.Resources.Resources.Blue_F9
        Me.BtnDesaplicarEntrada.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDesaplicarEntrada.Name = "BtnDesaplicarEntrada"
        Me.BtnDesaplicarEntrada.Size = New System.Drawing.Size(56, 86)
        Me.BtnDesaplicarEntrada.Text = "Anular"
        Me.BtnDesaplicarEntrada.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnFacturas
        '
        Me.BtnFacturas.Image = Global.Compras.My.Resources.Resources.Blue_F10
        Me.BtnFacturas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFacturas.Name = "BtnFacturas"
        Me.BtnFacturas.Size = New System.Drawing.Size(66, 86)
        Me.BtnFacturas.Text = "Facturas"
        Me.BtnFacturas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnLotes
        '
        Me.BtnLotes.Image = Global.Compras.My.Resources.Resources.Blue_F11
        Me.BtnLotes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLotes.Name = "BtnLotes"
        Me.BtnLotes.Size = New System.Drawing.Size(52, 86)
        Me.BtnLotes.Text = "Lotes"
        Me.BtnLotes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 89)
        '
        'BtnUtilidades
        '
        Me.BtnUtilidades.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnCargarArchivoArticulos, Me.BtnCreacionDeArticulos, Me.BtnEscaneo})
        Me.BtnUtilidades.Image = Global.Compras.My.Resources.Resources.Blue_F12
        Me.BtnUtilidades.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnUtilidades.Name = "BtnUtilidades"
        Me.BtnUtilidades.Size = New System.Drawing.Size(90, 86)
        Me.BtnUtilidades.Text = "Utilidades"
        Me.BtnUtilidades.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnUtilidades.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnCargarArchivoArticulos
        '
        Me.BtnCargarArchivoArticulos.Name = "BtnCargarArchivoArticulos"
        Me.BtnCargarArchivoArticulos.Size = New System.Drawing.Size(244, 26)
        Me.BtnCargarArchivoArticulos.Text = "Cargar Archivo Artículos"
        '
        'BtnCreacionDeArticulos
        '
        Me.BtnCreacionDeArticulos.Name = "BtnCreacionDeArticulos"
        Me.BtnCreacionDeArticulos.Size = New System.Drawing.Size(244, 26)
        Me.BtnCreacionDeArticulos.Text = "Creación de Artículos"
        '
        'BtnEscaneo
        '
        Me.BtnEscaneo.Name = "BtnEscaneo"
        Me.BtnEscaneo.Size = New System.Drawing.Size(244, 26)
        Me.BtnEscaneo.Text = "Escaneo"
        '
        'StatusBar
        '
        Me.StatusBar.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.TSSNombreEmpresa, Me.ToolStripStatusLabel3, Me.TSSNombreSucursal, Me.TSSClaveTitulo, Me.TSSClave})
        Me.StatusBar.Location = New System.Drawing.Point(0, 806)
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
        'TSSClaveTitulo
        '
        Me.TSSClaveTitulo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSSClaveTitulo.ForeColor = System.Drawing.Color.DarkBlue
        Me.TSSClaveTitulo.Name = "TSSClaveTitulo"
        Me.TSSClaveTitulo.Size = New System.Drawing.Size(54, 20)
        Me.TSSClaveTitulo.Text = "CLAVE"
        '
        'TSSClave
        '
        Me.TSSClave.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSSClave.ForeColor = System.Drawing.Color.DarkBlue
        Me.TSSClave.Name = "TSSClave"
        Me.TSSClave.Size = New System.Drawing.Size(45, 20)
        Me.TSSClave.Text = "0000"
        '
        'PnLineaDetalle
        '
        Me.PnLineaDetalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnLineaDetalle.Controls.Add(Me.TxtCostoActual)
        Me.PnLineaDetalle.Controls.Add(Me.Label21)
        Me.PnLineaDetalle.Controls.Add(Me.TxtPorcUtilidad)
        Me.PnLineaDetalle.Controls.Add(Me.TxtPrecio)
        Me.PnLineaDetalle.Controls.Add(Me.Lbl18)
        Me.PnLineaDetalle.Controls.Add(Me.Label19)
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
        Me.PnLineaDetalle.Location = New System.Drawing.Point(0, 219)
        Me.PnLineaDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.PnLineaDetalle.Name = "PnLineaDetalle"
        Me.PnLineaDetalle.Size = New System.Drawing.Size(1644, 79)
        Me.PnLineaDetalle.TabIndex = 15
        '
        'TxtCostoActual
        '
        Me.TxtCostoActual.Enabled = False
        Me.TxtCostoActual.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCostoActual.ForeColor = System.Drawing.Color.Navy
        Me.TxtCostoActual.Location = New System.Drawing.Point(956, 36)
        Me.TxtCostoActual.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCostoActual.Name = "TxtCostoActual"
        Me.TxtCostoActual.ReadOnly = True
        Me.TxtCostoActual.Size = New System.Drawing.Size(117, 27)
        Me.TxtCostoActual.TabIndex = 28
        Me.TxtCostoActual.Text = "0.00"
        Me.TxtCostoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label21.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(956, 10)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(119, 27)
        Me.Label21.TabIndex = 27
        Me.Label21.Text = "Costo Actual"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtPorcUtilidad
        '
        Me.TxtPorcUtilidad.BackColor = System.Drawing.SystemColors.Window
        Me.TxtPorcUtilidad.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPorcUtilidad.ForeColor = System.Drawing.Color.DarkGreen
        Me.TxtPorcUtilidad.Location = New System.Drawing.Point(876, 36)
        Me.TxtPorcUtilidad.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPorcUtilidad.Name = "TxtPorcUtilidad"
        Me.TxtPorcUtilidad.ReadOnly = True
        Me.TxtPorcUtilidad.Size = New System.Drawing.Size(76, 27)
        Me.TxtPorcUtilidad.TabIndex = 11
        Me.TxtPorcUtilidad.TabStop = False
        Me.TxtPorcUtilidad.Text = "0.00"
        Me.TxtPorcUtilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPrecio
        '
        Me.TxtPrecio.Enabled = False
        Me.TxtPrecio.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrecio.ForeColor = System.Drawing.Color.Navy
        Me.TxtPrecio.Location = New System.Drawing.Point(1227, 36)
        Me.TxtPrecio.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPrecio.Name = "TxtPrecio"
        Me.TxtPrecio.Size = New System.Drawing.Size(117, 27)
        Me.TxtPrecio.TabIndex = 13
        Me.TxtPrecio.Text = "0.00"
        Me.TxtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Lbl18
        '
        Me.Lbl18.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Lbl18.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl18.ForeColor = System.Drawing.Color.White
        Me.Lbl18.Location = New System.Drawing.Point(1227, 10)
        Me.Lbl18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl18.Name = "Lbl18"
        Me.Lbl18.Size = New System.Drawing.Size(119, 27)
        Me.Lbl18.TabIndex = 25
        Me.Lbl18.Text = "Precio"
        Me.Lbl18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label19.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(876, 10)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(77, 27)
        Me.Label19.TabIndex = 26
        Me.Label19.Text = "% Utl"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtFactorConversion
        '
        Me.TxtFactorConversion.BackColor = System.Drawing.SystemColors.Window
        Me.TxtFactorConversion.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFactorConversion.ForeColor = System.Drawing.Color.Maroon
        Me.TxtFactorConversion.Location = New System.Drawing.Point(547, 36)
        Me.TxtFactorConversion.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFactorConversion.Name = "TxtFactorConversion"
        Me.TxtFactorConversion.ReadOnly = True
        Me.TxtFactorConversion.Size = New System.Drawing.Size(56, 27)
        Me.TxtFactorConversion.TabIndex = 7
        Me.TxtFactorConversion.TabStop = False
        Me.TxtFactorConversion.Text = "0"
        Me.TxtFactorConversion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtMaximo
        '
        Me.TxtMaximo.BackColor = System.Drawing.SystemColors.Window
        Me.TxtMaximo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMaximo.ForeColor = System.Drawing.Color.DarkGreen
        Me.TxtMaximo.Location = New System.Drawing.Point(787, 36)
        Me.TxtMaximo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtMaximo.Name = "TxtMaximo"
        Me.TxtMaximo.ReadOnly = True
        Me.TxtMaximo.Size = New System.Drawing.Size(85, 27)
        Me.TxtMaximo.TabIndex = 10
        Me.TxtMaximo.TabStop = False
        Me.TxtMaximo.Text = "0.00"
        Me.TxtMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTransito
        '
        Me.TxtTransito.BackColor = System.Drawing.SystemColors.Window
        Me.TxtTransito.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTransito.ForeColor = System.Drawing.Color.DarkGreen
        Me.TxtTransito.Location = New System.Drawing.Point(696, 36)
        Me.TxtTransito.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTransito.Name = "TxtTransito"
        Me.TxtTransito.ReadOnly = True
        Me.TxtTransito.Size = New System.Drawing.Size(85, 27)
        Me.TxtTransito.TabIndex = 9
        Me.TxtTransito.TabStop = False
        Me.TxtTransito.Text = "0.00"
        Me.TxtTransito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtBonificacion
        '
        Me.TxtBonificacion.Enabled = False
        Me.TxtBonificacion.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBonificacion.ForeColor = System.Drawing.Color.Navy
        Me.TxtBonificacion.Location = New System.Drawing.Point(1524, 36)
        Me.TxtBonificacion.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtBonificacion.MaxLength = 9
        Me.TxtBonificacion.Name = "TxtBonificacion"
        Me.TxtBonificacion.Size = New System.Drawing.Size(89, 27)
        Me.TxtBonificacion.TabIndex = 16
        Me.TxtBonificacion.Text = "0.00"
        Me.TxtBonificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPorcDesc
        '
        Me.TxtPorcDesc.Enabled = False
        Me.TxtPorcDesc.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPorcDesc.ForeColor = System.Drawing.Color.Navy
        Me.TxtPorcDesc.Location = New System.Drawing.Point(1348, 36)
        Me.TxtPorcDesc.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPorcDesc.Name = "TxtPorcDesc"
        Me.TxtPorcDesc.Size = New System.Drawing.Size(76, 27)
        Me.TxtPorcDesc.TabIndex = 14
        Me.TxtPorcDesc.Text = "0.00"
        Me.TxtPorcDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(787, 10)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 28)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Máximo"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(696, 10)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(87, 28)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "Tránsito"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(1524, 10)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 28)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Bonif."
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(1348, 10)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 27)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Desc."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(547, 11)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 27)
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
        Me.LblSubTotal.Location = New System.Drawing.Point(138, 15)
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
        Me.Label17.Location = New System.Drawing.Point(6, 20)
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
        Me.Label18.Location = New System.Drawing.Point(318, 20)
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
        Me.LblDescuento.Location = New System.Drawing.Point(450, 15)
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
        Me.Label20.Location = New System.Drawing.Point(631, 20)
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
        Me.LblImpuestoVenta.Location = New System.Drawing.Point(763, 15)
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
        Me.LblTotalBonificacion.Location = New System.Drawing.Point(1447, 15)
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
        Me.Label23.Location = New System.Drawing.Point(1296, 20)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(103, 18)
        Me.Label23.TabIndex = 74
        Me.Label23.Text = "Bonificación"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnlBotones
        '
        Me.PnlBotones.Controls.Add(Me.ToolStrip1)
        Me.PnlBotones.Controls.Add(Me.PicLogo)
        Me.PnlBotones.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlBotones.Location = New System.Drawing.Point(0, 0)
        Me.PnlBotones.Margin = New System.Windows.Forms.Padding(4)
        Me.PnlBotones.Name = "PnlBotones"
        Me.PnlBotones.Size = New System.Drawing.Size(1644, 89)
        Me.PnlBotones.TabIndex = 77
        '
        'PicLogo
        '
        Me.PicLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.PicLogo.Location = New System.Drawing.Point(1511, 0)
        Me.PicLogo.Margin = New System.Windows.Forms.Padding(4)
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(133, 89)
        Me.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicLogo.TabIndex = 2
        Me.PicLogo.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Lbl_Total_Tit)
        Me.Panel2.Controls.Add(Me.LblTotalBonificacion)
        Me.Panel2.Controls.Add(Me.LblSubTotal)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.LblTotalCosto)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.LblDescuento)
        Me.Panel2.Controls.Add(Me.LblImpuestoVenta)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.PictureBox4)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.PictureBox3)
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Controls.Add(Me.PictureBox5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 747)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1644, 59)
        Me.Panel2.TabIndex = 78
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.Compras.My.Resources.Resources.Total6
        Me.PictureBox4.Location = New System.Drawing.Point(624, 5)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(312, 48)
        Me.PictureBox4.TabIndex = 73
        Me.PictureBox4.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.Compras.My.Resources.Resources.Total6
        Me.PictureBox1.Location = New System.Drawing.Point(-2, 5)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(312, 48)
        Me.PictureBox1.TabIndex = 67
        Me.PictureBox1.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = Global.Compras.My.Resources.Resources.Total6
        Me.PictureBox3.Location = New System.Drawing.Point(311, 5)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(312, 48)
        Me.PictureBox3.TabIndex = 70
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = Global.Compras.My.Resources.Resources.Total5
        Me.PictureBox2.Location = New System.Drawing.Point(938, 5)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(351, 48)
        Me.PictureBox2.TabIndex = 64
        Me.PictureBox2.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Image = Global.Compras.My.Resources.Resources.Total5
        Me.PictureBox5.Location = New System.Drawing.Point(1290, 5)
        Me.PictureBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(351, 48)
        Me.PictureBox5.TabIndex = 76
        Me.PictureBox5.TabStop = False
        '
        'FrmEntradaMercaderia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1644, 831)
        Me.Controls.Add(Me.LvwDetalle)
        Me.Controls.Add(Me.PnLineaDetalle)
        Me.Controls.Add(Me.PnEncabezado)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PnlBotones)
        Me.Controls.Add(Me.StatusBar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEntradaMercaderia"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Entrada de Mercadería"
        Me.PnEncabezado.ResumeLayout(False)
        Me.PnEncabezado.PerformLayout()
        Me.MenuDetalle.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.PnLineaDetalle.ResumeLayout(False)
        Me.PnLineaDetalle.PerformLayout()
        Me.PnlBotones.ResumeLayout(False)
        Me.PnlBotones.PerformLayout()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtOrden As System.Windows.Forms.TextBox
    Friend WithEvents BtnFacturas As System.Windows.Forms.ToolStripButton
    Friend WithEvents TxtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents Lbl18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TxtPorcUtilidad As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents MnuCrearArticuloSuelto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PnlBotones As System.Windows.Forms.Panel
    Friend WithEvents PicLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Label22 As Label
    Friend WithEvents TxtDiasCredito As TextBox
    Friend WithEvents TxtCostoActual As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents ColumnHeader21 As ColumnHeader
    Friend WithEvents MnuConsultar As ToolStripMenuItem
    Friend WithEvents Label24 As Label
    Friend WithEvents TxtComprobante As TextBox
    Friend WithEvents BtnDesaplicarEntrada As ToolStripButton
    Friend WithEvents Label25 As Label
    Friend WithEvents TxtPorcDescuentoGlobal As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnUtilidades As ToolStripDropDownButton
    Friend WithEvents BtnCargarArchivoArticulos As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BtnCreacionDeArticulos As ToolStripMenuItem
    Friend WithEvents TSSClaveTitulo As ToolStripStatusLabel
    Friend WithEvents TSSClave As ToolStripStatusLabel
    Friend WithEvents BtnLotes As ToolStripButton
    Friend WithEvents ColumnHeader22 As ColumnHeader
    Friend WithEvents BtnEscaneo As ToolStripMenuItem
    Friend WithEvents ColumnHeader23 As ColumnHeader
End Class
