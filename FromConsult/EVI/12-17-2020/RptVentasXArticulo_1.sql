USE [SDG-LOTE]
GO

/****** Object:  StoredProcedure [dbo].[RptVentasXArticulo]    Script Date: 12/17/2020 12:14:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[RptVentasXArticulo]
(
  @pEmp_Id smallint
 ,@pSuc_Id smallint
 ,@pFechaIni datetime
 ,@pFechaFin datetime
 ,@pLote_Id varchar(100)
 ,@pNombre varchar(100)
)
AS
  BEGIN

    If @pLote_Id = ''
    select c.Art_Id
          ,c.Nombre
		  ,a.Nombre as Nombre_Cliente
          ,SUM(b.Cantidad) as Cantidad
          ,b.TotalLinea as Precio
          ,(b.TotalLinea * SUM(b.Cantidad)) as Total
		  ,(select top 1 isnull(Lote_Id,'--') from FacturaDetalleLote d where d.Emp_Id=@pEmp_Id and d.Suc_Id=@pSuc_Id
		  and d.TipoDoc_Id=a.TipoDoc_Id and d.Caja_Id=a.Caja_Id and d.Documento_Id=a.Documento_Id) as Lote_Id
    from FacturaEncabezado a
        ,FacturaDetalle b
        ,Articulo c
    where (a.Emp_Id = b.Emp_Id
    and   a.Suc_Id = b.Suc_Id
    and   a.Caja_Id = b.Caja_Id
    and   a.TipoDoc_Id = b.TipoDoc_Id
    and   a.Documento_Id = b.Documento_Id
    and   a.Emp_Id = c.Emp_Id
    and   b.Art_Id = c.Art_Id
    and   a.Emp_Id = @pEmp_Id
    and   a.Suc_Id = @pSuc_Id
    and   a.Fecha >= @pFechaIni
    and   a.Fecha <  @pFechaFin)
    and   a.Nombre LIKE '%'+@pNombre+'%'
	
    group by c.Art_Id
            ,c.Nombre
			,a.Nombre
            ,b.TotalLinea
			,a.TipoDoc_Id
			,a.Caja_Id
			,a.Documento_Id
    order by c.Nombre
    
else
	
	select c.Art_Id
          ,c.Nombre
		  ,a.Nombre as Nombre_Cliente
          ,SUM(b.Cantidad) as Cantidad
          ,b.TotalLinea as Precio
          ,(b.TotalLinea * SUM(b.Cantidad)) as Total
		  ,d.Lote_Id
    from FacturaEncabezado a
        ,FacturaDetalle b
        ,Articulo c
		,FacturaDetalleLote d
    where a.Emp_Id = b.Emp_Id
	and   a.Emp_Id = d.Emp_Id
    and   a.Suc_Id = b.Suc_Id
	and   a.Suc_Id = d.Suc_Id
    and   a.Caja_Id = b.Caja_Id
	and  a.Caja_Id = d.Caja_Id
    and   a.TipoDoc_Id = b.TipoDoc_Id
	and a.TipoDoc_Id = d.TipoDoc_Id
    and   a.Documento_Id = b.Documento_Id
	and   a.Documento_Id = b.Documento_Id
    and   a.Emp_Id = c.Emp_Id
    and   b.Art_Id = c.Art_Id
    and   a.Emp_Id = @pEmp_Id
    and   a.Suc_Id = @pSuc_Id
    and   a.Fecha >= @pFechaIni
    and   a.Fecha <  @pFechaFin
	and d.Lote_Id = @pLote_Id
	and   a.Nombre LIKE '%'+@pNombre+'%'
    group by c.Art_Id
            ,c.Nombre
			,a.Nombre
            ,b.TotalLinea
			,a.TipoDoc_Id
			,a.Caja_Id
			,a.Documento_Id
			, d.Lote_Id

    order by c.Nombre


  END

 
GO


