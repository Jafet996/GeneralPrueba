<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDevolucionTipoPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDevolucionTipoPago))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.LvwPagos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RdbPagoTransferencias = New System.Windows.Forms.RadioButton()
        Me.RdbPagoTarjetas = New System.Windows.Forms.RadioButton()
        Me.RdbPagoEfectivo = New System.Windows.Forms.RadioButton()
        Me.RdbPagoOriginal = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnAceptar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(107, 523)
        Me.Panel1.TabIndex = 7
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(16, 111)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(76, 89)
        Me.BtnSalir.TabIndex = 6
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.White
        Me.BtnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnAceptar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnAceptar.Location = New System.Drawing.Point(16, 15)
        Me.BtnAceptar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(76, 89)
        Me.BtnAceptar.TabIndex = 5
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'LvwPagos
        '
        Me.LvwPagos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.LvwPagos.Dock = System.Windows.Forms.DockStyle.Top
        Me.LvwPagos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LvwPagos.Location = New System.Drawing.Point(107, 0)
        Me.LvwPagos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LvwPagos.Name = "LvwPagos"
        Me.LvwPagos.Size = New System.Drawing.Size(840, 336)
        Me.LvwPagos.TabIndex = 9
        Me.LvwPagos.UseCompatibleStateImageBehavior = False
        Me.LvwPagos.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Tipo"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Descripción"
        Me.ColumnHeader2.Width = 432
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Monto"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 165
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(499, 423)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 42)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Total"
        '
        'LblTotal
        '
        Me.LblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblTotal.Location = New System.Drawing.Point(620, 423)
        Me.LblTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(305, 41)
        Me.LblTotal.TabIndex = 12
        Me.LblTotal.Text = "0.00"
        Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RdbPagoTransferencias)
        Me.GroupBox1.Controls.Add(Me.RdbPagoTarjetas)
        Me.GroupBox1.Controls.Add(Me.RdbPagoEfectivo)
        Me.GroupBox1.Controls.Add(Me.RdbPagoOriginal)
        Me.GroupBox1.Location = New System.Drawing.Point(138, 368)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(353, 142)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo Devolución"
        '
        'RdbPagoTransferencias
        '
        Me.RdbPagoTransferencias.AutoSize = True
        Me.RdbPagoTransferencias.Location = New System.Drawing.Point(39, 110)
        Me.RdbPagoTransferencias.Margin = New System.Windows.Forms.Padding(4)
        Me.RdbPagoTransferencias.Name = "RdbPagoTransferencias"
        Me.RdbPagoTransferencias.Size = New System.Drawing.Size(200, 21)
        Me.RdbPagoTransferencias.TabIndex = 3
        Me.RdbPagoTransferencias.Text = "Aplicar a las transferencias"
        Me.RdbPagoTransferencias.UseVisualStyleBackColor = True
        '
        'RdbPagoTarjetas
        '
        Me.RdbPagoTarjetas.AutoSize = True
        Me.RdbPagoTarjetas.Location = New System.Drawing.Point(39, 81)
        Me.RdbPagoTarjetas.Margin = New System.Windows.Forms.Padding(4)
        Me.RdbPagoTarjetas.Name = "RdbPagoTarjetas"
        Me.RdbPagoTarjetas.Size = New System.Drawing.Size(157, 21)
        Me.RdbPagoTarjetas.TabIndex = 2
        Me.RdbPagoTarjetas.Text = "Aplicar a las tarjetas"
        Me.RdbPagoTarjetas.UseVisualStyleBackColor = True
        '
        'RdbPagoEfectivo
        '
        Me.RdbPagoEfectivo.AutoSize = True
        Me.RdbPagoEfectivo.Location = New System.Drawing.Point(39, 52)
        Me.RdbPagoEfectivo.Margin = New System.Windows.Forms.Padding(4)
        Me.RdbPagoEfectivo.Name = "RdbPagoEfectivo"
        Me.RdbPagoEfectivo.Size = New System.Drawing.Size(140, 21)
        Me.RdbPagoEfectivo.TabIndex = 1
        Me.RdbPagoEfectivo.Text = "Aplicar al efectivo"
        Me.RdbPagoEfectivo.UseVisualStyleBackColor = True
        '
        'RdbPagoOriginal
        '
        Me.RdbPagoOriginal.AutoSize = True
        Me.RdbPagoOriginal.Checked = True
        Me.RdbPagoOriginal.Location = New System.Drawing.Point(39, 23)
        Me.RdbPagoOriginal.Margin = New System.Windows.Forms.Padding(4)
        Me.RdbPagoOriginal.Name = "RdbPagoOriginal"
        Me.RdbPagoOriginal.Size = New System.Drawing.Size(177, 21)
        Me.RdbPagoOriginal.TabIndex = 0
        Me.RdbPagoOriginal.TabStop = True
        Me.RdbPagoOriginal.Text = "Reversar Pago Original"
        Me.RdbPagoOriginal.UseVisualStyleBackColor = True
        '
        'FrmDevolucionTipoPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(947, 523)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LblTotal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LvwPagos)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDevolucionTipoPago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle Pago Factura"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnAceptar As Button
    Friend WithEvents LvwPagos As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents Label1 As Label
    Friend WithEvents LblTotal As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RdbPagoTransferencias As RadioButton
    Friend WithEvents RdbPagoTarjetas As RadioButton
    Friend WithEvents RdbPagoEfectivo As RadioButton
    Friend WithEvents RdbPagoOriginal As RadioButton
End Class
