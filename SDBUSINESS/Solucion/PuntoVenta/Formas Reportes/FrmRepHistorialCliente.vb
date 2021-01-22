Imports Business

Public Class FrmRepHistorialCliente
    Public _VentanaCerrada As Boolean = False
    Public _Todos As Boolean = False
    Public _FechaIni As Date = Now()
    Public _FechaFin As Date = Now()
    Private Sub CbTodo_CheckedChanged(sender As Object, e As EventArgs) Handles CbTodo.CheckedChanged
        DtpPFechaFin.Visible = Not CbTodo.Checked
        DtpPFechaIni.Visible = Not CbTodo.Checked
        Label3.Visible = Not CbTodo.Checked
        Label4.Visible = Not CbTodo.Checked
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Try
            _Todos = CbTodo.Checked

            If Not _Todos Then

                If DtpPFechaIni.Value.Date <= DtpPFechaFin.Value.Date Then

                    _FechaIni = DtpPFechaIni.Value.Date
                    _FechaFin = DateAdd(DateInterval.Day, 1, DtpPFechaFin.Value.Date)

                Else

                    VerificaMensaje("La fecha incial debe ser menor a la fecha final")
                End If

            End If

            _VentanaCerrada = True
            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try


    End Sub

    Public Sub Execute()
        Me.ShowDialog()
    End Sub
End Class