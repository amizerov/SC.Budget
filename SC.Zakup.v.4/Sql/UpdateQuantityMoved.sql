--declare @postupId int = 12629;

update Postupleniya 
set QuantityMoved = (select SUM(nl.Quantity)
					from NakladLine nl
						join Nakladnaya n on nl.Naklad_ID = n.ID
							and n.FromObject_ID is null
					where Postup_ID = @postupId
					group by Postup_ID)
where ID = @postupId