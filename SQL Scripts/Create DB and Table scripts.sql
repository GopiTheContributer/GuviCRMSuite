create database GuviCRMSuite
go

use GuviCRMSuite
go

Create Table Products(id int identity(1,1), Product varchar(20), CompanyName varchar(20), Price decimal(10,2), CreatedAt datetime default getdate(), ModifiedAt datetime default getdate());

go

insert into Products(product, companyname, price) values('Tv', 'Samsung', 10000);
insert into Products(product, companyname, price) values('Washing Machine', 'LG', 12000);
insert into Products(product, companyname, price) values('J7 Mobile', 'Samsung', 10000);
insert into Products(product, companyname, price) values('AC', 'Onida', 20000);
insert into Products(product, companyname, price) values('Tv', 'Sansui', 12000);
insert into Products(product, companyname, price) values('Radio', 'BPL', 19000);
go

select Product, CompanyName, Price from products order by CompanyName asc
