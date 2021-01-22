USE [SDG-DMO]
GO

/****** Object:  StoredProcedure [dbo].[CreaArticulo]    Script Date: 12/23/2020 2:03:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER   procedure [dbo].[CreaArticulo]
(@pEmp_Id smallint
,@pArt_Id varchar(13)
,@pNombre varchar(100)
,@pCat_Id smallint
,@pSubCat_Id smallint
,@pDepartamento_Id smallint
,@pUnidadMedida_Id smallint
,@pExentoIV bit
,@pServicio bit
,@pCosto money
,@pMargen float
,@pCabysCodigo varchar(13))
as
begin

  begin try

  begin transaction

  insert into Articulo
              (Emp_Id
              ,Art_Id
              ,Nombre
              ,Cat_Id
              ,SubCat_Id
              ,Departamento_Id
              ,UnidadMedida_Id
              ,FactorConversion
              ,ExentoIV
              ,Suelto
              ,ArtPadre
              ,SolicitarCantidad
              ,PermiteFacturar
              ,CodigoCantidad
              ,CodigoCantidadTipo
              ,BusquedaRapida
              ,Frecuente
              ,Servicio
              ,TipoAcumulacion_Id
              ,CuentaIngreso
              ,Activo
              ,Compuesto
              ,SaldoPropio
              ,UltimaModificacion
              ,Anotaciones
              ,CodigoInterno
              ,CodigoProveedor
              ,CalculaCantidadFactura
              ,VentaSinSaldo
              ,ExentoIC
              ,PorcIC
              ,Lote
			  ,CabysCodigo
			  )
       VALUES 
              (@pEmp_Id
              ,@pArt_Id
              ,@pNombre
              ,@pCat_Id
              ,@pSubCat_Id
              ,@pDepartamento_Id
              ,@pUnidadMedida_Id
              ,1
              ,@pExentoIV
              ,0
              ,null
              ,0
              ,1
              ,0
              ,-1
              ,0
              ,0
              ,@pServicio 
              ,0
              ,''
              ,1
              ,1
              ,1
              ,'19000101'
              ,''
              ,''
              ,''
              ,0
              ,1
              ,0
              ,0
              ,''
			  ,@pCabysCodigo)
      if @@error <> 0 or @@rowcount = 0 begin
        raiserror ('Error Insertando Articulo', 16, 1)  
      end     
      

      insert into ArticuloBodega
                 (Emp_Id
                 ,Suc_Id
                 ,Bod_Id
                 ,Art_Id
                 ,Saldo
                 ,Comprometido
                 ,Transito
                 ,CostoPromedio
                 ,Costo
                 ,Margen
                 ,MargenMayorista
                 ,Margen3
                 ,Margen4
                 ,Margen5
                 ,Precio
                 ,PrecioMayorista
                 ,Precio3
                 ,Precio4
                 ,Precio5
                 ,FechaIniDescuento
                 ,FechaFinDescuento
                 ,PorcDescuento
                 ,FechaUltimaVenta
                 ,PromedioVenta
                 ,Minimo
                 ,Maximo
                 ,Activo
                 ,Ubicacion
                 ,UltimaModificacion
                 ,CostoNeto)
      select Emp_Id
            ,Suc_Id
            ,Bod_Id
            ,@pArt_Id 
            ,0
            ,0
            ,0
            ,@pCosto 
            ,@pCosto 
            ,@pMargen
            ,0
            ,0
            ,0
            ,0
            ,@pCosto * ((@pMargen/100) + 1)
            ,0
            ,0
            ,0
            ,0
            ,'19000101'
            ,'19000101'
            ,0
            ,'19000101'
            ,0
            ,0
            ,0
            ,1
            ,''
            ,'19000101'
            ,0
      from  Bodega 
      where Emp_Id = @pEmp_Id 

      if @@error <> 0 or @@rowcount = 0 begin
        raiserror ('Error Insertando ArticuloBodega', 16, 1)  
      end     


      if @pExentoIV = 0 begin
        INSERT INTO ArticuloImpuesto
                   (Emp_Id
                   ,Art_Id
                   ,Codigo_Id
                   ,Tarifa_Id
                   ,Porcentaje)
             VALUES
                   (@pEmp_Id
                   ,@pArt_Id
                   ,'01'
                   ,'08'
                   ,13)
        if @@error <> 0 or @@rowcount = 0 begin
          raiserror ('Error Insertando ArticuloImpuesto', 16, 1)  
        end     
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


