--declare @userId int = 0;

select distinct pr.ID, pr.Name, pr.Rukovod_ID
from Project pr
	join Object obj on obj.Project_ID = pr.ID
where (@userId = 0 or pr.Rukovod_ID = @userId)
	  and pr.IsDeleted = 0
	  and obj.Status = 0
order by pr.Name