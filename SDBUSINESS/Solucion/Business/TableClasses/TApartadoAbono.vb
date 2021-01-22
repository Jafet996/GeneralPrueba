Public Class TApartadoAbono
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Apartado_Id As Long
    Private _Abono_Id As Integer
    Private _Fecha As DateTime
    Private _Monto As Double
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _Usuario_Id As String
    Private _CPU As String
    Private _HostName As String
    Private _IPAddress As String
    Private _Anulado As Boolean
    Private _AnuladoFecha As DateTime
    Private _Usuario As TUsuario
    Private _Data As DataSet
    Private _Saldo As Double
    Private _Sucursal As String
    Private _Cliente As String
    Private _FechaVencimiento As DateTime
    Private _Detalle As List(Of TApartadoDetalle)
#End Region

#Region "Definicion de propiedades"

    Public Property Emp_Id() As Integer
        Get
            Return _Emp_Id
        End Get
        Set(ByVal Value As Integer)
            _Emp_Id = Value
        End Set
    End Property
    Public Property Suc_Id() As Integer
        Get
            Return _Suc_Id
        End Get
        Set(ByVal Value As Integer)
            _Suc_Id = Value
        End Set
    End Property
    Public Property Apartado_Id() As Long
        Get
            Return _Apartado_Id
        End Get
        Set(ByVal Value As Long)
            _Apartado_Id = Value
        End Set
    End Property
    Public Property Abono_Id() As Integer
        Get
            Return _Abono_Id
        End Get
        Set(ByVal Value As Integer)
            _Abono_Id = Value
        End Set
    End Property
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As DateTime)
            _Fecha = Value
        End Set
    End Property
    Public Property Monto() As Double
        Get
            Return _Monto
        End Get
        Set(ByVal Value As Double)
            _Monto = Value
        End Set
    End Property
    Public Property Caja_Id() As Integer
        Get
            Return _Caja_Id
        End Get
        Set(ByVal Value As Integer)
            _Caja_Id = Value
        End Set
    End Property
    Public Property Cierre_Id() As Integer
        Get
            Return _Cierre_Id
        End Get
        Set(ByVal Value As Integer)
            _Cierre_Id = Value
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
    Public Property CPU() As String
        Get
            Return _CPU
        End Get
        Set(ByVal Value As String)
            _CPU = Value
        End Set
    End Property
    Public Property HostName() As String
        Get
            Return _HostName
        End Get
        Set(ByVal Value As String)
            _HostName = Value
        End Set
    End Property
    Public Property IPAddress() As String
        Get
            Return _IPAddress
        End Get
        Set(ByVal Value As String)
            _IPAddress = Value
        End Set
    End Property
    Public Property Anulado() As Boolean
        Get
            Return _Anulado
        End Get
        Set(ByVal Value As Boolean)
            _Anulado = Value
        End Set
    End Property
    Public Property AnuladoFecha() As DateTime
        Get
            Return _AnuladoFecha
        End Get
        Set(ByVal Value As DateTime)
            _AnuladoFecha = Value
        End Set
    End Property

    Public Property Usuario() As TUsuario
        Get
            Return _Usuario
        End Get
        Set(ByVal Value As TUsuario)
            _Usuario = Value
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
    Public Property Saldo() As Double
        Get
            Return _Saldo
        End Get
        Set(ByVal Value As Double)
            _Saldo = Value
        End Set
    End Property
    Public Property Sucursal() As String
        Get
            Return _Sucursal
        End Get
        Set(ByVal Value As String)
            _Sucursal = Value
        End Set
    End Property
    Public Property Cliente() As String
        Get
            Return _Cliente
        End Get
        Set(ByVal Value As String)
            _Cliente = Value
        End Set
    End Property
    Public Property FechaVencimiento() As DateTime
        Get
            Return _FechaVencimiento
        End Get
        Set(ByVal Value As DateTime)
            _FechaVencimiento = Value
        End Set
    End Property
    Public Property Detalle() As List(Of TApartadoDetalle)
        Get
            Return _Detalle
        End Get
        Set(ByVal Value As List(Of TApartadoDetalle))
            _Detalle = Value
        End Set
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
        _Emp_Id = 0
        _Suc_Id = 0
        _Apartado_Id = 0
        _Abono_Id = 0
        _Fecha = CDate("1900/01/01")
        _Monto = 0
        _Caja_Id = 0
        _Cierre_Id = 0
        _Usuario_Id = ""
        _CPU = ""
        _HostName = ""
        _IPAddress = ""
        _Anulado = 0
        _AnuladoFecha = CDate("1900/01/01")
        _Usuario = New TUsuario(EmpresaParametroInfo.Emp_Id)
        _Data = New DataSet
    End Sub
#End Region

