Imports Business
Public Class FrmArticuloBodegas
    Dim Numerico() As TNumericFormat
    Dim _Cargando As Boolean = False
    Dim _Art_Id As String
    Dim _Activado As Boolean
    Dim _PrecioAnterior As Double = 0
    Dim _FacturaDetalleImpuestos As New List(Of TFacturaDetalleImpuesto)
    Dim InfoArticulo As New TInfoArticulo(EmpresaInfo.Emp_Id)

    Private Enum ColumnasAnotaciones
        Id = 0
        Anotacion = 1
        Fecha = 2
        Usuario = 3
    End Enum

    Public WriteOnly Property Art_Id As String
        Set(value As String)
            _Art_Id = value
        End Set
    End Property

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(12)

            Numerico(0) = New TNumericFormat(TxtMargen, 8, 2, False, "0", "#,##0.00")
            Numerico(1) = New TNumericFormat(TxtPrecioVenta, 12, 4, False, "0", "#,##0.00")
            Numerico(2) = New TNumericFormat(TxtPorcDescuento, 3, 2, False, "0", "#,##0.00")
            Numerico(3) = New TNumericFormat(TxtMinimo, 5, 2, False, "0", "#,##0.00")
            Numerico(4) = New TNumericFormat(TxtMaximo, 5, 2, False, "0", "#,##0.00")
            Numerico(5) = New TNumericFormat(TxtMargenMayorista, 8, 2, False, "0", "#,##0.00")
            Numerico(6) = New TNumericFormat(TxtPrecioVentaMayorista, 12, 4, False, "0", "#,##0.00")
            Numerico(7) = New TNumericFormat(TxtMargen3, 8, 2, False, "0", "#,##0.00")
            Numerico(8) = New TNumericFormat(TxtPrecioVenta3, 12, 4, False, "0", "#,##0.00")
            Numerico(9) = New TNumericFormat(TxtMargen4, 8, 2, False, "0", "#,##0.00")
            Numerico(10) = New TNumericFormat(TxtPrecioVenta4, 12, 4, False, "0", "#,##0.00")
            Numerico(11) = New TNumericFormat(TxtMargen5, 8, 2, False, "0", "#,##0.00")
            Numerico(12) = New TNumericFormat(TxtPrecioVenta5, 12, 4, False, "0", "#,##0.00")
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub ConfiguraListas()
        With LvwAnotaciones
            .Columns(ColumnasAnotaciones.Id).Text = "Id"
            .Columns(ColumnasAnotaciones.Id).Width = 38

            .Columns(ColumnasAnotaciones.Anotacion).Text = "Anotación"
            .Columns(ColumnasAnotaciones.Anotacion).Width = 313

            .Columns(ColumnasAnotaciones.Fecha).Text = "Fecha"
            .Columns(ColumnasAnotaciones.Fecha).Width = 76

            .Columns(ColumnasAnotaciones.Usuario).Text = "Hecho Por"
            .Columns(ColumnasAnotaciones.Usuario).Width = 0
        End With
    End Sub
    Private Sub CargaCombos()
        Dim Sucursal As New TSucursal(EmpresaInfo.Emp_Id)

        Try
            VerificaMensaje(Sucursal.LoadComboBox(CmbSucursal))

            GroupSucursal.Enabled = True
            CmbSucursal.Focus()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Sucursal = Nothing
        End Try
    End Sub

    Private Sub Inicializa()
        TxtCodigo.Enabled = True
        TxtCodigo.Text = ""
        LblNombreArticulo.Text = ""
        LblExento.Text = ""
        CmbSucursal.SelectedIndex = -1
        GroupSucursal.Enabled = False
        GbPrecioMayoreo.Enabled = False
        GbPrecioDetallista.Enabled = False
        GbPrecio3.Enabled = False
        GbPrecio4.Enabled = False
        GbPrecio5.Enabled = False
        GroupCosto.Enabled = False
        GroupDescuento.Enabled = False
        GroupGeneral.Enabled = False
        BtnGuardar.Enabled = False
        BtnLimpiar.Enabled = False
        BtnAnotacionAgregar.Enabled = False
        BtnAnotacionEliminar.Enabled = False
        LvwAnotaciones.Items.Clear()
        ChkTodas.Checked = False
        LimpiaInformacionBodega()
    End Sub

    Public Sub Execute()
        Try
            _Activado = False
            _Cargando = True
            LblSucursal.Text = SucursalInfo.Nombre
            CargaCombos()
            ConfiguraListas()
            Inicializa()
            _Cargando = False

            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCodigo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigo.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Dim Forma As New FrmBuscaArticuloOnLine

                Forma.Execute()
                If Forma.Art_Id.Trim <> "" Then
                    TxtCodigo.Text = Forma.Art_Id.Trim

                    CargaArticulo()
                End If
                Forma = Nothing
            Case Keys.Enter
                If TxtCodigo.Text.Trim <> "" Then
                    CargaArticulo()
                End If
        End Select
    End Sub

    Private Sub TxtCodigo_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCodigo.TextChanged
        LblNombreArticulo.Text = ""
    End Sub

    Private Sub FrmArticuloBodega_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If Not _Activado Then
            _Activado = True
            If _Art_Id <> "" Then
                TxtCodigo.Text = _Art_Id
                CargaArticulo()
            End If
        End If
    End Sub

    Private Sub FrmArticuloBodega_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FormateaCamposNumericos()
        TxtCodigo.Select()
    End Sub

    Private Sub CargaArticulo()
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)

        Try
            Articulo.Art_Id = TxtCodigo.Text.Trim
            VerificaMensaje(Articulo.ListKey())

            If Articulo.RowsAffected = 0 Then
                MsgBox("El código de artículo no existe", MsgBoxStyle.Information)
                TxtCodigo.SelectAll()
                TxtCodigo.Focus()
                Exit Sub
            End If

            TxtCodigo.Enabled = False
            LblNombreArticulo.Text = Articulo.Nombre
            LblExento.Text = IIf(Articulo.ExentoIV, "Si", "No")
            LblExento.Tag = Articulo.ExentoIV

            If CmbSucursal.Items.Count > 0 Then
                CmbSucursal.SelectedIndex = 0
            End If

            CargaImpuestos(_Art_Id)
            CargaListaAnotaciones(Articulo.Art_Id)
            BtnAnotacionAgregar.Enabled = True
            GroupSucursal.Enabled = True
            BtnGuardar.Enabled = True
            BtnLimpiar.Enabled = True
            TxtPrecioVenta.Focus()
            TxtPrecioVenta.SelectAll()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Articulo = Nothing
        End Try
    End Sub
    Private Sub CargaImpuestos(pArt_Id As String)
        Dim Mensaje As String = ""
        Dim Item As ListViewItem = Nothing
        Dim Items(4) As String
        Try

            InfoArticulo.Art_Id = pArt_Id
            Mensaje = InfoArticulo.ConsultaArticuloImpuestos
            VerificaMensaje(Mensaje)

            If InfoArticulo.RowsAffected = 0 Then
                Exit Sub
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub MarcarNodos(pNodo As TreeNode, pSuc_Id As Integer, pBod_Id As Integer)
        If pNodo.Nodes.Count = 0 Then
            If pNodo.ImageIndex = 2 And pNodo.Tag = pBod_Id And pNodo.Parent.Tag = pSuc_Id Then
                'pNodo.NodeFont = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                pNodo.ForeColor = Color.Blue
            End If
        Else
            For Each Nodo As TreeNode In pNodo.Nodes
                MarcarNodos(Nodo, pSuc_Id, pBod_Id)
            Next
        End If
    End Sub

    Private Sub BtnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpiar.Click
        Inicializa()
        TxtCodigo.Focus()
    End Sub

    Private Sub LimpiaInformacionBodega()
        _PrecioAnterior = 0
        TxtCosto.Text = ""
        TxtMargen.Text = ""
        TxtMargenMayorista.Text = ""
        TxtPrecio.Text = ""
        TxtPrecioMayorista.Text = ""
        TxtPrecio3.Text = ""
        TxtPrecio4.Text = ""
        TxtPrecio5.Text = ""
        TxtPrecioVenta.Text = ""
        TxtPrecioVentaMayorista.Text = ""
        TxtPrecioVenta3.Text = ""
        TxtPrecioVenta4.Text = ""
        TxtPrecioVenta5.Text = ""
        DtpDescuentoIni.Value = #1/1/1900#
        DtpDescuentoFin.Value = #1/1/1900#
        TxtPorcDescuento.Text = ""
        TxtUbicacion.Text = ""
    End Sub

    Private Sub CmbBodega_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbSucursal.SelectedIndexChanged
        Try
            LimpiaInformacionBodega()

            If _Cargando OrElse CmbSucursal.SelectedValue Is Nothing Then
                Exit Sub
            End If
            CargaInformacionBodega()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub CargaInformacionBodega()
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Try
            With ArticuloBodega
                .Suc_Id = CmbSucursal.SelectedValue
                .Art_Id = TxtCodigo.Text.Trim
            End With
            VerificaMensaje(ArticuloBodega.ListKeySucursal)

            CargaImpuestos(_Art_Id)

            If ArticuloBodega.RowsAffected = 0 Then
                LimpiaInformacionBodega()
                GbPrecioMayoreo.Enabled = False
                GbPrecioDetallista.Enabled = False
                GbPrecio3.Enabled = False
                GbPrecio4.Enabled = False
                GbPrecio5.Enabled = False
                GroupCosto.Enabled = False
                GroupDescuento.Enabled = False
                GroupGeneral.Enabled = False
                Exit Sub
            Else
                GbPrecioMayoreo.Enabled = True
                GbPrecioDetallista.Enabled = True
                GbPrecio3.Enabled = True
                GbPrecio4.Enabled = True
                GbPrecio5.Enabled = True
                GroupCosto.Enabled = True
                GroupDescuento.Enabled = True
                GroupGeneral.Enabled = True
            End If
            With ArticuloBodega
                TxtCosto.Text = Format(.Costo, "#,##0.00")
                TxtCosto.Tag = "p"
                TxtMargen.Text = Format(.Margen, "#,##0.00")
                TxtCosto.Tag = "p"
                TxtMargenMayorista.Text = Format(.MargenMayorista, "#,##0.00")
                TxtPrecio.Text = Format(.Precio, "#,##0.0000")
                _PrecioAnterior = .Precio
                TxtPrecioMayorista.Text = Format(.PrecioMayorista, "#,##0.0000")
                TxtPrecio3.Text = Format(.Precio3, "#,##0.0000")
                TxtPrecio4.Text = Format(.Precio4, "#,##0.0000")
                TxtPrecio5.Text = Format(.Precio5, "#,##0.0000")
                If LCase(LblExento.Text) = "si" Then
                    TxtPrecioVenta.Text = Format(.Precio, "#,##0.0000")
                    TxtPrecioVentaMayorista.Text = Format(.PrecioMayorista, "#,##0.0000")
                    TxtPrecioVenta3.Text = Format(.Precio3, "#,##0.0000")
                    TxtPrecioVenta4.Text = Format(.Precio4, "#,##0.0000")
                    TxtPrecioVenta5.Text = Format(.Precio5, "#,##0.0000")
                Else
                    TxtPrecioVenta.Text = Format(CDbl(.Precio) + CalculaMontoImpuesto(.Precio, InfoArticulo.ArticuloImpuestos), "##0.0000")
                    TxtPrecioVentaMayorista.Text = Format(CDbl(.PrecioMayorista) + CalculaMontoImpuesto(.PrecioMayorista, InfoArticulo.ArticuloImpuestos), "##0.0000")
                    TxtPrecioVenta3.Text = Format(CDbl(.Precio3) + CalculaMontoImpuesto(.Precio3, InfoArticulo.ArticuloImpuestos), "##0.0000")
                    TxtPrecioVenta4.Text = Format(CDbl(.Precio4) + CalculaMontoImpuesto(.Precio4, InfoArticulo.ArticuloImpuestos), "##0.0000")
                    TxtPrecioVenta5.Text = Format(CDbl(.Precio5) + CalculaMontoImpuesto(.Precio5, InfoArticulo.ArticuloImpuestos), "##0.0000")
                End If
                TxtCosto.Tag = ""
                DtpDescuentoIni.Value = DateValue(.FechaIniDescuento)
                DtpDescuentoFin.Value = DateValue(.FechaFinDescuento)
                TxtPorcDescuento.Text = Format(.PorcDescuento, "#,##0.00")
                TxtMinimo.Text = Format(.Minimo, "#,##0.00")
                TxtMaximo.Text = Format(.Maximo, "#,##0.00")
                TxtUbicacion.Text = .Ubicacion
                ChkActivo.Checked = .Activo
                ChkTodas.Checked = True
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtPrecioVenta_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtPrecioVenta.TextChanged
        Dim Costo As Double = 0
        Dim Precio As Double = 0
        Dim PrecioVenta As Double = 0
        'Dim Articulo As TArticulo

        Try
            If Not GbPrecioDetallista.Enabled Then
                Exit Sub
            End If

            If TxtCosto.Tag <> "" Then
                Exit Sub
            End If

            TxtCosto.Tag = "p"

            If Not IsNumeric(TxtCosto.Text) Then
                Costo = 0
            Else
                Costo = CDbl(TxtCosto.Text)
            End If

            If Not IsNumeric(TxtPrecioVenta.Text) Then
                PrecioVenta = 0
            Else
                PrecioVenta = CDbl(TxtPrecioVenta.Text)
            End If

            'Calcula el monto del precio sin impuesto de venta
            If LCase(LblExento.Text) = "si" Then
                TxtPrecio.Text = Format(PrecioVenta, "#,##0.0000")
            Else
                TxtPrecio.Text = Format(PrecioVenta - RestaMontoImpuesto(PrecioVenta, InfoArticulo.ArticuloImpuestos), "#,##0.0000")

            End If

            If Not IsNumeric(TxtPrecio.Text) Then
                Precio = 0
            Else
                Precio = CDbl(TxtPrecio.Text)
            End If

            'Calcula el margen de ganancia
            TxtMargen.Text = Format(CalculaMargen(Costo, Precio), "##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TxtCosto.Tag = ""
        End Try
    End Sub

    Private Function CalculaPrecio(pCosto As Double, pMargen As Double) As Double
        Dim Precio As Double = 0

        Try
            If pMargen <= 0 Then
                Precio = pCosto
            Else
                Precio = (pCosto * ((pMargen / 100) + 1))
            End If

            Return Precio
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Function CalculaMargen(pCosto As Double, pPrecio As Double) As Double
        Dim Diferencia As Double = 0
        Dim Margen As Double = 0

        Try
            If pCosto = 0 Then
                Margen = 100
            Else
                Diferencia = pPrecio - pCosto
                Margen = (Diferencia * 100) / pCosto
            End If

            Return Margen
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub TxtMargen_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtMargen.TextChanged
        Dim Costo As Double = 0
        Dim Margen As Double = 0

        Try
            If Not GbPrecioDetallista.Enabled Then
                Exit Sub
            End If

            If TxtCosto.Tag <> "" Then
                Exit Sub
            End If

            TxtCosto.Tag = "m"

            If Not IsNumeric(TxtCosto.Text) Then
                Costo = 0
            Else
                Costo = CDbl(TxtCosto.Text)
            End If

            If Not IsNumeric(TxtMargen.Text) Then
                Margen = 0
            Else
                Margen = CDbl(TxtMargen.Text)
            End If

            TxtPrecio.Text = Format(CalculaPrecio(Costo, Margen), "##0.0000")

            If LCase(LblExento.Text) = "si" Then
                TxtPrecioVenta.Text = TxtPrecio.Text
            Else
                TxtPrecioVenta.Text = Format(CDbl(TxtPrecio.Text) + CalculaMontoImpuesto(TxtPrecio.Text, InfoArticulo.ArticuloImpuestos), "##0.0000")
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TxtCosto.Tag = ""
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If Not IsNumeric(TxtMargen.Text) OrElse CDbl(TxtMargen.Text) < 0 Then
                TxtMargen.SelectAll()
                TxtMargen.Focus()
                VerificaMensaje("El margen de utilidad debe de ser mayor o igual a cero")
            End If

            If Not IsNumeric(TxtPrecio.Text) OrElse CDbl(TxtPrecio.Text) < 0 Then
                TxtPrecio.SelectAll()
                TxtPrecio.Focus()
                VerificaMensaje("El precio debe de ser mayor o igual a cero")
            End If

            If Not IsNumeric(TxtPrecioVenta.Text) OrElse CDbl(TxtPrecioVenta.Text) < 0 Then
                TxtPrecioVenta.SelectAll()
                TxtPrecioVenta.Focus()
                VerificaMensaje("El precio debe de ser mayor o igual a cero")
            End If


            If Not IsNumeric(TxtPrecioMayorista.Text) OrElse CDbl(TxtPrecioMayorista.Text) < 0 Then
                TxtPrecioMayorista.SelectAll()
                TxtPrecioMayorista.Focus()
                VerificaMensaje("El precio debe de ser mayor o igual a cero")
            End If

            If Not IsNumeric(TxtPrecioVentaMayorista.Text) OrElse CDbl(TxtPrecioVentaMayorista.Text) < 0 Then
                TxtPrecioVentaMayorista.SelectAll()
                TxtPrecioVentaMayorista.Focus()
                VerificaMensaje("El precio debe de ser mayor o igual a cero")
            End If

            If CDbl(TxtPrecio.Text) < CDbl(TxtCosto.Text) Then
                TxtPrecio.SelectAll()
                TxtPrecio.Focus()
                VerificaMensaje("El precio debe de ser mayor o igual al costo")
            End If

            If CDbl(TxtPrecioMayorista.Text) < CDbl(TxtCosto.Text) Then
                TxtPrecioMayorista.SelectAll()
                TxtPrecioMayorista.Focus()
                VerificaMensaje("El precio debe de ser mayor o igual al costo")
            End If

            If DateValue(DtpDescuentoIni.Value) > DateValue(DtpDescuentoFin.Value) Then
                DtpDescuentoFin.Focus()
                VerificaMensaje("La fecha final de descuento no puede ser menor a la de inicio")
            End If

            If Not IsNumeric(TxtPorcDescuento.Text) OrElse CDbl(TxtPorcDescuento.Text) < 0 Then
                TxtPorcDescuento.SelectAll()
                TxtPorcDescuento.Focus()
                VerificaMensaje("El porcentaje de descuento debe de ser mayor o igual a cero")
            End If

            If CDbl(TxtPorcDescuento.Text) > 100 Then
                TxtPorcDescuento.SelectAll()
                TxtPorcDescuento.Focus()
                VerificaMensaje("El porcentaje de descuento no puede ser mayor al 100 %")
            End If


            If Not IsNumeric(TxtMinimo.Text) OrElse CDbl(TxtMinimo.Text) < 0 Then
                TxtMinimo.SelectAll()
                TxtMinimo.Focus()
                VerificaMensaje("El mínimo de existencia debe de ser mayor o igual a cero")
            End If

            If Not IsNumeric(TxtMaximo.Text) OrElse CDbl(TxtMaximo.Text) < 0 Then
                TxtMaximo.SelectAll()
                TxtMaximo.Focus()
                VerificaMensaje("El máximo de existencia debe de ser mayor o igual a cero")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function
    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        Try
            If ValidaTodo() Then
                If VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.InvGuardaArticuloBodega, True) Then
                    Guardar()
                End If
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Guardar()
        Dim ArticuloBodega As New TArticuloBodega(SucursalInfo.Emp_Id)
        Dim ArticuloB As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Sucursal As New TSucursal(SucursalInfo.Emp_Id)
        Dim PrecioNuevo As Double
        Dim Precio As Double = TxtPrecio.Text
        Dim Art_Id As String = ""

        Try
            PrecioNuevo = CDbl(TxtPrecioVenta.Text)
            Art_Id = TxtCodigo.Text.Trim
            With ArticuloBodega
                .Margen = CDbl(TxtMargen.Text)
                .MargenMayorista = CDbl(TxtMargenMayorista.Text)
                .Margen3 = CDbl(TxtMargen3.Text)
                .Margen4 = CDbl(TxtMargen4.Text)
                .Margen5 = CDbl(TxtMargen5.Text)
                .Precio = CDbl(TxtPrecio.Text)
                .PrecioMayorista = CDbl(TxtPrecioMayorista.Text)
                .Precio3 = CDbl(TxtPrecio3.Text.Trim)
                .Precio4 = CDbl(TxtPrecio4.Text.Trim)
                .Precio5 = CDbl(TxtPrecio5.Text.Trim)
                .FechaIniDescuento = DateValue(DtpDescuentoIni.Value)
                .FechaFinDescuento = DateValue(DtpDescuentoFin.Value)
                .PorcDescuento = CDbl(TxtPorcDescuento.Text)
                .Minimo = CDbl(TxtMinimo.Text)
                .Maximo = CDbl(TxtMaximo.Text)
                .Ubicacion = TxtUbicacion.Text.Trim
                .Activo = ChkActivo.Checked
            End With

            With ArticuloBodega
                .Suc_Id = CmbSucursal.SelectedValue
                .Art_Id = TxtCodigo.Text.Trim
            End With
            If _PrecioAnterior <> PrecioNuevo Then
                If Not Precio <= 0 Then
                End If
                VerificaMensaje(ArticuloBodega.AddrticuloCambioPrecio(_PrecioAnterior, PrecioNuevo, Art_Id))
            End If
            If ChkTodas.Checked Then
                With ArticuloBodega
                    .Art_Id = TxtCodigo.Text.Trim
                End With
                VerificaMensaje(ArticuloBodega.ModificaBodegasEmpresa)
            Else
                With ArticuloBodega
                    .Emp_Id = SucursalInfo.Emp_Id
                    .Suc_Id = CmbSucursal.SelectedValue
                    .Art_Id = TxtCodigo.Text.Trim
                End With
                VerificaMensaje(ArticuloBodega.ModificaBodegasSucursal)
            End If
            'If PrecioAnterior <> PrecioNuevo Then
            '    If ChkTodas.Checked Then
            '        Todos = True
            '    Else
            '        Todos = False
            '    End If
            'End If
            ActualizaPrecioPrefacturas()
            Inicializa()
            TxtCodigo.Focus()
            If _Art_Id <> String.Empty Then
                Me.Close()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloBodega = Nothing
        End Try
    End Sub

    Private Sub ActualizaPrecioPrefacturas()
        Dim Suc As New TSucursal(EmpresaInfo.Emp_Id)
        Dim Bod As New TBodega(EmpresaInfo.Emp_Id)
        Try

            If ChkTodas.Checked Then
                VerificaMensaje(Suc.List)

                For Each filaSuc As DataRow In Suc.Data.Tables(0).Rows

                    Bod.Suc_Id = filaSuc("Suc_Id")
                    VerificaMensaje(Bod.List)

                    For Each filaBod As DataRow In Bod.Data.Tables(0).Rows
                        Bod.Bod_Id = filaBod("Bod_Id")

                        If ChkAplicaPrecio.Checked Then
                            VerificaMensaje(Bod.ActualizaPrecioArticuloProforma(TxtCodigo.Text, Enum_ClientPrecio.Detalle))
                        End If

                        If ChkAplicaMayorista.Checked Then
                            VerificaMensaje(Bod.ActualizaPrecioArticuloProforma(TxtCodigo.Text, Enum_ClientPrecio.Mayoreo))
                        End If

                        If ChkAplicaPrecio3.Checked Then
                            VerificaMensaje(Bod.ActualizaPrecioArticuloProforma(TxtCodigo.Text, Enum_ClientPrecio.Precio3))
                        End If

                        If ChkAplicaPrecio4.Checked Then
                            VerificaMensaje(Bod.ActualizaPrecioArticuloProforma(TxtCodigo.Text, Enum_ClientPrecio.Precio4))
                        End If

                        If ChkAplicaPrecio5.Checked Then
                            VerificaMensaje(Bod.ActualizaPrecioArticuloProforma(TxtCodigo.Text, Enum_ClientPrecio.Precio5))
                        End If
                    Next
                Next
            Else

                Bod.Suc_Id = CmbSucursal.SelectedValue
                VerificaMensaje(Bod.List)

                For Each filaBod As DataRow In Bod.Data.Tables(0).Rows
                    Bod.Bod_Id = filaBod("Bod_Id")

                    If ChkAplicaPrecio.Checked Then
                        VerificaMensaje(Bod.ActualizaPrecioArticuloProforma(TxtCodigo.Text, Enum_ClientPrecio.Detalle))
                    End If

                    If ChkAplicaMayorista.Checked Then
                        VerificaMensaje(Bod.ActualizaPrecioArticuloProforma(TxtCodigo.Text, Enum_ClientPrecio.Mayoreo))
                    End If

                    If ChkAplicaPrecio3.Checked Then
                        VerificaMensaje(Bod.ActualizaPrecioArticuloProforma(TxtCodigo.Text, Enum_ClientPrecio.Precio3))
                    End If

                    If ChkAplicaPrecio4.Checked Then
                        VerificaMensaje(Bod.ActualizaPrecioArticuloProforma(TxtCodigo.Text, Enum_ClientPrecio.Precio4))
                    End If

                    If ChkAplicaPrecio5.Checked Then
                        VerificaMensaje(Bod.ActualizaPrecioArticuloProforma(TxtCodigo.Text, Enum_ClientPrecio.Precio5))
                    End If
                Next

            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Suc = Nothing
            Bod = Nothing
        End Try
    End Sub


    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub TxtMargenMayorista_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtMargenMayorista.TextChanged
        Dim Costo As Double = 0
        Dim Margen As Double = 0

        Try
            If Not GbPrecioMayoreo.Enabled Then
                Exit Sub
            End If

            If TxtCosto.Tag <> "" Then
                Exit Sub
            End If

            TxtCosto.Tag = "m"

            If Not IsNumeric(TxtCosto.Text) Then
                Costo = 0
            Else
                Costo = CDbl(TxtCosto.Text)
            End If

            If Not IsNumeric(TxtMargenMayorista.Text) Then
                Margen = 0
            Else
                Margen = CDbl(TxtMargenMayorista.Text)
            End If

            TxtPrecioMayorista.Text = Format(CalculaPrecio(Costo, Margen), "##0.0000")

            If LCase(LblExento.Text) = "si" Then
                TxtPrecioVentaMayorista.Text = TxtPrecioMayorista.Text
            Else
                TxtPrecioVentaMayorista.Text = Format(CDbl(TxtPrecioMayorista.Text) + CalculaMontoImpuesto(TxtPrecioMayorista.Text, InfoArticulo.ArticuloImpuestos), "##0.0000")
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TxtCosto.Tag = ""
        End Try
    End Sub

    Private Sub TxtPrecioVentaMayorista_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtPrecioVentaMayorista.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtPrecioVenta3.Focus()
            TxtPrecioVenta3.SelectAll()
        End If
    End Sub

    Private Sub TxtPrecioVentaMayorista_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtPrecioVentaMayorista.TextChanged
        Dim Costo As Double = 0
        Dim Precio As Double = 0
        Dim PrecioVenta As Double = 0

        Try
            If Not GbPrecioMayoreo.Enabled Then
                Exit Sub
            End If

            If TxtCosto.Tag <> "" Then
                Exit Sub
            End If

            TxtCosto.Tag = "p"

            If Not IsNumeric(TxtCosto.Text) Then
                Costo = 0
            Else
                Costo = CDbl(TxtCosto.Text)
            End If

            If Not IsNumeric(TxtPrecioVentaMayorista.Text) Then
                PrecioVenta = 0
            Else
                PrecioVenta = CDbl(TxtPrecioVentaMayorista.Text)
            End If

            'Calcula el monto del precio sin impuesto de venta
            If LCase(LblExento.Text) = "si" Then
                TxtPrecioMayorista.Text = Format(PrecioVenta, "#,##0.0000")
            Else
                TxtPrecioMayorista.Text = Format(PrecioVenta - RestaMontoImpuesto(PrecioVenta, InfoArticulo.ArticuloImpuestos), "#,##0.0000")
            End If

            If Not IsNumeric(TxtPrecioMayorista.Text) Then
                Precio = 0
            Else
                Precio = CDbl(TxtPrecioMayorista.Text)
            End If


            'Calcula el margen de ganancia
            TxtMargenMayorista.Text = Format(CalculaMargen(Costo, Precio), "##0.00")
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TxtCosto.Tag = ""
        End Try
    End Sub

    Private Sub TxtPrecioVenta_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtPrecioVenta.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtPrecioVentaMayorista.Focus()
            TxtPrecioVentaMayorista.SelectAll()
        End If
    End Sub

    Private Sub CargaListaAnotaciones(pArt_Id As String)
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim Items(3) As String
        Dim Item As ListViewItem = Nothing

        Try
            LvwAnotaciones.Items.Clear()
            BtnAnotacionEliminar.Enabled = False

            Articulo.Art_Id = pArt_Id
            VerificaMensaje(Articulo.ConsultaAnotaciones)

            For Each Fila As DataRow In Articulo.Data.Tables(0).Rows
                Items(ColumnasAnotaciones.Id) = Fila("Anotacion_Id")
                Items(ColumnasAnotaciones.Anotacion) = Fila("Anotacion")
                Items(ColumnasAnotaciones.Fecha) = Format(Fila("Fecha"), "dd/MM/yyyy")
                Items(ColumnasAnotaciones.Usuario) = Fila("Usuario_Id")
                Item = New ListViewItem(Items)
                LvwAnotaciones.Items.Add(Item)
            Next

            BtnAnotacionEliminar.Enabled = LvwAnotaciones.Items.Count > 0

            If LvwAnotaciones.Items.Count > 0 Then
                LvwAnotaciones.Items(LvwAnotaciones.Items.Count - 1).EnsureVisible()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Articulo = Nothing
        End Try
    End Sub

    Private Sub BtnAnotacionEliminar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAnotacionEliminar.Click
        Dim ArticuloAnotacion As New TArticuloAnotacion(EmpresaInfo.Emp_Id)

        Try
            If LvwAnotaciones.SelectedItems Is Nothing OrElse LvwAnotaciones.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar una anotación")
            End If

            With ArticuloAnotacion
                .Art_Id = TxtCodigo.Text
                .Anotacion_Id = CInt(LvwAnotaciones.SelectedItems(0).SubItems(0).Text)
            End With
            VerificaMensaje(ArticuloAnotacion.Delete)

            CargaListaAnotaciones(TxtCodigo.Text)
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloAnotacion = Nothing
        End Try
    End Sub

    Private Sub BtnAnotacionAgregar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAnotacionAgregar.Click
        Dim Forma As New FrmArticuloAnotacion

        Try
            Forma.Art_Id = TxtCodigo.Text
            Forma.execute()
            CargaListaAnotaciones(TxtCodigo.Text)
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub TxtMargen3_TextChanged(sender As Object, e As EventArgs) Handles TxtMargen3.TextChanged
        Dim Costo As Double = 0
        Dim Margen As Double = 0

        Try
            If Not GbPrecio3.Enabled Then
                Exit Sub
            End If

            If TxtCosto.Tag <> "" Then
                Exit Sub
            End If

            TxtCosto.Tag = "m"

            If Not IsNumeric(TxtCosto.Text) Then
                Costo = 0
            Else
                Costo = CDbl(TxtCosto.Text)
            End If

            If Not IsNumeric(TxtMargen3.Text) Then
                Margen = 0
            Else
                Margen = CDbl(TxtMargen3.Text)
            End If

            TxtPrecio3.Text = Format(CalculaPrecio(Costo, Margen), "##0.0000")

            If LCase(LblExento.Text) = "si" Then
                TxtPrecioVenta3.Text = TxtPrecio3.Text
            Else
                TxtPrecioVenta3.Text = Format(CDbl(TxtPrecio3.Text) + CalculaMontoImpuesto(TxtPrecio3.Text, InfoArticulo.ArticuloImpuestos), "##0.0000")
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TxtCosto.Tag = ""
        End Try
    End Sub

    Private Sub TxtPrecioVenta3_TextChanged(sender As Object, e As EventArgs) Handles TxtPrecioVenta3.TextChanged
        Dim Costo As Double = 0
        Dim Precio As Double = 0
        Dim PrecioVenta As Double = 0

        Try
            If Not GbPrecio3.Enabled Then
                Exit Sub
            End If

            If TxtCosto.Tag <> "" Then
                Exit Sub
            End If

            TxtCosto.Tag = "p"

            If Not IsNumeric(TxtCosto.Text) Then
                Costo = 0
            Else
                Costo = CDbl(TxtCosto.Text)
            End If

            If Not IsNumeric(TxtPrecioVenta3.Text) Then
                PrecioVenta = 0
            Else
                PrecioVenta = CDbl(TxtPrecioVenta3.Text)
            End If

            'Calcula el monto del precio sin impuesto de venta
            If LCase(LblExento.Text) = "si" Then
                TxtPrecio3.Text = Format(PrecioVenta, "#,##0.0000")
            Else
                TxtPrecio3.Text = Format(PrecioVenta - RestaMontoImpuesto(PrecioVenta, InfoArticulo.ArticuloImpuestos), "#,##0.0000")
            End If

            If Not IsNumeric(TxtPrecio3.Text) Then
                Precio = 0
            Else
                Precio = CDbl(TxtPrecio3.Text)
            End If

            'Calcula el margen de ganancia
            TxtMargen3.Text = Format(CalculaMargen(Costo, Precio), "##0.00")



        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TxtCosto.Tag = ""
        End Try
    End Sub

    Private Sub TxtPrecioVenta3_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtPrecioVenta3.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtPrecioVenta4.Focus()
            TxtPrecioVenta4.SelectAll()
        End If
    End Sub

    Private Sub TxtMargen4_TextChanged(sender As Object, e As EventArgs) Handles TxtMargen4.TextChanged
        Dim Costo As Double = 0
        Dim Margen As Double = 0

        Try
            If Not GbPrecio4.Enabled Then
                Exit Sub
            End If

            If TxtCosto.Tag <> "" Then
                Exit Sub
            End If

            TxtCosto.Tag = "m"

            If Not IsNumeric(TxtCosto.Text) Then
                Costo = 0
            Else
                Costo = CDbl(TxtCosto.Text)
            End If

            If Not IsNumeric(TxtMargen4.Text) Then
                Margen = 0
            Else
                Margen = CDbl(TxtMargen4.Text)
            End If

            TxtPrecio4.Text = Format(CalculaPrecio(Costo, Margen), "##0.0000")

            If LCase(LblExento.Text) = "si" Then
                TxtPrecioVenta4.Text = TxtPrecio4.Text
            Else
                TxtPrecioVenta4.Text = Format(CDbl(TxtPrecio4.Text) + CalculaMontoImpuesto(TxtPrecio4.Text, InfoArticulo.ArticuloImpuestos), "##0.0000")
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TxtCosto.Tag = ""
        End Try
    End Sub

    Private Sub TxtPrecioVenta4_TextChanged(sender As Object, e As EventArgs) Handles TxtPrecioVenta4.TextChanged
        Dim Costo As Double = 0
        Dim Precio As Double = 0
        Dim PrecioVenta As Double = 0

        Try
            If Not GbPrecio4.Enabled Then
                Exit Sub
            End If

            If TxtCosto.Tag <> "" Then
                Exit Sub
            End If

            TxtCosto.Tag = "p"

            If Not IsNumeric(TxtCosto.Text) Then
                Costo = 0
            Else
                Costo = CDbl(TxtCosto.Text)
            End If

            If Not IsNumeric(TxtPrecioVenta4.Text) Then
                PrecioVenta = 0
            Else
                PrecioVenta = CDbl(TxtPrecioVenta4.Text)
            End If

            'Calcula el monto del precio sin impuesto de venta
            If LCase(LblExento.Text) = "si" Then
                TxtPrecio4.Text = Format(PrecioVenta, "#,##0.0000")
            Else
                TxtPrecio4.Text = Format(PrecioVenta - RestaMontoImpuesto(PrecioVenta, InfoArticulo.ArticuloImpuestos), "#,##0.0000")
            End If

            If Not IsNumeric(TxtPrecio4.Text) Then
                Precio = 0
            Else
                Precio = CDbl(TxtPrecio4.Text)
            End If

            'Calcula el margen de ganancia
            TxtMargen4.Text = Format(CalculaMargen(Costo, Precio), "##0.00")


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TxtCosto.Tag = ""
        End Try
    End Sub

    Private Sub TxtPrecioVenta4_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtPrecioVenta4.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtPrecioVenta5.Focus()
            TxtPrecioVenta5.SelectAll()
        End If
    End Sub

    Private Sub TxtMargen5_TextChanged(sender As Object, e As EventArgs) Handles TxtMargen5.TextChanged
        Dim Costo As Double = 0
        Dim Margen As Double = 0

        Try
            If Not GbPrecio5.Enabled Then
                Exit Sub
            End If

            If TxtCosto.Tag <> "" Then
                Exit Sub
            End If

            TxtCosto.Tag = "m"

            If Not IsNumeric(TxtCosto.Text) Then
                Costo = 0
            Else
                Costo = CDbl(TxtCosto.Text)
            End If

            If Not IsNumeric(TxtMargen5.Text) Then
                Margen = 0
            Else
                Margen = CDbl(TxtMargen5.Text)
            End If

            TxtPrecio5.Text = Format(CalculaPrecio(Costo, Margen), "##0.0000")

            If LCase(LblExento.Text) = "si" Then
                TxtPrecioVenta5.Text = TxtPrecio5.Text
            Else
                TxtPrecioVenta5.Text = Format(CDbl(TxtPrecio5.Text) + CalculaMontoImpuesto(TxtPrecio5.Text, InfoArticulo.ArticuloImpuestos), "##0.0000")
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TxtCosto.Tag = ""
        End Try
    End Sub

    Private Sub TxtPrecioVenta5_TextChanged(sender As Object, e As EventArgs) Handles TxtPrecioVenta5.TextChanged
        Dim Costo As Double = 0
        Dim Precio As Double = 0
        Dim PrecioVenta As Double = 0

        Try
            If Not GbPrecio5.Enabled Then
                Exit Sub
            End If

            If TxtCosto.Tag <> "" Then
                Exit Sub
            End If

            TxtCosto.Tag = "p"

            If Not IsNumeric(TxtCosto.Text) Then
                Costo = 0
            Else
                Costo = CDbl(TxtCosto.Text)
            End If

            If Not IsNumeric(TxtPrecioVenta5.Text) Then
                PrecioVenta = 0
            Else
                PrecioVenta = CDbl(TxtPrecioVenta5.Text)
            End If

            'Calcula el monto del precio sin impuesto de venta
            If LCase(LblExento.Text) = "si" Then
                TxtPrecio5.Text = Format(PrecioVenta, "#,##0.0000")
            Else
                TxtPrecio5.Text = Format(PrecioVenta - RestaMontoImpuesto(PrecioVenta, InfoArticulo.ArticuloImpuestos), "#,##0.0000")
            End If

            If Not IsNumeric(TxtPrecio5.Text) Then
                Precio = 0
            Else
                Precio = CDbl(TxtPrecio5.Text)
            End If

            'Calcula el margen de ganancia
            TxtMargen5.Text = Format(CalculaMargen(Costo, Precio), "##0.00")


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TxtCosto.Tag = ""
        End Try
    End Sub

    Private Sub TxtPrecioVenta5_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtPrecioVenta5.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnGuardar.Focus()
        End If
    End Sub

    Private Sub BtnAplicarPrecio_Click(sender As Object, e As EventArgs) Handles BtnAplicarPrecio.Click
        If MsgBox("Desea aplicar el precio detalle a todos los precios", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Me.Text) = MsgBoxResult.Yes Then
            TxtPrecioVentaMayorista.Text = TxtPrecioVenta.Text
            TxtPrecioVenta3.Text = TxtPrecioVenta.Text
            TxtPrecioVenta4.Text = TxtPrecioVenta.Text
            TxtPrecioVenta5.Text = TxtPrecioVenta.Text
        End If
    End Sub

    Private Sub FrmArticuloBodega_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnGuardar.PerformClick()
            Case Keys.F4
                BtnLimpiar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Function CalculaMontoImpuesto(pMonto As Double, pArticuloImpuestos As List(Of TFacturaDetalleImpuesto)) As Double
        Dim OtrosImpuestos As Double = 0
        Dim TotalImpuesto As Double = 0


        _FacturaDetalleImpuestos.RemoveAll(Function(x) x.Detalle_Id = 1)

        For Each impuesto As TFacturaDetalleImpuesto In pArticuloImpuestos
            If impuesto.Codigo_Id <> coImpuesto01 And impuesto.Codigo_Id <> coImpuesto12 Then
                With impuesto
                    .Detalle_Id = 1
                    .Monto = pMonto * (impuesto.Porcentaje / 100)
                End With
                OtrosImpuestos += impuesto.Monto
                _FacturaDetalleImpuestos.Add(impuesto)
            End If
        Next

        For Each impuesto As TFacturaDetalleImpuesto In pArticuloImpuestos
            If impuesto.Codigo_Id = coImpuesto01 OrElse impuesto.Codigo_Id = coImpuesto12 Then
                With impuesto
                    .Detalle_Id = 1
                    .Monto = (pMonto + OtrosImpuestos) * (impuesto.Porcentaje / 100)
                End With
                TotalImpuesto += impuesto.Monto
                _FacturaDetalleImpuestos.Add(impuesto)
            End If
        Next

        Return TotalImpuesto + OtrosImpuestos

    End Function

    Private Function RestaMontoImpuesto(pMonto As Double, pArticuloImpuestos As List(Of TFacturaDetalleImpuesto)) As Double
        Dim OtrosImpuestos As Double = 0
        Dim TotalImpuesto As Double = 0
        Dim TotalPorcentaje As Double = 0

        For Each impuesto As TFacturaDetalleImpuesto In pArticuloImpuestos
            If impuesto.Codigo_Id = coImpuesto01 OrElse impuesto.Codigo_Id = coImpuesto12 Then
                With impuesto
                    .Detalle_Id = 1
                    .Monto = pMonto - (pMonto / (1 + (impuesto.Porcentaje / 100)))
                End With
                TotalPorcentaje += impuesto.Porcentaje
            End If
        Next

        TotalImpuesto = pMonto - (pMonto / (1 + (TotalPorcentaje / 100)))

        For Each impuesto As TFacturaDetalleImpuesto In pArticuloImpuestos
            If impuesto.Codigo_Id <> coImpuesto01 And impuesto.Codigo_Id <> coImpuesto12 Then
                With impuesto
                    .Detalle_Id = 1
                    .Monto = (pMonto - TotalImpuesto) - ((pMonto - TotalImpuesto) / (1 + (impuesto.Porcentaje / 100)))
                End With
                OtrosImpuestos += impuesto.Porcentaje
            End If
        Next


        Return TotalImpuesto + (pMonto - TotalImpuesto) - ((pMonto - TotalImpuesto) / (1 + (OtrosImpuestos / 100)))

    End Function
End Class