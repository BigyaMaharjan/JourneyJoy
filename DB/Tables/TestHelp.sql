SELECT * FROM tbl_customer
SELECT * FROM tbl_VehicleDetail
SELECT * FROM tbl_ReserveVehicle
SELECT * FROM tbl_LocationList
SELECT * FROM tbl_Transaction

 SELECT DATEDIFF(DAY,'2023-12-17','2023-12-20') as ReservedDuration;

 
 --Difference in IS NULL && ISNULL
 --EXISTS
 --NOT EXISTS
 --SCOPE_IDENTITY()
 --cast()
 --len()
 --DECLARE 

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
  ('Lalitpur', 'City', 0,'SHINIGAMI',GETDATE()),
  ('Aathabis', 'City', 0, 'Kale', GETDATE()),
('Aathabiskot', 'City', 0, 'Kale', GETDATE()),
('Aurahi', 'City', 0, 'Kale', GETDATE()),
('Bagchaur', 'City', 0, 'Kale', GETDATE()),
('Bagmati', 'City', 0, 'Kale', GETDATE()),
('Bahudarmai', 'City', 0, 'Kale', GETDATE()),
('Balara', 'City', 0, 'Kale', GETDATE()),
('Balawa', 'City', 0, 'Kale', GETDATE()),
('Bangad Kupinde', 'City', 0, 'Kale', GETDATE()),
('Barhabise', 'City', 0, 'Kale', GETDATE()),
('Baudhimai', 'City', 0, 'Kale', GETDATE()),
('Bedkot', 'City', 0, 'Kale', GETDATE()),
('Belaka', 'City', 0, 'Kale', GETDATE()),
('Belkotgadhi', 'City', 0, 'Kale', GETDATE()),
('Beni', 'City', 0, 'Kale', GETDATE()),
('Besisahar', 'City', 0, 'Kale', GETDATE()),
('Bhangaha', 'City', 0, 'Kale', GETDATE()),
('Bhanu', 'City', 0, 'Kale', GETDATE()),
('Bheri', 'City', 0, 'Kale', GETDATE()),
('Bheriganga', 'City', 0, 'Kale', GETDATE()),
('Bhimad', 'City', 0, 'Kale', GETDATE()),
('Bhimeshwar', 'City', 0, 'Kale', GETDATE()),
('Bhirkot', 'City', 0, 'Kale', GETDATE()),
('Bhojpur', 'City', 0, 'Kale', GETDATE()),
('Bhumikasthan', 'City', 0, 'Kale', GETDATE()),
('Bideha', 'City', 0, 'Kale', GETDATE()),
('Bodebarsain', 'City', 0, 'Kale', GETDATE()),
('Brindaban', 'City', 0, 'Kale', GETDATE()),
('Bungal', 'City', 0, 'Kale', GETDATE()),
('Chainpur', 'City', 0, 'Kale', GETDATE()),
('Chamunda Bindrasaini', 'City', 0, 'Kale', GETDATE()),
('Chapakot', 'City', 0, 'Kale', GETDATE()),
('Chaudandigadhi', 'City', 0, 'Kale', GETDATE()),
('Chaurjahari', 'City', 0, 'Kale', GETDATE()),
('Chautara Sangachokgadhi', 'City', 0, 'Kale', GETDATE()),
('Chhedagad', 'City', 0, 'Kale', GETDATE()),
('Chhireshwarnath', 'City', 0, 'Kale', GETDATE()),
('Dakneshwari', 'City', 0, 'Kale', GETDATE()),
('Dasharathchand', 'City', 0, 'Kale', GETDATE()),
('Deumai', 'City', 0, 'Kale', GETDATE()),
('Devchuli', 'City', 0, 'Kale', GETDATE()),
('Dewahi Gonahi', 'City', 0, 'Kale', GETDATE()),
('Dhangadimai', 'City', 0, 'Kale', GETDATE()),
('Dhankuta', 'City', 0, 'Kale', GETDATE()),
('Dhanushadham', 'City', 0, 'Kale', GETDATE()),
('Dhorpatan', 'City', 0, 'Kale', GETDATE()),
('Dhulikhel', 'City', 0, 'Kale', GETDATE()),
('Dhunibeshi', 'City', 0, 'Kale', GETDATE()),
('Dipayal Silgadhi', 'City', 0, 'Kale', GETDATE()),
('Dullu', 'City', 0, 'Kale', GETDATE()),
('Gadhimai', 'City', 0, 'Kale', GETDATE()),
('Galkot', 'City', 0, 'Kale', GETDATE()),
('Galyang', 'City', 0, 'Kale', GETDATE()),
('Ganeshman Charanath', 'City', 0, 'Kale', GETDATE()),
('Gaur', 'City', 0, 'Kale', GETDATE()),
('Godaita', 'City', 0, 'Kale', GETDATE()),
('Gorkha', 'City', 0, 'Kale', GETDATE()),
('Gujara', 'City', 0, 'Kale', GETDATE()),
('Gurbhakot', 'City', 0, 'Kale', GETDATE()),
('Halesi Tuwachung', 'City', 0, 'Kale', GETDATE()),
('Hansapur', 'City', 0, 'Kale', GETDATE()),
('Hanumannagar Kankalini', 'City', 0, 'Kale', GETDATE()),
('Haripur', 'City', 0, 'Kale', GETDATE()),
('Haripurwa', 'City', 0, 'Kale', GETDATE()),
('Hariwan', 'City', 0, 'Kale', GETDATE()),
('Ilam', 'City', 0, 'Kale', GETDATE()),
('Ishnath', 'City', 0, 'Kale', GETDATE()),
('Jaimini', 'City', 0, 'Kale', GETDATE()),
('Kabilasi', 'City', 0, 'Kale', GETDATE()),
('Kalika', 'City', 0, 'Kale', GETDATE()),
('Kalyanpur', 'City', 0, 'Kale', GETDATE()),
('Kamala', 'City', 0, 'Kale', GETDATE()),
('Kanchanrup', 'City', 0, 'Kale', GETDATE()),
('Kankai', 'City', 0, 'Kale', GETDATE()),
('Karjanha', 'City', 0, 'Kale', GETDATE()),
('Katahariya', 'City', 0, 'Kale', GETDATE()),
('Khadak', 'City', 0, 'Kale', GETDATE()),
('Khandbari', 'City', 0, 'Kale', GETDATE()),
('Kolhabi', 'City', 0, 'Kale', GETDATE()),
('Kushma', 'City', 0, 'Kale', GETDATE()),
('Lamahi', 'City', 0, 'Kale', GETDATE()),
('Lekbeshi', 'City', 0, 'Kale', GETDATE()),
('Letang Bhogateni', 'City', 0, 'Kale', GETDATE()),
('Loharpatti', 'City', 0, 'Kale', GETDATE()),
('Madhav Narayan', 'City', 0, 'Kale', GETDATE()),
('Madhuwan', 'City', 0, 'Kale', GETDATE()),
('Madi', 'City', 0, 'Kale', GETDATE()),
('Mahakali', 'City', 0, 'Kale', GETDATE()),
('Mai', 'City', 0, 'Kale', GETDATE()),
('Malangwa', 'City', 0, 'Kale', GETDATE()),
('Manara Shiswa', 'City', 0, 'Kale', GETDATE()),
('Mandandeupur', 'City', 0, 'Kale', GETDATE()),
('Mangalsen', 'City', 0, 'Kale', GETDATE()),
('Manthali', 'City', 0, 'Kale', GETDATE()),
('Matihani', 'City', 0, 'Kale', GETDATE()),
('Maulapur', 'City', 0, 'Kale', GETDATE()),
('Melamchi', 'City', 0, 'Kale', GETDATE()),
('Mithila', 'City', 0, 'Kale', GETDATE()),
('Mithila Bihari', 'City', 0, 'Kale', GETDATE()),
('Musikot', 'City', 0, 'Kale', GETDATE()),
('Musikot', 'City', 0, 'Kale', GETDATE()),
('Nagarain', 'City', 0, 'Kale', GETDATE()),
('Nalgad', 'City', 0, 'Kale', GETDATE()),
('Namobuddha', 'City', 0, 'Kale', GETDATE()),
('Narayan', 'City', 0, 'Kale', GETDATE()),
('Nijgadh', 'City', 0, 'Kale', GETDATE()),
('Pacharauta', 'City', 0, 'Kale', GETDATE()),
('Palungtar', 'City', 0, 'Kale', GETDATE()),
('Panchadewal Binayak', 'City', 0, 'Kale', GETDATE()),
('Panchapuri', 'City', 0, 'Kale', GETDATE()),
('Panchkhal', 'City', 0, 'Kale', GETDATE()),
('Paroha', 'City', 0, 'Kale', GETDATE()),
('Parsagadhi', 'City', 0, 'Kale', GETDATE()),
('Parshuram', 'City', 0, 'Kale', GETDATE()),
('Patan', 'City', 0, 'Kale', GETDATE()),
('Paunauti', 'City', 0, 'Kale', GETDATE()),
('Phatuwa Bijayapur', 'City', 0, 'Kale', GETDATE()),
('Phidim', 'City', 0, 'Kale', GETDATE()),
('Pokhariya', 'City', 0, 'Kale', GETDATE()),
('Purchaudi', 'City', 0, 'Kale', GETDATE()),
('Putalibazar', 'City', 0, 'Kale', GETDATE()),
('Pyuthan', 'City', 0, 'Kale', GETDATE()),
('Rajdevi', 'City', 0, 'Kale', GETDATE()),
('Rajpur', 'City', 0, 'Kale', GETDATE()),
('Ramechhap', 'City', 0, 'Kale', GETDATE()),
('Ramgopalpur', 'City', 0, 'Kale', GETDATE()),
('Rampur', 'City', 0, 'Kale', GETDATE()),
('Resunga', 'City', 0, 'Kale', GETDATE()),
('Rolpa', 'City', 0, 'Kale', GETDATE()),
('Rupakot Majhuwagadhi', 'City', 0, 'Kale', GETDATE()),
('Sabaila', 'City', 0, 'Kale', GETDATE()),
('Sandhikharka', 'City', 0, 'Kale', GETDATE()),
('Sanphebagar', 'City', 0, 'Kale', GETDATE()),
('Shaarda', 'City', 0, 'Kale', GETDATE()),
('Shadanand', 'City', 0, 'Kale', GETDATE()),
('Shahidnagar', 'City', 0, 'Kale', GETDATE()),
('Shambhunath', 'City', 0, 'Kale', GETDATE()),
('Shankharapur', 'City', 0, 'Kale', GETDATE()),
('Shikhar', 'City', 0, 'Kale', GETDATE()),
('Shuklagandaki', 'City', 0, 'Kale', GETDATE()),
('Shuklaphanta', 'City', 0, 'Kale', GETDATE()),
('Siddhicharan', 'City', 0, 'Kale', GETDATE()),
('Simraungadh', 'City', 0, 'Kale', GETDATE()),
('Sitganga', 'City', 0, 'Kale', GETDATE()),
('Sukhipur', 'City', 0, 'Kale', GETDATE()),
('Sundarbazar', 'City', 0, 'Kale', GETDATE()),
('Surunga', 'City', 0, 'Kale', GETDATE()),
('Swargadwari', 'City', 0, 'Kale', GETDATE()),
('Taplejung(Phungling)', 'City', 0, 'Kale', GETDATE()),
('Thaha', 'City', 0, 'Kale', GETDATE()),
('Thakurbaba', 'City', 0, 'Kale', GETDATE());



  --https://en.wikipedia.org/wiki/List_of_cities_in_Nepal#Map
  ALTER TABLE tbl_VehicleDetail
DROP COLUMN Price;

 ALTER TABLE tbl_VehicleDetail
ADD Detail Varchar(500);
 ALTER TABLE tbl_VehicleDetail
ADD Price Varchar(10);

--Multiple Insert
 INSERT INTO tbl_VehicleDetail
  (
	  [VehicleType],
	  [Rating],
	  [Title],
	  [TotalPrice],
	  [CreatedBy],
	  [CreatedDate],
	  [IsAvailable]
  )
VALUES
  ('Car', '3', 'SUV','1200','SHINIGAMI',GETDATE(),1),
  ('Car', '5', '4X4','1300','SHINIGAMI',GETDATE(),1),
  ('Car', '5', 'BMW','1300','SHINIGAMI',GETDATE(),1)