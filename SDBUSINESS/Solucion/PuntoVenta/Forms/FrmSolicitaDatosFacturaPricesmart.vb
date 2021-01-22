Imports Business

Public Class FrmSolicitaDatosFacturaPricesmart

    Private NumericFormat(2) As TNumericFormat
    Private ListadoTiendas As New List(Of TPricesmartTiendas)
    Public _DatosGuardados As Boolean = False
    Dim FeAdjunto As New TFeAdjuntoEncabezado(EmpresaInfo.Emp_Id)
    Private _cliente As TCliente
    Public Enum PricesmartAdjuntoDetalle
        NumeroVendedor = 1
        GLNLugarDeEntrega = 3
        NumeroOrden = 2
        DireccionLugarDeEntrega = 4
        FechaOrden = 5
    End Enum


    Public Sub Execute(pCliente As TCliente)

        FormateaCamposNumericos()
        CargaListadoTiendas()
        CargaCombos()
        CargaDatos(pCliente)
        _DatosGuardados = False
        Me.ShowDialog()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub CargaDatos(pCliente As TCliente)

        Try

            _cliente = pCliente
            FeAdjunto = New TFeAdjuntoEncabezado(EmpresaInfo.Emp_Id)
            FeAdjunto.Adjunto_Id = pCliente.Adjunto_Id
            VerificaMensaje(FeAdjunto.CargaAdjuntos)
            For Each t As DataRow In FeAdjunto.Data.Tables(0).Rows

                If ("NumeroVendedor" = t.Item("Etiqueta")) Then
                    TxtCodigoProveedor.Text = t.Item("Valor")
                End If

                '-----------------------------------------------
                If ("GLNLugarDeEntrega" = t.Item("Etiqueta")) Then
                    CmbLugarDeEntrega.SelectedValue = t.Item("Valor")
                End If

                '-----------------------------------------------

                '-----------------------------------------------
                If ("NumeroOrden" = t.Item("Etiqueta")) Then
                    TxtNumeroDeOrden.Text = t.Item("Valor")
                End If
                '-----------------------------------------------
            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub

    Private Sub CargaCombos()
        CmbLugarDeEntrega.DataSource = ListadoTiendas
        CmbLugarDeEntrega.DisplayMember = "Nombre"
        CmbLugarDeEntrega.ValueMember = "Codigo"
        CmbLugarDeEntrega.SelectedIndex = 0
    End Sub

    Private Sub CargaListadoTiendas()
        ListadoTiendas = New List(Of TPricesmartTiendas)()

        ListadoTiendas.Add(New TPricesmartTiendas("G6401", "Zapote"))
        ListadoTiendas.Add(New TPricesmartTiendas("6402", "Escazú"))
        ListadoTiendas.Add(New TPricesmartTiendas("G6403", "Heredia"))
        ListadoTiendas.Add(New TPricesmartTiendas("G6404", "Llorente"))
        ListadoTiendas.Add(New TPricesmartTiendas("G6405", "Alajuela"))
        ListadoTiendas.Add(New TPricesmartTiendas("G6406", "Tres Ríos"))
        ListadoTiendas.Add(New TPricesmartTiendas("G6407", "Santa Ana"))
    End Sub

    Private Sub CapturaGuardaDatos()
        Try
            If ValidaTodo() Then
                GuardaDatos()
                _DatosGuardados = True
                Me.Close()
            End If
        Catch ex As Exception
            Mensaje(ex.Message)
        End Try
    End Sub


    Private Sub GuardaDatos()
        Dim FeAdjunto As New TFeAdjuntoEncabezado(EmpresaInfo.Emp_Id)
        Try
            FeAdjunto.Adjunto_Id = _cliente.Adjunto_Id

            'Actualiza NumeroVendedor
            FeAdjunto.ActulizaAdjuntos(PricesmartAdjuntoDetalle.NumeroVendedor, TxtCodigoProveedor.Text)

            'Actualiza GLNLugarDeEntrega
            FeAdjunto.ActulizaAdjuntos(PricesmartAdjuntoDetalle.GLNLugarDeEntrega, CmbLugarDeEntrega.SelectedValue.ToString())

            'Actualiza DireccionLugarDeEntrega
            FeAdjunto.ActulizaAdjuntos(PricesmartAdjuntoDetalle.DireccionLugarDeEntrega, ListadoTiendas(CmbLugarDeEntrega.SelectedIndex).Nombre.ToString())

            'Actualiza NumeroOrden
            FeAdjunto.ActulizaAdjuntos(PricesmartAdjuntoDetalle.NumeroOrden, TxtNumeroDeOrden.Text.ToString())

            'Actualiza FechaOrden
            FeAdjunto.ActulizaAdjuntos(PricesmartAdjuntoDetalle.FechaOrden, DtpFechaOrden.Value.ToString("yyyy-MM-dd") & "")

        Catch ex As Exception
            Mensaje(ex.Message)
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean

        Try
            If TxtCodigoProveedor.Text.Equals("") Then
                VerificaMensaje("El codigo de proveedor no puede estar en blanco.")
            End If

            If TxtCodigoProveedor.Text.Equals("0") Then
                VerificaMensaje("El codigo de proveedor no puede ser 0.")
            End If

            If TxtNumeroDeOrden.Text.Equals("") Then
                VerificaMensaje("El número de orden no puede ir en blanco.")
            End If

            If TxtNumeroDeOrden.Text.Equals("0") Then
                VerificaMensaje("El número de orden no puede ser 0.")
            End If

            Return True

        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Private Sub FormateaCamposNumericos()
        NumericFormat(1) = New TNumericFormat(TxtCodigoProveedor, 12, 0, False, "", "###0")
        NumericFormat(1) = New TNumericFormat(TxtNumeroDeOrden, 12, 0, False, "", "###0")
    End Sub

    Private Sub CmbLugarDeEntrega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbLugarDeEntrega.SelectedIndexChanged
        Try
            LblCodigo.Text = CmbLugarDeEntrega.SelectedValue
        Catch ex As Exception

        End Try

    End Sub



    Private Sub FrmSolicitaDatosFacturaPricesmart_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnAceptar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        CapturaGuardaDatos()
    End Sub

    Private Sub TxtCodigoProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigoProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtNumeroDeOrden.Select()
        End If
    End Sub
End Class