<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEntradaEfectivo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEntradaEfectivo))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtMonto = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnAgregar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbMotivo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtPagaCon = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(106, 146)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 25)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Monto:"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.Location = New System.Drawing.Point(241, 83)
        Me.TxtDescripcion.MaxLength = 1000
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(413, 37)
        Me.TxtDescripcion.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(104, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 25)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Descripción:"
        '
        'TxtMonto
        '
        Me.TxtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMonto.ForeColor = System.Drawing.Color.Blue
        Me.TxtMonto.Location = New System.Drawing.Point(241, 143)
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Size = New System.Drawing.Size(119, 31)
        Me.TxtMonto.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnAgregar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(85, 211)
        Me.Panel1.TabIndex = 19
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(12, 102)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(59, 70)
        Me.BtnSalir.TabIndex = 5
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnAgregar
        '
        Me.BtnAgregar.BackColor = System.Drawing.Color.White
        Me.BtnAgregar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnAgregar.Location = New System.Drawing.Point(12, 12)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(59, 70)
        Me.BtnAgregar.TabIndex = 4
        Me.BtnAgregar.Text = "Agregar"
        Me.BtnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAgregar.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(106, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 25)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Motivo:"
        '
        'CmbMotivo
        '
        Me.CmbMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbMotivo.FormattingEnabled = True
        Me.CmbMotivo.Location = New System.Drawing.Point(241, 29)
        Me.CmbMotivo.Name = "CmbMotivo"
        Me.CmbMotivo.Size = New System.Drawing.Size(413, 33)
        Me.CmbMotivo.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Green
        Me.Label4.Location = New System.Drawing.Point(391, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 25)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Pago con:"
        '
        'TxtPagaCon
        '
        Me.TxtPagaCon.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPagaCon.ForeColor = System.Drawing.Color.Green
        Me.TxtPagaCon.Location = New System.Drawing.Point(535, 143)
        Me.TxtPagaCon.Name = "TxtPagaCon"
        Me.TxtPagaCon.Size = New System.Drawing.Size(119, 31)
        Me.TxtPagaCon.TabIndex = 3
        '
        'FrmEntradaEfectivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(696, 211)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtPagaCon)
        Me.Controls.Add(Me.CmbMotivo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtDescripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtMonto)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEntradaEfectivo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Entrada de efectivo"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TxtDescripcion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtMonto As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnAgregar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents CmbMotivo As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtPagaCon As TextBox
End Class
