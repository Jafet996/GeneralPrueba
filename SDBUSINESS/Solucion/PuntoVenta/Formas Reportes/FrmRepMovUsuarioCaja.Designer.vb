<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRepMovUsuarioCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRepMovUsuarioCaja))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dpHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dpDesde = New System.Windows.Forms.DateTimePicker()
        Me.ckbUsuario = New System.Windows.Forms.CheckBox()
        Me.ckbCaja = New System.Windows.Forms.CheckBox()
        Me.CmbUsuario = New System.Windows.Forms.ComboBox()
        Me.CmbSucursal = New System.Windows.Forms.ComboBox()
        Me.CmbCaja = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dpHasta)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dpDesde)
        Me.GroupBox1.Controls.Add(Me.ckbUsuario)
        Me.GroupBox1.Controls.Add(Me.ckbCaja)
        Me.GroupBox1.Controls.Add(Me.CmbUsuario)
        Me.GroupBox1.Controls.Add(Me.CmbSucursal)
        Me.GroupBox1.Controls.Add(Me.CmbCaja)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(92, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(376, 146)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        '
        'dpHasta
        '
        Me.dpHasta.CustomFormat = "dd/MM/yyyy"
        Me.dpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpHasta.Location = New System.Drawing.Point(264, 107)
        Me.dpHasta.Name = "dpHasta"
        Me.dpHasta.Size = New System.Drawing.Size(98, 20)
        Me.dpHasta.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(215, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Desde"
        '
        'dpDesde
        '
        Me.dpDesde.CustomFormat = "dd/MM/yyyy"
        Me.dpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpDesde.Location = New System.Drawing.Point(98, 107)
        Me.dpDesde.Name = "dpDesde"
        Me.dpDesde.Size = New System.Drawing.Size(98, 20)
        Me.dpDesde.TabIndex = 19
        '
        'ckbUsuario
        '
        Me.ckbUsuario.AutoSize = True
        Me.ckbUsuario.Checked = True
        Me.ckbUsuario.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbUsuario.Location = New System.Drawing.Point(23, 82)
        Me.ckbUsuario.Name = "ckbUsuario"
        Me.ckbUsuario.Size = New System.Drawing.Size(69, 17)
        Me.ckbUsuario.TabIndex = 18
        Me.ckbUsuario.Text = "Usuario"
        Me.ckbUsuario.UseVisualStyleBackColor = True
        '
        'ckbCaja
        '
        Me.ckbCaja.AutoSize = True
        Me.ckbCaja.Checked = True
        Me.ckbCaja.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbCaja.Location = New System.Drawing.Point(23, 55)
        Me.ckbCaja.Name = "ckbCaja"
        Me.ckbCaja.Size = New System.Drawing.Size(51, 17)
        Me.ckbCaja.TabIndex = 17
        Me.ckbCaja.Text = "Caja"
        Me.ckbCaja.UseVisualStyleBackColor = True
        '
        'CmbUsuario
        '
        Me.CmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbUsuario.FormattingEnabled = True
        Me.CmbUsuario.Location = New System.Drawing.Point(98, 80)
        Me.CmbUsuario.Name = "CmbUsuario"
        Me.CmbUsuario.Size = New System.Drawing.Size(264, 21)
        Me.CmbUsuario.TabIndex = 16
        '
        'CmbSucursal
        '
        Me.CmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSucursal.FormattingEnabled = True
        Me.CmbSucursal.Location = New System.Drawing.Point(98, 26)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(264, 21)
        Me.CmbSucursal.TabIndex = 12
        '
        'CmbCaja
        '
        Me.CmbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCaja.FormattingEnabled = True
        Me.CmbCaja.Location = New System.Drawing.Point(98, 53)
        Me.CmbCaja.Name = "CmbCaja"
        Me.CmbCaja.Size = New System.Drawing.Size(264, 21)
        Me.CmbCaja.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Sucursal"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnImprimir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(81, 171)
        Me.Panel1.TabIndex = 17
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(12, 88)
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
        'FrmRepMovUsuarioCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(480, 171)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRepMovUsuarioCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movimientos por Usuario y Caja"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CmbUsuario As ComboBox
    Friend WithEvents CmbSucursal As ComboBox
    Friend WithEvents CmbCaja As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents ckbUsuario As CheckBox
    Friend WithEvents ckbCaja As CheckBox
    Friend WithEvents dpHasta As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dpDesde As DateTimePicker
End Class
