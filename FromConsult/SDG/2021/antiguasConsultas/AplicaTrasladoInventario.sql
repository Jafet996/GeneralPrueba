USE [SDG-DMO]
GO

/****** Object:  StoredProcedure [dbo].[AplicaTrasladoInventario]    Script Date: 1/20/2021 4:09:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AplicaTrasladoInventario]
(@pEmp_Id smallint
,@pTraslado_Id int 
,@pUsuario_Id varchar(20))
as
begin
  --Aplica el ajuste de inventario y rebaja de inventario
  begin try
    declare  @Art_Id            varchar(13)
            ,@Cantidad          float
            ,@Detalle           varchar(200)
            ,@Costo             money
			      ,@Suelto			      bit
            ,@SpResult          int
            ,@EntradaMercaderia bit
            ,@Comentario				varchar(200)
            ,@SucOrigen_Id      smallint
            ,@BodOrigen_Id      smallint
            ,@SucDestino_Id     smallint
            ,@BodDestino_Id     smallint
            ,@Aplicado          bit
            
    set @Detalle = 'Traslado de Mercaderia'



    select @Aplicado = Aplicado
    from  TrasladoEncabezado
    where Emp_Id = @pEmp_Id
    and   Traslado_Id = @pTraslado_Id
    if @@ROWCOUNT = 0 or @@ERROR <>0 begin
      raiserror ('Error aplicando Traslado de Mercaderia, no se encontró el documento', 16, 1)
    end

    if @Aplicado=1 begin
      raiserror ('Error aplicando Traslado de Mercaderia, El traslado ya fue aplicado anteriormente, imposible continuar', 16, 1)
    end

 
    --Marca el Traslado como aplicado
    update TrasladoEncabezado set    Aplicado           = 1
                                    ,UsuarioAplica_Id   = @pUsuario_Id
                                    ,AplicaFecha        = getdate()
                                    ,UltimaModificacion = getdate()
    where Emp_Id      = @pEmp_Id
    and   Traslado_Id = @pTraslado_Id
    if @@error<>0 begin
      raiserror ('Error Marcando como aplicado: TrasladoEncabezado', 16, 1)
    end
    
    --Busca la bodega en el encabezado para afectar las existencias
    select @SucOrigen_Id   = SucOrigen_Id
          ,@BodOrigen_Id   = BodOrigen_Id
          ,@SucDestino_Id  = SucDestino_Id
          ,@BodDestino_Id  = BodDestino_Id
					,@Comentario = Comentario
    from  TrasladoEncabezado
    where Emp_Id      = @pEmp_Id
    and   Traslado_Id = @pTraslado_Id
    if @@error<>0 or @@rowcount = 0begin
      raiserror ('Error buscando datos en el encabezado del Traslado', 16, 1)
    end
    
    set @Detalle = rtrim(substring(@Detalle + ' ' + @Comentario,1,200))
    
    declare CurDetalle cursor for
    select Art_Id
          ,Cantidad
          ,Costo
		  ,Suelto
    from  TrasladoDetalle
    where Emp_Id     = @pEmp_Id
    and   Traslado_Id     = @pTraslado_Id
    
    open CurDetalle
    
    fetch next from CurDetalle
    into @Art_Id, @Cantidad, @Costo, @Suelto
    
    while @@fetch_status = 0 begin

        if not exists(select 1 
                      from  ArticuloBodega
                      where Emp_Id = @pEmp_Id
                      and   Suc_Id = @SucOrigen_Id
                      and   Bod_Id = @BodOrigen_Id
                      and   Art_Id = @Art_Id
                      and   Saldo >= @Cantidad) 
        begin
          raiserror ('No hay existencia suficiente para el articulo: %s', 16, 1, @Art_Id)
        end


                   
        --La cantidad se envia negativo para que le sume al inventario y para que reste positiva
        exec @SpResult = RebajaSumaIventario @pEmp_Id, @SucOrigen_Id, @BodOrigen_Id, @Art_Id ,@Cantidad, @Detalle, @pUsuario_Id,'','',''
        if @SpResult<>0 begin
          raiserror ('Error ejecutando, RebajaSumaIventario, para el articulo: %s', 16, 1, @Art_Id)
        end  

        select @Cantidad = @Cantidad * -1

        exec @SpResult = RebajaSumaIventario @pEmp_Id, @SucDestino_Id, @BodDestino_Id, @Art_Id ,@Cantidad, @Detalle, @pUsuario_Id,'','',''
        if @SpResult<>0 begin
          raiserror ('Error ejecutando, RebajaSumaIventario, para el articulo: %s', 16, 1, @Art_Id)
        end

        fetch next from CurDetalle
        into @Art_Id, @Cantidad,@Costo, @Suelto
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


