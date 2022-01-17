--declare @userId int = 117;
--declare @month datetime = Cast('20191201' as datetime);
declare @roleId int;

select @roleId = Role_ID from [User] where ID = @userId

if @roleId = 0 or @roleId = 6
	select distinct r.*, u.Role_ID Role
	from Resource r
		join ResOP on ResOP.Resource_ID = r.ID
			and Year(ResOP.Month) = Year(@month)
			and Month(ResOP.Month) = Month(@month)
		left join [User] u on r.User_ID = u.ID
else if @roleId = 4
	select distinct r.*, u.Role_ID Role
	from Resource r
		join ResOP on ResOP.Resource_ID = r.ID
			and Year(ResOP.Month) = Year(@month)
			and Month(ResOP.Month) = Month(@month)
		join Object obj on obj.ID = ResOP.Object_ID
		join Project p on obj.Project_ID = p.ID
			and p.Rukovod_ID = @userId
		left join [User] u on r.User_ID = u.ID
else if @roleId = 5
	select distinct r.*, u.Role_ID Role
	from Resource r
		join ResOP on ResOP.Resource_ID = r.ID
			and Year(ResOP.Month) = Year(@month)
			and Month(ResOP.Month) = Month(@month)
		join Object obj on obj.ID = ResOP.Object_ID
			and obj.Manager_ID = @userId
		left join [User] u on r.User_ID = u.ID