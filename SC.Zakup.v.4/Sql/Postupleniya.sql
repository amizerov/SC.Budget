--declare @projectIds int = 124;
--declare @firmaId int = 1;

select p.*
	,nom.Name Nomenkl
	,Quantity - QuantityMoved QuantityOnSklad
	,s.Project_ID Project_ID
	,s.Firma_ID
from Postupleniya p 
	left join Scheta s on s.Nomer = p.Schet
	left join Nomenklatura nom on p.Nomenkl_ID = nom.ID
where p.Quantity - p.QuantityMoved > 0
	and p.IsDeleted = 0
	and (@firmaId is null or s.Firma_ID = @firmaId)
	--and exists (select * from Scheta s 
	--			where s.Nomer = p.Schet and s.Project_ID in (@projectIds))
order by DocDate desc