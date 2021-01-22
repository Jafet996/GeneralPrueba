<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRepRecargasTelefonicas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRepRecargasTelefonicas))
        Me.DtpPFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DtpPFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtTelefonoIni = New System.Windows.Forms.TextBox()
        Me.TxtTelefonoFin = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DtpPFechaIni
        '
        Me.DtpPFechaIni.CustomFormat = "dd/MM/yyyy"
        Me.DtpPFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpPFechaIni.Location = New System.Drawing.Point(155, 52)
        Me.DtpPFechaIni.Name = "DtpPFechaIni"
        Me.DtpPFechaIni.Size = New System.Drawing.Size(95, 20)
        Me.DtpPFechaIni.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(111, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Desde"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(111, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Hasta"
        '
        'DtpPFechaFin
        '
        Me.DtpPFechaFin.CustomFormat = "dd/MM/yyyy"
        Me.DtpPFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpPFechaFin.Location = New System.Drawing.Point(155, 78)
        Me.DtpPFechaFin.Name = "DtpPFechaFin"
        Me.DtpPFechaFin.Size = New System.Drawing.Size(95, 20)
        Me.DtpPFechaFin.TabIndex = 6
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
        Me.Panel1.TabIndex = 8
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(281, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Teléfono Desde :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(281, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Teléfono Hasta :"
        '
        'TxtTelefonoIni
        '
        Me.TxtTelefonoIni.Location = New System.Drawing.Point(373, 52)
        Me.TxtTelefonoIni.MaxLength = 8
        Me.TxtTelefonoIni.Name = "TxtTelefonoIni"
        Me.TxtTelefonoIni.Size = New System.Drawing.Size(100, 20)
        Me.TxtTelefonoIni.TabIndex = 11
        '
        'TxtTelefonoFin
        '
        Me.TxtTelefonoFin.Location = New System.Drawing.Point(373, 78)
        Me.TxtTelefonoFin.MaxLength = 8
        Me.TxtTelefonoFin.Name = "TxtTelefonoFin"
        Me.TxtTelefonoFin.Size = New System.Drawing.Size(100, 20)
        Me.TxtTelefonoFin.TabIndex = 12
        '
        'FrmRepRecargasTelefonicas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(499, 166)
        Me.Controls.Add(Me.TxtTelefonoFin)
        Me.Controls.Add(Me.TxtTelefonoIni)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DtpPFechaFin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DtpPFechaIni)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRepRecargasTelefonicas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Ventas x Fecha"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DtpPFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DtpPFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtTelefonoIni As System.Windows.Forms.TextBox
    Friend WithEvents TxtTelefonoFin As System.Windows.Forms.TextBox
End Class
