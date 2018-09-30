Use HotelDB
go
if exists  (select * from sysobjects  where name='prPager')
drop procedure prPager
go
create procedure   prPager
	@PageSize INT, 
	@CurrentCount INT, 
	@TableName NVARCHAR(200), 
	@Where NVARCHAR(800), 
	@Order NVARCHAR(800),
	@TotalCount INT OUTPUT 
AS
	DECLARE @sqlSelect    NVARCHAR(2000) 
	DECLARE @sqlGetCount  NVARCHAR(2000) 
	
	
	SET @sqlSelect = 'SELECT * FROM  ' 
	    + '    (SELECT ROW_NUMBER()  OVER( ORDER BY ' + @Order +
	    ' ) AS RowNumber,* '
	    + '        FROM ' + @TableName 
	    + '        WHERE ' + @Where 
	    + '     ) as  T2 ' 
	    + ' WHERE T2.RowNumber<= ' + STR(@CurrentCount + @PageSize) +
	    ' AND T2.RowNumber>' + STR(@CurrentCount) 
	
	SET @sqlGetCount = 'SELECT @TotalCount = COUNT(*) FROM ' + @TableName 
	    + ' WHERE ' + @Where
	
	
	EXEC (@sqlSelect) 
	EXEC SP_EXECUTESQL @sqlGetCount,
	     N'@TotalCount INT OUTPUT',
	     @TotalCount OUTPUT
