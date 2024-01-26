CREATE OR ALTER PROC [dbo].[sproc_customer_registration]
    @Flag VARCHAR(10),
	@UserName VARCHAR(50) = NULL,
    @Password VARCHAR(16) = NULL,
	@Email VARCHAR(2550) = NULL,
    @MobileNumber VARCHAR(15) = NULL,
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
        @ErrorDesc VARCHAR(MAX)

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
			@Password,
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