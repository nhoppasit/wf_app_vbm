USE [accelerometer_data]
GO

DECLARE	@return_value int,
		@CodeValue int,
		@RowCount int,
		@MessageResult nvarchar(1000)

EXEC	@return_value = [dbo].[sp_measurement_info_getall]
		@CodeValue = @CodeValue OUTPUT,
		@RowCount = @RowCount OUTPUT,
		@MessageResult = @MessageResult OUTPUT

SELECT	@CodeValue as N'@CodeValue',
		@RowCount as N'@RowCount',
		@MessageResult as N'@MessageResult'

SELECT	'Return Value' = @return_value

GO
