Use HotelDB
go
if exists  (select * from sysobjects  where name='usp_EditDish')
drop procedure usp_EditDish
go
create  procedure usp_EditDish
@DishId int, 
@DishName varchar(100), 
@UnitPrice numeric(18,2), 
@CategoryId int,
@DishImg varchar(50)
as
	update Dishes set  DishName=@DishName, UnitPrice=@UnitPrice, CategoryId=@CategoryId,DishImg=@DishImg where  DishId=@DishId