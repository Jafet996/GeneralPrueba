
GO

/****** Object:  StoredProcedure [dbo].[RptGarantia]    Script Date: 1/25/2021 9:33:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [dbo].[RptGarantia]
(@pEmp_Id smallint
,@pGarantia_Id bigint)

as
begin
  
  select e.Garantia_Id
        ,cast(a.Emp_Id as varchar) + '-' + cast(a.Suc_Id as varchar) + '-' + cast(a.Caja_Id as varchar) + '-' + cast(a.TipoDoc_Id as varchar) + '-' + cast(a.Documento_Id as varchar) as Factura
        ,e.OrdenNumero 
        ,e.FechaInicio 
        ,e.FechaFinal 
        ,d.Nombre ClienteNombre
        ,d.Cedula 
        ,c.Art_Id 
        ,c.Nombre ArticuloNombre
        ,DATEDIFF (MONTH,e.FechaInicio,e.FechaFinal) as Meses
        ,isnull(g.Lote,'--') Lote
        ,isnull(g.Vencimiento,'19000101') LoteFechaVencimiento
  from  FacturaEncabezado a (nolock)
  inner join FacturaDetalle b (nolock) on b.Emp_Id = a.Emp_Id and  b.Suc_Id = a.Suc_Id and b.Caja_Id = a.Caja_Id and b.TipoDoc_Id = a.TipoDoc_Id and b.Documento_Id = a.Documento_Id 
  inner join Articulo c (nolock) on c.Emp_Id = b.Emp_Id and c.Art_Id = b.Art_Id 
  inner join Cliente d (nolock) on d.Emp_Id = a.Emp_Id and d.Cliente_Id = a.Cliente_Id 
  inner join FacturaDetalleGarantia e (nolock) on e.Emp_Id = b.Emp_Id and  e.Suc_Id = b.Suc_Id and e.Caja_Id = b.Caja_Id and e.TipoDoc_Id = b.TipoDoc_Id and e.Documento_Id = b.Documento_Id and e.Detalle_Id = b.Detalle_Id
  inner join FacturaDetalleGarantia f (nolock) on f.Emp_Id = e.Emp_Id and  f.Suc_Id = e.Suc_Id and f.Caja_Id = e.Caja_Id and f.TipoDoc_Id = e.TipoDoc_Id and f.Documento_Id = e.Documento_Id and f.Detalle_Id = e.Detalle_Id
  left  join FacturaDetalleLote g (nolock) on f.Emp_Id = g.Emp_Id and  f.Suc_Id = g.Suc_Id and f.Caja_Id = g.Caja_Id and f.TipoDoc_Id = g.TipoDoc_Id and f.Documento_Id = g.Documento_Id and f.Detalle_Id = g.Detalle_Id
  where f.Emp_Id      = @pEmp_Id 
  and   f.Garantia_Id = @pGarantia_Id 



end
GO


