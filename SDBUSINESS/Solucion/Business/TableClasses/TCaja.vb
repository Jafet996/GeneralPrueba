Public Class TCaja
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Caja_Id As Integer
    Private _Nombre As String
    Private _Bod_Id As Integer
    Private _Abierta As Integer
    Private _Cierre_Id As Integer
    Private _Activo As Integer
    Private _PreFacturas As Integer
    Private _UltimaModificacion As Datetime
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
    Public Property Caja_Id() As Integer
        Get
            Return _Caja_Id
        End Get
        Set(ByVal Value As Integer)
            _Caja_Id = Value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
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
    Public Property Abierta() As Integer
        Get
            Return _Abierta
        End Get
        Set(ByVal Value As Integer)
            _Abierta = Value
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
    Public Property Activo() As Integer
        Get
            Return _Activo
        End Get
        Set(ByVal Value As Integer)
            _Activo = Value
        End Set
    End Property
    Public Property PreFacturas As Integer
        Get
            Return _PreFacturas
        End Get
        Set(value As Integer)
            _PreFacturas = value
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
        _Caja_Id = 0
        _Nombre = ""
        _Bod_Id = 0
        _Abierta = 0
        _Cierre_Id = 0
        _Activo = 0
        _PreFacturas = 0
        _UltimaModificacion = CDate("1900/01/01")
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into Caja( Emp_Id , Suc_Id" & _
                    " , Caja_Id , Nombre" & _
                    " , Bod_Id , Abierta" & _
                    " , Cierre_Id , Prefacturas" & _
                    " , Activo , UltimaModificacion" & _
                    " )" & _
                    " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & _
                    "," & _Caja_Id.ToString() & ",'" & _Nombre & "'" & _
                    "," & _Bod_Id.ToString() & "," & _Abierta.ToString() & _
                    "," & _Cierre_Id.ToString() & "," & _PreFacturas.ToString() & _
                    "," & _Activo.ToString() & ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "')"

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

            Query = "Delete Caja" &
                    " Where     Emp_Id=" & _Emp_Id.ToString() &
                    " And    Suc_Id=" & _Suc_Id.ToString() &
                    " And    Caja_Id=" & _Caja_Id.ToString()

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

            Query = " Update dbo.Caja " & _
                    " SET   Nombre='" & _Nombre & "' " & "," & _
                    " Bod_Id=" & _Bod_Id & "," & _
                    " Abierta=" & _Abierta & "," & _
                    " Cierre_Id=" & _Cierre_Id & "," & _
                    " Prefacturas=" & _PreFacturas & "," & _
                    " Activo=" & _Activo & "," & _
                    " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & _
                    " Where     Emp_Id=" & _Emp_Id.ToString() & _
                    " And    Suc_Id=" & _Suc_Id.ToString() & _
                    " And    Caja_Id=" & _Caja_Id.ToString()

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

            Query = "select * From Caja" & _
                    " Where     Emp_Id=" & _Emp_Id.ToString() & _
                    " And    Suc_Id=" & _Suc_Id.ToString() & _
                    " And    Caja_Id=" & _Caja_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _Abierta = Tabla.Rows(0).Item("Abierta")
                _Cierre_Id = Tabla.Rows(0).Item("Cierre_Id")
                _PreFacturas = Tabla.Rows(0).Item("Prefacturas")
                _Activo = Tabla.Rows(0).Item("Activo")
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

            Query = "select * From Caja"

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

            Query = "select Caja_Id as Numero, Nombre From Caja where Emp_Id = " & _Emp_Id.ToString() & " and Suc_Id = " & _Suc_Id.ToString()

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
    Public Function AbrirCaja(pUsuario As String, pFondo As Double, pTipoCambio As Double) As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Query = " exec CierreCajaAbreCaja " & _Emp_Id.ToString & "," & _Suc_Id.ToString & "," & _Caja_Id.ToString & ",'" & pUsuario & "'," & pFondo.ToString & "," & pTipoCambio.ToString()

            Cn.Ejecutar(Query)

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function CerrarCaja(pEfectivo As Double, pTarjetas As Double, pCheques As Double, pDocumentos As Double, pDolares As Double) As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Query = " exec CierreCajaCierraCaja " & _Emp_Id.ToString & "," & _Suc_Id.ToString & "," & _Caja_Id.ToString &
                "," & pEfectivo.ToString & "," & pTarjetas.ToString & "," & pCheques.ToString & "," & pDocumentos.ToString & "," & pDolares

            Cn.Ejecutar(Query)

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function GeneraAsientoCierre() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Query = " exec GeneraAsientoCierre " & _Emp_Id.ToString & "," & _Suc_Id.ToString & "," & _Caja_Id.ToString & "," & _Cierre_Id.ToString()

            Cn.Ejecutar(Query)

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

            Query = "select Caja_Id as Numero, Nombre From Caja Where Emp_Id = " & _Emp_Id.ToString & " and Suc_Id = " & _Suc_Id & " and Activo = 1"

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
#End Region
End Class