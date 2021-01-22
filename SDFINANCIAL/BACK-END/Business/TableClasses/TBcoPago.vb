Public Class TBcoPago
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _BcoPago_Id As Long
    Private _TipoPago_Id As Integer
    Private _Prov_Id As Integer
    Private _Banco_Id As Integer
    Private _Cuenta As String
    Private _Moneda As Char
    Private _Fecha As Datetime
    Private _Monto As Double
    Private _TipoCambio As Double
    Private _Dolares As Double
    Private _Usuario_Id As String
    Private _Concepto As String
    Private _Cheque As TBcoPagoCheque
    Private _Transferencia As TBcoPagoTransferencia
    Private _ListaSolicitudes As New List(Of TCxPSolicitudPago)
    Private _Consecutivos As DataTable
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
    Public Property BcoPago_Id() As Long
        Get
            Return _BcoPago_Id
        End Get
        Set(ByVal Value As Long)
            _BcoPago_Id = Value
        End Set
    End Property
    Public Property TipoPago_Id() As Integer
        Get
            Return _TipoPago_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoPago_Id = Value
        End Set
    End Property
    Public Property Prov_Id() As Integer
        Get
            Return _Prov_Id
        End Get
        Set(ByVal Value As Integer)
            _Prov_Id = Value
        End Set
    End Property
    Public Property Banco_Id() As Integer
        Get
            Return _Banco_Id
        End Get
        Set(ByVal Value As Integer)
            _Banco_Id = Value
        End Set
    End Property
    Public Property Cuenta() As String
        Get
            Return _Cuenta
        End Get
        Set(ByVal Value As String)
            _Cuenta = Value
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
    Public Property Concepto() As String
        Get
            Return _Concepto
        End Get
        Set(ByVal Value As String)
            _Concepto = Value
        End Set
    End Property
    Public Property Cheque As TBcoPagoCheque
        Get
            Return _Cheque
        End Get
        Set(value As TBcoPagoCheque)
            _Cheque = value
        End Set
    End Property
    Public Property Transferencia As TBcoPagoTransferencia
        Get
            Return _Transferencia
        End Get
        Set(value As TBcoPagoTransferencia)
            _Transferencia = value
        End Set
    End Property
    Public Property ListaSolicitudes As List(Of TCxPSolicitudPago)
        Get
            Return _ListaSolicitudes
        End Get
        Set(value As List(Of TCxPSolicitudPago))
            _ListaSolicitudes = value
        End Set
    End Property
    Public ReadOnly Property Consecutivos As DataTable
        Get
            Return _Consecutivos
        End Get
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
        _BcoPago_Id = 0
        _TipoPago_Id = 0
        _Prov_Id = 0
        _Banco_Id = 0
        _Cuenta = ""
        _Moneda = ""
        _Fecha = CDate("1900/01/01")
        _Monto = 0.0
        _TipoCambio = 0.0
        _Dolares = 0.0
        _Usuario_Id = ""
        _Concepto = ""
        _ListaSolicitudes.Clear()
        _Cheque = New TBcoPagoCheque(0)
        _Transferencia = New TBcoPagoTransferencia(0)
        _Consecutivos = New DataTable("Movimientos")
        _Consecutivos.Columns.Add("Tipo_Id", Type.GetType("System.String"))
        _Consecutivos.Columns.Add("Mov_Id", Type.GetType("System.String"))
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Dim Tabla As New DataTable
        Dim Batch_Id As Long = 0
        Dim Mov_Id As Long = 0
        Dim Diferencial As Double = 0.0
        Dim TipoPago As Integer = Enum_CxPMovimientoTipo.Pago
        Dim TipoDiferencial As Integer = 0

        Try
            Cn.Open()

            Cn.BeginTransaction()

            'Obtiene el siguiente número de batch
            VerificaMensaje(GetSiguienteBatch(Batch_Id))

            'Guarda el encabezado del movimiento y este retorna el numero de movimiento
            Query = "exec CxP_CreaMovimiento " & _Emp_Id.ToString & "," & TipoPago.ToString & _
                    "," & _Prov_Id.ToString & "," & Enum_CxPMovimientoEstado.Procesado & _
                    "," & "'PAGO DE SOLICITUDES'" & ",'" & Format(_Fecha, "yyyyMMdd hh:mm:ss") & "'" & _
                    ",'" & Format(_Fecha, "yyyyMMdd hh:mm:ss") & "','" & Format(_Fecha, "yyyyMMdd hh:mm:ss") & "'" & _
                    ",'" & _Moneda & "'," & _Monto.ToString & "," & _TipoCambio.ToString & ",'" & _Usuario_Id & "'" & _
                    "," & Batch_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            'Asigna el numero de movimiento retornado anteriormente
            If Not Tabla Is Nothing OrElse Tabla.Rows.Count > 0 Then
                Mov_Id = Tabla.Rows(0).Item("Mov_Id")

                _Consecutivos.Rows.Add(New Object() {TipoPago, Mov_Id})
            Else
                VerificaMensaje("Ocurrió un error al obtener el consecutivo del movimiento")
            End If

            'Registra el pago de la solicitud(s)
            Query = "exec Bco_CreaPago " & _Emp_Id.ToString & "," & _TipoPago_Id.ToString & "," & _Prov_Id.ToString & _
                    "," & _Banco_Id.ToString & ",'" & _Moneda & "','" & _Cuenta & "'," & _Monto.ToString & _
                    "," & _TipoCambio.ToString & "," & _Dolares.ToString & ",'" & _Usuario_Id & "','" & _Concepto & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            'Asigna el numero de pago retornado anteriormente
            If Not Tabla Is Nothing OrElse Tabla.Rows.Count > 0 Then
                _BcoPago_Id = Tabla.Rows(0).Item("BcoPago_Id")
            Else
                VerificaMensaje("Ocurrió un error al obtener el consecutivo del pago")
            End If

            'Guarda la información adicional del cheque o la transferencia segun sea el caso
            Select Case _TipoPago_Id
                Case Enum_BcoTipoPago.Cheque
                    'Guarda el cheque y además actualiza el consecutivo del cheque
                    Query = "exec Bco_CreaPagoCheque " & _Emp_Id.ToString & "," & _BcoPago_Id.ToString & _
                            ",'" & _Cheque.Nombre & "','" & Format(_Cheque.Fecha, "yyyyMMdd") & "'" & _
                            "," & _Banco_Id.ToString

                    Cn.Ejecutar(Query)
                Case Enum_BcoTipoPago.Transferencia
                    'Guarda la transferencia
                    Query = "exec Bco_CreaPagoTransferencia " & _Emp_Id.ToString & "," & _BcoPago_Id.ToString & _
                            "," & _Transferencia.Banco_Id.ToString & ",'" & _Transferencia.Cuenta & "'" & _
                            ",'" & _Transferencia.Moneda & "','" & Format(_Transferencia.Fecha, "yyyyMMdd") & "'" & _
                            "," & _Transferencia.TipoCambio.ToString & ",'" & _Transferencia.Numero & "'"

                    Cn.Ejecutar(Query)
            End Select

            'Crea la relación entre el Movimiento creado y el pago
            Query = "exec Bco_CreaPagoDetalle " & _Emp_Id.ToString & "," & _BcoPago_Id.ToString & _
                    "," & TipoPago.ToString & "," & Mov_Id.ToString & ",'" & _Moneda.ToString & "'" & _
                    "," & _Monto.ToString & "," & _TipoCambio.ToString & "," & _Dolares.ToString

            Cn.Ejecutar(Query)

            'Recorre la lista de solicitudes que se van a pagar
            For Each Solicitud As TCxPSolicitudPago In _ListaSolicitudes
                'Crea una relación entre el movimiento principal y los que esta pagando
                Query = "exec CxP_CreaMovimientoAplica " & _Emp_Id.ToString & "," & TipoPago.ToString & _
                        "," & Mov_Id.ToString & "," & Solicitud.Tipo_Id.ToString & "," & Solicitud.Mov_Id.ToString & _
                        "," & Solicitud.PagoMonto.ToString

                Cn.Ejecutar(Query)

                'Borra la solicitud de pago y guarda una bitacora del proceso
                Query = "exec CxP_CreaSolicitudPagoBitacora " & _Emp_Id.ToString & "," & Solicitud.Tipo_Id.ToString & _
                        "," & Solicitud.Mov_Id.ToString & ",'" & _Usuario_Id & "'," & Enum_CxPBitacoraTipo.Pago & _
                        "," & Solicitud.PagoMonto.ToString & "," & Solicitud.PagoDolares.ToString

                Cn.Ejecutar(Query)

                Diferencial += Solicitud.Diferencial
            Next

            'Verifica si en el pago existe diferencial cambiario
            If Diferencial > 0 Then
                TipoDiferencial = Enum_CxPMovimientoTipo.NotaDebito
            ElseIf Diferencial < 0 Then
                TipoDiferencial = Enum_CxPMovimientoTipo.NotaCredito
            End If

            If TipoDiferencial <> 0 Then
                'Crea un movimiento para normalizar el saldo del proveedor debido al diferencial cambiario
                Query = "exec CxP_CreaMovimiento " & _Emp_Id.ToString & "," & TipoDiferencial & _
                        "," & _Prov_Id.ToString & "," & Enum_CxPMovimientoEstado.Procesado & _
                        "," & "'AJUSTE POR DIFERENCIAL CAMBIARIO'" & ",'" & Format(_Fecha, "yyyyMMdd hh:mm:ss") & "'" & _
                        ",'" & Format(_Fecha, "yyyyMMdd hh:mm:ss") & "','" & Format(_Fecha, "yyyyMMdd hh:mm:ss") & "'" & _
                        ",'" & coMonedaColones & "'," & Diferencial.ToString & ",1,'" & _Usuario_Id & "'" & _
                        "," & Batch_Id.ToString

                Tabla = Cn.Seleccionar(Query)

                'Asigna el numero de movimiento retornado anteriormente
                If Not Tabla Is Nothing OrElse Tabla.Rows.Count > 0 Then
                    _Consecutivos.Rows.Add(New Object() {TipoDiferencial, Tabla.Rows(0).Item("Mov_Id")})
                Else
                    VerificaMensaje("Ocurrió un error al obtener el consecutivo del movimiento")
                End If

                'Recorre la lista de solicitudes que se pagaron
                For Each Solicitud As TCxPSolicitudPago In _ListaSolicitudes
                    If Solicitud.Diferencial <> 0 Then
                        'Crea una relación entre el movimiento principal y el ajuste por diferencial cambiario
                        Query = "exec CxP_CreaMovimientoAplica " & _Emp_Id.ToString & "," & TipoDiferencial.ToString & _
                                "," & Tabla.Rows(0).Item("Mov_Id").ToString & "," & Solicitud.Tipo_Id.ToString & _
                                "," & Solicitud.Mov_Id.ToString & "," & Math.Abs(Solicitud.Diferencial).ToString

                        Cn.Ejecutar(Query)
                    End If
                Next
            End If

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

            Query = "Delete BcoPago" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   BcoPago_Id = " & _BcoPago_Id.ToString

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return String.Empty
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

            Query = " Update BcoPago " & _
                    " SET    TipoPago_Id = " & _TipoPago_Id.ToString & "," & _
                    " Prov_Id = " & _Prov_Id & "," & _
                    " Banco_Id = " & _Banco_Id & "," & _
                    " Cuenta = '" & _Cuenta & "'" & "," & _
                    " Moneda = '" & _Moneda & "'" & "," & _
                    " Fecha = '" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                    " Monto = " & _Monto & "," & _
                    " TipoCambio = " & _TipoCambio & "," & _
                    " Dolares = " & _Dolares & "," & _
                    " Usuario_Id = '" & _Usuario_Id & "'" & "," & _
                    " Concepto = '" & _Concepto & "'" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   BcoPago_Id = " & _BcoPago_Id.ToString

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return String.Empty
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

            Query = "select * From BcoPago" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   BcoPago_Id = " & _BcoPago_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return String.Empty
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

            Query = "select * From BcoPago"

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return String.Empty
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

            Query = "select BcoPago_Id as Numero, Nombre From BcoPago" & _
                    " where Emp_Id = " & _Emp_Id.ToString & _
                    " and   Activo = 1"

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return String.Empty
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

            Query = "select BcoPago_Id as Codigo, Nombre From BcoPago" & _
                    " where Emp_Id = " & _Emp_Id.ToString

            If pNombre.Trim <> "" Then
                Query += " and Nombre Like '%" & pNombre & "%'"
            End If

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return String.Empty
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

            Query = "select ISNULL(MAX(BcoPago_Id),0) + 1 as BcoPago_Id From BcoPago" & _
                    " Where Emp_Id = " & _Emp_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Private Function GetSiguienteBatch(ByRef pBatch_Id As Long) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Query = "SELECT NEXT VALUE FOR BatchNumber as Batch_Id"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                pBatch_Id = Tabla.Rows(0).Item("Batch_Id")
            Else
                VerificaMensaje("Ocurrió un error buscando el número de batch")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
End Class