<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGeneraEtiquetaMediKam
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGeneraEtiquetaMediKam))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DtpVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.TxtLote = New System.Windows.Forms.TextBox()
        Me.CmbNombreMostrar = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmbCodigoMostrar = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbMoneda = New System.Windows.Forms.ComboBox()
        Me.TxtArticulo = New System.Windows.Forms.TextBox()
        Me.TxtArticuloNombre = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DtpVencimiento)
        Me.GroupBox1.Controls.Add(Me.TxtLote)
        Me.GroupBox1.Controls.Add(Me.CmbNombreMostrar)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.CmbCodigoMostrar)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CmbMoneda)
        Me.GroupBox1.Controls.Add(Me.TxtArticulo)
        Me.GroupBox1.Controls.Add(Me.TxtArticuloNombre)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(100, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(390, 254)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        '
        'DtpVencimiento
        '
        Me.DtpVencimiento.CustomFormat = "dd/MM/yy"
        Me.DtpVencimiento.Enabled = False
        Me.DtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpVencimiento.Location = New System.Drawing.Point(9, 101)
        Me.DtpVencimiento.Name = "DtpVencimiento"
        Me.DtpVencimiento.Size = New System.Drawing.Size(175, 20)
        Me.DtpVencimiento.TabIndex = 35
        '
        'TxtLote
        '
        Me.TxtLote.BackColor = System.Drawing.Color.White
        Me.TxtLote.Enabled = False
        Me.TxtLote.Location = New System.Drawing.Point(190, 101)
        Me.TxtLote.MaxLength = 13
        Me.TxtLote.Name = "TxtLote"
        Me.TxtLote.Size = New System.Drawing.Size(194, 20)
        Me.TxtLote.TabIndex = 34
        '
        'CmbNombreMostrar
        '
        Me.CmbNombreMostrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbNombreMostrar.FormattingEnabled = True
        Me.CmbNombreMostrar.Location = New System.Drawing.Point(9, 209)
        Me.CmbNombreMostrar.Name = "CmbNombreMostrar"
        Me.CmbNombreMostrar.Size = New System.Drawing.Size(375, 21)
        Me.CmbNombreMostrar.TabIndex = 33
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 190)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 13)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Nombre a mostrar."
        '
        'CmbCodigoMostrar
        '
        Me.CmbCodigoMostrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCodigoMostrar.FormattingEnabled = True
        Me.CmbCodigoMostrar.Location = New System.Drawing.Point(190, 155)
        Me.CmbCodigoMostrar.Name = "CmbCodigoMostrar"
        Me.CmbCodigoMostrar.Size = New System.Drawing.Size(194, 21)
        Me.CmbCodigoMostrar.TabIndex = 31
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(190, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Código a mostrar."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Fecha vencimiento."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(190, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Lote."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Moneda."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Código del articulo."
        '
        'CmbMoneda
        '
        Me.CmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMoneda.FormattingEnabled = True
        Me.CmbMoneda.Items.AddRange(New Object() {"Colones", "Dólares"})
        Me.CmbMoneda.Location = New System.Drawing.Point(9, 155)
        Me.CmbMoneda.Name = "CmbMoneda"
        Me.CmbMoneda.Size = New System.Drawing.Size(175, 21)
        Me.CmbMoneda.TabIndex = 22
        '
        'TxtArticulo
        '
        Me.TxtArticulo.Location = New System.Drawing.Point(9, 50)
        Me.TxtArticulo.MaxLength = 13
        Me.TxtArticulo.Name = "TxtArticulo"
        Me.TxtArticulo.Size = New System.Drawing.Size(121, 20)
        Me.TxtArticulo.TabIndex = 20
        '
        'TxtArticuloNombre
        '
        Me.TxtArticuloNombre.Location = New System.Drawing.Point(136, 50)
        Me.TxtArticuloNombre.MaxLength = 50
        Me.TxtArticuloNombre.Name = "TxtArticuloNombre"
        Me.TxtArticuloNombre.ReadOnly = True
        Me.TxtArticuloNombre.Size = New System.Drawing.Size(248, 20)
        Me.TxtArticuloNombre.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Artículo"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnImprimir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(81, 374)
        Me.Panel1.TabIndex = 20
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Inventario.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(12, 85)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(59, 70)
        Me.BtnSalir.TabIndex = 13
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnImprimir
        '
        Me.BtnImprimir.BackColor = System.Drawing.Color.White
        Me.BtnImprimir.Image = Global.Inventario.My.Resources.Resources.Blue_F3
        Me.BtnImprimir.Location = New System.Drawing.Point(12, 12)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(59, 70)
        Me.BtnImprimir.TabIndex = 12
        Me.BtnImprimir.Text = "Generar"
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(244, 310)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 16)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Código Formado"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.BackColor = System.Drawing.Color.White
        Me.TxtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigo.Location = New System.Drawing.Point(101, 272)
        Me.TxtCodigo.MaxLength = 13
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.ReadOnly = True
        Me.TxtCodigo.Size = New System.Drawing.Size(390, 20)
        Me.TxtCodigo.TabIndex = 34
        Me.TxtCodigo.Text = "(01)(17)(21)"
        Me.TxtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FrmGeneraEtiquetaMediKam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(503, 374)
        Me.Controls.Add(Me.TxtCodigo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGeneraEtiquetaMediKam"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generacion de Etiquetas CCSS"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CmbNombreMostrar As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents CmbCodigoMostrar As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CmbMoneda As ComboBox
    Friend WithEvents TxtArticulo As TextBox
    Friend WithEvents TxtArticuloNombre As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtCodigo As TextBox
    Friend WithEvents DtpVencimiento As DateTimePicker
    Friend WithEvents TxtLote As TextBox
End Class
