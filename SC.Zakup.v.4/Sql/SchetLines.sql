--declare @schetId int = 0;

select l.*, nom.Name Nomenklatura from SchetZakupLine l
join Nomenklatura nom on l.Nomenkl_ID = nom.ID
where l.Schet_ID = @schetId