Imports BUSINESS
Public Class FrmMantCatalogoLista
    Public Sub Execute()
        Try
            CargaCuentasPadre()

            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
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

    Private Sub TrwCuentas_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TrwCuentas.NodeMouseDoubleClick
        CargaSubCuenta(e.Node)
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnNueva_Click(sender As Object, e As EventArgs) Handles BtnNueva.Click
        Dim Forma As New FrmMantCuentaMayorDetalle

        Try
            With Forma
                .Nuevo = True
                .Execute(-1)
            End With

            If Forma.GuardoCambios Then
                CargaCuentasPadre()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        Dim Forma As New FrmMantCuentaHijaDetalle
        Dim Items() As String
        Dim Nivel As Integer
        Dim Moneda As String
        Dim Cuenta_Id As String
        Dim Nodo As TreeNode

        Try
            If TrwCuentas.SelectedNode Is Nothing Then
                VerificaMensaje("Debe de seleccionar una cuenta")
            End If

            Items = TrwCuentas.SelectedNode.Name.Split("_")

            Nivel = Items(1)
            Moneda = Items(2)
            Cuenta_Id = Items(3)

            Forma.Nuevo = True
            Forma.Execute(Cuenta_Id, String.Empty, Moneda, Nivel)

            If Forma.GuardoCambios Then

                Nodo = BuscaNodoPrimerNivel(TrwCuentas.SelectedNode)

                If Not Nodo Is Nothing Then
                    CargaSubCuenta(Nodo)
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click
        Dim DatosCuenta() As String

        Try
            DatosCuenta = Split(TrwCuentas.SelectedNode.Name, "_")

            If DatosCuenta.Length = 0 Then
                VerificaMensaje("Ocurrió un problema a la hora de recuperar los datos de la cuenta")
            End If

            If CInt(DatosCuenta(1)) = 1 Then
                Dim Forma As New FrmMantCuentaMayorDetalle

                With Forma
                    .Nuevo = False
                    .Execute(DatosCuenta(3))
                End With

                If Forma.GuardoCambios Then
                    CargaCuentasPadre()
                End If
            Else
                Dim Forma As New FrmMantCuentaHijaDetalle
                Dim Cuenta As New TCuenta

                With Cuenta
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Cuenta_Id = DatosCuenta(3)
                End With
                VerificaMensaje(Cuenta.ListKey)

                With Forma
                    .Nuevo = False
                    .Execute(Cuenta.Padre_Id, Cuenta.Cuenta_Id, Cuenta.Moneda, Cuenta.Nivel)
                End With

                For Each Item As TreeNode In TrwCuentas.Nodes
                    If Item.Tag = Cuenta.Padre_Id Then
                        CargaSubCuenta(Item)
                    End If
                Next

            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmMantCatalogoLista_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

End Class