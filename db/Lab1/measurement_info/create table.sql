USE [accelerometer_data]
GO
    /****** Object:  Table [dbo].[measurement_info]    Script Date: 6/8/2024 11:39:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO CREATE TABLE [dbo].[measurement_info](
        [measurement_id] [int] IDENTITY(1, 1) NOT NULL,
        [first_start_time] [datetime] NULL,
        [sensor_description] [nvarchar](255) NULL,
        [created_at] [datetime] NOT NULL,
        [serial_port] [nvarchar](5) NOT NULL,
        CONSTRAINT [PK__measurem__E3D1E1C1EA57F2DC] PRIMARY KEY CLUSTERED ([measurement_id] ASC) WITH (
            PAD_INDEX = OFF,
            STATISTICS_NORECOMPUTE = OFF,
            IGNORE_DUP_KEY = OFF,
            ALLOW_ROW_LOCKS = ON,
            ALLOW_PAGE_LOCKS = ON,
            OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
        ) ON [PRIMARY]
    ) ON [PRIMARY]
GO
ALTER TABLE [dbo].[measurement_info]
ADD CONSTRAINT [DF__measureme__creat__36B12243] DEFAULT (getdate()) FOR [created_at]
GO