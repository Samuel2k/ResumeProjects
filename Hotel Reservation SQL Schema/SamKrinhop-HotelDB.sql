USE [master];
GO

IF exists (SELECT * FROM sys.databases WHERE NAME = N'Hotel')
BEGIN
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'Hotel';
	ALTER DATABASE Hotel SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE Hotel;
END

CREATE DATABASE Hotel;

USE Hotel;
GO

CREATE TABLE Guests (
	GuestId INT PRIMARY KEY IDENTITY NOT NULL,
	GuestName NVARCHAR(60) NOT NULL,
	City NVARCHAR(20) NOT NULL,
	State NVARCHAR(15) NOT NULL,
	Zip INT NOT NULL,
	Phone NVARCHAR(15) NOT NULL,
	Address NVARCHAR(60) NOT NULL
);

CREATE TABLE Rooms (
	RoomNumber INT IDENTITY PRIMARY KEY NOT NULL,
	RoomType NVARCHAR (10) NOT NULL,
	Amenities NVARCHAR(50) NOT NULL,
	ADAaccessability BIT NOT NULL,
	StandardOccupancy INT NOT NULL,
	MaxOccupancy TINYINT NOT NULL,
	BasePrice DECIMAL NOT NULL,
	ExtraPerson DECIMAL NULL
);

CREATE TABLE Reservations (
	ReservationId INT IDENTITY PRIMARY KEY NOT NULL,
	GuestId INT FOREIGN KEY REFERENCES Guests(GuestId),
	Adults TINYINT NOT NULL,
	Children TINYINT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalRoomCost DECIMAL NOT NULL
);

CREATE TABLE RoomsReservations (
	ReservationId INT FOREIGN KEY REFERENCES Reservations(ReservationId),
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber)
);