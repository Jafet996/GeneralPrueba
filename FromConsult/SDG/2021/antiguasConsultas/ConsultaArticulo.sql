USE [SDG-DMO]
GO

/****** Object:  StoredProcedure [dbo].[ConsultaArticulo]    Script Date: 1/19/2021 2:24:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[ConsultaArticulo]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pArt_Id varchar(13)
,@pCliente_Id as int)
as
begin
  begin try
    --Declaracion variables
    declare  @Art_Id varchar(13)
			,@Precio_Id smallint
    declare @Articulo table (	Art_Id varchar(13) NOT NULL,
	                            Nombre varchar(100) NOT NULL,
	                            FactorConversion smallint NOT NULL,
	                            ExentoIV bit NOT NULL,
	                            Suelto bit NULL,
	                            ArtPadre varchar(13) NOT NULL,
	                            Activo bit NOT NULL,
	                            Saldo float NOT NULL,
	                            Costo money NOT NULL,
	                            Margen float NOT NULL,
	                            Precio float NOT NULL,
	                            FechaIniDescuento datetime NOT NULL,
	                            FechaFinDescuento datetime NOT NULL,
	                            PorcDescuento float NOT NULL,
	                            Conjunto bit NOT NULL,
	                            SolicitarCantidad bit NOT NULL,
	                            PermiteFacturar bit NOT NULL,
	                            UnidadMedidaNombre varchar(50) NOT NULL,
	                            Servicio bit NOT NULL,
                              PrecioVentaPublico float NOT NULL,
                              Compuesto bit NOT NULL,
                              SaldoPropio bit NOT NULL,
                              CalculaCantidadFactura float NOT NULL,
                              CodigoCABYS VARCHAR(100) NULL
                              )

	--Busca el precio del cliente
	if @pCliente_Id > 0 begin
		select @Precio_Id = Precio_Id
		from	Cliente 
		where	Emp_Id		= @pEmp_Id 
		and		Cliente_Id	= @pCliente_Id 
		if @@rowcount = 0 or @@error <> 0 begin
		  raiserror ('Error buscando cliente, articulo: %s', 16, 1, @pArt_Id)  
		end
	end 
	else begin
		set @Precio_Id = 1
	end


    --Verifica si se trata de un codigo equivalente
    select @Art_Id = Art_Id
    from  ArticuloEquivalente
    where Emp_Id            = @pEmp_Id 
    and   ArtEquivalente_Id = @pArt_Id
    if @@error <> 0  begin
      raiserror ('Error buscando codigo equivalente, articulo: %s', 16, 1, @pArt_Id)  
    end
    
    if @Art_Id is null begin
      set @Art_Id = @pArt_Id
    end
   
    --Busca la informacion del articulo
    insert @Articulo
          (Art_Id
          ,Nombre
          ,FactorConversion
          ,ExentoIV
          ,Suelto
          ,ArtPadre
          ,Activo
          ,Saldo
          ,Costo
          ,Margen
          ,Precio
          ,FechaIniDescuento
          ,FechaFinDescuento
          ,PorcDescuento
          ,Conjunto
          ,SolicitarCantidad
          ,PermiteFacturar
          ,UnidadMedidaNombre
          ,Servicio
          ,PrecioVentaPublico
          ,Compuesto 
          ,SaldoPropio
          ,CalculaCantidadFactura
          ,CodigoCABYS)
    select a.Art_Id
          ,a.Nombre
          ,a.FactorConversion
          ,a.ExentoIV
          ,a.Suelto
          ,isnull(a.ArtPadre,'')
          ,a.Activo
          ,b.Saldo
          ,b.Costo
          ,case 
            when @Precio_Id = 2	then b.MargenMayorista
            when @Precio_Id = 3 then b.Margen3
            when @Precio_Id = 4 then b.Margen4
            when @Precio_Id = 5 then b.Margen5
						else b.Margen
					 end as Margen
          ,case 
            when @Precio_Id = 2	then b.PrecioMayorista
            when @Precio_Id = 3	then b.Precio3
            when @Precio_Id = 4	then b.Precio4
            when @Precio_Id = 5	then b.Precio5
						else b.Precio 
					 end as Precio
          ,b.FechaIniDescuento
          ,b.FechaFinDescuento
          ,b.PorcDescuento
          ,0
          ,a.SolicitarCantidad
          ,a.PermiteFacturar
          ,c.Nombre
          ,a.Servicio 
          ,b.Precio as PrecioVentaPublico
          ,a.Compuesto
          ,a.SaldoPropio
          ,a.CalculaCantidadFactura
          ,isnull(a.CabysCodigo,'')
    from  Articulo a,
          ArticuloBodega b,
          UnidadMedida c
    where a.Emp_Id          = b.Emp_Id
    and   a.Art_Id          = b.Art_Id
    and   a.Emp_Id          = c.Emp_Id
    and   a.UnidadMedida_Id = c.UnidadMedida_Id
    and   b.Emp_Id          = @pEmp_Id
    and   b.Suc_Id          = @pSuc_Id
    and   b.Bod_Id          = @pBod_Id
    and   b.Art_Id          = @Art_Id
    if @@error <> 0  begin
      raiserror ('Error buscando, articulo: %s', 16, 1, @pArt_Id)  
    end
    
    -- Verifica si tiene algun articulo conjunto registrado
    update a set Conjunto = 1
    from  @Articulo a,
          ArticuloConjunto b
    where b.Emp_Id = @pEmp_Id
    and   b.Art_Id = @Art_Id
    and   a.Art_Id = b.Art_Id


    --Pone el descuento en cero para los articulos que no estan dentro del rango de fecha
    update @Articulo set PorcDescuento = 0
    where getdate() not between FechaIniDescuento and FechaFinDescuento


    --Cambia el precio segun la promocion para todos menos para los clientes con precio al Detalle
    if @Precio_Id <> 1 begin
      update a set a.Precio = b.Precio
                  ,PorcDescuento = 0
      from  @Articulo a,
            ArticuloPromocion b
      where a.Art_Id = b.Art_Id
      and   b.Emp_Id = @pEmp_Id
      and   getdate() between FechaInicio and FechaFinal
    end
   
    
    select @pEmp_Id as Emp_Id
          ,@pSuc_Id as Suc_Id
          ,@pBod_Id as Bod_Id
          ,Art_Id
          ,Nombre
          ,FactorConversion
          ,ExentoIV
          ,Suelto
          ,ArtPadre
          ,Activo
          ,Saldo
          ,Costo
          ,Margen
          ,Precio
          ,FechaIniDescuento
          ,FechaFinDescuento
          ,PorcDescuento
          ,Conjunto
          ,SolicitarCantidad
          ,PermiteFacturar
          ,UnidadMedidaNombre
          ,Servicio 
          ,PrecioVentaPublico 
          ,Compuesto
          ,SaldoPropio
          ,CalculaCantidadFactura
          ,CodigoCABYS
    from  @Articulo
    
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


