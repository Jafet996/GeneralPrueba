Imports BUSINESS
Public Class FrmMantCuentaTipoClaseDetalle
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private _Titulo As String
    Private _GuardoCambios As Boolean
    Private _Nuevo As Boolean
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

    Public Sub Execute(pTipo As Integer, pCodigo As Integer)
        Me.Text = _Titulo
        _GuardoCambios = False
        CargaCombo()

        If Not _Nuevo Then
            CmbTipos.SelectedValue = pTipo
            CmbTipos.Enabled = False
            TxtNumero.Text = pCodigo
            CargaDatos()
        End If

        TxtNumero.Focus()

        Me.ShowDialog()
    End Sub

    Private Sub CargaCombo()
        Dim CuentaTipo As New TCuentaTipo

        Try
            CuentaTipo.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(CuentaTipo.LoadComboBox(CmbTipos))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CuentaTipo = Nothing
        End Try
    End Sub

    Private Sub CargaDatos()
        Dim CuentaTipoClase As New TCuentaTipoClase

        Try
            With CuentaTipoClase
                .Emp_Id = EmpresaInfo.Emp_Id
                .Tipo_Id = CInt(CmbTipos.SelectedValue)
                .Clase_Id = CInt(TxtNumero.Text.Trim)
            End With
            VerificaMensaje(CuentaTipoClase.ListKey())

            With CuentaTipoClase
                TxtNombre.Text = .Nombre
                ChkActivo.Checked = .Activo
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If TxtNombre.Text.Trim = "" Then
                TxtNombre.Focus()
                VerificaMensaje("Debe de ingresar un valor")
            End If

            If CmbTipos.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar un tipo")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Guardar()
        Dim CuentaTipoClase As New TCuentaTipoClase
        Dim Mensaje As String = ""

        Try
            With CuentaTipoClase
                .Emp_Id = EmpresaInfo.Emp_Id
                .Tipo_Id = CInt(CmbTipos.SelectedValue)
            End With

            If _Nuevo Then
                VerificaMensaje(CuentaTipoClase.NextOne())
            Else
                CuentaTipoClase.Clase_Id = CInt(TxtNumero.Text)
            End If

            With CuentaTipoClase
                .Nombre = TxtNombre.Text.Trim
                .Activo = ChkActivo.Checked
            End With

            If _Nuevo Then
                Mensaje = CuentaTipoClase.Insert()
            Else
                Mensaje = CuentaTipoClase.Modify()
            End If
            VerificaMensaje(Mensaje)

            _GuardoCambios = True
            MsgBox("Los cambios se almacenaron correctamente", MsgBoxStyle.Information, Me.Text)

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        If ValidaTodo() Then
            Guardar()
        End If
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMantCuentaTipoClaseDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormateaCamposNumericos()
        TxtNombre.Select()
    End Sub

End Class