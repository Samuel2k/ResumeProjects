USE DvdLibrary
GO

CREATE LOGIN DvdLibraryApp WITH PASSWORD='testing123'
GO

/*Set it to use DVD Library Database*/
CREATE USER DvdLibraryAppUser FOR LOGIN DvdLibraryApp
GO
/*Grant permissions to SELECT, INSERT, UPDATE & DELTE all used tables*/
GRANT SELECT ON Dvds TO DvdLibraryAppUser
GRANT INSERT ON Dvds TO DvdLibraryAppUser
GRANT UPDATE ON Dvds TO DvdLibraryAppUser
GRANT DELETE ON Dvds TO DvdLibraryAppUser
GO