create database GuviCRMSuite
go

use GuviCRMSuite
go

Create Table Products(id int identity(1,1), Product varchar(20), CompanyName varchar(20), Price decimal(10,2), CreatedAt datetime default getutcdate(), ModifiedAt datetime default getutcdate());

go

insert into Products(product, companyname, price) values('Tv', 'Samsung', 10000);
insert into Products(product, companyname, price) values('Washing Machine', 'LG', 12000);
insert into Products(product, companyname, price) values('J7 Mobile', 'Samsung', 10000);
insert into Products(product, companyname, price) values('AC', 'Onida', 20000);
insert into Products(product, companyname, price) values('Tv', 'Sansui', 12000);
insert into Products(product, companyname, price) values('Radio', 'BPL', 19000);
go

select Product, CompanyName, Price from products order by CompanyName asc

-- create login table
go

create table login  (id  int identity(1,1) primary key, username varchar(25), password varchar(25), createdAt datetime default getutcdate(),
createdBy int default 1, modifiedAt datetime default getutcdate() , modifiedBy int default 1)

go

insert into login(username, password) values('admin', 'admin')

go 
select COUNT(*) haslogin from login where username = 'test' and password = 'test'