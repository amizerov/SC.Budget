--declare @userId int = 117;
--declare @start datetime = Cast('20200223' as datetime);
--declare @end datetime = Cast('20200224' as datetime);
--declare @month datetime = Cast('20200101' as datetime);
--declare @isDebtTotal int = 0;
--declare @isDebtCalculated int = 1;

with restStart as (
	select r.Acc_ID 
		,(case when r.Day = @start then r.Rest_In
			else r.Rest_In + r.InAmount - r.OutAmount 
			end) Rest_In
		,ROW_NUMBER() over (partition by r.Acc_ID order by r.Day desc) row
	from Account ac
		left join [User] u on u.ID = ac.User_ID
		left join RestDay r on r.Acc_ID = ac.ID	
	where r.Day < @start --именно меньше стартовой даты. Если дата будет равна дате старта, то не сойдётся 
		--and u.ID = @userId
),
salaryResOp as(
	select p.Rukovod_ID, obj.Project_ID, obj.Manager_ID, r.Object_ID
		,SUM(r.Calculated) Calculated
	from ResOP r
			join Object obj on r.Object_ID = obj.ID and obj.Status = 0
			join Project p on obj.Project_ID = p.ID and p.IsDeleted = 0
	where Month(r.Month) = Month(@month) and YEAR(r.Month) = YEAR(@month)
	group by p.Rukovod_ID, obj.Project_ID, obj.Manager_ID, OBJECT_ID
),
debtResOp as(
	select p.Rukovod_ID, obj.Project_ID, obj.Manager_ID, r.Object_ID
		,SUM(r.FactSalary) FactSalary
		,SUM(ISNULL(r.FactSalary, 0) - ISNULL(r.Paid, 0)) Debt
	from ResOP r
			join Object obj on r.Object_ID = obj.ID and obj.Status = 0 and obj.IsDeleted = 0
			join Project p on obj.Project_ID = p.ID and p.IsDeleted = 0
	where @isDebtTotal = 1 or (Month(r.Month) = Month(@month) and YEAR(r.Month) = YEAR(@month))
	group by p.Rukovod_ID, obj.Project_ID, obj.Manager_ID, OBJECT_ID
),
salaryOp as(
	select SUM(op.Amount) Amount
		,ac.User_ID User_ID
	from Operation op 
		join Account ac on op.To_ID = ac.ID
	where (Category = 1 or Category = 2)
		and (@isDebtTotal = 1 or (Month(op.Month) = Month(@month) and YEAR(op.Month) = YEAR(@month)))
	group by ac.User_ID
)
select ac.ID
	,ac.IsPassive
	,ac.NameForPassive
	,ac.User_ID
	,(case when ac.IsPassive = 1 then ac.NameForPassive	else u.Name end) UserName
	,(case when ac.IsPassive = 1 then 0	else u.Role_ID end) Role
	,u.Login Login
	,isnull(start.Rest_In, 0) Rest_In
	,isnull(Sum(rr.InAmount), 0) InAmount
	,isnull(Sum(rr.OutAmount), 0) OutAmount
	,isnull(start.Rest_In, 0) + isnull(Sum(rr.InAmount) - Sum(rr.OutAmount), 0) Rest_Out
	,case when ac.IsPassive = 1 then null
	when u.Role_ID = 4 then (
		select SUM(r.Calculated)
		from salaryResOp r
		where r.Rukovod_ID = ac.User_ID
	) when u.Role_ID = 5 then (
		select SUM(r.Calculated)
		from salaryResOp r
		where r.Manager_ID = ac.User_ID
	) when u.Role_ID = 6 then (
		select SUM(r.Calculated)
		from salaryResOp r		
	) end  SalaryCalculated
	, case when ac.IsPassive = 1 then null
		else (
			select case when @isDebtCalculated = 0 then SUM(r.Debt)
				else (isnull(SUM(r.FactSalary), 0) - isnull((select SUM(Amount) from salaryOp where User_ID = ac.User_ID), 0)) end
			from debtResOp r
			where (u.Role_ID = 4 and r.Rukovod_ID = ac.User_ID)
				or (u.Role_ID = 5 and r.Manager_ID = ac.User_ID)
				or u.Role_ID = 6
		) end  Debt
from Account ac
	left join [User] u on u.ID = ac.User_ID
	left join restStart start on start.Acc_ID = ac.ID and start.row = 1
	left join RestDay rr on rr.Acc_ID = ac.ID and rr.Day >= @start and rr.Day < @end
where ac.User_ID in (@userId)
	and ac.Status = 0
group by ac.ID
	,ac.User_ID
	,ac.IsPassive
	,u.Name
	,ac.NameForPassive
	,u.Role_ID
	,u.Login
	,start.Rest_In
order by u.Role_ID desc, u.Name