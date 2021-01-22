Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmArticuloBodega
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmArticuloBodega))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblSucursal = New System.Windows.Forms.Label()
        Me.CmbSucursal = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GbPrecioMayoreo = New System.Windows.Forms.GroupBox()
        Me.ChkAplicaMayorista = New System.Windows.Forms.CheckBox()
        Me.TxtMargenMayorista = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtPrecioVentaMayorista = New System.Windows.Forms.TextBox()
        Me.TxtPrecioMayorista = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtPrecio = New System.Windows.Forms.TextBox()
        Me.TxtCosto = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtMargen = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtPrecioVenta = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.GroupGeneral = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtUbicacion = New System.Windows.Forms.TextBox()
        Me.Máximo = New System.Windows.Forms.Label()
        Me.TxtMaximo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtMinimo = New System.Windows.Forms.TextBox()
        Me.ChkActivo = New System.Windows.Forms.CheckBox()
        Me.GroupDescuento = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DtpDescuentoIni = New System.Windows.Forms.DateTimePicker()
        Me.DtpDescuentoFin = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtPorcDescuento = New System.Windows.Forms.TextBox()
        Me.LblNombreArticulo = New System.Windows.Forms.Label()
        Me.GroupSucursal = New System.Windows.Forms.GroupBox()
        Me.ChkTodas = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblExento = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GbPrecioDetallista = New System.Windows.Forms.GroupBox()
        Me.ChkAplicaPrecio = New System.Windows.Forms.CheckBox()
        Me.GroupCosto = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.LvwAnotaciones = New System.Windows.Forms.ListView()
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BtnAnotacionEliminar = New System.Windows.Forms.Button()
        Me.BtnAnotacionAgregar = New System.Windows.Forms.Button()
        Me.GbPrecio3 = New System.Windows.Forms.GroupBox()
        Me.ChkAplicaPrecio3 = New System.Windows.Forms.CheckBox()
        Me.TxtMargen3 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TxtPrecioVenta3 = New System.Windows.Forms.TextBox()
        Me.TxtPrecio3 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GbPrecio4 = New System.Windows.Forms.GroupBox()
        Me.ChkAplicaPrecio4 = New System.Windows.Forms.CheckBox()
        Me.TxtMargen4 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TxtPrecioVenta4 = New System.Windows.Forms.TextBox()
        Me.TxtPrecio4 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GbPrecio5 = New System.Windows.Forms.GroupBox()
        Me.ChkAplicaPrecio5 = New System.Windows.Forms.CheckBox()
        Me.TxtMargen5 = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TxtPrecioVenta5 = New System.Windows.Forms.TextBox()
        Me.TxtPrecio5 = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.BtnAplicarPrecio = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.GbPrecioMayoreo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupGeneral.SuspendLayout()
        Me.GroupDescuento.SuspendLayout()
        Me.GroupSucursal.SuspendLayout()
        Me.GbPrecioDetallista.SuspendLayout()
        Me.GroupCosto.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GbPrecio3.SuspendLayout()
        Me.GbPrecio4.SuspendLayout()
        Me.GbPrecio5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(129, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sucursal"
        '
        'LblSucursal
        '
        Me.LblSucursal.BackColor = System.Drawing.Color.White
        Me.LblSucursal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblSucursal.Location = New System.Drawing.Point(211, 15)
        Me.LblSucursal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSucursal.Name = "LblSucursal"
        Me.LblSucursal.Size = New System.Drawing.Size(712, 26)
        Me.LblSucursal.TabIndex = 1
        Me.LblSucursal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbSucursal
        '
        Me.CmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSucursal.FormattingEnabled = True
        Me.CmbSucursal.Location = New System.Drawing.Point(85, 27)
        Me.CmbSucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(423, 24)
        Me.CmbSucursal.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 32)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Sucursal"
        '
        'GbPrecioMayoreo
        '
        Me.GbPrecioMayoreo.Controls.Add(Me.ChkAplicaMayorista)
        Me.GbPrecioMayoreo.Controls.Add(Me.TxtMargenMayorista)
        Me.GbPrecioMayoreo.Controls.Add(Me.Label15)
        Me.GbPrecioMayoreo.Controls.Add(Me.TxtPrecioVentaMayorista)
        Me.GbPrecioMayoreo.Controls.Add(Me.TxtPrecioMayorista)
        Me.GbPrecioMayoreo.Controls.Add(Me.Label16)
        Me.GbPrecioMayoreo.Controls.Add(Me.Label17)
        Me.GbPrecioMayoreo.Enabled = False
        Me.GbPrecioMayoreo.Location = New System.Drawing.Point(397, 240)
        Me.GbPrecioMayoreo.Margin = New System.Windows.Forms.Padding(4)
        Me.GbPrecioMayoreo.Name = "GbPrecioMayoreo"
        Me.GbPrecioMayoreo.Padding = New System.Windows.Forms.Padding(4)
        Me.GbPrecioMayoreo.Size = New System.Drawing.Size(259, 159)
        Me.GbPrecioMayoreo.TabIndex = 26
        Me.GbPrecioMayoreo.TabStop = False
        Me.GbPrecioMayoreo.Text = "Precio Mayoreo 1"
        '
        'ChkAplicaMayorista
        '
        Me.ChkAplicaMayorista.AutoSize = True
        Me.ChkAplicaMayorista.Location = New System.Drawing.Point(21, 130)
        Me.ChkAplicaMayorista.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkAplicaMayorista.Name = "ChkAplicaMayorista"
        Me.ChkAplicaMayorista.Size = New System.Drawing.Size(182, 21)
        Me.ChkAplicaMayorista.TabIndex = 29
        Me.ChkAplicaMayorista.Text = "Aplica Precio Prefactura"
        Me.ChkAplicaMayorista.UseVisualStyleBackColor = True
        '
        'TxtMargenMayorista
        '
        Me.TxtMargenMayorista.Location = New System.Drawing.Point(116, 34)
        Me.TxtMargenMayorista.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtMargenMayorista.Name = "TxtMargenMayorista"
        Me.TxtMargenMayorista.Size = New System.Drawing.Size(112, 22)
        Me.TxtMargenMayorista.TabIndex = 24
        Me.TxtMargenMayorista.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(17, 71)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 17)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "Precio"
        '
        'TxtPrecioVentaMayorista
        '
        Me.TxtPrecioVentaMayorista.Location = New System.Drawing.Point(116, 100)
        Me.TxtPrecioVentaMayorista.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPrecioVentaMayorista.Name = "TxtPrecioVentaMayorista"
        Me.TxtPrecioVentaMayorista.Size = New System.Drawing.Size(113, 22)
        Me.TxtPrecioVentaMayorista.TabIndex = 26
        Me.TxtPrecioVentaMayorista.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPrecioMayorista
        '
        Me.TxtPrecioMayorista.BackColor = System.Drawing.Color.White
        Me.TxtPrecioMayorista.Location = New System.Drawing.Point(115, 68)
        Me.TxtPrecioMayorista.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPrecioMayorista.Name = "TxtPrecioMayorista"
        Me.TxtPrecioMayorista.ReadOnly = True
        Me.TxtPrecioMayorista.Size = New System.Drawing.Size(113, 22)
        Me.TxtPrecioMayorista.TabIndex = 28
        Me.TxtPrecioMayorista.TabStop = False
        Me.TxtPrecioMayorista.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(17, 103)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(89, 17)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Precio Venta"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(17, 38)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 17)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "Margen"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 66)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 17)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Precio"
        '
        'TxtPrecio
        '
        Me.TxtPrecio.BackColor = System.Drawing.Color.White
        Me.TxtPrecio.Location = New System.Drawing.Point(115, 63)
        Me.TxtPrecio.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPrecio.Name = "TxtPrecio"
        Me.TxtPrecio.ReadOnly = True
        Me.TxtPrecio.Size = New System.Drawing.Size(113, 22)
        Me.TxtPrecio.TabIndex = 22
        Me.TxtPrecio.TabStop = False
        Me.TxtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtCosto
        '
        Me.TxtCosto.Location = New System.Drawing.Point(116, 20)
        Me.TxtCosto.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCosto.Name = "TxtCosto"
        Me.TxtCosto.ReadOnly = True
        Me.TxtCosto.Size = New System.Drawing.Size(113, 22)
        Me.TxtCosto.TabIndex = 15
        Me.TxtCosto.TabStop = False
        Me.TxtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(27, 23)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 17)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Costo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 33)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 17)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Margen"
        '
        'TxtMargen
        '
        Me.TxtMargen.Location = New System.Drawing.Point(116, 30)
        Me.TxtMargen.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtMargen.Name = "TxtMargen"
        Me.TxtMargen.Size = New System.Drawing.Size(112, 22)
        Me.TxtMargen.TabIndex = 17
        Me.TxtMargen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 98)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 17)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Precio Venta"
        '
        'TxtPrecioVenta
        '
        Me.TxtPrecioVenta.Location = New System.Drawing.Point(116, 95)
        Me.TxtPrecioVenta.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPrecioVenta.Name = "TxtPrecioVenta"
        Me.TxtPrecioVenta.Size = New System.Drawing.Size(113, 22)
        Me.TxtPrecioVenta.TabIndex = 19
        Me.TxtPrecioVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnLimpiar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnGuardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(113, 852)
        Me.Panel1.TabIndex = 27
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.BackColor = System.Drawing.Color.White
        Me.BtnLimpiar.Image = Global.Business.My.Resources.Resources.Blue_F4
        Me.BtnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnLimpiar.Location = New System.Drawing.Point(16, 112)
        Me.BtnLimpiar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(85, 89)
        Me.BtnLimpiar.TabIndex = 2
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnLimpiar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Business.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnSalir.Location = New System.Drawing.Point(16, 210)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(85, 89)
        Me.BtnSalir.TabIndex = 1
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.BackColor = System.Drawing.Color.White
        Me.BtnGuardar.Image = Global.Business.My.Resources.Resources.Blue_F3
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnGuardar.Location = New System.Drawing.Point(16, 16)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(85, 89)
        Me.BtnGuardar.TabIndex = 0
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnGuardar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(129, 53)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 17)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Código"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Location = New System.Drawing.Point(211, 49)
        Me.TxtCodigo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigo.MaxLength = 13
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(160, 22)
        Me.TxtCodigo.TabIndex = 29
        '
        'GroupGeneral
        '
        Me.GroupGeneral.Controls.Add(Me.Label6)
        Me.GroupGeneral.Controls.Add(Me.TxtUbicacion)
        Me.GroupGeneral.Controls.Add(Me.Máximo)
        Me.GroupGeneral.Controls.Add(Me.TxtMaximo)
        Me.GroupGeneral.Controls.Add(Me.Label5)
        Me.GroupGeneral.Controls.Add(Me.TxtMinimo)
        Me.GroupGeneral.Enabled = False
        Me.GroupGeneral.Location = New System.Drawing.Point(133, 644)
        Me.GroupGeneral.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupGeneral.Name = "GroupGeneral"
        Me.GroupGeneral.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupGeneral.Size = New System.Drawing.Size(789, 78)
        Me.GroupGeneral.TabIndex = 31
        Me.GroupGeneral.TabStop = False
        Me.GroupGeneral.Text = "Políticas Inventario"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(543, 33)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 17)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Ubicación"
        '
        'TxtUbicacion
        '
        Me.TxtUbicacion.Location = New System.Drawing.Point(624, 28)
        Me.TxtUbicacion.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtUbicacion.MaxLength = 20
        Me.TxtUbicacion.Name = "TxtUbicacion"
        Me.TxtUbicacion.Size = New System.Drawing.Size(113, 22)
        Me.TxtUbicacion.TabIndex = 31
        Me.TxtUbicacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Máximo
        '
        Me.Máximo.AutoSize = True
        Me.Máximo.Location = New System.Drawing.Point(289, 33)
        Me.Máximo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Máximo.Name = "Máximo"
        Me.Máximo.Size = New System.Drawing.Size(55, 17)
        Me.Máximo.TabIndex = 27
        Me.Máximo.Text = "Máximo"
        '
        'TxtMaximo
        '
        Me.TxtMaximo.Location = New System.Drawing.Point(365, 28)
        Me.TxtMaximo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtMaximo.Name = "TxtMaximo"
        Me.TxtMaximo.Size = New System.Drawing.Size(113, 22)
        Me.TxtMaximo.TabIndex = 28
        Me.TxtMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 33)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 17)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Mínimo"
        '
        'TxtMinimo
        '
        Me.TxtMinimo.Location = New System.Drawing.Point(84, 28)
        Me.TxtMinimo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtMinimo.Name = "TxtMinimo"
        Me.TxtMinimo.Size = New System.Drawing.Size(113, 22)
        Me.TxtMinimo.TabIndex = 26
        Me.TxtMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ChkActivo
        '
        Me.ChkActivo.AutoSize = True
        Me.ChkActivo.Location = New System.Drawing.Point(700, 30)
        Me.ChkActivo.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkActivo.Name = "ChkActivo"
        Me.ChkActivo.Size = New System.Drawing.Size(68, 21)
        Me.ChkActivo.TabIndex = 24
        Me.ChkActivo.Text = "Activo"
        Me.ChkActivo.UseVisualStyleBackColor = True
        '
        'GroupDescuento
        '
        Me.GroupDescuento.Controls.Add(Me.Label14)
        Me.GroupDescuento.Controls.Add(Me.Label13)
        Me.GroupDescuento.Controls.Add(Me.DtpDescuentoIni)
        Me.GroupDescuento.Controls.Add(Me.DtpDescuentoFin)
        Me.GroupDescuento.Controls.Add(Me.Label12)
        Me.GroupDescuento.Controls.Add(Me.TxtPorcDescuento)
        Me.GroupDescuento.Enabled = False
        Me.GroupDescuento.Location = New System.Drawing.Point(133, 572)
        Me.GroupDescuento.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupDescuento.Name = "GroupDescuento"
        Me.GroupDescuento.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupDescuento.Size = New System.Drawing.Size(789, 71)
        Me.GroupDescuento.TabIndex = 30
        Me.GroupDescuento.TabStop = False
        Me.GroupDescuento.Text = "Descuentos"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(300, 32)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 17)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "Hasta"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 32)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 17)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Desde"
        '
        'DtpDescuentoIni
        '
        Me.DtpDescuentoIni.CustomFormat = "dd/MM/yyy"
        Me.DtpDescuentoIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpDescuentoIni.Location = New System.Drawing.Point(84, 27)
        Me.DtpDescuentoIni.Margin = New System.Windows.Forms.Padding(4)
        Me.DtpDescuentoIni.Name = "DtpDescuentoIni"
        Me.DtpDescuentoIni.Size = New System.Drawing.Size(113, 22)
        Me.DtpDescuentoIni.TabIndex = 20
        '
        'DtpDescuentoFin
        '
        Me.DtpDescuentoFin.CustomFormat = "dd/MM/yyy"
        Me.DtpDescuentoFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpDescuentoFin.Location = New System.Drawing.Point(365, 27)
        Me.DtpDescuentoFin.Margin = New System.Windows.Forms.Padding(4)
        Me.DtpDescuentoFin.Name = "DtpDescuentoFin"
        Me.DtpDescuentoFin.Size = New System.Drawing.Size(113, 22)
        Me.DtpDescuentoFin.TabIndex = 21
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(596, 32)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(20, 17)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "%"
        '
        'TxtPorcDescuento
        '
        Me.TxtPorcDescuento.Location = New System.Drawing.Point(624, 27)
        Me.TxtPorcDescuento.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPorcDescuento.Name = "TxtPorcDescuento"
        Me.TxtPorcDescuento.Size = New System.Drawing.Size(113, 22)
        Me.TxtPorcDescuento.TabIndex = 23
        Me.TxtPorcDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblNombreArticulo
        '
        Me.LblNombreArticulo.BackColor = System.Drawing.Color.White
        Me.LblNombreArticulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblNombreArticulo.Location = New System.Drawing.Point(211, 80)
        Me.LblNombreArticulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreArticulo.Name = "LblNombreArticulo"
        Me.LblNombreArticulo.Size = New System.Drawing.Size(432, 25)
        Me.LblNombreArticulo.TabIndex = 32
        Me.LblNombreArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupSucursal
        '
        Me.GroupSucursal.Controls.Add(Me.ChkTodas)
        Me.GroupSucursal.Controls.Add(Me.CmbSucursal)
        Me.GroupSucursal.Controls.Add(Me.ChkActivo)
        Me.GroupSucursal.Controls.Add(Me.Label2)
        Me.GroupSucursal.Enabled = False
        Me.GroupSucursal.Location = New System.Drawing.Point(133, 108)
        Me.GroupSucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupSucursal.Name = "GroupSucursal"
        Me.GroupSucursal.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupSucursal.Size = New System.Drawing.Size(789, 71)
        Me.GroupSucursal.TabIndex = 33
        Me.GroupSucursal.TabStop = False
        '
        'ChkTodas
        '
        Me.ChkTodas.AutoSize = True
        Me.ChkTodas.Location = New System.Drawing.Point(523, 30)
        Me.ChkTodas.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkTodas.Name = "ChkTodas"
        Me.ChkTodas.Size = New System.Drawing.Size(166, 21)
        Me.ChkTodas.TabIndex = 4
        Me.ChkTodas.Text = "Todas las Sucursales"
        Me.ChkTodas.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(785, 85)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 17)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Exento"
        '
        'LblExento
        '
        Me.LblExento.BackColor = System.Drawing.Color.White
        Me.LblExento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblExento.Location = New System.Drawing.Point(847, 80)
        Me.LblExento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblExento.Name = "LblExento"
        Me.LblExento.Size = New System.Drawing.Size(76, 25)
        Me.LblExento.TabIndex = 35
        Me.LblExento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(129, 85)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 17)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Nombre"
        '
        'GbPrecioDetallista
        '
        Me.GbPrecioDetallista.Controls.Add(Me.ChkAplicaPrecio)
        Me.GbPrecioDetallista.Controls.Add(Me.TxtMargen)
        Me.GbPrecioDetallista.Controls.Add(Me.Label3)
        Me.GbPrecioDetallista.Controls.Add(Me.TxtPrecioVenta)
        Me.GbPrecioDetallista.Controls.Add(Me.TxtPrecio)
        Me.GbPrecioDetallista.Controls.Add(Me.Label11)
        Me.GbPrecioDetallista.Controls.Add(Me.Label10)
        Me.GbPrecioDetallista.Location = New System.Drawing.Point(133, 240)
        Me.GbPrecioDetallista.Margin = New System.Windows.Forms.Padding(4)
        Me.GbPrecioDetallista.Name = "GbPrecioDetallista"
        Me.GbPrecioDetallista.Padding = New System.Windows.Forms.Padding(4)
        Me.GbPrecioDetallista.Size = New System.Drawing.Size(259, 159)
        Me.GbPrecioDetallista.TabIndex = 23
        Me.GbPrecioDetallista.TabStop = False
        Me.GbPrecioDetallista.Text = "Precio Detalle"
        '
        'ChkAplicaPrecio
        '
        Me.ChkAplicaPrecio.AutoSize = True
        Me.ChkAplicaPrecio.Location = New System.Drawing.Point(21, 130)
        Me.ChkAplicaPrecio.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkAplicaPrecio.Name = "ChkAplicaPrecio"
        Me.ChkAplicaPrecio.Size = New System.Drawing.Size(182, 21)
        Me.ChkAplicaPrecio.TabIndex = 23
        Me.ChkAplicaPrecio.Text = "Aplica Precio Prefactura"
        Me.ChkAplicaPrecio.UseVisualStyleBackColor = True
        '
        'GroupCosto
        '
        Me.GroupCosto.Controls.Add(Me.TxtCosto)
        Me.GroupCosto.Controls.Add(Me.Label9)
        Me.GroupCosto.Location = New System.Drawing.Point(133, 183)
        Me.GroupCosto.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupCosto.Name = "GroupCosto"
        Me.GroupCosto.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupCosto.Size = New System.Drawing.Size(791, 55)
        Me.GroupCosto.TabIndex = 37
        Me.GroupCosto.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.LvwAnotaciones)
        Me.GroupBox3.Controls.Add(Me.BtnAnotacionEliminar)
        Me.GroupBox3.Controls.Add(Me.BtnAnotacionAgregar)
        Me.GroupBox3.Location = New System.Drawing.Point(133, 729)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(789, 119)
        Me.GroupBox3.TabIndex = 55
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Anotaciones"
        '
        'LvwAnotaciones
        '
        Me.LvwAnotaciones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader23})
        Me.LvwAnotaciones.FullRowSelect = True
        Me.LvwAnotaciones.Location = New System.Drawing.Point(4, 20)
        Me.LvwAnotaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.LvwAnotaciones.Name = "LvwAnotaciones"
        Me.LvwAnotaciones.Size = New System.Drawing.Size(737, 86)
        Me.LvwAnotaciones.TabIndex = 0
        Me.LvwAnotaciones.UseCompatibleStateImageBehavior = False
        Me.LvwAnotaciones.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Id"
        Me.ColumnHeader20.Width = 38
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Anotación"
        Me.ColumnHeader21.Width = 423
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "Fecha"
        Me.ColumnHeader22.Width = 82
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "Hecho Por"
        Me.ColumnHeader23.Width = 0
        '
        'BtnAnotacionEliminar
        '
        Me.BtnAnotacionEliminar.Enabled = False
        Me.BtnAnotacionEliminar.Location = New System.Drawing.Point(751, 80)
        Me.BtnAnotacionEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAnotacionEliminar.Name = "BtnAnotacionEliminar"
        Me.BtnAnotacionEliminar.Size = New System.Drawing.Size(28, 28)
        Me.BtnAnotacionEliminar.TabIndex = 2
        Me.BtnAnotacionEliminar.Text = "-"
        Me.BtnAnotacionEliminar.UseVisualStyleBackColor = True
        '
        'BtnAnotacionAgregar
        '
        Me.BtnAnotacionAgregar.Enabled = False
        Me.BtnAnotacionAgregar.Location = New System.Drawing.Point(751, 44)
        Me.BtnAnotacionAgregar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAnotacionAgregar.Name = "BtnAnotacionAgregar"
        Me.BtnAnotacionAgregar.Size = New System.Drawing.Size(28, 28)
        Me.BtnAnotacionAgregar.TabIndex = 1
        Me.BtnAnotacionAgregar.Text = "+"
        Me.BtnAnotacionAgregar.UseVisualStyleBackColor = True
        '
        'GbPrecio3
        '
        Me.GbPrecio3.Controls.Add(Me.ChkAplicaPrecio3)
        Me.GbPrecio3.Controls.Add(Me.TxtMargen3)
        Me.GbPrecio3.Controls.Add(Me.Label18)
        Me.GbPrecio3.Controls.Add(Me.TxtPrecioVenta3)
        Me.GbPrecio3.Controls.Add(Me.TxtPrecio3)
        Me.GbPrecio3.Controls.Add(Me.Label19)
        Me.GbPrecio3.Controls.Add(Me.Label20)
        Me.GbPrecio3.Enabled = False
        Me.GbPrecio3.Location = New System.Drawing.Point(664, 240)
        Me.GbPrecio3.Margin = New System.Windows.Forms.Padding(4)
        Me.GbPrecio3.Name = "GbPrecio3"
        Me.GbPrecio3.Padding = New System.Windows.Forms.Padding(4)
        Me.GbPrecio3.Size = New System.Drawing.Size(259, 159)
        Me.GbPrecio3.TabIndex = 56
        Me.GbPrecio3.TabStop = False
        Me.GbPrecio3.Text = "Precio Mayoreo 2"
        '
        'ChkAplicaPrecio3
        '
        Me.ChkAplicaPrecio3.AutoSize = True
        Me.ChkAplicaPrecio3.Location = New System.Drawing.Point(21, 130)
        Me.ChkAplicaPrecio3.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkAplicaPrecio3.Name = "ChkAplicaPrecio3"
        Me.ChkAplicaPrecio3.Size = New System.Drawing.Size(182, 21)
        Me.ChkAplicaPrecio3.TabIndex = 29
        Me.ChkAplicaPrecio3.Text = "Aplica Precio Prefactura"
        Me.ChkAplicaPrecio3.UseVisualStyleBackColor = True
        '
        'TxtMargen3
        '
        Me.TxtMargen3.Location = New System.Drawing.Point(116, 34)
        Me.TxtMargen3.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtMargen3.Name = "TxtMargen3"
        Me.TxtMargen3.Size = New System.Drawing.Size(112, 22)
        Me.TxtMargen3.TabIndex = 24
        Me.TxtMargen3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(17, 71)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(48, 17)
        Me.Label18.TabIndex = 27
        Me.Label18.Text = "Precio"
        '
        'TxtPrecioVenta3
        '
        Me.TxtPrecioVenta3.Location = New System.Drawing.Point(116, 100)
        Me.TxtPrecioVenta3.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPrecioVenta3.Name = "TxtPrecioVenta3"
        Me.TxtPrecioVenta3.Size = New System.Drawing.Size(113, 22)
        Me.TxtPrecioVenta3.TabIndex = 26
        Me.TxtPrecioVenta3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPrecio3
        '
        Me.TxtPrecio3.BackColor = System.Drawing.Color.White
        Me.TxtPrecio3.Location = New System.Drawing.Point(115, 68)
        Me.TxtPrecio3.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPrecio3.Name = "TxtPrecio3"
        Me.TxtPrecio3.ReadOnly = True
        Me.TxtPrecio3.Size = New System.Drawing.Size(113, 22)
        Me.TxtPrecio3.TabIndex = 28
        Me.TxtPrecio3.TabStop = False
        Me.TxtPrecio3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(17, 103)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(89, 17)
        Me.Label19.TabIndex = 25
        Me.Label19.Text = "Precio Venta"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(17, 38)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 17)
        Me.Label20.TabIndex = 23
        Me.Label20.Text = "Margen"
        '
        'GbPrecio4
        '
        Me.GbPrecio4.Controls.Add(Me.ChkAplicaPrecio4)
        Me.GbPrecio4.Controls.Add(Me.TxtMargen4)
        Me.GbPrecio4.Controls.Add(Me.Label21)
        Me.GbPrecio4.Controls.Add(Me.TxtPrecioVenta4)
        Me.GbPrecio4.Controls.Add(Me.TxtPrecio4)
        Me.GbPrecio4.Controls.Add(Me.Label22)
        Me.GbPrecio4.Controls.Add(Me.Label23)
        Me.GbPrecio4.Enabled = False
        Me.GbPrecio4.Location = New System.Drawing.Point(133, 406)
        Me.GbPrecio4.Margin = New System.Windows.Forms.Padding(4)
        Me.GbPrecio4.Name = "GbPrecio4"
        Me.GbPrecio4.Padding = New System.Windows.Forms.Padding(4)
        Me.GbPrecio4.Size = New System.Drawing.Size(259, 159)
        Me.GbPrecio4.TabIndex = 57
        Me.GbPrecio4.TabStop = False
        Me.GbPrecio4.Text = "Precio Mayoreo 3"
        '
        'ChkAplicaPrecio4
        '
        Me.ChkAplicaPrecio4.AutoSize = True
        Me.ChkAplicaPrecio4.Location = New System.Drawing.Point(21, 130)
        Me.ChkAplicaPrecio4.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkAplicaPrecio4.Name = "ChkAplicaPrecio4"
        Me.ChkAplicaPrecio4.Size = New System.Drawing.Size(182, 21)
        Me.ChkAplicaPrecio4.TabIndex = 29
        Me.ChkAplicaPrecio4.Text = "Aplica Precio Prefactura"
        Me.ChkAplicaPrecio4.UseVisualStyleBackColor = True
        '
        'TxtMargen4
        '
        Me.TxtMargen4.Location = New System.Drawing.Point(116, 34)
        Me.TxtMargen4.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtMargen4.Name = "TxtMargen4"
        Me.TxtMargen4.Size = New System.Drawing.Size(112, 22)
        Me.TxtMargen4.TabIndex = 24
        Me.TxtMargen4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(17, 71)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 17)
        Me.Label21.TabIndex = 27
        Me.Label21.Text = "Precio"
        '
        'TxtPrecioVenta4
        '
        Me.TxtPrecioVenta4.Location = New System.Drawing.Point(116, 100)
        Me.TxtPrecioVenta4.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPrecioVenta4.Name = "TxtPrecioVenta4"
        Me.TxtPrecioVenta4.Size = New System.Drawing.Size(113, 22)
        Me.TxtPrecioVenta4.TabIndex = 26
        Me.TxtPrecioVenta4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPrecio4
        '
        Me.TxtPrecio4.BackColor = System.Drawing.Color.White
        Me.TxtPrecio4.Location = New System.Drawing.Point(115, 68)
        Me.TxtPrecio4.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPrecio4.Name = "TxtPrecio4"
        Me.TxtPrecio4.ReadOnly = True
        Me.TxtPrecio4.Size = New System.Drawing.Size(113, 22)
        Me.TxtPrecio4.TabIndex = 28
        Me.TxtPrecio4.TabStop = False
        Me.TxtPrecio4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(17, 103)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(89, 17)
        Me.Label22.TabIndex = 25
        Me.Label22.Text = "Precio Venta"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(17, 38)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(56, 17)
        Me.Label23.TabIndex = 23
        Me.Label23.Text = "Margen"
        '
        'GbPrecio5
        '
        Me.GbPrecio5.Controls.Add(Me.ChkAplicaPrecio5)
        Me.GbPrecio5.Controls.Add(Me.TxtMargen5)
        Me.GbPrecio5.Controls.Add(Me.Label24)
        Me.GbPrecio5.Controls.Add(Me.TxtPrecioVenta5)
        Me.GbPrecio5.Controls.Add(Me.TxtPrecio5)
        Me.GbPrecio5.Controls.Add(Me.Label25)
        Me.GbPrecio5.Controls.Add(Me.Label26)
        Me.GbPrecio5.Enabled = False
        Me.GbPrecio5.Location = New System.Drawing.Point(397, 406)
        Me.GbPrecio5.Margin = New System.Windows.Forms.Padding(4)
        Me.GbPrecio5.Name = "GbPrecio5"
        Me.GbPrecio5.Padding = New System.Windows.Forms.Padding(4)
        Me.GbPrecio5.Size = New System.Drawing.Size(259, 159)
        Me.GbPrecio5.TabIndex = 58
        Me.GbPrecio5.TabStop = False
        Me.GbPrecio5.Text = "Precio Mayoreo 4"
        '
        'ChkAplicaPrecio5
        '
        Me.ChkAplicaPrecio5.AutoSize = True
        Me.ChkAplicaPrecio5.Location = New System.Drawing.Point(21, 130)
        Me.ChkAplicaPrecio5.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkAplicaPrecio5.Name = "ChkAplicaPrecio5"
        Me.ChkAplicaPrecio5.Size = New System.Drawing.Size(182, 21)
        Me.ChkAplicaPrecio5.TabIndex = 30
        Me.ChkAplicaPrecio5.Text = "Aplica Precio Prefactura"
        Me.ChkAplicaPrecio5.UseVisualStyleBackColor = True
        '
        'TxtMargen5
        '
        Me.TxtMargen5.Location = New System.Drawing.Point(116, 34)
        Me.TxtMargen5.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtMargen5.Name = "TxtMargen5"
        Me.TxtMargen5.Size = New System.Drawing.Size(112, 22)
        Me.TxtMargen5.TabIndex = 24
        Me.TxtMargen5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(17, 71)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(48, 17)
        Me.Label24.TabIndex = 27
        Me.Label24.Text = "Precio"
        '
        'TxtPrecioVenta5
        '
        Me.TxtPrecioVenta5.Location = New System.Drawing.Point(116, 100)
        Me.TxtPrecioVenta5.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPrecioVenta5.Name = "TxtPrecioVenta5"
        Me.TxtPrecioVenta5.Size = New System.Drawing.Size(113, 22)
        Me.TxtPrecioVenta5.TabIndex = 26
        Me.TxtPrecioVenta5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPrecio5
        '
        Me.TxtPrecio5.BackColor = System.Drawing.Color.White
        Me.TxtPrecio5.Location = New System.Drawing.Point(115, 68)
        Me.TxtPrecio5.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPrecio5.Name = "TxtPrecio5"
        Me.TxtPrecio5.ReadOnly = True
        Me.TxtPrecio5.Size = New System.Drawing.Size(113, 22)
        Me.TxtPrecio5.TabIndex = 28
        Me.TxtPrecio5.TabStop = False
        Me.TxtPrecio5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(17, 103)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(89, 17)
        Me.Label25.TabIndex = 25
        Me.Label25.Text = "Precio Venta"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(17, 38)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(56, 17)
        Me.Label26.TabIndex = 23
        Me.Label26.Text = "Margen"
        '
        'BtnAplicarPrecio
        '
        Me.BtnAplicarPrecio.BackColor = System.Drawing.Color.White
        Me.BtnAplicarPrecio.Location = New System.Drawing.Point(749, 469)
        Me.BtnAplicarPrecio.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAplicarPrecio.Name = "BtnAplicarPrecio"
        Me.BtnAplicarPrecio.Size = New System.Drawing.Size(83, 33)
        Me.BtnAplicarPrecio.TabIndex = 3
        Me.BtnAplicarPrecio.Text = "Aplicar"
        Me.BtnAplicarPrecio.UseVisualStyleBackColor = False
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(711, 416)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(161, 44)
        Me.Label27.TabIndex = 59
        Me.Label27.Text = "Aplicar precio detalle a todos los precios"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmArticuloBodega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(940, 852)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.BtnAplicarPrecio)
        Me.Controls.Add(Me.GbPrecio5)
        Me.Controls.Add(Me.GbPrecio4)
        Me.Controls.Add(Me.GbPrecio3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupCosto)
        Me.Controls.Add(Me.GbPrecioDetallista)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblExento)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupSucursal)
        Me.Controls.Add(Me.GbPrecioMayoreo)
        Me.Controls.Add(Me.LblNombreArticulo)
        Me.Controls.Add(Me.GroupGeneral)
        Me.Controls.Add(Me.GroupDescuento)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtCodigo)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LblSucursal)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmArticuloBodega"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Artículo x Bodega"
        Me.GbPrecioMayoreo.ResumeLayout(False)
        Me.GbPrecioMayoreo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupGeneral.ResumeLayout(False)
        Me.GroupGeneral.PerformLayout()
        Me.GroupDescuento.ResumeLayout(False)
        Me.GroupDescuento.PerformLayout()
        Me.GroupSucursal.ResumeLayout(False)
        Me.GroupSucursal.PerformLayout()
        Me.GbPrecioDetallista.ResumeLayout(False)
        Me.GbPrecioDetallista.PerformLayout()
        Me.GroupCosto.ResumeLayout(False)
        Me.GroupCosto.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GbPrecio3.ResumeLayout(False)
        Me.GbPrecio3.PerformLayout()
        Me.GbPrecio4.ResumeLayout(False)
        Me.GbPrecio4.PerformLayout()
        Me.GbPrecio5.ResumeLayout(False)
        Me.GbPrecio5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblSucursal As System.Windows.Forms.Label
    Friend WithEvents CmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GbPrecioMayoreo As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCosto As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtMargen As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioVenta As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents GroupGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents ChkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents GroupDescuento As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DtpDescuentoIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpDescuentoFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtPorcDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Máximo As System.Windows.Forms.Label
    Friend WithEvents TxtMaximo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtMinimo As System.Windows.Forms.TextBox
    Friend WithEvents LblNombreArticulo As System.Windows.Forms.Label
    Friend WithEvents GroupSucursal As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblExento As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ChkTodas As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents TxtMargenMayorista As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioVentaMayorista As System.Windows.Forms.TextBox
    Friend WithEvents TxtPrecioMayorista As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GbPrecioDetallista As System.Windows.Forms.GroupBox
    Friend WithEvents GroupCosto As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents LvwAnotaciones As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnAnotacionEliminar As System.Windows.Forms.Button
    Friend WithEvents BtnAnotacionAgregar As System.Windows.Forms.Button
    Friend WithEvents GbPrecio3 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtMargen3 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioVenta3 As System.Windows.Forms.TextBox
    Friend WithEvents TxtPrecio3 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GbPrecio4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtMargen4 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioVenta4 As System.Windows.Forms.TextBox
    Friend WithEvents TxtPrecio4 As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents GbPrecio5 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtMargen5 As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioVenta5 As System.Windows.Forms.TextBox
    Friend WithEvents TxtPrecio5 As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents ChkAplicaMayorista As CheckBox
    Friend WithEvents ChkAplicaPrecio As CheckBox
    Friend WithEvents ChkAplicaPrecio3 As CheckBox
    Friend WithEvents ChkAplicaPrecio4 As CheckBox
    Friend WithEvents ChkAplicaPrecio5 As CheckBox
    Friend WithEvents BtnAplicarPrecio As Button
    Friend WithEvents Label27 As Label
End Class
