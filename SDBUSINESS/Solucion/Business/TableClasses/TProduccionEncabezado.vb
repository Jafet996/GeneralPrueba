Public Class TProduccionEncabezado
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _TipoProd_Id As Integer
    Private _Prod_Id As Integer
    Private _Bod_Id As Integer
    Private _Fecha As DateTime
    Private _Comentario As String
    Private _Costo As Double
    Private _Aplicado As Integer
    Private _Usuario_Id As String
    Private _AplicaUsuario_Id As String
    Private _AplicaFecha As DateTime
    Private _UltimaModificacion As DateTime
    Private _ListaDetalles As New List(Of TProduccionDetalle)
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
    Public Property TipoProd_Id() As Integer
        Get
            Return _TipoProd_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoProd_Id = Value
        End Set
    End Property
    Public Property Prod_Id() As Integer
        Get
            Return _Prod_Id
        End Get
        Set(ByVal Value As Integer)
            _Prod_Id = Value
        End Set
    End Property
    Public Property Bod_Id() As Integer
        Get
            Return _Bod_Id
        End Get
        Set(ByVal Value As Integer)
            _Bod_Id = Value
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
    Public Property Comentario() As String
        Get
            Return _Comentario
        End Get
        Set(ByVal Value As String)
            _Comentario = Value
        End Set
    End Property
    Public Property Costo() As Double
        Get
            Return _Costo
        End Get
        Set(ByVal Value As Double)
            _Costo = Value
        End Set
    End Property
    Public Property Aplicado() As Integer
        Get
            Return _Aplicado
        End Get
        Set(ByVal Value As Integer)
            _Aplicado = Value
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
    Public Property AplicaUsuario_Id() As String
        Get
            Return _AplicaUsuario_Id
        End Get
        Set(ByVal Value As String)
            _AplicaUsuario_Id = Value
        End Set
    End Property
    Public Property AplicaFecha() As DateTime
        Get
            Return _AplicaFecha
        End Get
        Set(ByVal Value As DateTime)
            _AplicaFecha = Value
        End Set
    End Property
    Public Property UltimaModificacion() As DateTime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As DateTime)
            _UltimaModificacion = Value
        End Set
    End Property
    Public Property ListaDetalles As List(Of TProduccionDetalle)
        Get
            Return _ListaDetalles
        End Get
        Set(value As List(Of TProduccionDetalle))
            _ListaDetalles = value
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
        _TipoProd_Id = 0
        _Prod_Id = 0
        _Bod_Id = 0
        _Fecha = CDate("1900/01/01")
        _Comentario = ""
        _Costo = 0.0
        _Aplicado = 0
        _Usuario_Id = ""
        _AplicaUsuario_Id = ""
        _AplicaFecha = CDate("1900/01/01")
        _UltimaModificacion = CDate("1900/01/01")
        _ListaDetalles.Clear()
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Function SiguienteConsecutivo() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try


            Query = "select isnull(max(Prod_Id), 0) + 1 as Siguiente From ProduccionEncabezado" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    TipoProd_Id=" & _TipoProd_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Prod_Id = Tabla.Rows(0).Item("Siguiente")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
        End Try
    End Function
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into ProduccionEncabezado( Emp_Id , Suc_Id" &
                   " , TipoProd_Id , Prod_Id" &
                   " , Bod_Id , Fecha" &
                   " , Comentario , Costo" &
                   " , Aplicado , Usuario_Id" &
                   " , AplicaUsuario_Id , AplicaFecha" &
                   " , UltimaModificacion )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _TipoProd_Id.ToString() & "," & _Prod_Id.ToString() &
                   "," & _Bod_Id.ToString() & ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" &
                   ",'" & _Comentario & "'" & "," & _Costo.ToString() &
                   "," & _Aplicado.ToString() & ",'" & _Usuario_Id & "'" &
                   ",'" & _AplicaUsuario_Id & "'" & ",'" & Format(_AplicaFecha, "yyyyMMdd HH:mm:ss") & "'" &
                   ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & ")"

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

            Query = "Delete ProduccionEncabezado" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And    Suc_Id=" & _Suc_Id.ToString() &
               " And    TipoProd_Id=" & _TipoProd_Id.ToString() &
               " And    Prod_Id=" & _Prod_Id.ToString()

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

            Query = " Update dbo.ProduccionEncabezado " &
                      " SET    Bod_Id=" & _Bod_Id.ToString() & "," &
                      " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," &
                      " Comentario='" & _Comentario & "'" & "," &
                      " Costo=" & _Costo & "," &
                      " Aplicado=" & _Aplicado & "," &
                      " Usuario_Id='" & _Usuario_Id & "'" & "," &
                      " AplicaUsuario_Id='" & _AplicaUsuario_Id & "'" & "," &
                      " AplicaFecha='" & Format(_AplicaFecha, "yyyyMMdd HH:mm:ss") & "'" & "," &
                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Suc_Id=" & _Suc_Id.ToString() &
                      " And    TipoProd_Id=" & _TipoProd_Id.ToString() &
                      " And    Prod_Id=" & _Prod_Id.ToString()

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

            Query = "select * From ProduccionEncabezado" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    TipoProd_Id=" & _TipoProd_Id.ToString() &
           " And    Prod_Id=" & _Prod_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _TipoProd_Id = Tabla.Rows(0).Item("TipoProd_Id")
                _Prod_Id = Tabla.Rows(0).Item("Prod_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Comentario = Tabla.Rows(0).Item("Comentario")
                _Costo = Tabla.Rows(0).Item("Costo")
                _Aplicado = Tabla.Rows(0).Item("Aplicado")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _AplicaUsuario_Id = IIf(IsDBNull(Tabla.Rows(0).Item("AplicaUsuario_Id")), "", Tabla.Rows(0).Item("AplicaUsuario_Id"))
                _AplicaFecha = Tabla.Rows(0).Item("AplicaFecha")
                _UltimaModificacion = Tabla.Rows(0).Item("UltimaModificacion")
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

            Query = "select * From ProduccionEncabezado"

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

            Query = "select ProduccionEncabezado_Id as Numero, Nombre From ProduccionEncabezado"

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
    Public Function GuardarDocumento() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            If _Prod_Id = 0 Then
                VerificaMensaje(SiguienteConsecutivo())

                Query = " Insert into ProduccionEncabezado( Emp_Id , Suc_Id" &
                       " , TipoProd_Id , Prod_Id" &
                       " , Bod_Id , Fecha" &
                       " , Comentario , Costo" &
                       " , Aplicado , Usuario_Id" &
                       " , AplicaUsuario_Id , AplicaFecha" &
                       " , UltimaModificacion )" &
                       " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id &
                       "," & _TipoProd_Id.ToString()  & "," & _Prod_Id &
                       "," & _Bod_Id.ToString() & ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" &
                       ",'" & _Comentario & "'" & "," & _Costo.ToString() &
                       ",0,'" & _Usuario_Id & "'" &
                       ",null,'19000101',getdate())"

                Cn.Ejecutar(Query)
            Else

                Query = " Update dbo.ProduccionEncabezado " &
                      " set    Bod_Id=" & _Bod_Id.ToString() & "," &
                      " Comentario='" & _Comentario & "'" & "," &
                      " Costo=" & _Costo & "," &
                      " UltimaModificacion=getdate()" &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Suc_Id=" & _Suc_Id.ToString() &
                      " And    TipoProd_Id=" & _TipoProd_Id.ToString() &
                      " And    Prod_Id=" & _Prod_Id.ToString()

                Cn.Ejecutar(Query)

                'Elimina el detalle del movimiento antes de almacenarlo
                Query = "Delete ProduccionDetalle" &
                       " Where  Emp_Id=" & _Emp_Id.ToString() &
                       " And    Suc_Id=" & _Suc_Id.ToString() &
                       " And    TipoProd_Id=" & _TipoProd_Id.ToString() &
                       " And    Prod_Id=" & _Prod_Id.ToString()
                Cn.Ejecutar(Query)
            End If

            For Each Detalle As TProduccionDetalle In _ListaDetalles
                With Detalle
                    Query = "exec GuardaProduccionDetalle " & .Emp_Id.ToString & "," & .Suc_Id.ToString & "," & .TipoProd_Id.ToString & "," & _Prod_Id.ToString() & "," &
                        .Detalle_Id.ToString & ",'" & .Art_Id & "'," & .Cantidad.ToString & "," & .Costo.ToString & "," & .TotalLinea & "," & .Suelto & ",'" &
                        Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'"
                End With

                Cn.Ejecutar(Query)
            Next

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function AplicaProduccionAjuste() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "exec AplicaProduccionAjuste " & _Emp_Id.ToString() & "," & _Suc_Id.ToString & "," & _TipoProd_Id.ToString & "," & _Prod_Id.ToString & ",'" & _AplicaUsuario_Id & "'"
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

    Public Function EliminarDocumento() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            'Elimina el detalle del movimiento antes de almacenarlo
            Query = "Delete ProduccionDetalle" &
                   " Where  Emp_Id=" & _Emp_Id.ToString() &
                   " And    Suc_Id=" & _Suc_Id.ToString() &
                   " And    TipoProd_Id=" & _TipoProd_Id.ToString() &
                   " And    Prod_Id=" & _Prod_Id.ToString()
            Cn.Ejecutar(Query)

            'Elimina el detalle del movimiento antes de almacenarlo
            Query = "Delete ProduccionEncabezado" &
                   " Where  Emp_Id=" & _Emp_Id.ToString() &
                   " And    Suc_Id=" & _Suc_Id.ToString() &
                   " And    TipoProd_Id=" & _TipoProd_Id.ToString() &
                   " And    Prod_Id=" & _Prod_Id.ToString()
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

    Public Function ListBusqueda(pTipoBusqueda As Integer, pCantidad As Integer, pFechaIni As Date, pFechaFin As Date) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()


            Query = "select " & IIf((pTipoBusqueda = 1), "Top " & pCantidad.ToString, "") & " a.Prod_Id as Numero,  b.Nombre as TipoProduccion, a.Fecha , case a.Aplicado when 1 then 'Aplicado' else 'Pendiente' end as Estado" &
                " From ProduccionEncabezado a, TipoProduccion b  where a.Emp_Id = b.Emp_Id and a.TipoProd_Id = b.TipoProd_Id" &
                " and a.Emp_Id = " & _Emp_Id.ToString & " and a.Suc_Id = " & _Suc_Id.ToString & " and a.TipoProd_Id = " & _TipoProd_Id.ToString

            If pTipoBusqueda = 2 Then
                Query = Query & " and a.Fecha>='" & Format(pFechaIni, "yyyyMMdd") & "' and a.Fecha<='" & Format(DateAdd(DateInterval.Day, 1, pFechaFin), "yyyyMMdd") & "'"
            End If

            Query = Query & " Order by a.Prod_Id desc"

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
    Public Function RptAjusteProduccion() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptAjusteProduccion " & _Emp_Id.ToString & "," & _Suc_Id.ToString() & "," & _TipoProd_Id.ToString() & "," & _Prod_Id.ToString()

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
