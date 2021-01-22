Public Class TUsuarioCierre
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Usuario_Id As String
    Private _Cierre_Id As Integer
    Private _Fecha As DateTime
    Private _CantidadDocumentos As Integer
    Private _PromedioCompra As Double
    Private _Exento As Double
    Private _Gravado As Double
    Private _Subtotal As Double
    Private _Descuento As Double
    Private _IV As Double
    Private _Total As Double
    Private _Redondeo As Double
    Private _TotalCobrado As Double
    Private _Credito As Double
    Private _Tarjeta As Double
    Private _Efectivo As Double
    Private _Dolares As Double
    Private _Cheque As Double
    Private _Puntos As Double
    Private _Abonos As Double
    Private _TipoCambio As Double
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
    Public Property Usuario_Id() As String
        Get
            Return _Usuario_Id
        End Get
        Set(ByVal Value As String)
            _Usuario_Id = Value
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
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As DateTime)
            _Fecha = Value
        End Set
    End Property
    Public Property CantidadDocumentos() As Integer
        Get
            Return _CantidadDocumentos
        End Get
        Set(ByVal Value As Integer)
            _CantidadDocumentos = Value
        End Set
    End Property
    Public Property PromedioCompra() As Double
        Get
            Return _PromedioCompra
        End Get
        Set(ByVal Value As Double)
            _PromedioCompra = Value
        End Set
    End Property
    Public Property Exento() As Double
        Get
            Return _Exento
        End Get
        Set(ByVal Value As Double)
            _Exento = Value
        End Set
    End Property
    Public Property Gravado() As Double
        Get
            Return _Gravado
        End Get
        Set(ByVal Value As Double)
            _Gravado = Value
        End Set
    End Property
    Public Property Subtotal() As Double
        Get
            Return _Subtotal
        End Get
        Set(ByVal Value As Double)
            _Subtotal = Value
        End Set
    End Property
    Public Property Descuento() As Double
        Get
            Return _Descuento
        End Get
        Set(ByVal Value As Double)
            _Descuento = Value
        End Set
    End Property
    Public Property IV() As Double
        Get
            Return _IV
        End Get
        Set(ByVal Value As Double)
            _IV = Value
        End Set
    End Property
    Public Property Total() As Double
        Get
            Return _Total
        End Get
        Set(ByVal Value As Double)
            _Total = Value
        End Set
    End Property
    Public Property Redondeo() As Double
        Get
            Return _Redondeo
        End Get
        Set(ByVal Value As Double)
            _Redondeo = Value
        End Set
    End Property
    Public Property TotalCobrado() As Double
        Get
            Return _TotalCobrado
        End Get
        Set(ByVal Value As Double)
            _TotalCobrado = Value
        End Set
    End Property
    Public Property Credito() As Double
        Get
            Return _Credito
        End Get
        Set(ByVal Value As Double)
            _Credito = Value
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
    Public Property Efectivo() As Double
        Get
            Return _Efectivo
        End Get
        Set(ByVal Value As Double)
            _Efectivo = Value
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
    Public Property Cheque() As Double
        Get
            Return _Cheque
        End Get
        Set(ByVal Value As Double)
            _Cheque = Value
        End Set
    End Property
    Public Property Puntos() As Double
        Get
            Return _Puntos
        End Get
        Set(ByVal Value As Double)
            _Puntos = Value
        End Set
    End Property
    Public Property Abonos() As Double
        Get
            Return _Abonos
        End Get
        Set(ByVal Value As Double)
            _Abonos = Value
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
        _Usuario_Id = ""
        _Cierre_Id = 0
        _Fecha = CDate("1900/01/01")
        _CantidadDocumentos = 0
        _PromedioCompra = 0.00
        _Exento = 0.00
        _Gravado = 0.00
        _Subtotal = 0.00
        _Descuento = 0.00
        _IV = 0.00
        _Total = 0.00
        _Redondeo = 0.00
        _TotalCobrado = 0.00
        _Credito = 0.00
        _Tarjeta = 0.00
        _Efectivo = 0.00
        _Dolares = 0.00
        _Cheque = 0.00
        _Puntos = 0.00
        _Abonos = 0.00
        _TipoCambio = 0.00
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into UsuarioCierre( Emp_Id , Usuario_Id" &
                   " , Cierre_Id , Fecha" &
                   " , CantidadDocumentos , PromedioCompra" &
                   " , Exento , Gravado" &
                   " , Subtotal , Descuento" &
                   " , IV , Total" &
                   " , Redondeo , TotalCobrado" &
                   " , Credito , Tarjeta" &
                   " , Efectivo , Dolares" &
                   " , Cheque , Puntos" &
                   " , Abonos , TipoCambio" &
                   " )" &
                   " Values ( " & _Emp_Id.ToString() & ",'" & _Usuario_Id & "'" &
                   "," & _Cierre_Id.ToString() & ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" &
                   "," & _CantidadDocumentos.ToString() & "," & _PromedioCompra.ToString() &
                   "," & _Exento.ToString() & "," & _Gravado.ToString() &
                   "," & _Subtotal.ToString() & "," & _Descuento.ToString() &
                   "," & _IV.ToString() & "," & _Total.ToString() &
                   "," & _Redondeo.ToString() & "," & _TotalCobrado.ToString() &
                   "," & _Credito.ToString() & "," & _Tarjeta.ToString() &
                   "," & _Efectivo.ToString() & "," & _Dolares.ToString() &
                   "," & _Cheque.ToString() & "," & _Puntos.ToString() &
                   "," & _Abonos.ToString() & "," & _TipoCambio.ToString() & ")"

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

            Query = "Delete UsuarioCierre" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And     Usuario_Id='" & _Usuario_Id & "'" &
               " And    Cierre_Id=" & _Cierre_Id.ToString()

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

            Query = " Update dbo.UsuarioCierre " &
                      " SET    Fecha=" & _Fecha.ToString() & "," &
                      " CantidadDocumentos=" & _CantidadDocumentos & "," &
                      " PromedioCompra=" & _PromedioCompra & "," &
                      " Exento=" & _Exento & "," &
                      " Gravado=" & _Gravado & "," &
                      " Subtotal=" & _Subtotal & "," &
                      " Descuento=" & _Descuento & "," &
                      " IV=" & _IV & "," &
                      " Total=" & _Total & "," &
                      " Redondeo=" & _Redondeo & "," &
                      " TotalCobrado=" & _TotalCobrado & "," &
                      " Credito=" & _Credito & "," &
                      " Tarjeta=" & _Tarjeta & "," &
                      " Efectivo=" & _Efectivo & "," &
                      " Dolares=" & _Dolares & "," &
                      " Cheque=" & _Cheque & "," &
                      " Puntos=" & _Puntos & "," &
                      " Abonos=" & _Abonos & "," &
                      " TipoCambio=" & _TipoCambio &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And     Usuario_Id='" & _Usuario_Id & "'" &
                      " And    Cierre_Id=" & _Cierre_Id.ToString()

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

            Query = "select * From UsuarioCierre" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And     Usuario_Id='" & _Usuario_Id & "'" &
           " And    Cierre_Id=" & _Cierre_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _Cierre_Id = Tabla.Rows(0).Item("Cierre_Id")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _CantidadDocumentos = Tabla.Rows(0).Item("CantidadDocumentos")
                _PromedioCompra = Tabla.Rows(0).Item("PromedioCompra")
                _Exento = Tabla.Rows(0).Item("Exento")
                _Gravado = Tabla.Rows(0).Item("Gravado")
                _Subtotal = Tabla.Rows(0).Item("Subtotal")
                _Descuento = Tabla.Rows(0).Item("Descuento")
                _IV = Tabla.Rows(0).Item("IV")
                _Total = Tabla.Rows(0).Item("Total")
                _Redondeo = Tabla.Rows(0).Item("Redondeo")
                _TotalCobrado = Tabla.Rows(0).Item("TotalCobrado")
                _Credito = Tabla.Rows(0).Item("Credito")
                _Tarjeta = Tabla.Rows(0).Item("Tarjeta")
                _Efectivo = Tabla.Rows(0).Item("Efectivo")
                _Dolares = Tabla.Rows(0).Item("Dolares")
                _Cheque = Tabla.Rows(0).Item("Cheque")
                _Puntos = Tabla.Rows(0).Item("Puntos")
                _Abonos = Tabla.Rows(0).Item("Abonos")
                _TipoCambio = Tabla.Rows(0).Item("TipoCambio")
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

            Query = "select * From UsuarioCierre"

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

            Query = "select UsuarioCierre_Id as Numero, Nombre From UsuarioCierre"

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

    Public Function ListaCierresXUsuario(pDesde As Date, pHasta As Date) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select Cierre_Id, Fecha From UsuarioCierre Where Emp_Id = " & _Emp_Id &
                     " and Usuario_Id = '" & _Usuario_Id & "' and Fecha >='" & Format(pDesde, "yyyyMMdd") & "'" &
                     " and Fecha <'" & (Format(DateAdd(DateInterval.Day, 1, pHasta), "yyyyMMdd")) & "'"

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
    Public Function RptCierreCajaUsuario() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RtpCierreCajaUsuario " & _Emp_Id & ",'" & _Usuario_Id & "'," & _Cierre_Id

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

    Public Function CierreCajaUsuario() As String
        Dim Query As String = ""
        Try
            Cn.Open()


            Query = "exec CierreCajaUsuario " & _Emp_Id.ToString() & ",'" & _Usuario_Id & "'"

            Cn.Ejecutar(Query)


            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
#End Region
End Class

