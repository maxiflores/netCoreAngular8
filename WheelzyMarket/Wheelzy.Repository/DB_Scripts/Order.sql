create table Orders
(
	Id int IDENTITY(1,1) NOT NULL,
	DateOrder datetime not null,
	CONSTRAINT PK_Orders Primary key (Id)
);