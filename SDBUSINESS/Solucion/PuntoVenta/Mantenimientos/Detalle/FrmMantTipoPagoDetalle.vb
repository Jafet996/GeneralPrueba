Imports Business
Public Class FrmMantTipoPagoDetalle
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private TipoPago As New TTipoPago(EmpresaInfo.Emp_Id)
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
            ReDim Numerico(2)

            Numerico(0) = New TNumericFormat(TxtNumero, 4, 0, False, "", "###")
            Numerico(1) = New TNumericFormat(txtDescDesde, 3, 2, False, "", "#,##0.00")
            Numerico(2) = New TNumericFormat(TxtDescHasta, 3, 2, False, "", "#,##0.00")
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub CargaDatos()
        Dim Mensaje As String = ""
        Try
            TipoPago.TipoPago_Id = CInt(TxtNumero.Text)
            Mensaje = TipoPago.ListKey()
            VerificaMensaje(Mensaje)

            With TipoPago
                TxtNombre.Text = .Nombre
                txtDescDesde.Text = .PorcDescuentoDesde
                TxtDescHasta.Text = .PorcDescuentoHasta

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
            If Convert.ToDouble(txtDescDesde.Text) > 100 Then
                txtDescDesde.Focus()
                VerificaMensaje("Debe de ingresar un valor entre 0 y 100")
            End If
            If Convert.ToDouble(TxtDescHasta.Text) > 100 Then
                txtDescDesde.Focus()
                VerificaMensaje("Debe de ingresar un valor entre 0 y 100")
            End If
            If Convert.ToDouble(txtDescDesde.Text) > Convert.ToDouble(TxtDescHasta.Text) Then
                txtDescDesde.Focus()
                VerificaMensaje("Verifique porcentajes de descuento")
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
                Mensaje = TipoPago.Siguiente()
                VerificaMensaje(Mensaje)
            Else
                TipoPago.TipoPago_Id = CInt(TxtNumero.Text)
            End If

            With TipoPago
                .Nombre = TxtNombre.Text
                .PorcDescuentoDesde = txtDescDesde.Text
                .PorcDescuentoHasta = TxtDescHasta.Text
            End With

            If _Nuevo Then
                'Mensaje = TipoPago.Insert()
            Else
                Mensaje = TipoPago.Modify()
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
        FormateaCamposNumericos()
    End Sub

    Private Sub txtDescMax_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescDesde.KeyPress
        NumerosyDecimal(txtDescDesde, e)
    End Sub

    Public Sub NumerosyDecimal(ByVal CajaTexto As Windows.Forms.TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'If Char.IsDigit(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsControl(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf e.KeyChar = "." And Not CajaTexto.Text.IndexOf(".") Then
        '    e.Handled = True
        'ElseIf e.KeyChar = "." Then
        '    e.Handled = False
        'Else
        '    e.Handled = True
        'End If
    End Sub
End Class