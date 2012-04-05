use NunitTest
GO
----------------
-- Schema Change to project:
-- now, null account names are OK
alter table account alter column name varchar(50) null 

-- some null data:
INSERT INTO Account (balance) values (65000)
GO
