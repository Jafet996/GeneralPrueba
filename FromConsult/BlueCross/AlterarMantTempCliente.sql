USE [UAUBlueCross_STAGE]
GO

/****** Object:  StoredProcedure [dbo].[MantTempCliente]    Script Date: 14/12/2020 21:32:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER Procedure [dbo].[MantTempCliente]
	(
	@pComp_Id smallint,
	@pID int,
	@pTipoderegistro_1unsoloriesgo_2multiriesgo nvarchar(255),
	@pTransacción nvarchar(255),
	@pTipoproceso nvarchar(255),
	@pPólizaprincipal nvarchar(255),
	@pNúmeropóliza nvarchar(255),
	@pFechainicionovedad nvarchar(255),
	@pFechavencenovedad nvarchar(255),
	@pCausamodificación nvarchar(255),
	@pCódigoEntidad nvarchar(255),
	@pCanaldedescuento nvarchar(255),
	@pNumerodetarjetadecredito nvarchar(255),
	@pNúmerocuotas nvarchar(255),
	@pEmail1 nvarchar(255),
	@pFechaVencimientoTarjeta datetime,
	@pNúmerodeRiesgo nvarchar(255),
	@pTipo_documento nvarchar(255),
	@pDocumentoidentificación nvarchar(255),
	@pApellidos nvarchar(255),
	@pNombres nvarchar(255),
	@pSexo nvarchar(255),
	@pDirecciónHasta300caracteres nvarchar(255),
	@pCelular8posiciones1 nvarchar(255),
	@pCelular8posiciones2 nvarchar(255),
	@pCelular8posiciones3 nvarchar(255),
	@pCelular8posiciones4 nvarchar(255),
	@pCelular8posiciones5 nvarchar(255),
	@pTelefonoCasa8posiciones1 nvarchar(255),
	@pTelefonoCasa8posiciones2 nvarchar(255),
	@pTelefonoCasa8posiciones3 nvarchar(255),
	@pTelefonoCasa8posiciones4 nvarchar(255),
	@pTelefonoCasa8posiciones5 nvarchar(255),
	@pTelefonooficina8posiciones nvarchar(255),
	@pCiudad nvarchar(255),
	@pFecha_nacimientoFormatoDDMMYYYY datetime,
	@pCorreoMinimotresletrasunproveedordecorreounaexte nvarchar(255),
	@pTipodocumento float,
	@pDocumentoidentificación1 nvarchar(255),
	@pCiudadRadicacionRiesgo nvarchar(255),
	@pOpcion nvarchar(255),
	@pAlternativa nvarchar(255),
	@pVlr_asegurado nvarchar(255),
	@pEstado_civil nvarchar(255),
	@pCanton nvarchar(255),
	@pRangoIngreso numeric(18,2),
	@pULTIMOCOLUMNADECONTROLENVIARENBLANCO nvarchar(255)
	)
As
Begin	
	
	Insert TempClientesFull
	(
	[Comp_Id],
	[ID],
	[Tipo de registro_1= un solo riesgo_2= multiriesgo],
	[Transacción],
	[Tipo proceso],
	[Póliza principal],
	[Número póliza],
	[Fecha inicio novedad],
	[Fecha vence novedad],
	[Causa modificación],
	[Código Entidad],
	[Canal de descuento],
	[Numero de tarjeta de credito],
	[Número cuotas],
	[Email 1],
	[Fecha Vencimiento Tarjeta],
	[Número de Riesgo],
	[Tipo_documento],
	[Documento identificación],
	[Apellidos],
	[Nombres],
	[Sexo],
	[Dirección: Hasta 300 caracteres],
	[Celular: 8 posiciones 1],
	[Celular: 8 posiciones 2],
	[Celular: 8 posiciones 3],
	[Celular: 8 posiciones 4],
	[Celular: 8 posiciones 5],
	[Telefono Casa: 8 posiciones 1],
	[Telefono Casa: 8 posiciones 2],
	[Telefono Casa: 8 posiciones 3],
	[Telefono Casa: 8 posiciones 4],
	[Telefono Casa: 8 posiciones 5],
	[Telefono oficina: 8 posiciones],
	[Ciudad],
	[Fecha_nacimiento: Formato DDMMYYYY],
	[Correo: Minimo tres letras @ un proveedor de correo  "#"una exte],
	[Tipo documento],
	[Documento identificación1],
	[Ciudad Radicacion Riesgo],
	[Opcion],
	[Alternativa],
	[Vlr_asegurado],
	Canton,
	Estado_civil,
	RangoIngreso,
	[ULTIMO COLUMNA DE CONTROL: ENVIAR EN BLANCO]
	)	
	
	Values
	
	(
	@pComp_Id,
	@pID,
	@pTipoderegistro_1unsoloriesgo_2multiriesgo,
	@pTransacción,
	@pTipoproceso,
	@pPólizaprincipal,
	@pNúmeropóliza,
	@pFechainicionovedad,
	@pFechavencenovedad,
	@pCausamodificación,
	@pCódigoEntidad,
	@pCanaldedescuento,
	@pNumerodetarjetadecredito,
	@pNúmerocuotas,
	@pEmail1,
	@pFechaVencimientoTarjeta,
	@pNúmerodeRiesgo,
	@pTipo_documento,
	@pDocumentoidentificación,
	@pApellidos,
	@pNombres,
	@pSexo,
	@pDirecciónHasta300caracteres,
	@pCelular8posiciones1,
	@pCelular8posiciones2,
	@pCelular8posiciones3,
	@pCelular8posiciones4,
	@pCelular8posiciones5,
	@pTelefonoCasa8posiciones1,
	@pTelefonoCasa8posiciones2,
	@pTelefonoCasa8posiciones3,
	@pTelefonoCasa8posiciones4,
	@pTelefonoCasa8posiciones5,
	@pTelefonooficina8posiciones,
	@pCiudad,
	@pFecha_nacimientoFormatoDDMMYYYY,
	@pCorreoMinimotresletrasunproveedordecorreounaexte,
	@pTipodocumento,
	@pDocumentoidentificación1,
	@pCiudadRadicacionRiesgo,
	@pOpcion,
	@pAlternativa,
	@pVlr_asegurado,
	@pCanton,
	@pEstado_civil,
	@pRangoIngreso,
	@pULTIMOCOLUMNADECONTROLENVIARENBLANCO
	)
	
End
GO


