Imports BUSINESS
Public Class FrmMantProveedorCuentaLista
#Region "Variables"
    Private coTitulo = "Asignación de Cuentas"
    Private Numerico() As TNumericFormat
    Private _Prov_Id As Integer = 0
#End Region
#Region "Propiedades"
    Public WriteOnly Property Prov_Id As Integer
        Set(value As Integer)
            _Prov_Id = value
        End Set
    End Property
#End Region
#Region "Funciones Privadas"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtNumero, 4, 0, False, "", "###")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Public Sub Execute()
        Me.Text = coTitulo
        LblTitulo.Text = coTitulo
        Inicializa()
        Me.ShowDialog()
    End Sub

    Private Sub Inicializa()
        Try
            BtnLimpiar.Enabled = False
            TxtNumero.ReadOnly = False
            TxtNumero.Text = ""
            TxtCriterio.Text = ""
            HabilitaBotonesOpciones(False)
            GroupLista.Enabled = False
            DGDetalle.DataSource = Nothing
            DGDetalle.Rows.Clear()
            If _Prov_Id <> 0 Then
                TxtNumero.Text = _Prov_Id
                VerificaMensaje(CargaProveedor)
                BtnLimpiar.Enabled = False
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub HabilitaBotonesOpciones(pActivo As Boolean)
        BtnNuevo.Enabled = pActivo
        BtnModificar.Enabled = pActivo
        BtnEliminar.Enabled = pActivo
        BtnRefrescar.Enabled = pActivo
    End Sub

    Private Sub BuscaProveedor()
        Dim Forma As New FrmBusquedaProveedor

        Try
            Forma.Execute()

            If Forma.Selecciono Then
                TxtNumero.Text = Forma.Prov_Id
                VerificaMensaje(CargaProveedor)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Function CargaProveedor() As String
        Dim Proveedor As New TProveedor

        Try
            If TxtNumero.Text.Trim = "" Then
                Return String.Empty
            End If

            With Proveedor
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = CInt(TxtNumero.Text.Trim)
            End With
            VerificaMensaje(Proveedor.ListKey)

            If Proveedor.RowsAffected = 0 Then
                EnfocarTexto(TxtNumero)
                VerificaMensaje("No se encontró un proveedor con el código: " & TxtNumero.Text.Trim)
            End If

            If Not Proveedor.Activo Then
                EnfocarTexto(TxtNumero)
                VerificaMensaje("El proveedor " & Proveedor.Nombre & " se encuentra inactivo")
            End If

            TxtNombre.Text = Proveedor.Nombre
            TxtNumero.ReadOnly = True
            BtnLimpiar.Enabled = True
            GroupLista.Enabled = True
            HabilitaBotonesOpciones(True)
            Refrescar()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Proveedor = Nothing
        End Try
    End Function

    Private Sub Refrescar()
        Dim ProveedorCuenta As New TProveedorCuenta

        Try
            DGDetalle.DataSource = Nothing

            With ProveedorCuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = CInt(TxtNumero.Text.Trim)
            End With
            VerificaMensaje(ProveedorCuenta.ListMant(TxtCriterio.Text.Trim))

            DGDetalle.DataSource = ProveedorCuenta.Datos.Tables(0)
            DGDetalle.Columns(0).HeaderText = "Cuenta"
            DGDetalle.Columns(1).HeaderText = "Banco"
            DGDetalle.Columns(2).HeaderText = "Cuenta"
            DGDetalle.Columns(3).HeaderText = "Moneda"
            DGDetalle.Columns(0).Width = 80
            DGDetalle.Columns(1).Width = 300
            DGDetalle.Columns(2).Width = 120
            DGDetalle.Columns(3).Width = 80

            BtnModificar.Enabled = (DGDetalle.RowCount > 0)
            BtnEliminar.Enabled = (DGDetalle.RowCount > 0)
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ProveedorCuenta = Nothing
        End Try
    End Sub

    Private Sub CreaProveedor()
        Dim Forma As New FrmMantProveedorLista

        Try
            With Forma
                .SalirAlGuardar = True
                .Execute()
            End With

            If Forma.GuardoCambios AndAlso Not TxtNumero.ReadOnly Then
                If Forma.ProveedorNuevo <> 0 Then
                    TxtNumero.Text = Forma.ProveedorNuevo
                    VerificaMensaje(CargaProveedor)
                End If
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub ModificaProveedor()
        Dim Forma As New FrmMantProveedorDetalle
        Dim Codigo As Integer = -1

        Try
            Codigo = CInt(TxtNumero.Text.Trim)

            With Forma
                .Titulo = "Proveedor"
                .Nuevo = False
                .Execute(Codigo)
            End With

            If Forma.GuardoCambios Then
                VerificaMensaje(CargaProveedor)
            End If

        Catch ex As Exception
            MensajeError(ex.Message, "Mantenimiento")
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub Nuevo()
        Dim Forma As New FrmMantProveedorCuentaDetalle

        Try
            With Forma
                .Titulo = coTitulo
                .Nuevo = True
                .Prov_Id = CInt(TxtNumero.Text.Trim)
                .Cuenta_Id = -1
                .Execute()
            End With

            If Forma.GuardoCambios Then
                Refrescar()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub Modificar()
        Dim Forma As New FrmMantProveedorCuentaDetalle

        Try
            If DGDetalle.SelectedCells Is Nothing OrElse DGDetalle.SelectedCells.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un registro")
            End If

            With Forma
                .Titulo = coTitulo
                .Nuevo = False
                .Prov_Id = CInt(TxtNumero.Text.Trim)
                .Cuenta_Id = CInt(DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value)
                .Execute()
            End With

            If Forma.GuardoCambios Then
                Refrescar()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub Eliminar()
        Dim ProveedorCuenta As New TProveedorCuenta

        Try
            If DGDetalle.SelectedCells Is Nothing OrElse DGDetalle.SelectedCells.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un registro")
            End If

            If MsgBox("Desea eliminar el registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            With ProveedorCuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = CInt(TxtNumero.Text.Trim)
                .Cuenta_Id = CInt(DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value)
            End With
            VerificaMensaje(ProveedorCuenta.Delete)

            Refrescar()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ProveedorCuenta = Nothing
        End Try
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Nuevo()
    End Sub

    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click
        Modificar()
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Eliminar()
    End Sub

    Private Sub BtnRefrescar_Click(sender As Object, e As EventArgs) Handles BtnRefrescar.Click
        Refrescar()
    End Sub

    Private Sub BtnProveedor_Click(sender As Object, e As EventArgs) Handles BtnProveedor.Click
        If TxtNumero.ReadOnly Then
            ModificaProveedor()
        Else
            CreaProveedor()
        End If
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        Inicializa()
        TxtNumero.Focus()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub TxtCriterio_TextChanged(sender As Object, e As EventArgs) Handles TxtCriterio.TextChanged
        If TxtCriterio.Text.Trim <> "" Then
            PicBorrar.Image = My.Resources.delete
        Else
            PicBorrar.Image = Nothing
        End If

        Refrescar()
    End Sub

    Private Sub PicBorrar_Click(sender As Object, e As EventArgs) Handles PicBorrar.Click
        TxtCriterio.Text = ""
    End Sub

    Private Sub TxtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNumero.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    VerificaMensaje(CargaProveedor)
                Case Keys.F1
                    BuscaProveedor()
                Case Keys.Escape
                    TxtNumero.Text = ""
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub DGDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles DGDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.F2, Keys.Enter
                Modificar()
            Case Keys.Delete
                Eliminar()
        End Select
    End Sub

    Private Sub DGDetalle_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGDetalle.CellContentDoubleClick
        Modificar()
    End Sub

    Private Sub FrmMantProveedorCuentaLista_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                Refrescar()
        End Select
    End Sub

    Private Sub FrmMantProveedorCuentaLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtNumero.Select()
    End Sub

    Private Sub TxtNumero_TextChanged(sender As Object, e As EventArgs) Handles TxtNumero.TextChanged
        TxtNombre.Text = ""
    End Sub

End Class