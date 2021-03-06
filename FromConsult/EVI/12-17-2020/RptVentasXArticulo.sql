USE [SDG-EVI]
GO
/****** Object:  StoredProcedure [dbo].[RptVentasXArticulo]    Script Date: 12/17/2020 12:13:48 PM ******/
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
)
AS
  BEGIN

    select c.Art_Id
          ,c.Nombre
          ,SUM(b.Cantidad) as Cantidad
          ,b.TotalLinea as Precio
          ,(b.TotalLinea * SUM(b.Cantidad)) as Total
    from FacturaEncabezado a
        ,FacturaDetalle b
        ,Articulo c
    where a.Emp_Id = b.Emp_Id
    and   a.Suc_Id = b.Suc_Id
    and   a.Caja_Id = b.Caja_Id
    and   a.TipoDoc_Id = b.TipoDoc_Id
    and   a.Documento_Id = b.Documento_Id
    and   a.Emp_Id = c.Emp_Id
    and   b.Art_Id = c.Art_Id
    and   a.Emp_Id = @pEmp_Id
    and   a.Suc_Id = @pSuc_Id
    and   a.Fecha >= @pFechaIni
    and   a.Fecha <  @pFechaFin
    group by c.Art_Id
            ,c.Nombre
            ,b.TotalLinea
    order by c.Nombre

  END



