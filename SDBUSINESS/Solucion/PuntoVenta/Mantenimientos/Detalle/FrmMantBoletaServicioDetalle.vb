Imports Business
Public Class FrmMantBoletaServicioDetalle
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private BoletaServicio As New TBoletaServicio(EmpresaInfo.Emp_Id)
    Private _GuardoCambios As Boolean
    Private _Nuevo As Boolean
    Private _Asignar As Boolean
    Private _Cerrar As Boolean
    Private _PostServicio As Boolean
    Private _BoletaNueva As Integer
    Private _Cargando As Boolean = True
#End Region
#Region "Propiedades"
    Public WriteOnly Property Nuevo As Boolean
        Set(value As Boolean)
            _Nuevo = value
        End Set
    End Property
    Public WriteOnly Property Asignar As Boolean
        Set(value As Boolean)
            _Asignar = value
        End Set
    End Property
    Public WriteOnly Property Cerrar As Boolean
        Set(value As Boolean)
            _Cerrar = value
        End Set
    End Property
    Public WriteOnly Property PostServicio As Boolean
        Set(value As Boolean)
            _PostServicio = value
        End Set
    End Property
    Public ReadOnly Property GuardoCambios As Boolean
        Get
            Return _GuardoCambios
        End Get
    End Property
    Public ReadOnly Property BoletaNueva As Integer
        Get
            Return _BoletaNueva
        End Get
    End Property