#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into ApartadoAbono( Emp_Id , Suc_Id" &
                   " , Apartado_Id , Abono_Id" &
                   " , Fecha , Monto" &
                   " , Caja_Id , Cierre_Id" &
                   " , Usuario_Id , CPU" &
                   " , HostName , IPAddress" &
                   " , Anulado , AnuladoFecha" &
                   " )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Apartado_Id.ToString() & "," & _Abono_Id.ToString() &
                   ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & ",'" & _Monto & "'" &
                   "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString() &
                   ",'" & _Usuario_Id & "'" & ",'" & _CPU & "'" &
                   ",'" & _HostName & "'" & ",'" & _IPAddress & "'" &
                   "," & _Anulado.ToString() & ",'" & Format(_AnuladoFecha, "yyyyMMdd HH:mm:ss") & "'" &
                   ")"

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

            Query = "Delete ApartadoAbono" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And    Suc_Id=" & _Suc_Id.ToString() &
               " And    Apartado_Id=" & _Apartado_Id.ToString() &
               " And    Abono_Id=" & _Abono_Id.ToString()

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

            Query = " Update dbo.ApartadoAbono " &
                      " SET    Fecha=" & _Fecha.ToString() & "," &
                      " Monto='" & _Monto & "'" & "," &
                      " Caja_Id=" & _Caja_Id & "," &
                      " Cierre_Id=" & _Cierre_Id & "," &
                      " Usuario_Id='" & _Usuario_Id & "'" & "," &
                      " CPU='" & _CPU & "'" & "," &
                      " HostName='" & _HostName & "'" & "," &
                      " IPAddress='" & _IPAddress & "'" & "," &
                      " Anulado=" & _Anulado & "," &
                      " AnuladoFecha='" & Format(_AnuladoFecha, "yyyyMMdd HH:mm:ss") & "'" &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Suc_Id=" & _Suc_Id.ToString() &
                      " And    Apartado_Id=" & _Apartado_Id.ToString() &
                      " And    Abono_Id=" & _Abono_Id.ToString()

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

            Query = "select * From ApartadoAbono" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    Apartado_Id=" & _Apartado_Id.ToString() &
           " And    Abono_Id=" & _Abono_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Apartado_Id = Tabla.Rows(0).Item("Apartado_Id")
                _Abono_Id = Tabla.Rows(0).Item("Abono_Id")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Monto = Tabla.Rows(0).Item("Monto")
                _Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                _Cierre_Id = Tabla.Rows(0).Item("Cierre_Id")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _CPU = Tabla.Rows(0).Item("CPU")
                _HostName = Tabla.Rows(0).Item("HostName")
                _IPAddress = Tabla.Rows(0).Item("IPAddress")
                _Anulado = Tabla.Rows(0).Item("Anulado")
                _AnuladoFecha = Tabla.Rows(0).Item("AnuladoFecha")
            End If

            With _Usuario
                .Usuario_Id = _Usuario_Id
                .ListKey()
            End With

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

            Query = "select * From ApartadoAbono"

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

            Query = "select ApartadoAbono_Id as Numero, Nombre From ApartadoAbono"

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

    Public Function ObtenerAbonosApartados() As List(Of TApartadoAbono)
        Dim Query As String
        Dim Tabla As DataTable
        Dim Abonos As New List(Of TApartadoAbono)()
        Try
            Cn.Open()

            Query = "SELECT * FROM ApartadoAbono" &
                    " WHERE Emp_Id = " & Emp_Id &
                    " AND Suc_Id= " & Suc_Id &
                    " AND Apartado_Id = " & Apartado_Id

            Tabla = Cn.Seleccionar(Query).Copy

            For Each row As DataRow In Tabla.Rows

                Dim Abono As New TApartadoAbono(EmpresaInfo.Emp_Id)

                With Abono
                    .Emp_Id = Emp_Id
                    .Suc_Id = Suc_Id
                    .Apartado_Id = Apartado_Id
                    .Abono_Id = row.Item("Abono_Id").ToString()
                    .Fecha = CDate(row.Item("Fecha").ToString())
                    .Monto = row.Item("Monto").ToString()
                    .Caja_Id = row.Item("Caja_Id").ToString()
                    .Cierre_Id = row.Item("Cierre_Id").ToString()
                    .Usuario_Id = row.Item("Usuario_Id").ToString()
                    .CPU = row.Item("CPU").ToString()
                    .HostName = row.Item("HostName").ToString()
                    .IPAddress = row.Item("IPAddress").ToString()
                    .Anulado = row.Item("Anulado").ToString()
                    .AnuladoFecha = row.Item("AnuladoFecha").ToString()
                End With

                Usuario.Usuario_Id = Abono.Usuario_Id

                Usuario.ListKey()

                Abono.Usuario = Usuario

                Abonos.Add(Abono)
            Next

            Return Abonos

        Catch ex As Exception
            Throw ex
        Finally
            Cn.Close()
        End Try
    End Function


    Public Sub NextOne()

        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select IsNull(MAX(Abono_Id),0) + 1 as Mov_Id From ApartadoAbono" &
                    " Where Emp_Id = " & _Emp_Id.ToString &
                    " And   Suc_Id = " & Suc_Id &
                    " And   Apartado_Id = " & Apartado_Id

            Tabla = Cn.Seleccionar(Query).Copy

            _Abono_Id = CInt(Tabla.Rows(0).Item(0).ToString())

        Catch ex As Exception
            Throw ex
        Finally
            Cn.Close()
        End Try

    End Sub

    Public Function CrearAbono(Pagos As List(Of TFacturaPago)) As String
        'Ingresar Abono 
        'Ingresar Metodo de pago
        'Actualizar Saldo apartado
        'Actualizar Estado del apartado
        Return ""
    End Function
#End Region
End Class
