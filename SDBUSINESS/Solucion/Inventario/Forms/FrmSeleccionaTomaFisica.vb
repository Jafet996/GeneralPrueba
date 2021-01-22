Imports Business
Imports System.Threading

Public Class FrmSeleccionaTomaFisica
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

    Private Sub CargaArticulosBodega()
        Dim TFEncabezado As New TTomaFisicaEncabezado(EmpresaInfo.Emp_Id)
        Dim TFDetalleTmp As New TTomaFisicaDetalle(EmpresaInfo.Emp_Id)
        Dim ArticuloBodega = New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim TFDetalle = Nothing
        Dim Articulo As TArticulo = Nothing

        Try
            With TFEncabezado
                .Suc_Id = SucursalInfo.Suc_Id
                .Bod_Id = CmbBodega.SelectedValue
                .FechaInicio = EmpresaInfo.Getdate
                .Usuario_Id = UsuarioInfo.Usuario_Id
                .Activo = 1
                .Siguiente()
            End With

            VerificaMensaje(TFEncabezado.Insert)

            With TFDetalleTmp
                .Suc_Id = TFEncabezado.Suc_Id
                .Bod_Id = TFEncabezado.Bod_Id
                .TomaFisica_Id = TFEncabezado.TomaFisica_Id - 1
            End With

            VerificaMensaje(TFDetalleTmp.BorraTomaFisicaDetalle)

            ArticuloBodega.Suc_Id = SucursalInfo.Suc_Id
            ArticuloBodega.Bod_Id = CmbBodega.SelectedValue

            VerificaMensaje(ArticuloBodega.ArticulosConteo)

            If ArticuloBodega.Data.Tables(0).Rows.Count <= 0 Then
                VerificaMensaje("No hay articulos disponibles")
            End If

            For Each Fila As DataRow In ArticuloBodega.Data.Tables(0).Rows
                TFDetalle = New TTomaFisicaDetalle(EmpresaInfo.Emp_Id)
                Articulo = New TArticulo(EmpresaInfo.Emp_Id)

                TFDetalle.Suc_Id = SucursalInfo.Suc_Id
                TFDetalle.Bod_Id = CmbBodega.SelectedValue

                Articulo.Art_Id = Fila("Art_Id")

                VerificaMensaje(Articulo.ListKey)

                With TFDetalle
                    .TomaFisica_Id = TFEncabezado.TomaFisica_Id
                    .Art_Id = Fila("Art_Id")
                    .Suelto = Articulo.Suelto
                    .Magnetico = Fila("Saldo")
                    .FactorConversion = Articulo.FactorConversion
                End With

                VerificaMensaje(TFDetalle.Insert)

            Next

            MsgBox("Se ha iniciado una toma Física correctamente", MsgBoxStyle.Information)

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TFEncabezado = Nothing
            TFDetalle = Nothing
            ArticuloBodega = Nothing
            Articulo = Nothing
        End Try

    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnIniciar.Click
        Try

            If ValidaTodo() Then
                Cursor = Cursors.WaitCursor
                
                CargaArticulosBodega()
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
                    CargaArticulosBodega()
                End If
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub
End Class