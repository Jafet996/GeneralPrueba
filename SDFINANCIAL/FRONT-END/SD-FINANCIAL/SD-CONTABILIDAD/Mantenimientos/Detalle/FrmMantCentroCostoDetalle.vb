Imports BUSINESS
Public Class FrmMantCentroCostoDetalle
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

    Public Sub Execute(pCodigo As Integer)
        Me.Text = _Titulo
        _GuardoCambios = False
        CargaCombo()

        If Not _Nuevo Then
            TxtNumero.Text = pCodigo
            CargaDatos()
        End If

        TxtNumero.Focus()

        Me.ShowDialog()
    End Sub

    Private Sub CargaCombo()
        Dim Tipo As New TCentroCostoTipo

        Try
            Tipo.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(Tipo.LoadComboBox(CmbTipo))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Tipo = Nothing
        End Try
    End Sub

    Private Sub CargaDatos()
        Dim CentroCosto As New TCentroCosto

        Try
            With CentroCosto
                .Emp_Id = EmpresaInfo.Emp_Id
                .CC_Id = CInt(TxtNumero.Text.Trim)
            End With
            VerificaMensaje(CentroCosto.ListKey())

            With CentroCosto
                TxtNombre.Text = .Nombre
                CmbTipo.SelectedValue = .CCTipo_Id
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

            If CmbTipo.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar un tipo de centro de costo")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Guardar()
        Dim CentroCosto As New TCentroCosto
        Dim Mensaje As String = ""

        Try
            CentroCosto.Emp_Id = EmpresaInfo.Emp_Id

            If _Nuevo Then
                VerificaMensaje(CentroCosto.NextOne())
            Else
                CentroCosto.CC_Id = CInt(TxtNumero.Text.Trim)
            End If

            With CentroCosto
                .Nombre = TxtNombre.Text.Trim
                .CCTipo_Id = CInt(CmbTipo.SelectedValue)
                .Activo = ChkActivo.Checked
            End With

            If _Nuevo Then
                Mensaje = CentroCosto.Insert()
            Else
                Mensaje = CentroCosto.Modify()
            End If
            VerificaMensaje(Mensaje)

            _GuardoCambios = True
            MsgBox("Los cambios se almacenaron correctamente", MsgBoxStyle.Information, Me.Text)

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CentroCosto = Nothing
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

    Private Sub FrmMantCentroCostoDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormateaCamposNumericos()
        TxtNombre.Select()
    End Sub

End Class