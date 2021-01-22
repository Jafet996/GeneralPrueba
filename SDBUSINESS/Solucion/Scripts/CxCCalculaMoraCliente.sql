/****** Object:  StoredProcedure [dbo].[CxC_CalculaMoraCliente]    Script Date: 01/11/2013 09:13:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[CxC_CalculaMoraCliente]
(@pEmp_Id     smallint
,@pCliente_Id int
,@pFecha      datetime)
as 
begin
  
  declare  @TotalMora money
          ,@PorcentajeMora float

  begin try
  
    begin tran
    
    select @PorcentajeMora = 2 / 100
  
    create table #Movimientos(Emp_Id      smallint  NOT NULL,
                              TipoMov_Id  smallint  NOT NULL,
	                            Mov_Id      bigint    NOT NULL,
	                            DiasMora    int       NOT NULL,
	                            Saldo       money     NOT NULL,
	                            MoraMonto   money     NOT NULL)
  	                          
    --Busca los movimientos con mora pendientes
    insert #Movimientos 
          (Emp_Id 
          ,TipoMov_Id 
          ,Mov_Id
          ,DiasMora
          ,Saldo
          ,MoraMonto)
    select Emp_Id 
          ,TipoMov_Id 
          ,Mov_Id 
          ,DATEDIFF (day,Vencimiento,@pFecha)
          ,Saldo
          ,0
    from  CxCMovimiento
    where Emp_Id      = @pEmp_Id 
    and   Cliente_Id  = @pCliente_Id 
    and   Vencimiento < @pFecha 
    and   MoraAplica  = 1
    and   Activo      = 1
    and   Saldo       > 0
    if @@ERROR <> 0 begin
      raiserror ('Error buscando movimientos con mora', 16, 1)
    end    
    
    update #Movimientos set MoraMonto = ((Saldo / 30) * DiasMora ) * @PorcentajeMora
    if @@ERROR <> 0 begin
      raiserror ('Error calculando mora', 16, 1)
    end
    
    --Calcula el total de mora correspondiente al detalle    
    select  @TotalMora = SUM (MoraMonto )
    from  #Movimientos
    
    
    --Actualiza el monto de la mora x cliente
    update Cliente set Mora               = @TotalMora
                      ,UltimaModificacion = GETDATE ()
    where Emp_Id      = @pEmp_Id 
    and   Cliente_Id  = @pCliente_Id                       
    if @@ERROR <> 0 begin
      raiserror ('Error actualizando la mora en el cliente', 16, 1)
    end    
    
    
    update a set a.MoraDias   = b.DiasMora
                ,a.MoraMonto  = b.MoraMonto
    from  CxCMovimiento a,
          #Movimientos  b
    where a.Emp_Id      = b.Emp_Id
    and   a.TipoMov_Id  = b.TipoMov_Id 
    and   a.Mov_Id      = b.Mov_Id 
    if @@ERROR <> 0 begin
      raiserror ('Error actualizando la mora en el documento', 16, 1)
    end  
    
    
    
    
    commit tran
    
  end try
  begin catch
  
    rollback tran

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


