<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPreFacturaLista
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPreFacturaLista))
        Me.LvwDocumentos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolBotones = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.TSLF3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.TimerPreFacturas = New System.Windows.Forms.Timer(Me.components)
        Me.ToolBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'LvwDocumentos
        '
        Me.LvwDocumentos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.LvwDocumentos.FullRowSelect = True
        Me.LvwDocumentos.HideSelection = False
        Me.LvwDocumentos.Location = New System.Drawing.Point(3, 3)
        Me.LvwDocumentos.Name = "LvwDocumentos"
        Me.LvwDocumentos.Size = New System.Drawing.Size(699, 333)
        Me.LvwDocumentos.TabIndex = 0
        Me.LvwDocumentos.UseCompatibleStateImageBehavior = False
        Me.LvwDocumentos.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Caja_Id"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "TipoDocumento_Id"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Pre Factura"
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
        'ToolBotones
        '
        Me.ToolBotones.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolBotones.ImageScalingSize = New System.Drawing.Size(48, 48)
        Me.ToolBotones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.TSLF3, Me.ToolStripLabel5})
        Me.ToolBotones.Location = New System.Drawing.Point(544, 339)
        Me.ToolBotones.Name = "ToolBotones"
        Me.ToolBotones.Size = New System.Drawing.Size(158, 66)
        Me.ToolBotones.TabIndex = 50
        Me.ToolBotones.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Image = Global.PuntoVenta.My.Resources.Resources.F1
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(48, 63)
        Me.ToolStripLabel1.Text = "Buscar"
        Me.ToolStripLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'TSLF3
        '
        Me.TSLF3.Image = Global.PuntoVenta.My.Resources.Resources.F3
        Me.TSLF3.Name = "TSLF3"
        Me.TSLF3.Size = New System.Drawing.Size(50, 63)
        Me.TSLF3.Text = "Facturar"
        Me.TSLF3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Image = Global.PuntoVenta.My.Resources.Resources.Esc
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(48, 63)
        Me.ToolStripLabel5.Text = "Salir"
        Me.ToolStripLabel5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'TimerPreFacturas
        '
        Me.TimerPreFacturas.Interval = 15000
        '
        'FrmPreFacturaLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(706, 406)
        Me.Controls.Add(Me.ToolBotones)
        Me.Controls.Add(Me.LvwDocumentos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPreFacturaLista"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Proformas"
        Me.ToolBotones.ResumeLayout(False)
        Me.ToolBotones.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LvwDocumentos As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolBotones As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TSLF3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TimerPreFacturas As System.Windows.Forms.Timer
End Class
