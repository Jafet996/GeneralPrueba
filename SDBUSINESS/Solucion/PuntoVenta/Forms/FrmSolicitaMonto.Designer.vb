<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSolicitaMonto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSolicitaMonto))
        Me.TxtMonto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCantidad = New System.Windows.Forms.TextBox()
        Me.LblArticulo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblPrecio = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnViente = New System.Windows.Forms.Button()
        Me.BtnQuince = New System.Windows.Forms.Button()
        Me.BtnDiez = New System.Windows.Forms.Button()
        Me.BtnCinco = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblUnidadMedida = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtMonto
        '
        Me.TxtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMonto.Location = New System.Drawing.Point(254, 294)
        Me.TxtMonto.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Size = New System.Drawing.Size(225, 37)
        Me.TxtMonto.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label1.Location = New System.Drawing.Point(126, 299)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Monto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(126, 354)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 31)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Cantidad"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidad.Location = New System.Drawing.Point(254, 349)
        Me.TxtCantidad.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.ReadOnly = True
        Me.TxtCantidad.Size = New System.Drawing.Size(225, 37)
        Me.TxtCantidad.TabIndex = 2
        '
        'LblArticulo
        '
        Me.LblArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArticulo.ForeColor = System.Drawing.Color.DarkGreen
        Me.LblArticulo.Location = New System.Drawing.Point(109, 130)
        Me.LblArticulo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblArticulo.Name = "LblArticulo"
        Me.LblArticulo.Size = New System.Drawing.Size(401, 41)
        Me.LblArticulo.TabIndex = 4
        Me.LblArticulo.Text = "Nombre Articulo"
        Me.LblArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnAceptar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(96, 414)
        Me.Panel1.TabIndex = 19
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.ForeColor = System.Drawing.Color.DarkBlue
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnSalir.Location = New System.Drawing.Point(4, 108)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(87, 82)
        Me.BtnSalir.TabIndex = 5
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.White
        Me.BtnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAceptar.ForeColor = System.Drawing.Color.DarkBlue
        Me.BtnAceptar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnAceptar.Location = New System.Drawing.Point(4, 12)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(87, 90)
        Me.BtnAceptar.TabIndex = 4
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Indigo
        Me.Label3.Location = New System.Drawing.Point(112, 220)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(207, 31)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Precio Unitario :"
        '
        'LblPrecio
        '
        Me.LblPrecio.AutoSize = True
        Me.LblPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrecio.ForeColor = System.Drawing.Color.Indigo
        Me.LblPrecio.Location = New System.Drawing.Point(322, 220)
        Me.LblPrecio.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblPrecio.Name = "LblPrecio"
        Me.LblPrecio.Size = New System.Drawing.Size(74, 31)
        Me.LblPrecio.TabIndex = 21
        Me.LblPrecio.Text = "0000"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel2.Controls.Add(Me.BtnViente)
        Me.Panel2.Controls.Add(Me.BtnQuince)
        Me.Panel2.Controls.Add(Me.BtnDiez)
        Me.Panel2.Controls.Add(Me.BtnCinco)
        Me.Panel2.Location = New System.Drawing.Point(98, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(430, 102)
        Me.Panel2.TabIndex = 22
        '
        'BtnViente
        '
        Me.BtnViente.BackColor = System.Drawing.Color.White
        Me.BtnViente.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnViente.ForeColor = System.Drawing.Color.OrangeRed
        Me.BtnViente.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F7
        Me.BtnViente.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnViente.Location = New System.Drawing.Point(325, 11)
        Me.BtnViente.Name = "BtnViente"
        Me.BtnViente.Size = New System.Drawing.Size(87, 80)
        Me.BtnViente.TabIndex = 9
        Me.BtnViente.Text = "20,000"
        Me.BtnViente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnViente.UseVisualStyleBackColor = False
        '
        'BtnQuince
        '
        Me.BtnQuince.BackColor = System.Drawing.Color.White
        Me.BtnQuince.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnQuince.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F6
        Me.BtnQuince.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnQuince.Location = New System.Drawing.Point(227, 11)
        Me.BtnQuince.Name = "BtnQuince"
        Me.BtnQuince.Size = New System.Drawing.Size(87, 80)
        Me.BtnQuince.TabIndex = 8
        Me.BtnQuince.Text = "15,000"
        Me.BtnQuince.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnQuince.UseVisualStyleBackColor = False
        '
        'BtnDiez
        '
        Me.BtnDiez.BackColor = System.Drawing.Color.White
        Me.BtnDiez.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDiez.ForeColor = System.Drawing.Color.DarkGreen
        Me.BtnDiez.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F5
        Me.BtnDiez.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnDiez.Location = New System.Drawing.Point(124, 11)
        Me.BtnDiez.Name = "BtnDiez"
        Me.BtnDiez.Size = New System.Drawing.Size(87, 80)
        Me.BtnDiez.TabIndex = 7
        Me.BtnDiez.Text = "10,000"
        Me.BtnDiez.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnDiez.UseVisualStyleBackColor = False
        '
        'BtnCinco
        '
        Me.BtnCinco.BackColor = System.Drawing.Color.White
        Me.BtnCinco.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCinco.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.BtnCinco.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F4
        Me.BtnCinco.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnCinco.Location = New System.Drawing.Point(17, 11)
        Me.BtnCinco.Name = "BtnCinco"
        Me.BtnCinco.Size = New System.Drawing.Size(87, 80)
        Me.BtnCinco.TabIndex = 6
        Me.BtnCinco.Text = "5,000"
        Me.BtnCinco.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnCinco.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Indigo
        Me.Label4.Location = New System.Drawing.Point(109, 177)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(210, 31)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Unidad Medida :"
        '
        'LblUnidadMedida
        '
        Me.LblUnidadMedida.AutoSize = True
        Me.LblUnidadMedida.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUnidadMedida.ForeColor = System.Drawing.Color.Indigo
        Me.LblUnidadMedida.Location = New System.Drawing.Point(319, 177)
        Me.LblUnidadMedida.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblUnidadMedida.Name = "LblUnidadMedida"
        Me.LblUnidadMedida.Size = New System.Drawing.Size(100, 31)
        Me.LblUnidadMedida.TabIndex = 24
        Me.LblUnidadMedida.Text = "Unidad"
        '
        'FrmSolicitaMonto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(529, 414)
        Me.Controls.Add(Me.LblUnidadMedida)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.LblPrecio)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LblArticulo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtCantidad)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtMonto)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSolicitaMonto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Monto a vender"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtMonto As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtCantidad As TextBox
    Friend WithEvents LblArticulo As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnAceptar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents LblPrecio As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnViente As Button
    Friend WithEvents BtnQuince As Button
    Friend WithEvents BtnDiez As Button
    Friend WithEvents BtnCinco As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents LblUnidadMedida As Label
End Class
