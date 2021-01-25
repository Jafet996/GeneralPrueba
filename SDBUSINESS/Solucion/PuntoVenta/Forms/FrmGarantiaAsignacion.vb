Imports Business
Public Class FrmGarantiaAsignacion
    Dim Numerico() As TNumericFormat

    Public Property Acepto As Boolean = False
    Public Property Eliminar As Boolean = False
    Public Property Garantia As TGarantiaInfo = Nothing
    Public Property Art_Id As String = String.Empty


    Private Sub CargaCombos()
        Dim GarantiaPeriodo As New TGarantiaPeriodo(EmpresaInfo.Emp_Id)
        Try

            VerificaMensaje(GarantiaPeriodo.LoadComboBox(CmbGarantiaPeriodo))

            CmbGarantiaPeriodo.SelectedIndex = -1

            'If GarantiaPeriodo.RowsAffected > 0 Then
            '    CmbGarantiaPeriodo_SelectedIndexChanged(CmbGarantiaPeriodo, EventArgs.Empty)
            'End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            GarantiaPeriodo = Nothing
        End Try
    End Sub

    Public Sub Execute(pArt_Id As String, pGarantia As TGarantiaInfo)
        Try

            Art_Id = pArt_Id
            Garantia = pGarantia

            CargaCombos()

            BtnEliminar.Enabled = Not pGarantia Is Nothing

            If pGarantia Is Nothing Then
                DtpFecha.Value = DateValue(EmpresaInfo.Getdate())
                DtpVencimiento.Value = DtpFecha.Value
            Else
                With pGarantia
                    DtpFecha.Value = .Fecha
                    TxtOrden.Text = .OrdenNumero
                    DtpVencimiento.Value = .Vencimiento
                End With
            End If


            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub CmbGarantiaPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbGarantiaPeriodo.SelectedIndexChanged
        Try

            If CmbGarantiaPeriodo.SelectedValue Is Nothing OrElse CmbGarantiaPeriodo.SelectedValue.ToString = "System.Data.DataRowView" Then
                Exit Sub
            End If

            CalculaFechaVencimiento()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CalculaFechaVencimiento()
        Dim GarantiaPeriodo As New TGarantiaPeriodo(EmpresaInfo.Emp_Id)
        Try

            GarantiaPeriodo.Periodo_Id = CInt(CmbGarantiaPeriodo.SelectedValue)
            VerificaMensaje(GarantiaPeriodo.ListKey())
            If GarantiaPeriodo.RowsAffected = 0 Then
                Exit Sub
            End If

            DtpVencimiento.Value = DateValue(DateAdd(DateInterval.Month, GarantiaPeriodo.CantidadMes, DtpFecha.Value))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            GarantiaPeriodo = Nothing
        End Try
    End Sub

    Private Sub DtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles DtpFecha.ValueChanged
        Try

            If CmbGarantiaPeriodo.SelectedIndex = -1 Then
                DtpVencimiento.Value = DtpFecha.Value
            Else
                CalculaFechaVencimiento()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try

            If Not ConfirmaAccion("Desea almacenar los datos de la garantía?") Then
                Exit Sub
            End If


            If Garantia Is Nothing Then
                Garantia = New TGarantiaInfo()
            End If

            With Garantia
                .Art_Id = Art_Id
                .Fecha = DateValue(DtpFecha.Value)
                .OrdenNumero = TxtOrden.Text.Trim
                .Vencimiento = DateValue(DtpVencimiento.Value)
            End With

            Acepto = True

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Try
            If Not ConfirmaAccion("Desea eliminar los datos de la garantía?") Then
                Exit Sub
            End If

            Eliminar = True
            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class