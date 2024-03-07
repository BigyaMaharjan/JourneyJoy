CREATE OR ALTER PROC [dbo].[sp_Booking_Vehicle] 
@flag varchar (5),
@Username nvarchar (55) = null,
@Email VARCHAR(250) = NULL,
@Phonenumber VARCHAR(10) = NULL,
@Country VARCHAR(70) = NULL,
@City VARCHAR(76) = null,
@VID VARCHAR(10) = null,
@UID VARCHAR(10) = null,
@DrivingLicence VARCHAR(75) = NULL,
@Image NVARCHAR (MAX) = NULL
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
			[CreatedDate]
			)
			VALUES(
			@UID,
			@VID,
			'PENDING',
			'SHINIGAMI',
			GETDATE()
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
            INNER JOIN tbl_booking_vehicle bv WITH (NOLOCK)
                ON bv.VehicleID = vd.VehicleID
        WHERE bv.BookingStatus = 'PENDING'
              AND vd.IsAvailable = '0'
			  AND bv.userid = @UID
	END
END