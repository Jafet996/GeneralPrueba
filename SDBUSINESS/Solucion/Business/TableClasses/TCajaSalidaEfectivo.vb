Public Class TCajaSalidaEfectivo
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _Salida_Id As Integer
    Private _Fecha As DateTime
    Private _Motivo As String
    Private _Monto As Double
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
    Public Property Salida_Id() As Integer
        Get
            Return _Salida_Id
        End Get
        Set(ByVal Value As Integer)
            _Salida_Id = Value
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
    Public Property Motivo() As String
        Get
            Return _Motivo
        End Get
        Set(ByVal Value As String)
            _Motivo = Value
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
        _Salida_Id = 0
        _Fecha = CDate("1900/01/01")
        _Motivo = ""
        _Monto = 0.00
        _Usuario_Id = ""
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into CajaSalidaEfectivo( Emp_Id , Suc_Id" &
                   " , Caja_Id , Cierre_Id" &
                   " , Salida_Id , Fecha" &
                   " , Motivo , Monto" &
                   " , Usuario_Id )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString() &
                   "," & _Salida_Id.ToString() & ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" &
                   ",'" & _Motivo & "'" & "," & _Monto.ToString() &
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

            Query = "Delete CajaSalidaEfectivo" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And    Suc_Id=" & _Suc_Id.ToString() &
               " And    Caja_Id=" & _Caja_Id.ToString() &
               " And    Cierre_Id=" & _Cierre_Id.ToString() &
               " And    Salida_Id=" & _Salida_Id.ToString()

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

            Query = " Update dbo.CajaSalidaEfectivo " &
                      " SET    Fecha=" & _Fecha.ToString() & "," &
                      " Motivo='" & _Motivo & "'" & "," &
                      " Monto=" & _Monto & "," &
                      " Usuario_Id='" & _Usuario_Id & "'" &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Suc_Id=" & _Suc_Id.ToString() &
                      " And    Caja_Id=" & _Caja_Id.ToString() &
                      " And    Cierre_Id=" & _Cierre_Id.ToString() &
                      " And    Salida_Id=" & _Salida_Id.ToString()

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

            Query = "select * From CajaSalidaEfectivo" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    Caja_Id=" & _Caja_Id.ToString() &
           " And    Cierre_Id=" & _Cierre_Id.ToString() &
           " And    Salida_Id=" & _Salida_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                _Cierre_Id = Tabla.Rows(0).Item("Cierre_Id")
                _Salida_Id = Tabla.Rows(0).Item("Salida_Id")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Motivo = Tabla.Rows(0).Item("Motivo")
                _Monto = Tabla.Rows(0).Item("Monto")
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

            Query = "select * From CajaSalidaEfectivo"

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

            Query = "select Salida_Id as Numero, (Cast(Salida_Id as varchar) + '_'+Cast(Format(Fecha,'dd-MM-yyyy') as varchar)) as Nombre  From CajaSalidaEfectivo Where   Emp_Id =" & _Emp_Id.ToString() &
           " And    Suc_Id =" & _Suc_Id.ToString() & " And    Caja_Id =" & _Caja_Id.ToString() & " And    Cierre_Id =" & Cierre_Id.ToString() & " order by Salida_Id desc"
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
    Public Function InsertaSalidaEfectivo() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "exec CreaSalidaEfectivo " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString() & "," &
                     (-1 * _Monto).ToString() & ",'" & _Motivo.ToString() & "','" & _Usuario_Id.ToString() & "'"

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
    Public Function ultimaSalida()
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "SELECT TOP 1 Salida_id From CajaSalidaEfectivo Where Emp_Id =" & _Emp_Id &
            "And Suc_Id = " & _Suc_Id & "And Caja_Id =" & _Caja_Id & "And Cierre_Id =" & Cierre_Id &
            "order by salida_id desc"
            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Salida_Id = Tabla.Rows(0).Item("Salida_Id")
                Return _Salida_Id
            End If

            Return Tabla

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

#End Region
End Class
