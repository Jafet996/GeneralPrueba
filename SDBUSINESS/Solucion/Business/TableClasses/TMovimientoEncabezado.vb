Public Class TMovimientoEncabezado
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _TipoMov_Id As Integer
    Private _Mov_Id As Integer
    Private _Bod_Id As Integer
    Private _Fecha As Datetime
    Private _Comentario As String
    Private _Costo As Double
    Private _Aplicado As Integer
    Private _Usuario_Id As String
    Private _Suc_Id_Destino As Integer
    Private _Bod_Id_Destino As Integer
    Private _AplicaUsuario_Id As String
    Private _AplicaFecha As Datetime
    Private _UltimaModificacion As DateTime
    Private _ListaDetalles As New List(Of TMovimientoDetalle)
    Private _Lotes As New List(Of TArticuloLote)
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
    Public Property TipoMov_Id() As Integer
        Get
            Return _TipoMov_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoMov_Id = Value
        End Set
    End Property
    Public Property Mov_Id() As Integer
        Get
            Return _Mov_Id
        End Get
        Set(ByVal Value As Integer)
            _Mov_Id = Value
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
    Public Property Fecha() As Datetime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As Datetime)
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
    Public Property Suc_Id_Destino() As Integer
        Get
            Return _Suc_Id_Destino
        End Get
        Set(ByVal Value As Integer)
            _Suc_Id_Destino = Value
        End Set
    End Property
    Public Property Bod_Id_Destino() As Integer
        Get
            Return _Bod_Id_Destino
        End Get
        Set(ByVal Value As Integer)
            _Bod_Id_Destino = Value
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
    Public Property AplicaFecha() As Datetime
        Get
            Return _AplicaFecha
        End Get
        Set(ByVal Value As Datetime)
            _AplicaFecha = Value
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
    Public Property ListaDetalles As List(Of TMovimientoDetalle)
        Get
            Return _ListaDetalles
        End Get
        Set(value As List(Of TMovimientoDetalle))
            _ListaDetalles = value
        End Set
    End Property

    Public Property Lotes As List(Of TArticuloLote)
        Get
            Return _Lotes
        End Get
        Set(value As List(Of TArticuloLote))
            _Lotes = value
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
        _TipoMov_Id = 0
        _Mov_Id = 0
        _Bod_Id = 0
        _Fecha = CDate("1900/01/01")
        _Comentario = ""
        _Costo = 0.0
        _Aplicado = 0
        _Usuario_Id = ""
        _Suc_Id_Destino = 0
        _Bod_Id_Destino = 0
        _AplicaUsuario_Id = ""
        _AplicaFecha = CDate("1900/01/01")
        _UltimaModificacion = CDate("1900/01/01")
        _ListaDetalles.Clear()
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Function SiguienteConsecutivo() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try


            Query = "select isnull(max(Mov_Id), 0) + 1 as Siguiente From MovimientoEncabezado" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    Suc_Id=" & _Suc_Id.ToString() & _
           " And    TipoMov_Id=" & _TipoMov_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Mov_Id = Tabla.Rows(0).Item("Siguiente")
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

            Query = " Insert into MovimientoEncabezado( Emp_Id , Suc_Id" & _
                   " , TipoMov_Id , Mov_Id" & _
                   " , Bod_Id , Fecha" & _
                   " , Comentario , Costo" & _
                   " , Aplicado , Usuario_Id" & _
                   " , Suc_Id_Destino , Bod_Id_Destino" & _
                   " , AplicaUsuario_Id , AplicaFecha" & _
                   " , UltimaModificacion )" & _
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & _
                   "," & _TipoMov_Id.ToString() & "," & _Mov_Id.ToString() & _
                   "," & _Bod_Id.ToString() & ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & _
                   ",'" & _Comentario & "'" & "," & _Costo.ToString() & _
                   "," & _Aplicado.ToString() & ",'" & _Usuario_Id & "'" & _
                   "," & _Suc_Id_Destino.ToString() & "," & _Bod_Id_Destino.ToString() & _
                   ",'" & _AplicaUsuario_Id & "'" & ",'" & Format(_AplicaFecha, "yyyyMMdd HH:mm:ss") & "'" & _
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

            Query = "Delete MovimientoEncabezado" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And    Suc_Id=" & _Suc_Id.ToString() & _
               " And    TipoMov_Id=" & _TipoMov_Id.ToString() & _
               " And    Mov_Id=" & _Mov_Id.ToString()

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

            Query = " Update dbo.MovimientoEncabezado " & _
                      " SET    Bod_Id=" & _Bod_Id.ToString() & "," & _
                      " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                      " Comentario='" & _Comentario & "'" & "," & _
                      " Costo=" & _Costo & "," & _
                      " Aplicado=" & _Aplicado & "," & _
                      " Usuario_Id='" & _Usuario_Id & "'" & "," & _
                      " Suc_Id_Destino=" & _Suc_Id_Destino & "," & _
                      " Bod_Id_Destino=" & _Bod_Id_Destino & "," & _
                      " AplicaUsuario_Id='" & _AplicaUsuario_Id & "'" & "," & _
                      " AplicaFecha='" & Format(_AplicaFecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & _
                      " Where     Emp_Id=" & _Emp_Id.ToString() & _
                      " And    Suc_Id=" & _Suc_Id.ToString() & _
                      " And    TipoMov_Id=" & _TipoMov_Id.ToString() & _
                      " And    Mov_Id=" & _Mov_Id.ToString()

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

            Query = "select * From MovimientoEncabezado" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    Suc_Id=" & _Suc_Id.ToString() & _
           " And    TipoMov_Id=" & _TipoMov_Id.ToString() & _
           " And    Mov_Id=" & _Mov_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _TipoMov_Id = Tabla.Rows(0).Item("TipoMov_Id")
                _Mov_Id = Tabla.Rows(0).Item("Mov_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Comentario = Tabla.Rows(0).Item("Comentario")
                _Costo = Tabla.Rows(0).Item("Costo")
                _Aplicado = Tabla.Rows(0).Item("Aplicado")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _Suc_Id_Destino = IIf(IsDBNull(Tabla.Rows(0).Item("Suc_Id_Destino")), 0, Tabla.Rows(0).Item("Suc_Id_Destino"))
                _Bod_Id_Destino = IIf(IsDBNull(Tabla.Rows(0).Item("Bod_Id_Destino")), 0, Tabla.Rows(0).Item("Bod_Id_Destino"))
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

            Query = "select * From MovimientoEncabezado"

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

            Query = "select MovimientoEncabezado_Id as Numero, Nombre From MovimientoEncabezado"

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
        Dim Lote_Id As Integer = 0
        Try
            Cn.Open()

            Cn.BeginTransaction()

            If _Mov_Id = 0 Then
                VerificaMensaje(SiguienteConsecutivo())

                Query = " Insert into MovimientoEncabezado( Emp_Id , Suc_Id" &
                       " , TipoMov_Id , Mov_Id" &
                       " , Bod_Id , Fecha" &
                       " , Comentario , Costo" &
                       " , Aplicado , Usuario_Id" &
                       " , Suc_Id_Destino , Bod_Id_Destino" &
                       " , AplicaUsuario_Id , AplicaFecha" &
                       " , UltimaModificacion )" &
                       " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                       "," & _TipoMov_Id.ToString() & "," & _Mov_Id.ToString() &
                       "," & _Bod_Id.ToString() & ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" &
                       ",'" & _Comentario & "'" & "," & _Costo.ToString() &
                       ",0,'" & _Usuario_Id & "'" &
                       "," & IIf(_Suc_Id_Destino > 0, _Suc_Id_Destino.ToString(), "null") & "," & IIf(_Bod_Id_Destino > 0, _Bod_Id_Destino.ToString(), "null") &
                       ",null,'19000101',getdate())"

                Cn.Ejecutar(Query)
            Else

                Query = " Update dbo.MovimientoEncabezado " &
                      " set    Bod_Id=" & _Bod_Id.ToString() & "," &
                      " Comentario='" & _Comentario & "'" & "," &
                      " Costo=" & _Costo & "," &
                      " Suc_Id_Destino=" & IIf(_Suc_Id_Destino > 0, _Suc_Id_Destino.ToString(), "null") & "," &
                      " Bod_Id_Destino=" & IIf(_Bod_Id_Destino > 0, _Bod_Id_Destino.ToString(), "null") & "," &
                      " UltimaModificacion=getdate()" &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Suc_Id=" & _Suc_Id.ToString() &
                      " And    TipoMov_Id=" & _TipoMov_Id.ToString() &
                      " And    Mov_Id=" & _Mov_Id.ToString()

                Cn.Ejecutar(Query)

                'Elimina el detalle de lotes del movimiento antes de almacenarlo
                Query = " delete MovimientoDetalleLote" &
                    " where Emp_Id = " & _Emp_Id.ToString &
                    " and   Suc_Id = " & _Suc_Id.ToString &
                    " and   TipoMov_Id = " & _TipoMov_Id.ToString &
                    " and   Mov_Id = " & _Mov_Id.ToString

                Cn.Ejecutar(Query)

                'Elimina el detalle del movimiento antes de almacenarlo
                Query = "Delete MovimientoDetalle" &
                       " Where  Emp_Id=" & _Emp_Id.ToString() &
                       " And    Suc_Id=" & _Suc_Id.ToString() &
                       " And    TipoMov_Id=" & _TipoMov_Id.ToString() &
                       " And    Mov_Id=" & _Mov_Id.ToString()
                Cn.Ejecutar(Query)
            End If



            For Each Detalle As TMovimientoDetalle In _ListaDetalles
                With Detalle
                    Query = "GuardaMovimientoDetalle " & .Emp_Id.ToString & "," & .Suc_Id.ToString & "," & .TipoMov_Id.ToString & "," & _Mov_Id.ToString() & "," &
                        .Detalle_Id.ToString & ",'" & .Art_Id & "'," & .Cantidad.ToString & "," & .Costo.ToString & "," & .TotalLinea & "," & .Suelto & ",'" &
                        Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'," & .CantidadLote.ToString & "," & .Lote
                End With

                Cn.Ejecutar(Query)

                Lote_Id = 0
                For Each ArticuloLote As TArticuloLote In _Lotes
                    If ArticuloLote.Art_Id = Detalle.Art_Id Then
                        For Each Lote As TLote In ArticuloLote.Lotes
                            If Lote.Cantidad > 0 Then
                                Lote_Id += 1

                                Query = " insert into MovimientoDetalleLote (" &
                                        "  Emp_Id" &
                                        " ,Suc_Id" &
                                        " ,TipoMov_Id" &
                                        " ,Mov_Id" &
                                        " ,Detalle_Id" &
                                        " ,Lote_Id" &
                                        " ,Art_Id" &
                                        " ,Lote" &
                                        " ,Cantidad" &
                                        " ,Vencimiento" &
                                        " ,Bod_Id" &
                                        " ,Fecha )" &
                                        " values (" &
                                        _Emp_Id.ToString &
                                        "," & _Suc_Id.ToString &
                                        "," & _TipoMov_Id.ToString &
                                        "," & _Mov_Id.ToString &
                                        "," & Detalle.Detalle_Id.ToString &
                                        "," & Lote_Id.ToString &
                                        ",'" & ArticuloLote.Art_Id & "'" &
                                        ",'" & Lote.Lote & "'" &
                                        "," & Lote.Cantidad.ToString &
                                        ",'" & Lote.Vencimiento.ToString("yyyyMMdd") & "'" &
                                        "," & _Bod_Id.ToString &
                                        ",GETDATE())"

                                Cn.Ejecutar(Query)
                            End If
                        Next
                    End If
                Next

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

    Public Function AplicarDocumentoAjuste() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "exec AplicaMovimientoAjuste " & _Emp_Id.ToString() & "," & _Suc_Id.ToString & "," & _TipoMov_Id.ToString & "," & _Mov_Id.ToString & ",'" & _AplicaUsuario_Id & "'"
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


            'Elimina el detalle de lotes del movimiento antes de almacenarlo
            Query = " delete MovimientoDetalleLote" &
                    " where Emp_Id = " & _Emp_Id.ToString &
                    " and   Suc_Id = " & _Suc_Id.ToString &
                    " and   TipoMov_Id = " & _TipoMov_Id.ToString &
                    " and   Mov_Id = " & _Mov_Id.ToString
            Cn.Ejecutar(Query)

            'Elimina el detalle del movimiento antes de almacenarlo
            Query = "Delete MovimientoDetalle" & _
                   " Where  Emp_Id=" & _Emp_Id.ToString() & _
                   " And    Suc_Id=" & _Suc_Id.ToString() & _
                   " And    TipoMov_Id=" & _TipoMov_Id.ToString() & _
                   " And    Mov_Id=" & _Mov_Id.ToString()
            Cn.Ejecutar(Query)

            'Elimina el detalle del movimiento antes de almacenarlo
            Query = "Delete MovimientoEncabezado" & _
                   " Where  Emp_Id=" & _Emp_Id.ToString() & _
                   " And    Suc_Id=" & _Suc_Id.ToString() & _
                   " And    TipoMov_Id=" & _TipoMov_Id.ToString() & _
                   " And    Mov_Id=" & _Mov_Id.ToString()
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

    Public Function ListBusqueda(pTipoBusqueda As Integer, pCantidad As Integer, pFechaIni As Date, pFechaFin As Date, pComentario As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()


            Query = "select " & IIf((pTipoBusqueda = 1), "Top " & pCantidad.ToString, "") & " a.Mov_Id as Numero,  b.Nombre as TipoMovimiento, a.Fecha , case a.Aplicado when 1 then 'Aplicado' else 'Pendiente' end as Estado, a.comentario as Comentario " &
                " From MovimientoEncabezado a, TipoMovimiento b  where a.Emp_Id = b.Emp_Id and a.TipoMov_Id = b.TipoMov_Id" &
                " and a.Emp_Id = " & _Emp_Id.ToString & " and a.Suc_Id = " & _Suc_Id.ToString & " and a.TipoMov_Id = " & _TipoMov_Id.ToString

            If pTipoBusqueda = 2 Then
                Query = Query & " and a.Fecha>='" & Format(pFechaIni, "yyyyMMdd") & "' and a.Fecha<='" & Format(DateAdd(DateInterval.Day, 1, pFechaFin), "yyyyMMdd") & "'"
            End If
            If pTipoBusqueda = 3 Then
                Query = Query & " and a.comentario  LIKE '%" & pComentario & "%'"
            End If

            Query = Query & " Order by a.Mov_Id desc"

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
    Public Function RptAjusteInventario() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptAjusteInventario " & _Emp_Id.ToString & "," & _Suc_Id.ToString() & "," & _TipoMov_Id.ToString() & "," & _Mov_Id.ToString()

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
