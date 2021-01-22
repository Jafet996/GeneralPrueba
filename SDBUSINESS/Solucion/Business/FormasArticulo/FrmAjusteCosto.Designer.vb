<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAjusteCosto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAjusteCosto))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblSucursal = New System.Windows.Forms.Label()
        Me.CmbSucursal = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupPrecio = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtCostoNuevo = New System.Windows.Forms.TextBox()
        Me.TxtCosto = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.LblNombreArticulo = New System.Windows.Forms.Label()
        Me.GroupBodega = New System.Windows.Forms.GroupBox()
        Me.ChkTodas = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblExento = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupPrecio.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBodega.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(129, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sucursal"
        '
        'LblSucursal
        '
        Me.LblSucursal.BackColor = System.Drawing.Color.White
        Me.LblSucursal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblSucursal.Location = New System.Drawing.Point(211, 15)
        Me.LblSucursal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSucursal.Name = "LblSucursal"
        Me.LblSucursal.Size = New System.Drawing.Size(577, 26)
        Me.LblSucursal.TabIndex = 1
        Me.LblSucursal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbSucursal
        '
        Me.CmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSucursal.FormattingEnabled = True
        Me.CmbSucursal.Location = New System.Drawing.Point(77, 27)
        Me.CmbSucursal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(300, 24)
        Me.CmbSucursal.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 31)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Sucursal"
        '
        'GroupPrecio
        '
        Me.GroupPrecio.Controls.Add(Me.Label5)
        Me.GroupPrecio.Controls.Add(Me.TxtCostoNuevo)
        Me.GroupPrecio.Controls.Add(Me.TxtCosto)
        Me.GroupPrecio.Controls.Add(Me.Label9)
        Me.GroupPrecio.Enabled = False
        Me.GroupPrecio.Location = New System.Drawing.Point(133, 187)
        Me.GroupPrecio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupPrecio.Name = "GroupPrecio"
        Me.GroupPrecio.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupPrecio.Size = New System.Drawing.Size(655, 186)
        Me.GroupPrecio.TabIndex = 26
        Me.GroupPrecio.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(356, 91)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 17)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Costo Nuevo"
        '
        'TxtCostoNuevo
        '
        Me.TxtCostoNuevo.Location = New System.Drawing.Point(456, 87)
        Me.TxtCostoNuevo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCostoNuevo.Name = "TxtCostoNuevo"
        Me.TxtCostoNuevo.Size = New System.Drawing.Size(113, 22)
        Me.TxtCostoNuevo.TabIndex = 24
        Me.TxtCostoNuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtCosto
        '
        Me.TxtCosto.Location = New System.Drawing.Point(152, 87)
        Me.TxtCosto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCosto.Name = "TxtCosto"
        Me.TxtCosto.ReadOnly = True
        Me.TxtCosto.Size = New System.Drawing.Size(113, 22)
        Me.TxtCosto.TabIndex = 15
        Me.TxtCosto.TabStop = False
        Me.TxtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(47, 91)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 17)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Costo Anterior"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnLimpiar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnGuardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(98, 388)
        Me.Panel1.TabIndex = 27
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.BackColor = System.Drawing.Color.White
        Me.BtnLimpiar.Image = Global.Business.My.Resources.Resources.Blue_F4
        Me.BtnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnLimpiar.Location = New System.Drawing.Point(10, 100)
        Me.BtnLimpiar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(76, 80)
        Me.BtnLimpiar.TabIndex = 2
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnLimpiar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Business.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnSalir.Location = New System.Drawing.Point(10, 188)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(76, 80)
        Me.BtnSalir.TabIndex = 1
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.BackColor = System.Drawing.Color.White
        Me.BtnGuardar.Image = Global.Business.My.Resources.Resources.Blue_F3
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnGuardar.Location = New System.Drawing.Point(10, 12)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(76, 80)
        Me.BtnGuardar.TabIndex = 0
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnGuardar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(129, 53)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 17)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Código"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Location = New System.Drawing.Point(211, 49)
        Me.TxtCodigo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodigo.MaxLength = 13
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(160, 22)
        Me.TxtCodigo.TabIndex = 29
        '
        'LblNombreArticulo
        '
        Me.LblNombreArticulo.BackColor = System.Drawing.Color.White
        Me.LblNombreArticulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblNombreArticulo.Location = New System.Drawing.Point(211, 80)
        Me.LblNombreArticulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreArticulo.Name = "LblNombreArticulo"
        Me.LblNombreArticulo.Size = New System.Drawing.Size(432, 25)
        Me.LblNombreArticulo.TabIndex = 32
        Me.LblNombreArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBodega
        '
        Me.GroupBodega.Controls.Add(Me.ChkTodas)
        Me.GroupBodega.Controls.Add(Me.CmbSucursal)
        Me.GroupBodega.Controls.Add(Me.Label2)
        Me.GroupBodega.Enabled = False
        Me.GroupBodega.Location = New System.Drawing.Point(133, 108)
        Me.GroupBodega.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBodega.Name = "GroupBodega"
        Me.GroupBodega.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBodega.Size = New System.Drawing.Size(655, 71)
        Me.GroupBodega.TabIndex = 33
        Me.GroupBodega.TabStop = False
        '
        'ChkTodas
        '
        Me.ChkTodas.AutoSize = True
        Me.ChkTodas.Location = New System.Drawing.Point(409, 31)
        Me.ChkTodas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ChkTodas.Name = "ChkTodas"
        Me.ChkTodas.Size = New System.Drawing.Size(228, 21)
        Me.ChkTodas.TabIndex = 4
        Me.ChkTodas.Text = "Aplicar en todas las Sucursales"
        Me.ChkTodas.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(651, 85)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 17)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Exento"
        '
        'LblExento
        '
        Me.LblExento.BackColor = System.Drawing.Color.White
        Me.LblExento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblExento.Location = New System.Drawing.Point(712, 80)
        Me.LblExento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblExento.Name = "LblExento"
        Me.LblExento.Size = New System.Drawing.Size(76, 25)
        Me.LblExento.TabIndex = 35
        Me.LblExento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(129, 85)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 17)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Nombre"
        '
        'FrmAjusteCosto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(797, 388)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblExento)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBodega)
        Me.Controls.Add(Me.LblNombreArticulo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtCodigo)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupPrecio)
        Me.Controls.Add(Me.LblSucursal)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAjusteCosto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Artículo x Bodega"
        Me.GroupPrecio.ResumeLayout(False)
        Me.GroupPrecio.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBodega.ResumeLayout(False)
        Me.GroupBodega.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblSucursal As System.Windows.Forms.Label
    Friend WithEvents CmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupPrecio As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCosto As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents LblNombreArticulo As System.Windows.Forms.Label
    Friend WithEvents GroupBodega As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblExento As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ChkTodas As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtCostoNuevo As System.Windows.Forms.TextBox
End Class
