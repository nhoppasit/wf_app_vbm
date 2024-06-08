-- Create Procedure for Adding New Measurement Info
CREATE PROCEDURE sp_MeasurementInfo_AddNew @val_first_start_time DATETIME,
@val_sensor_description NVARCHAR(255),
@val_serial_port NVARCHAR(5),
@CodeValue INT OUT,
@RowCount INT OUT,
@MessageResult NVARCHAR(1000) OUT AS BEGIN
SET NOCOUNT ON;
BEGIN TRY
DECLARE @create_date DATETIME = GETDATE();
INSERT INTO measurement_info (
        first_start_time,
        sensor_description,
        created_at,
        serial_port
    )
VALUES (
        @val_first_start_time,
        @val_sensor_description,
        @create_date,
        @val_serial_port
    );
SET @CodeValue = 0;
SET @RowCount = @@ROWCOUNT;
SET @MessageResult = 'OK';
END TRY BEGIN CATCH
SET @CodeValue = -1;
SET @RowCount = 0;
SET @MessageResult = 'Error, Message = ' + ERROR_MESSAGE();
END CATCH;
END;
GO -- Create Procedure for Retrieving Measurement Info by ID
    CREATE PROCEDURE sp_MeasurementInfo_GetById @val_measurement_id INT,
    @CodeValue INT OUT,
    @RowCount INT OUT,
    @MessageResult NVARCHAR(1000) OUT AS BEGIN
SET NOCOUNT ON;
BEGIN TRY
SELECT *
FROM measurement_info
WHERE measurement_id = @val_measurement_id;
SET @CodeValue = 0;
SET @RowCount = @@ROWCOUNT;
SET @MessageResult = 'OK';
END TRY BEGIN CATCH
SET @CodeValue = -1;
SET @RowCount = 0;
SET @MessageResult = 'Error, Message = ' + ERROR_MESSAGE();
END CATCH;
END;
GO -- Create Procedure for Updating Measurement Info
    CREATE PROCEDURE sp_MeasurementInfo_Update @val_measurement_id INT,
    @val_first_start_time DATETIME,
    @val_sensor_description NVARCHAR(255),
    @val_serial_port NVARCHAR(5),
    @CodeValue INT OUT,
    @RowCount INT OUT,
    @MessageResult NVARCHAR(1000) OUT AS BEGIN
SET NOCOUNT ON;
BEGIN TRY
DECLARE @update_date DATETIME = GETDATE();
UPDATE measurement_info
SET first_start_time = @val_first_start_time,
    sensor_description = @val_sensor_description,
    serial_port = @val_serial_port,
    created_at = @update_date
WHERE measurement_id = @val_measurement_id;
SET @CodeValue = 0;
SET @RowCount = @@ROWCOUNT;
SET @MessageResult = 'OK';
END TRY BEGIN CATCH
SET @CodeValue = -1;
SET @RowCount = 0;
SET @MessageResult = 'Error, Message = ' + ERROR_MESSAGE();
END CATCH;
END;
GO -- Create Procedure for Deleting Measurement Info
    CREATE PROCEDURE sp_MeasurementInfo_Delete @val_measurement_id INT,
    @CodeValue INT OUT,
    @RowCount INT OUT,
    @MessageResult NVARCHAR(1000) OUT AS BEGIN
SET NOCOUNT ON;
BEGIN TRY
DELETE FROM measurement_info
WHERE measurement_id = @val_measurement_id;
SET @CodeValue = 0;
SET @RowCount = @@ROWCOUNT;
SET @MessageResult = 'OK';
END TRY BEGIN CATCH
SET @CodeValue = -1;
SET @RowCount = 0;
SET @MessageResult = 'Error, Message = ' + ERROR_MESSAGE();
END CATCH;
END;
GO