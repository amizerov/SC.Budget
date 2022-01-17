select op.*
,s.DataCreate DataCreate
,f.Name FirmaName
,su.Name Comment
from OperationCash op
	join Scheta s on op.Schet_ID = s.ID
	left join Supplier su on s.Supplier_ID = su.ID
	left join SCFirma f on s.Firma_ID = f.ID
--where op.Status = 0