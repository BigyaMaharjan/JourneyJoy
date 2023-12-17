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
				'CustomerName is Required!' message
				RETURN 
		END
		IF @Password IS NULL 
		BEGIN
			SELECT 99 code , 
				'Password is Required!' message
				RETURN 
		END
		SELECT 000 code,
			'success' message,
			* FROM [dbo].[tbl_Customer]
		WHERE CustomerName = @CustomerName
	END
 END
