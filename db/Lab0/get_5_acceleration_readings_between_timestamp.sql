ALTER PROCEDURE [dbo].[get_5_acceleration_readings_between_timestamp] (
    @measurement_id INT,
    @start_datetime DATETIME,
    @end_datetime DATETIME,
    @num_rows INT
) AS BEGIN
SET NOCOUNT ON;
PRINT @measurement_id PRINT @start_datetime PRINT @end_datetime PRINT @num_rows;
WITH RandomizedReadings AS (
    SELECT *,
        ROW_NUMBER() OVER (
            ORDER BY NEWID()
        ) AS RowNum
    FROM acceleration_readings
    WHERE CAST(
            CHECKSUM(NEWID(), reading_id) & 0x7fffffff AS float
        ) / CAST (0x7fffffff AS int) < 0.8
        AND measurement_id = @measurement_id
        AND [timestamp] BETWEEN @start_datetime AND @end_datetime
)
SELECT TOP (@num_rows) *
FROM RandomizedReadings;
END
GO