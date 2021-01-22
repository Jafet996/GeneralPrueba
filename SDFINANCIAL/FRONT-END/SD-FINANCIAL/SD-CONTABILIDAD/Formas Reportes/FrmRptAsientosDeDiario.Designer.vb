<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptAsientosDeDiario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptAsientosDeDiario))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmbTipoAsiento = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChkTipo = New System.Windows.Forms.CheckBox()
        Me.CmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ChkEstado = New System.Windows.Forms.CheckBox()
        Me.ChkOrigen = New System.Windows.Forms.CheckBox()
        Me.CmbOrigen = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GbFechas = New System.Windows.Forms.GroupBox()
        Me.ChkFechas = New System.Windows.Forms.CheckBox()
        Me.DtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GbPeriodo = New System.Windows.Forms.GroupBox()
        Me.ChkPeriodo = New System.Windows.Forms.CheckBox()
        Me.CmbAnnio = New System.Windows.Forms.ComboBox()
        Me.CmbMes = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GbFechas.SuspendLayout()
        Me.GbPeriodo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnImprimir)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(77, 265)
        Me.Panel1.TabIndex = 10
        '
        'BtnImprimir
        '
        Me.BtnImprimir.BackColor = System.Drawing.Color.White
        Me.BtnImprimir.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_F3
        Me.BtnImprimir.Location = New System.Drawing.Point(10, 6)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(57, 72)
        Me.BtnImprimir.TabIndex = 1
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(10, 84)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(57, 72)
        Me.BtnSalir.TabIndex = 2
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GbPeriodo)
        Me.GroupBox1.Controls.Add(Me.GbFechas)
        Me.GroupBox1.Controls.Add(Me.ChkOrigen)
        Me.GroupBox1.Controls.Add(Me.CmbOrigen)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ChkEstado)
        Me.GroupBox1.Controls.Add(Me.CmbEstado)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.ChkTipo)
        Me.GroupBox1.Controls.Add(Me.CmbTipoAsiento)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(84, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(390, 247)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'CmbTipoAsiento
        '
        Me.CmbTipoAsiento.BackColor = System.Drawing.Color.White
        Me.CmbTipoAsiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoAsiento.Enabled = False
        Me.CmbTipoAsiento.FormattingEnabled = True
        Me.CmbTipoAsiento.Location = New System.Drawing.Point(175, 17)
        Me.CmbTipoAsiento.Name = "CmbTipoAsiento"
        Me.CmbTipoAsiento.Size = New System.Drawing.Size(176, 21)
        Me.CmbTipoAsiento.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(44, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 21)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Tipo"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ChkTipo
        '
        Me.ChkTipo.AutoSize = True
        Me.ChkTipo.Checked = True
        Me.ChkTipo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkTipo.Location = New System.Drawing.Point(113, 19)
        Me.ChkTipo.Name = "ChkTipo"
        Me.ChkTipo.Size = New System.Drawing.Size(56, 17)
        Me.ChkTipo.TabIndex = 5
        Me.ChkTipo.Text = "Todos"
        Me.ChkTipo.UseVisualStyleBackColor = True
        '
        'CmbEstado
        '
        Me.CmbEstado.BackColor = System.Drawing.Color.White
        Me.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEstado.Enabled = False
        Me.CmbEstado.FormattingEnabled = True
        Me.CmbEstado.Location = New System.Drawing.Point(175, 44)
        Me.CmbEstado.Name = "CmbEstado"
        Me.CmbEstado.Size = New System.Drawing.Size(176, 21)
        Me.CmbEstado.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(44, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 21)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Estado"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ChkEstado
        '
        Me.ChkEstado.AutoSize = True
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(113, 46)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(56, 17)
        Me.ChkEstado.TabIndex = 8
        Me.ChkEstado.Text = "Todos"
        Me.ChkEstado.UseVisualStyleBackColor = True
        '
        'ChkOrigen
        '
        Me.ChkOrigen.AutoSize = True
        Me.ChkOrigen.Checked = True
        Me.ChkOrigen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkOrigen.Location = New System.Drawing.Point(113, 73)
        Me.ChkOrigen.Name = "ChkOrigen"
        Me.ChkOrigen.Size = New System.Drawing.Size(56, 17)
        Me.ChkOrigen.TabIndex = 11
        Me.ChkOrigen.Text = "Todos"
        Me.ChkOrigen.UseVisualStyleBackColor = True
        '
        'CmbOrigen
        '
        Me.CmbOrigen.BackColor = System.Drawing.Color.White
        Me.CmbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbOrigen.Enabled = False
        Me.CmbOrigen.FormattingEnabled = True
        Me.CmbOrigen.Location = New System.Drawing.Point(175, 71)
        Me.CmbOrigen.Name = "CmbOrigen"
        Me.CmbOrigen.Size = New System.Drawing.Size(176, 21)
        Me.CmbOrigen.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(44, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 21)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Origen"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GbFechas
        '
        Me.GbFechas.Controls.Add(Me.ChkFechas)
        Me.GbFechas.Controls.Add(Me.DtpFechaFinal)
        Me.GbFechas.Controls.Add(Me.Label3)
        Me.GbFechas.Controls.Add(Me.DtpFechaInicio)
        Me.GbFechas.Controls.Add(Me.Label4)
        Me.GbFechas.Location = New System.Drawing.Point(28, 98)
        Me.GbFechas.Name = "GbFechas"
        Me.GbFechas.Size = New System.Drawing.Size(337, 67)
        Me.GbFechas.TabIndex = 12
        Me.GbFechas.TabStop = False
        '
        'ChkFechas
        '
        Me.ChkFechas.AutoSize = True
        Me.ChkFechas.Location = New System.Drawing.Point(4, 9)
        Me.ChkFechas.Name = "ChkFechas"
        Me.ChkFechas.Size = New System.Drawing.Size(15, 14)
        Me.ChkFechas.TabIndex = 4
        Me.ChkFechas.UseVisualStyleBackColor = True
        '
        'DtpFechaFinal
        '
        Me.DtpFechaFinal.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaFinal.Enabled = False
        Me.DtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaFinal.Location = New System.Drawing.Point(223, 29)
        Me.DtpFechaFinal.Name = "DtpFechaFinal"
        Me.DtpFechaFinal.Size = New System.Drawing.Size(97, 20)
        Me.DtpFechaFinal.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(175, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 21)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Hasta"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DtpFechaInicio
        '
        Me.DtpFechaInicio.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaInicio.Enabled = False
        Me.DtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaInicio.Location = New System.Drawing.Point(72, 29)
        Me.DtpFechaInicio.Name = "DtpFechaInicio"
        Me.DtpFechaInicio.Size = New System.Drawing.Size(97, 20)
        Me.DtpFechaInicio.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(22, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 21)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Desde"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GbPeriodo
        '
        Me.GbPeriodo.Controls.Add(Me.ChkPeriodo)
        Me.GbPeriodo.Controls.Add(Me.CmbAnnio)
        Me.GbPeriodo.Controls.Add(Me.CmbMes)
        Me.GbPeriodo.Controls.Add(Me.Label7)
        Me.GbPeriodo.Location = New System.Drawing.Point(28, 166)
        Me.GbPeriodo.Name = "GbPeriodo"
        Me.GbPeriodo.Size = New System.Drawing.Size(337, 67)
        Me.GbPeriodo.TabIndex = 13
        Me.GbPeriodo.TabStop = False
        '
        'ChkPeriodo
        '
        Me.ChkPeriodo.AutoSize = True
        Me.ChkPeriodo.Checked = True
        Me.ChkPeriodo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPeriodo.Location = New System.Drawing.Point(4, 10)
        Me.ChkPeriodo.Name = "ChkPeriodo"
        Me.ChkPeriodo.Size = New System.Drawing.Size(15, 14)
        Me.ChkPeriodo.TabIndex = 4
        Me.ChkPeriodo.UseVisualStyleBackColor = True
        '
        'CmbAnnio
        '
        Me.CmbAnnio.BackColor = System.Drawing.Color.White
        Me.CmbAnnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAnnio.FormattingEnabled = True
        Me.CmbAnnio.Location = New System.Drawing.Point(223, 28)
        Me.CmbAnnio.Name = "CmbAnnio"
        Me.CmbAnnio.Size = New System.Drawing.Size(97, 21)
        Me.CmbAnnio.TabIndex = 4
        '
        'CmbMes
        '
        Me.CmbMes.BackColor = System.Drawing.Color.White
        Me.CmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMes.FormattingEnabled = True
        Me.CmbMes.Location = New System.Drawing.Point(85, 28)
        Me.CmbMes.Name = "CmbMes"
        Me.CmbMes.Size = New System.Drawing.Size(132, 21)
        Me.CmbMes.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(16, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 21)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Periodo"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmRptAsientosDeDiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(479, 265)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptAsientosDeDiario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Asientos de Diario"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GbFechas.ResumeLayout(False)
        Me.GbFechas.PerformLayout()
        Me.GbPeriodo.ResumeLayout(False)
        Me.GbPeriodo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkTipo As System.Windows.Forms.CheckBox
    Friend WithEvents CmbTipoAsiento As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkEstado As System.Windows.Forms.CheckBox
    Friend WithEvents CmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ChkOrigen As System.Windows.Forms.CheckBox
    Friend WithEvents CmbOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GbFechas As System.Windows.Forms.GroupBox
    Friend WithEvents ChkFechas As System.Windows.Forms.CheckBox
    Friend WithEvents DtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GbPeriodo As System.Windows.Forms.GroupBox
    Friend WithEvents ChkPeriodo As System.Windows.Forms.CheckBox
    Friend WithEvents CmbAnnio As System.Windows.Forms.ComboBox
    Friend WithEvents CmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
