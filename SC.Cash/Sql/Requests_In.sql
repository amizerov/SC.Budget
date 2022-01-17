declare @role_ID int
--,@userId int = 1

select  @role_ID = u.Role_ID
from [User] u	
where u.ID = @userId

if @role_ID = 1 --admin
	select r.*
		,u.Name UserName
		,p.Name ProjectName
	from RequestOP r
		join [User] u on u.ID = r.User_ID
		left join Project p on p.ID = r.Project_ID

else if @role_ID = 6 --director
	select r.*
		,u.Name UserName
		,p.Name ProjectName
	from RequestOP r
		join [User] u on u.ID = r.User_ID
		left join Project p on p.ID = r.Project_ID
		where u.Role_ID = 4

else if @role_ID = 4 --rukovod
	select r.*
		,u.Name UserName
		,p.Name ProjectName
	from RequestOP r
		join [User] u on u.ID = r.User_ID
		left join Project p on p.ID = r.Project_ID
		where exists (select o.* 
			from Object o
				join Project p on p.ID = o.Project_ID
			where o.Manager_ID = u.ID
					and p.Rukovod_ID = @userId)