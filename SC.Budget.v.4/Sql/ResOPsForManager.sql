--declare
--@userId int = 0,
--@month datetime = Cast('20191001' as datetime);

select obj.Address ObjectName
	,Sum(case when r.RateDays is null or r.RateDays = 0	then 0
			else Round(ISNULL(okl.Summa, 0) / r.RateDays * ISNULL(r.FactDays, 0) + ISNULL(r.Premium, 0), 0)
			end) Calculated
	,Sum(Round(ISNULL(r.Avans, 0), 0)) Avans
	,Sum(Round(ISNULL(r.Premium, 0), 0)) Premium
	,Sum(Round(ISNULL(r.Docs, 0), 0)) Docs
	,Sum(Round(ISNULL(r.MedBook, 0), 0)) MedBook
	,Sum(Round(ISNULL(r.SpecWear, 0), 0)) SpecWear
	,Sum(Round(ISNULL(r.Washings, 0), 0)) Washings
	,Sum(Round(ISNULL(r.Paid, 0), 0)) Paid
	,Sum(Round(ISNULL(r.FactSalary, 0), 0)) FactSalary
from Object obj
	left join (select * from ResOP
			  where YEAR(ResOP.Month) = YEAR(@month)
				and MONTH(ResOP.Month) = MONTH(@month)) r on r.Object_ID = obj.ID
	left join Position pos on pos.ID = r.Position_ID
	left join Oklad okl on okl.Object_ID = obj.ID and okl.Position_ID = pos.ID
where obj.Manager_ID = @userId
	  and obj.Status = 0
	  and YEAR(r.Month) = YEAR(@month)
	  and MONTH(r.Month) = MONTH(@month)
group by obj.Address
order by obj.Address