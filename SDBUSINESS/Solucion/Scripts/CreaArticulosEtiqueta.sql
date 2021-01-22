INSERT INTO [Articulo]
           ([Emp_Id]
           ,[Art_Id]
           ,[Nombre]
           ,[Cat_Id]
           ,[SubCat_Id]
           ,[Departamento_Id]
           ,[UnidadMedida_Id]
           ,[FactorConversion]
           ,[ExentoIV]
           ,[Suelto]
           ,[ArtPadre]
           ,[SolicitarCantidad]
           ,[PermiteFacturar]
           ,[CodigoCantidad]
           ,[Activo]
           ,[UltimaModificacion])
select 1
      ,CodigoBarra
      ,Nombre
      ,201
      ,1
      ,21
      ,3
      ,1
      ,1
      ,1
      ,NULL
      ,0
      ,1
      ,1
      ,1
      ,getdate()
from ArticuloRomana           



