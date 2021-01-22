Imports Business
Public Class FrmClienteEncargo
#Region "Enum"
    Private Enum ColumnasAnotaciones
        Id = 0
        Anotacion = 1
        Fecha = 2
        Usuario = 3
    End Enum
    Private Enum ColumnasEncargos
        Id = 0
        Articulo
        Descripcion
        Fecha
        Usuario
        Notificado
        FechaNotificacion
        Facturado
        FechaFacturacion
    End Enum
#End Region
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private _Cliente_Id As Integer = 0
    Private _ClienteNuevo As Integer = 0
    Private _GuardoCambios As Boolean = False
#End Region
#Region "Propiedades"
    Public Property Cliente_Id As Integer
        Get
            Return _Cliente_Id
        End Get
        Set(value As Integer)
            _Cliente_Id = value
        End Set
    End Property
    Public ReadOnly Property ClienteNuevo As Integer
        Get
            Return _ClienteNuevo
        End Get
    End Property
    Public ReadOnly Property GuardoCambios As Boolean
        Get
            Return _GuardoCambios
        End Get
    End Property
#End Region
#Region "Formateo de Campos"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtNumero, 8, 0, False, "", "###0")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub ConfiguraDetalle()
        Try

            With LvwAnotaciones
                .Columns(ColumnasAnotaciones.Id).Text = "Id"
                .Columns(ColumnasAnotaciones.Id).Width = 0

                .Columns(ColumnasAnotaciones.Anotacion).Text = "Anotación"
                .Columns(ColumnasAnotaciones.Anotacion).Width = 305

                .Columns(ColumnasAnotaciones.Fecha).Text = "Fecha"
                .Columns(ColumnasAnotaciones.Fecha).Width = 76

                .Columns(ColumnasAnotaciones.Usuario).Text = "Hecho Por"
                .Columns(ColumnasAnotaciones.Usuario).Width = 75
            End With

            With LvwEncargos
                .Columns(ColumnasEncargos.Id).Text = "Id"
                .Columns(ColumnasEncargos.Id).Width = 0

                .Columns(ColumnasEncargos.Articulo).Text = "Artículo"
                .Columns(ColumnasEncargos.Articulo).Width = 100

                .Columns(ColumnasEncargos.Descripcion).Text = "Descripción"
                .Columns(ColumnasEncargos.Descripcion).Width = 425

                .Columns(ColumnasEncargos.Fecha).Text = "Fecha"
                .Columns(ColumnasEncargos.Fecha).Width = 76

                .Columns(ColumnasEncargos.Usuario).Text = "Usuario"
                .Columns(ColumnasEncargos.Usuario).Width = 75

                .Columns(ColumnasEncargos.Notificado).Text = "Notificado"
                .Columns(ColumnasEncargos.Notificado).Width = 60

                .Columns(ColumnasEncargos.FechaNotificacion).Text = "Notificación"
                .Columns(ColumnasEncargos.FechaNotificacion).Width = 76

                .Columns(ColumnasEncargos.Facturado).Text = "Facturado"
                .Columns(ColumnasEncargos.Facturado).Width = 60

                .Columns(ColumnasEncargos.FechaFacturacion).Text = "Facturación"
                .Columns(ColumnasEncargos.FechaFacturacion).Width = 76

            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute()
        If _Cliente_Id > 0 AndAlso _Cliente_Id <> InfoMaquina.ClienteDefault Then
            TxtNumero.Text = _Cliente_Id
            CargaDatos()
        End If

        Me.ShowDialog()
    End Sub

    Private Sub CargaDatos()
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)

        Try
            Cliente.Cliente_Id = CInt(TxtNumero.Text.Trim)
            VerificaMensaje(Cliente.ListKey)

            BtnLimpiar.Enabled = True
            BtnImprime.Enabled = True
            BtnPreFactura.Enabled = True
            TxtNumero.Enabled = False
            BtnAnotacionAgregar.Enabled = True
            BtnArticuloAgregar.Enabled = True

            With Cliente
                TxtNombre.Text = .Nombre
                TxtTelefono1.Text = .Telefono1
                TxtTelefono2.Text = .Telefono2
                TxtApartado.Text = .Apartado
                TxtEmail.Text = .Email
                TxtDireccion.Text = .Direccion
                CargaListaAnotaciones(Cliente.Cliente_Id)
                CargaListaEncargos(Cliente.Cliente_Id)
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
        End Try
    End Sub

    Private Sub CargaListaAnotaciones(pCliente As Integer)
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim Items(3) As String
        Dim Item As ListViewItem = Nothing

        Try
            LvwAnotaciones.Items.Clear()
            BtnAnotacionEliminar.Enabled = False

            Cliente.Cliente_Id = pCliente
            VerificaMensaje(Cliente.ConsultaAnotacionesCliente)

            For Each Fila As DataRow In Cliente.Data.Tables(0).Rows
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
            Cliente = Nothing
        End Try
    End Sub

    Private Sub CargaListaEncargos(pCliente As Integer)
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim Items(8) As String
        Dim Item As ListViewItem = Nothing

        Try
            LvwEncargos.Items.Clear()
            BtnArticuloEliminar.Enabled = False

            Cliente.Cliente_Id = pCliente
            VerificaMensaje(Cliente.ConsultaEncargosCliente)

            For Each Fila As DataRow In Cliente.Data.Tables(0).Rows
                Items(ColumnasEncargos.Id) = Fila("Encargo_Id")
                Items(ColumnasEncargos.Articulo) = Fila("Art_Id")
                Items(ColumnasEncargos.Descripcion) = Fila("Nombre")
                Items(ColumnasEncargos.Fecha) = Format(Fila("Fecha"), "dd/MM/yyyy")
                Items(ColumnasEncargos.Usuario) = Fila("Usuario_Id")
                Items(ColumnasEncargos.Notificado) = IIf(Fila("Notificacion"), "SI", "NO")
                Items(ColumnasEncargos.FechaNotificacion) = Format(Fila("NotificacionFecha"), "dd/MM/yyyy")
                Items(ColumnasEncargos.Facturado) = IIf(Fila("Facturado"), "SI", "NO")
                Items(ColumnasEncargos.FechaFacturacion) = Format(Fila("FacturadoFecha"), "dd/MM/yyyy")

                Item = New ListViewItem(Items)
                LvwEncargos.Items.Add(Item)
            Next

            BtnArticuloEliminar.Enabled = LvwEncargos.Items.Count > 0

            If LvwEncargos.Items.Count > 0 Then
                LvwEncargos.Items(LvwEncargos.Items.Count - 1).EnsureVisible()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
        End Try
    End Sub


    Private Sub TxtNumero_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtNumero.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If IsNumeric(TxtNumero.Text) Then
                    CargaDatos()
                End If
            Case Keys.F1
                BusquedaCliente()
        End Select
    End Sub

    Private Sub TxtNumero_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtNumero.TextChanged
        Inicializa()
    End Sub

    Private Sub BusquedaCliente()
        Dim Forma As New FrmBusquedaClienteOnLine

        Try
            Forma.Execute()

            If Forma.Selecciono Then
                TxtNumero.Text = Forma.Cliente_Id
                CargaDatos()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub Inicializa()
        TxtNombre.Text = String.Empty
        TxtTelefono1.Text = String.Empty
        TxtTelefono2.Text = String.Empty
        TxtApartado.Text = String.Empty
        TxtEmail.Text = String.Empty
        TxtDireccion.Text = String.Empty
        BtnLimpiar.Enabled = False
        BtnImprime.Enabled = False
        BtnPreFactura.Enabled = False
        TxtNumero.Enabled = True
        LvwAnotaciones.Items.Clear()
        LvwEncargos.Items.Clear()
        BtnAnotacionAgregar.Enabled = False
        BtnAnotacionEliminar.Enabled = False
        BtnArticuloAgregar.Enabled = False
        BtnArticuloEliminar.Enabled = False
    End Sub


    Private Sub FrmClienteEncargo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try

            EnviaCorreoEncagos()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmConsultaCliente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnPreFactura.PerformClick()
            Case Keys.F7
                BtnCrearCliente.PerformClick()
            Case Keys.F11
                BtnImprime.PerformClick()
            Case Keys.F12
                BtnLimpiar.PerformClick()
        End Select
    End Sub

    Private Sub FrmConsultaCliente_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try

            EnviaCorreoEncagos()
            FormateaCamposNumericos()
            ConfiguraDetalle()
            TxtNumero.Select()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpiar.Click
        Inicializa()
        TxtNumero.Text = String.Empty
        TxtNumero.Focus()
    End Sub


    Private Sub BtnPreFactura_Click(sender As System.Object, e As System.EventArgs) Handles BtnPreFactura.Click
        Dim Forma As New FrmPuntoVentaRetail

        Try
            Forma.Execute(Enum_TipoFacturacion.PreFactura, CInt(TxtNumero.Text))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub




    Private Sub BtnCrearCliente_Click(sender As System.Object, e As System.EventArgs) Handles BtnCrearCliente.Click
        CreaCliente()
    End Sub

    Private Sub CreaCliente()
        Dim Forma As New FrmMantClienteLista

        Try
            If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PVModificaClienteFacturacion, False) Then
                VerificaMensaje("No tiene permiso para modificar la información de los clientes")
            End If

            With Forma
                .SalirAlGuardar = True
                .Execute()
            End With

            _ClienteNuevo = Forma.ClienteNuevo
            _GuardoCambios = Forma.GuardoCambios

            If Forma.GuardoCambios AndAlso TxtNumero.Enabled Then
                If ConfirmaAccion("Desea refrescar la la información del cliente") Then
                    If Forma.ClienteNuevo <> 0 Then
                        TxtNumero.Text = Forma.ClienteNuevo
                    End If
                    CargaDatos()
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnAnotacionAgregar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAnotacionAgregar.Click
        Dim Forma As New FrmClienteAnotacion

        Try
            With Forma
                .Cliente_Id = CInt(TxtNumero.Text)
                .execute()
            End With

            CargaListaAnotaciones(CInt(TxtNumero.Text))
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnAnotacionEliminar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAnotacionEliminar.Click
        Dim ClienteAnotacion As New TClienteAnotacion(EmpresaInfo.Emp_Id)

        Try
            If LvwAnotaciones.SelectedItems Is Nothing OrElse LvwAnotaciones.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar una anotación")
            End If

            With ClienteAnotacion
                .Cliente_Id = CInt(TxtNumero.Text)
                .Anotacion_Id = CInt(LvwAnotaciones.SelectedItems(0).SubItems(0).Text)
            End With
            VerificaMensaje(ClienteAnotacion.Delete)

            CargaListaAnotaciones(CInt(TxtNumero.Text))
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ClienteAnotacion = Nothing
        End Try
    End Sub

    Private Sub BtnImprime_Click(sender As Object, e As EventArgs) Handles BtnImprime.Click
        Try
            ImprimeClienteInformacion(CInt(TxtNumero.Text), String.Empty)
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnArticuloAgregar_Click(sender As Object, e As EventArgs) Handles BtnArticuloAgregar.Click
        Dim Forma As New FrmBusquedaArticuloOnLine
        Dim ClienteEncargo As New TClienteEncargo(EmpresaInfo.Emp_Id)
        Dim Art_Id As String = String.Empty
        Dim Nombre As String = String.Empty
        Try

            Forma.Execute()
            If Forma.Art_Id.Trim <> "" Then
                Art_Id = Forma.Art_Id.Trim
                Nombre = Forma.Nombre
                ClienteEncargo.Cliente_Id = CInt(TxtNumero.Text)
                VerificaMensaje(ClienteEncargo.Siguiente)
                With ClienteEncargo
                    .Art_Id = Art_Id
                    .Usuario_Id = UsuarioInfo.Usuario_Id
                    .Notificacion = 0
                End With
                VerificaMensaje(ClienteEncargo.Insert)
            End If

            Threading.Thread.Sleep(1000)

            CargaListaEncargos(CInt(TxtNumero.Text))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
            ClienteEncargo = Nothing
        End Try
    End Sub

    Private Sub BtnArticuloEliminar_Click(sender As Object, e As EventArgs) Handles BtnArticuloEliminar.Click
        Dim ClienteEncargo As New TClienteEncargo(EmpresaInfo.Emp_Id)

        Try
            If LvwEncargos.SelectedItems Is Nothing OrElse LvwEncargos.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un artículo")
            End If

            With ClienteEncargo
                .Cliente_Id = CInt(TxtNumero.Text)
                .Encargo_Id = CInt(LvwEncargos.SelectedItems(0).SubItems(ColumnasEncargos.Id).Text)
            End With
            VerificaMensaje(ClienteEncargo.Delete)

            CargaListaEncargos(CInt(TxtNumero.Text))
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ClienteEncargo = Nothing
        End Try
    End Sub
End Class