USE [JourneyJoy]
GO
/****** Object:  StoredProcedure [dbo].[sp_LogIn]    Script Date: 12/31/2023 9:04:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER   PROC [dbo].[sp_SearchVehicleList] 
@flag nvarchar (1),
@LocationId nvarchar (15)

 AS

 BEGIN
 IF  ISNULL(@flag, '')  = 'S'
	BEGIN	
		IF @LocationId IS NULL 
		BEGIN
			SELECT 100 code , 
				'LocationId is Required!' message
				RETURN 
		END		
		SELECT 000 code,
			'success' message,
			* FROM [dbo].[tbl_VehicleDetail]
		WHERE LocationId = 1 AND IsAvailable = '0'			
	END
 END


 select * from[dbo].[tbl_VehicleDetail]
 select * from[dbo].[tbl_LocationList]

 ALTER TABLE [dbo].[tbl_VehicleDetail]
 ADD  LocationId INT NOT NULL

 INSERT INTO [dbo].[tbl_VehicleDetail]
 (VehicleType, TotalPrice, TotalSeats, IsAvailable, LocationId)
 Values ('Ferrari', 10000, 2, 0, 1)