INSERT INTO Customers(UserId,CompanyName)
VALUES
	('1','Lavish'),
	('2','Emerald'),
	('3','Imperial'),
	('4','Endeavor'),
	('5','Domain');

INSERT INTO Users(Id,FirstName,LastName,Email,Password)
VALUES
	('1','Serap','Akbaş','serapakbas@gmail.com','12345'),
	('2','Coşkun','Alan','coskunalan@gmail.com','678910'),
	('3','İrem','Algor','iremalgor@gmail.com','23456'),
	('4','Şevket','Akın','sevketakin@gmail.com','34567'),
	('5','Halil','Adahan','haliladahan@gmail.com','45678');

INSERT INTO Rentals(Id, CarId, CustomerId, RentDate, ReturnDate)
VALUES
	('1','1','3','01.10.2021','08.10.2021'),
	('2','2','4','12.02.2021','19.02.2021'),
	('3','4','5','07.01.2021','14.01.2021'),
	('4','3','1','22.12.2020','25.12.2020'),
	('5','5','2','24.11.2020','27.11.2020');