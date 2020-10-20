USE GuildCars
GO

SET IDENTITY_INSERT Specials ON

INSERT INTO Specials (SpecialId, SpecialTitle, SpecialDescription) VALUES
(0, 'BIG MONEY, BIG PRIZES', 'I LLLOVE IT!'),
(1, 'Save a dollar', 'Save a dollar on stuff today.'),
(2, 'John Shoemaker Charity', 'Help us raise money for the John Shoemaker childrens cobbler fund! 5% of each purchase goes to making a child in need a shoe.')

SET IDENTITY_INSERT Specials OFF

/*Insert into user as well*/
INSERT INTO AspNetRoles (Id, Name) VALUES
('A', 'Sales'),
('B', 'Admin')

USE GuildCars
GO

INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES
('21bfa463-552e-4750-ab4d-7fb1cf2539a4', 'A'),
('76c17ab7-e079-42b4-83ba-72d39154477c', 'B')

SET IDENTITY_INSERT Makes ON

INSERT INTO Makes (MakeId, MakeName, DateCreated, UserId) VALUES
(0, 'Spaghetti', '10/12/12', '76c17ab7-e079-42b4-83ba-72d39154477c'),
(1, 'Rockefeller', '3/3/03', '76c17ab7-e079-42b4-83ba-72d39154477c'),
(2, 'MaidenIron', '4/4/04', '76c17ab7-e079-42b4-83ba-72d39154477c')

SET IDENTITY_INSERT Makes OFF

SET IDENTITY_INSERT Models ON

INSERT INTO Models (ModelId, ModelName, ModelYear, DateCreated, MakeId, UserId) VALUES
(0, 'X9', '2010', '1/2/03', 0, '76c17ab7-e079-42b4-83ba-72d39154477c'),
(1, 'EE', '2006', '2/3/04', 1, '76c17ab7-e079-42b4-83ba-72d39154477c'),
(2, 'SQ', '2019', '3/4/05', 2, '76c17ab7-e079-42b4-83ba-72d39154477c')

SET IDENTITY_INSERT Models OFF

SET IDENTITY_INSERT Colors ON

INSERT INTO Colors (ColorId, ColorName) VALUES
(0, 'Purple'),
(1, 'Green'),
(2, 'Blue'),
(3, 'Aqua'),
(4, 'Navy')

SET IDENTITY_INSERT Colors OFF

SET IDENTITY_INSERT BodyStyles ON

INSERT INTO BodyStyles (BodyStyleId, BodyStyleName) VALUES
(0, 'Truck'),
(1, 'Car'),
(2, 'SUV'),
(3, 'Van')

SET IDENTITY_INSERT BodyStyles OFF

SET IDENTITY_INSERT Interiors ON

INSERT INTO Interiors (InteriorId, InteriorName) VALUES
(0, 'Red Leather'),
(1, 'Periwinkle w/ Steel Roll Cage'),
(2, 'Carpeted Ceiling')

SET IDENTITY_INSERT Interiors OFF

SET IDENTITY_INSERT Vehicles ON

INSERT INTO Vehicles (VehicleId, Type, Transmission, Mileage, VIN, MSRP, Price, Description, DateCreated, Picture, ModelId, BodyStyleId, ColorId, InteriorId, UserId, Featured) VALUES
(0, 'Used', 'Automatic', 2500, '1a1a1a1a1a1a1a1a1', 35000, 30000, 'A car. Its pretty cool. Please buy it.', '1/1/11', '/Pictures/BlackTruck.jpg', 0, 0, 0, 0, '76c17ab7-e079-42b4-83ba-72d39154477c', 0),
(1, 'New', 'Automatic', 2, '2b2b2b2b2b2b2b2b2', 44000, 34000, 'A car. Haha.', '2/2/12', '/Pictures/RedSUV.jpg', 1, 1, 1, 1, '76c17ab7-e079-42b4-83ba-72d39154477c', 1),
(2, 'Used', 'Automatic', 212600, '3c3c3c3c3c3c3c3c3', 13000, 1000, 'Is this even used?',' 3/3/13', '/Pictures/YellowSedan.png', 2, 2, 2, 2, '76c17ab7-e079-42b4-83ba-72d39154477c', 0)

SET IDENTITY_INSERT Vehicles OFF

SET IDENTITY_INSERT Purchases ON

INSERT INTO Purchases (PurchaseId, VehicleId, PurchasePrice, PurchaseType, Name, PhoneNumber, Email, Street1, Street2, City, ZipCode, StateAbbreviation, DateCreated, UserId) VALUES
(0, 0, 30000, 'Dealer Finance', 'Fredrick Johnson', '999-888-7777', 'FredJ@place.place', 'Shoemaker Ave', '', 'Woodcity', '12345', 'XX', '1/1/01', '21bfa463-552e-4750-ab4d-7fb1cf2539a4'), 
(1, 1, 56000, 'Out-of-pocket', 'Mary Kneeble', '676-123-2345', 'Steamguy@ice.site', 'Bad cheese Bld', 'Apartment 3', 'Iron ville', '98545', 'AC', '3/2/06', '21bfa463-552e-4750-ab4d-7fb1cf2539a4')

SET IDENTITY_INSERT Purchases OFF