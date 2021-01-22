Public Class TCompraFacturar
    Inherits TBaseClassManager
#Region "Definition of Properties"
    Public Property Emisor_Id As Integer
    Public Property Compra_Id As Long
    Public Property Prov_Id As Integer
    Public Property TipoDoc As String
    Public Property FechaEmision As Date
    Public Property Clave As String
    Public Property Consecutivo As String
    Public Property Xml As String
    Public Property Moneda As String
    Public Property TipoCambio As Double
    Public Property Subtotal As Double
    Public Property Descuento As Double
    Public Property Impuesto As Double
    Public Property TotalCobrado As Double
    Public Property Estado_Id As Integer
    Public Property FechaRegistro As Date
    Public Property EstadoMensaje As Integer
    Public Property MensajeAcuse As String
    Public Property Data As DataSet
    Public ReadOnly Property RowsAffected() As Long
        Get
            Return Cn.RowsAffected
        End Get
    End Property
#End Region
#Region "Definition of Constructors"
    Public Sub New(pEmisor_Id As Integer)
        MyBase.New()
        Inicializa()
        Emisor_Id = pEmisor_Id
    End Sub
    Public Sub New(pEmisor_Id As Integer, pCnStr As String)
        MyBase.New(pCnStr)
        Inicializa()
        Emisor_Id = pEmisor_Id
    End Sub
#End Region
#Region "Definition of Private Methods"
    Private Sub Inicializa()
        Emisor_Id = 0
        Compra_Id = 0
        Prov_Id = 0
        TipoDoc = ""
        FechaEmision = #1900/01/01#
        Clave = ""
        Consecutivo = ""
        Xml = ""
        Moneda = ""
        TipoCambio = 0.00
        Subtotal = 0.00
        Descuento = 0.00
        Impuesto = 0.00
        TotalCobrado = 0.00
        Estado_Id = 0
        FechaRegistro = #1900/01/01#
        EstadoMensaje = 0
        MensajeAcuse = ""
        Data = New DataSet
    End Sub
