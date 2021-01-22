<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantArticuloEquivalenteProveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantArticuloEquivalenteProveedor))
        Me.PnlProveedor = New System.Windows.Forms.Panel()
        Me.LblProvArt_Id = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblProvArt_Nombre = New System.Windows.Forms.Label()
        Me.LblProveedor = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtnDel = New System.Windows.Forms.Button()
        Me.LblArt_Id = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblArt_Nombre = New System.Windows.Forms.Label()
        Me.PnlProveedor.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlProveedor
        '
        Me.PnlProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlProveedor.Controls.Add(Me.LblProvArt_Id)
        Me.PnlProveedor.Controls.Add(Me.Label3)
        Me.PnlProveedor.Controls.Add(Me.LblProvArt_Nombre)
        Me.PnlProveedor.ForeColor = System.Drawing.Color.MidnightBlue
        Me.PnlProveedor.Location = New System.Drawing.Point(22, 145)
        Me.PnlProveedor.Name = "PnlProveedor"
        Me.PnlProveedor.Size = New System.Drawing.Size(1009, 138)
        Me.PnlProveedor.TabIndex = 3
        '
        'LblProvArt_Id
        '
        Me.LblProvArt_Id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblProvArt_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProvArt_Id.ForeColor = System.Drawing.Color.Purple
        Me.LblProvArt_Id.Location = New System.Drawing.Point(14, 51)
        Me.LblProvArt_Id.Name = "LblProvArt_Id"
        Me.LblProvArt_Id.Size = New System.Drawing.Size(204, 40)
        Me.LblProvArt_Id.TabIndex = 2
        Me.LblProvArt_Id.Text = "Artículo Proveedor"
        Me.LblProvArt_Id.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Purple
        Me.Label3.Location = New System.Drawing.Point(10, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Artículo Proveedor"
        '
        'LblProvArt_Nombre
        '
        Me.LblProvArt_Nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblProvArt_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProvArt_Nombre.ForeColor = System.Drawing.Color.Purple
        Me.LblProvArt_Nombre.Location = New System.Drawing.Point(224, 51)
        Me.LblProvArt_Nombre.Name = "LblProvArt_Nombre"
        Me.LblProvArt_Nombre.Size = New System.Drawing.Size(771, 40)
        Me.LblProvArt_Nombre.TabIndex = 0
        Me.LblProvArt_Nombre.Text = "Artículo Proveedor"
        Me.LblProvArt_Nombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblProveedor
        '
        Me.LblProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProveedor.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblProveedor.Location = New System.Drawing.Point(15, 18)
        Me.LblProveedor.Name = "LblProveedor"
        Me.LblProveedor.Size = New System.Drawing.Size(1016, 105)
        Me.LblProveedor.TabIndex = 0
        Me.LblProveedor.Text = "Proveedor"
        Me.LblProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.BtnAdd)
        Me.Panel2.Controls.Add(Me.BtnDel)
        Me.Panel2.Controls.Add(Me.LblArt_Id)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.LblArt_Nombre)
        Me.Panel2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Panel2.Location = New System.Drawing.Point(22, 289)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1009, 171)
        Me.Panel2.TabIndex = 4
        '
        'BtnAdd
        '
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.ForeColor = System.Drawing.Color.White
        Me.BtnAdd.Image = Global.Business.My.Resources.Resources.add1
        Me.BtnAdd.Location = New System.Drawing.Point(946, 5)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(49, 53)
        Me.BtnAdd.TabIndex = 10
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'BtnDel
        '
        Me.BtnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDel.ForeColor = System.Drawing.Color.White
        Me.BtnDel.Image = Global.Business.My.Resources.Resources.delete
        Me.BtnDel.Location = New System.Drawing.Point(946, 109)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(49, 53)
        Me.BtnDel.TabIndex = 9
        Me.BtnDel.UseVisualStyleBackColor = True
        '
        'LblArt_Id
        '
        Me.LblArt_Id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblArt_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArt_Id.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblArt_Id.Location = New System.Drawing.Point(14, 63)
        Me.LblArt_Id.Name = "LblArt_Id"
        Me.LblArt_Id.Size = New System.Drawing.Size(204, 40)
        Me.LblArt_Id.TabIndex = 3
        Me.LblArt_Id.Text = "Artículo Interno"
        Me.LblArt_Id.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 20)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Artículo Interno"
        '
        'LblArt_Nombre
        '
        Me.LblArt_Nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblArt_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArt_Nombre.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblArt_Nombre.Location = New System.Drawing.Point(224, 63)
        Me.LblArt_Nombre.Name = "LblArt_Nombre"
        Me.LblArt_Nombre.Size = New System.Drawing.Size(771, 40)
        Me.LblArt_Nombre.TabIndex = 1
        Me.LblArt_Nombre.Text = "Artículo Interno"
        Me.LblArt_Nombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmMantArticuloEquivalenteProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1053, 483)
        Me.Controls.Add(Me.LblProveedor)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PnlProveedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantArticuloEquivalenteProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Equivalencia Artículo Proveedor"
        Me.PnlProveedor.ResumeLayout(False)
        Me.PnlProveedor.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlProveedor As Windows.Forms.Panel
    Friend WithEvents LblProveedor As Windows.Forms.Label
    Friend WithEvents LblProvArt_Nombre As Windows.Forms.Label
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents LblArt_Nombre As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents LblProvArt_Id As Windows.Forms.Label
    Friend WithEvents LblArt_Id As Windows.Forms.Label
    Friend WithEvents BtnDel As Windows.Forms.Button
    Friend WithEvents BtnAdd As Windows.Forms.Button
End Class
