declare @role_ID int;
--declare @userId int = 54

select  @role_ID = u.Role_ID
from [User] u	
where u.ID = @userId

if @role_ID = 5 --manager
	select distinct u.*
	from [User] u
		join Project pr on pr.Rukovod_ID = u.ID
		join Object obj on obj.Project_ID = pr.ID
	where obj.Manager_ID = @userId
else if @role_ID = 4 --rukovod
	select *
	from [User]	where Role_ID = 6