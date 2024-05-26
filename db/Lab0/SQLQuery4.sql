USE [accelerometer_data]
GO

CREATE PROCEDURE get_5_acceleration_readings
(
    @measurement_id INT,
    @start_datetime DATETIME,
    @end_datetime DATETIME
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM acceleration_readings TABLESAMPLE (5 ROWS)
    WHERE measurement_id = @measurement_id
    AND [timestamp] BETWEEN @start_datetime AND @end_datetime;
END
GO
