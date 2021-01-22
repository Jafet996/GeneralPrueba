Public Class TCajaCambioDolar
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _Cambio_Id As Integer
    Private _Fecha As DateTime
    Private _Dolares As Double
    Private _TipoCambio As Double
    Private _Efectivo As Double
    Private _Usuario_Id As String
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
    Public Property Cambio_Id() As Integer
        Get
            Return _Cambio_Id
        End Get
        Set(ByVal Value As Integer)
            _Cambio_Id = Value
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
    Public Property Dolares() As Double
        Get
            Return _Dolares
        End Get
        Set(ByVal Value As Double)
            _Dolares = Value
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
    Public Property Efectivo() As Double
        Get
            Return _Efectivo
        End Get
        Set(ByVal Value As Double)
            _Efectivo = Value
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
        _Emp_Id = 0
        _Suc_Id = 0
        _Caja_Id = 0
        _Cierre_Id = 0
        _Cambio_Id = 0
        _Fecha = CDate("1900/01/01")
        _Dolares = 0.00
        _TipoCambio = 0.00
        _Efectivo = 0.00
        _Usuario_Id = ""
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Function Siguiente() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select isnull(max(Cambio_Id),0) + 1 from CajaCambioDolar" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And    Suc_Id=" & _Suc_Id.ToString() &
               " And    Caja_Id=" & _Caja_Id.ToString() &
               " And    Cierre_Id=" & _Cierre_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Cambio_Id = Tabla.Rows(0).Item(0)
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()



            Query = " Insert into CajaCambioDolar( Emp_Id , Suc_Id" &
                   " , Caja_Id , Cierre_Id" &
                   " , Cambio_Id , Fecha" &
                   " , Dolares , TipoCambio" &
                   " , Efectivo , Usuario_Id" &
                   " )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString() &
                   "," & _Cambio_Id.ToString() & ",getdate()" &
                   "," & _Dolares.ToString() & "," & _TipoCambio.ToString() &
                   "," & _Efectivo.ToString() & ",'" & _Usuario_Id & "'" & ")"

            Cn.Ejecutar(Query)


            Query = "update CajaCierreEncabezado set Dolares = Dolares + " & _Dolares & ",Efectivo = Efectivo - " & _Efectivo & ", Total = Total - " & _Efectivo & ",MontoResta = MontoResta + " & _Efectivo &
                " where Emp_Id = " & _Emp_Id.ToString() &
                " and Suc_Id = " & _Suc_Id.ToString() &
                " and Caja_Id = " & _Caja_Id.ToString() &
                " and Cierre_Id = " & _Cierre_Id.ToString()

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

            Query = "Delete CajaCambioDolar" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And    Suc_Id=" & _Suc_Id.ToString() &
               " And    Caja_Id=" & _Caja_Id.ToString() &
               " And    Cierre_Id=" & _Cierre_Id.ToString() &
               " And    Cambio_Id=" & _Cambio_Id.ToString()

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

            Query = " Update dbo.CajaCambioDolar " &
                      " SET    Fecha=" & _Fecha.ToString() & "," &
                      " Dolares=" & _Dolares & "," &
                      " TipoCambio=" & _TipoCambio & "," &
                      " Efectivo=" & _Efectivo & "," &
                      " Usuario_Id='" & _Usuario_Id & "'" &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Suc_Id=" & _Suc_Id.ToString() &
                      " And    Caja_Id=" & _Caja_Id.ToString() &
                      " And    Cierre_Id=" & _Cierre_Id.ToString() &
                      " And    Cambio_Id=" & _Cambio_Id.ToString()

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

            Query = "select * From CajaCambioDolar" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    Caja_Id=" & _Caja_Id.ToString() &
           " And    Cierre_Id=" & _Cierre_Id.ToString() &
           " And    Cambio_Id=" & _Cambio_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                _Cierre_Id = Tabla.Rows(0).Item("Cierre_Id")
                _Cambio_Id = Tabla.Rows(0).Item("Cambio_Id")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Dolares = Tabla.Rows(0).Item("Dolares")
                _TipoCambio = Tabla.Rows(0).Item("TipoCambio")
                _Efectivo = Tabla.Rows(0).Item("Efectivo")
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

            Query = "select * From CajaCambioDolar"

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

            Query = "select CajaCambioDolar_Id as Numero, Nombre From CajaCambioDolar"

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
#End Region
End Class
