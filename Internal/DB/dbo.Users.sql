USE [QA_DEV]
GO

/****** Object: Table [dbo].[Users] Script Date: 6/15/2017 8:46:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users] (
    [Id]               INT           NOT NULL,
    [Username]         VARCHAR (50)  NULL,
    [EmailAddress]     VARCHAR (150) NULL,
    [PasswordHash]     VARCHAR (150) NULL,
    [FirstName]        VARCHAR (150) NULL,
    [LastName]         VARCHAR (150) NULL,
    [DateLastModified] DATETIME      NULL,
    [TempSessionId]    VARCHAR (150) NULL
);


