--declare 
--@rukId int = 63

select *
from [User] u
where exists (select o.* 
			from Object o
				join Project p on p.ID = o.Project_ID
			where o.Manager_ID = u.ID
					and p.Rukovod_ID = @rukId)