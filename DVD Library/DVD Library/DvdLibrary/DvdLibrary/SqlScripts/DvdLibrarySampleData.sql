USE DvdLibrary
GO

SET IDENTITY_INSERT Dvds ON

INSERT INTO Dvds (DvdId, Title, RealeaseYear, Director, Rating, Notes) VALUES
(0, 'Test Title 1', 1996, 'Jane Doe', 'G', 'Shush you.'),
(1, 'Test Title 2', 1996, 'Johnathan', 'PG-13', 'Lemons.'),
(2, 'Test Entry 3', 2040, 'Jane Doe', 'PG-13', 'Ironing board.')