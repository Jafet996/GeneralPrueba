Public Class TArticuloLote
#Region "Definition of Fields"
    Private _Art_Id As String
    Private _Nombre As String
    Private _Cantidad As Double
    Private _Escaneado As Double
    Private _Lotes As New List(Of TLote)
#End Region
#Region "Definition of Properties"
    Public Property Art_Id() As String
        Get
            Return _Art_Id
        End Get
        Set(ByVal value As String)
            _Art_Id = value
        End Set
    End Property
    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
        End Set
    End Property
    Public Property Cantidad As Double
        Get
            Return _Cantidad
        End Get
        Set(value As Double)
            _Cantidad = value
        End Set
    End Property
    Public Property Escaneado As Double
        Get
            Return _Escaneado
        End Get
        Set(value As Double)
            _Escaneado = value
        End Set
    End Property
    Public Property Lotes As List(Of TLote)
        Get
            Return _Lotes
        End Get
        Set(value As List(Of TLote))
            _Lotes = value
        End Set
    End Property
#End Region
#Region "Definition of Constructors"
    Public Sub New()
        _Art_Id = String.Empty
        _Nombre = String.Empty
        _Cantidad = 0
        _Escaneado = 0
        _Lotes.Clear()
    End Sub
#End Region
#Region "Definition of Public Methods"
    Public Sub CalcularEscaneo()
        Dim Cantidad = 0

        Try
            For Each lote As TLote In _Lotes
                Cantidad += lote.Cantidad
            Next

            _Escaneado = Cantidad
        Catch ex As Exception

        End Try
    End Sub
#End Region
End Class