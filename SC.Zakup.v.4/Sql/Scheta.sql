--declare @id int = null;
--declare @start datetime = '20200101';
--declare @end datetime = '20200801';
--declare @isDeleted int = 0;

select s.*
	,su.Name SupplierName
	,d.Name DetailName
	,r.Name StRashName
	,p.Name ProjectName
	,f.Name FirmaName
	,(select max(Data) from Oplata where Schet_ID = s.ID) OplataDate
	,s.Summa - isnull((select SUM(Summa) from Oplata where Schet_ID = s.ID and Summa > 0), 0) Rest
	,p.IsCash IsCash
from Scheta s 
	left join Supplier su on s.Supplier_ID = su.ID 
	left join SCFirma f on s.Firma_ID = f.ID 
	left join Project p on s.Project_ID = p.ID
	left join Detail d on d.ID = s.Detail_ID
	left join StRash r on r.ID = s.StRash_ID
where s.ID = @id
	or (@id is null
		and (@isDeleted is null or s.IsDeleted = @isDeleted)
		and s.DataCreate >= @start
		and s.DataCreate < @end)
order by s.DataCreate desc