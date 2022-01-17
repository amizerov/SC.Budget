--declare @objectId int = 1110;

with send as (
	select l.Postup_ID
		, sum(l.Quantity) Quantity
	from Nakladnaya n join NakladLine l on n.ID = l.Naklad_ID
		join Postupleniya p on p.ID = l.Postup_ID
	where FromObject_ID = @objectId
	group by l.Postup_ID
)
select l.ID
	, l.Postup_ID
	, l.Naklad_ID
	, n.DocDate
	, nom.Name Nomenkl
	, n.DocNumber Naklad
	, p.Price
	, p.PriceAdditional
	, p.Measure
	, l.InventoryNum
	, p.Category
	, p.Comment
	, l.Quantity - isnull(send.Quantity, 0) Quantity
	, p.Quantity - p.QuantityMoved QuantityOnSklad
from Nakladnaya n join NakladLine l on n.ID = l.Naklad_ID
	join Postupleniya p on p.ID = l.Postup_ID and p.IsDeleted = 0
	left join send on send.Postup_ID = l.Postup_ID
	left join Nomenklatura nom on p.Nomenkl_ID = nom.ID
where Object_ID = @objectId
	and l.Quantity - isnull(send.Quantity, 0) > 0
	--and (year(n.DocDate) = year(GETDATE()) and month(n.DocDate) = month(GETDATE()))