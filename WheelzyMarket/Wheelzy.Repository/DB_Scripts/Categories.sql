create table Categories
(
	Id int IDENTITY(1,1) not null,
	CategoryName varchar(50) not null,
	CONSTRAINT PK_Category Primary key (Id)
);