<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantUsuarioCodigoPermisoDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantUsuarioCodigoPermisoDetalle))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GbUsuarioConectado = New System.Windows.Forms.GroupBox()
        Me.LblUsuarioNombre = New System.Windows.Forms.Label()
        Me.PnlCodigos = New System.Windows.Forms.Panel()
        Me.LvwCodigos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCantidad = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtpFechaVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnGenerar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GbUsuarioConectado.SuspendLayout()
        Me.PnlCodigos.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnImprimir)
        Me.Panel1.Controls.Add(Me.BtnGenerar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(85, 419)
        Me.Panel1.TabIndex = 53
        '
        'GbUsuarioConectado
        '
        Me.GbUsuarioConectado.Controls.Add(Me.LblUsuarioNombre)
        Me.GbUsuarioConectado.Location = New System.Drawing.Point(92, 13)
        Me.GbUsuarioConectado.Name = "GbUsuarioConectado"
        Me.GbUsuarioConectado.Size = New System.Drawing.Size(491, 46)
        Me.GbUsuarioConectado.TabIndex = 54
        Me.GbUsuarioConectado.TabStop = False
        Me.GbUsuarioConectado.Text = "Usuario Conectado"
        '
        'LblUsuarioNombre
        '
        Me.LblUsuarioNombre.AutoSize = True
        Me.LblUsuarioNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsuarioNombre.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblUsuarioNombre.Location = New System.Drawing.Point(60, 20)
        Me.LblUsuarioNombre.Name = "LblUsuarioNombre"
        Me.LblUsuarioNombre.Size = New System.Drawing.Size(55, 16)
        Me.LblUsuarioNombre.TabIndex = 0
        Me.LblUsuarioNombre.Text = "Label1"
        '
        'PnlCodigos
        '
        Me.PnlCodigos.Controls.Add(Me.LvwCodigos)
        Me.PnlCodigos.Location = New System.Drawing.Point(92, 91)
        Me.PnlCodigos.Name = "PnlCodigos"
        Me.PnlCodigos.Size = New System.Drawing.Size(491, 323)
        Me.PnlCodigos.TabIndex = 55
        '
        'LvwCodigos
        '
        Me.LvwCodigos.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.LvwCodigos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.LvwCodigos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvwCodigos.FullRowSelect = True
        Me.LvwCodigos.Location = New System.Drawing.Point(0, 0)
        Me.LvwCodigos.Name = "LvwCodigos"
        Me.LvwCodigos.Size = New System.Drawing.Size(491, 323)
        Me.LvwCodigos.TabIndex = 0
        Me.LvwCodigos.UseCompatibleStateImageBehavior = False
        Me.LvwCodigos.View = System.Windows.Forms.View.Details
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(91, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 13)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Cantidad Códigos Nuevos"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(227, 67)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(76, 20)
        Me.TxtCantidad.TabIndex = 58
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(320, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "Fecha de Vencimiento"
        '
        'DtpFechaVencimiento
        '
        Me.DtpFechaVencimiento.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaVencimiento.Location = New System.Drawing.Point(440, 67)
        Me.DtpFechaVencimiento.Name = "DtpFechaVencimiento"
        Me.DtpFechaVencimiento.Size = New System.Drawing.Size(143, 20)
        Me.DtpFechaVencimiento.TabIndex = 60
        '
        'BtnImprimir
        '
        Me.BtnImprimir.BackColor = System.Drawing.Color.White
        Me.BtnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImprimir.ForeColor = System.Drawing.Color.Black
        Me.BtnImprimir.Image = Global.SDCXP.My.Resources.Resources.Blue_F4
        Me.BtnImprimir.Location = New System.Drawing.Point(8, 89)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(69, 72)
        Me.BtnImprimir.TabIndex = 14
        Me.BtnImprimir.TabStop = False
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'BtnGenerar
        '
        Me.BtnGenerar.BackColor = System.Drawing.Color.White
        Me.BtnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGenerar.ForeColor = System.Drawing.Color.Black
        Me.BtnGenerar.Image = Global.SDCXP.My.Resources.Resources.Blue_F3
        Me.BtnGenerar.Location = New System.Drawing.Point(8, 11)
        Me.BtnGenerar.Name = "BtnGenerar"
        Me.BtnGenerar.Size = New System.Drawing.Size(69, 72)
        Me.BtnGenerar.TabIndex = 13
        Me.BtnGenerar.TabStop = False
        Me.BtnGenerar.Text = "Generar"
        Me.BtnGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnGenerar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = Global.SDCXP.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(8, 167)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(69, 72)
        Me.BtnSalir.TabIndex = 12
        Me.BtnSalir.TabStop = False
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'FrmMantUsuarioCodigoPermisoDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(588, 419)
        Me.Controls.Add(Me.DtpFechaVencimiento)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCantidad)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PnlCodigos)
        Me.Controls.Add(Me.GbUsuarioConectado)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantUsuarioCodigoPermisoDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar Códigos de Acceso"
        Me.Panel1.ResumeLayout(False)
        Me.GbUsuarioConectado.ResumeLayout(False)
        Me.GbUsuarioConectado.PerformLayout()
        Me.PnlCodigos.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnGenerar As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents GbUsuarioConectado As System.Windows.Forms.GroupBox
    Friend WithEvents LblUsuarioNombre As System.Windows.Forms.Label
    Friend WithEvents PnlCodigos As System.Windows.Forms.Panel
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents LvwCodigos As System.Windows.Forms.ListView
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpFechaVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
End Class
