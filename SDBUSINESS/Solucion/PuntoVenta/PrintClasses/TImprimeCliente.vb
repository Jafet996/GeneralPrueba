Imports Business
Public Class TImprimeCliente
    Inherits TPrint


#Region "Declaracion de variables"
    Private _ClienteImpresion As TClienteImpresion
#End Region

    Public Sub New(pPrinterTo As String, ByVal pClienteImpresion As TClienteImpresion)
        MyBase.New()


        MyBase.PrintTo = pPrinterTo
        _ClienteImpresion = pClienteImpresion

    End Sub

    Protected Overrides Sub Print_Doc()
        Dim y As Integer = 0

        ImprimeEncabezado(y)

        ImprimeDetalle(y)

        ImprimePieFactura(y)
    End Sub

    Private Sub ImprimeEncabezado(ByRef y As Integer)
        Dim Leyenda As String = String.Empty

        Send(_ClienteImpresion.Nombre, PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)
        Send("------------------------------------------------", PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)
        Send("Teléfono : " & _ClienteImpresion.Telefono, PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)
        'If _ClienteImpresion.Email.Trim <> String.Empty Then
        '    Send("Email: " & _ClienteImpresion.Email, PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)
        'Else
        '    Send("", PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)
        'End If

        Send("", PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)

        If _ClienteImpresion.Direccion.Length > 0 Then
            Leyenda = "Dirección: " & _ClienteImpresion.Direccion
            While Leyenda.Length > 0
                Send(BuscaFraseEntera(Leyenda, 36).Trim, PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)
            End While
            Send("", PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)
        End If

    End Sub

    Private Sub ImprimeDetalle(ByRef y As Integer)
    End Sub

    Private Sub ImprimePieFactura(ByRef y As Integer)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Sleep(100)
    End Sub

End Class
