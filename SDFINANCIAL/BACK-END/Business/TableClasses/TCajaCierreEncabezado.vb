Public Class TCajaCierreEncabezado
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _Usuario_Id As String
    Private _Cerrado As Integer
    Private _FechaCierre As Datetime
    Private _FechaApertura As Datetime
    Private _Efectivo As Double
    Private _Tarjeta As Double
    Private _Cheque As Double
    Private _Dolares As Double
    Private _Fondo As Double
    Private _Transferencia As Double
    Private _Deposito As Double
    Private _CajeroEfectivo As Double
    Private _CajeroTarjeta As Double
    Private _CajeroCheque As Double
    Private _CajeroDocumentos As Double
    Private _CajeroDolares As Double
    Private _TipoCambio As Double
    Private _UltimaModificacion As Datetime
    Private _Data As DataSet

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
    Public Property Cerrado() As Integer
        Get
            Return _Cerrado
        End Get
        Set(ByVal Value As Integer)
            _Cerrado = Value
        End Set
    End Property
    Public Property FechaCierre() As Datetime
        Get
            Return _FechaCierre
        End Get
        Set(ByVal Value As Datetime)
            _FechaCierre = Value
        End Set
    End Property
    Public Property FechaApertura() As Datetime
        Get
            Return _FechaApertura
        End Get
        Set(ByVal Value As Datetime)
            _FechaApertura = Value
        End Set
    End Property
    Public Property Efectivo() As Double
        Get
            Return _Efectivo
        End Get
        Set(ByVal Value As Double)
            _Efectivo = Value
        End Set
    End Property
    Public Property Tarjeta() As Double
        Get
            Return _Tarjeta
        End Get
        Set(ByVal Value As Double)
            _Tarjeta = Value
        End Set
    End Property
    Public Property Cheque() As Double
        Get
            Return _Cheque
        End Get
        Set(ByVal Value As Double)
            _Cheque = Value
        End Set
    End Property
    Public Property Dolares() As Double
        Get
            Return _Dolares
        End Get
        Set(ByVal Value As Double)
            _Dolares = Value
        End Set
    End Property
    Public Property Fondo() As Double
        Get
            Return _Fondo
        End Get
        Set(ByVal Value As Double)
            _Fondo = Value
        End Set
    End Property
    Public Property Transferencia() As Double
        Get
            Return _Transferencia
        End Get
        Set(ByVal Value As Double)
            _Transferencia = Value
        End Set
    End Property
    Public Property Deposito() As Double
        Get
            Return _Deposito
        End Get
        Set(ByVal Value As Double)
            _Deposito = Value
        End Set
    End Property
    Public Property CajeroEfectivo() As Double
        Get
            Return _CajeroEfectivo
        End Get
        Set(ByVal Value As Double)
            _CajeroEfectivo = Value
        End Set
    End Property
    Public Property CajeroTarjeta() As Double
        Get
            Return _CajeroTarjeta
        End Get
        Set(ByVal Value As Double)
            _CajeroTarjeta = Value
        End Set
    End Property
    Public Property CajeroCheque() As Double
        Get
            Return _CajeroCheque
        End Get
        Set(ByVal Value As Double)
            _CajeroCheque = Value
        End Set
    End Property
    Public Property CajeroDocumentos() As Double
        Get
            Return _CajeroDocumentos
        End Get
        Set(ByVal Value As Double)
            _CajeroDocumentos = Value
        End Set
    End Property
    Public Property CajeroDolares() As Double
        Get
            Return _CajeroDolares
        End Get
        Set(ByVal Value As Double)
            _CajeroDolares = Value
        End Set
    End Property
    Public Property TipoCambio() As Double
        Get
            Return _TipoCambio
        End Get
        Set(ByVal Value As Double)
            _TipoCambio = Value
        End Set
    End Property
    Public Property UltimaModificacion() As Datetime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As Datetime)
            _UltimaModificacion = Value
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
        _Emp_Id = 0
        _Caja_Id = 0
        _Cierre_Id = 0
        _Usuario_Id = ""
        _Cerrado = 0
        _FechaCierre = CDate("1900/01/01")
        _FechaApertura = CDate("1900/01/01")
        _Efectivo = 0.0
        _Tarjeta = 0.0
        _Cheque = 0.0
        _Dolares = 0.0
        _Fondo = 0.0
        _Transferencia = 0.0
        _Deposito = 0.0
        _CajeroEfectivo = 0.0
        _CajeroTarjeta = 0.0
        _CajeroCheque = 0.0
        _CajeroDocumentos = 0.0
        _CajeroDolares = 0.0
        _TipoCambio = 0.0
        _UltimaModificacion = CDate("1900/01/01")
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into CajaCierreEncabezado( Emp_Id , Caja_Id" & _
                    " , Cierre_Id , Usuario_Id" & _
                    " , Cerrado , FechaCierre" & _
                    " , FechaApertura , Efectivo" & _
                    " , Tarjeta , Cheque" & _
                    " , Dolares" & _
                    " , Fondo , Transferencia" & _
                    " , Deposito , CajeroEfectivo" & _
                    " , CajeroTarjeta , CajeroCheque" & _
                    " , CajeroDocumentos , CajeroDolares" & _
                    " , TipoCambio" & _
                    " , UltimaModificacion )" & _
                    " Values ( " & _Emp_Id.ToString & "," & _Caja_Id.ToString & _
                    "," & _Cierre_Id.ToString & ",'" & _Usuario_Id & "'" & _
                    "," & _Cerrado.ToString & ",'" & Format(_FechaCierre, "yyyyMMdd HH:mm:ss") & "'" & _
                    ",'" & Format(_FechaApertura, "yyyyMMdd HH:mm:ss") & "'" & "," & _Efectivo.ToString & _
                    "," & _Tarjeta.ToString & "," & _Cheque.ToString & _
                    "," & _Dolares.ToString & _
                    "," & _Fondo.ToString & "," & _Transferencia.ToString & _
                    "," & _Deposito.ToString & "," & _CajeroEfectivo.ToString & _
                    "," & _CajeroTarjeta.ToString & "," & _CajeroCheque.ToString & _
                    "," & _CajeroDocumentos.ToString & "," & _CajeroDolares.ToString & _
                    "," & _TipoCambio.ToString & _
                    ",GETDATE()" & ")"

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

            Query = "Delete CajaCierreEncabezado" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Caja_Id = " & _Caja_Id.ToString & _
                    " And   Cierre_Id = " & _Cierre_Id.ToString

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

            Query = " Update CajaCierreEncabezado " & _
                    " SET   Usuario_Id = '" & _Usuario_Id & "' " & "," & _
                    " Cerrado = " & _Cerrado & "," & _
                    " FechaCierre = '" & Format(_FechaCierre, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                    " FechaApertura = '" & Format(_FechaApertura, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                    " Efectivo = " & _Efectivo & "," & _
                    " Tarjeta = " & _Tarjeta & "," & _
                    " Cheque = " & _Cheque & "," & _
                    " Dolares = " & _Dolares & "," & _
                    " Fondo = " & _Fondo & "," & _
                    " Transferencia = " & _Transferencia & "," & _
                    " Deposito = " & _Deposito & "," & _
                    " CajeroEfectivo = " & _CajeroEfectivo & "," & _
                    " CajeroTarjeta = " & _CajeroTarjeta & "," & _
                    " CajeroCheque = " & _CajeroCheque & "," & _
                    " CajeroDocumentos = " & _CajeroDocumentos & "," & _
                    " CajeroDolares = " & _CajeroDolares & "," & _
                    " TipoCambio = " & _TipoCambio & "," & _
                    " UltimaModificacion = GETDATE()" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Caja_Id = " & _Caja_Id.ToString & _
                    " And   Cierre_Id = " & _Cierre_Id.ToString

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

            Query = "select a.*" & _
                    " ,b.Nombre as NombreUsuario" & _
                    " From CajaCierreEncabezado a" & _
                    " ,Usuario b" & _
                    " Where a.Emp_Id = b.Emp_Id" & _
                    " And   a.Usuario_Id = b.Usuario_Id" & _
                    " And   a.Emp_Id = " & _Emp_Id.ToString & _
                    " And   a.Caja_Id = " & _Caja_Id.ToString & _
                    " And   a.Cierre_Id = " & _Cierre_Id.ToString

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
    Public Overrides Function List() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select * From CajaCierreEncabezado"

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
    Public Overrides Function LoadComboBox() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select CajaCierreEncabezado_Id as Numero, Nombre From CajaCierreEncabezado"

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
    Public Overrides Function ListMant(pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select CajaCierreEncabezado_Id as Codigo, Nombre From CajaCierreEncabezado" & _
                    " where Emp_Id = " & _Emp_Id.ToString

            If pNombre.Trim <> "" Then
                Query += " and Nombre Like '%" & pNombre & "%'"
            End If

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
    Public Overrides Function NextOne() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select IsNull(MAX(CajaCierreEncabezado_Id),0) + 1 as CajaCierreEncabezado_Id From CajaCierreEncabezado" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Caja_Id = " & _Caja_Id.ToString

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
#End Region
End Class