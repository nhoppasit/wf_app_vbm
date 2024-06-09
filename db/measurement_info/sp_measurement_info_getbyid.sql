USE [accelerometer_data]
GO

-- Check if the stored procedure exists and drop it if it does
IF OBJECT_ID('dbo.sp_measurement_info_getbyid', 'P') IS NOT NULL
BEGIN
    PRINT 'Dropping existing procedure sp_measurement_info_getbyid';
    DROP PROCEDURE dbo.sp_measurement_info_getbyid;
END
GO

-- Create the new stored procedure
CREATE PROCEDURE sp_measurement_info_getbyid
    @measurement_id INT,
    @CodeValue INT OUTPUT,
    @RowCount INT OUTPUT,
    @MessageResult NVARCHAR(1000) OUTPUT
AS
BEGIN
    DECLARE @errCode CHAR(5) = '00000';
    DECLARE @errMsg NVARCHAR(4000);
    DECLARE @count INT;

    PRINT 'Starting procedure sp_measurement_info_getbyid';

    BEGIN TRY
        PRINT 'Executing SELECT statement';
        SELECT * FROM dbo.measurement_info WHERE measurement_id = @measurement_id;
        
        SET @count = @@ROWCOUNT;
        
        PRINT 'SELECT statement executed successfully';
        SET @CodeValue = 0;
        SET @RowCount = @count;
        SET @MessageResult = 'OK';
        PRINT 'Setting output parameters for successful execution';
    END TRY
    BEGIN CATCH
        PRINT 'An error occurred';
        SET @errCode = ERROR_NUMBER();
        SET @errMsg = ERROR_MESSAGE();
        
        SET @CodeValue = -1;
        SET @RowCount = 0;
        SET @MessageResult = CONCAT('Error, Code = ', @errCode, ', Message = ', @errMsg);
        PRINT 'Setting output parameters for error condition';
    END CATCH;

    PRINT 'Procedure sp_measurement_info_getbyid completed';
END;
GO
