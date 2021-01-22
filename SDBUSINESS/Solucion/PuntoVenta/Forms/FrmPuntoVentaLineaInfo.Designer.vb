<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPuntoVentaLineaInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPuntoVentaLineaInfo))
        Me.LblArticuloNombre = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblComentario = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LblArticuloNombre
        '
        Me.LblArticuloNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArticuloNombre.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblArticuloNombre.Location = New System.Drawing.Point(12, 9)
        Me.LblArticuloNombre.Name = "LblArticuloNombre"
        Me.LblArticuloNombre.Size = New System.Drawing.Size(583, 54)
        Me.LblArticuloNombre.TabIndex = 0
        Me.LblArticuloNombre.Text = "Nombre Articulo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(13, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Comentario"
        '
        'LblComentario
        '
        Me.LblComentario.BackColor = System.Drawing.Color.White
        Me.LblComentario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblComentario.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblComentario.Location = New System.Drawing.Point(101, 81)
        Me.LblComentario.Name = "LblComentario"
        Me.LblComentario.Size = New System.Drawing.Size(483, 169)
        Me.LblComentario.TabIndex = 2
        '
        'FrmPuntoVentaLineaInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(607, 281)
        Me.Controls.Add(Me.LblComentario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblArticuloNombre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPuntoVentaLineaInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle Línea"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblArticuloNombre As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblComentario As System.Windows.Forms.Label
End Class
