Imports System

Imports System.Net

Imports System.Net.Sockets

Imports System.Threading

Imports System.Text

Imports System.IO



Public Class ClientSocked



#Region "VARIABLES"

    Private Stm As NetworkStream 'Utilizado para enviar datos al Servidor y recibir datos del mismo 

    Private m_IPDelHost As String 'Direccion del objeto de la clase Servidor 

    Private m_PuertoDelHost As String 'Puerto donde escucha el objeto de la clase Servidor 

    Private _DescripcionSocket As String
    Private _NumSocket As String


    Private _Conectado As Boolean

#End Region


#Region "EVENTOS"

    Public Event ConexionTerminada(ByVal pNumSocket As String, ByVal pDescripcionSocket As String)

    Public Event DatosRecibidos(ByVal datos As String, ByVal pNumSocket As String, ByVal pDescripcionSocket As String)

    Public Event DatosEnviados(ByVal Mensaje As String, ByVal FechaHora As Date, ByVal pNumSocket As String, ByVal pDescripcionSocket As String)

#End Region



#Region "PROPIEDADES"
    Public Property DescripcionSocket() As String
        Get
            Return _DescripcionSocket
        End Get
        Set(ByVal value As String)
            _DescripcionSocket = value
        End Set
    End Property
    Public Property NumSocket() As String
        Get
            Return _NumSocket
        End Get
        Set(ByVal value As String)
            _NumSocket = value
        End Set
    End Property

    Public Property IPDelHost() As String

        Get

            IPDelHost = m_IPDelHost

        End Get



        Set(ByVal Value As String)

            m_IPDelHost = Value

        End Set

    End Property



    Public Property PuertoDelHost() As String

        Get

            PuertoDelHost = m_PuertoDelHost

        End Get

        Set(ByVal Value As String)

            m_PuertoDelHost = Value

        End Set

    End Property

    Public Property Conectado() As Boolean
        Get
            Return _Conectado
        End Get
        Set(ByVal value As Boolean)
            _Conectado = value
        End Set
    End Property

#End Region



#Region "METODOS"

    Public Function Conectar() As String
        Try

            Dim tcpClnt As TcpClient

            Dim tcpThd As Thread 'Se encarga de escuchar mensajes enviados por el Servidor 

            tcpClnt = New TcpClient()

            'Me conecto al objeto de la clase Servidor, 

            '  determinado por las propiedades IPDelHost y PuertoDelHost 

            tcpClnt.Connect(IPDelHost, PuertoDelHost)
            tcpClnt.ReceiveBufferSize = 100000

            Stm = tcpClnt.GetStream()

            'Creo e inicio un thread para que escuche los mensajes enviados por el Servidor 

            tcpThd = New Thread(AddressOf LeerSocket)


            tcpThd.Start(tcpClnt)

            Return ""

        Catch ex As Exception
            _Conectado = False
            Return ex.Message
        End Try

    End Function

    Public Sub EnviarDatos(ByVal Datos As String)
        Dim BufferDeEscritura() As Byte

        BufferDeEscritura = Encoding.ASCII.GetBytes(Datos)

        If Not (Stm Is Nothing) Then
            'Envio los datos al Servidor 
            Stm.Write(BufferDeEscritura, 0, BufferDeEscritura.Length)

            RaiseEvent DatosEnviados(Datos, Now, _NumSocket, _DescripcionSocket)
        End If

    End Sub



#End Region



#Region "FUNCIONES PRIVADAS"

    Private Sub LeerSocket(ByVal ptcpClnt As TcpClient)
        Dim BufferDeLectura() As Byte

        While True
            Try
                BufferDeLectura = New Byte(ptcpClnt.ReceiveBufferSize) {}
                'Me quedo esperando a que llegue algun mensaje 

                _Conectado = True

                Stm.Read(BufferDeLectura, 0, BufferDeLectura.Length)

                'Genero el evento DatosRecibidos, ya que se han recibido datos desde el Servidor 
                If EntradaValida(BufferDeLectura) Then
                    RaiseEvent DatosRecibidos(Encoding.ASCII.GetString(BufferDeLectura), _NumSocket, _DescripcionSocket)
                End If

            Catch e As Exception

                Exit While

            End Try
        End While



        'Finalizo la conexion, por lo tanto genero el evento correspondiente 

        _Conectado = False

        RaiseEvent ConexionTerminada(_NumSocket, _DescripcionSocket)

    End Sub


    Private Function EntradaValida(ByVal BufferDeLectura() As Byte) As Boolean
        Dim i As Integer
        EntradaValida = False

        For i = 0 To UBound(BufferDeLectura) - 1
            If BufferDeLectura(i) <> 0 Then
                EntradaValida = True
                Exit For
            End If
        Next

    End Function

#End Region



    Public Sub New()
        _Conectado = False
    End Sub
End Class


