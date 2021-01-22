USE [SDG-DMO]
GO

/****** Object:  StoredProcedure [dbo].[GuardaMovimientoDetalle]    Script Date: 1/20/2021 9:05:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GuardaMovimientoDetalle]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pTipoMov_Id smallint
,@pMov_Id int 
,@pDetalle_Id smallint
,@pArt_Id varchar(13) 
,@pCantidad float 
,@pCosto money 
,@pTotalLinea money 
,@pSuelto bit 
,@pFecha datetime)
as
begin
  --Unicamente almacena el movimiento, el rebajo se hace al aplicar sp AplicaMovimientoAjuste
  begin try
  
    insert into MovimientoDetalle 
               (Emp_Id 
               ,Suc_Id 
               ,TipoMov_Id 
               ,Mov_Id 
               ,Detalle_Id 
               ,Art_Id 
               ,Cantidad 
               ,Costo 
               ,TotalLinea 
               ,Suelto 
               ,Fecha 
               ,UltimaModificacion)
         VALUES
               (@pEmp_Id 
               ,@pSuc_Id 
               ,@pTipoMov_Id 
               ,@pMov_Id
               ,@pDetalle_Id 
               ,@pArt_Id
               ,@pCantidad
               ,@pCosto
               ,@pTotalLinea
               ,@pSuelto
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


