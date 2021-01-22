USE [UniversalPruebas]
GO

/****** Object:  StoredProcedure [dbo].[FE_GetDocument]    Script Date: 12/16/2020 11:08:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[FE_GetDocument]
(
  @pCantidad smallint
)
AS
  BEGIN
    
    Begin Try

      create table #ReciboDinero
      (
        Emp_Id                     smallint
       ,Suc_Id                     smallint
       ,Caja_Id                    smallint
       ,TipoDoc_Id                 varchar(2)
       ,ReciboDinero_Id            int
       ,Estudiante_Id              int
       ,Estudiante_Nombre          varchar(80)
       ,Estudiante_NombreComercial varchar(80)
       ,Estudiante_TipoId          varchar(2)
       ,Estudiante_Identificacion  varchar(12)
       ,Estudiante_Id_Extranjero   varchar(20)
       ,Estudiante_TelefonoArea    numeric(3, 0)
       ,Estudiante_Telefono        numeric(20, 0)
       ,Estudiante_FaxArea         numeric(3, 0)
       ,Estudiante_Fax             numeric(20, 0)
       ,Estudiante_Email           varchar(50)
       ,Estudiante_Provincia       varchar(1)
       ,Estudiante_Canton          varchar(2)
       ,Estudiante_Distrito        varchar(2)
       ,Estudiante_Barrio          varchar(2)
       ,Estudiante_OtrasSenas      varchar(160)
       ,Fecha                      datetime
       ,Comentario                 varchar(400)
       ,TipoCambio                 float
       ,CondicionVenta             varchar(2)
       ,PlazoCredito               varchar(10)
       ,Moneda                     varchar(3)
       ,Ref_TipoDoc                varchar(2)
       ,Ref_Numero                 varchar(50)
       ,Ref_FechaEmision           datetime
       ,Ref_Codigo                 varchar(2)
       ,Ref_Razon                  varchar(180)
       ,Emisor_Id                  int
       ,Clave                      varchar(50)
       ,Consecutivo                varchar(20)
       ,Token                      varchar(200)
      )

      create table #ReciboDineroPago
      (
        Emp_Id          smallint
       ,ReciboDinero_Id int
       ,TipoDoc_Id      varchar(2)
       ,Pago_Id         smallint
       ,TipoPago_Id     varchar(2)
      )

      create table #ReciboDineroCuota
      (
        Emp_Id                smallint
       ,ReciboDinero_Id       int
       ,TipoDoc_Id            varchar(2)
       ,Cuota_Id              smallint
       ,UnidadMedida          varchar(10)
       ,UnidadMedidaC         varchar(20)
       ,ArtCodigoTipo         varchar(2)
       ,ArtCodigo             varchar(20)
       ,Detalle               varchar(160)
       ,Cantidad              float
       ,PrecioUnitario        float
       ,MontoTotal            float
       ,NaturalezaDescuento   varchar(80)
       ,MontoDescuento        float
       ,SubTotal              float
       ,MontoImpuesto         float
       ,Total                 float
       ,Servicio              bit
       ,Exento                bit
       ,Comentario            varchar(500)
       ,Impuesto_Codigo       varchar(2)
       ,Impuesto_Tarifa       varchar(2)
       ,Porcentaje_Impuesto   float
			 ,CabysCodigo           varchar(13)
      )

      create table #ReciboDineroProducto
      (
        Emp_Id                smallint
       ,ReciboDinero_Id       int
       ,TipoDoc_Id            varchar(2)
       ,Linea_Id              int
       ,UnidadMedida          varchar(10)
       ,UnidadMedidaC         varchar(20)
       ,ArtCodigoTipo         varchar(2)
       ,ArtCodigo             varchar(20)
       ,Producto_Id           int
       ,Detalle               varchar(50)
       ,Cantidad              float
       ,PrecioUnitario        float
       ,MontoTotal            float
       ,MontoDescuento        float
       ,NaturalezaDescuento   varchar(80)
       ,SubTotal              float
       ,MontoImpuesto         float
       ,Total                 float
       ,Servicio              bit
       ,Exento                bit
       ,Comentario            varchar(500)
       ,Impuesto_Codigo       varchar(2)
       ,Impuesto_Tarifa       varchar(2)
       ,Porcentaje_Impuesto   float
       ,Exo_TipoDocumento     varchar(2)
       ,Exo_NumDocumento      varchar(17)
       ,Exo_NombreInstitucion varchar(100)
       ,Exo_FechaEmision      datetime
       ,Exo_MontoImpuesto     float
       ,Exo_PorcentajeCompra  float
	     ,CabysCodigo           varchar(13)
      )

      set rowcount @pCantidad;
    
      insert into #ReciboDinero
      (
        Emp_Id
       ,Suc_Id
       ,Caja_Id
       ,TipoDoc_Id
       ,ReciboDinero_Id
       ,Estudiante_Id
       ,Estudiante_Nombre
       ,Estudiante_NombreComercial
       ,Estudiante_TipoId
       ,Estudiante_Identificacion
       ,Estudiante_Id_Extranjero
       ,Estudiante_TelefonoArea
       ,Estudiante_Telefono
       ,Estudiante_FaxArea
       ,Estudiante_Fax
       ,Estudiante_Email
       ,Estudiante_Provincia
       ,Estudiante_Canton
       ,Estudiante_Distrito
       ,Estudiante_Barrio
       ,Estudiante_OtrasSenas
       ,Fecha
       ,Comentario
       ,TipoCambio
       ,CondicionVenta
       ,PlazoCredito
       ,Moneda
       ,Ref_TipoDoc
       ,Ref_Numero
       ,Ref_FechaEmision
       ,Ref_Codigo
       ,Ref_Razon
       ,Emisor_Id
       ,Clave
       ,Consecutivo
       ,Token
      )
      select b.Emp_Id 
            ,b.Suc_Id
            ,b.Caja_Id
            ,a.TipoDoc
            ,b.ReciboDinero_Id
            ,b.Estudiante_Id
            ,SUBSTRING(LTRIM(RTRIM(b.Nombre)), 1, 80) -- Nombre
            ,SUBSTRING(LTRIM(RTRIM(b.Nombre)), 1, 80) -- Nombre Comercial
            ,case c.TipoIdentificacion_Id
                when 1 then '01'
                when 2 then '02'
                when 3 then '03'
                when 4 then '04'
                when 999 then '01'
            end -- Tipo de Identificación
            ,case c.TipoIdentificacion_Id
                 when 1 then SUBSTRING(c.Identificacion, 1, 12)
                 when 2 then SUBSTRING(c.Identificacion, 1, 12)
                 when 3 then SUBSTRING(c.Identificacion, 1, 12)
                 when 4 then SUBSTRING(c.Identificacion, 1, 12)
                 when 999 then '000000000'
            end -- Número de Indetificación
            ,case c.TipoIdentificacion_Id
                 when 1 then ''
                 when 2 then ''
                 when 3 then ''
                 when 4 then ''
                 when 999 then SUBSTRING(c.Identificacion, 1, 20)
            end -- Identificacion Extranjero
            ,506 -- Telefono Area
            ,case c.TelefonoCelular 
              when '.' then 0
              else 
                CAST(case ISNUMERIC(c.TelefonoCelular)
                  when 1 then c.TelefonoCelular
                  when 0 then 0
                end as numeric(20, 0))
             end -- Telefono
            ,506 -- Fax Area
            ,0 -- Fax
            ,SUBSTRING(c.Email, 1, 50)
            ,CAST(c.Provincia_Id as varchar(1))
            ,REPLICATE('0', 2 - LEN(c.Canton_Id)) + CAST(c.Canton_Id as varchar)
            ,REPLICATE('0', 2 - LEN(c.Distrito_Id)) + CAST(c.Distrito_Id as varchar)
            ,'00'
            ,case LTRIM(RTRIM(c.LugarResidencia))
                when '' then 'NO DEFINIDA'
                else SUBSTRING(c.LugarResidencia, 1, 160)
             end
            ,case a.TipoDoc
                when '03' then b.FechaAnulacion
                else b.Fecha
             end
            ,SUBSTRING(b.Comentario, 1, 400)
            ,case b.Moneda_Id
                when 2 then b.TipoCambioDolar
                else 0
             end -- Tipo Cambio
            ,'01' -- Condicion Venta -> 01 Contado
            ,'' -- Plazo Credito
            ,case b.Moneda_Id
                when 1 then 'CRC'
                when 2 then 'USD'
                else ''
             end -- Codigo Moneda
            ,case a.TipoDoc
                when '03' then ISNULL((select ISNULL(e.TipoDoc, '99') from FE_FacturaElectronica e with (nolock) where a.Emp_Id = e.Emp_Id and a.ReciboDinero_Id = e.ReciboDinero_Id and e.TipoDoc IN ('01','04')), '99')
                else '00'
             end -- Refernecia Tipo de Documento
            ,case a.TipoDoc
                when '03' then ISNULL((select ISNULL(e.Clave, CONVERT(varchar, a.ReciboDinero_Id)) from FE_FacturaElectronica e with (nolock) where a.Emp_Id = e.Emp_Id and a.ReciboDinero_Id = e.ReciboDinero_Id and e.TipoDoc IN ('01','04')), CONVERT(varchar, a.ReciboDinero_Id))
                else ''
             end -- Referencia Numero de Documento
            ,case a.TipoDoc
                when '03' then b.Fecha
                else '19000101'
             end -- Referencia fecha de Emisión
            ,case a.TipoDoc
                when '03' then '01'
                else '00'
             end -- Referencia Codigo
            ,case a.TipoDoc
                when '03' then 'Anulación de Recibo de Dinero: ' + CONVERT(varchar, b.ReciboDinero_Id)
                else ''
             end -- Referencia Razón
            ,a.Emisor_Id
            ,a.Clave
            ,a.Consecutivo
            ,d.Token
      from FE_FacturaElectronica a
      JOIN ReciboDinero b ON a.Emp_Id = b.Emp_Id and a.ReciboDinero_Id = b.ReciboDinero_Id
      JOIN Estudiante c ON b.Emp_Id = c.Emp_Id and b.Estudiante_Id = c.Estudiante_Id
      JOIN FE_Parametros d ON b.Emp_Id = d.Emp_Id and b.Suc_Id = d.Suc_Id
      where a.Procesar  = 1
      and   a.Procesado = 0
      order by b.Fecha asc

      set rowcount 0;

      insert into #ReciboDineroPago
      (
        Emp_Id
       ,ReciboDinero_Id
       ,TipoDoc_Id
       ,Pago_Id
       ,TipoPago_Id
      )
      select distinct b.Emp_Id
            ,b.ReciboDinero_Id
            ,a.TipoDoc_Id
            ,ROW_NUMBER() over (partition by b.ReciboDinero_Id order by case b.TipoPago_Id when 5 then 1 else b.TipoPago_Id end)
            ,case case b.TipoPago_Id
                    when 5 then 1
                    else b.TipoPago_Id
                  end
              when 1 then '01' -- Efectivo
              when 2 then '02' -- Tarjeta
              when 3 then '03' -- Cheque
              when 4 then '04' -- Déposito - Transferencia
              when 5 then '01' -- Dólalres
              else '99'        -- Otro
            end
      from #ReciboDinero a
      INNER JOIN ReciboDineroPago b ON a.Emp_Id = b.Emp_Id and a.ReciboDinero_Id = b.ReciboDinero_Id
      group by b.Emp_Id
              ,b.ReciboDinero_Id
              ,a.TipoDoc_Id
              ,case b.TipoPago_Id
                  when 5 then 1
                  else b.TipoPago_Id
                end

      declare @PorcCuota float = (select PorcIV from Empresa where Emp_Id = 1)	

      insert into #ReciboDineroCuota
      (
        Emp_Id
       ,ReciboDinero_Id
       ,TipoDoc_Id
       ,Cuota_Id
       ,UnidadMedida
       ,UnidadMedidaC
       ,ArtCodigoTipo
       ,ArtCodigo
       ,Detalle
       ,Cantidad
       ,PrecioUnitario
       ,MontoTotal
       ,MontoDescuento
       ,NaturalezaDescuento
       ,SubTotal
       ,MontoImpuesto
       ,Total
       ,Servicio
       ,Exento
       ,Comentario
       ,Impuesto_Codigo
       ,Impuesto_Tarifa
       ,Porcentaje_Impuesto
			 ,CabysCodigo
      )
      select b.Emp_Id
            ,b.ReciboDinero_Id
            ,a.TipoDoc_Id
            ,b.Cuota_Id
            ,'Sp' -- Unidad de Medida
            ,'' -- Unidad de Medida Comercial
            ,'01' -- Articulo Codigo Tipo
            ,'C' + CAST(b.Emp_Id as varchar) + '-' + CAST(b.ReciboDinero_Id as varchar) + '-' + CAST(b.Cuota_Id as varchar) -- Articulo Codigo
            ,SUBSTRING(c.Nombre + ' (Cuota ' + CONVERT(varchar, b.Cuota_id) + ') ' + CONVERT(varchar, d.FechaCuotaDesde, 103) + ' - ' + CONVERT(varchar, d.FechaCuotaHasta, 103), 1, 160) -- Detalle
            ,1 -- Cantidad
            ,b.MontoBruto / case a.Moneda when 'USD' then a.TipoCambio else 1 end -- Precio Unitario
            ,b.MontoBruto / case a.Moneda when 'USD' then a.TipoCambio else 1 end -- Monto Total
            ,b.MontoDescuento / case a.Moneda when 'USD' then a.TipoCambio else 1 end -- Monto Descuento
            ,case b.MontoDescuento
                when 0 then 'NA'
                else 'DESCUENTO'
             end -- Naturaleza Descuento
            ,b.MontoNeto / case a.Moneda when 'USD' then a.TipoCambio else 1 end -- Sub Total
            ,b.MontoIVA -- Monto Impuestos
            ,(b.MontoNeto + b.MontoIVA) / case a.Moneda when 'USD' then a.TipoCambio else 1 end -- Total
            ,1 -- Servicio
            ,0 -- Exento
            ,'' -- Comentario
            ,'01'
            ,'03'
            ,@PorcCuota
						,ISNULL(e.CabysCodigo, '')
      from #ReciboDinero a
      JOIN ReciboDineroCuota b ON a.Emp_Id = b.Emp_Id and a.ReciboDinero_Id = b.ReciboDinero_Id
      JOIN Grupo c ON b.Emp_Id = c.Emp_Id and b.Grupo_Id = c.Grupo_Id
      JOIN EstudianteGrupoCuota d ON b.Emp_Id = d.Emp_Id and b.Estudiante_Id = d.Estudiante_Id and b.Grupo_Id = d.Grupo_Id and b.Item_Id = d.Item_Id and b.Cuota_Id = d.Cuota_Id
			JOIN Sucursal e ON a.Emp_Id = e.Emp_Id and a.Suc_Id = e.Suc_Id

      insert into #ReciboDineroProducto
      (
        Emp_Id
       ,ReciboDinero_Id
       ,TipoDoc_Id
       ,Linea_Id
       ,Producto_Id
       ,Detalle
       ,UnidadMedida
       ,UnidadMedidaC
       ,ArtCodigoTipo
       ,ArtCodigo
       ,Cantidad
       ,PrecioUnitario
       ,MontoTotal
       ,MontoDescuento
       ,NaturalezaDescuento
       ,SubTotal
       ,MontoImpuesto
       ,Total
       ,Servicio
       ,Exento
       ,Comentario
       ,Impuesto_Codigo
       ,Impuesto_Tarifa
       ,Porcentaje_Impuesto
       ,Exo_TipoDocumento
       ,Exo_NumDocumento
       ,Exo_NombreInstitucion
       ,Exo_FechaEmision
       ,Exo_MontoImpuesto
       ,Exo_PorcentajeCompra
			 ,CabysCodigo
      )
      select b.Emp_Id
            ,b.ReciboDinero_Id
            ,a.TipoDoc_Id
            ,b.Linea_Id
            ,b.Producto_Id
            ,c.Nombre
            ,iif(b.Servicio = 1, 'Sp', 'Unid') -- Unidad de Medida
            ,'' -- Unidad de Medida Comercial
            ,'01' -- Articulo Codigo Tipo
            ,case b.Servicio
                when 1 then 'S'
                when 0 then 'P'
             end + CAST(b.Emp_Id as varchar) + '-' + CAST(b.ReciboDinero_Id as varchar) + '-' + CAST(b.Linea_Id as varchar) -- Articulo Codigo
            ,b.Cantidad -- Cantidad
            ,b.Precio / case a.Moneda when 'USD' then a.TipoCambio else 1 end -- Precio Unitario
            ,(b.Cantidad * b.Precio) / case a.Moneda when 'USD' then a.TipoCambio else 1 end -- Monto Total
            ,(b.Cantidad * b.MontoDesc) / case a.Moneda when 'USD' then a.TipoCambio else 1 end -- Monto Descuento
            ,case b.MontoDesc
                when 0 then 'NA'
                else 'DESCUENTO'
             end -- Naturaleza Descuento
            ,((b.Cantidad * b.Precio) - (b.Cantidad * b.MontoDesc)) / case a.Moneda when 'USD' then a.TipoCambio else 1 end -- Sub Total
            ,(b.MontoIV * b.Cantidad) / case a.Moneda when 'USD' then a.TipoCambio else 1 end -- Monto Impuestos
            ,(b.PrecioNeto * b.Cantidad) / case a.Moneda when 'USD' then a.TipoCambio else 1 end -- Total
            ,b.Servicio
            ,c.ExentoIV
            ,'' -- Comentario
            ,case c.ExentoIV
                when 0 then c.CodigoImpuesto
                else '00'
             end -- Código del Impuesto
            ,c.Tarifa_Id -- Tarifa del Impuesto
            ,c.PorcentajeImpuesto --Porcentaje Impuesto
            ,'00' -- Exoneración Tipo de Documento
            ,'' -- Exoneración Número de Documento
            ,'' -- Exoneración Nombre de la Instituación
            ,'19000101' -- Fecha de Emisión del Documento
            ,0 -- Monto de Impuesto Exonerado
            ,0 -- Porcentaje de compra exonerado
						,ISNULL(c.CabysCodigo, '')
      from #ReciboDinero a
      JOIN ReciboDineroProducto b ON a.Emp_Id = b.Emp_Id and a.ReciboDinero_Id = b.ReciboDinero_Id
      JOIN Producto c ON b.Emp_Id = c.Emp_Id and b.Producto_Id = c.Producto_Id
      JOIN Empresa d ON b.Emp_Id = d.Emp_Id

      -- Retorna la información de los documentos

      select *
      from #ReciboDinero
      order by Fecha asc

      select *
      from #ReciboDineroPago

      select *
      from #ReciboDineroCuota

      select *
      from #ReciboDineroProducto

    End Try
    Begin Catch

      declare @errorMessage  varchar(MAX);
      declare @errorSeverity int;
      declare @errorState    int;

      select @errorMessage  = 'Error in FE_GetDocument() [' + ERROR_MESSAGE() + ']',
             @errorSeverity = ERROR_SEVERITY(),
             @errorState    = ERROR_STATE();

      raiserror (@errorMessage, @errorSeverity, @errorState)

    End Catch

  END
GO


