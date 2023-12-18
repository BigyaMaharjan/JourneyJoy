CREATE TABLE [dbo].[tbl_LocationList](
	[LocationId] [bigint] IDENTITY(1,2) NOT NULL,
	[LocationName] [varchar](500) NULL,
	[LocationDescription] [varchar] NULL,
	[LocationStatus] [bit] NOT NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [varchar](50) NULL,
	[UpdatedDate] [varchar](50) NULL,
	[UpdatedBy] [varchar](50) NULL
	);