--declare @projectId int = 0;
--declare @month datetime = Cast('20191001' as datetime);

select s.*
	, ISNULL(d.Class, 0) Class
from Scheta s
	left join Detail d on s.Detail_ID = d.ID
where YEAR(s.DataCreate) = YEAR(@month)
		and MONTH(s.DataCreate) = MONTH(@month)
		and s.IsDeleted = 0
		and s.Project_ID = @projectId