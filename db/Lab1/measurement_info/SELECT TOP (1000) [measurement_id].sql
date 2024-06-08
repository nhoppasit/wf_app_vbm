SELECT TOP (1000) [measurement_id],
    [first_start_time],
    [sensor_description],
    [created_at],
    [serial_port]
FROM [accelerometer_data].[dbo].[measurement_info]