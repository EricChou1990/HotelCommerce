Use HotelDB
go
if exists  (select * from sysobjects  where name='usp_PublishNews')
drop procedure usp_PublishNews
go
create   procedure usp_PublishNews
@NewsTitle varchar(100), 
@NewsContents text,
@CategoryId int
as
	insert into News(NewsTitle,NewsContents,CategoryId) values(@NewsTitle, @NewsContents,@CategoryId)