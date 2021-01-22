Imports Business

Public Class FrmAjusteVentasyCompras
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

    Private Sub AplicaRebajoAutomatico()
        Dim TFEncabezado As New TTomaFisicaEncabezado(EmpresaInfo.Emp_Id)

        Try
            TFEncabezado.Suc_Id = _TomaFisica.Suc_Id
            TFEncabezado.Bod_Id = _TomaFisica.Bod_Id

            VerificaMensaje(TFEncabezado.VerificaTomaFisicaActiva)

            If TFEncabezado.VerificaRebajoVentasAutomatico Then
                VerificaMensaje("La toma fisica actual ya se le aplico anteriormente el rebajo de ventas y compras automatico")
            End If

            If TFEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontró una Toma Física activa para esta bodega")
                Me.Close()
            End If

            Cursor = Cursors.WaitCursor


            VerificaMensaje(TFEncabezado.AplicaRebajoAutomatico())


            MsgBox("Se ha aplicado el rebajo automático de manera exitosa", MsgBoxStyle.Information)

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
            If MsgBox("Desea rebajo de ventas y compras de manera automatica?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                If VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.InvRebajoVentasAutomatico, True) Then
                    AplicaRebajoAutomatico()
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
                    AplicaRebajoAutomatico()
                End If
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub
End Class