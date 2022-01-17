--declare
--@userId int = 0,
--@month datetime = Cast('20191001' as datetime);

select pr.ID
	,pr.Name ProjectName
	,Sum(sch.Summa) Summa
from Project pr 
	left join (select * from SchetProdaLine s 
	--left join Object obj on obj.Project_ID = pr.ID
		where YEAR(s.dtc) = YEAR(@month)
			and MONTH(s.dtc) = MONTH(@month)) sch on sch.Object_ID = obj.ID
where (@userId = 0 or pr.Rukovod_ID = @userId)
	  and pr.IsDeleted = 0
	  --and obj.Status = 0
group by pr.ID, pr.Name
order by pr.Name