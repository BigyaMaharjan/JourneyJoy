USE [JourneyJoy]
GO
/****** Object:  StoredProcedure [dbo].[sp_Booking_Vehicle]    Script Date: 3/26/2024 12:50:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROC [dbo].[sp_Booking_Vehicle] 
@flag varchar (5),
@Username nvarchar (55) = null,
@Email VARCHAR(250) = NULL,
@Phonenumber VARCHAR(10) = NULL,
@Country VARCHAR(70) = NULL,
@City VARCHAR(76) = null,
@VID VARCHAR(5) = null,
@UID VARCHAR(5) = null,
@ExtraData VARCHAR(10) = null,
@ExtraData2 VARCHAR(10) = null,
@DrivingLicence VARCHAR(75) = NULL,
@Image NVARCHAR (MAX) = NULL,
@VehicleType VARCHAR(20) = NULL,
@VehicleModel VARCHAR(20) = NULL,
@VehicleCapicity VARCHAR(10) = NULL,
@VehicleRating VARCHAR(10) = NULL,
@VehicleSeats VARCHAR(10) = NULL,
@Title VARCHAR(70) = NULL,
@Milage VARCHAR(10) = NULL,
@Price VARCHAR(10) = NULL,
@Detail VARCHAR(500) = NULL
 AS

 BEGIN
 IF  ISNULL(@flag, '')  = 'bv' --Book vehicle
	BEGIN	
		IF @DrivingLicence IS NULL 
		BEGIN
			SELECT 100 code , 
				'Driving Licence is Required !' message
				RETURN 
		END
		IF @Phonenumber IS NULL 
		BEGIN
			SELECT 99 code , 
				'Phone number is Required !' message
				RETURN 
		END
		IF @Email IS NULL 
		BEGIN
			SELECT 98 code , 
				'Email is Required !' message
				RETURN 
		END
		IF @Image IS NULL 
		BEGIN
			SELECT 97 code , 
				'Image is Required !' message
				RETURN 
		END

		IF EXISTS (SELECT 'X' FROM tbl_booking_vehicle
			WHERE UserID = @UID)
			BEGIN
			SELECT 001 code,
				'User already has one booking in pending, So cannot book' message
				RETURN
			END

		IF EXISTS (SELECT 'X' FROM tbl_booking_vehicle
			WHERE VehicleID = @VID)
			BEGIN
			SELECT 001 code,
				'Somebody already booked this vehicle or is in Pending state' message
				RETURN
			END
		ELSE
		BEGIN
			INSERT INTO tbl_booking_vehicle(
			[UserID],
			[VehicleID],
			[BookingStatus],
			[CreatedBy],
			[CreatedDate],
			[ExtraData],
			[ExtraData2],
			[ExtraData3]
			)
			VALUES(
			@UID,
			@VID,
			'PENDING',
			'SHINIGAMI',
			GETDATE(),
			@ExtraData,
			@ExtraData2,
			DATEDIFF(DAY, DATEADD(MONTH, DATEDIFF(MONTH, @ExtraData, @ExtraData2), @ExtraData), @ExtraData2)
			)

			UPDATE tbl_VehicleDetail set IsAvailable = '0'
			where VehicleID = @VID

			SELECT 000 code,
				  'Vehicle Booked Successfully' message
				  RETURN;
		END
	END

 IF  ISNULL(@flag, '')  = 'gbvl' --gbvl- Get booking vehicle lsit
	BEGIN			
		IF @UID IS NULL 
		BEGIN
			SELECT 97 code , 
				'UID is Required !' message
				RETURN 
		END
		SELECT    
			   bv.BID,
               bv.BookingStatus,
			   bv.ExtraData,
			   bv.ExtraData2,
			   bv.ExtraData3,
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
			   CASE
				WHEN ISNUMERIC(vd.TotalPrice) = 1 AND ISNUMERIC(BV.ExtraData3) = 1 THEN CONVERT(decimal(18, 2), vd.TotalPrice) * CONVERT(decimal(18, 2), BV.ExtraData3)
				ELSE NULL -- Handle non-numeric values or null values appropriately
				END AS CalculatedPrice,
			   vd.Detail
        FROM tbl_VehicleDetail vd WITH (NOLOCK)
            INNER JOIN tbl_booking_vehicle bv WITH (NOLOCK)
                ON bv.VehicleID = vd.VehicleID
        WHERE bv.BookingStatus = 'PENDING'
              AND vd.IsAvailable = '0'
			  AND bv.userid = @UID
	END

 IF  ISNULL(@flag, '')  = 'cb' -- cb - Cancell book
	BEGIN			
		IF @UID IS NULL 
		BEGIN
			SELECT 97 code , 
				'UID is Required !' message
				RETURN 
		END
		IF @VID IS NULL 
		BEGIN
			SELECT 99 code , 
				'VID is Required !' message
				RETURN 
		END
		UPDATE tbl_booking_vehicle set BookingStatus = 'Cancelled'
		WHERE BID = @UID AND VehicleID = @VID

		UPDATE tbl_VehicleDetail set IsAvailable = '1'
		where VehicleID = @VID

		SELECT    
			  '000' code,
			  'Booking Cancelled Successfully' Message
			  RETURN;
	END

	IF ISNULL(@flag, '') = 'av' -- add vehicle
BEGIN
	IF(@UID IS NULL)
		BEGIN
			SELECT 101 CODE,
			'User id is required' MESSAGE
			RETURN
		END
			IF(@Price IS NULL)
		BEGIN
			SELECT 102 CODE,
			'Price is required' MESSAGE
			RETURN
		END
			IF(@Image IS NULL)
		BEGIN
			SELECT 103 CODE,
			'Vehicle Image is required' MESSAGE
			RETURN
		END

		INSERT INTO tbl_VehicleDetail(
		VehicleType,
		VehicleModel,
		VehicleCapacity,
		Rating,
		TotalSeats,
		Title,
		TotalMilage,
		ProfileImage,
		TotalPrice,
		Detail,
		City,
		[CreatedBy],
		[CreatedDate]
		)
		VALUES(
		@VehicleType,
		@VehicleModel,
		@VehicleCapicity,
		@VehicleRating,
		@VehicleSeats,
		@Title,
		@Milage,
		@Image,
		@Price,
		@Detail,
		@City,
		'SHINIGAMI',
		GETDATE()
		)

		SELECT 000 CODE,
		'success' message
		return
END

 IF  ISNULL(@flag, '')  = 'gvbid' --gvbid- Get vehicles by ID
	BEGIN			
		IF @UID IS NULL 
		BEGIN
			SELECT 97 code , 
				'UID is Required !' message
				RETURN 
		END
		SELECT   
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
			   vd.Detail,
			   vd.userid
        FROM tbl_VehicleDetail vd WITH (NOLOCK)
            INNER JOIN tbl_UserDetail bv WITH (NOLOCK)
                ON bv.UserID = vd.userid
        WHERE vd.IsAvailable = '1'
			  AND bv.userid = @UID
	END
END