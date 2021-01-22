<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBusquedaProforma
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBusquedaProforma))
        Me.LvwDocumentos = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LvwDetalle = New System.Windows.Forms.ListView()
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PnlFiltros = New System.Windows.Forms.Panel()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.RdbNumero = New System.Windows.Forms.RadioButton()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.RdbNombre = New System.Windows.Forms.RadioButton()
        Me.DtpFechaEntrega = New System.Windows.Forms.DateTimePicker()
        Me.RdbFechaEntrega = New System.Windows.Forms.RadioButton()
        Me.RdbMostarTodo = New System.Windows.Forms.RadioButton()
        Me.CMSDocumentos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuEliminarPrefactura = New System.Windows.Forms.ToolStripMenuItem()
        Me.PnlFiltros.SuspendLayout()
        Me.CMSDocumentos.SuspendLayout()
        Me.SuspendLayout()
        '
        'LvwDocumentos
        '
        Me.LvwDocumentos.BackColor = System.Drawing.Color.White
        Me.LvwDocumentos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader8, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader23, Me.ColumnHeader24})
        Me.LvwDocumentos.ContextMenuStrip = Me.CMSDocumentos
        Me.LvwDocumentos.FullRowSelect = True
        Me.LvwDocumentos.HideSelection = False
        Me.LvwDocumentos.Location = New System.Drawing.Point(1, 1)
        Me.LvwDocumentos.Name = "LvwDocumentos"
        Me.LvwDocumentos.Size = New System.Drawing.Size(1234, 486)
        Me.LvwDocumentos.TabIndex = 1
        Me.LvwDocumentos.UseCompatibleStateImageBehavior = False
        Me.LvwDocumentos.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Documento"
        Me.ColumnHeader3.Width = 100
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Cliente"
        Me.ColumnHeader4.Width = 204
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Fecha Hora"
        Me.ColumnHeader5.Width = 111
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Monto"
        Me.ColumnHeader6.Width = 111
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Vencimiento"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Tipo"
        Me.ColumnHeader1.Width = 153
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Tipo Entrega"
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Fecha Entrega"
        '
        'LvwDetalle
        '
        Me.LvwDetalle.BackColor = System.Drawing.Color.AliceBlue
        Me.LvwDetalle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14})
        Me.LvwDetalle.FullRowSelect = True
        Me.LvwDetalle.Location = New System.Drawing.Point(1, 493)
        Me.LvwDetalle.Name = "LvwDetalle"
        Me.LvwDetalle.Size = New System.Drawing.Size(641, 182)
        Me.LvwDetalle.TabIndex = 53
        Me.LvwDetalle.UseCompatibleStateImageBehavior = False
        Me.LvwDetalle.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Línea"
        Me.ColumnHeader9.Width = 44
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Artículo"
        Me.ColumnHeader10.Width = 90
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Cantidad"
        Me.ColumnHeader11.Width = 69
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Descripcion"
        Me.ColumnHeader12.Width = 269
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Total"
        Me.ColumnHeader13.Width = 112
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Comentario"
        Me.ColumnHeader14.Width = 0
        '
        'PnlFiltros
        '
        Me.PnlFiltros.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.PnlFiltros.Controls.Add(Me.TxtNumero)
        Me.PnlFiltros.Controls.Add(Me.RdbNumero)
        Me.PnlFiltros.Controls.Add(Me.TxtNombre)
        Me.PnlFiltros.Controls.Add(Me.RdbNombre)
        Me.PnlFiltros.Controls.Add(Me.DtpFechaEntrega)
        Me.PnlFiltros.Controls.Add(Me.RdbFechaEntrega)
        Me.PnlFiltros.Controls.Add(Me.RdbMostarTodo)
        Me.PnlFiltros.Location = New System.Drawing.Point(648, 493)
        Me.PnlFiltros.Name = "PnlFiltros"
        Me.PnlFiltros.Size = New System.Drawing.Size(587, 182)
        Me.PnlFiltros.TabIndex = 54
        '
        'TxtNumero
        '
        Me.TxtNumero.Location = New System.Drawing.Point(218, 107)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(95, 20)
        Me.TxtNumero.TabIndex = 9
        '
        'RdbNumero
        '
        Me.RdbNumero.AutoSize = True
        Me.RdbNumero.ForeColor = System.Drawing.Color.White
        Me.RdbNumero.Location = New System.Drawing.Point(106, 109)
        Me.RdbNumero.Name = "RdbNumero"
        Me.RdbNumero.Size = New System.Drawing.Size(62, 17)
        Me.RdbNumero.TabIndex = 8
        Me.RdbNumero.TabStop = True
        Me.RdbNumero.Text = "&Número"
        Me.RdbNumero.UseVisualStyleBackColor = True
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(218, 74)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(256, 20)
        Me.TxtNombre.TabIndex = 7
        '
        'RdbNombre
        '
        Me.RdbNombre.AutoSize = True
        Me.RdbNombre.ForeColor = System.Drawing.Color.White
        Me.RdbNombre.Location = New System.Drawing.Point(106, 75)
        Me.RdbNombre.Name = "RdbNombre"
        Me.RdbNombre.Size = New System.Drawing.Size(62, 17)
        Me.RdbNombre.TabIndex = 6
        Me.RdbNombre.TabStop = True
        Me.RdbNombre.Text = "&Nombre"
        Me.RdbNombre.UseVisualStyleBackColor = True
        '
        'DtpFechaEntrega
        '
        Me.DtpFechaEntrega.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaEntrega.Location = New System.Drawing.Point(218, 37)
        Me.DtpFechaEntrega.Name = "DtpFechaEntrega"
        Me.DtpFechaEntrega.Size = New System.Drawing.Size(95, 20)
        Me.DtpFechaEntrega.TabIndex = 5
        '
        'RdbFechaEntrega
        '
        Me.RdbFechaEntrega.AutoSize = True
        Me.RdbFechaEntrega.ForeColor = System.Drawing.Color.White
        Me.RdbFechaEntrega.Location = New System.Drawing.Point(106, 39)
        Me.RdbFechaEntrega.Name = "RdbFechaEntrega"
        Me.RdbFechaEntrega.Size = New System.Drawing.Size(95, 17)
        Me.RdbFechaEntrega.TabIndex = 1
        Me.RdbFechaEntrega.TabStop = True
        Me.RdbFechaEntrega.Text = "&Fecha Entrega"
        Me.RdbFechaEntrega.UseVisualStyleBackColor = True
        '
        'RdbMostarTodo
        '
        Me.RdbMostarTodo.AutoSize = True
        Me.RdbMostarTodo.ForeColor = System.Drawing.Color.White
        Me.RdbMostarTodo.Location = New System.Drawing.Point(106, 140)
        Me.RdbMostarTodo.Name = "RdbMostarTodo"
        Me.RdbMostarTodo.Size = New System.Drawing.Size(88, 17)
        Me.RdbMostarTodo.TabIndex = 0
        Me.RdbMostarTodo.TabStop = True
        Me.RdbMostarTodo.Text = "&Mostrar Todo"
        Me.RdbMostarTodo.UseVisualStyleBackColor = True
        '
        'CMSDocumentos
        '
        Me.CMSDocumentos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuEliminarPrefactura})
        Me.CMSDocumentos.Name = "CMSDocumentos"
        Me.CMSDocumentos.Size = New System.Drawing.Size(181, 48)
        '
        'MnuEliminarPrefactura
        '
        Me.MnuEliminarPrefactura.Name = "MnuEliminarPrefactura"
        Me.MnuEliminarPrefactura.Size = New System.Drawing.Size(180, 22)
        Me.MnuEliminarPrefactura.Text = "Eliminar Proforma"
        '
        'FrmBusquedaProforma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1247, 676)
        Me.ContextMenuStrip = Me.CMSDocumentos
        Me.Controls.Add(Me.PnlFiltros)
        Me.Controls.Add(Me.LvwDetalle)
        Me.Controls.Add(Me.LvwDocumentos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmBusquedaProforma"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Búsqueda de Proformas"
        Me.PnlFiltros.ResumeLayout(False)
        Me.PnlFiltros.PerformLayout()
        Me.CMSDocumentos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LvwDocumentos As ListView
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader15 As ColumnHeader
    Friend WithEvents ColumnHeader16 As ColumnHeader
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents ColumnHeader19 As ColumnHeader
    Friend WithEvents ColumnHeader20 As ColumnHeader
    Friend WithEvents ColumnHeader21 As ColumnHeader
    Friend WithEvents ColumnHeader22 As ColumnHeader
    Friend WithEvents ColumnHeader23 As ColumnHeader
    Friend WithEvents ColumnHeader24 As ColumnHeader
    Friend WithEvents LvwDetalle As ListView
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents PnlFiltros As Panel
    Friend WithEvents RdbNumero As RadioButton
    Friend WithEvents TxtNombre As TextBox
    Friend WithEvents RdbNombre As RadioButton
    Friend WithEvents DtpFechaEntrega As DateTimePicker
    Friend WithEvents RdbFechaEntrega As RadioButton
    Friend WithEvents RdbMostarTodo As RadioButton
    Friend WithEvents CMSDocumentos As ContextMenuStrip
    Friend WithEvents MnuEliminarPrefactura As ToolStripMenuItem
    Friend WithEvents TxtNumero As TextBox
End Class
