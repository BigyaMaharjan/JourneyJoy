SELECT * FROM tbl_UserDetail
SELECT * FROM tbl_VehicleDetail
SELECT * FROM tbl_ReserveVehicle
SELECT * FROM tbl_LocationList
SELECT * FROM tbl_Transaction

 SELECT DATEDIFF(DAY,'2023-12-17','2023-12-20') as ReservedDuration;

 Difference in IS NULL && ISNULL
 EXISTS
 NOT EXISTS
 SCOPE_IDENTITY()
 cast()
 len()
 DECLARE

 --Multiple Insert
 INSERT INTO tbl_LocationList
  (
	  [LocationName],
	  [LocationDescription],
	  [LocationStatus],
	  [CreatedBy],
	  [CreatedDate]
  )
VALUES
  ('Kathmandu', 'Capital City', 0,'SHINIGAMI',GETDATE()), 
  ('Pokhara', 'City', 0,'SHINIGAMI',GETDATE()), 
  ('Bharatpur', 'City', 1,'SHINIGAMI',GETDATE()), 
  ('Lalitpur', 'City', 0,'SHINIGAMI',GETDATE());

  --https://en.wikipedia.org/wiki/List_of_cities_in_Nepal#Map