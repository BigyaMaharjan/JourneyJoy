CREATE TABLE [dbo].[tbl_booking_vehicle](
	[BID] [bigint] IDENTITY(1,2) PRIMARY KEY,	
	[UserID] [int] NOT NULL,
	[VehicleID] [int] NOT NULL,
	[BookingStatus] [varchar](10) NOT NULL,
	[ExtraData] [varchar](100) NULL,
	[ExtraData2] [varchar](100) NULL,
	[ExtraData3] [varchar](100) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [varchar](50) NULL,
	[UpdatedDate] [varchar](50) NULL,
	[UpdatedBy] [varchar](50) NULL
	);