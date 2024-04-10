tbl_Vehicle (VID,Type,Company Name,Description,Owner,Image,rating,luggage,fule,Price,seats,Actionuser,createdDate)
tbl_Customer (CID,FirstName,MiddleName,LastName,LicenceImage,Email,Title,Number,Addres,City,DateofBirth,ActionUser,CreatedDate )
tbl_Booking (BID,CID,VID,BookingDate,DropLocation,PickingLocation,BookingDuration,Price,ActionUser,CreatedDate)

SELECT * FROM [dbo].[tbl_Customer]

INSERT INTO [dbo].[tbl_Customer]
(CustomerName, Password, MobileNumber) VALUES ('tARZAN', 'UYQWE62', '98745152')

CREATE TABLE tbl_Vehicle(
	VehicleID INT NOT NULL, PRIMARY KEY (VehicleID),
	VehicleType	nvarchar(10),
	VehicleModel nvarchar(10),
	VehicleCapacity	nvarchar(10),
	TotalSeats	nvarchar(10),
	TotalMileage	nvarchar(10),
	TotalPrice	nvarchar(10),
	Image	nvarchar(10),
	Rating	nvarchar
)

CREATE TABLE tbl_Booking(
	BookingID INT NOT NULL, PRIMARY KEY (VehicleID),
	CustomerID INT,
	VehicleID INT,
	BookingDate	DATE,
	DropLocation nvarchar(10),
	PickingLocation	nvarchar(10),
	BookingDuration	nvarchar(10),
	Price	nvarchar(10),
	ActionUser	nvarchar(10),
	CreatedDate	Date,

)

ALTER TABLE [dbo].[tbl_Customer]
ADD Email		nvarchar(25),
	Title		nvarchar(5),
	FirstName	nvarchar(10),
	MiddleName	nvarchar(10),
	LastName	nvarchar(10),
	Country		nvarchar(10),
	Address		nvarchar(10),
	City		nvarchar(10),
	PostCode	nvarchar(10),
	Description	nvarchar(10),
	Age			nvarchar(10),
	Gender		nvarchar(10),
	DriverLicenceNumber int,
	DriverLicenceImage	nvarchar(10),
	RefundableDeposite	nvarchar(10),
	GrandTotal	nvarchar(10)






SELECT 000 code,
			'success' message,
			* FROM [dbo].[tbl_Customer]
		WHERE CustomerName = 'tARZAN'



		exec sp_LogIn  @flag= 'L' ,@CustomerName='tARZAN',@Password='hhhhhhhhh'