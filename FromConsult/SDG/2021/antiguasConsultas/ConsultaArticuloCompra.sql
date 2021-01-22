
GO

/****** Object:  StoredProcedure [dbo].[ConsultaArticuloCompra]    Script Date: 1/21/2021 11:13:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[ConsultaArticuloCompra]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pArt_Id varchar(13))
as
begin
  begin try
    --Declaracion variables
    declare @Art_Id varchar(13)
    declare @Articulo table (	Art_Id varchar(13) NOT NULL,
	                            Nombre varchar(100) NOT NULL,
	                            FactorConversion smallint NOT NULL,
	                            ExentoIV bit NOT NULL,
	                            Suelto bit NULL,
	                            ArtPadre varchar(13) NOT NULL,
	                            Activo bit NOT NULL,
	                            Saldo float NOT NULL,
	                            Transito float NOT NULL,
	                            Costo money NOT NULL,
	                            Margen float NOT NULL,
	                            Precio money NOT NULL,
	                            UnidadMedidaNombre varchar(50) NOT NULL,
	                            FechaUltimaVenta datetime NOT NULL,
	                            PromedioVenta float NOT NULL,
	                            Minimo float NOT NULL,
	                            Maximo float NOT NULL,
	                            Servicio bit NOT NULL,
                              Compuesto bit NOT NULL,
                              SaldoPropio bit NOT NULL,
							  SolicitaCantidad bit NOT NULL)
	                            

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
          ,Transito
          ,Costo
          ,Margen
          ,Precio
          ,UnidadMedidaNombre
          ,FechaUltimaVenta
          ,PromedioVenta
          ,Minimo
          ,Maximo
          ,Servicio
          ,Compuesto
          ,SaldoPropio
		  ,SolicitaCantidad)
    select a.Art_Id
          ,a.Nombre 
          ,a.FactorConversion
          ,a.ExentoIV
          ,a.Suelto
          ,isnull(a.ArtPadre,'') 
          ,a.Activo
          ,b.Saldo
          ,b.Transito
          ,b.Costo
          ,b.Margen
          ,b.Precio
          ,c.Nombre 
          ,b.FechaUltimaVenta
          ,b.PromedioVenta
          ,b.Minimo
          ,b.Maximo
          ,a.Servicio
          ,a.Compuesto 
          ,a.SaldoPropio 
		  ,a.SolicitarCantidad
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
    
   
    
    select @pEmp_Id as Emp_Id
          ,@pSuc_Id as Suc_Id
          ,@pBod_Id as Bod_Id
          ,Art_Id
          ,Nombre as NombreArticulo
          ,FactorConversion
          ,ExentoIV
          ,Suelto
          ,isnull(ArtPadre,'') as ArtPadre
          ,Activo
          ,Saldo
          ,Transito
          ,Costo
          ,Margen
          ,Precio
          ,UnidadMedidaNombre as NombreUnidad
          ,FechaUltimaVenta
          ,PromedioVenta
          ,Minimo
          ,Maximo
          ,Servicio 
          ,Compuesto
          ,SaldoPropio
		  ,SolicitaCantidad
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


