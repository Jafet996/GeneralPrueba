Imports Business
Public Class FrmSalidaEfectivo
    Dim Numerico() As TNumericFormat
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtMonto, 7, 2, False, "", "#,##0.00")
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute()
        TxtMonto.Text = "0.00"
        Me.Text = "Salidas de Efectivo"
        TxtMonto.Focus()
        TxtMonto.SelectionLength = TxtMonto.Text.Length
        Me.ShowDialog()

    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If TxtMotivo.Text.Length = 0 Then
                TxtMotivo.Focus()
                TxtMotivo.SelectionLength = TxtMotivo.Text.Length
                VerificaMensaje("No se ha indicado el motivo")
            End If
            If Not IsNumeric(TxtMonto.Text) Then
                TxtMonto.Focus()
                TxtMonto.SelectionLength = TxtMonto.Text.Length
                VerificaMensaje("El monto ingresado debe de ser numérico")
            End If

            If CDbl(TxtMonto.Text) < 0 Then
                TxtMonto.Text = "0.00"
                TxtMonto.Focus()
                TxtMonto.SelectionLength = TxtMonto.Text.Length
            End If
            If TxtMonto.Text = "" Then
                TxtMonto.Text = "0.00"
                TxtMonto.Focus()
                TxtMonto.SelectionLength = TxtMonto.Text.Length
            End If

            If CDbl(TxtMonto.Text) = 0 Then
                If Not ConfirmaAccion("No se ha indicado el monto de salida de efectivo, Desea continuar de todos modos?") Then
                    VerificaMensaje("El monto de salida de efectivo debe de ser mayor a cero")
                    TxtMonto.Focus()
                    TxtMonto.SelectionLength = TxtMonto.Text.Length
                End If
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function
    Private Sub Agregar()
        Dim SalidaEfectivo As New TCajaSalidaEfectivo(EmpresaInfo.Emp_Id)
        Try
            
            With SalidaEfectivo
                .Emp_Id = CajaInfo.Emp_Id
                .Suc_Id = CajaInfo.Suc_Id
                .Caja_Id = CajaInfo.Caja_Id
                .Cierre_Id = CajaInfo.Cierre_Id
                .Monto = Convert.ToDouble(TxtMonto.Text)
                .Motivo = TxtMotivo.Text
                .Usuario_Id = UsuarioInfo.Usuario_Id
            End With

            VerificaMensaje(SalidaEfectivo.InsertaSalidaEfectivo())

            VerificaMensaje(SalidaEfectivo.ListKey())


            Mensaje("La salida de efectivo de almacenó correctamente")


            TxtMonto.Text = 0.00
            TxtMonto.Focus()
            TxtMonto.SelectionLength = TxtMonto.Text.Length
            TxtMotivo.Text = ""

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            SalidaEfectivo = Nothing
        End Try

    End Sub
    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        If ValidaTodo() = True Then

            If ConfirmaAccion("Desea crear una salida de efectivo?") Then
                Me.Agregar()
                Me.Imprimir()
            End If

        End If
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmSalidaEfectivo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Me.Agregar()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub
    Private Sub Imprimir()
        Dim CajaSalida As New TCajaSalidaEfectivo(EmpresaInfo.Emp_Id)
        Dim UltimaSalida As New TCajaSalidaEfectivo(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            BtnAgregar.Enabled = False
            BtnSalir.Enabled = False

            With UltimaSalida
                .Suc_Id = CajaInfo.Suc_Id
                .Caja_Id = CajaInfo.Caja_Id
                .Cierre_Id = CajaInfo.Cierre_Id

            End With

            Dim salida As String = UltimaSalida.ultimaSalida()

            With CajaSalida
                .Suc_Id = CajaInfo.Suc_Id
                .Caja_Id = CajaInfo.Caja_Id
                .Cierre_Id = CajaInfo.Cierre_Id
                .Salida_Id = Convert.ToInt32(salida)
            End With
            Mensaje = CajaSalida.ListKey()
            VerificaMensaje(Mensaje)

            ImprimirSalida(CajaSalida, 1)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CajaSalida = Nothing
            BtnAgregar.Enabled = True
            BtnSalir.Enabled = True
        End Try
    End Sub

    Private Sub ImprimirSalida(pCajaSalidaEfectivo As TCajaSalidaEfectivo, pResumido As Boolean)
        Dim ImprimeCierre As TImprimeSalidaEfectivo = Nothing
        Dim ImprimeCierreParalelo As TImprimeSalidaEfectivo = Nothing
        Dim TipoImpresion As PrintLocation
        Try
            If InfoMaquina.PrintLocation = PrintLocation.ParaleloPuerto Then
                ImprimeCierreParalelo = New TImprimeSalidaEfectivo(EmpresaInfo, SucursalInfo, CajaInfo, pCajaSalidaEfectivo, pResumido)

                If Not ImprimeCierreParalelo.Print(InfoMaquina.ParallePort, False) Then
                    VerificaMensaje("Se presentaron problemas de impresión")
                End If
            Else
                Select Case InfoMaquina.PrintLocation
                    Case PrintLocation.Serial
                        TipoImpresion = PrintLocation.Serial
                    Case PrintLocation.Paralelo, PrintLocation.Carta1
                        TipoImpresion = PrintLocation.Paralelo
                    Case Else
                        TipoImpresion = PrintLocation.Paralelo
                End Select

                AbrirCajon()
                ImprimeCierre = New TImprimeSalidaEfectivo(EmpresaInfo, SucursalInfo, CajaInfo, pCajaSalidaEfectivo, pResumido)

                If Not ImprimeCierre.Print(TipoImpresion, False) Then
                    VerificaMensaje("Se presentaron problemas de impresión")
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ImprimeCierre = Nothing
            ImprimeCierreParalelo = Nothing
        End Try
    End Sub

    Private Sub FrmSalidaEfectivo_Load(sender As Object, e As EventArgs) Handles Me.Load
        FormateaCamposNumericos()
    End Sub

    Private Sub TxtMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtMonto.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If

    End Sub
End Class