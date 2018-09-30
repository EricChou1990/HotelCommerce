Use HotelDB
go
if exists  (select * from sysobjects  where name='usp_EditRecruitment')
drop procedure usp_EditRecruitment
go
create   procedure usp_EditRecruitment
@PostId int, 
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
	update Recruitment set PostName=@PostName, PostType=@PostType, PostPlace=@PostPlace, PostDesc=@PostDesc, PostRequire=@PostRequire, Experience=@Experience, EduBackground=@EduBackground, RequireCount=@RequireCount, Manager=@Manager, PhoneNumber=@PhoneNumber, Email=@Email where PostId=@PostId