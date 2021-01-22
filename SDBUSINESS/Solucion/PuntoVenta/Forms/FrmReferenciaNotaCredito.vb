Imports Business
Public Class FrmReferenciaNotaCredito
    Public Property Guardo As Boolean = False
    Public Property ReferenciaNC As TReferenciaNC

    Public Sub Execute()
        Try

            CmbTipo.SelectedIndex = 0

            If Not ReferenciaNC Is Nothing Then
                With ReferenciaNC
                    DtpFecha.Value = .Fecha
                    Select Case ReferenciaNC.Tipo
                        Case coNC_Otros
                            CmbTipo.SelectedIndex = 0
                        Case coNC_Contingencia
                            CmbTipo.SelectedValue = 1
                    End Select
                    TxtDocumento.Text = .Documento
                    TxtRazon.Text = .Razon
                End With
            Else
                ReferenciaNC = New TReferenciaNC
            End If


            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub



    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Guardo = False
        Me.Close()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try

            If ConfirmaAccion("Desea guardar los datos de Referencia?") Then
                If ValidaDatos() Then
                    Aceptar()
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaDatos() As Boolean
        Dim Fecha As Date
        Try

            Fecha = EmpresaInfo.Getdate()

            If Format(DtpFecha.Value, "yyyyMMdd") > Format(Fecha, "yyyyMMdd") Then
                DtpFecha.Select()
                VerificaMensaje("La fecha seleccionada no puede ser mayor al dia de hoy")
            End If

            TxtDocumento.Text = TxtDocumento.Text.Trim().Replace("'", "")

            If TxtDocumento.Text.Trim().Length = 0 Then
                TxtDocumento.Select()
                VerificaMensaje("Debe de ingresar un número de documento")
            End If


            TxtDocumento.Text = TxtDocumento.Text.Trim().Replace("'", "")

            If TxtRazon.Text.Trim().Length = 0 Then
                TxtRazon.Select()
                VerificaMensaje("Debe de ingresar la razón de la Nota de Crédito")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Aceptar()
        Try

            ReferenciaNC.Fecha = DateValue(DtpFecha.Value)

            Select Case CmbTipo.SelectedIndex
                Case 0
                    ReferenciaNC.Tipo = coNC_Otros
                Case 1
                    ReferenciaNC.Tipo = coNC_Contingencia
            End Select

            ReferenciaNC.Documento = TxtDocumento.Text.Trim()
            ReferenciaNC.Razon = TxtRazon.Text.Trim()

            Guardo = True

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmReferenciaNotaCredito_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnAceptar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub
End Class