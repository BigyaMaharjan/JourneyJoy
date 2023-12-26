CREATE TABLE [dbo].[tbl_error_log](
	[Id] [bigint] IDENTITY(1,2) NOT NULL,
	[ErrorDesc] [varchar](max) NULL,
	[ErrorScript] [varchar](512) NULL,
	[QueryString] [varchar](512) NULL,
	[ErrorCategory] [varchar](512) NULL,
	[ErrorSource] [varchar](512) NULL,
	[ActionDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
