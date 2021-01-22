Imports System.Drawing
Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.IO.Ports.SerialPort
Imports System.IO.Ports
Imports Business
Public Enum PrintLocation
    Serial = 0
    Paralelo = 1
    ParaleloPuerto = 2
    Carta1 = 3
    Perfumes = 4
    PerfumesPOS = 5
End Enum

Public Enum EpsonDrawer
    epsPin2 = 0
    epsPin5 = 1
End Enum

Public Enum PrintJustification
    epsleft = 0
    epsCenter = 1
    epsRight = 2
End Enum

Public Enum PrintFont
    FontTitulo
    FontSingle
End Enum


Public Class TPrintLine

    Public Str As String
    Public pFont As PrintFont
    Public pAlign As PrintJustification
    Public pBold As Boolean
    Public X As Integer
    Public Y As Integer
    Public inc As Integer

End Class

Public MustInherit Class TPrint

#Region "Definicion de Variables Locales"
    Protected _MsgError As String
    Protected _Location As PrintLocation
    Private _lines As ArrayList
    Private _SerialPort As IO.Ports.SerialPort
    Private _ParaleloPort As PrintDocument


#End Region


#Region "Definicion  Constructor"

    Public Sub New()
        _lines = New ArrayList
        _MsgError = ""
    End Sub
#End Region

#Region "Metodos de Puerto Serial"

    Private Function ConnectSerial() As Boolean
        Dim Result As Boolean = False
        Try
            If _SerialPort.IsOpen Then
                _SerialPort.Close()
            End If

            With _SerialPort
                .PortName = InfoMaquina.ComPort
                .BaudRate = 9600
                .Parity = IO.Ports.Parity.None
                .DataBits = 8
                .StopBits = IO.Ports.StopBits.One
            End With
            _SerialPort.Open()
            Result = True
        Catch ex As Exception
            _MsgError = ex.Message
        End Try
        Return Result
    End Function

    Private Function DisconnectSerial() As Boolean
        Dim Result As Boolean = False
        Try
            _SerialPort.Close()
            Result = True
        Catch ex As Exception
            _MsgError = ex.Message
        End Try
        Return Result
    End Function

    Private Function SendToSerial(ByVal Str As String) As Boolean
        Dim Result As Boolean = True
        Try
            _SerialPort.Write(Cambiar_ANSII(Str))
            Result = True
        Catch ex As Exception

        End Try
        Return Result
    End Function

    Private Function OpenCashDrawerSerial(ByVal pPin As EpsonDrawer, ByVal pOn As Integer, ByVal pOff As Integer) As Boolean
        Return SendToSerial(Chr(27) & Chr(112) & Chr(pPin) & Chr(pOn) & Chr(pOff))
    End Function

    Private Function SetBoldSerial(ByVal pBold As Boolean) As Boolean
        Return SendToSerial(Chr(27) & Chr(69) & Chr(IIf(pBold, 1, 0)))
    End Function

    Private Function SetJustificationSerial(ByVal pJustification As PrintJustification) As Boolean
        Return SendToSerial(Chr(27) & Chr(97) & Chr(pJustification))
    End Function

    Private Function SetFontSerial(ByVal pSize7x9 As Boolean, ByVal pBold As Boolean, ByVal pDoubleHeight As Boolean, ByVal pDoubleWidth As Boolean, ByVal pUnderline As Boolean) As Boolean
        Return SendToSerial(Chr(27) & Chr(33) & Chr(IIf(pSize7x9, 1, 0) + IIf(pBold, 8, 0) + IIf(pDoubleHeight, 16, 0) + IIf(pDoubleWidth, 32, 0) + IIf(pUnderline, 128, 0)))
    End Function

#End Region

