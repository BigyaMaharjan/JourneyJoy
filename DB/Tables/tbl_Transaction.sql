CREATE TABLE dbo.tbl_Transaction
(
	[Sno] [BIGINT] IDENTITY(1,2) NOT NULL,
	[TransactionId] [BIGINT] NULL,
	[VehicleId] BIGINT NULL,
	[Amount] DECIMAL(18,2) NULL,
	[Remarks] VARCHAR(512) NULL,
	[Status] CHAR(1) NULL,
	[GatewayStatus] VARCHAR(50) NULL,
	[GatewayTxnId] VARCHAR(150) NULL,
	[GatewayCharge] DECIMAL(18,2) NULL,
	[CreatedDate] DATETIME NOT NULL DEFAULT GETDATE(),
    [ActionUser] VARCHAR(200) NULL,
    [ActionIP] VARCHAR(50) NULL,
    [ActionPlatform] VARCHAR(20) NULL
)


