CREATE TABLE [dbo].[tbl_VehicleDetail](
	[VehicleID] [bigint] IDENTITY(1,2) PRIMARY KEY,
	[VehicleType] [varchar](100) NULL,
	[VehicleModel] [varchar](100) NULL,
	[VehicleCapacity] [varchar](50) NULL,
	[Rating] [int] NULL,
	[TotalSeats] [int] NULL,
	[IsAvailable] [bit] NOT NULL,
	[Title] [varchar](50) NULL,
	[TotalMilage] [varchar](50) NULL,
	[ProfileImage] [varchar](MAX) NULL,
	[TotalPrice] [varchar](500) NULL,
	[Country] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [varchar](50) NULL,
	[UpdatedDate] [varchar](50) NULL,
	[UpdatedBy] [varchar](50) NULL
	);

