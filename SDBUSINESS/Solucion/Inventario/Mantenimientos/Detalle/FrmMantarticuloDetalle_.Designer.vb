<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantarticuloDetalle_
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantarticuloDetalle_))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnConsulta = New System.Windows.Forms.Button()
        Me.BtnReceta = New System.Windows.Forms.Button()
        Me.BtnProveedor = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.BtnCosto = New System.Windows.Forms.Button()
        Me.BtnPrecios = New System.Windows.Forms.Button()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.CmbCategoria = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbSubCategoria = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbUnidadMedida = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.TxtFactorConversion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ChkExento = New System.Windows.Forms.CheckBox()
        Me.ChkSuelto = New System.Windows.Forms.CheckBox()
        Me.TxtCodigoPadre = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ChkSolicitaCantidad = New System.Windows.Forms.CheckBox()
        Me.ChkPermiteFacturar = New System.Windows.Forms.CheckBox()
        Me.ChkActivo = New System.Windows.Forms.CheckBox()
        Me.TxtNombrePadre = New System.Windows.Forms.TextBox()
        Me.GroupOpciones = New System.Windows.Forms.GroupBox()
        Me.ChkArticuloFrecuente = New System.Windows.Forms.CheckBox()
        Me.ChkBusquedaRapida = New System.Windows.Forms.CheckBox()
        Me.CmbCodigoCantidadTipo = New System.Windows.Forms.ComboBox()
        Me.ChkCantidadEtiqueta = New System.Windows.Forms.CheckBox()
        Me.GroupConjuntos = New System.Windows.Forms.GroupBox()
        Me.TxtCantidadConjunto = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtNombreConjunto = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtCodigoConjunto = New System.Windows.Forms.TextBox()
        Me.BtnEliminarConjunto = New System.Windows.Forms.Button()
        Me.LvwConjuntos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BtnAgregarConjunto = New System.Windows.Forms.Button()
        Me.PanelGeneral1 = New System.Windows.Forms.Panel()
        Me.GroupImpuesto = New System.Windows.Forms.GroupBox()
        Me.LvwImpuesto = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImgLstImpuestos = New System.Windows.Forms.ImageList(Me.components)
        Me.TxtCodInterno = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtCodProveedor = New System.Windows.Forms.TextBox()
        Me.TxtAnotaciones = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtCuentaContable = New System.Windows.Forms.TextBox()
        Me.CmbTipoAcumulacion = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChkCalculaCantidad = New System.Windows.Forms.CheckBox()
        Me.ChkSaldoPropio = New System.Windows.Forms.CheckBox()
        Me.ChkCompuesto = New System.Windows.Forms.CheckBox()
        Me.ChkServicio = New System.Windows.Forms.CheckBox()
        Me.GroupSuelto = New System.Windows.Forms.GroupBox()
        Me.GroupEquivalentes = New System.Windows.Forms.GroupBox()
        Me.TxtCodigoEquivalente = New System.Windows.Forms.TextBox()
        Me.BtnEquivalenteEliminar = New System.Windows.Forms.Button()
        Me.LvwEquivalentes = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BtnEquivalenteAgregar = New System.Windows.Forms.Button()
        Me.PanelGeneral2 = New System.Windows.Forms.Panel()
        Me.PanelGeneral3 = New System.Windows.Forms.Panel()
        Me.GroupBodegas = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnAgregarBodega = New System.Windows.Forms.Button()
        Me.TrwBodegas = New System.Windows.Forms.TreeView()
        Me.ImgLstBodegas = New System.Windows.Forms.ImageList(Me.components)
        Me.Txbcabys = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnCABYS = New System.Windows.Forms.Button()
        Me.ChkGarantia = New System.Windows.Forms.CheckBox()
        Me.ChkLote = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.GroupOpciones.SuspendLayout()
        Me.GroupConjuntos.SuspendLayout()
        Me.PanelGeneral1.SuspendLayout()
        Me.GroupImpuesto.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupSuelto.SuspendLayout()
        Me.GroupEquivalentes.SuspendLayout()
        Me.PanelGeneral2.SuspendLayout()
        Me.PanelGeneral3.SuspendLayout()
        Me.GroupBodegas.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnConsulta)
        Me.Panel1.Controls.Add(Me.BtnReceta)
        Me.Panel1.Controls.Add(Me.BtnProveedor)
        Me.Panel1.Controls.Add(Me.BtnEliminar)
        Me.Panel1.Controls.Add(Me.BtnCosto)
        Me.Panel1.Controls.Add(Me.BtnPrecios)
        Me.Panel1.Controls.Add(Me.BtnLimpiar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnGuardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(113, 884)
        Me.Panel1.TabIndex = 0
        '
        'BtnConsulta
        '
        Me.BtnConsulta.BackColor = System.Drawing.Color.White
        Me.BtnConsulta.Image = Global.Inventario.My.Resources.Resources.Blue_F10
        Me.BtnConsulta.Location = New System.Drawing.Point(12, 683)
        Me.BtnConsulta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnConsulta.Name = "BtnConsulta"
        Me.BtnConsulta.Size = New System.Drawing.Size(85, 89)
        Me.BtnConsulta.TabIndex = 8
        Me.BtnConsulta.Text = "Consulta"
        Me.BtnConsulta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnConsulta.UseVisualStyleBackColor = False
        '
        'BtnReceta
        '
        Me.BtnReceta.BackColor = System.Drawing.Color.White
        Me.BtnReceta.Image = Global.Inventario.My.Resources.Resources.Blue_F9
        Me.BtnReceta.Location = New System.Drawing.Point(12, 587)
        Me.BtnReceta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnReceta.Name = "BtnReceta"
        Me.BtnReceta.Size = New System.Drawing.Size(85, 89)
        Me.BtnReceta.TabIndex = 7
        Me.BtnReceta.Text = "Receta"
        Me.BtnReceta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnReceta.UseVisualStyleBackColor = False
        '
        'BtnProveedor
        '
        Me.BtnProveedor.BackColor = System.Drawing.Color.White
        Me.BtnProveedor.Image = Global.Inventario.My.Resources.Resources.Blue_F7
        Me.BtnProveedor.Location = New System.Drawing.Point(12, 395)
        Me.BtnProveedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnProveedor.Name = "BtnProveedor"
        Me.BtnProveedor.Size = New System.Drawing.Size(85, 89)
        Me.BtnProveedor.TabIndex = 4
        Me.BtnProveedor.Text = "Proveedor"
        Me.BtnProveedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnProveedor.UseVisualStyleBackColor = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.Color.White
        Me.BtnEliminar.Image = Global.Inventario.My.Resources.Resources.Blue_F8
        Me.BtnEliminar.Location = New System.Drawing.Point(12, 491)
        Me.BtnEliminar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(85, 89)
        Me.BtnEliminar.TabIndex = 5
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'BtnCosto
        '
        Me.BtnCosto.BackColor = System.Drawing.Color.White
        Me.BtnCosto.Image = Global.Inventario.My.Resources.Resources.Blue_F5
        Me.BtnCosto.Location = New System.Drawing.Point(12, 203)
        Me.BtnCosto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnCosto.Name = "BtnCosto"
        Me.BtnCosto.Size = New System.Drawing.Size(85, 89)
        Me.BtnCosto.TabIndex = 2
        Me.BtnCosto.Text = "Costo"
        Me.BtnCosto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnCosto.UseVisualStyleBackColor = False
        '
        'BtnPrecios
        '
        Me.BtnPrecios.BackColor = System.Drawing.Color.White
        Me.BtnPrecios.Image = Global.Inventario.My.Resources.Resources.Blue_F6
        Me.BtnPrecios.Location = New System.Drawing.Point(12, 299)
        Me.BtnPrecios.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnPrecios.Name = "BtnPrecios"
        Me.BtnPrecios.Size = New System.Drawing.Size(85, 89)
        Me.BtnPrecios.TabIndex = 3
        Me.BtnPrecios.Text = "Precios"
        Me.BtnPrecios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnPrecios.UseVisualStyleBackColor = False
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.BackColor = System.Drawing.Color.White
        Me.BtnLimpiar.Image = Global.Inventario.My.Resources.Resources.Blue_F4
        Me.BtnLimpiar.Location = New System.Drawing.Point(12, 107)
        Me.BtnLimpiar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(85, 89)
        Me.BtnLimpiar.TabIndex = 1
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnLimpiar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Inventario.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(12, 783)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(85, 86)
        Me.BtnSalir.TabIndex = 6
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.BackColor = System.Drawing.Color.White
        Me.BtnGuardar.Image = Global.Inventario.My.Resources.Resources.Blue_F3
        Me.BtnGuardar.Location = New System.Drawing.Point(12, 11)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(85, 89)
        Me.BtnGuardar.TabIndex = 0
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnGuardar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(133, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Código"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Location = New System.Drawing.Point(261, 11)
        Me.TxtCodigo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodigo.MaxLength = 13
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(160, 22)
        Me.TxtCodigo.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 23)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nombre"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(132, 20)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtNombre.MaxLength = 100
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(613, 22)
        Me.TxtNombre.TabIndex = 8
        '
        'CmbCategoria
        '
        Me.CmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCategoria.FormattingEnabled = True
        Me.CmbCategoria.ItemHeight = 16
        Me.CmbCategoria.Location = New System.Drawing.Point(132, 60)
        Me.CmbCategoria.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmbCategoria.Name = "CmbCategoria"
        Me.CmbCategoria.Size = New System.Drawing.Size(195, 24)
        Me.CmbCategoria.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 65)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Categoría"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 98)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Sub Categoría"
        '
        'CmbSubCategoria
        '
        Me.CmbSubCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSubCategoria.FormattingEnabled = True
        Me.CmbSubCategoria.Location = New System.Drawing.Point(132, 94)
        Me.CmbSubCategoria.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmbSubCategoria.Name = "CmbSubCategoria"
        Me.CmbSubCategoria.Size = New System.Drawing.Size(195, 24)
        Me.CmbSubCategoria.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 166)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 17)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Unidad Medida"
        '
        'CmbUnidadMedida
        '
        Me.CmbUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbUnidadMedida.FormattingEnabled = True
        Me.CmbUnidadMedida.Location = New System.Drawing.Point(132, 161)
        Me.CmbUnidadMedida.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmbUnidadMedida.Name = "CmbUnidadMedida"
        Me.CmbUnidadMedida.Size = New System.Drawing.Size(195, 24)
        Me.CmbUnidadMedida.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 132)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Departamento"
        '
        'CmbDepartamento
        '
        Me.CmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbDepartamento.FormattingEnabled = True
        Me.CmbDepartamento.Location = New System.Drawing.Point(132, 127)
        Me.CmbDepartamento.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmbDepartamento.Name = "CmbDepartamento"
        Me.CmbDepartamento.Size = New System.Drawing.Size(195, 24)
        Me.CmbDepartamento.TabIndex = 10
        '
        'TxtFactorConversion
        '
        Me.TxtFactorConversion.Location = New System.Drawing.Point(568, 161)
        Me.TxtFactorConversion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtFactorConversion.MaxLength = 13
        Me.TxtFactorConversion.Name = "TxtFactorConversion"
        Me.TxtFactorConversion.Size = New System.Drawing.Size(195, 22)
        Me.TxtFactorConversion.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(404, 166)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 17)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Unidades Paquete"
        '
        'ChkExento
        '
        Me.ChkExento.AutoSize = True
        Me.ChkExento.Location = New System.Drawing.Point(23, 50)
        Me.ChkExento.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ChkExento.Name = "ChkExento"
        Me.ChkExento.Size = New System.Drawing.Size(73, 21)
        Me.ChkExento.TabIndex = 28
        Me.ChkExento.Text = "Exento"
        Me.ChkExento.UseVisualStyleBackColor = True
        '
        'ChkSuelto
        '
        Me.ChkSuelto.AutoSize = True
        Me.ChkSuelto.Location = New System.Drawing.Point(23, 36)
        Me.ChkSuelto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ChkSuelto.Name = "ChkSuelto"
        Me.ChkSuelto.Size = New System.Drawing.Size(70, 21)
        Me.ChkSuelto.TabIndex = 20
        Me.ChkSuelto.Text = "Suelto"
        Me.ChkSuelto.UseVisualStyleBackColor = True
        '
        'TxtCodigoPadre
        '
        Me.TxtCodigoPadre.Location = New System.Drawing.Point(152, 33)
        Me.TxtCodigoPadre.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodigoPadre.MaxLength = 13
        Me.TxtCodigoPadre.Name = "TxtCodigoPadre"
        Me.TxtCodigoPadre.Size = New System.Drawing.Size(160, 22)
        Me.TxtCodigoPadre.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(97, 37)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 17)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Padre"
        '
        'ChkSolicitaCantidad
        '
        Me.ChkSolicitaCantidad.AutoSize = True
        Me.ChkSolicitaCantidad.Location = New System.Drawing.Point(23, 80)
        Me.ChkSolicitaCantidad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ChkSolicitaCantidad.Name = "ChkSolicitaCantidad"
        Me.ChkSolicitaCantidad.Size = New System.Drawing.Size(135, 21)
        Me.ChkSolicitaCantidad.TabIndex = 30
        Me.ChkSolicitaCantidad.Text = "Solicita Cantidad"
        Me.ChkSolicitaCantidad.UseVisualStyleBackColor = True
        '
        'ChkPermiteFacturar
        '
        Me.ChkPermiteFacturar.AutoSize = True
        Me.ChkPermiteFacturar.Location = New System.Drawing.Point(223, 23)
        Me.ChkPermiteFacturar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ChkPermiteFacturar.Name = "ChkPermiteFacturar"
        Me.ChkPermiteFacturar.Size = New System.Drawing.Size(135, 21)
        Me.ChkPermiteFacturar.TabIndex = 27
        Me.ChkPermiteFacturar.Text = "Permite Facturar"
        Me.ChkPermiteFacturar.UseVisualStyleBackColor = True
        '
        'ChkActivo
        '
        Me.ChkActivo.AutoSize = True
        Me.ChkActivo.Location = New System.Drawing.Point(23, 23)
        Me.ChkActivo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ChkActivo.Name = "ChkActivo"
        Me.ChkActivo.Size = New System.Drawing.Size(68, 21)
        Me.ChkActivo.TabIndex = 26
        Me.ChkActivo.Text = "Activo"
        Me.ChkActivo.UseVisualStyleBackColor = True
        '
        'TxtNombrePadre
        '
        Me.TxtNombrePadre.Location = New System.Drawing.Point(321, 33)
        Me.TxtNombrePadre.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtNombrePadre.MaxLength = 50
        Me.TxtNombrePadre.Name = "TxtNombrePadre"
        Me.TxtNombrePadre.ReadOnly = True
        Me.TxtNombrePadre.Size = New System.Drawing.Size(437, 22)
        Me.TxtNombrePadre.TabIndex = 19
        '
        'GroupOpciones
        '
        Me.GroupOpciones.Controls.Add(Me.ChkArticuloFrecuente)
        Me.GroupOpciones.Controls.Add(Me.ChkBusquedaRapida)
        Me.GroupOpciones.Location = New System.Drawing.Point(788, 341)
        Me.GroupOpciones.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupOpciones.Name = "GroupOpciones"
        Me.GroupOpciones.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupOpciones.Size = New System.Drawing.Size(387, 59)
        Me.GroupOpciones.TabIndex = 22
        Me.GroupOpciones.TabStop = False
        '
        'ChkArticuloFrecuente
        '
        Me.ChkArticuloFrecuente.AutoSize = True
        Me.ChkArticuloFrecuente.Location = New System.Drawing.Point(223, 23)
        Me.ChkArticuloFrecuente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ChkArticuloFrecuente.Name = "ChkArticuloFrecuente"
        Me.ChkArticuloFrecuente.Size = New System.Drawing.Size(145, 21)
        Me.ChkArticuloFrecuente.TabIndex = 24
        Me.ChkArticuloFrecuente.Text = "Artículo Frecuente"
        Me.ChkArticuloFrecuente.UseVisualStyleBackColor = True
        '
        'ChkBusquedaRapida
        '
        Me.ChkBusquedaRapida.AutoSize = True
        Me.ChkBusquedaRapida.Location = New System.Drawing.Point(23, 23)
        Me.ChkBusquedaRapida.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ChkBusquedaRapida.Name = "ChkBusquedaRapida"
        Me.ChkBusquedaRapida.Size = New System.Drawing.Size(143, 21)
        Me.ChkBusquedaRapida.TabIndex = 23
        Me.ChkBusquedaRapida.Text = "Búsqueda Rápida"
        Me.ChkBusquedaRapida.UseVisualStyleBackColor = True
        '
        'CmbCodigoCantidadTipo
        '
        Me.CmbCodigoCantidadTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCodigoCantidadTipo.FormattingEnabled = True
        Me.CmbCodigoCantidadTipo.Items.AddRange(New Object() {"Peso", "Unidad"})
        Me.CmbCodigoCantidadTipo.Location = New System.Drawing.Point(223, 107)
        Me.CmbCodigoCantidadTipo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmbCodigoCantidadTipo.Name = "CmbCodigoCantidadTipo"
        Me.CmbCodigoCantidadTipo.Size = New System.Drawing.Size(136, 24)
        Me.CmbCodigoCantidadTipo.TabIndex = 33
        '
        'ChkCantidadEtiqueta
        '
        Me.ChkCantidadEtiqueta.AutoSize = True
        Me.ChkCantidadEtiqueta.Location = New System.Drawing.Point(23, 110)
        Me.ChkCantidadEtiqueta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ChkCantidadEtiqueta.Name = "ChkCantidadEtiqueta"
        Me.ChkCantidadEtiqueta.Size = New System.Drawing.Size(162, 21)
        Me.ChkCantidadEtiqueta.TabIndex = 32
        Me.ChkCantidadEtiqueta.Text = "Cantidad en Etiqueta"
        Me.ChkCantidadEtiqueta.UseVisualStyleBackColor = True
        '
        'GroupConjuntos
        '
        Me.GroupConjuntos.Controls.Add(Me.TxtCantidadConjunto)
        Me.GroupConjuntos.Controls.Add(Me.Label16)
        Me.GroupConjuntos.Controls.Add(Me.TxtNombreConjunto)
        Me.GroupConjuntos.Controls.Add(Me.Label15)
        Me.GroupConjuntos.Controls.Add(Me.TxtCodigoConjunto)
        Me.GroupConjuntos.Controls.Add(Me.BtnEliminarConjunto)
        Me.GroupConjuntos.Controls.Add(Me.LvwConjuntos)
        Me.GroupConjuntos.Controls.Add(Me.BtnAgregarConjunto)
        Me.GroupConjuntos.Location = New System.Drawing.Point(8, 4)
        Me.GroupConjuntos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupConjuntos.Name = "GroupConjuntos"
        Me.GroupConjuntos.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupConjuntos.Size = New System.Drawing.Size(768, 160)
        Me.GroupConjuntos.TabIndex = 24
        Me.GroupConjuntos.TabStop = False
        Me.GroupConjuntos.Text = "Artículos Conjuntos"
        '
        'TxtCantidadConjunto
        '
        Me.TxtCantidadConjunto.Location = New System.Drawing.Point(599, 124)
        Me.TxtCantidadConjunto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCantidadConjunto.MaxLength = 13
        Me.TxtCantidadConjunto.Name = "TxtCantidadConjunto"
        Me.TxtCantidadConjunto.Size = New System.Drawing.Size(71, 22)
        Me.TxtCantidadConjunto.TabIndex = 24
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(552, 129)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(37, 17)
        Me.Label16.TabIndex = 23
        Me.Label16.Text = "Cant"
        '
        'TxtNombreConjunto
        '
        Me.TxtNombreConjunto.Location = New System.Drawing.Point(221, 124)
        Me.TxtNombreConjunto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtNombreConjunto.MaxLength = 50
        Me.TxtNombreConjunto.Name = "TxtNombreConjunto"
        Me.TxtNombreConjunto.ReadOnly = True
        Me.TxtNombreConjunto.Size = New System.Drawing.Size(321, 22)
        Me.TxtNombreConjunto.TabIndex = 22
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 129)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 17)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Artículo"
        '
        'TxtCodigoConjunto
        '
        Me.TxtCodigoConjunto.Location = New System.Drawing.Point(73, 124)
        Me.TxtCodigoConjunto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodigoConjunto.MaxLength = 13
        Me.TxtCodigoConjunto.Name = "TxtCodigoConjunto"
        Me.TxtCodigoConjunto.Size = New System.Drawing.Size(139, 22)
        Me.TxtCodigoConjunto.TabIndex = 21
        '
        'BtnEliminarConjunto
        '
        Me.BtnEliminarConjunto.Location = New System.Drawing.Point(724, 123)
        Me.BtnEliminarConjunto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnEliminarConjunto.Name = "BtnEliminarConjunto"
        Me.BtnEliminarConjunto.Size = New System.Drawing.Size(36, 28)
        Me.BtnEliminarConjunto.TabIndex = 11
        Me.BtnEliminarConjunto.Text = "-"
        Me.BtnEliminarConjunto.UseVisualStyleBackColor = True
        '
        'LvwConjuntos
        '
        Me.LvwConjuntos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader4})
        Me.LvwConjuntos.FullRowSelect = True
        Me.LvwConjuntos.HideSelection = False
        Me.LvwConjuntos.Location = New System.Drawing.Point(8, 23)
        Me.LvwConjuntos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LvwConjuntos.Name = "LvwConjuntos"
        Me.LvwConjuntos.Size = New System.Drawing.Size(751, 91)
        Me.LvwConjuntos.TabIndex = 10
        Me.LvwConjuntos.UseCompatibleStateImageBehavior = False
        Me.LvwConjuntos.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Artículo"
        Me.ColumnHeader1.Width = 120
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Nombre"
        Me.ColumnHeader2.Width = 322
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Cantidad"
        Me.ColumnHeader4.Width = 100
        '
        'BtnAgregarConjunto
        '
        Me.BtnAgregarConjunto.Location = New System.Drawing.Point(679, 123)
        Me.BtnAgregarConjunto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnAgregarConjunto.Name = "BtnAgregarConjunto"
        Me.BtnAgregarConjunto.Size = New System.Drawing.Size(36, 28)
        Me.BtnAgregarConjunto.TabIndex = 9
        Me.BtnAgregarConjunto.Text = "+"
        Me.BtnAgregarConjunto.UseVisualStyleBackColor = True
        '
        'PanelGeneral1
        '
        Me.PanelGeneral1.Controls.Add(Me.GroupImpuesto)
        Me.PanelGeneral1.Controls.Add(Me.TxtCodInterno)
        Me.PanelGeneral1.Controls.Add(Me.Label13)
        Me.PanelGeneral1.Controls.Add(Me.Label12)
        Me.PanelGeneral1.Controls.Add(Me.TxtCodProveedor)
        Me.PanelGeneral1.Controls.Add(Me.TxtAnotaciones)
        Me.PanelGeneral1.Controls.Add(Me.Label11)
        Me.PanelGeneral1.Controls.Add(Me.Label10)
        Me.PanelGeneral1.Controls.Add(Me.TxtCuentaContable)
        Me.PanelGeneral1.Controls.Add(Me.CmbTipoAcumulacion)
        Me.PanelGeneral1.Controls.Add(Me.Label9)
        Me.PanelGeneral1.Controls.Add(Me.GroupBox1)
        Me.PanelGeneral1.Controls.Add(Me.GroupSuelto)
        Me.PanelGeneral1.Controls.Add(Me.GroupEquivalentes)
        Me.PanelGeneral1.Controls.Add(Me.GroupOpciones)
        Me.PanelGeneral1.Controls.Add(Me.Label2)
        Me.PanelGeneral1.Controls.Add(Me.CmbDepartamento)
        Me.PanelGeneral1.Controls.Add(Me.TxtNombre)
        Me.PanelGeneral1.Controls.Add(Me.TxtFactorConversion)
        Me.PanelGeneral1.Controls.Add(Me.Label6)
        Me.PanelGeneral1.Controls.Add(Me.CmbCategoria)
        Me.PanelGeneral1.Controls.Add(Me.CmbUnidadMedida)
        Me.PanelGeneral1.Controls.Add(Me.Label7)
        Me.PanelGeneral1.Controls.Add(Me.Label5)
        Me.PanelGeneral1.Controls.Add(Me.Label3)
        Me.PanelGeneral1.Controls.Add(Me.Label4)
        Me.PanelGeneral1.Controls.Add(Me.CmbSubCategoria)
        Me.PanelGeneral1.Location = New System.Drawing.Point(129, 43)
        Me.PanelGeneral1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PanelGeneral1.Name = "PanelGeneral1"
        Me.PanelGeneral1.Size = New System.Drawing.Size(1187, 652)
        Me.PanelGeneral1.TabIndex = 27
        '
        'GroupImpuesto
        '
        Me.GroupImpuesto.Controls.Add(Me.LvwImpuesto)
        Me.GroupImpuesto.Location = New System.Drawing.Point(4, 287)
        Me.GroupImpuesto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupImpuesto.Name = "GroupImpuesto"
        Me.GroupImpuesto.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupImpuesto.Size = New System.Drawing.Size(773, 281)
        Me.GroupImpuesto.TabIndex = 37
        Me.GroupImpuesto.TabStop = False
        Me.GroupImpuesto.Text = "Impuestos"
        '
        'LvwImpuesto
        '
        Me.LvwImpuesto.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.LvwImpuesto.FullRowSelect = True
        Me.LvwImpuesto.HideSelection = False
        Me.LvwImpuesto.Location = New System.Drawing.Point(4, 23)
        Me.LvwImpuesto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LvwImpuesto.Name = "LvwImpuesto"
        Me.LvwImpuesto.Size = New System.Drawing.Size(760, 249)
        Me.LvwImpuesto.SmallImageList = Me.ImgLstImpuestos
        Me.LvwImpuesto.TabIndex = 35
        Me.LvwImpuesto.UseCompatibleStateImageBehavior = False
        Me.LvwImpuesto.View = System.Windows.Forms.View.Details
        '
        'ImgLstImpuestos
        '
        Me.ImgLstImpuestos.ImageStream = CType(resources.GetObject("ImgLstImpuestos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgLstImpuestos.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgLstImpuestos.Images.SetKeyName(0, "check.ico")
        '
        'TxtCodInterno
        '
        Me.TxtCodInterno.Location = New System.Drawing.Point(568, 127)
        Me.TxtCodInterno.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodInterno.MaxLength = 30
        Me.TxtCodInterno.Name = "TxtCodInterno"
        Me.TxtCodInterno.Size = New System.Drawing.Size(195, 22)
        Me.TxtCodInterno.TabIndex = 17
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(404, 132)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 17)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "Código Interno"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(404, 98)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(122, 17)
        Me.Label12.TabIndex = 34
        Me.Label12.Text = "Código Proveedor"
        '
        'TxtCodProveedor
        '
        Me.TxtCodProveedor.Location = New System.Drawing.Point(568, 94)
        Me.TxtCodProveedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodProveedor.MaxLength = 30
        Me.TxtCodProveedor.Name = "TxtCodProveedor"
        Me.TxtCodProveedor.Size = New System.Drawing.Size(195, 22)
        Me.TxtCodProveedor.TabIndex = 15
        '
        'TxtAnotaciones
        '
        Me.TxtAnotaciones.Location = New System.Drawing.Point(132, 233)
        Me.TxtAnotaciones.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtAnotaciones.MaxLength = 1000
        Me.TxtAnotaciones.Multiline = True
        Me.TxtAnotaciones.Name = "TxtAnotaciones"
        Me.TxtAnotaciones.Size = New System.Drawing.Size(631, 46)
        Me.TxtAnotaciones.TabIndex = 18
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(4, 236)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 17)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Anotaciones"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(404, 65)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(113, 17)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Cuenta Contable"
        '
        'TxtCuentaContable
        '
        Me.TxtCuentaContable.Location = New System.Drawing.Point(568, 60)
        Me.TxtCuentaContable.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCuentaContable.MaxLength = 39
        Me.TxtCuentaContable.Name = "TxtCuentaContable"
        Me.TxtCuentaContable.Size = New System.Drawing.Size(195, 22)
        Me.TxtCuentaContable.TabIndex = 16
        '
        'CmbTipoAcumulacion
        '
        Me.CmbTipoAcumulacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoAcumulacion.FormattingEnabled = True
        Me.CmbTipoAcumulacion.Location = New System.Drawing.Point(132, 194)
        Me.CmbTipoAcumulacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmbTipoAcumulacion.Name = "CmbTipoAcumulacion"
        Me.CmbTipoAcumulacion.Size = New System.Drawing.Size(195, 24)
        Me.CmbTipoAcumulacion.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 199)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 17)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Acumulación"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkLote)
        Me.GroupBox1.Controls.Add(Me.ChkGarantia)
        Me.GroupBox1.Controls.Add(Me.ChkCalculaCantidad)
        Me.GroupBox1.Controls.Add(Me.ChkExento)
        Me.GroupBox1.Controls.Add(Me.ChkSaldoPropio)
        Me.GroupBox1.Controls.Add(Me.ChkCompuesto)
        Me.GroupBox1.Controls.Add(Me.ChkServicio)
        Me.GroupBox1.Controls.Add(Me.CmbCodigoCantidadTipo)
        Me.GroupBox1.Controls.Add(Me.ChkActivo)
        Me.GroupBox1.Controls.Add(Me.ChkCantidadEtiqueta)
        Me.GroupBox1.Controls.Add(Me.ChkPermiteFacturar)
        Me.GroupBox1.Controls.Add(Me.ChkSolicitaCantidad)
        Me.GroupBox1.Location = New System.Drawing.Point(788, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(387, 324)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        '
        'ChkCalculaCantidad
        '
        Me.ChkCalculaCantidad.AutoSize = True
        Me.ChkCalculaCantidad.Location = New System.Drawing.Point(223, 78)
        Me.ChkCalculaCantidad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ChkCalculaCantidad.Name = "ChkCalculaCantidad"
        Me.ChkCalculaCantidad.Size = New System.Drawing.Size(136, 21)
        Me.ChkCalculaCantidad.TabIndex = 35
        Me.ChkCalculaCantidad.Text = "Calcula Cantidad"
        Me.ChkCalculaCantidad.UseVisualStyleBackColor = True
        '
        'ChkSaldoPropio
        '
        Me.ChkSaldoPropio.AutoSize = True
        Me.ChkSaldoPropio.Checked = True
        Me.ChkSaldoPropio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkSaldoPropio.Enabled = False
        Me.ChkSaldoPropio.Location = New System.Drawing.Point(223, 140)
        Me.ChkSaldoPropio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ChkSaldoPropio.Name = "ChkSaldoPropio"
        Me.ChkSaldoPropio.Size = New System.Drawing.Size(111, 21)
        Me.ChkSaldoPropio.TabIndex = 34
        Me.ChkSaldoPropio.Text = "Saldo Propio"
        Me.ChkSaldoPropio.UseVisualStyleBackColor = True
        '
        'ChkCompuesto
        '
        Me.ChkCompuesto.AutoSize = True
        Me.ChkCompuesto.Enabled = False
        Me.ChkCompuesto.Location = New System.Drawing.Point(23, 138)
        Me.ChkCompuesto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ChkCompuesto.Name = "ChkCompuesto"
        Me.ChkCompuesto.Size = New System.Drawing.Size(101, 21)
        Me.ChkCompuesto.TabIndex = 31
        Me.ChkCompuesto.Text = "Compuesto"
        Me.ChkCompuesto.UseVisualStyleBackColor = True
        '
        'ChkServicio
        '
        Me.ChkServicio.AutoSize = True
        Me.ChkServicio.Location = New System.Drawing.Point(223, 52)
        Me.ChkServicio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ChkServicio.Name = "ChkServicio"
        Me.ChkServicio.Size = New System.Drawing.Size(80, 21)
        Me.ChkServicio.TabIndex = 29
        Me.ChkServicio.Text = "Servicio"
        Me.ChkServicio.UseVisualStyleBackColor = True
        '
        'GroupSuelto
        '
        Me.GroupSuelto.Controls.Add(Me.ChkSuelto)
        Me.GroupSuelto.Controls.Add(Me.TxtNombrePadre)
        Me.GroupSuelto.Controls.Add(Me.Label8)
        Me.GroupSuelto.Controls.Add(Me.TxtCodigoPadre)
        Me.GroupSuelto.Location = New System.Drawing.Point(4, 560)
        Me.GroupSuelto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupSuelto.Name = "GroupSuelto"
        Me.GroupSuelto.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupSuelto.Size = New System.Drawing.Size(773, 81)
        Me.GroupSuelto.TabIndex = 19
        Me.GroupSuelto.TabStop = False
        '
        'GroupEquivalentes
        '
        Me.GroupEquivalentes.Controls.Add(Me.TxtCodigoEquivalente)
        Me.GroupEquivalentes.Controls.Add(Me.BtnEquivalenteEliminar)
        Me.GroupEquivalentes.Controls.Add(Me.LvwEquivalentes)
        Me.GroupEquivalentes.Controls.Add(Me.BtnEquivalenteAgregar)
        Me.GroupEquivalentes.Location = New System.Drawing.Point(788, 407)
        Me.GroupEquivalentes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupEquivalentes.Name = "GroupEquivalentes"
        Me.GroupEquivalentes.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupEquivalentes.Size = New System.Drawing.Size(387, 167)
        Me.GroupEquivalentes.TabIndex = 25
        Me.GroupEquivalentes.TabStop = False
        Me.GroupEquivalentes.Text = "Códigos Equivalentes"
        '
        'TxtCodigoEquivalente
        '
        Me.TxtCodigoEquivalente.Location = New System.Drawing.Point(20, 135)
        Me.TxtCodigoEquivalente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodigoEquivalente.MaxLength = 20
        Me.TxtCodigoEquivalente.Name = "TxtCodigoEquivalente"
        Me.TxtCodigoEquivalente.Size = New System.Drawing.Size(265, 22)
        Me.TxtCodigoEquivalente.TabIndex = 34
        '
        'BtnEquivalenteEliminar
        '
        Me.BtnEquivalenteEliminar.Location = New System.Drawing.Point(339, 134)
        Me.BtnEquivalenteEliminar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnEquivalenteEliminar.Name = "BtnEquivalenteEliminar"
        Me.BtnEquivalenteEliminar.Size = New System.Drawing.Size(36, 28)
        Me.BtnEquivalenteEliminar.TabIndex = 36
        Me.BtnEquivalenteEliminar.Text = "-"
        Me.BtnEquivalenteEliminar.UseVisualStyleBackColor = True
        '
        'LvwEquivalentes
        '
        Me.LvwEquivalentes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3})
        Me.LvwEquivalentes.FullRowSelect = True
        Me.LvwEquivalentes.HideSelection = False
        Me.LvwEquivalentes.Location = New System.Drawing.Point(20, 23)
        Me.LvwEquivalentes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LvwEquivalentes.Name = "LvwEquivalentes"
        Me.LvwEquivalentes.Size = New System.Drawing.Size(353, 101)
        Me.LvwEquivalentes.TabIndex = 10
        Me.LvwEquivalentes.UseCompatibleStateImageBehavior = False
        Me.LvwEquivalentes.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Código"
        Me.ColumnHeader3.Width = 241
        '
        'BtnEquivalenteAgregar
        '
        Me.BtnEquivalenteAgregar.Location = New System.Drawing.Point(295, 134)
        Me.BtnEquivalenteAgregar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnEquivalenteAgregar.Name = "BtnEquivalenteAgregar"
        Me.BtnEquivalenteAgregar.Size = New System.Drawing.Size(36, 28)
        Me.BtnEquivalenteAgregar.TabIndex = 35
        Me.BtnEquivalenteAgregar.Text = "+"
        Me.BtnEquivalenteAgregar.UseVisualStyleBackColor = True
        '
        'PanelGeneral2
        '
        Me.PanelGeneral2.Controls.Add(Me.GroupConjuntos)
        Me.PanelGeneral2.Location = New System.Drawing.Point(129, 703)
        Me.PanelGeneral2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PanelGeneral2.Name = "PanelGeneral2"
        Me.PanelGeneral2.Size = New System.Drawing.Size(780, 166)
        Me.PanelGeneral2.TabIndex = 25
        '
        'PanelGeneral3
        '
        Me.PanelGeneral3.Controls.Add(Me.GroupBodegas)
        Me.PanelGeneral3.Location = New System.Drawing.Point(917, 706)
        Me.PanelGeneral3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PanelGeneral3.Name = "PanelGeneral3"
        Me.PanelGeneral3.Size = New System.Drawing.Size(399, 162)
        Me.PanelGeneral3.TabIndex = 27
        '
        'GroupBodegas
        '
        Me.GroupBodegas.Controls.Add(Me.Label17)
        Me.GroupBodegas.Controls.Add(Me.Panel3)
        Me.GroupBodegas.Controls.Add(Me.BtnAgregarBodega)
        Me.GroupBodegas.Controls.Add(Me.TrwBodegas)
        Me.GroupBodegas.Location = New System.Drawing.Point(8, 4)
        Me.GroupBodegas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBodegas.Name = "GroupBodegas"
        Me.GroupBodegas.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBodegas.Size = New System.Drawing.Size(379, 156)
        Me.GroupBodegas.TabIndex = 26
        Me.GroupBodegas.TabStop = False
        Me.GroupBodegas.Text = "Bodegas"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(39, 128)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(89, 17)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "= En bodega"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Panel3.Location = New System.Drawing.Point(9, 124)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(21, 22)
        Me.Panel3.TabIndex = 29
        '
        'BtnAgregarBodega
        '
        Me.BtnAgregarBodega.Enabled = False
        Me.BtnAgregarBodega.Location = New System.Drawing.Point(331, 121)
        Me.BtnAgregarBodega.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnAgregarBodega.Name = "BtnAgregarBodega"
        Me.BtnAgregarBodega.Size = New System.Drawing.Size(36, 28)
        Me.BtnAgregarBodega.TabIndex = 12
        Me.BtnAgregarBodega.Text = "+"
        Me.BtnAgregarBodega.UseVisualStyleBackColor = True
        '
        'TrwBodegas
        '
        Me.TrwBodegas.FullRowSelect = True
        Me.TrwBodegas.HideSelection = False
        Me.TrwBodegas.ImageIndex = 0
        Me.TrwBodegas.ImageList = Me.ImgLstBodegas
        Me.TrwBodegas.Location = New System.Drawing.Point(8, 23)
        Me.TrwBodegas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TrwBodegas.Name = "TrwBodegas"
        Me.TrwBodegas.SelectedImageIndex = 0
        Me.TrwBodegas.ShowRootLines = False
        Me.TrwBodegas.Size = New System.Drawing.Size(357, 93)
        Me.TrwBodegas.TabIndex = 0
        '
        'ImgLstBodegas
        '
        Me.ImgLstBodegas.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImgLstBodegas.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImgLstBodegas.TransparentColor = System.Drawing.Color.Transparent
        '
        'Txbcabys
        '
        Me.Txbcabys.Location = New System.Drawing.Point(563, 11)
        Me.Txbcabys.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Txbcabys.Name = "Txbcabys"
        Me.Txbcabys.ReadOnly = True
        Me.Txbcabys.Size = New System.Drawing.Size(163, 22)
        Me.Txbcabys.TabIndex = 28
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(451, 12)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(101, 17)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Código CABYS"
        '
        'btnCABYS
        '
        Me.btnCABYS.Location = New System.Drawing.Point(747, 11)
        Me.btnCABYS.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCABYS.Name = "btnCABYS"
        Me.btnCABYS.Size = New System.Drawing.Size(75, 23)
        Me.btnCABYS.TabIndex = 30
        Me.btnCABYS.Text = "Buscar"
        Me.btnCABYS.UseVisualStyleBackColor = True
        '
        'ChkGarantia
        '
        Me.ChkGarantia.AutoSize = True
        Me.ChkGarantia.Location = New System.Drawing.Point(23, 170)
        Me.ChkGarantia.Name = "ChkGarantia"
        Me.ChkGarantia.Size = New System.Drawing.Size(85, 21)
        Me.ChkGarantia.TabIndex = 36
        Me.ChkGarantia.Text = "Garantía"
        Me.ChkGarantia.UseVisualStyleBackColor = True
        '
        'ChkLote
        '
        Me.ChkLote.AutoSize = True
        Me.ChkLote.Location = New System.Drawing.Point(223, 170)
        Me.ChkLote.Name = "ChkLote"
        Me.ChkLote.Size = New System.Drawing.Size(127, 21)
        Me.ChkLote.TabIndex = 37
        Me.ChkLote.Text = "Control de Lote"
        Me.ChkLote.UseVisualStyleBackColor = True
        '
        'FrmMantarticuloDetalle_
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1325, 884)
        Me.Controls.Add(Me.btnCABYS)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Txbcabys)
        Me.Controls.Add(Me.PanelGeneral2)
        Me.Controls.Add(Me.PanelGeneral3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelGeneral1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCodigo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantarticuloDetalle_"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "    Articulo"
        Me.Panel1.ResumeLayout(False)
        Me.GroupOpciones.ResumeLayout(False)
        Me.GroupOpciones.PerformLayout()
        Me.GroupConjuntos.ResumeLayout(False)
        Me.GroupConjuntos.PerformLayout()
        Me.PanelGeneral1.ResumeLayout(False)
        Me.PanelGeneral1.PerformLayout()
        Me.GroupImpuesto.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupSuelto.ResumeLayout(False)
        Me.GroupSuelto.PerformLayout()
        Me.GroupEquivalentes.ResumeLayout(False)
        Me.GroupEquivalentes.PerformLayout()
        Me.PanelGeneral2.ResumeLayout(False)
        Me.PanelGeneral3.ResumeLayout(False)
        Me.GroupBodegas.ResumeLayout(False)
        Me.GroupBodegas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents CmbCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbSubCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbUnidadMedida As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents TxtFactorConversion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ChkExento As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSuelto As System.Windows.Forms.CheckBox
    Friend WithEvents TxtCodigoPadre As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ChkSolicitaCantidad As System.Windows.Forms.CheckBox
    Friend WithEvents ChkPermiteFacturar As System.Windows.Forms.CheckBox
    Friend WithEvents ChkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents GroupOpciones As System.Windows.Forms.GroupBox
    Friend WithEvents GroupConjuntos As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregarConjunto As System.Windows.Forms.Button
    Friend WithEvents BtnEliminarConjunto As System.Windows.Forms.Button
    Friend WithEvents TxtNombrePadre As System.Windows.Forms.TextBox
    Friend WithEvents GroupEquivalentes As System.Windows.Forms.GroupBox
    Friend WithEvents BtnEquivalenteEliminar As System.Windows.Forms.Button
    Friend WithEvents LvwEquivalentes As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnEquivalenteAgregar As System.Windows.Forms.Button
    Friend WithEvents TxtCodigoEquivalente As System.Windows.Forms.TextBox
    Friend WithEvents LvwConjuntos As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupSuelto As System.Windows.Forms.GroupBox
    Friend WithEvents ImgLstBodegas As System.Windows.Forms.ImageList
    Friend WithEvents GroupBodegas As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregarBodega As System.Windows.Forms.Button
    Friend WithEvents TrwBodegas As System.Windows.Forms.TreeView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TxtNombreConjunto As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoConjunto As System.Windows.Forms.TextBox
    Friend WithEvents TxtCantidadConjunto As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents PanelGeneral1 As System.Windows.Forms.Panel
    Friend WithEvents PanelGeneral2 As System.Windows.Forms.Panel
    Friend WithEvents PanelGeneral3 As System.Windows.Forms.Panel
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ChkCantidadEtiqueta As System.Windows.Forms.CheckBox
    Friend WithEvents CmbCodigoCantidadTipo As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkArticuloFrecuente As System.Windows.Forms.CheckBox
    Friend WithEvents ChkBusquedaRapida As System.Windows.Forms.CheckBox
    Friend WithEvents BtnPrecios As System.Windows.Forms.Button
    Friend WithEvents ChkServicio As System.Windows.Forms.CheckBox
    Friend WithEvents BtnCosto As System.Windows.Forms.Button
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents CmbTipoAcumulacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BtnProveedor As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtCuentaContable As System.Windows.Forms.TextBox
    Friend WithEvents ChkCompuesto As CheckBox
    Friend WithEvents TxtAnotaciones As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TxtCodProveedor As TextBox
    Friend WithEvents TxtCodInterno As TextBox
    Friend WithEvents ChkSaldoPropio As CheckBox
    Friend WithEvents BtnReceta As Button
    Friend WithEvents BtnConsulta As Button
    Friend WithEvents ChkCalculaCantidad As CheckBox
    Friend WithEvents GroupImpuesto As GroupBox
    Friend WithEvents LvwImpuesto As ListView
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ImgLstImpuestos As ImageList
    Friend WithEvents Txbcabys As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents btnCABYS As Button
    Friend WithEvents ChkLote As CheckBox
    Friend WithEvents ChkGarantia As CheckBox
End Class
