DROP PROCEDURE SP_DeleteRecordFromTable;  
GO  

CREATE PROCEDURE [dbo].[SP_DeleteRecordFromTable]
	-- Add the parameters for the stored procedure here
	@P_tableName nvarchar(50) = null,
	@P_Id int = null
AS
BEGIN
	SET NOCOUNT ON;
	
	declare @V_table nvarchar(50) = null
	if (@P_tableName is not null)
		select @V_table = QUOTENAME( TABLE_NAME )
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = @P_tableName

	declare @V_sql as nvarchar(MAX) = null
	if (@V_table is not null and @P_Id is not null)
		select @V_sql = 'delete from ' + @V_table + ' where Id = ' + @P_Id + '; select 1;'

	if(@V_sql is not null)
		exec(@V_sql)
	else
		select 0;
END
