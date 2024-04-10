CREATE TABLE [dbo].[tbl_ContactUs](
	[CID] [bigint] IDENTITY(1,2) NOT NULL,
	[FirstName] [varchar](120) NULL,
	[LastName] [varchar](120) NULL,
	[Vehicle] [varchar](50) NULL,
	[Email] [varchar](255) NULL,
	[Description] [varchar](500) NULL,
	[CreatedBy] [Varchar] NULL,
	[CreatedDate] [datetime] NULL
)
GO