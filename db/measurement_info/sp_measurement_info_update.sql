USE [accelerometer_data]
GO

-- Check if the stored procedure exists and drop it if it does
IF OBJECT_ID('dbo.sp_measurement_info_update', 'P') IS NOT NULL
BEGIN
    PRINT 'Dropping existing procedure sp_measurement_info_update';
    DROP PROCEDURE dbo.sp_measurement_info_update;
END
GO

-- Create the new stored procedure
CREATE PROCEDURE sp_measurement_info_update
    @measurement_id INT,
    @first_start_time DATETIME,
    @sensor_description NVARCHAR(255),
    @serial_port NVARCHAR(5),
    @CodeValue INT OUTPUT,
    @RowCount INT OUTPUT,
    @MessageResult NVARCHAR(1000) OUTPUT
AS
BEGIN
    DECLARE @errCode CHAR(5) = '00000';
    DECLARE @errMsg NVARCHAR(4000);
    
    PRINT 'Starting procedure sp_measurement_info_update';

    BEGIN TRY
        PRINT 'Updating record in measurement_info table';
        UPDATE dbo.measurement_info
        SET 
            first_start_time = @first_start_time,
            sensor_description = @sensor_description,
            serial_port = @serial_port
        WHERE 
            measurement_id = @measurement_id;
        
        SET @CodeValue = 0;
        SET @RowCount = @@ROWCOUNT;
        SET @MessageResult = 'Record updated successfully';
        PRINT 'Record updated successfully';
    END TRY
    BEGIN CATCH
        PRINT 'An error occurred';
        SET @errCode = ERROR_NUMBER();
        SET @errMsg = ERROR_MESSAGE();
        
        SET @CodeValue = -1;
        SET @RowCount = 0;
        SET @MessageResult = CONCAT('Error, Code = ', @errCode, ', Message = ', @errMsg);
        PRINT 'Error occurred while updating record';
    END CATCH;

    PRINT 'Procedure sp_measurement_info_update completed';
END;
GO