#Region "Metodos de Puerto Paralelo"

    Private Sub SendtoParalelo(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim Linea As TPrintLine
        Dim _font As Font
        Dim _font2 As Font
        Dim Font As Font
        Dim _Alignment As System.Drawing.StringFormat
        Dim _Alignment_Center As System.Drawing.StringFormat
        Dim _Alignment_Left As System.Drawing.StringFormat
        Dim _Alignment_Rigth As System.Drawing.StringFormat
        '_font = New Font("Courier New", 8)
        '_font2 = New Font("Courier New", 14)

        _font = New Font("Verdana", 8, FontStyle.Regular)
        _font2 = New Font("Verdana", 12, FontStyle.Regular)

        _Alignment_Center = New System.Drawing.StringFormat
        _Alignment_Left = New System.Drawing.StringFormat
        _Alignment_Rigth = New System.Drawing.StringFormat
        _Alignment_Center.Alignment = StringAlignment.Center
        _Alignment_Left.Alignment = StringAlignment.Near
        _Alignment_Rigth.Alignment = StringAlignment.Far
        For Each Linea In _lines
            If Linea.pFont = PrintFont.FontSingle Then
                Font = _font
            Else
                Font = _font2
            End If
            If Linea.pAlign = PrintJustification.epsCenter Then
                _Alignment = _Alignment_Center
            ElseIf Linea.pAlign = PrintJustification.epsleft Then
                _Alignment = _Alignment_Left
            Else
                _Alignment = _Alignment_Rigth
            End If

            ev.Graphics.DrawString(Linea.Str, Font, Brushes.Black, Linea.X, Linea.Y, _Alignment)
            'ev.Graphics.DrawString(Linea.Str, New Font("Verdana", 8, FontStyle.Regular), Brushes.Black, Linea.X, Linea.Y, _Alignment)
        Next
    End Sub

    Private Sub OpenCashDrawerParalelo()

    End Sub

#End Region

#Region "Metodos para imprimir"

    Protected Sub Begin_Doc(pOpenCashDrawer As Boolean)

        _lines.Clear()
        If _Location = PrintLocation.Serial Then
            _SerialPort = New IO.Ports.SerialPort
            ConnectSerial()

            'Dim msg As String = _SerialPort.ReadExisting()
            ''display the data to the user
            'Dim _msg As String = msg

            'Abre la gaveta, al inicio para que de tiempo de dar vueltos
            If pOpenCashDrawer Then
                OpenCashDrawerSerial(EpsonDrawer.epsPin2, 50, 150)
            End If
        Else
            _ParaleloPort = New PrintDocument()
            AddHandler _ParaleloPort.PrintPage, AddressOf SendtoParalelo
        End If
    End Sub

    Protected Sub End_Doc(ByVal pPaperCut As Boolean)
        If _Location = PrintLocation.Serial Then
            Send("  ", PrintFont.FontSingle, 200, 0, PrintJustification.epsleft, 1)
            Send("  ", PrintFont.FontSingle, 200, 0, PrintJustification.epsleft, 1)
            Send("  ", PrintFont.FontSingle, 200, 0, PrintJustification.epsleft, 1)
            'Send("  ", PrintFont.FontSingle, 200, 0, PrintJustification.epsleft, 1)
            'Send("  ", PrintFont.FontSingle, 200, 0, PrintJustification.epsleft, 1)
            'Send("  ", PrintFont.FontSingle, 200, 0, PrintJustification.epsleft, 1)
            'Send("  ", PrintFont.FontSingle, 200, 0, PrintJustification.epsleft, 1)
            'Send("  ", PrintFont.FontSingle, 200, 0, PrintJustification.epsleft, 1)
            'Send("  ", PrintFont.FontSingle, 200, 0, PrintJustification.epsleft, 1)
            'Send("  ", PrintFont.FontSingle, 200, 0, PrintJustification.epsleft, 1)
            'Send("  ", PrintFont.FontSingle, 200, 0, PrintJustification.epsleft, 1)
            'Send("  ", PrintFont.FontSingle, 200, 0, PrintJustification.epsleft, 1)
            'Send("  ", PrintFont.FontSingle, 200, 0, PrintJustification.epsleft, 1)
            'Send("  ", PrintFont.FontSingle, 200, 0, PrintJustification.epsleft, 1)
            'Send("  ", PrintFont.FontSingle, 200, 0, PrintJustification.epsleft, 1)


            If pPaperCut Then
                CortaPapel()
            End If

            'If pOpenCashDrawer Then
            '    OpenCashDrawerSerial(EpsonDrawer.epsPin2, 50, 150)
            'End If

            DisconnectSerial()
        Else
            OpenCashDrawerParalelo()
            _ParaleloPort.Print()
        End If
        _lines.Clear()
    End Sub

    Protected Sub Send(ByVal Str As String, ByVal pFont As PrintFont, ByVal X As Integer, ByRef Y As Integer, ByVal pAlign As PrintJustification, ByVal inc As Integer)
        If _Location = PrintLocation.Serial Then
            SetJustificationSerial(pAlign)
            If inc > 0 Then
                SendToSerial(Str & vbCrLf)
            Else
                SendToSerial(Str)
            End If
        Else
            Dim Linea As New TPrintLine
            Linea.Str = Str
            Linea.pAlign = pAlign
            Linea.pFont = pFont
            Linea.pBold = False
            Linea.X = X
            Linea.Y = Y
            Linea.inc = inc
            _lines.Add(Linea)
        End If
        Y = Y + inc
    End Sub

    Protected Sub Sleep(ByVal pMilliseconds As Integer)
        If _Location = PrintLocation.Serial Then
            Dim F As DateTime
            Dim Salir As Boolean = False
            F = Now.AddMilliseconds(pMilliseconds)
            While Not Salir
                If Now >= F Then
                    Salir = True
                End If
            End While
        End If
    End Sub

    Protected MustOverride Sub Print_Doc()

    Protected Sub Segmenta_Pie_Ticket(ByVal pTexto As String, ByVal pMaximo As Integer, ByVal pFont As PrintFont, ByVal pX As Integer, ByRef pY As Integer, ByVal pAlineado As PrintJustification, ByVal pSalto As Integer)
        Dim Texto As String = pTexto
        Dim A_Imprimir As String = ""
        Dim Texto_Corte As String = ""
        Dim Puntero As Integer = 0
        Dim Muestra As String = ""
        Dim Corte_ini As Integer = 0
        Dim Corte_Fin As Integer = 1
        Dim Corte_Ant As Integer = 1
        Dim extraer As Integer = 0
        Dim Caracter As Integer
        If Texto = Nothing Then
            Exit Sub
        End If
        If Texto.Length > pMaximo Then
            While Puntero <> Texto.Length
                Muestra = Texto.Substring(Puntero, 1)

                If Muestra = " " Then
                    If extraer = 0 Then
                        Texto_Corte = Texto.Substring(Corte_ini, Puntero)
                    Else
                        Texto_Corte = Texto.Substring(Corte_ini, extraer)
                    End If
                    If Texto_Corte.Length <= pMaximo Then
                        Corte_Fin = Puntero
                    Else
                        A_Imprimir = Texto.Substring(Corte_ini, Corte_Fin)
                        Corte_ini = Corte_Fin + 1
                        Send(A_Imprimir, pFont, pX, pY, pAlineado, pSalto)
                        pY = pY + pSalto
                        Puntero = Corte_Fin
                        Caracter = CInt(Texto.Length) - Puntero - 1
                        A_Imprimir = Texto.Substring(Corte_ini, Caracter)
                        If A_Imprimir.Length <= pMaximo Then
                            Send(A_Imprimir, PrintFont.FontSingle, 120, pY, PrintJustification.epsCenter, 15)
                            Exit While
                        Else
                            extraer = Corte_ini
                        End If
                    End If

                End If

                Muestra = ""
                Puntero = Puntero + 1
            End While
        Else
            Send(Texto, pFont, pX, pY, pAlineado, pSalto)
        End If
    End Sub

    Protected Sub CortaPapel()
        SendToSerial(Chr(&H1D) & "V" & Chr(66) & Chr(0))
    End Sub

#End Region

#Region "Metodos para sobreescribir"

    Public Function Print(ByVal pLocation As PrintLocation, ByVal pOpenCashDrawer As Boolean) As Boolean
        _Location = pLocation
        Begin_Doc(pOpenCashDrawer)
        Print_Doc()
        End_Doc(True)
        Return True
    End Function

#End Region

#Region "Metodos para manejo de String"

    Protected Function Alinea_Columnas(ByVal pTexto As String, ByVal pRellena_Espacios As Boolean, ByVal pAntes_Texto As Boolean, ByVal pcaracteres As Integer) As String
        If _Location = PrintLocation.Serial Then
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
        Else
            Return pTexto
        End If
    End Function

    Protected Function Alinea_Columnas(ByVal pTexto As String, ByVal pLenCol As Integer, ByVal pllenaIZQ As Boolean) As String
        If _Location = PrintLocation.Serial Then
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
        Else
            Return pTexto
        End If
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

#End Region

End Class
