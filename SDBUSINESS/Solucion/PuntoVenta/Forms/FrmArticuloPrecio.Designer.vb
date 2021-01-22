<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmArticuloPrecio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmArticuloPrecio))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.TxtMonto = New System.Windows.Forms.TextBox()
        Me.LblDescripcion = New System.Windows.Forms.Label()
        Me.TxtPrecio1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtPrecio2 = New System.Windows.Forms.TextBox()
        Me.TxtPrecio3 = New System.Windows.Forms.TextBox()
        Me.TxtPrecio4 = New System.Windows.Forms.TextBox()
        Me.TxtPrecio5 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LblPoliticaImpuesto = New System.Windows.Forms.Label()
        Me.TxtMontoConImpuesto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtImpuesto = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnAceptar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(70, 449)
        Me.Panel1.TabIndex = 5
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.White
        Me.BtnAceptar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnAceptar.Location = New System.Drawing.Point(5, 12)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(60, 71)
        Me.BtnAceptar.TabIndex = 6
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(5, 87)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(60, 71)
        Me.BtnSalir.TabIndex = 7
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'TxtMonto
        '
        Me.TxtMonto.BackColor = System.Drawing.Color.White
        Me.TxtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMonto.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtMonto.Location = New System.Drawing.Point(301, 328)
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Size = New System.Drawing.Size(137, 26)
        Me.TxtMonto.TabIndex = 0
        Me.TxtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDescripcion
        '
        Me.LblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescripcion.ForeColor = System.Drawing.Color.Navy
        Me.LblDescripcion.Location = New System.Drawing.Point(120, 330)
        Me.LblDescripcion.Name = "LblDescripcion"
        Me.LblDescripcion.Size = New System.Drawing.Size(158, 22)
        Me.LblDescripcion.TabIndex = 6
        Me.LblDescripcion.Text = "Precio Sin Impuesto"
        Me.LblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtPrecio1
        '
        Me.TxtPrecio1.BackColor = System.Drawing.Color.White
        Me.TxtPrecio1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrecio1.ForeColor = System.Drawing.Color.OrangeRed
        Me.TxtPrecio1.Location = New System.Drawing.Point(147, 32)
        Me.TxtPrecio1.Name = "TxtPrecio1"
        Me.TxtPrecio1.ReadOnly = True
        Me.TxtPrecio1.Size = New System.Drawing.Size(137, 26)
        Me.TxtPrecio1.TabIndex = 1
        Me.TxtPrecio1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(33, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 22)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Precio 1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(33, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 22)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Precio 2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(33, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 22)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Precio 3"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(33, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 22)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Precio 4"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(33, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 22)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Precio 5"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtPrecio2
        '
        Me.TxtPrecio2.BackColor = System.Drawing.Color.White
        Me.TxtPrecio2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrecio2.ForeColor = System.Drawing.Color.OrangeRed
        Me.TxtPrecio2.Location = New System.Drawing.Point(147, 62)
        Me.TxtPrecio2.Name = "TxtPrecio2"
        Me.TxtPrecio2.ReadOnly = True
        Me.TxtPrecio2.Size = New System.Drawing.Size(137, 26)
        Me.TxtPrecio2.TabIndex = 2
        Me.TxtPrecio2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPrecio3
        '
        Me.TxtPrecio3.BackColor = System.Drawing.Color.White
        Me.TxtPrecio3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrecio3.ForeColor = System.Drawing.Color.OrangeRed
        Me.TxtPrecio3.Location = New System.Drawing.Point(147, 92)
        Me.TxtPrecio3.Name = "TxtPrecio3"
        Me.TxtPrecio3.ReadOnly = True
        Me.TxtPrecio3.Size = New System.Drawing.Size(137, 26)
        Me.TxtPrecio3.TabIndex = 3
        Me.TxtPrecio3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPrecio4
        '
        Me.TxtPrecio4.BackColor = System.Drawing.Color.White
        Me.TxtPrecio4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrecio4.ForeColor = System.Drawing.Color.OrangeRed
        Me.TxtPrecio4.Location = New System.Drawing.Point(147, 122)
        Me.TxtPrecio4.Name = "TxtPrecio4"
        Me.TxtPrecio4.ReadOnly = True
        Me.TxtPrecio4.Size = New System.Drawing.Size(137, 26)
        Me.TxtPrecio4.TabIndex = 4
        Me.TxtPrecio4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPrecio5
        '
        Me.TxtPrecio5.BackColor = System.Drawing.Color.White
        Me.TxtPrecio5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrecio5.ForeColor = System.Drawing.Color.OrangeRed
        Me.TxtPrecio5.Location = New System.Drawing.Point(147, 152)
        Me.TxtPrecio5.Name = "TxtPrecio5"
        Me.TxtPrecio5.ReadOnly = True
        Me.TxtPrecio5.Size = New System.Drawing.Size(137, 26)
        Me.TxtPrecio5.TabIndex = 5
        Me.TxtPrecio5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtPrecio5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtPrecio4)
        Me.GroupBox1.Controls.Add(Me.TxtPrecio1)
        Me.GroupBox1.Controls.Add(Me.TxtPrecio3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtPrecio2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(120, 104)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(318, 205)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Precios sin impuesto"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.LblPoliticaImpuesto)
        Me.Panel2.Location = New System.Drawing.Point(120, 18)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(318, 80)
        Me.Panel2.TabIndex = 19
        '
        'LblPoliticaImpuesto
        '
        Me.LblPoliticaImpuesto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblPoliticaImpuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPoliticaImpuesto.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblPoliticaImpuesto.Location = New System.Drawing.Point(0, 0)
        Me.LblPoliticaImpuesto.Name = "LblPoliticaImpuesto"
        Me.LblPoliticaImpuesto.Size = New System.Drawing.Size(316, 78)
        Me.LblPoliticaImpuesto.TabIndex = 0
        Me.LblPoliticaImpuesto.Text = "Gravado"
        Me.LblPoliticaImpuesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtMontoConImpuesto
        '
        Me.TxtMontoConImpuesto.BackColor = System.Drawing.Color.White
        Me.TxtMontoConImpuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMontoConImpuesto.ForeColor = System.Drawing.Color.Blue
        Me.TxtMontoConImpuesto.Location = New System.Drawing.Point(301, 392)
        Me.TxtMontoConImpuesto.Name = "TxtMontoConImpuesto"
        Me.TxtMontoConImpuesto.Size = New System.Drawing.Size(137, 26)
        Me.TxtMontoConImpuesto.TabIndex = 20
        Me.TxtMontoConImpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(120, 394)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(158, 22)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Precio Con Impuesto"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtImpuesto
        '
        Me.TxtImpuesto.BackColor = System.Drawing.Color.White
        Me.TxtImpuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtImpuesto.ForeColor = System.Drawing.Color.DarkGreen
        Me.TxtImpuesto.Location = New System.Drawing.Point(301, 360)
        Me.TxtImpuesto.Name = "TxtImpuesto"
        Me.TxtImpuesto.ReadOnly = True
        Me.TxtImpuesto.Size = New System.Drawing.Size(137, 26)
        Me.TxtImpuesto.TabIndex = 22
        Me.TxtImpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(120, 362)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 22)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Impuesto"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmArticuloPrecio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(471, 449)
        Me.Controls.Add(Me.TxtImpuesto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtMontoConImpuesto)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TxtMonto)
        Me.Controls.Add(Me.LblDescripcion)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmArticuloPrecio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmArticuloPrecio"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnAceptar As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents TxtMonto As TextBox
    Friend WithEvents LblDescripcion As Label
    Friend WithEvents TxtPrecio1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtPrecio2 As TextBox
    Friend WithEvents TxtPrecio3 As TextBox
    Friend WithEvents TxtPrecio4 As TextBox
    Friend WithEvents TxtPrecio5 As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LblPoliticaImpuesto As Label
    Friend WithEvents TxtMontoConImpuesto As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtImpuesto As TextBox
    Friend WithEvents Label7 As Label
End Class
