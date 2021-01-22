Public Class FrmCambioNombre
#Region "Variables"
    Private _Nombre As String
    Private _Acepto As Boolean
#End Region
#Region "Propiedades"
    Public ReadOnly Property Acepto As Boolean
        Get
            Return _Acepto
        End Get
    End Property
    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
        End Set
    End Property
#End Region
#Region "Metodos Publicos"
    Public Sub Execute()
        _Acepto = False
        TxtNombre.Text = _Nombre
        TxtNombre.SelectAll()
        TxtNombre.Focus()
        Me.ShowDialog()
    End Sub
#End Region
#Region "Eventos"

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        _Acepto = True
        _Nombre = TxtNombre.Text.Trim
        Me.Close()
    End Sub
    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
    Private Sub FrmCambioNombre_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                BtnAceptar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select

    End Sub
#End Region

End Class