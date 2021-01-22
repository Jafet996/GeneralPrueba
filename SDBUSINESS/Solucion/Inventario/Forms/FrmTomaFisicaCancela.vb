Imports Business
Public Class FrmTomaFisicaCancela
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

    Private Sub CancelarTomaFisica()
        Dim TFEncabezado As New TTomaFisicaEncabezado(EmpresaInfo.Emp_Id)

        Try
            With TFEncabezado
                .Suc_Id = _TomaFisica.Suc_Id
                .Bod_Id = _TomaFisica.Bod_Id
                .TomaFisica_Id = _TomaFisica.TomaFisica_Id
            End With

            VerificaMensaje(TFEncabezado.BorraTomaFisica)

            Mensaje("Se ha cancelado la Toma Física")

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
            If VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.InvCancelarTomaFisica, True) Then
                If MsgBox("Desea cancelar la Toma Física", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                    CancelarTomaFisica()
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
                BtnAplicar.PerformClick()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub GuardarMovimientoSueltos(pTFEncabezado As TTomaFisicaEncabezado)
        'Dim MovimientoEncabezadoSuma As New TMovimientoEncabezado(EmpresaInfo.Emp_Id)
        'Dim MovimientoEncabezadoResta As New TMovimientoEncabezado(EmpresaInfo.Emp_Id)
        'Dim MovimientoDetalle As TMovimientoDetalle = Nothing
        'Dim TFDetalle As New TTomaFisicaDetalle(EmpresaInfo.Emp_Id)
        'Dim ArticuloBodega As TArticuloBodega = Nothing
        'Dim TipoMovimiento As Integer = 0
        'Dim Cantidad As Double = 0
        'Dim CostoSuma As Double = 0
        'Dim CostoResta As Double = 0
        'Dim DetalleSuma As Integer = 0
        'Dim DetalleResta As Integer = 0

        'Try
        '    TFDetalle.Suc_Id = SucursalInfo.Suc_Id
        '    TFDetalle.Bod_Id = CmbBodega.SelectedValue
        '    TFDetalle.TomaFisica_Id = pTFEncabezado.TomaFisica_Id

        '    VerificaMensaje(TFDetalle.ListaTomaFisicaDetalle(1))

        '    If TFDetalle.Data.Tables(0).Rows.Count = 0 Then
        '        VerificaMensaje("No se encontrarón artículos sueltos")
        '    End If

        '    With MovimientoEncabezadoSuma
        '        .Emp_Id = SucursalInfo.Emp_Id
        '        .Suc_Id = SucursalInfo.Suc_Id
        '        .TipoMov_Id = 2
        '        .Mov_Id = 0
        '        .Bod_Id = CmbBodega.SelectedValue
        '        .Fecha = EmpresaInfo.Getdate()
        '        .Comentario = "Ajuste de inventario generado automaticamente para Artículos Sueltos"
        '        .Aplicado = 0
        '        .Usuario_Id = UsuarioInfo.Usuario_Id
        '        .Suc_Id_Destino = 0
        '        .Bod_Id_Destino = 0
        '    End With

        '    With MovimientoEncabezadoResta
        '        .Emp_Id = SucursalInfo.Emp_Id
        '        .Suc_Id = SucursalInfo.Suc_Id
        '        .TipoMov_Id = 3
        '        .Mov_Id = 0
        '        .Bod_Id = CmbBodega.SelectedValue
        '        .Fecha = EmpresaInfo.Getdate()
        '        .Comentario = "Ajuste de inventario generado automaticamente para Artículos Sueltos"
        '        .Aplicado = 0
        '        .Usuario_Id = UsuarioInfo.Usuario_Id
        '        .Suc_Id_Destino = 0
        '        .Bod_Id_Destino = 0
        '    End With

        '    For Each Fila As DataRow In TFDetalle.Data.Tables(0).Rows
        '        Cantidad = CDbl(Fila("Fisico")) - CDbl(Fila("Magnetico"))

        '        If Cantidad > 0 Then
        '            TipoMovimiento = 2
        '        Else
        '            TipoMovimiento = 3
        '        End If

        '        ArticuloBodega = New TArticuloBodega(EmpresaInfo.Emp_Id)

        '        With ArticuloBodega
        '            .Suc_Id = SucursalInfo.Suc_Id
        '            .Bod_Id = CmbBodega.SelectedValue
        '            .Art_Id = Fila("Art_Id")
        '        End With

        '        VerificaMensaje(ArticuloBodega.ListKey)

        '        If ArticuloBodega.RowsAffected = 0 Then
        '            VerificaMensaje("No se encontró un artículo con el código " & Fila("Art_Id"))
        '        End If

        '        If Cantidad <> 0 Then

        '            MovimientoDetalle = New TMovimientoDetalle(SucursalInfo.Emp_Id)

        '            With MovimientoDetalle
        '                .Suc_Id = SucursalInfo.Suc_Id
        '                .Art_Id = ArticuloBodega.Art_Id
        '                .Cantidad = Cantidad
        '                .Costo = ArticuloBodega.Costo
        '                .TotalLinea = Cantidad * ArticuloBodega.Costo
        '                .Suelto = CInt(Fila("Suelto"))
        '            End With

        '            If TipoMovimiento = 2 Then
        '                CostoSuma += Cantidad * ArticuloBodega.Costo
        '                DetalleSuma += 1

        '                With MovimientoDetalle
        '                    .TipoMov_Id = TipoMovimiento
        '                    .Mov_Id = MovimientoEncabezadoSuma.Mov_Id
        '                    .Detalle_Id = DetalleSuma
        '                    .Fecha = MovimientoEncabezadoSuma.Fecha
        '                End With

        '                MovimientoEncabezadoSuma.ListaDetalles.Add(MovimientoDetalle)

        '            ElseIf TipoMovimiento = 3 Then
        '                CostoResta -= Cantidad * ArticuloBodega.Costo
        '                DetalleResta += 1

        '                With MovimientoDetalle
        '                    .TipoMov_Id = TipoMovimiento
        '                    .Mov_Id = MovimientoEncabezadoResta.Mov_Id
        '                    .Detalle_Id = DetalleResta
        '                    .Fecha = MovimientoEncabezadoResta.Fecha
        '                    .TotalLinea = .TotalLinea * -1
        '                End With

        '                MovimientoEncabezadoResta.ListaDetalles.Add(MovimientoDetalle)

        '            End If

        '        End If
        '    Next

        '    If DetalleSuma <> 0 Then
        '        MovimientoEncabezadoSuma.Costo = CostoSuma
        '        VerificaMensaje(MovimientoEncabezadoSuma.GuardarDocumento)

        '        MovimientoEncabezadoSuma.AplicaUsuario_Id = UsuarioInfo.Usuario_Id
        '        VerificaMensaje(MovimientoEncabezadoSuma.AplicarDocumentoAjuste())
        '    End If

        '    If DetalleResta <> 0 Then
        '        MovimientoEncabezadoResta.Costo = CostoResta * -1
        '        VerificaMensaje(MovimientoEncabezadoResta.GuardarDocumento)

        '        MovimientoEncabezadoResta.AplicaUsuario_Id = UsuarioInfo.Usuario_Id
        '        VerificaMensaje(MovimientoEncabezadoResta.AplicarDocumentoAjuste())
        '    End If

        'Catch ex As Exception
        '    MensajeError(ex.Message)
        'Finally
        '    MovimientoEncabezadoSuma = Nothing
        '    MovimientoEncabezadoResta = Nothing
        '    MovimientoDetalle = Nothing
        '    TFDetalle = Nothing
        '    ArticuloBodega = Nothing
        'End Try

    End Sub

    Private Sub GuardarMovimientoCajas(pTFEncabezado As TTomaFisicaEncabezado)
        '    Dim MovimientoEncabezadoSuma As New TMovimientoEncabezado(EmpresaInfo.Emp_Id)
        '    Dim MovimientoEncabezadoResta As New TMovimientoEncabezado(EmpresaInfo.Emp_Id)
        '    Dim MovimientoDetalle As TMovimientoDetalle = Nothing
        '    Dim TFDetalle As New TTomaFisicaDetalle(EmpresaInfo.Emp_Id)
        '    Dim ArticuloBodega As TArticuloBodega = Nothing
        '    Dim TipoMovimiento As Integer = 0
        '    Dim Cantidad As Double = 0
        '    Dim CostoSuma As Double = 0
        '    Dim CostoResta As Double = 0
        '    Dim DetalleSuma As Integer = 0
        '    Dim DetalleResta As Integer = 0

        '    Try
        '        TFDetalle.Suc_Id = SucursalInfo.Suc_Id
        '        TFDetalle.Bod_Id = CmbBodega.SelectedValue
        '        TFDetalle.TomaFisica_Id = pTFEncabezado.TomaFisica_Id

        '        VerificaMensaje(TFDetalle.ListaTomaFisicaDetalle(0))

        '        If TFDetalle.Data.Tables(0).Rows.Count = 0 Then
        '            VerificaMensaje("No se encontrarón artículos sueltos")
        '        End If

        '        With MovimientoEncabezadoSuma
        '            .Emp_Id = SucursalInfo.Emp_Id
        '            .Suc_Id = SucursalInfo.Suc_Id
        '            .TipoMov_Id = 2
        '            .Mov_Id = 0
        '            .Bod_Id = CmbBodega.SelectedValue
        '            .Fecha = EmpresaInfo.Getdate()
        '            .Comentario = "Ajuste de inventario generado automaticamente para Cajas"
        '            .Aplicado = 0
        '            .Usuario_Id = UsuarioInfo.Usuario_Id
        '            .Suc_Id_Destino = 0
        '            .Bod_Id_Destino = 0
        '        End With

        '        With MovimientoEncabezadoResta
        '            .Emp_Id = SucursalInfo.Emp_Id
        '            .Suc_Id = SucursalInfo.Suc_Id
        '            .TipoMov_Id = 3
        '            .Mov_Id = 0
        '            .Bod_Id = CmbBodega.SelectedValue
        '            .Fecha = EmpresaInfo.Getdate()
        '            .Comentario = "Ajuste de inventario generado automaticamente para Cajas"
        '            .Aplicado = 0
        '            .Usuario_Id = UsuarioInfo.Usuario_Id
        '            .Suc_Id_Destino = 0
        '            .Bod_Id_Destino = 0
        '        End With

        '        For Each Fila As DataRow In TFDetalle.Data.Tables(0).Rows
        '            Cantidad = CDbl(Fila("Fisico")) - CDbl(Fila("Magnetico"))

        '            If Cantidad > 0 Then
        '                TipoMovimiento = 2
        '            Else
        '                TipoMovimiento = 3
        '            End If

        '            ArticuloBodega = New TArticuloBodega(EmpresaInfo.Emp_Id)

        '            With ArticuloBodega
        '                .Suc_Id = SucursalInfo.Suc_Id
        '                .Bod_Id = CmbBodega.SelectedValue
        '                .Art_Id = Fila("Art_Id")
        '            End With

        '            VerificaMensaje(ArticuloBodega.ListKey)

        '            If ArticuloBodega.RowsAffected = 0 Then
        '                VerificaMensaje("No se encontró un artículo con el código " & Fila("Art_Id"))
        '            End If

        '            If Cantidad <> 0 Then

        '                MovimientoDetalle = New TMovimientoDetalle(SucursalInfo.Emp_Id)

        '                With MovimientoDetalle
        '                    .Suc_Id = SucursalInfo.Suc_Id
        '                    .Art_Id = ArticuloBodega.Art_Id
        '                    .Cantidad = Cantidad
        '                    .Costo = ArticuloBodega.Costo
        '                    .TotalLinea = Cantidad * ArticuloBodega.Costo
        '                    .Suelto = CInt(Fila("Suelto"))
        '                End With

        '                If TipoMovimiento = 2 Then
        '                    CostoSuma += Cantidad * ArticuloBodega.Costo
        '                    DetalleSuma += 1

        '                    With MovimientoDetalle
        '                        .TipoMov_Id = TipoMovimiento
        '                        .Mov_Id = MovimientoEncabezadoSuma.Mov_Id
        '                        .Detalle_Id = DetalleSuma
        '                        .Fecha = MovimientoEncabezadoSuma.Fecha
        '                    End With

        '                    MovimientoEncabezadoSuma.ListaDetalles.Add(MovimientoDetalle)

        '                ElseIf TipoMovimiento = 3 Then
        '                    CostoResta -= Cantidad * ArticuloBodega.Costo
        '                    DetalleResta += 1

        '                    With MovimientoDetalle
        '                        .TipoMov_Id = TipoMovimiento
        '                        .Mov_Id = MovimientoEncabezadoResta.Mov_Id
        '                        .Detalle_Id = DetalleResta
        '                        .Fecha = MovimientoEncabezadoResta.Fecha
        '                        .TotalLinea = .TotalLinea * -1
        '                    End With

        '                    MovimientoEncabezadoResta.ListaDetalles.Add(MovimientoDetalle)

        '                End If

        '            End If
        '        Next

        '        If DetalleSuma <> 0 Then
        '            MovimientoEncabezadoSuma.Costo = CostoSuma
        '            VerificaMensaje(MovimientoEncabezadoSuma.GuardarDocumento)

        '            MovimientoEncabezadoSuma.AplicaUsuario_Id = UsuarioInfo.Usuario_Id
        '            VerificaMensaje(MovimientoEncabezadoSuma.AplicarDocumentoAjuste())
        '        End If

        '        If DetalleResta <> 0 Then
        '            MovimientoEncabezadoResta.Costo = CostoResta * -1
        '            VerificaMensaje(MovimientoEncabezadoResta.GuardarDocumento)

        '            MovimientoEncabezadoResta.AplicaUsuario_Id = UsuarioInfo.Usuario_Id
        '            VerificaMensaje(MovimientoEncabezadoResta.AplicarDocumentoAjuste())
        '        End If

        '    Catch ex As Exception
        '        MensajeError(ex.Message)
        '    Finally
        '        MovimientoEncabezadoSuma = Nothing
        '        MovimientoEncabezadoResta = Nothing
        '        MovimientoDetalle = Nothing
        '        TFDetalle = Nothing
        '        ArticuloBodega = Nothing
        '    End Try
    End Sub
End Class