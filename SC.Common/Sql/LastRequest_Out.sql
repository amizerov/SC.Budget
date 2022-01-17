--declare
--@userId int = 1

select top (1) *
from RequestOP
where User_ID = @userId
	order by DateTime desc