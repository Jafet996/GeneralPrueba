Imports Business
Public Class FrmEntregaMercaderia
    Private _Guardo As Boolean
    Private _TipoEntrega As Integer = -1
    Private _Fechaentrega As Date = DateValue(EmpresaInfo.Getdate())
    Private _TipoEntregaNombre As String = ""
    Private _DireccionEntrega As String = String.Empty


    Public Property Guardo As Boolean
        Get
            Return _Guardo
        End Get
        Set(value As Boolean)
            _Guardo = value
        End Set
    End Property
    Public Property TipoEntrega As Integer
        Get
            Return _TipoEntrega
        End Get
        Set(value As Integer)
            _TipoEntrega = value
        End Set
    End Property
    Public Property FechaEntrega As Date
        Get
            Return _Fechaentrega
        End Get
        Set(value As Date)
            _Fechaentrega = value
        End Set
    End Property
    Public Property TipoEntregaNombre As String
        Get
            Return _TipoEntregaNombre
        End Get
        Set(value As String)
            _TipoEntregaNombre = value
        End Set
    End Property
    Public Property DireccionEntrega As String
        Get
            Return _DireccionEntrega
        End Get
        Set(value As String)
            _DireccionEntrega = value
        End Set
    End Property



    Private Sub CargaComnbos()
        Dim ProformaTipoEntrega As New TProformaTipoEntrega(EmpresaInfo.Emp_Id)
        Try

            VerificaMensaje(ProformaTipoEntrega.LoadComboBox(CmbTipoEntrega))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ProformaTipoEntrega = Nothing
        End Try
    End Sub


    Public Sub Execute()

        _Guardo = False

        CargaComnbos()

        If _TipoEntrega <> -1 Then
            CmbTipoEntrega.SelectedValue = _TipoEntrega
            DtpFechaEntrega.Value = _Fechaentrega
        End If

        TxtDireccionEntrega.Text = _DireccionEntrega

        CmbTipoEntrega.Focus()

        Me.ShowDialog()
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click

        _Guardo = False

        Me.Close()

    End Sub

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        Try

            _TipoEntrega = CmbTipoEntrega.SelectedValue
            _Fechaentrega = DateValue(DtpFechaEntrega.Value)
            _TipoEntregaNombre = CmbTipoEntrega.Text
            _DireccionEntrega = TxtDireccionEntrega.Text
            _Guardo = True

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmEntregaMercaderia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnGuardar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub CmbTipoEntrega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoEntrega.SelectedIndexChanged
        If CmbTipoEntrega.SelectedValue Is Nothing OrElse CmbTipoEntrega.SelectedValue.ToString = "System.Data.DataRowView" Then
            Exit Sub
        End If


        TxtDireccionEntrega.Enabled = (CmbTipoEntrega.SelectedValue <> Enum_TipoEntrega.Tienda)
    End Sub
End Class