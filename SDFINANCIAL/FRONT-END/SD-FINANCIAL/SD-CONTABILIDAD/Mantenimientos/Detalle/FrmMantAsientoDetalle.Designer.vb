<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantAsientoDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantAsientoDetalle))
        Me.BtnAplicar = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.PnlEncabezado = New System.Windows.Forms.Panel()
        Me.CmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtFecha = New System.Windows.Forms.TextBox()
        Me.CmbMes = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbAnnio = New System.Windows.Forms.ComboBox()
        Me.TxtComentario = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbTipo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnlDetalle = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtCentroCostoNombre = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtCentroCosto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtTipoCambio = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TxtHaber = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TxtDebe = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TxtMoneda = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TxtCuentaNombre = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TxtCuenta = New System.Windows.Forms.MaskedTextBox()
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblDebeDolaresTotal = New System.Windows.Forms.Label()
        Me.LblDebeColonesTotal = New System.Windows.Forms.Label()
        Me.LblHaberColonesTotal = New System.Windows.Forms.Label()
        Me.LblHaberDolaresTotal = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LblDiferenciaColones = New System.Windows.Forms.Label()
        Me.LblDiferenciaDolares = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.LblDiferenciaColonizado = New System.Windows.Forms.Label()
        Me.LblHaberColonizadoTotal = New System.Windows.Forms.Label()
        Me.LblDebeColonizadoTotal = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnReversar = New System.Windows.Forms.Button()
        Me.PnlEncabezado.SuspendLayout()
        Me.PnlDetalle.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnAplicar
        '
        Me.BtnAplicar.BackColor = System.Drawing.Color.White
        Me.BtnAplicar.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_F3
        Me.BtnAplicar.Location = New System.Drawing.Point(10, 87)
        Me.BtnAplicar.Name = "BtnAplicar"
        Me.BtnAplicar.Size = New System.Drawing.Size(57, 73)
        Me.BtnAplicar.TabIndex = 3
        Me.BtnAplicar.Text = "Aplicar"
        Me.BtnAplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAplicar.UseVisualStyleBackColor = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.BackColor = System.Drawing.Color.White
        Me.BtnGuardar.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_F2
        Me.BtnGuardar.Location = New System.Drawing.Point(10, 8)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(57, 73)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnGuardar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(10, 246)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(57, 73)
        Me.BtnSalir.TabIndex = 1
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'PnlEncabezado
        '
        Me.PnlEncabezado.Controls.Add(Me.CmbEstado)
        Me.PnlEncabezado.Controls.Add(Me.Label7)
        Me.PnlEncabezado.Controls.Add(Me.Label6)
        Me.PnlEncabezado.Controls.Add(Me.TxtFecha)
        Me.PnlEncabezado.Controls.Add(Me.CmbMes)
        Me.PnlEncabezado.Controls.Add(Me.Label5)
        Me.PnlEncabezado.Controls.Add(Me.CmbAnnio)
        Me.PnlEncabezado.Controls.Add(Me.TxtComentario)
        Me.PnlEncabezado.Controls.Add(Me.Label3)
        Me.PnlEncabezado.Controls.Add(Me.CmbTipo)
        Me.PnlEncabezado.Controls.Add(Me.Label2)
        Me.PnlEncabezado.Location = New System.Drawing.Point(84, 48)
        Me.PnlEncabezado.Name = "PnlEncabezado"
        Me.PnlEncabezado.Size = New System.Drawing.Size(1234, 60)
        Me.PnlEncabezado.TabIndex = 10
        '
        'CmbEstado
        '
        Me.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEstado.Enabled = False
        Me.CmbEstado.FormattingEnabled = True
        Me.CmbEstado.Location = New System.Drawing.Point(1132, 30)
        Me.CmbEstado.Name = "CmbEstado"
        Me.CmbEstado.Size = New System.Drawing.Size(99, 21)
        Me.CmbEstado.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(1047, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 20)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Estado"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(1047, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 20)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Fecha"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtFecha
        '
        Me.TxtFecha.BackColor = System.Drawing.Color.White
        Me.TxtFecha.Location = New System.Drawing.Point(1132, 8)
        Me.TxtFecha.Name = "TxtFecha"
        Me.TxtFecha.ReadOnly = True
        Me.TxtFecha.Size = New System.Drawing.Size(100, 20)
        Me.TxtFecha.TabIndex = 11
        Me.TxtFecha.TabStop = False
        Me.TxtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmbMes
        '
        Me.CmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMes.FormattingEnabled = True
        Me.CmbMes.Location = New System.Drawing.Point(444, 7)
        Me.CmbMes.Name = "CmbMes"
        Me.CmbMes.Size = New System.Drawing.Size(95, 21)
        Me.CmbMes.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(355, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 20)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Periodo"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbAnnio
        '
        Me.CmbAnnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAnnio.FormattingEnabled = True
        Me.CmbAnnio.Location = New System.Drawing.Point(545, 7)
        Me.CmbAnnio.Name = "CmbAnnio"
        Me.CmbAnnio.Size = New System.Drawing.Size(83, 21)
        Me.CmbAnnio.TabIndex = 7
        '
        'TxtComentario
        '
        Me.TxtComentario.BackColor = System.Drawing.Color.White
        Me.TxtComentario.Location = New System.Drawing.Point(88, 34)
        Me.TxtComentario.MaxLength = 500
        Me.TxtComentario.Name = "TxtComentario"
        Me.TxtComentario.Size = New System.Drawing.Size(540, 20)
        Me.TxtComentario.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(0, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Comentario"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbTipo
        '
        Me.CmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipo.FormattingEnabled = True
        Me.CmbTipo.Location = New System.Drawing.Point(88, 7)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(261, 21)
        Me.CmbTipo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(-1, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tipo"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtNumero
        '
        Me.TxtNumero.BackColor = System.Drawing.Color.White
        Me.TxtNumero.Enabled = False
        Me.TxtNumero.Location = New System.Drawing.Point(173, 24)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(100, 20)
        Me.TxtNumero.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(84, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Asiento"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnlDetalle
        '
        Me.PnlDetalle.Controls.Add(Me.Label14)
        Me.PnlDetalle.Controls.Add(Me.TxtDescripcion)
        Me.PnlDetalle.Controls.Add(Me.Label13)
        Me.PnlDetalle.Controls.Add(Me.TxtReferencia)
        Me.PnlDetalle.Controls.Add(Me.Label12)
        Me.PnlDetalle.Controls.Add(Me.TxtCentroCostoNombre)
        Me.PnlDetalle.Controls.Add(Me.Label8)
        Me.PnlDetalle.Controls.Add(Me.TxtCentroCosto)
        Me.PnlDetalle.Controls.Add(Me.Label4)
        Me.PnlDetalle.Controls.Add(Me.TxtTipoCambio)
        Me.PnlDetalle.Controls.Add(Me.Label24)
        Me.PnlDetalle.Controls.Add(Me.TxtHaber)
        Me.PnlDetalle.Controls.Add(Me.Label23)
        Me.PnlDetalle.Controls.Add(Me.TxtDebe)
        Me.PnlDetalle.Controls.Add(Me.Label22)
        Me.PnlDetalle.Controls.Add(Me.TxtMoneda)
        Me.PnlDetalle.Controls.Add(Me.Label21)
        Me.PnlDetalle.Controls.Add(Me.TxtCuentaNombre)
        Me.PnlDetalle.Controls.Add(Me.Label20)
        Me.PnlDetalle.Controls.Add(Me.TxtCuenta)
        Me.PnlDetalle.Controls.Add(Me.LvwDetalle)
        Me.PnlDetalle.Location = New System.Drawing.Point(84, 114)
        Me.PnlDetalle.Name = "PnlDetalle"
        Me.PnlDetalle.Size = New System.Drawing.Size(1234, 475)
        Me.PnlDetalle.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(721, 3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(223, 19)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "Descripción"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.BackColor = System.Drawing.Color.White
        Me.TxtDescripcion.Location = New System.Drawing.Point(721, 22)
        Me.TxtDescripcion.MaxLength = 50
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(223, 20)
        Me.TxtDescripcion.TabIndex = 20
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SteelBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(634, 3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 19)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Referencia"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtReferencia
        '
        Me.TxtReferencia.BackColor = System.Drawing.Color.White
        Me.TxtReferencia.Location = New System.Drawing.Point(634, 22)
        Me.TxtReferencia.MaxLength = 15
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(81, 20)
        Me.TxtReferencia.TabIndex = 18
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SteelBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(483, 3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(145, 19)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Nombre"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtCentroCostoNombre
        '
        Me.TxtCentroCostoNombre.BackColor = System.Drawing.Color.White
        Me.TxtCentroCostoNombre.Location = New System.Drawing.Point(483, 22)
        Me.TxtCentroCostoNombre.Name = "TxtCentroCostoNombre"
        Me.TxtCentroCostoNombre.ReadOnly = True
        Me.TxtCentroCostoNombre.Size = New System.Drawing.Size(145, 20)
        Me.TxtCentroCostoNombre.TabIndex = 16
        Me.TxtCentroCostoNombre.TabStop = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(444, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 19)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "CC"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCentroCosto
        '
        Me.TxtCentroCosto.BackColor = System.Drawing.Color.White
        Me.TxtCentroCosto.Location = New System.Drawing.Point(444, 22)
        Me.TxtCentroCosto.Name = "TxtCentroCosto"
        Me.TxtCentroCosto.Size = New System.Drawing.Size(33, 20)
        Me.TxtCentroCosto.TabIndex = 14
        Me.TxtCentroCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(979, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 19)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "TC"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtTipoCambio
        '
        Me.TxtTipoCambio.BackColor = System.Drawing.Color.White
        Me.TxtTipoCambio.Location = New System.Drawing.Point(979, 22)
        Me.TxtTipoCambio.Name = "TxtTipoCambio"
        Me.TxtTipoCambio.Size = New System.Drawing.Size(49, 20)
        Me.TxtTipoCambio.TabIndex = 12
        Me.TxtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.SteelBlue
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(1136, 3)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(96, 19)
        Me.Label24.TabIndex = 11
        Me.Label24.Text = "Haber"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtHaber
        '
        Me.TxtHaber.BackColor = System.Drawing.Color.White
        Me.TxtHaber.Location = New System.Drawing.Point(1136, 22)
        Me.TxtHaber.Name = "TxtHaber"
        Me.TxtHaber.Size = New System.Drawing.Size(96, 20)
        Me.TxtHaber.TabIndex = 10
        Me.TxtHaber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.SteelBlue
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(1034, 3)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(96, 19)
        Me.Label23.TabIndex = 9
        Me.Label23.Text = "Debe"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtDebe
        '
        Me.TxtDebe.BackColor = System.Drawing.Color.White
        Me.TxtDebe.Location = New System.Drawing.Point(1034, 22)
        Me.TxtDebe.Name = "TxtDebe"
        Me.TxtDebe.Size = New System.Drawing.Size(96, 20)
        Me.TxtDebe.TabIndex = 8
        Me.TxtDebe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.SteelBlue
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(950, 3)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(23, 19)
        Me.Label22.TabIndex = 7
        Me.Label22.Text = "M"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtMoneda
        '
        Me.TxtMoneda.BackColor = System.Drawing.Color.White
        Me.TxtMoneda.Location = New System.Drawing.Point(950, 22)
        Me.TxtMoneda.Name = "TxtMoneda"
        Me.TxtMoneda.ReadOnly = True
        Me.TxtMoneda.Size = New System.Drawing.Size(23, 20)
        Me.TxtMoneda.TabIndex = 6
        Me.TxtMoneda.TabStop = False
        Me.TxtMoneda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.SteelBlue
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(116, 3)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(322, 19)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "Cuenta"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtCuentaNombre
        '
        Me.TxtCuentaNombre.BackColor = System.Drawing.Color.White
        Me.TxtCuentaNombre.Location = New System.Drawing.Point(116, 22)
        Me.TxtCuentaNombre.Name = "TxtCuentaNombre"
        Me.TxtCuentaNombre.ReadOnly = True
        Me.TxtCuentaNombre.Size = New System.Drawing.Size(322, 20)
        Me.TxtCuentaNombre.TabIndex = 4
        Me.TxtCuentaNombre.TabStop = False
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.SteelBlue
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(0, 3)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(110, 19)
        Me.Label20.TabIndex = 3
        Me.Label20.Text = "Cuenta"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtCuenta
        '
        Me.TxtCuenta.BackColor = System.Drawing.Color.White
        Me.TxtCuenta.Location = New System.Drawing.Point(0, 22)
        Me.TxtCuenta.Mask = "000-000-000-000-000"
        Me.TxtCuenta.Name = "TxtCuenta"
        Me.TxtCuenta.Size = New System.Drawing.Size(110, 20)
        Me.TxtCuenta.TabIndex = 2
        '
        'LvwDetalle
        '
        Me.LvwDetalle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14})
        Me.LvwDetalle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LvwDetalle.FullRowSelect = True
        Me.LvwDetalle.HideSelection = False
        Me.LvwDetalle.Location = New System.Drawing.Point(0, 48)
        Me.LvwDetalle.Name = "LvwDetalle"
        Me.LvwDetalle.Size = New System.Drawing.Size(1234, 427)
        Me.LvwDetalle.TabIndex = 0
        Me.LvwDetalle.UseCompatibleStateImageBehavior = False
        Me.LvwDetalle.View = System.Windows.Forms.View.Details
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(644, 635)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 29)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "₡"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label10.Location = New System.Drawing.Point(646, 668)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(27, 29)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "$"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.SteelBlue
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(681, 601)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(207, 25)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Debe"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblDebeDolaresTotal
        '
        Me.LblDebeDolaresTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblDebeDolaresTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDebeDolaresTotal.ForeColor = System.Drawing.Color.ForestGreen
        Me.LblDebeDolaresTotal.Location = New System.Drawing.Point(681, 670)
        Me.LblDebeDolaresTotal.Name = "LblDebeDolaresTotal"
        Me.LblDebeDolaresTotal.Size = New System.Drawing.Size(207, 25)
        Me.LblDebeDolaresTotal.TabIndex = 15
        Me.LblDebeDolaresTotal.Text = "0.00"
        Me.LblDebeDolaresTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblDebeColonesTotal
        '
        Me.LblDebeColonesTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblDebeColonesTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDebeColonesTotal.ForeColor = System.Drawing.Color.Blue
        Me.LblDebeColonesTotal.Location = New System.Drawing.Point(681, 637)
        Me.LblDebeColonesTotal.Name = "LblDebeColonesTotal"
        Me.LblDebeColonesTotal.Size = New System.Drawing.Size(207, 25)
        Me.LblDebeColonesTotal.TabIndex = 16
        Me.LblDebeColonesTotal.Text = "0.00"
        Me.LblDebeColonesTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblHaberColonesTotal
        '
        Me.LblHaberColonesTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblHaberColonesTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHaberColonesTotal.ForeColor = System.Drawing.Color.Blue
        Me.LblHaberColonesTotal.Location = New System.Drawing.Point(894, 637)
        Me.LblHaberColonesTotal.Name = "LblHaberColonesTotal"
        Me.LblHaberColonesTotal.Size = New System.Drawing.Size(207, 25)
        Me.LblHaberColonesTotal.TabIndex = 21
        Me.LblHaberColonesTotal.Text = "0.00"
        Me.LblHaberColonesTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblHaberDolaresTotal
        '
        Me.LblHaberDolaresTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblHaberDolaresTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHaberDolaresTotal.ForeColor = System.Drawing.Color.ForestGreen
        Me.LblHaberDolaresTotal.Location = New System.Drawing.Point(894, 670)
        Me.LblHaberDolaresTotal.Name = "LblHaberDolaresTotal"
        Me.LblHaberDolaresTotal.Size = New System.Drawing.Size(207, 25)
        Me.LblHaberDolaresTotal.TabIndex = 20
        Me.LblHaberDolaresTotal.Text = "0.00"
        Me.LblHaberDolaresTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.SteelBlue
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(894, 601)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(207, 25)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "Haber"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblDiferenciaColones
        '
        Me.LblDiferenciaColones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblDiferenciaColones.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDiferenciaColones.ForeColor = System.Drawing.Color.Blue
        Me.LblDiferenciaColones.Location = New System.Drawing.Point(1107, 637)
        Me.LblDiferenciaColones.Name = "LblDiferenciaColones"
        Me.LblDiferenciaColones.Size = New System.Drawing.Size(207, 25)
        Me.LblDiferenciaColones.TabIndex = 24
        Me.LblDiferenciaColones.Text = "0.00"
        Me.LblDiferenciaColones.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblDiferenciaDolares
        '
        Me.LblDiferenciaDolares.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblDiferenciaDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDiferenciaDolares.ForeColor = System.Drawing.Color.ForestGreen
        Me.LblDiferenciaDolares.Location = New System.Drawing.Point(1107, 670)
        Me.LblDiferenciaDolares.Name = "LblDiferenciaDolares"
        Me.LblDiferenciaDolares.Size = New System.Drawing.Size(207, 25)
        Me.LblDiferenciaDolares.TabIndex = 23
        Me.LblDiferenciaDolares.Text = "0.00"
        Me.LblDiferenciaDolares.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.SteelBlue
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(1107, 601)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(207, 25)
        Me.Label19.TabIndex = 22
        Me.Label19.Text = "Diferencia"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblDiferenciaColonizado
        '
        Me.LblDiferenciaColonizado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblDiferenciaColonizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDiferenciaColonizado.ForeColor = System.Drawing.Color.Blue
        Me.LblDiferenciaColonizado.Location = New System.Drawing.Point(1107, 704)
        Me.LblDiferenciaColonizado.Name = "LblDiferenciaColonizado"
        Me.LblDiferenciaColonizado.Size = New System.Drawing.Size(207, 25)
        Me.LblDiferenciaColonizado.TabIndex = 28
        Me.LblDiferenciaColonizado.Text = "0.00"
        Me.LblDiferenciaColonizado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblHaberColonizadoTotal
        '
        Me.LblHaberColonizadoTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblHaberColonizadoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHaberColonizadoTotal.ForeColor = System.Drawing.Color.Blue
        Me.LblHaberColonizadoTotal.Location = New System.Drawing.Point(894, 704)
        Me.LblHaberColonizadoTotal.Name = "LblHaberColonizadoTotal"
        Me.LblHaberColonizadoTotal.Size = New System.Drawing.Size(207, 25)
        Me.LblHaberColonizadoTotal.TabIndex = 27
        Me.LblHaberColonizadoTotal.Text = "0.00"
        Me.LblHaberColonizadoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblDebeColonizadoTotal
        '
        Me.LblDebeColonizadoTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblDebeColonizadoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDebeColonizadoTotal.ForeColor = System.Drawing.Color.Blue
        Me.LblDebeColonizadoTotal.Location = New System.Drawing.Point(681, 704)
        Me.LblDebeColonizadoTotal.Name = "LblDebeColonizadoTotal"
        Me.LblDebeColonizadoTotal.Size = New System.Drawing.Size(207, 25)
        Me.LblDebeColonizadoTotal.TabIndex = 26
        Me.LblDebeColonizadoTotal.Text = "0.00"
        Me.LblDebeColonizadoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(644, 701)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(31, 29)
        Me.Label17.TabIndex = 25
        Me.Label17.Text = "₡"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnReversar)
        Me.Panel1.Controls.Add(Me.BtnGuardar)
        Me.Panel1.Controls.Add(Me.BtnAplicar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(78, 744)
        Me.Panel1.TabIndex = 29
        '
        'BtnReversar
        '
        Me.BtnReversar.BackColor = System.Drawing.Color.White
        Me.BtnReversar.Enabled = False
        Me.BtnReversar.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_F4
        Me.BtnReversar.Location = New System.Drawing.Point(10, 167)
        Me.BtnReversar.Name = "BtnReversar"
        Me.BtnReversar.Size = New System.Drawing.Size(57, 73)
        Me.BtnReversar.TabIndex = 4
        Me.BtnReversar.Text = "Reversa"
        Me.BtnReversar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnReversar.UseVisualStyleBackColor = False
        '
        'FrmMantAsientoDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1323, 744)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LblDiferenciaColonizado)
        Me.Controls.Add(Me.LblHaberColonizadoTotal)
        Me.Controls.Add(Me.LblDebeColonizadoTotal)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.LblDiferenciaColones)
        Me.Controls.Add(Me.LblDiferenciaDolares)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.LblHaberColonesTotal)
        Me.Controls.Add(Me.LblHaberDolaresTotal)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.LblDebeColonesTotal)
        Me.Controls.Add(Me.LblDebeDolaresTotal)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PnlDetalle)
        Me.Controls.Add(Me.PnlEncabezado)
        Me.Controls.Add(Me.TxtNumero)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantAsientoDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asientos Contables"
        Me.PnlEncabezado.ResumeLayout(False)
        Me.PnlEncabezado.PerformLayout()
        Me.PnlDetalle.ResumeLayout(False)
        Me.PnlDetalle.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnAplicar As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents PnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtFecha As System.Windows.Forms.TextBox
    Friend WithEvents CmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbAnnio As System.Windows.Forms.ComboBox
    Friend WithEvents TxtComentario As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PnlDetalle As System.Windows.Forms.Panel
    Friend WithEvents LvwDetalle As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LblDebeDolaresTotal As System.Windows.Forms.Label
    Friend WithEvents LblDebeColonesTotal As System.Windows.Forms.Label
    Friend WithEvents LblHaberColonesTotal As System.Windows.Forms.Label
    Friend WithEvents LblHaberDolaresTotal As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents LblDiferenciaColones As System.Windows.Forms.Label
    Friend WithEvents LblDiferenciaDolares As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TxtCuenta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TxtCuentaNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TxtHaber As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TxtDebe As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TxtMoneda As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtCentroCosto As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtCentroCostoNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblDiferenciaColonizado As System.Windows.Forms.Label
    Friend WithEvents LblHaberColonizadoTotal As System.Windows.Forms.Label
    Friend WithEvents LblDebeColonizadoTotal As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnReversar As System.Windows.Forms.Button
End Class
