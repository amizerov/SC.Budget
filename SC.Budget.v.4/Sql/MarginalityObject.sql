--declare @object_Id int = 1074;
--declare @year int = 2020;
declare @month int = 1;
declare @res table (Expense decimal, Income decimal);

while @month <= 12
begin
	insert @res values(
		
		isnull((select sum(l.Quantity * (p.Price + isnull(p.PriceAdditional, 0))) from NakladLine l
			join Nakladnaya n on l.Naklad_ID = n .ID
				and Year(n.DocDate) = @year and Month(n.DocDate) = @month
				and n.Object_ID = @object_Id
			join Postupleniya p on l.Postup_ID = p.ID), 0)
		+ isnull((select sum(resOp.FactSalary) from ResOP resOp
				where Year(resOp.Month) = @year and Month(resOp.Month) = @month
					and resOp.Object_ID = @object_Id), 0),

		(select sum(l.Summa) from SchetProdaLine l
			join SchetaProda s on l.Schet_ID = s.ID
				and Year(s.DataCreate) = @year and Month(s.DataCreate) = @month
				and l.Object_ID = @object_Id)
	)
	set @month = @month + 1
end
select * from @res