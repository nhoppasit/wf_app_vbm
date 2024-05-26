-- Insert sample data into measurement_info table
INSERT INTO measurement_info (start_time, sensor_description, notes)
VALUES (
        '2024-05-26 08:00:00',
        'Temperature Sensor',
        'Room temperature measurements'
    );
-- Insert sample data into port_info table
INSERT INTO port_info (measurement_id, serial_port, port_level)
VALUES (1, 'COM1', 1),
    (1, 'COM2', 2);
-- Insert sample data into acceleration_readings table
DECLARE @i INT = 1;
DECLARE @measurement_id INT = 1;
DECLARE @port_id1 INT = 1;
DECLARE @port_id2 INT = 2;
WHILE @i <= 40 BEGIN
INSERT INTO acceleration_readings (
        measurement_id,
        port_id,
        x_acceleration,
        y_acceleration,
        z_acceleration,
        timestamp
    )
VALUES (
        @measurement_id,
        @port_id1,
        RAND() * 10,
        RAND() * 10,
        RAND() * 10,
        DATEADD(SECOND, @i * 10, '2024-05-26 08:00:00')
    ),
    (
        @measurement_id,
        @port_id2,
        RAND() * 10,
        RAND() * 10,
        RAND() * 10,
        DATEADD(SECOND, @i * 10, '2024-05-26 08:00:00')
    );
SET @i = @i + 1;
END;