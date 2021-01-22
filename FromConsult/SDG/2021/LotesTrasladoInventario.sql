
GO

/****** Object:  StoredProcedure [dbo].[LotesTrasladoInventario]    Script Date: 1/20/2021 3:17:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[LotesTrasladoInventario]
(
  @pEmp_Id      smallint
 ,@pTraslado_Id int
)
AS
  BEGIN

    select c.Art_Id
          ,c.Nombre
          ,a.Cantidad
          ,a.CantidadLote
          ,ISNULL(b.Lote, '') Lote
          ,ISNULL(b.Vencimiento, CONVERT(datetime, '19000101')) Vencimiento
          ,ISNULL(b.Cantidad, 0) LoteCantidad
    from TrasladoDetalle a with (nolock)
    LEFT JOIN TrasladoDetalleLote b with (nolock) ON a.Emp_Id = b.Emp_Id and a.Traslado_Id = b.Traslado_Id and a.Detalle_Id = b.Detalle_Id
    INNER JOIN Articulo c with (nolock) ON a.Emp_Id = c.Emp_Id and a.Art_Id = c.Art_Id and c.Lote = 1
    where a.Emp_Id      = @pEmp_Id
    and   a.Traslado_Id = @pTraslado_Id
    order by a.Detalle_Id asc

  END
GO


