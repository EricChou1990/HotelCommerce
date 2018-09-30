Use HotelDB
go
if exists  (select * from sysobjects  where name='usp_SubmitSuggestion')
drop procedure usp_SubmitSuggestion
go
create  procedure  usp_SubmitSuggestion
@CustomerName nvarchar(50), 
@ConsumeDesc text, 
@SuggestionDesc text, 
@PhoneNumber varchar(100), 
@Email varchar(100)
as
	insert into Suggestion(CustomerName, ConsumeDesc, SuggestionDesc, PhoneNumber, Email) values(@CustomerName, @ConsumeDesc, @SuggestionDesc, @PhoneNumber, @Email)