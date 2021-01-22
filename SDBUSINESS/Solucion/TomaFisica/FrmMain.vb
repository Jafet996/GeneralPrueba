Imports Business
Public Class FrmMain
    Private Sub MnuSalir_Click(sender As System.Object, e As System.EventArgs) Handles MnuSalir.Click
        Application.Exit()
    End Sub

    Private Sub MuestraMenu(pMostrar)
        MnuProcesos.Visible = pMostrar
        MnuCreacionArticulo.Visible = pMostrar
    End Sub
    Private Sub MuestraEquiquetas(pVisible As Boolean)
        LblEmpresa.Visible = pVisible
        LblEmpresaNombre.Visible = pVisible
        TSSCompaniaLabel.Visible = pVisible
        TSSCompania.Visible = pVisible
        TSSSucursalLabel.Visible = pVisible
        TSSSucursal.Visible = pVisible
        TSSUsuarioLabel.Visible = pVisible
        TSSUsuario.Visible = pVisible
    End Sub
    Private Sub MnuConexión_Click(sender As System.Object, e As System.EventArgs) Handles MnuConexión.Click
        Dim Forma As New FrmConexion
        Try
            Inicializa()

            Forma.Execute()
            If Forma.Conecto Then
                MuestraMenu(True)
                TSSCompania.Text = EmpresaInfo.Nombre
                TSSSucursal.Text = SucursalInfo.Nombre
                TSSUsuario.Text = UsuarioInfo.Nombre
                MuestraEquiquetas(True)
                LblEmpresaNombre.Text = EmpresaInfo.Nombre
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Sub Inicializa()
        MuestraMenu(False)
        TSSCompania.Text = ""
        TSSSucursal.Text = ""
        TSSUsuario.Text = ""
        LblEmpresaNombre.Text = ""
        MuestraEquiquetas(False)
    End Sub
    Private Sub FrmMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Modulo_Id = Modulos.TomaFisica
        Try
            GuardaMenu()
            Inicializa()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub

    Private Sub MnuCreacionArticulo_Click(sender As System.Object, e As System.EventArgs) Handles MnuCreacionArticulo.Click
        Dim Forma As New FrmCreaArticulo
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Public Sub RecorrerNivelesAltos(pMenu As TMenu)
        Dim Orden As Integer = 0

        For Each M As ToolStripMenuItem In MenuStripPrincipal.Items
            With pMenu
                .Modulo_Id = Modulo_Id
                .Menu_Id = M.Name
                .MenuPadre_Id = ""
                .Nombre = M.Text
                .Orden = Orden
            End With
            VerificaMensaje(pMenu.Insert())
            Orden = Orden + 1
            Me.RecorrerSubMenuNivelesAltos(pMenu, Orden, M)
        Next
    End Sub

    Public Sub RecorrerSubMenuNivelesAltos(pMenu As TMenu, ByRef pOrden As Integer, ByVal M As ToolStripMenuItem)
        For Each SubMenu As ToolStripMenuItem In M.DropDownItems
            With pMenu
                .Modulo_Id = Modulo_Id
                .Menu_Id = SubMenu.Name
                .MenuPadre_Id = M.Name
                .Nombre = SubMenu.Text
                .Orden = pOrden
            End With
            VerificaMensaje(pMenu.Insert())
            pOrden = pOrden + 1
            Me.RecorrerSubMenuNivelesAltos(pMenu, pOrden, SubMenu)
        Next
    End Sub

    Private Sub GuardaMenu()
        Dim Menu As New TMenu(Modulo_Id)
        Try

            VerificaMensaje(Menu.Delete())

            RecorrerNivelesAltos(Menu)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Menu = Nothing
        End Try
    End Sub

End Class