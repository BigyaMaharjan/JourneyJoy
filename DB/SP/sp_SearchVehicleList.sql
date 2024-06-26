USE [JourneyJoy]
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchVehicleList]    Script Date: 3/13/2024 10:09:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER     PROC [dbo].[sp_SearchVehicleList]
    @Flag VARCHAR(10),
	@UserName VARCHAR(50) = NULL,
	@Title VARCHAR(10) = NULL,
	@id Varchar(10) = NULL,
	@UserType VARCHAR(10) = NULL,
	@VehicleCategory VARCHAR(15) = NULL,
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
               'Success' Message,
			   VehicleID,
			   VehicleType,
			   Rating,
			   Title,
			   TotalMilage,
			   ProfileImage,
			   TotalSeats,
			   VehicleCapacity,
			   TotalPrice,
			   CreatedBy,
			   CreatedDate,
			   Detail
			   from tbl_VehicleDetail
        RETURN;
    END;

	IF ISNULL(@Flag, '') = '00l' --location
    BEGIN
        SELECT DISTINCT top 99
               l.LocationName AS Value,
               l.LocationId AS TEXT
        FROM tbl_LocationList l WITH (NOLOCK)
            
        WHERE l.LocationStatus = 0
        ORDER BY l.LocationName ASC;

        RETURN;
    END;

	IF ISNULL(@Flag, '') = 'vtype' --Vehicle Type
    BEGIN
	IF @Title IS NULL 
		BEGIN
			SELECT 100 code , 
				'Title is Required !' message
				RETURN 
		END
        	SELECT    
			   ud.UserID,
               ud.UserName,
			   vd.VehicleID,
			   vd.VehicleType,
			   vd.VehicleModel,
			   vd.Title,
			   vd.VehicleCapacity,
			   vd.Rating,
			   vd.TotalSeats,
			   vd.IsAvailable,
			   vd.TotalMilage,
			   vd.ProfileImage,
			   vd.TotalPrice,
			   vd.Detail
        FROM tbl_VehicleDetail vd WITH (NOLOCK)
            INNER JOIN tbl_UserDetail ud WITH (NOLOCK)
                ON ud.UserID = vd.userid
        WHERE vd.IsAvailable = 1
              AND vd.VehicleType = @Title

        RETURN;
    END;

	IF ISNULL(@Flag, '') = 'vid' --By Vehicle Id
    BEGIN
	IF @id IS NULL 
		BEGIN
			SELECT 100 code , 
				'ID is Required !' message
				RETURN 
		END
        	SELECT    
			   '0' AS code,
			   'Success' AS message,
			   ud.UserID,
               ud.UserName,
			   vd.VehicleID,
			   vd.VehicleType,
			   vd.VehicleModel,
			   vd.Title,
			   vd.VehicleCapacity,
			   vd.Rating,
			   vd.TotalSeats,
			   vd.IsAvailable,
			   vd.TotalMilage,
			   vd.ProfileImage,
			   vd.TotalPrice,
			   vd.Detail
        FROM tbl_VehicleDetail vd WITH (NOLOCK)
            INNER JOIN tbl_UserDetail ud WITH (NOLOCK)
                ON ud.UserID = vd.userid
        WHERE vd.IsAvailable = 1
              AND vd.VehicleID = @id

        RETURN;
    END;

	IF ISNULL(@Flag, '') = 'gsvcl' -- gsvcl- Get Searched Vechicle Category List
    BEGIN
	IF @id IS NULL 
		BEGIN
			SELECT 100 code , 
				'ID is Required !' message
				RETURN 
		END
	IF @VehicleCategory IS NULL 
	BEGIN
		SELECT 100 code , 
			'Vehicle Category is Required !' message
			RETURN 
	END
        	SELECT    
			   '0' AS code,
			   'Success' AS message,
			   ud.UserID,
               ud.UserName,
			   ll.LocationId,
               ll.LocationName,
			   vd.VehicleID,
			   vd.VehicleType,
			   vd.VehicleModel,
			   vd.Title,
			   vd.VehicleCapacity,
			   vd.Rating,
			   vd.TotalSeats,
			   vd.IsAvailable,
			   vd.TotalMilage,
			   vd.ProfileImage,
			   vd.TotalPrice,
			   vd.Detail
        FROM tbl_VehicleDetail vd WITH (NOLOCK)
		INNER JOIN tbl_LocationList ll WITH (NOLOCK) ON ll.LocationId = vd.City
		INNER JOIN tbl_UserDetail ud WITH (NOLOCK) ON ud.UserID = vd.userid
		WHERE vd.IsAvailable = 1
              AND ll.LocationId = @id
			  AND vd.VehicleType = @VehicleCategory
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