<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRepComisionxVendedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRepComisionxVendedor))
        Me.CmbVendedor = New System.Windows.Forms.ComboBox()
        Me.ChkTodos = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DtpPFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DtpPFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.CmbTipo = New System.Windows.Forms.ComboBox()
        Me.Tipo = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmbVendedor
        '
        Me.CmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbVendedor.FormattingEnabled = True
        Me.CmbVendedor.Location = New System.Drawing.Point(211, 83)
        Me.CmbVendedor.Name = "CmbVendedor"
        Me.CmbVendedor.Size = New System.Drawing.Size(228, 21)
        Me.CmbVendedor.TabIndex = 12
        '
        'ChkTodos
        '
        Me.ChkTodos.AutoSize = True
        Me.ChkTodos.Checked = True
        Me.ChkTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkTodos.Location = New System.Drawing.Point(149, 85)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(56, 17)
        Me.ChkTodos.TabIndex = 11
        Me.ChkTodos.Text = "Todos"
        Me.ChkTodos.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnImprimir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(81, 170)
        Me.Panel1.TabIndex = 13
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(300, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Hasta"
        '
        'DtpPFechaFin
        '
        Me.DtpPFechaFin.CustomFormat = "dd/MM/yyyy"
        Me.DtpPFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpPFechaFin.Location = New System.Drawing.Point(344, 126)
        Me.DtpPFechaFin.Name = "DtpPFechaFin"
        Me.DtpPFechaFin.Size = New System.Drawing.Size(95, 20)
        Me.DtpPFechaFin.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(146, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Desde"
        '
        'DtpPFechaIni
        '
        Me.DtpPFechaIni.CustomFormat = "dd/MM/yyyy"
        Me.DtpPFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpPFechaIni.Location = New System.Drawing.Point(190, 126)
        Me.DtpPFechaIni.Name = "DtpPFechaIni"
        Me.DtpPFechaIni.Size = New System.Drawing.Size(95, 20)
        Me.DtpPFechaIni.TabIndex = 14
        '
        'CmbTipo
        '
        Me.CmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipo.FormattingEnabled = True
        Me.CmbTipo.Items.AddRange(New Object() {"VENTAS GENERALES", "POR PROVEEDOR", "POR SERVICIOS"})
        Me.CmbTipo.Location = New System.Drawing.Point(211, 41)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(228, 21)
        Me.CmbTipo.TabIndex = 18
        '
        'Tipo
        '
        Me.Tipo.AutoSize = True
        Me.Tipo.Location = New System.Drawing.Point(166, 41)
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Size = New System.Drawing.Size(28, 13)
        Me.Tipo.TabIndex = 19
        Me.Tipo.Text = "Tipo"
        '
        'FrmRepComisionxVendedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(503, 170)
        Me.Controls.Add(Me.Tipo)
        Me.Controls.Add(Me.CmbTipo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DtpPFechaFin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DtpPFechaIni)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CmbVendedor)
        Me.Controls.Add(Me.ChkTodos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRepComisionxVendedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comisión por Vendedor"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CmbVendedor As ComboBox
    Friend WithEvents ChkTodos As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents DtpPFechaFin As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents DtpPFechaIni As DateTimePicker
    Friend WithEvents Tipo As Label
    Friend WithEvents CmbTipo As ComboBox
End Class
