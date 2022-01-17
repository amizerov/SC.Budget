--declare @position_ID int = 22;
--declare @object_ID int = 1;

select top(1) p.*, o.Summa Salary
from Position p 
	Left outer Join Oklad o on o.Position_ID = p.ID
		and o.Object_ID = @object_ID
where p.ID = @position_ID