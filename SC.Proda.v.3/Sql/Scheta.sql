--declare @start datetime = '20200101';
--declare @end datetime = '20200801';

select s.*
	,b.Name BuyerName
	,d.Name DetailName
	,do.Name StDohoName
	,p.Name ProjectName
	,s.Summa - Oplata - Penalty Rest
	,(select max(Data) from OplataProda where Schet_ID = s.ID) OplataDate
	,f.Name FirmaName
from SchetaProda s 
	left join Buyer b on s.Buyer_ID = b.ID 
	left join SCFirma f on s.Firma_ID = f.ID 
	left join Project p on s.Project_ID = p.ID
	left join DetailProda d on d.ID = s.Detail_ID
	left join StDoho do on do.ID = s.StDoho_ID
where s.IsDeleted = 0 
		and s.DataCreate >= @start
		and s.DataCreate < @end
order by s.DataCreate desc