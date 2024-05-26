use [accelerometer_data]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO ALTER PROCEDURE [dbo].[get_5_acceleration_readings_between_timestamp] (
        @measurement_id INT,
        @start_datetime DATETIME,
        @end_datetime DATETIME
    ) AS BEGIN
SET NOCOUNT ON;
SELECT * -- FROM acceleration_readings TABLESAMPLE (5 ROWS)
FROM acceleration_readings
WHERE measurement_id = @measurement_id
    AND [timestamp] BETWEEN @start_datetime AND @end_datetime;
END
GO