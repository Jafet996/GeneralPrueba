Imports Business
Public Class FrmFacturasCreditoCliente
#Region "Variables"
    Private _Cliente_Id As Integer
    Private _Factura As TFacturaCxCLlave

    Private Enum ColumnasDetalle
        CajaNombre = 0
        Factura = 1
        Fecha = 2
        Monto = 3
        Saldo = 4
        TipoMov_Id = 5
        Mov_Id = 6
        Suc_Id = 7
        Caja_Id = 8
        TipoDoc_Id = 9
        Documento_Id = 10
    End Enum

#End Region
#Region "Propiedades"
    Public WriteOnly Property Cliente_Id As Integer
        Set(value As Integer)
            _Cliente_Id = value
        End Set
    End Property
    Public Property Factura As TFacturaCxCLlave
        Get
            Return _Factura
        End Get
        Set(value As TFacturaCxCLlave)
            _Factura = value
        End Set
    End Property
#End Region

    Private Sub ConfiguraDetalle()
        With LvwDetalle
            .Columns(ColumnasDetalle.CajaNombre).Text = "Caja"
            .Columns(ColumnasDetalle.CajaNombre).Width = 210
            .Columns(ColumnasDetalle.Factura).Text = "Factura"
            .Columns(ColumnasDetalle.Factura).Width = 130
            .Columns(ColumnasDetalle.Fecha).Text = "Fecha"
            .Columns(ColumnasDetalle.Fecha).Width = 90
            .Columns(ColumnasDetalle.Monto).Text = "Monto"
            .Columns(ColumnasDetalle.Monto).Width = 100
            .Columns(ColumnasDetalle.Saldo).Text = "Saldo"
            .Columns(ColumnasDetalle.Saldo).Width = 100
            .Columns(ColumnasDetalle.TipoMov_Id).Width = 0
            .Columns(ColumnasDetalle.Mov_Id).Width = 0
            .Columns(ColumnasDetalle.Suc_Id).Width = 0
            .Columns(ColumnasDetalle.Caja_Id).Width = 0
            .Columns(ColumnasDetalle.TipoDoc_Id).Width = 0
            .Columns(ColumnasDetalle.Documento_Id).Width = 0
        End With
    End Sub

    Private Sub Seleccionar()
        Try

            If LvwDetalle.SelectedItems Is Nothing OrElse LvwDetalle.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar una factura")
            End If

            _Factura = New TFacturaCxCLlave()

            With _Factura
                .Emp_Id = CajaInfo.Emp_Id
                .TipoMov_Id = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.TipoMov_Id).Text
                .Mov_Id = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Mov_Id).Text
                .Suc_Id = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Suc_Id).Text
                .Caja_Id = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Caja_Id).Text
                .TipoDoc_Id = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.TipoDoc_Id).Text
                .Documento_Id = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Documento_Id).Text
            End With

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub CargaFacturas()
        Dim CxCMovimiento As New TCxCMovimiento(EmpresaInfo.Emp_Id)
        Dim Item As ListViewItem = Nothing
        Dim Items(11) As String
        Dim Mensaje As String = ""
        Try

            LvwDetalle.Items.Clear()

            Mensaje = CxCMovimiento.FacturasPendientesCliente(CajaInfo.Suc_Id, _Cliente_Id)
            VerificaMensaje(Mensaje)

            For Each Fila As DataRow In CxCMovimiento.Data.Tables(0).Rows
                Items(ColumnasDetalle.CajaNombre) = Fila("NombreCaja")
                Items(ColumnasDetalle.Factura) = Fila("Factura")
                Items(ColumnasDetalle.Fecha) = Fila("Fecha")
                Items(ColumnasDetalle.Monto) = Format(Fila("Monto"), "#,##0.00")
                Items(ColumnasDetalle.Saldo) = Format(Fila("Saldo"), "#,##0.00")
                Items(ColumnasDetalle.TipoMov_Id) = Fila("TipoMov_Id")
                Items(ColumnasDetalle.Mov_Id) = Fila("Mov_Id")
                Items(ColumnasDetalle.Suc_Id) = Fila("Suc_Id")
                Items(ColumnasDetalle.Caja_Id) = Fila("Caja_Id")
                Items(ColumnasDetalle.TipoDoc_Id) = Fila("TipoDoc_Id")
                Items(ColumnasDetalle.Documento_Id) = Fila("Documento_Id")

                Item = New ListViewItem(Items)
                LvwDetalle.Items.Add(Item)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CxCMovimiento = Nothing
        End Try
    End Sub
    Public Sub Execute()
        Try

            _Factura = Nothing

            ConfiguraDetalle()

            CargaFacturas()

            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmFacturasCreditoCliente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                BtnSalir.PerformClick()
            Case Keys.F2
                BtnAceptar.PerformClick()
        End Select
    End Sub

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        Try

            Seleccionar()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class