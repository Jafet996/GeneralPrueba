<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEnviandoFE
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.TimerPrincipal = New System.Windows.Forms.Timer(Me.components)
        Me.LblFecha = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.LblCantidadStr = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(458, 70)
        Me.Panel1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(458, 70)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enviando Factura Electrónica"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblClave
        '
        Me.LblClave.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClave.ForeColor = System.Drawing.Color.Navy
        Me.LblClave.Location = New System.Drawing.Point(0, 70)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(458, 30)
        Me.LblClave.TabIndex = 6
        Me.LblClave.Text = "50622061800310148635400100001010000400027100000111"
        Me.LblClave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimerPrincipal
        '
        Me.TimerPrincipal.Interval = 2500
        '
        'LblFecha
        '
        Me.LblFecha.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFecha.ForeColor = System.Drawing.Color.Navy
        Me.LblFecha.Location = New System.Drawing.Point(0, 342)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(458, 31)
        Me.LblFecha.TabIndex = 9
        Me.LblFecha.Text = "14/06/2019 - 12:59"
        Me.LblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Business.My.Resources.Resources.ElectronicDocument
        Me.PictureBox2.Location = New System.Drawing.Point(122, 103)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(214, 205)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        '
        'LblCantidad
        '
        Me.LblCantidadStr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantidadStr.ForeColor = System.Drawing.Color.Green
        Me.LblCantidadStr.Location = New System.Drawing.Point(0, 312)
        Me.LblCantidadStr.Name = "LblCantidad"
        Me.LblCantidadStr.Size = New System.Drawing.Size(458, 30)
        Me.LblCantidadStr.TabIndex = 10
        Me.LblCantidadStr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmEnviandoFE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(458, 373)
        Me.ControlBox = False
        Me.Controls.Add(Me.LblCantidadStr)
        Me.Controls.Add(Me.LblClave)
        Me.Controls.Add(Me.LblFecha)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEnviandoFE"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents LblClave As Windows.Forms.Label
    Friend WithEvents TimerPrincipal As Windows.Forms.Timer
    Friend WithEvents PictureBox2 As Windows.Forms.PictureBox
    Friend WithEvents LblFecha As Windows.Forms.Label
    Friend WithEvents LblCantidadStr As Windows.Forms.Label
End Class
