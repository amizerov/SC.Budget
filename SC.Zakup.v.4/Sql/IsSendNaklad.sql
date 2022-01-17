--declare @nakladId int = 1702;

select case when exists(
	select * from Nakladnaya n
		join Nakladnaya from_n on from_n.FromObject_ID = n.Object_ID
			and n.ID = @nakladId
		join NakladLine from_nl on from_nl.Naklad_ID = from_n.ID
		join NakladLine nl on nl.Naklad_ID = @nakladId
			and nl.Postup_ID = from_nl.Postup_ID
) then 1 else 0 end