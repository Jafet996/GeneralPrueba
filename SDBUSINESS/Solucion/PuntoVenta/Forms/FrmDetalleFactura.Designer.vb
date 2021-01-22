<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDetalleFactura
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PicEscape = New System.Windows.Forms.PictureBox()
        Me.LblMensajeFactura = New System.Windows.Forms.Label()
        Me.LvwDetalle = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PicLogo = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PicEscape, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PicLogo)
        Me.Panel1.Controls.Add(Me.LblMensajeFactura)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(862, 83)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.LblTotal)
        Me.Panel2.Controls.Add(Me.PictureBox7)
        Me.Panel2.Controls.Add(Me.PicEscape)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 511)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(862, 52)
        Me.Panel2.TabIndex = 1
        '
        'PicEscape
        '
        Me.PicEscape.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.PicEscape.Location = New System.Drawing.Point(3, 1)
        Me.PicEscape.Name = "PicEscape"
        Me.PicEscape.Size = New System.Drawing.Size(48, 48)
        Me.PicEscape.TabIndex = 3
        Me.PicEscape.TabStop = False
        '
        'LblMensajeFactura
        '
        Me.LblMensajeFactura.AutoSize = True
        Me.LblMensajeFactura.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMensajeFactura.ForeColor = System.Drawing.Color.White
        Me.LblMensajeFactura.Location = New System.Drawing.Point(29, 33)
        Me.LblMensajeFactura.Name = "LblMensajeFactura"
        Me.LblMensajeFactura.Size = New System.Drawing.Size(218, 19)
        Me.LblMensajeFactura.TabIndex = 0
        Me.LblMensajeFactura.Text = "Detalle del Documento # "
        '
        'LvwDetalle
        '
        Me.LvwDetalle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.LvwDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvwDetalle.FullRowSelect = True
        Me.LvwDetalle.Location = New System.Drawing.Point(0, 83)
        Me.LvwDetalle.Name = "LvwDetalle"
        Me.LvwDetalle.Size = New System.Drawing.Size(862, 428)
        Me.LvwDetalle.TabIndex = 2
        Me.LvwDetalle.UseCompatibleStateImageBehavior = False
        Me.LvwDetalle.View = System.Windows.Forms.View.Details
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label9.Location = New System.Drawing.Point(565, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 25)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "Total"
        '
        'LblTotal
        '
        Me.LblTotal.BackColor = System.Drawing.Color.White
        Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.Location = New System.Drawing.Point(692, 10)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(153, 29)
        Me.LblTotal.TabIndex = 47
        Me.LblTotal.Text = "0.00"
        Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = Global.PuntoVenta.My.Resources.Resources.Total3
        Me.PictureBox7.Location = New System.Drawing.Point(550, 0)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(309, 52)
        Me.PictureBox7.TabIndex = 48
        Me.PictureBox7.TabStop = False
        '
        'PicLogo
        '
        Me.PicLogo.BackColor = System.Drawing.Color.White
        Me.PicLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.PicLogo.Location = New System.Drawing.Point(767, 0)
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(95, 83)
        Me.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicLogo.TabIndex = 1
        Me.PicLogo.TabStop = False
        '
        'FrmDetalleFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(862, 563)
        Me.Controls.Add(Me.LvwDetalle)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDetalleFactura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PicEscape, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PicEscape As System.Windows.Forms.PictureBox
    Friend WithEvents LblMensajeFactura As System.Windows.Forms.Label
    Friend WithEvents LvwDetalle As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PicLogo As System.Windows.Forms.PictureBox
End Class
