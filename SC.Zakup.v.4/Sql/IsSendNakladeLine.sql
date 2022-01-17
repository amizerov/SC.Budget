--declare @nakladLineId int = 11060;

select case when exists(
	select * from NakladLine nl
		join Nakladnaya n on nl.Naklad_ID = n.ID
			and nl.ID = @nakladLineId
		join Nakladnaya from_n on from_n.FromObject_ID = n.Object_ID
		join NakladLine from_nl on from_nl.Naklad_ID = from_n.ID
			and nl.Postup_ID = from_nl.Postup_ID
) then 1 else 0 end