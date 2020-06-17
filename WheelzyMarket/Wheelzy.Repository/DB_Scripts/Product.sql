CREATE TABLE Products
(
	Id int IDENTITY(1,1) NOT NULL,
	Code varchar (50) NOT NULL,
	Description  varchar(255) NOT NULL,
	CategoryId int NOT NULL,
	SubCategoryId int NOT NULL,
	Price money NOT NULL,
	Status bit NOT NULL,
	CONSTRAINT PK_Product Primary key (Id)
);


alter table Products
add FOREIGN KEY (CategoryId) REFERENCES Categories(Id);

alter table Products
add FOREIGN KEY (SubCategoryId) REFERENCES SubCategories(Id);