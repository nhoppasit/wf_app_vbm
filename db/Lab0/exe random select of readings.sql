USE [accelerometer_data]
GO -- DECLARE @return_value int EXEC @return_value = [dbo].[get_5_acceleration_readings_between_timestamp] 
	-- 	@measurement_id = 1,
	-- 	@start_datetime = '2024-05-26 08:00:00',
	-- 	@end_datetime = '2024-05-26 08:10:00'
	-- SELECT 'Return Value' = @return_value
	-- GO
	EXEC [dbo].[get_5_acceleration_readings_between_timestamp] 
	@measurement_id = 1,
	@start_datetime = '2024-05-26 08:00:00',
	@end_datetime = '2024-05-26 08:10:00',
	@num_rows = 300;