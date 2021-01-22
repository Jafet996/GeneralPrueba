
GO

/****** Object:  StoredProcedure [dbo].[GuardaTrasladoDetalle]    Script Date: 1/20/2021 2:45:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER   procedure [dbo].[GuardaTrasladoDetalle]
(@pEmp_Id smallint
,@pTraslado_Id int
,@pDetalle_Id smallint
,@pArt_Id varchar(13) 
,@pCantidad float 
,@pCosto money 
,@pTotalLinea money 
,@pSuelto bit 
,@pFecha datetime
,@pCantidadLote float
,@pLote bit)
as
begin
  --Unicamente almacena el movimiento, el rebajo se hace al aplicar sp AplicaMovimientoAjuste
  begin try


  
    insert into TrasladoDetalle 
                (Emp_Id
                ,Traslado_Id
                ,Detalle_Id
                ,Art_Id
                ,Cantidad
                ,CantidadLote
                ,Costo
                ,TotalLinea
                ,Suelto
                ,Lote
                ,Fecha
                ,UltimaModificacion)
         VALUES
               (@pEmp_Id 
               ,@pTraslado_Id
               ,@pDetalle_Id 
               ,@pArt_Id
               ,@pCantidad
               ,@pCantidadLote
               ,@pCosto
               ,@pTotalLinea
               ,@pSuelto
               ,@pLote
               ,@pFecha
               ,getdate())
    if @@error<>0 begin
      raiserror ('Error guardando detalle, para el articulo: %s', 16, 1, @pArt_Id)
    end               
          
  end try
  begin catch

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch
end
GO


