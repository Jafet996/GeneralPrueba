Public Class TTrasladoEncabezado
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Traslado_Id As Integer
    Private _SucOrigen_Id As Integer
    Private _BodOrigen_Id As Integer
    Private _SucDestino_Id As Integer
    Private _BodDestino_Id As Integer
    Private _Fecha As Datetime
    Private _Comentario As String
    Private _Costo As Double
    Private _Aplicado As Integer
    Private _Usuario_Id As String
    Private _UsuarioAplica_Id As String
    Private _AplicaFecha As Datetime
    Private _UltimaModificacion As DateTime
    Private _ListaDetalles As New List(Of TTrasladoDetalle)
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
    Public Property Traslado_Id() As Integer
        Get
            Return _Traslado_Id
        End Get
        Set(ByVal Value As Integer)
            _Traslado_Id = Value
        End Set
    End Property
    Public Property SucOrigen_Id() As Integer
        Get
            Return _SucOrigen_Id
        End Get
        Set(ByVal Value As Integer)
            _SucOrigen_Id = Value
        End Set
    End Property
    Public Property BodOrigen_Id() As Integer
        Get
            Return _BodOrigen_Id
        End Get
        Set(ByVal Value As Integer)
            _BodOrigen_Id = Value
        End Set
    End Property
    Public Property SucDestino_Id() As Integer
        Get
            Return _SucDestino_Id
        End Get
        Set(ByVal Value As Integer)
            _SucDestino_Id = Value
        End Set
    End Property
    Public Property BodDestino_Id() As Integer
        Get
            Return _BodDestino_Id
        End Get
        Set(ByVal Value As Integer)
            _BodDestino_Id = Value
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
    Public Property UsuarioAplica_Id() As String
        Get
            Return _UsuarioAplica_Id
        End Get
        Set(ByVal Value As String)
            _UsuarioAplica_Id = Value
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
    Public Property ListaDetalles As List(Of TTrasladoDetalle)
        Get
            Return _ListaDetalles
        End Get
        Set(value As List(Of TTrasladoDetalle))
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
        _Traslado_Id = 0
        _SucOrigen_Id = 0
        _BodOrigen_Id = 0
        _SucDestino_Id = 0
        _BodDestino_Id = 0
        _Fecha = CDate("1900/01/01")
        _Comentario = ""
        _Costo = 0.0
        _Aplicado = 0
        _Usuario_Id = ""
        _UsuarioAplica_Id = ""
        _AplicaFecha = CDate("1900/01/01")
        _UltimaModificacion = CDate("1900/01/01")
        _ListaDetalles.Clear()
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into TrasladoEncabezado( Emp_Id , Traslado_Id" & _
                   " , SucOrigen_Id , BodOrigen_Id" & _
                   " , SucDestino_Id , BodDestino_Id" & _
                   " , Fecha , Comentario" & _
                   " , Costo , Aplicado" & _
                   " , Usuario_Id , UsuarioAplica_Id" & _
                   " , AplicaFecha , UltimaModificacion" & _
                   " )" & _
                   " Values ( " & _Emp_Id.ToString() & "," & _Traslado_Id.ToString() & _
                   "," & _SucOrigen_Id.ToString() & "," & _BodOrigen_Id.ToString() & _
                   "," & _SucDestino_Id.ToString() & "," & _BodDestino_Id.ToString() & _
                   ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & ",'" & _Comentario & "'" & _
                   "," & _Costo.ToString() & "," & _Aplicado.ToString() & _
                   ",'" & _Usuario_Id & "'" & ",'" & _UsuarioAplica_Id & "'" & _
                   ",'" & Format(_AplicaFecha, "yyyyMMdd HH:mm:ss") & "'" & ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "')"

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

            query = "Delete TrasladoEncabezado" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And    Traslado_Id=" & _Traslado_Id.ToString()

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

            query = " Update dbo.TrasladoEncabezado " & _
                      " SET    SucOrigen_Id=" & _SucOrigen_Id.ToString() & "," & _
                      " BodOrigen_Id=" & _BodOrigen_Id & "," & _
                      " SucDestino_Id=" & _SucDestino_Id & "," & _
                      " BodDestino_Id=" & _BodDestino_Id & "," & _
                      " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                      " Comentario='" & _Comentario & "'" & "," & _
                      " Costo=" & _Costo & "," & _
                      " Aplicado=" & _Aplicado & "," & _
                      " Usuario_Id='" & _Usuario_Id & "'" & "," & _
                      " UsuarioAplica_Id='" & _UsuarioAplica_Id & "'" & "," & _
                      " AplicaFecha='" & Format(_AplicaFecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & _
                      " Where     Emp_Id=" & _Emp_Id.ToString() & _
                      " And    Traslado_Id=" & _Traslado_Id.ToString()

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

            Query = "select * From TrasladoEncabezado" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    Traslado_Id=" & _Traslado_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Traslado_Id = Tabla.Rows(0).Item("Traslado_Id")
                _SucOrigen_Id = Tabla.Rows(0).Item("SucOrigen_Id")
                _BodOrigen_Id = Tabla.Rows(0).Item("BodOrigen_Id")
                _SucDestino_Id = Tabla.Rows(0).Item("SucDestino_Id")
                _BodDestino_Id = Tabla.Rows(0).Item("BodDestino_Id")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Comentario = Tabla.Rows(0).Item("Comentario")
                _Costo = Tabla.Rows(0).Item("Costo")
                _Aplicado = Tabla.Rows(0).Item("Aplicado")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _UsuarioAplica_Id = IIf(IsDBNull(Tabla.Rows(0).Item("UsuarioAplica_Id")), "", Tabla.Rows(0).Item("UsuarioAplica_Id"))
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

            Query = "select * From TrasladoEncabezado"

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

            Query = "select TrasladoEncabezado_Id as Numero, Nombre From TrasladoEncabezado"

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
    Public Function SiguienteConsecutivo() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try


            Query = "select isnull(max(Traslado_Id), 0) + 1 as Siguiente From TrasladoEncabezado" &
           " Where     Emp_Id=" & _Emp_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Traslado_Id = Tabla.Rows(0).Item("Siguiente")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
        End Try
    End Function


    Public Function GuardarDocumento() As String
        Dim Query As String = ""
        Dim TrasladoEncabezadoTmp As New TTrasladoEncabezado(_Emp_Id)
        Dim Lote_Id As Integer = 0
        Try
            Cn.Open()

            Cn.BeginTransaction()


            With TrasladoEncabezadoTmp
                .Traslado_Id = _Traslado_Id
            End With
            VerificaMensaje(TrasladoEncabezadoTmp.ListKey)

            If _UltimaModificacion <> TrasladoEncabezadoTmp.UltimaModificacion Then
                VerificaMensaje("El documento fue modificado por otro usuario, debe de volver a cargar el documento")
            End If


            If _Traslado_Id = 0 Then
                VerificaMensaje(SiguienteConsecutivo())

                Query = " Insert into TrasladoEncabezado( Emp_Id , Traslado_Id" &
               " , SucOrigen_Id , BodOrigen_Id" &
               " , SucDestino_Id , BodDestino_Id" &
               " , Fecha , Comentario" &
               " , Costo , Aplicado" &
               " , Usuario_Id , UsuarioAplica_Id" &
               " , AplicaFecha , UltimaModificacion)" &
               " Values ( " & _Emp_Id.ToString() & "," & _Traslado_Id.ToString() &
               "," & _SucOrigen_Id.ToString() & "," & _BodOrigen_Id.ToString() &
               "," & _SucDestino_Id.ToString() & "," & _BodDestino_Id.ToString() &
               ",getdate(),'" & _Comentario & "'" &
               "," & _Costo.ToString() & ",0,'" & _Usuario_Id & "'" & ",null" &
               ",'19000101'" & ",getdate())"

                Cn.Ejecutar(Query)
            Else

                Query = " Update dbo.TrasladoEncabezado " &
              " SET    SucOrigen_Id=" & _SucOrigen_Id.ToString() & "," &
              " BodOrigen_Id=" & _BodOrigen_Id & "," &
              " SucDestino_Id=" & _SucDestino_Id & "," &
              " BodDestino_Id=" & _BodDestino_Id & "," &
              " Comentario='" & _Comentario & "'" & "," &
              " Costo=" & _Costo & "," &
              " Aplicado=" & _Aplicado & "," &
              " Usuario_Id='" & _Usuario_Id & "'" & "," &
              " UltimaModificacion=getdate()" &
              " Where     Emp_Id=" & _Emp_Id.ToString() &
              " And    Traslado_Id=" & _Traslado_Id.ToString()

                Cn.Ejecutar(Query)

                'Elimina el detalle de los lotes del movimiento antes de almacenarlo
                Query = " delete TrasladoDetalleLote" &
                    " where Emp_Id = " & _Emp_Id.ToString &
                    " and   Traslado_Id = " & _Traslado_Id.ToString
                Cn.Ejecutar(Query)

                'Elimina el detalle del movimiento antes de almacenarlo
                Query = "Delete TrasladoDetalle" &
                       " Where  Emp_Id=" & _Emp_Id.ToString() &
                       " And    Traslado_Id=" & _Traslado_Id.ToString()
                Cn.Ejecutar(Query)
            End If

            For Each Detalle As TTrasladoDetalle In _ListaDetalles
                With Detalle
                    Query = "exec GuardaTrasladoDetalle " & .Emp_Id.ToString & "," & _Traslado_Id.ToString() & "," &
                        .Detalle_Id.ToString & ",'" & .Art_Id & "'," & .Cantidad.ToString & "," & .Costo.ToString & "," & .TotalLinea & "," & .Suelto & ",'" &
                        Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'," & .CantidadLote & "," & .Lote
                End With

                Cn.Ejecutar(Query)
                Lote_Id = 0

                For Each ArticuloLote As TArticuloLote In _Lotes
                    If ArticuloLote.Art_Id = Detalle.Art_Id Then
                        For Each Lote As TLote In ArticuloLote.Lotes
                            If Lote.Cantidad > 0 Then
                                Lote_Id += 1

                                Query = " insert into TrasladoDetalleLote (" &
                                        "  Emp_Id" &
                                        " ,Traslado_Id" &
                                        " ,Detalle_Id" &
                                        " ,Lote_Id" &
                                        " ,Art_Id" &
                                        " ,Lote" &
                                        " ,Cantidad" &
                                        " ,Vencimiento" &
                                        " ,Fecha )" &
                                        " values (" &
                                        _Emp_Id.ToString &
                                        "," & _Traslado_Id.ToString &
                                        "," & Detalle.Detalle_Id.ToString &
                                        "," & Lote_Id.ToString &
                                        ",'" & ArticuloLote.Art_Id & "'" &
                                        ",'" & Lote.Lote & "'" &
                                        "," & Lote.Cantidad.ToString &
                                        ",'" & Lote.Vencimiento.ToString("yyyyMMdd") & "'" &
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
            TrasladoEncabezadoTmp = Nothing
            Cn.Close()
        End Try
    End Function
    Public Function AplicarTrasladoAjuste() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "exec AplicaTrasladoInventario " & _Emp_Id.ToString() & "," & _Traslado_Id.ToString & ",'" & _UsuarioAplica_Id & "'"
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

            'Elimina el detalle de los lotes del movimiento antes de almacenarlo
            Query = " delete TrasladoDetalleLote" &
                    " where Emp_Id = " & _Emp_Id.ToString &
                    " and   Traslado_Id = " & _Traslado_Id.ToString
            Cn.Ejecutar(Query)

            'Elimina el detalle del movimiento antes de almacenarlo
            Query = "Delete TrasladoDetalle" & _
                   " Where  Emp_Id=" & _Emp_Id.ToString() & _
                   " And    Traslado_Id=" & _Traslado_Id.ToString()
            Cn.Ejecutar(Query)

            'Elimina el detalle del movimiento antes de almacenarlo
            Query = "Delete TrasladoEncabezado" & _
                   " Where  Emp_Id=" & _Emp_Id.ToString() & _
                   " And    Traslado_Id=" & _Traslado_Id.ToString()
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
    Public Function ListBusqueda(pTipoBusqueda As Integer, pCantidad As Integer, pFechaIni As Date, pFechaFin As Date, pSucOrigen As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()


            Query = "select " & IIf((pTipoBusqueda = 1), "Top " & pCantidad.ToString, "") & " a.Traslado_Id as Numero, a.Fecha , s.Nombre as Origen, d.Nombre as Destino, case a.Aplicado when 1 then 'Aplicado' else 'Pendiente' end as Estado" &
                " From TrasladoEncabezado a inner join Sucursal s on a.Emp_Id = s.Emp_Id and a.SucOrigen_Id = s.Suc_Id inner join Sucursal d on a.Emp_Id = d.Emp_Id and a.SucDestino_Id = d.Suc_Id  where a.Emp_Id = " & _Emp_Id.ToString

            If pTipoBusqueda = 2 Then
                Query = Query & " and a.Fecha>='" & Format(pFechaIni, "yyyyMMdd") & "' and a.Fecha<='" & Format(DateAdd(DateInterval.Day, 1, pFechaFin), "yyyyMMdd") & "'"
            End If

            If pTipoBusqueda = 3 Then
                Query = Query & " and a.SucOrigen_Id = " & pSucOrigen
            End If

            Query = Query & " Order by a.Traslado_Id desc"

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
    Public Function RptTrasladoInventario() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptTasladoInventario " & _Emp_Id.ToString & "," & _Traslado_Id.ToString()

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
    Public Function RptTrasladoxArticulo(pArt_id As String, pDesde As DateTime, pHasta As DateTime, pSucOrigen As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptTrasladoxArticulo " & _Emp_Id.ToString & ",'" & pArt_id & "','" & Format(pDesde, "yyyyMMdd") & "','" & Format(pHasta, "yyyyMMdd") & "'," & pSucOrigen

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
