Imports Business
Public Class FrmPuntoVentaFuncionalidades
    Private Sub BtnConsultaSaldos_Click(sender As Object, e As EventArgs) Handles BtnConsultaSaldos.Click
        Try

            ConsultarArticulo()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub ConsultarArticulo()
        Dim Forma As New  FrmConsultaArticulo

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Public Sub Execute(pTipoFacturacion As Enum_TipoFacturacion)
        Try

            If InfoMaquina.InterfazFactura <> Enum_InterfazFacturacion.Reducida Then
                Me.Height = 333
            End If


            BtnReferencia.Enabled = (pTipoFacturacion = Enum_TipoFacturacion.Factura)
            BtnImprimeUltimaFactura.Enabled = (pTipoFacturacion = Enum_TipoFacturacion.Factura)


            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaDetalleFactura()
        Dim Forma As New FrmBusquedaFacturas
        Dim FormaPV As FrmPuntoVentaRetail

        Try
            FormaPV = My.Application.OpenForms("FrmPuntoVentaRetail")
            Forma.Execute()

            If Not Forma.Respuesta Is Nothing Then
                FormaPV.CargaDetalleFactura(Forma.Respuesta)
            End If

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
            FormaPV = Nothing
        End Try
    End Sub

    Private Sub BtnCargaFactura_Click(sender As Object, e As EventArgs) Handles BtnCargaFactura.Click
        Dim Forma As FrmPuntoVentaRetail = Nothing
        Try

            Forma = My.Application.OpenForms("FrmPuntoVentaRetail")

            If Forma.TxtTipoDocumento.Enabled Then
                MensajeError("Debe de seleccionar un tipo de documento primero para poder cargar una factura")
                Me.Close()
            ElseIf Not Forma.PanelDetalle.Enabled Then
                MensajeError("Debe de completar el encabezado del documento para poder realizar una carga")
                Me.Close()
            Else
                CargaDetalleFactura()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaArchivoArticulos()
        Dim Forma As New FrmCargaArticulos
        Dim FormaPV As FrmPuntoVentaRetail

        Try
            FormaPV = My.Application.OpenForms("FrmPuntoVentaRetail")
            Forma.Execute()

            If Forma.Guardo Then
                FormaPV.CargaArchivoArticulos(Forma.ListaConteo)
            End If

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
            FormaPV = Nothing
        End Try
    End Sub

    Private Sub BtnCargaArchivo_Click(sender As Object, e As EventArgs) Handles BtnCargaArchivo.Click
        Dim Forma As FrmPuntoVentaRetail = Nothing
        Try

            Forma = My.Application.OpenForms("FrmPuntoVentaRetail")

            If Forma.TxtTipoDocumento.Enabled Then
                MensajeError("Debe de seleccionar un tipo de documento primero para poder cargar una factura")
                Me.Close()
            ElseIf Not Forma.PanelDetalle.Enabled Then
                MensajeError("Debe de completar el encabezado del documento para poder realizar una carga")
                Me.Close()
            Else
                CargaArchivoArticulos()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ConsultarCliente()
        Dim Forma As New FrmConsultaCliente

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnConsultaCliente_Click(sender As Object, e As EventArgs) Handles BtnConsultaCliente.Click
        Try

            ConsultarCliente()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub DevolucionFactura(pTipoDoc_Id As Enum_TipoDocumento)
        Dim Forma As New FrmBusquedaFacturasDev
        Dim FormaPV As FrmPuntoVentaRetail

        Try
            FormaPV = My.Application.OpenForms("FrmPuntoVentaRetail")
            Forma.Execute(pTipoDoc_Id)

            If Not Forma.Respuesta Is Nothing Then
                FormaPV.CargaFacturaDev(Forma.Respuesta)
            End If

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
            FormaPV = Nothing
        End Try
    End Sub


    Private Sub AgregaReferenciaFactura(pTipoDoc_Id As Enum_TipoDocumento)
        'Dim Forma As New FrmBusquedaFacturasDev
        Dim FormaPV As FrmPuntoVentaRetail

        Try
            FormaPV = My.Application.OpenForms("FrmPuntoVentaRetail")

            VerificaMensaje(FormaPV.ReferenciaFacturaManual(pTipoDoc_Id))

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaPV = Nothing
        End Try
    End Sub

    Private Sub BtnDevolucionMercaderia_Click(sender As Object, e As EventArgs) Handles BtnDevolucionMercaderia.Click
        Dim Forma As FrmPuntoVentaRetail = Nothing
        Try

            Forma = My.Application.OpenForms("FrmPuntoVentaRetail")

            If Forma.TxtTipoDocumento.Enabled OrElse (Forma.TxtTipoDocumento.Text <> "3" And Forma.TxtTipoDocumento.Text <> "4") Then
                MensajeError("El tipo de documento no es valido para realizar una devolución")
                Me.Close()
            Else
                DevolucionFactura(CInt(Forma.TxtTipoDocumento.Text))
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnAbrirGaveta_Click(sender As Object, e As EventArgs) Handles BtnAbrirGaveta.Click
        Try

            If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PvAbreCajon, False) Then
                VerificaMensaje("No tiene permiso para Abrir Cajón")
            End If

            AbrirCajon()

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnPagoFactura_Click(sender As Object, e As EventArgs) Handles BtnPagoFactura.Click
        Dim Forma As New FrmCxCPago
        Try

            If Not EmpresaParametroInfo.InterfazCxC Then
                VerificaMensaje("No tiene activada la interfaz de Cuentas x Cobrar")
            End If

            If CajaInfo.PreFacturas Then
                VerificaMensaje("Opcion no disponible en prefacturas")
            End If

            If RevisaCajaEstado(True) Then
                VerificaMensaje(CajaInfo.ListKey)
                Forma.Execute()
            Else
                VerificaMensaje("Imposible facturar, primero debe de abrir caja")
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnAbonoApartado_Click(sender As Object, e As EventArgs) Handles BtnAbonoApartado.Click
        Dim Forma As New FrmBusquedaApartado
        Try
            If CajaInfo.PreFacturas Then
                VerificaMensaje("Opcion no disponible en prefacturas")
            End If

            If SucursalParametroInfo.BodegaApartado_Id <= 0 Then
                VerificaMensaje("No se encontró definida una bodega de apartados")
            End If

            If RevisaCajaEstado(True) Then
                VerificaMensaje(CajaInfo.ListKey)
                Forma.Execute()
            Else
                VerificaMensaje("Imposible crear apartados, primero debe de abrir caja")
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub


    Private Sub ReImpresionFactura()
        Dim Forma As New FrmReimpresionFactura
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Sub BtnReenvioDocumento_Click(sender As Object, e As EventArgs) Handles BtnReenvioDocumento.Click
        Try

            ReImpresionFactura()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnCreaCliente_Click(sender As Object, e As EventArgs) Handles BtnCreaCliente.Click
        Dim Forma As New FrmMantClienteDetalle
        Dim FormaPV As New FrmPuntoVentaRetail
        Dim Mensaje As String = ""
        Try


            FormaPV = My.Application.OpenForms("FrmPuntoVentaRetail")

            Forma.Titulo = "Creacion de Cliente"
            Forma.Nuevo = True
            Forma.Execute(-1)

            If Forma.GuardoCambios Then
                FormaPV.TxtCliente.Text = Forma.ClienteNuevo
                FormaPV.TxtCliente_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                Me.Close()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub FrmPuntoVentaFuncionalidades_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Me.Close()
    End Sub

    Private Sub BtnEntradaEfectivo_Click(sender As Object, e As EventArgs) Handles BtnEntradaEfectivo.Click
        Dim Forma As New FrmEntradaEfectivo
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnSalidaEfectivo_Click(sender As Object, e As EventArgs) Handles BtnSalidaEfectivo.Click
        Dim Forma As New FrmSalidaEfectivo
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnReferencia_Click(sender As Object, e As EventArgs) Handles BtnReferencia.Click
        Dim Forma As FrmPuntoVentaRetail = Nothing
        Try

            Forma = My.Application.OpenForms("FrmPuntoVentaRetail")

            If Forma.TxtTipoDocumento.Enabled OrElse (Forma.TxtTipoDocumento.Text <> "1" And Forma.TxtTipoDocumento.Text <> "2") Then
                MensajeError("Opción disponible únicamente para facturas")
                Me.Close()
            Else
                AgregaReferenciaFactura(CInt(Forma.TxtTipoDocumento.Text))
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnImprimeUltimaFactura_Click(sender As Object, e As EventArgs) Handles BtnImprimeUltimaFactura.Click
        Dim FormaPV As FrmPuntoVentaRetail
        Try

            FormaPV = My.Application.OpenForms("FrmPuntoVentaRetail")

            FormaPV.ImprimeUltimaFactura()

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaPV = Nothing
        End Try
    End Sub

    Private Sub BtnOtrosValores_Click(sender As Object, e As EventArgs) Handles BtnOtrosValores.Click
        Dim Forma As New FrmOtroValor
        Dim FormaPV As FrmPuntoVentaRetail
        Try

            FormaPV = My.Application.OpenForms("FrmPuntoVentaRetail")


            If FormaPV.TxtTipoDocumento.Enabled OrElse Not IsNumeric(FormaPV.TxtTipoDocumento.Text) Then
                MensajeError("Debe de seleccionar el tipo de documento")
                Me.Close()
                Exit Sub
            End If



            Forma.OtrosValores = FormaPV._OtroValores
            Forma.Execute()
            FormaPV._OtroValores = Forma.OtrosValores


            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaPV = Nothing
        End Try
    End Sub

    Private Sub BtnArticulo_Click(sender As Object, e As EventArgs) Handles BtnArticulo.Click
        Dim Forma As New FrmMantArticuloDetalle
        Try

            If VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PVMantenimientodeArticulos, True) Then
                Forma.Execute()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
End Class