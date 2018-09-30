Use HotelDB
go
if exists  (select * from sysobjects  where name='usp_AddDish')
drop procedure usp_AddDish
go
create procedure usp_AddDish 
@DishName varchar(100), 
@UnitPrice numeric(18,2), 
@CategoryId int,
@DishImg varchar(50)
as
 insert into Dishes(DishName, UnitPrice, CategoryId,DishImg) values(@DishName, @UnitPrice, @CategoryId,@DishImg)
 select @@IDENTITY