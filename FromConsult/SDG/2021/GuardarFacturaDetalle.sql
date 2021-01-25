
GO

/****** Object:  StoredProcedure [dbo].[GuardaFacturaDetalle]    Script Date: 1/25/2021 8:34:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER   procedure [dbo].[GuardaFacturaDetalle]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pCaja_Id smallint
,@pBod_Id smallint
,@pTipoDoc_Id smallint
,@pDocumento_Id bigint
,@pDetalle_Id smallint
,@pArt_Id varchar(13)
,@pCantidad float
,@pFecha datetime
,@pCosto money
,@pPrecio money
,@pPorcDescuento money
,@pMontoDescuento money
,@pMontoIV money
,@pTotalLinea money
,@pExentoIV bit
,@pSuelto bit
,@pUsuario_Id varchar(20)
,@pObservacion varchar(500)
,@pServicio bit
,@pNombreEntidad varchar(80)
,@pConsecutivo varchar(20)
,@pClave varchar(50)
,@pLote bit
,@pGarantia bit
,@pInfoLotes dbo.InfoLotes readonly)
as
begin
  begin try

    
  
    declare  @SpResult int
            ,@Nombre varchar(50)
    
    
    --Busca el nombre del tipo de documento
    select @Nombre = Nombre
    from  TipoDocumento
    where Emp_Id     = @pEmp_Id
    and   TipoDoc_Id = @pTipoDoc_Id
    if @@error <> 0  begin
      raiserror ('Error buscando el nombre del tipo de documento, articulo: %s', 16, 1, @pArt_Id)  
    end
    
    
    --Guarda el detalle de la factura           
    insert into FacturaDetalle
               (Emp_Id
               ,Suc_Id
               ,Caja_Id
               ,TipoDoc_Id
               ,Documento_Id
               ,Detalle_Id
               ,Art_Id
               ,Cantidad
               ,Fecha
               ,Costo
               ,Precio
               ,PorcDescuento
               ,MontoDescuento
               ,MontoIV
               ,TotalLinea
               ,ExentoIV
               ,Suelto
               ,Observacion
               ,Servicio
               ,Lote
               ,Garantia)
         values
               (@pEmp_Id
               ,@pSuc_Id
               ,@pCaja_Id
               ,@pTipoDoc_Id
               ,@pDocumento_Id
               ,@pDetalle_Id
               ,@pArt_Id
               ,@pCantidad
               ,@pFecha
               ,@pCosto
               ,@pPrecio
               ,@pPorcDescuento
               ,@pMontoDescuento
               ,@pMontoIV
               ,@pTotalLinea
               ,@pExentoIV
               ,@pSuelto
               ,@pObservacion
               ,@pServicio
               ,@pLote
               ,@pGarantia)
               
    if @@error <> 0  begin
      raiserror ('Error guardando detalle factura , articulo: %s', 16, 1, @pArt_Id)  
    end
    
    --Si es una devolucion el monto se envia negativo para que se haga la devolucion al inventario
    exec @SpResult = RebajaSumaIventario @pEmp_Id, @pSuc_Id, @pBod_Id, @pArt_Id ,@pCantidad, @Nombre, @pUsuario_Id, @pNombreEntidad, @pConsecutivo, @pClave, @pInfoLotes 
    if @SpResult<>0 begin
      raiserror ('Error ejecutando, RebajaSumaIventario, para el articulo: %s', 16, 1, @pArt_Id)
    end
    
    
    --Actualiza la decha de la ultima venta
    update ArticuloBodega set FechaUltimaVenta = getdate()
    where Emp_Id = @pEmp_Id
    and   Suc_Id = @pSuc_Id
    and   Bod_Id = @pBod_Id
    and   Art_Id = @pArt_Id
    if @@error <> 0 begin
      raiserror ('Error actualizando fecha ultima venta, articulo: %s', 16, 1, @pArt_Id)  
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


