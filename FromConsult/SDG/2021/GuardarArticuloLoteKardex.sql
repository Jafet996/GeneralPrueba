
GO

/****** Object:  StoredProcedure [dbo].[GuardaArticuloLoteKardex]    Script Date: 1/20/2021 10:07:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [dbo].[GuardaArticuloLoteKardex]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pArt_Id varchar(13)
,@pLote   varchar(20)
,@pVencimiento date
,@pCantidad float
,@pDetalle varchar(200)
,@pUsuario_Id varchar(20))
as
begin
  begin try

	  declare @SaldoActual float

	  select	@SaldoActual = Saldo
	  from	ArticuloBodegaLote  
	  where	Emp_Id      = @pEmp_Id
	  and		Suc_Id      = @pSuc_Id
	  and		Bod_Id      = @pBod_Id 
	  and		Art_Id      = @pArt_Id
    and   Lote        = @pLote 
    and   Vencimiento = @pVencimiento 
	  if @@error<>0 begin
			  raiserror ('Error buscando saldo alctual de producto en GuardaArticuloKardex', 16, 1)
	  end
  
    --Le invierte el signo, para guardar positivo lo que suma al inventario
    --y negativo lo que resta 
    --Jimmy Trejos Valverde 02/05/2012
    select @pCantidad = @pCantidad * -1
  
  
    --Guarda el Kardex del articulo
    insert into ArticuloLoteKardex
               (Emp_Id
               ,Suc_Id
               ,Bod_Id
               ,Art_Id
               ,Lote
               ,Vencimiento
               ,Fecha
               ,Cantidad
               ,Detalle
               ,Usuario_Id
               ,Saldo)
         VALUES
               (@pEmp_Id
               ,@pSuc_Id
               ,@pBod_Id
               ,@pArt_Id
               ,@pLote
               ,@pVencimiento 
               ,getdate()
               ,@pCantidad
               ,@pDetalle
               ,@pUsuario_Id
               ,@SaldoActual)
    if @@error<>0 begin
      raiserror ('Error guardando en ArticuloLoteKardex', 16, 1)
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


