Imports BUSINESS
Public Class FrmCajaCierre
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private _TotalCajero As Double = 0.0
#End Region
#Region "Metodos Privados"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(4)

            Numerico(0) = New TNumericFormat(TxtEfectivo, 11, 2, False, "", "#,##0.00")
            Numerico(1) = New TNumericFormat(TxtTarjetas, 11, 2, False, "", "##0.00")
            Numerico(2) = New TNumericFormat(TxtCheques, 11, 2, False, "", "##0.00")
            Numerico(3) = New TNumericFormat(TxtDocumentos, 11, 2, False, "", "##0.00")
            Numerico(4) = New TNumericFormat(TxtDolares, 11, 2, False, "", "##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Public Sub Execute()
        Try
            LblCaja.Text = CajaInfo.Nombre
            LblUsuario.Text = UsuarioInfo.Nombre
            TxtEfectivo.Text = "0.00"

            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If Not IsNumeric(TxtEfectivo.Text) Then
                TxtEfectivo.Focus()
                VerificaMensaje("El monto ingresado debe de ser numérico")
            End If

            If CDbl(TxtEfectivo.Text) < 0 Then
                TxtEfectivo.Focus()
                VerificaMensaje("El monto ingresado debe de ser mayor o igual a cero")
            End If

            If Not IsNumeric(TxtTarjetas.Text) Then
                TxtTarjetas.Focus()
                VerificaMensaje("El monto ingresado debe de ser numérico")
            End If

            If CDbl(TxtTarjetas.Text) < 0 Then
                TxtTarjetas.Focus()
                VerificaMensaje("El monto ingresado debe de ser mayor o igual a cero")
            End If

            If Not IsNumeric(TxtCheques.Text) Then
                TxtCheques.Focus()
                VerificaMensaje("El monto ingresado debe de ser numérico")
            End If

            If CDbl(TxtCheques.Text) < 0 Then
                TxtCheques.Focus()
                VerificaMensaje("El monto ingresado debe de ser mayor o igual a cero")
            End If

            If Not IsNumeric(TxtDocumentos.Text) Then
                TxtDocumentos.Focus()
                VerificaMensaje("El monto ingresado debe de ser numérico")
            End If

            If CDbl(TxtDocumentos.Text) < 0 Then
                TxtDocumentos.Focus()
                VerificaMensaje("El monto ingresado debe de ser mayor o igual a cero")
            End If

            If Not IsNumeric(TxtDolares.Text) Then
                TxtDolares.Focus()
                VerificaMensaje("El monto ingresado debe de ser numérico")
            End If

            If CDbl(TxtDolares.Text) < 0 Then
                TxtDolares.Focus()
                VerificaMensaje("El monto ingresado debe de ser mayor o igual a cero")
            End If

            VerificaMensaje(CajaEstaAbierta)

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        If ValidaTodo() Then
            If MsgBox("Desea cerrar la caja?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                Aceptar()
            End If
        End If
    End Sub

    Private Sub FrmCajaCierre_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            FormateaCamposNumericos()
            TxtEfectivo.Select()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    'Private Sub NotificaDiferencia(pCierre As TCajaCierreEncabezado)
    '    Dim Mensaje As String = ""
    '    Dim Monto As Double = 0.0

    '    Try
    '        Monto = pCierre.Total - _TotalCajero

    '        If Monto > EmpresaParametroInfo.DiferenciaCierre Then
    '            Mensaje = "Existe un faltante en el Cierre #" & pCierre.Cierre_Id & _
    '                      " de la Caja #" & CajaInfo.Caja_Id & " - " & CajaInfo.Nombre & _
    '                      ", por un monto de " & Monto.ToString & ", la acción fue realizada por " & _
    '                      pCierre.UsuarioNombre
    '        ElseIf Monto * -1 > EmpresaParametroInfo.DiferenciaCierre Then
    '            Mensaje = "Existe un sobrante en el Cierre #" & pCierre.Cierre_Id & _
    '                      " de la Caja #" & CajaInfo.Caja_Id & " - " & CajaInfo.Nombre & _
    '                      ", por un monto de " & (Monto * -1).ToString & ", la acción fue realizada por " & _
    '                      pCierre.UsuarioNombre
    '        End If

    '        If Mensaje.Trim = String.Empty Then
    '            Exit Sub
    '        End If

    '        EnviaCorreoCierreCaja(Mensaje)

    '    Catch ex As Exception
    '        MensajeError(ex.Message)
    '    End Try
    'End Sub

    Private Sub Aceptar()
        Dim Caja As New TCaja()
        Dim Cierre As New TCajaCierreEncabezado()

        Try
            With Cierre
                .Emp_Id = CajaInfo.Emp_Id
                .Caja_Id = CajaInfo.Caja_Id
                .Cierre_Id = CajaInfo.Cierre_Id
            End With
            VerificaMensaje(Cierre.ListKey)

            _TotalCajero = CDbl(CDbl(TxtEfectivo.Text) + CDbl(TxtTarjetas.Text) + CDbl(TxtCheques.Text) + CDbl(TxtDocumentos.Text))

            'If Cierre.Total <> _TotalCajero Then
            '    If MsgBox("Existe una diferencia entre los totales de cierre de caja¿Desea cerrar la caja con los montos actuales?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Cuidado!!") <> MsgBoxResult.Yes Then
            '        Exit Sub
            '    End If

            '    NotificaDiferencia(Cierre)
            'End If

            With Caja
                .Emp_Id = CajaInfo.Emp_Id
                .Caja_Id = CajaInfo.Caja_Id
            End With
            VerificaMensaje(Caja.CerrarCaja(CDbl(TxtEfectivo.Text), CDbl(TxtTarjetas.Text), CDbl(TxtCheques.Text), CDbl(TxtDocumentos.Text), CDbl(TxtDolares.Text)))
            VerificaMensaje(CajaInfo.ListKey())
            'VerificaMensaje(CajaInfo.GeneraAsientoCierre())
            ImprimeCierreCaja(EmpresaInfo, CajaInfo, False, False)

            Mensaje("Proceso exitoso!!!")

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Caja = Nothing
            Cierre = Nothing
        End Try
    End Sub

    Private Sub FrmCajaCierre_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnAceptar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

End Class