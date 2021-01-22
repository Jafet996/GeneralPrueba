<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRepAsientosCierreSD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRepAsientosCierreSD))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnRegeneraAsiento = New System.Windows.Forms.Button()
        Me.BtnImprimirAsiento = New System.Windows.Forms.Button()
        Me.BtnDetalleCierre = New System.Windows.Forms.Button()
        Me.BtnRefresca = New System.Windows.Forms.Button()
        Me.BtnAplicar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.LvwAsientos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PrgProgreso = New System.Windows.Forms.ProgressBar()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnRegeneraAsiento)
        Me.Panel1.Controls.Add(Me.BtnImprimirAsiento)
        Me.Panel1.Controls.Add(Me.BtnDetalleCierre)
        Me.Panel1.Controls.Add(Me.BtnRefresca)
        Me.Panel1.Controls.Add(Me.BtnAplicar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnImprimir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(113, 870)
        Me.Panel1.TabIndex = 8
        '
        'BtnRegeneraAsiento
        '
        Me.BtnRegeneraAsiento.BackColor = System.Drawing.Color.White
        Me.BtnRegeneraAsiento.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F6
        Me.BtnRegeneraAsiento.Location = New System.Drawing.Point(16, 606)
        Me.BtnRegeneraAsiento.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnRegeneraAsiento.Name = "BtnRegeneraAsiento"
        Me.BtnRegeneraAsiento.Size = New System.Drawing.Size(79, 111)
        Me.BtnRegeneraAsiento.TabIndex = 18
        Me.BtnRegeneraAsiento.Text = "Genera Asiento"
        Me.BtnRegeneraAsiento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnRegeneraAsiento.UseVisualStyleBackColor = False
        '
        'BtnImprimirAsiento
        '
        Me.BtnImprimirAsiento.BackColor = System.Drawing.Color.White
        Me.BtnImprimirAsiento.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnImprimirAsiento.Location = New System.Drawing.Point(16, 251)
        Me.BtnImprimirAsiento.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnImprimirAsiento.Name = "BtnImprimirAsiento"
        Me.BtnImprimirAsiento.Size = New System.Drawing.Size(79, 111)
        Me.BtnImprimirAsiento.TabIndex = 17
        Me.BtnImprimirAsiento.Text = "Imprime Asiento"
        Me.BtnImprimirAsiento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnImprimirAsiento.UseVisualStyleBackColor = False
        '
        'BtnDetalleCierre
        '
        Me.BtnDetalleCierre.BackColor = System.Drawing.Color.White
        Me.BtnDetalleCierre.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F4
        Me.BtnDetalleCierre.Location = New System.Drawing.Point(16, 369)
        Me.BtnDetalleCierre.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnDetalleCierre.Name = "BtnDetalleCierre"
        Me.BtnDetalleCierre.Size = New System.Drawing.Size(79, 111)
        Me.BtnDetalleCierre.TabIndex = 16
        Me.BtnDetalleCierre.Text = "Detalle Cierre"
        Me.BtnDetalleCierre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnDetalleCierre.UseVisualStyleBackColor = False
        '
        'BtnRefresca
        '
        Me.BtnRefresca.BackColor = System.Drawing.Color.White
        Me.BtnRefresca.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F1
        Me.BtnRefresca.Location = New System.Drawing.Point(16, 15)
        Me.BtnRefresca.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnRefresca.Name = "BtnRefresca"
        Me.BtnRefresca.Size = New System.Drawing.Size(79, 111)
        Me.BtnRefresca.TabIndex = 15
        Me.BtnRefresca.Text = "Refresca Lista"
        Me.BtnRefresca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnRefresca.UseVisualStyleBackColor = False
        '
        'BtnAplicar
        '
        Me.BtnAplicar.BackColor = System.Drawing.Color.White
        Me.BtnAplicar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F5
        Me.BtnAplicar.Location = New System.Drawing.Point(16, 487)
        Me.BtnAplicar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnAplicar.Name = "BtnAplicar"
        Me.BtnAplicar.Size = New System.Drawing.Size(79, 111)
        Me.BtnAplicar.TabIndex = 14
        Me.BtnAplicar.Text = "Pasa Conta"
        Me.BtnAplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAplicar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(16, 724)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(79, 111)
        Me.BtnSalir.TabIndex = 13
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnImprimir
        '
        Me.BtnImprimir.BackColor = System.Drawing.Color.White
        Me.BtnImprimir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F2
        Me.BtnImprimir.Location = New System.Drawing.Point(16, 133)
        Me.BtnImprimir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(79, 111)
        Me.BtnImprimir.TabIndex = 12
        Me.BtnImprimir.Text = "Imprime Todo"
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'LvwAsientos
        '
        Me.LvwAsientos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.LvwAsientos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvwAsientos.FullRowSelect = True
        Me.LvwAsientos.HideSelection = False
        Me.LvwAsientos.Location = New System.Drawing.Point(113, 0)
        Me.LvwAsientos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LvwAsientos.Name = "LvwAsientos"
        Me.LvwAsientos.Size = New System.Drawing.Size(1444, 860)
        Me.LvwAsientos.TabIndex = 9
        Me.LvwAsientos.UseCompatibleStateImageBehavior = False
        Me.LvwAsientos.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Sucursal"
        Me.ColumnHeader1.Width = 174
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Caja"
        Me.ColumnHeader2.Width = 129
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Cierre"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Fecha"
        Me.ColumnHeader4.Width = 122
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Cuenta"
        Me.ColumnHeader5.Width = 116
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Nombre"
        Me.ColumnHeader6.Width = 237
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Debe"
        Me.ColumnHeader7.Width = 110
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Haber"
        Me.ColumnHeader8.Width = 110
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Caja_Id"
        Me.ColumnHeader9.Width = 0
        '
        'PrgProgreso
        '
        Me.PrgProgreso.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PrgProgreso.Location = New System.Drawing.Point(113, 860)
        Me.PrgProgreso.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PrgProgreso.Name = "PrgProgreso"
        Me.PrgProgreso.Size = New System.Drawing.Size(1444, 10)
        Me.PrgProgreso.TabIndex = 10
        '
        'FrmRepAsientosCierreSD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1557, 870)
        Me.Controls.Add(Me.LvwAsientos)
        Me.Controls.Add(Me.PrgProgreso)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRepAsientosCierreSD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asientos contables x cierre de caja"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents BtnAplicar As System.Windows.Forms.Button
    Friend WithEvents LvwAsientos As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnRefresca As System.Windows.Forms.Button
    Friend WithEvents BtnDetalleCierre As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnImprimirAsiento As System.Windows.Forms.Button
    Friend WithEvents BtnRegeneraAsiento As System.Windows.Forms.Button
    Friend WithEvents PrgProgreso As System.Windows.Forms.ProgressBar
End Class
