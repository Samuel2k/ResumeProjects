/*Should sort list of titles by Id*/
USE DvdLibrary
GO

CREATE PROCEDURE SelectAll 
AS
	SELECT DvdId, Title, Director, RealeaseYear, Rating, Notes
	FROM Dvds
GO

CREATE PROCEDURE CreateNew (@Title NVARCHAR(40), @RealeaseYear VARCHAR(4), @Director NVARCHAR(60), @Rating NVARCHAR(5), @Notes NVARCHAR(100))
AS
	INSERT INTO [Dvds] (Title, Director, RealeaseYear, Rating, Notes) 
	VALUES (@Title, @Director, @RealeaseYear, @Rating, @Notes)
GO

CREATE PROCEDURE DeleteFrom (@DvdId INT)
AS
	DELETE FROM [Dvds] WHERE DvdId = @DvdId
GO

CREATE PROCEDURE UpdateThis (@DvdId INT, @Title NVARCHAR(40), @RealeaseYear VARCHAR(4), @Director NVARCHAR(60), @Rating NVARCHAR(5), @Notes NVARCHAR(100))
AS
	UPDATE [Dvds] 
	SET Title = @Title, Director = @Director, RealeaseYear = @RealeaseYear, Rating = @Rating, Notes = @Notes
	WHERE DvdId = @DvdId
GO