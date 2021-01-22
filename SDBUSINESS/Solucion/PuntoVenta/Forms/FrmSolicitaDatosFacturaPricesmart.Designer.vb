<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSolicitaDatosFacturaPricesmart
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSolicitaDatosFacturaPricesmart))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DtpFechaOrden = New System.Windows.Forms.DateTimePicker()
        Me.TxtNumeroDeOrden = New System.Windows.Forms.TextBox()
        Me.LblCodigo = New System.Windows.Forms.Label()
        Me.CmbLugarDeEntrega = New System.Windows.Forms.ComboBox()
        Me.TxtCodigoProveedor = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(44, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(207, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Numero de proveedor:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(45, 69)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(166, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Lugar de entrega:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(44, 124)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(169, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Numero de orden:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(44, 177)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(155, 25)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Fecha de orden:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DtpFechaOrden)
        Me.GroupBox1.Controls.Add(Me.TxtNumeroDeOrden)
        Me.GroupBox1.Controls.Add(Me.LblCodigo)
        Me.GroupBox1.Controls.Add(Me.CmbLugarDeEntrega)
        Me.GroupBox1.Controls.Add(Me.TxtCodigoProveedor)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(132, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(715, 229)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Requeridos"
        '
        'DtpFechaOrden
        '
        Me.DtpFechaOrden.Location = New System.Drawing.Point(327, 176)
        Me.DtpFechaOrden.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DtpFechaOrden.Name = "DtpFechaOrden"
        Me.DtpFechaOrden.Size = New System.Drawing.Size(375, 22)
        Me.DtpFechaOrden.TabIndex = 8
        '
        'TxtNumeroDeOrden
        '
        Me.TxtNumeroDeOrden.Location = New System.Drawing.Point(327, 127)
        Me.TxtNumeroDeOrden.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtNumeroDeOrden.Name = "TxtNumeroDeOrden"
        Me.TxtNumeroDeOrden.Size = New System.Drawing.Size(375, 22)
        Me.TxtNumeroDeOrden.TabIndex = 7
        '
        'LblCodigo
        '
        Me.LblCodigo.AutoSize = True
        Me.LblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCodigo.Location = New System.Drawing.Point(560, 71)
        Me.LblCodigo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(80, 25)
        Me.LblCodigo.TabIndex = 6
        Me.LblCodigo.Text = "Codigo "
        '
        'CmbLugarDeEntrega
        '
        Me.CmbLugarDeEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbLugarDeEntrega.FormattingEnabled = True
        Me.CmbLugarDeEntrega.Location = New System.Drawing.Point(327, 71)
        Me.CmbLugarDeEntrega.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmbLugarDeEntrega.Name = "CmbLugarDeEntrega"
        Me.CmbLugarDeEntrega.Size = New System.Drawing.Size(224, 24)
        Me.CmbLugarDeEntrega.TabIndex = 5
        '
        'TxtCodigoProveedor
        '
        Me.TxtCodigoProveedor.Location = New System.Drawing.Point(327, 20)
        Me.TxtCodigoProveedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodigoProveedor.Name = "TxtCodigoProveedor"
        Me.TxtCodigoProveedor.Size = New System.Drawing.Size(375, 22)
        Me.TxtCodigoProveedor.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnAceptar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(103, 261)
        Me.Panel1.TabIndex = 11
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.White
        Me.BtnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnAceptar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnAceptar.Location = New System.Drawing.Point(8, 14)
        Me.BtnAceptar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(83, 95)
        Me.BtnAceptar.TabIndex = 6
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(8, 116)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(83, 95)
        Me.BtnSalir.TabIndex = 5
        Me.BtnSalir.Text = "Cancelar"
        Me.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'FrmSolicitaDatosFacturaPricesmart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(867, 261)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSolicitaDatosFacturaPricesmart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datos Factura Pricesmart"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DtpFechaOrden As DateTimePicker
    Friend WithEvents TxtNumeroDeOrden As TextBox
    Friend WithEvents LblCodigo As Label
    Friend WithEvents CmbLugarDeEntrega As ComboBox
    Friend WithEvents TxtCodigoProveedor As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnAceptar As Button
End Class
