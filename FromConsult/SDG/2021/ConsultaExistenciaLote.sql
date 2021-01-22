
GO

/****** Object:  StoredProcedure [dbo].[ConsultaExistenciaLote]    Script Date: 1/20/2021 12:26:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[ConsultaExistenciaLote]
(
  @pEmp_Id smallint
 ,@pSuc_Id smallint
 ,@pBod_Id smallint
 ,@pArt_Id varchar(13)
)
AS
  BEGIN

    select b.Nombre Sucursal
          ,c.Nombre Bodega
          ,a.Lote
          ,a.Vencimiento
          ,a.Saldo
          ,d.Saldo as Existencia
    from ArticuloBodegaLote a with (nolock)
    INNER JOIN Sucursal b with (nolock) ON a.Emp_Id = b.Emp_Id and a.Suc_Id = b.Suc_Id
    INNER JOIN Bodega c with (nolock) ON a.Emp_Id = c.Emp_Id and a.Suc_Id = c.Suc_Id and a.Bod_Id = c.Bod_Id
    INNER JOIN ArticuloBodega d (nolock) on a.Emp_Id = d.Emp_Id and a.Suc_Id = d.Suc_Id and a.Bod_Id = d.Bod_Id and a.Art_Id = d.Art_Id 
    where a.Emp_Id = @pEmp_Id
    and   a.Suc_Id = @pSuc_Id
    and   a.Bod_Id = @pBod_Id
    and   a.Art_Id = @pArt_Id
    and   a.Saldo  > 0
    order by a.Vencimiento asc

  END
GO


