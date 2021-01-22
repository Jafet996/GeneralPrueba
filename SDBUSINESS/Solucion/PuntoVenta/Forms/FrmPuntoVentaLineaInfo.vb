Public Class FrmPuntoVentaLineaInfo
    Private _ArticuloNombre As String
    Private _Comentario As String

    Public Property ArticuloNombre As String
        Get
            Return _ArticuloNombre
        End Get
        Set(value As String)
            _ArticuloNombre = value
        End Set
    End Property

    Public Property Comentario As String
        Get
            Return _Comentario
        End Get
        Set(value As String)
            _Comentario = value
        End Set
    End Property

    Public Sub Execute()

        LblArticuloNombre.Text = _ArticuloNombre
        LblComentario.Text = _Comentario

        Me.ShowDialog()
    End Sub

    Private Sub FrmPuntoVentaLineaInfo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub
End Class