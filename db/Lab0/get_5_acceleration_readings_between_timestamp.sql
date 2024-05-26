SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO -- ;
    ALTER PROCEDURE [dbo].[get_5_acceleration_readings_between_timestamp] (
        @measurement_id INT,
        @start_datetime DATETIME,
        @end_datetime DATETIME,
        @num_rows INT
    ) AS BEGIN
SET NOCOUNT ON;
DECLARE @random_threshold FLOAT;
-- Compute the number of rows for the given filters
DECLARE @total_rows INT;
SELECT @total_rows = COUNT(*)
FROM acceleration_readings
WHERE measurement_id = @measurement_id
    AND [timestamp] BETWEEN @start_datetime AND @end_datetime;
-- Calculate the random threshold based on the number of rows
SET @random_threshold = @num_rows / CAST(@total_rows AS FLOAT);
PRINT @measurement_id;
PRINT @start_datetime;
PRINT @end_datetime;
PRINT @random_threshold;
SELECT TOP (@num_rows) *
FROM acceleration_readings TABLESAMPLE (5000 ROWS)
WHERE @random_threshold >= CAST(
        CHECKSUM(NEWID(), reading_id) & 0x7fffffff AS FLOAT
    ) / CAST (0x7fffffff AS INT)
    AND measurement_id = @measurement_id
    AND [timestamp] BETWEEN @start_datetime AND @end_datetime;
PRINT @@ROWCOUNT;
END
GO