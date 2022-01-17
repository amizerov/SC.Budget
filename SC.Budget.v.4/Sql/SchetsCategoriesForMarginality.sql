--declare @userId int = 0;
--declare @month datetime = Cast('20191001' as datetime);

select distinct d.Class
from Detail d
	join Scheta s on s.Detail_ID = d.ID
		and YEAR(s.DataCreate) = YEAR(@month)
		and MONTH(s.DataCreate) = MONTH(@month)
		and s.IsDeleted = 0
	join Project p on s.Project_ID = p.ID
		and (@userId = 0 or p.Rukovod_ID = @userId)
		and p.IsDeleted = 0
	join Object obj on obj.Project_ID = p.ID
		and obj.Status = 0
