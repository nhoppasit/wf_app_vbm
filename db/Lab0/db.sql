-- Check if the database exists, if not, create it
IF NOT EXISTS (
    SELECT name
    FROM sys.databases
    WHERE name = N'accelerometer_data'
) BEGIN CREATE DATABASE [accelerometer_data];
END
GO -- Use the new database
    USE [accelerometer_data];
GO -- Create a table to store measurement information
    IF NOT EXISTS (
        SELECT 1
        FROM INFORMATION_SCHEMA.TABLES
        WHERE TABLE_SCHEMA = 'dbo'
            AND TABLE_NAME = 'measurement_info'
    ) BEGIN CREATE TABLE measurement_info (
        measurement_id INT PRIMARY KEY IDENTITY(1, 1),
        start_time DATETIME NOT NULL,
        sensor_description NVARCHAR(255),
        notes NVARCHAR(MAX),
        created_at DATETIME DEFAULT CURRENT_TIMESTAMP
    );
END
GO -- Create a table to store port information
    IF NOT EXISTS (
        SELECT 1
        FROM INFORMATION_SCHEMA.TABLES
        WHERE TABLE_SCHEMA = 'dbo'
            AND TABLE_NAME = 'port_info'
    ) BEGIN CREATE TABLE port_info (
        port_id INT PRIMARY KEY IDENTITY(1, 1),
        measurement_id INT,
        serial_port NVARCHAR(50) NOT NULL,
        port_level INT,
        FOREIGN KEY (measurement_id) REFERENCES measurement_info(measurement_id)
    );
END
GO -- Create a table to store acceleration data
    IF NOT EXISTS (
        SELECT 1
        FROM INFORMATION_SCHEMA.TABLES
        WHERE TABLE_SCHEMA = 'dbo'
            AND TABLE_NAME = 'acceleration_readings'
    ) BEGIN CREATE TABLE acceleration_readings (
        reading_id INT PRIMARY KEY IDENTITY(1, 1),
        measurement_id INT,
        port_id INT,
        x_acceleration FLOAT NOT NULL,
        y_acceleration FLOAT NOT NULL,
        z_acceleration FLOAT NOT NULL,
        timestamp DATETIME DEFAULT CURRENT_TIMESTAMP,
        FOREIGN KEY (measurement_id) REFERENCES measurement_info(measurement_id),
        FOREIGN KEY (port_id) REFERENCES port_info(port_id)
    );
END
GO -- Create stored procedure for creating a measurement
    CREATE
    OR ALTER PROCEDURE create_measurement_info @p_start_time DATETIME,
    @p_sensor_description NVARCHAR(255),
    @p_notes NVARCHAR(MAX) AS BEGIN
INSERT INTO measurement_info (start_time, sensor_description, notes)
VALUES (@p_start_time, @p_sensor_description, @p_notes);
END
GO -- Create stored procedure for reading measurements
    CREATE
    OR ALTER PROCEDURE get_measurement_info AS BEGIN
SELECT *
FROM measurement_info;
END
GO -- Create stored procedure for updating a measurement
    CREATE
    OR ALTER PROCEDURE update_measurement_info @p_measurement_id INT,
    @p_start_time DATETIME,
    @p_sensor_description NVARCHAR(255),
    @p_notes NVARCHAR(MAX) AS BEGIN
UPDATE measurement_info
SET start_time = @p_start_time,
    sensor_description = @p_sensor_description,
    notes = @p_notes
WHERE measurement_id = @p_measurement_id;
END
GO -- Create stored procedure for deleting a measurement
    CREATE
    OR ALTER PROCEDURE delete_measurement_info @p_measurement_id INT AS BEGIN
DELETE FROM measurement_info
WHERE measurement_id = @p_measurement_id;
END
GO -- Create stored procedure for creating a port info
    CREATE
    OR ALTER PROCEDURE create_port_info @p_measurement_id INT,
    @p_serial_port NVARCHAR(50),
    @p_port_level INT AS BEGIN
INSERT INTO port_info (measurement_id, serial_port, port_level)
VALUES (@p_measurement_id, @p_serial_port, @p_port_level);
END
GO -- Create stored procedure for reading port info
    CREATE
    OR ALTER PROCEDURE get_port_info AS BEGIN
SELECT *
FROM port_info;
END
GO -- Create stored procedure for updating a port info
    CREATE
    OR ALTER PROCEDURE update_port_info @p_port_id INT,
    @p_serial_port NVARCHAR(50),
    @p_port_level INT AS BEGIN
UPDATE port_info
SET serial_port = @p_serial_port,
    port_level = @p_port_level
WHERE port_id = @p_port_id;
END
GO -- Create stored procedure for deleting a port info
    CREATE
    OR ALTER PROCEDURE delete_port_info @p_port_id INT AS BEGIN
DELETE FROM port_info
WHERE port_id = @p_port_id;
END
GO -- Create stored procedure for creating an acceleration reading
    CREATE
    OR ALTER PROCEDURE create_acceleration_reading @p_measurement_id INT,
    @p_port_id INT,
    @p_x_acceleration FLOAT,
    @p_y_acceleration FLOAT,
    @p_z_acceleration FLOAT AS BEGIN
INSERT INTO acceleration_readings (
        measurement_id,
        port_id,
        x_acceleration,
        y_acceleration,
        z_acceleration
    )
VALUES (
        @p_measurement_id,
        @p_port_id,
        @p_x_acceleration,
        @p_y_acceleration,
        @p_z_acceleration
    );
END
GO -- Create stored procedure for reading acceleration readings
    CREATE
    OR ALTER PROCEDURE get_acceleration_readings AS BEGIN
SELECT *
FROM acceleration_readings;
END
GO -- Create stored procedure for updating an acceleration reading
    CREATE
    OR ALTER PROCEDURE update_acceleration_reading @p_reading_id INT,
    @p_measurement_id INT,
    @p_port_id INT,
    @p_x_acceleration FLOAT,
    @p_y_acceleration FLOAT,
    @p_z_acceleration FLOAT AS BEGIN
UPDATE acceleration_readings
SET measurement_id = @p_measurement_id,
    port_id = @p_port_id,
    x_acceleration = @p_x_acceleration,
    y_acceleration = @p_y_acceleration,
    z_acceleration = @p_z_acceleration
WHERE reading_id = @p_reading_id;
END
GO -- Create stored procedure for deleting an acceleration reading
    CREATE
    OR ALTER PROCEDURE delete_acceleration_reading @p_reading_id INT AS BEGIN
DELETE FROM acceleration_readings
WHERE reading_id = @p_reading_id;
END
GO