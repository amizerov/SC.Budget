--declare @projectId int = 0;
--declare @year int = 2020;

select distinct d.Class
from Detail d
	join Scheta s on s.Detail_ID = d.ID
		and YEAR(s.DataCreate) = @year
		and s.IsDeleted = 0
		and s.Oplata > 0
		and s.Project_ID =  @projectId