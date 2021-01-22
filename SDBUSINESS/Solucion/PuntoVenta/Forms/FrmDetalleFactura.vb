Imports Business
Public Class FrmDetalleFactura
#Region "Enum"
    Private Enum Enum_Columnas
        ArticuloCodigo = 0
        ArticuloNombre
        Cantidad
        Precio
        Descuento
        IV
        TotalLinea
    End Enum
#End Region
#Region "Variables"
    Private _Titulo As String
    Private _Mensaje As String
    Private _Caja_Id As Integer
    Private _TipoDoc_Id As Integer
    Private _Documento_Id As Integer
#End Region
#Region "Propiedades"
    Public WriteOnly Property Titulo As String
        Set(value As String)
            _Titulo = value
        End Set
    End Property
    Public WriteOnly Property Mensaje As String
        Set(value As String)
            _Mensaje = value
        End Set
    End Property
    Public WriteOnly Property Caja_Id As Integer
        Set(value As Integer)
            _Caja_Id = value
        End Set
    End Property
    Public WriteOnly Property TipoDoc_Id As Integer
        Set(value As Integer)
            _TipoDoc_Id = value
        End Set
    End Property
    Public WriteOnly Property Documento_Id As Integer
        Set(value As Integer)
            _Documento_Id = value
        End Set
    End Property
#End Region

    Public Sub Execute()
        Me.Text = _Titulo
        Me.LblMensajeFactura.Text += _Mensaje
        AsignaLogo(PicLogo)
        ConfiguraLista()
        CargaLista()

        Me.ShowDialog()
    End Sub

    Private Sub ConfiguraLista()
        Try
            With LvwDetalle
                .Columns(Enum_Columnas.ArticuloCodigo).Text = "Código"
                .Columns(Enum_Columnas.ArticuloCodigo).Width = 100

                .Columns(Enum_Columnas.ArticuloNombre).Text = "Descripción"
                .Columns(Enum_Columnas.ArticuloNombre).Width = 300

                .Columns(Enum_Columnas.Cantidad).Text = "Cantidad"
                .Columns(Enum_Columnas.Cantidad).Width = 55

                .Columns(Enum_Columnas.Precio).Text = "Precio"
                .Columns(Enum_Columnas.Precio).Width = 100
                .Columns(Enum_Columnas.Precio).TextAlign = HorizontalAlignment.Right

                .Columns(Enum_Columnas.Descuento).Text = "Descuento"
                .Columns(Enum_Columnas.Descuento).Width = 100
                .Columns(Enum_Columnas.Descuento).TextAlign = HorizontalAlignment.Right

                .Columns(Enum_Columnas.IV).Text = "IV"
                .Columns(Enum_Columnas.IV).Width = 100
                .Columns(Enum_Columnas.IV).TextAlign = HorizontalAlignment.Right

                .Columns(Enum_Columnas.TotalLinea).Text = "Total"
                .Columns(Enum_Columnas.TotalLinea).Width = 100
                .Columns(Enum_Columnas.TotalLinea).TextAlign = HorizontalAlignment.Right
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaLista()
        Dim FacturaEncabezado As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim FacturaDetalle As New TFacturaDetalle(EmpresaInfo.Emp_Id)
        Dim Item As ListViewItem = Nothing
        Dim Items(6) As String

        Try
            LvwDetalle.Items.Clear()

            With FacturaDetalle
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
                .Caja_Id = _Caja_Id
                .TipoDoc_Id = _TipoDoc_Id
                .Documento_Id = _Documento_Id
            End With
            VerificaMensaje(FacturaDetalle.ConsultaDetalleFactura)

            If FacturaDetalle.RowsAffected = 0 Then
                VerificaMensaje("No se encontró el detalle de la factura seleccionada")
            End If

            For Each Fila As DataRow In FacturaDetalle.Data.Tables(0).Rows
                Items(0) = Fila("Art_Id")
                Items(1) = Fila("Nombre")
                Items(2) = Fila("Cantidad")
                Items(3) = Format(Fila("PrecioUnitario"), "#,##0.00")
                Items(4) = Format(Fila("Descuento"), "#,##0.00")
                Items(5) = Format(Fila("IV"), "#,##0.00")
                Items(6) = Format(Fila("PrecioTotal"), "#,##0.00")

                Item = New ListViewItem(Items)
                LvwDetalle.Items.Add(Item)
            Next

            With FacturaEncabezado
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
                .Caja_Id = _Caja_Id
                .TipoDoc_Id = _TipoDoc_Id
                .Documento_Id = _Documento_Id
            End With
            VerificaMensaje(FacturaEncabezado.ListKey)

            'If FacturaEncabezado.Copago > 0 Then
            '    Items(0) = EmpresaParametroInfo.CodigoCopago
            '    Items(1) = "COPAGO"
            '    Items(2) = "1"
            '    Items(3) = Format(FacturaEncabezado.Copago * -1, "#,##0.00")
            '    Items(4) = "0.00"
            '    Items(5) = "0.00"
            '    Items(6) = Format(FacturaEncabezado.Copago * -1, "#,##0.00")

            '    Dim CoPago As New ListViewItem(Items)
            '    LvwDetalle.Items.Add(CoPago)
            'End If

            'If FacturaEncabezado.Coaseguro > 0 Then
            '    Items(0) = EmpresaParametroInfo.CodigoCoaseguro
            '    Items(1) = "COASEGURO"
            '    Items(2) = "1"
            '    Items(3) = Format(FacturaEncabezado.Coaseguro * -1, "#,##0.00")
            '    Items(4) = "0.00"
            '    Items(5) = "0.00"
            '    Items(6) = Format(FacturaEncabezado.Coaseguro * -1, "#,##0.00")

            '    Dim Coaseguro As New ListViewItem(Items)
            '    LvwDetalle.Items.Add(Coaseguro)
            'End If

            'If FacturaEncabezado.Deducible > 0 Then
            '    Items(0) = EmpresaParametroInfo.CodigoDeducible
            '    Items(1) = "DEDUCIBLE"
            '    Items(2) = "1"
            '    Items(3) = Format(FacturaEncabezado.Deducible * -1, "#,##0.00")
            '    Items(4) = "0.00"
            '    Items(5) = "0.00"
            '    Items(6) = Format(FacturaEncabezado.Deducible * -1, "#,##0.00")

            '    Dim Deducible As New ListViewItem(Items)
            '    LvwDetalle.Items.Add(Deducible)
            'End If

            'If FacturaEncabezado.Excedente > 0 Then
            '    Items(0) = EmpresaParametroInfo.CodigoExcedente
            '    Items(1) = "EXCEDENTE"
            '    Items(2) = "1"
            '    Items(3) = Format(FacturaEncabezado.Excedente * -1, "#,##0.00")
            '    Items(4) = "0.00"
            '    Items(5) = "0.00"
            '    Items(6) = Format(FacturaEncabezado.Excedente * -1, "#,##0.00")

            '    Dim Excedente As New ListViewItem(Items)
            '    LvwDetalle.Items.Add(Excedente)
            'End If

            CalculaTotal()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FacturaEncabezado = Nothing
            FacturaDetalle = Nothing
        End Try
    End Sub

    Private Sub CalculaTotal()
        Dim Monto As Double = 0.0

        Try
            For Each Item As ListViewItem In LvwDetalle.Items
                Monto += CDbl(Item.SubItems(6).Text)
            Next

            LblTotal.Text = Format(Monto, "#,##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmDetalleFactura_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

End Class