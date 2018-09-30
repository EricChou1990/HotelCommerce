Use HotelDB
go
if exists  (select * from sysobjects  where name='usp_QueryDishes')
drop procedure usp_QueryDishes
go
create    procedure usp_QueryDishes
@CategoryId varchar(2)
as
	if len(@CategoryId)!=0
	--���ݷ����ѯ
		select DishId, DishName, UnitPrice, Dishes.CategoryId,CategoryName
		from Dishes 
		inner join DishCategory on DishCategory.CategoryId=Dishes.CategoryId
		where Dishes.CategoryId=@CategoryId
	else
		--��ѯȫ����Ʒ
		select DishId, DishName, UnitPrice, Dishes.CategoryId,CategoryName
		from Dishes 
		inner join DishCategory on DishCategory.CategoryId=Dishes.CategoryId