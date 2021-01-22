Imports Business
Public Class FrmTomaFisicaAplica
    Dim _TomaFisica As TTomaFisicaEncabezado = Nothing

    Public Sub Execute(pTomaFisica As TTomaFisicaEncabezado)
        Try

            _TomaFisica = pTomaFisica
            CargaBodega()

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaBodega()
        Dim Bodega As New TBodega(EmpresaInfo.Emp_Id)

        Try
            With Bodega
                .Suc_Id = _TomaFisica.Suc_Id
                .Bod_Id = _TomaFisica.Bod_Id
            End With

            VerificaMensaje(Bodega.ListKey)

            LblBodegaNombre.Text = Bodega.Nombre

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Bodega = Nothing
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try

    End Function

    Private Sub AplicaTomaFisica()
        Dim TFEncabezado As New TTomaFisicaEncabezado(EmpresaInfo.Emp_Id)

        Try
            TFEncabezado.Suc_Id = _TomaFisica.Suc_Id
            TFEncabezado.Bod_Id = _TomaFisica.Bod_Id

            VerificaMensaje(TFEncabezado.VerificaTomaFisicaActiva)

            If TFEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontró una Toma Física activa para esta bodega")
                Me.Close()
            End If

            Cursor = Cursors.WaitCursor


            VerificaMensaje(TFEncabezado.AplicaTomaFisica())


            MsgBox("Se ha aplicado la toma Física", MsgBoxStyle.Information)

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TFEncabezado = Nothing
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BtnAplicar_Click(sender As Object, e As EventArgs) Handles BtnAplicar.Click
        If ValidaTodo() Then
            If MsgBox("Desea aplicar la toma física?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                If VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.invAplicaTomaFisica, True) Then
                    AplicaTomaFisica()
                End If
            End If
        End If
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmAplicaTomaFisica_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                If ValidaTodo() Then
                    AplicaTomaFisica()
                End If
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

End Class