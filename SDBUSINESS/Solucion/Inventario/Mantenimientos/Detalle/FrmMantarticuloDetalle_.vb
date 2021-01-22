Imports Business
Public Class FrmMantarticuloDetalle_
#Region "Declaracion Variables"
    Dim Numerico() As TNumericFormat
    Private coErrorArticulo = "--ERROR:Articulo--"
    Private _Activo As Boolean = False
    Private _Nuevo As Boolean = True
    Private Codigo As String
    Private Descripcion As String
    Private Tarifa As Double
    Private Enum AccionEnum
        Inicial = 0
        Editando = 1
    End Enum

    Private Enum EnumImpuestoColumnas
        ImpuestoCodigo = 0
        ImpuestoDescripcion
        PermiteModificar
        PoseeTarifa
        Tarifa
        Tarifa_Id
        Porcentaje
    End Enum
#End Region
#Region "Metodos Publicos"
    Public Sub Execute()
        FormateaCamposNumericos()
        CargaCombos()
        CreaArbolBodegas()
        ConfiguraListas()
        Inicializa()

        Me.Show()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub HabilitaBotones(pAccion As AccionEnum)
        Select Case pAccion
            Case AccionEnum.Inicial
                BtnGuardar.Enabled = False
                BtnLimpiar.Enabled = False
                BtnCosto.Enabled = False
                BtnPrecios.Enabled = False
                BtnReceta.Enabled = False
                BtnProveedor.Enabled = False
                BtnEliminar.Enabled = False
                BtnConsulta.Enabled = False
                BtnSalir.Enabled = True
            Case AccionEnum.Editando
                BtnGuardar.Enabled = True
                BtnLimpiar.Enabled = True
                BtnSalir.Enabled = True
        End Select
    End Sub
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(2)

            Numerico(0) = New TNumericFormat(TxtFactorConversion, 4, 0, False, "1", "###")
            Numerico(1) = New TNumericFormat(TxtCantidadConjunto, 4, 2, False, "1", "##0.00")


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub CargaCombos()
        Dim Categoria As New TCategoria(EmpresaInfo.Emp_Id)
        Dim SubCategoria As New TSubCategoria(EmpresaInfo.Emp_Id)
        Dim Departamento As New TDepartamento(EmpresaInfo.Emp_Id)
        Dim UnidadMedida As New TUnidadMedida(EmpresaInfo.Emp_Id)
        Dim TipoAcumulacion As New TTipoAcumulacion(EmpresaInfo.Emp_Id)
        Dim ImpuestoCodigo As New TImpuestoCodigo()
        Dim ImpuestoTarifa As New TImpuestoTarifa()
        Dim Mensaje As String = ""
        Try
            Mensaje = Categoria.LoadComboBox(CmbCategoria)
            VerificaMensaje(Mensaje)

            SubCategoria.Cat_Id = Categoria.Cat_Id
            Mensaje = SubCategoria.LoadComboBox(CmbSubCategoria)
            VerificaMensaje(Mensaje)

            Mensaje = Departamento.LoadComboBox(CmbDepartamento)
            VerificaMensaje(Mensaje)

            Mensaje = UnidadMedida.LoadComboBox(CmbUnidadMedida)
            VerificaMensaje(Mensaje)

            Mensaje = TipoAcumulacion.LoadComboBox(CmbTipoAcumulacion)
            VerificaMensaje(Mensaje)


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Categoria = Nothing
            SubCategoria = Nothing
            Departamento = Nothing
            UnidadMedida = Nothing
            TipoAcumulacion = Nothing
            ImpuestoCodigo = Nothing
            ImpuestoTarifa = Nothing
        End Try
    End Sub
    Private Sub CreaArbolBodegas()
        Dim Bodega As New TBodega(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            Mensaje = Bodega.CreaArbolBodegas(TrwBodegas)

            If PrintLocation.Tectel = InfoMaquina.PrintLocation Then
                Mensaje = Bodega.CreaArbolBodegasConSaldos(TrwBodegas, TxtCodigo.Text)
            Else
                Mensaje = Bodega.CreaArbolBodegas(TrwBodegas)
            End If

            VerificaMensaje(Mensaje)


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ConfiguraListas()
        Try

            With LvwImpuesto
                .Columns(EnumImpuestoColumnas.ImpuestoCodigo).Text = "Código"
                .Columns(EnumImpuestoColumnas.ImpuestoCodigo).Width = 50
                .Columns(EnumImpuestoColumnas.ImpuestoCodigo).TextAlign = HorizontalAlignment.Center

                .Columns(EnumImpuestoColumnas.ImpuestoDescripcion).Text = "Impuesto"
                .Columns(EnumImpuestoColumnas.ImpuestoDescripcion).Width = 250
                .Columns(EnumImpuestoColumnas.ImpuestoDescripcion).TextAlign = HorizontalAlignment.Left

                .Columns(EnumImpuestoColumnas.PermiteModificar).Text = "PermiteModificar"
                .Columns(EnumImpuestoColumnas.PermiteModificar).Width = 0
                .Columns(EnumImpuestoColumnas.PermiteModificar).TextAlign = HorizontalAlignment.Left

                .Columns(EnumImpuestoColumnas.PoseeTarifa).Text = "PoseeTarifa"
                .Columns(EnumImpuestoColumnas.PoseeTarifa).Width = 0
                .Columns(EnumImpuestoColumnas.PoseeTarifa).TextAlign = HorizontalAlignment.Left

                .Columns(EnumImpuestoColumnas.Tarifa).Text = "Tipo Tarifa"
                .Columns(EnumImpuestoColumnas.Tarifa).Width = 150
                .Columns(EnumImpuestoColumnas.Tarifa).TextAlign = HorizontalAlignment.Left

                .Columns(EnumImpuestoColumnas.Tarifa_Id).Text = "Tarifa"
                .Columns(EnumImpuestoColumnas.Tarifa_Id).Width = 0
                .Columns(EnumImpuestoColumnas.Tarifa_Id).TextAlign = HorizontalAlignment.Left

                .Columns(EnumImpuestoColumnas.Porcentaje).Text = "Porcentaje"
                .Columns(EnumImpuestoColumnas.Porcentaje).Width = 100
                .Columns(EnumImpuestoColumnas.Porcentaje).TextAlign = HorizontalAlignment.Left
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Inicializa()
        Try
            HabilitaBotones(AccionEnum.Inicial)
            PanelGeneral1.Enabled = False
            PanelGeneral2.Enabled = False
            PanelGeneral3.Enabled = False
            TxtCodigo.Enabled = True
            Txbcabys.Enabled = False
            TxtCodigo.Focus()
            _Nuevo = True


            GroupImpuesto.Enabled = False


            TxtCodigo.Text = ""
            TxtNombre.Text = ""
            TxtCuentaContable.Text = ""
            Txbcabys.Text = ""
            If CmbCategoria.Items.Count > 0 Then
                CmbCategoria.SelectedIndex = -1
            End If
            If CmbSubCategoria.Items.Count > 0 Then
                CmbSubCategoria.DataSource = Nothing
                CmbSubCategoria.Items.Clear()
            End If
            If CmbDepartamento.Items.Count > 0 Then
                CmbDepartamento.SelectedIndex = 0
            End If
            If CmbUnidadMedida.Items.Count > 0 Then
                CmbUnidadMedida.SelectedIndex = 0
            End If
            If CmbTipoAcumulacion.Items.Count > 0 Then
                CmbTipoAcumulacion.SelectedIndex = 0
            End If


            TxtFactorConversion.Text = ""
            ChkSuelto.Checked = False
            ChkSuelto_CheckedChanged(Nothing, EventArgs.Empty)
            TxtCodigoPadre.Text = ""
            TxtNombrePadre.Text = ""

            ChkPermiteFacturar.Checked = False
            ChkCantidadEtiqueta.Checked = False
            ChkSolicitaCantidad.Checked = False
            ChkCalculaCantidad.Checked = False
            ChkCalculaCantidad.Checked = False
            ChkActivo.Checked = False
            ChkServicio.Checked = False
            ChkCompuesto.Checked = False


            ChkBusquedaRapida.Checked = False
            ChkArticuloFrecuente.Checked = False

            LvwEquivalentes.Items.Clear()
            TxtCodigoEquivalente.Text = ""
            LvwConjuntos.Items.Clear()
            TxtCodigoConjunto.Text = ""
            TxtNombreConjunto.Text = ""
            TxtCantidadConjunto.Text = ""
            TrwBodegas.Nodes.Clear()

            LvwImpuesto.Items.Clear()
            ChkExento.Checked = True

            CmbCodigoCantidadTipo.SelectedIndex = -1

            TxtAnotaciones.Text = ""
            TxtCodInterno.Text = ""
            TxtCodProveedor.Text = ""

            ChkCompuesto.Enabled = False
            ChkSaldoPropio.Enabled = False
            'TxtPorcImpuestoConsumo.Text = 0
            'ChkExentoIC.Checked = True

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Function ValidaArticuloPadre(pCodigo As String) As Boolean
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            Articulo.Art_Id = pCodigo
            Mensaje = Articulo.ListKey()
            VerificaMensaje(Mensaje)

            If Articulo.RowsAffected = 0 Then
                VerificaMensaje("El código de artículo no es válido")
            End If

            TxtNombrePadre.Text = Articulo.Nombre

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        Finally
            Articulo = Nothing
        End Try
    End Function
    Private Function ValidaArticuloConjunto(pCodigo As String) As String
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            Articulo.Art_Id = pCodigo
            Mensaje = Articulo.ListKey()
            VerificaMensaje(Mensaje)

            If Articulo.RowsAffected = 0 Then
                VerificaMensaje("El código de artículo no es válido")
            End If

            Return Articulo.Nombre

        Catch ex As Exception
            MensajeError(ex.Message)
            Return coErrorArticulo
        Finally
            Articulo = Nothing
        End Try
    End Function
    Private Function ExisteItemListView(pValor As String, pLvwLista As ListView) As Boolean

        For Each Item As ListViewItem In pLvwLista.Items
            If Item.Tag = pValor Then
                Return True
                Exit Function
            End If
        Next

        Return False
    End Function
    Private Function VerificaCodigoEquivalente(pCodigo As String, pVerificaListaLocal As Boolean) As Boolean
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim ArticuloEquivaente As New TArticuloEquivalente(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            If pCodigo = "" Then
                VerificaMensaje("Debe de digitar un código")
            End If

            If pVerificaListaLocal Then
                If ExisteItemListView(pCodigo, LvwEquivalentes) Then
                    VerificaMensaje("El código ya se encuentra en la lista")
                End If
            End If

            Articulo.Art_Id = pCodigo
            Mensaje = Articulo.ListKey()
            VerificaMensaje(Mensaje)

            If Articulo.RowsAffected > 0 Then
                VerificaMensaje("Ya existe un artículo con el código " & pCodigo)
            End If


            ArticuloEquivaente.ArtEquivalente_Id = pCodigo
            Mensaje = ArticuloEquivaente.ListKey()
            VerificaMensaje(Mensaje)

            If ArticuloEquivaente.RowsAffected > 0 Then
                If ArticuloEquivaente.Art_Id <> TxtCodigo.Text Then
                    VerificaMensaje("Ya existe un artículo que tiene asignado el con el código equivalente " & pCodigo)
                End If
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        Finally
            Articulo = Nothing
            ArticuloEquivaente = Nothing
        End Try
    End Function
    Private Function VerificaCodigoConjunto(pCodigo As String) As Boolean
        Dim Resultado As String = ""
        Try
            If pCodigo = "" Then
                TxtCodigoConjunto.SelectAll()
                TxtCodigoConjunto.Focus()
                VerificaMensaje("Debe de digitar un código")
            End If


            Resultado = ValidaArticuloConjunto(pCodigo)
            If Resultado = coErrorArticulo Then
                TxtCodigoConjunto.SelectAll()
                TxtCodigoConjunto.Focus()
                VerificaMensaje("Debe de digitar un código válido")
            Else
                TxtNombreConjunto.Text = Resultado
            End If

            If pCodigo.Trim = TxtCodigo.Text.Trim Then
                TxtCodigoConjunto.SelectAll()
                TxtCodigoConjunto.Focus()
                VerificaMensaje("El código conjunto no puede ser igual al código del artículo")
            End If

            If ExisteItemListView(pCodigo, LvwConjuntos) Then
                TxtCodigoConjunto.SelectAll()
                TxtCodigoConjunto.Focus()
                VerificaMensaje("El código ya se encuentra en la lista")
            End If

            If Not IsNumeric(TxtCantidadConjunto.Text) Then
                TxtCantidadConjunto.Focus()
                VerificaMensaje("Debe de digitar una cantidad")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function
    Private Sub CargaEquivalentes(pArt_Id As String)
        Dim ArticuloEquivalente As New TArticuloEquivalente(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Dim Item As ListViewItem = Nothing
        Try

            ArticuloEquivalente.Art_Id = pArt_Id
            Mensaje = ArticuloEquivalente.List
            VerificaMensaje(Mensaje)

            If ArticuloEquivalente.RowsAffected = 0 Then
                Exit Sub
            End If

            For Each Fila As DataRow In ArticuloEquivalente.Data.Tables(0).Rows
                Item = LvwEquivalentes.Items.Add(Fila.Item("ArtEquivalente_Id"))
                Item.Tag = Fila.Item("ArtEquivalente_Id")
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloEquivalente = Nothing
        End Try
    End Sub
    Private Sub CargaConjuntos(pArt_Id As String)
        Dim ArticuloConjunto As New TArticuloConjunto(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Dim Item As ListViewItem = Nothing
        Dim Items(2) As String
        Try

            ArticuloConjunto.Art_Id = pArt_Id
            Mensaje = ArticuloConjunto.List
            VerificaMensaje(Mensaje)

            If ArticuloConjunto.RowsAffected = 0 Then
                Exit Sub
            End If

            For Each Fila As DataRow In ArticuloConjunto.Data.Tables(0).Rows
                Items(0) = Fila.Item("ArtConjunto_Id")
                Items(1) = Fila.Item("NombreConjunto")
                Items(2) = Fila.Item("Cantidad")

                Item = New ListViewItem(Items)
                Item.Tag = Fila.Item("ArtConjunto_Id")

                LvwConjuntos.Items.Add(Item)

            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloConjunto = Nothing
        End Try
    End Sub
    Private Sub CargaBodegasArticulo(pArt_Id As String)
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            ArticuloBodega.Art_Id = pArt_Id
            Mensaje = ArticuloBodega.ListaBodegasArticulo()
            VerificaMensaje(Mensaje)

            If ArticuloBodega.RowsAffected = 0 Then
                Exit Sub
            End If

            For Each Fila As DataRow In ArticuloBodega.Data.Tables(0).Rows
                For Each Nodo As TreeNode In TrwBodegas.Nodes
                    MarcarNodos(Nodo, Fila.Item("Suc_Id"), Fila.Item("Bod_Id"))
                Next
            Next

            TrwBodegas.Refresh()


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloBodega = Nothing
        End Try
    End Sub
    Private Sub CargaImpuestos(pArt_Id As String)
        Dim ArticuloImpuesto As New TArticuloImpuesto(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Dim Impuestos As New TImpuestoCodigo()
        Dim Item As ListViewItem = Nothing
        Dim Items(6) As String
        Dim Asignado As Boolean = False
        Try
            LvwImpuesto.Items.Clear()
            ArticuloImpuesto.Art_Id = pArt_Id
            Mensaje = ArticuloImpuesto.List
            VerificaMensaje(Mensaje)

            VerificaMensaje(Impuestos.List())

            For Each Fila As DataRow In Impuestos.Data.Tables(0).Rows

                Items(EnumImpuestoColumnas.ImpuestoCodigo) = Fila.Item("Codigo_Id")
                Items(EnumImpuestoColumnas.ImpuestoDescripcion) = Fila.Item("Nombre")
                Items(EnumImpuestoColumnas.PermiteModificar) = Fila.Item("PermiteModificar")
                Items(EnumImpuestoColumnas.PoseeTarifa) = Fila.Item("PoseeTarifa")
                Items(EnumImpuestoColumnas.Porcentaje) = CDbl("0").ToString("#,##0.00")
                Items(EnumImpuestoColumnas.Tarifa) = "Ninguna"
                Items(EnumImpuestoColumnas.Tarifa_Id) = "00"

                Asignado = False

                For Each registro As DataRow In ArticuloImpuesto.Data.Tables(0).Rows
                    If Fila.Item("Codigo_Id") = registro.Item("Codigo_Id") Then
                        Items(EnumImpuestoColumnas.Porcentaje) = CDbl(registro.Item("Porcentaje")).ToString("#,##0.00")
                        Items(EnumImpuestoColumnas.Tarifa) = registro.Item("Tarifa")
                        Items(EnumImpuestoColumnas.Tarifa_Id) = registro.Item("Tarifa_Id")
                        Asignado = True
                        Exit For
                    End If
                Next

                Item = New ListViewItem(Items)



                Item.ImageIndex = IIf(Asignado, 0, -1)

                LvwImpuesto.Items.Add(Item)

            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloImpuesto = Nothing
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
    Dim cabysDescripcion As String = " "
    Private Sub CargaDatos()
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim ArticuloEquivalente As New TArticuloEquivalente(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            ArticuloEquivalente.ArtEquivalente_Id = TxtCodigo.Text.Trim
            Mensaje = ArticuloEquivalente.ListKey()
            VerificaMensaje(Mensaje)
            If ArticuloEquivalente.RowsAffected > 0 Then
                VerificaMensaje("Este código de artículo ya se encuentra asignado como equivalente al artículo " & ArticuloEquivalente.Art_Id)
            End If

            LvwEquivalentes.Items.Clear()
            ChkSolicitaCantidad.Checked = True

            _Nuevo = True

            Articulo.Art_Id = TxtCodigo.Text.Trim
            Mensaje = Articulo.ListKey()
            VerificaMensaje(Mensaje)

            If Articulo.RowsAffected = 0 Then
                If MsgBox("El código de artículo no existe, Desea crearlo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                    TxtCodigo.SelectAll()
                    TxtCodigo.Focus()
                    Exit Sub
                Else
                    ChkCompuesto.Enabled = True
                End If
            End If

            HabilitaBotones(AccionEnum.Editando)

            GroupImpuesto.Enabled = True

            PanelGeneral1.Enabled = True
            PanelGeneral2.Enabled = True
            PanelGeneral3.Enabled = (Articulo.RowsAffected > 0)
            TxtCodigo.Enabled = False
            Txbcabys.Enabled = True
            Txbcabys.Focus()
            'TxtNombre.Focus()

            CreaArbolBodegas()

            If Articulo.RowsAffected > 0 Then
                _Nuevo = False
                With Articulo
                    TxtNombre.Text = .Nombre
                    CmbCategoria.SelectedValue = .Cat_Id
                    CmbSubCategoria.SelectedValue = .SubCat_Id
                    CmbDepartamento.SelectedValue = .Departamento_Id
                    CmbUnidadMedida.SelectedValue = .UnidadMedida_Id
                    CmbTipoAcumulacion.SelectedValue = .TipoAcumulacion_Id
                    TxtFactorConversion.Text = .FactorConversion
                    ChkSuelto.Checked = .Suelto
                    ChkSuelto_CheckedChanged(Nothing, EventArgs.Empty)
                    Txbcabys.Text = .CodigoCabys
                    cabysDescripcion = .CabysDescripcion
                    Tarifa = .CabysTarifa
                    If .Suelto Then
                        TxtCodigoPadre.Text = .ArtPadre
                        ValidaArticuloPadre(.ArtPadre)
                    End If
                    ChkExento.Checked = .ExentoIV
                    ChkPermiteFacturar.Checked = .PermiteFacturar
                    ChkSolicitaCantidad.Checked = .SolicitarCantidad
                    ChkCalculaCantidad.Checked = .CalculaCantidadFactura
                    ChkCantidadEtiqueta.Checked = .CodigoCantidad
                    ChkBusquedaRapida.Checked = .BusquedaRapida
                    ChkArticuloFrecuente.Checked = .Frecuente
                    ChkServicio.Checked = .Servicio
                    ChkCompuesto.Checked = .Compuesto
                    TxtCuentaContable.Text = .CuentaIngreso
                    TxtAnotaciones.Text = .Anotaciones
                    TxtCodProveedor.Text = .CodigoProveedor
                    TxtCodInterno.Text = .CodigoInterno
                    ChkSaldoPropio.Checked = .SaldoPropio

                    ChkGarantia.Checked = .Garantia
                    ChkLote.Checked = .Lote

                    If Not ChkCantidadEtiqueta.Checked Then
                        CmbCodigoCantidadTipo.SelectedIndex = -1
                        CmbCodigoCantidadTipo.Enabled = False
                    Else
                        CmbCodigoCantidadTipo.SelectedIndex = .CodigoCantidadTipo
                        CmbCodigoCantidadTipo.Enabled = True
                    End If
                    BtnCosto.Enabled = True
                    BtnPrecios.Enabled = True
                    BtnReceta.Enabled = .Compuesto
                    BtnProveedor.Enabled = True
                    BtnConsulta.Enabled = True
                    BtnEliminar.Enabled = True
                    ChkActivo.Checked = .Activo
                    CargaEquivalentes(.Art_Id)
                    CargaConjuntos(.Art_Id)
                    CargaBodegasArticulo(.Art_Id)
                    CargaImpuestos(.Art_Id)

                    ChkCompuesto.Enabled = False
                    ChkSaldoPropio.Enabled = False
                    'ChkExentoIC.Checked = .ExentoIC
                    'TxtPorcImpuestoConsumo.Text = .PorcIC
                End With
            Else
                TxtFactorConversion.Text = "1"
                BtnCosto.Enabled = False
                BtnPrecios.Enabled = False
                BtnReceta.Enabled = False
                BtnProveedor.Enabled = False
                BtnEliminar.Enabled = False
                ChkActivo.Checked = True
                ChkPermiteFacturar.Checked = True
                ChkServicio.Checked = False
                ChkCompuesto.Checked = False
                ChkSaldoPropio.Checked = True
                ChkSolicitaCantidad.Checked = EmpresaParametroInfo.ArticuloSolicitaCantidadDefault
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Articulo = Nothing
            ArticuloEquivalente = Nothing
        End Try
    End Sub
    Private Sub RefrescaInformacionBodega()
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            If TrwBodegas.SelectedNode Is Nothing OrElse TrwBodegas.SelectedNode.ImageIndex <> 2 Then
                MsgBox("Debe de seleccionar una bodega", MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If

            With ArticuloBodega
                .Suc_Id = CInt(TrwBodegas.SelectedNode.Parent.Tag)
                .Bod_Id = CInt(TrwBodegas.SelectedNode.Tag)
                .Art_Id = TxtCodigo.Text.Trim
            End With
            Mensaje = ArticuloBodega.ListKey()
            VerificaMensaje(Mensaje)

            If ArticuloBodega.RowsAffected = 0 Then
                Exit Sub
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloBodega = Nothing
        End Try
    End Sub

    Private Function ValidaDatos() As Boolean
        Dim TieneImpuestos As Boolean = False
        Dim Mensaje As String = String.Empty
        Dim ArticuloBodegaTmp As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Try
            If EmpresaParametroInfo.ValidaCabys = True And Txbcabys.Text.Trim = "" Then
                Txbcabys.Focus()
                VerificaMensaje("Debe de ingresar un valor")
            End If

            If TxtNombre.Text.Trim = "" Then
                TxtNombre.Focus()
                VerificaMensaje("Debe de ingresar un valor")
            End If

            If CmbCategoria.SelectedIndex < 0 OrElse CmbCategoria.SelectedValue Is Nothing Then
                CmbCategoria.Focus()
                VerificaMensaje("Debe de seleccionar una categoría")
            End If

            If CmbSubCategoria.SelectedIndex < 0 OrElse CmbSubCategoria.SelectedValue Is Nothing Then
                CmbSubCategoria.Focus()
                VerificaMensaje("Debe de seleccionar una sub categoría")
            End If

            If CmbDepartamento.SelectedIndex < 0 OrElse CmbDepartamento.SelectedValue Is Nothing Then
                CmbDepartamento.Focus()
                VerificaMensaje("Debe de seleccionar un departamento")
            End If

            If CmbUnidadMedida.SelectedIndex < 0 OrElse CmbUnidadMedida.SelectedValue Is Nothing Then
                CmbUnidadMedida.Focus()
                VerificaMensaje("Debe de seleccionar una unidad de medida")
            End If

            If CmbTipoAcumulacion.SelectedIndex < 0 OrElse CmbTipoAcumulacion.SelectedValue Is Nothing Then
                CmbTipoAcumulacion.Focus()
                VerificaMensaje("Debe de seleccionar un tipo de acumulación de puntos")
            End If


            If Not IsNumeric(TxtFactorConversion.Text) OrElse CInt(TxtFactorConversion.Text) < 1 Then
                TxtFactorConversion.SelectAll()
                TxtFactorConversion.Focus()
                VerificaMensaje("Debe ingresar el factor de conversión")
            End If

            If ChkCantidadEtiqueta.Checked Then
                If CmbCodigoCantidadTipo.SelectedIndex < 0 Then
                    CmbCodigoCantidadTipo.Focus()
                    VerificaMensaje("Debe seleccionar el tipo de medida que viene en la etiqueta (Peso o Unidad)")
                End If
            End If

            If Not ChkExento.Checked Then
                For Each item As ListViewItem In LvwImpuesto.Items
                    If item.ImageIndex = 0 Then
                        TieneImpuestos = True
                    End If
                Next
                If Not TieneImpuestos Then
                    VerificaMensaje("El artículo es gravado, debe de contener impuestos")
                End If
            End If

            If ChkCompuesto.Checked And ChkSuelto.Checked Then
                VerificaMensaje("Un artículo no puede ser suento y compuesto a la vez")
            End If


            'Verifica el codigo padre si se trata de un articulo suelto
            If ChkSuelto.Checked Then
                If TxtCodigoPadre.Text.Trim = "" Then
                    TxtCodigoPadre.SelectAll()
                    TxtCodigoPadre.Focus()
                    VerificaMensaje("Debe ingresar el código del padre")
                End If
                If Not ValidaArticuloPadre(TxtCodigoPadre.Text) Then
                    TxtCodigoPadre.SelectAll()
                    TxtCodigoPadre.Focus()
                End If
            End If

            If ChkServicio.Checked Then
                If ChkSolicitaCantidad.Checked Then
                    VerificaMensaje("Si el producto esta marcado como un servicio no puede estar marcada la opción de Solicita Cantidad")
                End If
                If ChkCantidadEtiqueta.Checked Then
                    VerificaMensaje("Si el producto esta marcado como un servicio no puede estar marcada la opción de Cantidad en Etiqueta")
                End If
                'If Not ChkExento.Checked Then
                '    VerificaMensaje("El producto esta marcado como un servicio, este debe de ser exento")
                'End If

            End If
            ''Validad si el producto no tiene marcado solicita cantidad y si esta marcado Calcula Cantidad
            'If Not ChkSolicitaCantidad.Checked And ChkCalculaCantidad.Checked Then
            '    VerificaMensaje("Si el producto no esta marcado con Solicita Cantidad, NO es posible marcar Calcula Cantidad")
            'End If

            'Valida códigos equivalentes
            For Each Item As ListViewItem In LvwEquivalentes.Items
                If Not VerificaCodigoEquivalente(Item.Text, False) Then
                    VerificaMensaje("Verifique los códigos equivalentes")
                End If
            Next

            If Not _Nuevo AndAlso ChkLote.Checked Then
                ArticuloBodegaTmp.Art_Id = TxtCodigo.Text.Trim()
                Mensaje = ArticuloBodegaTmp.TieneSaldo()
                If Mensaje <> String.Empty Then
                    VerificaMensaje("No se puede definir el articulo que tiene control de lotes, antes debe de dejar la existencia en cero: " & Mensaje)
                End If
            End If


            'If Not ChkExentoIC.Checked And Not TxtPorcImpuestoConsumo.Text = "" And Not IsNumeric(TxtPorcImpuestoConsumo.Text(0)) And Not IsNumeric(TxtPorcImpuestoConsumo.Text(TxtPorcImpuestoConsumo.Text.Length - 1)) Then
            '    VerificaMensaje("El porcentaje de impuesto de consumo no es valido")
            'End If


            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Guardar()
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim ArticuloEquivalente As TArticuloEquivalente = Nothing
        Dim ArticuloConjunto As TArticuloConjunto = Nothing
        Dim ArticuloImpuesto As TArticuloImpuesto = Nothing
        Dim Mensaje As String = ""
        Try

            With Articulo
                .Art_Id = TxtCodigo.Text.Trim
                .Nombre = UCase(DepuraTexto(TxtNombre.Text.Trim))
                .Cat_Id = CmbCategoria.SelectedValue
                .SubCat_Id = CmbSubCategoria.SelectedValue
                .Departamento_Id = CmbDepartamento.SelectedValue
                .UnidadMedida_Id = CmbUnidadMedida.SelectedValue
                .TipoAcumulacion_Id = CmbTipoAcumulacion.SelectedValue
                .FactorConversion = CInt(TxtFactorConversion.Text)
                .ExentoIV = ChkExento.Checked
                .Suelto = ChkSuelto.Checked
                .ArtPadre = TxtCodigoPadre.Text
                .SolicitarCantidad = ChkSolicitaCantidad.Checked
                .CalculaCantidadFactura = ChkCalculaCantidad.Checked
                .PermiteFacturar = ChkPermiteFacturar.Checked
                .CodigoCantidad = ChkCantidadEtiqueta.Checked
                .Activo = ChkActivo.Checked
                .BusquedaRapida = ChkBusquedaRapida.Checked
                .Frecuente = ChkArticuloFrecuente.Checked
                .Servicio = ChkServicio.Checked
                .Compuesto = ChkCompuesto.Checked
                .CuentaIngreso = TxtCuentaContable.Text.Trim
                .Anotaciones = DepuraTexto(TxtAnotaciones.Text.Trim)
                .CodigoProveedor = TxtCodProveedor.Text.Trim
                .CodigoInterno = TxtCodInterno.Text.Trim
                .UltimaModificacion = Now
                .PorcIC = 0
                .ExentoIC = True
                .Lote = ChkLote.Checked
                .Garantia = ChkGarantia.Checked
                .CodigoCabys = Txbcabys.Text.Trim
                .CabysDescripcion = cabysDescripcion
                .CabysTarifa = Tarifa
                If Not ChkCompuesto.Checked Then
                    .SaldoPropio = True
                Else
                    .SaldoPropio = ChkSaldoPropio.Checked
                End If

                If ChkCantidadEtiqueta.Checked Then
                    .CodigoCantidadTipo = CmbCodigoCantidadTipo.SelectedIndex
                Else
                    .CodigoCantidadTipo = -1
                End If

                For Each Item As ListViewItem In LvwEquivalentes.Items
                    ArticuloEquivalente = New TArticuloEquivalente(EmpresaInfo.Emp_Id)
                    With ArticuloEquivalente
                        .Art_Id = TxtCodigo.Text
                        .ArtEquivalente_Id = Item.Text
                    End With
                    .ListaEquivalentes.Add(ArticuloEquivalente)
                Next

                For Each Item As ListViewItem In LvwConjuntos.Items
                    ArticuloConjunto = New TArticuloConjunto(EmpresaInfo.Emp_Id)
                    With ArticuloConjunto
                        .Art_Id = TxtCodigo.Text
                        .ArtConjunto_Id = Item.SubItems(0).Text
                        .Cantidad = Item.SubItems(2).Text
                    End With
                    .ListaConjuntos.Add(ArticuloConjunto)
                Next


                For Each Item As ListViewItem In LvwImpuesto.Items
                    If Item.ImageIndex = 0 Then
                        ArticuloImpuesto = New TArticuloImpuesto(EmpresaInfo.Emp_Id)
                        With ArticuloImpuesto
                            .Art_Id = TxtCodigo.Text
                            .Codigo_Id = Item.SubItems(EnumImpuestoColumnas.ImpuestoCodigo).Text
                            .Tarifa_Id = Item.SubItems(EnumImpuestoColumnas.Tarifa_Id).Text
                            .Porcentaje = Item.SubItems(EnumImpuestoColumnas.Porcentaje).Text
                        End With
                        .ArticuloImpuesto.Add(ArticuloImpuesto)
                    End If
                Next
            End With

            If _Nuevo Then
                Mensaje = Articulo.Insert()
            Else
                Mensaje = Articulo.Modify()
            End If
            VerificaMensaje(Mensaje)

            If _Nuevo Then
                GuardaArticuloBodegas()
                CargaBodegasArticulo(TxtCodigo.Text.Trim)
                PanelGeneral3.Enabled = True
                BtnCosto.Enabled = True
                BtnPrecios.Enabled = True
                BtnConsulta.Enabled = True
                BtnReceta.Enabled = ChkCompuesto.Checked
                BtnProveedor.Enabled = True
                BtnEliminar.Enabled = True
                _Nuevo = False
                'Else
                '    Inicializa()
            End If

            MsgBox("Los cambios se guardaron de manera exitosa", MsgBoxStyle.Information, Me.Text)

            ChkSaldoPropio.Enabled = False
            ChkCompuesto.Enabled = False

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Articulo = Nothing
        End Try
    End Sub

    Private Sub GuardaArticuloBodegas()
        Dim Bodega As New TBodega(EmpresaInfo.Emp_Id)
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            Bodega.Suc_Id = 0
            Mensaje = Bodega.List()
            VerificaMensaje(Mensaje)

            For Each FilaBodega As DataRow In Bodega.Data.Tables(0).Rows()
                With ArticuloBodega
                    .Emp_Id = FilaBodega("Emp_Id")
                    .Suc_Id = FilaBodega("Suc_Id")
                    .Bod_Id = FilaBodega("Bod_Id")
                    .Art_Id = TxtCodigo.Text.Trim
                    .Saldo = 0.0
                    .CostoPromedio = 0.0
                    .Costo = 0.0
                    .Margen = 0.0
                    .Precio = 0.0
                    .FechaIniDescuento = #1/1/1900#
                    .FechaFinDescuento = #1/1/1900#
                    .PorcDescuento = 0.0
                    .FechaUltimaVenta = #1/1/1900#
                    .PromedioVenta = 0.0
                    .Minimo = 0.0
                    .Maximo = 0.0
                    .Activo = -1
                    .UltimaModificacion = #1/1/1900#
                End With
                Mensaje = ArticuloBodega.Insert()
                VerificaMensaje(Mensaje)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Bodega = Nothing
            ArticuloBodega = Nothing
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
#End Region
#Region "Eventos Forma"
    Private Sub CmbCategoria_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbCategoria.SelectedIndexChanged
        Dim SubCategoria As New TSubCategoria(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            If CmbCategoria.SelectedValue Is Nothing OrElse CmbCategoria.SelectedValue.ToString = "System.Data.DataRowView" Then
                Exit Sub
            End If

            SubCategoria.Cat_Id = CmbCategoria.SelectedValue
            Mensaje = SubCategoria.LoadComboBox(CmbSubCategoria)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            SubCategoria = Nothing
        End Try
    End Sub
    Private Sub ChkSuelto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkSuelto.CheckedChanged
        TxtCodigoPadre.Enabled = ChkSuelto.Checked
        TxtNombrePadre.Enabled = ChkSuelto.Checked
    End Sub
    Private Sub TxtCodigoPadre_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoPadre.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Dim Forma As New FrmBuscaArticuloOnLine
                Forma.Execute()
                If Forma.Art_Id.Trim <> "" Then
                    TxtCodigoPadre.Text = Forma.Art_Id.Trim
                    If ValidaArticuloPadre(Forma.Art_Id.Trim) Then
                        TxtCodigoEquivalente.Focus()
                    Else
                        TxtCodigoPadre.SelectAll()
                        TxtCodigoPadre.Focus()
                    End If
                End If
                Forma = Nothing
            Case Keys.Enter
                If TxtCodigoPadre.Text.Trim <> "" Then
                    ValidaArticuloPadre(TxtCodigoPadre.Text.Trim)
                    If ValidaArticuloPadre(TxtCodigoPadre.Text.Trim) Then
                        TxtCodigoEquivalente.Focus()
                    Else
                        TxtCodigoPadre.SelectAll()
                        TxtCodigoPadre.Focus()
                    End If
                End If
        End Select
    End Sub
    Private Sub TxtCodigoPadre_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCodigoPadre.TextChanged
        TxtNombrePadre.Text = ""
    End Sub
    Private Sub BtnEquivalenteAgregar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEquivalenteAgregar.Click
        Try
            If Not VerificaCodigoEquivalente(TxtCodigoEquivalente.Text.Trim, True) Then
                TxtCodigoEquivalente.SelectAll()
                TxtCodigoEquivalente.Focus()
                Exit Sub
            End If

            Dim Item As New ListViewItem(TxtCodigoEquivalente.Text.Trim)
            Item.Tag = TxtCodigoEquivalente.Text.Trim

            LvwEquivalentes.Items.Add(Item)

            TxtCodigoEquivalente.Text = ""

            Item.EnsureVisible()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub TxtCodigoEquivalente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoEquivalente.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                BtnEquivalenteAgregar_Click(Nothing, EventArgs.Empty)
        End Select
    End Sub
    Private Sub BtnEquivalenteEliminar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEquivalenteEliminar.Click
        Try
            If LvwEquivalentes.SelectedItems Is Nothing OrElse LvwEquivalentes.SelectedItems.Count = 0 Then
                LvwEquivalentes.Focus()
                VerificaMensaje("Debe de seleccionar un item")
            End If

            LvwEquivalentes.Items.Remove(LvwEquivalentes.SelectedItems(0))

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub BtnAgregarConjunto_Click(sender As System.Object, e As System.EventArgs) Handles BtnAgregarConjunto.Click
        Dim Item As ListViewItem = Nothing
        Dim Items(2) As String
        Try
            If Not VerificaCodigoConjunto(TxtCodigoConjunto.Text.Trim) Then
                Exit Sub
            End If


            Items(0) = TxtCodigoConjunto.Text.Trim
            Items(1) = TxtNombreConjunto.Text
            Items(2) = TxtCantidadConjunto.Text

            Item = New ListViewItem(Items)
            Item.Tag = TxtCodigoConjunto.Text.Trim

            LvwConjuntos.Items.Add(Item)

            TxtCodigoConjunto.Text = ""
            TxtCantidadConjunto.Text = ""
            TxtCodigoConjunto.Focus()

            Item.EnsureVisible()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub TxtCodigoConjunto_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoConjunto.KeyDown
        Dim Resutado As String = ""
        Select Case e.KeyCode
            Case Keys.F1
                Dim Forma As New FrmBuscaArticuloOnLine
                Forma.Execute()
                If Forma.Art_Id.Trim <> "" Then
                    TxtCodigoConjunto.Text = Forma.Art_Id.Trim
                    Resutado = ValidaArticuloConjunto(Forma.Art_Id.Trim)
                    If Resutado <> coErrorArticulo Then
                        TxtNombreConjunto.Text = Resutado
                        TxtCantidadConjunto.Text = "1"
                        TxtCantidadConjunto.Focus()
                    Else
                        TxtCodigoConjunto.SelectAll()
                        TxtCodigoConjunto.Focus()
                    End If
                End If
                Forma = Nothing
            Case Keys.Enter
                If TxtCodigoConjunto.Text.Trim <> "" Then
                    Resutado = ValidaArticuloConjunto(TxtCodigoConjunto.Text.Trim)
                    If Resutado <> coErrorArticulo Then
                        TxtNombreConjunto.Text = Resutado
                        TxtCantidadConjunto.Text = "1"
                        TxtCantidadConjunto.Focus()
                    Else
                        TxtCodigoConjunto.SelectAll()
                        TxtCodigoConjunto.Focus()
                    End If
                End If
        End Select
    End Sub
    Private Sub TxtCodigoConjunto_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCodigoConjunto.TextChanged
        TxtNombreConjunto.Text = ""
        TxtCantidadConjunto.Text = ""
    End Sub
    Private Sub TxtCantidadConjunto_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCantidadConjunto.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If TxtCantidadConjunto.Text.Trim = "" Then
                    Exit Sub
                End If
                BtnAgregarConjunto_Click(Nothing, EventArgs.Empty)
        End Select
    End Sub
    Private Sub BtnEliminarConjunto_Click(sender As System.Object, e As System.EventArgs) Handles BtnEliminarConjunto.Click
        Try
            If LvwConjuntos.SelectedItems Is Nothing OrElse LvwConjuntos.SelectedItems.Count = 0 Then
                LvwConjuntos.Focus()
                VerificaMensaje("Debe de seleccionar un item")
            End If

            LvwConjuntos.Items.Remove(LvwConjuntos.SelectedItems(0))

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
                    CargaDatos()
                End If
                Forma = Nothing
            Case Keys.Enter
                If TxtCodigo.Text.Trim <> "" Then
                    CargaDatos()
                End If
        End Select
    End Sub
    Private Sub FrmMantArticulo_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If Not _Activo Then
            _Activo = True
            TxtCodigo.Focus()
        End If
    End Sub
    Private Sub BtnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpiar.Click
        Inicializa()
    End Sub
    Private Sub BtnAgregarBodega_Click(sender As System.Object, e As System.EventArgs) Handles BtnAgregarBodega.Click
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            If TrwBodegas.SelectedNode Is Nothing OrElse TrwBodegas.SelectedNode.ImageIndex <> 2 Then
                MsgBox("Debe de seleccionar una bodega", MsgBoxStyle.Information, Me.Text)
                BtnAgregarBodega.Enabled = False
                Exit Sub
            End If

            If MsgBox("Desea incluir el artículo en la bodega " & TrwBodegas.SelectedNode.Text & " de la sucursal " & TrwBodegas.SelectedNode.Parent.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            With ArticuloBodega
                .Suc_Id = CInt(TrwBodegas.SelectedNode.Parent.Tag)
                .Bod_Id = CInt(TrwBodegas.SelectedNode.Tag)
                .Art_Id = TxtCodigo.Text.Trim
            End With
            Mensaje = ArticuloBodega.Insert()
            VerificaMensaje(Mensaje)


            TrwBodegas.SelectedNode.ForeColor = Color.Blue

            BtnAgregarBodega.Enabled = False
            TrwBodegas.SelectedNode = TrwBodegas.Nodes(0)
            TrwBodegas.Refresh()


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloBodega = Nothing
        End Try
    End Sub
    Private Sub TrwBodegas_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles TrwBodegas.AfterSelect
        BtnAgregarBodega.Enabled = (e.Node.ImageIndex = 2 And e.Node.ForeColor <> Color.Blue)
    End Sub
    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            If Not ValidaDatos() Then
                Exit Sub
            End If

            Guardar()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Articulo = Nothing
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
    Private Sub ChkCantidadEtiqueta_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkCantidadEtiqueta.CheckedChanged
        CmbCodigoCantidadTipo.Enabled = ChkCantidadEtiqueta.Checked
    End Sub
#End Region
    'Private Sub AplicaBodegasChequeadas(pNodo As TreeNode)
    '    If pNodo.Nodes.Count = 0 Then
    '        If pNodo.ImageIndex = 2 And pNodo.ForeColor = Color.Blue And pNodo.Checked Then
    '            MsgBox(pNodo.Parent.Text & " - " & pNodo.Text)
    '        End If
    '    Else
    '        For Each Nodo As TreeNode In pNodo.Nodes
    '            AplicaBodegasChequeadas(Nodo)
    '        Next
    '    End If
    'End Sub

    'Private Sub TrwBodegas_BeforeCheck(sender As Object, e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TrwBodegas.BeforeCheck
    '    If e.Node.ForeColor <> Color.Blue Then
    '        e.Cancel = True
    '    End If
    'End Sub

    'Private Sub DesChekeaNodos(pNodo As TreeNode)
    '    If pNodo.Nodes.Count = 0 Then
    '        If pNodo.Checked And pNodo.ForeColor <> Color.Blue Then
    '            pNodo.Checked = False
    '        End If
    '    Else
    '        For Each Nodo As TreeNode In pNodo.Nodes
    '            DesChekeaNodos(Nodo)
    '            If Nodo.Checked And Nodo.ForeColor <> Color.Blue Then
    '                Nodo.Checked = False
    '            End If
    '        Next
    '    End If
    'End Sub


    Private Sub BtnPrecios_Click(sender As System.Object, e As System.EventArgs) Handles BtnPrecios.Click
        Dim Forma As New FrmArticuloBodega
        Dim ArticuloImpuesto As New TArticuloImpuesto(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.InvAccesoPrecio, False) Then
                VerificaMensaje("No tiene permiso para acceder a precios.")
            End If

            Forma.Art_Id = TxtCodigo.Text
            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnCosto_Click(sender As System.Object, e As System.EventArgs) Handles BtnCosto.Click
        Dim Forma As New FrmAjusteCosto
        Try
            If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.InvAccesoCosto, False) Then
                VerificaMensaje("No tiene permiso para acceder a costo.")
            End If

            Forma.Art_Id = TxtCodigo.Text
            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEliminar.Click
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Try

            If MsgBox("Desea eliminar el artículo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            ArticuloBodega.Art_Id = TxtCodigo.Text
            VerificaMensaje(ArticuloBodega.EliminaArticulo)

            BtnLimpiar.PerformClick()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloBodega = Nothing
        End Try
    End Sub

    Private Sub BtnProveedor_Click(sender As System.Object, e As System.EventArgs) Handles BtnProveedor.Click
        Dim Forma As New FrmMantArticuloProveedor
        Try

            Forma.Art_Id = TxtCodigo.Text
            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub TxtCuentaContable_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCuentaContable.KeyDown
        Dim Resultado As String = ""
        Try

            Select Case e.KeyCode
                Case Keys.F1
                    Resultado = BusquedaCuentaContable()
                    If Resultado.Trim <> String.Empty Then
                        TxtCuentaContable.Text = Resultado.Trim
                    End If
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmMantArticuloDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnGuardar.PerformClick()
            Case Keys.F4
                BtnLimpiar.PerformClick()
            Case Keys.F5
                BtnCosto.PerformClick()
            Case Keys.F6
                BtnPrecios.PerformClick()
            Case Keys.F7
                BtnProveedor.PerformClick()
            Case Keys.F8
                BtnEliminar.PerformClick()
            Case Keys.F9
                BtnReceta.PerformClick()
            Case Keys.F10
                BtnConsulta.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub ChkCompuesto_CheckedChanged(sender As Object, e As EventArgs) Handles ChkCompuesto.CheckedChanged
        Try
            If ChkCompuesto.Checked Then
                ChkSaldoPropio.Enabled = True
            Else
                ChkSaldoPropio.Enabled = False
                ChkSaldoPropio.Checked = True
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnReceta_Click(sender As Object, e As EventArgs) Handles BtnReceta.Click
        Dim Forma As New FrmMantRecetaDetalle
        Dim Mensaje As String = ""
        Try

            If VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.InvModificaReceta, True) Then
                Forma.Titulo = "Receta : " & UCase(TxtNombre.Text.Trim)
                Forma.Execute(TxtCodigo.Text)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try

    End Sub

    Private Sub BtnConsulta_Click(sender As Object, e As EventArgs) Handles BtnConsulta.Click
        Dim forma As New FrmConsultaArticulo()
        Try
            forma.Execute(TxtCodigo.Text)
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCodProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodProveedor.KeyDown

        Dim forma As New FrmBusquedaProveedor()
        If e.KeyCode = Keys.F1 Then
            forma.Execute()
            If forma.Selecciono Then
                TxtCodProveedor.Text = forma.Prov_Id
            End If
        End If
    End Sub


    Private Sub ChkExento_CheckedChanged(sender As Object, e As EventArgs) Handles ChkExento.CheckedChanged
        LvwImpuesto.Enabled = Not ChkExento.Checked

        If ChkExento.Checked Then

            If LvwImpuesto.Items.Count() > 0 Then
                If MsgBox("El artículo posee impuestos, desea cambiarlo a exento? Se borrarán los impuestos asignados a este artículo.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                    ' If VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.InvAplicaAjusteProduccion, True) Then

                    LvwImpuesto.Items.Clear()

                    ' End If
                Else
                    ChkExento.Checked = False
                End If
            End If

        Else
            CargaImpuestos(TxtCodigo.Text)
        End If
    End Sub

    Private Sub LvwImpuesto_KeyDown(sender As Object, e As KeyEventArgs) Handles LvwImpuesto.KeyDown
        Try

            If LvwImpuesto.SelectedItems Is Nothing Then
                VerificaMensaje("Debe de seleccionar un impuesto")
            End If

            If LvwImpuesto.SelectedItems(0).ImageIndex = 0 Then
                With LvwImpuesto.SelectedItems(0)
                    .ImageIndex = -1
                    .SubItems(EnumImpuestoColumnas.Tarifa).Text = "Ninguna"
                    .SubItems(EnumImpuestoColumnas.Tarifa_Id).Text = "00"
                    .SubItems(EnumImpuestoColumnas.Porcentaje).Text = "0.00"
                End With

            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub EliminaImpuesto()
        Try
            For i As Integer = LvwImpuesto.SelectedItems.Count - 1 To 0 Step -1
                LvwImpuesto.SelectedItems(i).Remove()
            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LvwImpuesto_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LvwImpuesto.MouseDoubleClick
        Dim forma As New FrmMantArticuloImpuestoTarifaPorcentaje()
        Try


            If LvwImpuesto.SelectedItems(0).SubItems(EnumImpuestoColumnas.ImpuestoCodigo).Text = "01" OrElse
                           LvwImpuesto.SelectedItems(0).SubItems(EnumImpuestoColumnas.ImpuestoCodigo).Text = "07" OrElse
                           LvwImpuesto.SelectedItems(0).SubItems(EnumImpuestoColumnas.ImpuestoCodigo).Text = "08" Then

                Dim CodigoSeleccionado As String = LvwImpuesto.SelectedItems(0).SubItems(EnumImpuestoColumnas.ImpuestoCodigo).Text

                For Each item As ListViewItem In LvwImpuesto.Items
                    If CodigoSeleccionado <> item.SubItems(EnumImpuestoColumnas.ImpuestoCodigo).Text Then
                        If item.SubItems(EnumImpuestoColumnas.ImpuestoCodigo).Text = "01" And Double.Parse(item.SubItems(EnumImpuestoColumnas.Porcentaje).Text) > 0 Then
                            VerificaMensaje("Ya posee un impuesto de tipo IVA asignado ")
                            Exit For
                        End If

                        If item.SubItems(EnumImpuestoColumnas.ImpuestoCodigo).Text = "07" And Double.Parse(item.SubItems(EnumImpuestoColumnas.Porcentaje).Text) > 0 Then
                            VerificaMensaje("Ya posee un impuesto de tipo IVA asignado ")
                            Exit For
                        End If

                        If item.SubItems(EnumImpuestoColumnas.ImpuestoCodigo).Text = "08" And Double.Parse(item.SubItems(EnumImpuestoColumnas.Porcentaje).Text) > 0 Then
                            VerificaMensaje("Ya posee un impuesto de tipo IVA asignado ")
                            Exit For
                        End If
                    End If
                Next
            End If

            forma.PoseeTarifa = LvwImpuesto.SelectedItems(0).SubItems(EnumImpuestoColumnas.PoseeTarifa).Text
            forma.PermiteModificar = LvwImpuesto.SelectedItems(0).SubItems(EnumImpuestoColumnas.PermiteModificar).Text
            forma.Porcentaje = LvwImpuesto.SelectedItems(0).SubItems(EnumImpuestoColumnas.Porcentaje).Text
            forma.Tarifa = LvwImpuesto.SelectedItems(0).SubItems(EnumImpuestoColumnas.Tarifa_Id).Text

            forma.Execute()

            If forma.CerroVentana Then
                Dim tarifa As New TImpuestoTarifa()
                VerificaMensaje(tarifa.List())

                For Each registro As DataRow In tarifa.Data.Tables(0).Rows
                    If forma.Tarifa = registro.Item("Tarifa_Id") Then
                        LvwImpuesto.SelectedItems(0).SubItems(EnumImpuestoColumnas.Tarifa).Text = registro.Item("Nombre")
                        Exit For
                    End If
                Next

                LvwImpuesto.SelectedItems(0).SubItems(EnumImpuestoColumnas.Tarifa_Id).Text = forma.Tarifa
                LvwImpuesto.SelectedItems(0).SubItems(EnumImpuestoColumnas.Porcentaje).Text = forma.Porcentaje.ToString("##0.00")
                LvwImpuesto.SelectedItems(0).ImageIndex = 0

            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            forma = Nothing
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCABYS.Click
        buscarCabys()
    End Sub

    Private Sub buscarCabys()
        Dim Forma As New FrmCabys
        Try

            Forma.Execute()

            If Forma.Selecciono Then
                Codigo = Forma.Codigo
                Descripcion = Forma.Descripcion
                Tarifa = Forma.Tarifa
                Txbcabys.Text = Codigo
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub Txbcabys_TextChanged(sender As Object, e As EventArgs) Handles Txbcabys.TextChanged

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub

    'Private Sub ChkExentoIC_CheckedChanged(sender As Object, e As EventArgs)
    '    LblPorcIC.Visible = Not ChkExentoIC.Checked
    '    TxtPorcImpuestoConsumo.Visible = Not ChkExentoIC.Checked
    'End Sub

    'Private Sub ChkLote_CheckedChanged(sender As Object, e As EventArgs)
    '    If ChkServicio.Checked And ChkLote.Checked Then
    '        MensajeError("Un servicio no puede manejar lotes")
    '        ChkLote.Checked = False
    '    End If
    'End Sub
End Class