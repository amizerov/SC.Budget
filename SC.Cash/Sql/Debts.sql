--declare @rukovodId int = 0;

with debts as (
	select ruk.Name RukovodName
		,p.ID Project_ID
		,p.Name ProjectName
		,manager.Name ManagerName
		,obj.ID Object_ID
		,obj.Address ObjectName
		,Cast(DATEADD(day, 1 - Day(r.Month), r.Month) as date) Month
		,(ISNULL(r.FactSalary, 0) - ISNULL(r.Paid, 0)) Debt
		,r.Calculated Calculated
	from ResOP r 
		join Object obj on r.Object_ID = obj.ID
			and obj.IsDeleted = 0 
			and obj.Status = 0
		left join [User] manager on obj.Manager_ID = manager.ID
		join Project p on obj.Project_ID = p.ID
			and p.IsDeleted = 0
			and (@rukovodId = 0 or p.Rukovod_ID = @rukovodId)
		left join [User] ruk on p.Rukovod_ID = ruk.ID
)

select RukovodName, Project_ID, ProjectName
	,ManagerName, Object_ID, ObjectName
	,Month
,SUM(Debt) Debt
,SUM(Calculated) Calculated
from debts d
group by RukovodName, Project_ID, ProjectName
	,ManagerName, Object_ID, ObjectName
	,Month
order by RukovodName, ProjectName, ManagerName, ObjectName