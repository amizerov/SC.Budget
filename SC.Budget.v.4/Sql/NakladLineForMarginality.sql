--declare @projectId int = 2
--declare @month datetime = Cast('20191201' as datetime)

select nl.*
	,p.Price * nl.Quantity Cost
from Object obj 
	join Nakladnaya n on n.Object_ID = obj.ID
				and YEAR(n.DocDate) = YEAR(@month)
				and MONTH(n.DocDate) = MONTH(@month)
	join NakladLine nl on nl.Naklad_ID = n.ID
	join Postupleniya p on nl.Postup_ID = p.ID				
where obj.Project_ID = @projectId 
	and obj.Status = 0