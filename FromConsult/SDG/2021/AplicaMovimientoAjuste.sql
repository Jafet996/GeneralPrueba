USE [SDG-DMO]
GO

/****** Object:  StoredProcedure [dbo].[AplicaMovimientoAjuste]    Script Date: 1/20/2021 9:35:25 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER   procedure [dbo].[AplicaMovimientoAjuste]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pTipoMov_Id smallint
,@pMov_Id int 
,@pUsuario_Id varchar(20))
as
begin
  --Aplica el ajuste de inventario y rebaja de inventario
  begin try
    declare  @Bod_Id            smallint
            ,@Detalle_Id        smallint
            ,@Art_Id            varchar(13)
            ,@Cantidad          float
            ,@Detalle           varchar(200)
            ,@Costo             money
			      ,@Suelto			bit
            ,@SpResult          int
            ,@EntradaMercaderia bit
            ,@Comentario				varchar(200)
            ,@SumaMovimiento    bit
            ,@Lote              bit
            ,@InfoLotes         dbo.InfoLotes
            
    --Busca el nombre del movimiento para la descripcion del Kardex
    select @Detalle           = Nombre
          ,@EntradaMercaderia = EntradaMercaderia
          ,@SumaMovimiento    = Suma
    from   TipoMovimiento
    where Emp_Id     = @pEmp_Id
    and   TipoMov_Id = @pTipoMov_Id
    if @@error<>0 begin
      raiserror ('Error Buscando tipo de movimiento', 16, 1)
    end        
  
    --Marca el movimiento como aplicado
    update MovimientoEncabezado set  Aplicado           = 1
                                    ,AplicaUsuario_Id   = @pUsuario_Id
                                    ,AplicaFecha        = getdate()
                                    ,UltimaModificacion = getdate()
    where Emp_Id     = @pEmp_Id
    and   Suc_Id     = @pSuc_Id
    and   TipoMov_Id = @pTipoMov_Id
    and   Mov_Id     = @pMov_Id
    if @@error<>0 begin
      raiserror ('Error Marcando como aplicado: MovimientoEncabezado', 16, 1)
    end
    
    --Busca la bodega en el encabezado para afectar las existencias
    select @Bod_Id = Bod_Id
					,@Comentario = Comentario
    from  MovimientoEncabezado
    where Emp_Id     = @pEmp_Id
    and   Suc_Id     = @pSuc_Id
    and   TipoMov_Id = @pTipoMov_Id
    and   Mov_Id     = @pMov_Id
    if @@error<>0 or @@rowcount = 0begin
      raiserror ('Error buscando datos en el encabezado del movimiento', 16, 1)
    end
    
    set @Detalle = rtrim(substring(@Detalle + ' ' + @Comentario,1,200))
    
    declare CurDetalle cursor for
    select Detalle_Id 
          ,Art_Id
          ,Cantidad
          ,Costo
		      ,Suelto
          ,Lote
    from  MovimientoDetalle
    where Emp_Id     = @pEmp_Id
    and   Suc_Id     = @pSuc_Id
    and   TipoMov_Id = @pTipoMov_Id
    and   Mov_Id     = @pMov_Id
    
    open CurDetalle
    
    fetch next from CurDetalle
    into @Detalle_Id, @Art_Id, @Cantidad, @Costo, @Suelto, @Lote
    
    while @@fetch_status = 0 begin

        delete @InfoLotes

        If @Lote = 1 Begin

          insert @InfoLotes 
                (Art_Id
                ,Lote
                ,Vencimiento
                ,Cantidad)
          select Art_Id 
                ,Lote
                ,Vencimiento
                ,Cantidad * IIf(@SumaMovimiento = 1, -1, 1)
          from  MovimientoDetalleLote 
          where Emp_Id     = @pEmp_Id
          and   Suc_Id     = @pSuc_Id
          and   TipoMov_Id = @pTipoMov_Id
          and   Mov_Id     = @pMov_Id
          and   Detalle_Id = @Detalle_Id
          If @@ROWCOUNT = 0 OR @@ERROR <> 0 Begin
            raiserror ('Error buscando lotes para el articulo: %s', 16, 1, @Art_Id)  
          End

        End


        --Le invierte el signo para que haga bien el rebajo o suma de inventario
        select @Cantidad = @Cantidad * -1
                   
        --La cantidad se envia negativo para que le sume al inventario y para que reste positiva
        exec @SpResult = RebajaSumaIventario @pEmp_Id, @pSuc_Id, @Bod_Id, @Art_Id ,@Cantidad, @Detalle, @pUsuario_Id,'','','',@InfoLotes
        if @SpResult<>0 begin
          raiserror ('Error ejecutando, RebajaSumaIventario, para el articulo: %s', 16, 1, @Art_Id)
        end  

        --Si es una entrada de mercaderia aplica actualiza con el ultimo costo
        --y hace el recalculo del precio
        if @EntradaMercaderia = 1 begin
          update ArticuloBodega set  Costo              = @Costo
                                    ,UltimaModificacion = getdate()
          where Emp_Id = @pEmp_Id
          and   Suc_Id = @pSuc_Id
          and   Bod_Id = @Bod_Id
          and   Art_Id = @Art_Id
          if @@error<>0 begin
            raiserror ('Actualizando el costo del articulo', 16, 1)
          end          
          
        end


        fetch next from CurDetalle
        into @Detalle_Id, @Art_Id, @Cantidad, @Costo, @Suelto, @Lote
    end

    close CurDetalle
    deallocate CurDetalle
  
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


