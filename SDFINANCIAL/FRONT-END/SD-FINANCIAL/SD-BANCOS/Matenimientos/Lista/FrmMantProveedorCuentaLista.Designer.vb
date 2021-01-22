<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantProveedorCuentaLista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantProveedorCuentaLista))
        Me.PicBorrar = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DGDetalle = New System.Windows.Forms.DataGridView()
        Me.GroupLista = New System.Windows.Forms.GroupBox()
        Me.TxtCriterio = New System.Windows.Forms.TextBox()
        Me.GroupOpciones = New System.Windows.Forms.GroupBox()
        Me.BtnProveedor = New System.Windows.Forms.Button()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.BtnRefrescar = New System.Windows.Forms.Button()
        Me.BtnModificar = New System.Windows.Forms.Button()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.GroupEncabezado = New System.Windows.Forms.GroupBox()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.PicBorrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupLista.SuspendLayout()
        Me.GroupOpciones.SuspendLayout()
        Me.GroupEncabezado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PicBorrar
        '
        Me.PicBorrar.Cursor = System.Windows.Forms.Cursors.Default
        Me.PicBorrar.Location = New System.Drawing.Point(543, 21)
        Me.PicBorrar.Name = "PicBorrar"
        Me.PicBorrar.Size = New System.Drawing.Size(20, 20)
        Me.PicBorrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicBorrar.TabIndex = 3
        Me.PicBorrar.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Criterio"
        '
        'DGDetalle
        '
        Me.DGDetalle.AllowUserToAddRows = False
        Me.DGDetalle.AllowUserToDeleteRows = False
        Me.DGDetalle.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.DGDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDetalle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DGDetalle.Location = New System.Drawing.Point(3, 59)
        Me.DGDetalle.Name = "DGDetalle"
        Me.DGDetalle.ReadOnly = True
        Me.DGDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DGDetalle.Size = New System.Drawing.Size(600, 382)
        Me.DGDetalle.TabIndex = 0
        '
        'GroupLista
        '
        Me.GroupLista.Controls.Add(Me.PicBorrar)
        Me.GroupLista.Controls.Add(Me.Label1)
        Me.GroupLista.Controls.Add(Me.TxtCriterio)
        Me.GroupLista.Controls.Add(Me.DGDetalle)
        Me.GroupLista.Location = New System.Drawing.Point(101, 94)
        Me.GroupLista.Name = "GroupLista"
        Me.GroupLista.Size = New System.Drawing.Size(606, 444)
        Me.GroupLista.TabIndex = 15
        Me.GroupLista.TabStop = False
        '
        'TxtCriterio
        '
        Me.TxtCriterio.Location = New System.Drawing.Point(104, 21)
        Me.TxtCriterio.Name = "TxtCriterio"
        Me.TxtCriterio.Size = New System.Drawing.Size(438, 20)
        Me.TxtCriterio.TabIndex = 1
        '
        'GroupOpciones
        '
        Me.GroupOpciones.BackColor = System.Drawing.Color.SteelBlue
        Me.GroupOpciones.Controls.Add(Me.BtnProveedor)
        Me.GroupOpciones.Controls.Add(Me.BtnNuevo)
        Me.GroupOpciones.Controls.Add(Me.BtnEliminar)
        Me.GroupOpciones.Controls.Add(Me.BtnRefrescar)
        Me.GroupOpciones.Controls.Add(Me.BtnModificar)
        Me.GroupOpciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupOpciones.Location = New System.Drawing.Point(0, 90)
        Me.GroupOpciones.Name = "GroupOpciones"
        Me.GroupOpciones.Size = New System.Drawing.Size(96, 451)
        Me.GroupOpciones.TabIndex = 14
        Me.GroupOpciones.TabStop = False
        '
        'BtnProveedor
        '
        Me.BtnProveedor.BackColor = System.Drawing.Color.White
        Me.BtnProveedor.Location = New System.Drawing.Point(11, 196)
        Me.BtnProveedor.Name = "BtnProveedor"
        Me.BtnProveedor.Size = New System.Drawing.Size(75, 38)
        Me.BtnProveedor.TabIndex = 5
        Me.BtnProveedor.Text = "Proveedor"
        Me.BtnProveedor.UseVisualStyleBackColor = False
        '
        'BtnNuevo
        '
        Me.BtnNuevo.BackColor = System.Drawing.Color.White
        Me.BtnNuevo.Location = New System.Drawing.Point(11, 19)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(75, 38)
        Me.BtnNuevo.TabIndex = 0
        Me.BtnNuevo.Text = "Nuevo"
        Me.BtnNuevo.UseVisualStyleBackColor = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.Color.White
        Me.BtnEliminar.Enabled = False
        Me.BtnEliminar.Location = New System.Drawing.Point(11, 107)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(75, 38)
        Me.BtnEliminar.TabIndex = 2
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'BtnRefrescar
        '
        Me.BtnRefrescar.BackColor = System.Drawing.Color.White
        Me.BtnRefrescar.Location = New System.Drawing.Point(11, 151)
        Me.BtnRefrescar.Name = "BtnRefrescar"
        Me.BtnRefrescar.Size = New System.Drawing.Size(75, 38)
        Me.BtnRefrescar.TabIndex = 4
        Me.BtnRefrescar.Text = "Refrescar"
        Me.BtnRefrescar.UseVisualStyleBackColor = False
        '
        'BtnModificar
        '
        Me.BtnModificar.BackColor = System.Drawing.Color.White
        Me.BtnModificar.Enabled = False
        Me.BtnModificar.Location = New System.Drawing.Point(11, 63)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(75, 38)
        Me.BtnModificar.TabIndex = 3
        Me.BtnModificar.Text = "Modificar"
        Me.BtnModificar.UseVisualStyleBackColor = False
        '
        'TxtNombre
        '
        Me.TxtNombre.BackColor = System.Drawing.Color.White
        Me.TxtNombre.Location = New System.Drawing.Point(211, 21)
        Me.TxtNombre.MaxLength = 50
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.ReadOnly = True
        Me.TxtNombre.Size = New System.Drawing.Size(332, 20)
        Me.TxtNombre.TabIndex = 61
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Location = New System.Drawing.Point(632, 12)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(75, 38)
        Me.BtnSalir.TabIndex = 1
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "Proveedor"
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.BackColor = System.Drawing.Color.White
        Me.BtnLimpiar.Location = New System.Drawing.Point(551, 12)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(75, 38)
        Me.BtnLimpiar.TabIndex = 63
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.UseVisualStyleBackColor = False
        '
        'GroupEncabezado
        '
        Me.GroupEncabezado.BackColor = System.Drawing.Color.SteelBlue
        Me.GroupEncabezado.Controls.Add(Me.BtnLimpiar)
        Me.GroupEncabezado.Controls.Add(Me.BtnSalir)
        Me.GroupEncabezado.Controls.Add(Me.Label2)
        Me.GroupEncabezado.Controls.Add(Me.TxtNumero)
        Me.GroupEncabezado.Controls.Add(Me.TxtNombre)
        Me.GroupEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupEncabezado.Location = New System.Drawing.Point(0, 31)
        Me.GroupEncabezado.Name = "GroupEncabezado"
        Me.GroupEncabezado.Size = New System.Drawing.Size(716, 59)
        Me.GroupEncabezado.TabIndex = 13
        Me.GroupEncabezado.TabStop = False
        '
        'TxtNumero
        '
        Me.TxtNumero.BackColor = System.Drawing.Color.White
        Me.TxtNumero.Location = New System.Drawing.Point(105, 21)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(100, 20)
        Me.TxtNumero.TabIndex = 60
        Me.TxtNumero.TabStop = False
        '
        'LblTitulo
        '
        Me.LblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.SystemColors.Window
        Me.LblTitulo.Location = New System.Drawing.Point(8, 4)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(548, 23)
        Me.LblTitulo.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.LblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(716, 31)
        Me.Panel1.TabIndex = 12
        '
        'FrmMantProveedorCuentaLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(716, 541)
        Me.Controls.Add(Me.GroupLista)
        Me.Controls.Add(Me.GroupOpciones)
        Me.Controls.Add(Me.GroupEncabezado)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantProveedorCuentaLista"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PicBorrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupLista.ResumeLayout(False)
        Me.GroupLista.PerformLayout()
        Me.GroupOpciones.ResumeLayout(False)
        Me.GroupEncabezado.ResumeLayout(False)
        Me.GroupEncabezado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PicBorrar As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents GroupLista As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCriterio As System.Windows.Forms.TextBox
    Friend WithEvents GroupOpciones As System.Windows.Forms.GroupBox
    Friend WithEvents BtnProveedor As System.Windows.Forms.Button
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents BtnRefrescar As System.Windows.Forms.Button
    Friend WithEvents BtnModificar As System.Windows.Forms.Button
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents GroupEncabezado As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
