Imports Business
Public Class FrmMantGrupoDetalle
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private Grupo As New TGrupo(EmpresaInfo.Emp_Id)
    Private _Titulo As String
    Private _GuardoCambios As Boolean
    Private _Nuevo As Boolean
    Private _Cargando As Boolean
#End Region
#Region "Propiedades"
    Public WriteOnly Property Titulo As String
        Set(value As String)
            _Titulo = value
        End Set
    End Property
    Public WriteOnly Property Nuevo As Boolean
        Set(value As Boolean)
            _Nuevo = value
        End Set
    End Property
    Public ReadOnly Property GuardoCambios As Boolean
        Get
            Return _GuardoCambios
        End Get
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

    Private Sub CargaDatos()
        Dim Mensaje As String = ""
        Try
            Grupo.Grupo_Id = CInt(TxtNumero.Text)
            Mensaje = Grupo.ListKey()
            VerificaMensaje(Mensaje)

            With Grupo
                TxtNombre.Text = .Nombre
                ChkActivo.Checked = .Activo
                ChequeaMenu(Grupo.Grupo_Id)
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ChequeaMenu(pGrupo_Id As Integer)
        Dim GrupoMenu As New TGrupoMenu(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Dim Nodo As TreeNode() = Nothing
        Try
            GrupoMenu.Grupo_Id = pGrupo_Id
            GrupoMenu.Modulo_Id = Modulo_Id
            GrupoMenu.List()
            VerificaMensaje(Mensaje)

            For Each Fila As DataRow In GrupoMenu.Data.Tables(0).Rows
                Nodo = TrwMenu.Nodes.Find(Fila("Menu_Id"), True)
                If Not Nodo Is Nothing And Nodo.Count > 0 Then
                    Nodo(0).Checked = True
                End If
            Next


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            GrupoMenu = Nothing
        End Try
    End Sub

    Public Sub Execute(pCodigo As Integer)
        Dim Menu As New TMenu(Modulo_Id)
        Try
            Me.Text = _Titulo
            _GuardoCambios = False
            _Cargando = True

            Menu.CreaArbolMenu(TrwMenu)

            If Not _Nuevo Then
                TxtNumero.Text = pCodigo
                CargaDatos()
            End If

            TxtNumero.Focus()

            _Cargando = False
            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Menu = Nothing
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMantCategoriaDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If TxtNombre.Text.Trim = "" Then
                TxtNombre.Focus()
                VerificaMensaje("Debe de ingresar un valor")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        If ValidaTodo() Then
            Guardar()
        End If
    End Sub

    Private Sub Guardar()
        Dim NodosChequeados As New List(Of TreeNode)
        Dim OpcionMenu As TGrupoMenu = Nothing
        Dim Mensaje As String = ""
        Try

            If _Nuevo Then
                Mensaje = Grupo.Siguiente()
                VerificaMensaje(Mensaje)
            Else
                Grupo.Grupo_Id = CInt(TxtNumero.Text)
            End If

            With Grupo
                .Nombre = TxtNombre.Text
                .Activo = ChkActivo.Checked
                .Modulo_Id = Modulo_Id
            End With

            NodosChequeados = GetCheck(TrwMenu.Nodes)

            For Each Nodo As TreeNode In NodosChequeados
                OpcionMenu = New TGrupoMenu(EmpresaInfo.Emp_Id)
                With OpcionMenu
                    .Grupo_Id = Grupo.Grupo_Id
                    .Modulo_Id = Modulo_Id
                    .Menu_Id = Nodo.Name
                    .Modulo_Id = Modulo_Id
                End With
                Grupo.GrupoMenues.Add(OpcionMenu)
            Next


            If _Nuevo Then
                Mensaje = Grupo.Insert()
            Else
                Mensaje = Grupo.Modify()
            End If
            VerificaMensaje(Mensaje)

            _GuardoCambios = True

            MsgBox("Los cambios se almacenaron correctamente", MsgBoxStyle.Information, Me.Text)

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub FrmMantProveedorDetalle_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtNombre.Select()
    End Sub
    Private Sub TrwMenu_AfterCheck(sender As Object, e As System.Windows.Forms.TreeViewEventArgs) Handles TrwMenu.AfterCheck
        If Not _Cargando Then
            CheckChildNones(e.Node)
        End If
    End Sub
End Class