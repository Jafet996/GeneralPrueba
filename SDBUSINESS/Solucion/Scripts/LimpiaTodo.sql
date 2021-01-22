delete MovimientoDetalle
delete MovimientoEncabezado
delete CajaCierreDetalle
delete CajaCierreEncabezado
delete FacturaDetalle
delete FacturaEncabezado
delete FacturaPago
update Caja set Cierre_Id = 0, Abierta = 0
update ArticuloBodega set Saldo = 0
delete ArticuloKardex