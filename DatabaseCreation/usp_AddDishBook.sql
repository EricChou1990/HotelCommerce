Use HotelDB
go
if exists  (select * from sysobjects  where name='usp_AddDishBook')
drop procedure usp_AddDishBook
go
create procedure usp_AddDishBook
@HotelName varchar(50), 
@ConsumeTime datetime, 
@ConsumePersons int, 
@RoomType varchar(20), 
@CustomerName varchar(20), 
@CustomerPhone varchar(100), 
@CustomerEmail varchar(100), 
@Comments nvarchar(500)
as
	insert into DishBook(HotelName, ConsumeTime, ConsumePersons, RoomType, CustomerName, CustomerPhone, CustomerEmail, Comments) values(@HotelName, @ConsumeTime, @ConsumePersons, @RoomType, @CustomerName, @CustomerPhone, @CustomerEmail, @Comments) 
