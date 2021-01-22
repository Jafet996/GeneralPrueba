Imports System.Windows.Forms
Imports Business

Public Class FrmMantArticuloImpuestoTarifaPorcentaje

#Region "Variables"

    Private _PermiteModificar As Boolean
    Private _PoseeTarifa As Boolean
    Private _CerroVentana As Boolean = False
    Private _Tarifa As String
    Private _Porcentaje As Double
    Private _Tarifas As New List(Of TImpuestoTarifa)()
    Dim Numerico() As TNumericFormat

#End Region

#Region "Propiedades"
    Public Property Porcentaje() As Double
        Get
            Return _Porcentaje
        End Get
        Set(ByVal value As Double)
            _Porcentaje = value
        End Set
    End Property
    Public Property Tarifa() As String
        Get
            Return _Tarifa
        End Get
        Set(ByVal value As String)
            _Tarifa = value
        End Set
    End Property
    Public ReadOnly Property CerroVentana() As Boolean
        Get
            Return _CerroVentana
        End Get
    End Property
    Public Property PoseeTarifa() As Boolean
        Get
            Return _PoseeTarifa
        End Get
        Set(ByVal value As Boolean)
            _PoseeTarifa = value
        End Set
    End Property
    Public Property PermiteModificar() As Boolean
        Get
            Return _PermiteModificar
        End Get
        Set(ByVal value As Boolean)
            _PermiteModificar = value
        End Set
    End Property
#End Region

#Region "Metodos publicos"
    Public Sub Execute()
        Try

            CargaTarifas()
            CargaCombos()
            CmbTarifa.Enabled = _PoseeTarifa
            If _PoseeTarifa Then
                CmbTarifa.SelectedValue = _Tarifa
            End If

            TxtPorcentaje.Enabled = _PermiteModificar
            TxtPorcentaje.Text = Porcentaje

            FormateaCamposNumericos()
            TxtPorcentaje.Select()
            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

#End Region

#Region "Metodos privados"
    Private Sub CargaCombos()
        Dim tarifas As New TImpuestoTarifa()
        Try
            tarifas.LoadComboBox(CmbTarifa)
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaTarifas()
        Dim tarifas As New TImpuestoTarifa()
        _Tarifas = New List(Of TImpuestoTarifa)()
        Try
            VerificaMensaje(tarifas.List())
            For Each row As DataRow In tarifas.Data.Tables(0).Rows

                Dim tmpTarifa As New TImpuestoTarifa()

                With tmpTarifa
                    .Tarifa_Id = row.Item("Tarifa_Id").ToString()
                    .Porcentaje = CDbl(row.Item("Porcentaje").ToString())
                End With
                _Tarifas.Add(tmpTarifa)

            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try

            If Not PoseeTarifa Then

                If Not IsNumeric(TxtPorcentaje.Text) OrElse CDbl(TxtPorcentaje.Text) <= 0 Then
                    VerificaMensaje("El porcentaje debe de ser mayor a cero")
                End If

                _Tarifa = "00"

            Else
                If CmbTarifa.SelectedValue = "00" Then
                    VerificaMensaje("Debe de seleccionar el código de tarifa")
                End If

                _Tarifa = CmbTarifa.SelectedValue

            End If

            If CDbl(TxtPorcentaje.Text) > 100 Then
                VerificaMensaje("El porcentaje no puede ser mayor a 100")
            End If


            _Porcentaje = TxtPorcentaje.Text

            _CerroVentana = True
            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Try
            _CerroVentana = False
            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CmbTarifa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTarifa.SelectedIndexChanged
        Try

            For Each item As TImpuestoTarifa In _Tarifas
                If item.Tarifa_Id = CmbTarifa.SelectedValue Then
                    TxtPorcentaje.Text = item.Porcentaje
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(1)

            Numerico(0) = New TNumericFormat(TxtPorcentaje, 4, 2, False, "1", "##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmMantArticuloImpuestoTarifaPorcentaje_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            BtnAceptar.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            BtnSalir.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            BtnAceptar.PerformClick()
        End If

    End Sub
End Class
#End Region


