Imports BUSINESS
Public Class FrmMantCuentaFlujoDetalle
#Region "Enum"
    Private Enum ColumnaDetalle
        Tipo_Id = 0
        TipoNombre
        Cuenta_Id
        CuentaNombre
    End Enum
#End Region
#Region "Variables"
    Private _Titulo As String = "Cuentas de Flujo de Efectivo"
#End Region

    Public Sub Execute()
        ConfiguraLista()
        CargaLista()
        CargaCombo()
        Me.Text = _Titulo
        Me.ShowDialog()
    End Sub

    Private Sub Inicializa()
        TxtCuenta.Text = ""
        TxtCuentaNombre.Text = ""
        TxtCuenta.Focus()
    End Sub

    Private Sub CargaCombo()
        Dim TipoFlujoEfectivo As New TCuentaTipoFlujoEfectivo

        Try
            TipoFlujoEfectivo.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(TipoFlujoEfectivo.LoadComboBox(CmbTipoFlujoEfectivo))
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TipoFlujoEfectivo = Nothing
        End Try
    End Sub

    Private Sub ConfiguraLista()
        Try
            With LvwDetalle
                .Columns(ColumnaDetalle.Tipo_Id).Text = ""
                .Columns(ColumnaDetalle.Tipo_Id).Width = 0

                .Columns(ColumnaDetalle.TipoNombre).Text = "Tipo"
                .Columns(ColumnaDetalle.TipoNombre).Width = 120

                .Columns(ColumnaDetalle.Cuenta_Id).Text = "Cuenta"
                .Columns(ColumnaDetalle.Cuenta_Id).Width = 160

                .Columns(ColumnaDetalle.CuentaNombre).Text = "Nombre"
                .Columns(ColumnaDetalle.CuentaNombre).Width = 310
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaLista()
        Dim CuentaFlujoEfectivo As New TCuentaFlujoEfectivo
        Dim Item As ListViewItem = Nothing
        Dim Items(3) As String

        Try
            LvwDetalle.Items.Clear()

            With CuentaFlujoEfectivo
                .Emp_Id = EmpresaInfo.Emp_Id
            End With
            VerificaMensaje(CuentaFlujoEfectivo.List)

            If CuentaFlujoEfectivo.RowsAffected = 0 Then
                Exit Sub
            End If

            For Each Fila As DataRow In CuentaFlujoEfectivo.Datos.Tables(0).Rows
                Items(0) = Fila("Tipo_Id").ToString
                Items(1) = Fila("TipoNombre").ToString
                Items(2) = Fila("Cuenta_Id").ToString
                Items(3) = Fila("CuentaNombre").ToString

                Item = New ListViewItem(Items)
                LvwDetalle.Items.Add(Item)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CuentaFlujoEfectivo = Nothing
            Inicializa()
        End Try
    End Sub

    Private Function VerificaCuenta(pCuenta_Id As String) As String
        Dim Cuenta As New TCuenta

        Try
            With Cuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cuenta_Id = DepuraNumeroCuenta(TxtCuenta.Text)
            End With
            VerificaMensaje(Cuenta.ListKey)

            If Cuenta.RowsAffected = 0 Then
                VerificaMensaje("El número de cuenta no existe")
            End If

            If Cuenta.Nivel > 1 Then
                VerificaMensaje("Solo se permiten cuentas mayores")
            End If

            If Not Cuenta.Activo Then
                VerificaMensaje("La cuenta se encuentra desactivada")
            End If

            TxtCuentaNombre.Text = Cuenta.Nombre
            BtnAgregar.Select()

            Return String.Empty
        Catch ex As Exception
            TxtCuenta.Text = String.Empty
            TxtCuenta.Focus()
            Return ex.Message
        Finally
            Cuenta = Nothing
        End Try
    End Function

    Private Sub BusquedaCuenta()
        Dim Forma As New FrmBusquedaCuentaContable

        Try
            Forma.Execute()

            If Forma.Selecciono Then
                TxtCuenta.Text = Forma.Cuenta_Id
                VerificaMensaje(VerificaCuenta(TxtCuenta.Text.Trim))
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Dim CuentaFlujoEfectivo As New TCuentaFlujoEfectivo

        Try
            VerificaMensaje(VerificaCuenta(TxtCuenta.Text.Trim))

            If CmbTipoFlujoEfectivo.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar un tipo")
            End If

            With CuentaFlujoEfectivo
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cuenta_Id = DepuraNumeroCuenta(TxtCuenta.Text.Trim)
            End With
            VerificaMensaje(CuentaFlujoEfectivo.ListaXCuenta)

            If CuentaFlujoEfectivo.RowsAffected > 0 Then
                VerificaMensaje("La cuenta seleccionada ya fue agregada a la lista")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        Finally
            CuentaFlujoEfectivo = Nothing
        End Try
    End Function

    Private Sub AgregarCuenta()
        Dim CuentaFlujoEfectivo As New TCuentaFlujoEfectivo

        Try
            With CuentaFlujoEfectivo
                .Emp_Id = EmpresaInfo.Emp_Id
                .Tipo_Id = CInt(CmbTipoFlujoEfectivo.SelectedValue)
                .Cuenta_Id = DepuraNumeroCuenta(TxtCuenta.Text.Trim)
            End With
            VerificaMensaje(CuentaFlujoEfectivo.Insert)
            CargaLista()
            Mensaje("Se agregó correctamente la cuenta")
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CuentaFlujoEfectivo = Nothing
        End Try
    End Sub

    Private Sub EliminaCuenta()
        Dim CuentaFlujoEfectivo As New TCuentaFlujoEfectivo

        Try
            If LvwDetalle.SelectedItems Is Nothing OrElse LvwDetalle.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar una cuenta de la lista")
            End If

            If MsgBox("¿Desea eliminar de la lista la cuenta seleccionada?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Me.Text) <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            With CuentaFlujoEfectivo
                .Emp_Id = EmpresaInfo.Emp_Id
                .Tipo_Id = CInt(LvwDetalle.SelectedItems(0).SubItems(ColumnaDetalle.Tipo_Id).Text.Trim)
                .Cuenta_Id = LvwDetalle.SelectedItems(0).SubItems(ColumnaDetalle.Cuenta_Id).Text.Trim
            End With
            VerificaMensaje(CuentaFlujoEfectivo.Delete)
            CargaLista()
            Mensaje("Se eliminó correctamente la cuenta")
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CuentaFlujoEfectivo = Nothing
        End Try
    End Sub

    Private Sub TxtCuenta_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCuenta.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    BusquedaCuenta()
                Case Keys.Enter
                    VerificaMensaje(VerificaCuenta(TxtCuenta.Text.Trim))
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCuenta_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtCuenta.MaskInputRejected
        TxtCuentaNombre.Text = ""
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        If ValidaTodo() Then
            AgregarCuenta()
        End If
    End Sub

    Private Sub LvwDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles LvwDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                EliminaCuenta()
        End Select
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMantCuentaFlujoDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub FrmMantCuentaFlujoDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtCuenta.Select()
    End Sub

End Class