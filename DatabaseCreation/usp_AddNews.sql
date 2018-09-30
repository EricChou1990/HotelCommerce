Use HotelDB
go
if exists  (select * from sysobjects  where name='usp_AddNews')
drop procedure usp_AddNews
go
create procedure usp_AddNews
@NewsTitle varchar(100), 
@NewsContents text, 
@CategoryId int
as
	insert into News(NewsTitle, NewsContents, CategoryId) values(@NewsTitle, @NewsContents, @CategoryId)
	select @@IDENTITY