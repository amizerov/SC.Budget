--declare @accId int = 13;
--declare @start datetime = Cast('20190101' as datetime);
--declare @end datetime = Cast('20200101' as datetime);

with outOp as (

--declare
--@accId int = 13

	select op.*
		,op.Amount OutAmount
		,toUser.Name ToUser
		,null InAmount
		,null FromUser
	from Operation op
		left join Account toAcc on toAcc.ID = op.To_ID
		left join [User] toUser on toUser.ID = toAcc.User_ID
	where op.From_ID = @accId 
		and op.Status = 0
		and op.ToResOP_ID is null
		and CAST(op.DateTime AS DATE) between @start and @end
	),
outResOp as (

--declare
--@accId int = 14

	select op.*
		,op.Amount OutAmount
		,r.Name ToUser
		,null InAmount
		,null FromUser
	from Operation op
		left join ResOP res on res.ID = op.ToResOP_ID
		left join Resource r on r.ID = res.Resource_ID
	where op.From_ID = @accId 
		and op.ToResOP_ID is not null
		and op.Status = 0
		and CAST(op.DateTime AS DATE) between @start and @end
	),
inOp as (
	select op.*
		,null OutAmount
		,null ToUser
		,op.Amount InAmount
		,ISNULL(fromUser.Name, su.Name) FromUser
	from Operation op
		left join Account fromAcc on fromAcc.ID = op.From_ID
		left join [User] fromUser on fromUser.ID = fromAcc.User_ID
		left join OperationCash cash on op.FromCash_ID = cash.ID
		left join Scheta schet on cash.Schet_ID = schet.ID
		left join Supplier su on schet.Supplier_ID = su.ID
	where op.To_ID = @accId 
		and op.Status = 0
		and CAST(op.DateTime AS DATE) between @start and @end
		--and op.From_ID is not null
	),
allOps as (
	select *
	from outOp
	union all select * from outResOp
	union all select * from inOp
	)
select FromUser
	,SUM(ISNULL(InAmount, 0)) InAmount
	,ToUser
	,-SUM(ISNULL(OutAmount, 0)) OutAmount
from allOps
group by FromUser, ToUser
