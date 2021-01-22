Imports Business
Public Class FrmCreaArticuloSuelto
    Private _ArticuloPadre As String = ""
    Private _Precio As Double = 0
    Private _FactorConversion As Integer = 0
    Dim Numerico() As TNumericFormat

    Public WriteOnly Property ArticuloPadre As String
        Set(value As String)
            _ArticuloPadre = value
        End Set
    End Property
    Public WriteOnly Property Precio As Double
        Set(value As Double)
            _Precio = value
        End Set
    End Property
    Public WriteOnly Property FactorConversion As Integer
        Set(value As Integer)
            _FactorConversion = value
        End Set
    End Property


    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtPrecio, 8, 2, False, "", "###0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Function ValidaTodo() As Boolean
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            If TxtCodigo.Text.Trim = "" Then
                TxtCodigo.SelectAll()
                TxtCodigo.Focus()
                VerificaMensaje("Debe de ingresar un código")
            End If

            Articulo.Art_Id = TxtCodigo.Text.Trim
            Mensaje = Articulo.ListKey()

            If Articulo.Existe Then
                TxtCodigo.SelectAll()
                TxtCodigo.Focus()
                VerificaMensaje("Codigo de artículo no valido este ya lo tiene asignado el articulo " & Articulo.Nombre)
            End If

            If Not IsNumeric(TxtPrecio.Text) OrElse CDbl(TxtPrecio.Text) <= 0 Then
                TxtPrecio.SelectAll()
                TxtPrecio.Focus()
                VerificaMensaje("El precio debe de ser mayor a cero")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        Finally
            Articulo = Nothing
        End Try
    End Function

    Private Sub TxtCodigo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigo.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter And TxtCodigo.Text.Trim <> ""
                TxtPrecio.Focus()
        End Select
    End Sub

    Private Sub TxtPrecio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtPrecio.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter And IsNumeric(TxtPrecio.Text)
                BtnGuardar.Focus()
        End Select
    End Sub

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            If Not ValidaTodo() Then
                Exit Sub
            End If

            Articulo.Art_Id = _ArticuloPadre
            Mensaje = Articulo.CreaArticuloSuelto(TxtCodigo.Text, CDbl(TxtPrecio.Text), ChkBusquedaRapida.Checked, ChkArticuloFrecuente.Checked)
            VerificaMensaje(Mensaje)


            MsgBox("El artículo se creó de manera correcta", MsgBoxStyle.Information, Me.Text)

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Articulo = Nothing
        End Try
    End Sub
    Public Sub Execute()

        If _FactorConversion > 0 Then
            TxtPrecio.Text = Format(RedondeaMontoCobro(_Precio / _FactorConversion), "###0.00")
        Else
            TxtPrecio.Text = "0.00"
        End If

        Me.ShowDialog()
    End Sub

    Private Sub FrmCreaArticuloSuelto_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub FrmCreaArticuloSuelto_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtCodigo.Select()
    End Sub


End Class