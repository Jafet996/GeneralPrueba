
GO

/****** Object:  StoredProcedure [dbo].[BuscaGarantia]    Script Date: 1/25/2021 11:41:53 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE  procedure [dbo].[BuscaGarantia]
(@pEmp_Id smallint
,@pArt_Id varchar(13)
,@pSerie varchar(13)
,@pCliente_Id int)

as
begin
  
  select e.Garantia_Id
        ,cast(a.Suc_Id as varchar) + '-' + cast(a.Caja_Id as varchar) + '-' + cast(a.TipoDoc_Id as varchar) + '-' + cast(a.Documento_Id as varchar) as Factura
        ,a.Fecha as FacturaFecha
        ,b.Detalle_Id
		,a.Documento_Id
        ,e.OrdenNumero 
        ,e.FechaInicio 
        ,e.FechaFinal 
        ,d.Cliente_Id 
        ,d.Nombre ClienteNombre
        ,d.Cedula 
        ,c.Art_Id 
        ,c.Nombre ArtNombre
        ,DATEDIFF (MONTH,e.FechaInicio,e.FechaFinal) as Meses
        ,(select  TOP 1 isnull(lote,'--')  from FacturaDetalleLote g where  g.Emp_Id = e.Emp_Id and  g.Suc_Id = e.Suc_Id and g.Caja_Id = e.Caja_Id and g.TipoDoc_Id = e.TipoDoc_Id and g.Documento_Id = e.Documento_Id and g.Detalle_Id = e.Detalle_Id ) as Lote
        ,(select  TOP 1 isnull(Vencimiento,'--')  from FacturaDetalleLote g where  g.Emp_Id = e.Emp_Id and  g.Suc_Id = e.Suc_Id and g.Caja_Id = e.Caja_Id and g.TipoDoc_Id = e.TipoDoc_Id and g.Documento_Id = e.Documento_Id and g.Detalle_Id = e.Detalle_Id ) as LoteFechaVencimiento
        ,DATEDIFF (day,getdate(),e.FechaFinal) as DiasSaldo
  from  FacturaEncabezado a (nolock)
  inner join FacturaDetalle b (nolock) on b.Emp_Id = a.Emp_Id and  b.Suc_Id = a.Suc_Id and b.Caja_Id = a.Caja_Id and b.TipoDoc_Id = a.TipoDoc_Id and b.Documento_Id = a.Documento_Id 
  inner join Articulo c (nolock) on c.Emp_Id = b.Emp_Id and c.Art_Id = b.Art_Id 
  inner join Cliente d (nolock) on d.Emp_Id = a.Emp_Id and d.Cliente_Id = a.Cliente_Id 
  inner join FacturaDetalleGarantia e (nolock) on e.Emp_Id = b.Emp_Id and  e.Suc_Id = b.Suc_Id and e.Caja_Id = b.Caja_Id and e.TipoDoc_Id = b.TipoDoc_Id and e.Documento_Id = b.Documento_Id and e.Detalle_Id = b.Detalle_Id
  where a.Emp_Id      = @pEmp_Id 
  and   a.Cliente_Id  = iif(@pCliente_Id = 0, a.Cliente_Id, @pCliente_Id) 
  and   b.Art_Id      = iif(@pArt_Id = '', b.Art_Id , @pArt_Id) 
  
end
GO


