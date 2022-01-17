﻿--declare @userId int = 0;
--declare @month datetime = Cast('20191201' as datetime);

select pr.Name ProjectName
	,Sum(s.Summa) Summa
	,Sum(s.Oplata) Oplata
from Project pr
	left join SchetaProda s on s.Project_ID = pr.ID
		and Year(s.DataCreate) = Year(@month)
		and Month(s.DataCreate) = Month(@month)
where pr.IsDeleted = 0
group by pr.Name
order by pr.Name