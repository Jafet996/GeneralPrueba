<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRepEstadoFacturas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRepEstadoFacturas))
        Me.CmbTipoDocumento = New System.Windows.Forms.ComboBox()
        Me.CmbCaja = New System.Windows.Forms.ComboBox()
        Me.FechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.TxtClienteNombre = New System.Windows.Forms.TextBox()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.FechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.CbCliente = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CbCaja = New System.Windows.Forms.CheckBox()
        Me.CbTipo = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmbTipoDocumento
        '
        Me.CmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoDocumento.Enabled = False
        Me.CmbTipoDocumento.FormattingEnabled = True
        Me.CmbTipoDocumento.Location = New System.Drawing.Point(88, 19)
        Me.CmbTipoDocumento.Name = "CmbTipoDocumento"
        Me.CmbTipoDocumento.Size = New System.Drawing.Size(157, 21)
        Me.CmbTipoDocumento.TabIndex = 22
        '
        'CmbCaja
        '
        Me.CmbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCaja.Enabled = False
        Me.CmbCaja.FormattingEnabled = True
        Me.CmbCaja.Location = New System.Drawing.Point(88, 45)
        Me.CmbCaja.Name = "CmbCaja"
        Me.CmbCaja.Size = New System.Drawing.Size(157, 21)
        Me.CmbCaja.TabIndex = 23
        '
        'FechaInicial
        '
        Me.FechaInicial.CustomFormat = "dd/MM/yyyy"
        Me.FechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.FechaInicial.Location = New System.Drawing.Point(68, 32)
        Me.FechaInicial.Name = "FechaInicial"
        Me.FechaInicial.Size = New System.Drawing.Size(95, 20)
        Me.FechaInicial.TabIndex = 24
        '
        'TxtClienteNombre
        '
        Me.TxtClienteNombre.BackColor = System.Drawing.Color.White
        Me.TxtClienteNombre.Enabled = False
        Me.TxtClienteNombre.Location = New System.Drawing.Point(159, 72)
        Me.TxtClienteNombre.Name = "TxtClienteNombre"
        Me.TxtClienteNombre.ReadOnly = True
        Me.TxtClienteNombre.Size = New System.Drawing.Size(198, 20)
        Me.TxtClienteNombre.TabIndex = 32
        '
        'TxtCliente
        '
        Me.TxtCliente.Enabled = False
        Me.TxtCliente.Location = New System.Drawing.Point(88, 72)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.ReadOnly = True
        Me.TxtCliente.Size = New System.Drawing.Size(67, 20)
        Me.TxtCliente.TabIndex = 31
        '
        'FechaFinal
        '
        Me.FechaFinal.CustomFormat = "dd/MM/yyyy"
        Me.FechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.FechaFinal.Location = New System.Drawing.Point(68, 58)
        Me.FechaFinal.Name = "FechaFinal"
        Me.FechaFinal.Size = New System.Drawing.Size(95, 20)
        Me.FechaFinal.TabIndex = 25
        '
        'CbCliente
        '
        Me.CbCliente.AutoSize = True
        Me.CbCliente.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.CbCliente.Location = New System.Drawing.Point(18, 74)
        Me.CbCliente.Name = "CbCliente"
        Me.CbCliente.Size = New System.Drawing.Size(64, 17)
        Me.CbCliente.TabIndex = 30
        Me.CbCliente.Text = "Cliente :"
        Me.CbCliente.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(24, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Desde"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(24, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Hasta"
        '
        'CbCaja
        '
        Me.CbCaja.AutoSize = True
        Me.CbCaja.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.CbCaja.Location = New System.Drawing.Point(18, 46)
        Me.CbCaja.Name = "CbCaja"
        Me.CbCaja.Size = New System.Drawing.Size(53, 17)
        Me.CbCaja.TabIndex = 29
        Me.CbCaja.Text = "Caja :"
        Me.CbCaja.UseVisualStyleBackColor = True
        '
        'CbTipo
        '
        Me.CbTipo.AutoSize = True
        Me.CbTipo.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.CbTipo.Location = New System.Drawing.Point(18, 20)
        Me.CbTipo.Name = "CbTipo"
        Me.CbTipo.Size = New System.Drawing.Size(53, 17)
        Me.CbTipo.TabIndex = 28
        Me.CbTipo.Text = "Tipo :"
        Me.CbTipo.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnImprimir)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(81, 166)
        Me.Panel1.TabIndex = 33
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
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
        Me.BtnImprimir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnImprimir.Location = New System.Drawing.Point(12, 12)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(59, 70)
        Me.BtnImprimir.TabIndex = 12
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(28, 309)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Salir"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.FechaInicial)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.FechaFinal)
        Me.GroupBox1.Location = New System.Drawing.Point(98, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fechas"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CmbTipoDocumento)
        Me.GroupBox2.Controls.Add(Me.CbTipo)
        Me.GroupBox2.Controls.Add(Me.CbCaja)
        Me.GroupBox2.Controls.Add(Me.CbCliente)
        Me.GroupBox2.Controls.Add(Me.CmbCaja)
        Me.GroupBox2.Controls.Add(Me.TxtCliente)
        Me.GroupBox2.Controls.Add(Me.TxtClienteNombre)
        Me.GroupBox2.Location = New System.Drawing.Point(319, 32)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(365, 100)
        Me.GroupBox2.TabIndex = 35
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Opciones"
        '
        'FrmRepEstadoFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(696, 166)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmRepEstadoFacturas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte estado de facturas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CmbTipoDocumento As ComboBox
    Friend WithEvents CmbCaja As ComboBox
    Friend WithEvents FechaInicial As DateTimePicker
    Friend WithEvents TxtClienteNombre As TextBox
    Friend WithEvents TxtCliente As TextBox
    Friend WithEvents FechaFinal As DateTimePicker
    Friend WithEvents CbCliente As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents CbCaja As CheckBox
    Friend WithEvents CbTipo As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
End Class
