delete Nakladnaya
where not exists (select * from NakladLine l where l.Naklad_ID = Nakladnaya.ID)