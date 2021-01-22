<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmConfirmacion
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.LblMensaje = New System.Windows.Forms.Label()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.BtnRechazar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.LblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(693, 65)
        Me.Panel1.TabIndex = 1
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.White
        Me.LblTitulo.Location = New System.Drawing.Point(12, 21)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(62, 24)
        Me.LblTitulo.TabIndex = 0
        Me.LblTitulo.Text = "Título"
        '
        'LblMensaje
        '
        Me.LblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMensaje.ForeColor = System.Drawing.Color.Navy
        Me.LblMensaje.Location = New System.Drawing.Point(11, 68)
        Me.LblMensaje.Name = "LblMensaje"
        Me.LblMensaje.Size = New System.Drawing.Size(672, 222)
        Me.LblMensaje.TabIndex = 4
        Me.LblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.White
        Me.BtnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAceptar.Image = Global.Business.My.Resources.Resources.Blue_F3
        Me.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnAceptar.Location = New System.Drawing.Point(18, 304)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(55, 67)
        Me.BtnAceptar.TabIndex = 5
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'BtnRechazar
        '
        Me.BtnRechazar.BackColor = System.Drawing.Color.White
        Me.BtnRechazar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRechazar.Image = Global.Business.My.Resources.Resources.Blue_Esc
        Me.BtnRechazar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnRechazar.Location = New System.Drawing.Point(79, 304)
        Me.BtnRechazar.Name = "BtnRechazar"
        Me.BtnRechazar.Size = New System.Drawing.Size(55, 67)
        Me.BtnRechazar.TabIndex = 6
        Me.BtnRechazar.UseVisualStyleBackColor = False
        '
        'FrmConfirmacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(693, 393)
        Me.Controls.Add(Me.BtnRechazar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.LblMensaje)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmConfirmacion"
        Me.Text = "FrmConfirmacion"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents LblTitulo As Windows.Forms.Label
    Friend WithEvents LblMensaje As Windows.Forms.Label
    Friend WithEvents BtnAceptar As Windows.Forms.Button
    Friend WithEvents BtnRechazar As Windows.Forms.Button
End Class
