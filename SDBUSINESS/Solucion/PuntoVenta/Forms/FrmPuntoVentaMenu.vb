Imports Business
Public Class FrmPuntoVentaMenu
#Region "Variables"
    Private _MenuActual As String
    Private coMenuM1 As String = "M1"
    Private coMenuM2 As String = "M2"
#End Region

    Public Sub Execute()
        _MenuActual = coMenuM1
        RefrescaMenu()

        Me.ShowDialog()
    End Sub

    Private Sub RefrescaMenu()
        Select Case _MenuActual
            Case coMenuM1
                LblF1.Text = "Saldos"
                LblF2.Text = "Artículo"
                'LblF3.Text = "Recarga KOLBI"
                LblF3.Text = "Carga Factura"
                LblF4.Text = "Carga Archivo"
                LblF5.Text = "Consulta Cliente"
                LblF6.Text = "Devolución"
                LblF7.Text = "ReImpresión"
                LblF8.Text = "Abrir Cajón"
                LblF11.Text = "Mas..."
            Case coMenuM2
                LblF1.Text = ""
                LblF2.Text = ""
                LblF3.Text = ""
                LblF4.Text = ""
                LblF5.Text = ""
                LblF6.Text = ""
                LblF7.Text = ""
                LblF11.Text = "Mas..."
        End Select
    End Sub

    Private Sub FrmPuntoVentaMenu_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim Forma As FrmPuntoVenta = Nothing

        Try
            Select Case e.KeyCode
                Case Keys.F11
                    Select Case _MenuActual
                        Case coMenuM1
                            _MenuActual = coMenuM2
                        Case coMenuM2
                            _MenuActual = coMenuM1
                    End Select
                    RefrescaMenu()
                Case Keys.Escape
                    Me.Close()
                Case Keys.F1 And _MenuActual = coMenuM1
                    ConsultarArticulo()
                Case Keys.F2 And _MenuActual = coMenuM1
                    CreaArticulo()
                Case Keys.F3 And _MenuActual = coMenuM1

                    Forma = My.Application.OpenForms("FrmPuntoVenta")

                    If Forma.TxtTipoDocumento.Enabled Then
                        MensajeError("Debe de seleccionar un tipo de documento primero para poder cargar una factura")
                        Me.Close()
                    ElseIf Not Forma.PanelDetalle.Enabled Then
                        MensajeError("Debe de completar el encabezado del documento para poder realizar una carga")
                        Me.Close()
                    Else
                        CargaDetalleFactura()
                    End If
                Case Keys.F4 And _MenuActual = coMenuM1
                    Forma = My.Application.OpenForms("FrmPuntoVenta")

                    If Forma.TxtTipoDocumento.Enabled Then
                        MensajeError("Debe de seleccionar un tipo de documento primero para poder cargar una factura")
                        Me.Close()
                    ElseIf Not Forma.PanelDetalle.Enabled Then
                        MensajeError("Debe de completar el encabezado del documento para poder realizar una carga")
                        Me.Close()
                    Else
                        CargaArchivoArticulos()
                    End If
                Case Keys.F5 And _MenuActual = coMenuM1
                    ConsultarCliente()
                Case Keys.F6 And _MenuActual = coMenuM1
                    Forma = My.Application.OpenForms("FrmPuntoVenta")

                    If Forma.TxtTipoDocumento.Enabled OrElse (Forma.TxtTipoDocumento.Text <> "3" And Forma.TxtTipoDocumento.Text <> "4") Then
                        MensajeError("El tipo de documento no es valido para realizar una devolución")
                        Me.Close()
                    Else
                        DevolucionFactura(CInt(Forma.TxtTipoDocumento.Text))
                    End If
                Case Keys.F7 And _MenuActual = coMenuM1
                    ReImpresionFactura()
                Case Keys.F8 And _MenuActual = coMenuM1

                    If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PvAbreCajon, False) Then
                        VerificaMensaje("No tiene permiso para Abrir Cajón")
                    End If


                    AbrirCajon()
                    Me.Close()
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
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

    Private Sub CargaDetalleFactura()
        Dim Forma As New FrmBusquedaFacturas
        Dim FormaPV As FrmPuntoVenta

        Try
            FormaPV = My.Application.OpenForms("FrmPuntoVenta")
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


    Private Sub CargaArchivoArticulos()
        Dim Forma As New FrmCargaArticulos
        Dim FormaPV As FrmPuntoVenta

        Try
            FormaPV = My.Application.OpenForms("FrmPuntoVenta")
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

    Private Sub DevolucionFactura(pTipoDoc_Id As Enum_TipoDocumento)
        Dim Forma As New FrmBusquedaFacturasDev
        Dim FormaPV As FrmPuntoVenta

        Try
            FormaPV = My.Application.OpenForms("FrmPuntoVenta")
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

    Private Sub ConsultarArticulo()
        Dim Forma As New FrmConsultaArticulo

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub CreaArticulo()
        Dim Forma As New FrmCreaArticulo

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

End Class