#End Region
    Public Sub Execute(pCodigo As Integer)

        _GuardoCambios = False

        CargaCombos()
        If _Nuevo Then
            CargaPantalla()
            GpCliente.Enabled = True
            GpMotivo.Enabled = True
            GpAsignar.Enabled = False
            GpCierre.Enabled = False
            GpPostServicio.Enabled = False
            CmbTecnico.SelectedValue = -1
        End If
        If Not _Nuevo And Not _Asignar And Not _Cerrar And Not _PostServicio Then

            TxtBoleta.Text = pCodigo
            GpCliente.Enabled = True
            GpMotivo.Enabled = True
            GpAsignar.Enabled = False
            GpCierre.Enabled = False
            GpPostServicio.Enabled = False
            CargaDatosBoleta(pCodigo)
        End If
        If _Asignar Then
            TxtBoleta.Text = pCodigo
            GpCliente.Enabled = False
            GpMotivo.Enabled = False
            GpCierre.Enabled = False
            GpAsignar.Enabled = True
            GpPostServicio.Enabled = False
            CargaDatosBoleta(pCodigo)
            dpFechaAsigna.Value = EmpresaInfo.Getdate
        End If
        If _Cerrar Then
            TxtBoleta.Text = pCodigo
            GpCliente.Enabled = False
            GpMotivo.Enabled = False
            GpAsignar.Enabled = False
            GpCierre.Enabled = True
            GpPostServicio.Enabled = False
            CargaDatosBoleta(pCodigo)
            dpFechaCierre.Value = EmpresaInfo.Getdate
        End If
        If _PostServicio Then
            TxtBoleta.Text = pCodigo
            GpCliente.Enabled = False
            GpMotivo.Enabled = False
            GpAsignar.Enabled = False
            GpCierre.Enabled = False
            GpPostServicio.Enabled = True
            CargaDatosBoleta(pCodigo)
        End If
        TxtCodigo.Focus()
        _Cargando = False

        Me.ShowDialog()
    End Sub
    Private Sub CargaPantalla()
        DpFechaCrea.Value = EmpresaInfo.Getdate
        TxtUsuarioCrea.Text = UsuarioInfo.Nombre
        TxtSucursal.Text = SucursalInfo.Nombre
        CargaCombos()
        CmbEstado.SelectedValue = 1

    End Sub

    Private Function ValidaNuevo() As Boolean
        Try
            If TxtNombre.Text.Trim = "" Then
                TxtNombre.Focus()
                VerificaMensaje("Debe de ingresar un valor")
            End If

            If TxtAsunto.Text.Trim = "" Then
                TxtAsunto.Focus()
                VerificaMensaje("Debe de ingresar asunto")
            End If

            If TxtMotivo.Text.Trim = "" Then
                TxtMotivo.Focus()
                VerificaMensaje("Debe de ingresar motivo")
            End If

            If TxtDireccion.Text.Trim = "" Then
                TxtDireccion.Focus()
                VerificaMensaje("Debe de ingresar dirección")
            End If
            '------- Telefono -------------------------------------------------------
            If TxtTelefono1.Text.Trim = "" Then
                TxtTelefono1.Focus()
                VerificaMensaje("Debe de ingresar al menos un teléfono")
            End If

            If InStr(TxtTelefono1.Text, "-") > 0 Then
                TxtTelefono1.Focus()
                VerificaMensaje("El número de teléfono no puede contener guiones debe de ser un valor numerico")
            End If

            If InStr(TxtTelefono1.Text.Trim, " ") > 0 Then
                TxtTelefono1.Focus()
                VerificaMensaje("El número de teléfono no puede contener espacios")
            End If

            If Mid(TxtTelefono1.Text, 1, 1) = "0" Then
                TxtTelefono1.Focus()
                VerificaMensaje("El número de teléfono no puede iniciar con cero")
            End If

            If Not IsNumeric(TxtTelefono1.Text) Then
                TxtTelefono1.Focus()
                VerificaMensaje("El número de teléfono debe de ser un valor numérico")
            End If

            If TxtTelefono1.Text.Trim.Length < 8 Then
                TxtTelefono1.Focus()
                VerificaMensaje("El número de teléfono debe de tener al menos 8 digitos")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try

    End Function

    Private Function ValidaAsigna() As Boolean
        Try
            If CmbTecnico.SelectedValue = Nothing Then
                CmbTecnico.Focus()
                VerificaMensaje("Debe de seleccionar técnico")
            End If
            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function
    Private Function ValidaCierre() As Boolean
        Try
            If TxtSolucion.Text.Trim = "" Then
                TxtSolucion.Focus()
                VerificaMensaje("Debe de ingresar solución")
            End If
            If TxtFactura.Text.Trim = "" Then
                TxtFactura.Focus()
                VerificaMensaje("Debe de ingresar número de factura")
            End If
            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub CargaDatosBoleta(codigo As Integer)
        Dim BoletaServicio As New TBoletaServicio(EmpresaInfo.Emp_Id)
        Dim ClienteContacto As New TCliente(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Dim cont As Integer = 0
        Dim items(2) As String

        Try
            With BoletaServicio
                .Boleta_Id = codigo
            End With

            Mensaje = BoletaServicio.ListKey()
            VerificaMensaje(Mensaje)
            TxtCodigo.Text = BoletaServicio.Cliente_Id
            TxtNombre.Text = BoletaServicio.NombreCliente
            DpFechaCrea.Value = BoletaServicio.Fecha
            dpFechaFinal.Value = BoletaServicio.FechaVisita
            TxtSucursal.Text = BoletaServicio.Sucursal
            TxtTelefono1.Text = BoletaServicio.Telefono1
            TxtTelefono2.Text = BoletaServicio.Telefono2
            TxtEmail.Text = BoletaServicio.Email
            TxtDireccion.Text = BoletaServicio.Direccion
            TxtAsunto.Text = BoletaServicio.Asunto
            TxtMotivo.Text = BoletaServicio.Motivo
            CmbEstado.SelectedValue = BoletaServicio.Estado_Id
            CmbPrioridad.SelectedValue = BoletaServicio.Prioridad_Id
            TxtUsuarioCrea.Text = BoletaServicio.Usuario
            txtUsuarioAsigna.Text = BoletaServicio.UsuarioAsigna_Id
            CmbTecnico.SelectedValue = BoletaServicio.Tecnico_Id
            TxtObservacion.Text = BoletaServicio.Observacion
            TxtUsuarioCierre.Text = BoletaServicio.UsuarioCierre_Id
            TxtSolucion.Text = BoletaServicio.Solucion
            dpFechaCierre.Value = BoletaServicio.FechaCierra
            TxtFactura.Text = BoletaServicio.Factura

            For Each item In BoletaServicio.Contactos
                lsvContactosBoleta.Items.Add(item.ToString())
            Next


            For Each item In BoletaServicio.TraeComentario
                If item <> "" Then
                    If cont <= 2 Then
                        items(cont) = item.ToString
                    End If
                    If cont = 2 Then
                        cont = -1
                        lsvPost.Items.Add(New ListViewItem(items))
                        items(0) = ""
                        items(1) = ""
                        items(2)=""
                    End If
                    cont = cont + 1
                End If
            Next


            With ClienteContacto
                .Cliente_Id = BoletaServicio.Cliente_Id
            End With

            VerificaMensaje(ClienteContacto.ConsultaContactosCliente())
            For Each item In ClienteContacto.Contactos
                LsvContactos.Items.Add(item.ToString())
            Next


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            BoletaServicio = Nothing
            ClienteContacto = Nothing
        End Try

    End Sub
    Private Sub CargaCombos()
        Dim Estado As New TBoletaServicioEstado(EmpresaInfo.Emp_Id)
        Dim Prioridad As New TPrioridad(EmpresaInfo.Emp_Id)
        Dim Tecnico As New TTecnico(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            Mensaje = Estado.LoadComboBox(CmbEstado)
            VerificaMensaje(Mensaje)
            Mensaje = Prioridad.LoadComboBox(CmbPrioridad)
            VerificaMensaje(Mensaje)
            Mensaje = Tecnico.LoadComboBox(CmbTecnico)
            VerificaMensaje(Mensaje)
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Estado = Nothing
            Prioridad = Nothing
        End Try
    End Sub

    Private Sub TxtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigo.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If IsNumeric(TxtCodigo.Text) Then
                    CargaCliente()
                End If
            Case Keys.F1
                BusquedaCliente()
            Case Keys.F8
                BtnCliente.PerformClick()
        End Select
    End Sub
    Private Sub BusquedaCliente()
        Dim Forma As New FrmBusquedaClienteOnLine

        Try
            Forma.Execute()

            If Forma.Selecciono Then
                TxtCodigo.Text = Forma.Cliente_Id
                CargaCliente()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Sub CargaCliente()
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)

        Try
            Cliente.Cliente_Id = CInt(TxtCodigo.Text.Trim)
            VerificaMensaje(Cliente.ListKey)

            With Cliente
                TxtNombre.Text = .Nombre
                TxtTelefono1.Text = .Telefono1
                TxtTelefono2.Text = .Telefono2
                TxtEmail.Text = .Email
                TxtDireccion.Text = .Direccion
            End With


            VerificaMensaje(Cliente.ConsultaContactosCliente())
            For Each item In Cliente.Contactos
                LsvContactos.Items.Add(item.ToString())
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
        End Try
    End Sub

    Private Sub LsvContactos_DoubleClick(sender As Object, e As EventArgs) Handles LsvContactos.DoubleClick
        Dim valor As String
        For i As Integer = LsvContactos.SelectedItems.Count - 1 To 0 Step -1
            valor = LsvContactos.SelectedItems(i).Text.ToString()
            lsvContactosBoleta.Items.Add(valor)
        Next
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If _Nuevo Then
                If ValidaNuevo() Then
                    GuardarNuevo()
                End If
            End If
            If Not _Nuevo And Not _Asignar And Not _Cerrar And Not _PostServicio Then
                If ValidaNuevo() Then
                    GuardarNuevo()
                End If
            End If
            If _Asignar Then
                If ValidaAsigna() Then
                    GuardarAsignado()
                End If
            End If
            If _Cerrar Then
                If ValidaCierre() Then
                    GuardarCierre()
                End If
            End If
            If _PostServicio Then
                GuardaPost()
            End If
        Catch
        Finally
        End Try

    End Sub

    Private Sub GuardarNuevo()
        Try
            If _Nuevo Then
                VerificaMensaje(BoletaServicio.Siguiente())
            Else
                BoletaServicio.Boleta_Id = CInt(TxtBoleta.Text)
            End If

            With BoletaServicio
                .FechaVisita = dpFechaFinal.Value
                .Suc_Id = SucursalInfo.Suc_Id
                .Cliente_Id = CInt(TxtCodigo.Text)
                .Telefono1 = TxtTelefono1.Text
                .Telefono2 = TxtTelefono2.Text
                .Email = TxtEmail.Text
                .Direccion = TxtDireccion.Text
                .Asunto = TxtAsunto.Text
                .Motivo = TxtMotivo.Text
                .Estado_Id = CmbEstado.SelectedValue
                .Prioridad_Id = CmbPrioridad.SelectedValue
                .Usuario_Id = UsuarioInfo.Usuario_Id
                .Tecnico_Id = IIf(_Nuevo, -1, CmbTecnico.SelectedValue)
                .UsuarioAsigna_Id = IIf(_Nuevo, -1, UsuarioInfo.Usuario_Id)
                .FechaAsignada = CDate("1900-01-01")
                .UsuarioCierre_Id = IIf(_Nuevo, -1, UsuarioInfo.Usuario_Id)
                .FechaCierra = CDate("1900-01-01")
                .Observacion = ""
                .Solucion = ""
                .Contactos.Clear()
                For Each item As ListViewItem In lsvContactosBoleta.Items
                    .Contactos.Add(item.SubItems(0).Text.ToString)
                Next

            End With

            If _Nuevo Then
                VerificaMensaje(BoletaServicio.Insert())
                _BoletaNueva = BoletaServicio.Boleta_Id
            Else
                VerificaMensaje(BoletaServicio.Modify())
            End If

            _GuardoCambios = True
            Mensaje("Los cambios se almacenaron correctamente")
            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub GuardarAsignado()
        Try

            BoletaServicio.Boleta_Id = CInt(TxtBoleta.Text)

            With BoletaServicio
                .Estado_Id = IIf(CmbEstado.SelectedValue = 1, 2, CmbEstado.SelectedValue)
                .Tecnico_Id = CmbTecnico.SelectedValue
                .UsuarioAsigna_Id = UsuarioInfo.Usuario_Id
                .FechaAsignada = dpFechaAsigna.Value
                .Observacion = TxtObservacion.Text

            End With

            VerificaMensaje(BoletaServicio.Asigna())

            _GuardoCambios = True
            Mensaje("Los cambios se almacenaron correctamente")
            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub GuardarCierre()
        Try

            BoletaServicio.Boleta_Id = CInt(TxtBoleta.Text)

            With BoletaServicio
                .Estado_Id = IIf(CmbEstado.SelectedValue = 2, 3, CmbEstado.SelectedValue)
                .Observacion = TxtObservacion.Text
                .UsuarioCierre_Id = UsuarioInfo.Usuario_Id
                .Solucion = TxtSolucion.Text
                .Factura = TxtFactura.Text

            End With

            VerificaMensaje(BoletaServicio.Cierra())

            _GuardoCambios = True
            Mensaje("Los cambios se almacenaron correctamente")
            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub GuardaPost()
        Try

            BoletaServicio.Boleta_Id = CInt(TxtBoleta.Text)

            With BoletaServicio
                .Usuario_Id = UsuarioInfo.Usuario_Id
                .Comentarios.Clear()
                For Each item As ListViewItem In lsvPost.Items
                    .Comentarios.Add(item.SubItems(0).Text.ToString)
                Next
            End With

            VerificaMensaje(BoletaServicio.Post())

            _GuardoCambios = True
            Mensaje("Los cambios se almacenaron correctamente")
            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmMantBoletaServicioDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F7
                BtnGuardar.PerformClick()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub lsvContactosBoleta_KeyDown(sender As Object, e As KeyEventArgs) Handles lsvContactosBoleta.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Delete

                    For i As Integer = lsvContactosBoleta.SelectedItems.Count - 1 To 0 Step -1
                        lsvContactosBoleta.SelectedItems(i).Remove()
                    Next

            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        Try
            CapturaComentarioDocumento()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub CapturaComentarioDocumento()
        Dim Forma As New FrmComentario
        Dim _Comentario As String = ""
        Dim item(2) As String
        Try
            Forma.Titulo = "Comentario Boleta"
            Forma.Comentario = _Comentario
            Forma.Execute()
            If Forma.Acepto Then
                _Comentario = Forma.Comentario
                item(0) = _Comentario
                item(1) = EmpresaInfo.Getdate.ToString("dd/MM/yyyy")
                item(2) = UsuarioInfo.Usuario_Id
                lsvPost.Items.Add(New ListViewItem(item))
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnCliente_Click(sender As Object, e As EventArgs) Handles BtnCliente.Click
        Dim Forma As New FrmMantClienteDetalle
        Dim Codigo As Integer = -1
        Try
            If TxtCodigo.Text <> "" And TxtNombre.Text <> "" Then
                Codigo = TxtCodigo.Text

                Forma.Titulo = "Cliente"
                Forma.Nuevo = False
                Forma.Execute(Codigo)
            Else
                Codigo = -1
                Forma.Nuevo = True
                Forma.Execute(Codigo)
            End If

        Catch ex As Exception
            MensajeError(ex.Message, "Mantenimiento")
        Finally
            Forma = Nothing
        End Try
    End Sub
End Class