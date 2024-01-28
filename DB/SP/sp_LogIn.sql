USE [JourneyJoy]
GO
/****** Object:  StoredProcedure [dbo].[sp_LogIn]    Script Date: 1/28/2024 2:54:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[sp_LogIn] 
@flag nvarchar (15),
@CustomerName nvarchar (15),
@Password nvarchar (15)
 AS

 BEGIN
 IF  ISNULL(@flag, '')  = 'L'
	BEGIN	
		IF @CustomerName IS NULL 
		BEGIN
			SELECT 100 code , 
				'Customer name is Required !' message
				RETURN 
		END
		IF @Password IS NULL 
		BEGIN
			SELECT 99 code , 
				'Password is Required !' message
				RETURN 
		END
		IF EXISTS (SELECT 'X' FROM tbl_UserDetail
			WHERE UserName = @CustomerName)
			SELECT 000 code,
				'success' message,
				* FROM [dbo].[tbl_UserDetail]  WITH (NOLOCK)
			WHERE UserName = @CustomerName
		ELSE
			SELECT 1 code,
			'Password or Username wrong' message
	END
 END