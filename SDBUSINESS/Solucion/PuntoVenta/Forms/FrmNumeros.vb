Public Class FrmNumeros
    Dim _MaximoLargo As Integer
    Dim _ValorInicial As Double
    Dim _Cantidad As Double
    Dim _Cancelo As Boolean
    Dim _PermiteCantidadCero As Boolean

    Dim PrimerDigito As Boolean = True

    Public ReadOnly Property Cantidad() As Double
        Get
            Return _Cantidad
        End Get
    End Property
    Public ReadOnly Property Cancelo() As Boolean
        Get
            Return _Cancelo
        End Get
    End Property

    Private Sub BotonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Btn As Button

        Btn = CType(sender, Button)

        If TextResultado.Text.Length <= _MaximoLargo Then
            If PrimerDigito Then
                PrimerDigito = False
                TextResultado.Text = ""
            End If

            TextResultado.Text = IIf(TextResultado.Text = "0", "", TextResultado.Text) & Btn.Text
        End If
    End Sub

    Private Sub FrmNumeros_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Btn_0.Click, AddressOf BotonClick
        AddHandler Btn_1.Click, AddressOf BotonClick
        AddHandler Btn_2.Click, AddressOf BotonClick
        AddHandler Btn_3.Click, AddressOf BotonClick
        AddHandler Btn_4.Click, AddressOf BotonClick
        AddHandler Btn_5.Click, AddressOf BotonClick
        AddHandler Btn_6.Click, AddressOf BotonClick
        AddHandler Btn_7.Click, AddressOf BotonClick
        AddHandler Btn_8.Click, AddressOf BotonClick
        AddHandler Btn_9.Click, AddressOf BotonClick
    End Sub

    Public Sub Execute(ByVal pMaximoLargo As Integer, ByVal pValorInicial As Double, Optional ByVal pPermiteCantidadCero As Boolean = False)
        _MaximoLargo = pMaximoLargo
        _ValorInicial = pValorInicial
        PrimerDigito = True
        _Cancelo = False
        _PermiteCantidadCero = pPermiteCantidadCero

        If pValorInicial > 1 Then
            TextResultado.Text = pValorInicial
            TextResultado.SelectAll()
        Else
            TextResultado.Text = ""
        End If

        Me.ShowDialog()
    End Sub

    Private Sub Btn_Borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Borrar.Click
        TextResultado.Text = ""
    End Sub


    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        _Cantidad = _ValorInicial
        _Cancelo = True
        Me.Close()
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        Try
            If Not IsNumeric(TextResultado.Text) Then
                TextResultado.Text = "0"
            End If

            If CDbl(TextResultado.Text) < 0 Then
                Throw New Exception("Cantidad no válida")
            End If

            If Not _PermiteCantidadCero Then
                If CDbl(TextResultado.Text) = 0 Then
                    Throw New Exception("La cantidad debe de ser mayor a cero")
                End If
            End If

            _Cancelo = False
            _Cantidad = CDbl(TextResultado.Text)
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class