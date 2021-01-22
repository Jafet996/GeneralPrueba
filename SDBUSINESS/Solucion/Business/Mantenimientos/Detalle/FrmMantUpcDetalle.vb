Imports Business
Imports System.Windows.Forms
Public Class FrmMantUpcDetalle
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private Upc As New TUpc(EmpresaInfo.Emp_Id)
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
            ReDim Numerico(1)

            Numerico(0) = New TNumericFormat(TxtNumero, 4, 0, False, "", "###")

            Numerico(1) = New TNumericFormat(TxtCantidad, 6, 0, False, "", "###")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub CargaDatos()
        Dim Mensaje As String = ""
        Try
            Upc.Upc_Id = CInt(TxtNumero.Text)
            Mensaje = Upc.ListKey()
            VerificaMensaje(Mensaje)

            With Upc
                TxtNombre.Text = .Nombre
                TxtCantidad.Text = .Cantidad
                ChkActivo.Checked = .Activo
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute(pCodigo As Integer)
        Me.Text = _Titulo

        FormateaCamposNumericos()

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

            If Not IsNumeric(TxtCantidad.Text) OrElse CInt(TxtCantidad.Text) <= 0 Then
                TxtCantidad.Select()
                VerificaMensaje("La cantidad de unidades x empaque debe de ser mayor o igual a 1")
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
                Mensaje = Upc.Siguiente()
                VerificaMensaje(Mensaje)
            Else
                Upc.Upc_Id = CInt(TxtNumero.Text)
            End If

            With Upc
                .Nombre = TxtNombre.Text
                .Cantidad = CInt(TxtCantidad.Text)
                .Activo = ChkActivo.Checked
            End With

            If _Nuevo Then
                Mensaje = Upc.Insert()
            Else
                Mensaje = Upc.Modify()
            End If

            VerificaMensaje(Mensaje)

            _GuardoCambios = True

            MsgBox("Los cambios se almacenaron correctamente", MsgBoxStyle.Information, Me.Text)

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub FrmMantUpcDetalle_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtNombre.Select()
    End Sub
End Class