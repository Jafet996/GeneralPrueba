Imports Business
Public Class FrmCreaArticulo
#Region "Declaracion Variables"
    Dim Numerico() As TNumericFormat
    Private coErrorArticulo = "--ERROR:Articulo--"
    Private _Activo As Boolean = False
    Private _Nuevo As Boolean = True
    Private Enum AccionEnum
        Inicial = 0
        Editando = 1
    End Enum
#End Region
#Region "Metodos Publicos"
    Public Sub Execute()
        FormateaCamposNumericos()
        CargaCombos()

        Inicializa()

        Me.ShowDialog()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub HabilitaBotones(pAccion As AccionEnum)
        Select Case pAccion
            Case AccionEnum.Inicial
                BtnGuardar.Enabled = False
                BtnLimpiar.Enabled = False
                BtnSalir.Enabled = True
            Case AccionEnum.Editando
                BtnGuardar.Enabled = True
                BtnLimpiar.Enabled = True
                BtnSalir.Enabled = True
        End Select
    End Sub
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(1)

            Numerico(0) = New TNumericFormat(TxtFactorConversion, 4, 0, False, "1", "###")
            Numerico(1) = New TNumericFormat(TxtPrecio, 6, 2, False, "1", "##0.00")


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub CargaCombos()
        Dim Categoria As New TCategoria(EmpresaInfo.Emp_Id)
        Dim SubCategoria As New TSubCategoria(EmpresaInfo.Emp_Id)
        Dim Departamento As New TDepartamento(EmpresaInfo.Emp_Id)
        Dim UnidadMedida As New TUnidadMedida(EmpresaInfo.Emp_Id)
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

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Categoria = Nothing
            SubCategoria = Nothing
            Departamento = Nothing
            UnidadMedida = Nothing
        End Try
    End Sub

    Private Sub Inicializa()
        Try
            HabilitaBotones(AccionEnum.Inicial)
            PanelGeneral1.Enabled = False
            TxtCodigo.Enabled = True
            TxtCodigo.Focus()
            _Nuevo = True

            TxtCodigo.Text = ""
            TxtNombre.Text = ""
            If CmbCategoria.Items.Count > 0 Then
                CmbCategoria.SelectedIndex = -1
            End If
            If CmbSubCategoria.Items.Count > 0 Then
                CmbSubCategoria.DataSource = Nothing
                CmbSubCategoria.Items.Clear()
            End If
            If CmbDepartamento.Items.Count > 0 Then
                CmbDepartamento.SelectedIndex = -1
            End If
            If CmbUnidadMedida.Items.Count > 0 Then
                CmbUnidadMedida.SelectedIndex = -1
            End If
            TxtFactorConversion.Text = ""
            ChkExento.Checked = False
            TxtPrecio.Text = ""

            ChkSuelto.Checked = False


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function PrecioArticulo(pArt_Id As String) As Double
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Try

            With ArticuloBodega
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
                .Bod_Id = 1
                .Art_Id = pArt_Id
            End With

            VerificaMensaje(ArticuloBodega.ListKey())

            Return ArticuloBodega.Precio

        Catch ex As Exception
            Return 0
        Finally
            ArticuloBodega = Nothing
        End Try
    End Function


    Private Sub CargaDatos()
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)

        Dim Mensaje As String = ""
        Try

            _Nuevo = True

            If TxtCodigo.Text.Trim = "0" Then
                HabilitaBotones(AccionEnum.Editando)
                PanelGeneral1.Enabled = True
                TxtCodigo.Enabled = False
                TxtNombre.Focus()
            Else
                Articulo.Art_Id = TxtCodigo.Text.Trim
                Mensaje = Articulo.ListKey()
                VerificaMensaje(Mensaje)

                If Articulo.RowsAffected = 0 Then
                    If MsgBox("El código de artículo no existe, Desea crearlo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                        TxtCodigo.SelectAll()
                        TxtCodigo.Focus()
                        Inicializa()
                        Exit Sub
                    End If
                End If

                HabilitaBotones(AccionEnum.Editando)
                PanelGeneral1.Enabled = True
                TxtCodigo.Enabled = False
                TxtNombre.Focus()

                If Articulo.RowsAffected > 0 Then
                    _Nuevo = False
                    With Articulo
                        TxtNombre.Text = QuitaComillas(.Nombre)
                        TxtFactorConversion.Text = .FactorConversion
                        TxtPrecio.Text = Format(PrecioArticulo(TxtCodigo.Text), "###0.00")
                        CmbCategoria.SelectedValue = .Cat_Id
                        CmbSubCategoria.SelectedValue = .SubCat_Id
                        CmbDepartamento.SelectedValue = .Departamento_Id
                        CmbUnidadMedida.SelectedValue = .UnidadMedida_Id

                        ChkExento.Checked = .ExentoIV
                    End With
                    TxtNombre.SelectAll()
                    TxtNombre.Focus()
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Articulo = Nothing
        End Try
    End Sub

    Private Function ValidaDatos() As Boolean
        Try
            If TxtNombre.Text.Trim = "" Then
                TxtNombre.Focus()
                VerificaMensaje("Debe de ingresar un valor")
            End If

            If Not IsNumeric(TxtFactorConversion.Text) OrElse CInt(TxtFactorConversion.Text) < 1 Then
                TabPrincipal.SelectedTab = TabPrincipal.TabPages(0)
                TxtFactorConversion.SelectAll()
                TxtFactorConversion.Focus()
                VerificaMensaje("Debe ingresar el factor de conversión")
            End If

            If Not IsNumeric(TxtPrecio.Text) OrElse CInt(TxtPrecio.Text) < 1 Then
                TabPrincipal.SelectedTab = TabPrincipal.TabPages(0)
                TxtPrecio.SelectAll()
                TxtPrecio.Focus()
                VerificaMensaje("Debe ingresar el Precio")
            End If

            If CmbCategoria.SelectedIndex < 0 OrElse CmbCategoria.SelectedValue Is Nothing Then
                TabPrincipal.SelectedTab = TabPrincipal.TabPages(0)
                CmbCategoria.Focus()
                VerificaMensaje("Debe de seleccionar una categoría")
            End If

            If CmbSubCategoria.SelectedIndex < 0 OrElse CmbSubCategoria.SelectedValue Is Nothing Then
                TabPrincipal.SelectedTab = TabPrincipal.TabPages(0)
                CmbSubCategoria.Focus()
                VerificaMensaje("Debe de seleccionar una sub categoría")
            End If

            If CmbDepartamento.SelectedIndex < 0 OrElse CmbDepartamento.SelectedValue Is Nothing Then
                TabPrincipal.SelectedTab = TabPrincipal.TabPages(0)
                CmbDepartamento.Focus()
                VerificaMensaje("Debe de seleccionar un departamento")
            End If

            If CmbUnidadMedida.SelectedIndex < 0 OrElse CmbUnidadMedida.SelectedValue Is Nothing Then
                TabPrincipal.SelectedTab = TabPrincipal.TabPages(0)
                CmbUnidadMedida.Focus()
                VerificaMensaje("Debe de seleccionar una unidad de medida")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function
    Private Sub Guardar()
        Dim ArticuloTemporal As New TArticuloTemporal(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            With ArticuloTemporal
                .Art_Id = TxtCodigo.Text.Trim
                .Nombre = QuitaComillas(UCase(TxtNombre.Text.Trim))
                .Cat_Id = CmbCategoria.SelectedValue
                .SubCat_Id = CmbSubCategoria.SelectedValue
                .Departamento_Id = CmbDepartamento.SelectedValue
                .UnidadMedida_Id = CmbUnidadMedida.SelectedValue
                .FactorConversion = CInt(TxtFactorConversion.Text)
                .ExentoIV = ChkExento.Checked
                .Precio = CDbl(TxtPrecio.Text)
                .Suelto = ChkSuelto.Checked
                .CodigoManual = (TxtCodigo.Text = "0")
            End With

            Mensaje = ArticuloTemporal.Insert()
            VerificaMensaje(Mensaje)

            'MsgBox("Los cambios se guardaron de manera exitosa", MsgBoxStyle.Information, Me.Text)
            Inicializa()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloTemporal = Nothing
        End Try
    End Sub
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

    Private Sub TxtCodigo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigo.KeyDown
        Select Case e.KeyCode
            'Case Keys.F1
            '    Dim Forma As New FrmBusquedaArticulo
            '    Forma.Execute()
            '    If Forma.Art_Id.Trim <> "" Then
            '        TxtCodigo.Text = Forma.Art_Id.Trim
            '        CargaDatos()
            '    End If
            '    Forma = Nothing
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
        TabPrincipal.SelectedTab = TabPrincipal.TabPages(0)
    End Sub

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            If ValidaDatos() Then
                Guardar()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Articulo = Nothing
        End Try
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

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub TxtFactorConversion_GotFocus(sender As Object, e As System.EventArgs) Handles TxtFactorConversion.GotFocus
        TxtFactorConversion.SelectAll()
    End Sub

    Private Sub TxtNombre_GotFocus(sender As Object, e As System.EventArgs) Handles TxtNombre.GotFocus
        TxtNombre.SelectAll()
    End Sub

    Private Sub TxtPrecio_GotFocus(sender As Object, e As System.EventArgs) Handles TxtPrecio.GotFocus
        TxtPrecio.SelectAll()
    End Sub
    Private Sub FrmCreaArticulo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F11 And Not TxtCodigo.Enabled
                If ValidaDatos() Then
                    Guardar()
                End If
            Case Keys.F12
                Inicializa()
                TxtCodigo.Focus()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub


    Private Sub TxtCodigo_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCodigo.TextChanged

    End Sub

    Private Sub BtnRefrescar_Click(sender As System.Object, e As System.EventArgs) Handles BtnRefrescar.Click
        Try
            CargaCombos()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class