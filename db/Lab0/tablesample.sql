use [accelerometer_data]
SELECT top 100 *
FROM acceleration_readings TABLESAMPLE (5000 ROWS);
-- WHERE