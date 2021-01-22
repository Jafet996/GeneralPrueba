Imports BUSINESS
Public Class FrmMovimientoListaAplicados
#Region "Enum"
    Private Enum Enum_Columnas
        TipoNombre = 0
        Tipo_Id
        Mov_Id
        Monto
        Fecha
    End Enum
#End Region
#Region "Variables"
    Private _Tipo_Id As Integer = 0
    Private _Movimiento_Id As Long = 0
    Private _CerrarPantalla As Boolean = False
#End Region
#Region "Propiedades"
    Public WriteOnly Property Tipo_Id As Integer
        Set(value As Integer)
            _Tipo_Id = value
        End Set
    End Property
    Public WriteOnly Property Movimiento_Id As Long
        Set(value As Long)
            _Movimiento_Id = value
        End Set
    End Property
#End Region

    Public Sub Execute()
        CargaTitulo()
        ConfiguraLista()
        CargaLista()

        If Not _CerrarPantalla Then
            Me.ShowDialog()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub CargaTitulo()
        Try
            Select Case _Tipo_Id
                Case Enum_CxCMovimientoTipo.Factura, Enum_CxCMovimientoTipo.NotaDebito, Enum_CxCMovimientoTipo.NotaDebitoXIntereses
                    LblTitulo.Text = "Movimientos que afectarón al movimiento seleccionado"
                Case Enum_CxCMovimientoTipo.Recibo, Enum_CxCMovimientoTipo.NotaCredito
                    LblTitulo.Text = "Movimientos que afectó el movimiento seleccionado"
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ConfiguraLista()
        Try
            With LvwMovimientos
                .Columns(Enum_Columnas.TipoNombre).Text = "Tipo"
                .Columns(Enum_Columnas.TipoNombre).Width = 160
                .Columns(Enum_Columnas.TipoNombre).TextAlign = HorizontalAlignment.Left

                .Columns(Enum_Columnas.Tipo_Id).Text = "Tipo_Id"
                .Columns(Enum_Columnas.Tipo_Id).Width = 0
                .Columns(Enum_Columnas.Tipo_Id).TextAlign = HorizontalAlignment.Left

                .Columns(Enum_Columnas.Mov_Id).Text = "Mov #"
                .Columns(Enum_Columnas.Mov_Id).Width = 100
                .Columns(Enum_Columnas.Mov_Id).TextAlign = HorizontalAlignment.Right

                .Columns(Enum_Columnas.Monto).Text = "Monto"
                .Columns(Enum_Columnas.Monto).Width = 140
                .Columns(Enum_Columnas.Monto).TextAlign = HorizontalAlignment.Right

                .Columns(Enum_Columnas.Fecha).Text = "Fecha"
                .Columns(Enum_Columnas.Fecha).Width = 120
                .Columns(Enum_Columnas.Fecha).TextAlign = HorizontalAlignment.Right
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
            _CerrarPantalla = True
        End Try
    End Sub

    Private Sub CargaLista()
        Dim Movimiento As New TCxCMovimiento
        Dim Item As ListViewItem = Nothing
        Dim Items(4) As String

        Try
            LvwMovimientos.Items.Clear()

            If _Tipo_Id = 0 Or _Movimiento_Id = 0 Then
                VerificaMensaje("Error en el envío de número de movimiento")
            End If

            With Movimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Tipo_Id = _Tipo_Id
                .Mov_Id = _Movimiento_Id
            End With
            VerificaMensaje(Movimiento.ObtieneListaMovimientos)

            If Movimiento.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron movimientos aplicados para mostrar")
            End If

            For Each Fila As DataRow In Movimiento.Datos.Tables(0).Rows
                Items(Enum_Columnas.TipoNombre) = Fila("TipoNombre")
                Items(Enum_Columnas.Tipo_Id) = Fila("TipoAplica_Id")
                Items(Enum_Columnas.Mov_Id) = Fila("Mov_Id")
                Items(Enum_Columnas.Monto) = Format(Fila("Monto"), "#,##0.00")
                Items(Enum_Columnas.Fecha) = Format(Fila("Fecha"), "dd/MM/yyyy")

                Item = New ListViewItem(Items)
                LvwMovimientos.Items.Add(Item)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
            _CerrarPantalla = True
        Finally
            Movimiento = Nothing
        End Try
    End Sub

    Private Sub Imprimir()

        Dim Movimiento As New TCxCMovimiento
        Dim Reporte As New RptListaMovimientosAplicados
        Dim FormaReporte As New FrmReporte

        Try

            If _Tipo_Id = 0 Or _Movimiento_Id = 0 Then
                VerificaMensaje("Error en el envío de número de movimiento")
            End If

            With Movimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Tipo_Id = _Tipo_Id
                .Mov_Id = _Movimiento_Id
            End With

            VerificaMensaje(Movimiento.RptListaMovimientosAplicados)

            If Movimiento.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(Movimiento.Datos.Tables(0))
            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Datos.Tables(0))
            Reporte.SetParameterValue("pEmpresaNombre", EmpresaInfo.Nombre)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception

            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            Movimiento = Nothing
            Cursor = Cursors.Default

        End Try
    End Sub

    Private Function ValidaTodo() As Boolean

        If LvwMovimientos.Items.Count <= 0 Then
            Return False
        End If

        Return True
    End Function

    Private Sub FrmMovimientoListaAplicados_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F3
                If ValidaTodo() Then
                    Imprimir()
                End If
        End Select
    End Sub

End Class