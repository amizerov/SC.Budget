--declare @nakladId int = 0

select nl.*
, n.DocDate
, nom.Name Nomenkl
, n.DocNumber Naklad
, p.Measure
, p.Category
, p.Price
, p.PriceAdditional
, p.Quantity - p.QuantityMoved QuantityOnSklad
, p.InventoryNum
from NakladLine nl 
	join Postupleniya p on p.ID = nl.Postup_ID						
	join Nakladnaya n on nl.Naklad_ID = n.ID
	left join Nomenklatura nom on p.Nomenkl_ID = nom.ID
where Naklad_ID = @nakladId