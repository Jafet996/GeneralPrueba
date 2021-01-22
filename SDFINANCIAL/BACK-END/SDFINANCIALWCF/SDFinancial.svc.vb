Imports Business
Imports SDFINANCIALWCF

Public Class SDFinancial
    Implements ISDFinancial
#Region "Constructor"
    Public Sub New()
    End Sub
#End Region
#Region "A"
    Public Function AsientoDetalleMant(pTabla As DTAsientoDetalle, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.AsientoDetalleMant
        Dim Resultado As New TResultado
        Dim AsientoDetalle As New TAsientoDetalle(pTabla.Emp_Id)

        Try
            With AsientoDetalle
                .Emp_Id = pTabla.Emp_Id
                .Asiento_Id = pTabla.Asiento_Id
                .Linea_Id = pTabla.Linea_Id
                .Fecha = pTabla.Fecha
                .Moneda = pTabla.Moneda
                .CC_Id = pTabla.CC_Id
                .Cuenta_Id = pTabla.Cuenta_Id
                .Tipo = pTabla.Tipo
                .Monto = pTabla.Monto
                .MontoDolares = pTabla.MontoDolares
                .TipoCambio = pTabla.TipoCambio
                .Referencia = pTabla.Referencia
                .Descripcion = pTabla.Descripcion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(AsientoDetalle.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(AsientoDetalle.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(AsientoDetalle.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(AsientoDetalle.List)
                    Resultado.Datos = AsientoDetalle.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(AsientoDetalle.ListKey)
                    Resultado.Datos = AsientoDetalle.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(AsientoDetalle.LoadComboBox)
                    Resultado.Datos = AsientoDetalle.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(AsientoDetalle.ListMant(pCriterio))
                    Resultado.Datos = AsientoDetalle.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(AsientoDetalle.NextOne)
                    Resultado.Datos = AsientoDetalle.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = AsientoDetalle.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function AsientoEncabezadoMant(pTabla As DTAsientoEncabezado, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.AsientoEncabezadoMant
        Dim Resultado As New TResultado
        Dim AsientoEncabezado As New TAsientoEncabezado(pTabla.Emp_Id)
        Dim Detalle As TAsientoDetalle
        Dim Lista As New List(Of TAsientoDetalle)

        Try
            For Each Item As DTAsientoDetalle In pTabla.ListaDetalle
                Detalle = New TAsientoDetalle(pTabla.Emp_Id)

                With Detalle
                    .Emp_Id = Item.Emp_Id
                    .Asiento_Id = Item.Asiento_Id
                    .Linea_Id = Item.Linea_Id
                    .Fecha = Item.Fecha
                    .Moneda = Item.Moneda
                    .CC_Id = Item.CC_Id
                    .Cuenta_Id = Item.Cuenta_Id
                    .Tipo = Item.Tipo
                    .Monto = Item.Monto
                    .MontoDolares = Item.MontoDolares
                    .TipoCambio = Item.TipoCambio
                    .Referencia = Item.Referencia
                    .Descripcion = Item.Descripcion
                End With

                Lista.Add(Detalle)
            Next

            With AsientoEncabezado
                .Emp_Id = pTabla.Emp_Id
                .Asiento_Id = pTabla.Asiento_Id
                .Annio = pTabla.Annio
                .Mes = pTabla.Mes
                .Fecha = pTabla.Fecha
                .Tipo_Id = pTabla.Tipo_Id
                .Comentario = pTabla.Comentario
                .Estado_Id = pTabla.Estado_Id
                .Debitos = pTabla.Debitos
                .Creditos = pTabla.Creditos
                .Usuario_Id = pTabla.Usuario_Id
                .UsuarioAplica_Id = pTabla.UsuarioAplica_Id
                .Origen_Id = pTabla.Origen_Id
                .ListaDetalle = Lista
                .AplicarAsiento = pTabla.AplicarAsiento
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(AsientoEncabezado.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(AsientoEncabezado.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(AsientoEncabezado.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(AsientoEncabezado.List)
                    Resultado.Datos = AsientoEncabezado.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(AsientoEncabezado.ListKey)
                    Resultado.Datos = AsientoEncabezado.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(AsientoEncabezado.LoadComboBox)
                    Resultado.Datos = AsientoEncabezado.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(AsientoEncabezado.ListMant(pCriterio))
                    Resultado.Datos = AsientoEncabezado.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(AsientoEncabezado.NextOne)
                    Resultado.Datos = AsientoEncabezado.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = AsientoEncabezado.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function AsientoEstadoMant(pTabla As DTAsientoEstado, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.AsientoEstadoMant
        Dim Resultado As New TResultado
        Dim AsientoEstado As New TAsientoEstado(pTabla.Emp_Id)

        Try
            With AsientoEstado
                .Emp_Id = pTabla.Emp_Id
                .Estado_Id = pTabla.Estado_Id
                .Nombre = pTabla.Nombre
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(AsientoEstado.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(AsientoEstado.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(AsientoEstado.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(AsientoEstado.List)
                    Resultado.Datos = AsientoEstado.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(AsientoEstado.ListKey)
                    Resultado.Datos = AsientoEstado.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(AsientoEstado.LoadComboBox)
                    Resultado.Datos = AsientoEstado.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(AsientoEstado.ListMant(pCriterio))
                    Resultado.Datos = AsientoEstado.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(AsientoEstado.NextOne)
                    Resultado.Datos = AsientoEstado.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = AsientoEstado.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function AsientoOrigenMant(pTabla As DTAsientoOrigen, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.AsientoOrigenMant
        Dim Resultado As New TResultado
        Dim AsientoOrigen As New TAsientoOrigen(pTabla.Emp_Id)

        Try
            With AsientoOrigen
                .Emp_Id = pTabla.Emp_Id
                .Origen_Id = pTabla.Origen_Id
                .Nombre = pTabla.Nombre
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(AsientoOrigen.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(AsientoOrigen.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(AsientoOrigen.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(AsientoOrigen.List)
                    Resultado.Datos = AsientoOrigen.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(AsientoOrigen.ListKey)
                    Resultado.Datos = AsientoOrigen.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(AsientoOrigen.LoadComboBox)
                    Resultado.Datos = AsientoOrigen.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(AsientoOrigen.ListMant(pCriterio))
                    Resultado.Datos = AsientoOrigen.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(AsientoOrigen.NextOne)
                    Resultado.Datos = AsientoOrigen.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = AsientoOrigen.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function AsientoTipoMant(pTabla As DTAsientoTipo, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.AsientoTipoMant
        Dim Resultado As New TResultado
        Dim AsientoTipo As New TAsientoTipo(pTabla.Emp_Id)

        Try
            With AsientoTipo
                .Emp_Id = pTabla.Emp_Id
                .Tipo_Id = pTabla.Tipo_Id
                .Nombre = pTabla.Nombre
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(AsientoTipo.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(AsientoTipo.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(AsientoTipo.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(AsientoTipo.List)
                    Resultado.Datos = AsientoTipo.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(AsientoTipo.ListKey)
                    Resultado.Datos = AsientoTipo.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(AsientoTipo.LoadComboBox)
                    Resultado.Datos = AsientoTipo.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(AsientoTipo.ListMant(pCriterio))
                    Resultado.Datos = AsientoTipo.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(AsientoTipo.NextOne)
                    Resultado.Datos = AsientoTipo.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = AsientoTipo.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function AuxAsientoDetalleMant(pTabla As DTAuxAsientoDetalle, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.AuxAsientoDetalleMant
        Dim Resultado As New TResultado
        Dim AuxAsientoDetalle As New TAuxAsientoDetalle(pTabla.Emp_Id)

        Try
            With AuxAsientoDetalle
                .Emp_Id = pTabla.Emp_Id
                .Asiento_Id = pTabla.Asiento_Id
                .Linea_Id = pTabla.Linea_Id
                .Fecha = pTabla.Fecha
                .Moneda = pTabla.Moneda
                .CC_Id = pTabla.CC_Id
                .Cuenta_Id = pTabla.Cuenta_Id
                .Tipo = pTabla.Tipo
                .Monto = pTabla.Monto
                .MontoDolares = pTabla.MontoDolares
                .TipoCambio = pTabla.TipoCambio
                .Referencia = pTabla.Referencia
                .Descripcion = pTabla.Descripcion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(AuxAsientoDetalle.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(AuxAsientoDetalle.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(AuxAsientoDetalle.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(AuxAsientoDetalle.List)
                    Resultado.Datos = AuxAsientoDetalle.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(AuxAsientoDetalle.ListKey)
                    Resultado.Datos = AuxAsientoDetalle.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(AuxAsientoDetalle.LoadComboBox)
                    Resultado.Datos = AuxAsientoDetalle.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(AuxAsientoDetalle.ListMant(pCriterio))
                    Resultado.Datos = AuxAsientoDetalle.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(AuxAsientoDetalle.NextOne)
                    Resultado.Datos = AuxAsientoDetalle.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = AuxAsientoDetalle.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function AuxAsientoEncabezadoMant(pTabla As DTAuxAsientoEncabezado, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.AuxAsientoEncabezadoMant
        Dim Resultado As New TResultado
        Dim AuxAsientoEncabezado As New TAuxAsientoEncabezado(pTabla.Emp_Id)
        Dim Detalle As TAuxAsientoDetalle
        Dim Lista As New List(Of TAuxAsientoDetalle)

        Try
            For Each Item As DTAuxAsientoDetalle In pTabla.ListaDetalle
                Detalle = New TAuxAsientoDetalle(pTabla.Emp_Id)

                With Detalle
                    .Emp_Id = Item.Emp_Id
                    .Asiento_Id = Item.Asiento_Id
                    .Linea_Id = Item.Linea_Id
                    .Fecha = Item.Fecha
                    .Moneda = Item.Moneda
                    .CC_Id = Item.CC_Id
                    .Cuenta_Id = Item.Cuenta_Id
                    .Tipo = Item.Tipo
                    .Monto = Item.Monto
                    .MontoDolares = Item.MontoDolares
                    .TipoCambio = Item.TipoCambio
                    .Referencia = Item.Referencia
                    .Descripcion = Item.Descripcion
                End With

                Lista.Add(Detalle)
            Next

            With AuxAsientoEncabezado
                .Emp_Id = pTabla.Emp_Id
                .Asiento_Id = pTabla.Asiento_Id
                .Annio = pTabla.Annio
                .Mes = pTabla.Mes
                .Fecha = pTabla.Fecha
                .Tipo_Id = pTabla.Tipo_Id
                .Comentario = pTabla.Comentario
                .Debitos = pTabla.Debitos
                .Creditos = pTabla.Creditos
                .Usuario_Id = pTabla.Usuario_Id
                .Origen_Id = pTabla.Origen_Id
                .MAC_Address = pTabla.MAC_Address
                .ListaDetalle = Lista
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(AuxAsientoEncabezado.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(AuxAsientoEncabezado.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(AuxAsientoEncabezado.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(AuxAsientoEncabezado.List)
                    Resultado.Datos = AuxAsientoEncabezado.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(AuxAsientoEncabezado.ListKey)
                    Resultado.Datos = AuxAsientoEncabezado.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(AuxAsientoEncabezado.LoadComboBox)
                    Resultado.Datos = AuxAsientoEncabezado.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(AuxAsientoEncabezado.ListMant(pCriterio))
                    Resultado.Datos = AuxAsientoEncabezado.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(AuxAsientoEncabezado.NextOne)
                    Resultado.Datos = AuxAsientoEncabezado.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = AuxAsientoEncabezado.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function
#End Region
#Region "B"
    Public Function BancoMant(pTabla As DTBanco, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.BancoMant
        Dim Resultado As New TResultado
        Dim Banco As New TBanco(pTabla.Emp_Id)

        Try
            With Banco
                .Emp_Id = pTabla.Emp_Id
                .Banco_Id = pTabla.Banco_Id
                .Nombre = pTabla.Nombre
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(Banco.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(Banco.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(Banco.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(Banco.List)
                    Resultado.Datos = Banco.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(Banco.ListKey)
                    Resultado.Datos = Banco.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(Banco.LoadComboBox)
                    Resultado.Datos = Banco.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(Banco.ListMant(pCriterio))
                    Resultado.Datos = Banco.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(Banco.NextOne)
                    Resultado.Datos = Banco.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = Banco.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function BcoPagoMant(pTabla As DTBcoPago, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.BcoPagoMant
        Dim Resultado As New TResultado
        Dim BcoPago As New TBcoPago(pTabla.Emp_Id)
        Dim Lista As New List(Of TCxPSolicitudPago)
        Dim Detalle As TCxPSolicitudPago

        Try
            For Each Item As DTCxPSolicitudPago In pTabla.ListaSolicitudes
                Detalle = New TCxPSolicitudPago(pTabla.Emp_Id)

                With Detalle
                    .Emp_Id = Item.Emp_Id
                    .Prov_Id = Item.Prov_Id
                    .Tipo_Id = Item.Tipo_Id
                    .Mov_Id = Item.Mov_Id
                    .Monto = Item.Monto
                    .PagoMonto = Item.PagoMonto
                    .PagoDolares = Item.PagoDolares
                    .Diferencial = Item.Diferencial
                End With

                Lista.Add(Detalle)
            Next

            With BcoPago
                .Emp_Id = pTabla.Emp_Id
                .BcoPago_Id = pTabla.BcoPago_Id
                .TipoPago_Id = pTabla.TipoPago_Id
                .Prov_Id = pTabla.Prov_Id
                .Banco_Id = pTabla.Banco_Id
                .Cuenta = pTabla.Cuenta
                .Moneda = pTabla.Moneda
                .Fecha = pTabla.Fecha
                .Monto = pTabla.Monto
                .TipoCambio = pTabla.TipoCambio
                .Dolares = pTabla.Dolares
                .Usuario_Id = pTabla.Usuario_Id
                .Concepto = pTabla.Concepto
                .ListaSolicitudes = Lista
            End With

            With BcoPago.Cheque
                .Nombre = pTabla.Cheque.Nombre
                .Fecha = pTabla.Cheque.Fecha
            End With

            With BcoPago.Transferencia
                .Banco_Id = pTabla.Transferencia.Banco_Id
                .Cuenta = pTabla.Transferencia.Cuenta
                .Moneda = pTabla.Transferencia.Moneda
                .Fecha = pTabla.Transferencia.Fecha
                .TipoCambio = pTabla.Transferencia.TipoCambio
                .Numero = pTabla.Transferencia.Numero
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(BcoPago.Insert)
                    Resultado.Datos = BcoPago.Consecutivos
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(BcoPago.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(BcoPago.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(BcoPago.List)
                    Resultado.Datos = BcoPago.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(BcoPago.ListKey)
                    Resultado.Datos = BcoPago.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(BcoPago.LoadComboBox)
                    Resultado.Datos = BcoPago.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(BcoPago.ListMant(pCriterio))
                    Resultado.Datos = BcoPago.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(BcoPago.NextOne)
                    Resultado.Datos = BcoPago.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = BcoPago.RowsAffected
                .ErrorCode = "00"
                .Valor = BcoPago.BcoPago_Id
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function BcoPagoChequeMant(pTabla As DTBcoPagoCheque, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.BcoPagoChequeMant
        Dim Resultado As New TResultado
        Dim BcoPagoCheque As New TBcoPagoCheque(pTabla.Emp_Id)

        Try
            With BcoPagoCheque
                .Emp_Id = pTabla.Emp_Id
                .BcoPago_Id = pTabla.BcoPago_Id
                .Nombre = pTabla.Nombre
                .Numero = pTabla.Numero
                .Fecha = pTabla.Fecha
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(BcoPagoCheque.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(BcoPagoCheque.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(BcoPagoCheque.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(BcoPagoCheque.List)
                    Resultado.Datos = BcoPagoCheque.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(BcoPagoCheque.ListKey)
                    Resultado.Datos = BcoPagoCheque.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(BcoPagoCheque.LoadComboBox)
                    Resultado.Datos = BcoPagoCheque.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(BcoPagoCheque.ListMant(pCriterio))
                    Resultado.Datos = BcoPagoCheque.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(BcoPagoCheque.NextOne)
                    Resultado.Datos = BcoPagoCheque.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = BcoPagoCheque.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function BcoPagoTransferenciaMant(pTabla As DTBcoPagoTransferencia, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.BcoPagoTransferenciaMant
        Dim Resultado As New TResultado
        Dim BcoPagoTransferencia As New TBcoPagoTransferencia(pTabla.Emp_Id)

        Try
            With BcoPagoTransferencia
                .Emp_Id = pTabla.Emp_Id
                .BcoPago_Id = pTabla.BcoPago_Id
                .Banco_Id = pTabla.Banco_Id
                .Cuenta = pTabla.Cuenta
                .Moneda = pTabla.Moneda
                .Fecha = pTabla.Fecha
                .TipoCambio = pTabla.TipoCambio
                .Numero = pTabla.Numero
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(BcoPagoTransferencia.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(BcoPagoTransferencia.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(BcoPagoTransferencia.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(BcoPagoTransferencia.List)
                    Resultado.Datos = BcoPagoTransferencia.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(BcoPagoTransferencia.ListKey)
                    Resultado.Datos = BcoPagoTransferencia.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(BcoPagoTransferencia.LoadComboBox)
                    Resultado.Datos = BcoPagoTransferencia.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(BcoPagoTransferencia.ListMant(pCriterio))
                    Resultado.Datos = BcoPagoTransferencia.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(BcoPagoTransferencia.NextOne)
                    Resultado.Datos = BcoPagoTransferencia.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = BcoPagoTransferencia.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function BcoTipoPagoMant(pTabla As DTBcoTipoPago, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.BcoTipoPagoMant
        Dim Resultado As New TResultado
        Dim BcoTipoPago As New TBcoTipoPago(pTabla.Emp_Id)

        Try
            With BcoTipoPago
                .Emp_Id = pTabla.Emp_Id
                .TipoPago_Id = pTabla.TipoPago_Id
                .Nombre = pTabla.Nombre
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(BcoTipoPago.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(BcoTipoPago.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(BcoTipoPago.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(BcoTipoPago.List)
                    Resultado.Datos = BcoTipoPago.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(BcoTipoPago.ListKey)
                    Resultado.Datos = BcoTipoPago.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(BcoTipoPago.LoadComboBox)
                    Resultado.Datos = BcoTipoPago.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(BcoTipoPago.ListMant(pCriterio))
                    Resultado.Datos = BcoTipoPago.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(BcoTipoPago.NextOne)
                    Resultado.Datos = BcoTipoPago.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = BcoTipoPago.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function
#End Region
#Region "C"
    Public Function CajaMant(pTabla As DTCaja, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CajaMant
        Dim Resultado As New TResultado
        Dim Caja As New TCaja(pTabla.Emp_Id)

        Try
            With Caja
                .Emp_Id = pTabla.Emp_Id
                .Caja_Id = pTabla.Caja_Id
                .Nombre = pTabla.Nombre
                .Abierta = pTabla.Abierta
                .Cierre_Id = pTabla.Cierre_Id
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(Caja.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(Caja.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(Caja.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(Caja.List)
                    Resultado.Datos = Caja.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(Caja.ListKey)
                    Resultado.Datos = Caja.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(Caja.LoadComboBox)
                    Resultado.Datos = Caja.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(Caja.ListMant(pCriterio))
                    Resultado.Datos = Caja.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(Caja.NextOne)
                    Resultado.Datos = Caja.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = Caja.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CajaCierreDetalleMant(pTabla As DTCajaCierreDetalle, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CajaCierreDetalleMant
        Dim Resultado As New TResultado
        Dim CajaCierreDetalle As New TCajaCierreDetalle(pTabla.Emp_Id)

        Try
            With CajaCierreDetalle
                .Emp_Id = pTabla.Emp_Id
                .Caja_Id = pTabla.Caja_Id
                .Cierre_Id = pTabla.Cierre_Id
                .Detalle_Id = pTabla.Detalle_Id
                .Tipo_Id = pTabla.Tipo_Id
                .Mov_Id = pTabla.Mov_Id
                .Pago_Id = pTabla.Pago_Id
                .TipoPago_Id = pTabla.TipoPago_Id
                .Monto = pTabla.Monto
                .Banco_Id = pTabla.Banco_Id
                .ChequeNumero = pTabla.ChequeNumero
                .Tarjeta_Id = pTabla.Tarjeta_Id
                .TarjetaNumero = pTabla.TarjetaNumero
                .TarjetaAutorizacion = pTabla.TarjetaAutorizacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CajaCierreDetalle.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CajaCierreDetalle.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CajaCierreDetalle.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CajaCierreDetalle.List)
                    Resultado.Datos = CajaCierreDetalle.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CajaCierreDetalle.ListKey)
                    Resultado.Datos = CajaCierreDetalle.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CajaCierreDetalle.LoadComboBox)
                    Resultado.Datos = CajaCierreDetalle.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CajaCierreDetalle.ListMant(pCriterio))
                    Resultado.Datos = CajaCierreDetalle.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CajaCierreDetalle.NextOne)
                    Resultado.Datos = CajaCierreDetalle.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CajaCierreDetalle.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CajaCierreEncabezadoMant(pTabla As DTCajaCierreEncabezado, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CajaCierreEncabezadoMant
        Dim Resultado As New TResultado
        Dim CajaCierreEncabezado As New TCajaCierreEncabezado(pTabla.Emp_Id)

        Try
            With CajaCierreEncabezado
                .Emp_Id = pTabla.Emp_Id
                .Caja_Id = pTabla.Caja_Id
                .Cierre_Id = pTabla.Cierre_Id
                .Usuario_Id = pTabla.Usuario_Id
                .Cerrado = pTabla.Cerrado
                .FechaCierre = pTabla.FechaCierre
                .FechaApertura = pTabla.FechaApertura
                .Efectivo = pTabla.Efectivo
                .Tarjeta = pTabla.Tarjeta
                .Cheque = pTabla.Cheque
                .Dolares = pTabla.Dolares
                .Fondo = pTabla.Fondo
                .Transferencia = pTabla.Transferencia
                .Deposito = pTabla.Deposito
                .CajeroEfectivo = pTabla.CajeroEfectivo
                .CajeroTarjeta = pTabla.CajeroTarjeta
                .CajeroCheque = pTabla.CajeroCheque
                .CajeroDocumentos = pTabla.CajeroDocumentos
                .CajeroDolares = pTabla.CajeroDolares
                .TipoCambio = pTabla.TipoCambio
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CajaCierreEncabezado.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CajaCierreEncabezado.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CajaCierreEncabezado.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CajaCierreEncabezado.List)
                    Resultado.Datos = CajaCierreEncabezado.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CajaCierreEncabezado.ListKey)
                    Resultado.Datos = CajaCierreEncabezado.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CajaCierreEncabezado.LoadComboBox)
                    Resultado.Datos = CajaCierreEncabezado.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CajaCierreEncabezado.ListMant(pCriterio))
                    Resultado.Datos = CajaCierreEncabezado.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CajaCierreEncabezado.NextOne)
                    Resultado.Datos = CajaCierreEncabezado.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CajaCierreEncabezado.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CambioMonedaMant(pTabla As DTCambioMoneda, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CambioMonedaMant
        Dim Resultado As New TResultado
        Dim CambioMoneda As New TCambioMoneda(pTabla.Emp_Id)

        Try
            With CambioMoneda
                .Emp_Id = pTabla.Emp_Id
                .Cambio_Id = pTabla.Cambio_Id
                .Tipo_Id = pTabla.Tipo_Id
                .Caja_Id = pTabla.Caja_Id
                .Cierre_Id = pTabla.Cierre_Id
                .Efectivo = pTabla.Efectivo
                .Dolares = pTabla.Dolares
                .TipoCambio = pTabla.TipoCambio
                .Fecha = pTabla.Fecha
                .Usuario_Id = pTabla.Usuario_Id
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CambioMoneda.Insert)
                    Resultado.Valor = CambioMoneda.Cambio_Id
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CambioMoneda.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CambioMoneda.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CambioMoneda.List)
                    Resultado.Datos = CambioMoneda.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CambioMoneda.ListKey)
                    Resultado.Datos = CambioMoneda.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CambioMoneda.LoadComboBox)
                    Resultado.Datos = CambioMoneda.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CambioMoneda.ListMant(pCriterio))
                    Resultado.Datos = CambioMoneda.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CambioMoneda.NextOne)
                    Resultado.Datos = CambioMoneda.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CambioMoneda.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CambioMonedaTipoMant(pTabla As DTCambioMonedaTipo, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CambioMonedaTipoMant
        Dim Resultado As New TResultado
        Dim CambioMonedaTipo As New TCambioMonedaTipo(pTabla.Emp_Id)

        Try
            With CambioMonedaTipo
                .Emp_Id = pTabla.Emp_Id
                .Tipo_Id = pTabla.Tipo_Id
                .Nombre = pTabla.Nombre
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CambioMonedaTipo.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CambioMonedaTipo.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CambioMonedaTipo.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CambioMonedaTipo.List)
                    Resultado.Datos = CambioMonedaTipo.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CambioMonedaTipo.ListKey)
                    Resultado.Datos = CambioMonedaTipo.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CambioMonedaTipo.LoadComboBox)
                    Resultado.Datos = CambioMonedaTipo.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CambioMonedaTipo.ListMant(pCriterio))
                    Resultado.Datos = CambioMonedaTipo.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CambioMonedaTipo.NextOne)
                    Resultado.Datos = CambioMonedaTipo.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CambioMonedaTipo.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CentroCostoMant(pTabla As DTCentroCosto, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CentroCostoMant
        Dim Resultado As New TResultado
        Dim CentroCosto As New TCentroCosto(pTabla.Emp_Id)

        Try
            With CentroCosto
                .Emp_Id = pTabla.Emp_Id
                .CC_Id = pTabla.CC_Id
                .Nombre = pTabla.Nombre
                .CCTipo_Id = pTabla.CCTipo_Id
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CentroCosto.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CentroCosto.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CentroCosto.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CentroCosto.List)
                    Resultado.Datos = CentroCosto.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CentroCosto.ListKey)
                    Resultado.Datos = CentroCosto.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CentroCosto.LoadComboBox)
                    Resultado.Datos = CentroCosto.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CentroCosto.ListMant(pCriterio))
                    Resultado.Datos = CentroCosto.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CentroCosto.NextOne)
                    Resultado.Datos = CentroCosto.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CentroCosto.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CentroCostoTipoMant(pTabla As DTCentroCostoTipo, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CentroCostoTipoMant
        Dim Resultado As New TResultado
        Dim CentroCostoTipo As New TCentroCostoTipo(pTabla.Emp_Id)

        Try
            With CentroCostoTipo
                .Emp_Id = pTabla.Emp_Id
                .CCTipo_Id = pTabla.CCTipo_Id
                .Nombre = pTabla.Nombre
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CentroCostoTipo.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CentroCostoTipo.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CentroCostoTipo.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CentroCostoTipo.List)
                    Resultado.Datos = CentroCostoTipo.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CentroCostoTipo.ListKey)
                    Resultado.Datos = CentroCostoTipo.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CentroCostoTipo.LoadComboBox)
                    Resultado.Datos = CentroCostoTipo.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CentroCostoTipo.ListMant(pCriterio))
                    Resultado.Datos = CentroCostoTipo.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CentroCostoTipo.NextOne)
                    Resultado.Datos = CentroCostoTipo.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CentroCostoTipo.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function ClienteMant(pTabla As DTCliente, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.ClienteMant
        Dim Resultado As New TResultado
        Dim Cliente As New TCliente(pTabla.Emp_Id)

        Try
            With Cliente
                .Emp_Id = pTabla.Emp_Id
                .Cliente_Id = pTabla.Cliente_Id
                .TipoIdentificacion_Id = pTabla.TipoIdentificacion_Id
                .Identificacion = pTabla.Identificacion
                .Nombre = pTabla.Nombre
                .NombreComercial = pTabla.NombreComercial
                .Telefono1 = pTabla.Telefono1
                .Telefono2 = pTabla.Telefono2
                .Email = pTabla.Email
                .Direccion = pTabla.Direccion
                .Debitos = pTabla.Debitos
                .Creditos = pTabla.Creditos
                .Saldo = pTabla.Saldo
                .DiasCredito = pTabla.DiasCredito
                .PorcMora = pTabla.PorcMora
                .DiasGraciaMora = pTabla.DiasGraciaMora
                .AplicaMora = pTabla.AplicaMora
                .LimiteCredito = pTabla.LimiteCredito
                .CxC_Colones = pTabla.CxC_Colones
                .CxC_Dolares = pTabla.CxC_Dolares
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
                .Vendedor_Id = pTabla.Vendedor_Id
                .EsInterno = pTabla.EsInterno
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(Cliente.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(Cliente.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(Cliente.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(Cliente.List)
                    Resultado.Datos = Cliente.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(Cliente.ListKey)
                    Resultado.Datos = Cliente.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(Cliente.LoadComboBox)
                    Resultado.Datos = Cliente.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(Cliente.ListMant(pCriterio))
                    Resultado.Datos = Cliente.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(Cliente.NextOne)
                    Resultado.Datos = Cliente.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = Cliente.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function ClienteSaldo(pTabla As DTCliente) As TResultado

        Try
            Dim Cliente As New TCliente(pTabla.Emp_Id) With {
                .Cliente_Id = pTabla.Cliente_Id
            }

            VerificaMensaje(Cliente.ListKey)

            Dim Resultado As New TResultado With {
                .Datos = Cliente.Data.Tables(0)
            }

            Return Resultado
        Catch ex As Exception
            VerificaMensaje(ex.Message)
        End Try



    End Function

    Public Function ClienteMovimientos(pTabla As DTCliente, ByVal pDesde As Date, ByVal pHasta As Date) As TResultado Implements ISDFinancial.ClienteMovimientos

        Try
            Dim Cliente As New TCliente(pTabla.Emp_Id) With {
                .Cliente_Id = pTabla.Cliente_Id
            }

            VerificaMensaje(Cliente.Movimientos(pDesde, pHasta))

            Dim Resultado As New TResultado With {
                .Datos = Cliente.Data.Tables(0)
            }

            Return Resultado
        Catch ex As Exception
            VerificaMensaje(ex.Message)
        End Try



    End Function

    Public Function CodigoPermisoBitacoraMant(pTabla As DTCodigoPermisoBitacora, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CodigoPermisoBitacoraMant
        Dim Resultado As New TResultado
        Dim CodigoPermisoBitacora As New TCodigoPermisoBitacora(pTabla.Emp_Id)

        Try
            With CodigoPermisoBitacora
                .Bitacora_Id = pTabla.Bitacora_Id
                .Emp_Id = pTabla.Emp_Id
                .Usuario_Id = pTabla.Usuario_Id
                .UsuarioUtilizo_Id = pTabla.UsuarioUtilizo_Id
                .Permiso_Id = pTabla.Permiso_Id
                .Codigo = pTabla.Codigo
                .Fecha = pTabla.Fecha
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CodigoPermisoBitacora.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CodigoPermisoBitacora.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CodigoPermisoBitacora.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CodigoPermisoBitacora.List)
                    Resultado.Datos = CodigoPermisoBitacora.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CodigoPermisoBitacora.ListKey)
                    Resultado.Datos = CodigoPermisoBitacora.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CodigoPermisoBitacora.LoadComboBox)
                    Resultado.Datos = CodigoPermisoBitacora.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CodigoPermisoBitacora.ListMant(pCriterio))
                    Resultado.Datos = CodigoPermisoBitacora.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CodigoPermisoBitacora.NextOne)
                    Resultado.Datos = CodigoPermisoBitacora.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CodigoPermisoBitacora.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function ConvierteNumeroLetras(ByVal pNumero As Double) As TResultado Implements ISDFinancial.ConvierteNumeroLetras
        Dim Resultado As New TResultado

        Try
            Resultado.Valor = Letras(pNumero)

            With Resultado
                .RowsAffected = 0
                .ErrorCode = "00"
            End With
        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CuentaMant(pTabla As DTCuenta, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CuentaMant
        Dim Resultado As New TResultado
        Dim Cuenta As New TCuenta(pTabla.Emp_Id)

        Try
            With Cuenta
                .Emp_Id = pTabla.Emp_Id
                .Cuenta_Id = pTabla.Cuenta_Id
                .Nombre = pTabla.Nombre
                .Tipo_Id = pTabla.Tipo_Id
                .Clase_Id = pTabla.Clase_Id
                .Nivel = pTabla.Nivel
                .Padre_Id = pTabla.Padre_Id
                .Moneda = pTabla.Moneda
                .AceptaMovimiento = pTabla.AceptaMovimiento
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
                .SolicitaCentroCosto = pTabla.SolicitaCentroCosto
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(Cuenta.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(Cuenta.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(Cuenta.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(Cuenta.List)
                    Resultado.Datos = Cuenta.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(Cuenta.ListKey)
                    Resultado.Datos = Cuenta.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(Cuenta.LoadComboBox)
                    Resultado.Datos = Cuenta.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(Cuenta.ListMant(pCriterio))
                    Resultado.Datos = Cuenta.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(Cuenta.NextOne)
                    Resultado.Datos = Cuenta.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = Cuenta.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CuentaFlujoEfectivoMant(pTabla As DTCuentaFlujoEfectivo, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CuentaFlujoEfectivoMant
        Dim Resultado As New TResultado
        Dim CuentaFlujoEfectivo As New TCuentaFlujoEfectivo(pTabla.Emp_Id)

        Try
            With CuentaFlujoEfectivo
                .Emp_Id = pTabla.Emp_Id
                .Tipo_Id = pTabla.Tipo_Id
                .Cuenta_Id = pTabla.Cuenta_Id
                .Entrada = pTabla.Entrada
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CuentaFlujoEfectivo.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CuentaFlujoEfectivo.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CuentaFlujoEfectivo.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CuentaFlujoEfectivo.List)
                    Resultado.Datos = CuentaFlujoEfectivo.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CuentaFlujoEfectivo.ListKey)
                    Resultado.Datos = CuentaFlujoEfectivo.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CuentaFlujoEfectivo.LoadComboBox)
                    Resultado.Datos = CuentaFlujoEfectivo.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CuentaFlujoEfectivo.ListMant(pCriterio))
                    Resultado.Datos = CuentaFlujoEfectivo.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CuentaFlujoEfectivo.NextOne)
                    Resultado.Datos = CuentaFlujoEfectivo.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CuentaFlujoEfectivo.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CuentaTipoMant(pTabla As DTCuentaTipo, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CuentaTipoMant
        Dim Resultado As New TResultado
        Dim CuentaTipo As New TCuentaTipo(pTabla.Emp_Id)

        Try
            With CuentaTipo
                .Emp_Id = pTabla.Emp_Id
                .Tipo_Id = pTabla.Tipo_Id
                .Nombre = pTabla.Nombre
                .CCTipo_Id = pTabla.CCTipo_Id
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CuentaTipo.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CuentaTipo.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CuentaTipo.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CuentaTipo.List)
                    Resultado.Datos = CuentaTipo.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CuentaTipo.ListKey)
                    Resultado.Datos = CuentaTipo.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CuentaTipo.LoadComboBox)
                    Resultado.Datos = CuentaTipo.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CuentaTipo.ListMant(pCriterio))
                    Resultado.Datos = CuentaTipo.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CuentaTipo.NextOne)
                    Resultado.Datos = CuentaTipo.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CuentaTipo.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CuentaTipoClaseMant(pTabla As DTCuentaTipoClase, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CuentaTipoClaseMant
        Dim Resultado As New TResultado
        Dim CuentaTipoClase As New TCuentaTipoClase(pTabla.Emp_Id)

        Try
            With CuentaTipoClase
                .Emp_Id = pTabla.Emp_Id
                .Tipo_Id = pTabla.Tipo_Id
                .Clase_Id = pTabla.Clase_Id
                .Nombre = pTabla.Nombre
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CuentaTipoClase.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CuentaTipoClase.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CuentaTipoClase.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CuentaTipoClase.List)
                    Resultado.Datos = CuentaTipoClase.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CuentaTipoClase.ListKey)
                    Resultado.Datos = CuentaTipoClase.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CuentaTipoClase.LoadComboBox)
                    Resultado.Datos = CuentaTipoClase.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CuentaTipoClase.ListMant(pCriterio))
                    Resultado.Datos = CuentaTipoClase.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CuentaTipoClase.NextOne)
                    Resultado.Datos = CuentaTipoClase.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CuentaTipoClase.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CuentaTipoFlujoEfectivoMant(pTabla As DTCuentaTipoFlujoEfectivo, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CuentaTipoFlujoEfectivoMant
        Dim Resultado As New TResultado
        Dim CuentaTipoFlujoEfectivo As New TCuentaTipoFlujoEfectivo(pTabla.Emp_Id)

        Try
            With CuentaTipoFlujoEfectivo
                .Emp_Id = pTabla.Emp_Id
                .Tipo_Id = pTabla.Tipo_Id
                .Nombre = pTabla.Nombre
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CuentaTipoFlujoEfectivo.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CuentaTipoFlujoEfectivo.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CuentaTipoFlujoEfectivo.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CuentaTipoFlujoEfectivo.List)
                    Resultado.Datos = CuentaTipoFlujoEfectivo.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CuentaTipoFlujoEfectivo.ListKey)
                    Resultado.Datos = CuentaTipoFlujoEfectivo.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CuentaTipoFlujoEfectivo.LoadComboBox)
                    Resultado.Datos = CuentaTipoFlujoEfectivo.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CuentaTipoFlujoEfectivo.ListMant(pCriterio))
                    Resultado.Datos = CuentaTipoFlujoEfectivo.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CuentaTipoFlujoEfectivo.NextOne)
                    Resultado.Datos = CuentaTipoFlujoEfectivo.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CuentaTipoFlujoEfectivo.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CxCMovimientoMant(pTabla As DTCxCMovimiento, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CxCMovimientoMant
        Dim Resultado As New TResultado
        Dim CxCMovimiento As New TCxCMovimiento(pTabla.Emp_Id)
        Dim Detalle As TCxCMovimientoPago
        Dim Lista As New List(Of TCxCMovimientoPago)
        Dim DetalleMov As TCxCMovimientoLinea
        Dim ListaMov As New List(Of TCxCMovimientoLinea)
        Try


            For Each Item As DTCxCMovimientoPago In pTabla.ListaPagos
                Detalle = New TCxCMovimientoPago(pTabla.Emp_Id)

                With Detalle
                    .Emp_Id = Item.Emp_Id
                    .Caja_Id = Item.Caja_Id
                    .Cierre_Id = Item.Cierre_Id
                    .TipoPago_Id = Item.TipoPago_Id
                    .Monto = Item.Monto
                    .Banco_Id = Item.Banco_Id
                    .Cuenta = Item.Cuenta
                    .ChequeNumero = Item.ChequeNumero
                    .ChequeFecha = Item.ChequeFecha
                    .DepositoNumero = Item.DepositoNumero
                    .DepositoFecha = Item.DepositoFecha
                    .TransferenciaNumero = Item.TransferenciaNumero
                    .Tarjeta_Id = Item.Tarjeta_Id
                    .TarjetaNumero = Item.TarjetaNumero
                    .TarjetaAutorizacion = Item.TarjetaAutorizacion
                    .Moneda = Item.Moneda
                    .TipoCambio = Item.TipoCambio
                    .Dolares = Item.Dolares
                End With

                Lista.Add(Detalle)
            Next

            For Each Item As DTCxCMovimientoLinea In pTabla.ListaMovimientos
                DetalleMov = New TCxCMovimientoLinea

                With DetalleMov
                    .Emp_Id = Item.Emp_Id
                    .Tipo_Id = Item.Tipo_Id
                    .Mov_Id = Item.Mov_Id
                    .Monto = Item.Monto
                End With

                ListaMov.Add(DetalleMov)
            Next


            With CxCMovimiento
                .Emp_Id = pTabla.Emp_Id
                .Tipo_Id = pTabla.Tipo_Id
                .Mov_Id = pTabla.Mov_Id
                .Cliente_Id = pTabla.Cliente_Id
                .Referencia = pTabla.Referencia
                .Fecha = pTabla.Fecha
                .FechaRecibido = pTabla.FechaRecibido
                .FechaDocumento = pTabla.FechaDocumento
                .FechaVencimiento = pTabla.FechaVencimiento
                .Moneda = pTabla.Moneda
                .Monto = pTabla.Monto
                .Saldo = pTabla.Saldo
                .TipoCambio = pTabla.TipoCambio
                .Dolares = pTabla.Dolares
                .Usuario_Id = pTabla.Usuario_Id
                .AplicaMora = pTabla.AplicaMora
                .FechaCalculoMora = pTabla.FechaCalculoMora
                .Batch_Id = pTabla.Batch_Id
                .Caja_Id = pTabla.Caja_Id
                .Cierre_Id = pTabla.Cierre_Id
                .UltimaModificacion = pTabla.UltimaModificacion
                .ListaPagos = Lista
                .ListaMovimientos = ListaMov
                .GeneraNotaCredito = pTabla.GeneraNotaCredito
                .MontoNotaCredito = pTabla.MontoNotaCredito
                .MAC_Address = pTabla.MAC_Address
                .GeneraAsiento = pTabla.GeneraAsiento
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CxCMovimiento.Insert)
                    Resultado.Datos = CxCMovimiento.Consecutivos
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CxCMovimiento.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CxCMovimiento.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CxCMovimiento.List)
                    Resultado.Datos = CxCMovimiento.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CxCMovimiento.ListKey)
                    Resultado.Datos = CxCMovimiento.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CxCMovimiento.LoadComboBox)
                    Resultado.Datos = CxCMovimiento.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CxCMovimiento.ListMant(pCriterio))
                    Resultado.Datos = CxCMovimiento.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CxCMovimiento.NextOne)
                    Resultado.Datos = CxCMovimiento.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CxCMovimiento.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CxCMovimientoMantSD(pTabla As DTCxCMovimiento, pOperacion As EnumOperacionMant, pCriterio As String, ByVal pFacturaEncabezado As TFacturaEncabezado) As TResultado Implements ISDFinancial.CxCMovimientoMantSD
        Dim Resultado As New TResultado
        Dim CxCMovimiento As New TCxCMovimiento(pTabla.Emp_Id)
        Dim Detalle As TCxCMovimientoPago
        Dim Lista As New List(Of TCxCMovimientoPago)
        Dim DetalleMov As TCxCMovimientoLinea
        Dim ListaMov As New List(Of TCxCMovimientoLinea)
        Try


            For Each Item As DTCxCMovimientoPago In pTabla.ListaPagos
                Detalle = New TCxCMovimientoPago(pTabla.Emp_Id)

                With Detalle
                    .Emp_Id = Item.Emp_Id
                    .Caja_Id = Item.Caja_Id
                    .Cierre_Id = Item.Cierre_Id
                    .TipoPago_Id = Item.TipoPago_Id
                    .Monto = Item.Monto
                    .Banco_Id = Item.Banco_Id
                    .Cuenta = Item.Cuenta
                    .ChequeNumero = Item.ChequeNumero
                    .ChequeFecha = Item.ChequeFecha
                    .DepositoNumero = Item.DepositoNumero
                    .DepositoFecha = Item.DepositoFecha
                    .TransferenciaNumero = Item.TransferenciaNumero
                    .Tarjeta_Id = Item.Tarjeta_Id
                    .TarjetaNumero = Item.TarjetaNumero
                    .TarjetaAutorizacion = Item.TarjetaAutorizacion
                    .Moneda = Item.Moneda
                    .TipoCambio = Item.TipoCambio
                    .Dolares = Item.Dolares
                End With

                Lista.Add(Detalle)
            Next

            For Each Item As DTCxCMovimientoLinea In pTabla.ListaMovimientos
                DetalleMov = New TCxCMovimientoLinea

                With DetalleMov
                    .Emp_Id = Item.Emp_Id
                    .Tipo_Id = Item.Tipo_Id
                    .Mov_Id = Item.Mov_Id
                    .Monto = Item.Monto
                End With

                ListaMov.Add(DetalleMov)
            Next


            With CxCMovimiento
                .Emp_Id = pTabla.Emp_Id
                .Tipo_Id = pTabla.Tipo_Id
                .Mov_Id = pTabla.Mov_Id
                .Cliente_Id = pTabla.Cliente_Id
                .Referencia = pTabla.Referencia
                .Fecha = pTabla.Fecha
                .FechaRecibido = pTabla.FechaRecibido
                .FechaDocumento = pTabla.FechaDocumento
                .FechaVencimiento = pTabla.FechaVencimiento
                .Moneda = pTabla.Moneda
                .Monto = pTabla.Monto
                .Saldo = pTabla.Saldo
                .TipoCambio = pTabla.TipoCambio
                .Dolares = pTabla.Dolares
                .Usuario_Id = pTabla.Usuario_Id
                .AplicaMora = pTabla.AplicaMora
                .FechaCalculoMora = pTabla.FechaCalculoMora
                .Batch_Id = pTabla.Batch_Id
                .Caja_Id = pTabla.Caja_Id
                .Cierre_Id = pTabla.Cierre_Id
                .UltimaModificacion = pTabla.UltimaModificacion
                .ListaPagos = Lista
                .ListaMovimientos = ListaMov
                .GeneraNotaCredito = pTabla.GeneraNotaCredito
                .MontoNotaCredito = pTabla.MontoNotaCredito
                .MAC_Address = pTabla.MAC_Address
                .GeneraAsiento = pTabla.GeneraAsiento
                .FacturaEncabezado = pFacturaEncabezado
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CxCMovimiento.Insert)
                    Resultado.Datos = CxCMovimiento.Consecutivos
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CxCMovimiento.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CxCMovimiento.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CxCMovimiento.List)
                    Resultado.Datos = CxCMovimiento.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CxCMovimiento.ListKey)
                    Resultado.Datos = CxCMovimiento.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CxCMovimiento.LoadComboBox)
                    Resultado.Datos = CxCMovimiento.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CxCMovimiento.ListMant(pCriterio))
                    Resultado.Datos = CxCMovimiento.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CxCMovimiento.NextOne)
                    Resultado.Datos = CxCMovimiento.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CxCMovimiento.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = "CxC -> " & ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CxCMovimientoAplicaMant(pTabla As DTCxCMovimientoAplica, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CxCMovimientoAplicaMant
        Dim Resultado As New TResultado
        Dim CxCMovimientoAplica As New TCxCMovimientoAplica(pTabla.Emp_Id)

        Try
            With CxCMovimientoAplica
                .Emp_Id = pTabla.Emp_Id
                .Tipo_Id = pTabla.Tipo_Id
                .Mov_Id = pTabla.Mov_Id
                .Aplica_Id = pTabla.Aplica_Id
                .TipoAplica_Id = pTabla.TipoAplica_Id
                .MovAplica_Id = pTabla.MovAplica_Id
                .Fecha = pTabla.Fecha
                .Monto = pTabla.Monto
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CxCMovimientoAplica.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CxCMovimientoAplica.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CxCMovimientoAplica.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CxCMovimientoAplica.List)
                    Resultado.Datos = CxCMovimientoAplica.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CxCMovimientoAplica.ListKey)
                    Resultado.Datos = CxCMovimientoAplica.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CxCMovimientoAplica.LoadComboBox)
                    Resultado.Datos = CxCMovimientoAplica.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CxCMovimientoAplica.ListMant(pCriterio))
                    Resultado.Datos = CxCMovimientoAplica.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CxCMovimientoAplica.NextOne)
                    Resultado.Datos = CxCMovimientoAplica.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CxCMovimientoAplica.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CxCMovimientoPagoMant(pTabla As DTCxCMovimientoPago, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CxCMovimientoPagoMant
        Dim Resultado As New TResultado
        Dim CxCMovimientoPago As New TCxCMovimientoPago(pTabla.Emp_Id)

        Try
            With CxCMovimientoPago
                .Emp_Id = pTabla.Emp_Id
                .Tipo_Id = pTabla.Tipo_Id
                .Mov_Id = pTabla.Mov_Id
                .Pago_Id = pTabla.Pago_Id
                .Caja_Id = pTabla.Caja_Id
                .Cierre_Id = pTabla.Cierre_Id
                .TipoPago_Id = pTabla.TipoPago_Id
                .Monto = pTabla.Monto
                .Banco_Id = pTabla.Banco_Id
                .Cuenta = pTabla.Cuenta
                .ChequeNumero = pTabla.ChequeNumero
                .ChequeFecha = pTabla.ChequeFecha
                .DepositoNumero = pTabla.DepositoNumero
                .DepositoFecha = pTabla.DepositoFecha
                .TransferenciaNumero = pTabla.TransferenciaNumero
                .Tarjeta_Id = pTabla.Tarjeta_Id
                .TarjetaNumero = pTabla.TarjetaNumero
                .TarjetaAutorizacion = pTabla.TarjetaAutorizacion
                .Moneda = pTabla.Moneda
                .TipoCambio = pTabla.TipoCambio
                .Dolares = pTabla.Dolares
                .Fecha = pTabla.Fecha
                .Batch_Id = pTabla.Batch_Id
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CxCMovimientoPago.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CxCMovimientoPago.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CxCMovimientoPago.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CxCMovimientoPago.List)
                    Resultado.Datos = CxCMovimientoPago.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CxCMovimientoPago.ListKey)
                    Resultado.Datos = CxCMovimientoPago.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CxCMovimientoPago.LoadComboBox)
                    Resultado.Datos = CxCMovimientoPago.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CxCMovimientoPago.ListMant(pCriterio))
                    Resultado.Datos = CxCMovimientoPago.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CxCMovimientoPago.NextOne)
                    Resultado.Datos = CxCMovimientoPago.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CxCMovimientoPago.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CxCMovimientoTipoMant(pTabla As DTCxCMovimientoTipo, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CxCMovimientoTipoMant
        Dim Resultado As New TResultado
        Dim CxCMovimientoTipo As New TCxCMovimientoTipo(pTabla.Emp_Id)

        Try
            With CxCMovimientoTipo
                .Emp_Id = pTabla.Emp_Id
                .Tipo_Id = pTabla.Tipo_Id
                .Nombre = pTabla.Nombre
                .IncrementaSaldo = pTabla.IncrementaSaldo
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CxCMovimientoTipo.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CxCMovimientoTipo.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CxCMovimientoTipo.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CxCMovimientoTipo.List)
                    Resultado.Datos = CxCMovimientoTipo.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CxCMovimientoTipo.ListKey)
                    Resultado.Datos = CxCMovimientoTipo.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CxCMovimientoTipo.LoadComboBox)
                    Resultado.Datos = CxCMovimientoTipo.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CxCMovimientoTipo.ListMant(pCriterio))
                    Resultado.Datos = CxCMovimientoTipo.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CxCMovimientoTipo.NextOne)
                    Resultado.Datos = CxCMovimientoTipo.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CxCMovimientoTipo.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CxPMovimientoMant(pTabla As DTCxPMovimiento, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CxPMovimientoMant
        Dim Resultado As New TResultado
        Dim CxPMovimiento As New TCxPMovimiento(pTabla.Emp_Id)
        Dim AuxAsientoEncabezado As New TAuxAsientoEncabezado(pTabla.AsientoEncabezado.Emp_Id)
        Dim Detalle As TAuxAsientoDetalle
        Dim Lista As New List(Of TAuxAsientoDetalle)

        Try
            For Each Item As DTAuxAsientoDetalle In pTabla.AsientoEncabezado.ListaDetalle
                Detalle = New TAuxAsientoDetalle(pTabla.Emp_Id)

                With Detalle
                    .Emp_Id = Item.Emp_Id
                    .Asiento_Id = Item.Asiento_Id
                    .Linea_Id = Item.Linea_Id
                    .Fecha = Item.Fecha
                    .Moneda = Item.Moneda
                    .CC_Id = Item.CC_Id
                    .Cuenta_Id = Item.Cuenta_Id
                    .Tipo = Item.Tipo
                    .Monto = Item.Monto
                    .MontoDolares = Item.MontoDolares
                    .TipoCambio = Item.TipoCambio
                    .Referencia = Item.Referencia
                    .Descripcion = Item.Descripcion
                End With

                Lista.Add(Detalle)
            Next

            With AuxAsientoEncabezado
                .Emp_Id = pTabla.AsientoEncabezado.Emp_Id
                .Asiento_Id = pTabla.AsientoEncabezado.Asiento_Id
                .Annio = pTabla.AsientoEncabezado.Annio
                .Mes = pTabla.AsientoEncabezado.Mes
                .Fecha = pTabla.AsientoEncabezado.Fecha
                .Tipo_Id = pTabla.AsientoEncabezado.Tipo_Id
                .Comentario = pTabla.AsientoEncabezado.Comentario
                .Debitos = pTabla.AsientoEncabezado.Debitos
                .Creditos = pTabla.AsientoEncabezado.Creditos
                .Usuario_Id = pTabla.AsientoEncabezado.Usuario_Id
                .Origen_Id = pTabla.AsientoEncabezado.Origen_Id
                .MAC_Address = pTabla.AsientoEncabezado.MAC_Address
                .ListaDetalle = Lista
            End With

            With CxPMovimiento
                .Emp_Id = pTabla.Emp_Id
                .Tipo_Id = pTabla.Tipo_Id
                .Mov_Id = pTabla.Mov_Id
                .Prov_Id = pTabla.Prov_Id
                .Estado_Id = pTabla.Estado_Id
                .Referencia = pTabla.Referencia
                .Fecha = pTabla.Fecha
                .FechaRecibido = pTabla.FechaRecibido
                .FechaDocumento = pTabla.FechaDocumento
                .FechaVencimiento = pTabla.FechaVencimiento
                .Moneda = pTabla.Moneda
                .Monto = pTabla.Monto
                .Saldo = pTabla.Saldo
                .TipoCambio = pTabla.TipoCambio
                .Dolares = pTabla.Dolares
                .Usuario_Id = pTabla.Usuario_Id
                .Batch_Id = pTabla.Batch_Id
                .UltimaModificacion = pTabla.UltimaModificacion
                .GeneraAsiento = pTabla.GeneraAsiento
                .AsientoEncabezado = AuxAsientoEncabezado

            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CxPMovimiento.Insert)
                    Resultado.Valor = CxPMovimiento.Mov_Id
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CxPMovimiento.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CxPMovimiento.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CxPMovimiento.List)
                    Resultado.Datos = CxPMovimiento.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CxPMovimiento.ListKey)
                    Resultado.Datos = CxPMovimiento.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CxPMovimiento.LoadComboBox)
                    Resultado.Datos = CxPMovimiento.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CxPMovimiento.ListMant(pCriterio))
                    Resultado.Datos = CxPMovimiento.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CxPMovimiento.NextOne)
                    Resultado.Datos = CxPMovimiento.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CxPMovimiento.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CxPMovimientoAplicaMant(pTabla As DTCxPMovimientoAplica, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CxPMovimientoAplicaMant
        Dim Resultado As New TResultado
        Dim CxPMovimientoAplica As New TCxPMovimientoAplica(pTabla.Emp_Id)

        Try
            With CxPMovimientoAplica
                .Emp_Id = pTabla.Emp_Id
                .Tipo_Id = pTabla.Tipo_Id
                .Mov_Id = pTabla.Mov_Id
                .Aplica_Id = pTabla.Aplica_Id
                .TipoAplica_Id = pTabla.TipoAplica_Id
                .MovAplica_Id = pTabla.MovAplica_Id
                .Fecha = pTabla.Fecha
                .Monto = pTabla.Monto
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CxPMovimientoAplica.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CxPMovimientoAplica.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CxPMovimientoAplica.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CxPMovimientoAplica.List)
                    Resultado.Datos = CxPMovimientoAplica.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CxPMovimientoAplica.ListKey)
                    Resultado.Datos = CxPMovimientoAplica.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CxPMovimientoAplica.LoadComboBox)
                    Resultado.Datos = CxPMovimientoAplica.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CxPMovimientoAplica.ListMant(pCriterio))
                    Resultado.Datos = CxPMovimientoAplica.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CxPMovimientoAplica.NextOne)
                    Resultado.Datos = CxPMovimientoAplica.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CxPMovimientoAplica.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CxPMovimientoPagoMant(pTabla As DTCxPMovimientoPago, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CxPMovimientoPagoMant
        Dim Resultado As New TResultado
        Dim CxPMovimientoPago As New TCxPMovimientoPago(pTabla.Emp_Id)

        Try
            With CxPMovimientoPago
                .Emp_Id = pTabla.Emp_Id
                .Tipo_Id = pTabla.Tipo_Id
                .Mov_Id = pTabla.Mov_Id
                .Pago_Id = pTabla.Pago_Id
                .TipoPago_Id = pTabla.TipoPago_Id
                .Monto = pTabla.Monto
                .Banco_Id = pTabla.Banco_Id
                .ChequeNumero = pTabla.ChequeNumero
                .ChequeFecha = pTabla.ChequeFecha
                .DepositoNumero = pTabla.DepositoNumero
                .DepositoFecha = pTabla.DepositoFecha
                .TransferenciaNumero = pTabla.TransferenciaNumero
                .Tarjeta_Id = pTabla.Tarjeta_Id
                .TarjetaNumero = pTabla.TarjetaNumero
                .TarjetaAutorizacion = pTabla.TarjetaAutorizacion
                .Moneda = pTabla.Moneda
                .TipoCambio = pTabla.TipoCambio
                .Dolares = pTabla.Dolares
                .Fecha = pTabla.Fecha
                .Batch_Id = pTabla.Batch_Id
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CxPMovimientoPago.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CxPMovimientoPago.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CxPMovimientoPago.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CxPMovimientoPago.List)
                    Resultado.Datos = CxPMovimientoPago.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CxPMovimientoPago.ListKey)
                    Resultado.Datos = CxPMovimientoPago.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CxPMovimientoPago.LoadComboBox)
                    Resultado.Datos = CxPMovimientoPago.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CxPMovimientoPago.ListMant(pCriterio))
                    Resultado.Datos = CxPMovimientoPago.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CxPMovimientoPago.NextOne)
                    Resultado.Datos = CxPMovimientoPago.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CxPMovimientoPago.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CxPMovimientoTipoMant(pTabla As DTCxPMovimientoTipo, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CxPMovimientoTipoMant
        Dim Resultado As New TResultado
        Dim CxPMovimientoTipo As New TCxPMovimientoTipo(pTabla.Emp_Id)

        Try
            With CxPMovimientoTipo
                .Emp_Id = pTabla.Emp_Id
                .Tipo_Id = pTabla.Tipo_Id
                .Nombre = pTabla.Nombre
                .IncrementaSaldo = pTabla.IncrementaSaldo
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CxPMovimientoTipo.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CxPMovimientoTipo.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CxPMovimientoTipo.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CxPMovimientoTipo.List)
                    Resultado.Datos = CxPMovimientoTipo.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CxPMovimientoTipo.ListKey)
                    Resultado.Datos = CxPMovimientoTipo.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CxPMovimientoTipo.LoadComboBox)
                    Resultado.Datos = CxPMovimientoTipo.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CxPMovimientoTipo.ListMant(pCriterio))
                    Resultado.Datos = CxPMovimientoTipo.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CxPMovimientoTipo.NextOne)
                    Resultado.Datos = CxPMovimientoTipo.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CxPMovimientoTipo.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CxPSolicitudPagoMant(pTabla As DTCxPSolicitudPago, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CxPSolicitudPagoMant
        Dim Resultado As New TResultado
        Dim CxPSolicitudPago As New TCxPSolicitudPago(pTabla.Emp_Id)
        Dim DetalleMov As TCxPMovimientoLinea
        Dim ListaMov As New List(Of TCxPMovimientoLinea)

        Try
            For Each Item As DTCxPMovimientoLinea In pTabla.ListaMovimientos
                DetalleMov = New TCxPMovimientoLinea

                With DetalleMov
                    .Emp_Id = Item.Emp_Id
                    .Tipo_Id = Item.Tipo_Id
                    .Mov_Id = Item.Mov_Id
                    .Monto = Item.Monto
                    .Moneda = Item.Moneda
                    .Dolares = Item.Dolares
                    .TipoCambio = Item.TipoCambio
                End With

                ListaMov.Add(DetalleMov)
            Next

            With CxPSolicitudPago
                .Emp_Id = pTabla.Emp_Id
                .Solicitud_Id = pTabla.Solicitud_Id
                .Prov_Id = pTabla.Prov_Id
                .Tipo_Id = pTabla.Tipo_Id
                .Mov_Id = pTabla.Mov_Id
                .Fecha = pTabla.Fecha
                .Monto = pTabla.Monto
                .Moneda = pTabla.Moneda
                .TipoCambio = pTabla.TipoCambio
                .Dolares = pTabla.Dolares
                .Usuario_Id = pTabla.Usuario_Id
                .UltimaModificacion = pTabla.UltimaModificacion
                .ListaMovimientos = ListaMov
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CxPSolicitudPago.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CxPSolicitudPago.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CxPSolicitudPago.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CxPSolicitudPago.List)
                    Resultado.Datos = CxPSolicitudPago.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CxPSolicitudPago.ListKey)
                    Resultado.Datos = CxPSolicitudPago.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CxPSolicitudPago.LoadComboBox)
                    Resultado.Datos = CxPSolicitudPago.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CxPSolicitudPago.ListMant(pCriterio))
                    Resultado.Datos = CxPSolicitudPago.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CxPSolicitudPago.NextOne)
                    Resultado.Datos = CxPSolicitudPago.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CxPSolicitudPago.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CxCEntregaDocumentoEncabezadoMant(pTabla As DTCxCEntregaDocumentoEncabezado, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CxCEntregaDocumentoEncabezadoMant
        Dim Resultado As New TResultado
        Dim CxCEntregaDocumentoEncabezado As New TCxCEntregaDocumentoEncabezado(pTabla.Emp_Id)

        Try
            With CxCEntregaDocumentoEncabezado
                .Emp_Id = pTabla.Emp_Id
                .Entrega_Id = pTabla.Entrega_Id
                .Vendedor_Id = pTabla.Vendedor_Id
                .Fecha = pTabla.Fecha
                .Usuario_Id = pTabla.Usuario_Id
                .Activo = pTabla.Activo
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CxCEntregaDocumentoEncabezado.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CxCEntregaDocumentoEncabezado.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CxCEntregaDocumentoEncabezado.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CxCEntregaDocumentoEncabezado.List)
                    Resultado.Datos = CxCEntregaDocumentoEncabezado.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CxCEntregaDocumentoEncabezado.ListKey)
                    Resultado.Datos = CxCEntregaDocumentoEncabezado.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CxCEntregaDocumentoEncabezado.LoadComboBox)
                    Resultado.Datos = CxCEntregaDocumentoEncabezado.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CxCEntregaDocumentoEncabezado.ListMant(pCriterio))
                    Resultado.Datos = CxCEntregaDocumentoEncabezado.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CxCEntregaDocumentoEncabezado.NextOne)
                    Resultado.Datos = CxCEntregaDocumentoEncabezado.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CxCEntregaDocumentoEncabezado.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function CxCEntregaDocumentoDetalleMant(pTabla As DTCxCEntregaDocumentoDetalle, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.CxCEntregaDocumentoDetalleMant
        Dim Resultado As New TResultado
        Dim CxCEntregaDocumentoDetalle As New TCxCEntregaDocumentoDetalle(pTabla.Emp_Id)

        Try
            With CxCEntregaDocumentoDetalle
                .Emp_Id = pTabla.Emp_Id
                .Entrega_Id = pTabla.Entrega_Id
                .Doc_Id = pTabla.Doc_Id
                .Tipo_Id = pTabla.Tipo_Id
                .Mov_Id = pTabla.Mov_Id
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(CxCEntregaDocumentoDetalle.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(CxCEntregaDocumentoDetalle.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(CxCEntregaDocumentoDetalle.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(CxCEntregaDocumentoDetalle.List)
                    Resultado.Datos = CxCEntregaDocumentoDetalle.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(CxCEntregaDocumentoDetalle.ListKey)
                    Resultado.Datos = CxCEntregaDocumentoDetalle.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(CxCEntregaDocumentoDetalle.LoadComboBox)
                    Resultado.Datos = CxCEntregaDocumentoDetalle.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(CxCEntregaDocumentoDetalle.ListMant(pCriterio))
                    Resultado.Datos = CxCEntregaDocumentoDetalle.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(CxCEntregaDocumentoDetalle.NextOne)
                    Resultado.Datos = CxCEntregaDocumentoDetalle.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = CxCEntregaDocumentoDetalle.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function


#End Region
#Region "D"
#End Region
#Region "E"
    Public Function EmpresaMant(pTabla As DTEmpresa, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.EmpresaMant
        Dim Resultado As New TResultado
        Dim Empresa As New TEmpresa(pTabla.Emp_Id)

        Try
            With Empresa
                .Emp_Id = pTabla.Emp_Id
                .Nombre = pTabla.Nombre
                .Cedula = pTabla.Cedula
                .Telefono = pTabla.Telefono
                .Fax = pTabla.Fax
                .Email = pTabla.Email
                .Direccion = pTabla.Direccion
                .DireccionWeb = pTabla.DireccionWeb
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
                .Logo = pTabla.Logo
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(Empresa.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(Empresa.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(Empresa.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(Empresa.List)
                    Resultado.Datos = Empresa.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(Empresa.ListKey)
                    Resultado.Datos = Empresa.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(Empresa.LoadComboBox)
                    Resultado.Datos = Empresa.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(Empresa.ListMant(pCriterio))
                    Resultado.Datos = Empresa.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(Empresa.NextOne)
                    Resultado.Datos = Empresa.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = Empresa.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function EmpresaCuentaMant(pTabla As DTEmpresaCuenta, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.EmpresaCuentaMant
        Dim Resultado As New TResultado
        Dim EmpresaCuenta As New TEmpresaCuenta(pTabla.Emp_Id)

        Try
            With EmpresaCuenta
                .Emp_Id = pTabla.Emp_Id
                .Cuenta_Id = pTabla.Cuenta_Id
                .Banco_Id = pTabla.Banco_Id
                .Cuenta = pTabla.Cuenta
                .Moneda = pTabla.Moneda
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(EmpresaCuenta.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(EmpresaCuenta.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(EmpresaCuenta.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(EmpresaCuenta.List)
                    Resultado.Datos = EmpresaCuenta.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(EmpresaCuenta.ListKey)
                    Resultado.Datos = EmpresaCuenta.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(EmpresaCuenta.LoadComboBox)
                    Resultado.Datos = EmpresaCuenta.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(EmpresaCuenta.ListMant(pCriterio))
                    Resultado.Datos = EmpresaCuenta.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(EmpresaCuenta.NextOne)
                    Resultado.Datos = EmpresaCuenta.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = EmpresaCuenta.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function EmpresaParametroMant(pTabla As DTEmpresaParametro, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.EmpresaParametroMant
        Dim Resultado As New TResultado
        Dim EmpresaParametro As New TEmpresaParametro(pTabla.Emp_Id)

        Try
            With EmpresaParametro
                .Emp_Id = pTabla.Emp_Id
                .ProcesoAnnio = pTabla.ProcesoAnnio
                .ProcesoMes = pTabla.ProcesoMes
                .MesCierreFiscal = pTabla.MesCierreFiscal
                .CuentaResultadoPeriodo = pTabla.CuentaResultadoPeriodo
                .DiasCredito = pTabla.DiasCredito
                .PorcMora = pTabla.PorcMora
                .DiasGraciaMora = pTabla.DiasGraciaMora
                .AplicaMora = pTabla.AplicaMora
                .CuentaIngresoXDiferencial = pTabla.CuentaIngresoXDiferencial
                .CuentaGastoXDiferencial = pTabla.CuentaGastoXDiferencial
                .CuentaRedondeo = pTabla.CuentaRedondeo
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(EmpresaParametro.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(EmpresaParametro.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(EmpresaParametro.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(EmpresaParametro.List)
                    Resultado.Datos = EmpresaParametro.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(EmpresaParametro.ListKey)
                    Resultado.Datos = EmpresaParametro.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(EmpresaParametro.LoadComboBox)
                    Resultado.Datos = EmpresaParametro.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(EmpresaParametro.ListMant(pCriterio))
                    Resultado.Datos = EmpresaParametro.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(EmpresaParametro.NextOne)
                    Resultado.Datos = EmpresaParametro.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = EmpresaParametro.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function ExecuteQuery(pQuery As String, Optional ByVal pCnStr As String = "") As TResultado Implements ISDFinancial.ExecuteQuery
        Dim Resultado As New TResultado
        Dim SQL As ExecuteSQL

        Try
            If pCnStr.Equals(String.Empty) Then
                SQL = New ExecuteSQL
            Else
                SQL = New ExecuteSQL(pCnStr)
            End If

            VerificaMensaje(SQL.ExecuteQuery(pQuery))

            With Resultado
                .RowsAffected = SQL.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function
#End Region
#Region "F"
    Public Function FacturaEncabezadoCxCMant(pTabla As DTFacturaEncabezadoCxC, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.FacturaEncabezadoCxCMant
        Dim Resultado As New TResultado
        Dim FacturaEncabezadoCxC As New TFacturaEncabezadoCxC(pTabla.Emp_Id)

        Try
            With FacturaEncabezadoCxC
                .Emp_Id = pTabla.Emp_Id
                .Suc_Id = pTabla.Suc_Id
                .Caja_Id = pTabla.Caja_Id
                .TipoDoc_Id = pTabla.TipoDoc_Id
                .Documento_Id = pTabla.Documento_Id
                .Tipo_Id = pTabla.Tipo_Id
                .Mov_Id = pTabla.Mov_Id
                .Fecha = pTabla.Fecha
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(FacturaEncabezadoCxC.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(FacturaEncabezadoCxC.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(FacturaEncabezadoCxC.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(FacturaEncabezadoCxC.List)
                    Resultado.Datos = FacturaEncabezadoCxC.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(FacturaEncabezadoCxC.ListKey)
                    Resultado.Datos = FacturaEncabezadoCxC.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(FacturaEncabezadoCxC.LoadComboBox)
                    Resultado.Datos = FacturaEncabezadoCxC.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(FacturaEncabezadoCxC.ListMant(pCriterio))
                    Resultado.Datos = FacturaEncabezadoCxC.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(FacturaEncabezadoCxC.NextOne)
                    Resultado.Datos = FacturaEncabezadoCxC.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = FacturaEncabezadoCxC.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function
#End Region
#Region "G"
    Public Function GrupoMant(pTabla As DTGrupo, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.GrupoMant
        Dim Resultado As New TResultado
        Dim Grupo As New TGrupo(pTabla.Emp_Id)

        Try
            With Grupo
                .Emp_Id = pTabla.Emp_Id
                .Grupo_Id = pTabla.Grupo_Id
                .Nombre = pTabla.Nombre
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(Grupo.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(Grupo.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(Grupo.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(Grupo.List)
                    Resultado.Datos = Grupo.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(Grupo.ListKey)
                    Resultado.Datos = Grupo.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(Grupo.LoadComboBox)
                    Resultado.Datos = Grupo.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(Grupo.ListMant(pCriterio))
                    Resultado.Datos = Grupo.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(Grupo.NextOne)
                    Resultado.Datos = Grupo.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = Grupo.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function GrupoMenuMant(pTabla As DTGrupoMenu, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.GrupoMenuMant
        Dim Resultado As New TResultado
        Dim GrupoMenu As New TGrupoMenu(pTabla.Emp_Id)

        Try
            With GrupoMenu
                .Emp_Id = pTabla.Emp_Id
                .Grupo_Id = pTabla.Grupo_Id
                .Modulo_Id = pTabla.Modulo_Id
                .Menu_Id = pTabla.Menu_Id
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(GrupoMenu.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(GrupoMenu.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(GrupoMenu.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(GrupoMenu.List)
                    Resultado.Datos = GrupoMenu.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(GrupoMenu.ListKey)
                    Resultado.Datos = GrupoMenu.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(GrupoMenu.LoadComboBox)
                    Resultado.Datos = GrupoMenu.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(GrupoMenu.ListMant(pCriterio))
                    Resultado.Datos = GrupoMenu.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(GrupoMenu.NextOne)
                    Resultado.Datos = GrupoMenu.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = GrupoMenu.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function GetIp(pIp As String) As TResultado Implements ISDFinancial.GetIp
        Dim Resultado As New TResultado
        Try

            Resultado.Valor = GetIPV4()

            Resultado.ErrorCode = "00"
        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try
        Return Resultado
    End Function
#End Region
#Region "M"
    Public Function MaquinaConfiguracionMant(pTabla As DTMaquinaConfiguracion, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.MaquinaConfiguracionMant
        Dim Resultado As New TResultado
        Dim MaquinaConfiguracion As New TMaquinaConfiguracion

        Try
            With MaquinaConfiguracion
                .MAC_Address = pTabla.MAC_Address
                .Nombre = pTabla.Nombre
                .Caja_Id = pTabla.Caja_Id
                .ClienteDefault = pTabla.ClienteDefault
                .ComPort = pTabla.ComPort
                .ConfirmaImpresionFactura = pTabla.ConfirmaImpresionFactura
                .Emp_Id = pTabla.Emp_Id
                .FacturaContadoSolicitaCliente = pTabla.FacturaContadoSolicitaCliente
                .ImprimeCodigoArticulo = pTabla.ImprimeCodigoArticulo
                .ImprimePrefactura = pTabla.ImprimePrefactura
                .Interfaz = pTabla.Interfaz
                .ParallePort = pTabla.ParallePort
                .PrefacturaTipoEntrega = pTabla.PrefacturaTipoEntrega
                .PrinterName = pTabla.PrinterName
                .PrintLocation = pTabla.PrintLocation
                .URLTipoCambio = pTabla.URLTipoCambio
                .FechaIngreso = pTabla.FechaIngreso
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(MaquinaConfiguracion.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(MaquinaConfiguracion.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(MaquinaConfiguracion.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(MaquinaConfiguracion.List)
                    Resultado.Datos = MaquinaConfiguracion.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(MaquinaConfiguracion.ListKey)
                    Resultado.Datos = MaquinaConfiguracion.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(MaquinaConfiguracion.LoadComboBox)
                    Resultado.Datos = MaquinaConfiguracion.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(MaquinaConfiguracion.ListMant(pCriterio))
                    Resultado.Datos = MaquinaConfiguracion.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(MaquinaConfiguracion.NextOne)
                    Resultado.Datos = MaquinaConfiguracion.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = MaquinaConfiguracion.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function MenuMant(pTabla As DTMenu, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.MenuMant
        Dim Resultado As New TResultado
        Dim Menu As New TMenu()

        Try
            With Menu
                .Modulo_Id = pTabla.Modulo_Id
                .Menu_Id = pTabla.Menu_Id
                .MenuPadre_Id = pTabla.MenuPadre_Id
                .Nombre = pTabla.Nombre
                .Orden = pTabla.Orden
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(Menu.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(Menu.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(Menu.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(Menu.List)
                    Resultado.Datos = Menu.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(Menu.ListKey)
                    Resultado.Datos = Menu.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(Menu.LoadComboBox)
                    Resultado.Datos = Menu.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(Menu.ListMant(pCriterio))
                    Resultado.Datos = Menu.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(Menu.NextOne)
                    Resultado.Datos = Menu.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = Menu.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function ModuloMant(pTabla As DTModulo, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.ModuloMant
        Dim Resultado As New TResultado
        Dim Modulo As New TModulo()

        Try
            With Modulo
                .Modulo_Id = pTabla.Modulo_Id
                .Nombre = pTabla.Nombre
                .Major = pTabla.Major
                .Menor = pTabla.Menor
                .Bug = pTabla.Bug
                .Build = pTabla.Build
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(Modulo.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(Modulo.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(Modulo.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(Modulo.List)
                    Resultado.Datos = Modulo.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(Modulo.ListKey)
                    Resultado.Datos = Modulo.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(Modulo.LoadComboBox)
                    Resultado.Datos = Modulo.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(Modulo.ListMant(pCriterio))
                    Resultado.Datos = Modulo.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(Modulo.NextOne)
                    Resultado.Datos = Modulo.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = Modulo.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function
#End Region
#Region "P"
    Public Function PermisoMant(pTabla As DTPermiso, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.PermisoMant
        Dim Resultado As New TResultado
        Dim Permiso As New TPermiso()

        Try
            With Permiso
                .Permiso_Id = pTabla.Permiso_Id
                .Modulo_Id = pTabla.Modulo_Id
                .Nombre = pTabla.Nombre
                .Activo = pTabla.Activo
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(Permiso.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(Permiso.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(Permiso.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(Permiso.List)
                    Resultado.Datos = Permiso.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(Permiso.ListKey)
                    Resultado.Datos = Permiso.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(Permiso.LoadComboBox)
                    Resultado.Datos = Permiso.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(Permiso.ListMant(pCriterio))
                    Resultado.Datos = Permiso.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(Permiso.NextOne)
                    Resultado.Datos = Permiso.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = Permiso.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function PermisoBitacoraMant(pTabla As DTPermisoBitacora, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.PermisoBitacoraMant
        Dim Resultado As New TResultado
        Dim PermisoBitacora As New TPermisoBitacora(pTabla.Emp_Id)

        Try
            With PermisoBitacora
                .Bitacora_Id = pTabla.Bitacora_Id
                .Emp_Id = pTabla.Emp_Id
                .Permiso_Id = pTabla.Permiso_Id
                .Usuario_Id = pTabla.Usuario_Id
                .Fecha = pTabla.Fecha
                .Observacion = pTabla.Observacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(PermisoBitacora.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(PermisoBitacora.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(PermisoBitacora.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(PermisoBitacora.List)
                    Resultado.Datos = PermisoBitacora.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(PermisoBitacora.ListKey)
                    Resultado.Datos = PermisoBitacora.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(PermisoBitacora.LoadComboBox)
                    Resultado.Datos = PermisoBitacora.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(PermisoBitacora.ListMant(pCriterio))
                    Resultado.Datos = PermisoBitacora.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(PermisoBitacora.NextOne)
                    Resultado.Datos = PermisoBitacora.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = PermisoBitacora.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function ProveedorMant(pTabla As DTProveedor, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.ProveedorMant
        Dim Resultado As New TResultado
        Dim Proveedor As New TProveedor(pTabla.Emp_Id)

        Try
            With Proveedor
                .Emp_Id = pTabla.Emp_Id
                .Prov_Id = pTabla.Prov_Id
                .TipoIdentificacion_Id = pTabla.TipoIdentificacion_Id
                .Identificacion = pTabla.Identificacion
                .Nombre = pTabla.Nombre
                .Telefono1 = pTabla.Telefono1
                .Telefono2 = pTabla.Telefono2
                .Email = pTabla.Email
                .Direccion = pTabla.Direccion
                .Debitos = pTabla.Debitos
                .Creditos = pTabla.Creditos
                .Saldo = pTabla.Saldo
                .CxP_Colones = pTabla.CxP_Colones
                .CxP_Dolares = pTabla.CxP_Dolares
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
                .DiasCredito = pTabla.DiasCredito
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(Proveedor.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(Proveedor.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(Proveedor.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(Proveedor.List)
                    Resultado.Datos = Proveedor.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(Proveedor.ListKey)
                    Resultado.Datos = Proveedor.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(Proveedor.LoadComboBox)
                    Resultado.Datos = Proveedor.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(Proveedor.ListMant(pCriterio))
                    Resultado.Datos = Proveedor.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(Proveedor.NextOne)
                    Resultado.Datos = Proveedor.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = Proveedor.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function ProveedorCuentaMant(pTabla As DTProveedorCuenta, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.ProveedorCuentaMant
        Dim Resultado As New TResultado
        Dim ProveedorCuenta As New TProveedorCuenta(pTabla.Emp_Id)

        Try
            With ProveedorCuenta
                .Emp_Id = pTabla.Emp_Id
                .Prov_Id = pTabla.Prov_Id
                .Cuenta_Id = pTabla.Cuenta_Id
                .Banco_Id = pTabla.Banco_Id
                .Cuenta = pTabla.Cuenta
                .Moneda = pTabla.Moneda
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(ProveedorCuenta.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(ProveedorCuenta.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(ProveedorCuenta.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(ProveedorCuenta.List)
                    Resultado.Datos = ProveedorCuenta.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(ProveedorCuenta.ListKey)
                    Resultado.Datos = ProveedorCuenta.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(ProveedorCuenta.LoadComboBox)
                    Resultado.Datos = ProveedorCuenta.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(ProveedorCuenta.ListMant(pCriterio))
                    Resultado.Datos = ProveedorCuenta.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(ProveedorCuenta.NextOne)
                    Resultado.Datos = ProveedorCuenta.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = ProveedorCuenta.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function
#End Region
#Region "S"
    Public Function SelectQuery(pQuery As String, Optional ByVal pCnStr As String = "") As TResultado Implements ISDFinancial.SelectQuery
        Dim Resultado As New TResultado
        Dim SQL As ExecuteSQL

        Try
            If pCnStr.Equals(String.Empty) Then
                SQL = New ExecuteSQL
            Else
                SQL = New ExecuteSQL(pCnStr)
            End If
            VerificaMensaje(SQL.SelectQuery(pQuery))

            With Resultado
                .Datos = SQL.Datos
                .RowsAffected = SQL.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function
#End Region
#Region "T"
    Public Function TipoIdentificacionMant(pTabla As DTTipoIdentificacion, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.TipoIdentificacionMant
        Dim Resultado As New TResultado
        Dim TipoIdentificacion As New TTipoIdentificacion(pTabla.Emp_Id)

        Try
            With TipoIdentificacion
                .Emp_Id = pTabla.Emp_Id
                .TipoIdentificacion_Id = pTabla.TipoIdentificacion_Id
                .Nombre = pTabla.Nombre
                .Activo = pTabla.Activo
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(TipoIdentificacion.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(TipoIdentificacion.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(TipoIdentificacion.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(TipoIdentificacion.List)
                    Resultado.Datos = TipoIdentificacion.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(TipoIdentificacion.ListKey)
                    Resultado.Datos = TipoIdentificacion.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(TipoIdentificacion.LoadComboBox)
                    Resultado.Datos = TipoIdentificacion.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(TipoIdentificacion.ListMant(pCriterio))
                    Resultado.Datos = TipoIdentificacion.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(TipoIdentificacion.NextOne)
                    Resultado.Datos = TipoIdentificacion.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = TipoIdentificacion.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function TarjetaMant(pTabla As DTTarjeta, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.TarjetaMant
        Dim Resultado As New TResultado
        Dim Tarjeta As New TTarjeta(pTabla.Emp_Id)

        Try
            With Tarjeta
                .Emp_Id = pTabla.Emp_Id
                .Tarjeta_Id = pTabla.Tarjeta_Id
                .Nombre = pTabla.Nombre
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(Tarjeta.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(Tarjeta.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(Tarjeta.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(Tarjeta.List)
                    Resultado.Datos = Tarjeta.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(Tarjeta.ListKey)
                    Resultado.Datos = Tarjeta.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(Tarjeta.LoadComboBox)
                    Resultado.Datos = Tarjeta.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(Tarjeta.ListMant(pCriterio))
                    Resultado.Datos = Tarjeta.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(Tarjeta.NextOne)
                    Resultado.Datos = Tarjeta.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = Tarjeta.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function TipoCambioMant(pTabla As DTTipoCambio, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.TipoCambioMant
        Dim Resultado As New TResultado
        Dim TipoCambio As New TTipoCambio

        Try
            With TipoCambio
                .TipoCambio_Id = pTabla.TipoCambio_Id
                .Fecha = pTabla.Fecha
                .Compra = pTabla.Compra
                .Venta = pTabla.Venta
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(TipoCambio.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(TipoCambio.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(TipoCambio.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(TipoCambio.List)
                    Resultado.Datos = TipoCambio.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(TipoCambio.ListKey)
                    Resultado.Datos = TipoCambio.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(TipoCambio.LoadComboBox)
                    Resultado.Datos = TipoCambio.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(TipoCambio.ListMant(pCriterio))
                    Resultado.Datos = TipoCambio.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(TipoCambio.NextOne)
                    Resultado.Datos = TipoCambio.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = TipoCambio.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function TipoPagoMant(pTabla As DTTipoPago, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.TipoPagoMant
        Dim Resultado As New TResultado
        Dim TipoPago As New TTipoPago(pTabla.Emp_Id)

        Try
            With TipoPago
                .Emp_Id = pTabla.Emp_Id
                .TipoPago_Id = pTabla.TipoPago_Id
                .Nombre = pTabla.Nombre
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(TipoPago.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(TipoPago.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(TipoPago.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(TipoPago.List)
                    Resultado.Datos = TipoPago.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(TipoPago.ListKey)
                    Resultado.Datos = TipoPago.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(TipoPago.LoadComboBox)
                    Resultado.Datos = TipoPago.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(TipoPago.ListMant(pCriterio))
                    Resultado.Datos = TipoPago.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(TipoPago.NextOne)
                    Resultado.Datos = TipoPago.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = TipoPago.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function
#End Region
#Region "U"
    Public Function UsuarioMant(pTabla As DTUsuario, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.UsuarioMant
        Dim Resultado As New TResultado
        Dim Usuario As New TUsuario(pTabla.Emp_Id)

        Try
            With Usuario
                .Emp_Id = pTabla.Emp_Id
                .Usuario_Id = pTabla.Usuario_Id
                .Nombre = pTabla.Nombre
                .Password = pTabla.Password
                .Grupo_Id = pTabla.Grupo_Id
                .Activo = pTabla.Activo
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(Usuario.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(Usuario.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(Usuario.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(Usuario.List)
                    Resultado.Datos = Usuario.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(Usuario.ListKey)
                    Resultado.Datos = Usuario.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(Usuario.LoadComboBox)
                    Resultado.Datos = Usuario.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(Usuario.ListMant(pCriterio))
                    Resultado.Datos = Usuario.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(Usuario.NextOne)
                    Resultado.Datos = Usuario.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = Usuario.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function UsuarioCodigoPermisoMant(pTabla As DTUsuarioCodigoPermiso, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.UsuarioCodigoPermisoMant
        Dim Resultado As New TResultado
        Dim UsuarioCodigoPermiso As New TUsuarioCodigoPermiso(pTabla.Emp_Id)

        Try
            With UsuarioCodigoPermiso
                .Emp_Id = pTabla.Emp_Id
                .Usuario_Id = pTabla.Usuario_Id
                .Codigo_Id = pTabla.Codigo_Id
                .Codigo = pTabla.Codigo
                .Activo = pTabla.Activo
                .Fecha = pTabla.Fecha
                .FechaVencimiento = pTabla.FechaVencimiento
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(UsuarioCodigoPermiso.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(UsuarioCodigoPermiso.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(UsuarioCodigoPermiso.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(UsuarioCodigoPermiso.List)
                    Resultado.Datos = UsuarioCodigoPermiso.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(UsuarioCodigoPermiso.ListKey)
                    Resultado.Datos = UsuarioCodigoPermiso.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(UsuarioCodigoPermiso.LoadComboBox)
                    Resultado.Datos = UsuarioCodigoPermiso.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(UsuarioCodigoPermiso.ListMant(pCriterio))
                    Resultado.Datos = UsuarioCodigoPermiso.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(UsuarioCodigoPermiso.NextOne)
                    Resultado.Datos = UsuarioCodigoPermiso.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = UsuarioCodigoPermiso.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function

    Public Function UsuarioPermisoMant(pTabla As DTUsuarioPermiso, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.UsuarioPermisoMant
        Dim Resultado As New TResultado
        Dim UsuarioPermiso As New TUsuarioPermiso(pTabla.Emp_Id)

        Try
            With UsuarioPermiso
                .Emp_Id = pTabla.Emp_Id
                .Usuario_Id = pTabla.Usuario_Id
                .Permiso_Id = pTabla.Permiso_Id
                .Modulo_Id = pTabla.Modulo_Id
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(UsuarioPermiso.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(UsuarioPermiso.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(UsuarioPermiso.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(UsuarioPermiso.List)
                    Resultado.Datos = UsuarioPermiso.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(UsuarioPermiso.ListKey)
                    Resultado.Datos = UsuarioPermiso.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(UsuarioPermiso.LoadComboBox)
                    Resultado.Datos = UsuarioPermiso.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(UsuarioPermiso.ListMant(pCriterio))
                    Resultado.Datos = UsuarioPermiso.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(UsuarioPermiso.NextOne)
                    Resultado.Datos = UsuarioPermiso.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = UsuarioPermiso.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function
#End Region
#Region "V"
    Public Function VerificaCliente(ByVal pEmp_Id As Integer, ByVal pCliente_Id As Integer) As String Implements ISDFinancial.VerificaCliente
        Dim Cliente As New TCliente(pEmp_Id)

        Try
            With Cliente
                .Cliente_Id = pCliente_Id
            End With
            VerificaMensaje(Cliente.ListKey)

            If Cliente.RowsAffected = 0 Then
                VerificaMensaje("No existe un cliente con el código (" & pCliente_Id.ToString & ") en el módulo de CxC")
            End If

            If Not Cliente.Data Is Nothing AndAlso Cliente.Data.Tables(0).Rows.Count > 0 Then
                With Cliente
                    .Emp_Id = Cliente.Data.Tables(0).Rows(0).Item("Emp_Id")
                    .Cliente_Id = Cliente.Data.Tables(0).Rows(0).Item("Cliente_Id")
                    .Nombre = Cliente.Data.Tables(0).Rows(0).Item("Nombre")
                    .Telefono1 = Cliente.Data.Tables(0).Rows(0).Item("Telefono1")
                    .Telefono2 = Cliente.Data.Tables(0).Rows(0).Item("Telefono2")
                    .Email = Cliente.Data.Tables(0).Rows(0).Item("Email")
                    .Direccion = Cliente.Data.Tables(0).Rows(0).Item("Direccion")
                    .Debitos = Cliente.Data.Tables(0).Rows(0).Item("Debitos")
                    .Creditos = Cliente.Data.Tables(0).Rows(0).Item("Creditos")
                    .Saldo = Cliente.Data.Tables(0).Rows(0).Item("Saldo")
                    .DiasCredito = Cliente.Data.Tables(0).Rows(0).Item("DiasCredito")
                    .PorcMora = Cliente.Data.Tables(0).Rows(0).Item("PorcMora")
                    .DiasGraciaMora = Cliente.Data.Tables(0).Rows(0).Item("DiasGraciaMora")
                    .AplicaMora = Cliente.Data.Tables(0).Rows(0).Item("AplicaMora")
                    .Activo = Cliente.Data.Tables(0).Rows(0).Item("Activo")
                    .UltimaModificacion = Cliente.Data.Tables(0).Rows(0).Item("UltimaModificacion")
                End With
            End If

            If Not Cliente.Activo Then
                VerificaMensaje("El cliente " & Cliente.Nombre & " se encuentra inactivo en el módulo de CxC")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Cliente = Nothing
        End Try
    End Function

    Public Function VerificaProveedor(ByVal pEmp_Id As Integer, ByVal pProv_Id As Integer) As String Implements ISDFinancial.VerificaProveedor
        Dim Proveedor As New TProveedor(pEmp_Id)

        Try
            With Proveedor
                .Prov_Id = pProv_Id
            End With
            VerificaMensaje(Proveedor.ListKey)

            If Proveedor.RowsAffected = 0 Then
                VerificaMensaje("No existe un proveedor con el código (" & pProv_Id.ToString & ") en el módulo de CxP")
            End If

            If Not Proveedor.Data Is Nothing AndAlso Proveedor.Data.Tables(0).Rows.Count > 0 Then
                With Proveedor
                    .Emp_Id = Proveedor.Data.Tables(0).Rows(0).Item("Emp_Id")
                    .Prov_Id = Proveedor.Data.Tables(0).Rows(0).Item("Prov_Id")
                    .TipoIdentificacion_Id = Proveedor.Data.Tables(0).Rows(0).Item("TipoIdentificacion_Id")
                    .Identificacion = Proveedor.Data.Tables(0).Rows(0).Item("Identificacion")
                    .Nombre = Proveedor.Data.Tables(0).Rows(0).Item("Nombre")
                    .Telefono1 = Proveedor.Data.Tables(0).Rows(0).Item("Telefono1")
                    .Telefono2 = Proveedor.Data.Tables(0).Rows(0).Item("Telefono2")
                    .Email = Proveedor.Data.Tables(0).Rows(0).Item("Email")
                    .Direccion = Proveedor.Data.Tables(0).Rows(0).Item("Direccion")
                    .Debitos = Proveedor.Data.Tables(0).Rows(0).Item("Debitos")
                    .Creditos = Proveedor.Data.Tables(0).Rows(0).Item("Creditos")
                    .Saldo = Proveedor.Data.Tables(0).Rows(0).Item("Saldo")
                    .Activo = Proveedor.Data.Tables(0).Rows(0).Item("Activo")
                    .UltimaModificacion = Proveedor.Data.Tables(0).Rows(0).Item("UltimaModificacion")
                End With
            End If

            If Not Proveedor.Activo Then
                VerificaMensaje("El proveedor " & Proveedor.Nombre & " se encuentra inactivo en el módulo de CxP")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Proveedor = Nothing
        End Try
    End Function
    Public Function VendedorMant(pTabla As DTVendedor, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado Implements ISDFinancial.VendedorMant
        Dim Resultado As New TResultado
        Dim Vendedor As New TVendedor(pTabla.Emp_Id)

        Try
            With Vendedor
                .Emp_Id = pTabla.Emp_Id
                .Vendedor_Id = pTabla.Vendedor_Id
                .Nombre = pTabla.Nombre
                .Activo = pTabla.Activo
                .Comision = pTabla.Comision
                .UltimaModificacion = pTabla.UltimaModificacion
            End With

            Select Case pOperacion
                Case EnumOperacionMant.Insertar
                    VerificaMensaje(Vendedor.Insert)
                Case EnumOperacionMant.Eliminar
                    VerificaMensaje(Vendedor.Delete)
                Case EnumOperacionMant.Modificar
                    VerificaMensaje(Vendedor.Modify)
                Case EnumOperacionMant.List
                    VerificaMensaje(Vendedor.List)
                    Resultado.Datos = Vendedor.Data.Tables(0)
                Case EnumOperacionMant.ListKey
                    VerificaMensaje(Vendedor.ListKey)
                    Resultado.Datos = Vendedor.Data.Tables(0)
                Case EnumOperacionMant.LoadCombo
                    VerificaMensaje(Vendedor.LoadComboBox)
                    Resultado.Datos = Vendedor.Data.Tables(0)
                Case EnumOperacionMant.ListMant
                    VerificaMensaje(Vendedor.ListMant(pCriterio))
                    Resultado.Datos = Vendedor.Data.Tables(0)
                Case EnumOperacionMant.NextOne
                    VerificaMensaje(Vendedor.NextOne)
                    Resultado.Datos = Vendedor.Data.Tables(0)
            End Select

            With Resultado
                .RowsAffected = Vendedor.RowsAffected
                .ErrorCode = "00"
            End With

        Catch ex As Exception
            With Resultado
                .ErrorCode = "01"
                .ErrorDescription = ex.Message
            End With
        End Try

        Return Resultado
    End Function


#End Region
End Class