
GO

/****** Object:  StoredProcedure [dbo].[RebajaSumaIventario]    Script Date: 1/20/2021 9:56:32 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER   procedure [dbo].[RebajaSumaIventario]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pArt_Id varchar(13)
,@pCantidad float
,@pDetalle varchar(200)
,@pUsuario_Id varchar(20)
,@pNombreEntidad varchar(80)
,@pConsecutivo varchar(20)
,@pClave varchar(50)
,@pInfoLotes dbo.InfoLotes readonly) --Si es una devolucion el monto viene negativo
as
begin
  --Jimmy Trejos Valverde 13/May/2012 09:00 am
  begin try


    -- Guarda la informacion de lotes------
    create table #InfoLotes(
	    Art_Id varchar(13) NOT NULL,
	    Lote varchar(20) NOT NULL,
	    Vencimiento date NOT NULL,
	    Cantidad float NOT NULL,
    )


    declare  @SpResult						int
            ,@Suelto							bit          --Indicador de si es un suelto
            ,@ArtPadre						varchar(13)  --Codigo del artículo padre
            ,@FactorConversion		smallint     --Cantidad de unidades de la caja
            ,@SaldoActual					float        --Saldo actual del producto
            ,@SaldoSueltoTmp			float        --Suma del saldo actual de suelto + cantidad        
            ,@CantidadCajas				int          --Cantidad total de suma-resta de cajas
            ,@CantidadSueltos			float        --Cantidad total de suma-resta de sueltos
            ,@Servicio						int          --Indica si es un servicio
            ,@CantidadCajasKardex int					 --Cantidad Cajas Kardex
            ,@DetalleKardex				varchar(200)
            ,@Compuesto           bit          --Indica si el articulo tiene una receta asociada
            ,@SaldoPropio         bit          --Indica si se debe rebajar al saldo propio o al de los componentes 
            ,@Ingrediente_Id      varchar(13)
            ,@IngredienteCantidad float
            ,@Lote                bit
            ,@InfoLote            varchar(20)
            ,@InfoVencimiento     date
            ,@InfoCantidad        float
            
            
    --Inicializa variables
    set @SaldoActual					= 0
    set @SaldoSueltoTmp				= 0
    set @CantidadCajas				= 0
    set @CantidadSueltos			= 0
    set @CantidadCajasKardex	= 0


    insert #InfoLotes
          (Art_Id
          ,Lote
	        ,Vencimiento
	        ,Cantidad)
    select Art_Id
          ,Lote
	        ,Vencimiento
	        ,Cantidad
    from  @pInfoLotes
   
    
    
    --Busca si se trata de un articulo suelto
    select @Suelto      = Suelto
          ,@ArtPadre    = ArtPadre
          ,@Servicio    = Servicio 
          ,@Compuesto   = Compuesto 
          ,@SaldoPropio = SaldoPropio 
          ,@Lote        = Lote
    from  Articulo
    where Emp_Id = @pEmp_Id
    and   Art_Id = @pArt_Id
    if @@error <> 0  begin
      raiserror ('Error buscando artículo padre, articulo: %s', 16, 1, @pArt_Id)  
    end
    
    --Hace el rebajo de inventario solo si es un servicio    
    if @Servicio = 0 begin
      if @Suelto = 0 begin
        if @Compuesto = 0 or (@Compuesto = 1 and @SaldoPropio = 1) begin
          --Si es una caja se le suma o resta normal la cantidad al inventario

          if @Lote = 1 begin
            if 0 = (select count(*) from #InfoLotes) begin
              raiserror('No se indicaron los lotes para el articulo: %s', 16, 1, @pArt_Id)  
            end

            if @pCantidad <> (select CONVERT(float, isnull(sum(Cantidad),0)) from #InfoLotes) begin
              raiserror('La suma de los lotes debe de ser igual a la cantidad para el articulo: %s', 16, 1, @pArt_Id)  
            end
          end

          --Si es devolucion la cantidad viene negativo
          update ArticuloBodega set  Saldo              = Saldo - @pCantidad
                                    ,UltimaModificacion = getdate()
          where Emp_Id = @pEmp_Id
          and   Suc_Id = @pSuc_Id
          and   Bod_Id = @pBod_Id             
          and   Art_Id = @pArt_Id
          if @@error <> 0  begin
            raiserror ('Error rebajando de inventario, articulo: %s', 16, 1, @pArt_Id)  
          end


          --Crea el Kardex para cada articulo
          exec @SpResult = GuardaArticuloKardex @pEmp_Id, @pSuc_Id, @pBod_Id, @pArt_Id, @pCantidad, @pDetalle, @pUsuario_Id, 0, @pNombreEntidad, @pConsecutivo, @pClave
          if @@error <> 0  begin
            raiserror ('Error buscando ejecutando GuardaArticuloKardex, articulo: %s', 16, 1, @pArt_Id)  
          end



        
-----------------------------------------------------------------------------------------------
          while exists(select 1 from  #InfoLotes) begin
            set rowcount 1
            select @InfoLote        = Lote
                  ,@InfoVencimiento = Vencimiento
                  ,@InfoCantidad    = Cantidad
            from  #InfoLotes 
            set rowcount 0

            update ArticuloBodegaLote set Saldo               = Saldo - @InfoCantidad
                                         ,UltimaModificacion  = getdate()
            where Emp_Id      = @pEmp_Id
            and   Suc_Id      = @pSuc_Id
            and   Bod_Id      = @pBod_Id             
            and   Art_Id      = @pArt_Id
            and   Lote        = @InfoLote
            and   Vencimiento = @InfoVencimiento

            if @@rowcount = 0 begin

              if @InfoCantidad > 0 begin
                raiserror ('Error intentando rebajar existencia de un lote que no esta definido, articulo: %s', 16, 1, @pArt_Id)  
              end

              insert ArticuloBodegaLote
                    (Emp_Id
                    ,Suc_Id
                    ,Bod_Id
                    ,Art_Id
                    ,Lote
                    ,Vencimiento
                    ,Saldo)
              values(@pEmp_Id
                    ,@pSuc_Id
                    ,@pBod_Id
                    ,@pArt_Id
                    ,@InfoLote
                    ,@InfoVencimiento
                    ,abs(@InfoCantidad))

              if @@error <> 0  begin
                raiserror ('Error actualizando saldo ArticuloBodegaLote, articulo: %s', 16, 1, @pArt_Id)  
              end

            end

            --Crea el Kardex para cada articulo
            exec @SpResult = GuardaArticuloLoteKardex @pEmp_Id, @pSuc_Id, @pBod_Id, @pArt_Id, @InfoLote, @InfoVencimiento, @InfoCantidad, @pDetalle, @pUsuario_Id
            if @@error <> 0  begin
              raiserror ('Error buscando ejecutando GuardaArticuloLoteKardex, articulo: %s', 16, 1, @pArt_Id)  
            end

            delete #InfoLotes
            where Lote        = @InfoLote
            and   Vencimiento = @InfoVencimiento
          end


-----------------------------------------------------------------------------------------------

        end
        else begin

          --Crea el Kardex para el articulo articulo compuesto
          exec @SpResult = GuardaArticuloKardex @pEmp_Id, @pSuc_Id, @pBod_Id, @pArt_Id, @pCantidad, @pDetalle, @pUsuario_Id, 0, @pNombreEntidad, @pConsecutivo, @pClave
          if @@error <> 0  begin
            raiserror ('Error buscando ejecutando GuardaArticuloKardex, articulo: %s', 16, 1, @pArt_Id)  
          end

          --Busca la receta para el articulo
          declare Cur_Ingredientes cursor for
          select Ingrediente_Id 
                ,Cantidad * @pCantidad 
          from  ArticuloReceta
          where Emp_Id = @pEmp_Id
          and   Art_Id = @pArt_Id 

          open Cur_Ingredientes

          fetch next from Cur_Ingredientes 
          into @Ingrediente_Id, @IngredienteCantidad

          
          while @@FETCH_STATUS = 0 begin

            --Crea el Kardex para cada articulo
            exec @SpResult = GuardaArticuloKardex @pEmp_Id, @pSuc_Id, @pBod_Id, @Ingrediente_Id, @IngredienteCantidad, @pDetalle, @pUsuario_Id, 0, @pNombreEntidad, @pConsecutivo, @pClave
            if @@error <> 0  begin
              raiserror ('Error buscando ejecutando GuardaArticuloKardex, articulo: %s', 16, 1, @pArt_Id)  
            end
        
              --Si es devolucion la cantidad viene negativo
              update ArticuloBodega set  Saldo              = Saldo - @IngredienteCantidad
                                        ,UltimaModificacion = getdate()
              where Emp_Id = @pEmp_Id
              and   Suc_Id = @pSuc_Id
              and   Bod_Id = @pBod_Id             
              and   Art_Id = @Ingrediente_Id
              if @@error <> 0 or @@ROWCOUNT = 0  begin
                raiserror ('Error rebajando de inventario, no se encontro el articulo : %s', 16, 1, @pArt_Id)  
              end

                fetch next from Cur_Ingredientes 
                into @Ingrediente_Id, @IngredienteCantidad
              end

            close Cur_Ingredientes
            deallocate Cur_Ingredientes

        end   
      end
      else begin
        --Busca el factor de conversion de la caja (padre)
        select @FactorConversion = FactorConversion
        from  Articulo
        where Emp_Id = @pEmp_Id
        and   Art_Id = @ArtPadre
        if @@error <> 0  begin
          raiserror ('Error buscando factor de conversion, articulo: %s', 16, 1, @pArt_Id)  
        end
        
        --Busca el saldo actual del suelto
        select @SaldoActual = Saldo
        from  ArticuloBodega
        where Emp_Id = @pEmp_Id
        and   Suc_Id = @pSuc_Id
        and   Bod_Id = @pBod_Id             
        and   Art_Id = @pArt_Id
        if @@error <> 0 or @@rowcount = 0 begin
          raiserror ('Error buscando saldo actual, articulo: %s', 16, 1, @pArt_Id)  
        end
        
        
        if @pCantidad > 0 begin --Si es una salida de inventario
          --Le resta los sueltos al saldo actual
          set @SaldoSueltoTmp = @SaldoActual - @pCantidad
          --Calcula la cantidad de cajas que debe rebajar
          set @CantidadCajas  = abs(@SaldoSueltoTmp)/@FactorConversion
          --Le quita el equivalente en sueltos a las cajas que desea rebajar
          set @CantidadSueltos = @SaldoSueltoTmp + (@CantidadCajas*@FactorConversion)
          
          --Si la cantidad de sueltos es negativa quiere decir que tiene que 
          --abrir una caja, entonces rebaja otra caja y calcula los suletos que quedan
          if @CantidadSueltos<0 begin
            set @CantidadCajas   = @CantidadCajas + 1
            set @CantidadSueltos = @CantidadSueltos + @FactorConversion
          end
          
          --Rebaja la cantidad de cajas
          if @CantidadCajas>0 begin
						set @DetalleKardex = @pDetalle + ' - Ajuste Sueltos (Resta)'
          
            --Crea el Kardex para la caja
            exec @SpResult = GuardaArticuloKardex @pEmp_Id, @pSuc_Id, @pBod_Id, @ArtPadre, @CantidadCajas, @DetalleKardex, @pUsuario_Id, 0, @pNombreEntidad, @pConsecutivo, @pClave
            if @@error <> 0  begin
              raiserror ('Error buscando ejecutando GuardaArticuloKardex, articulo: %s', 16, 1, @pArt_Id)  
            end          
          
            update ArticuloBodega set  Saldo              = Saldo - @CantidadCajas
                                      ,UltimaModificacion = getdate()
            where Emp_Id = @pEmp_Id
            and   Suc_Id = @pSuc_Id
            and   Bod_Id = @pBod_Id             
            and   Art_Id = @ArtPadre
            if @@error <> 0  begin
              raiserror ('Error rebajando de inventario, articulo: %s', 16, 1, @pArt_Id)  
            end            
          end
          
          --Actualiza la cantidad de sueltos
          update ArticuloBodega set  Saldo              = @CantidadSueltos
                                    ,UltimaModificacion = getdate()
          where Emp_Id = @pEmp_Id
          and   Suc_Id = @pSuc_Id
          and   Bod_Id = @pBod_Id             
          and   Art_Id = @pArt_Id
          if @@error <> 0  begin
            raiserror ('Error rebajando de inventario, articulo: %s', 16, 1, @pArt_Id)  
          end
          
          --Crea el Kardex para el suelto
          exec @SpResult = GuardaArticuloKardex @pEmp_Id, @pSuc_Id, @pBod_Id, @pArt_Id, @pCantidad, @pDetalle, @pUsuario_Id, 1, @pNombreEntidad, @pConsecutivo, @pClave
          if @@error <> 0  begin
            raiserror ('Error buscando ejecutando GuardaArticuloKardex, articulo: %s', 16, 1, @pArt_Id)  
          end          
          
        end     
        else begin --Si es una entrada al inventario
          --Le suma los sueltos al saldo actual
          set @SaldoSueltoTmp = @SaldoActual + (-@pCantidad)
          --Calcula la cantidad de cajas que debe agregar
          set @CantidadCajas  = abs(@SaldoSueltoTmp)/@FactorConversion
          --Le quita el equivalente en sueltos a las cajas que desea rebajar
          set @CantidadSueltos = @SaldoSueltoTmp - (@CantidadCajas*@FactorConversion)
          
          --Suma la cantidad de cajas
          if @CantidadCajas>0 begin
            --Crea el Kardex para la caja
            set @DetalleKardex = @pDetalle + ' - Ajuste Sueltos (Suma)'
            set @CantidadCajasKardex = (@CantidadCajas * -1)
            
            exec @SpResult = GuardaArticuloKardex @pEmp_Id, @pSuc_Id, @pBod_Id, @ArtPadre, @CantidadCajasKardex, @DetalleKardex, @pUsuario_Id, 0, @pNombreEntidad, @pConsecutivo, @pClave
            if @@error <> 0  begin
              raiserror ('Error buscando ejecutando GuardaArticuloKardex, articulo: %s', 16, 1, @pArt_Id)  
            end    
          
            update ArticuloBodega set  Saldo              = Saldo + @CantidadCajas
                                      ,UltimaModificacion = getdate()
            where Emp_Id = @pEmp_Id
            and   Suc_Id = @pSuc_Id
            and   Bod_Id = @pBod_Id             
            and   Art_Id = @ArtPadre
            if @@error <> 0  begin
              raiserror ('Error rebajando de inventario, articulo: %s', 16, 1, @pArt_Id)  
            end            
          end
          
          --Actualiza la cantidad de sueltos
          update ArticuloBodega set  Saldo              = @CantidadSueltos
                                    ,UltimaModificacion = getdate()
          where Emp_Id = @pEmp_Id
          and   Suc_Id = @pSuc_Id
          and   Bod_Id = @pBod_Id             
          and   Art_Id = @pArt_Id
          if @@error <> 0  begin
            raiserror ('Error rebajando de inventario, articulo: %s', 16, 1, @pArt_Id)  
          end
          
          --Crea el Kardex para el suelto
          exec @SpResult = GuardaArticuloKardex @pEmp_Id, @pSuc_Id, @pBod_Id, @pArt_Id, @pCantidad, @pDetalle, @pUsuario_Id, 1, @pNombreEntidad, @pConsecutivo, @pClave
          if @@error <> 0  begin
            raiserror ('Error buscando ejecutando GuardaArticuloKardex, articulo: %s', 16, 1, @pArt_Id)  
          end           
                        
        end 
      end --Fin suelto
    end --Fin Servicio


    --Genera informacion de notificacion de encargo 08 Julio 2017 10:47 am
    exec @SpResult = CreaNotificacionEncargos @pEmp_Id
    if @@error <> 0  begin
      raiserror ('Error buscando ejecutando CreaNotificacionEncargos, articulo: %s', 16, 1, @pArt_Id)  
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


