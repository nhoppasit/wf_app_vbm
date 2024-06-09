USE [master]
GO
/****** Object:  Database [accelerometer_data]    Script Date: 6/9/2024 10:23:51 PM ******/
CREATE DATABASE [accelerometer_data]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'accelerometer_data', FILENAME = N'd:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS02\MSSQL\DATA\accelerometer_data.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'accelerometer_data_log', FILENAME = N'd:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS02\MSSQL\DATA\accelerometer_data_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [accelerometer_data] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [accelerometer_data].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [accelerometer_data] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [accelerometer_data] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [accelerometer_data] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [accelerometer_data] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [accelerometer_data] SET ARITHABORT OFF 
GO
ALTER DATABASE [accelerometer_data] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [accelerometer_data] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [accelerometer_data] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [accelerometer_data] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [accelerometer_data] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [accelerometer_data] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [accelerometer_data] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [accelerometer_data] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [accelerometer_data] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [accelerometer_data] SET  ENABLE_BROKER 
GO
ALTER DATABASE [accelerometer_data] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [accelerometer_data] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [accelerometer_data] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [accelerometer_data] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [accelerometer_data] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [accelerometer_data] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [accelerometer_data] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [accelerometer_data] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [accelerometer_data] SET  MULTI_USER 
GO
ALTER DATABASE [accelerometer_data] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [accelerometer_data] SET DB_CHAINING OFF 
GO
ALTER DATABASE [accelerometer_data] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [accelerometer_data] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [accelerometer_data] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [accelerometer_data] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [accelerometer_data] SET QUERY_STORE = OFF
GO
USE [accelerometer_data]
GO
/****** Object:  Table [dbo].[acceleration_readings]    Script Date: 6/9/2024 10:23:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[acceleration_readings](
	[reading_id] [int] IDENTITY(1,1) NOT NULL,
	[measurement_id] [int] NULL,
	[x_acceleration] [float] NOT NULL,
	[y_acceleration] [float] NOT NULL,
	[z_acceleration] [float] NOT NULL,
	[timestamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[reading_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[measurement_info]    Script Date: 6/9/2024 10:23:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[measurement_info](
	[measurement_id] [int] IDENTITY(1,1) NOT NULL,
	[first_start_time] [datetime] NULL,
	[sensor_description] [nvarchar](255) NULL,
	[created_at] [datetime] NOT NULL,
	[serial_port] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK__measurem__E3D1E1C1EA57F2DC] PRIMARY KEY CLUSTERED 
(
	[measurement_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[acceleration_readings] ADD  DEFAULT (getdate()) FOR [timestamp]
GO
ALTER TABLE [dbo].[measurement_info] ADD  CONSTRAINT [DF__measureme__creat__36B12243]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[acceleration_readings]  WITH CHECK ADD  CONSTRAINT [FK_acceleration_readings_measurement_info] FOREIGN KEY([measurement_id])
REFERENCES [dbo].[measurement_info] ([measurement_id])
GO
ALTER TABLE [dbo].[acceleration_readings] CHECK CONSTRAINT [FK_acceleration_readings_measurement_info]
GO
/****** Object:  StoredProcedure [dbo].[create_acceleration_reading]    Script Date: 6/9/2024 10:23:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Create stored procedure for creating an acceleration reading
CREATE   PROCEDURE [dbo].[create_acceleration_reading]
    @p_measurement_id INT,
    @p_port_id INT,
    @p_x_acceleration FLOAT,
    @p_y_acceleration FLOAT,
    @p_z_acceleration FLOAT
AS
BEGIN
    INSERT INTO acceleration_readings (measurement_id, port_id, x_acceleration, y_acceleration, z_acceleration)
    VALUES (@p_measurement_id, @p_port_id, @p_x_acceleration, @p_y_acceleration, @p_z_acceleration);
END
GO
/****** Object:  StoredProcedure [dbo].[delete_acceleration_reading]    Script Date: 6/9/2024 10:23:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Create stored procedure for deleting an acceleration reading
CREATE   PROCEDURE [dbo].[delete_acceleration_reading]
    @p_reading_id INT
AS
BEGIN
    DELETE FROM acceleration_readings WHERE reading_id = @p_reading_id;
END
GO
/****** Object:  StoredProcedure [dbo].[delete_measurement_info]    Script Date: 6/9/2024 10:23:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Create stored procedure for deleting a measurement
CREATE   PROCEDURE [dbo].[delete_measurement_info]
    @p_measurement_id INT
AS
BEGIN
    DELETE FROM measurement_info WHERE measurement_id = @p_measurement_id;
END
GO
/****** Object:  StoredProcedure [dbo].[delete_port_info]    Script Date: 6/9/2024 10:23:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Create stored procedure for deleting a port info
CREATE   PROCEDURE [dbo].[delete_port_info]
    @p_port_id INT
AS
BEGIN
    DELETE FROM port_info WHERE port_id = @p_port_id;
END
GO
/****** Object:  StoredProcedure [dbo].[get_5_acceleration_readings_between_timestamp]    Script Date: 6/9/2024 10:23:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    CREATE PROCEDURE [dbo].[get_5_acceleration_readings_between_timestamp] (
        @measurement_id INT,
        @start_datetime DATETIME,
        @end_datetime DATETIME,
        @num_rows INT
    ) AS BEGIN
SET NOCOUNT ON;
DECLARE @random_threshold FLOAT;
-- Compute the number of rows for the given filters
DECLARE @total_rows INT;
SELECT @total_rows = COUNT(*)
FROM acceleration_readings
WHERE measurement_id = @measurement_id
    AND [timestamp] BETWEEN @start_datetime AND @end_datetime;
-- Calculate the random threshold based on the number of rows
SET @random_threshold = @num_rows / CAST(@total_rows AS FLOAT);
PRINT @measurement_id;
PRINT @start_datetime;
PRINT @end_datetime;
PRINT @random_threshold;
SELECT TOP (@num_rows) *
FROM acceleration_readings TABLESAMPLE (5000 ROWS)
WHERE @random_threshold >= CAST(
        CHECKSUM(NEWID(), reading_id) & 0x7fffffff AS FLOAT
    ) / CAST (0x7fffffff AS INT)
    AND measurement_id = @measurement_id
    AND [timestamp] BETWEEN @start_datetime AND @end_datetime;
PRINT @@ROWCOUNT;
END
GO
/****** Object:  StoredProcedure [dbo].[get_acceleration_readings]    Script Date: 6/9/2024 10:23:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Create stored procedure for reading acceleration readings
CREATE   PROCEDURE [dbo].[get_acceleration_readings]
AS
BEGIN
    SELECT * FROM acceleration_readings;
END
GO
/****** Object:  StoredProcedure [dbo].[get_acceleration_readings_by_meas_id]    Script Date: 6/9/2024 10:23:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[get_acceleration_readings_by_meas_id]
(
    @measurement_info_id INT
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM acceleration_readings
    WHERE measurement_id = @measurement_info_id;
END
GO
/****** Object:  StoredProcedure [dbo].[get_measurement_info]    Script Date: 6/9/2024 10:23:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Create stored procedure for reading measurements
CREATE   PROCEDURE [dbo].[get_measurement_info]
AS
BEGIN
    SELECT * FROM measurement_info;
END
GO
/****** Object:  StoredProcedure [dbo].[get_port_info]    Script Date: 6/9/2024 10:23:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Create stored procedure for reading port info
CREATE   PROCEDURE [dbo].[get_port_info]
AS
BEGIN
    SELECT * FROM port_info;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_measurement_info_addnew]    Script Date: 6/9/2024 10:23:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Create the new stored procedure
CREATE PROCEDURE [dbo].[sp_measurement_info_addnew]
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
/****** Object:  StoredProcedure [dbo].[sp_measurement_info_delete]    Script Date: 6/9/2024 10:23:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Create the new stored procedure
CREATE PROCEDURE [dbo].[sp_measurement_info_delete]
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
/****** Object:  StoredProcedure [dbo].[sp_measurement_info_getall]    Script Date: 6/9/2024 10:23:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Create the new stored procedure
CREATE PROCEDURE [dbo].[sp_measurement_info_getall]
    @CodeValue INT OUTPUT,
    @RowCount INT OUTPUT,
    @MessageResult NVARCHAR(1000) OUTPUT
AS
BEGIN
    DECLARE @errCode CHAR(5) = '00000';
    DECLARE @errMsg NVARCHAR(4000);
    DECLARE @count INT;

    PRINT 'Starting procedure sp_measurement_info_getall';

    BEGIN TRY
        PRINT 'Executing SELECT statement';
        SELECT TOP 100 * FROM dbo.measurement_info;
        
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

    PRINT 'Procedure sp_measurement_info_getall completed';
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_measurement_info_getbyid]    Script Date: 6/9/2024 10:23:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Create the new stored procedure
CREATE PROCEDURE [dbo].[sp_measurement_info_getbyid]
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
/****** Object:  StoredProcedure [dbo].[sp_measurement_info_update]    Script Date: 6/9/2024 10:23:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Create the new stored procedure
CREATE PROCEDURE [dbo].[sp_measurement_info_update]
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
/****** Object:  StoredProcedure [dbo].[update_acceleration_reading]    Script Date: 6/9/2024 10:23:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Create stored procedure for updating an acceleration reading
CREATE   PROCEDURE [dbo].[update_acceleration_reading]
    @p_reading_id INT,
    @p_measurement_id INT,
    @p_port_id INT,
    @p_x_acceleration FLOAT,
    @p_y_acceleration FLOAT,
    @p_z_acceleration FLOAT
AS
BEGIN
    UPDATE acceleration_readings
    SET measurement_id = @p_measurement_id,
        port_id = @p_port_id,
        x_acceleration = @p_x_acceleration,
        y_acceleration = @p_y_acceleration,
        z_acceleration = @p_z_acceleration
    WHERE reading_id = @p_reading_id;
END
GO
USE [master]
GO
ALTER DATABASE [accelerometer_data] SET  READ_WRITE 
GO
