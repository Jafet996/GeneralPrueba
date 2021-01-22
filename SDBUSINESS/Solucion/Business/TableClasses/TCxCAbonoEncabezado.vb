Public Class TCxCAbonoEncabezado
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _Abono_Id As Integer
    Private _Tipo_Id As Integer
    Private _Fecha As DateTime
    Private _Monto As Double
    Private _Vendedor_Id As Integer
    Private _VendedorNombre As String
    Private _Usuario_Id As String
    Private _Detalles As New List(Of TCxCAbonoDetalle)
    Private _Pagos As New List(Of TCxCAbonoPago)
    Private _Cliente As TCliente
    Private _Cliente_Id As Integer
    Private _Anulado As Integer
    Private _AnuladoFecha As DateTime
    Private _TipoDocumentoNombre As String
    Private _UsuarioNombre As String
    Private _SaldoCxC As Double
    Private _Referencia As String
    Private _Data As DataSet
    Private _SDL As New SDFinancial.SDFinancial
    Private _DTMovimiento As New SDFinancial.DTCxCMovimiento
    Private _Resultado As New SDFinancial.TResultado
    Private _MovimientoLista As New List(Of SDFinancial.DTCxCMovimientoLinea)
    Private _ClienteNombre As String
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

    Public Property Vendedor_Id() As Integer
        Get
            Return _Vendedor_Id
        End Get
        Set(ByVal Value As Integer)
            _Vendedor_Id = Value
        End Set
    End Property

    Public Property VendedorNombre() As String
        Get
            Return _VendedorNombre
        End Get
        Set(ByVal Value As String)
            _VendedorNombre = Value
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
    Public Property TipoDocumentoNombre() As String
        Get
            Return _TipoDocumentoNombre
        End Get
        Set(ByVal value As String)
            _TipoDocumentoNombre = value
        End Set
    End Property

    Public Property UsuarioNombre() As String
        Get
            Return _UsuarioNombre
        End Get
        Set(ByVal value As String)
            _UsuarioNombre = value
        End Set
    End Property

    Public ReadOnly Property Data() As DataSet
        Get
            Return _Data
        End Get
    End Property
    Public Property Detalles As List(Of TCxCAbonoDetalle)
        Get
            Return _Detalles
        End Get
        Set(value As List(Of TCxCAbonoDetalle))
            _Detalles = value
        End Set
    End Property
    Public Property Pagos As List(Of TCxCAbonoPago)
        Get
            Return _Pagos
        End Get
        Set(value As List(Of TCxCAbonoPago))
            _Pagos = value
        End Set
    End Property
    Public ReadOnly Property RowsAffected() As Long
        Get
            Return Cn.RowsAffected
        End Get
    End Property
    Public Property Cliente As TCliente
        Get
            Return _Cliente
        End Get
        Set(value As TCliente)
            _Cliente = value
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
    Public Property Tipo_Id() As Integer
        Get
            Return _Tipo_Id
        End Get
        Set(ByVal Value As Integer)
            _Tipo_Id = Value
        End Set
    End Property
    Public Property ClienteNombre() As String
        Get
            Return _ClienteNombre
        End Get
        Set(ByVal Value As String)
            _ClienteNombre = Value
        End Set
    End Property
    Public Property Anulado As Integer
        Get
            Return _Anulado
        End Get
        Set(value As Integer)
            _Anulado = value
        End Set
    End Property
    Public Property AnuladoFecha As DateTime
        Get
            Return _AnuladoFecha
        End Get
        Set(value As DateTime)
            _AnuladoFecha = value
        End Set
    End Property
    Public Property SaldoCxC() As Double
        Get
            Return _SaldoCxC
        End Get
        Set(ByVal value As Double)
            _SaldoCxC = value
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
        If Not InfoMaquina Is Nothing AndAlso InfoMaquina.URLContabilidad <> "" Then
            _SDL.Url = InfoMaquina.URLContabilidad
        End If
        _Emp_Id = 0
        _Suc_Id = 0
        _Caja_Id = 0
        _Cierre_Id = 0
        _Abono_Id = 0
        _Tipo_Id = 0
        _Fecha = CDate("1900/01/01")
        _Monto = 0.00
        _Vendedor_Id = 0
        _VendedorNombre = ""
        _Usuario_Id = ""
        _Data = New DataSet
        _Detalles.Clear()
        _Pagos.Clear()
        _Cliente_Id = 0
        _Anulado = 0
        _AnuladoFecha = CDate("1900/01/01")
        _TipoDocumentoNombre = ""
        _UsuarioNombre = ""
        _ClienteNombre = ""
        _SaldoCxC = 0
        _Referencia = ""
        _MovimientoLista.Clear()
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Function SiguienteAbono(pOpenConnection As Boolean) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            If pOpenConnection Then
                Cn.Open()
            End If

            _Abono_Id = 0

            Query = "select (isnull(max(Abono_Id),0) + 1) as SiguienteDocumento" &
                    " From CxCAbonoEncabezado" &
                    " Where Emp_Id =" & _Emp_Id.ToString() &
                    " And   Suc_Id =" & _Suc_Id.ToString() &
                    " And   Caja_Id=" & _Caja_Id.ToString() &
                    " And   Tipo_Id=" & _Tipo_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                Abono_Id = Tabla.Rows(0).Item("SiguienteDocumento")
            Else
                VerificaMensaje("Se presentaron errorres buscando el número de documento")
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            If pOpenConnection Then
                Cn.Close()
            End If
        End Try
    End Function


    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into CxCAbonoEncabezado( Emp_Id , Suc_Id" &
           " , Caja_Id , Tipo_Id" &
           " , Abono_Id , Referencia" &
           " , Cierre_Id , Cliente_Id" &
           " , Fecha , Monto" &
           " , Vendedor_Id , Usuario_Id" &
           " , Anulado , AnuladoFecha" &
           " )" &
           " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
           "," & _Caja_Id.ToString() & "," & _Tipo_Id.ToString() &
           "," & _Abono_Id.ToString() & ",'" & _Referencia & "'" &
           "," & _Cierre_Id.ToString() & "," & _Cliente_Id.ToString() &
           ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _Monto.ToString() &
           "," & _Vendedor_Id.ToString() & ",'" & _Usuario_Id & "'" &
           "," & _Anulado.ToString() & ",'" & Format(_AnuladoFecha, "yyyyMMdd HH:mm:ss") & "')"

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

            Query = "Delete CxCAbonoEncabezado" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And    Suc_Id=" & _Suc_Id.ToString() &
               " And    Caja_Id=" & _Caja_Id.ToString() &
               " And    Tipo_Id=" & _Tipo_Id.ToString() &
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

            Query = " Update dbo.CxCAbonoEncabezado " &
           " SET   Referencia='" & _Referencia & "' " & "," &
           " Cierre_Id=" & _Cierre_Id & "," &
           " Cliente_Id=" & _Cliente_Id & "," &
           " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," &
           " Monto=" & _Monto & "," &
           " Vendedor_Id=" & _Vendedor_Id & "," &
           " Usuario_Id='" & _Usuario_Id & "'" & "," &
           " Anulado=" & _Anulado & "," &
           " AnuladoFecha='" & Format(_AnuladoFecha, "yyyyMMdd HH:mm:ss") & "'" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    Caja_Id=" & _Caja_Id.ToString() &
           " And    Tipo_Id=" & _Tipo_Id.ToString() &
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
        Dim CxC_Cliente = New TCxC_Cliente
        Try
            Cn.Open()


            Query = "select a.*, b.Nombre as TipoDocumentoNombre, c.Nombre as UsuarioNombre, d.Nombre as ClienteNombre  From CxCAbonoEncabezado a" &
           " inner join CxCAbonoTipo b on a.Tipo_Id = b.Tipo_Id" &
           " inner join Usuario c on a.Emp_Id = c.Emp_Id and a.Usuario_Id = c.Usuario_Id" &
           " inner join Cliente d on a.Emp_Id = d.Emp_Id and a.Cliente_Id = d.Cliente_Id" &
           " Where  a.Emp_Id=" & _Emp_Id.ToString() &
           " And    a.Suc_Id=" & _Suc_Id.ToString() &
           " And    a.Caja_Id=" & _Caja_Id.ToString() &
           " And    a.Tipo_Id=" & _Tipo_Id.ToString() &
           " And    a.Abono_Id=" & _Abono_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                _Cierre_Id = Tabla.Rows(0).Item("Cierre_Id")
                _Abono_Id = Tabla.Rows(0).Item("Abono_Id")
                _Tipo_Id = Tabla.Rows(0).Item("Tipo_Id")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Monto = Tabla.Rows(0).Item("Monto")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _Anulado = Tabla.Rows(0).Item("Anulado")
                _AnuladoFecha = Tabla.Rows(0).Item("AnuladoFecha")
                _Vendedor_Id = Tabla.Rows(0).Item("Vendedor_Id")
                _VendedorNombre = Tabla.Rows(0).Item("Vendedor_Id")
                _TipoDocumentoNombre = Tabla.Rows(0).Item("TipoDocumentoNombre")
                _UsuarioNombre = Tabla.Rows(0).Item("UsuarioNombre")
                _ClienteNombre = Tabla.Rows(0).Item("ClienteNombre")
                _Referencia = Tabla.Rows(0).Item("Referencia")
            End If

            With CxC_Cliente
                .Emp_Id = EmpresaParametroInfo.EmpresaExterna
                .Cliente_Id = _Cliente.ClienteExterno
            End With
            VerificaMensaje(CxC_Cliente.ListKey)

            SaldoCxC = CxC_Cliente.Saldo

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            CxC_Cliente = Nothing
            Cn.Close()
        End Try
    End Function
    Public Overrides Function List() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select * From CxCAbonoEncabezado"

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

            Query = "select CxCAbonoEncabezado_Id as Numero, Nombre From CxCAbonoEncabezado"

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
    Public Function GuardaAbono() As String
        Dim Query As String = ""
        Dim Mensaje As String = ""
        Dim CxCTotalSeleccionadas As Double = 0
        Dim CxCMontoNota As Double = 0
        Dim CxC_Cliente = New TCxC_Cliente
        Try
            Cn.Open()

            Cn.BeginTransaction()


            Query = " Insert into CxCAbonoEncabezado( Emp_Id , Suc_Id" &
                   " , Caja_Id , Tipo_Id" &
                   " , Abono_Id , Referencia, Cierre_Id" &
                   " , Cliente_Id , Fecha" &
                   " , Monto , Vendedor_Id" &
                   " , Usuario_Id , Anulado" &
                   " , AnuladoFecha )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Caja_Id.ToString() & "," & _Tipo_Id.ToString() &
                   "," & _Abono_Id.ToString() & ",'" & _Referencia.Trim() & "'," & _Cierre_Id.ToString() &
                   "," & _Cliente_Id.ToString() & ",getdate()" &
                   "," & _Monto.ToString() & "," & _Vendedor_Id.ToString() &
                   ",'" & _Usuario_Id & "'" & ",0,'19000101')"

            Cn.Ejecutar(Query)

            '----------- Guarda los pagos 
            For Each Pago As TCxCAbonoPago In _Pagos

                Query = " Insert into CxCAbonoPago( Emp_Id , Suc_Id" &
                        " , Caja_Id , Tipo_Id, Abono_Id" &
                        " , Pago_Id,  TipoPago_Id , Monto" &
                        " , Banco_Id , ChequeNumero, ChequeFecha" &
                        " , Tarjeta_Id , TarjetaNumero" &
                        " , TarjetaAutorizacion , Fecha" &
                        " )" &
                        " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                        "," & _Caja_Id.ToString() & "," & _Tipo_Id.ToString() &
                        "," & Abono_Id.ToString() & "," & Pago.Pago_Id.ToString() &
                        "," & Pago.TipoPago_Id.ToString() & "," & Pago.Monto.ToString() &
                        "," & IIf(Pago.Banco_Id > 0, Pago.Banco_Id.ToString(), "null") & ",'" & Pago.ChequeNumero & "','" & Format(Pago.ChequeFecha, "yyyyMMdd") & "'" &
                        "," & IIf(Pago.Tarjeta_Id > 0, Pago.Tarjeta_Id.ToString(), "null") & ",'" & Pago.TarjetaNumero & "'" &
                        ",'" & Pago.TarjetaAutorizacion & "'" & ",'" & Format(Pago.Fecha, "yyyyMMdd HH:mm:ss") & "')"
                Cn.Ejecutar(Query)
            Next

            Query = "exec CierreCajaAcumulaCxCAbonoPago " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," &
                _Caja_Id.ToString() & "," & _Tipo_Id.ToString() & "," & _Abono_Id.ToString() & "," & _Cierre_Id.ToString()

            Cn.Ejecutar(Query)

            '----------- Guarda el detalle del abono
            _MovimientoLista.Clear()

            For Each Detalle As TCxCAbonoDetalle In _Detalles
                Query = "Insert into CxCAbonoDetalle( Emp_Id, Suc_Id, Caja_Id" &
                       ", Tipo_Id, Abono_Id, Detalle_Id " &
                       ", Fecha, CxCTipo_Id, CxCMov_Id) " &
                       " Values ( " & _Emp_Id.ToString() & " ," & _Suc_Id.ToString() & "," & _Caja_Id.ToString() &
                       ", " & _Tipo_Id & "," & Abono_Id & " ," & Detalle.Detalle_Id.ToString() &
                       ", '" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "' ," & Detalle.Tipo_Id.ToString() & " ," & Detalle.Mov_Id.ToString() & ")"
                Cn.Ejecutar(Query)

                _MovimientoLista.Add(New SDFinancial.DTCxCMovimientoLinea() With
                                     {.Emp_Id = EmpresaParametroInfo.EmpresaExterna _
                                     , .Tipo_Id = Detalle.Tipo_Id _
                                     , .Mov_Id = Detalle.Mov_Id _
                                     , .Monto = Detalle.Monto})

                CxCTotalSeleccionadas += Detalle.Monto
            Next


            _Cliente = New TCliente(_Emp_Id)
            _Cliente.Cliente_Id = _Cliente_Id
            VerificaMensaje(Cliente.ListKey)

            'Verifica que el codigo del cliente sea del formato esperado
            If Not IsNumeric(_Cliente.ClienteExterno) Then
                VerificaMensaje("El código asociado al cliente en CxC debe de ser númerico")
            End If

            Mensaje = _SDL.VerificaCliente(EmpresaParametroInfo.EmpresaExterna, _Cliente.ClienteExterno)
            VerificaMensaje(Mensaje)


            With CxC_Cliente
                .Emp_Id = EmpresaParametroInfo.EmpresaExterna
                .Cliente_Id = _Cliente.ClienteExterno
            End With
            VerificaMensaje(CxC_Cliente.ListKey)

            ' agrega la referencia 
            _DTMovimiento.Tipo_Id = Enum_CxCMovimientoTipo.NotaCredito
            _DTMovimiento.Referencia = "Pago SD-POS "



            If CxCTotalSeleccionadas > 0 Then
                If _Monto > CxCTotalSeleccionadas Then
                    CxCMontoNota = _Monto - CxCTotalSeleccionadas
                    _Monto = CxCTotalSeleccionadas
                End If

                With _DTMovimiento
                    .Emp_Id = EmpresaParametroInfo.EmpresaExterna
                    .Cliente_Id = _Cliente.ClienteExterno
                    .Referencia += _Referencia
                    .FechaRecibido = _Fecha
                    .FechaDocumento = _Fecha
                    .FechaVencimiento = DateAdd(DateInterval.Day, CxC_Cliente.DiasCredito, _Fecha)
                    .Moneda = coMonedaColones
                    .Monto = Math.Abs(_Monto)
                    .Saldo = 0.00
                    .TipoCambio = 0.00
                    .Usuario_Id = coUsuarioGeneral
                    .AplicaMora = CxC_Cliente.AplicaMora
                    .Caja_Id = 0
                    .Cierre_Id = 0
                    .Tipo_Id = Enum_CxCMovimientoTipo.NotaCredito
                    .ListaMovimientos = _MovimientoLista.ToArray
                    .GeneraNotaCredito = (CxCMontoNota > 0)
                    .MontoNotaCredito = CxCMontoNota
                End With

            Else
                'If CxC_Cliente.Saldo < _Monto Then
                '    CxCMontoNota = _Monto - CxC_Cliente.Saldo
                '    _Monto = CxC_Cliente.Saldo
                'End If
                With _DTMovimiento
                    .Emp_Id = EmpresaParametroInfo.EmpresaExterna
                    .Cliente_Id = _Cliente.ClienteExterno
                    .Referencia += _Referencia + " Pago aplicado sin seleccionar facturas"
                    .FechaRecibido = _Fecha
                    .FechaDocumento = _Fecha
                    .FechaVencimiento = DateAdd(DateInterval.Day, CxC_Cliente.DiasCredito, _Fecha)
                    .Moneda = coMonedaColones
                    .Monto = Math.Abs(_Monto)
                    .Saldo = 0.00
                    .TipoCambio = 0.00
                    .Usuario_Id = coUsuarioGeneral
                    .AplicaMora = CxC_Cliente.AplicaMora
                    .Caja_Id = 0
                    .Cierre_Id = 0
                    .Tipo_Id = Enum_CxCMovimientoTipo.NotaCredito
                    .GeneraNotaCredito = False
                End With

            End If


            _Resultado = _SDL.CxCMovimientoMant(_DTMovimiento, SDFinancial.EnumOperacionMant.Insertar, String.Empty)
            VerificaMensaje(_Resultado.ErrorDescription)


            VerificaMensaje(CxC_Cliente.ListKey)

            _SaldoCxC = CxC_Cliente.Saldo



            Cn.CommitTransaction()

            Return ""

        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function ListAbono(pCliente As Boolean, pFechas As Boolean, pDesde As DateTime, pHasta As DateTime) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select a.*, c.Nombre From CxCAbonoEncabezado a inner join Cliente c on a.Emp_Id = c.Emp_Id and a.Cliente_Id = c.Cliente_Id" &
           " Where  a.Emp_Id  =" & _Emp_Id.ToString() &
           " And    a.Suc_Id  =" & _Suc_Id.ToString() &
           " And    a.Caja_Id =" & _Caja_Id.ToString() &
           " And    a.Tipo_Id =" & Enum_CxCAbonoTipo.Abono &
           " And    a.Anulado = 0"

            If pCliente = True Then
                Query = Query & " And    a.Cliente_Id=" & _Cliente_Id.ToString()
            End If

            If pFechas = True Then
                Query = Query & " And  Fecha >= '" & Format(pDesde, "yyyyMMdd") & "' And Fecha <'" & Format(DateAdd(DateInterval.Day, 1, pHasta), "yyyyMMdd") & "'"
            End If

            Tabla = Cn.Seleccionar(Query).Copy
            _Data.Tables.Add(Tabla)

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function AnulaAbono() As String
        Dim Query As String = ""
        Dim Mensaje As String = ""
        Dim Anulacion_Id As Long = 0
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Update CxCAbonoEncabezado " &
           " SET    Anulado= 1, AnuladoFecha = getdate() " &
           " Where  Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    Caja_Id=" & _Caja_Id.ToString() &
           " And    Tipo_Id=" & _Tipo_Id.ToString() &
           " And    Abono_Id=" & _Abono_Id.ToString()

            Cn.Ejecutar(Query)

            _Tipo_Id = Enum_CxCAbonoTipo.AbonoAnulacion
            _Referencia = "Anulacion Abono # " & _Abono_Id.ToString()
            SiguienteAbono(False)

            Query = "exec CierreCajaAcumulaCxCAbonoMonto " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," &
            _Caja_Id.ToString() & "," & _Cierre_Id.ToString() & "," & _Abono_Id.ToString() & "," & -(_Monto).ToString()

            Cn.Ejecutar(Query)


            Query = " Insert into CxCAbonoEncabezado( Emp_Id , Suc_Id" &
                   " , Caja_Id , Tipo_Id" &
                   " , Abono_Id , Referencia, Cierre_Id" &
                   " , Cliente_Id , Fecha" &
                   " , Monto , Vendedor_Id" &
                   " , Usuario_Id , Anulado" &
                   " , AnuladoFecha )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Caja_Id.ToString() & "," & _Tipo_Id.ToString() &
                   "," & _Abono_Id.ToString() & ",'" & _Referencia.Trim() & "'," & _Cierre_Id.ToString() &
                   "," & _Cliente_Id.ToString() & ",getdate()" &
                   "," & -(_Monto.ToString()) & "," & _Vendedor_Id.ToString() &
                   ",'" & _Usuario_Id & "'" & ",0,'19000101')"

            Cn.Ejecutar(Query)


            Cn.CommitTransaction()

            If EmpresaParametroInfo.InterfazCxC Then
                'Interfaz entre Punto de Venta y Cuentas x Cobrar Software Design Business
                Try
                    Dim CxC_Cliente = New TCxC_Cliente

                    _Cliente = New TCliente(_Emp_Id)
                    _Cliente.Cliente_Id = _Cliente_Id
                    VerificaMensaje(Cliente.ListKey)

                    'Verifica que el codigo del cliente sea del formato esperado
                    If Not IsNumeric(_Cliente.ClienteExterno) Then
                        VerificaMensaje(GuardaErrorAbonoCxC(_Emp_Id, _Suc_Id, _Caja_Id, _Cierre_Id, _Abono_Id, "El código asociado al cliente en CxC debe de ser númerico"))
                    End If


                    Mensaje = _SDL.VerificaCliente(EmpresaParametroInfo.EmpresaExterna, _Cliente.ClienteExterno)

                    ' Valida que el cliente exista en el módulo de CxC
                    If Mensaje <> "" Then
                        VerificaMensaje(GuardaErrorAbonoCxC(_Emp_Id, _Suc_Id, _Caja_Id, _Cierre_Id, _Abono_Id, Mensaje))
                    End If

                    With CxC_Cliente
                        .Emp_Id = EmpresaParametroInfo.EmpresaExterna
                        .Cliente_Id = _Cliente.ClienteExterno
                    End With
                    VerificaMensaje(CxC_Cliente.ListKey)

                    ' agrega la referencia 
                    _DTMovimiento.Tipo_Id = Enum_CxCMovimientoTipo.NotaCredito
                    _DTMovimiento.Referencia = "Anulación de pago desde el punto de venta"


                    With _DTMovimiento
                        .Emp_Id = EmpresaParametroInfo.EmpresaExterna
                        .Cliente_Id = _Cliente.ClienteExterno
                        .Referencia += " Nota de debito, Caja #" & _Caja_Id & ", Abono #" & _Abono_Id
                        .FechaRecibido = EmpresaInfo.Getdate()
                        .FechaDocumento = _Fecha
                        .FechaVencimiento = DateAdd(DateInterval.Day, CxC_Cliente.DiasCredito, _Fecha)
                        .Moneda = coMonedaColones
                        .Monto = Math.Abs(_Monto)
                        .Saldo = 0.00
                        .TipoCambio = TipoCambioCierreCaja(CajaInfo.Suc_Id, CajaInfo.Caja_Id, CajaInfo.Cierre_Id)
                        .Usuario_Id = coUsuarioGeneral
                        .AplicaMora = CxC_Cliente.AplicaMora
                        .Caja_Id = _Caja_Id
                        .Cierre_Id = CajaInfo.Cierre_Id
                        .Tipo_Id = Enum_CxCMovimientoTipo.NotaDebito
                    End With

                    _Resultado = _SDL.CxCMovimientoMant(_DTMovimiento, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

                    If _Resultado.ErrorDescription <> "" Then
                        VerificaMensaje(GuardaErrorAbonoCxC(_Emp_Id, _Suc_Id, _Caja_Id, _Cierre_Id, _Abono_Id, _Resultado.ErrorDescription))
                    End If

                    VerificaMensaje(CxC_Cliente.ListKey())

                    SaldoCxC = CxC_Cliente.Saldo

                Catch ex As Exception
                    VerificaMensaje(GuardaErrorAbonoCxC(_Emp_Id, _Suc_Id, _Caja_Id, _Cierre_Id, _Abono_Id, ex.Message))
                End Try
            End If
            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function



#End Region
End Class
