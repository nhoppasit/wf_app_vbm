USE [accelerometer_data]
SELECT *
FROM acceleration_readings
WHERE 0.8 >= CAST(
        CHECKSUM(NEWID(), reading_id) & 0x7fffffff AS float
    ) / CAST (0x7fffffff AS int)