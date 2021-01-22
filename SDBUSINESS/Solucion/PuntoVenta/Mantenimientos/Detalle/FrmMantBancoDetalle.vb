Imports Business
Public Class FrmMantBancoDetalle
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private Banco As New TBanco(EmpresaInfo.Emp_Id)
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
            ReDim Numerico(3)

            Numerico(0) = New TNumericFormat(TxtNumero, 4, 0, False, "", "###")


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub CargaDatos()
        Dim Mensaje As String = ""
        Try
            Banco.Banco_Id = CInt(TxtNumero.Text)
            Mensaje = Banco.ListKey()
            VerificaMensaje(Mensaje)

            With Banco
                TxtNombre.Text = .Nombre
                ChkTransferencia.Checked = .Transferencia
                ChkActivo.Checked = .Activo
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute(pCodigo As Integer)
        Me.Text = _Titulo
        _GuardoCambios = False

        If Not _Nuevo Then
            TxtNumero.Text = pCodigo
            CargaDatos()
        End If

        TxtNumero.Focus()

        Me.ShowDialog()
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
        Dim Mensaje As String = ""
        Try

            If _Nuevo Then
                Mensaje = Banco.Siguiente()
                VerificaMensaje(Mensaje)
            Else
                Banco.Banco_Id = CInt(TxtNumero.Text)
            End If

            With Banco
                .Nombre = TxtNombre.Text
                .Transferencia = ChkTransferencia.Checked
                .Activo = ChkActivo.Checked
            End With

            If _Nuevo Then
                Mensaje = Banco.Insert()
            Else
                Mensaje = Banco.Modify()
            End If

            _GuardoCambios = True

            MsgBox("Los cambios se almacenaron correctamente", MsgBoxStyle.Information, Me.Text)

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub FrmMantBancoDetalle_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtNombre.Select()
    End Sub
End Class