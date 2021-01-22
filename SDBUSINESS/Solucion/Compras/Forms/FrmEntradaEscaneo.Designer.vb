<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEntradaEscaneo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEntradaEscaneo))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtCantidad = New System.Windows.Forms.TextBox()
        Me.TxtArticulo = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GrpBoxDatos = New System.Windows.Forms.GroupBox()
        Me.DtpVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.LblVencimiento = New System.Windows.Forms.Label()
        Me.LblLote = New System.Windows.Forms.Label()
        Me.TxtLote = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.GrpBoxDatos.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(32, 37)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cantidad"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidad.Location = New System.Drawing.Point(225, 32)
        Me.TxtCantidad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(284, 37)
        Me.TxtCantidad.TabIndex = 2
        '
        'TxtArticulo
        '
        Me.TxtArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtArticulo.Location = New System.Drawing.Point(225, 30)
        Me.TxtArticulo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtArticulo.MaxLength = 13
        Me.TxtArticulo.Name = "TxtArticulo"
        Me.TxtArticulo.Size = New System.Drawing.Size(284, 37)
        Me.TxtArticulo.TabIndex = 1
        Me.TxtArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnAceptar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(97, 389)
        Me.Panel1.TabIndex = 3
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Compras.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnSalir.Location = New System.Drawing.Point(11, 103)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(77, 84)
        Me.BtnSalir.TabIndex = 7
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.White
        Me.BtnAceptar.Image = Global.Compras.My.Resources.Resources.Blue_F3
        Me.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnAceptar.Location = New System.Drawing.Point(11, 12)
        Me.BtnAceptar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(77, 84)
        Me.BtnAceptar.TabIndex = 6
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(32, 37)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 31)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Artículo"
        '
        'GrpBoxDatos
        '
        Me.GrpBoxDatos.Controls.Add(Me.DtpVencimiento)
        Me.GrpBoxDatos.Controls.Add(Me.LblVencimiento)
        Me.GrpBoxDatos.Controls.Add(Me.LblLote)
        Me.GrpBoxDatos.Controls.Add(Me.TxtLote)
        Me.GrpBoxDatos.Controls.Add(Me.Label1)
        Me.GrpBoxDatos.Controls.Add(Me.TxtCantidad)
        Me.GrpBoxDatos.Location = New System.Drawing.Point(109, 159)
        Me.GrpBoxDatos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GrpBoxDatos.Name = "GrpBoxDatos"
        Me.GrpBoxDatos.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GrpBoxDatos.Size = New System.Drawing.Size(540, 212)
        Me.GrpBoxDatos.TabIndex = 5
        Me.GrpBoxDatos.TabStop = False
        '
        'DtpVencimiento
        '
        Me.DtpVencimiento.CustomFormat = "dd/MM/yyyy"
        Me.DtpVencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpVencimiento.Location = New System.Drawing.Point(225, 159)
        Me.DtpVencimiento.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DtpVencimiento.Name = "DtpVencimiento"
        Me.DtpVencimiento.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DtpVencimiento.Size = New System.Drawing.Size(284, 37)
        Me.DtpVencimiento.TabIndex = 4
        '
        'LblVencimiento
        '
        Me.LblVencimiento.AutoSize = True
        Me.LblVencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVencimiento.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblVencimiento.Location = New System.Drawing.Point(32, 164)
        Me.LblVencimiento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblVencimiento.Name = "LblVencimiento"
        Me.LblVencimiento.Size = New System.Drawing.Size(91, 31)
        Me.LblVencimiento.TabIndex = 4
        Me.LblVencimiento.Text = "Vence"
        '
        'LblLote
        '
        Me.LblLote.AutoSize = True
        Me.LblLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLote.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblLote.Location = New System.Drawing.Point(32, 102)
        Me.LblLote.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblLote.Name = "LblLote"
        Me.LblLote.Size = New System.Drawing.Size(67, 31)
        Me.LblLote.TabIndex = 2
        Me.LblLote.Text = "Lote"
        '
        'TxtLote
        '
        Me.TxtLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLote.Location = New System.Drawing.Point(225, 97)
        Me.TxtLote.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtLote.MaxLength = 20
        Me.TxtLote.Name = "TxtLote"
        Me.TxtLote.Size = New System.Drawing.Size(284, 37)
        Me.TxtLote.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtDescripcion)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TxtArticulo)
        Me.GroupBox2.Location = New System.Drawing.Point(109, 9)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(540, 138)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.BackColor = System.Drawing.Color.White
        Me.TxtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtDescripcion.Location = New System.Drawing.Point(39, 75)
        Me.TxtDescripcion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtDescripcion.MaxLength = 0
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.ReadOnly = True
        Me.TxtDescripcion.Size = New System.Drawing.Size(471, 37)
        Me.TxtDescripcion.TabIndex = 5
        Me.TxtDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FrmEntradaEscaneo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(669, 389)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GrpBoxDatos)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEntradaEscaneo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Escaneo de Mercadería"
        Me.Panel1.ResumeLayout(False)
        Me.GrpBoxDatos.ResumeLayout(False)
        Me.GrpBoxDatos.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TxtCantidad As TextBox
    Friend WithEvents TxtArticulo As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents GrpBoxDatos As GroupBox
    Friend WithEvents DtpVencimiento As DateTimePicker
    Friend WithEvents LblVencimiento As Label
    Friend WithEvents LblLote As Label
    Friend WithEvents TxtLote As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TxtDescripcion As TextBox
    Private WithEvents BtnAceptar As Button
    Friend WithEvents BtnSalir As Button
End Class
