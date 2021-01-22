Imports System.Net.Mail
'Jimmy Trejos Valverde
Public Class TEmailManagement

#Region "Variables"
    Private _FromAddress As String
    Private _ToAddress As String
    Private _MailServer As String
    Private _IsHTMLBody As Boolean
    Private _Body As String
    Private _Subject As String
    Private _Priority As System.Net.Mail.MailPriority
    Private _ErrorMessage As String
    Private _MailAddressesTo As MailAddressCollection
    Private _MailAddressesCC As MailAddressCollection
    Private _MailAddressesBCC As MailAddressCollection
    Private _UserName As String
    Private _Password As String
#End Region
#Region "Propiedades"
    Public Property Body() As String
        Get
            Return _Body
        End Get
        Set(ByVal value As String)
            _Body = "<HTML><BODY><B>" & value & "</B></BODY></HTML>"
        End Set
    End Property
    Public Property ErrorMessage() As String
        Get
            Return _ErrorMessage
        End Get
        Set(ByVal value As String)
            _ErrorMessage = value
        End Set
    End Property
    Public Property IsHTMLBody() As Boolean
        Get
            Return _IsHTMLBody
        End Get
        Set(ByVal value As Boolean)
            _IsHTMLBody = value
        End Set
    End Property
    Public Property MailServer() As String
        Get
            Return _MailServer
        End Get
        Set(ByVal value As String)
            _MailServer = value
        End Set
    End Property
    Public Property Priority() As System.Net.Mail.MailPriority
        Get
            Return _Priority
        End Get
        Set(ByVal value As System.Net.Mail.MailPriority)
            _Priority = value
        End Set
    End Property
    Public Property Subject() As String
        Get
            Return _Subject
        End Get
        Set(ByVal value As String)
            _Subject = value
        End Set
    End Property
    Public Property ToAddress() As String
        Get
            Return _ToAddress
        End Get
        Set(ByVal value As String)
            _ToAddress = value
        End Set
    End Property
    Public Property FromAddress() As String
        Get
            Return _FromAddress
        End Get
        Set(ByVal value As String)
            _FromAddress = value
        End Set
    End Property

    Public Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal value As String)
            _Password = value
        End Set
    End Property


#End Region
#Region "Constructores"
    Public Sub New()
        _FromAddress = ""
        _ToAddress = ""
        _MailServer = ""
        _IsHTMLBody = True
        _Body = ""
        _Subject = ""
        _Priority = MailPriority.Normal
        _ErrorMessage = ""
        _MailAddressesTo = New MailAddressCollection
        _MailAddressesCC = New MailAddressCollection
        _MailAddressesBCC = New MailAddressCollection
        _UserName = ""
        _Password = ""
    End Sub
#End Region
#Region "Metodos Publicos"
    Public Function SendMail() As String
        Dim Message As New MailMessage
        Dim Server As New SmtpClient(_MailServer)
        Dim i As Integer
        Dim UserCredentials As System.Net.NetworkCredential = Nothing
        Try

            If _UserName <> "" Then
                Server.UseDefaultCredentials = True
                UserCredentials = New System.Net.NetworkCredential
                UserCredentials.UserName = _UserName
                UserCredentials.Password = _Password
                Server.Credentials = UserCredentials
            End If

            For i = 0 To _MailAddressesTo.Count - 1
                Message.To.Add(_MailAddressesTo(i).Address)
            Next

            For i = 0 To _MailAddressesCC.Count - 1
                Message.CC.Add(_MailAddressesCC(i).Address)
            Next

            For i = 0 To _MailAddressesBCC.Count - 1
                Message.Bcc.Add(_MailAddressesBCC(i).Address)
            Next


            If Message.To.Count > 0 Then
                Message.From = New MailAddress(_FromAddress)
                Message.Subject = _Subject
                Message.IsBodyHtml = _IsHTMLBody
                Message.Body = _Body
                Message.Priority = _IsHTMLBody
                Server.Send(Message)
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Public Sub CreateAddressListTo(ByVal pAddressListStr As String)
        Dim AddressStr As String = ""
        Dim Pos As Integer = 0

        _MailAddressesTo.Clear()

        While pAddressListStr.Length > 0
            Pos = InStr(pAddressListStr, ";", CompareMethod.Text)

            If Pos > 0 Then
                AddressStr = Mid(pAddressListStr, 1, Pos - 1)
                pAddressListStr = Mid(pAddressListStr, Pos + 1)
            Else
                AddressStr = pAddressListStr
                pAddressListStr = ""
            End If

            _MailAddressesTo.Add(AddressStr)
        End While

    End Sub

    Public Sub CreateAddressListCC(ByVal pAddressListStr As String)
        Dim AddressStr As String = ""
        Dim Pos As Integer = 0

        _MailAddressesCC.Clear()

        While pAddressListStr.Length > 0
            Pos = InStr(pAddressListStr, ";", CompareMethod.Text)

            If Pos > 0 Then
                AddressStr = Mid(pAddressListStr, 1, Pos - 1)
                pAddressListStr = Mid(pAddressListStr, Pos + 1)
            Else
                AddressStr = pAddressListStr
                pAddressListStr = ""
            End If

            _MailAddressesCC.Add(AddressStr)
        End While

    End Sub

    Public Sub CreateAddressListBCC(ByVal pAddressListStr As String)
        Dim AddressStr As String = ""
        Dim Pos As Integer = 0

        _MailAddressesBCC.Clear()

        While pAddressListStr.Length > 0
            Pos = InStr(pAddressListStr, ";", CompareMethod.Text)

            If Pos > 0 Then
                AddressStr = Mid(pAddressListStr, 1, Pos - 1)
                pAddressListStr = Mid(pAddressListStr, Pos + 1)
            Else
                AddressStr = pAddressListStr
                pAddressListStr = ""
            End If

            _MailAddressesBCC.Add(AddressStr)
        End While
    End Sub


#End Region
End Class
