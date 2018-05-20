CREATE TABLE [dbo].[AthleteAccount]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[UserId] INT,
	[ADPId] INT,
	[ADPUsername] varchar(150),
	[ADPAuthId] varchar(500)
)
