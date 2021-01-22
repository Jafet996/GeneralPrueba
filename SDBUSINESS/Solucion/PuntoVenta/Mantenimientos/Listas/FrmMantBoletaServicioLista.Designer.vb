<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantBoletaServicioLista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantBoletaServicioLista))
        Me.GroupOpciones = New System.Windows.Forms.GroupBox()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnControl = New System.Windows.Forms.Button()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.BtnAsignar = New System.Windows.Forms.Button()
        Me.BtnModificar = New System.Windows.Forms.Button()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.DGDetalle = New System.Windows.Forms.DataGridView()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DpHasta = New System.Windows.Forms.DateTimePicker()
        Me.DpDesde = New System.Windows.Forms.DateTimePicker()
        Me.CkbEstado = New System.Windows.Forms.CheckBox()
        Me.CmbEstado = New System.Windows.Forms.ComboBox()
        Me.TxtBoleta = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCliente = New System.Windows.Forms.Button()
        Me.GroupOpciones.SuspendLayout()
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupOpciones
        '
        Me.GroupOpciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.GroupOpciones.Controls.Add(Me.btnCliente)
        Me.GroupOpciones.Controls.Add(Me.BtnImprimir)
        Me.GroupOpciones.Controls.Add(Me.BtnControl)
        Me.GroupOpciones.Controls.Add(Me.BtnCerrar)
        Me.GroupOpciones.Controls.Add(Me.BtnAsignar)
        Me.GroupOpciones.Controls.Add(Me.BtnModificar)
        Me.GroupOpciones.Controls.Add(Me.BtnNuevo)
        Me.GroupOpciones.Controls.Add(Me.BtnSalir)
        Me.GroupOpciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupOpciones.Location = New System.Drawing.Point(0, 0)
        Me.GroupOpciones.Name = "GroupOpciones"
        Me.GroupOpciones.Size = New System.Drawing.Size(83, 637)
        Me.GroupOpciones.TabIndex = 7
        Me.GroupOpciones.TabStop = False
        '
        'BtnImprimir
        '
        Me.BtnImprimir.BackColor = System.Drawing.Color.White
        Me.BtnImprimir.Enabled = False
        Me.BtnImprimir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F6
        Me.BtnImprimir.Location = New System.Drawing.Point(12, 320)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(63, 71)
        Me.BtnImprimir.TabIndex = 6
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'BtnControl
        '
        Me.BtnControl.BackColor = System.Drawing.Color.White
        Me.BtnControl.Enabled = False
        Me.BtnControl.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F7
        Me.BtnControl.Location = New System.Drawing.Point(12, 397)
        Me.BtnControl.Name = "BtnControl"
        Me.BtnControl.Size = New System.Drawing.Size(63, 71)
        Me.BtnControl.TabIndex = 5
        Me.BtnControl.Text = "Control"
        Me.BtnControl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnControl.UseVisualStyleBackColor = False
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackColor = System.Drawing.Color.White
        Me.BtnCerrar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F5
        Me.BtnCerrar.Location = New System.Drawing.Point(12, 243)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(63, 71)
        Me.BtnCerrar.TabIndex = 4
        Me.BtnCerrar.Text = "Cerrar"
        Me.BtnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'BtnAsignar
        '
        Me.BtnAsignar.BackColor = System.Drawing.Color.White
        Me.BtnAsignar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F4
        Me.BtnAsignar.Location = New System.Drawing.Point(12, 166)
        Me.BtnAsignar.Name = "BtnAsignar"
        Me.BtnAsignar.Size = New System.Drawing.Size(63, 71)
        Me.BtnAsignar.TabIndex = 3
        Me.BtnAsignar.Text = "Asignar"
        Me.BtnAsignar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAsignar.UseVisualStyleBackColor = False
        '
        'BtnModificar
        '
        Me.BtnModificar.BackColor = System.Drawing.Color.White
        Me.BtnModificar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnModificar.Location = New System.Drawing.Point(12, 89)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(63, 71)
        Me.BtnModificar.TabIndex = 2
        Me.BtnModificar.Text = "Modificar"
        Me.BtnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnModificar.UseVisualStyleBackColor = False
        '
        'BtnNuevo
        '
        Me.BtnNuevo.BackColor = System.Drawing.Color.White
        Me.BtnNuevo.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F2
        Me.BtnNuevo.Location = New System.Drawing.Point(12, 12)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(63, 71)
        Me.BtnNuevo.TabIndex = 0
        Me.BtnNuevo.Text = "Nuevo"
        Me.BtnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnNuevo.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(12, 551)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(63, 71)
        Me.BtnSalir.TabIndex = 1
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'DGDetalle
        '
        Me.DGDetalle.AllowUserToAddRows = False
        Me.DGDetalle.AllowUserToDeleteRows = False
        Me.DGDetalle.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.DGDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDetalle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DGDetalle.Location = New System.Drawing.Point(83, 111)
        Me.DGDetalle.MultiSelect = False
        Me.DGDetalle.Name = "DGDetalle"
        Me.DGDetalle.ReadOnly = True
        Me.DGDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DGDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGDetalle.Size = New System.Drawing.Size(869, 526)
        Me.DGDetalle.TabIndex = 8
        '
        'TxtNombre
        '
        Me.TxtNombre.BackColor = System.Drawing.Color.White
        Me.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombre.Location = New System.Drawing.Point(166, 19)
        Me.TxtNombre.MaxLength = 50
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(268, 20)
        Me.TxtNombre.TabIndex = 54
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(121, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Cliente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(121, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Desde "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(293, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Hasta"
        '
        'DpHasta
        '
        Me.DpHasta.CustomFormat = "dd/MM/yyyy"
        Me.DpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DpHasta.Location = New System.Drawing.Point(334, 49)
        Me.DpHasta.Name = "DpHasta"
        Me.DpHasta.Size = New System.Drawing.Size(100, 20)
        Me.DpHasta.TabIndex = 58
        '
        'DpDesde
        '
        Me.DpDesde.CustomFormat = "dd/MM/yyyy"
        Me.DpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DpDesde.Location = New System.Drawing.Point(166, 49)
        Me.DpDesde.Name = "DpDesde"
        Me.DpDesde.Size = New System.Drawing.Size(100, 20)
        Me.DpDesde.TabIndex = 59
        '
        'CkbEstado
        '
        Me.CkbEstado.AutoSize = True
        Me.CkbEstado.Location = New System.Drawing.Point(460, 52)
        Me.CkbEstado.Name = "CkbEstado"
        Me.CkbEstado.Size = New System.Drawing.Size(59, 17)
        Me.CkbEstado.TabIndex = 60
        Me.CkbEstado.Text = "Estado"
        Me.CkbEstado.UseVisualStyleBackColor = True
        '
        'CmbEstado
        '
        Me.CmbEstado.BackColor = System.Drawing.Color.White
        Me.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEstado.Enabled = False
        Me.CmbEstado.FormattingEnabled = True
        Me.CmbEstado.Location = New System.Drawing.Point(525, 48)
        Me.CmbEstado.Name = "CmbEstado"
        Me.CmbEstado.Size = New System.Drawing.Size(100, 21)
        Me.CmbEstado.TabIndex = 83
        '
        'TxtBoleta
        '
        Me.TxtBoleta.BackColor = System.Drawing.Color.White
        Me.TxtBoleta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBoleta.Location = New System.Drawing.Point(525, 19)
        Me.TxtBoleta.MaxLength = 50
        Me.TxtBoleta.Name = "TxtBoleta"
        Me.TxtBoleta.Size = New System.Drawing.Size(100, 20)
        Me.TxtBoleta.TabIndex = 84
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(457, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "# Boleta"
        '
        'btnCliente
        '
        Me.btnCliente.BackColor = System.Drawing.Color.White
        Me.btnCliente.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F8
        Me.btnCliente.Location = New System.Drawing.Point(12, 474)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(63, 71)
        Me.btnCliente.TabIndex = 7
        Me.btnCliente.Text = "Cliente"
        Me.btnCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCliente.UseVisualStyleBackColor = False
        '
        'FrmMantBoletaServicioLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(952, 637)
        Me.Controls.Add(Me.TxtBoleta)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CmbEstado)
        Me.Controls.Add(Me.CkbEstado)
        Me.Controls.Add(Me.DpDesde)
        Me.Controls.Add(Me.DpHasta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DGDetalle)
        Me.Controls.Add(Me.GroupOpciones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantBoletaServicioLista"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Boletas de Servicio"
        Me.GroupOpciones.ResumeLayout(False)
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupOpciones As GroupBox
    Friend WithEvents BtnModificar As Button
    Friend WithEvents BtnNuevo As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnCerrar As Button
    Friend WithEvents BtnAsignar As Button
    Friend WithEvents DGDetalle As DataGridView
    Friend WithEvents TxtNombre As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DpHasta As DateTimePicker
    Friend WithEvents DpDesde As DateTimePicker
    Friend WithEvents CkbEstado As CheckBox
    Friend WithEvents CmbEstado As ComboBox
    Friend WithEvents TxtBoleta As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnControl As Button
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents btnCliente As Button
End Class
