
Public Class TFacturaElectronicaPendiente
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Caja_Id As Integer
    Private _TipoDoc_Id As Integer
    Private _Documento_Id As Long
    Private _Fecha As DateTime
    Private _Emisor_Id As Integer
    Private _Consecutivo As String
    Private _Clave As String
    Private _Batch_Id As Long
    Private _Data As DataSet
    Private _Monto As Double
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
    Public Property TipoDoc_Id() As Integer
        Get
            Return _TipoDoc_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoDoc_Id = Value
        End Set
    End Property
    Public Property Documento_Id() As Long
        Get
            Return _Documento_Id
        End Get
        Set(ByVal Value As Long)
            _Documento_Id = Value
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
    Public Property Emisor_Id() As Integer
        Get
            Return _Emisor_Id
        End Get
        Set(ByVal Value As Integer)
            _Emisor_Id = Value
        End Set
    End Property
    Public Property Consecutivo() As String
        Get
            Return _Consecutivo
        End Get
        Set(ByVal Value As String)
            _Consecutivo = Value
        End Set
    End Property
    Public Property Clave() As String
        Get
            Return _Clave
        End Get
        Set(ByVal Value As String)
            _Clave = Value
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
    Public Property Monto() As Integer
        Get
            Return _Monto
        End Get
        Set(ByVal Value As Integer)
            _Monto = Value
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
        _TipoDoc_Id = 0
        _Documento_Id = 0
        _Fecha = CDate("1900/01/01")
        _Emisor_Id = 0
        _Consecutivo = ""
        _Clave = ""
        _Batch_Id = 0
        _Data = New DataSet
        _Monto = 0
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into FacturaElectronicaPendiente( Emp_Id , Suc_Id" &
                   " , Caja_Id , TipoDoc_Id" &
                   " , Documento_Id , Fecha" &
                   " , Emisor_Id , Consecutivo" &
                   " , Clave , Batch_Id" &
                   " )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Caja_Id.ToString() & "," & _TipoDoc_Id.ToString() &
                   "," & _Documento_Id.ToString() & ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" &
                   "," & _Emisor_Id.ToString() & ",'" & _Consecutivo & "'" &
                   ",'" & _Clave & "'" & "," & _Batch_Id.ToString() & ")"

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

            Query = "Delete FacturaElectronicaPendiente" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And    Suc_Id=" & _Suc_Id.ToString() &
               " And    Caja_Id=" & _Caja_Id.ToString() &
               " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() &
               " And    Documento_Id=" & _Documento_Id.ToString()

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

            Query = " Update dbo.FacturaElectronicaPendiente " &
                      " SET    Fecha=" & _Fecha.ToString() & "," &
                      " Emisor_Id=" & _Emisor_Id & "," &
                      " Consecutivo='" & _Consecutivo & "'" & "," &
                      " Clave='" & _Clave & "'" & "," &
                      " Batch_Id=" & _Batch_Id &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Suc_Id=" & _Suc_Id.ToString() &
                      " And    Caja_Id=" & _Caja_Id.ToString() &
                      " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() &
                      " And    Documento_Id=" & _Documento_Id.ToString()

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

            Query = "select * From FacturaElectronicaPendiente" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    Caja_Id=" & _Caja_Id.ToString() &
           " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() &
           " And    Documento_Id=" & _Documento_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                _TipoDoc_Id = Tabla.Rows(0).Item("TipoDoc_Id")
                _Documento_Id = Tabla.Rows(0).Item("Documento_Id")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Emisor_Id = Tabla.Rows(0).Item("Emisor_Id")
                _Consecutivo = Tabla.Rows(0).Item("Consecutivo")
                _Clave = Tabla.Rows(0).Item("Clave")
                _Batch_Id = Tabla.Rows(0).Item("Batch_Id")
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

            Query = "select * From FacturaElectronicaPendiente"

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

            Query = "select FacturaElectronicaPendiente_Id as Numero, Nombre From FacturaElectronicaPendiente"

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

    Public Function CargaFacturaPendiente() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select f.*, e.TotalCobrado, c.Cliente_Id, c.Nombre as ClienteNombre From FacturaElectronicaPendiente f" &
            " inner join FacturaEncabezado e on f.Emp_Id = e.Emp_Id And f.Suc_Id = e.Suc_Id And f.Caja_Id = e.Caja_Id And f.TipoDoc_Id = e.TipoDoc_Id And f.Documento_Id = e.Documento_Id" &
            " inner join Cliente c on e.Emp_Id = c.Emp_Id and e.Cliente_Id = c.Cliente_Id" &
            " Where f.Emp_Id=" & _Emp_Id.ToString()



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

    Public Function EnviaFacturasPendientes() As String
        Dim Query As String
        Dim Tabla As DataTable
        Dim FE As New TFacturacionElectronica()
        Dim FacturaEncabezado As TFacturaEncabezado
        Dim Mensaje As String = String.Empty
        Dim Cantidad As Integer = 0
        Dim Total As Integer = 0
        Try

            Cn.Open()

            Query = "select * From FacturaElectronicaPendiente where Emp_Id = " & _Emp_Id.ToString() & " order by FechaRegistro asc"

            Tabla = Cn.Seleccionar(Query).Copy

            Total = Tabla.Rows.Count


            For Each fila As DataRow In Tabla.Rows
                Try


                    FacturaEncabezado = New TFacturaEncabezado(_Emp_Id)

                    With FacturaEncabezado
                        .Emp_Id = fila("Emp_Id")
                        .Suc_Id = fila("Suc_Id")
                        .Caja_Id = fila("Caja_Id")
                        .TipoDoc_Id = fila("TipoDoc_Id")
                        .Documento_Id = fila("Documento_Id")
                    End With

                    VerificaMensaje(FacturaEncabezado.ListKey)

                    Cantidad += 1

                    With FE
                        .Encabezado = FacturaEncabezado
                        .CoreURL = InfoMaquina.URLCoreAPI
                        .Emisor_Id = EmpresaParametroInfo.Emisor_Id
                        .Token = EmpresaParametroInfo.FeToken
                        .Moneda = IIf(FacturaEncabezado.Dolares, "USD", "CRC")
                        .Clave = fila("Clave")
                        .Consecutivo = fila("Consecutivo")
                        .Bacth_Id = fila("Batch_Id")
                        .Situacion = Enum_SituacionDocumentoElectronico.Normal
                        .Moneda = IIf(FacturaEncabezado.Dolares = 1, "USD", "CRC")
                        .TipoCambio = FacturaEncabezado.TipoCambio
                        .CantidadStr = "Procesando (" & Cantidad.ToString() & " de " & Total.ToString() & ")"
                    End With

                    Mensaje = FE.Facturar(Cn)
                    If Mensaje.Trim = String.Empty Then

                        Query = "delete FacturaElectronicaPendiente" &
                        " where Emp_Id = " & fila("Emp_Id") &
                        " And Suc_Id = " & fila("Suc_Id") &
                        " And Caja_Id = " & fila("Caja_Id") &
                        " And TipoDoc_Id = " & fila("TipoDoc_Id") &
                        " And Documento_Id = " & fila("Documento_Id")

                        Cn.Ejecutar(Query)
                    Else
                        If Mensaje.IndexOf(coFeErrorYaSeRecibio) > 0 Then
                            Query = "exec ProcesaDocumentoRecibido " & fila("Emp_Id") & "," & fila("Suc_Id") & "," & fila("Caja_Id") & "," & fila("TipoDoc_Id") & "," & fila("Documento_Id")
                        Else
                            Query = "update FacturaElectronicaPendiente set Mensaje = '" & Mensaje.Replace("'", " ") & "'" &
                            " where Emp_Id = " & fila("Emp_Id") &
                            " and Suc_Id = " & fila("Suc_Id") &
                            " and Caja_Id = " & fila("Caja_Id") &
                            " and TipoDoc_Id = " & fila("TipoDoc_Id") &
                            " and Documento_Id = " & fila("Documento_Id")
                        End If

                        Cn.Ejecutar(Query)

                    End If



                Catch ex As Exception
                    MensajeError(ex.Message)
                End Try
            Next

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
            FE = Nothing
            FacturaEncabezado = Nothing
        End Try
    End Function


#End Region
End Class
