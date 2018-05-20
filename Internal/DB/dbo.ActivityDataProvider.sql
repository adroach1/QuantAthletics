USE [QA_DEV]
GO

/****** Object: Table [dbo].[ActivityDataProvider] Script Date: 6/15/2017 8:47:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ActivityDataProvider] (
    [Id]             INT           NOT NULL,
    [Name]           VARCHAR (150) NULL,
    [GrantAccessUrl] VARCHAR (500) NULL,
    [Discriminator]  VARCHAR (128) NULL
);


