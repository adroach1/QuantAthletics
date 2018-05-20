USE [QA_DEV]
GO

/****** Object: Table [dbo].[AthleteAccount] Script Date: 6/15/2017 8:47:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AthleteAccount] (
    [Id]          INT           NOT NULL,
    [UserId]      INT           NULL,
    [ADPId]       INT           NULL,
    [ADPUsername] VARCHAR (150) NULL,
    [ADPAuthId]   VARCHAR (500) NULL
);


