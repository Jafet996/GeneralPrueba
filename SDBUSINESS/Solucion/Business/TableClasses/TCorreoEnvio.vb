Public Class TCorreoEnvio
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Correo_Id As Long
    Private _Emp_Id As Integer
    Private _Desde As String
    Private _Para As String
    Private _Asunto As String
    Private _Mensaje As String
    Private _Fecha As Datetime
    Private _Enviado As Integer
    Private _FechaEnvio As Datetime
    Private _Modulo_Id As Integer
    Private _Usuario_Id As String
    Private _Data As DataSet

#End Region

#Region "Definicion de propiedades"

    Public Property Correo_Id() As Long
        Get
            Return _Correo_Id
        End Get
        Set(ByVal Value As Long)
            _Correo_Id = Value
        End Set
    End Property
    Public Property Emp_Id() As Integer
        Get
            Return _Emp_Id
        End Get
        Set(ByVal Value As Integer)
            _Emp_Id = Value
        End Set
    End Property
    Public Property Desde() As String
        Get
            Return _Desde
        End Get
        Set(ByVal Value As String)
            _Desde = Value
        End Set
    End Property
    Public Property Para() As String
        Get
            Return _Para
        End Get
        Set(ByVal Value As String)
            _Para = Value
        End Set
    End Property
    Public Property Asunto() As String
        Get
            Return _Asunto
        End Get
        Set(ByVal Value As String)
            _Asunto = Value
        End Set
    End Property
    Public Property Mensaje() As String
        Get
            Return _Mensaje
        End Get
        Set(ByVal Value As String)
            _Mensaje = Value
        End Set
    End Property
    Public Property Fecha() As Datetime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As Datetime)
            _Fecha = Value
        End Set
    End Property
    Public Property Enviado() As Integer
        Get
            Return _Enviado
        End Get
        Set(ByVal Value As Integer)
            _Enviado = Value
        End Set
    End Property
    Public Property FechaEnvio() As Datetime
        Get
            Return _FechaEnvio
        End Get
        Set(ByVal Value As Datetime)
            _FechaEnvio = Value
        End Set
    End Property
    Public Property Modulo_Id() As Integer
        Get
            Return _Modulo_Id
        End Get
        Set(ByVal Value As Integer)
            _Modulo_Id = Value
        End Set
    End Property
    Public Property Usuario_Id() As String
        Get
            Return _Usuario_Id
        End Get
        Set(ByVal Value As String)
            _Usuario_Id = Value
        End Set
    End Property
    Public ReadOnly Property Data() As DataSet
        Get
            Return _Data
        End Get
    End Property
    Public ReadOnly Property RowsAffected() As Long
        Get
            Return Cn.RowsAffected
        End Get
    End Property


#End Region
#Region "Constructores"
    Public Sub New(pEmp_Id As Integer)
        MyBase.New()
        Inicializa()
        _Emp_Id = pEmp_Id
    End Sub
    Public Sub New(pEmp_Id As Integer, ByVal pCnStr As String)
        MyBase.New(pCnStr)
        Inicializa()
        _Emp_Id = pEmp_Id
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _Correo_Id = 0
        _Emp_Id = 0
        _Desde = ""
        _Para = ""
        _Asunto = ""
        _Mensaje = ""
        _Fecha = CDate("1900/01/01")
        _Enviado = 0
        _FechaEnvio = CDate("1900/01/01")
        _Modulo_Id = 0
        _Usuario_Id = ""
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            query = " Insert into CorreoEnvio( Correo_Id , Emp_Id" & _
                   " , Desde , Para" & _
                   " , Asunto , Mensaje" & _
                   " , Fecha , Enviado" & _
                   " , FechaEnvio , Modulo_Id" & _
                   " , Usuario_Id )" & _
                   " Values ( " & _Correo_Id.ToString() & "," & _Emp_Id.ToString() & _
                   ",'" & _Desde & "'" & ",'" & _Para & "'" & _
                   ",'" & _Asunto & "'" & ",'" & _Mensaje & "'" & _
                   ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _Enviado.ToString() & _
                   ",'" & Format(_FechaEnvio, "yyyyMMdd HH:mm:ss") & "'" & "," & _Modulo_Id.ToString() & _
                   ",'" & _Usuario_Id & "'" & ")"

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function Delete() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            query = "Delete CorreoEnvio" & _
               " Where     Correo_Id=" & _Correo_Id.ToString()

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function Modify() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            query = " Update dbo.CorreoEnvio " & _
                      " SET    Emp_Id=" & _Emp_Id.ToString() & "," & _
                      " Desde='" & _Desde & "'" & "," & _
                      " Para='" & _Para & "'" & "," & _
                      " Asunto='" & _Asunto & "'" & "," & _
                      " Mensaje='" & _Mensaje & "'" & "," & _
                      " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                      " Enviado=" & _Enviado & "," & _
                      " FechaEnvio='" & Format(_FechaEnvio, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                      " Modulo_Id=" & _Modulo_Id & "," & _
                      " Usuario_Id='" & _Usuario_Id & "'" & _
                      " Where     Correo_Id=" & _Correo_Id.ToString()

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function ListKey() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select * From CorreoEnvio" & _
           " Where     Correo_Id=" & _Correo_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Correo_Id = Tabla.Rows(0).Item("Correo_Id")
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Desde = Tabla.Rows(0).Item("Desde")
                _Para = Tabla.Rows(0).Item("Para")
                _Asunto = Tabla.Rows(0).Item("Asunto")
                _Mensaje = Tabla.Rows(0).Item("Mensaje")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Enviado = Tabla.Rows(0).Item("Enviado")
                _FechaEnvio = Tabla.Rows(0).Item("FechaEnvio")
                _Modulo_Id = Tabla.Rows(0).Item("Modulo_Id")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function List() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select * From CorreoEnvio"

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function LoadComboBox(pCombo As System.Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select CorreoEnvio_Id as Numero, Nombre From CorreoEnvio"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing Then
                pCombo.DataSource = Nothing
                pCombo.DataSource = Tabla
                pCombo.DisplayMember = "Nombre"
                pCombo.ValueMember = "Numero"
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function CorreosPendientes()
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "Select * From CorreoEnvio" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " and   Enviado = 0"

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Cn.Close()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function
    Public Function EliminacionAutomatica() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "Delete CorreoEnvio" & _
                    " Where DATEDIFF (day,fecha,getdate()) >= 30" & _
                    " And   Enviado = 1" & _
                    " And   Emp_Id = " & _Emp_Id.ToString

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
#End Region
End Class
