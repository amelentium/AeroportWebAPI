DROP PROCEDURE SP_InsertRecordToTable;  
GO  

CREATE PROCEDURE [dbo].[SP_InsertRecordToTable]
	-- Add the parameters for the stored procedure here
	@P_tableName nvarchar(50) = null,
	@P_columnsString nvarchar(MAX) = null, 
	@P_propertiesString nvarchar(MAX) = null
AS
BEGIN
	SET NOCOUNT ON;
	
	declare @V_table nvarchar(50) = null
	if (@P_tableName is not null)
		select @V_table = QUOTENAME( TABLE_NAME )
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = @P_tableName

	declare @V_sql as nvarchar(MAX) = null
	if (@V_table is not null and @P_columnsString is not null and @P_propertiesString is not null)
		select @V_sql = 'insert into ' + @V_table + ' (' + @P_columnsString + ') values (' + @P_propertiesString + ');
		 select cast(SCOPE_IDENTITY() as int);'

	if(@V_sql is not null)
		exec(@V_sql)
	else
		select -1;
END
