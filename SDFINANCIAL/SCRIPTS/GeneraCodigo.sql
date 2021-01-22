declare @Tabla varchar(100)

set @Tabla = 'Cuenta'

----------- BACK END
exec WCF_GeneraCodigoClase @Tabla,''
exec WCF_GeneraCodigoClaseDataContract @Tabla,''
exec WCF_GeneraCodigoInterfaz @Tabla
exec WCF_GeneraCodigoFuncion @Tabla,''

----------- FRONT END
exec WCF_GeneraCodigoClaseFrontEnd @Tabla,''