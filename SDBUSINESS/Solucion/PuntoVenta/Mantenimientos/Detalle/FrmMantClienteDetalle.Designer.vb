<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMantClienteDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantClienteDetalle))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ChkActivo = New System.Windows.Forms.CheckBox()
        Me.TxtDireccion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtTelefono1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtTelefono2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtApartado = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtPorcDescContado = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtPorcDescCredito = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtLimiteCredito = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtDiasGraciaMora = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TxtPorcMora = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtDiasCredito = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ChkAcumulaPuntos = New System.Windows.Forms.CheckBox()
        Me.CmbPrecio = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ChkFacturaCredito = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtCxCDolares = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtCxCColones = New System.Windows.Forms.TextBox()
        Me.ChkAplicaMora = New System.Windows.Forms.CheckBox()
        Me.GroupCredito = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CmbTipoIdentificacion = New System.Windows.Forms.ComboBox()
        Me.TxtCedula = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.CmbBarrio = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.CmbDistrito = New System.Windows.Forms.ComboBox()
        Me.CmbProvincia = New System.Windows.Forms.ComboBox()
        Me.CmbCanton = New System.Windows.Forms.ComboBox()
        Me.LblCedulaInfo = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtAgregaContacto = New System.Windows.Forms.TextBox()
        Me.LvwAnotaciones = New System.Windows.Forms.ListView()
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BtnAnotacionAgregar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TxtAnotaciones = New System.Windows.Forms.TextBox()
        Me.CmbDocumentoElectronico = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.GroupDocumentoElectronico = New System.Windows.Forms.GroupBox()
        Me.CmbPlantilla = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TxtNombreComercial = New System.Windows.Forms.TextBox()
        Me.CmbVendedor = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtCorreoCotizaciones = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.GroupCredito.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupDocumentoElectronico.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnGuardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(89, 742)
        Me.Panel1.TabIndex = 1
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(7, 102)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(76, 90)
        Me.BtnSalir.TabIndex = 31
        Me.BtnSalir.TabStop = False
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.BackColor = System.Drawing.Color.White
        Me.BtnGuardar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F7
        Me.BtnGuardar.Location = New System.Drawing.Point(7, 5)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(76, 90)
        Me.BtnGuardar.TabIndex = 30
        Me.BtnGuardar.TabStop = False
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnGuardar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(133, 27)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Código"
        '
        'TxtNumero
        '
        Me.TxtNumero.Enabled = False
        Me.TxtNumero.Location = New System.Drawing.Point(277, 23)
        Me.TxtNumero.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(132, 22)
        Me.TxtNumero.TabIndex = 0
        Me.TxtNumero.TabStop = False
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(277, 54)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNombre.MaxLength = 80
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(424, 22)
        Me.TxtNombre.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(133, 58)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nombre"
        '
        'ChkActivo
        '
        Me.ChkActivo.AutoSize = True
        Me.ChkActivo.Checked = True
        Me.ChkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkActivo.Location = New System.Drawing.Point(464, 434)
        Me.ChkActivo.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkActivo.Name = "ChkActivo"
        Me.ChkActivo.Size = New System.Drawing.Size(68, 21)
        Me.ChkActivo.TabIndex = 15
        Me.ChkActivo.Text = "Activo"
        Me.ChkActivo.UseVisualStyleBackColor = True
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(115, 98)
        Me.TxtDireccion.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtDireccion.MaxLength = 200
        Me.TxtDireccion.Multiline = True
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Size = New System.Drawing.Size(431, 101)
        Me.TxtDireccion.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(39, 102)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Dirección"
        '
        'TxtTelefono1
        '
        Me.TxtTelefono1.Location = New System.Drawing.Point(277, 121)
        Me.TxtTelefono1.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTelefono1.MaxLength = 20
        Me.TxtTelefono1.Name = "TxtTelefono1"
        Me.TxtTelefono1.Size = New System.Drawing.Size(132, 22)
        Me.TxtTelefono1.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(133, 124)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Teléfono 1"
        '
        'TxtTelefono2
        '
        Me.TxtTelefono2.Location = New System.Drawing.Point(569, 121)
        Me.TxtTelefono2.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTelefono2.MaxLength = 20
        Me.TxtTelefono2.Name = "TxtTelefono2"
        Me.TxtTelefono2.Size = New System.Drawing.Size(132, 22)
        Me.TxtTelefono2.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(460, 124)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 17)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Teléfono 2"
        '
        'TxtEmail
        '
        Me.TxtEmail.Location = New System.Drawing.Point(277, 250)
        Me.TxtEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtEmail.MaxLength = 100
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(424, 22)
        Me.TxtEmail.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(133, 321)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 17)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Email"
        '
        'TxtApartado
        '
        Me.TxtApartado.Location = New System.Drawing.Point(277, 153)
        Me.TxtApartado.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtApartado.MaxLength = 20
        Me.TxtApartado.Name = "TxtApartado"
        Me.TxtApartado.Size = New System.Drawing.Size(132, 22)
        Me.TxtApartado.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(133, 156)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 17)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Apartado"
        '
        'TxtPorcDescContado
        '
        Me.TxtPorcDescContado.Location = New System.Drawing.Point(277, 402)
        Me.TxtPorcDescContado.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPorcDescContado.MaxLength = 20
        Me.TxtPorcDescContado.Name = "TxtPorcDescContado"
        Me.TxtPorcDescContado.Size = New System.Drawing.Size(132, 22)
        Me.TxtPorcDescContado.TabIndex = 12
        Me.TxtPorcDescContado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(133, 407)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 17)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Desc. Contado"
        '
        'TxtPorcDescCredito
        '
        Me.TxtPorcDescCredito.Location = New System.Drawing.Point(569, 402)
        Me.TxtPorcDescCredito.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPorcDescCredito.MaxLength = 20
        Me.TxtPorcDescCredito.Name = "TxtPorcDescCredito"
        Me.TxtPorcDescCredito.Size = New System.Drawing.Size(132, 22)
        Me.TxtPorcDescCredito.TabIndex = 13
        Me.TxtPorcDescCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(460, 407)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 17)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Desc. Crédito"
        '
        'TxtLimiteCredito
        '
        Me.TxtLimiteCredito.Location = New System.Drawing.Point(192, 112)
        Me.TxtLimiteCredito.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtLimiteCredito.MaxLength = 20
        Me.TxtLimiteCredito.Name = "TxtLimiteCredito"
        Me.TxtLimiteCredito.Size = New System.Drawing.Size(175, 22)
        Me.TxtLimiteCredito.TabIndex = 25
        Me.TxtLimiteCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(52, 117)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 17)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Limite Crédito"
        '
        'TxtDiasGraciaMora
        '
        Me.TxtDiasGraciaMora.Location = New System.Drawing.Point(192, 48)
        Me.TxtDiasGraciaMora.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtDiasGraciaMora.MaxLength = 30
        Me.TxtDiasGraciaMora.Name = "TxtDiasGraciaMora"
        Me.TxtDiasGraciaMora.Size = New System.Drawing.Size(175, 22)
        Me.TxtDiasGraciaMora.TabIndex = 23
        Me.TxtDiasGraciaMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(52, 52)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(118, 17)
        Me.Label17.TabIndex = 14
        Me.Label17.Text = "Días Gracia Mora"
        '
        'TxtPorcMora
        '
        Me.TxtPorcMora.Location = New System.Drawing.Point(192, 80)
        Me.TxtPorcMora.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPorcMora.MaxLength = 30
        Me.TxtPorcMora.Name = "TxtPorcMora"
        Me.TxtPorcMora.Size = New System.Drawing.Size(175, 22)
        Me.TxtPorcMora.TabIndex = 24
        Me.TxtPorcMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(52, 84)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(112, 17)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "Porcentaje Mora"
        '
        'TxtDiasCredito
        '
        Me.TxtDiasCredito.Location = New System.Drawing.Point(192, 16)
        Me.TxtDiasCredito.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtDiasCredito.MaxLength = 30
        Me.TxtDiasCredito.Name = "TxtDiasCredito"
        Me.TxtDiasCredito.Size = New System.Drawing.Size(175, 22)
        Me.TxtDiasCredito.TabIndex = 22
        Me.TxtDiasCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(53, 20)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 17)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "Días Credito"
        '
        'ChkAcumulaPuntos
        '
        Me.ChkAcumulaPuntos.AutoSize = True
        Me.ChkAcumulaPuntos.Checked = True
        Me.ChkAcumulaPuntos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkAcumulaPuntos.Location = New System.Drawing.Point(277, 434)
        Me.ChkAcumulaPuntos.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkAcumulaPuntos.Name = "ChkAcumulaPuntos"
        Me.ChkAcumulaPuntos.Size = New System.Drawing.Size(132, 21)
        Me.ChkAcumulaPuntos.TabIndex = 14
        Me.ChkAcumulaPuntos.Text = "Acumula Puntos"
        Me.ChkAcumulaPuntos.UseVisualStyleBackColor = True
        '
        'CmbPrecio
        '
        Me.CmbPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbPrecio.FormattingEnabled = True
        Me.CmbPrecio.Location = New System.Drawing.Point(569, 153)
        Me.CmbPrecio.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbPrecio.Name = "CmbPrecio"
        Me.CmbPrecio.Size = New System.Drawing.Size(132, 24)
        Me.CmbPrecio.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(460, 156)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 17)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Precio"
        '
        'ChkFacturaCredito
        '
        Me.ChkFacturaCredito.AutoSize = True
        Me.ChkFacturaCredito.Location = New System.Drawing.Point(779, 85)
        Me.ChkFacturaCredito.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkFacturaCredito.Name = "ChkFacturaCredito"
        Me.ChkFacturaCredito.Size = New System.Drawing.Size(127, 21)
        Me.ChkFacturaCredito.TabIndex = 21
        Me.ChkFacturaCredito.Text = "Factura Crédito"
        Me.ChkFacturaCredito.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(53, 180)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 17)
        Me.Label14.TabIndex = 39
        Me.Label14.Text = "CxC Dólares"
        '
        'TxtCxCDolares
        '
        Me.TxtCxCDolares.Location = New System.Drawing.Point(192, 176)
        Me.TxtCxCDolares.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCxCDolares.MaxLength = 39
        Me.TxtCxCDolares.Name = "TxtCxCDolares"
        Me.TxtCxCDolares.Size = New System.Drawing.Size(175, 22)
        Me.TxtCxCDolares.TabIndex = 27
        Me.TxtCxCDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(52, 148)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 17)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "CxC Colones"
        '
        'TxtCxCColones
        '
        Me.TxtCxCColones.Location = New System.Drawing.Point(192, 144)
        Me.TxtCxCColones.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCxCColones.MaxLength = 39
        Me.TxtCxCColones.Name = "TxtCxCColones"
        Me.TxtCxCColones.Size = New System.Drawing.Size(175, 22)
        Me.TxtCxCColones.TabIndex = 26
        Me.TxtCxCColones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ChkAplicaMora
        '
        Me.ChkAplicaMora.AutoSize = True
        Me.ChkAplicaMora.Location = New System.Drawing.Point(57, 215)
        Me.ChkAplicaMora.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkAplicaMora.Name = "ChkAplicaMora"
        Me.ChkAplicaMora.Size = New System.Drawing.Size(109, 21)
        Me.ChkAplicaMora.TabIndex = 28
        Me.ChkAplicaMora.Text = "Aplicar Mora"
        Me.ChkAplicaMora.UseVisualStyleBackColor = True
        '
        'GroupCredito
        '
        Me.GroupCredito.Controls.Add(Me.TxtDiasCredito)
        Me.GroupCredito.Controls.Add(Me.TxtDiasGraciaMora)
        Me.GroupCredito.Controls.Add(Me.TxtCxCColones)
        Me.GroupCredito.Controls.Add(Me.Label14)
        Me.GroupCredito.Controls.Add(Me.Label12)
        Me.GroupCredito.Controls.Add(Me.TxtPorcMora)
        Me.GroupCredito.Controls.Add(Me.Label16)
        Me.GroupCredito.Controls.Add(Me.TxtLimiteCredito)
        Me.GroupCredito.Controls.Add(Me.ChkAplicaMora)
        Me.GroupCredito.Controls.Add(Me.Label15)
        Me.GroupCredito.Controls.Add(Me.Label17)
        Me.GroupCredito.Controls.Add(Me.TxtCxCDolares)
        Me.GroupCredito.Controls.Add(Me.Label11)
        Me.GroupCredito.Enabled = False
        Me.GroupCredito.Location = New System.Drawing.Point(773, 113)
        Me.GroupCredito.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupCredito.Name = "GroupCredito"
        Me.GroupCredito.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupCredito.Size = New System.Drawing.Size(413, 246)
        Me.GroupCredito.TabIndex = 40
        Me.GroupCredito.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(133, 188)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(122, 17)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "Tipo Identificación"
        '
        'CmbTipoIdentificacion
        '
        Me.CmbTipoIdentificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoIdentificacion.FormattingEnabled = True
        Me.CmbTipoIdentificacion.Location = New System.Drawing.Point(277, 185)
        Me.CmbTipoIdentificacion.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbTipoIdentificacion.Name = "CmbTipoIdentificacion"
        Me.CmbTipoIdentificacion.Size = New System.Drawing.Size(132, 24)
        Me.CmbTipoIdentificacion.TabIndex = 7
        '
        'TxtCedula
        '
        Me.TxtCedula.Location = New System.Drawing.Point(277, 218)
        Me.TxtCedula.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCedula.MaxLength = 20
        Me.TxtCedula.Name = "TxtCedula"
        Me.TxtCedula.Size = New System.Drawing.Size(132, 22)
        Me.TxtCedula.TabIndex = 8
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(133, 222)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 17)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "Cédula"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.CmbBarrio)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.CmbDistrito)
        Me.GroupBox1.Controls.Add(Me.CmbProvincia)
        Me.GroupBox1.Controls.Add(Me.CmbCanton)
        Me.GroupBox1.Controls.Add(Me.TxtDireccion)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(137, 518)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(588, 219)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(308, 64)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(46, 17)
        Me.Label19.TabIndex = 59
        Me.Label19.Text = "Barrio"
        '
        'CmbBarrio
        '
        Me.CmbBarrio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBarrio.FormattingEnabled = True
        Me.CmbBarrio.Location = New System.Drawing.Point(371, 60)
        Me.CmbBarrio.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbBarrio.Name = "CmbBarrio"
        Me.CmbBarrio.Size = New System.Drawing.Size(175, 24)
        Me.CmbBarrio.TabIndex = 19
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(39, 27)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(66, 17)
        Me.Label26.TabIndex = 52
        Me.Label26.Text = "Provincia"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(308, 27)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(53, 17)
        Me.Label28.TabIndex = 57
        Me.Label28.Text = "Cantón"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(39, 64)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(52, 17)
        Me.Label27.TabIndex = 56
        Me.Label27.Text = "Distrito"
        '
        'CmbDistrito
        '
        Me.CmbDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbDistrito.FormattingEnabled = True
        Me.CmbDistrito.ItemHeight = 16
        Me.CmbDistrito.Location = New System.Drawing.Point(115, 60)
        Me.CmbDistrito.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbDistrito.Name = "CmbDistrito"
        Me.CmbDistrito.Size = New System.Drawing.Size(175, 24)
        Me.CmbDistrito.TabIndex = 18
        '
        'CmbProvincia
        '
        Me.CmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbProvincia.FormattingEnabled = True
        Me.CmbProvincia.Location = New System.Drawing.Point(115, 23)
        Me.CmbProvincia.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbProvincia.Name = "CmbProvincia"
        Me.CmbProvincia.Size = New System.Drawing.Size(175, 24)
        Me.CmbProvincia.TabIndex = 16
        '
        'CmbCanton
        '
        Me.CmbCanton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCanton.FormattingEnabled = True
        Me.CmbCanton.ItemHeight = 16
        Me.CmbCanton.Location = New System.Drawing.Point(371, 23)
        Me.CmbCanton.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbCanton.Name = "CmbCanton"
        Me.CmbCanton.Size = New System.Drawing.Size(175, 24)
        Me.CmbCanton.TabIndex = 17
        '
        'LblCedulaInfo
        '
        Me.LblCedulaInfo.Location = New System.Drawing.Point(419, 185)
        Me.LblCedulaInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCedulaInfo.Name = "LblCedulaInfo"
        Me.LblCedulaInfo.Size = New System.Drawing.Size(284, 58)
        Me.LblCedulaInfo.TabIndex = 47
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtAgregaContacto)
        Me.GroupBox2.Controls.Add(Me.LvwAnotaciones)
        Me.GroupBox2.Controls.Add(Me.BtnAnotacionAgregar)
        Me.GroupBox2.Location = New System.Drawing.Point(773, 482)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(413, 219)
        Me.GroupBox2.TabIndex = 48
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Contacto Cliente"
        '
        'TxtAgregaContacto
        '
        Me.TxtAgregaContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAgregaContacto.Location = New System.Drawing.Point(8, 32)
        Me.TxtAgregaContacto.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtAgregaContacto.MaxLength = 39
        Me.TxtAgregaContacto.Name = "TxtAgregaContacto"
        Me.TxtAgregaContacto.Size = New System.Drawing.Size(265, 22)
        Me.TxtAgregaContacto.TabIndex = 29
        Me.TxtAgregaContacto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LvwAnotaciones
        '
        Me.LvwAnotaciones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader21})
        Me.LvwAnotaciones.FullRowSelect = True
        Me.LvwAnotaciones.HideSelection = False
        Me.LvwAnotaciones.Location = New System.Drawing.Point(8, 64)
        Me.LvwAnotaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.LvwAnotaciones.Name = "LvwAnotaciones"
        Me.LvwAnotaciones.Size = New System.Drawing.Size(396, 138)
        Me.LvwAnotaciones.TabIndex = 31
        Me.LvwAnotaciones.UseCompatibleStateImageBehavior = False
        Me.LvwAnotaciones.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Nombre"
        Me.ColumnHeader21.Width = 250
        '
        'BtnAnotacionAgregar
        '
        Me.BtnAnotacionAgregar.Location = New System.Drawing.Point(305, 27)
        Me.BtnAnotacionAgregar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAnotacionAgregar.Name = "BtnAnotacionAgregar"
        Me.BtnAnotacionAgregar.Size = New System.Drawing.Size(100, 28)
        Me.BtnAnotacionAgregar.TabIndex = 30
        Me.BtnAnotacionAgregar.Text = "Agregar"
        Me.BtnAnotacionAgregar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PuntoVenta.My.Resources.Resources.user1
        Me.PictureBox1.Location = New System.Drawing.Point(1116, 44)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(71, 62)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 41
        Me.PictureBox1.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(133, 321)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(77, 17)
        Me.Label20.TabIndex = 49
        Me.Label20.Text = "Referencia"
        '
        'txtReferencia
        '
        Me.txtReferencia.Location = New System.Drawing.Point(277, 318)
        Me.txtReferencia.Margin = New System.Windows.Forms.Padding(4)
        Me.txtReferencia.MaxLength = 100
        Me.txtReferencia.Multiline = True
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(424, 45)
        Me.txtReferencia.TabIndex = 10
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(133, 466)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(86, 17)
        Me.Label21.TabIndex = 50
        Me.Label21.Text = "Anotaciones"
        '
        'TxtAnotaciones
        '
        Me.TxtAnotaciones.Location = New System.Drawing.Point(277, 463)
        Me.TxtAnotaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtAnotaciones.MaxLength = 1000
        Me.TxtAnotaciones.Multiline = True
        Me.TxtAnotaciones.Name = "TxtAnotaciones"
        Me.TxtAnotaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtAnotaciones.Size = New System.Drawing.Size(424, 50)
        Me.TxtAnotaciones.TabIndex = 51
        '
        'CmbDocumentoElectronico
        '
        Me.CmbDocumentoElectronico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbDocumentoElectronico.FormattingEnabled = True
        Me.CmbDocumentoElectronico.Location = New System.Drawing.Point(192, 22)
        Me.CmbDocumentoElectronico.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbDocumentoElectronico.Name = "CmbDocumentoElectronico"
        Me.CmbDocumentoElectronico.Size = New System.Drawing.Size(175, 24)
        Me.CmbDocumentoElectronico.TabIndex = 52
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(17, 26)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(154, 17)
        Me.Label22.TabIndex = 53
        Me.Label22.Text = "Documento Electrónico"
        '
        'GroupDocumentoElectronico
        '
        Me.GroupDocumentoElectronico.Controls.Add(Me.CmbPlantilla)
        Me.GroupDocumentoElectronico.Controls.Add(Me.Label29)
        Me.GroupDocumentoElectronico.Controls.Add(Me.CmbDocumentoElectronico)
        Me.GroupDocumentoElectronico.Controls.Add(Me.Label22)
        Me.GroupDocumentoElectronico.Location = New System.Drawing.Point(773, 367)
        Me.GroupDocumentoElectronico.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupDocumentoElectronico.Name = "GroupDocumentoElectronico"
        Me.GroupDocumentoElectronico.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupDocumentoElectronico.Size = New System.Drawing.Size(413, 111)
        Me.GroupDocumentoElectronico.TabIndex = 54
        Me.GroupDocumentoElectronico.TabStop = False
        '
        'CmbPlantilla
        '
        Me.CmbPlantilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbPlantilla.FormattingEnabled = True
        Me.CmbPlantilla.Location = New System.Drawing.Point(192, 62)
        Me.CmbPlantilla.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbPlantilla.Name = "CmbPlantilla"
        Me.CmbPlantilla.Size = New System.Drawing.Size(175, 24)
        Me.CmbPlantilla.TabIndex = 55
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(17, 64)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(104, 17)
        Me.Label29.TabIndex = 54
        Me.Label29.Text = "Plantilla Cliente"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(133, 90)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(124, 17)
        Me.Label23.TabIndex = 56
        Me.Label23.Text = "Nombre Comercial"
        '
        'TxtNombreComercial
        '
        Me.TxtNombreComercial.Location = New System.Drawing.Point(277, 86)
        Me.TxtNombreComercial.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNombreComercial.MaxLength = 80
        Me.TxtNombreComercial.Name = "TxtNombreComercial"
        Me.TxtNombreComercial.Size = New System.Drawing.Size(424, 22)
        Me.TxtNombreComercial.TabIndex = 2
        '
        'CmbVendedor
        '
        Me.CmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbVendedor.FormattingEnabled = True
        Me.CmbVendedor.Location = New System.Drawing.Point(277, 370)
        Me.CmbVendedor.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbVendedor.Name = "CmbVendedor"
        Me.CmbVendedor.Size = New System.Drawing.Size(424, 24)
        Me.CmbVendedor.TabIndex = 11
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(133, 374)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(70, 17)
        Me.Label24.TabIndex = 58
        Me.Label24.Text = "Vendedor"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(133, 253)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(51, 17)
        Me.Label25.TabIndex = 59
        Me.Label25.Text = "Correo"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(133, 282)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(135, 17)
        Me.Label30.TabIndex = 60
        Me.Label30.Text = "Correo Cotizaciones"
        '
        'txtCorreoCotizaciones
        '
        Me.txtCorreoCotizaciones.Location = New System.Drawing.Point(277, 279)
        Me.txtCorreoCotizaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCorreoCotizaciones.Name = "txtCorreoCotizaciones"
        Me.txtCorreoCotizaciones.Size = New System.Drawing.Size(424, 22)
        Me.txtCorreoCotizaciones.TabIndex = 61
        '
        'FrmMantClienteDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtnSalir
        Me.ClientSize = New System.Drawing.Size(1232, 742)
        Me.Controls.Add(Me.txtCorreoCotizaciones)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.CmbVendedor)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.TxtNombreComercial)
        Me.Controls.Add(Me.GroupDocumentoElectronico)
        Me.Controls.Add(Me.TxtAnotaciones)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtReferencia)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LblCedulaInfo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TxtCedula)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.CmbTipoIdentificacion)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.ChkFacturaCredito)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupCredito)
        Me.Controls.Add(Me.ChkAcumulaPuntos)
        Me.Controls.Add(Me.CmbPrecio)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtPorcDescCredito)
        Me.Controls.Add(Me.ChkActivo)
        Me.Controls.Add(Me.TxtNumero)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtPorcDescContado)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtApartado)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtTelefono2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtTelefono1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtEmail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantClienteDetalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMantCategoriaDetalle"
        Me.Panel1.ResumeLayout(False)
        Me.GroupCredito.ResumeLayout(False)
        Me.GroupCredito.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupDocumentoElectronico.ResumeLayout(False)
        Me.GroupDocumentoElectronico.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ChkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtTelefono1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtTelefono2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtApartado As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtPorcDescContado As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtPorcDescCredito As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtLimiteCredito As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtDiasGraciaMora As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtPorcMora As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtDiasCredito As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ChkAplicaMora As System.Windows.Forms.CheckBox
    Friend WithEvents ChkFacturaCredito As System.Windows.Forms.CheckBox
    Friend WithEvents CmbPrecio As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ChkAcumulaPuntos As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtCxCDolares As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtCxCColones As System.Windows.Forms.TextBox
    Friend WithEvents GroupCredito As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As Label
    Friend WithEvents CmbTipoIdentificacion As ComboBox
    Friend WithEvents TxtCedula As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label19 As Label
    Friend WithEvents CmbBarrio As ComboBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents CmbDistrito As ComboBox
    Friend WithEvents CmbProvincia As ComboBox
    Friend WithEvents CmbCanton As ComboBox
    Friend WithEvents LblCedulaInfo As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BtnAnotacionAgregar As Button
    Friend WithEvents LvwAnotaciones As ListView
    Friend WithEvents ColumnHeader21 As ColumnHeader
    Friend WithEvents TxtAgregaContacto As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtReferencia As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents TxtAnotaciones As TextBox
    Friend WithEvents CmbDocumentoElectronico As ComboBox
    Friend WithEvents Label22 As Label
    Friend WithEvents GroupDocumentoElectronico As GroupBox
    Friend WithEvents Label23 As Label
    Friend WithEvents TxtNombreComercial As TextBox
    Friend WithEvents CmbVendedor As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents CmbPlantilla As ComboBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents txtCorreoCotizaciones As TextBox
End Class
