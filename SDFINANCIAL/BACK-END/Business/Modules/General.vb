Imports Microsoft.Win32
Imports System.Net
Imports System.Configuration
Public Module General
    Public Function FormatearOpcionesRegionales() As Boolean
        Try
            My.Application.ChangeCulture("en-US")

            Return True
        Catch ex As Exception
            MsgBox("Error cargando la cultura [en-US]: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function GetConnectionString() As String
        Dim CnStr As String = ""

        Try
            CnStr = UnLockPassword(System.Configuration.ConfigurationManager.ConnectionStrings(coConexionBD).ConnectionString)

            Return CnStr
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function UnLockPassword(ByVal key As String) As String
        Dim sResultado As String = Convert.ToString(System.Text.Encoding.UTF8.GetChars(Convert.FromBase64String(key)))
        Return sResultado.Substring(0, sResultado.Length)
    End Function

    Public Function LockPassword(ByVal key As String) As String
        Dim ValueAndSalt As String = String.Concat(key)
        Dim byteValue() As Byte = System.Text.Encoding.UTF8.GetBytes(ValueAndSalt)
        Return (Convert.ToBase64String(byteValue))
    End Function

    Public Sub VerificaMensaje(ByVal pMensaje As String)
        If pMensaje.Trim <> "" Then
            Throw New Exception(pMensaje)
        End If
    End Sub

    Public Function GetIPV4() As String
        Dim myHost As String = Dns.GetHostName
        Dim ipEntry As IPHostEntry = Dns.GetHostEntry(myHost)
        Dim ip As String = ""

        For Each tmpIpAddress As IPAddress In ipEntry.AddressList
            If tmpIpAddress.AddressFamily = Sockets.AddressFamily.InterNetwork Then
                Dim ipAddress As String = tmpIpAddress.ToString
                ip = ipAddress
                Exit For
            End If
        Next

        If ip = "" Then
            Throw New Exception("No 10. IP found!")
        End If

        Return ip
    End Function

End Module
