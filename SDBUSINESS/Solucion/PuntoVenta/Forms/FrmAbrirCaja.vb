Imports Business
Public Class FrmAbrirCaja
    Dim Numerico() As TNumericFormat

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtFondo, 7, 2, False, "", "##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute()
        LblCaja.Text = CajaInfo.Nombre
        LblUsuario.Text = UsuarioInfo.Nombre
        TxtFondo.Text = "0.00"

        Me.ShowDialog()
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If Not IsNumeric(TxtFondo.Text) Then
                VerificaMensaje("El monto ingresado debe de ser numérico")
            End If

            If CDbl(TxtFondo.Text) < 0 Then
                TxtFondo.SelectAll()
                VerificaMensaje("El monto de apertura debe de ser mayor o igual a cero")
            End If

            If Not RevisaCajaEstado(False) Then
                VerificaMensaje("Imposible abrir la caja, ya que esta ya se encuentra abierta")
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub FrmAbrirCaja_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FormateaCamposNumericos()
    End Sub
    Private Sub Aceptar()
        Dim Caja As New TCaja(EmpresaInfo.Emp_Id)
        Dim tipoCambio As Decimal
        Try

            With Caja
                .Emp_Id = CajaInfo.Emp_Id
                .Suc_Id = CajaInfo.Suc_Id
                .Caja_Id = CajaInfo.Caja_Id
            End With

            If EmpresaParametroInfo.TipoCambioFac = "C" Then
                tipoCambio = Format(TipoCambioCompra(), "#,##0.00")
            Else
                tipoCambio = Format(TipoCambioVenta(), "#,##0.00")
            End If


            VerificaMensaje(Caja.AbrirCaja(UsuarioInfo.Usuario_Id, CDbl(TxtFondo.Text), tipoCambio))

            VerificaMensaje(CajaInfo.ListKey())

            Mensaje("La caja se abrió correctamente")

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Caja = Nothing
        End Try

    End Sub
    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        If ValidaTodo() Then
            If ConfirmaAccion("Desea abrir la caja?") Then
                Aceptar()
            End If
        End If
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
End Class