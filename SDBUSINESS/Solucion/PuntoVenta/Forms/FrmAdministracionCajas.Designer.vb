<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAdministracionCajas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAdministracionCajas))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmbCaja = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GrpFromasPago = New System.Windows.Forms.GroupBox()
        Me.TxtDocumentos = New System.Windows.Forms.TextBox()
        Me.LblSalidas = New System.Windows.Forms.Label()
        Me.TxtCheques = New System.Windows.Forms.TextBox()
        Me.LblTranferencia = New System.Windows.Forms.Label()
        Me.TxtDolares = New System.Windows.Forms.TextBox()
        Me.LblDolares = New System.Windows.Forms.Label()
        Me.TxtTarjetas = New System.Windows.Forms.TextBox()
        Me.lblTarjetas = New System.Windows.Forms.Label()
        Me.TxtEfectivo = New System.Windows.Forms.TextBox()
        Me.lblEfectivo = New System.Windows.Forms.Label()
        Me.CmbSucursal = New System.Windows.Forms.ComboBox()
        Me.BtnAccion = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GrpFromasPago.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnAccion)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(70, 290)
        Me.Panel1.TabIndex = 7
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(3, 88)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(60, 71)
        Me.BtnSalir.TabIndex = 7
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmbSucursal)
        Me.GroupBox1.Controls.Add(Me.CmbCaja)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(92, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(376, 94)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información  de cajas"
        '
        'CmbCaja
        '
        Me.CmbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCaja.FormattingEnabled = True
        Me.CmbCaja.Location = New System.Drawing.Point(72, 54)
        Me.CmbCaja.Name = "CmbCaja"
        Me.CmbCaja.Size = New System.Drawing.Size(288, 21)
        Me.CmbCaja.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Caja"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Sucursal"
        '
        'GrpFromasPago
        '
        Me.GrpFromasPago.Controls.Add(Me.TxtDocumentos)
        Me.GrpFromasPago.Controls.Add(Me.LblSalidas)
        Me.GrpFromasPago.Controls.Add(Me.TxtCheques)
        Me.GrpFromasPago.Controls.Add(Me.LblTranferencia)
        Me.GrpFromasPago.Controls.Add(Me.TxtDolares)
        Me.GrpFromasPago.Controls.Add(Me.LblDolares)
        Me.GrpFromasPago.Controls.Add(Me.TxtTarjetas)
        Me.GrpFromasPago.Controls.Add(Me.lblTarjetas)
        Me.GrpFromasPago.Controls.Add(Me.TxtEfectivo)
        Me.GrpFromasPago.Controls.Add(Me.lblEfectivo)
        Me.GrpFromasPago.Location = New System.Drawing.Point(92, 112)
        Me.GrpFromasPago.Name = "GrpFromasPago"
        Me.GrpFromasPago.Size = New System.Drawing.Size(376, 153)
        Me.GrpFromasPago.TabIndex = 20
        Me.GrpFromasPago.TabStop = False
        Me.GrpFromasPago.Text = "Formas de pago."
        Me.GrpFromasPago.Visible = False
        '
        'TxtDocumentos
        '
        Me.TxtDocumentos.Location = New System.Drawing.Point(101, 122)
        Me.TxtDocumentos.Name = "TxtDocumentos"
        Me.TxtDocumentos.Size = New System.Drawing.Size(259, 20)
        Me.TxtDocumentos.TabIndex = 9
        '
        'LblSalidas
        '
        Me.LblSalidas.AutoSize = True
        Me.LblSalidas.Location = New System.Drawing.Point(21, 125)
        Me.LblSalidas.Name = "LblSalidas"
        Me.LblSalidas.Size = New System.Drawing.Size(41, 13)
        Me.LblSalidas.TabIndex = 8
        Me.LblSalidas.Text = "Salidas"
        '
        'TxtCheques
        '
        Me.TxtCheques.Location = New System.Drawing.Point(101, 95)
        Me.TxtCheques.Name = "TxtCheques"
        Me.TxtCheques.Size = New System.Drawing.Size(259, 20)
        Me.TxtCheques.TabIndex = 7
        '
        'LblTranferencia
        '
        Me.LblTranferencia.AutoSize = True
        Me.LblTranferencia.Location = New System.Drawing.Point(21, 98)
        Me.LblTranferencia.Name = "LblTranferencia"
        Me.LblTranferencia.Size = New System.Drawing.Size(77, 13)
        Me.LblTranferencia.TabIndex = 6
        Me.LblTranferencia.Text = "Transferencias"
        '
        'TxtDolares
        '
        Me.TxtDolares.Location = New System.Drawing.Point(101, 69)
        Me.TxtDolares.Name = "TxtDolares"
        Me.TxtDolares.Size = New System.Drawing.Size(259, 20)
        Me.TxtDolares.TabIndex = 5
        '
        'LblDolares
        '
        Me.LblDolares.AutoSize = True
        Me.LblDolares.Location = New System.Drawing.Point(21, 72)
        Me.LblDolares.Name = "LblDolares"
        Me.LblDolares.Size = New System.Drawing.Size(43, 13)
        Me.LblDolares.TabIndex = 4
        Me.LblDolares.Text = "Dólares"
        '
        'TxtTarjetas
        '
        Me.TxtTarjetas.Location = New System.Drawing.Point(101, 43)
        Me.TxtTarjetas.Name = "TxtTarjetas"
        Me.TxtTarjetas.Size = New System.Drawing.Size(259, 20)
        Me.TxtTarjetas.TabIndex = 3
        '
        'lblTarjetas
        '
        Me.lblTarjetas.AutoSize = True
        Me.lblTarjetas.Location = New System.Drawing.Point(21, 46)
        Me.lblTarjetas.Name = "lblTarjetas"
        Me.lblTarjetas.Size = New System.Drawing.Size(45, 13)
        Me.lblTarjetas.TabIndex = 2
        Me.lblTarjetas.Text = "Tarjetas"
        '
        'TxtEfectivo
        '
        Me.TxtEfectivo.Location = New System.Drawing.Point(101, 17)
        Me.TxtEfectivo.Name = "TxtEfectivo"
        Me.TxtEfectivo.Size = New System.Drawing.Size(259, 20)
        Me.TxtEfectivo.TabIndex = 1
        '
        'lblEfectivo
        '
        Me.lblEfectivo.AutoSize = True
        Me.lblEfectivo.Location = New System.Drawing.Point(21, 20)
        Me.lblEfectivo.Name = "lblEfectivo"
        Me.lblEfectivo.Size = New System.Drawing.Size(46, 13)
        Me.lblEfectivo.TabIndex = 0
        Me.lblEfectivo.Text = "Efectivo"
        '
        'CmbSucursal
        '
        Me.CmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSucursal.FormattingEnabled = True
        Me.CmbSucursal.Location = New System.Drawing.Point(73, 27)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(287, 21)
        Me.CmbSucursal.TabIndex = 15
        '
        'BtnAccion
        '
        Me.BtnAccion.BackColor = System.Drawing.Color.White
        Me.BtnAccion.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnAccion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnAccion.Location = New System.Drawing.Point(3, 12)
        Me.BtnAccion.Name = "BtnAccion"
        Me.BtnAccion.Size = New System.Drawing.Size(59, 69)
        Me.BtnAccion.TabIndex = 8
        Me.BtnAccion.Text = "Accion"
        Me.BtnAccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnAccion.UseVisualStyleBackColor = False
        '
        'FrmAdministracionCajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(480, 290)
        Me.Controls.Add(Me.GrpFromasPago)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAdministracionCajas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administracion de cajas"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GrpFromasPago.ResumeLayout(False)
        Me.GrpFromasPago.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnSalir As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CmbCaja As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GrpFromasPago As GroupBox
    Friend WithEvents TxtCheques As TextBox
    Friend WithEvents LblTranferencia As Label
    Friend WithEvents TxtDolares As TextBox
    Friend WithEvents LblDolares As Label
    Friend WithEvents TxtTarjetas As TextBox
    Friend WithEvents lblTarjetas As Label
    Friend WithEvents TxtEfectivo As TextBox
    Friend WithEvents lblEfectivo As Label
    Friend WithEvents TxtDocumentos As TextBox
    Friend WithEvents LblSalidas As Label
    Friend WithEvents CmbSucursal As ComboBox
    Friend WithEvents BtnAccion As Button
End Class
