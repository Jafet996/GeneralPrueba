<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRepVentasXHoraXCategoria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRepVentasXHoraXCategoria))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DtpPFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DtpPFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DpHoraFin = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DpHoraIni = New System.Windows.Forms.DateTimePicker()
        Me.CmbCategoria = New System.Windows.Forms.ComboBox()
        Me.CbkCategoria = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnImprimir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(81, 169)
        Me.Panel1.TabIndex = 19
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
        Me.Label4.Location = New System.Drawing.Point(293, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Hasta"
        '
        'DtpPFechaFin
        '
        Me.DtpPFechaFin.CustomFormat = "dd/MM/yyyy"
        Me.DtpPFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpPFechaFin.Location = New System.Drawing.Point(346, 35)
        Me.DtpPFechaFin.Name = "DtpPFechaFin"
        Me.DtpPFechaFin.Size = New System.Drawing.Size(95, 20)
        Me.DtpPFechaFin.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(120, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Desde"
        '
        'DtpPFechaIni
        '
        Me.DtpPFechaIni.CustomFormat = "dd/MM/yyyy"
        Me.DtpPFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpPFechaIni.Location = New System.Drawing.Point(186, 35)
        Me.DtpPFechaIni.Name = "DtpPFechaIni"
        Me.DtpPFechaIni.Size = New System.Drawing.Size(95, 20)
        Me.DtpPFechaIni.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(293, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Hora Fin"
        '
        'DpHoraFin
        '
        Me.DpHoraFin.CustomFormat = "HH:mm"
        Me.DpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DpHoraFin.Location = New System.Drawing.Point(346, 67)
        Me.DpHoraFin.Name = "DpHoraFin"
        Me.DpHoraFin.Size = New System.Drawing.Size(95, 20)
        Me.DpHoraFin.TabIndex = 26
        Me.DpHoraFin.Value = New Date(2018, 8, 13, 23, 59, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(120, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Hora Ini"
        '
        'DpHoraIni
        '
        Me.DpHoraIni.CustomFormat = "HH:mm"
        Me.DpHoraIni.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DpHoraIni.Location = New System.Drawing.Point(186, 67)
        Me.DpHoraIni.Name = "DpHoraIni"
        Me.DpHoraIni.Size = New System.Drawing.Size(95, 20)
        Me.DpHoraIni.TabIndex = 24
        Me.DpHoraIni.Value = New Date(2018, 8, 13, 0, 1, 0, 0)
        '
        'CmbCategoria
        '
        Me.CmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCategoria.FormattingEnabled = True
        Me.CmbCategoria.Location = New System.Drawing.Point(186, 97)
        Me.CmbCategoria.Name = "CmbCategoria"
        Me.CmbCategoria.Size = New System.Drawing.Size(254, 21)
        Me.CmbCategoria.TabIndex = 29
        '
        'CbkCategoria
        '
        Me.CbkCategoria.AutoSize = True
        Me.CbkCategoria.Checked = True
        Me.CbkCategoria.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CbkCategoria.Location = New System.Drawing.Point(107, 97)
        Me.CbkCategoria.Name = "CbkCategoria"
        Me.CbkCategoria.Size = New System.Drawing.Size(73, 17)
        Me.CbkCategoria.TabIndex = 30
        Me.CbkCategoria.Text = "Categoría"
        Me.CbkCategoria.UseVisualStyleBackColor = True
        '
        'FrmRepVentasXHoraXCategoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(477, 169)
        Me.Controls.Add(Me.CbkCategoria)
        Me.Controls.Add(Me.CmbCategoria)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DpHoraFin)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DpHoraIni)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DtpPFechaFin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DtpPFechaIni)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmRepVentasXHoraXCategoria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ventas por hora por categoría"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents DtpPFechaFin As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents DtpPFechaIni As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents DpHoraFin As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents DpHoraIni As DateTimePicker
    Friend WithEvents CmbCategoria As ComboBox
    Friend WithEvents CbkCategoria As CheckBox
End Class
