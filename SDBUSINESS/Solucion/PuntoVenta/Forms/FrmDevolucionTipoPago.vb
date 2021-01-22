Imports Business

Public Class FrmDevolucionTipoPago
#Region "Variables"
    Private _FacturaDev As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
    Private _Guardo As Boolean = False
    Private _TipoDevolucion As Enum_TipoDevolucion
    Private _Monto As Double

#End Region
#Region "Propiedades"
    Public Property Monto() As Double
        Get
            Return _Monto
        End Get
        Set(ByVal value As Double)
            _Monto = value
        End Set
    End Property
    Public Property FacturaDev() As TFacturaEncabezado
        Get
            Return _FacturaDev
        End Get
        Set(ByVal value As TFacturaEncabezado)
            _FacturaDev = value
        End Set
    End Property
    Public ReadOnly Property Guardo As Boolean
        Get
            Return _Guardo
        End Get
    End Property
    Public ReadOnly Property TipoDevolucion As Enum_TipoDevolucion
        Get
            Return _TipoDevolucion
        End Get
    End Property
#End Region

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        _Guardo = False
        Me.Close()
    End Sub

    Private Sub FrmDevolucionTipoPago_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnAceptar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub


    Private Sub CargaPagos()
        Dim FacturaPago As New TFacturaPago(_FacturaDev.Emp_Id)
        Dim Item As ListViewItem
        Dim Items(2) As String
        Dim Total As Double = 0
        Try
            With FacturaPago
                .Suc_Id = _FacturaDev.Suc_Id
                .Caja_Id = _FacturaDev.Caja_Id
                .TipoDoc_Id = _FacturaDev.TipoDoc_Id
                .Documento_Id = _FacturaDev.Documento_Id
            End With

            VerificaMensaje(FacturaPago.List())

            For Each Pago As DataRow In FacturaPago.Data.Tables(0).Rows

                Items(0) = Pago("Pago_Id")
                Items(1) = Pago("NombreTipoPago")
                Items(2) = Format(Pago("Monto"), "#,##0.00")

                Total = Total + CDbl(Pago("Monto"))

                Item = New ListViewItem(Items)

                LvwPagos.Items.Add(Item)
            Next

            'If _Monto <> Total Then
            '    RdbPagoOriginal.Visible = False
            '    RdbPagoEfectivo.Checked = True
            'End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FacturaPago = Nothing
        End Try
    End Sub
    Public Sub Execute(Monto As Double)
        Try
            _Monto = Monto
            LblTotal.Text = Format(Monto, "#,##0.00")
            _TipoDevolucion = Enum_TipoDevolucion.Original
            _Guardo = False
            CargaPagos()

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try


            If RdbPagoEfectivo.Checked Then
                _TipoDevolucion = Enum_TipoDevolucion.Efectivo
            ElseIf RdbPagoTarjetas.Checked Then
                _TipoDevolucion = Enum_TipoDevolucion.Tarjeta
            ElseIf RdbPagoTransferencias.Checked Then
                _TipoDevolucion = Enum_TipoDevolucion.Transferencia
            Else
                _TipoDevolucion = Enum_TipoDevolucion.Original
            End If

            _Guardo = True

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class