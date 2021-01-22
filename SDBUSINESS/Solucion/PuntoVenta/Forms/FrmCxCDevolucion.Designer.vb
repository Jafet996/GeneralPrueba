<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCxCDevolucion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCxCDevolucion))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblMontoNotaCreditoGeneral = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblTotalDevolucion = New System.Windows.Forms.Label()
        Me.LblTotalMovimientosSeleccionados = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblDocumentoMonto = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblDocumentoMontoFavor = New System.Windows.Forms.Label()
        Me.LblDocumentoSaldo = New System.Windows.Forms.Label()
        Me.LvwMovimientos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(86, 621)
        Me.Panel1.TabIndex = 10
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(14, 91)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(58, 73)
        Me.BtnSalir.TabIndex = 1
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.White
        Me.BtnAceptar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnAceptar.Location = New System.Drawing.Point(14, 12)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(58, 73)
        Me.BtnAceptar.TabIndex = 0
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(86, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1157, 172)
        Me.Panel2.TabIndex = 12
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.LblMontoNotaCreditoGeneral)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.LblTotalDevolucion)
        Me.GroupBox2.Controls.Add(Me.LblTotalMovimientosSeleccionados)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(755, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(390, 152)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Crimson
        Me.Label4.Location = New System.Drawing.Point(27, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(168, 18)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Nota Crédito General"
        '
        'LblMontoNotaCreditoGeneral
        '
        Me.LblMontoNotaCreditoGeneral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblMontoNotaCreditoGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMontoNotaCreditoGeneral.ForeColor = System.Drawing.Color.Crimson
        Me.LblMontoNotaCreditoGeneral.Location = New System.Drawing.Point(201, 101)
        Me.LblMontoNotaCreditoGeneral.Name = "LblMontoNotaCreditoGeneral"
        Me.LblMontoNotaCreditoGeneral.Size = New System.Drawing.Size(148, 27)
        Me.LblMontoNotaCreditoGeneral.TabIndex = 17
        Me.LblMontoNotaCreditoGeneral.Text = "0.00"
        Me.LblMontoNotaCreditoGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(27, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(161, 18)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Total Seleccionadas"
        '
        'LblTotalDevolucion
        '
        Me.LblTotalDevolucion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblTotalDevolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalDevolucion.ForeColor = System.Drawing.Color.DarkGreen
        Me.LblTotalDevolucion.Location = New System.Drawing.Point(201, 29)
        Me.LblTotalDevolucion.Name = "LblTotalDevolucion"
        Me.LblTotalDevolucion.Size = New System.Drawing.Size(148, 27)
        Me.LblTotalDevolucion.TabIndex = 8
        Me.LblTotalDevolucion.Text = "0.00"
        Me.LblTotalDevolucion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTotalMovimientosSeleccionados
        '
        Me.LblTotalMovimientosSeleccionados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblTotalMovimientosSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMovimientosSeleccionados.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblTotalMovimientosSeleccionados.Location = New System.Drawing.Point(201, 66)
        Me.LblTotalMovimientosSeleccionados.Name = "LblTotalMovimientosSeleccionados"
        Me.LblTotalMovimientosSeleccionados.Size = New System.Drawing.Size(148, 27)
        Me.LblTotalMovimientosSeleccionados.TabIndex = 15
        Me.LblTotalMovimientosSeleccionados.Text = "0.00"
        Me.LblTotalMovimientosSeleccionados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label6.Location = New System.Drawing.Point(27, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(135, 18)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Total Devolucion"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.LblDocumentoMonto)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.LblDocumentoMontoFavor)
        Me.GroupBox1.Controls.Add(Me.LblDocumentoSaldo)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(305, 152)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Documento CxC"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label5.Location = New System.Drawing.Point(19, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 18)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Pagado"
        '
        'LblDocumentoMonto
        '
        Me.LblDocumentoMonto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblDocumentoMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDocumentoMonto.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblDocumentoMonto.Location = New System.Drawing.Point(117, 29)
        Me.LblDocumentoMonto.Name = "LblDocumentoMonto"
        Me.LblDocumentoMonto.Size = New System.Drawing.Size(148, 27)
        Me.LblDocumentoMonto.TabIndex = 2
        Me.LblDocumentoMonto.Text = "0.00"
        Me.LblDocumentoMonto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(19, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Monto"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Crimson
        Me.Label3.Location = New System.Drawing.Point(19, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 18)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Saldo"
        '
        'LblDocumentoMontoFavor
        '
        Me.LblDocumentoMontoFavor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblDocumentoMontoFavor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDocumentoMontoFavor.ForeColor = System.Drawing.Color.DarkGreen
        Me.LblDocumentoMontoFavor.Location = New System.Drawing.Point(117, 66)
        Me.LblDocumentoMontoFavor.Name = "LblDocumentoMontoFavor"
        Me.LblDocumentoMontoFavor.Size = New System.Drawing.Size(148, 27)
        Me.LblDocumentoMontoFavor.TabIndex = 6
        Me.LblDocumentoMontoFavor.Text = "0.00"
        Me.LblDocumentoMontoFavor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblDocumentoSaldo
        '
        Me.LblDocumentoSaldo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblDocumentoSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDocumentoSaldo.ForeColor = System.Drawing.Color.Crimson
        Me.LblDocumentoSaldo.Location = New System.Drawing.Point(117, 102)
        Me.LblDocumentoSaldo.Name = "LblDocumentoSaldo"
        Me.LblDocumentoSaldo.Size = New System.Drawing.Size(148, 27)
        Me.LblDocumentoSaldo.TabIndex = 4
        Me.LblDocumentoSaldo.Text = "0.00"
        Me.LblDocumentoSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LvwMovimientos
        '
        Me.LvwMovimientos.CheckBoxes = True
        Me.LvwMovimientos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.LvwMovimientos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LvwMovimientos.FullRowSelect = True
        Me.LvwMovimientos.HideSelection = False
        Me.LvwMovimientos.Location = New System.Drawing.Point(86, 178)
        Me.LvwMovimientos.Name = "LvwMovimientos"
        Me.LvwMovimientos.Size = New System.Drawing.Size(1157, 443)
        Me.LvwMovimientos.TabIndex = 13
        Me.LvwMovimientos.UseCompatibleStateImageBehavior = False
        Me.LvwMovimientos.View = System.Windows.Forms.View.Details
        '
        'FrmCxCDevolucion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1243, 621)
        Me.Controls.Add(Me.LvwMovimientos)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCxCDevolucion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Devolución de Facturas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnAceptar As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LblDocumentoMontoFavor As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LblDocumentoMonto As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LblDocumentoSaldo As Label
    Friend WithEvents LvwMovimientos As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents Label2 As Label
    Friend WithEvents LblTotalMovimientosSeleccionados As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LblTotalDevolucion As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LblMontoNotaCreditoGeneral As Label
    Friend WithEvents ColumnHeader8 As ColumnHeader
End Class
