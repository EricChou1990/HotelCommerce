Use HotelDB
go
if exists  (select * from sysobjects  where name='usp_Book')
drop procedure usp_Book
go
create procedure usp_Book
@HotelName varchar(50), 
@ConsumeTime datetime, 
@ConsumePersons int, 
@RoomType varchar(20), 
@CustomerName varchar(20), 
@CustomerPhone varchar(100), 
@CustomerEmail varchar(100), 
@Comments varchar(500)
as
 insert into DishBook(HotelName, ConsumeTime, ConsumePersons, RoomType, CustomerName, CustomerPhone, CustomerEmail, Comments) values(@HotelName, @ConsumeTime, @ConsumePersons, @RoomType, @CustomerName, @CustomerPhone, @CustomerEmail, @Comments) 