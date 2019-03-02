CREATE TABLE dbo.UsersToken(
	UserID varchar(20) NOT NULL,
	AccessKey varchar(32) NOT NULL,
	CONSTRAINT PK_Clientes PRIMARY KEY (UserID)
)
GO

