<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRepListadoPreciosxCategoria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRepListadoPreciosxCategoria))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbSucursal = New System.Windows.Forms.ComboBox()
        Me.CmbBodega = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChkTodasLasCategorias = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ChkPrecio5 = New System.Windows.Forms.CheckBox()
        Me.ChkPrecio4 = New System.Windows.Forms.CheckBox()
        Me.ChkPrecioMayoreo = New System.Windows.Forms.CheckBox()
        Me.ChkPrecio3 = New System.Windows.Forms.CheckBox()
        Me.ChkPrecioDetalle = New System.Windows.Forms.CheckBox()
        Me.LvwCategorias = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChkMuestraSaldo = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnImprimir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(108, 456)
        Me.Panel1.TabIndex = 8
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Inventario.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(16, 105)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(79, 86)
        Me.BtnSalir.TabIndex = 13
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnImprimir
        '
        Me.BtnImprimir.BackColor = System.Drawing.Color.White
        Me.BtnImprimir.Image = Global.Inventario.My.Resources.Resources.Blue_F3
        Me.BtnImprimir.Location = New System.Drawing.Point(16, 15)
        Me.BtnImprimir.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(79, 86)
        Me.BtnImprimir.TabIndex = 12
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 54)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 17)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Sucursal"
        '
        'CmbSucursal
        '
        Me.CmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSucursal.FormattingEnabled = True
        Me.CmbSucursal.Location = New System.Drawing.Point(115, 50)
        Me.CmbSucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(365, 24)
        Me.CmbSucursal.TabIndex = 12
        '
        'CmbBodega
        '
        Me.CmbBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBodega.FormattingEnabled = True
        Me.CmbBodega.Location = New System.Drawing.Point(115, 84)
        Me.CmbBodega.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbBodega.Name = "CmbBodega"
        Me.CmbBodega.Size = New System.Drawing.Size(365, 24)
        Me.CmbBodega.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 87)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 17)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Bodega"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkMuestraSaldo)
        Me.GroupBox1.Controls.Add(Me.ChkTodasLasCategorias)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ChkPrecio5)
        Me.GroupBox1.Controls.Add(Me.ChkPrecio4)
        Me.GroupBox1.Controls.Add(Me.ChkPrecioMayoreo)
        Me.GroupBox1.Controls.Add(Me.ChkPrecio3)
        Me.GroupBox1.Controls.Add(Me.ChkPrecioDetalle)
        Me.GroupBox1.Controls.Add(Me.LvwCategorias)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CmbSucursal)
        Me.GroupBox1.Controls.Add(Me.CmbBodega)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(129, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(501, 418)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'ChkTodasLasCategorias
        '
        Me.ChkTodasLasCategorias.AutoSize = True
        Me.ChkTodasLasCategorias.Location = New System.Drawing.Point(115, 186)
        Me.ChkTodasLasCategorias.Name = "ChkTodasLasCategorias"
        Me.ChkTodasLasCategorias.Size = New System.Drawing.Size(164, 21)
        Me.ChkTodasLasCategorias.TabIndex = 23
        Me.ChkTodasLasCategorias.Text = "Todas las Categorías"
        Me.ChkTodasLasCategorias.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 120)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 17)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Precios"
        '
        'ChkPrecio5
        '
        Me.ChkPrecio5.AutoSize = True
        Me.ChkPrecio5.Checked = True
        Me.ChkPrecio5.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPrecio5.Location = New System.Drawing.Point(380, 155)
        Me.ChkPrecio5.Name = "ChkPrecio5"
        Me.ChkPrecio5.Size = New System.Drawing.Size(82, 21)
        Me.ChkPrecio5.TabIndex = 21
        Me.ChkPrecio5.Text = "Precio 5"
        Me.ChkPrecio5.UseVisualStyleBackColor = True
        '
        'ChkPrecio4
        '
        Me.ChkPrecio4.AutoSize = True
        Me.ChkPrecio4.Checked = True
        Me.ChkPrecio4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPrecio4.Location = New System.Drawing.Point(246, 150)
        Me.ChkPrecio4.Name = "ChkPrecio4"
        Me.ChkPrecio4.Size = New System.Drawing.Size(82, 21)
        Me.ChkPrecio4.TabIndex = 20
        Me.ChkPrecio4.Text = "Precio 4"
        Me.ChkPrecio4.UseVisualStyleBackColor = True
        '
        'ChkPrecioMayoreo
        '
        Me.ChkPrecioMayoreo.AutoSize = True
        Me.ChkPrecioMayoreo.Checked = True
        Me.ChkPrecioMayoreo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPrecioMayoreo.Location = New System.Drawing.Point(246, 119)
        Me.ChkPrecioMayoreo.Name = "ChkPrecioMayoreo"
        Me.ChkPrecioMayoreo.Size = New System.Drawing.Size(85, 21)
        Me.ChkPrecioMayoreo.TabIndex = 19
        Me.ChkPrecioMayoreo.Text = "Mayoreo"
        Me.ChkPrecioMayoreo.UseVisualStyleBackColor = True
        '
        'ChkPrecio3
        '
        Me.ChkPrecio3.AutoSize = True
        Me.ChkPrecio3.Checked = True
        Me.ChkPrecio3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPrecio3.Location = New System.Drawing.Point(115, 150)
        Me.ChkPrecio3.Name = "ChkPrecio3"
        Me.ChkPrecio3.Size = New System.Drawing.Size(82, 21)
        Me.ChkPrecio3.TabIndex = 18
        Me.ChkPrecio3.Text = "Precio 3"
        Me.ChkPrecio3.UseVisualStyleBackColor = True
        '
        'ChkPrecioDetalle
        '
        Me.ChkPrecioDetalle.AutoSize = True
        Me.ChkPrecioDetalle.Checked = True
        Me.ChkPrecioDetalle.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPrecioDetalle.Location = New System.Drawing.Point(115, 119)
        Me.ChkPrecioDetalle.Name = "ChkPrecioDetalle"
        Me.ChkPrecioDetalle.Size = New System.Drawing.Size(74, 21)
        Me.ChkPrecioDetalle.TabIndex = 17
        Me.ChkPrecioDetalle.Text = "Detalle"
        Me.ChkPrecioDetalle.UseVisualStyleBackColor = True
        '
        'LvwCategorias
        '
        Me.LvwCategorias.CheckBoxes = True
        Me.LvwCategorias.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.LvwCategorias.FullRowSelect = True
        Me.LvwCategorias.HideSelection = False
        Me.LvwCategorias.Location = New System.Drawing.Point(115, 213)
        Me.LvwCategorias.Name = "LvwCategorias"
        Me.LvwCategorias.Size = New System.Drawing.Size(365, 128)
        Me.LvwCategorias.TabIndex = 16
        Me.LvwCategorias.UseCompatibleStateImageBehavior = False
        Me.LvwCategorias.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Cat Id"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Nombre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 186)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 17)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Categoría"
        '
        'ChkMuestraSaldo
        '
        Me.ChkMuestraSaldo.AutoSize = True
        Me.ChkMuestraSaldo.Checked = True
        Me.ChkMuestraSaldo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkMuestraSaldo.Location = New System.Drawing.Point(115, 366)
        Me.ChkMuestraSaldo.Name = "ChkMuestraSaldo"
        Me.ChkMuestraSaldo.Size = New System.Drawing.Size(121, 21)
        Me.ChkMuestraSaldo.TabIndex = 24
        Me.ChkMuestraSaldo.Text = "Muestra Saldo"
        Me.ChkMuestraSaldo.UseVisualStyleBackColor = True
        '
        'FrmRepListadoPreciosxCategoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(659, 456)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRepListadoPreciosxCategoria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado Precios"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents CmbBodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ChkPrecio5 As CheckBox
    Friend WithEvents ChkPrecio4 As CheckBox
    Friend WithEvents ChkPrecioMayoreo As CheckBox
    Friend WithEvents ChkPrecio3 As CheckBox
    Friend WithEvents ChkPrecioDetalle As CheckBox
    Friend WithEvents LvwCategorias As ListView
    Friend WithEvents Label1 As Label
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ChkTodasLasCategorias As CheckBox
    Friend WithEvents ChkMuestraSaldo As CheckBox
End Class
