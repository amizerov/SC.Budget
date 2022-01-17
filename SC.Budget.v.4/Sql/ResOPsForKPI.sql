--declare @project_ID int = 2
--declare @month datetime = Cast('20200701' as datetime)

select resOp.*
	,r.User_ID
	,u.Role_ID 
	,r.OfficialSalary
from ResOP resOp
	join Object obj on resOp.Object_ID = obj.ID
	join Project p on obj.Project_ID = p.ID and p.ID = @project_ID
	left join Resource r on resOp.Resource_ID = r.ID
	left join [User] u on r.User_ID = u.ID
where YEAR(resOp.Month) = YEAR(@month)
	and MONTH(resOp.Month) = MONTH(@month)