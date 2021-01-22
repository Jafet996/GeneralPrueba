GO

/****** Object:  StoredProcedure [dbo].[AplicaEntrada]    Script Date: 1/22/2021 4:00:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER   procedure [dbo].[AplicaEntrada]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pEntrada_Id int 
,@pUsuario_Id varchar(20))
as
begin
  begin try

 
    declare  @Bod_Id                smallint
            ,@Art_Id                varchar(13)
            ,@Cantidad              float
            ,@Costo                 money
            ,@CantidadBonificada    float
            ,@Orden_Id              int
            ,@SaldoActual           float
            ,@CostoActual           money
            ,@PrecioActual          money
            ,@SpResult              int
            ,@CostoPromedio         float
            ,@Margen                float
            ,@Precio                money
			      ,@CostoNeto	            money
			      ,@CostoPromedioAnterior money
            ,@Cambio_Id             bigint
			      ,@Suelto				        bit
            ,@NombreProveedor       varchar(50)
            ,@Prov_Id               smallint
            ,@Lote                  bit
            ,@InfoLotes             dbo.InfoLotes
            ,@CantidadTotal         float
            ,@Detalle_Id            smallint





    --Marca el encabezado como aplicado
    update EntradaEncabezado set   EntradaEstado_Id   = 2
                                  ,AplicaUsuario_Id   = @pUsuario_Id
                                  ,AplicaFecha        = getdate()
                                  ,UltimaModificacion = getdate()
    where Emp_Id     = @pEmp_Id
    and   Suc_Id     = @pSuc_Id
    and   Entrada_Id = @pEntrada_Id
    if @@error<>0 begin
      raiserror ('Error Marcando como aplicado: EntradaEncabezado', 16, 1)
    end
    
    
    --Busca datos de encabezado
    select  @Orden_Id         = isnull(a.Orden_Id,-1)
           ,@Bod_Id           = a.Bod_Id
           ,@NombreProveedor  = b.Nombre
           ,@Prov_Id          = a.Prov_Id 
    from  EntradaEncabezado a with(nolock)
    inner join Proveedor b with(nolock) on a.Emp_Id = b.Emp_Id and a.Prov_Id = b.Prov_Id 
    where a.Emp_Id     = @pEmp_Id
    and   a.Suc_Id     = @pSuc_Id
    and   a.Entrada_Id = @pEntrada_Id
    if @@error<>0 begin
      raiserror ('Error buscando numero de orden: EntradaEncabezado', 16, 1)
    end    
  
  
    --Si se encontro un numero de orden libera los comprometidos
    if @Orden_Id > 0 begin
      declare CurDetalle cursor for
      select Art_Id
            ,Cantidad
            ,Costo
      from  OrdenCompraDetalle
      where Emp_Id     = @pEmp_Id
      and   Suc_Id     = @pSuc_Id
      and   Orden_Id   = @Orden_Id  
  
      open CurDetalle
      
      fetch next from CurDetalle
      into @Art_Id, @Cantidad, @Costo
      
      while @@fetch_status = 0 begin
        update ArticuloBodega set  Transito = Transito - @Cantidad
                                  ,UltimaModificacion  = getdate()
        where Emp_Id = @pEmp_Id
        and   Suc_Id = @pSuc_Id
        and   Bod_Id = @Bod_Id
        and   Art_Id = @Art_Id
        if @@error<>0 begin
          raiserror ('Actualizando el transito del articulo', 16, 1)
        end          
            

        fetch next from CurDetalle
        into @Art_Id, @Cantidad, @Costo
      end

      close CurDetalle
      deallocate CurDetalle
    end
    
    
    --Hace la entrada al inventario y recalcula el precio
    declare CurEntrada cursor for
    select Detalle_Id 
          ,Art_Id
          ,Cantidad
          ,Costo - MontoDescuento 
          ,CantidadBonificada
          ,Margen
          ,Precio
          ,Lote 
    from  EntradaDetalle
    where Emp_Id     = @pEmp_Id
    and   Suc_Id     = @pSuc_Id
    and   Entrada_Id = @pEntrada_Id

    open CurEntrada
    
    fetch next from CurEntrada
    into @Detalle_Id, @Art_Id, @Cantidad, @Costo, @CantidadBonificada, @Margen, @Precio, @Lote
    
    while @@fetch_status = 0 begin

      delete @InfoLotes

      If @Lote = 1 Begin

        insert @InfoLotes 
        (
          Art_Id
          ,Lote
          ,Vencimiento
          ,Cantidad
        )
        select Art_Id 
              ,Lote
              ,Vencimiento
              ,Cantidad * -1
        from  EntradaDetalleLote 
        where Emp_Id     = @pEmp_Id
        and   Suc_Id     = @pSuc_Id
        and   Entrada_Id = @pEntrada_Id
        and   Detalle_Id = @Detalle_Id 
        If @@ROWCOUNT = 0 OR @@ERROR <> 0 Begin
          raiserror ('Error buscando lotes para el articulo: %s', 16, 1, @Art_Id)  
        End

      End


      if not exists(select 1 from ArticuloProveedor where Emp_Id = @pEmp_Id and Art_Id = @Art_Id and Prov_Id = @Prov_Id) begin
        insert ArticuloProveedor(Emp_Id,Art_Id,Prov_Id,UltimaModificacion)
        values (@pEmp_Id, @Art_Id, @Prov_Id, GETDATE())
        if @@error<>0 begin
          raiserror ('Insertando ArticuloProveedor', 16, 1)
        end 
      end


      --Busca el costo y saldo actual del articulo
      select @SaldoActual  = Saldo
            ,@CostoActual  = Costo
			      ,@CostoPromedioAnterior = CostoPromedio
            ,@PrecioActual          = Precio
      from  ArticuloBodega
      where Emp_Id = @pEmp_Id
      and   Suc_Id = @pSuc_Id
      and   Bod_Id = @Bod_Id
      and   Art_Id = @Art_Id
      if @@error<>0 begin
        raiserror ('Actualizando el saldo del articulo', 16, 1)
      end 
      
      
      --Calcula el costo promedio
      if @SaldoActual>0 begin
        set @CostoPromedio = ((@CostoPromedioAnterior * @SaldoActual) + (@Costo * @Cantidad)) / (@SaldoActual + @Cantidad)
      end
      else begin
        set @CostoPromedio = @Costo 
      end
      
	  --Calcula el costo neto
	  set @CostoNeto = 0
	  if (@SaldoActual + @Cantidad)<>0 begin
        set @CostoNeto = (@Costo * @Cantidad) / (@Cantidad + @CantidadBonificada)
      end


      --Actualiza la informacion de precios del articulo en la bodega que se aplico la entrada 
      update ArticuloBodega set  Precio       = @Precio
                                ,UltimaModificacion  = getdate()
      where Emp_Id = @pEmp_Id
      and   Suc_Id = @pSuc_Id
      and   Bod_Id = @Bod_Id
      and   Art_Id = @Art_Id
      if @@error<>0 begin
        raiserror ('Actualizando el saldo del articulo', 16, 1)
      end

	  declare @RecalculaMargen as bit  =  (select RecalculaPrecioEntradaMercaderia from EmpresaParametro )
        
      --Actualiza la informacion de costos del articulo en todas las bodegas
      update ArticuloBodega set  CostoPromedio      = @CostoPromedio 
                                ,Costo              = @Costo 
                                ,Margen             = iif(@Costo<>0,(((Precio - @Costo)*100)/@Costo),100)
								                ,CostoNeto	        = @CostoNeto
                                ,UltimaModificacion = getdate()
								                ,PrecioMayorista    = IIF(@RecalculaMargen = 1, (@Costo * (1 + (MargenMayorista/100))), PrecioMayorista)
								                ,Precio3            = IIF(@RecalculaMargen = 1, (@Costo * (1 + (Margen3/100))), Precio3)
								                ,Precio4            = IIF(@RecalculaMargen = 1, (@Costo * (1 + (Margen4/100))), Precio4)
								                ,Precio5            = IIF(@RecalculaMargen = 1, (@Costo * (1 + (Margen5/100))), Precio5)
      where Emp_Id = @pEmp_Id
      and   Art_Id = @Art_Id
      if @@error<>0 begin
        raiserror ('Actualizando el saldo del articulo', 16, 1)
      end

      --Si cambia de precio lo inserta en bitacora de cambios de precio
      if @PrecioActual <> @Precio begin

        select @Cambio_Id = isnull(max(Cambio_Id),0)+1
        from  ArticuloCambioPrecio          
        where Emp_Id = @pEmp_Id
        and   Suc_Id = @pSuc_Id 
        and   Art_Id = @Art_Id
        if @@error<>0 begin
          raiserror ('Error buscando el consecutivo de cambio de precio', 16, 1)
        end

        insert into ArticuloCambioPrecio
                   (Emp_Id
                   ,Suc_Id
                   ,Art_Id
                   ,Cambio_Id
                   ,PrecioAnterior
                   ,PrecioNuevo
                   ,Fecha)
             values
                   (@pEmp_Id
                   ,@pSuc_Id
                   ,@Art_Id
                   ,@Cambio_Id
                   ,@PrecioActual 
                   ,@Precio
                   ,getdate())
        if @@error<>0 begin
          raiserror ('Error insertando en ArticuloCambioPrecio', 16, 1)
        end

      end
     

      --Si es una devolucion el monto se envia negativo para que se haga la devolucion al inventario      
      set @Cantidad           = (@Cantidad * -1)
      set @CantidadBonificada = (@CantidadBonificada * -1)
      set @CantidadTotal      = (@Cantidad + @CantidadBonificada)
      
      exec @SpResult = RebajaSumaIventario @pEmp_Id, @pSuc_Id, @Bod_Id, @Art_Id ,@CantidadTotal, 'Entrada de Mercadería', @pUsuario_Id, @NombreProveedor,'', '',@InfoLotes
      if @SpResult<>0 begin
        raiserror ('Error ejecutando, RebajaSumaIventario, para el articulo: %s', 16, 1, @Art_Id)
      end

      --if @CantidadBonificada >0 begin
      --  set @CantidadBonificada = (@CantidadBonificada * -1)
        
      --  exec @SpResult = RebajaSumaIventario @pEmp_Id, @pSuc_Id, @Bod_Id, @Art_Id ,@CantidadBonificada, 'Entrada de Mercadería(Bonificación)', @pUsuario_Id, @NombreProveedor,'', ''
      --  if @SpResult<>0 begin
      --    raiserror ('Error ejecutando, RebajaSumaIventario, para el articulo: %s', 16, 1, @Art_Id)
      --  end

      --end

      fetch next from CurEntrada
      into @Detalle_Id, @Art_Id, @Cantidad, @Costo, @CantidadBonificada, @Margen, @Precio, @Lote
    end

    close CurEntrada
    deallocate CurEntrada    
    
      
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


