--declare @accId int = 13;
--declare @start datetime = Cast('20190101' as datetime);
--declare @end datetime = Cast('20200101' as datetime);

with outOp as (

--declare @accId int = 13

	select op.*
		,op.Amount OutAmount
		,(case when toAcc.IsPassive = 1 then toAcc.NameForPassive else toUser.Name end) ToUser
		,(case when toAcc.IsPassive = 1 then -1 else toUser.Role_ID end) ToRole
		,(case when toAcc.IsPassive = 0 then toUser.Login end) ToLogin
		,null InAmount
		,(case when op.To_ID is null and op.ToResOP_ID is null then fromUser.Name else null end) FromUser
		,(case when op.To_ID is null and op.ToResOP_ID is null then fromUser.Role_ID else null end) FromRole
		,(case when op.To_ID is null and op.ToResOP_ID is null then fromUser.Login else null end) FromLogin
		,pr.Name ProjectName
	from Operation op
		left join Account toAcc on toAcc.ID = op.To_ID
		left join [User] toUser on toUser.ID = toAcc.User_ID
		left join Account fromAcc on fromAcc.ID = op.From_ID
		left join [User] fromUser on fromUser.ID = fromAcc.User_ID
		left join Project pr on op.Project_ID = pr.ID
	where op.From_ID = @accId 
		and op.Status = 0
		and op.ToResOP_ID is null
		and CAST(op.DateTime AS DATE) >= @start 
		and CAST(op.DateTime AS DATE) < @end
	),
outResOp as (

--declare @accId int = 14

	select op.*
		,op.Amount OutAmount
		,r.Name ToUser
		,0 ToRole
		,null ToLogin
		,null InAmount
		,null FromUser
		,null FromRole
		,null FromLogin
		,pr.Name ProjectName
	from Operation op
		left join ResOP res on res.ID = op.ToResOP_ID
		left join Resource r on r.ID = res.Resource_ID
		left join Project pr on op.Project_ID = pr.ID
	where op.From_ID = @accId 
		and op.ToResOP_ID is not null
		and op.Status = 0
		and CAST(op.DateTime AS DATE) >= @start 
		and CAST(op.DateTime AS DATE) < @end
	),
inOp as (
	select op.*
		,null OutAmount
		,null ToUser
		,0 ToRole
		,null ToLogin
		,op.Amount InAmount
		,(case when fromAcc.IsPassive = 1 then fromAcc.NameForPassive 
			else COALESCE(fromUser.Name, fromUserCash.Name, su.Name) end) FromUser
		,(case when fromAcc.IsPassive = 1 then -1 else fromUser.Role_ID end) FromRole
		,(case when fromAcc.IsPassive = 0 then fromUser.Login end) FromLogin
		,pr.Name ProjectName
	from Operation op
		left join Account fromAcc on fromAcc.ID = op.From_ID
		left join [User] fromUser on fromUser.ID = fromAcc.User_ID
		left join Account fromAccCash on fromAccCash.ID = op.FromAccCash_ID
		left join [User] fromUserCash on fromUserCash.ID = fromAccCash.User_ID
		left join OperationCash cash on op.FromCash_ID = cash.ID
		left join Scheta schet on cash.Schet_ID = schet.ID
		left join Supplier su on schet.Supplier_ID = su.ID
		left join Project pr on op.Project_ID = pr.ID
	where op.To_ID = @accId 
		and op.Status = 0
		and CAST(op.DateTime AS DATE) >= @start 
		and CAST(op.DateTime AS DATE) < @end
		--and op.From_ID is not null
	)
select *
from outOp
union all select * from outResOp
union all select * from inOp
order by DateTime