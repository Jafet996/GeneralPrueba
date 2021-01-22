USE [SDG-DMO]
GO

/****** Object:  StoredProcedure [dbo].[CreaHistorialArticulo]    Script Date: 12/28/2020 10:44:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE   procedure [dbo].[CreaHistorialArticulo]
(@pEmp_Id smallint
,@pArt_Id varchar(13)
,@pNombre varchar(100)
,@pTipoMovimiento varchar(20)
,@pExentoIV bit
,@pServicio bit
,@pCosto money
,@pCabysCodigo varchar(13)
,@pClave varchar(50)
)

as
begin

  begin try



  begin transaction

    insert into ArticuloHistoricoCompra(
		Historial_Id,
		Emp_Id,
		Art_Id,
		FechaModificacion,
		TipoMovimiento,
		Nombre,
		ExentoIV,
		Suelto,
		Servicio,
		Costo,
		CodigoCabys,
		Clave

	)
	values(
	--select @pPropietario_Id=ISNULL(MAX(Propietario_Id),0) + 1 
		(select ISNULL(MAX(Historial_Id),0)+1 from ArticuloHistoricoCompra),
		@pEmp_Id,
		@pArt_Id,
		GETDATE(),
		@pTipoMovimiento,
		@pNombre,
		@pExentoIV,
		0,
		@pServicio,
		@pCosto,
		@pCabysCodigo,
		@pClave
		)

		


   if @@error <> 0 or @@rowcount = 0 begin
        raiserror ('Error Insertando Articulo En el Historial', 16, 1)  
      end 

	   commit transaction

  end try
  begin catch
  
    rollback transaction

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


