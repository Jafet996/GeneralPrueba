<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCargaFacturaElectronica
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCargaFacturaElectronica))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TSSLMensaje = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PnlEncabezado = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.LblTotalDocumento = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblConsecutivo = New System.Windows.Forms.Label()
        Me.LblFechaDocumento = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtIdentificacionNumero = New System.Windows.Forms.TextBox()
        Me.LblProveedorInterno = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.RdbNombreComercial = New System.Windows.Forms.RadioButton()
        Me.RdbNombreRazonSocial = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblNombreComercial = New System.Windows.Forms.Label()
        Me.BtnCreaProveedor = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblTelefono = New System.Windows.Forms.Label()
        Me.LblProveedor = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblEmail = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblIdentificacionTipo = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.BtnArticuloCrea = New System.Windows.Forms.Button()
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
        Me.CMSDetalle = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuMarcarTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDesmarcharTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuProductoServicio = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImgLstDetalle = New System.Windows.Forms.ImageList(Me.components)
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.PnlMenu = New System.Windows.Forms.Panel()
        Me.BtnProveedor = New System.Windows.Forms.Button()
        Me.BtnArticulo = New System.Windows.Forms.Button()
        Me.BtnEntrada = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnEmail = New System.Windows.Forms.Button()
        Me.BtnArchivo = New System.Windows.Forms.Button()
        Me.PicProveedor = New System.Windows.Forms.PictureBox()
        Me.BtnFacturarCR = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        Me.PnlEncabezado.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.CMSDetalle.SuspendLayout()
        Me.PnlMenu.SuspendLayout()
        CType(Me.PicProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSSLMensaje})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 809)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1644, 22)
        Me.StatusStrip1.TabIndex = 79
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TSSLMensaje
        '
        Me.TSSLMensaje.Name = "TSSLMensaje"
        Me.TSSLMensaje.Size = New System.Drawing.Size(0, 17)
        '
        'PnlEncabezado
        '
        Me.PnlEncabezado.Controls.Add(Me.Panel3)
        Me.PnlEncabezado.Controls.Add(Me.Panel1)
        Me.PnlEncabezado.Controls.Add(Me.Panel4)
        Me.PnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlEncabezado.Location = New System.Drawing.Point(0, 100)
        Me.PnlEncabezado.Name = "PnlEncabezado"
        Me.PnlEncabezado.Size = New System.Drawing.Size(1644, 232)
        Me.PnlEncabezado.TabIndex = 80
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.LblClave)
        Me.Panel3.Controls.Add(Me.LblTotalDocumento)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.LblConsecutivo)
        Me.Panel3.Controls.Add(Me.LblFechaDocumento)
        Me.Panel3.Location = New System.Drawing.Point(901, 6)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(732, 164)
        Me.Panel3.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.Location = New System.Drawing.Point(16, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 20)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Clave"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.Location = New System.Drawing.Point(442, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 20)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Total"
        '
        'LblClave
        '
        Me.LblClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClave.ForeColor = System.Drawing.Color.MediumBlue
        Me.LblClave.Location = New System.Drawing.Point(144, 84)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(565, 20)
        Me.LblClave.TabIndex = 9
        Me.LblClave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTotalDocumento
        '
        Me.LblTotalDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalDocumento.ForeColor = System.Drawing.Color.MediumBlue
        Me.LblTotalDocumento.Location = New System.Drawing.Point(499, 17)
        Me.LblTotalDocumento.Name = "LblTotalDocumento"
        Me.LblTotalDocumento.Size = New System.Drawing.Size(210, 20)
        Me.LblTotalDocumento.TabIndex = 9
        Me.LblTotalDocumento.Text = "1800.00"
        Me.LblTotalDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(16, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Consecutivo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.Location = New System.Drawing.Point(16, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 20)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Fecha"
        '
        'LblConsecutivo
        '
        Me.LblConsecutivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblConsecutivo.ForeColor = System.Drawing.Color.MediumBlue
        Me.LblConsecutivo.Location = New System.Drawing.Point(503, 50)
        Me.LblConsecutivo.Name = "LblConsecutivo"
        Me.LblConsecutivo.Size = New System.Drawing.Size(206, 20)
        Me.LblConsecutivo.TabIndex = 7
        Me.LblConsecutivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblFechaDocumento
        '
        Me.LblFechaDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFechaDocumento.ForeColor = System.Drawing.Color.MediumBlue
        Me.LblFechaDocumento.Location = New System.Drawing.Point(144, 17)
        Me.LblFechaDocumento.Name = "LblFechaDocumento"
        Me.LblFechaDocumento.Size = New System.Drawing.Size(170, 20)
        Me.LblFechaDocumento.TabIndex = 7
        Me.LblFechaDocumento.Text = "27/04/2011 11:34"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TxtIdentificacionNumero)
        Me.Panel1.Controls.Add(Me.LblProveedorInterno)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.RdbNombreComercial)
        Me.Panel1.Controls.Add(Me.RdbNombreRazonSocial)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.LblNombreComercial)
        Me.Panel1.Controls.Add(Me.PicProveedor)
        Me.Panel1.Controls.Add(Me.BtnCreaProveedor)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.LblTelefono)
        Me.Panel1.Controls.Add(Me.LblProveedor)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.LblEmail)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.LblIdentificacionTipo)
        Me.Panel1.Location = New System.Drawing.Point(12, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(883, 213)
        Me.Panel1.TabIndex = 10
        '
        'TxtIdentificacionNumero
        '
        Me.TxtIdentificacionNumero.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIdentificacionNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIdentificacionNumero.ForeColor = System.Drawing.Color.Purple
        Me.TxtIdentificacionNumero.Location = New System.Drawing.Point(164, 120)
        Me.TxtIdentificacionNumero.Name = "TxtIdentificacionNumero"
        Me.TxtIdentificacionNumero.Size = New System.Drawing.Size(191, 20)
        Me.TxtIdentificacionNumero.TabIndex = 17
        Me.TxtIdentificacionNumero.TabStop = False
        Me.TxtIdentificacionNumero.Text = "000000000"
        '
        'LblProveedorInterno
        '
        Me.LblProveedorInterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProveedorInterno.ForeColor = System.Drawing.Color.Purple
        Me.LblProveedorInterno.Location = New System.Drawing.Point(160, 155)
        Me.LblProveedorInterno.Name = "LblProveedorInterno"
        Me.LblProveedorInterno.Size = New System.Drawing.Size(586, 20)
        Me.LblProveedorInterno.TabIndex = 16
        Me.LblProveedorInterno.Text = "Proveedor Interno"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.Location = New System.Drawing.Point(10, 155)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 20)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Interno"
        '
        'RdbNombreComercial
        '
        Me.RdbNombreComercial.AutoSize = True
        Me.RdbNombreComercial.Location = New System.Drawing.Point(137, 53)
        Me.RdbNombreComercial.Name = "RdbNombreComercial"
        Me.RdbNombreComercial.Size = New System.Drawing.Size(17, 16)
        Me.RdbNombreComercial.TabIndex = 14
        Me.RdbNombreComercial.UseVisualStyleBackColor = True
        '
        'RdbNombreRazonSocial
        '
        Me.RdbNombreRazonSocial.AutoSize = True
        Me.RdbNombreRazonSocial.Checked = True
        Me.RdbNombreRazonSocial.Location = New System.Drawing.Point(137, 19)
        Me.RdbNombreRazonSocial.Name = "RdbNombreRazonSocial"
        Me.RdbNombreRazonSocial.Size = New System.Drawing.Size(17, 16)
        Me.RdbNombreRazonSocial.TabIndex = 13
        Me.RdbNombreRazonSocial.TabStop = True
        Me.RdbNombreRazonSocial.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.Location = New System.Drawing.Point(10, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 20)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Comercial"
        '
        'LblNombreComercial
        '
        Me.LblNombreComercial.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombreComercial.ForeColor = System.Drawing.Color.Purple
        Me.LblNombreComercial.Location = New System.Drawing.Point(160, 50)
        Me.LblNombreComercial.Name = "LblNombreComercial"
        Me.LblNombreComercial.Size = New System.Drawing.Size(586, 20)
        Me.LblNombreComercial.TabIndex = 12
        Me.LblNombreComercial.Text = "Proveedor"
        '
        'BtnCreaProveedor
        '
        Me.BtnCreaProveedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCreaProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCreaProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCreaProveedor.ForeColor = System.Drawing.Color.DarkGreen
        Me.BtnCreaProveedor.Location = New System.Drawing.Point(778, 12)
        Me.BtnCreaProveedor.Name = "BtnCreaProveedor"
        Me.BtnCreaProveedor.Size = New System.Drawing.Size(86, 31)
        Me.BtnCreaProveedor.TabIndex = 3
        Me.BtnCreaProveedor.Text = "Crear"
        Me.BtnCreaProveedor.UseVisualStyleBackColor = True
        Me.BtnCreaProveedor.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(10, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Proveedor"
        '
        'LblTelefono
        '
        Me.LblTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTelefono.ForeColor = System.Drawing.Color.Purple
        Me.LblTelefono.Location = New System.Drawing.Point(483, 84)
        Me.LblTelefono.Name = "LblTelefono"
        Me.LblTelefono.Size = New System.Drawing.Size(180, 20)
        Me.LblTelefono.TabIndex = 9
        Me.LblTelefono.Text = "86511599"
        '
        'LblProveedor
        '
        Me.LblProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProveedor.ForeColor = System.Drawing.Color.Purple
        Me.LblProveedor.Location = New System.Drawing.Point(160, 17)
        Me.LblProveedor.Name = "LblProveedor"
        Me.LblProveedor.Size = New System.Drawing.Size(551, 20)
        Me.LblProveedor.TabIndex = 1
        Me.LblProveedor.Text = "Proveedor"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.Location = New System.Drawing.Point(362, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 20)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Teléfono"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(10, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Identificación"
        '
        'LblEmail
        '
        Me.LblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmail.ForeColor = System.Drawing.Color.Purple
        Me.LblEmail.Location = New System.Drawing.Point(483, 115)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(381, 31)
        Me.LblEmail.TabIndex = 7
        Me.LblEmail.Text = "jimmy.trejos@gmail.com"
        Me.LblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.Location = New System.Drawing.Point(362, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Email"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.Location = New System.Drawing.Point(10, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Tipo"
        '
        'LblIdentificacionTipo
        '
        Me.LblIdentificacionTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIdentificacionTipo.ForeColor = System.Drawing.Color.Purple
        Me.LblIdentificacionTipo.Location = New System.Drawing.Point(160, 84)
        Me.LblIdentificacionTipo.Name = "LblIdentificacionTipo"
        Me.LblIdentificacionTipo.Size = New System.Drawing.Size(195, 20)
        Me.LblIdentificacionTipo.TabIndex = 5
        Me.LblIdentificacionTipo.Text = "0000000"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.BtnArticuloCrea)
        Me.Panel4.Location = New System.Drawing.Point(901, 176)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(732, 43)
        Me.Panel4.TabIndex = 13
        '
        'BtnArticuloCrea
        '
        Me.BtnArticuloCrea.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnArticuloCrea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnArticuloCrea.ForeColor = System.Drawing.Color.White
        Me.BtnArticuloCrea.Location = New System.Drawing.Point(592, 3)
        Me.BtnArticuloCrea.Name = "BtnArticuloCrea"
        Me.BtnArticuloCrea.Size = New System.Drawing.Size(135, 33)
        Me.BtnArticuloCrea.TabIndex = 0
        Me.BtnArticuloCrea.Text = "Crear Atículos"
        Me.BtnArticuloCrea.UseVisualStyleBackColor = False
        '
        'LvwDetalle
        '
        Me.LvwDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LvwDetalle.CheckBoxes = True
        Me.LvwDetalle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14})
        Me.LvwDetalle.ContextMenuStrip = Me.CMSDetalle
        Me.LvwDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvwDetalle.FullRowSelect = True
        Me.LvwDetalle.HideSelection = False
        Me.LvwDetalle.Location = New System.Drawing.Point(0, 332)
        Me.LvwDetalle.Name = "LvwDetalle"
        Me.LvwDetalle.Size = New System.Drawing.Size(1644, 477)
        Me.LvwDetalle.SmallImageList = Me.ImgLstDetalle
        Me.LvwDetalle.TabIndex = 82
        Me.LvwDetalle.UseCompatibleStateImageBehavior = False
        Me.LvwDetalle.View = System.Windows.Forms.View.Details
        '
        'CMSDetalle
        '
        Me.CMSDetalle.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CMSDetalle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMarcarTodos, Me.MnuDesmarcharTodos, Me.MnuProductoServicio})
        Me.CMSDetalle.Name = "CMSDetalle"
        Me.CMSDetalle.Size = New System.Drawing.Size(220, 76)
        '
        'MnuMarcarTodos
        '
        Me.MnuMarcarTodos.Name = "MnuMarcarTodos"
        Me.MnuMarcarTodos.Size = New System.Drawing.Size(219, 24)
        Me.MnuMarcarTodos.Text = "Marcar Todos"
        '
        'MnuDesmarcharTodos
        '
        Me.MnuDesmarcharTodos.Name = "MnuDesmarcharTodos"
        Me.MnuDesmarcharTodos.Size = New System.Drawing.Size(219, 24)
        Me.MnuDesmarcharTodos.Text = "Desmarcar Todos"
        '
        'MnuProductoServicio
        '
        Me.MnuProductoServicio.Name = "MnuProductoServicio"
        Me.MnuProductoServicio.Size = New System.Drawing.Size(219, 24)
        Me.MnuProductoServicio.Text = "Producto Equivalente"
        '
        'ImgLstDetalle
        '
        Me.ImgLstDetalle.ImageStream = CType(resources.GetObject("ImgLstDetalle.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgLstDetalle.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgLstDetalle.Images.SetKeyName(0, "check.ico")
        Me.ImgLstDetalle.Images.SetKeyName(1, "delete.ico")
        '
        'OFD
        '
        Me.OFD.FileName = "OpenFileDialog1"
        '
        'PnlMenu
        '
        Me.PnlMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.PnlMenu.Controls.Add(Me.BtnFacturarCR)
        Me.PnlMenu.Controls.Add(Me.BtnProveedor)
        Me.PnlMenu.Controls.Add(Me.BtnArticulo)
        Me.PnlMenu.Controls.Add(Me.BtnEntrada)
        Me.PnlMenu.Controls.Add(Me.BtnSalir)
        Me.PnlMenu.Controls.Add(Me.BtnEmail)
        Me.PnlMenu.Controls.Add(Me.BtnArchivo)
        Me.PnlMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlMenu.Location = New System.Drawing.Point(0, 0)
        Me.PnlMenu.Name = "PnlMenu"
        Me.PnlMenu.Size = New System.Drawing.Size(1644, 100)
        Me.PnlMenu.TabIndex = 83
        '
        'BtnProveedor
        '
        Me.BtnProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProveedor.ForeColor = System.Drawing.Color.White
        Me.BtnProveedor.Location = New System.Drawing.Point(662, 12)
        Me.BtnProveedor.Name = "BtnProveedor"
        Me.BtnProveedor.Size = New System.Drawing.Size(124, 73)
        Me.BtnProveedor.TabIndex = 5
        Me.BtnProveedor.Text = "Prov"
        Me.BtnProveedor.UseVisualStyleBackColor = True
        '
        'BtnArticulo
        '
        Me.BtnArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnArticulo.ForeColor = System.Drawing.Color.White
        Me.BtnArticulo.Location = New System.Drawing.Point(532, 12)
        Me.BtnArticulo.Name = "BtnArticulo"
        Me.BtnArticulo.Size = New System.Drawing.Size(124, 73)
        Me.BtnArticulo.TabIndex = 4
        Me.BtnArticulo.Text = "Artículo"
        Me.BtnArticulo.UseVisualStyleBackColor = True
        '
        'BtnEntrada
        '
        Me.BtnEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEntrada.ForeColor = System.Drawing.Color.White
        Me.BtnEntrada.Location = New System.Drawing.Point(402, 12)
        Me.BtnEntrada.Name = "BtnEntrada"
        Me.BtnEntrada.Size = New System.Drawing.Size(124, 73)
        Me.BtnEntrada.TabIndex = 3
        Me.BtnEntrada.Text = "Entrada"
        Me.BtnEntrada.UseVisualStyleBackColor = True
        '
        'BtnSalir
        '
        Me.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.ForeColor = System.Drawing.Color.White
        Me.BtnSalir.Location = New System.Drawing.Point(791, 12)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(124, 73)
        Me.BtnSalir.TabIndex = 2
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'BtnEmail
        '
        Me.BtnEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEmail.ForeColor = System.Drawing.Color.White
        Me.BtnEmail.Location = New System.Drawing.Point(142, 12)
        Me.BtnEmail.Name = "BtnEmail"
        Me.BtnEmail.Size = New System.Drawing.Size(124, 73)
        Me.BtnEmail.TabIndex = 1
        Me.BtnEmail.Text = "Email"
        Me.BtnEmail.UseVisualStyleBackColor = True
        '
        'BtnArchivo
        '
        Me.BtnArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnArchivo.ForeColor = System.Drawing.Color.White
        Me.BtnArchivo.Location = New System.Drawing.Point(12, 12)
        Me.BtnArchivo.Name = "BtnArchivo"
        Me.BtnArchivo.Size = New System.Drawing.Size(124, 73)
        Me.BtnArchivo.TabIndex = 0
        Me.BtnArchivo.Text = "Archivo"
        Me.BtnArchivo.UseVisualStyleBackColor = True
        '
        'PicProveedor
        '
        Me.PicProveedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicProveedor.Image = Global.Compras.My.Resources.Resources.check
        Me.PicProveedor.Location = New System.Drawing.Point(738, 11)
        Me.PicProveedor.Name = "PicProveedor"
        Me.PicProveedor.Size = New System.Drawing.Size(34, 33)
        Me.PicProveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicProveedor.TabIndex = 10
        Me.PicProveedor.TabStop = False
        Me.PicProveedor.Visible = False
        '
        'BtnFacturarCR
        '
        Me.BtnFacturarCR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFacturarCR.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFacturarCR.ForeColor = System.Drawing.Color.White
        Me.BtnFacturarCR.Location = New System.Drawing.Point(272, 12)
        Me.BtnFacturarCR.Name = "BtnFacturarCR"
        Me.BtnFacturarCR.Size = New System.Drawing.Size(124, 73)
        Me.BtnFacturarCR.TabIndex = 6
        Me.BtnFacturarCR.Text = "FacturarCR"
        Me.BtnFacturarCR.UseVisualStyleBackColor = True
        '
        'FrmCargaFacturaElectronica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1644, 831)
        Me.Controls.Add(Me.LvwDetalle)
        Me.Controls.Add(Me.PnlEncabezado)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.PnlMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCargaFacturaElectronica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carga Factura Electrónica"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.PnlEncabezado.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.CMSDetalle.ResumeLayout(False)
        Me.PnlMenu.ResumeLayout(False)
        CType(Me.PicProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents PnlEncabezado As Panel
    Friend WithEvents LvwDetalle As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents OFD As OpenFileDialog
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ImgLstDetalle As ImageList
    Friend WithEvents PnlMenu As Panel
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnEmail As Button
    Friend WithEvents BtnArchivo As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents LblProveedor As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LblIdentificacionTipo As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LblTelefono As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LblEmail As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents LblClave As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LblConsecutivo As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents LblTotalDocumento As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents LblFechaDocumento As Label
    Friend WithEvents BtnCreaProveedor As Button
    Friend WithEvents PicProveedor As PictureBox
    Friend WithEvents TSSLMensaje As ToolStripStatusLabel
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents Label6 As Label
    Friend WithEvents LblNombreComercial As Label
    Friend WithEvents RdbNombreComercial As RadioButton
    Friend WithEvents RdbNombreRazonSocial As RadioButton
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents Panel4 As Panel
    Friend WithEvents BtnArticuloCrea As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents LblProveedorInterno As Label
    Friend WithEvents CMSDetalle As ContextMenuStrip
    Friend WithEvents MnuMarcarTodos As ToolStripMenuItem
    Friend WithEvents MnuDesmarcharTodos As ToolStripMenuItem
    Friend WithEvents MnuProductoServicio As ToolStripMenuItem
    Friend WithEvents BtnEntrada As Button
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents BtnArticulo As Button
    Friend WithEvents BtnProveedor As Button
    Friend WithEvents TxtIdentificacionNumero As TextBox
    Friend WithEvents BtnFacturarCR As Button
End Class
