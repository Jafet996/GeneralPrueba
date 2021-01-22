GO

/****** Object:  StoredProcedure [dbo].[LotesAjusteInventario]    Script Date: 1/20/2021 11:06:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[LotesAjusteInventario]
(
  @pEmp_Id     smallint
 ,@pSuc_Id     smallint
 ,@pTipoMov_Id smallint
 ,@pMov_Id     int
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
    from MovimientoDetalle a with (nolock)
    LEFT JOIN MovimientoDetalleLote b with (nolock) ON a.Emp_Id = b.Emp_Id and a.Suc_Id = b.Suc_Id and a.TipoMov_Id = b.TipoMov_Id and a.Mov_Id = b.Mov_Id and a.Detalle_Id = b.Detalle_Id
    INNER JOIN Articulo c with (nolock) ON a.Emp_Id = c.Emp_Id and a.Art_Id = c.Art_Id and c.Lote = 1
    where a.Emp_Id     = @pEmp_Id
    and   a.Suc_Id     = @pSuc_Id
    and   a.TipoMov_Id = @pTipoMov_Id
    and   a.Mov_Id     = @pMov_Id
    order by a.Detalle_Id asc

  END
GO


