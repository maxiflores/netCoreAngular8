create table SubCategories
(
	Id int IDENTITY(1,1) not null,
	SubCategoryName varchar(50) not null,
	CategoryId int not null,
	CONSTRAINT PK_SubCategory Primary key (Id)
);

alter table SubCategories
add FOREIGN KEY (CategoryId) REFERENCES Categories(Id);

