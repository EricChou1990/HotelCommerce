Use HotelDB
go
if exists  (select * from sysobjects  where name='usp_EditNews')
drop procedure usp_EditNews
go
create  procedure usp_EditNews
@NewsId int, 
@NewsTitle varchar(100), 
@NewsContents text,
@CategoryId int
as
	update News set NewsTitle=@NewsTitle,NewsContents=@NewsContents,CategoryId=@CategoryId	where NewsId=@NewsId