Public Class TRecargaTelefonica
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Recarga_Id As Long
    Private _Suc_Id As Integer
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _Operacion As String
    Private _Cia As String
    Private _Telefono As String
    Private _Monto As Double
    Private _Detallista As String
    Private _Fecha As Datetime
    Private _Usuario_Id As String
    Private _Documento As Long
    Private _IdTrans As Long
    Private _Comision As Double
    Private _Correlativo As String
    Private _FechaRespuesta As Datetime
    Private _NumSerie As String
    Private _DiasExp As Integer
    Private _EstadoRecarga As String
    Private _DetalleRecarga As String
    Private _ErrorCode As String
    Private _ErrorDes As String
    Private _IceTransId As String
    Private _DistComision As Double
    Private _Saldo As Double
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
    Public Property Recarga_Id() As Long
        Get
            Return _Recarga_Id
        End Get
        Set(ByVal Value As Long)
            _Recarga_Id = Value
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
    Public Property Operacion() As String
        Get
            Return _Operacion
        End Get
        Set(ByVal Value As String)
            _Operacion = Value
        End Set
    End Property
    Public Property Cia() As String
        Get
            Return _Cia
        End Get
        Set(ByVal Value As String)
            _Cia = Value
        End Set
    End Property
    Public Property Telefono() As String
        Get
            Return _Telefono
        End Get
        Set(ByVal Value As String)
            _Telefono = Value
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
    Public Property Detallista() As String
        Get
            Return _Detallista
        End Get
        Set(ByVal Value As String)
            _Detallista = Value
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
    Public Property Usuario_Id() As String
        Get
            Return _Usuario_Id
        End Get
        Set(ByVal Value As String)
            _Usuario_Id = Value
        End Set
    End Property
    Public Property Documento() As Long
        Get
            Return _Documento
        End Get
        Set(ByVal Value As Long)
            _Documento = Value
        End Set
    End Property
    Public Property IdTrans() As Long
        Get
            Return _IdTrans
        End Get
        Set(ByVal Value As Long)
            _IdTrans = Value
        End Set
    End Property
    Public Property Comision() As Double
        Get
            Return _Comision
        End Get
        Set(ByVal Value As Double)
            _Comision = Value
        End Set
    End Property
    Public Property Correlativo() As String
        Get
            Return _Correlativo
        End Get
        Set(ByVal Value As String)
            _Correlativo = Value
        End Set
    End Property
    Public Property FechaRespuesta() As Datetime
        Get
            Return _FechaRespuesta
        End Get
        Set(ByVal Value As Datetime)
            _FechaRespuesta = Value
        End Set
    End Property
    Public Property NumSerie() As String
        Get
            Return _NumSerie
        End Get
        Set(ByVal Value As String)
            _NumSerie = Value
        End Set
    End Property
    Public Property DiasExp() As Integer
        Get
            Return _DiasExp
        End Get
        Set(ByVal Value As Integer)
            _DiasExp = Value
        End Set
    End Property
    Public Property EstadoRecarga() As String
        Get
            Return _EstadoRecarga
        End Get
        Set(ByVal Value As String)
            _EstadoRecarga = Value
        End Set
    End Property
    Public Property DetalleRecarga() As String
        Get
            Return _DetalleRecarga
        End Get
        Set(ByVal Value As String)
            _DetalleRecarga = Value
        End Set
    End Property
    Public Property ErrorCode() As String
        Get
            Return _ErrorCode
        End Get
        Set(ByVal Value As String)
            _ErrorCode = Value
        End Set
    End Property
    Public Property ErrorDes() As String
        Get
            Return _ErrorDes
        End Get
        Set(ByVal Value As String)
            _ErrorDes = Value
        End Set
    End Property
    Public Property IceTransId() As String
        Get
            Return _IceTransId
        End Get
        Set(ByVal Value As String)
            _IceTransId = Value
        End Set
    End Property
    Public Property DistComision() As Double
        Get
            Return _DistComision
        End Get
        Set(ByVal Value As Double)
            _DistComision = Value
        End Set
    End Property
    Public Property Saldo() As Double
        Get
            Return _Saldo
        End Get
        Set(ByVal Value As Double)
            _Saldo = Value
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
    Public Sub New(ByVal pEmp_Id As Integer)
        MyBase.New()
        Inicializa()
        _Emp_Id = pEmp_Id
    End Sub
    Public Sub New(ByVal pEmp_Id As Integer, ByVal pCnStr As String)
        MyBase.New(pCnStr)
        Inicializa()
        _Emp_Id = pEmp_Id
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _Emp_Id = 0
        _Recarga_Id = 0
        _Suc_Id = 0
        _Caja_Id = 0
        _Cierre_Id = 0
        _Operacion = ""
        _Cia = ""
        _Telefono = ""
        _Monto = 0.0
        _Detallista = ""
        _Fecha = CDate("1900/01/01")
        _Usuario_Id = ""
        _Documento = 0
        _IdTrans = 0
        _Comision = 0.0
        _Correlativo = ""
        _FechaRespuesta = CDate("1900/01/01")
        _NumSerie = ""
        _DiasExp = 0
        _EstadoRecarga = ""
        _DetalleRecarga = ""
        _ErrorCode = ""
        _ErrorDes = ""
        _IceTransId = ""
        _DistComision = 0.0
        _Saldo = 0.0
        _Data = New Dataset
    End Sub

    Private Function AcumulaRecargaCierre() As String
        Dim Query As String = ""
        Try

            Query = " Update CajaCierreEncabezado set RecargaTelefonica = RecargaTelefonica + " & _Monto.ToString & _
                      " Where Emp_Id  = " & _Emp_Id.ToString() & _
                      " And   Suc_Id  = " & _Suc_Id.ToString() & _
                      " And   Caja_Id = " & _Caja_Id.ToString() & _
                      " And   Cierre_Id = " & _Cierre_Id.ToString()


            Cn.Ejecutar(Query)


            If RowsAffected = 0 Then
                VerificaMensaje("No se encontró el numero de cierre")
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            query = " Insert into RecargaTelefonica( Emp_Id , Recarga_Id" & _
                   " , Suc_Id , Caja_Id" & _
                   " , Cierre_Id , Operacion" & _
                   " , Cia , Telefono" & _
                   " , Monto , Detallista" & _
                   " , Fecha , Usuario_Id" & _
                   " , Documento , IdTrans" & _
                   " , Comision , Correlativo" & _
                   " , FechaRespuesta , NumSerie" & _
                   " , DiasExp , EstadoRecarga" & _
                   " , DetalleRecarga , ErrorCode" & _
                   " , ErrorDes , IceTransId" & _
                   " , DistComision , Saldo" & _
                   " )" & _
                   " Values ( " & _Emp_Id.ToString() & "," & _Recarga_Id.ToString() & _
                   "," & _Suc_Id.ToString() & "," & _Caja_Id.ToString() & _
                   "," & _Cierre_Id.ToString() & ",'" & _Operacion & "'" & _
                   ",'" & _Cia & "'" & ",'" & _Telefono & "'" & _
                   "," & _Monto.ToString() & ",'" & _Detallista & "'" & _
                   ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & ",'" & _Usuario_Id & "'" & _
                   "," & _Documento.ToString() & "," & _IdTrans.ToString() & _
                   "," & _Comision.ToString() & ",'" & _Correlativo & "'" & _
                   ",'" & Format(_FechaRespuesta, "yyyyMMdd HH:mm:ss") & "'" & ",'" & _NumSerie & "'" & _
                   "," & _DiasExp.ToString() & ",'" & _EstadoRecarga & "'" & _
                   ",'" & _DetalleRecarga & "'" & ",'" & _ErrorCode & "'" & _
                   ",'" & _ErrorDes & "'" & ",'" & _IceTransId & "'" & _
                   "," & _DistComision.ToString() & "," & _Saldo.ToString() & ")"

            Cn.Ejecutar(Query)

            If _ErrorCode = "00" Then
                VerificaMensaje(AcumulaRecargaCierre())
            End If

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

            query = "Delete RecargaTelefonica" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And    Recarga_Id=" & _Recarga_Id.ToString()

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

            query = " Update dbo.RecargaTelefonica " & _
                      " SET    Suc_Id=" & _Suc_Id.ToString() & "," & _
                      " Caja_Id=" & _Caja_Id & "," & _
                      " Cierre_Id=" & _Cierre_Id & "," & _
                      " Operacion='" & _Operacion & "'" & "," & _
                      " Cia='" & _Cia & "'" & "," & _
                      " Telefono='" & _Telefono & "'" & "," & _
                      " Monto=" & _Monto & "," & _
                      " Detallista='" & _Detallista & "'" & "," & _
                      " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                      " Usuario_Id='" & _Usuario_Id & "'" & "," & _
                      " Documento=" & _Documento & "," & _
                      " IdTrans=" & _IdTrans & "," & _
                      " Comision=" & _Comision & "," & _
                      " Correlativo='" & _Correlativo & "'" & "," & _
                      " FechaRespuesta='" & Format(_FechaRespuesta, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                      " NumSerie='" & _NumSerie & "'" & "," & _
                      " DiasExp=" & _DiasExp & "," & _
                      " EstadoRecarga='" & _EstadoRecarga & "'" & "," & _
                      " DetalleRecarga='" & _DetalleRecarga & "'" & "," & _
                      " ErrorCode='" & _ErrorCode & "'" & "," & _
                      " ErrorDes='" & _ErrorDes & "'" & "," & _
                      " IceTransId='" & _IceTransId & "'" & "," & _
                      " DistComision=" & _DistComision & "," & _
                      " Saldo=" & _Saldo & _
                      " Where     Emp_Id=" & _Emp_Id.ToString() & _
                      " And    Recarga_Id=" & _Recarga_Id.ToString()

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

            Query = "select * From RecargaTelefonica" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    Recarga_Id=" & _Recarga_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Recarga_Id = Tabla.Rows(0).Item("Recarga_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                _Cierre_Id = Tabla.Rows(0).Item("Cierre_Id")
                _Operacion = Tabla.Rows(0).Item("Operacion")
                _Cia = Tabla.Rows(0).Item("Cia")
                _Telefono = Tabla.Rows(0).Item("Telefono")
                _Monto = Tabla.Rows(0).Item("Monto")
                _Detallista = Tabla.Rows(0).Item("Detallista")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _Documento = Tabla.Rows(0).Item("Documento")
                _IdTrans = Tabla.Rows(0).Item("IdTrans")
                _Comision = Tabla.Rows(0).Item("Comision")
                _Correlativo = Tabla.Rows(0).Item("Correlativo")
                _FechaRespuesta = Tabla.Rows(0).Item("FechaRespuesta")
                _NumSerie = Tabla.Rows(0).Item("NumSerie")
                _DiasExp = Tabla.Rows(0).Item("DiasExp")
                _EstadoRecarga = Tabla.Rows(0).Item("EstadoRecarga")
                _DetalleRecarga = Tabla.Rows(0).Item("DetalleRecarga")
                _ErrorCode = Tabla.Rows(0).Item("ErrorCode")
                _ErrorDes = Tabla.Rows(0).Item("ErrorDes")
                _IceTransId = Tabla.Rows(0).Item("IceTransId")
                _DistComision = Tabla.Rows(0).Item("DistComision")
                _Saldo = Tabla.Rows(0).Item("Saldo")
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

            Query = "select * From RecargaTelefonica"

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
    Public Overrides Function LoadComboBox(ByVal pCombo As System.Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select RecargaTelefonica_Id as Numero, Nombre From RecargaTelefonica"

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

    Public Function RptRecargasTelefonicasList(ByVal pFechaIni As Date, ByVal pFechaFin As Date, ByVal pTelefonoIni As String, ByVal pTelefonoFin As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()


            Query = "exec RptRecargasTelefonicas " & _Emp_Id.ToString & "," & _Suc_Id.ToString & ",'" & _
                Format(DateValue(pFechaIni), "yyyyMMdd") & "','" & Format(DateValue(pFechaFin), "yyyyMMdd") & "','" & _
                pTelefonoIni & "','" & pTelefonoFin & "'"

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
