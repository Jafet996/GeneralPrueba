Imports BUSINESS

Public Class FrmAsignaFacturaVendedor

    Private _detallesLista As List(Of TCxCEntregaDocumentoDetalle)
    Private _primerCarga As Boolean = True
    Public Property DetallesLista() As List(Of TCxCEntregaDocumentoDetalle)
        Get
            Return _detallesLista
        End Get
        Set(ByVal value As List(Of TCxCEntregaDocumentoDetalle))
            _detallesLista = value
        End Set
    End Property

    Public Property PrimerCarga As Boolean
        Get
            Return _primerCarga
        End Get
        Set(value As Boolean)
            _primerCarga = value
        End Set
    End Property

    Dim EncabezadoEntregaDocumento As New TCxCEntregaDocumentoEncabezado()

    Private Enum ColumnasDetalle
        TipoNombre
        Mov_Id
        Tipo_Id
        Cliente_Id
        Referencia
        Cliente
        Vence
        Monto
        Saldo

    End Enum

    Dim Encabezado As New TCxCEntregaDocumentoEncabezado()


    Public Sub Execute()

        ConfiguraLista()
        CargarCombos()
        CbVendedores.DropDownStyle = ComboBoxStyle.DropDownList
        PrimerCarga = False
        CargarDatosLista()
        Me.ShowDialog()

    End Sub


    Private Sub CargaFacturarAsignadas()

    End Sub

    Private Sub CargarCombos()

        Dim Vendedor As New TVendedor()

        Try
            Vendedor.Emp_Id = EmpresaInfo.Emp_Id
            Vendedor.LoadComboBox(CbVendedores)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try


    End Sub

    Private Sub CargaLista()
        Dim Items(8) As String
        Dim Item As ListViewItem = Nothing

        Dim detalleEntregaDocumento As New TCxCEntregaDocumentoDetalle()

        Try
            LvwMovimientos.Items.Clear()

            With EncabezadoEntregaDocumento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Vendedor_Id = CbVendedores.SelectedValue()
            End With

            EncabezadoEntregaDocumento.RptConsultaFacturasAsignadasDiario()
            DetallesLista = New List(Of TCxCEntregaDocumentoDetalle)()

            For Each fila As DataRow In EncabezadoEntregaDocumento.Datos.Tables(0).Rows
                Items(ColumnasDetalle.TipoNombre) = fila("TipoNombre")
                Items(ColumnasDetalle.Mov_Id) = fila("Mov_Id")
                Items(ColumnasDetalle.Tipo_Id) = fila("Tipo_Id")
                Items(ColumnasDetalle.Cliente_Id) = fila("Cliente_Id")
                Items(ColumnasDetalle.Referencia) = fila("Referencia")
                Items(ColumnasDetalle.Cliente) = fila("Cliente")
                Items(ColumnasDetalle.Vence) = Format(fila("FechaVencimiento"), "dd/MM/yyyy")
                Items(ColumnasDetalle.Monto) = Format(fila("Monto"), "#,##0.00")
                Items(ColumnasDetalle.Saldo) = Format(fila("Saldo"), "#,##0.00")
                Item = New ListViewItem(Items)
                LvwMovimientos.Items.Add(Item)
            Next


        Catch ex As Exception
            MensajeError(ex.Message)
            Me.Close()
        Finally
        End Try
    End Sub

    Private Sub ConfiguraLista()
        Try
            With LvwMovimientos
                .Columns(ColumnasDetalle.Mov_Id).Text = "Documento"
                .Columns(ColumnasDetalle.Mov_Id).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Mov_Id).Width = 75

                .Columns(ColumnasDetalle.Tipo_Id).Text = ""
                .Columns(ColumnasDetalle.Tipo_Id).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Tipo_Id).Width = 0

                .Columns(ColumnasDetalle.Cliente_Id).Text = ""
                .Columns(ColumnasDetalle.Cliente_Id).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Cliente_Id).Width = 0

                .Columns(ColumnasDetalle.TipoNombre).Text = "Tipo"
                .Columns(ColumnasDetalle.TipoNombre).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.TipoNombre).Width = 120

                .Columns(ColumnasDetalle.Referencia).Text = "Referencia"
                .Columns(ColumnasDetalle.Referencia).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Referencia).Width = 300

                .Columns(ColumnasDetalle.Cliente).Text = "Cliente"
                .Columns(ColumnasDetalle.Cliente).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Cliente).Width = 150

                .Columns(ColumnasDetalle.Vence).Text = "Vence"
                .Columns(ColumnasDetalle.Vence).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalle.Vence).Width = 80

                .Columns(ColumnasDetalle.Monto).Text = "Monto"
                .Columns(ColumnasDetalle.Monto).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Monto).Width = 120

                .Columns(ColumnasDetalle.Saldo).Text = "Saldo"
                .Columns(ColumnasDetalle.Saldo).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Saldo).Width = 120
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub EliminarElemento()

    End Sub

    Private Sub actualizarVendedor()

        With Encabezado
            .Emp_Id = EmpresaInfo.Emp_Id
            .ListKey()
            .Vendedor_Id = CbVendedores.SelectedValue()
            .Modify()
        End With

    End Sub

    Private Sub MuestraReporte()
        Dim Reporte As New RptCxCAsignarFacturasVendedores
        Dim FormaReporte As New FrmReporte


        Try
            Cursor = Cursors.WaitCursor

            With Encabezado
                .Emp_Id = EmpresaInfo.Emp_Id
                .Entrega_Id = DetallesLista(0).Entrega_Id
            End With
            VerificaMensaje(Encabezado.RptConsultaFacturasAsignadas())

            If Encabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.SetDataSource(Encabezado.Datos.Tables(0))
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Datos.Tables(0))
            Reporte.SetParameterValue("pEmpresa", EmpresaInfo.Nombre)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Imprimir()
        If ValidaTodo() Then
            'actualizarVendedor()
            MuestraReporte()
        End If

    End Sub

    Private Function ValidaTodo() As Boolean
        If LvwMovimientos.Items.Count > 0 Then
            Return True
        End If
        MensajeError("Debe Seleccionar al menos un documento para asignar al vendedor")

        Return False
    End Function

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs)
        Imprimir()
    End Sub

    Private Sub BntImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click

        If ValidaTodo() Then
            Imprimir()
        End If
    End Sub


    Private Sub BntSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmAsignaFacturaVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            BtnImprimir.PerformClick()
        ElseIf e.KeyCode = Keys.F1 Then
            BtnBuscar.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            BtnSalir.PerformClick()
        End If
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Dim forma As New FrmBusquedaFactura()

        Try
            forma.DetallesEntregaDocumento = DetallesLista
            If LvwMovimientos.Items.Count = 0 Then

                forma._Nuevo = True
                forma._Vendedor_id = CbVendedores.SelectedValue
            End If

            forma.Execute()

            If forma._CerrarPantalla Then
                CargarDatosLista()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EliminarCms_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CargarDatosLista()
        If Not PrimerCarga Then
            LvwMovimientos.Items.Clear()
            CargaLista()
            DetallesLista = EncabezadoEntregaDocumento.RptConsultaFacturasAsignadasDiarioCargaLista(DetallesLista)
        End If
    End Sub

    Private Sub CbVendedores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbVendedores.SelectedIndexChanged
        CargarDatosLista()
    End Sub
End Class