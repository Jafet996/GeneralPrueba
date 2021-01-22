USE [SDG-DMO]
GO

/****** Object:  StoredProcedure [dbo].[ValidaCodigoArticulo]    Script Date: 12/21/2020 2:07:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER   procedure [dbo].[ValidaCodigoArticulo]
(@pEmp_Id smallint
,@Prov_Id int
,@pArt_Id varchar(30))
as
begin

  declare  @Art_Id    varchar(13)
          ,@Nombre    varchar(100)
          ,@Servicio  bit

  ---------------------------------------------------------
  declare @Tipo  int 
  --0 - No Existe
  --1 - Articulo Interno, 
  --2 - Articulo Equivalente
  --3 - Articulo Equivalente Proveedor
  set @Tipo     = 0
  set @Art_Id   = ''
  set @Nombre   = 'NO EXISTE'
  set @Servicio = 0

  ---------------------------------------------------------

  select @Art_Id    = b.Art_Id
        ,@Nombre    = b.Nombre 
        ,@Servicio  = b.Servicio 
  from  ArticuloEquivalenteProveedor a (nolock)
  inner join Articulo b (nolock) on a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id 
  where a.Emp_Id          = @pEmp_Id
  and   a.Prov_Id           = @Prov_Id 
  and   a.ArtEquivalente_Id = @pArt_Id
  if @@ROWCOUNT > 0 begin
    set @Tipo = 3
  end
  else begin
    select @Art_Id = b.Art_Id
          ,@Nombre = b.Nombre 
          ,@Servicio  = b.Servicio 
    from  ArticuloEquivalente a (nolock)
    inner join Articulo b (nolock) on a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id 
    where a.Emp_Id          = @pEmp_Id
    and   a.ArtEquivalente_Id = @pArt_Id
    if @@ROWCOUNT > 0 begin
      set @Tipo = 2
    end
    else begin
      select @Art_Id    = Art_Id
            ,@Nombre    = Nombre 
            ,@Servicio  = Servicio 
      from  Articulo 
      where Emp_Id = @pEmp_Id
      and   Art_Id = @pArt_Id
      if @@ROWCOUNT > 0 begin
        set @Tipo = 1
      end
    end
  end

  select @Tipo      Tipo
        ,@Art_Id    Art_Id
        ,@Nombre    Nombre
        ,@Servicio  Servicio
        

end
GO

