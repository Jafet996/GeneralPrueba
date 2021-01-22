Imports Business
Public Class TImprimeToken
    Inherits TPrint

#Region "Declaracion de variables"
    Private _Empresa As TEmpresa
    Private _EmpresaParametro As TEmpresaParametro
    Private _Tokens As List(Of TUsuarioCodigoPermiso)
#End Region

    Public Sub New(ByVal pEmpresa As TEmpresa, ByVal pEmpresaParametro As TEmpresaParametro, ByVal pTokens As List(Of TUsuarioCodigoPermiso))
        MyBase.New()

        _Empresa = pEmpresa
        _EmpresaParametro = pEmpresaParametro
        _Tokens = pTokens

    End Sub

    Protected Overrides Sub Print_Doc()
        Dim y As Integer = 0

        ImprimeEncabezado(y)
        ImprimeDetalle(y)
        ImprimePieFactura(y)

    End Sub

    Private Sub ImprimeEncabezado(ByRef y As Integer)
        Dim Fecha As DateTime = EmpresaInfo.Getdate

        Send(_Empresa.Nombre, PrintFont.FontTitulo, 1, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Fecha: " + Format(Fecha, "dd/MM/yyyy hh:mm tt"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        Send("Lista de Token Disponibles", PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)
        Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Usuario: " + Format(UsuarioInfo.Nombre), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
    End Sub

    Private Sub ImprimeDetalle(ByRef y As Integer)
        Try
            Send("Codigo (Fecha Vencimiento)", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

            For Each Item As TUsuarioCodigoPermiso In _Tokens
                Send(Item.Codigo & " (" & Format(Item.FechaVencimiento, "dd/MM/yyyy") & ")", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Next

            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ImprimePieFactura(ByRef y As Integer)
        Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
    End Sub
End Class
