
GO

/****** Object:  StoredProcedure [dbo].[LotesEntradaMercaderia]    Script Date: 1/21/2021 1:24:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[LotesEntradaMercaderia]
(
  @pEmp_Id     smallint
 ,@pSuc_Id     smallint
 ,@pEntrada_Id int
)
AS
  BEGIN

    select c.Art_Id
          ,c.Nombre
          ,a.Cantidad
          ,a.CantidadEscaneada
          ,ISNULL(b.Lote, '') Lote
          ,ISNULL(b.Vencimiento, CONVERT(datetime, '19000101')) Vencimiento
          ,ISNULL(b.Cantidad, 0) LoteCantidad
    from EntradaDetalle a with (nolock)
    LEFT JOIN EntradaDetalleLote b with (nolock) ON a.Emp_Id = b.Emp_Id and a.Suc_Id = b.Suc_Id and a.Entrada_Id = b.Entrada_Id and a.Detalle_Id = b.Detalle_Id
    INNER JOIN Articulo c with (nolock) ON a.Emp_Id = c.Emp_Id and a.Art_Id = c.Art_Id and c.Lote = 1
    where a.Emp_Id     = @pEmp_Id
    and   a.Suc_Id     = @pSuc_Id
    and   a.Entrada_Id = @pEntrada_Id
    order by a.Detalle_Id asc

  END
GO


