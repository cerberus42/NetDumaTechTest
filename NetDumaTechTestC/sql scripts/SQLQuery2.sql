CREATE TABLE Contact_Info(
	Contact_ID INT IDENTITY(1,1) PRIMARY KEY ,
	First_Name nchar (30) NULL,
	Other_Name nchar (30)NULL, 
	Email nchar (30)NULL,
	Telephone nchar (30)NULL,
	Street nchar(30)NULL,
	Town nchar(30)NULL,
	Country nchar(30)NULL

)