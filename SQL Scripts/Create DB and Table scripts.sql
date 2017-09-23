create database GuviCRMSuite
go

use GuviCRMSuite
go

create table login  (id  int identity(1,1) primary key, username varchar(25), password varchar(25), createdAt datetime default getutcdate(),
createdBy int default 1, modifiedAt datetime default getutcdate() , modifiedBy int default 1)

go

insert into login(username, password) values('admin', 'admin')
insert into login(username, password) values('gopi', 'gopi@123')

go 
select COUNT(*) haslogin from login where username = 'test' and password = 'test'

go

Create Table Scheduler(sch_id int identity(1,1) primary key, Event_id varchar(10), GoalId int, EventstartDTTM datetime not null, EventEndDTTM datetime not null, CreatedAt datetime default getutcdate(), createdBy varchar(25) not null,  ModifiedAt datetime default getutcdate(), modifiedby varchar(25) not null, foreign key(GoalId) references goal(goal_id));

go

create table Goal(
Goal_id int identity(1,1) primary key, 
GoalTitle varchar(25) not null,
Goals varchar(1000) not null,
Createdat datetime default getdate(),
Createdby varchar(25) not null,
Modifiedat datetime default getdate(),
Modifiedby varchar(25) not null)

go

select * from Goal
select * from Scheduler

select GoalTitle, eventstartdttm, eventenddttm from goal inner join scheduler on goal.goal_id

