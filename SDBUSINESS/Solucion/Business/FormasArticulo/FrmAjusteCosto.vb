Imports Business
Imports System.Windows.Forms
Public Class FrmAjusteCosto
    Dim Numerico() As TNumericFormat
    Dim _Cargando As Boolean = False
    Dim _Art_Id As String
    Dim _Costo As Double = 0
    Dim _Activado As Boolean

    Public WriteOnly Property Art_Id As String
        Set(value As String)
            _Art_Id = value
        End Set
    End Property
    Public WriteOnly Property Costo As Double
        Set(value As Double)
            _Costo = value
        End Set
    End Property


    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtCostoNuevo, 8, 2, False, "0", "#,##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub CargaCombos()
        Dim Bodega As New TSucursal(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            Bodega.Suc_Id = SucursalInfo.Suc_Id
            Mensaje = Bodega.LoadComboBox(CmbSucursal)
            VerificaMensaje(Mensaje)

            GroupBodega.Enabled = True
            CmbSucursal.Focus()


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Bodega = Nothing
        End Try
    End Sub

    Private Sub Inicializa()
        TxtCodigo.Enabled = True
        TxtCodigo.Text = ""
        LblNombreArticulo.Text = ""
        LblExento.Text = ""

        CmbSucursal.SelectedIndex = -1
        GroupBodega.Enabled = False
        GroupPrecio.Enabled = False

        BtnGuardar.Enabled = False
        BtnLimpiar.Enabled = False

        ChkTodas.Checked = False
        LimpiaInformacionBodega()
    End Sub

    Public Sub Execute()
        Try
            _Activado = False
            _Cargando = True
            LblSucursal.Text = SucursalInfo.Nombre
            CargaCombos()
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
        Dim Mensaje As String = ""
        Try

            Articulo.Art_Id = TxtCodigo.Text.Trim
            Mensaje = Articulo.ListKey()
            VerificaMensaje(Mensaje)

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

            GroupBodega.Enabled = True
            BtnGuardar.Enabled = True
            BtnLimpiar.Enabled = True

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Articulo = Nothing
        End Try
    End Sub

    Private Sub BtnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpiar.Click
        Inicializa()
        TxtCodigo.Focus()
    End Sub

    Private Sub LimpiaInformacionBodega()
        TxtCosto.Text = ""
        TxtCostoNuevo.Text = ""

    End Sub

    Private Sub CmbSucursal_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbSucursal.SelectedIndexChanged
        Try
            LimpiaInformacionBodega()

            If _Cargando OrElse CmbSucursal.SelectedValue Is Nothing Then
                Exit Sub
            End If
            CargaInformacionSucursal()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaInformacionSucursal()
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            With ArticuloBodega
                .Suc_Id = CmbSucursal.SelectedValue
                .Art_Id = TxtCodigo.Text.Trim
            End With

            Mensaje = ArticuloBodega.ListKey1()
            VerificaMensaje(Mensaje)

            If ArticuloBodega.RowsAffected = 0 Then
                LimpiaInformacionBodega()
                GroupPrecio.Enabled = False
                Exit Sub
            Else
                GroupPrecio.Enabled = True
            End If

            With ArticuloBodega
                TxtCosto.Text = Format(.Costo, "#,##0.00")


                If _Art_Id <> "" AndAlso _Costo > 0 Then
                    TxtCostoNuevo.Text = Format(_Costo, "#,##0.00")
                Else
                    TxtCostoNuevo.Text = Format(.Costo, "#,##0.00")
                End If
                TxtCostoNuevo.SelectAll()
                TxtCostoNuevo.Focus()

                ChkTodas.Checked = True
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub



    Private Function ValidaTodo() As Boolean
        Try
            If Not IsNumeric(TxtCostoNuevo.Text) OrElse CDbl(TxtCostoNuevo.Text) < 0 Then
                TxtCostoNuevo.SelectAll()
                TxtCostoNuevo.Focus()
                VerificaMensaje("El costo debe de ser mayor o igual a cero")
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
                If MsgBox("Desea cambiar el costo del artículo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                    If VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.InvAplicaAjusteCosto, True) Then
                        Guardar()
                    End If
                End If
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Guardar()
        Dim ArticuloSucursal As New TArticuloBodega(SucursalInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            With ArticuloSucursal
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = CmbSucursal.SelectedValue
                .Art_Id = TxtCodigo.Text.Trim
                .Costo = CDbl(TxtCostoNuevo.Text)
            End With
            Mensaje = ArticuloSucursal.CrearAjusteCosto(ChkTodas.Checked, UsuarioInfo.Usuario_Id)
            VerificaMensaje(Mensaje)

            MsgBox("Los cambios se guardaron con éxito", MsgBoxStyle.Information, Me.Text)

            Inicializa()
            TxtCodigo.Focus()

            If _Art_Id <> String.Empty Then
                Me.Close()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloSucursal = Nothing
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub TxtCostoNuevo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCostoNuevo.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If IsNumeric(TxtCostoNuevo.Text) And BtnGuardar.Enabled Then
                    BtnGuardar_Click(BtnGuardar, EventArgs.Empty)
                End If

        End Select
    End Sub

    Private Sub TxtCostoNuevo_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCostoNuevo.TextChanged

    End Sub

    Private Sub FrmAjusteCosto_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnGuardar.PerformClick()
            Case Keys.F4
                BtnLimpiar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub
End Class