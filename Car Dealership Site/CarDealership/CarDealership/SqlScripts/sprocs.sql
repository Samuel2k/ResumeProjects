USE GuildCars
GO

/*User & Role*/
CREATE PROCEDURE RetrieveAllUsers
AS
SELECT *
FROM AspNetUsers
GO

CREATE PROCEDURE RetrieveAllRoles
AS
SELECT *
FROM AspNetRoles
GO

CREATE PROCEDURE RetrieveAllUserRoles
AS
SELECT *
FROM AspNetUserRoles
GO

/*Contacts*/
CREATE PROCEDURE RetrieveAllContacts
AS
SELECT *
FROM Contacts
GO

CREATE PROCEDURE CreateContact(
							   @Email NVARCHAR(40),
							   @Name NVARCHAR(60),
							   @Message NVARCHAR(500),
							   @Phone NVARCHAR(15))
AS
	INSERT INTO [Contacts] (Email, Name, Message, Phone)
	VALUES (@Email, @Name, @Message, @Phone)
GO

/*Vehicles*/
USE GuildCars
GO
CREATE PROCEDURE VehicleSearch (@minPrice INT,
								@maxPrice INT,
								@minYear INT,
								@maxYear INT,
								@searchTerm NVARCHAR(20))
AS
	SELECT ModelYear, MakeName, ModelName, VehicleId, BodyStyleId, Transmission, Picture, Type, ColorId, InteriorId, Mileage, VIN, Price, MSRP, Vehicles.ModelId
	FROM Vehicles
	JOIN Models ON Vehicles.ModelId = Models.ModelId
	JOIN Makes ON Models.MakeId = Makes.MakeId

	WHERE (Price >= @minPrice) AND (Price <= @maxPrice) AND (ModelYear >= @minYear) AND (ModelYear <= @maxYear) AND (ModelYear LIKE '%'+@searchTerm+'%' OR MakeName LIKE '%'+@searchTerm+'%' OR ModelName LIKE '%'+@searchTerm+'%')
GO

CREATE PROCEDURE RetrieveAllVehicles
AS
	SELECT *
	FROM Vehicles
GO

CREATE PROCEDURE CreateVehicle (@Type NVARCHAR(4),
								@Transmission NVARCHAR(15),
								@Mileage INT,
								@VIN VARCHAR(17),
								@MSRP DECIMAL,
								@Price DECIMAL,
								@Description NVARCHAR(250),
								@DateCreated NVARCHAR(10),
								@Picture NVARCHAR(250),
								@Featured BIT,

								@ModelId INT,
								@BodyStyleId INT,
								@ColorId INT,
								@InteriorId INT,
								@UserId NVARCHAR(128))
AS
	INSERT INTO [Vehicles] (Type, Transmission, Mileage, VIN, MSRP, Price, Description, DateCreated, Picture, Featured, ModelId, BodyStyleId, ColorId, InteriorId, UserId)
	VALUES (@Type, @Transmission, @Mileage, @VIN, @MSRP, @Price, @Description, @DateCreated, @Picture, @Featured, @ModelId, @BodyStyleId, @ColorId, @InteriorId, @UserId)
GO

CREATE PROCEDURE DeleteVehicle (@VehicleId INT)
AS
	DELETE FROM [Vehicles] WHERE VehicleId = @VehicleId
GO

CREATE PROCEDURE UpdateVehicle (@VehicleId INT,
								@Type NVARCHAR(4),
								@Transmission NVARCHAR(15),
								@Mileage INT,
								@VIN VARCHAR(17),
								@MSRP DECIMAL,
								@Price DECIMAL,
								@Description NVARCHAR(250),
								@DateCreated NVARCHAR(10),
								@Picture NVARCHAR(250),
								@Featured BIT,

								@ModelId INT,
								@BodyStyleId INT,
								@ColorId INT,
								@InteriorId INT,
								@UserId NVARCHAR(128))
AS
	UPDATE [Vehicles] 
	SET Type = @Type, 
		Transmission = @Transmission, 
		Mileage = @Mileage,
		VIN = @VIN,
		MSRP = @MSRP,
		Price = @Price,
		Description = @Description, 
		DateCreated = @DateCreated,
		Picture = @Picture,
		Featured = @Featured,
		ModelId = @ModelId,
		BodyStyleId = @BodyStyleId,
		ColorId = @ColorId,
		InteriorId = @InteriorId,
		UserId = @UserId
	WHERE VehicleId = @VehicleId 
GO

/*Purchases*/
CREATE PROCEDURE RetrieveAllPurchases
AS
	SELECT *
	FROM Purchases
GO

CREATE PROCEDURE CreatePurchase (
								 @VehicleId INT,
								 @PurchasePrice DECIMAL,
								 @PurchaseType NVARCHAR(15),
								 @Name NVARCHAR(60),
								 @PhoneNumber NVARCHAR(15),
								 @Email NVARCHAR(40),
								 @Street1 NVARCHAR(30),
								 @Street2 NVARCHAR(30),
								 @City NVARCHAR(50),
								 @ZipCode NVARCHAR (5),
								 @StateAbbreviation VARCHAR(2),
								 @DateCreated NVARCHAR(10),
								 @UserId NVARCHAR(128))
AS
	INSERT INTO [Purchases] (VehicleId, PurchasePrice, PurchaseType, Name, PhoneNumber, Email, Street1, Street2, City, ZipCode, StateAbbreviation, DateCreated, UserId)
	VALUES (@VehicleId, @PurchasePrice, @PurchaseType, @Name, @PhoneNumber, @Email, @Street1, @Street2, @City, @ZipCode, @StateAbbreviation, @DateCreated, @UserId)
GO

/*Model*/
CREATE PROCEDURE RetrieveAllModels
AS
	SELECT *
	FROM Models
GO

CREATE PROCEDURE CreateModel (
							  @ModelName NVARCHAR(55),
							  @ModelYear NVARCHAR(4),
							  @DateCreated DATE,
							  @MakeId INT,
							  @UserId NVARCHAR(128))
AS
	INSERT INTO [Models] ( ModelName, ModelYear, DateCreated, MakeId, UserId)
	VALUES ( @ModelName, @ModelYear, @DateCreated, @MakeId, @UserId)
GO

/*Make*/
CREATE PROCEDURE RetrieveAllMakes
AS
	SELECT *
	FROM Makes
GO

CREATE PROCEDURE CreateMake (
							 @MakeName NVARCHAR(20),
							 @DateCreated DATE,
							 @UserId NVARCHAR(128))
AS
	INSERT INTO [Makes] ( MakeName, DateCreated, UserId)
	VALUES ( @MakeName, @DateCreated, @UserId)
GO

/*Specials*/
CREATE PROCEDURE CreateSpecial (
							 @SpecialTitle NVARCHAR(30),
							 @SpecialDescription NVARCHAR(500))
AS
INSERT INTO [Specials] ( SpecialTitle, SpecialDescription)
	VALUES ( @SpecialTitle, @SpecialDescription)
GO

CREATE PROCEDURE RetrieveAllSpecials
AS
	SELECT *
	FROM Specials
GO

CREATE PROCEDURE DeleteSpecial (@SpecialId INT)
AS
	DELETE FROM [Specials] WHERE SpecialId = @SpecialId
GO

/*BodyStyle, Color, Interior*/
CREATE PROCEDURE RetrieveAllBodyStyles
AS
	SELECT *
	FROM BodyStyles
GO

CREATE PROCEDURE RetrieveAllColors
AS
	SELECT *
	FROM Colors
GO

CREATE PROCEDURE RetrieveAllInteriors
AS
	SELECT *
	FROM Interiors
GO