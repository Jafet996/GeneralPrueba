Imports BUSINESS
Public Class TImprimePagoChequePromerica
    Inherits TPrint

#Region "Declaracion de variables"
    Private _Empresa As TEmpresa
    Private _BcoPago As TBcoPago
#End Region

    Public Sub New(ByVal pEmpresa As TEmpresa, ByVal pBcoPago As TBcoPago)
        MyBase.New()
        _Empresa = pEmpresa
        _BcoPago = pBcoPago
    End Sub

    Protected Overrides Sub Print_Doc()
        Dim y As Integer = 55

        ImprimeEncabezado(y)
    End Sub

    Private Sub ImprimeEncabezado(ByRef y As Integer)
        Dim Leyenda As String = ""

        Send(FormateaFecha(_BcoPago.Cheque.Fecha, Enum_FormatDate.Largo), PrintFont.FontSingle, 500, y, PrintJustification.epsRight, 35)
        Send(_BcoPago.Cheque.Nombre, PrintFont.FontSingle, 80, y, PrintJustification.epsleft, 0)
        Send(Format(_BcoPago.Monto, "#,##0.00"), PrintFont.FontSingle, 665, y, PrintJustification.epsRight, 24)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send(_Empresa.ConvierteNumeroLetras(_BcoPago.Monto), PrintFont.FontSingle, 80, y, PrintJustification.epsleft, 0)

        Sleep(100)
    End Sub

    Private Function CreaStrNumero(pMonto As Double) As String
        Dim MontoStr As String = ""

        MontoStr = Format(pMonto, "#,##0.00")

        If MontoStr.Length <= 12 Then
            MontoStr = StrDup(12 - MontoStr.Length, " ") & MontoStr
        End If

        Return MontoStr
    End Function

End Class