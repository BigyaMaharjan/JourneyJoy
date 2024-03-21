USE [JourneyJoy]
GO
/****** Object:  StoredProcedure [dbo].[sp_LogIn]    Script Date: 3/18/2024 2:29:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[sp_LogIn] 
@flag varchar (5),
@CustomerName nvarchar (15) = NULL,
@Firstname VARCHAR(30) = NULL,
@Lastname VARCHAR(30) = NULL,
@Mobilenumber VARCHAR(10) = NULL,
@Password VARCHAR(16) = NULL,
@Email VARCHAR(255) = NULL,
@confirmpassword VARCHAR (16) = NULL,
@UID VARCHAR(5) = NULL
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
			--and Password = PWDENCRYPT(CONVERT(varbinary,@Password))
		ELSE
			SELECT 1 code,
			'Password or Username wrong' message
	END

IF ISNULL(@flag, '') = 'reg'
BEGIN
	IF(@Mobilenumber IS NULL)
		BEGIN
			SELECT 101 CODE,
			'Customer Mobile Number is required' MESSAGE
			RETURN
		END
	IF (@Password <> @confirmpassword)
		BEGIN
			SELECT 102 CODE,
			'Password and Confirm password didnt macth' MESSAGE
			RETURN
		END

		INSERT INTO tbl_UserDetail(
		UserName,
		Email,
		MobileNo,
		[Password]		
		)
		VALUES(
		@CustomerName,
		@Email,
		@Mobilenumber,
		PWDENCRYPT(CONVERT(varbinary,@Password))
		)

		SELECT 000 CODE,
		'success' message
		return
END

IF ISNULL(@flag, '') = 'gud'
BEGIN
	IF(@UID IS NULL)
		BEGIN
			SELECT 101 CODE,
			'User Id is required' MESSAGE
			RETURN
		END	 
	 

		SELECT 000 CODE,
		'success' message,
		*
		from tbl_UserDetail
		where UserID = @UID
		return
END
END