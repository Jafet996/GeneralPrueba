<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmComprasFacturarCR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmComprasFacturarCR))
        Me.PnlMenu = New System.Windows.Forms.Panel()
        Me.ChkProveedor = New System.Windows.Forms.CheckBox()
        Me.CmbProveedor = New System.Windows.Forms.ComboBox()
        Me.DtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.BtnRefrescar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LvwDetalle = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PnlMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlMenu
        '
        Me.PnlMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.PnlMenu.Controls.Add(Me.ChkProveedor)
        Me.PnlMenu.Controls.Add(Me.CmbProveedor)
        Me.PnlMenu.Controls.Add(Me.DtpHasta)
        Me.PnlMenu.Controls.Add(Me.Label6)
        Me.PnlMenu.Controls.Add(Me.DtpDesde)
        Me.PnlMenu.Controls.Add(Me.BtnRefrescar)
        Me.PnlMenu.Controls.Add(Me.BtnSalir)
        Me.PnlMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlMenu.Location = New System.Drawing.Point(0, 0)
        Me.PnlMenu.Name = "PnlMenu"
        Me.PnlMenu.Size = New System.Drawing.Size(1547, 99)
        Me.PnlMenu.TabIndex = 84
        '
        'ChkProveedor
        '
        Me.ChkProveedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkProveedor.AutoSize = True
        Me.ChkProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkProveedor.ForeColor = System.Drawing.Color.White
        Me.ChkProveedor.Location = New System.Drawing.Point(1008, 54)
        Me.ChkProveedor.Name = "ChkProveedor"
        Me.ChkProveedor.Size = New System.Drawing.Size(99, 22)
        Me.ChkProveedor.TabIndex = 23
        Me.ChkProveedor.Text = "Proveedor"
        Me.ChkProveedor.UseVisualStyleBackColor = True
        '
        'CmbProveedor
        '
        Me.CmbProveedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbProveedor.FormattingEnabled = True
        Me.CmbProveedor.Location = New System.Drawing.Point(1130, 52)
        Me.CmbProveedor.Name = "CmbProveedor"
        Me.CmbProveedor.Size = New System.Drawing.Size(395, 26)
        Me.CmbProveedor.TabIndex = 20
        '
        'DtpHasta
        '
        Me.DtpHasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtpHasta.CustomFormat = "dd/MM/yyyy"
        Me.DtpHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHasta.Location = New System.Drawing.Point(1379, 21)
        Me.DtpHasta.Name = "DtpHasta"
        Me.DtpHasta.Size = New System.Drawing.Size(146, 24)
        Me.DtpHasta.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(1296, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 18)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Hasta"
        '
        'DtpDesde
        '
        Me.DtpDesde.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtpDesde.CustomFormat = "dd/MM/yyyy"
        Me.DtpDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpDesde.Location = New System.Drawing.Point(1130, 21)
        Me.DtpDesde.Name = "DtpDesde"
        Me.DtpDesde.Size = New System.Drawing.Size(146, 24)
        Me.DtpDesde.TabIndex = 15
        '
        'BtnRefrescar
        '
        Me.BtnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRefrescar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRefrescar.ForeColor = System.Drawing.Color.White
        Me.BtnRefrescar.Location = New System.Drawing.Point(11, 11)
        Me.BtnRefrescar.Name = "BtnRefrescar"
        Me.BtnRefrescar.Size = New System.Drawing.Size(99, 73)
        Me.BtnRefrescar.TabIndex = 5
        Me.BtnRefrescar.Text = "Refrescar"
        Me.BtnRefrescar.UseVisualStyleBackColor = True
        '
        'BtnSalir
        '
        Me.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.ForeColor = System.Drawing.Color.White
        Me.BtnSalir.Location = New System.Drawing.Point(116, 11)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(99, 73)
        Me.BtnSalir.TabIndex = 2
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 752)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1547, 22)
        Me.StatusStrip1.TabIndex = 85
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LvwDetalle
        '
        Me.LvwDetalle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.LvwDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvwDetalle.FullRowSelect = True
        Me.LvwDetalle.HideSelection = False
        Me.LvwDetalle.Location = New System.Drawing.Point(0, 99)
        Me.LvwDetalle.Name = "LvwDetalle"
        Me.LvwDetalle.Size = New System.Drawing.Size(1547, 653)
        Me.LvwDetalle.TabIndex = 86
        Me.LvwDetalle.UseCompatibleStateImageBehavior = False
        Me.LvwDetalle.View = System.Windows.Forms.View.Details
        '
        'FrmComprasFacturarCR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1547, 774)
        Me.Controls.Add(Me.LvwDetalle)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.PnlMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmComprasFacturarCR"
        Me.Text = "Compras Facturar.CR"
        Me.PnlMenu.ResumeLayout(False)
        Me.PnlMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PnlMenu As Panel
    Friend WithEvents BtnRefrescar As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents DtpHasta As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents DtpDesde As DateTimePicker
    Friend WithEvents ChkProveedor As CheckBox
    Friend WithEvents CmbProveedor As ComboBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LvwDetalle As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
End Class
