Public Class TCajaCierreEncabezado
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _Usuario_Id As String
    Private _Efectivo As Double
    Private _Tarjeta As Double
    Private _Cheque As Double
    Private _Total As Double
    Private _MontoSuma As Double
    Private _MontoResta As Double
    Private _Fondo As Double
    Private _Cerrado As Integer
    Private _FechaApertura As Datetime
    Private _FechaCierre As Datetime
    Private _CajeroEfectivo As Double
    Private _CajeroTarjeta As Double
    Private _CajeroCheque As Double
    Private _CajeroDocumentos As Double
    Private _CajeroTotal As Double
    Private _UltimaModificacion As DateTime
    Private _UsuarioNombre As String
    Private _RecargaTelefonica As Double

    Private _Exento As Double
    Private _Gravado As Double

    Private _Puntos As Double
    Private _CajeroDolares As Double
    Private _TipoCambio As Double
    Private _Dolares As Double

    Private _CajaCierreDetalles As New List(Of TCajaCierreDetalle)
    Private _Data As DataSet

    Private _Salidas As Double

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
    Public Property Usuario_Id() As String
        Get
            Return _Usuario_Id
        End Get
        Set(ByVal Value As String)
            _Usuario_Id = Value
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
    Public Property Tarjeta() As Double
        Get
            Return _Tarjeta
        End Get
        Set(ByVal Value As Double)
            _Tarjeta = Value
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
    Public Property Puntos As Double
        Get
            Return _Puntos
        End Get
        Set(value As Double)
            _Puntos = value
        End Set
    End Property
    Public Property CajeroDolares As Double
        Get
            Return _CajeroDolares
        End Get
        Set(value As Double)
            _CajeroDolares = value
        End Set
    End Property

    Public Property TipoCambio As Double
        Get
            Return _TipoCambio
        End Get
        Set(value As Double)
            _TipoCambio = value
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
    Public Property MontoSuma() As Double
        Get
            Return _MontoSuma
        End Get
        Set(ByVal Value As Double)
            _MontoSuma = Value
        End Set
    End Property
    Public Property MontoResta() As Double
        Get
            Return _MontoResta
        End Get
        Set(ByVal Value As Double)
            _MontoResta = Value
        End Set
    End Property
    Public Property Fondo() As Double
        Get
            Return _Fondo
        End Get
        Set(ByVal Value As Double)
            _Fondo = Value
        End Set
    End Property
    Public Property Cerrado() As Integer
        Get
            Return _Cerrado
        End Get
        Set(ByVal Value As Integer)
            _Cerrado = Value
        End Set
    End Property
    Public Property FechaApertura() As Datetime
        Get
            Return _FechaApertura
        End Get
        Set(ByVal Value As Datetime)
            _FechaApertura = Value
        End Set
    End Property
    Public Property FechaCierre() As Datetime
        Get
            Return _FechaCierre
        End Get
        Set(ByVal Value As Datetime)
            _FechaCierre = Value
        End Set
    End Property
    Public Property CajeroEfectivo() As Double
        Get
            Return _CajeroEfectivo
        End Get
        Set(ByVal Value As Double)
            _CajeroEfectivo = Value
        End Set
    End Property
    Public Property CajeroTarjeta() As Double
        Get
            Return _CajeroTarjeta
        End Get
        Set(ByVal Value As Double)
            _CajeroTarjeta = Value
        End Set
    End Property
    Public Property CajeroCheque() As Double
        Get
            Return _CajeroCheque
        End Get
        Set(ByVal Value As Double)
            _CajeroCheque = Value
        End Set
    End Property
    Public Property CajeroDocumentos() As Double
        Get
            Return _CajeroDocumentos
        End Get
        Set(ByVal Value As Double)
            _CajeroDocumentos = Value
        End Set
    End Property
    Public Property CajeroTotal() As Double
        Get
            Return _CajeroTotal
        End Get
        Set(ByVal Value As Double)
            _CajeroTotal = Value
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
    Public Property UsuarioNombre As String
        Get
            Return _UsuarioNombre
        End Get
        Set(value As String)
            _UsuarioNombre = value
        End Set
    End Property
    Public Property RecargaTelefonica As Double
        Get
            Return _RecargaTelefonica
        End Get
        Set(value As Double)
            _RecargaTelefonica = value
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
    Public Property Dolares As Double
        Get
            Return _Dolares
        End Get
        Set(value As Double)
            _Dolares = value
        End Set
    End Property
    Public Property CajaCierreDetalles As List(Of TCajaCierreDetalle)
        Get
            Return _CajaCierreDetalles
        End Get
        Set(value As List(Of TCajaCierreDetalle))
            _CajaCierreDetalles = value
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
    Public Property Salidas() As Double
        Get
            Return _Salidas
        End Get
        Set(ByVal Value As Double)
            _Salidas = Value
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
        _Emp_Id = 0
        _Suc_Id = 0
        _Caja_Id = 0
        _Cierre_Id = 0
        _Usuario_Id = ""
        _Efectivo = 0.0
        _Tarjeta = 0.0
        _Cheque = 0.0
        _Total = 0.0
        _MontoSuma = 0.0
        _MontoResta = 0.0
        _Fondo = 0.0
        _Cerrado = 0
        _FechaApertura = CDate("1900/01/01")
        _FechaCierre = CDate("1900/01/01")
        _CajeroEfectivo = 0.0
        _CajeroTarjeta = 0.0
        _CajeroCheque = 0.0
        _CajeroDocumentos = 0.0
        _CajeroTotal = 0.0
        _UltimaModificacion = CDate("1900/01/01")
        _UsuarioNombre = ""
        _RecargaTelefonica = 0.0
        _Exento = 0.0
        _Gravado = 0.0
        _CajeroDolares = 0.0
        _TipoCambio = 0.00
        _Dolares = 0.00
        _Data = New DataSet
        _Salidas = 0.0
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into CajaCierreEncabezado( Emp_Id , Suc_Id" &
                   " , Caja_Id , Cierre_Id" &
                   " , Usuario_Id , Efectivo" &
                   " , Tarjeta , Cheque" &
                   " , Total , MontoSuma" &
                   " , MontoResta , Fondo" &
                   " , Cerrado , FechaApertura" &
                   " , FechaCierre , CajeroEfectivo" &
                   " , CajeroTarjeta , CajeroCheque" &
                   " , CajeroDocumentos , CajeroTotal" &
                   " , UltimaModificacion , RecargaTelefonica" &
                   " , Exento , Gravado, Puntos, Salidas" &
                   " )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString() &
                   ",'" & _Usuario_Id & "'" & "," & _Efectivo.ToString() &
                   "," & _Tarjeta.ToString() & "," & _Cheque.ToString() &
                   "," & _Total.ToString() & "," & _MontoSuma.ToString() &
                   "," & _MontoResta.ToString() & "," & _Fondo.ToString() &
                   "," & _Cerrado.ToString() & ",'" & Format(_FechaApertura, "yyyyMMdd HH:mm:ss") & "'" &
                   ",'" & Format(_FechaCierre, "yyyyMMdd HH:mm:ss") & "'" & "," & _CajeroEfectivo.ToString() &
                   "," & _CajeroTarjeta.ToString() & "," & _CajeroCheque.ToString() &
                   "," & _CajeroDocumentos.ToString() & "," & _CajeroTotal.ToString() &
                   ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & "," & _RecargaTelefonica.ToString() &
                   "," & _Exento.ToString() & "," & _Gravado.ToString() & "," & _Puntos.ToString & "," & _Salidas.ToString & ")"

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

            Query = "Delete CajaCierreEncabezado" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And    Suc_Id=" & _Suc_Id.ToString() & _
               " And    Caja_Id=" & _Caja_Id.ToString() & _
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

            Query = " Update dbo.CajaCierreEncabezado " &
                      " SET   Usuario_Id='" & _Usuario_Id & "' " & "," &
                      " Efectivo=" & _Efectivo & "," &
                      " Puntos=" & _Puntos & "," &
                      " Tarjeta=" & _Tarjeta & "," &
                      " Cheque=" & _Cheque & "," &
                      " Total=" & _Total & "," &
                      " MontoSuma=" & _MontoSuma & "," &
                      " MontoResta=" & _MontoResta & "," &
                      " Fondo=" & _Fondo & "," &
                      " Cerrado=" & _Cerrado & "," &
                      " FechaApertura='" & Format(_FechaApertura, "yyyyMMdd HH:mm:ss") & "'" & "," &
                      " FechaCierre='" & Format(_FechaCierre, "yyyyMMdd HH:mm:ss") & "'" & "," &
                      " CajeroEfectivo=" & _CajeroEfectivo & "," &
                      " CajeroTarjeta=" & _CajeroTarjeta & "," &
                      " CajeroCheque=" & _CajeroCheque & "," &
                      " CajeroDocumentos=" & _CajeroDocumentos & "," &
                      " CajeroTotal=" & _CajeroTotal & "," &
                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & "," &
                      " RecargaTelefonica=" & _RecargaTelefonica & "," &
                      " Exento=" & _Exento & "," &
                      " Gravado=" & _Gravado & "," &
                      " Salidas=" & _Salidas &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Suc_Id=" & _Suc_Id.ToString() &
                      " And    Caja_Id=" & _Caja_Id.ToString() &
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
        Dim Tabla As DataTable = Nothing
        Dim TablaDetalle As DataTable = Nothing
        Dim CajaCierreDetalle As TCajaCierreDetalle = Nothing

        Try
            Cn.Open()

            Query = "select a.*,b.Nombre as UsuarioNombre From CajaCierreEncabezado a, Usuario b" & _
           " Where  a.Emp_Id = b.Emp_Id and a.Usuario_Id = b.Usuario_Id" & _
           " And    a.Emp_Id = " & _Emp_Id.ToString() & _
           " And    a.Suc_Id=" & _Suc_Id.ToString() & _
           " And    a.Caja_Id=" & _Caja_Id.ToString() & _
           " And    a.Cierre_Id=" & _Cierre_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                _Cierre_Id = Tabla.Rows(0).Item("Cierre_Id")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _Efectivo = Tabla.Rows(0).Item("Efectivo")
                _Tarjeta = Tabla.Rows(0).Item("Tarjeta")
                _Cheque = Tabla.Rows(0).Item("Cheque")
                _Total = Tabla.Rows(0).Item("Total")
                _MontoSuma = Tabla.Rows(0).Item("MontoSuma")
                _MontoResta = Tabla.Rows(0).Item("MontoResta")
                _Fondo = Tabla.Rows(0).Item("Fondo")
                _Cerrado = Tabla.Rows(0).Item("Cerrado")
                _FechaApertura = Tabla.Rows(0).Item("FechaApertura")
                _FechaCierre = Tabla.Rows(0).Item("FechaCierre")
                _CajeroEfectivo = Tabla.Rows(0).Item("CajeroEfectivo")
                _CajeroTarjeta = Tabla.Rows(0).Item("CajeroTarjeta")
                _CajeroCheque = Tabla.Rows(0).Item("CajeroCheque")
                _CajeroDocumentos = Tabla.Rows(0).Item("CajeroDocumentos")
                _CajeroTotal = Tabla.Rows(0).Item("CajeroTotal")
                _UltimaModificacion = Tabla.Rows(0).Item("UltimaModificacion")
                _UsuarioNombre = Tabla.Rows(0).Item("UsuarioNombre")
                _RecargaTelefonica = Tabla.Rows(0).Item("RecargaTelefonica")
                _Exento = Tabla.Rows(0).Item("Exento")
                _Gravado = Tabla.Rows(0).Item("Gravado")
                _Puntos = Tabla.Rows(0).Item("Puntos")
                _CajeroDolares = Tabla.Rows(0).Item("CajeroDolares")
                _TipoCambio = Tabla.Rows(0).Item("TipoCambio")
                _Dolares = Tabla.Rows(0).Item("Dolares")
                _Salidas = Tabla.Rows(0).Item("Salidas")
            End If

            Query = "exec RepCierreDetalle " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString()

            TablaDetalle = Cn.Seleccionar(Query).Copy

            If Not TablaDetalle Is Nothing Then
                For Each Fila As DataRow In TablaDetalle.Rows
                    CajaCierreDetalle = New TCajaCierreDetalle(Fila("Emp_Id"))
                    With CajaCierreDetalle
                        .Emp_Id = Fila("Emp_Id")
                        .Suc_Id = Fila("Suc_Id")
                        .Caja_Id = Fila("Caja_Id")
                        .Cierre_Id = Fila("Cierre_Id")
                        .Detalle_Id = Fila("Detalle_Id")
                        .TipoDoc_Id = Fila("TipoDoc_Id")
                        .Documento_Id = Fila("Documento_Id")
                        .Pago_Id = Fila("Pago_Id")
                        .TipoPago_Id = Fila("TipoPago_Id")
                        .Monto = Fila("Monto")
                        .Banco_Id = IIf(IsDBNull(Fila("Banco_Id")), 0, Fila("Banco_Id"))
                        .ChequeNumero = Fila("ChequeNumero")
                        .Tarjeta_Id = IIf(IsDBNull(Fila("Tarjeta_Id")), 0, Fila("Tarjeta_Id"))
                        .TarjetaNumero = Fila("TarjetaNumero")
                        .TarjetaAutorizacion = Fila("TarjetaAutorizacion")
                        .NombreTipoDocumento = Fila("NombreTipoDocumento")
                        .NombreTipoPago = Fila("NombreTipoPago")
                        .NombreBanco = Fila("NombreBanco")
                    End With
                    _CajaCierreDetalles.Add(CajaCierreDetalle)
                Next
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

            Query = "select * From CajaCierreEncabezado"

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

            Query = "select top 90 Cierre_Id as Numero, cast(Cierre_Id as varchar(10)) + ' - ' + convert(varchar(10),FechaCierre,103) as FechaCierre From CajaCierreEncabezado " &
                "where Emp_Id = " & _Emp_Id.ToString & " and Suc_Id = " & _Suc_Id.ToString & " and Caja_Id = " & _Caja_Id.ToString & " and Cerrado = 1 order by Cierre_Id desc"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing Then
                pCombo.DataSource = Nothing
                pCombo.DataSource = Tabla
                pCombo.DisplayMember = "FechaCierre"
                pCombo.ValueMember = "Numero"
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function RepCierreCaja() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "exec RepCierreCaja " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy
            Tabla.TableName = "Cierre"

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            'Query = "exec RepCierreCajaAdelanto " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString()

            'Tabla = Cn.Seleccionar(Query).Copy
            'Tabla.TableName = "CierreAdelanto"

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
    Public Function CargaComboBox(pCombo As System.Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select top 90 Cierre_Id as Numero, cast(Cierre_Id as varchar(10)) + ' - ' + convert(varchar(10),FechaCierre,103) as FechaCierre From CajaCierreEncabezado " &
                "where Emp_Id = " & _Emp_Id.ToString & " and Suc_Id = " & _Suc_Id.ToString & " and Caja_Id = " & _Caja_Id.ToString & " order by Cierre_Id desc"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing Then
                pCombo.DataSource = Nothing
                pCombo.DataSource = Tabla
                pCombo.DisplayMember = "FechaCierre"
                pCombo.ValueMember = "Numero"
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function CargaCierreAbierto(pCombo As System.Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select top 90 Cierre_Id as Numero, cast(Cierre_Id as varchar(10)) + ' - ' + convert(varchar(10),FechaCierre,103) as FechaCierre From CajaCierreEncabezado " &
                "where Emp_Id = " & _Emp_Id.ToString & " and Suc_Id = " & _Suc_Id.ToString & " and Caja_Id = " & _Caja_Id.ToString & " and Cerrado = 0 order by Cierre_Id desc"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing Then
                pCombo.DataSource = Nothing
                pCombo.DataSource = Tabla
                pCombo.DisplayMember = "FechaCierre"
                pCombo.ValueMember = "Numero"
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function CargaCierre(pCombo As System.Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select top 90 Cierre_Id as Numero, cast(Cierre_Id as varchar(10)) + ' - ' + convert(varchar(10),FechaCierre,103) as FechaCierre From CajaCierreEncabezado " &
                "where Emp_Id = " & _Emp_Id.ToString & " and Suc_Id = " & _Suc_Id.ToString & " and Caja_Id = " & _Caja_Id.ToString & " order by Cierre_Id desc"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing Then
                pCombo.DataSource = Nothing
                pCombo.DataSource = Tabla
                pCombo.DisplayMember = "FechaCierre"
                pCombo.ValueMember = "Numero"
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function CargaCierreCerrado(pCombo As System.Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select top 90 Cierre_Id as Numero, cast(Cierre_Id as varchar(10)) + ' - ' + convert(varchar(10),FechaCierre,103) as FechaCierre From CajaCierreEncabezado " &
                "where Emp_Id = " & _Emp_Id.ToString & " and Suc_Id = " & _Suc_Id.ToString & " and Caja_Id = " & _Caja_Id.ToString & " and Cerrado = 1 order by Cierre_Id desc"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing Then
                pCombo.DataSource = Nothing
                pCombo.DataSource = Tabla
                pCombo.DisplayMember = "FechaCierre"
                pCombo.ValueMember = "Numero"
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function RptArqueoCaja() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptArqueoCaja " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString()

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


    Public Function RptMovimientosPorCajaUsuario(pDesde As DateTime, pHasta As DateTime) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptMovimientosPorCajaUsuario " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Caja_Id.ToString() & ",'" & _Usuario_Id.ToString() & "','" & pDesde.ToString("yyyyMMdd") & "','" & pHasta.ToString("yyyyMMdd") & "'"

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
    Public Function RptEntradasEfectivo() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptEntradaEfectivo " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString()

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
    Public Function RptCierreCajaDetallado() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            If EmpresaParametroInfo.FinancialDB.Trim() <> String.Empty Then
                Query = "exec RptCierreCajaDetallado " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString() & ",'[" & EmpresaParametroInfo.FinancialDB & "]'"
            Else
                Query = "exec RptCierreCajaDetallado " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString() & ",''"
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

    Public Function RpRptCierreCajaCarta() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RepCierreDetalle " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString()

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

    Public Function RptCierreCajaCSM(pReporte As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptCierreCajaCSM " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString() & "," & pReporte

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