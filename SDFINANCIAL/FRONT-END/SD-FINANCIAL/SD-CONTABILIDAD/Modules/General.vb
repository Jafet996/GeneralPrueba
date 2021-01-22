Imports Business
Public Module General
#Region "Variables"
    Public Modulo_Id As Enum_Modulos
#End Region

    Public Function ImprimeListaToken(pTokens As List(Of TUsuarioCodigoPermiso))
        Dim Token As List(Of TUsuarioCodigoPermiso)

        Try
            Token = pTokens

            Select Case InfoMaquina.PrintLocation
                Case Else
                    VerificaMensaje(ImprimeToken(Token))
            End Select

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Token = Nothing
        End Try
    End Function

    Public Function ImprimeToken(pTokens As List(Of TUsuarioCodigoPermiso)) As String
        Dim ImprimeTokens As New TImprimeToken(EmpresaInfo, EmpresaParametroInfo, pTokens)
        Dim TipoImpresion As PrintLocation

        Try
            Select Case InfoMaquina.PrintLocation
                Case PrintLocation.Serial
                    TipoImpresion = PrintLocation.Serial
                Case PrintLocation.Paralelo
                    TipoImpresion = PrintLocation.Paralelo
                Case Else
                    TipoImpresion = PrintLocation.Serial
            End Select

            If Not ImprimeTokens.Print(TipoImpresion, True) Then
                VerificaMensaje("Se presentaron problemas al imprimir el documento")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            ImprimeTokens = Nothing
        End Try
    End Function
End Module