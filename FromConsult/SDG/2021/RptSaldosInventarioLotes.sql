
GO

/****** Object:  StoredProcedure [dbo].[RptSaldosInventarioLotes]    Script Date: 1/21/2021 9:56:50 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE procedure [dbo].[RptSaldosInventarioLotes] --1,1,1,'M',1
(
 @pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pTipo char
,@pCantidad as float
)
as
begin

  create table #Reporte(
	  Art_Id varchar(13) NOT NULL,
	  Nombre varchar(100) NOT NULL,
	  Costo money NOT NULL,
	  Precio money NOT NULL,
	  Saldo float NOT NULL,
      Margen float NOT NULL,
      Lote varchar(20),
	  VencimientoLote datetime,
	  Ubicacion varchar(20) NOT NULL,
	  NombreProveedor varchar(50) NOT NULL,
    Comprometido FLOAT,
    CostoComprometido MONEY,
	  ExentoIVA bit,
    Activo bit)

  
  IF @pTipo = 'M' BEGIN
    if @pCantidad<>0 begin
      insert #Reporte
            (Art_Id
            ,Nombre
	          ,Costo
	          ,Precio
	          ,Saldo
			  ,Lote
			  ,VencimientoLote
            ,Margen
	          ,Ubicacion
	          ,NombreProveedor
            ,Comprometido
            ,CostoComprometido
            ,ExentoIVA
            ,Activo)
      SELECT a.Art_Id 
            ,a.Nombre 
            ,b.Costo
            ,b.Precio 
            ,c.Saldo
			,c.Lote
			 ,c.Vencimiento
            ,b.Margen
            ,b.Ubicacion            
            ,' --- '
            ,b.Comprometido
            ,b.CostoPromedio
			      ,a.ExentoIV
            ,a.Activo 
      FROM  Articulo a 
            INNER JOIN  ArticuloBodega b             
            ON a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id 
            INNER JOIN  SubCategoria e
            ON a.Emp_Id = e.Emp_Id and a.Cat_Id = e.Cat_Id and a.SubCat_Id = e.SubCat_Id
			,ArticuloBodegaLote  c
      WHERE b.Emp_Id  = @pEmp_Id
	  AND  c.Emp_Id = b.Emp_Id
      AND   b.Suc_Id  = @pSuc_Id
	  AND   c.Suc_Id  = b.Suc_Id
      AND   b.Bod_Id  = @pBod_Id 
	  AND   c.Bod_Id = b.Bod_Id
	  AND   c.Art_Id = a.Art_Id
	  AND    a.Lote = 1
      AND   c.Saldo  >= iif(@pCantidad = 0, c.Saldo, @pCantidad)
      ORDER BY e.Nombre asc, b.Saldo desc
    end
    else begin
       insert #Reporte
            (Art_Id
            ,Nombre
	          ,Costo
	          ,Precio
	          ,Saldo
			  ,Lote
			  ,VencimientoLote
            ,Margen
	          ,Ubicacion
	          ,NombreProveedor
            ,Comprometido
            ,CostoComprometido
            ,ExentoIVA
            ,Activo)
      SELECT a.Art_Id 
            ,a.Nombre 
            ,b.Costo
            ,b.Precio 
            ,c.Saldo 
			,c.Lote
			,c.Vencimiento
            ,b.Margen
            ,b.Ubicacion            
            ,' --- '
            ,b.Comprometido
            ,b.CostoPromedio
			      ,a.ExentoIV
            ,a.Activo 
      FROM  Articulo a 
            INNER JOIN  ArticuloBodega b             
            ON a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id 
            INNER JOIN  SubCategoria e
            ON a.Emp_Id = e.Emp_Id and a.Cat_Id = e.Cat_Id and a.SubCat_Id = e.SubCat_Id,
			ArticuloBodegaLote c 
      WHERE b.Emp_Id  = @pEmp_Id
	   AND  c.Emp_Id = b.Emp_Id
	   AND   c.Art_Id = a.Art_Id
      AND   b.Suc_Id  = @pSuc_Id 
	   AND   c.Suc_Id  = b.Suc_Id
      AND   b.Bod_Id  = @pBod_Id 
	  AND   c.Bod_Id =  b.Bod_Id
	  AND    a.Lote = 1
      AND   c.Saldo  >= iif(@pCantidad = 0, c.Saldo, @pCantidad)
      ORDER BY e.Nombre asc, c.Saldo desc
    end
  END
  ELSE BEGIN
       insert #Reporte
            (Art_Id
            ,Nombre
	          ,Costo
	          ,Precio
	          ,Saldo
			  ,Lote
			  ,VencimientoLote
            ,Margen
	          ,Ubicacion
	          ,NombreProveedor
            ,Comprometido
            ,CostoComprometido
            ,Activo)
      SELECT a.Art_Id 
            ,a.Nombre 
            ,b.Costo
            ,b.Precio 
            ,c.Saldo
			,c.Lote
			,c.Vencimiento
            ,b.Margen
            ,b.Ubicacion            
            ,' --- '
            ,b.Comprometido
            ,b.CostoPromedio
            ,a.Activo 
      FROM  Articulo a 
            INNER JOIN  ArticuloBodega b             
            ON a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id 
            INNER JOIN  SubCategoria e
            ON a.Emp_Id = e.Emp_Id and a.Cat_Id = e.Cat_Id and a.SubCat_Id = e.SubCat_Id,
			ArticuloBodegaLote c
      WHERE b.Emp_Id  = @pEmp_Id
	  AND   c.Art_Id = a.Art_Id
	  AND  c.Emp_Id = b.Emp_Id
	  AND   c.Suc_Id  = b.Suc_Id
      AND   b.Suc_Id  = @pSuc_Id 
      AND   b.Bod_Id  = @pBod_Id 
	  AND   c.Bod_Id =  b.Bod_Id
	  AND    a.Lote = 1
      AND   c.Saldo  >= iif(@pCantidad = 0, c.Saldo, @pCantidad)
      ORDER BY e.Nombre asc, b.Saldo desc
  END
  update a set a.NombreProveedor = c.Nombre 
  from  #Reporte a,
        ArticuloProveedor b,
        Proveedor c
  where a.Art_Id  = b.Art_Id 
  and   b.Emp_Id  = c.Emp_Id
  and   b.Prov_Id = c.Prov_Id 
  and   b.Emp_Id  = @pEmp_Id 

  select * from  #Reporte
end



GO


