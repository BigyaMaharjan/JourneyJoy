CREATE TABLE [dbo].[tbl_ReserveVehicle](
	[ReserveID] [bigint] IDENTITY(1,2) PRIMARY KEY,	
	[UserID] [int] NOT NULL,
	[VehicleID] [int] NOT NULL,
	[ReserveFromDate] [nvarchar](100) NULL,
	[ReserveToDate] [nvarchar](100) NULL,
	[ReserveReason] [varchar](50) NULL,
	[ReservedDuration] [varchar](50) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [varchar](50) NULL,
	[UpdatedDate] [varchar](50) NULL,
	[UpdatedBy] [varchar](50) NULL
	);