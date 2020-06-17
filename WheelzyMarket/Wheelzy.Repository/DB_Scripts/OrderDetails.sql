create table OrderDetails
(
	Id int IDENTITY(1,1) NOT NULL,
	IdOrder int NOT NULL,
	ProductId int NOT NULL,
	Price money NOT NULL,
	Quantity int not null,
	CONSTRAINT PK_OrderDetails Primary key (Id)
);

alter table OrderDetails
add FOREIGN KEY (IdOrder) REFERENCES Orders(Id);

alter table OrderDetails
add FOREIGN KEY (ProductId) REFERENCES Products(Id);