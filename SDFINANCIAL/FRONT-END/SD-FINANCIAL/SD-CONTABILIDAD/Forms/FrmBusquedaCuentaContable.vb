Imports BUSINESS
Public Class FrmBusquedaCuentaContable
#Region "Variables"
    Private _Selecciono As Boolean = False
    Private _Cuenta_Id As String = ""
#End Region
#Region "Propiedades"
    Public ReadOnly Property Selecciono As Boolean
        Get
            Return _Selecciono
        End Get
    End Property
    Public ReadOnly Property Cuenta_Id As String
        Get
            Return _Cuenta_Id
        End Get
    End Property
#End Region

    Public Sub Execute()
        CargaCuentasPadre()
        TabControl1.SelectedIndex = 1
        RdbCuenta.Checked = True
        TxtCriterio.Select()

        Me.ShowDialog()
    End Sub

    Private Sub CargaCuentasPadre()
        Dim Cuenta As New TCuenta

        Try
            Cuenta.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(Cuenta.CreaArbolCuentasPadre(TrwCuentas))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cuenta = Nothing
        End Try
    End Sub

    Private Sub CargaSubCuenta(ByVal pNodo As TreeNode)
        Dim Cuenta As New TCuenta

        Try
            Cuenta.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(Cuenta.CreaArbolCuentasHija(pNodo))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cuenta = Nothing
        End Try
    End Sub

    Private Function ValidaCuenta(pCuenta_Id As String) As String
        Dim Cuenta As New TCuenta

        Try
            With Cuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cuenta_Id = pCuenta_Id
            End With
            VerificaMensaje(Cuenta.ListKey)

            If Cuenta.RowsAffected = 0 Then
                VerificaMensaje("No se encontró la cuenta seleccionada")
            End If

            If Not Cuenta.Activo Then
                VerificaMensaje("La cuenta seleccionada se ecnuetra inactiva")
            End If

            If Not Cuenta.AceptaMovimiento Then
                VerificaMensaje("La cuenta seleccionada no permite movimientos")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Cuenta = Nothing
        End Try
    End Function

    Private Sub Seleccionar()
        Try
            If TrwCuentas.SelectedNode Is Nothing Then
                VerificaMensaje("Debe de seleccionar un cuenta")
            End If

            VerificaMensaje(ValidaCuenta(TrwCuentas.SelectedNode.Tag.ToString))

            _Cuenta_Id = TrwCuentas.SelectedNode.Tag.ToString
            _Selecciono = True

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Buscar()
        Dim Cuenta As New TCuenta
        Dim TipoBusqueda As Char = ""

        Try
            If TxtCriterio.Text.Trim = "" Then
                DGDetalle.DataSource = Nothing
                DGDetalle.Rows.Clear()
                Exit Sub
            End If

            DGDetalle.DataSource = Nothing
            DGDetalle.Rows.Clear()

            If RdbNombre.Checked Then
                TipoBusqueda = "N"
            Else
                TipoBusqueda = "C"
            End If

            Cuenta.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(Cuenta.ListBusqueda(TxtCriterio.Text.Trim, TipoBusqueda))

            If Cuenta.RowsAffected = 0 Then
                LblMensaje.Text = "No se encontraron datos relacionados"
            Else
                LblMensaje.Text = ""
            End If

            DGDetalle.DataSource = Cuenta.Datos.Tables(0)
            DGDetalle.Columns(0).Width = 100
            DGDetalle.Columns(1).Width = 280
            DGDetalle.Columns(2).Width = 150
            DGDetalle.Columns(0).Width = 100

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cuenta = Nothing
        End Try
    End Sub

    Private Sub SeleccionarLista()
        Try
            If DGDetalle.CurrentCell Is Nothing Then
                VerificaMensaje("Debe de seleccionar un valor")
            End If

            VerificaMensaje(ValidaCuenta(DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value.ToString))

            _Cuenta_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value.ToString
            _Selecciono = True

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCriterio_TextChanged(sender As Object, e As EventArgs) Handles TxtCriterio.TextChanged
        Buscar()
    End Sub

    Private Sub RdbNombre_CheckedChanged(sender As Object, e As EventArgs) Handles RdbNombre.CheckedChanged
        Buscar()
    End Sub

    Private Sub RdbCuenta_CheckedChanged(sender As Object, e As EventArgs) Handles RdbCuenta.CheckedChanged
        Buscar()
    End Sub

    Private Sub DGDetalle_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGDetalle.CellContentDoubleClick
        SeleccionarLista()
    End Sub

    Private Sub TxtCriterio_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCriterio.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                If DGDetalle.Rows.Count > 0 Then
                    DGDetalle.Rows(0).Selected = True
                    DGDetalle.Focus()
                End If
        End Select
    End Sub

    Private Sub DGDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles DGDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.F2, Keys.Enter
                SeleccionarLista()
        End Select
    End Sub

    Private Sub TrwCuentas_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TrwCuentas.NodeMouseClick
        CargaSubCuenta(e.Node)
    End Sub

    Private Sub TrwCuentas_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TrwCuentas.NodeMouseDoubleClick
        Seleccionar()
    End Sub

    Private Sub FrmBusquedaCuentaContable_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

End Class