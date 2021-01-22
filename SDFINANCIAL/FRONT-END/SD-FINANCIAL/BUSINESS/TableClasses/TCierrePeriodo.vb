Public Class TCierrePeriodo
#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Usuario_Id As String
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _Resultado As New SDFinancial.TResultado
    Private _MsgError As String = String.Empty
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
    Public Property Usuario_Id As String
        Get
            Return _Usuario_Id
        End Get
        Set(value As String)
            _Usuario_Id = value
        End Set
    End Property
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        If Not InfoMaquina Is Nothing AndAlso InfoMaquina.Url <> "" Then
            _SDWCF.Url = InfoMaquina.Url
        Else
            _SDWCF.Url = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegUrl, String.Empty)
        End If

        _Emp_Id = 0
        _Usuario_Id = String.Empty
        _MsgError = String.Empty
    End Sub
#End Region
#Region "Constructores"
    Public Sub New()
        Inicializa()
    End Sub
#End Region
#Region "Metodos Publicos"
    Public Function CierraPeriodoMes() As String
        Dim Query As String = String.Empty

        Try
            Query = "CierraPeriodoMes " & _Emp_Id.ToString

            _Resultado = _SDWCF.ExecuteQuery(Query, String.Empty)
            _MsgError = _Resultado.ErrorDescription

            If _MsgError.Trim <> "" Then
                Throw New Exception(_MsgError)
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function CierraPeriodoAnnio() As String
        Dim Query As String = String.Empty

        Try
            Query = "CierraPeriodoAnnio " & _Emp_Id.ToString & ",'" & _Usuario_Id & "'"

            _Resultado = _SDWCF.ExecuteQuery(Query, String.Empty)
            _MsgError = _Resultado.ErrorDescription

            If _MsgError.Trim <> "" Then
                Throw New Exception(_MsgError)
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
End Class