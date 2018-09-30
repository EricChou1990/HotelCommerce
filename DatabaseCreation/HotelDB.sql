use Master
go
if exists(select * from sysdatabases where name='HotelDB')
drop database HotelDB
go
create database HotelDB
on primary
(
	name='HotelDB_data',
	filename='D:\DB\HotelDB_data.mdf',
	size=5MB,
	filegrowth=2MB
)
 log on
(
	name='HotelDB_log',
	filename='D:\DB\HotelDB_log.ldf',
	size=5MB,
	filegrowth=2MB
)
go
use HotelDB
go

if exists(select * from sysobjects where name='SysAdmins')
drop table SysAdmins
go
create table SysAdmins 
(
	LoginId int primary key ,
	LoginName varchar(20) not null, 
	LoginPwd varchar(20)	not null 
) 
go

if exists(select * from sysobjects where name='NewsCategory')
drop table NewsCategory
go
create table NewsCategory 
(
	CategoryId int  identity(1,1) primary key ,
	CategoryName varchar(20) not null
)
go

if exists(select * from sysobjects where name='News')
drop table News
go
create table News  
(
	NewsId int  identity(1000,1)  primary key ,
	NewsTitle varchar(100) not null,
	NewsContents text not null,	
	PublishTime datetime default(getdate()),
	CategoryId int references NewsCategory(CategoryId)
)
go

if exists(select * from sysobjects where name='DishCategory')
drop table DishCategory
go
create table DishCategory 
(
	CategoryId int  identity(1,1) primary key ,
	CategoryName varchar(20) not null
)
go

if exists(select * from sysobjects where name='Dishes')
drop table Dishes 
go
create table Dishes 
(
	DishId int  identity(100,1)  primary key , 
	DishName varchar(100) not null,
	UnitPrice numeric(18,2) not null, 
	CategoryId int references DishCategory(CategoryId)
)
go

if exists(select * from sysobjects where name='DishBook')
drop table DishBook
go
create table DishBook  
(
	BookId int  identity(10000,1) primary key , 
	HotelName varchar(50) not null,  
	ConsumeTime datetime not null,
	ConsumePersons int not null,
	RoomType varchar(20) not null,
	CustomerName varchar(20) not null,
	CustomerPhone varchar(100) not null,
	CustomerEmail varchar(100), 
	Comments nvarchar(500), 
	BookTime datetime default(getdate()),
	OrderStatus int default(0), 	
)
go

if exists(select * from sysobjects where name='Recruitment')
drop table Recruitment
go
create table Recruitment 
(
	PostId int identity(100000,1) primary key ,
	PostName nvarchar(50) not null, 
	PostType char(4) not null,
	PostPlace nvarchar(50) not null,
	PostDesc text not null,
	PostRequire text not null,
	Experience nvarchar(100) not null,
	EduBackground nvarchar(100) not null,
	RequireCount int  not null,
	PublishTime datetime default(getdate()), 
	Manager varchar(20) not null,
	PhoneNumber varchar(100) not null,
	Email varchar(100)  not null
)
go

if exists(select * from sysobjects where name='Suggestion')
drop table Suggestion
go
create table Suggestion 
(
	SuggestionId int identity(100000,1) primary key ,
	CustomerName nvarchar(50) not null, 
	ConsumeDesc text not null,
	SuggestionDesc text not null,
	SuggestTime datetime default(getdate()),
	PhoneNumber varchar(100) not null,
	Email varchar(100), 
	StatusId int default(0)
)
go










