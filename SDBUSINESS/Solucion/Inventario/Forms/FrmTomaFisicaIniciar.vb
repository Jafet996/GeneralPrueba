Imports Business
Imports System.Threading

Public Class FrmTomaFisicaIniciar
    Public Sub Execute()
        LlenaComboBodega()
        MuestraErrores(False)

        Me.ShowDialog()
    End Sub

    Private Sub LlenaComboBodega()
        Dim Bodega As New TBodega(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""

        Try
            If Not IsNumeric(SucursalInfo.Suc_Id) Then
                Exit Sub
            End If

            Bodega.Suc_Id = CInt(SucursalInfo.Suc_Id)
            Mensaje = Bodega.LoadComboBox(CmbBodega)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Bodega = Nothing
        End Try
    End Sub

    Private Sub MuestraErrores(pMostrar As Boolean)
        Try
            LblInfoInicio.Visible = pMostrar
            LblFechaInicio.Visible = pMostrar
            LblInfoUsuario.Visible = pMostrar
            LblUsuario.Visible = pMostrar
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Dim TomaFisica As New TTomaFisicaEncabezado(EmpresaInfo.Emp_Id)
        Try
            If CmbBodega.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar una bodega.")
                CmbBodega.SelectedIndex = 0
            End If

            TomaFisica.Suc_Id = SucursalInfo.Suc_Id
            TomaFisica.Bod_Id = CmbBodega.SelectedValue

            VerificaMensaje(TomaFisica.VerificaTomaFisicaActiva)

            If TomaFisica.RowsAffected > 0 Then
                MuestraErrores(True)

                LblFechaInicio.Text = TomaFisica.FechaInicio
                LblUsuario.Text = TomaFisica.Usuario_Id

                VerificaMensaje("En este momento hay una toma física abierta para la bodega seleccionada")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        Finally
            TomaFisica = Nothing
        End Try

    End Function

    Private Sub CreaTomafisica()
        Dim TomaFisicaEncabezado As New TTomaFisicaEncabezado(EmpresaInfo.Emp_Id)
        Try
            With TomaFisicaEncabezado
                .Suc_Id = SucursalInfo.Suc_Id
                .Bod_Id = CmbBodega.SelectedValue
                .Usuario_Id = UsuarioInfo.Usuario_Id
            End With

            VerificaMensaje(TomaFisicaEncabezado.CreaTomaFisica)

            Mensaje("Se ha iniciado una Toma Física correctamente")

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TomaFisicaEncabezado = Nothing
        End Try

    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnIniciar.Click
        Try

            If ValidaTodo() Then
                Cursor = Cursors.WaitCursor

                If VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.InvIniciaTomaFisica, True) Then
                    If MsgBox("Desea iniciar una Toma Física", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                        CreaTomafisica()
                    End If
                End If

            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FrmSeleccionaTomaFisica_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                If ValidaTodo() Then
                    CreaTomafisica()
                End If
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub
End Class