--declare @categories int = 0;
--declare @start datetime = '20200701';
--declare @end datetime = '20200801';

with postup as(
	select p.ID
		,l.Naklad_ID
		,p.Price * l.Quantity Cost
		,p.PriceAdditional * l.Quantity CostAdditional
		,p.Kontragent
		,p.Organization
	from Postupleniya p
		join NakladLine l on l.Postup_ID = p.ID
	where p.Category in (@categories)
)

select n.*
	,from_p.Name FromProjectName
	,(case when n.FromObject_ID is null then null
		  else from_o.Name + ' - ' + from_o.Address end) FromObjectName
	,(case when n.Object_ID = 0 then 'Списание'
		  else isnull(p.Name, 'Не назначено') end) ProjectName
	, (case when n.Object_ID = 0 then 'Списание'
		else (case when n.Sklad1C is not null then n.Sklad1C + (case when n.Object_ID is not null then '' else '(не найден)' end)
		else isnull(o.Address, 'Не назначено') end) end) ObjectName
	,(select COUNT(l.ID) from NakladLine l where l.Naklad_ID = n.ID) PositionCount
	,(select sum(p.Cost) from postup p where p.Naklad_ID = n.ID) Cost
	,(select sum(p.CostAdditional) from postup p where p.Naklad_ID = n.ID) CostAdditional
	,(select top(1) p.Kontragent from postup p where p.Naklad_ID = n.ID) Kontragent
	,(select top(1) p.Organization from postup p where p.Naklad_ID = n.ID) FirmaName
from Nakladnaya n 
	left join Object from_o on from_o.ID = n.FromObject_ID
	left join Project from_p on from_p.ID = from_o.Project_ID
	left join Object o on o.ID = n.Object_ID
	left join Project p on p.ID = o.Project_ID
	left join SCFirma firma on firma.ID = o.Firma_ID
where exists (select * from postup post where post.Naklad_ID = n.ID)
	 and n.DocDate >= @start and n.DocDate < @end
order by DocDate desc