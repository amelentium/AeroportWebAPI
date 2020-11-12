DROP PROCEDURE SP_GetAllFlightsByDepartId;  
GO  

CREATE PROCEDURE [dbo].[SP_GetAllFlightsByDepartId]
	-- Add the parameters for the stored procedure here
	@P_Id int = null
AS
BEGIN
	SET NOCOUNT ON;
	
	Declare @V_sql as nvarchar(MAX) = null
	if (@P_Id is not null)
		select @V_sql = 'select * from Flight where DepartFrom_Id = ' + @P_Id + ';'

	if(@V_sql is not null)
		exec(@V_sql)
	else
		select -1;
END