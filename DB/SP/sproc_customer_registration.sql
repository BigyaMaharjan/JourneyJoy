USE [JourneyJoy]
GO
/****** Object:  StoredProcedure [dbo].[sproc_customer_registration]    Script Date: 3/17/2024 11:04:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROC [dbo].[sproc_customer_registration]
    @Flag VARCHAR(10),
	@UserName VARCHAR(50) = NULL,
	@FirstName VARCHAR(120) = NULL,
	@LastName VARCHAR(120) = NULL,
    @Password VARCHAR(16) = NULL,
	@Email VARCHAR(2550) = NULL,
    @MobileNumber VARCHAR(15) = NULL,
	@Vehicle VARCHAR(20) = NULL,
	@Gender VARCHAR(10) = NULL,
	@Title VARCHAR(10) = NULL,
	@UserType VARCHAR(10) = NULL,
	@ProfileImage VARCHAR(MAX) = NULL,
	@Bio VARCHAR(500) = NULL,
	@DriverLicenceNumber VARCHAR(50) = NULL,
	@Country VARCHAR(75) = NULL,
	@City VARCHAR(75) = NULL,
	@CurrentAdress VARCHAR(75) = NULL,
	@PostCode VARCHAR(10) = NULL,
	@Age VARCHAR(10) = NULL,
    @CreatedBy VARCHAR(50) = NULL,
    @CreatedDate VARCHAR(100) = NULL,
    @UpdatedDate VARCHAR(100) = NULL,
	@UpdatedBy VARCHAR(50) = NULL
AS
DECLARE @TransactionName VARCHAR(200),
        @ErrorDesc VARCHAR(MAX),
		@scopeid varchar(10)

BEGIN TRY
    IF ISNULL(@Flag, '') = 'rc' --register customer
    BEGIN
        IF EXISTS
        (
            SELECT 'X'
            FROM dbo.tbl_UserDetail ud WITH (NOLOCK)
            WHERE ud.MobileNo = @MobileNumber
			and ud.UserType = @UserType
        )
        BEGIN
            SELECT 1 Code,
                   'Mobile number with same Usertype already exists' Message;
            RETURN;
        END;
        
        SET @TransactionName = 'Flag_rc';

        BEGIN TRANSACTION @TransactionName;

        INSERT INTO dbo.tbl_UserDetail
        (
            [UserName],
            [Password],
            [Email],
            [MobileNo],
            [Gender],
            [Title],
            [UserType],
			[ProfileImage],
			[Bio],
			[DriverLicenceNumber],
			[Country],
			[City],
			[CurrentAdress],
			[PostCode],
			[Age],
			[CreatedBy],
			[CreatedDate]
			)
        VALUES
        (
			@UserName,
			CONVERT(varbinary(max), @Password),
			@Email,
			@MobileNumber,
			@Gender,
			@Title,
			@UserType,
			@ProfileImage,
			@Bio,
			@DriverLicenceNumber,
			@Country,
			@City,
			@CurrentAdress,
			@PostCode,
			@Age,
			@CreatedBy,
			GETDATE()
			);

        COMMIT TRANSACTION @TransactionName;

        SELECT 0 Code,
               'Registration successfull' Message
        RETURN;
    END;
	    IF ISNULL(@Flag, '') = 'cu' --Contact us
    BEGIN
        INSERT INTO dbo.tbl_ContactUs
        (
            [FirstName],
            [LastName],
            [Vehicle],
            [Email],
            [Description],            
			[CreatedBy],
			[CreatedDate]
			)
        VALUES
        (
			@FirstName,
			@LastName,
			@Vehicle,
			@Email,
			@Bio,
			@CreatedBy,
			GETDATE()
			);

			SET @scopeid = SCOPE_IDENTITY();
			
        SELECT 0 Code,
               'User Information saved successfull' Message,
			   * from tbl_ContactUs
			   where CID = @scopeid
        RETURN;
    END;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION @TransactionName;

    SET @ErrorDesc = 'SQL error found: (' + ERROR_MESSAGE() + ')' + ' at ' + CAST(ERROR_LINE() AS VARCHAR);

    INSERT INTO tbl_error_log
    (
        ErrorDesc,
        ErrorScript,
        QueryString,
        ErrorCategory,
        ErrorSource,
        ActionDate
    )
    VALUES
    (@ErrorDesc, 'sproc_customer_registration (Flag: ' + ISNULL(@Flag, '') + ')', 'SQL', 'SQL',
     'sproc_customer_registration', GETDATE());

    SELECT 1 Code,
           'ErrorId:' + CAST(SCOPE_IDENTITY() AS VARCHAR) Message;
    RETURN;
END CATCH;