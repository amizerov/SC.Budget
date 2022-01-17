select o.*
,s.Nomer Schet_Nomer
,s.NomerInternal Schet_NomerInternal
,d.ID Detail_ID
,d.Name DetailName
,f.ID Firma_ID
,f.Name FirmaName
,su.ID Supplier_ID
,su.Name SupplierName
from Oplata o
	left join Scheta s on o.Schet_ID = s.ID
	left join Detail d on s.Detail_ID = d.ID 
	left join SCFirma f on s.Firma_ID = f.ID
	left join Supplier su on s.Supplier_ID = su.ID
order by Data desc