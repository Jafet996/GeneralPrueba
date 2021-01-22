Imports System.Windows.Forms
Public MustInherit Class WCF_BaseClass
#Region "Variables"
    Private _MsgError As String
    Private _Datos As New DataSet
#End Region
#Region "Propiedades"
    Public Property MsgError() As String
        Get
            Return _MsgError
        End Get
        Set(ByVal value As String)
            _MsgError = value
        End Set
    End Property
    Public Property Datos As DataSet
        Get
            Return _Datos
        End Get
        Set(value As DataSet)
            _Datos = value
        End Set
    End Property
#End Region
#Region "Constructor"
    Public Sub New()
        _MsgError = ""
    End Sub
#End Region
#Region "Metodos Publicos"
    Public Sub VerificaMsgError()
        If _MsgError.Trim <> "" Then
            Throw New Exception(_MsgError)
        End If
    End Sub
#End Region
#Region "Metodos Publicos para Sobreescribir"
    Public MustOverride Function Insert() As String
    Public MustOverride Function Delete() As String
    Public MustOverride Function Modify() As String
    Public MustOverride Function List() As String
    Public MustOverride Function ListKey() As String
    Public MustOverride Function LoadComboBox(pCombo As ComboBox) As String
    Public MustOverride Function ListMant(pCriterio As String) As String
    Public MustOverride Function NextOne() As String
#End Region
End Class
