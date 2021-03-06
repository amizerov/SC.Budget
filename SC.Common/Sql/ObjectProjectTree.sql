--declare @projectIds int = 124;
--declare @firmaId int = 1;

with objs as (
	select 'Object ' + CAST(obj.ID AS nvarchar)  ViewModelID
		,'Project ' + CAST(obj.Project_ID AS nvarchar) ParentID
		,1 Type
		,p.ID Project_ID
		,obj.ID Object_ID
		,1 ObjectsCount
		,obj.Name Name
		,obj.Address Address
		,u.Name RukovodName
	from Object obj
		join [User] u on obj.Manager_ID = u.ID 
		join Project p on obj.Project_ID = p.ID
    where obj.IsDeleted = 0 and obj.Status = 0
		and p.ID in (@projectIds)
		and (@firmaId is null or obj.Firma_ID = @firmaId)
),
projects as (
	select 'Project ' + CAST(p.ID AS nvarchar) ViewModelID
		,null ParentID
		,0 Type
		,p.ID Project_ID
		,-1 Object_ID
		,(select count(*) from objs where Project_ID = p.ID) ObjectsCount
		,p.Name Name
		,'Объектов: ' + CAST((select count(*) from objs where Project_ID = p.ID) AS nvarchar) Address
		,u.Name RukovodName
	from Project p
		join [User] u on p.Rukovod_ID = u.ID
	where p.ID in (@projectIds)
		and p.IsDeleted = 0
	)

select * from projects where ObjectsCount > 0
union all select * from objs where exists (select * from projects p where objs.Project_ID = p.Project_ID)
union all select 'Summary' ViewModelID
		 ,null ParentID
		,3 Type
		,-1 Project_ID
		,-1 Object_ID
		,(select count(*) from objs) ObjectsCount
		,'Итого проектов: ' + CAST((select count(*) from projects p where p.ObjectsCount > 0) AS nvarchar) Name
		,'Объектов: ' + CAST((select count(*) from objs) AS nvarchar) Address
		,null RukovodName
order by Type, Name