#End Region
#Region "Definition of Public Methods"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()
            Cn.BeginTransaction()

            Query = " insert into CompraFacturar ( Emisor_Id , Compra_Id" &
                    " , Prov_Id , TipoDoc" &
                    " , FechaEmision , Clave" &
                    " , Consecutivo , Xml" &
                    " , Moneda , TipoCambio" &
                    " , Subtotal , Descuento" &
                    " , Impuesto , TotalCobrado" &
                    " , Estado_Id , FechaRegistro" &
                    " , EstadoMensaje , MensajeAcuse" & ")" &
                    " values ( " & Emisor_Id.ToString & "," & Compra_Id.ToString &
                    "," & Prov_Id.ToString & ",'" & TipoDoc & "'" &
                    ",'" & Format(FechaEmision, "yyyyMMdd HH:mm:ss") & "'" & ",'" & Clave & "'" &
                    ",'" & Consecutivo & "'" & ",'" & Xml & "'" &
                    ",'" & Moneda & "'" & "," & TipoCambio.ToString &
                    "," & Subtotal.ToString & "," & Descuento.ToString &
                    "," & Impuesto.ToString & "," & TotalCobrado.ToString &
                    "," & Estado_Id.ToString & ",'" & Format(FechaRegistro, "yyyyMMdd HH:mm:ss") & "'" &
                    "," & EstadoMensaje.ToString & ",'" & MensajeAcuse & "'" & ")"

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

            Query = " update CompraFacturar " &
                    " set    Prov_Id = " & Prov_Id.ToString &                    "       ,TipoDoc = '" & TipoDoc & "'" &                    "       ,FechaEmision = '" & Format(FechaEmision, "yyyyMMdd HH:mm:ss") & "'" &                    "       ,Clave = '" & Clave & "'" &                    "       ,Consecutivo = '" & Consecutivo & "'" &                    "       ,Xml = '" & Xml & "'" &                    "       ,Moneda = '" & Moneda & "'" &                    "       ,TipoCambio = " & TipoCambio &                    "       ,Subtotal = " & Subtotal &                    "       ,Descuento = " & Descuento &                    "       ,Impuesto = " & Impuesto &                    "       ,TotalCobrado = " & TotalCobrado &                    "       ,Estado_Id = " & Estado_Id &                    "       ,FechaRegistro = '" & Format(FechaRegistro, "yyyyMMdd HH:mm:ss") & "'" &                    "       ,EstadoMensaje = " & EstadoMensaje &                    "       ,MensajeAcuse = '" & MensajeAcuse & "'" &
                    " where Emisor_Id = " & Emisor_Id.ToString &
                    " and   Compra_Id = " & Compra_Id.ToString

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
    Public Overrides Function Delete() As String
        Dim Query As String = ""

        Try
            Cn.Open()
            Cn.BeginTransaction()

            Query = " delete CompraFacturar" &
                    " where Emisor_Id = " & Emisor_Id.ToString &
                    " and   Compra_Id = " & Compra_Id.ToString

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

            Query = " select *" &
                    " from CompraFacturar with (nolock)" &
                    " where Emisor_Id = " & Emisor_Id.ToString &
                    " and   Compra_Id = " & Compra_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                Emisor_Id = Tabla.Rows(0).Item("Emisor_Id")
                Compra_Id = Tabla.Rows(0).Item("Compra_Id")
                Prov_Id = Tabla.Rows(0).Item("Prov_Id")
                TipoDoc = Tabla.Rows(0).Item("TipoDoc")
                FechaEmision = Tabla.Rows(0).Item("FechaEmision")
                Clave = Tabla.Rows(0).Item("Clave")
                Consecutivo = Tabla.Rows(0).Item("Consecutivo")
                Xml = Tabla.Rows(0).Item("Xml")
                Moneda = Tabla.Rows(0).Item("Moneda")
                TipoCambio = Tabla.Rows(0).Item("TipoCambio")
                Subtotal = Tabla.Rows(0).Item("Subtotal")
                Descuento = Tabla.Rows(0).Item("Descuento")
                Impuesto = Tabla.Rows(0).Item("Impuesto")
                TotalCobrado = Tabla.Rows(0).Item("TotalCobrado")
                Estado_Id = Tabla.Rows(0).Item("Estado_Id")
                FechaRegistro = Tabla.Rows(0).Item("FechaRegistro")
                EstadoMensaje = Tabla.Rows(0).Item("EstadoMensaje")
                MensajeAcuse = Tabla.Rows(0).Item("MensajeAcuse")
            End If

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

            Query = "select * from CompraFacturar with (nolock)"

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
    Public Overrides Function LoadComboBox(pCombo As Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = " select CompraFacturar_Id as Numero " &
                    "       ,Nombre" &
                    " from CompraFacturar with (nolock) " &
                    " where Emisor_Id = " & Emisor_Id.ToString &
                    " and   Activo = 1"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing Then
                pCombo.DataSource = Tabla
                pCombo.DisplayMember = "Nombre"
                pCombo.ValueMember = "Numero"
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function LoadComboBoxProveedor(pCombo As Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select Prov_Id as Numero, Nombre from  Proveedor" &
            " where Emisor_Id = " & Emisor_Id.ToString &
            " order by Nombre asc "


            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing Then
                pCombo.DataSource = Tabla
                pCombo.DisplayMember = "Nombre"
                pCombo.ValueMember = "Numero"
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function SDComprasxEmisor(pFechaIni As Date, pFechaFin As Date) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "SDComprasxEmisor " & Emisor_Id & "," & Prov_Id & ",'" & pFechaIni.ToString("yyyyMMdd") & "','" & pFechaFin.ToString("yyyyMMdd") & "'"

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

#End Region
End Class

