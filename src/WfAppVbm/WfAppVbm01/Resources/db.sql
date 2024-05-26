-- Create a database named 'accelerometer_data'
CREATE DATABASE IF NOT EXISTS accelerometer_data;

-- Use the database
USE accelerometer_data;

-- Create a table to store measurement information
CREATE TABLE IF NOT EXISTS measurement_info (
    measurement_id INT AUTO_INCREMENT PRIMARY KEY,
    start_time DATETIME NOT NULL,
    sensor_description VARCHAR(255),
    notes TEXT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Create a table to store port information
CREATE TABLE IF NOT EXISTS port_info (
    port_id INT AUTO_INCREMENT PRIMARY KEY,
    measurement_id INT,
    serial_port VARCHAR(50) NOT NULL,
    port_level INT,  -- Assuming there are levels associated with each port
    FOREIGN KEY (measurement_id) REFERENCES measurement_info(measurement_id)
);

-- Create a table to store acceleration data
CREATE TABLE IF NOT EXISTS acceleration_readings (
    reading_id INT AUTO_INCREMENT PRIMARY KEY,
    measurement_id INT,
    port_id INT,  -- Linking to port_info
    x_acceleration FLOAT NOT NULL,
    y_acceleration FLOAT NOT NULL,
    z_acceleration FLOAT NOT NULL,
    timestamp DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (measurement_id) REFERENCES measurement_info(measurement_id),
    FOREIGN KEY (port_id) REFERENCES port_info(port_id)
);

-- Create stored procedure for creating a measurement
DELIMITER //
CREATE PROCEDURE create_measurement_info (
    IN p_start_time DATETIME,
    IN p_sensor_description VARCHAR(255),
    IN p_notes TEXT
)
BEGIN
    INSERT INTO measurement_info (start_time, sensor_description, notes)
    VALUES (p_start_time, p_sensor_description, p_notes);
END //
DELIMITER ;

-- Create stored procedure for reading measurements
DELIMITER //
CREATE PROCEDURE get_measurement_info ()
BEGIN
    SELECT * FROM measurement_info;
END //
DELIMITER ;

-- Create stored procedure for updating a measurement
DELIMITER //
CREATE PROCEDURE update_measurement_info (
    IN p_measurement_id INT,
    IN p_start_time DATETIME,
    IN p_sensor_description VARCHAR(255),
    IN p_notes TEXT
)
BEGIN
    UPDATE measurement_info
    SET start_time = p_start_time,
        sensor_description = p_sensor_description,
        notes = p_notes
    WHERE measurement_id = p_measurement_id;
END //
DELIMITER ;

-- Create stored procedure for deleting a measurement
DELIMITER //
CREATE PROCEDURE delete_measurement_info (
    IN p_measurement_id INT
)
BEGIN
    DELETE FROM measurement_info WHERE measurement_id = p_measurement_id;
END //
DELIMITER ;

-- Create stored procedure for creating a port info
DELIMITER //
CREATE PROCEDURE create_port_info (
    IN p_measurement_id INT,
    IN p_serial_port VARCHAR(50),
    IN p_port_level INT
)
BEGIN
    INSERT INTO port_info (measurement_id, serial_port, port_level)
    VALUES (p_measurement_id, p_serial_port, p_port_level);
END //
DELIMITER ;

-- Create stored procedure for reading port info
DELIMITER //
CREATE PROCEDURE get_port_info ()
BEGIN
    SELECT * FROM port_info;
END //
DELIMITER ;

-- Create stored procedure for updating a port info
DELIMITER //
CREATE PROCEDURE update_port_info (
    IN p_port_id INT,
    IN p_serial_port VARCHAR(50),
    IN p_port_level INT
)
BEGIN
    UPDATE port_info
    SET serial_port = p_serial_port,
        port_level = p_port_level
    WHERE port_id = p_port_id;
END //
DELIMITER ;

-- Create stored procedure for deleting a port info
DELIMITER //
CREATE PROCEDURE delete_port_info (
    IN p_port_id INT
)
BEGIN
    DELETE FROM port_info WHERE port_id = p_port_id;
END //
DELIMITER ;

-- Create stored procedure for creating an acceleration reading
DELIMITER //
CREATE PROCEDURE create_acceleration_reading (
    IN p_measurement_id INT,
    IN p_port_id INT,
    IN p_x_acceleration FLOAT,
    IN p_y_acceleration FLOAT,
    IN p_z_acceleration FLOAT
)
BEGIN
    INSERT INTO acceleration_readings (measurement_id, port_id, x_acceleration, y_acceleration, z_acceleration)
    VALUES (p_measurement_id, p_port_id, p_x_acceleration, p_y_acceleration, p_z_acceleration);
END //
DELIMITER ;

-- Create stored procedure for reading acceleration readings
DELIMITER //
CREATE PROCEDURE get_acceleration_readings ()
BEGIN
    SELECT * FROM acceleration_readings;
END //
DELIMITER ;

-- Create stored procedure for updating an acceleration reading
DELIMITER //
CREATE PROCEDURE update_acceleration_reading (
    IN p_reading_id INT,
    IN p_measurement_id INT,
    IN p_port_id INT,
    IN p_x_acceleration FLOAT,
    IN p_y_acceleration FLOAT,
    IN p_z_acceleration FLOAT
)
BEGIN
    UPDATE acceleration_readings
    SET measurement_id = p_measurement_id,
        port_id = p_port_id,
        x_acceleration = p_x_acceleration,
        y_acceleration = p_y_acceleration,
        z_acceleration = p_z_acceleration
    WHERE reading_id = p_reading_id;
END //
DELIMITER ;

-- Create stored procedure for deleting an acceleration reading
DELIMITER //
CREATE PROCEDURE delete_acceleration_reading (
    IN p_reading_id INT
)
BEGIN
    DELETE FROM acceleration_readings WHERE reading_id = p_reading_id;
END //
DELIMITER ;
