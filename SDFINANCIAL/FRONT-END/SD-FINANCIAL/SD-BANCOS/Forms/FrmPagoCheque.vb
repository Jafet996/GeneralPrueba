Imports BUSINESS
Public Class FrmPagoCheque
#Region "Variables"
    Private _Titulo As String = "Cheque"
    Private _Prov_Id As Integer = 0
    Private _MontoColones As Double = 0.0
    Private _MontoDolares As Double = 0.0
    Private _Diferencial As Double = 0.0
    Private _ListaCxPSolicitud As New List(Of TCxPSolicitudPago)
    Private _Acepto As Boolean = False
#End Region
#Region "Propiedades"
    Public WriteOnly Property Prov_Id As Integer
        Set(value As Integer)
            _Prov_Id = value
        End Set
    End Property
    Public WriteOnly Property MontoColones As Double
        Set(value As Double)
            _MontoColones = value
        End Set
    End Property
    Public WriteOnly Property MontoDolares As Double
        Set(value As Double)
            _MontoDolares = value
        End Set
    End Property
    Public WriteOnly Property Diferencial As Double
        Set(value As Double)
            _Diferencial = value
        End Set
    End Property
    Public WriteOnly Property ListaCxPSolicitud As List(Of TCxPSolicitudPago)
        Set(value As List(Of TCxPSolicitudPago))
            _ListaCxPSolicitud = value
        End Set
    End Property
    Public ReadOnly Property Acepto As Boolean
        Get
            Return _Acepto
        End Get
    End Property
    Public WriteOnly Property Titulo As String
        Set(value As String)
            _Titulo = value
        End Set
    End Property
