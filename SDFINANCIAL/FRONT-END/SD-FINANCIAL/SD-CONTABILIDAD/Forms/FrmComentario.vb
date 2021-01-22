Imports Business
Public Class FrmComentario
#Region "Variables"
    Private _Comentario As String
    Private _Acepto As Boolean
    Private _Titulo As String
    Private _Largo As Integer
    Private _PermiteGuardar As Boolean = True
#End Region
#Region "Propiedades"
    Public ReadOnly Property Acepto As Boolean
        Get
            Return _Acepto
        End Get
    End Property
    Public Property Comentario As String
        Get
            Return _Comentario
        End Get
        Set(value As String)
            _Comentario = value
        End Set
    End Property
    Public Property Titulo As String
        Get
            Return _Titulo
        End Get
        Set(value As String)
            _Titulo = value
        End Set
    End Property
    Public WriteOnly Property Largo As Integer
        Set(value As Integer)
            _Largo = value
        End Set
    End Property
    Public WriteOnly Property PermiteGuardar
        Set(value)
            _PermiteGuardar = value
        End Set
    End Property
#End Region
#Region "Metodos Publicos"
    Public Sub Execute()
        _Acepto = False
        Me.Text = _Titulo

        If _Largo > 0 Then
            TxtComentario.MaxLength = _Largo
        End If

        BtnAceptar.Enabled = _PermiteGuardar
        TxtComentario.ReadOnly = Not _PermiteGuardar

        TxtComentario.Text = _Comentario
        TxtComentario.Focus()
        Me.ShowDialog()
    End Sub
#End Region
#Region "Metodos Privados"

    Private Function ValidaTodo() As Boolean
        Try
            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Aceptar()
        _Acepto = True
        _Comentario = TxtComentario.Text.Trim

        Me.Close()
    End Sub

#End Region
#Region "Eventos"

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        If ValidaTodo() Then
            Aceptar()
        End If
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