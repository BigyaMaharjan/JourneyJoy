Create or ALTER   PROC [dbo].[sp_SearchVehicleList]
    @Flag VARCHAR(10),
	@UserName VARCHAR(50) = NULL,
	@Title VARCHAR(10) = NULL,
	@UserType VARCHAR(10) = NULL,
	@ProfileImage VARCHAR(MAX) = NULL,
	@DriverLicenceNumber VARCHAR(50) = NULL,
    @CreatedBy VARCHAR(50) = NULL,
    @CreatedDate VARCHAR(100) = NULL,
    @UpdatedDate VARCHAR(100) = NULL,
	@UpdatedBy VARCHAR(50) = NULL
AS
DECLARE 
        @ErrorDesc VARCHAR(MAX)

BEGIN TRY
    IF ISNULL(@Flag, '') = 'gral' --Get rectently added  List
    BEGIN      
        SELECT 0 Code,
               'Registration successfull' Message,
			   VehicleID,
			   VehicleType,
			   Rating,
			   Title,
			   TotalMilage,
			   ProfileImage,
			   TotalPrice,
			   CreatedBy,
			   CreatedDate,
			   Detail
			   from tbl_VehicleDetail
        RETURN;
    END;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
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