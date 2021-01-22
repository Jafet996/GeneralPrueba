<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantTecnicoLista
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.GroupOpciones = New System.Windows.Forms.GroupBox()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.BtnRefrescar = New System.Windows.Forms.Button()
        Me.BtnModificar = New System.Windows.Forms.Button()
        Me.GroupLista = New System.Windows.Forms.GroupBox()
        Me.PicBorrar = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtCriterio = New System.Windows.Forms.TextBox()
        Me.DGDetalle = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        Me.GroupOpciones.SuspendLayout()
        Me.GroupLista.SuspendLayout()
        CType(Me.PicBorrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.LblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(601, 31)
        Me.Panel1.TabIndex = 8
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
        'GroupOpciones
        '
        Me.GroupOpciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.GroupOpciones.Controls.Add(Me.BtnNuevo)
        Me.GroupOpciones.Controls.Add(Me.BtnSalir)
        Me.GroupOpciones.Controls.Add(Me.BtnEliminar)
        Me.GroupOpciones.Controls.Add(Me.BtnRefrescar)
        Me.GroupOpciones.Controls.Add(Me.BtnModificar)
        Me.GroupOpciones.Location = New System.Drawing.Point(0, 37)
        Me.GroupOpciones.Name = "GroupOpciones"
        Me.GroupOpciones.Size = New System.Drawing.Size(96, 407)
        Me.GroupOpciones.TabIndex = 9
        Me.GroupOpciones.TabStop = False
        '
        'BtnNuevo
        '
        Me.BtnNuevo.BackColor = System.Drawing.Color.White
        Me.BtnNuevo.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F7
        Me.BtnNuevo.Location = New System.Drawing.Point(17, 19)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(62, 71)
        Me.BtnNuevo.TabIndex = 0
        Me.BtnNuevo.Text = "Nuevo"
        Me.BtnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnNuevo.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(17, 228)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(62, 71)
        Me.BtnSalir.TabIndex = 1
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.Color.White
        Me.BtnEliminar.Enabled = False
        Me.BtnEliminar.Location = New System.Drawing.Point(17, 140)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(62, 38)
        Me.BtnEliminar.TabIndex = 2
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'BtnRefrescar
        '
        Me.BtnRefrescar.BackColor = System.Drawing.Color.White
        Me.BtnRefrescar.Location = New System.Drawing.Point(17, 184)
        Me.BtnRefrescar.Name = "BtnRefrescar"
        Me.BtnRefrescar.Size = New System.Drawing.Size(62, 38)
        Me.BtnRefrescar.TabIndex = 4
        Me.BtnRefrescar.Text = "Refrescar"
        Me.BtnRefrescar.UseVisualStyleBackColor = False
        '
        'BtnModificar
        '
        Me.BtnModificar.BackColor = System.Drawing.Color.White
        Me.BtnModificar.Enabled = False
        Me.BtnModificar.Location = New System.Drawing.Point(17, 96)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(62, 38)
        Me.BtnModificar.TabIndex = 3
        Me.BtnModificar.Text = "Modificar"
        Me.BtnModificar.UseVisualStyleBackColor = False
        '
        'GroupLista
        '
        Me.GroupLista.Controls.Add(Me.PicBorrar)
        Me.GroupLista.Controls.Add(Me.Label1)
        Me.GroupLista.Controls.Add(Me.TxtCriterio)
        Me.GroupLista.Controls.Add(Me.DGDetalle)
        Me.GroupLista.Location = New System.Drawing.Point(102, 37)
        Me.GroupLista.Name = "GroupLista"
        Me.GroupLista.Size = New System.Drawing.Size(491, 407)
        Me.GroupLista.TabIndex = 10
        Me.GroupLista.TabStop = False
        '
        'PicBorrar
        '
        Me.PicBorrar.Location = New System.Drawing.Point(459, 19)
        Me.PicBorrar.Name = "PicBorrar"
        Me.PicBorrar.Size = New System.Drawing.Size(20, 20)
        Me.PicBorrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicBorrar.TabIndex = 3
        Me.PicBorrar.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Criterio"
        '
        'TxtCriterio
        '
        Me.TxtCriterio.Location = New System.Drawing.Point(55, 19)
        Me.TxtCriterio.Name = "TxtCriterio"
        Me.TxtCriterio.Size = New System.Drawing.Size(404, 20)
        Me.TxtCriterio.TabIndex = 1
        '
        'DGDetalle
        '
        Me.DGDetalle.AllowUserToAddRows = False
        Me.DGDetalle.AllowUserToDeleteRows = False
        Me.DGDetalle.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.DGDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDetalle.Location = New System.Drawing.Point(3, 52)
        Me.DGDetalle.Name = "DGDetalle"
        Me.DGDetalle.ReadOnly = True
        Me.DGDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DGDetalle.Size = New System.Drawing.Size(485, 352)
        Me.DGDetalle.TabIndex = 0
        '
        'FrmMantTecnicoLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(601, 447)
        Me.Controls.Add(Me.GroupLista)
        Me.Controls.Add(Me.GroupOpciones)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantTecnicoLista"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMantTecnico"
        Me.Panel1.ResumeLayout(False)
        Me.GroupOpciones.ResumeLayout(False)
        Me.GroupLista.ResumeLayout(False)
        Me.GroupLista.PerformLayout()
        CType(Me.PicBorrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LblTitulo As Label
    Friend WithEvents GroupOpciones As GroupBox
    Friend WithEvents BtnNuevo As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnEliminar As Button
    Friend WithEvents BtnRefrescar As Button
    Friend WithEvents BtnModificar As Button
    Friend WithEvents GroupLista As GroupBox
    Friend WithEvents PicBorrar As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtCriterio As TextBox
    Friend WithEvents DGDetalle As DataGridView
End Class
