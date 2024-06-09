DECLARE @RC int
DECLARE @val_first_start_time datetime
DECLARE @val_sensor_description nvarchar(255)
DECLARE @val_serial_port nvarchar(5)
DECLARE @CodeValue int
DECLARE @RowCount int
DECLARE @MessageResult nvarchar(1000) --
    -- Set parameter values here
SET @val_first_start_time = GETDATE() -- current date and time
SET @val_sensor_description = N'Sensor A1' -- a random sensor description
SET @val_serial_port = N'COM3' -- a random serial port
    --
    EXECUTE @RC = [dbo].[sp_MeasurementInfo_AddNew] @val_first_start_time,
    @val_sensor_description,
    @val_serial_port,
    @CodeValue OUTPUT,
    @RowCount OUTPUT,
    @MessageResult OUTPUT
GO