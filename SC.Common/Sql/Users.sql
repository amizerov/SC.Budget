--declare 
--@userId int = 63

select u.*, r.Name RoleName
from [User] u
	join Role r on r.ID = u.Role_ID
where @userId = 0 or u.ID = @userId