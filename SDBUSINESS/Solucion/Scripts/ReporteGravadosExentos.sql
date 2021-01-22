select CONVERT( varchar(10),Fecha,111) as Fecha,
      sum(case ExentoIV when 1 then Cantidad * Precio else 0 end) Exento,
      sum(case ExentoIV when 1 then 0 else Cantidad * Precio end) Gravado,
      sum(case ExentoIV when 1 then Cantidad * MontoDescuento else 0 end) DescExento,
      sum(case ExentoIV when 1 then 0 else Cantidad * MontoDescuento end) DescGravado,
      sum(Cantidad * MontoDescuento) Descuento,
      sum(Cantidad*MontoIV ) as IV,
      sum(Cantidad*TotalLinea) as Total
from  FacturaDetalle 
where Caja_Id = 1
group by CONVERT( varchar(10),Fecha,111)
order by CONVERT( varchar(10),Fecha,111)


