Imports Business
Public MustInherit Class TPrintParallel
#Region "Variables"
    Protected _ObjFSO As Object
    Protected _ObjStream As Object
    Protected _Port As String
#End Region
#Region "Propiedades"
    Protected ReadOnly Property ObjFSO As Object
        Get
            Return _ObjFSO
        End Get
    End Property
    Protected ReadOnly Property ObjStream As Object
        Get
            Return _ObjStream
        End Get
    End Property
    Public WriteOnly Property Port As String
        Set(value As String)
            _Port = value
        End Set
    End Property
#End Region

    Protected Sub Sleep(ByVal pMilliseconds As Integer)
        Dim F As DateTime
        Dim Salir As Boolean = False
        F = Now.AddMilliseconds(pMilliseconds)
        While Not Salir
            If Now >= F Then
                Salir = True
            End If
        End While
    End Sub

    Public Sub New()
        Try
            _ObjFSO = CreateObject("Scripting.FileSystemObject")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Protected MustOverride Sub Print_Doc()

    Protected Function Alinea_Columnas(ByVal pTexto As String, ByVal pRellena_Espacios As Boolean, ByVal pAntes_Texto As Boolean, ByVal pcaracteres As Integer) As String
        Dim Texto As String = pTexto
        Dim Espacios As String = ""
        Dim largo As Integer
        Dim I As Integer
        largo = Texto.Length
        If pRellena_Espacios Then
            For I = largo To pcaracteres - 1
                Espacios = Espacios + " "
            Next I
        Else
            For I = 1 To pcaracteres - 1
                Espacios = Espacios + " "
            Next I
        End If
        If pAntes_Texto Then
            Texto = Espacios + Texto
        Else
            Texto = Texto + Espacios
        End If
        Return Texto

    End Function

    Protected Function Alinea_Columnas(ByVal pTexto As String, ByVal pLenCol As Integer, ByVal pllenaIZQ As Boolean) As String

        Dim Result As String = ""
        Dim l As Integer = pTexto.Length
        Dim i As Integer
        For i = l To pLenCol
            Result = Result & " "
        Next
        If pllenaIZQ Then
            Result = Result & pTexto
        Else
            Result = pTexto & Result
        End If
        Return Result

    End Function

    Private Function Cambiar_ANSII(ByVal pStr As String) As String
        Dim Result As String = pStr
        Result = Result.Replace("á", "a")
        Result = Result.Replace("é", "e")
        Result = Result.Replace("í", "i")
        Result = Result.Replace("ó", "o")
        Result = Result.Replace("ú", "u")
        Result = Result.Replace("ñ", "n")
        Result = Result.Replace("Ñ", "N")
        Result = Result.Replace("¢", " ")
        Result = Result.Replace("$", Chr(36))
        Return Result
    End Function

    Protected Sub Begin_Doc(pOpenCashDrawer As Boolean)
        If pOpenCashDrawer Then
            ObjStream.Writeline(Chr(27) & "p" & Chr(&H0) & Chr(&H64) & Chr(&H64)) ' este abre el cajon del dinero  
        End If
    End Sub
    Protected Sub End_Doc()
        ObjStream.Writeline(Chr(27) & Chr(109)) ' este es un corte de ticket, no completo  
        ObjStream.Writeline(Chr(27) & Chr(64)) ' limpia Buffer de la impresora  
        ObjStream.Writeline(Chr(27) & Chr(60)) ' la deja en Posicion Stand BY  

        ObjStream.Close()
    End Sub

    Public Function Print(ByVal pPort As String, ByVal pOpenCashDrawer As Boolean) As Boolean
        _Port = pPort
        _ObjStream = ObjFSO.CreateTextFile(_Port) 'Puerto al cual se envía la impresión  
        Begin_Doc(pOpenCashDrawer)
        Print_Doc()
        End_Doc()
        Return True
    End Function
End Class