#End Region

    Public Sub Execute()
        Try
            CargaComboBanco()
            CargaDatos()

            Me.Text = _Titulo
            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaComboBanco()
        Dim Banco As New TBanco

        Try
            CmbBanco.Items.Clear()

            With Banco
                .Emp_Id = EmpresaInfo.Emp_Id
            End With
            VerificaMensaje(Banco.LoadComboBoxEmpresaCuenta(CmbBanco))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Banco = Nothing
        End Try
    End Sub

    Private Sub CargaComboCuenta()
        Dim EmpresaCuenta As New TEmpresaCuenta

        Try
            If CmbBanco.SelectedValue Is Nothing OrElse CmbBanco.SelectedValue.ToString.Equals("System.Data.DataRowView") Then
                Exit Sub
            End If

            CmbCuenta.DataSource = Nothing

            With EmpresaCuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Banco_Id = CmbBanco.SelectedValue
            End With
            VerificaMensaje(EmpresaCuenta.LoadComboBox(CmbCuenta))

            AsignaMonedaCuenta()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            EmpresaCuenta = Nothing
        End Try
    End Sub

    Private Sub AsignaMonedaCuenta()
        Dim EmpresaCuenta As New TEmpresaCuenta

        Try
            If CmbCuenta.SelectedValue Is Nothing OrElse CmbCuenta.SelectedValue.ToString.Equals("System.Data.DataRowView") Then
                Exit Sub
            End If

            With EmpresaCuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cuenta_Id = CmbCuenta.SelectedValue
            End With
            VerificaMensaje(EmpresaCuenta.ListKey)

            CmbMoneda.SelectedIndex = IIf(EmpresaCuenta.Moneda = coMonedaColones, 0, 1)

            Select Case EmpresaCuenta.Moneda
                Case coMonedaColones
                    LblMonto.Text = Format(_MontoColones, "#,##0.00")
                Case coMonedaDolares
                    LblMonto.Text = Format(_MontoDolares, "#,##0.00")
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            EmpresaCuenta = Nothing
        End Try
    End Sub

    Private Sub CargaDatos()
        Dim Fecha As DateTime
        Dim Proveedor As New TProveedor

        Try
            Fecha = EmpresaInfo.Getdate

            DtpFecha.Value = Fecha
            LblMonto.Text = Format(_MontoColones, "#,##0.00")

            With Proveedor
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = _Prov_Id
            End With
            VerificaMensaje(Proveedor.ListKey)

            If Proveedor.RowsAffected = 0 Then
                VerificaMensaje("No se encontró un proveedor con el código " & _Prov_Id.ToString)
            End If

            If Not Proveedor.Activo Then
                VerificaMensaje("El proveedor seleccionado se encuentra inactivo")
            End If

            TxtBeneficiario.Text = Proveedor.Nombre
            AsignaMonedaCuenta()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Proveedor = Nothing
        End Try
    End Sub

    Private Sub ComprobanteCheque(pBacoPago_Id As Long)
        Dim Pago As New TBcoPago
        Dim Reporte As New RptComprobanteCheque
        Dim FormaReporte As New FrmReporte

        Try
            Cursor = Cursors.WaitCursor

            With Pago
                .Emp_Id = EmpresaInfo.Emp_Id
                .BcoPago_Id = pBacoPago_Id
            End With
            VerificaMensaje(Pago.RptComprobanteCheque)

            If Pago.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.SetDataSource(Pago.Datos.Tables(0))
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Datos.Tables(0))

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            Pago = Nothing
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Dim SolicitudPago As TCxPSolicitudPago

        Try
            If TxtBeneficiario.Text.Trim = "" Then
                TxtBeneficiario.Focus()
                VerificaMensaje("Debe de ingresar el nombre del beneficiario")
            End If

            If CmbBanco.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar el banco del cual desea emitir el cheque")
            End If

            If CmbCuenta.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar la cuenta de la cual desea emitir el cheque")
            End If

            If TxtConcepto.Text.Trim = "" Then
                TxtConcepto.Focus()
                VerificaMensaje("Debe de ingresar un concepto al cheque")
            End If

            If _ListaCxPSolicitud.Count = 0 Then
                VerificaMensaje("Debe de seleccionar al menos una solicitud para realizar el pago")
            End If

            For Each Solicitud As TCxPSolicitudPago In _ListaCxPSolicitud
                SolicitudPago = New TCxPSolicitudPago

                With SolicitudPago
                    .Emp_Id = Solicitud.Emp_Id
                    .Solicitud_Id = Solicitud.Solicitud_Id
                End With
                VerificaMensaje(SolicitudPago.ListKey)

                If SolicitudPago.RowsAffected = 0 Then
                    VerificaMensaje("No se encontró la solicitud #" & Solicitud.Solicitud_Id.ToString)
                End If
            Next

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Aplicar()
        Dim Pago As New TBcoPago

        Try
            With Pago.Cheque
                .Nombre = TxtBeneficiario.Text.Trim
                .Fecha = DateValue(DtpFecha.Value)
            End With

            With Pago
                .Emp_Id = EmpresaInfo.Emp_Id
                .TipoPago_Id = Enum_BcoTipoPago.Cheque
                .Prov_Id = _Prov_Id
                .Banco_Id = CmbBanco.SelectedValue
                .Cuenta = CmbCuenta.Text.Trim
                .Moneda = IIf(CmbMoneda.SelectedIndex = 0, coMonedaColones, coMonedaDolares)
                .Monto = _MontoColones
                .TipoCambio = IIf(.Moneda = coMonedaColones, 1, TipoCambioBancos)
                .Dolares = IIf(.Moneda = coMonedaColones, 0, _MontoDolares)
                .Usuario_Id = UsuarioInfo.Usuario_Id
                .Concepto = TxtConcepto.Text.Trim
                .ListaSolicitudes = _ListaCxPSolicitud
            End With
            VerificaMensaje(Pago.Insert)

            _Acepto = True
            ComprobanteCheque(Pago.BcoPago_Id)
            If MsgBox("¿Desea imprimir el cheque?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Me.Text) = MsgBoxResult.Yes Then
                VerificaMensaje(ImprimePagoCheque(EmpresaInfo, Pago))
            End If
            Mensaje("El cheque se aplicó de manera exitosa")
            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Pago = Nothing
        End Try
    End Sub

    Private Sub CmbBanco_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbBanco.SelectedValueChanged
        CargaComboCuenta()
    End Sub

    Private Sub CmbCuenta_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbCuenta.SelectedValueChanged
        AsignaMonedaCuenta()
    End Sub

    Private Sub FrmPagoCheque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnfocarTexto(TxtBeneficiario)
    End Sub

    Private Sub FrmPagoCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                If ValidaTodo() Then
                    Aplicar()
                End If
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

End Class