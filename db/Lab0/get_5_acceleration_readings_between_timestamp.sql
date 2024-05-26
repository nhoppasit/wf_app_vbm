SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO ALTER PROCEDURE [dbo].[get_5_acceleration_readings_between_timestamp] (
        @measurement_id INT,
        @start_datetime DATETIME,
        @end_datetime DATETIME,
        @random_threshold FLOAT
    ) AS BEGIN
SET NOCOUNT ON;
PRINT @measurement_id PRINT @start_datetime PRINT @end_datetime PRINT @random_threshold
SELECT *
FROM acceleration_readings TABLESAMPLE (5000 ROWS)
WHERE @random_threshold >= CAST(
        CHECKSUM(NEWID(), reading_id) & 0x7fffffff AS float
    ) / CAST (0x7fffffff AS int)
    AND measurement_id = @measurement_id
    AND [timestamp] BETWEEN @start_datetime AND @end_datetime;
PRINT @@ROWCOUNT
END
GO