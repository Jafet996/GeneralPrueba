Public Class TTipoCambio
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _TipoCambio_Id As Integer
    Private _Fecha As Datetime
    Private _Compra As Double
    Private _Venta As Double
    Private _Data As DataSet

#End Region

#Region "Definicion de propiedades"

    Public Property TipoCambio_Id() As Integer
        Get
            Return _TipoCambio_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoCambio_Id = Value
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
    Public Property Compra() As Double
        Get
            Return _Compra
        End Get
        Set(ByVal Value As Double)
            _Compra = Value
        End Set
    End Property
    Public Property Venta() As Double
        Get
            Return _Venta
        End Get
        Set(ByVal Value As Double)
            _Venta = Value
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
    Public Sub New()
        MyBase.New()
        Inicializa()

    End Sub
    Public Sub New(ByVal pCnStr As String)
        MyBase.New(pCnStr)
        Inicializa()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _TipoCambio_Id = 0
        _Fecha = CDate("1900/01/01")
        _Compra = 0.0
        _Venta = 0.0
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into TipoCambio( Fecha" & _
                   " , Compra , Venta)" & _
                   " Values (getdate() ," & _Compra.ToString() & "," & _Venta.ToString() & ")"

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

            query = "Delete TipoCambio" & _
               " Where     TipoCambio_Id=" & _TipoCambio_Id.ToString()

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

            query = " Update dbo.TipoCambio " & _
                      " SET    Fecha=" & _Fecha.ToString() & "," & _
                      " Compra=" & _Compra & "," & _
                      " Venta=" & _Venta & _
                      " Where     TipoCambio_Id=" & _TipoCambio_Id.ToString()

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

            Query = "exec RetornaTipoCambio"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Compra = Tabla.Rows(0).Item("Compra")
                _Venta = Tabla.Rows(0).Item("Venta")
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

            Query = "select * From TipoCambio order by Fecha desc"

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

            Query = "select TipoCambio_Id as Numero, Nombre From TipoCambio"

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

    Public Function ActualizaTipoCambio() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = " select * from TipoCambio where TipoCambio_Id = (select max(TipoCambio_Id ) from TipoCambio)"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                If Tabla.Rows(0).Item("Compra") <> _Compra OrElse Tabla.Rows(0).Item("Venta") <> Venta Then
                    VerificaMensaje(Insert)
                End If
            Else
                VerificaMensaje(Insert)
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
