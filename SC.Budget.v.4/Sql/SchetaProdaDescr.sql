--declare @userId int = 54;
--declare @month datetime = Cast('20200401' as datetime);

select *
from SchetaProda s
	left join Project pr on s.Project_ID = pr.ID
		and Year(s.DataCreate) = Year(@month)
		and Month(s.DataCreate) = Month(@month)
where (@userId = 0 or pr.Rukovod_ID = @userId)
and pr.IsDeleted = 0