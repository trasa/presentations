use master
go
CREATE DATABASE NUnitTest
GO
use NUnitTest
GO
CREATE TABLE Account (
	[ID] int identity not null,
	[Name] varchar(50) not null,
	[Balance] decimal(10,5) not null
)
GO
ALTER TABLE Account add constraint Account_PK primary key ("ID")
GO


-- some data
INSERT INTO Account (name, balance) values ('Account 1011', 100)
INSERT INTO Account (name, balance) values ('GloboFund', 33)
INSERT INTO Account (name, balance) values ('NoAccount', 250)



