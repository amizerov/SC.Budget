--declare
--@userId int = 0,
--@month datetime = Cast('20191001' as datetime);

select SUM(p.Quantity * p.Price) Cost, pr.Name ProjectName
from Project pr 
	left join Object obj on obj.Project_ID = pr.ID
	left join Nakladnaya n on n.Object_ID = obj.ID
	left join (select * from Postupleniya pos
				where YEAR(pos.DocDate) = YEAR(@month)
				  and MONTH(pos.DocDate) = MONTH(@month)) p on p.Naklad = n.DocNumber
where pr.IsDeleted = 0
	  and obj.Status = 0
group by pr.Name
order by pr.Name