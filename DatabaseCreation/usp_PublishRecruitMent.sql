Use HotelDB
go
if exists  (select * from sysobjects  where name='usp_PublishRecruitMent')
drop procedure usp_PublishRecruitMent
go
create   procedure usp_PublishRecruitMent
@PostName nvarchar(50), 
@PostType char(4), 
@PostPlace nvarchar(50), 
@PostDesc text, 
@PostRequire text, 
@Experience nvarchar(100), 
@EduBackground nvarchar(100), 
@RequireCount int, 
@Manager varchar(20), 
@PhoneNumber varchar(100), 
@Email varchar(100)
as
	insert into Recruitment(PostName, PostType, PostPlace, PostDesc, PostRequire, Experience, EduBackground, RequireCount,Manager, PhoneNumber, Email) values(@PostName, @PostType, @PostPlace, @PostDesc, @PostRequire, @Experience, @EduBackground, @RequireCount,@Manager, @PhoneNumber, @Email)