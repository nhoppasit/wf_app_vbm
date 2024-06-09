USE [accelerometer_data]
GO

-- Check if the stored procedure exists and drop it if it does
IF OBJECT_ID('dbo.sp_measurement_info_delete', 'P') IS NOT NULL
BEGIN
    PRINT 'Dropping existing procedure sp_measurement_info_delete';
    DROP PROCEDURE dbo.sp_measurement_info_delete;
END
GO

-- Create the new stored procedure
CREATE PROCEDURE sp_measurement_info_delete
    @measurement_id INT,
    @CodeValue INT OUTPUT,
    @RowCount INT OUTPUT,
    @MessageResult NVARCHAR(1000) OUTPUT
AS
BEGIN
    DECLARE @errCode CHAR(5) = '00000';
    DECLARE @errMsg NVARCHAR(4000);
    
    PRINT 'Starting procedure sp_measurement_info_delete';

    BEGIN TRY
        PRINT 'Deleting record from measurement_info table';
        DELETE FROM dbo.measurement_info
        WHERE measurement_id = @measurement_id;
        
        SET @CodeValue = 0;
        SET @RowCount = @@ROWCOUNT;
        SET @MessageResult = 'Record deleted successfully';
        PRINT 'Record deleted successfully';
    END TRY
    BEGIN CATCH
        PRINT 'An error occurred';
        SET @errCode = ERROR_NUMBER();
        SET @errMsg = ERROR_MESSAGE();
        
        SET @CodeValue = -1;
        SET @RowCount = 0;
        SET @MessageResult = CONCAT('Error, Code = ', @errCode, ', Message = ', @errMsg);
        PRINT 'Error occurred while deleting record';
    END CATCH;

    PRINT 'Procedure sp_measurement_info_delete completed';
END;
GO
