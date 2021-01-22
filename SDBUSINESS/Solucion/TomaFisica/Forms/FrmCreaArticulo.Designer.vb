<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCreaArticulo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCreaArticulo))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
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
        Me.TabPrincipal = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PanelGeneral1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ChkSuelto = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtPrecio = New System.Windows.Forms.TextBox()
        Me.ImgLstBodegas = New System.Windows.Forms.ImageList(Me.components)
        Me.BtnRefrescar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.TabPrincipal.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.PanelGeneral1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Panel1.Controls.Add(Me.BtnRefrescar)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.BtnLimpiar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnGuardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(85, 347)
        Me.Panel1.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 262)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "F11 = Guardar"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 320)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "ESC = Salir"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 290)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "F12 = Limpiar"
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.Location = New System.Drawing.Point(4, 56)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(75, 38)
        Me.BtnLimpiar.TabIndex = 12
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.UseVisualStyleBackColor = True
        '
        'BtnSalir
        '
        Me.BtnSalir.Location = New System.Drawing.Point(4, 144)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(75, 38)
        Me.BtnSalir.TabIndex = 13
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Location = New System.Drawing.Point(4, 12)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(75, 38)
        Me.BtnGuardar.TabIndex = 11
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Código"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Location = New System.Drawing.Point(117, 32)
        Me.TxtCodigo.MaxLength = 13
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(121, 20)
        Me.TxtCodigo.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nombre"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(102, 3)
        Me.TxtNombre.MaxLength = 50
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(456, 20)
        Me.TxtNombre.TabIndex = 1
        '
        'CmbCategoria
        '
        Me.CmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCategoria.FormattingEnabled = True
        Me.CmbCategoria.Location = New System.Drawing.Point(102, 81)
        Me.CmbCategoria.Name = "CmbCategoria"
        Me.CmbCategoria.Size = New System.Drawing.Size(175, 21)
        Me.CmbCategoria.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Categoría"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Sub Categoría"
        '
        'CmbSubCategoria
        '
        Me.CmbSubCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSubCategoria.FormattingEnabled = True
        Me.CmbSubCategoria.Location = New System.Drawing.Point(102, 108)
        Me.CmbSubCategoria.Name = "CmbSubCategoria"
        Me.CmbSubCategoria.Size = New System.Drawing.Size(175, 21)
        Me.CmbSubCategoria.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(298, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Unidad Medida"
        '
        'CmbUnidadMedida
        '
        Me.CmbUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbUnidadMedida.FormattingEnabled = True
        Me.CmbUnidadMedida.Location = New System.Drawing.Point(383, 108)
        Me.CmbUnidadMedida.Name = "CmbUnidadMedida"
        Me.CmbUnidadMedida.Size = New System.Drawing.Size(175, 21)
        Me.CmbUnidadMedida.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(298, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Departamento"
        '
        'CmbDepartamento
        '
        Me.CmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbDepartamento.FormattingEnabled = True
        Me.CmbDepartamento.Location = New System.Drawing.Point(383, 81)
        Me.CmbDepartamento.Name = "CmbDepartamento"
        Me.CmbDepartamento.Size = New System.Drawing.Size(175, 21)
        Me.CmbDepartamento.TabIndex = 6
        '
        'TxtFactorConversion
        '
        Me.TxtFactorConversion.Location = New System.Drawing.Point(102, 33)
        Me.TxtFactorConversion.MaxLength = 13
        Me.TxtFactorConversion.Name = "TxtFactorConversion"
        Me.TxtFactorConversion.Size = New System.Drawing.Size(80, 20)
        Me.TxtFactorConversion.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Cantidad Paquete"
        '
        'ChkExento
        '
        Me.ChkExento.AutoSize = True
        Me.ChkExento.Location = New System.Drawing.Point(30, 41)
        Me.ChkExento.Name = "ChkExento"
        Me.ChkExento.Size = New System.Drawing.Size(59, 17)
        Me.ChkExento.TabIndex = 8
        Me.ChkExento.Text = "Exento"
        Me.ChkExento.UseVisualStyleBackColor = True
        '
        'TabPrincipal
        '
        Me.TabPrincipal.Controls.Add(Me.TabPage1)
        Me.TabPrincipal.Location = New System.Drawing.Point(91, 12)
        Me.TabPrincipal.Name = "TabPrincipal"
        Me.TabPrincipal.SelectedIndex = 0
        Me.TabPrincipal.Size = New System.Drawing.Size(599, 334)
        Me.TabPrincipal.TabIndex = 25
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PanelGeneral1)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.TxtCodigo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(591, 308)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General 1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PanelGeneral1
        '
        Me.PanelGeneral1.Controls.Add(Me.GroupBox2)
        Me.PanelGeneral1.Controls.Add(Me.GroupBox1)
        Me.PanelGeneral1.Controls.Add(Me.Label11)
        Me.PanelGeneral1.Controls.Add(Me.CmbDepartamento)
        Me.PanelGeneral1.Controls.Add(Me.Label2)
        Me.PanelGeneral1.Controls.Add(Me.CmbSubCategoria)
        Me.PanelGeneral1.Controls.Add(Me.TxtPrecio)
        Me.PanelGeneral1.Controls.Add(Me.Label4)
        Me.PanelGeneral1.Controls.Add(Me.TxtNombre)
        Me.PanelGeneral1.Controls.Add(Me.Label3)
        Me.PanelGeneral1.Controls.Add(Me.TxtFactorConversion)
        Me.PanelGeneral1.Controls.Add(Me.Label5)
        Me.PanelGeneral1.Controls.Add(Me.Label7)
        Me.PanelGeneral1.Controls.Add(Me.Label6)
        Me.PanelGeneral1.Controls.Add(Me.CmbCategoria)
        Me.PanelGeneral1.Controls.Add(Me.CmbUnidadMedida)
        Me.PanelGeneral1.Location = New System.Drawing.Point(15, 58)
        Me.PanelGeneral1.Name = "PanelGeneral1"
        Me.PanelGeneral1.Size = New System.Drawing.Size(564, 245)
        Me.PanelGeneral1.TabIndex = 27
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ChkSuelto)
        Me.GroupBox2.Location = New System.Drawing.Point(283, 154)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(275, 88)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Suelto"
        '
        'ChkSuelto
        '
        Me.ChkSuelto.AutoSize = True
        Me.ChkSuelto.Location = New System.Drawing.Point(27, 40)
        Me.ChkSuelto.Name = "ChkSuelto"
        Me.ChkSuelto.Size = New System.Drawing.Size(96, 17)
        Me.ChkSuelto.TabIndex = 0
        Me.ChkSuelto.Text = "Artículo Suelto"
        Me.ChkSuelto.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkExento)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 153)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(271, 88)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opciones"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(421, 37)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Precio"
        '
        'TxtPrecio
        '
        Me.TxtPrecio.Location = New System.Drawing.Point(480, 33)
        Me.TxtPrecio.Name = "TxtPrecio"
        Me.TxtPrecio.Size = New System.Drawing.Size(78, 20)
        Me.TxtPrecio.TabIndex = 3
        Me.TxtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ImgLstBodegas
        '
        Me.ImgLstBodegas.ImageStream = CType(resources.GetObject("ImgLstBodegas.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgLstBodegas.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgLstBodegas.Images.SetKeyName(0, "Company-Building.ico")
        Me.ImgLstBodegas.Images.SetKeyName(1, "House (2).ico")
        Me.ImgLstBodegas.Images.SetKeyName(2, "box_closed.ico")
        Me.ImgLstBodegas.Images.SetKeyName(3, "arrow_right_blue.ico")
        '
        'BtnRefrescar
        '
        Me.BtnRefrescar.Location = New System.Drawing.Point(4, 100)
        Me.BtnRefrescar.Name = "BtnRefrescar"
        Me.BtnRefrescar.Size = New System.Drawing.Size(75, 38)
        Me.BtnRefrescar.TabIndex = 16
        Me.BtnRefrescar.Text = "Refrescar"
        Me.BtnRefrescar.UseVisualStyleBackColor = True
        '
        'FrmCreaArticulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 347)
        Me.Controls.Add(Me.TabPrincipal)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCreaArticulo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Artículos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabPrincipal.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.PanelGeneral1.ResumeLayout(False)
        Me.PanelGeneral1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

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
    Friend WithEvents TabPrincipal As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents ImgLstBodegas As System.Windows.Forms.ImageList
    Friend WithEvents TxtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PanelGeneral1 As System.Windows.Forms.Panel
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkSuelto As System.Windows.Forms.CheckBox
    Friend WithEvents BtnRefrescar As System.Windows.Forms.Button
End Class
