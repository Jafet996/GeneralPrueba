USE [SDMAT]
GO

/****** Object:  StoredProcedure [dbo].[CxC_GeneraFacturasArregloPago]    Script Date: 01/27/2016 11:08:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[CxC_GeneraFacturasArregloPago]
(@pEmp_Id           smallint
,@pTipoMov_Id       smallint
,@pCliente_Id       int
,@pReferencia       varchar(400)
,@pFechaMovimiento  datetime
,@pCuotas           smallint
,@pMonto            money
,@pUsuario_Id       varchar(20)
,@pPorcInteres      float
,@pSuc_Id           smallint
,@pCaja_Id          smallint
,@pTipoDoc_Id       smallint
,@pDocumento_Id     bigint)
as
begin
  --Jimmy Trejos Valverde 26/MARZO/2013
  begin try
  
    begin transaction
    
    create table #Movimientos(Mov_Id bigint)

    declare  @MontoFactura    money
            ,@Mes             smallint
            ,@Mov_Id          bigint
            ,@Fecha           datetime
            ,@LimiteCredito   money
            ,@Saldo           money
            ,@DiasCredito     money
            ,@PorcMora        float
            ,@DiasGraciaMora  smallint
            ,@AplicaMora      bit
            ,@MontoTotal      money
            ,@NombreMes       varchar(20)
--            ,@Referencia      varchar(400)
            

    --Inicializa variables
    select @MontoFactura  = round((@pMonto/@pCuotas),2)
          ,@Mes           = 1
          ,@Mov_Id        = 0
          ,@Fecha         = GETDATE ()
          ,@MontoTotal    = 0
          --,@Referencia    = ''
          
    --Busca parametros del cliente
    select   @LimiteCredito  = LimiteCredito
            ,@Saldo          = Saldo
            ,@DiasCredito    = DiasCredito
            ,@PorcMora       = PorcMora
            ,@DiasGraciaMora = DiasGraciaMora
            ,@AplicaMora     = AplicaMora
    from  Cliente 
    where Emp_Id      = @pEmp_Id 
    and   Cliente_Id  = @pCliente_Id 
    if @@ROWCOUNT=0 or @@ERROR<>0 begin
      raiserror ('Error buscando el datos del cliente', 16, 1)
    end
    
    --if ltrim(rtrim(@pReferencia)) <> '' begin
    --  set @Referencia = ' - ' + @pReferencia
    --end
    
          
    while @Mes <= @pCuotas begin
    
      --Busca el consecutivo del movimiento
      select @Mov_Id = ISNULL( MAX (Mov_Id), 0) + 1
      from  CxCMovimiento 
      where Emp_Id      = @pEmp_Id 
      and   TipoMov_Id  = @pTipoMov_Id 
      if @@ERROR<>0 begin
        raiserror ('Error buscando el consecutivo del movimiento', 16, 1)
      end 
      
      

      select @NombreMes = case datepart(MONTH,@pFechaMovimiento)
                                 when 1 then 'ENERO'
                                 when 2 then 'FEBRERO'
                                 when 3 then 'MARZO'
                                 when 4 then 'ABRIL'
                                 when 5 then 'MAYO'
                                 when 6 then 'JUNIO'
                                 when 7 then 'JULIO'
                                 when 8 then 'AGOSTO'
                                 when 9 then 'SETIEMBRE'
                                 when 10 then 'OCTUBRE'
                                 when 11 then 'NOVIEMBRE'
                                 when 12 then 'DICIEMBRE'
                          end      
      
      
      --Inserta el registro en cxc
      insert into CxCMovimiento
             (Emp_Id
             ,TipoMov_Id
             ,Mov_Id
             ,Cliente_Id
             ,Referencia
             ,Fecha
             ,FechaMovimiento
             ,Vencimiento
             ,Monto
             ,Saldo
             ,Activo
             ,Usuario_Id
             ,AplicaMora
             ,FechaCalculoMora
             ,Intereses
             ,UltimaModificacion)
      select @pEmp_Id
            ,@pTipoMov_Id
            ,@Mov_Id
            ,@pCliente_Id
            ,'COBRO MES :' + @NombreMes + @pReferencia
            ,@Fecha
            ,@pFechaMovimiento
            ,@pFechaMovimiento --La fecha de vencimiento es la misma del movimiento
            ,@MontoFactura
            ,@MontoFactura
            ,1
            ,@pUsuario_Id
            ,@AplicaMora
            ,@pFechaMovimiento
            ,0
            ,@Fecha
            
      if @@ROWCOUNT=0 or @@ERROR<>0 begin
        raiserror ('Error insertando cuota en CxCMovimiento', 16, 1)
      end  
      
      
      --Inserta la relacion entre el documento y la factura
      insert into CxCMovimientoFactura
           (Emp_Id
           ,TipoMov_Id
           ,Mov_Id
           ,Suc_Id
           ,Caja_Id
           ,TipoDoc_Id
           ,Documento_Id)
     VALUES
           (@pEmp_Id 
           ,@pTipoMov_Id
           ,@Mov_Id
           ,@pSuc_Id 
           ,@pCaja_Id 
           ,@pTipoDoc_Id 
           ,@pDocumento_Id)
      if @@ROWCOUNT=0 or @@ERROR<>0 begin
        raiserror ('Error insertando cuota en CxCMovimiento', 16, 1)
      end            
      
      
      
      insert #Movimientos (Mov_Id) values (@Mov_Id)
            
      set @MontoTotal = @MontoTotal + @MontoFactura         
      set @pFechaMovimiento = DATEADD(month,1,@pFechaMovimiento)
      set @Mes = @Mes + 1
    end
    
    update Cliente set Saldo = Saldo + @MontoTotal, UltimaModificacion = GETDATE ()
    where Emp_Id      = @pEmp_Id 
    and   Cliente_Id  = @pCliente_Id 
    if @@ROWCOUNT=0 or @@ERROR<>0 begin
      raiserror ('Error actualizando datos del cliente', 16, 1)
    end
    
    
    select *
    from  #Movimientos 
    
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


