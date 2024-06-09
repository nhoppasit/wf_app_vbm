USE [accelerometer_data]
GO

-- Check if the stored procedure exists and drop it if it does
IF OBJECT_ID('dbo.sp_measurement_info_addnew', 'P') IS NOT NULL
BEGIN
    PRINT 'Dropping existing procedure sp_measurement_info_addnew';
    DROP PROCEDURE dbo.sp_measurement_info_addnew;
END
GO

-- Create the new stored procedure
CREATE PROCEDURE sp_measurement_info_addnew
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
    
    PRINT 'Starting procedure sp_measurement_info_addnew';

    BEGIN TRY
        PRINT 'Inserting new record into measurement_info table';
        INSERT INTO dbo.measurement_info (first_start_time, sensor_description, serial_port, created_at)
        VALUES (@first_start_time, @sensor_description, @serial_port, GETDATE());
        
        SET @CodeValue = 0;
        SET @RowCount = @@ROWCOUNT;
        SET @MessageResult = 'New record added successfully';
        PRINT 'New record added successfully';
    END TRY
    BEGIN CATCH
        PRINT 'An error occurred';
        SET @errCode = ERROR_NUMBER();
        SET @errMsg = ERROR_MESSAGE();
        
        SET @CodeValue = -1;
        SET @RowCount = 0;
        SET @MessageResult = CONCAT('Error, Code = ', @errCode, ', Message = ', @errMsg);
        PRINT 'Error occurred while adding new record';
    END CATCH;

    PRINT 'Procedure sp_measurement_info_addnew completed';
END;
GO
