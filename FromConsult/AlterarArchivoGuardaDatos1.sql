USE [UAUBlueCross_STAGE]
GO

/****** Object:  StoredProcedure [dbo].[ArchivoGuardarDatos]    Script Date: 12/15/2020 8:32:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER Procedure [dbo].[ArchivoGuardarDatos]
(
  @pComp_Id	    smallint
 ,@pUser_Id	    varchar(50)
 ,@pNombreCarga varchar(50)
 ,@pProyecto_Id smallint
 ,@pProd_Id     smallint
 ,@pTran        bit = 1
)
AS
BEGIN

  Begin Try

    If @pTran = 1
      begin transaction

      -- Declaracion de variables
      Declare	 @MaxId	int
              ,@Fecha datetime
              ,@Cantidad int
                            
	    -- Inicializa valores
      select   @Fecha     = Getdate()
              ,@MaxId     = 0
              ,@Cantidad  = 0

------ Integra el documento de excel completo con el machote de carga estandar
Delete From Tempclientes Where comp_Id = @pComp_Id
Insert TempClientes
           ([COMP_ID]
           ,[ID]
           ,[MONEDA]
           ,[TIPODEDOCUMENTO]
           ,[ENTE]
           ,[Miembro_Cedula]
           ,[FECHADENACIMIENTO]
           ,[LUGARDENACIMIENTO]
           ,[FECHAACTUAL]
           ,[EDAD]
           ,[PRIMERNOMBRE]
           ,[SEGUNDONOMBRE]
           ,[PRIMERAPELLIDO]
           ,[SEGUNDOAPELLIDO]
           ,[NACIONALIDAD]
           ,[SEXO]
           ,[ESTADOCIVIL]
           ,[PROVINCIA]
           ,[CANTON]
           ,[DISTRITO]
           ,[PUNTOSCARDINALES]
           ,[TELEFONO]
           ,[CELULAR]
           ,[APARTADOPOSTAL]
           ,[OCUPACION ]
           ,[CORREOELECTRONICO]
           ,[DIRECCIONMEDIOPARARECIBIRNOTIFICACIONES]
           ,[CONTRATACIONDELACOBERTURA]
           ,[PRIMAMENSUAL]
           ,[PERIODICIDADDEPAGO]
           ,[MEDIODEPAGO]
           ,[NODECUENTAOTARJETADECREDITO]
           ,[FECHAVENCIMIENTO]
           ,[TELEFONO3]
           ,[TELEFONO4]
           ,[TELEFONO5]
           ,[TELEFONO6]
           ,[TELEFONO7]
           ,[TELEFONO8]
           ,[TELEFONO9]
           ,[TELEFONO10]
           ,[BIN]
           ,[CIUDAD]
		   ,[RANGOINGRESO])

select
@pComp_Id
,ID
,''
           ,[Tipo_documento]
,''
           ,[Documento identificación]
           ,[Fecha_nacimiento: Formato DDMMYYYY]
,''
,Getdate()
,0
           ,[Nombres]
,''
,''
,''
,''
,Case [Sexo] When 'M' Then 'Masculino' When 'F' Then 'Femenino' Else [Sexo]  End
,Estado_civil
,''
,Canton
,''
           ,ISNULL([Dirección: Hasta 300 caracteres], '')
           ,[Celular: 8 posiciones 2]
           ,[Celular: 8 posiciones 1]
,''
,''
           ,[Email 1]
,''
,''
,'0'
,''
,''
           ,[Numero de tarjeta de credito]
           ,[Fecha Vencimiento Tarjeta]
           ,[Celular: 8 posiciones 3]
           ,[Celular: 8 posiciones 4]
           ,[Celular: 8 posiciones 5]
           ,[Telefono Casa: 8 posiciones 1]
           ,[Telefono Casa: 8 posiciones 2]
           ,[Telefono Casa: 8 posiciones 3]
           ,[Telefono Casa: 8 posiciones 4]
           ,[Telefono Casa: 8 posiciones 5]
           ,[Opcion]
           ,[Ciudad]
		   ,Rango_ingreso
from TempClientesFull where comp_Id = @pComp_Id

------




	If Exists(Select * From TempClientes Where Comp_Id=@pComp_Id and LTRIM(rtrim(miembro_Cedula))='')
	Begin
		--Raiserror 40000 
		raiserror ('Archivo con cédulas en blanco. Imposible procesar el archivo.',16,1)
		Return 40000
	End	


	-- Cambio solicitado: En el excel pueden venir varias tarjetas para la misma cedula
	Update TempClientes Set Excluye = 0 Where Comp_Id=@pComp_Id
	select t.*,
	row_number()over (partition by miembro_cedula order by miembro_cedula) total 
	Into #Excluye
	from tempclientes t Where Comp_Id= @pComp_Id
				
	Update TempClientes Set Excluye = 1 Where Comp_Id= @pComp_Id
	and Id in (Select Id From #Excluye Where total > 1)
	-- 

	---------------------------------------------------------------------------------------              
	-- 1. Primero actualiza los registros de miembro fisico con lo que viene en la carga --
	-- para las cedulas existentes														 --
	---------------------------------------------------------------------------------------              
	-- Saca una imagen antes de la actualizacion
	INSERT INTO MiembroFisicoImagen
           (Comp_Id
           ,Miembro_Id
           ,Miembro_Codigo
           ,Miembro_CodigoNuevo
           ,Miembro_Cedula
           ,Miembro_Nombre
           ,Miembro_NombreContacto
           ,Miembro_FechaInicio
           ,Miembro_Telefono1
           ,Miembro_Telefono2
           ,Miembro_Telefono3
           ,Miembro_Telefono4
           ,Miembro_Telefono5
           ,Miembro_Telefono6
           ,Miembro_Telefono7
           ,Miembro_Telefono8
           ,Miembro_Telefono9
           ,Miembro_Telefono10
           ,Miembro_BaseDatos
           ,Miembro_TelefonoLocalizacion
           ,Miembro_Nodo
           ,Miembro_FechaCarga
           ,Miembro_ServiciosActuales
           ,Miembro_Direccion
           ,Miembro_Email
           ,Nacionalidad_Id
           ,Miembro_Cedula_Cliente
           ,Genero_Id
           ,EstadoCivil_Id
           ,Miembro_FechaNacimiento
           ,Miembro_Provincia
           ,Miembro_Canton
           ,Miembro_Distrito
           ,TipoIdentificacion_Id
           ,TipoDireccion_Id
           ,Titulo_Id
           ,Miembro_SegundoNombre
           ,Miembro_PrimerApellido
           ,Miembro_SegundoApellido
           ,Miembro_TelefonoValido
           ,Miembro_TelefonoContacto
           ,User_id
           ,Referido_Id
           ,Miembro_Activo
           ,Miembro_Apartado
           ,Miembro_Sugerido
           ,Miembro_MedioNotificacion
           ,Miembro_Moneda
           ,LugarDeNacimiento
           ,Ente
           ,Ocupacion
           ,EstadoCivil
           ,Genero
           ,Edad
           ,Nacionalidad
           ,FechaActual
           ,ContratacionDeLaCobertura
           ,PrimaMensual
           ,PeriodicidadDePago
           ,MedioDePago
           ,NoDeCuentaOTarjetaDeCredito
           ,FechaVencimiento
           ,TipoDeDocumento
           ,FechaHoraImagen
           ,Miembro_Ciudad
           ,Profesion_Id)
           
      Select 
      
            a.Comp_Id
           ,a.Miembro_Id
           ,a.Miembro_Codigo
           ,a.Miembro_CodigoNuevo
           ,a.Miembro_Cedula
           ,a.Miembro_Nombre
           ,a.Miembro_NombreContacto
           ,a.Miembro_FechaInicio
           ,a.Miembro_Telefono1
           ,a.Miembro_Telefono2
           ,a.Miembro_Telefono3
           ,a.Miembro_Telefono4
           ,a.Miembro_Telefono5
           ,a.Miembro_Telefono6
           ,a.Miembro_Telefono7
           ,a.Miembro_Telefono8
           ,a.Miembro_Telefono9
           ,a.Miembro_Telefono10
           ,a.Miembro_BaseDatos
           ,a.Miembro_TelefonoLocalizacion
           ,a.Miembro_Nodo
           ,a.Miembro_FechaCarga
           ,a.Miembro_ServiciosActuales
           ,a.Miembro_Direccion
           ,a.Miembro_Email
           ,a.Nacionalidad_Id
           ,a.Miembro_Cedula_Cliente
           ,a.Genero_Id
           ,a.EstadoCivil_Id
           ,a.Miembro_FechaNacimiento
           ,a.Miembro_Provincia
           ,a.Miembro_Canton
           ,a.Miembro_Distrito
           ,a.TipoIdentificacion_Id
           ,a.TipoDireccion_Id
           ,a.Titulo_Id
           ,a.Miembro_SegundoNombre
           ,a.Miembro_PrimerApellido
           ,a.Miembro_SegundoApellido
           ,a.Miembro_TelefonoValido
           ,a.Miembro_TelefonoContacto
           ,a.User_id
           ,a.Referido_Id
           ,a.Miembro_Activo
           ,a.Miembro_Apartado
           ,a.Miembro_Sugerido
           ,a.Miembro_MedioNotificacion
           ,a.Miembro_Moneda
           ,a.LugarDeNacimiento
           ,a.Ente
           ,a.Ocupacion
           ,a.EstadoCivil
           ,a.Genero
           ,a.Edad
           ,a.Nacionalidad
           ,a.FechaActual
           ,a.ContratacionDeLaCobertura
           ,a.PrimaMensual
           ,a.PeriodicidadDePago
           ,a.MedioDePago
           ,a.NoDeCuentaOTarjetaDeCredito
           ,a.FechaVencimiento
           ,a.TipoDeDocumento
           ,Getdate()
           ,Miembro_Ciudad
           ,Profesion_Id
           
         FROM
			MiembroFisico a,
			TempClientes b
		WHERE
			a.Comp_Id = b.Comp_Id
			and a.Miembro_Cedula = b.Miembro_Cedula		



	-- Actualiza
	UPDATE MiembroFisico
	SET
		--MiembroFisico.Comp_Id						= TempClientes.a.Comp_Id, 
		--MiembroFisico.Miembro_Id					= TempClientes.a.Id + @MaxId,
		--MiembroFisico.Miembro_Codigo				= TempClientes.a.Miembro_Cedula, 
		--MiembroFisico.Miembro_CodigoNuevo			= TempClientes.'', 
		--MiembroFisico.Miembro_Cedula				= TempClientes.a.Miembro_Cedula,            
		MiembroFisico.Miembro_Nombre				= Replace(Replace(Replace(Replace(Replace(TempClientes.PRIMERNOMBRE,',',''),'.',''),'''',''),'"',''),'-',''),
		MiembroFisico.Miembro_SegundoNombre			= Replace(Replace(Replace(Replace(Replace(TempClientes.SEGUNDONOMBRE,',',''),'.',''),'''',''),'"',''),'-',''),
		MiembroFisico.Miembro_PrimerApellido		= Replace(Replace(Replace(Replace(Replace(TempClientes.PRIMERAPELLIDO,',',''),'.',''),'''',''),'"',''),'-',''),
		MiembroFisico.Miembro_SegundoApellido		= Replace(Replace(Replace(Replace(Replace(TempClientes.SEGUNDOAPELLIDO,',',''),'.',''),'''',''),'"',''),'-',''),
		MiembroFisico.Miembro_Telefono1				= TempClientes.CELULAR,
		MiembroFisico.Miembro_Telefono2				= TempClientes.TELEFONO,
		MiembroFisico.Miembro_Telefono3				= TempClientes.TELEFONO3,
		MiembroFisico.Miembro_Telefono4				= TempClientes.TELEFONO4,
		MiembroFisico.Miembro_Telefono5				= TempClientes.TELEFONO5,
		MiembroFisico.Miembro_Telefono6				= TempClientes.TELEFONO6,
		MiembroFisico.Miembro_Telefono7				= TempClientes.TELEFONO7,
		MiembroFisico.Miembro_Telefono8				= TempClientes.TELEFONO8,
		MiembroFisico.Miembro_Telefono9				= TempClientes.TELEFONO9,
		MiembroFisico.Miembro_Telefono10			= TempClientes.TELEFONO10,
		MiembroFisico.Miembro_Ciudad				= TempClientes.CIUDAD,
		MiembroFisico.Miembro_BaseDatos				= @pNombreCarga,
		MiembroFisico.Miembro_FechaCarga			= Getdate(),
		MiembroFisico.Miembro_Direccion				= TempClientes.PUNTOSCARDINALES,
		MiembroFisico.Miembro_Email					= TempClientes.CORREOELECTRONICO,
		MiembroFisico.Miembro_FechaNacimiento		= TempClientes.FECHADENACIMIENTO,
		MiembroFisico.Miembro_Provincia				= TempClientes.PROVINCIA,
		MiembroFisico.Miembro_Canton				= TempClientes.CANTON,
		MiembroFisico.Miembro_Distrito				= TempClientes.DISTRITO,
		MiembroFisico.Miembro_Apartado						= TempClientes.APARTADOPOSTAL,
		MiembroFisico.Miembro_MedioNotificacion				= TempClientes.DIRECCIONMEDIOPARARECIBIRNOTIFICACIONES,
		MiembroFisico.Miembro_Moneda						= TempClientes.MONEDA,
		MiembroFisico.LugarDeNacimiento				= TempClientes.LUGARDENACIMIENTO,
		MiembroFisico.Ente							= TempClientes.ENTE,
		MiembroFisico.Ocupacion						= TempClientes.OCUPACION,
		MiembroFisico.EstadoCivil					= TempClientes.ESTADOCIVIL,
		MiembroFisico.EstadoCivil_Id                = TempClientes.ESTADOCIVIL,
		MiembroFisico.Genero						= TempClientes.SEXO,
		MiembroFisico.Edad							= TempClientes.EDAD,
		MiembroFisico.Nacionalidad					= TempClientes.NACIONALIDAD,
		MiembroFisico.FechaActual					= TempClientes.FECHAACTUAL,
		MiembroFisico.ContratacionDeLaCobertura		= TempClientes.CONTRATACIONDELACOBERTURA,
		MiembroFisico.PrimaMensual					= TempClientes.PRIMAMENSUAL,
		MiembroFisico.PeriodicidadDePago			= TempClientes.PERIODICIDADDEPAGO,
		MiembroFisico.MedioDePago					= TempClientes.MEDIODEPAGO,
		MiembroFisico.NoDeCuentaOTarjetaDeCredito	= TempClientes.NODECUENTAOTARJETADECREDITO,
		MiembroFisico.FechaVencimiento				= TempClientes.FECHAVENCIMIENTO,
		MiembroFisico.TipoDeDocumento				= TempClientes.TIPODEDOCUMENTO,
		MiembroFisico.Miembro_Sugerido						= 'Cobertura: ' + TempClientes.CONTRATACIONDELACOBERTURA + ' Prima: ' + TempClientes.PRIMAMENSUAL + ' Pago: ' + TempClientes.PERIODICIDADDEPAGO, 
		MiembroFisico.RangoIngreso                  = TempClientes.RANGOINGRESO
		--MiembroFisico.TipoIdentificacion_Id		= TempClientes.0,
		--MiembroFisico.TipoDireccion_Id			= TempClientes.0,
		--MiembroFisico.Titulo_Id					= TempClientes.0,
		--MiembroFisico.Nacionalidad_Id				= TempClientes.0,
		--MiembroFisico.Genero_Id					= TempClientes.0,
		--MiembroFisico.EstadoCivil_Id				= TempClientes.0,

	FROM TempClientes
	WHERE MiembroFisico.Comp_Id = TempClientes.Comp_Id and
		MiembroFisico.Miembro_Cedula = TempClientes.Miembro_Cedula
	---

	---------------------------------------------------------------------------------------              
	-- 2. Luego agrega a miembro fisico los registros nuevos que vienen en la carga		 --
	---------------------------------------------------------------------------------------              

              
      -- Crea la relacion Miembro-Proyecto
      insert into MiembroFisicoProyecto
            (Comp_Id
            ,Miembro_Cedula
            ,Proyecto_Id)
      Select a.Comp_Id
            ,a.Miembro_Cedula
            ,@pProyecto_Id
      From	TempClientes a
      Where	a.Comp_Id = @pComp_Id
      and  not exists (Select *	
			              From	MiembroFisicoProyecto b
                    where a.Comp_Id = b.Comp_Id
                    and   a.Miembro_Cedula = b.Miembro_Cedula
                    and   b.Proyecto_Id = @pProyecto_Id)
                    and ISNULL(Excluye,0)=0           

   -- Crea la relacion Miembro-Producto
      insert into MiembroFisicoProductoCarga
            (Comp_Id
            ,Miembro_Cedula
            ,Proyecto_Id
            ,Prod_Id)
      Select a.Comp_Id
            ,a.Miembro_Cedula
            ,@pProyecto_Id
            ,@pProd_Id
      From	TempClientes a
      Where	a.Comp_Id = @pComp_Id
      and  not exists (Select *	
			              From	MiembroFisicoProductoCarga b
                    where a.Comp_Id = b.Comp_Id
                    and   a.Miembro_Cedula = b.Miembro_Cedula
                    and   b.Proyecto_Id = @pProyecto_Id
                    and   b.Prod_Id = @pProd_Id)
                    and ISNULL(Excluye,0)=0           





    -- Crea la relacion Miembro-Tarjetas
      insert into MiembroFisicoTarjeta
            (Comp_Id
            ,Miembro_Cedula
            ,Proyecto_Id
            ,Tipo
            ,TarjetaNumero
            ,Vencimiento
            ,Estado
            ,TarjetaCodigo
            ,BIN)
      Select a.Comp_Id
            ,a.Miembro_Cedula
            ,@pProyecto_Id
            --,Case Substring(BIN,1,1) When '3' Then 'AMEX' When '4' Then 'Visa' When '5' Then 'Mastercard' Else 'N/A' End
            --,'N/A'
            ,BIN
            ,Substring(a.NODECUENTAOTARJETADECREDITO, 1,20)
            , Right('0' + Convert(varchar,datepart(month,a.FECHAVENCIMIENTO)),2) + '/' + Right(Convert(Varchar,datepart(year,a.FECHAVENCIMIENTO)),2)
			--,'01/01'
            ,'SS'
            --,Case Substring(BIN,1,1) When '3' Then '10' When '4' Then 'XZ' When '5' Then 'XV' Else '10' End
            ,'10'
            ,BIN


      From	TempClientes a
      Where	a.Comp_Id = @pComp_Id
      and  not exists (Select *	
			              From	MiembroFisicoTarjeta b
                    where a.Comp_Id = b.Comp_Id
                    and   a.Miembro_Cedula = b.Miembro_Cedula
                    and   b.Proyecto_Id = @pProyecto_Id
                    and   a.NODECUENTAOTARJETADECREDITO = b.TarjetaNumero)
                    and   a.NODECUENTAOTARJETADECREDITO <> ''
                    and   a.FECHAVENCIMIENTO <> CONVERT(datetime, '19000101 00:00:00.000')


      -- Busca el maximo numero de miembro actual
      Select	@MaxId = IsNull (Miembro_Id,0) + 1
      From	MiembroFisico
      Where	Comp_Id	= @pComp_Id

      
            -- Almacena la cantidad de registros duplicados
            
      insert into ClientesRepetidos
            (Comp_Id
            ,Miembro_Cedula
            ,Miembro_Nombre
            ,Miembro_Direccion
            ,Miembro_Telefono1
            ,Miembro_Telefono2
            ,Miembro_Nodo
            ,Miembro_BaseDatos)
      Select a.Comp_Id
            ,a.Miembro_Cedula
            ,Substring(a.PRIMERNOMBRE, 1,50)
            ,Substring(a.PUNTOSCARDINALES, 1,500)
            ,Substring(a.CELULAR, 1,50)
            ,Substring(a.TELEFONO, 1,50)
            ,''
            ,@pNombreCarga
      From	TempClientes a
      Where	Comp_Id = @pComp_Id
      and   exists (Select *	
			              From	MiembroFisico b
                    where a.Comp_Id = b.Comp_Id
                    and   a.Miembro_Cedula = b.Miembro_Cedula)
                    
      if @@error <> 0 begin
        raiserror ('Se presentaron errores al insetar en ClientesRepetidos', 16, 1)  
      end



		INSERT INTO MiembroFisico
           (Comp_Id
           ,Miembro_Id
           ,Miembro_Codigo
           ,Miembro_CodigoNuevo
           ,Miembro_Cedula
           ,Miembro_Nombre
           ,Miembro_NombreContacto
           ,Miembro_FechaInicio
           ,Miembro_Telefono1
           ,Miembro_Telefono2
           ,Miembro_Telefono3
           ,Miembro_Telefono4
           ,Miembro_Telefono5
           ,Miembro_Telefono6
           ,Miembro_Telefono7
           ,Miembro_Telefono8
           ,Miembro_Telefono9
           ,Miembro_Telefono10
           ,Miembro_BaseDatos
           ,Miembro_TelefonoLocalizacion
           ,Miembro_Nodo
           ,Miembro_FechaCarga
           ,Miembro_ServiciosActuales
           ,Miembro_Direccion
           ,Miembro_Email
           ,Nacionalidad_Id
           ,Miembro_Cedula_Cliente
           ,Genero_Id
           ,EstadoCivil_Id
           ,Miembro_FechaNacimiento
           ,Miembro_Provincia
           ,Miembro_Canton
           ,Miembro_Distrito
           ,TipoIdentificacion_Id
           ,TipoDireccion_Id
           ,Titulo_Id
           ,Miembro_SegundoNombre
           ,Miembro_PrimerApellido
           ,Miembro_SegundoApellido
           ,Miembro_TelefonoValido
           ,Miembro_TelefonoContacto
           ,User_id
           ,Referido_Id
           ,Miembro_Activo
           ,Miembro_Apartado
           ,Miembro_Sugerido
           ,Miembro_MedioNotificacion
           ,Miembro_Moneda
           ,LugarDeNacimiento
           ,Ente
           ,Ocupacion
           ,EstadoCivil
           ,Genero
           ,Edad
           ,Nacionalidad
           ,FechaActual
           ,ContratacionDeLaCobertura
           ,PrimaMensual
           ,PeriodicidadDePago
           ,MedioDePago
           ,NoDeCuentaOTarjetaDeCredito
           ,FechaVencimiento
           ,TipoDeDocumento
           ,Miembro_Ciudad
		   ,RangoIngreso)

		Select 
                
           a.Comp_Id
           ,a.Id + @MaxId
           ,Substring(a.Miembro_Cedula, 1,50)
           ,Substring('', 1,50)
           ,Substring(a.Miembro_Cedula, 1,50)
           ,Substring(a.PRIMERNOMBRE, 1,150)
           ,Substring(a.PRIMERNOMBRE, 1,150)
           ,Getdate()
           ,Substring(a.CELULAR, 1,50)
           ,Substring(a.TELEFONO, 1,50)
           ,Substring(a.TELEFONO3, 1,50)
           ,Substring(a.TELEFONO4, 1,50)
           ,Substring(a.TELEFONO5, 1,50)
           ,Substring(a.TELEFONO6, 1,50)
           ,Substring(a.TELEFONO7, 1,50)
           ,Substring(a.TELEFONO8, 1,50)
           ,Substring(a.TELEFONO9, 1,50)
           ,Substring(a.TELEFONO10, 1,50)
           ,Substring(@pNombreCarga, 1,50)
           ,Substring('', 1,50)
           ,Substring('', 1,50)
           ,Getdate()
           ,Substring('', 1,200)
           ,Substring(a.PUNTOSCARDINALES, 1,500)
           ,Substring(a.CORREOELECTRONICO, 1,100)
           ,-1
           ,Substring(a.Miembro_Cedula, 1,20)
           ,-1
           ,a.ESTADOCIVIL
           ,a.FECHADENACIMIENTO
           ,Substring(a.PROVINCIA, 1,50)
           ,Substring(a.CANTON, 1,50)
           ,Substring(a.DISTRITO, 1,50)
           ,-1
           ,-1
           ,-1
           ,Substring(a.SEGUNDONOMBRE, 1,50)
           ,Substring(a.PRIMERAPELLIDO, 1,100)
           ,Substring(a.SEGUNDOAPELLIDO, 1,50)
           ,Substring('0000000000', 1,10)
           ,Substring('0000000000', 1,10)
           ,Substring(@pUser_Id, 1,50)
           ,0
           ,1
           ,Substring(a.APARTADOPOSTAL, 1,50)
           ,Substring('Cobertura: ' + a.CONTRATACIONDELACOBERTURA + ' Prima: ' + a.PRIMAMENSUAL + ' Pago: ' + a.PERIODICIDADDEPAGO , 1,100)
           ,Substring(a.DIRECCIONMEDIOPARARECIBIRNOTIFICACIONES, 1,50)
           ,Substring(a.MONEDA, 1,10)
           ,Substring(a.LUGARDENACIMIENTO, 1,255)
           ,a.ENTE
           ,Substring(a.OCUPACION, 1,255)
		   ,Substring(a.ESTADOCIVIL, 1,255)
           ,Substring(a.SEXO, 1,255)
           ,a.EDAD
           ,Substring(a.NACIONALIDAD, 1,255)
           ,a.FECHAACTUAL
           ,Substring(a.CONTRATACIONDELACOBERTURA, 1,50)
           ,Substring(a.PRIMAMENSUAL, 1,50)
           ,Substring(a.PERIODICIDADDEPAGO, 1,255)
           ,Substring(a.MEDIODEPAGO, 1,255)
           ,Substring(a.NODECUENTAOTARJETADECREDITO, 1,255)
           ,a.FECHAVENCIMIENTO
           ,Substring(a.TIPODEDOCUMENTO, 1,255)
           ,Substring(a.CIUDAD, 1,50)
		   ,a.RANGOINGRESO
		  From	TempClientes a
		  Where	Comp_Id = @pComp_Id
		  and not exists (Select *	
				              From	MiembroFisico b
                      where a.Comp_Id = b.Comp_Id
                      and   a.Miembro_Cedula = b.Miembro_Cedula)
        and ISNULL(Excluye,0)=0    


                      
                      
      -- Almacena la cantidad de registros guardados
      select @Cantidad = @@rowcount
    
    -- Relaciona el MiembroFisico con la Campaña -- Oscar Jiménez, 23 FEB 2018
    If EXISTS(select 1 from Campana where Comp_Id = @pComp_Id and Campana_Id = @pNombreCarga) Begin
      insert into CampanaMiembroFisico (
             Comp_Id
            ,Campana_Id
            ,Miembro_Id )
      select @pComp_Id
            ,@pNombreCarga
            ,a.Miembro_Id
      from MiembroFisico a
      where a.Comp_Id = @pComp_Id
      and   a.Miembro_BaseDatos = @pNombreCarga
      and   NOT EXISTS(select *
                       from CampanaMiembroFisico b
                       where a.Comp_Id    = b.Comp_Id
                       and   a.Miembro_Id = b.Miembro_Id
                       and   b.Campana_Id = @pNombreCarga)
    End -- FIN DE -> If EXISTS(select 1 from Campana where Comp_Id = @pComp_Id and Campana_Id = @pNombreCarga) 
 
	-- Actualiza campos de IDS
		Update MiembroFisico Set MiembroFisico.Nacionalidad_Id = Nacionalidad.Nacionalidad_Id 
		From Nacionalidad 
		Where MiembroFisico.Comp_Id = @pComp_Id
		and MiembroFisico.Comp_Id = Nacionalidad.Emp_Id
		and MiembroFisico.Nacionalidad = Nacionalidad.Nombre
		and MiembroFisico.Nacionalidad_Id = -1

		Update MiembroFisico Set MiembroFisico.Genero_Id = Genero.Genero_Id 
		From Genero 
		Where MiembroFisico.Comp_Id = @pComp_Id
		and MiembroFisico.Comp_Id = Genero.Comp_Id
		and MiembroFisico.Genero = Genero.Nombre
		and MiembroFisico.Genero_Id = -1

		/*Update MiembroFisico Set MiembroFisico.EstadoCivil_Id = EstadoCivil.EstadoCivil_Id 
		From EstadoCivil 
		Where MiembroFisico.Comp_Id = @pComp_Id
		and MiembroFisico.Comp_Id = EstadoCivil.Comp_Id
		and MiembroFisico.EstadoCivil = EstadoCivil.Nombre
		 and MiembroFisico.EstadoCivil_Id = -1*/

		Update MiembroFisico Set MiembroFisico.TipoIdentificacion_Id = TipoIdentificacion.TipoIdentificacion_Id 
		From TipoIdentificacion 
		Where MiembroFisico.Comp_Id = @pComp_Id
		and MiembroFisico.Comp_Id = TipoIdentificacion.Comp_Id
		and MiembroFisico.TipoDeDocumento = TipoIdentificacion.Nombre
		and MiembroFisico.TipoIdentificacion_Id = -1	
	--                     

		--------------------------------------------
		--           GUARDA HISTORIAL             --
		--------------------------------------------
		
		INSERT INTO /*[UAUDPRF].[dbo].*/[TempClientesFullHistorial]
		([Comp_Id]
		,[ID]
		,[Tipo de registro_1= un solo riesgo_2= multiriesgo]
		,[Transacción]
		,[Tipo proceso]
		,[Póliza principal]
		,[Número póliza]
		,[Fecha inicio novedad]
		,[Fecha vence novedad]
		,[Causa modificación]
		,[Código Entidad]
		,[Canal de descuento]
		,[Numero de tarjeta de credito]
		,[Número cuotas]
		,[Email 1]
		,[Fecha Vencimiento Tarjeta]
		,[Número de Riesgo]
		,[Tipo_documento]
		,[Documento identificación]
		,[Apellidos]
		,[Nombres]
		,[Sexo]
		,[Dirección: Hasta 300 caracteres]
		,[Celular: 8 posiciones 1]
		,[Celular: 8 posiciones 2]
		,[Celular: 8 posiciones 3]
		,[Celular: 8 posiciones 4]
		,[Celular: 8 posiciones 5]
		,[Telefono Casa: 8 posiciones 1]
		,[Telefono Casa: 8 posiciones 2]
		,[Telefono Casa: 8 posiciones 3]
		,[Telefono Casa: 8 posiciones 4]
		,[Telefono Casa: 8 posiciones 5]
		,[Telefono oficina: 8 posiciones]
		,[Ciudad]
		,[Fecha_nacimiento: Formato DDMMYYYY]
		,[Correo: Minimo tres letras @ un proveedor de correo  "#"una exte]
		,[Tipo documento]
		,[Documento identificación1]
		,[Ciudad Radicacion Riesgo]
		,[Opcion]
		,[Alternativa]
		,[Vlr_asegurado]
		,[ULTIMO COLUMNA DE CONTROL: ENVIAR EN BLANCO]
		,[CargaNombre]
		,[CargaFecha]
		,[CargaUser_Id])


		Select 

		[Comp_Id]
		,[ID]
		,[Tipo de registro_1= un solo riesgo_2= multiriesgo]
		,[Transacción]
		,[Tipo proceso]
		,[Póliza principal]
		,[Número póliza]
		,[Fecha inicio novedad]
		,[Fecha vence novedad]
		,[Causa modificación]
		,[Código Entidad]
		,[Canal de descuento]
		,[Numero de tarjeta de credito]
		,[Número cuotas]
		,[Email 1]
		,[Fecha Vencimiento Tarjeta]
		,[Número de Riesgo]
		,[Tipo_documento]
		,[Documento identificación]
		,[Apellidos]
		,[Nombres]
		,[Sexo]
		,[Dirección: Hasta 300 caracteres]
		,[Celular: 8 posiciones 1]
		,[Celular: 8 posiciones 2]
		,[Celular: 8 posiciones 3]
		,[Celular: 8 posiciones 4]
		,[Celular: 8 posiciones 5]
		,[Telefono Casa: 8 posiciones 1]
		,[Telefono Casa: 8 posiciones 2]
		,[Telefono Casa: 8 posiciones 3]
		,[Telefono Casa: 8 posiciones 4]
		,[Telefono Casa: 8 posiciones 5]
		,[Telefono oficina: 8 posiciones]
		,[Ciudad]
		,[Fecha_nacimiento: Formato DDMMYYYY]
		,[Correo: Minimo tres letras @ un proveedor de correo  "#"una exte]
		,[Tipo documento]
		,[Documento identificación1]
		,[Ciudad Radicacion Riesgo]
		,[Opcion]
		,[Alternativa]
		,[Vlr_asegurado]
		,[ULTIMO COLUMNA DE CONTROL: ENVIAR EN BLANCO]
		,@pNombreCarga
		,Getdate()
		,@pUser_Id

		From TempClientesFull
		--------------------------------------------
 
 
 
                    

      Insert Carga(Comp_Id,Carga_Nombre,Carga_Fecha,User_Id,Prod_Id,Proyecto_Id)
	  Values (@pComp_Id,@pNombreCarga,Getdate(),@pUser_Id,@pProd_Id,@pProyecto_Id)	

      select @Cantidad as Cantidad


	  If @pTran = 1
      commit transaction

  end try
  begin catch

    If @pTran = 1
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


