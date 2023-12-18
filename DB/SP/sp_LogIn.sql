CREATE PROC sp_LogIn 
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
		IF EXISTS (SELECT 'X' FROM tbl_Customer
			WHERE CustomerName = @CustomerName)
			SELECT 000 code,
				'success' message,
				* FROM [dbo].[tbl_Customer]  WITH (NOLOCK)
			WHERE CustomerName = @CustomerName
		ELSE
			SELECT 1 code,
			'Password or Username wrong' message
	END
 END