Public Class TCxCMovimiento
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Tipo_Id As Integer
    Private _Mov_Id As Long
    Private _Cliente_Id As Integer
    Private _Referencia As String
    Private _Fecha As DateTime
    Private _FechaRecibido As DateTime
    Private _FechaDocumento As Datetime
    Private _FechaVencimiento As Datetime
    Private _Moneda As Char
    Private _Monto As Double
    Private _Saldo As Double
    Private _TipoCambio As Double
    Private _Dolares As Double
    Private _Usuario_Id As String
    Private _AplicaMora As Integer
    Private _FechaCalculoMora As DateTime
    Private _Batch_Id As Long
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _UltimaModificacion As DateTime
    Private _Suc_Id As Integer
    Private _ListaPagos As New List(Of TCxCMovimientoPago)
    Private _ListaMovimientos As New List(Of TCxCMovimientoLinea)
    Private _GeneraNotaCredito As Boolean
    Private _MontoNotaCredito As Double
    Private _MAC_Address As String
    Private _GeneraAsiento As Boolean
    Private _AsientoEncabezado As TAuxAsientoEncabezado
    Private _Consecutivos As DataTable
    Private _FacturaEncabezado As New TFacturaEncabezado()
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
    Public Property Tipo_Id() As Integer
        Get
            Return _Tipo_Id
        End Get
        Set(ByVal Value As Integer)
            _Tipo_Id = Value
        End Set
    End Property
    Public Property Mov_Id() As Long
        Get
            Return _Mov_Id
        End Get
        Set(ByVal Value As Long)
            _Mov_Id = Value
        End Set
    End Property
    Public Property Cliente_Id() As Integer
        Get
            Return _Cliente_Id
        End Get
        Set(ByVal Value As Integer)
            _Cliente_Id = Value
        End Set
    End Property
    Public Property Referencia() As String
        Get
            Return _Referencia
        End Get
        Set(ByVal Value As String)
            _Referencia = Value
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
    Public Property FechaRecibido() As DateTime
        Get
            Return _FechaRecibido
        End Get
        Set(ByVal Value As DateTime)
            _FechaRecibido = Value
        End Set
    End Property
    Public Property FechaDocumento() As DateTime
        Get
            Return _FechaDocumento
        End Get
        Set(ByVal Value As DateTime)
            _FechaDocumento = Value
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
    Public Property Moneda() As Char
        Get
            Return _Moneda
        End Get
        Set(ByVal Value As Char)
            _Moneda = Value
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
    Public Property Saldo() As Double
        Get
            Return _Saldo
        End Get
        Set(ByVal Value As Double)
            _Saldo = Value
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
    Public Property Dolares() As Double
        Get
            Return _Dolares
        End Get
        Set(ByVal Value As Double)
            _Dolares = Value
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
    Public Property AplicaMora() As Integer
        Get
            Return _AplicaMora
        End Get
        Set(ByVal Value As Integer)
            _AplicaMora = Value
        End Set
    End Property
    Public Property FechaCalculoMora() As DateTime
        Get
            Return _FechaCalculoMora
        End Get
        Set(ByVal Value As DateTime)
            _FechaCalculoMora = Value
        End Set
    End Property
    Public Property Batch_Id() As Long
        Get
            Return _Batch_Id
        End Get
        Set(ByVal Value As Long)
            _Batch_Id = Value
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
    Public Property UltimaModificacion() As DateTime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As DateTime)
            _UltimaModificacion = Value
        End Set
    End Property

    Public Property Suc_Id() As Integer
        Get
            Return _Suc_Id
        End Get
        Set(ByVal value As Integer)
            _Suc_Id = value
        End Set
    End Property

    Public Property ListaPagos As List(Of TCxCMovimientoPago)
        Get
            Return _ListaPagos
        End Get
        Set(value As List(Of TCxCMovimientoPago))
            _ListaPagos = value
        End Set
    End Property
    Public Property ListaMovimientos As List(Of TCxCMovimientoLinea)
        Get
            Return _ListaMovimientos
        End Get
        Set(value As List(Of TCxCMovimientoLinea))
            _ListaMovimientos = value
        End Set
    End Property
    Public Property GeneraNotaCredito As Boolean
        Get
            Return _GeneraNotaCredito
        End Get
        Set(value As Boolean)
            _GeneraNotaCredito = value
        End Set
    End Property
    Public Property MontoNotaCredito As Double
        Get
            Return _MontoNotaCredito
        End Get
        Set(value As Double)
            _MontoNotaCredito = value
        End Set
    End Property
    Public Property MAC_Address As String
        Get
            Return _MAC_Address
        End Get
        Set(value As String)
            _MAC_Address = value
        End Set
    End Property
    Public Property GeneraAsiento As Boolean
        Get
            Return _GeneraAsiento
        End Get
        Set(value As Boolean)
            _GeneraAsiento = value
        End Set
    End Property
    Public Property AsientoEncabezado As TAuxAsientoEncabezado
        Get
            Return _AsientoEncabezado
        End Get
        Set(value As TAuxAsientoEncabezado)
            _AsientoEncabezado = value
        End Set
    End Property
    Public ReadOnly Property Consecutivos As DataTable
        Get
            Return _Consecutivos
        End Get
    End Property
    Public Property FacturaEncabezado As TFacturaEncabezado
        Get
            Return _FacturaEncabezado
        End Get
        Set(value As TFacturaEncabezado)
            _FacturaEncabezado = value
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
        _Tipo_Id = 0
        _Mov_Id = 0
        _Cliente_Id = 0
        _Referencia = ""
        _Fecha = CDate("1900/01/01")
        _FechaRecibido = CDate("1900/01/01")
        _FechaDocumento = CDate("1900/01/01")
        _FechaVencimiento = CDate("1900/01/01")
        _Moneda = ""
        _Monto = 0.0
        _Saldo = 0.0
        _TipoCambio = 0.0
        _Dolares = 0
        _Usuario_Id = ""
        _AplicaMora = 0
        _FechaCalculoMora = CDate("1900/01/01")
        _Batch_Id = 0
        _Caja_Id = 0
        _Cierre_Id = 0
        _UltimaModificacion = CDate("1900/01/01")
        _ListaPagos.Clear()
        _ListaMovimientos.Clear()
        _GeneraNotaCredito = False
        _MontoNotaCredito = 0.0
        _MAC_Address = ""
        _GeneraAsiento = False
        _AsientoEncabezado = New TAuxAsientoEncabezado(0)
        _Consecutivos = New DataTable("Movimientos")
        _Consecutivos.Columns.Add("Tipo_Id", Type.GetType("System.String"))
        _Consecutivos.Columns.Add("Mov_Id", Type.GetType("System.String"))
        _Consecutivos.Columns.Add("Emp_Id", Type.GetType("System.String"))
        _FacturaEncabezado = Nothing
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Dim Tabla As New DataTable
        Dim TotalPagado As Double = 0.0
        Dim TipoNC_Id As Integer = 0
        Dim MovNC_Id As Long = 0
        Dim Caja As Integer = 0
        Dim Cierre As Integer = 0

        Try
            Cn.Open()

            Cn.BeginTransaction()


            If _Tipo_Id <> Enum_CxCMovimientoTipo.Recibo Then
                _Caja_Id = 0
                _Cierre_Id = 0
            End If

            'Busca y asigna el siguiente número de batch
            VerificaMensaje(GetSiguienteBatch)

            'Guarda el encabezado del movimiento y este retorna el numero de movimiento
            Query = "exec CxC_CreaMovimiento " & _Emp_Id.ToString & "," & _Tipo_Id.ToString & "," & _Cliente_Id.ToString &
                    ",'" & _Referencia & "','" & Format(_FechaRecibido, "yyyyMMdd") & "','" & Format(_FechaDocumento, "yyyyMMdd") & "'" &
                    ",'" & Format(_FechaVencimiento, "yyyyMMdd") & "','" & _Moneda & "'," & _Monto.ToString &
                    "," & _TipoCambio.ToString & ",'" & _Usuario_Id & "'," & _AplicaMora.ToString & "," & _Batch_Id.ToString &
                    "," & IIf(_Caja_Id <= 0, "NULL", _Caja_Id.ToString) & "," & IIf(_Cierre_Id <= 0, "NULL", _Cierre_Id.ToString)

            Tabla = Cn.Seleccionar(Query).Copy

            'Asigna el numero de movimiento retornado anteriormente
            If Not Tabla Is Nothing OrElse Tabla.Rows.Count > 0 Then
                _Mov_Id = Tabla.Rows(0).Item("Mov_Id")

                _Consecutivos.Rows.Add(New Object() {_Tipo_Id, _Mov_Id, _Emp_Id})

                'Almacena el documento de PV para evitar que se duplique Jimmy 06 Mayo 2019
                If Not _FacturaEncabezado Is Nothing Then
                    Query = " Insert into FacturaEncabezado( Emp_Id , Suc_Id, Caja_Id , TipoDoc_Id, Documento_Id , Fecha)" &
                           " Values ( " & _FacturaEncabezado.Emp_Id.ToString & "," & _FacturaEncabezado.Suc_Id.ToString &
                           "," & _FacturaEncabezado.Caja_Id.ToString & "," & _FacturaEncabezado.TipoDoc_Id.ToString &
                           "," & _FacturaEncabezado.Documento_Id.ToString & ", getdate())"

                    Cn.Ejecutar(Query)

                    Query = " Insert into FacturaEncabezadoCxC( Emp_Id , Suc_Id, Caja_Id , TipoDoc_Id, Documento_Id , Tipo_Id, Mov_Id , Fecha)" &
                           " Values ( " & _FacturaEncabezado.Emp_Id.ToString & "," & _FacturaEncabezado.Suc_Id.ToString &
                           "," & _FacturaEncabezado.Caja_Id.ToString & "," & _FacturaEncabezado.TipoDoc_Id.ToString &
                           "," & _FacturaEncabezado.Documento_Id.ToString & "," & _Tipo_Id.ToString &
                           "," & _Mov_Id.ToString & ",getdate())"

                    Cn.Ejecutar(Query)
                End If
            Else
                VerificaMensaje("Ocurrió un error al obtener el consecutivo del movimiento")
            End If

            'Verifica si el movimiento posee pagos para aplicar
            If Not _ListaPagos Is Nothing AndAlso _ListaPagos.Count > 0 Then
                For Each Pago As TCxCMovimientoPago In _ListaPagos
                    'Guarda el pago realizado al movimiento
                    Query = "exec CxC_CreaMovimientoPago " & Pago.Emp_Id.ToString & "," & _Tipo_Id.ToString & _
                            "," & _Mov_Id.ToString & "," & Pago.TipoPago_Id.ToString & "," & Pago.Monto.ToString & _
                            "," & Pago.Banco_Id.ToString & ",'" & Pago.Cuenta & "','" & Pago.ChequeNumero & "'" & _
                            ",'" & Format(Pago.ChequeFecha, "yyyyMMdd") & "','" & Pago.DepositoNumero & "'" & _
                            ",'" & Format(Pago.DepositoFecha, "yyyyMMdd") & "','" & Pago.TransferenciaNumero & "'" & _
                            "," & Pago.Tarjeta_Id.ToString & ",'" & Pago.TarjetaNumero & "','" & Pago.TarjetaAutorizacion & "'" & _
                            ",'" & Pago.Moneda & "'," & Pago.TipoCambio.ToString & "," & Pago.Dolares.ToString & _
                            "," & Pago.Caja_Id.ToString & "," & Pago.Cierre_Id.ToString & "," & _Batch_Id.ToString

                    Cn.Ejecutar(Query)
                Next

                'Obtiene el numero de caja y cierre de los pagos realizados
                Caja = _ListaPagos.Item(0).Caja_Id
                Cierre = _ListaPagos.Item(0).Cierre_Id

                'Acumula los pagos en el cierre de caja
                Query = "exec CierreCajaAcumulaPago " & _Emp_Id.ToString & "," & Caja.ToString & _
                         "," & Cierre.ToString & "," & _Tipo_Id.ToString & "," & _Mov_Id.ToString

                Cn.Ejecutar(Query)
            End If

            'Si el documento es un recibo hay dos maneras de distribuir el pago
            'Cambio de Hulk
            If _Tipo_Id = Enum_CxCMovimientoTipo.Recibo Or _Tipo_Id = Enum_CxCMovimientoTipo.NotaCredito Then
                '1 - El usuario eligió los documentos que quería aplicar
                If Not _ListaMovimientos Is Nothing AndAlso _ListaMovimientos.Count > 0 Then
                    TotalPagado = _Monto ' Obtiene el monto total a distribuir en las facturas seleccionadas

                    For Each Movimieno As TCxCMovimientoLinea In _ListaMovimientos
                        'Si el monto para aplicar documentos es igual a 0 finaliza el proceso
                        If TotalPagado = 0 Then
                            Exit For
                        End If

                        'Si el monto del documento es menor o igual al total por distribuir, cancela el documento
                        If TotalPagado >= Movimieno.Monto Then
                            Query = "exec CxC_AplicaMovimiento " & _Emp_Id.ToString & "," & _Tipo_Id.ToString &
                                    "," & _Mov_Id.ToString & "," & _Cliente_Id.ToString & "," & Movimieno.Tipo_Id.ToString &
                                    "," & Movimieno.Mov_Id.ToString & "," & Movimieno.Monto.ToString

                            Cn.Ejecutar(Query)

                            'Resta el monto que se cancelo del movimiento al total por distribuir
                            TotalPagado -= Movimieno.Monto
                        Else 'Si el monto del documento es mayor al total por distribuir, rebaja el saldo y termina el proceso
                            Query = "exec CxC_AplicaMovimiento " & _Emp_Id.ToString & "," & _Tipo_Id.ToString &
                                    "," & _Mov_Id.ToString & "," & _Cliente_Id.ToString & "," & Movimieno.Tipo_Id.ToString &
                                    "," & Movimieno.Mov_Id.ToString & "," & TotalPagado.ToString

                            Cn.Ejecutar(Query)

                            TotalPagado = 0

                            Exit For
                        End If
                    Next

                    If TotalPagado > 0 Then
                        'Distribuye el pago entre todas las facturas posibles comenzando con íntereses y por antigüedad
                        Query = "exec CxC_DistribuyePago " & _Emp_Id.ToString & "," & _Tipo_Id.ToString &
                                "," & _Mov_Id.ToString & "," & _Cliente_Id.ToString & "," & TotalPagado.ToString

                        Cn.Ejecutar(Query)
                    End If
                Else '2 - El usuario solo creo el recibo
                    'Distribuye el pago entre todas las facturas posibles comenzando con íntereses y por antigüedad
                    Query = "exec CxC_DistribuyePago " & _Emp_Id.ToString & "," & _Tipo_Id.ToString &
                            "," & _Mov_Id.ToString & "," & _Cliente_Id.ToString & "," & _Monto.ToString

                    Cn.Ejecutar(Query)
                End If

            End If


            'Modificacion Rambo
            ''En caso de que el documento sea una nota de credito siempre distribuye el pago de esta manera
            'If _Tipo_Id = Enum_CxCMovimientoTipo.NotaCredito Then
            '    'Distribuye el pago entre todas las facturas posibles comenzando con íntereses y por antigüedad
            '    Query = "exec CxC_DistribuyePago " & _Emp_Id.ToString & "," & _Tipo_Id.ToString & _
            '            "," & _Mov_Id.ToString & "," & _Cliente_Id.ToString & "," & _Monto.ToString

            '    Cn.Ejecutar(Query)
            'End If

            'Si hubo un pago adicional al saldo y queda un saldo a favor se genera una nota de crédito
            If _GeneraNotaCredito Then
                TipoNC_Id = Enum_CxCMovimientoTipo.NotaCredito

                'Genera la nota de crédito por el excedente
                Query = "exec CxC_CreaMovimiento " & _Emp_Id.ToString & "," & TipoNC_Id.ToString & "," & _Cliente_Id.ToString & _
                        ",'NOTA DE CRÉDITO DEBIDO A EXCEDENTE DE PAGO REALIZADO EN EL MOVIMIENTO #" & _Mov_Id.ToString & "'" & _
                        ",'" & Format(_FechaRecibido, "yyyyMMdd") & "','" & Format(_FechaDocumento, "yyyyMMdd") & "'" & _
                        ",'" & Format(_FechaVencimiento, "yyyyMMdd") & "','" & _Moneda & "'," & _MontoNotaCredito.ToString & _
                        "," & _TipoCambio.ToString() & ",'" & _Usuario_Id & "'," & "0" & "," & _Batch_Id.ToString & ",NULL,NULL"

                Tabla = Cn.Seleccionar(Query).Copy

                'Obtiene el numero del movimiento de la nota de credito
                If Not Tabla Is Nothing OrElse Tabla.Rows.Count > 0 Then
                    MovNC_Id = Tabla.Rows(0).Item("Mov_Id")

                    _Consecutivos.Rows.Add(New Object() {TipoNC_Id, MovNC_Id, _Emp_Id})

                    'Almacena el documento de PV para evitar que se duplique Jimmy 06 Mayo 2019
                    If Not _FacturaEncabezado Is Nothing Then
                        Query = " Insert into FacturaEncabezadoCxC( Emp_Id , Suc_Id, Caja_Id , TipoDoc_Id, Documento_Id , Tipo_Id, Mov_Id , Fecha)" &
                           " Values ( " & _FacturaEncabezado.Emp_Id.ToString & "," & _FacturaEncabezado.Suc_Id.ToString &
                           "," & _FacturaEncabezado.Caja_Id.ToString & "," & _FacturaEncabezado.TipoDoc_Id.ToString &
                           "," & _FacturaEncabezado.Documento_Id.ToString & "," & TipoNC_Id.ToString &
                           "," & MovNC_Id.ToString & ",getdate())"

                        Cn.Ejecutar(Query)
                    End If
                Else
                    VerificaMensaje("Ocurrió un error al obtener el consecutivo de la nota de crédito")
                End If

                'Distribuye el monto de la nota de credito entre todas las facturas posibles comenzando con intereses y por antigüedad
                Query = "exec CxC_DistribuyePago " & _Emp_Id.ToString & "," & TipoNC_Id & _
                        "," & MovNC_Id.ToString & "," & _Cliente_Id.ToString & "," & _MontoNotaCredito.ToString

                Cn.Ejecutar(Query)
            End If

            ''Si el tipo de movimiento es un recibo(2), genera un asiento automatico para la transacción
            'If _Tipo_Id = Enum_CxCMovimientoTipo.Recibo Then
            '    Query = "exec CxC_GeneraAsientoPago " & _Emp_Id.ToString & "," & _Batch_Id.ToString & ",'" & _MAC_Address & "'"

            '    Cn.Ejecutar(Query)
            'End If

            ''Genera un asiento para los movimientos, con las cuentas digitadas a la hora de registrar el documento
            'If _GeneraAsiento Then
            '    Select Case _Tipo_Id
            '        Case Enum_CxCMovimientoTipo.Factura, Enum_CxCMovimientoTipo.NotaCredito, Enum_CxCMovimientoTipo.NotaDebito
            '            Query = " exec CreaAuxAsientoEncabezado " & AsientoEncabezado.Emp_Id.ToString & "," & AsientoEncabezado.Annio.ToString & _
            '                    "," & AsientoEncabezado.Mes.ToString & ",'" & Format(AsientoEncabezado.Fecha, "yyyyMMdd HH:mm:ss") & "'," & AsientoEncabezado.Tipo_Id.ToString & _
            '                    ",'" & AsientoEncabezado.Comentario & "'" & "," & AsientoEncabezado.Debitos.ToString & "," & AsientoEncabezado.Creditos.ToString & ",'" & _Usuario_Id & "'" & _
            '                    "," & AsientoEncabezado.Origen_Id.ToString & ",'" & AsientoEncabezado.MAC_Address & "'"

            '            Tabla = Cn.Seleccionar(Query).Copy

            '            If Not Tabla Is Nothing OrElse Tabla.Rows.Count > 0 Then
            '                AsientoEncabezado.Asiento_Id = Tabla.Rows(0).Item("Asiento_Id")
            '            End If

            '            For Each Item As TAuxAsientoDetalle In AsientoEncabezado.ListaDetalle
            '                Query = " exec CreaAuxAsientoDetalle " & Item.Emp_Id.ToString & "," & AsientoEncabezado.Asiento_Id.ToString & _
            '                        "," & Item.Linea_Id.ToString & ",'" & Format(Item.Fecha, "yyyyMMdd HH:mm:ss") & "'" & _
            '                        ",'" & Item.Moneda.ToString & "'," & Item.CC_Id.ToString & ",'" & Item.Cuenta_Id & "'" & _
            '                        ",'" & Item.Tipo.ToString & "'," & Item.Monto.ToString & "," & Item.MontoDolares.ToString & _
            '                        "," & Item.TipoCambio.ToString & ",'" & Item.Referencia & "','" & Item.Descripcion & "'"

            '                Cn.Ejecutar(Query)
            '            Next
            '    End Select
            'End If

            Cn.CommitTransaction()

            Return String.Empty
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

            Query = "Delete CxCMovimiento" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Tipo_Id = " & _Tipo_Id.ToString & _
                    " And   Mov_Id = " & _Mov_Id.ToString

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

            Query = " Update CxCMovimiento " &
                    " SET    Cliente_Id = " & _Cliente_Id.ToString & "," &
                    " Referencia = '" & _Referencia & "'" & "," &
                    " Fecha = '" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," &
                    " FechaRecibido = '" & Format(_FechaRecibido, "yyyyMMdd HH:mm:ss") & "'" & "," &
                    " FechaDocumento = '" & Format(_FechaDocumento, "yyyyMMdd HH:mm:ss") & "'" & "," &
                    " FechaVencimiento = '" & Format(_FechaVencimiento, "yyyyMMdd HH:mm:ss") & "'" & "," &
                    " Moneda = '" & _Moneda & "'" & "," &
                    " Monto = " & _Monto & "," &
                    " Saldo = " & _Saldo & "," &
                    " TipoCambio = " & _TipoCambio & "," &
                    " Dolares = " & _Dolares & "," &
                    " Usuario_Id = '" & _Usuario_Id & "'" & "," &
                    " AplicaMora = " & _AplicaMora & "," &
                    " FechaCalculoMora = '" & Format(_FechaCalculoMora, "yyyyMMdd HH:mm:ss") & "'" & "," &
                    " Batch_Id = " & _Batch_Id & "," &
                    " Caja_Id = " & _Caja_Id & "," &
                    " Cierre_Id = " & _Cierre_Id & "," &
                    " UltimaModificacion = GETDATE()" &
                    " Where Emp_Id = " & _Emp_Id.ToString &
                    " And   Tipo_Id = " & _Tipo_Id.ToString &
                    " And   Mov_Id = " & _Mov_Id.ToString

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
                    " ,b.Nombre as NombreTipo" & _
                    " ,c.Nombre as NombreUsuario" & _
                    " ,d.Nombre as NombreCliente" & _
                    " ,d.Saldo as SaldoCliente" & _
                    " From CxCMovimiento a" & _
                    " ,CxCMovimientoTipo b" & _
                    " ,Usuario c" & _
                    " ,Cliente d" & _
                    " Where a.Emp_Id = b.Emp_Id" & _
                    " And   a.Tipo_Id = b.Tipo_Id" & _
                    " And   a.Emp_Id = c.Emp_Id" & _
                    " And   a.Usuario_Id = c.Usuario_Id" & _
                    " And   a.Emp_Id = d.Emp_Id" & _
                    " And   a.Cliente_Id = d.Cliente_Id" & _
                    " And   a.Emp_Id = " & _Emp_Id.ToString & _
                    " And   a.Tipo_Id = " & _Tipo_Id.ToString & _
                    " And   a.Mov_Id = " & _Mov_Id.ToString

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

            If _Cliente_Id <> 0 Then
                Query = "select a.Mov_Id, b.Nombre as TipoNombre, a.Tipo_Id, a.Referencia, a.FechaVencimiento, a.Monto, a.Saldo " &
                        "From CxCMovimiento a " &
                        "inner join CxCMovimientoTipo b  on b.Emp_Id = a.Emp_Id and b.Tipo_Id = a.Tipo_Id " &
                        "where a.Emp_Id = " & _Emp_Id.ToString() & " " &
                        "and   a.Cliente_Id = " & _Cliente_Id & " " &
                        "order by a.FechaVencimiento asc"
            Else
                Query = "select * From CxCMovimiento"
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
    Public Overrides Function LoadComboBox() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select Mov_Id as Numero, Nombre From CxCMovimiento"

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

            Query = "select Mov_Id as Codigo, Nombre From CxCMovimiento" & _
                    " where Emp_Id = " & _Emp_Id.ToString

            If pNombre.Trim <> "" Then
                Query += " And Nombre Like '%" & pNombre & "%'"
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

            Query = "select IsNull(MAX(Mov_Id),0) + 1 as Mov_Id From CxCMovimiento" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Tipo_Id = " & _Tipo_Id.ToString

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
    Private Function GetSiguienteBatch() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Query = "SELECT NEXT VALUE FOR BatchNumber as Batch_Id"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Batch_Id = Tabla.Rows(0).Item("Batch_Id")
            Else
                VerificaMensaje("Ocurrió un error buscando el número de batch")
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
End Class